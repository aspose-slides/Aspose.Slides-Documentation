---
title: 在 C++ 中將 PPT 和 PPTX 轉換為 PDF（包含進階功能）
linktitle: PowerPoint 轉 PDF
type: docs
weight: 40
url: /zh-hant/cpp/convert-powerpoint-to-pdf/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 PDF
- 簡報 轉 PDF
- PPT 轉 PDF
- 將 PPT 轉換為 PDF
- PPTX 轉 PDF
- 將 PPTX 轉換為 PDF
- 將 PowerPoint 儲存為 PDF
- 將 PPT 儲存為 PDF
- 將 PPTX 儲存為 PDF
- 匯出 PPT 為 PDF
- 匯出 PPTX 為 PDF
- 附件
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速範例程式碼與進階轉換選項。"
---
## **概述**

在 C++ 中將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 PDF 格式具有多項優勢，包括在不同設備間的相容性以及保留簡報的版面配置和格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、使用密碼保護 PDF 檔案、偵測字型置換、選取特定投影片進行轉換，並套用合規標準於輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別，然後使用 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別公開的 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法通常用於將簡報轉換為 PDF。

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」的形式。**Note** 您無法指示 Aspose.Slides 更改或移除這些資訊於輸出文件中。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份簡報至 PDF
* 只選取簡報的特定投影片至 PDF

Aspose.Slides 匯出簡報為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會精確呈現元素與屬性，包括：

* 圖片
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 標頭與頁腳
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 嘗試以最佳設定及最高品質層級將提供的簡報轉換為 PDF。

以下範例載入一個簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose 提供免費的線上[**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/conversion/ppt-to-pdf)示範簡報轉 PDF 的流程。您可以使用此轉換器執行測試，以即時體驗此處說明的程序。
{{% /alert %}}

## **將 PowerPoint 轉換為 PDF（含選項）**

Aspose.Slides 提供自訂選項（位於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別下的屬性），讓您自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換過程的執行方式。

### **將 PowerPoint 轉換為 PDF（自訂選項）**

使用自訂轉換選項，您可以為點陣圖影像定義偏好的品質設定，指定如何處理中繼檔，設定文字的壓縮等級，配置影像 DPI，等等。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **將嵌入的 OLE 檔案保留為 PDF 附件**

如果簡報中包含嵌入的 Excel 活頁簿，您可能希望 PDF 接收者能存取該活頁簿的資料，同時檢視投影片。呼叫 [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) 並傳入 `true`，即可在產生的 PDF 中保留嵌入的 OLE 檔案作為附件。

預設值為 `false`：OLE 物件的預覽圖像或圖示會在 PDF 頁面上呈現，但其嵌入檔案不會以附件形式加入。將選項設為 `true` 則會額外包含檔案資料。預覽仍為視覺表示；附件讓接收者可另行開啟或儲存嵌入檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入 Excel 活頁簿的簡報，並將其匯出為帶有活頁簿附件的 PDF。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

若要檢查結果：

1. 在支援附件的檢視器（例如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，找到嵌入的活頁簿。
3. 儲存附件並以 Excel 開啟以檢查其資料，或直接在檢視器允許的情況下開啟。PDF 頁面上的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有嚴格限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 僅允許 PDF/A 附件，PDF/A-3 則允許其他檔案類型（包括 Excel 活頁簿）。這些限制屬於標準本身的要求，並非 Aspose.Slides 特有的限制。本範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **將 PowerPoint 轉換為 PDF（含隱藏投影片）**

如果簡報包含隱藏投影片，您可以使用 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法（屬於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別），將隱藏投影片納入產生的 PDF 頁面中。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。存取權限允許列印，包含高品質列印。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **偵測字型置換**

