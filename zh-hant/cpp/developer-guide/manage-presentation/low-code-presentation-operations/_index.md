---
title: 在 C++ 中的低程式碼簡報操作
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/cpp/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 遍歷投影片
- 遍歷形狀
- 遍歷文字
- 收集形狀
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面配置投影片
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 低程式碼 API 以轉換與合併簡報、遍歷內容、收集形狀，並減少簡報大小。"
---
## **概述**

[Aspose::Slides::LowCode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/) 命名空間提供用於常見簡報操作的靜態輔助類別。這些輔助類別將常用的物件模型工作流程封裝在專注的方法中，讓您能以更少的程式碼轉換或合併檔案、處理簡報元素、收集形狀，並移除未使用的內容。

當操作適用於整個檔案或簡報且預設工作流程符合需求時，低程式碼輔助類別最為有用。若需要對單一投影片、母片、版面配置、形狀、匯出設定或簡報元素之間的關係進行精細控制，請使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/)。

下表概述了可用的輔助類別：

| 輔助類別 | 用途 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/convert/) | 將簡報直接以檔案對檔案的方式轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/) | 對每張投影片、形狀、段落或文字片段執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/collect/) | 從整個簡報取得形狀，以便重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) | 移除未使用的母片與版面配置，並縮減嵌入字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以決定匯出格式時，請使用 [Convert::AutoByExtension](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/convert/autobyextension/)。此方法會開啟來源簡報，根據輸出路徑判斷所需格式，然後寫入結果。

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/convert/) 類別同時提供 PDF、SVG、JPEG、PNG 與 TIFF 等專屬輸出方法。若需在匯出前檢查或修改簡報，或設定一般輔助類別未提供的匯出選項，請使用完整的物件模型。請參閱 [轉換簡報](/cpp/convert-presentation/) 了解特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger::Process](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/merger/process/) 只需一次呼叫即可合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

當所有投影片都應直接附加至最終結果且不需個別選取或重新對映時，此輔助類別非常適合。若需要合併指定投影片、套用目標母片或版面配置、明確保留章節，或協調不同的投影片尺寸，請使用完整的物件模型。相關情境請參閱 [合併簡報](/cpp/merge-presentation/)。

## **遍歷簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/) 類別會為每個請求的簡報元素類型呼叫回呼函式。它避免了巢狀集合迴圈，適合用於整個簡報的檢查或格式變更。

以下範例使用 [ForEach::Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/slide/)、[ForEach::Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/shape/)、[ForEach::Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/paragraph/)、[ForEach::Portion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/portion/) 來檢查對應的元素：

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

預設情況下，遍歷整個簡報的形狀與文字會包含一般投影片、母片與版面配置投影片。帶有 `includeNotes` 參數的重載可同時處理備註投影片。若遍歷順序、提前退出、在呼叫回呼前過濾，或需要詳細的父子關係控制，請改用直接的集合迴圈。

## **收集形狀**

當您需要取得簡報中所有形狀的集合，而非對每個形狀即時處理時，請使用 [Collect::Shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/collect/shapes/)。這在需要對同一組形狀多次過濾、計數或處理時特別有用。

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

若每個形狀都能立即處理且不需要保留收集結果，請改用 [ForEach::Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/shape/)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別可以移除未使用的結構元素並縮減嵌入字型資料：

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 移除無任何一般投影片參照的版面配置投影片。  
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) 移除不再使用的母片。  
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) 移除嵌入字型中未使用的字元。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

先移除未使用的版面配置，再移除未使用的母片，這樣在版面配置清理後變成未參照的母片也能被移除。若日後可能需要原始的母片、版面配置或完整的嵌入字型資料，請將最佳化後的簡報另存為新檔案。欲了解更多細節，請參閱 [Slide Master](/cpp/slide-master/) 與 [Embedded Font](/cpp/embedded-font/)。

## **常見問題**

**何時應該使用低程式碼 API 而非完整的物件模型？**

當標準操作適用於完整檔案或簡報且不需要對個別元素進行詳細控制時，請使用低程式碼輔助類別。若需要選取特定投影片、控制母片與版面配置之關係、檢查中間狀態，或設定輔助類別未公開的行為，則應使用完整的物件模型。

**Merger 能否合併不同檔案格式的簡報？**

不能。[Merger::Process](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/merger/process/) 要求輸入的簡報必須為相同格式。請先使用 [Convert::AutoByExtension](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/convert/autobyextension/) 等方法將輸入檔案轉換為統一格式，然後再執行合併。

**ForEach 會處理母片、版面配置與備註投影片嗎？**

[ForEach::Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/slide/) 只遍歷一般簡報投影片。全域的 [ForEach::Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/shape/)、[ForEach::Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/paragraph/)、[ForEach::Portion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/portion/) 作業預設會包含一般、母片與版面配置投影片。使用帶有 `includeNotes` 設為 `true` 的重載即可包含備註投影片。

**ForEach::Shape 與 Collect::Shapes 有何差異？**

使用 [ForEach::Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/shape/) 時會立即透過回呼處理每個形狀。使用 [Collect::Shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/collect/shapes/) 則會取得可保留的可列舉結果，以便後續過濾、計數或多次遍歷。

**Compress 是否總會讓簡報檔案變小？**

未必。結果取決於簡報是否包含未使用的版面配置、未使用的母片或含有未使用字元的嵌入字型。若上述項目皆不存在，對應的 [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 作業可能不會減少檔案大小。

**ForEach 或 Compress 所做的變更會自動儲存嗎？**

不會。這些輔助類別作用於記憶體中已載入的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件。於 [ForEach](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/) 回呼或執行 [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 後，請呼叫 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 以寫入結果。

## **相關文章**

- [轉換簡報](/cpp/convert-presentation/)
- [合併簡報](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)