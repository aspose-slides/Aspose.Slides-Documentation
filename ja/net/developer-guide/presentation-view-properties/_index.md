---
title: プレゼンテーション ビュー プロパティ
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
- 寸法サイズ
- 自動調整
- デフォルトズーム
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint プレゼンテーションのビュー プロパティを管理する"
---

{{% alert color="primary" %}} 

標準ビューは3つのコンテンツ領域で構成されています。スライド本体、サイドコンテンツ領域、そして下部コンテンツ領域です。各コンテンツ領域の位置に関連するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存された時と同じ状態で表示されます。

プレゼンテーションの標準ビュー プロパティへのアクセスを提供するために、プロパティ [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) が追加されました。

[INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) インターフェイスとその子孫、[SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) 列挙体が追加されました。

{{% /alert %}}

## **INormalViewProperties について**

標準ビューのプロパティを表します。

プロパティ **ShowOutlineIcons** は、標準ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示すべきかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さい場合に、垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが3つのコンテンツ領域を持つ標準ビューではなく、ウィンドウ全体で単一のコンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することを選択できる場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッターバーが表示される状態を指定します。水平スプリッターバーはスライドとスライド下部のコンテンツ領域を分離し、垂直スプリッターバーはスライドとサイドコンテンツ領域を分離します。可能な値は **SplitterBarStateType.Minimized、SplitterBarStateType.Maximized、SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** にそれぞれ **SplitterBarStateType.Restored** が適用された場合の、標準ビューにおける左側または上側のスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

標準ビューにおいて、領域が可変の復元サイズ（最小化でも最大化でもない）である場合の、スライド領域のサイズ（RestoredTop の子要素の場合は幅、RestoredLeft の子要素の場合は高さ）を指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（restoredTop の子要素の場合は幅、restoredLeft の子要素の場合は高さ）を指定します。

プロパティ **AutoAdjust** は、アプリケーション内でビューを含むウィンドウのサイズ変更時に、サイドコンテンツ領域のサイズが新しいサイズに合わせて調整されるかどうかを指定します。

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

Aspose.Slides for .NET は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルトのズーム値を設定する機能をサポートするようになりました。これは、プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) を設定することで実現できます。スライドビュー プロパティだけでなく、[NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) もプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する例を紹介します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成する
2. プレゼンテーションのビュー[Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) を設定する
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

**プレゼンテーションのセクションごとに異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) はプレゼンテーション レベルで定義されており（[Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)）、セクション単位ではありません。そのため、開く際には単一のパラメータセットがドキュメント全体に適用されます。

**異なるユーザーごとに異なるビュー状態を事前に定義できますか？**

いいえ。設定はファイルに保存され、共有されます。ビューアー アプリケーションはユーザーの設定を尊重することはありますが、ファイル自体には単一のビュー プロパティが含まれています。

**事前定義された View Properties を持つテンプレートを作成し、新しいプレゼンテーションを同じ方式で開くようにできますか？**

はい。[view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込み、同じ初期ビュー設定で新しいドキュメントを作成できます。