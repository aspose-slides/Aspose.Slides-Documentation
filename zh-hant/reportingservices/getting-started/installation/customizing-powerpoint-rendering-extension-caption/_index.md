---
title: 自訂 PowerPoint 呈現擴充功能說明文字
type: docs
weight: 60
url: /zh-hant/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 
本文說明如何自訂 Aspose.Slides for Reporting Services 的渲染選項說明文字。 
{{% /alert %}} 
## **範例**
安裝 Aspose.Slides for Reporting Services 後，匯出選項下拉選單中會新增 4 個額外的匯出選項：

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **如何修改說明文字**
這些擴充功能的預設說明文字可透過覆寫預設名稱來變更。以下步驟示範如何將說明文字從 “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” 改為 “ **PowerPoint 97 – 2003 format(PPT)** ”。 

**步驟 1:** 在以下目錄中尋找通常位於的 **rsreportserver.config** 檔案：

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**步驟 2:** 在 rsreportserver.config 檔案中找到以下行：

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**步驟 3:** 用以下內容取代擴充參數：

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

匯出選項現在會顯示如下：

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)