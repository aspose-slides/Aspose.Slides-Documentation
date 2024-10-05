---
title: プレゼンテーションビューのプロパティ
type: docs
url: /cpp/presentation-view-properties/
---

{{% alert color="primary" %}} 

通常のビューは、スライド自体、側面のコンテンツ領域、下部のコンテンツ領域という3つのコンテンツ領域で構成されています。異なるコンテンツ領域の配置に関するプロパティ。この情報により、アプリケーションはそのビューの状態をファイルに保存でき、再度開いたときに、プレゼンテーションが最後に保存されたときと同じ状態になります。

メソッド [**IViewProperties::get_NormalViewProperties()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06)が追加され、プレゼンテーションの通常ビューのプロパティにアクセスできるようになりました。 

[**INormalViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties)、[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties)インターフェイスとその子孫、[**SplitterBarStateType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950)列挙型が追加されました。

{{% /alert %}} 



## **INormalViewPropertiesについて** #

通常のビューのプロパティを表します。

プロパティ **ShowOutlineIcons** は、通常のビュー モードのコンテンツ領域のいずれかにアウトライン コンテンツを表示する場合に、アプリケーションがアイコンを表示するかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、側面の領域が十分に小さい場合に、垂直スプリッタが最小化された状態にスナップするかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが3つのコンテンツ領域を持つ通常のビューよりも、フルウィンドウの単一コンテンツ領域を表示したいかどうかを指定します。これが有効になっている場合、アプリケーションはウィンドウ全体に1つのコンテンツ領域を表示することを選択する場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直のスプリッターバーが表示される状態を指定します。水平スプリッターバーはスライドをその下のコンテンツ領域から分離し、垂直スプリッターバーはスライドを側面のコンテンツ領域から分離します。可能な値は、**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** および **SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**SplitterBarStateType.Restored** の値が **VerticalBarState** および **HorizontalBarState** に適用されたときの、通常のビューの上部または側面のスライド領域のサイズを指定します。



## **INormalViewRestoredPropertiesについて** #

通常のビューでのスライド領域のサイズ ((RestoredTop の子の場合の幅、RestoredLeft の子の場合の高さ) を指定し、その領域が可変の復元サイズ (最小化されても最大化されてもいない) の場合を指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ (RestoredTop の子の場合の幅、RestoredLeft の子の場合の高さ) を指定します。

プロパティ **AutoAdjust** は、アプリケーション内のビューを含むウィンドウをリサイズする際に、側面のコンテンツ領域のサイズが新しいサイズを補償するかどうかを指定します。

以下の例は、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。

``` cpp
//プレゼンテーションファイルを表すプレゼンテーションオブジェクトをインスタンス化
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **デフォルトのズーム値を設定する**
Aspose.Slides for C++ は、プレゼンテーションが開かれるときにズームがすでに設定されるように、プレゼンテーションのデフォルトのズーム値を設定することをサポートしています。これは、プレゼンテーションの [**ViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) を設定することで行うことができます。スライドビューのプロパティおよび [get_NotesViewProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) はプログラムで設定することができます。このトピックでは、Aspose.Slides でプレゼンテーションのビュープロパティを設定する方法を例を用いて見ていきます。

ビュープロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. プレゼンテーションのビュープロパティを設定します。
1. プレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、スライドビューとノートビューのズーム値を設定しました。

``` cpp
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
// プレゼンテーションのビュープロパティ設定

presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// スライドビューのズーム値（パーセンテージ）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);
// ノートビューのズーム値（パーセンテージ） 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```



## **ビュープロパティを設定する**
ビュープロパティを設定するには、以下の手順に従ってください。

1. プレゼンテーションクラスのインスタンスを作成します。
1. プレゼンテーションのビュープロパティを設定します。
1. プレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、スライドビューとノートビューのズーム値を設定しました。

``` cpp
// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// プレゼンテーションのビュープロパティ設定
// スライドビューのズーム値（パーセンテージ）
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// ノートビューのズーム値（パーセンテージ）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```