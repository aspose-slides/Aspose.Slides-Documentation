---
title: プレゼンテーションビューのプロパティ
type: docs
url: /net/presentation-view-properties/
keywords: "PowerPointビューワー, ビューアプロパティ, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointプレゼンテーションビューワーのプロパティ"
---

{{% alert color="primary" %}} 

通常のビューは、スライド自体、サイドコンテンツ領域、および下部コンテンツ領域の3つのコンテンツ領域で構成されています。さまざまなコンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはそのビュー状態をファイルに保存でき、再度開いたときには、プレゼンテーションが最後に保存されたときと同じ状態にビューが戻ります。

プロパティ [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) が追加され、プレゼンテーションの通常ビューのプロパティにアクセスできるようになりました。

[**INormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties)、[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties)インターフェイスおよびその子孫、[**SplitterBarStateType**](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) 列挙体が追加されました。

{{% /alert %}} 



## **INormalViewPropertiesについて** #

通常ビューのプロパティを表します。

プロパティ **ShowOutlineIcons** は、アプリケーションが通常ビュー モードの任意のコンテンツ領域でアウトラインコンテンツを表示する場合にアイコンを表示するかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さい場合に、垂直スプリッターが最小化状態にスナップするかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが3つのコンテンツ領域を持つ標準の通常ビューよりもウィンドウ全体を占める単一コンテンツ領域を表示することを好むかどうかを指定します。有効な場合、アプリケーションはウィンドウ全体に1つのコンテンツ領域を表示することを選択できます。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッターバーが表示されるべき状態を指定します。水平スプリッターバーはスライドとその下のコンテンツ領域を分離し、垂直スプリッターバーはスライドとサイドコンテンツ領域を分離します。可能な値は **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** および **SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**SplitterBarStateType.Restored** 値がそれぞれ **VerticalBarState** と **HorizontalBarState** に適用された場合の通常ビューの上部または側面スライド領域のサイズを指定します。



## **INormalViewRestoredPropertiesについて** #

通常ビューのスライド領域のサイズ（RestoredTopの子の場合の幅、RestoredLeftの子の場合の高さ）を指定します。この領域が可変の復元サイズ（最小化も最大化もされていない）であるときです。

プロパティ **DimensionSize** は、スライド領域のサイズ（restoredTopの子の場合の幅、restoredLeftの子の場合の高さ）を指定します。

プロパティ **AutoAdjust** は、アプリケーション内のビューを含むウィンドウのリサイズ時に、サイドコンテンツ領域のサイズが新しいサイズに補償されるかどうかを指定します。

以下の例では、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示します。

```c#
// プレゼンテーションファイルを表すプレゼンテーションオブジェクトをインスタンス化
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```




## **デフォルトのズーム値を設定する**
Aspose.Slides for .NETは、プレゼンテーションが開かれたときにズームがすでに設定されているように、デフォルトのズーム値を設定することをサポートしています。これはプレゼンテーションの [**ViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) を設定することで実現できます。スライドビューのプロパティおよび [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) はプログラム的に設定できます。このトピックでは、Aspose.Slidesでプレゼンテーションのビューのプロパティを設定する方法を例を交えて見ていきます。

ビューのプロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. プレゼンテーションのビュー [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) を設定します。
1. プレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、スライドビューとノートビューのズーム値を設定しました。

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // プレゼンテーションのビュー プロパティを設定

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // スライドビューのズーム値（パーセンテージ）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // ノートビューのズーム値（パーセンテージ）

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```



## **ビューのプロパティを設定する**
ビューのプロパティを設定するには、以下の手順に従ってください。

1. Presentationクラスのインスタンスを作成します。
1. プレゼンテーションのビューのプロパティを設定します。
1. プレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、スライドビューとノートビューのズーム値を設定しました。

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // プレゼンテーションのビュー プロパティを設定

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // スライドビューのズーム値（パーセンテージ）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // ノートビューのズーム値（パーセンテージ）

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```