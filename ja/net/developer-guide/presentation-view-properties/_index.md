---
title: .NET でプレゼンテーションのビュー プロパティを取得および更新する
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/net/presentation-view-properties/
keywords:
- ビュー プロパティ
- 標準ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- 単一ビュー
- バーの状態
- サイズの寸法
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションの標準ビュー レイアウト、スライドとノートのズーム、グリッド間隔、コメントの表示状態を構成します。"
---
## **はじめに**

PowerPoint の標準ビューでは、スライドはサムネイルやアウトライン用のサイドペインと、下部のノートペインの間に表示されます。Aspose.Slides for .NET は、プレゼンテーションの保存された編集設定を [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) を通じて公開します。これらにはペインレイアウト、ズームレベル、グリッド間隔、コメントの表示状態が含まれます。

## **INormalViewProperties について**

[NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) を使用して [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) インターフェイスにアクセスします。[ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) はアウトラインでスライドタイトルの横にアイコンを表示するかどうかを制御します。[SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) は、ユーザーがサイドペインを狭くしたときにペインを最小化状態にスナップさせます。[PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) は、ウィンドウ全体で 1 つのペインを表示することを優先するかを示します。[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) はサイドペインとスライド間の区切り線を制御します。[HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) はノートペイン上部の区切り線を制御します。両方とも `Minimized`、`Maximized`、または `Restored` のいずれかの [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) 値を受け取ります。

## **INormalViewProperties の復元について**

区切り線が復元されると、[RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) はサイドペインの保存されたサイズを提供し、[RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) は上部スライド領域の保存されたサイズを提供します。両方とも [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/) を公開します。その [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) プロパティは 0 から 100 のパーセンテージを受け取り、[AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) はウィンドウのサイズ変更時にエディタがサイズを調整するかどうかを制御します。この例は既存のプレゼンテーションを更新します。水平区切り線を復元し、[RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) を自動調整を有効にした状態で 80% に設定し、垂直区切り線を最大化します。また、アウトラインビュー用に [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) を有効にします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **デフォルトズーム値の設定**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) と [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) はエディタ用の個別のズーム設定を保存します。これらの設定はスライドのサイズ、スライドショーの再生、または画像エクスポートの解像度には影響しません。この例は既存のプレゼンテーションを開き、[VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) を有効にしてスライドを編集ウィンドウに合わせます。ノートページについては自動スケーリングを無効にし、[Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) を固定の 80% ズームに設定します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **グリッド間隔の設定**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) はプレゼンテーション全体の編集グリッド線間の距離を設定します。単位はポイントで、1 インチは 72 ポイントです。この例は既存のプレゼンテーションで現在の間隔を出力し、間隔を 18 ポイントに設定して 1/4 インチのグリッドを保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

グリッドは固定間隔で繰り返されます。[Drawing guides](/slides/ja/net/drawing-guides/) は個々の水平または垂直位置を示すガイドです。どちらも編集支援ツールであり、表示できるエディタでのみ表示されます。スライドショーや PDF、画像、SVG へのエクスポートでは表示されません。

## **プレゼンテーションを開くときのコメントの表示/非表示**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) は、対応するエディタがプレゼンテーションを開く際に使用する設定を保存します。コメントが含まれる既存のプレゼンテーションについて、この例は現在の設定を出力し、コメントを非表示にしたコピーを保存します。また、[LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) を [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) に設定して、コピーがスライドビューで開くようにします。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

コメントを非表示にしても、テキスト、作成者、位置、返信、ステータスは保持されます。コメントそのものを変更するには、[Presentation Comments](/slides/ja/net/presentation-comments/) を参照してください。エクスポート設定により、PDF、HTML、画像、ノート、ハンドアウトにコメントを含めるかどうかが決まります。

## **FAQ**

**プレゼンテーションを再度開くときにグリッドが非表示になるのはなぜですか？**  
プレゼンテーションはグリッド間隔を保存しています。グリッドを表示するには、エディタでグリッドの表示を有効にしてください。

**描画ガイドを削除してもグリッド間隔は変わりますか？**  
いいえ。ガイドを追加、移動、削除してもグリッド間隔は変わりません。

**プレゼンテーションの異なるセクションでビュー設定を変更できますか？**  
いいえ。[Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) はプレゼンテーション全体に適用されます。

**異なるユーザーごとに異なるビュー設定を保存できますか？**  
ファイルはすべてのユーザーに対して 1 つのビュー設定を保存します。エディタはユーザー固有のローカル設定を適用することもあります。

**テンプレートにビュー設定を保存できますか？**  
はい。テンプレートから作成されたプレゼンテーションは、テンプレートに保存されたビュー設定を継承します。