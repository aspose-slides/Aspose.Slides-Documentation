---
title: .NET のプレゼンテーションで描画ガイドを管理する
linktitle: 描画ガイド
type: docs
weight: 85
url: /ja/net/drawing-guides/
keywords:
- 描画ガイド
- 水平ガイド
- 垂直ガイド
- 配置ガイド
- スライド ビュー
- マスタ スライド
- レイアウト スライド
- ノート マスタ
- ハンドアウト マスタ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションの水平および垂直描画ガイドを追加、アクセス、クリアします。"
---
## **概要**

描画ガイドは、調整可能な水平線および垂直線で、PowerPoint でプレゼンテーションを編集するときに形状を一貫して配置できるよう支援します。アプリケーションが後で手動で調整されるプレゼンテーションを生成する場合に特に便利です。アプリケーションは、コンテンツを追加または移動するときに作者が従うべき同じ配置補助線を保存できます。

描画ガイドは編集支援ツールであり、スライド コンテンツではありません。スライド ショーやレンダリングされた出力には表示されません。Aspose.Slides for .NET はこれらを [IDrawingGuidesCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/idrawingguidescollection/) インターフェイスで提供します。ガイドは [IDrawingGuide](https://reference.aspose.com/slides/ja/net/aspose.slides/idrawingguide/) で表され、向き、位置、色を持ちます。

位置は対象スライドまたはマスタの左上隅からのポイントで測定されます。垂直ガイドは水平座標を使用し、通常は 0 からスライドの幅までの範囲です。水平ガイドは垂直座標を使用し、通常は 0 からスライドの高さまでの範囲です。

## **スライド ビューへのガイドの追加**

通常のスライドを編集している間に表示されるガイドは、[ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/ja/net/aspose.slides/icommonslideviewproperties/drawingguides/) を使用して管理します。[IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/ja/net/aspose.slides/idrawingguidescollection/add/) に [Orientation](https://reference.aspose.com/slides/ja/net/aspose.slides/orientation/) の値とポイント単位の位置を渡して呼び出します。

次の例は、スライドの中心の右側に垂直ガイドを、下側に水平ガイドをそれぞれ 1 つ追加します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **描画ガイドへのアクセス**

[IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/ja/net/aspose.slides/idrawingguidescollection/count/) プロパティとインデクサーで既存のガイドにアクセスできます。[IDrawingGuide.Orientation](https://reference.aspose.com/slides/ja/net/aspose.slides/idrawingguide/orientation/)、[IDrawingGuide.Position](https://reference.aspose.com/slides/ja/net/aspose.slides/idrawingguide/position/)、および [IDrawingGuide.Color](https://reference.aspose.com/slides/ja/net/aspose.slides/idrawingguide/color/) プロパティは読み取りまたは変更可能です。

次の例は、上記で作成したプレゼンテーションからスライド ビューのガイドを読み取ります。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **マスタとレイアウト スライドへのガイドの追加**

スライド マスタとその各レイアウト スライドは、それぞれ独自の描画ガイド コレクションを持つことができます。マスタ スライドの場合は [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterslide/drawingguides/)、レイアウト スライドの場合は [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/ja/net/aspose.slides/ilayoutslide/drawingguides/) を使用します。

次の例は、最初のマスタ スライドに垂直ガイドを、最初のレイアウト スライドに水平ガイドを追加します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **ノート マスタとハンドアウト マスタへのガイドの追加**

ノート マスタとハンドアウト マスタも描画ガイドをサポートします。各コレクションへは [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/ja/net/aspose.slides/imasternotesslide/drawingguides/) と [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterhandoutslide/drawingguides/) を使用してアクセスします。プレゼンテーションにこれらのマスタが含まれていない場合は、[IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) または [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ja/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) がデフォルト マスタを作成し、返します。

次の例は、ノート マスタに水平ガイドを、ハンドアウト マスタに垂直ガイドを追加します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **描画ガイドのクリア**

[IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/ja/net/aspose.slides/idrawingguidescollection/clear/) を呼び出すと、特定のコレクション内のすべてのガイドが削除されます。1 つのコレクションをクリアしても、別のスコープに保存されたガイドには影響しません。

次の例は、スライド ビューのガイドと、スライド マスタ、レイアウト スライド、ノート マスタ、ハンドアウト マスタ上のすべてのガイドを、マスタが存在しない場合は作成せずにクリアします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**描画ガイドはスライド ショーやエクスポートされた画像に表示されますか？**

いいえ。描画ガイドは編集用の配置補助であり、プレゼンテーション コンテンツとしてレンダリングされません。

**描画ガイドを個々の通常スライドに直接追加できますか？**

通常スライドの編集ガイドはプレゼンテーションのスライド ビュー プロパティに保存されます。スライド マスタ、レイアウト スライド、ノート マスタ、ハンドアウト マスタ用の別個のガイド コレクションが用意されています。

**ガイド位置の単位は何ですか？**

位置はポイントで指定され、1 インチは 72 ポイントに相当します。垂直位置は左端から、水平位置は上端から測定されます。

**描画ガイドをクリアするとシェイプやスライド コンテンツが削除または変更されますか？**

いいえ。`Clear` メソッドは選択されたコレクション内のガイドのみを削除します。シェイプやその他のスライド コンテンツは変更されません。