---
title: Tích hợp thủ công Aspose.Slides trong chế độ tích hợp SharePoint SSRS 2012
type: docs
weight: 100
url: /vi/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 
Bài viết này hướng dẫn bạn cách tích hợp Aspose.Slides for Reporting Services một cách thủ công trong khái niệm tích hợp SharePoint SSRS 2012. 
{{% /alert %}} 
## **Tích hợp Aspose.Slides với SSRS 2012 trong chế độ tích hợp SharePoint**
Việc cài đặt thủ công ở đây sử dụng DLL thay cho trình cài đặt MSI. 

Chúng tôi khuyến nghị bạn cài đặt sản phẩm bằng trình cài đặt MSI vì nó thực hiện tự động tất cả các quy trình cài đặt và nhiệm vụ cấu hình cần thiết. Tuy nhiên, nếu việc cài đặt tự động bằng MSI thất bại, bạn cần thực hiện các bước sau:

1. Sao chép **Aspose.Slides.ReportingServices.dll** từ thư mục **Universal** sang thư mục **SharePonit RS** bin.
   Trong trường hợp của chúng tôi, đường dẫn là *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin*
1. Cập nhật tệp **rssrvpolicy.config** của Sharepoint (từ thư mục *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) theo cùng cách được mô tả trong bài viết [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/vi/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/).
1. Chạy script này trong Powershell nhưng thay rs_test bằng tên ứng dụng Reporting Services của bạn. 

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

Để biết thêm thông tin về các cmdlet Reporting Service cho SharePoint, hãy đọc [bài viết này của Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).