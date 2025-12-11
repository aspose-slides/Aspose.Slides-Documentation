---
title: C++でプレゼンテーションのビュー プロパティを取得および更新
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/cpp/presentation-view-properties/
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
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のビュー プロパティを活用して、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズームレベル、表示設定を調整します。"
---

{{% alert color="primary" %}} 

標準ビューは 3 つのコンテンツ領域で構成されます：スライド自体、サイドコンテンツ領域、そして下部コンテンツ領域です。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

プレゼンテーションの標準ビュー プロパティにアクセスできるよう、メソッド [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) が追加されました。

[INormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) インターフェイスとその子孫、[SplitterBarStateType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950) 列挙体が追加されました。

{{% /alert %}} 

## **INormalViewProperties について**

標準ビュー プロパティを表します。

プロパティ **ShowOutlineIcons** は、標準ビュー モードのいずれかのコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示するかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さい場合に、垂直スプリッタを最小化状態にスナップするかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが標準の 3 つのコンテンツ領域を持つ標準ビューよりも、全画面の単一コンテンツ領域を好むかどうかを指定します。有効にすると、アプリケーションはコンテンツ領域のいずれかをウィンドウ全体に表示することを選択できる場合があります。

プロパティ **VerticalBarState** および **HorizontalBarState** は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイドコンテンツ領域を分離します。可能な値は **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**、**SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** に **SplitterBarStateType.Restored** が適用された場合の、標準ビューの上部またはサイドのスライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

標準ビューのスライド領域のサイズ（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）を、領域が可変の復元サイズ（最小化でも最大化でもない）である場合に指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）を指定します。

プロパティ **AutoAdjust** は、アプリケーション内でビューを含むウィンドウのサイズを変更したときに、サイドコンテンツ領域のサイズが新しいサイズに合わせて調整されるかどうかを指定します。

以下の例は、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。
```cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// プレゼンテーションのビュー プロパティを復元する
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **デフォルトのズーム値を設定する**

Aspose.Slides for C++ は、プレゼンテーションを開いたときにズームが既に設定された状態になるよう、デフォルトのズーム値を設定できるようになりました。これはプレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) を設定することで実現できます。スライド ビュー プロパティおよび [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) もプログラムで設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する方法を例で示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成する
1. プレゼンテーションのビュー [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) を設定する
1. プレゼンテーションを PPTX ファイルとして書き出す

以下の例では、スライドビューとノートビューの両方のズーム値を設定しています。
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// プレゼンテーションのビュー プロパティを設定
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // スライド ビューのズーム値（パーセンテージ）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // ノート ビューのズーム値（パーセンテージ） 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**プレゼンテーションの異なるセクションに対して異なるビュー設定を行うことはできますか？**

[View settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) はプレゼンテーション レベルで定義されており（[Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)）、セクションごとではありません。そのため、開いたときにはドキュメント全体に単一のパラメータセットが適用されます。

**異なるユーザー向けに異なるビュー状態を事前に定義することはできますか？**

いいえ。設定はファイルに保存されて共有されます。ビューア アプリケーションはユーザーの設定を尊重することがありますが、ファイル自体は 1 つのビュー プロパティセットしか含みません。

**事前定義された View Properties を持つテンプレートを用意し、新しいプレゼンテーションが同じ設定で開くようにできますか？**

はい。[view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、同じ初期ビュー構成で新しいドキュメントを作成できます。