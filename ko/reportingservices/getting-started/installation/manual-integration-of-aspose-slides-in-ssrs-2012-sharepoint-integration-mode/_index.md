---
title: SSRS 2012 SharePoint 통합 모드에서 Aspose.Slides 수동 통합
type: docs
weight: 100
url: /ko/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

이 문서는 SSRS 2012 SharePoint 통합 개념에서 Aspose.Slides for Reporting Services를 수동으로 통합하는 방법을 설명합니다. 

{{% /alert %}} 
## **SSRS 2012와 SharePoint 통합 모드에서 Aspose.Slides 통합**
여기에서 수동 설치는 MSI 설치 프로그램 대신 DLL을 사용합니다. 

제품을 MSI 설치 프로그램을 사용하여 설치하는 것이 좋습니다. MSI 설치 프로그램은 필요한 모든 설치 과정과 구성 작업을 자동으로 수행합니다. 하지만 MSI 설치 프로그램으로 자동 설치가 실패할 경우, 다음 단계들을 따라야 합니다:

1. **Universal** 디렉터리에서 **Aspose.Slides.ReportingServices.dll**를 **SharePonit RS** bin 디렉터리로 복사합니다.  
   우리의 경우, 경로는 *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 입니다. 
1. SharePoint의 **rssrvpolicy.config** 파일을 (*C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* 디렉터리에서) [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/ko/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) 문서에 설명된 동일한 방법으로 업데이트합니다. 
1. PowerShell에서 이 스크립트를 실행하되, rs_test를 실제 Reporting Services 앱 이름으로 바꿉니다. 

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

SharePoint용 Reporting Service cmdlet에 대한 자세한 내용은 [이 Microsoft 기사](http://technet.microsoft.com/en-us/library/gg492249?ppud=4)를 참조하세요.