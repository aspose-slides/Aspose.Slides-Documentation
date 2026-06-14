---
title: 取得字型替代的警告回呼
type: docs
weight: 70
url: /zh-hant/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 字型替代
- 渲染過程
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中取得字型替代的警告回呼，並準確顯示 PowerPoint 與 OpenDocument 簡報。"
---
## **簡介**

Aspose.Slides for C++ 允許您在渲染期間，當所需字型在機器上不可用時，接收字型替代的警告回呼。這些回呼有助於診斷缺少或無法存取的字型問題。

## **啟用警告回呼**

Aspose.Slides for C++ 提供簡單直接的 API 以在渲染簡報投影片時接收警告回呼。請依照以下步驟設定警告回呼：

1. 建立一個自訂回呼類別，實作 [IWarningCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.warnings/iwarningcallback/) 介面以處理警告。
1. 使用選項類別（例如 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/renderingoptions/)、[PdfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/htmloptions/) 等）設定警告回呼。
1. 載入使用目標機器上不存在的字型的簡報。
1. 產生投影片縮圖或匯出簡報以觀察效果。

**自訂警告回呼類別**:

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// 範例輸出:
//
// 字型將從 XYZ 替換為 {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**產生投影片縮圖**:

```cpp
// 設定警告回呼以在投影片渲染期間處理字型相關的警告。
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// 從指定的檔案路徑載入簡報。
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// 為簡報中的每張投影片產生縮圖影像。
for(auto&& slide : presentation->get_Slides())
{
    // 使用指定的渲染選項取得投影片縮圖影像。
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**匯出為 PDF 格式**:

```cpp
// 設定警告回呼以在 PDF 匯出期間處理字型相關的警告。
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// 從指定的檔案路徑載入簡報。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 將簡報匯出為 PDF。
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**匯出為 HTML 格式**:

```cpp
// 設定警告回呼以在 HTML 匯出期間處理字型相關的警告。
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// 從指定的檔案路徑載入簡報。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 以 HTML 格式匯出簡報。
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```