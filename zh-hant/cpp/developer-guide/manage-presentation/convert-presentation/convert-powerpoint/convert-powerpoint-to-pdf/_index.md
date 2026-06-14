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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，提供快速程式範例與進階轉換選項。"
---
## **概述**

在 C++ 中將 PowerPoint 簡報 (PPT、PPTX、ODP 等) 轉換為 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、為 PDF 檔案設定密碼保護、偵測字型置換、選擇特定投影片進行轉換，以及對輸出文件套用合規標準。

## **PowerPoint 轉 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，只需將檔案名稱作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別，然後使用 `Save` 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別公開了通常用於將簡報轉換為 PDF 的 `Save` 方法。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for C++ 會將其 API 資訊與版本號插入輸出文件。例如，將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入「*Aspose.Slides*」，在 PDF Producer 欄位填入「*Aspose.Slides v XX.XX*」的格式。**注意** 你無法指示 Aspose.Slides 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報為 PDF
* 簡報中指定的投影片為 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保產生的 PDF 與原始簡報高度相符。轉換過程中會正確呈現以下元素與屬性：

* 影像
* 文字方塊與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 項目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會嘗試使用最佳設定與最高品質層級將提供的簡報轉換為 PDF。

以下 C++ 程式碼示範如何將簡報 (PPT、PPTX、ODP 等) 轉換為 PDF：

```c++
// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// 將簡報儲存為 PDF。
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose 提供免費的線上 [**PowerPoint 轉 PDF 轉換器**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf) 以示範簡報轉 PDF 的過程。您可使用此轉換器執行測試，實作本文件中描述的程序。

{{% /alert %}}

## **將 PowerPoint 轉 PDF（含選項）**

### **使用自訂選項將 PowerPoint 轉 PDF**

透過自訂的轉換選項，您可以定義點陣圖影像的品質設定、指定中繼檔的處理方式、設定文字的壓縮等級、配置影像的 DPI 等等。

以下程式碼示範如何使用多項自訂選項將 PowerPoint 簡報轉換為 PDF：

```c++
// 實例化 PdfOptions 類別。
auto pdfOptions = MakeObject<PdfOptions>();

// 設定 JPG 影像的品質。
pdfOptions->set_JpegQuality(90);

// 設定影像的 DPI。
pdfOptions->set_SufficientResolution(300);

// 設定中繼檔的處理方式。
pdfOptions->set_SaveMetafilesAsPng(true);

// 設定文字內容的壓縮等級。
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// 定義 PDF 合規模式。
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 將簡報儲存為 PDF 文件。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **將 PowerPoint 轉 PDF（含隱藏投影片）**

若簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別的 [set_ShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法，將隱藏投影片納入產生的 PDF 頁面。

以下 C++ 程式碼示範如何在轉換 PDF 時包含隱藏投影片：

```c++
// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 實例化 PdfOptions 類別。
auto pdfOptions = MakeObject<PdfOptions>();

// 添加隱藏投影片。
pdfOptions->set_ShowHiddenSlides(true);

// 將簡報儲存為 PDF。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **將 PowerPoint 轉 PDF（密碼保護）**

以下 C++ 程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別的保護參數，將 PowerPoint 簡報轉換為具密碼保護的 PDF：

```c++
// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 實例化 PdfOptions 類別。
auto pdfOptions = MakeObject<PdfOptions>();

// 設定 PDF 密碼與存取權限。
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// 將簡報儲存為 PDF。
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **偵測字型置換**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別下提供 [set_WarningCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 方法，讓您在簡報轉 PDF 的過程中偵測字型置換。

以下 C++ 程式碼示範如何偵測字型置換：

```c++
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
    // 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
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

{{%  alert color="primary"  %}} 

欲取得渲染過程中字型置換的回呼資訊，請參閱 [Getting Warning Callbacks for Fonts Substitution](/slides/zh-hant/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

欲取得更多字型置換相關資訊，請參閱 [Font Substitution](/slides/zh-hant/cpp/font-substitution/) 文章。

{{% /alert %}} 

## **將 PowerPoint 中選定的投影片轉換為 PDF**

以下 C++ 程式碼示範如何僅將 PowerPoint 簡報中的特定投影片轉換為 PDF：

```C++
// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 設定投影片編號陣列。
auto slides = MakeArray<int32_t>({ 1, 3 });

// 將簡報儲存為 PDF。
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **將 PowerPoint 轉 PDF（自訂投影片尺寸）**

以下 C++ 程式碼示範如何以指定的投影片尺寸將 PowerPoint 簡報轉換為 PDF：

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **將 PowerPoint 轉 PDF（包含備註投影片檢視）**

以下 C++ 程式碼示範如何將包含備註的 PowerPoint 簡報轉換為 PDF：

```C++
// 實例化表示 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 設定具有註記版面的 PDF 選項。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// 將簡報儲存為含註記的 PDF。
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF 的可存取性與合規標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換流程。您可以使用以下任一合規標準將 PowerPoint 文件匯出為 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下 C++ 程式碼示範一個產生多種合規標準 PDF 的 PowerPoint 轉 PDF 流程：

```C++
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

{{% alert title="注意" color="warning" %}} 

Aspose.Slides 支援 PDF 轉換作業，讓您可將 PDF 檔案轉換為常見格式。您可執行 [PDF to HTML](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-jpg/)、以及 [PDF to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-png/) 轉換。其他針對特殊格式的 PDF 轉換作業，如 [PDF to SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-tiff/)、以及 [PDF to XML](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-xml/) 亦受支援。

{{% /alert %}}

> **注意：** 在匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**我可以一次大量將多個 PowerPoint 檔案批次轉換為 PDF 嗎？**

可以，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以透過程式迭代檔案並套用轉換流程。

**是否可以對轉換後的 PDF 設定密碼保護？**

當然可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別在轉換過程中設定密碼與存取權限。

**如何在 PDF 中包含隱藏投影片？**

在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類別中使用 `set_ShowHiddenSlides` 方法，即可將隱藏投影片納入產生的 PDF。

**Aspose.Slides 能否在 PDF 中維持高影像品質？**

可以，您可使用 `set_JpegQuality` 與 `set_SufficientResolution` 等方法於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 中控制影像品質，確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 合規標準？**

支援。Aspose.Slides 允許您匯出符合 PDF/A1a、PDF/A1b 與 PDF/UA 等多種合規標準的 PDF，確保文件符合可存取性與保存需求。

## **其他資源**

- [Aspose.Slides for C++ 文件](/slides/zh-hant/cpp/)
- [Aspose.Slides for C++ API 參考](https://reference.aspose.com/slides/zh-hant/cpp/)
- [Aspose 免費線上轉換工具](https://products.aspose.app/slides/zh-hant/conversion)