---
title: 在 C++ 中將 PPT 與 PPTX 轉換為 PDF [包含進階功能]
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/cpp/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 PDF
- 簡報轉 PDF
- PPT 轉 PDF
- 將 PPT 轉換為 PDF
- PPTX 轉 PDF
- 將 PPTX 轉換為 PDF
- 將 PowerPoint 儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例與進階轉換選項。"
---
## **概觀**

在 C++ 中將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、對 PDF 檔案設定密碼保護、偵測字型替換、選取特定投影片進行轉換，以及對輸出文件套用合規標準。

## **PowerPoint 轉 PDF 轉換**

* **PPT**
* **PPTX**
* **ODP**

若要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別，然後使用 `Save` 方法將簡報儲存為 PDF。[Presentation] 類別公開了 `Save` 方法，通常用於將簡報轉換為 PDF。

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for C++ 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」並在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意** 您無法指示 Aspose.Slides 更改或移除這些資訊於輸出文件中。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報轉為 PDF
* 從簡報中選取特定投影片轉為 PDF

Aspose.Slides 將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中元素與屬性會精確呈現，包括：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁眉與頁腳
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會嘗試使用最佳設定與最高品質層級將提供的簡報轉換為 PDF。

以下 C++ 程式碼示範如何將簡報 (PPT、PPTX、ODP 等) 轉換為 PDF：

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// 將簡報儲存為 PDF。
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 
Aspose 提供一個免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf) ，示範簡報轉 PDF 的過程。您可以使用此轉換器執行測試，以即時實作此處描述的程序。
{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別下的屬性——讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換程序的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以定義點陣圖影像的首選品質設定、指定如何處理中繪檔、設定文字的壓縮等級、配置影像的 DPI 等。

以下程式碼範例展示如何使用多項自訂選項將 PowerPoint 簡報轉換為 PDF：

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立 PdfOptions 類別實例。
auto pdfOptions = MakeObject<PdfOptions>();

// 設定 JPG 影像的品質。
pdfOptions->set_JpegQuality(90);

// 設定影像的 DPI。
pdfOptions->set_SufficientResolution(300);

// 設定中繪檔的處理方式。
pdfOptions->set_SaveMetafilesAsPng(true);

// 設定文字內容的壓縮等級。
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// 定義 PDF 合規模式。
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 將簡報儲存為 PDF 文件。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **使用隱藏投影片將 PowerPoint 轉換為 PDF**

如果簡報中包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別的 [set_ShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法，將隱藏投影片作為頁面包含在產生的 PDF 中。

此 C++ 程式碼示範如何在 PDF 中包含隱藏投影片：

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 建立 PdfOptions 類別實例。
auto pdfOptions = MakeObject<PdfOptions>();

// 加入隱藏投影片。
pdfOptions->set_ShowHiddenSlides(true);

// 將簡報儲存為 PDF。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

此 C++ 程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 建立 PdfOptions 類別實例。
auto pdfOptions = MakeObject<PdfOptions>();

// 設定 PDF 密碼與存取權限。
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// 將簡報儲存為 PDF。
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **偵測字型替換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別下提供 [set_WarningCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 方法，使您能在簡報轉 PDF 的過程中偵測字型替換。

此 C++ 程式碼示範如何偵測字型替換：

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

// 警告回呼的實作。
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // 在 PDF 選項中設定警告回呼。
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // 將簡報儲存為 PDF。
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 
如需取得渲染過程中字型替換的回呼資訊，請參閱 [Getting Warning Callbacks for Fonts Substitution](/slides/zh-hant/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

如需了解更多字型替換資訊，請參閱 [Font Substitution](/slides/zh-hant/cpp/font-substitution/) 文章。
{{% /alert %}} 

## **將 PowerPoint 中選取的投影片轉換為 PDF**

此 C++ 程式碼示範如何僅將 PowerPoint 簡報中的特定投影片轉換為 PDF：

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 設定投影片編號的陣列。
auto slides = MakeArray<int32_t>({ 1, 3 });

// 將簡報儲存為 PDF。
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **使用自訂投影片大小將 PowerPoint 轉換為 PDF**

此 C++ 程式碼示範如何以指定的投影片大小將 PowerPoint 簡報轉換為 PDF：

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 建立一個具有調整後投影片尺寸的新簡報。
auto resizedPresentation = MakeObject<Presentation>();

// 設定自訂投影片尺寸。
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// 從原始簡報複製第一張投影片。
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// 將調整尺寸後的簡報儲存為含備註的 PDF。
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **以備註投影片檢視將 PowerPoint 轉換為 PDF**

此 C++ 程式碼示範如何將 PowerPoint 簡報轉換為包含備註的 PDF：

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 設定含備註版面的 PDF 選項。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// 將簡報儲存為含備註的 PDF。
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF 的無障礙與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可依以下合規標準匯出 PowerPoint 為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

此 C++ 程式碼示範一個根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides 支援 PDF 轉換操作，允許您將 PDF 檔案轉換為常見格式。您可以執行 [PDF to HTML](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-png/) 轉換。其他針對專業格式的 PDF 轉換操作，如 [PDF to SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-tiff/)、以及 [PDF to XML](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-xml/) 亦受到支援。
{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標示為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

### 我可以一次大量將多個 PowerPoint 檔案轉換為 PDF 嗎？

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以程式化地遍歷檔案並套用轉換程序。

### 是否可以對轉換後的 PDF 設定密碼保護？

絕對可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別在轉換過程中設定密碼與存取權限。

### 如何在 PDF 中包含隱藏投影片？

在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別中使用 `set_ShowHiddenSlides` 方法，即可將隱藏投影片納入產生的 PDF。

### Aspose.Slides 能否在 PDF 中保持高影像品質？

可以。您可透過 `set_JpegQuality`、`set_SufficientResolution` 等方法於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別中控制影像品質，確保 PDF 中的影像高品質。

### Aspose.Slides 是否支援 PDF/A 合規標準？

是的，Aspose.Slides 允許您匯出符合 PDF/A1a、PDF/A1b 與 PDF/UA 等各種標準的 PDF，確保文件符合無障礙與存檔需求。

## **其他資源**

- [Aspose.Slides for C++ 文件](/slides/zh-hant/cpp/)
- [Aspose.Slides for C++ API 參考]https://reference.aspose.com/slides/zh-hant/cpp/
- [Aspose 免費線上轉換工具]https://products.aspose.app/slides/zh-hant/conversion