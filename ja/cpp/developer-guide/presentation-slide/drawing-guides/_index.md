---
title: C++ でのプレゼンテーションにおける描画ガイドの管理
linktitle: 描画ガイド
type: docs
weight: 85
url: /ja/cpp/drawing-guides/
keywords:
- 描画ガイド
- 水平ガイド
- 垂直ガイド
- 整列ガイド
- スライドビュー
- マスタースライド
- レイアウトスライド
- ノートマスター
- 配布資料マスター
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーションの水平および垂直描画ガイドを追加、アクセス、クリアします。"
---
## **概要**

描画ガイドは、PowerPoint でプレゼンテーションを編集する際に、形状を一貫して整列させるのに役立つ調整可能な水平および垂直の線です。特に、アプリケーションがプレゼンテーションを生成し、後で手動で調整する場合に便利です。アプリケーションは、コンテンツを追加または移動する際に作者が従うべき同じ整列支援を保存できます。

描画ガイドは編集支援であり、スライドのコンテンツではありません。スライドショーやレンダリングされた出力には表示されません。Aspose.Slides for C++ はこれらを [IDrawingGuidesCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguidescollection/) インターフェイスを通じて公開します。ガイドは [IDrawingGuide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguide/) によって表され、向き、位置、色を持ちます。

位置は、対象となるスライドまたはマスターの左上隅からのポイントで測定されます。垂直ガイドは水平座標を使用し、通常は 0 からスライド幅までの範囲です。水平ガイドは垂直座標を使用し、通常は 0 からスライドの高さまでの範囲です。

## **スライドビューにガイドを追加**

通常のスライドを編集している間に表示されるガイドを管理するには、[ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) を使用します。[IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguidescollection/add/) を呼び出し、[Orientation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/orientation/) の値とポイント単位の位置を指定します。

次の例は、スライドの中心の右側に垂直ガイドを 1 本、下側に水平ガイドを 1 本追加します。

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **描画ガイドへのアクセス**

[IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguidescollection/get_count/) メソッドと [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguidescollection/idx_get/) メソッドは、既存のガイドへのアクセスを提供します。[IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguide/get_orientation/)、[IDrawingGuide::get_Position](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguide/get_position/)、および [IDrawingGuide::get_Color](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguide/get_color/) メソッドはガイドの現在のプロパティを返します。対応する setter メソッドを使用してこれらのプロパティを変更できます。

次の例は、上で作成したプレゼンテーションからスライドビューのガイドを読み取ります。

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **マスタースライドおよびレイアウトスライドにガイドを追加**

スライドマスターとその各レイアウトスライドは、それぞれ独自の描画ガイド コレクションを持つことができます。マスタースライドについては [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterslide/get_drawingguides/) を使用し、レイアウトスライドについては [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ilayoutslide/get_drawingguides/) を使用します。

次の例は、最初のマスタースライドに垂直ガイドを、最初のレイアウトスライドに水平ガイドを追加します。

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ノートマスターと配布資料マスターにガイドを追加**

ノートマスターと配布資料マスターも描画ガイドをサポートします。これらのコレクションにアクセスするには、[IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslide/get_drawingguides/) と [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) を使用します。プレゼンテーションにこれらのマスターが含まれていない場合、[IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) または [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) がデフォルトマスターを作成し、返します。

次の例は、ノートマスターに水平ガイドを、配布資料マスターに垂直ガイドを追加します。

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoffMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **描画ガイドのクリア**

特定のコレクションからすべてのガイドを削除するには、[IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idrawingguidescollection/clear/) を呼び出します。1 つのコレクションをクリアしても、別のスコープに保存されているガイドには影響しません。

次の例は、スライドビューのガイドと、スライドマスター、レイアウトスライド、ノートマスター、配布資料マスター上のすべてのガイドを、欠落したマスターを作成せずにクリアします。

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**描画ガイドはスライドショーやエクスポートされた画像に表示されますか？**

いいえ。描画ガイドは編集用の整列支援であり、プレゼンテーションのコンテンツとしてレンダリングされません。

**個々の通常スライドに直接描画ガイドを追加できますか？**

通常スライドの編集ガイドはプレゼンテーションのスライドビュー プロパティに保存されます。スライドマスター、レイアウトスライド、ノートマスター、配布資料マスター用の個別のガイド コレクションも利用可能です。

**ガイド位置にはどの単位が使用されますか？**

位置はポイントで指定され、72 ポイントが 1 インチに相当します。垂直位置は左端から、水平位置は上端から測定されます。

**描画ガイドをクリアすると、図形が削除されたりスライドのコンテンツが変更されたりしますか？**

いいえ。`Clear` メソッドは選択したコレクション内のガイドのみを削除します。図形やその他のスライド コンテンツは変更されずそのまま残ります。