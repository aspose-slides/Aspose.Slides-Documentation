---
title: 以 C++ 儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/cpp/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預先定義的檢視類型
- 嚴格 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- C++
- Aspose.Slides
description: "了解如何在 C++ 中使用 Aspose.Slides 儲存簡報——匯出為 PowerPoint 或 OpenDocument，並保留版面配置、字型與效果。"
---
## **概觀**

[在 C++ 中開啟簡報](/slides/zh-hant/cpp/open-presentation/) 說明了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別開啟簡報。本文說明如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要將其儲存。使用 Aspose.Slides for C++，您可以儲存至 **檔案** 或 **串流**。本文說明儲存簡報的不同方式。

## **將簡報儲存為檔案**

呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的 `Save` 方法即可將簡報儲存至檔案。將檔名與儲存格式傳遞給此方法。以下範例示範如何使用 Aspose.Slides 儲存簡報。

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 在此執行一些工作...

// 將簡報儲存至檔案。
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **將簡報儲存至串流**

您可以將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的 `Save` 方法，以將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例建立新簡報並將其儲存至檔案串流。

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// 將簡報儲存至串流。
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **使用預先定義的檢視類型儲存簡報**

Aspose.Slides 允許您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/) 類別設定 PowerPoint 開啟產生之簡報時的初始檢視。使用 [set_LastView](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/set_lastview/) 方法，並傳入 [ViewType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewtype/) 列舉中的值。

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **以嚴格的 Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以嚴格的 Office Open XML 格式儲存簡報。使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/) 類別，並在儲存時設定其 conformance 屬性。如果將 `Conformance.Iso29500_2008_Strict` 設為值，輸出檔案即會以嚴格的 Office Open XML 格式儲存。

以下範例建立簡報並以嚴格的 Office Open XML 格式儲存。

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 以嚴格的 Office Open XML 格式儲存簡報。
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **以 Zip64 模式在 Office Open XML 格式中儲存簡報**

Office Open XML 檔案是 ZIP 壓縮檔，對未壓縮檔案大小、壓縮後檔案大小與壓縮檔總大小皆設有 4 GB (2^32 位元組) 限制，且檔案數量上限為 65 535 (2^16‑1) 個。ZIP64 格式擴充可將這些限制提升至 2^64。

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) 方法讓您在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。

此方法可配合以下模式使用：

- `IfNecessary` 只有在簡報超過上述限制時才使用 ZIP64 格式擴充。這是預設模式。
- `Never` 永不使用 ZIP64 格式擴充。
- `Always` 總是使用 ZIP64 格式擴充。

以下程式碼示範如何將簡報儲存為啟用 ZIP64 格式擴充的 PPTX：

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="注意" color="warning" %}}
當以 `Zip64Mode.Never` 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxexception/)。
{{% /alert %}}

## **儲存簡報時不重新整理縮圖**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) 方法可控制儲存為 PPTX 時是否產生縮圖：

- 設為 `true` 時，儲存過程會重新整理縮圖。這是預設值。
- 設為 `false` 時，保留現有縮圖。如果簡報沒有縮圖，則不會產生。

以下程式碼示範將簡報儲存為 PPTX 且不重新整理縮圖。

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="資訊" color="info" %}}
此選項有助於縮短以 PPTX 格式儲存簡報所需的時間。
{{% /alert %}}

## **以百分比形式取得儲存進度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprogresscallback/) 介面透過 [ISaveOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isaveoptions/) 介面的 `set_ProgressCallback` 方法以及抽象的 [SaveOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/) 類別使用。將實作了 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprogresscallback/) 的物件指定給 `set_ProgressCallback`，即可以百分比接收儲存進度更新。

以下程式碼片段示範如何使用 `IProgressCallback`。

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // 在此使用進度百分比值。
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="資訊" color="info" %}}
Aspose 開發了 a [免費 PowerPoint 分割程式](https://products.aspose.app/slides/zh-hant/splitter)，使用其 API。此應用程式可透過將選取的投影片儲存為新 PPTX 或 PPT 檔案，將簡報分割為多個檔案。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」(增量儲存) 只寫入變更？**

不支援。每次儲存都會重新產生完整的目標檔案，未提供增量「快速儲存」功能。

**從多個執行緒同時儲存同一 Presentation 實例是否安全？**

不安全。 [Presentation](/slides/zh-hant/cpp/multithreading/) 實例 **不是執行緒安全**，請只在單一執行緒中呼叫儲存。

**儲存時超連結與外部連結檔案會發生什麼事？**

[超連結](/slides/zh-hant/cpp/manage-hyperlinks/) 會被保留。外部連結的檔案（例如以相對路徑引用的影片）不會自動複製——請確保相關路徑在儲存後仍可存取。

**我可以設定/儲存文件的中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的 [文件屬性](/slides/zh-hant/cpp/presentation-properties/)，儲存時會寫入檔案中。