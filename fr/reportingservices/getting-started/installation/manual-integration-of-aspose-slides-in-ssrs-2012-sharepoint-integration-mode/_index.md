---  
title: Intégration manuelle d'Aspose.Slides dans le mode d'intégration SharePoint de SSRS 2012  
type: docs  
weight: 100  
url: /fr/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/  
---  

{{% alert color="primary" %}}  

Cet article vous apprend comment intégrer manuellement Aspose.Slides pour Reporting Services dans le concept d'intégration SharePoint de SSRS 2012.  

{{% /alert %}}  
## **Intégration d'Aspose.Slides avec SSRS 2012 en mode d'intégration SharePoint**  
L'installation manuelle ici utilise le DLL à la place de l'installateur MSI.  

Nous vous recommandons d'installer le produit en utilisant l'installateur MSI car il exécute automatiquement tous les processus d'installation et les tâches de configuration nécessaires. Cependant, si l'installation automatique avec l'installateur MSI échoue, voici les étapes que vous devez suivre :  

1. Copiez le **Aspose.Slides.ReportingServices.dll** du répertoire **Universal** vers le répertoire bin de **SharePonit RS**.  
   Dans notre cas, c'est *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin*  
1. Mettez à jour le fichier **rssrvpolicy.config** de Sharepoint (du répertoire *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) de la même manière décrite dans l'article [Installation manuelle d'Aspose.Slides pour Reporting Services](https://docs.aspose.com/slides/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/).  
1. Exécutez ce script dans Powershell mais remplacez rs_test par le nom de votre application Reporting Services.  

**rs_test**  

``` xml  
  
  
Write-Host "Ajout des extensions de rendu Aspose.Slides"  

Add-PSSnapIn Microsoft.SharePoint.PowerShell  
  
  
Write-Host "Obtenir le service d'application Reporting Service"  

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

Pour plus d'informations sur les cmdlets Reporting Service pour SharePoint, consultez [cet article Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).