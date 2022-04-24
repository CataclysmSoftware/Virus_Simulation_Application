function rez = evalSpline(x,c,t)
% Calculeza valorile cubicei spline
% input:    - x = nodurile
%           - c = coeficientii spline
%           - t = punctele pe care le evaluam

n = length(x);
x = x(:); 
t = t(:);
k = ones(size(t));
for j = 2:n-1
    k(x(j) <= t) = j;
end
% interpolant evaluation
s = t - x(k);
rez = c(k,4) + s.*(c(k,3) + s.*(c(k,2) + s.*c(k,1)));

end

