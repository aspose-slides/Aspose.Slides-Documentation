---
title: 從 PDF 或 HTML 匯入 .NET 簡報
linktitle: 匯入簡報
type: docs
weight: 60
url: /zh-hant/net/import-presentation/
keywords:
- 匯入簡報
- 匯入投影片
- 匯入 PDF
- 匯入 HTML
- PDF 轉簡報
- PDF 轉 PPT
- PDF 轉 PPTX
- PDF 轉 ODP
- HTML 轉簡報
- HTML 轉 PPT
- HTML 轉 PPTX
- HTML 轉 ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides，在 .NET 中輕鬆將 PDF 與 HTML 文件匯入 PowerPoint 與 OpenDocument 簡報，實現無縫且高效能的投影片處理。"
---
## **簡介**

使用 Aspose.Slides，您可以從其他格式的檔案匯入簡報。Aspose.Slides 提供 [SlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/) 類別，讓您能夠從 PDF 與 HTML 文件匯入簡報。

## **從 PDF 匯入 PowerPoint**

在此情況下，您可以將 PDF 轉換為 PowerPoint 簡報。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。 
2. 呼叫 [AddFromPdf](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.slidecollection/addfrompdf/methods/1) 方法並傳入 PDF 檔案。 
3. 使用 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.presentation/save/methods/5) 方法以 PowerPoint 格式儲存檔案。

此 C# 程式碼示範 PDF 轉 PowerPoint 的操作：

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 

您可能想要試用 **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/zh-hant/import/pdf-to-powerpoint) 網頁應用程式，因為它即時展示了此處所述的流程。 

{{% /alert %}} 

## **從 HTML 匯入 PowerPoint**

在此情況下，您可以將 HTML 文件轉換為 PowerPoint 簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。 
2. 呼叫 [AddFromHtml](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) 方法並傳入 HTML 檔案。 
3. 使用 [Save](https://apireference.aspose.com/slides/zh-hant/net/aspose.slides.presentation/save/methods/5) 方法將檔案儲存為 PowerPoint 文件。

此 C# 程式碼示範 HTML 轉 PowerPoint 的操作： 

```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**匯入 PDF 時表格會被保留嗎？其偵測是否可以改進？**

匯入過程中可以偵測表格；[PdfImportOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/pdfimportoptions/) 包含 [DetectTables](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/pdfimportoptions/detecttables/) 參數，可啟用表格辨識。其效果取決於 PDF 的結構。

{{% alert title="Note" color="warning" %}} 

您也可以使用 Aspose.Slides 將 HTML 轉換為其他常見檔案格式： 

* [HTML 轉圖像](https://products.aspose.com/slides/zh-hant/net/conversion/html-to-image/)
* [HTML 轉 JPG](https://products.aspose.com/slides/zh-hant/net/conversion/html-to-jpg/)
* [HTML 轉 XML](https://products.aspose.com/slides/zh-hant/net/conversion/html-to-xml/)
* [HTML 轉 TIFF](https://products.aspose.com/slides/zh-hant/net/conversion/html-to-tiff/)

{{% /alert %}}