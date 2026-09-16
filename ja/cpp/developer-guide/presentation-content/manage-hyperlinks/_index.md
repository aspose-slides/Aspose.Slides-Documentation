---
title: C++でプレゼンテーションハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/cpp/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- シェイプハイパーリンク
- 画像ハイパーリンク
- ビデオハイパーリンク
- 変更可能なハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides を使用し、C++ のサンプルで PowerPoint および OpenDocument のプレゼンテーションにハイパーリンクを追加、書式設定、更新、削除します。"
---
## **導入**

ハイパーリンクは、プレゼンテーションのコンテンツを Web サイトやプレゼンテーション内の場所に接続します。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、シェイプ、またはメディアフレームから Web サイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for C++ を使用すると、これらのリンクを追加し、外観やサウンドを制御し、設定を更新し、削除できます。以下の例は、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキストフレームレベルでハイパーリンクにアクセスする方法を示しています。

{{% alert color="info" title="Note" %}}
無料のオンライン Aspose PowerPoint エディターでプレゼンテーションを編集することもできます[free online Aspose PowerPoint editor](https://products.aspose.app/slides/ja/editor)。
{{% /alert %}} 

## **URLハイパーリンクの追加**

テキスト、シェイプ、メディアフレームに Web サイトの URL を割り当てることができます。ハイパーリンクを割り当てる要素によってクリック可能な領域が決まります。テキスト部分にリンクを設定すると選択したテキストだけがクリック可能になり、シェイプやフレームにリンクを設定するとスライドオブジェクト全体がクリック可能になります。

### **テキストへのURLハイパーリンクの追加**

テキストを Web サイトにリンクするには、[Hyperlink](https://reference.aspose.com/slides/ja/cpp/aspose.slides/hyperlink/) を作成し、テキスト部分の [set_HyperlinkClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/portionformat/set_hyperlinkclick/) メソッドに割り当てます。以下の例のように、対象となるテキスト部分だけがクリック可能になります。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **シェイプおよびメディアフレームへのURLハイパーリンクの追加**

シェイプやフレームをクリック可能にするには、[set_HyperlinkClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/set_hyperlinkclick/) メソッドを使用します。ハイパーリンクはテキスト部分ではなくオブジェクト自体に属します。

画像、音声、動画フレームにも同様にハイパーリンクを割り当て、必要に応じて [set_Tooltip](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/set_tooltip/) でヒントを追加できます。

以下の例は矩形をクリック可能にします。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **ハイパーリンクを使った目次の作成**

内部ハイパーリンクを使用すると、読者は目次から特定のスライドへジャンプできます。以下の例は、1枚目のスライドの「Page 2」テキストを 2枚目のスライドにリンクするために [SetInternalHyperlinkClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) を使用しています。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **ハイパーリンクの書式設定**

### **色**

[IHyperlink](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/) の [set_ColorSource](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/set_colorsource/) メソッドは、ハイパーリンクがプレゼンテーションのハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタムテキスト色を適用するには、[HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、古いバージョンでは設定が適用されません。

以下の例は、同じスライドに 2 つのテキストハイパーリンクを追加します。1 つ目は赤いテキスト塗りつぶし、2 つ目はデフォルトのハイパーリンク色を使用します。

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```
### **サウンド**

ハイパーリンクはアクティブ化時にサウンドを再生したり、既に再生中のサウンドを停止したりできます。以下のメソッドでこれらの動作を構成します。

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/set_sound/) はハイパーリンクに関連付けるオーディオを指定します。
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) はハイパーリンクをアクティブ化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンクサウンドの追加**

以下の例は `sampleaudio.wav` を読み込み、1枚目のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別のシェイプはクリック時に前のサウンドを停止し、ナビゲーションは行いません。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **ハイパーリンクサウンドの抽出**

以下の例は上記で作成したプレゼンテーションを開き、最初のシェイプのハイパーリンクオーディオを [get_Sound](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/get_sound/) と [get_BinaryData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iaudio/get_binarydata/) を使ってメモリに読み取ります。

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **ツールチップとインタラクション設定**

テキストまたはシェイプにハイパーリンクを割り当てた後、以下の [IHyperlink](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/) 設定をこれらのメソッドで更新できます。

- [set_Tooltip](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/set_tooltip/) はリンクのヒントとして表示できるテキストを設定します。
- [set_TargetFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/set_targetframe/) は該当する場合に親 HTML フレームセット内のターゲットフレームを指定します。
- [set_History](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/set_history/) はリンクをアクティブ化したときに閲覧履歴に追加するかどうかを制御します。
- [set_HighlightClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/set_highlightclick/) はクリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

ハイパーリンクコンテナ（テキスト部分のリンクを含む）を収集するには [GetAnyHyperlinks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) を使用します。以下の例は 1枚目のスライドから両方のアクティベーションタイプを削除します。1 つだけ削除したい場合は、[RemoveHyperlinkClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) または [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) のみを呼び出してください。クリックアクションを削除してもマウスオーバーは残ります。

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

条件なしで削除する場合は、[RemoveAllHyperlinks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) を使用すると、選択範囲内の両方のアクティベーションタイプが一括で削除されます。マスター、レイアウト、ノートを含む選択的なクリーンアップについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **ハイパーリンクインベントリの作成**

プレゼンテーションを配布する前に、インタラクティブな操作と Web リンクのインベントリを取得します。[GetAnyHyperlinks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) は [IHyperlinkContainer](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkcontainer/) オブジェクトを返し、URL 文字列のフラットリストではありません。各コンテナの [get_HyperlinkClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) と [get_HyperlinkMouseOver](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) を確認します。これらは独立しており、同じコンテナが両方のアクションを持つことがあるため、完全なレポートにはコンテナごとに最大 2 行が必要です。

シェイプレベルのハイパーリンクだけをスキャンすると、テキスト部分に付随したリンクを見逃す可能性があります。適切なスコープでクエリを実行し、返されたコンテナを保持して後で更新または削除できるようにします。

### **プレゼンテーション、スライド、テキストフレームのスコープをクエリする**

[IHyperlinkQueries](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkqueries/) インターフェイスは以下から取得できます。
- [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/)
- [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/)
- [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_hyperlinkqueries/)

各スコープは同じクエリをサポートします。

- [GetHyperlinkClicks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) はクリックアクションを持つコンテナを返します。
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) はマウスオーバーアクションを持つコンテナを返します。
- [GetAnyHyperlinks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) はいずれか、または両方のアクションを持つコンテナを返します。

以下の例は、外部クリックリンク、ファイルマウスオーバーリンク、内部スライドナビゲーション、テキストマウスオーバーリンク、マクロアクションを持つ `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。3 つのクエリはすべてのスコープで機能し、カウントはコンテナ数を示します。テキストフレームスコープは囲むシェイプ自体のリンクは除外します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

この例では、プレゼンテーションとスライドのクエリはそれぞれクリックコンテナ 3 件、マウスオーバーコンテナ 2 件、いずれかのアクションを持つコンテナ 3 件を報告します。テキストフレームのクエリは各カテゴリで 1 件ずつ報告します。

### **アクションと宛先の分類**

[IHyperlink::get_ActionType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/get_actiontype/) を使用して、宛先を解釈する前にアクションの種類を判定します。[HyperlinkActionType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/hyperlinkactiontype/) の値は Web ナビゲーション以外もカバーします。

| 値 | 監査時の意味 |
| --- | --- |
| `Hyperlink` | 外部ハイパーリンク。URL とスキームを確認します。 |
| `JumpSpecificSlide` | 特定のスライドへの内部ナビゲーション。 |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | スライドショー内の組み込みナビゲーション。 |
| `JumpEndShow`, `StartCustomSlideShow` | 現在のショーを終了、またはカスタムショーを開始。 |
| `StartMacro` | マクロを実行。 |
| `StartProgram` | プログラムを起動。 |
| `OpenFile`, `OpenPresentation` | ファイルまたは別のプレゼンテーションを開く。Web URL とは別に確認してください。 |
| `StartStopMedia` | メディアの再生／停止。 |
| `NoAction`, `Unknown` | ナビゲーションアクションなし、または未認識のアクションでレビューが必要。 |

外部宛先は [get_ExternalUrl](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/get_externalurl/) から、内部の具体的な宛先は [get_TargetSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/get_targetslide/) から取得します。内部アクションや組み込みコマンドには外部 URL が存在しないことがあります。空の URL が存在してもコンテナにアクションが無いことを意味しません。正規化された URL と異なる場合は [get_ExternalUrlOriginal](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) を保持し、利用可能な場合は [get_Tooltip](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlink/get_tooltip/) が返すツールチップも含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の C++ サンプルは既存のプレゼンテーション（上記で作成したファイル）を読み込み、`hyperlink-audit.json` を書き出し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方のアクティベーションタイプを確認します。変更前にコンテナを収集し、ポインタ同一性で重複処理を防止します。プレゼンテーションクエリは通常スライドを対象とし、パッケージ全体のインベントリを取得するためにマスター、レイアウト、ノート、ノート/ハンドアウトマスターも明示的にクエリします。

レポートは 1 ベースのスライドインデックスと、利用可能な場合は [get_SlideId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseslide/get_slideid/) を記録します。サポート対象コンテナには所有スライドを提供する [ISlideComponent::get_Slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidecomponent/get_slide/) が使用されます。マスター、レイアウト、ノートは通常スライドインデックスを持たず、スコープで識別されます。シェイプコンテナとテキスト部分の書式コンテナは別々にラベル付けされ、その他のコンテナはランタイム型名を保持します。各コンテナにはローカル ID が付与され、2 つのアクションを相関付けられます。

このポリシーは絶対 HTTPS URL と有効な内部スライドターゲットのみを許可し、マクロ、プログラム、ファイル操作、その他のスライドショーアクション、未知のアクション、その他の URL スキームは拒否します。これらの拒否はポリシー判断であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼を構成できないため、ホスト許可リストや追加チェックを実装してください。元の URL と正規化された外部 URL の両方がチェック対象です。サンプルはリンクをたどったりアクションを実行したりせず、メタデータのみを監査します。

修正の際は、コンテナの [get_HyperlinkManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) を通じて [SetExternalHyperlinkClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)、[RemoveHyperlinkClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)、[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) を使用できます。禁止された外部クリックリンクは固定の HTTPS ランディングページに置き換え、他の禁止クリックと禁止マウスオーバーは個別に削除します。`replaceExternalClicks` を `false` に設定すると、すべてのポリシー違反を削除します。展開前にアプリケーション所有の置換ページを用意してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用します。マウスオーバーアクションや外部リンク以外・スライドジャンプ以外のものは「サポート外」とフラグ付けします。これはレビューのヒントであり、機能テストやフラグが付いていないリンクがエクスポートで保持される保証ではありません。サポート対象の [PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/cpp/convert-powerpoint-to-html/) エクスポートはアクション、エクスポートオプション、ビューアに依存してハイパーリンクを保持できる場合があります。ラスタ画像 [images](/slides/ja/cpp/convert-powerpoint-to-png/) や [video](/slides/ja/cpp/convert-powerpoint-to-video/) はインタラクティブハイパーリンクを保持できないため、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

上記の入力で作成したレポートは 5 行のアクションを含みます。ファイルマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライドナビゲーションは残ります。検証は禁止アクションが 0 件であることを出力します。禁止された外部クリック URL を含む入力は置換ブランチも実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリックアクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく両方のアクティベーションタイプを削除する [RemoveAllHyperlinks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) とは異なります。ここでの検証はハイパーリンクアクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブコンテンツの削除や、エクスポートされた PDF や HTML の検証は行いません。

## **FAQ**

**セクションやその最初のスライドにリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスター スライドの要素にハイパーリンクを付与すれば、すべてのスライドで機能しますか？**

はい。マスター スライドやレイアウト要素はハイパーリンクをサポートします。これらの要素に付けたリンクは、対応するマスターまたはレイアウトを使用するスライドのスライドショー中に利用可能です。

**PDF、HTML、画像、動画へエクスポートした場合、ハイパーリンクは保持されますか？**

サポート対象の PDF と HTML のエクスポートはハイパーリンクを保持できる可能性がありますが、ラスタ画像や動画はインタラクティブハイパーリンクを保持できません。詳細は [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) のエクスポートに関する考慮点を参照してください。