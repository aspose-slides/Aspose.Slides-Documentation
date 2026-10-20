---
title: 在 C++ 中將 PPT 和 PPTX 轉換為 PDF [包含進階功能]
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
- 轉換 PPT 為 PDF
- PPTX 轉 PDF
- 轉換 PPTX 為 PDF
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
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式碼範例與進階轉換選項。"
---
## **概述**

在 C++ 中將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字型替代、選取特定投影片進行轉換，並將合規標準套用於輸出文件。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

若要將簡報轉換為 PDF，將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別，然後使用 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別公開了通常用於將簡報轉換為 PDF 的 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法。

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ 會將其 API 資訊和版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」形式的值。**注意** 您無法指示 Aspose.Slides 更改或移除這些資訊。
{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整份簡報轉為 PDF
* 簡報中的特定投影片轉為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 與原始簡報極為相似。轉換過程中會準確呈現以下元素與屬性：

* 圖片
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉為 PDF**

標準的 PowerPoint 轉 PDF 轉換流程使用預設選項。在此情況下，Aspose.Slides 會嘗試以最佳設定及最高品質水平將提供的簡報轉換為 PDF。

以下範例載入簡報，並使用預設匯出設定將所有可見投影片儲存為 PDF。

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
Aspose 提供一個免費的線上 [**PowerPoint 轉 PDF 轉換工具**](https://products.aspose.app/slides/conversion/ppt-to-pdf) 以示範簡報轉 PDF 的過程。您可以使用此轉換工具執行測試，以即時體驗此處描述的步驟。
{{% /alert %}}

## **使用選項將 PowerPoint 轉為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別下的屬性——讓您可以自訂產生的 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉為 PDF**

使用自訂轉換選項，您可以為點陣圖影像定義偏好的品質設定、指定如何處理中繼檔案、設定文字的壓縮層級、配置影像的 DPI，等等。

以下範例將簡報匯出為 PDF 1.5，JPEG 品質設定為 90，影像解析度設定為 300 DPI，中繼檔案儲存為 PNG，並使用 Flate 文字壓縮。

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

### **自動選取影像壓縮**

當簡報包含大量相片或螢幕擷取圖時，減少匯出 PDF 的檔案大小可讓寄送或下載更為方便。呼叫 [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) 並傳入 `true`，即可在 PDF 匯出期間自動為每張影像選擇最適合的壓縮演算法。

以下範例載入現有簡報，啟用自動影像壓縮選取，並將其儲存為 PDF 文件。其他 PDF 匯出設定則保留預設值。

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

此選項會為每張影像選取壓縮演算法。使用 [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) 降低 JPEG 品質會直接降低 JPEG 影像品質；而使用 [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) 降低解析度則允許影像降採樣至較低解析度，從而減少細節。啟用自動壓縮選取本身不會降低上述任何設定。

選取影像壓縮演算法會需要額外的處理時間與記憶體。大小的減少取決於簡報的影像與匯出設定，無法保證每個簡報皆有固定的縮減幅度。

### **保留嵌入的 OLE 檔案作為 PDF 附件**

如果簡報內嵌了 Excel 活頁簿，您可能希望 PDF 接收者同時能存取該活頁簿的資料以及檢視投影片。呼叫 [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) 並傳入 `true`，即可在產生的 PDF 中保留嵌入的 OLE 檔案作為附件。

預設值為 `false`：OLE 物件的預覽圖片或圖示會在 PDF 頁面上呈現，但其嵌入的檔案不會作為附件加入。將此選項設為 `true` 會額外包含檔案資料。預覽仍然只是視覺呈現；附件則允許接收者單獨開啟或儲存嵌入的檔案。OLE 物件不會在 PDF 頁面上變成可互動的 Excel 工作表。

以下範例載入已包含嵌入 Excel 活頁簿的簡報，並將其匯出為附帶該活頁簿的 PDF。

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

要檢查結果：

1. 在支援檔案附件的檢視器（例如 Adobe Acrobat Reader）中開啟匯出的 PDF。
2. 開啟檢視器的 **Attachments** 面板，並找到嵌入的活頁簿。
3. 儲存附件並在 Excel 中開啟以檢查其資料，或在檢視器允許的情況下直接開啟。PDF 頁面上的預覽與附件是分開的。

{{% alert color="info" title="Note" %}}
PDF/A 標準對附件有限制：PDF/A-1 禁止嵌入檔案，PDF/A-2 只允許 PDF/A 附件，PDF/A-3 允許其他檔案類型，包括 Excel 活頁簿。這些是標準的要求，而非 Aspose.Slides 的限制。此範例使用預設的 PDF 合規設定，未示範 PDF/A 匯出。
{{% /alert %}}

### **使用隱藏投影片將 PowerPoint 轉為 PDF**

如果簡報包含隱藏投影片，您可以使用 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法（於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別）將隱藏投影片納入產生的 PDF 頁面中。

以下範例將簡報匯出為 PDF，並包含所有隱藏投影片。

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

### **將 PowerPoint 轉為受密碼保護的 PDF**

以下範例將簡報匯出為需要密碼 `password` 才能開啟的 PDF。存取權限允許列印，包括高品質列印。

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

### **偵測字型替代**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別下提供 [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 方法，使您能在簡報轉 PDF 的過程中偵測字型替代。

以下範例將簡報匯出為 PDF，並將字型替代警告印至主控台。僅在匯出期間遇到無法使用的字型被替代時才會印出警告。

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
如需有關字型替代的更多資訊，請參閱 [字型替代](/slides/zh-hant/cpp/font-substitution/) 文章。
{{% /alert %}}

### **處理沒有專用粗體字型的字體**

即使字體沒有專用的粗體字型，簡報仍可能對文字套用粗體格式。此時文字會透過合成粗體（synthetic bolding）呈現，即人工加粗常規字形。若此文字在 PDF 中顯得過於粗重或與預期外觀不同，請嘗試呼叫 [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) 並傳入 `true`。此選項會在 PDF 匯出時將受影響的文字以點陣圖形式呈現，並可改善某些字體的外觀。其預設值為 `false`。

此範例簡報包含兩個文字方塊：一個為普通文字，另一個對同一字體（無專用粗體字型）套用粗體格式。以下範例載入簡報，啟用對不支援字型樣式的點陣化，並將其匯出為 PDF：

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

以下預覽顯示停用與啟用選項的輸出。在此範例中，停用選項時粗體文字的筆畫較粗；啟用選項後，粗體文字的筆畫變得較細，普通文字則保持不變。請比較結果後再為您的簡報選擇設定。

| 選項停用 (`false`，預設) | 選項啟用 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

在此範例中，啟用此選項會將僅粗體文字轉為點陣圖：此文字無法被選取、複製，或在未使用 OCR 時搜尋，且在 800% 放大時邊緣較為柔和。普通文字仍可搜尋。停用選項時，兩段文字皆保持為文字。

此選項會在字體沒有專用粗體字型時，將以粗體格式的文字點陣化。[字型替代](/slides/zh-hant/cpp/font-substitution/) 則會在原始字型不可用時選擇其他字型。

## **將選取的 PowerPoint 投影片轉為 PDF**

以下範例將簡報的第 1 與第 3 張投影片匯出為 PDF。此陣列中的投影片編號以 1 為起點，且輸入的簡報必須至少包含三張投影片。

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

## **使用自訂投影片大小將 PowerPoint 轉為 PDF**

以下範例將簡報的第一張投影片複製到一個新簡報，並將投影片大小設定為 612 × 792 點（8.5 × 11 吋）。它會縮放投影片內容以適應尺寸，並將單一投影片匯出為 PDF。

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

## **在備註投影片檢視中將 PowerPoint 轉為 PDF**

以下範例將簡報匯出為 PDF，並將每張投影片的講者備註放置於投影片下方。請使用包含講者備註的簡報以查看結果。

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

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換流程。您可以使用以下任何合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下 C++ 程式碼示範了依據不同合規標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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
Aspose.Slides 支援 PDF 轉換操作，讓您能將 PDF 檔案轉換為常見檔案格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)、[PDF 轉 圖片](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) 與 [PDF 轉 PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) 轉換。其他針對特殊格式的 PDF 轉換操作—[PDF 轉 SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)、[PDF 轉 XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—亦受支援。
{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能會被標記為雜訊；僅對整個圖形提供替代文字。

## **常見問題**

**我可以批次將多個 PowerPoint 檔案轉換為 PDF 嗎？**

是的，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以在程式中遍歷檔案並套用轉換流程。

**是否可以為轉換後的 PDF 設定密碼保護？**

是的。可使用 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別在轉換過程中設定密碼並定義存取權限。

**如何在 PDF 中包含隱藏投影片？**

使用 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法（於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別）即可在產生的 PDF 中包含隱藏投影片。

**Aspose.Slides 能在 PDF 中保持高影像品質嗎？**

是的，您可以使用 [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) 與 [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) 等方法於 [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) 類別中控制影像品質，確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

是的，Aspose.Slides 允許您匯出符合多種標準的 PDF，包括 PDF/A1a、PDF/A1b 與 PDF/UA，確保您的文件符合無障礙與保存要求。

## **其他資源**

- [Aspose.Slides for C++ 文件](/slides/zh-hant/cpp/)
- [Aspose.Slides for C++ API 參考](https://reference.aspose.com/slides/cpp/)
- [Aspose 免費線上轉換工具](https://products.aspose.app/slides/conversion)