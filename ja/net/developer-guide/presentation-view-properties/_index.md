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
- シングルビュー
- バー 状態
- 寸法サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のビュー プロパティを活用し、PPT、PPTX、ODP スライドの形式をカスタマイズしましょう—レイアウト、ズームレベル、表示設定を調整できます。"
---

{{% alert color="primary" %}} 

標準ビューは3つのコンテンツ領域で構成されます: スライド自体、サイドコンテンツ領域、そして下部コンテンツ領域です。これらの領域の位置に関するプロパティです。この情報によりアプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存された時と同じ状態で表示されます。

プロパティ [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) が追加され、プレゼンテーションの標準ビュー プロパティにアクセスできるようになりました。

[INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) インターフェイスとその子孫、[SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) 列挙型が追加されました。

{{% /alert %}}

## **INormalViewProperties について**

標準ビューのプロパティを表します。

プロパティ **ShowOutlineIcons** は、標準ビュー モードのコンテンツ領域のいずれかでアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示すべきかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さくなったときに垂直スプリッタを最小化状態にスナップさせるかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが標準ビューの3つのコンテンツ領域を持つ標準表示よりも、全画面の単一コンテンツ領域の表示を好むかどうかを指定します。有効にすると、アプリケーションはウィンドウ全体に1つのコンテンツ領域を表示することを選択する場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッタバーをどの状態で表示するかを指定します。水平スプリッタバーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッタバーはスライドとサイドコンテンツ領域を分離します。可能な値は **SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** および **SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** に **SplitterBarStateType.Restored** が適用された場合の、標準ビューの上部またはサイドスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

標準ビューで領域が可変の復元サイズ（最小化でも最大化でもない）である場合に、スライド領域（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）のサイズを指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）を指定します。

プロパティ **AutoAdjust** は、ウィンドウサイズを変更したときにサイドコンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるかどうかを指定します。

以下の例は、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。
```c#
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


## **デフォルトズーム値の設定**

Aspose.Slides for .NET は、プレゼンテーションを開いたときにズームが既に設定された状態になるように、デフォルトのズーム値を設定する機能をサポートするようになりました。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) を設定することで実現できます。スライドビュー プロパティおよび [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) はプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する方法を例で示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成する
2. プレゼンテーションのビュー [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) を設定する
3. プレゼンテーションを書き出して PPTX ファイルに保存する

以下の例では、スライドビューとノートビューのズーム値を設定しています。
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // プレゼンテーションのビュー プロパティを設定する
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // スライドビューのズーム値（パーセンテージ）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // ノートビューのズーム値（パーセンテージ） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**プレゼンテーションの異なるセクションに対して異なるビュー設定を設定できますか？**

[ビュー設定](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) はプレゼンテーションレベルで定義されており（[標準ビュー](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[スライドビュー](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)）、セクションごとではありません。そのため、開く際には単一のパラメータセットがドキュメント全体に適用されます。

**異なるユーザー向けに異なるビュー状態を事前に定義できますか？**

いいえ。設定はファイルに保存され、共有されます。ビューア アプリケーションはユーザーの設定を尊重する場合がありますが、ファイル自体は 1 つのビュー プロパティセットしか含みません。

**事前定義されたビュー プロパティを含むテンプレートを作成し、新しいプレゼンテーションを同じ方法で開くことはできますか？**

はい。ビュー プロパティはプレゼンテーションレベルで保存されるため、テンプレートに埋め込めば、新しいドキュメントを作成した際に同じ初期ビュー設定で開くことができます。