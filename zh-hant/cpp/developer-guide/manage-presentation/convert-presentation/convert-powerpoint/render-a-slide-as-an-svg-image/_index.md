---
title: 在 C++ 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報轉 SVG
- 投影片轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- 互動式 SVG
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "在 C++ 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、圖像、ID 與事件。"
---
## **概觀**

SVG 是一種可伸縮的基於 XML 的圖像格式，適用於網站發佈、投影片檢視器、無障礙工作流程和自動後處理。Aspose.Slides for C++ 會將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片以及 SVG 元素的寫入方式。

當匯出的 SVG 必須保持緊湊、在不同瀏覽器間具有可預測性，或已準備好用於互動時，請使用 [SVGOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)，選取投影片，並將其寫入串流。以下範例會將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

檔名使用 [ISlide::get_SlideNumber](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/get_slidenumber/) 而非迴圈索引。當投影片檢視器或網頁只需要特定圖形時，也可以使用 [IShape::WriteAsSvg](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/writeassvg/) 匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/) 控制 SVG 的渲染。對於文字框，[SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_useframesize/) 會將文字框納入渲染區域，而 [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_useframerotation/) 決定是否套用框的旋轉。當文字必須以無連字的方式呈現時，將 [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) 設為 `true`。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **控制文字與字型**

### **向量化全部文字**

將 [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) 設為 `true`，即可將所有投影片文字寫成向量圖形。這樣可消除字型相依性，並使視覺結果在各瀏覽器間更一致，但文字將不再可作為 SVG 文字被選取或搜尋。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **選擇外部字型的處理方式**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) 為外部載入的字型使用一個 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgexternalfontshandling/) 值。選擇 `AddLinksToFontFiles` 以參照獨立的字型檔案，`Embed` 以在 SVG 中嵌入字型資料，或 `Vectorize` 只將使用外部字型的文字渲染為圖形。嵌入字型前請確認字型授權。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **縮小嵌入式圖像大小**

使用 [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_picturescompression/) 可降低嵌入圖片的解析度，使用 [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) 可省略裁切過的來源區域，並使用 [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_jpegquality/) 來控制 JPEG 的編碼品質。這些設定會以圖像保真度或保留的圖像資料為代價來減少檔案大小。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **為圖形與文字指派穩定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isvgshapeformattingcontroller/) 為每個 SVG 圖形設定 [ISvgShape::set_Id](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isvgshape/set_id/)。若也要在文字 `tspan` 元素上設定 [ISvgTSpan::set_Id](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isvgtspan/set_id/) 值，請實作 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/)。透過 [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) 指派任一控制器。

以下控制器使用 [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_officeinteropshapeid/)，此 ID 在圖形的生命週期內保持穩定，以及可重複使用的計數器來產生其文字 span。這使得產生的 ID 適合於對未變更的簡報執行後處理。

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **新增 SVG 事件處理程序**

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isvgshapeformattingcontroller/) 中，呼叫 [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isvgshape/seteventhandler/) 並傳入 [SvgEvent](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgevent/) 值，即可為匯出的圖形加入 JavaScript 事件處理程序。透過 [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) 指派此控制器，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

宿主頁面可以定義事件處理器所引用的 JavaScript 函式。指派 ID 與事件處理程序可支援投影片檢視器、無障礙功能增強以及其他互動式 SVG 工作流程。

## **常見問題**

**何時應使用 [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) 而非 [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgexternalfontshandling/)?**

當所有文字必須與字型無關時，請使用 [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/set_vectorizetext/)。若僅需將使用外部字型的文字轉換為圖形，則使用 [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgexternalfontshandling/)。

**如何最佳地縮小 SVG 大小？**

首先壓縮嵌入的圖片、刪除裁切的圖像區域，並在目標環境能提供字型檔案時選擇連結字型檔。請測試結果，因為降低圖像解析度、降低 JPEG 品質以及向量化文字各自會在品質與檔案大小之間產生不同的取捨。

**匯出後我能修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，之後在後處理工具或瀏覽器腳本中選取相對應的 SVG 元素。