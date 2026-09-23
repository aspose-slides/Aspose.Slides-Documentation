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
- 単一ビュー
- バー状態
- 次元サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のビュー プロパティを活用し、PPT、PPTX、ODP スライドの形式をカスタマイズしましょう。レイアウトやズーム レベル、表示設定を調整できます。"
---
## **Introduction**

通常ビューは 3 つのコンテンツ領域で構成されます。スライド自体、サイドコンテンツ領域、そして下部コンテンツ領域です。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

プロパティ [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/iviewproperties/properties/normalviewproperties) が追加され、プレゼンテーションの通常ビュー プロパティへのアクセスが提供されました。

[INormalViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/inormalviewrestoredproperties) インターフェイスとその派生、[SplitterBarStateType](https://reference.aspose.com/slides/ja/net/aspose.slides/splitterbarstatetype) 列挙型が追加されました。

## **About INormalViewProperties**

通常ビューのプロパティを表します。

プロパティ **ShowOutlineIcons** は、通常ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する場合にアイコンを表示するかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さくなったときに垂直スプリッタが最小化状態にスナップするかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが 3 つのコンテンツ領域を持つ標準の通常ビューではなく、全ウィンドウで単一コンテンツ領域を表示したいかどうかを指定します。有効にすると、アプリケーションはウィンドウ全体にコンテンツ領域の 1 つを表示することを選択できる場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライドの下部コンテンツ領域を分割し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分割します。可能な値は **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**、**SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** にそれぞれ **SplitterBarStateType.Restored** が適用されたときの、通常ビューの上部またはサイドスライド領域のサイズを指定します。

## **About Restoring INormalViewProperties**

領域が可変の復元サイズ（最小化でも最大化でもない）である場合の、通常ビューのスライド領域（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）のサイズを指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

プロパティ **AutoAdjust** は、ウィンドウのサイズ変更時にサイドコンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるかどうかを指定します。

以下の例は、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // プレゼンテーションのビュー プロパティを復元する
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Set the Default Zoom Value**

Aspose.Slides for .NET は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルト ズーム値の設定をサポートするようになりました。これは、プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties) を設定することで実現できます。スライド ビュー プロパティだけでなく、[NotesViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/properties/notesviewproperties) もプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する方法をサンプルで示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成
2. プレゼンテーションのビュー [Properties](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties) を設定
3. プレゼンテーションを PPTX ファイルとして書き出し

以下のサンプルでは、スライド ビューとノート ビューの両方にズーム値を設定しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // プレゼンテーションのビュー プロパティを設定する
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // スライドビューのズーム値（パーセンテージ）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // ノートビューのズーム値（パーセンテージ） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Set the Grid Spacing**

[Presentation.ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/viewproperties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。プロパティ [IViewProperties.GridSpacing](https://reference.aspose.com/slides/ja/net/aspose.slides/iviewproperties/gridspacing/) は、基礎となる編集グリッドの間隔を読み取るか変更します。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API ドキュメントで求められているように、正の値を使用してください。

次の例は既存の `demo.pptx` を開き、現在のグリッド間隔を出力し、1/4 インチ間隔に設定して結果を保存します。

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

グリッドは [drawing guides](/slides/ja/net/drawing-guides/) とは異なります。グリッド間隔は規則的な間隔を制御するのに対し、描画ガイドは個別に配置された水平または垂直の整列線です。描画ガイドを追加、移動、またはクリアしてもグリッド間隔は変更されません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、スライドショーとしてレンダリングされるスライド コンテンツには含まれません。グリッド間隔を保存しても、エディタがグリッドを表示するかどうかは保証されません。表示はビューアやエディタの設定にも依存します。

## **Show or Hide Comments When Opening a Presentation**

[Presentation.ViewProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/viewproperties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[IViewProperties.ShowComments](https://reference.aspose.com/slides/ja/net/aspose.slides/iviewproperties/showcomments/) を読み取るか変更して、PowerPoint やその他の対応エディタでプレゼンテーションを開く際にコメントを表示するかどうかの設定を保存できます。

この設定は保存されたビューの優先設定のみを制御します。コメントの追加、削除、編集、解決は行いません。コメントを非表示にしても、コメントの内容、作成者、位置、返信、ステータスは保持されます。コメント自体を変更する操作については、[Presentation Comments](/slides/ja/net/presentation-comments/) を参照してください。

以下の例は、コメントが含まれた既存の `comments.pptx` を使用します。現在の可視性設定を出力し、コメントを非表示に設定して新しい PPTX を保存します。また、[IViewProperties.LastView](https://reference.aspose.com/slides/ja/net/aspose.slides/iviewproperties/lastview/) を [ViewType.SlideView](https://reference.aspose.com/slides/ja/net/aspose.slides/viewtype/) に設定し、コメントの可視性とともに初期編集ビューを構成します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

この設定は、PDF、HTML、画像、ノート、または配布資料のエクスポート時にコメントが含まれるかどうかを決定するものではありません。エクスポート固有のオプションは別途構成してください。

## **FAQ**

**なぜプレゼンテーションを再度開いたときにグリッドが表示されないのですか？**

ファイルはグリッド間隔を保存しますが、エディタがグリッドを表示するかはエディタ側の設定に依存します。エディタのグリッド表示設定をご確認ください。

**描画ガイドをクリアしてもグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても保存されたグリッド間隔は変わりません。

**プレゼンテーションのセクションごとに異なるビュー設定を持たせることはできますか？**

[View settings](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/viewproperties/) はプレゼンテーション レベルで定義され（[Normal View](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ja/net/aspose.slides/viewproperties/slideviewproperties/)）、セクションごとではありません。そのため、ドキュメント全体に対して単一のパラメータセットが適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションがユーザーの好みを尊重することはありますが、ファイル自体には 1 つのビュー プロパティセットしか含まれません。

**テンプレートに事前定義されたビュー プロパティを埋め込んで、新規プレゼンテーションを同じ設定で開かせることは可能ですか？**

可能です。ビュー プロパティはプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、新規ドキュメントを作成したときに同じ初期ビュー構成で開くことができます。