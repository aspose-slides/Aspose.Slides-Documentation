---
title: Χειροκίνητη ενσωμάτωση του Aspose.Slides σε λειτουργία ενσωμάτωσης SharePoint του SSRS 2012
type: docs
weight: 100
url: /el/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Αυτό το άρθρο σας διδάσκει πώς να ενσωματώσετε το Aspose.Slides for Reporting Services χειροκίνητα στην έννοια ενσωμάτωσης SharePoint του SSRS 2012. 

{{% /alert %}} 
## **Ενσωμάτωση του Aspose.Slides με το SSRS 2012 σε λειτουργία ενσωμάτωσης SharePoint**
Η χειροκίνητη εγκατάσταση εδώ χρησιμοποιεί το DLL αντί για τον εγκαταστάτη MSI. 

Σας συνιστούμε να εγκαταστήσετε το προϊόν χρησιμοποιώντας τον εγκαταστάτη MSI, επειδή εκτελεί αυτόματα όλες τις απαραίτητες διαδικασίες εγκατάστασης και εργασίες διαμόρφωσης. Ωστόσο, εάν η αυτόματη εγκατάσταση με τον εγκαταστάτη MSI αποτύχει, αυτά είναι τα βήματα που πρέπει να ακολουθήσετε:

1. Αντιγράψτε το **Aspose.Slides.ReportingServices.dll** από τον φάκελο **Universal** στον φάκελο **SharePonit RS** bin. Στην περίπτωσή μας, είναι *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
2. Ενημερώστε το αρχείο **rssrvpolicy.config** του Sharepoint (από τον φάκελο *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) με τον ίδιο τρόπο που περιγράφεται στο άρθρο [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/el/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) .
3. Εκτελέστε αυτό το script στο Powershell, αλλά αντικαταστήστε το rs_test με το όνομα της εφαρμογής Reporting Services σας. 

**rs_test**

``` xml



Write-Host "Adding Aspose.Slides rendering extensions"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "Get ReportinService Application Service"

$app = get-sprsserviceapplication



if ($app) {

                $app | ForEach-Object {



                $aspps = Get-SPRSExtension -Identity $_ -Name "ASPPS" -ExtensionType "Render"

                $aspptx = Get-SPRSExtension -Identity $_ -Name "ASPPTX" -ExtensionType "Render"

                $asppsx = Get-SPRSExtension -Identity $_ -Name "ASPPSX" -ExtensionType "Render"

                $asppt = Get-SPRSExtension -Identity $_ -Name "ASPPT" -ExtensionType "Render"



                if (-not $aspps ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPS" -TypeName "Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices" }

                if (-not $aspptx) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPTX" -TypeName "Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"}

                if (-not $asppsx ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPSX" -TypeName "Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"}

                if (-not $asppt ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPT" -TypeName "Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"}

                }

}



```

Για περισσότερες πληροφορίες σχετικά με τα cmdlet του Reporting Service για το SharePoint, διαβάστε [αυτό το άρθρο της Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).