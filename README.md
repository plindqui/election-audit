# election-audit
Facilitating audit of election results using digital ballot images.

In Dane County, Wisconsin they use ES&S DS200 Scanner/Tabulators at polling places to tabulate paper ballots. These devices capture a digital image of each ballot as the voter feeds it into the scanner for tabulation. This application displays these ballot image so that a group of auditors may determine if the images correlate with the outcome of the machine count. We hope to extend this software to accomodate ballot images from other ballot scan devices as sample images become available.

Recently, we added the option to perform a risk limiting audit of county-wide races. This approach seeks to comfirm the correct candidate was awarded the election win, while avoiding the time consuming process of reviewing every ballot image. A random sample of ballots are selected in a transparent fashion and then after tallying, a statistcal assessment is performed to confirm the sample conforms to the machine count victor. If the sample assessment doesn't comport with the machine outcome, a larger sample is tallied and the audit continues. 
