---
title: 自定义 PowerPoint 渲染扩展标题
type: docs
weight: 60
url: /reportingservices/customizing-powerpoint-rendering-extension-caption/
---

{{% alert color="primary" %}} 

本文将向您展示如何自定义 Aspose.Slides for Reporting Services 的渲染选项标题。

{{% /alert %}} 
## **示例**
安装 Aspose.Slides for Reporting Services 后，导出选项的下拉菜单中会添加 4 个额外的导出选项：

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **如何修改标题文本**
这些扩展的默认标题可以通过覆盖默认名称来更改。以下步骤将展示如何将标题从“ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ”更改为“ **PowerPoint 97 – 2003 format(PPT)** ”。

**步骤 1：** 找到 **rsreportserver.config** 文件，通常位于以下目录：

**OS 根驱动器\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**步骤 2：** 在 rsreportserver.config 文件中找到这些行：

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**步骤 3：** 用以下内容替换扩展参数：

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

导出选项现在将如下所示：

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)