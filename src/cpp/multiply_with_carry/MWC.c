static unsigned long Q[4096],c=362436;
unsigned long CMWC4096(void)
{
	unsigned long long t, a=18782LL;
	static unsigned long i=4095;
	unsigned long x,r=0xfffffffe;
	i=(i+1)&4095;
	t=a*Q[i]+c;
	c=(t>>32); x=t+c; if(x<c){x++;c++;}
	return(Q[i]=r-x);   
}