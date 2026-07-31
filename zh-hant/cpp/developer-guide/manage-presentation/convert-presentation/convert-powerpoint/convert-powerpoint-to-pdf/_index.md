---
title: 將 PPT 與 PPTX 轉換為 PDF（C++）【包含進階功能】
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
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint PPT/PPTX 轉換為高品質、可搜尋的 PDF，並提供快速程式範例與進階轉換選項。"
---
## **概觀**

將 PowerPoint 簡報（PPT、PPTX、ODP 等）轉換為 C++ 中的 PDF 格式具有多項優勢，包括在不同裝置間的相容性以及保留簡報的版面配置與格式。本指南示範如何將簡報轉換為 PDF 文件、使用各種選項控制影像品質、包含隱藏投影片、以密碼保護 PDF 檔案、偵測字型取代、選取特定投影片進行轉換，並將符合性標準套用至輸出文件。

## **PowerPoint 到 PDF 轉換**

使用 Aspose.Slides，您可以將以下格式的簡報轉換為 PDF：

* **PPT**
* **PPTX**
* **ODP**

要將簡報轉換為 PDF，請將檔名作為參數傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類，然後使用 `Save` 方法將簡報儲存為 PDF。[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類提供的 `Save` 方法通常用於將簡報轉換為 PDF。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for C++ 會將其 API 資訊與版本號插入輸出文件。例如，在將簡報轉換為 PDF 時，Aspose.Slides 會在 Application 欄位填入 "*Aspose.Slides*"，在 PDF Producer 欄位填入 "*Aspose.Slides v XX.XX*" 形式的值。**注意**，您無法指示 Aspose.Slides 更改或移除這些資訊。

{{% /alert %}}

Aspose.Slides 允許您轉換：

* 整個簡報至 PDF
* 簡報中的特定投影片至 PDF

Aspose.Slides 會將簡報匯出為 PDF，確保輸出的 PDF 與原始簡報高度相符。轉換過程中會準確呈現元素與屬性，包括：

* 影像
* 文本框與圖形
* 文字格式
* 段落格式
* 超連結
* 頁首與頁尾
* 项目符號
* 表格

## **將 PowerPoint 轉換為 PDF**

標準的 PowerPoint 轉 PDF 轉換程序使用預設選項。在此情況下，Aspose.Slides 會在最高品質層級下，以最佳設定將提供的簡報轉換為 PDF。

以下 C++ 程式碼示範如何將簡報（PPT、PPTX、ODP 等）轉換為 PDF：

```c++
// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// 將簡報儲存為 PDF。
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose 提供免費線上 **[PowerPoint 轉 PDF 轉換器](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pdf)**，可示範簡報到 PDF 的轉換流程。您可以使用此轉換器執行測試，以實作本文所述程序。

{{% /alert %}}

## **使用選項將 PowerPoint 轉換為 PDF**

Aspose.Slides 提供自訂選項——位於 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類下的屬性——讓您自訂輸出 PDF、以密碼鎖定 PDF，或指定轉換流程的執行方式。

### **使用自訂選項將 PowerPoint 轉換為 PDF**

使用自訂轉換選項，您可以為點陣圖影像設定偏好的品質、指定如何處理圖形檔、設定文字壓縮等級、設定影像 DPI 等。

以下程式碼示範如何使用多項自訂選項將 PowerPoint 簡報轉換為 PDF：

```c++
// 實例化 PdfOptions 類別。
auto pdfOptions = MakeObject<PdfOptions>();

// 設定 JPG 影像的品質。
pdfOptions->set_JpegQuality(90);

// 設定影像的 DPI。
pdfOptions->set_SufficientResolution(300);

// 設定中繼檔的行為。
pdfOptions->set_SaveMetafilesAsPng(true);

// 設定文字內容的壓縮等級。
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// 定義 PDF 符合模式。
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 將簡報儲存為 PDF 文件。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **使用隱藏投影片將 PowerPoint 轉換為 PDF**

如果簡報包含隱藏投影片，您可以使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類的 [set_ShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) 方法，將隱藏投影片作為頁面納入輸出 PDF。

以下 C++ 程式碼示範如何在轉換時包含隱藏投影片：

```c++
// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 實例化 PdfOptions 類別。
auto pdfOptions = MakeObject<PdfOptions>();

// 加入隱藏投影片。
pdfOptions->set_ShowHiddenSlides(true);

// 將簡報儲存為 PDF。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **將 PowerPoint 轉換為受密碼保護的 PDF**

以下 C++ 程式碼示範如何使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類的保護參數，將 PowerPoint 簡報轉換為受密碼保護的 PDF：

```c++
// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
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

### **偵測字型取代**

Aspose.Slides 在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類下提供 [set_WarningCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_warningcallback/) 方法，讓您在簡報轉 PDF 的過程中偵測字型取代。

以下 C++ 程式碼示範如何偵測字型取代：

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
    // 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
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

欲了解在渲染過程中取得字型取代回呼的更多資訊，請參閱 [Getting Warning Callbacks for Fonts Substitution](/slides/zh-hant/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)。

欲取得字型取代的其他資訊，請參閱 [Font Substitution](/slides/zh-hant/cpp/font-substitution/) 文章。

{{% /alert %}} 

## **將 PowerPoint 中選取的投影片轉換為 PDF**

以下 C++ 程式碼示範如何僅將 PowerPoint 簡報中的特定投影片轉換為 PDF：

```C++
// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// 設定投影片編號陣列。
auto slides = MakeArray<int32_t>({ 1, 3 });

// 將簡報儲存為 PDF。
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **使用自訂投影片尺寸將 PowerPoint 轉換為 PDF**

以下 C++ 程式碼示範如何以指定的投影片尺寸將 PowerPoint 簡報轉換為 PDF：

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 建立具有調整後投影片尺寸的新簡報。
auto resizedPresentation = MakeObject<Presentation>();

// 設定自訂投影片尺寸。
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// 從原始簡報克隆第一張投影片。
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// 將調整尺寸的簡報儲存為包含註解的 PDF。
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **在註解投影片檢視中將 PowerPoint 轉換為 PDF**

以下 C++ 程式碼示範如何將包含註解的 PowerPoint 簡報轉換為 PDF：

```C++
// 實例化代表 PowerPoint 或 OpenDocument 檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 以備註版面配置設定 PDF 選項。
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// 將簡報儲存為包含註解的 PDF。
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF 的可及性與符合性標準**

Aspose.Slides 允許您使用符合 [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) 的轉換程序。您可以使用以下任一符合性標準匯出 PDF：**PDF/A1a**、**PDF/A1b** 與 **PDF/UA**。

以下 C++ 程式碼示範依不同符合性標準產生多個 PDF 的 PowerPoint 轉 PDF 流程：

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

Aspose.Slides 支援 PDF 轉換作業，允許您將 PDF 檔案轉換為常見格式。您可以執行 [PDF 轉 HTML](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-html/)、[PDF 轉影像](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-image/)、[PDF 轉 JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-jpg/)、以及 [PDF 轉 PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-png/) 的轉換。其他專用格式的 PDF 轉換亦受支援，包括 [PDF 轉 SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-svg/)、[PDF 轉 TIFF](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-tiff/)、以及 [PDF 轉 XML](https://products.aspose.com/slides/zh-hant/cpp/conversion/pdf-to-xml/)。

{{% /alert %}}

> **注意：** 匯出為 PDF/UA 時，Aspose.Slides 會將 SmartArt、圖表與公式等複雜圖形視為單一圖形。個別路徑元素不會保留為獨立內容，可能被標記為雜訊；僅為整體圖形提供替代文字。

## **常見問題**

**是否可以一次批次將多個 PowerPoint 檔案轉換為 PDF？**

可以，Aspose.Slides 支援批次將多個 PPT 或 PPTX 檔案轉換為 PDF。您可以以程式方式遍歷檔案並套用轉換流程。

**是否可以為轉換後的 PDF 設定密碼保護？**

當然可以。使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類設定密碼與存取權限，即可在轉換過程中加入保護。

**如何在 PDF 中包含隱藏投影片？**

使用 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 類的 `set_ShowHiddenSlides` 方法，即可將隱藏投影片納入輸出 PDF。

**Aspose.Slides 能否在 PDF 中維持高影像品質？**

可以。透過 `set_JpegQuality`、`set_SufficientResolution` 等方法，您可在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/) 中控制影像品質，確保 PDF 中的影像保持高品質。

**Aspose.Slides 是否支援 PDF/A 符合性標準？**

支援。Aspose.Slides 允許您匯出符合 PDF/A1a、PDF/A1b 與 PDF/UA 等多種標準的 PDF，確保文件符合可及性與保存要求。

## **其他資源**

- [Aspose.Slides for C++ 文件](/slides/zh-hant/cpp/)
- [Aspose.Slides for C++ API 參考](https://reference.aspose.com/slides/zh-hant/cpp/)
- [Aspose 免費線上轉換器](https://products.aspose.app/slides/zh-hant/conversion)