Aspose.Slides 提供位於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別下的 [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 方法，讓您在簡報轉 PDF 的過程中偵測字型置換。

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
如需取得更多字型置換資訊，請參閱[字型置換](/slides/zh-hant/cpp/font-substitution/)文章。
{{% /alert %}} 

### **處理沒有專屬粗體字型的字體**

即使字體本身沒有專屬的粗體字形，簡報仍可能對文字套用粗體格式。此時文字會透過合成粗體（synthetic bolding）方式呈現，即人工加粗常規字形。若合成粗體在 PDF 中顯得過於粗重或與預期外觀不符，可呼叫 [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) 並傳入 `true`。此選項會在 PDF 匯出時將受影響的文字以點陣圖方式呈現，對某些字體可改善其外觀，預設值為 `false`。

範例簡報包含兩個文字方塊：一個為普通文字，另一個對同一字體套用粗體格式，但該字體並無專屬粗體字形。以下範例載入簡報，啟用不支援字體樣式的光柵化，並將其匯出為 PDF：

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

以下預覽顯示停用與啟用的輸出。在此範例中，停用選項時粗體文字的筆劃較粗；啟用選項後筆劃較輕；普通文字則保持不變。請比較結果後再決定簡報的設定。

| 選項停用 (`false`，預設) | 選項啟用 (`true`) |
|---|---|
| ![PDF（未啟用不支援字型樣式光柵化）](unsupported-bold-disabled.png) | ![PDF（已啟用不支援字型樣式光柵化）](unsupported-bold-enabled.png) |

在此範例中，啟用選項僅將粗體文字轉為點陣圖：它無法被選取、複製或以非 OCR 方式搜尋，且在 800% 放大時邊緣較為柔和。普通文字仍可搜尋。停用選項時，兩段文字皆保持文字形式。

此選項會在字體沒有專屬粗體字形時，將粗體文字光柵化。[字型置換](/slides/zh-hant/cpp/font-substitution/) 則會在原字體不可用時選擇其他字體。

## **將選取的投影片從 PowerPoint 轉換為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。此陣列中的投影片編號為一基制，且輸入的簡報必須至少包含三張投影片。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **將 PowerPoint 轉換為 PDF（自訂投影片尺寸）**

以下範例將簡報的第一張投影片複製到新簡報，並將投影片尺寸設為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以適應尺寸，並將單一投影片匯出為 PDF。

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **將 PowerPoint 轉換為 PDF（備註投影片檢視）**

以下範例將簡報匯出為 PDF，將每張投影片的講者備註置於投影片下方。請使用包含講者備註的簡報以查看結果。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **PDF 的無障礙與合規標準**

Aspose.Slides 允許您使用符合[Web 內容無障礙指引 (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)的轉換程序。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下 C++ 程式碼示範一個根據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 轉換流程：

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides 支援 PDF 轉換作業，讓您可將 PDF 檔案轉換為常見格式。您可以執行[PDF 轉 HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF 轉 image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)、以及[PDF 轉 PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/)的轉換。其他針對特殊格式的 PDF 轉換作業——[PDF 轉 SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、與[PDF 轉 XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)——亦受到支援。
{{% /alert %}}

> **Note:** When exporting to PDF/UA, Aspose.Slides treats complex graphics such as SmartArt, charts, and formulas as a single figure. Individual path elements are not preserved as separate content and may be marked as artifacts; alternative text is provided only for the whole figure.

## **FAQ**

**Can I convert multiple PowerPoint files to PDF in bulk?**

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以以程式方式遍歷檔案並套用轉換程序。

**Is it possible to password-protect the converted PDF?**

是的。使用 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**How do I include hidden slides in the PDF?**

使用 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法（位於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別）即可將隱藏投影片納入產生的 PDF。

**Can Aspose.Slides maintain high image quality in the PDF?**

可以，您可以透過 [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) 與 [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) 方法（屬於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別）控制影像品質，確保 PDF 中的圖片保持高質量。

**Does Aspose.Slides support PDF/A compliance standards?**

是的，Aspose.Slides 允許您匯出符合各種標準的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保文件符合無障礙與保存需求。

## **Additional Resources**

- [Aspose.Slides for C++ Documentation](/slides/zh-hant/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)