---
title: .NET でプレゼンテーションのビュー プロパティを取得および更新
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
- シングル ビュー
- バー の 状態
- ディメンション サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のビュー プロパティを活用し、PPT、PPTX、ODP スライドの形式をカスタマイズ。レイアウト、ズーム レベル、表示設定を調整できます。"
---
## **概要**

標準ビューは 3 つのコンテンツ領域で構成されます。スライド自体、サイドコンテンツ領域、そしてボトムコンテンツ領域です。これらのコンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

プロパティ [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/iviewproperties/properties/normalviewproperties) が追加され、プレゼンテーションの標準ビュー プロパティへのアクセスが可能になりました。

[INormalViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/inormalviewrestoredproperties) インターフェイスとその派生、[SplitterBarStateType](https://reference.aspose.com/slides/ja/net/aspose.slides/splitterbarstatetype) 列挙型が追加されました。

## **INormalViewProperties について**

標準ビュー プロパティを表します。

プロパティ **ShowOutlineIcons** は、標準ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さくなったときに垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが 3 つのコンテンツ領域を持つ標準ビューではなく、単一のコンテンツ領域を全画面で表示することを好むかどうかを指定します。有効にすると、アプリケーションはウィンドウ全体に 1 つのコンテンツ領域を表示することを選択できる場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分離します。可能な値は **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**、**SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** に **SplitterBarStateType.Restored** が適用された場合の、標準ビューにおける左側または上側のスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）であるときの、標準ビューのスライド領域（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）のサイズを指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

プロパティ **AutoAdjust** は、ウィンドウのサイズ変更時にサイド コンテンツ領域のサイズが新しいサイズに合わせて自動調整されるべきかどうかを指定します。

以下の例は、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // プレゼンテーションのビュー プロパティを復元
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **デフォルトズーム値の設定**

Aspose.Slides for .NET は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルト ズーム値を設定できるようになりました。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties) を設定することで実現できます。スライド ビュー プロパティだけでなく、[NotesViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/properties/notesviewproperties) もプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する方法を例で示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します
1. プレゼンテーションのビュー [Properties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties) を設定します
1. プレゼンテーションを PPTX ファイルとして保存します

以下の例では、スライドビューとノートビューの両方のズーム値を設定しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // プレゼンテーションのビュー プロパティを設定
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // スライド ビューのズーム値（パーセンテージ）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // ノート ビューのズーム値（パーセンテージ）

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **グリッド間隔の設定**

[Presentation.ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/viewproperties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。プロパティ [IViewProperties.GridSpacing](https://reference.aspose.com/slides/ja/net/aspose.slides/iviewproperties/gridspacing/) は、基礎となる編集グリッドの間隔を取得または変更します。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイント単位で指定され、72 ポイントが 1 インチに相当します。API ドキュメントの要件に従い、正の値を使用してください。

以下の例は、既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、1/4 インチの間隔に設定して結果を保存します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

グリッドは [drawing guides](/slides/ja/net/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御しますが、描画ガイドは個別に配置された水平または垂直の整列ラインです。描画ガイドを追加、移動、またはクリアしてもグリッド間隔は変わりません。

グリッドも描画ガイドも編集補助機能です。PDF、画像、SVG、スライドショーとしてレンダリングされるスライド コンテンツには含まれません。グリッド間隔を保存しても、エディタが必ずグリッドを表示するわけではなく、表示はビューアまたはエディタの設定に依存します。

## **よくある質問**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルはグリッド間隔を保存しますが、エディタ側でグリッドの表示/非表示を制御します。エディタのグリッド表示設定を確認してください。

**描画ガイドをクリアするとグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は別々の設定です。ガイドをクリアしても保存されたグリッド間隔は変わりません。

**プレゼンテーションのセクションごとに異なるビュー設定を行うことはできますか？**

[View settings](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/viewproperties/) はプレゼンテーション レベル（[Normal View](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/slideviewproperties/)）で定義され、セクションごとには設定できません。そのため、ドキュメントを開くときは単一のパラメータセットが全体に適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションがユーザー設定を優先することはありますが、ファイル自体には 1 つのビュー プロパティセットしか含まれません。

**テンプレートに事前定義された View Properties を埋め込んで、新規プレゼンテーションを同じ表示状態で開くことは可能ですか？**

可能です。ビュー プロパティはプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、新規ドキュメントを作成する際に同じ初期ビュー構成で開くことができます。