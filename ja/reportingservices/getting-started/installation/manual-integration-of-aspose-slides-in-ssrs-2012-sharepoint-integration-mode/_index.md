---
title: SSRS 2012 SharePoint統合モードでのAspose.Slidesの手動統合
type: docs
weight: 100
url: /ja/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---

{{% alert color="primary" %}} 

この記事では、SSRS 2012 SharePoint統合概念におけるAspose.Slides for Reporting Servicesの手動統合方法を説明します。

{{% /alert %}} 
## **SharePoint統合モードでのSSRS 2012とのAspose.Slidesの統合**
ここでの手動インストールは、MSIインストーラーの代わりにDLLを使用します。

製品をMSIインストーラーを使ってインストールすることをお勧めします。なぜなら、必要なすべてのインストールプロセスと設定作業が自動的に実行されるからです。ただし、MSIインストーラーを使った自動インストールが失敗した場合、以下のステップに従ってください：

1. **Universal**ディレクトリから**Aspose.Slides.ReportingServices.dll**を**SharePont RS**のbinディレクトリにコピーします。  
   私たちの場合、これは*C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin*です。
2. [Aspose.Slides for Reporting Services手動インストール](https://docs.aspose.com/slides/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/)記事で説明されているのと同じ方法で、SharePointの**rssrvpolicy.config**ファイルを更新します（*C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*ディレクトリから）。
3. PowerShellでこのスクリプトを実行しますが、rs_testを自分のReporting Servicesアプリ名に置き換えます。

**rs_test**

``` xml



Write-Host "Aspose.Slidesレンダリング拡張の追加"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "Reportingサービスアプリケーションの取得"

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

SharePoint向けReportingサービスコマンドレットの詳細については[このMicrosoftの記事](http://technet.microsoft.com/en-us/library/gg492249?ppud=4)をお読みください。