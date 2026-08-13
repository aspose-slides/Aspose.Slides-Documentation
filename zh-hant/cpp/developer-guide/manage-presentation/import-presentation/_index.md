---
title: 在 C++ 中從 PDF 或 HTML 匯入簡報
linktitle: 匯入簡報
type: docs
weight: 60
url: /zh-hant/cpp/import-presentation/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides，輕鬆在 C++ 中將 PDF 與 HTML 文件匯入 PowerPoint 和 OpenDocument 簡報，實現無縫且高效能的投影片處理。"
---
## **簡介**

使用 [**Aspose.Slides for C++**](https://products.aspose.com/slides/zh-hant/cpp/)，您可以從其他格式的檔案匯入簡報。Aspose.Slides 提供 [SlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.slide_collection) 類別，允許您從 PDF、HTML 文件等匯入簡報。

## **從 PDF 匯入 PowerPoint**

在此情況下，您可以將 PDF 轉換為 PowerPoint 簡報。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 實例化 Presentation 類別的物件。 
2. 呼叫 [AddFromPdf()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) 方法並傳入 PDF 檔案。 
3. 使用 [Save()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法將檔案儲存為 PowerPoint 格式。

以下 C++ 程式碼示範 PDF 轉換為 PowerPoint 的操作：

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 
您可能想要檢視 **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/zh-hant/import/pdf-to-powerpoint) 網路應用程式，因為它即是此處所述流程的即時實作。 
{{% /alert %}} 

## **從 HTML 匯入 PowerPoint**

在此情況下，您可以將 HTML 文件轉換為 PowerPoint 簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別的實例。 
2. 呼叫 [AddFromHtml()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) 方法並傳入 HTML 檔案。 
3. 使用 [Save()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法將檔案儲存為 PowerPoint 格式。

以下 C++ 程式碼示範 HTML 轉換為 PowerPoint 的操作：

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
您也可以使用 Aspose.Slides 將 HTML 轉換為其他常見檔案格式： 

* [HTML to image](https://products.aspose.com/slides/zh-hant/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/zh-hant/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/zh-hant/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **常見問題**

### 匯入 PDF 時表格是否會被保留下來，且其偵測能否改善？

在匯入過程中可偵測表格；[PdfImportOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.import/pdfimportoptions/) 包含一個 [set_DetectTables](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) 方法，可啟用表格辨識。其效果取決於 PDF 的結構。