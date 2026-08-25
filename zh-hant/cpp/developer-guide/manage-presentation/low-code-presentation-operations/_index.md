---
title: C++ 低程式碼簡報作業
linktitle: 低程式碼 API
type: docs
weight: 50
url: /zh-hant/cpp/low-code-presentation-operations/
keywords:
- 低程式碼簡報 API
- 轉換簡報
- 合併簡報
- 遍歷投影片
- 遍歷圖形
- 遍歷文字
- 收集圖形
- 壓縮簡報
- 移除未使用的母片投影片
- 移除未使用的版面配置投影片
- 壓縮嵌入字型
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 低程式碼 API 來轉換與合併簡報、遍歷內容、收集圖形，並減少簡報大小。"
---
## **概觀**

[Aspose::Slides::LowCode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/) 命名空間提供用於常見簡報操作的靜態輔助類別。這些輔助類別將常用的物件模型工作流程封裝在專注的方法中，讓您能以更少的程式碼執行檔案轉換或合併、處理簡報元素、收集圖形，以及移除未使用的內容。

當操作適用於整個檔案或簡報且預設工作流程符合需求時，低程式碼輔助最為有用。若需要對個別投影片、母片、版面配置、圖形、匯出設定或簡報元素之間的關係進行細緻控制，請使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/)。

下表總結了可用的輔助類別：

| 輔助類別 | 適用情況 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/convert/) | 以直接的檔案對檔案呼叫將簡報轉換為其他格式。 |
| [Merger](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/merger/) | 合併相同格式的完整簡報檔案。 |
| [ForEach](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/) | 為每張投影片、圖形、段落或文字片段執行動作。 |
| [Collect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/collect/) | 從整個簡報取得圖形以供重複處理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) | 移除未使用的母片與版面配置，並減少嵌入字型資料。 |

## **轉換簡報**

當輸出檔案副檔名足以選擇匯出格式時，請使用 [Convert::AutoByExtension](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/convert/autobyextension/)。此方法會開啟來源簡報、從輸出路徑判斷所需格式，然後寫入結果。

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/convert/) 類別還提供針對 PDF、SVG、JPEG、PNG 與 TIFF 的專屬輸出方法。若需要在匯出前檢查或修改簡報，或是設定未由此輔助類別公開的匯出選項，請使用完整的物件模型。請參閱 [轉換簡報](/slides/zh-hant/cpp/convert-presentation/) 了解針對特定格式的工作流程與選項。

## **合併簡報**

使用 [Merger::Process](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/merger/process/) 可一次呼叫合併完整的簡報檔案。輸入的簡報必須具有相同的檔案格式。

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

當所有投影片都應直接附加至最終結果且不需逐一選取或重新對應時，這個輔助類別相當適合。若需要合併特定投影片、套用目標母片或版面配置、明確保留章節，或是協調不同的投影片尺寸，請使用完整的物件模型。請參閱 [合併簡報](/slides/zh-hant/cpp/merge-presentation/) 了解相關情境。

## **遍歷簡報元素**

[ForEach](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/) 類別會對每種所請求的簡報元素類型呼叫回呼函式。它可避免巢狀集合迴圈，且在簡報範圍內的檢查或格式變更時相當便利。

以下範例使用 [ForEach::Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/slide/)、[ForEach::Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/shape/)、[ForEach::Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/paragraph/)、[ForEach::Portion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/portion/) 來檢查相對應的元素：

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

預設情況下，簡報範圍的圖形與文字遍歷會同時包含普通投影片、母片與版面配置投影片。帶有 `includeNotes` 參數的重載方法亦可處理備註投影片。若遍歷順序、提前退出、在呼叫回呼前進行篩選，或需要詳細的父子層級控制，請改用直接的集合迴圈。

## **收集圖形**

當您需要取得簡報中全部圖形的集合，而非對每個圖形立即執行回呼時，請使用 [Collect::Shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/collect/shapes/)。在需要對同一組圖形進行多次篩選、計數或處理時，此方式特別有用。

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

若每個圖形都能立即處理且不需要保留收集結果，請改用 [ForEach::Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/shape/)。

## **壓縮簡報內容**

[Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別可移除未使用的結構元素並減少嵌入字型資料：

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 移除未被任何普通投影片參考的版面配置投影片。
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) 移除已不再使用的母片。
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) 從嵌入字型中移除未使用的字元。

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

先移除未使用的版面配置，之後再移除未使用的母片，這樣在版面配置清理後變成未被引用的母片也能一起移除。若日後可能仍需原始的母片、版面配置或完整的嵌入字型資料，請將最佳化後的簡報儲存為新檔案。欲取得更詳細資訊，請參閱 [Slide Master](/slides/zh-hant/cpp/slide-master/) 與 [Embedded Font](/slides/zh-hant/cpp/embedded-font/)。

## **常見問題**

**什麼時候該使用低程式碼 API 而非完整物件模型？**

當標準操作適用於完整檔案或簡報且不需要對個別元素進行細部控制時，請使用低程式碼輔助。若需要選取特定投影片、控制母片與版面配置之間的關係、檢查中間狀態，或設定輔助類別未公開的行為，則使用完整物件模型。

**Merger 可以合併不同檔案格式的簡報嗎？**

不能。[Merger::Process](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/merger/process/) 必須使用相同格式的輸入簡報。請先使用例如 [Convert::AutoByExtension](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/convert/autobyextension/) 將輸入檔案轉換為相同格式，再執行合併。

**ForEach 會處理母片、版面配置與備註投影片嗎？**

[ForEach::Slide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/slide/) 只遍歷普通的簡報投影片。簡報範圍的 [ForEach::Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/shape/)、[ForEach::Paragraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/paragraph/)、[ForEach::Portion](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/portion/) 預設會同時包含普通、母片與版面配置投影片。使用其帶有 `includeNotes` 並設為 `true` 的重載，即可將備註投影片納入。

**ForEach::Shape 與 Collect::Shapes 有何不同？**

當您希望立即透過回呼處理每個圖形時，使用 [ForEach::Shape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/shape/)。若需要取得可保留、篩選、計數或多次遍歷的可列舉結果，請使用 [Collect::Shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/collect/shapes/)。

**Compress 總是會讓簡報檔案變小嗎？**

未必。結果取決於簡報是否包含未使用的版面配置、未使用的母片，或嵌入字型中有未使用的字元。如果上述情況皆不存在，相應的 [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 操作可能不會減少檔案大小。

**ForEach 或 Compress 所做的變更會自動儲存嗎？**

不會。這些輔助類別在記憶體中的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件上執行操作。變更完元素後，請在 [ForEach](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/foreach/) 回呼或執行 [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 後，呼叫 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 將結果寫入檔案。

## **相關文章**

- [轉換簡報](/slides/zh-hant/cpp/convert-presentation/)
- [合併簡報](/slides/zh-hant/cpp/merge-presentation/)
- [Slide Master](/slides/zh-hant/cpp/slide-master/)
- [Manage Text Box](/slides/zh-hant/cpp/manage-textbox/)
- [Embedded Font](/slides/zh-hant/cpp/embedded-font/)