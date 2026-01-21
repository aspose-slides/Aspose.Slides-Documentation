---
title: C++ のプレゼンテーション ビュー プロパティの取得と更新
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
- 寸法 サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のビュー プロパティを活用して、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウトやズームレベル、表示設定を調整しましょう。"
---

{{% alert color="primary" %}} 

通常ビューは3つのコンテンツ領域で構成されます: スライド自体、側面コンテンツ領域、下部コンテンツ領域です。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

メソッド[IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/)が追加され、プレゼンテーションの通常ビュー プロパティにアクセスできるようになりました。

[INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/)インターフェイスとその派生型、[SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/)列挙体が追加されました。

{{% /alert %}} 

## **INormalViewProperties について**

通常ビューのプロパティを表します。

プロパティ**ShowOutlineIcons**は、通常ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

プロパティ**SnapVerticalSplitter**は、側面領域が十分に小さい場合に、垂直スプリッタが最小化状態にスナップすべきかどうかを指定します。

プロパティ**PreferSingleView**は、ユーザーが3つのコンテンツ領域を持つ標準の通常ビューではなく、ウィンドウ全体に単一のコンテンツ領域を表示するフルウィンドウ表示を好むかどうかを指定します。有効にすると、アプリケーションはウィンドウ全体に1つのコンテンツ領域を表示することを選択できる場合があります。

プロパティ**VerticalBarState**および**HorizontalBarState**は、水平スプリッタバーまたは垂直スプリッタバーがどの状態で表示されるべきかを指定します。水平スプリッタバーはスライドとスライド下部のコンテンツ領域を分割し、垂直スプリッタバーはスライドと側面コンテンツ領域を分割します。可能な値は**SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**、**SplitterBarStateType.Restored**です。

プロパティ**RestoredLeft**および**RestoredTop**は、**VerticalBarState**および**HorizontalBarState**に**SplitterBarStateType.Restored**が適用された場合に、通常ビューの上部または側面スライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）である場合の、通常ビューのスライド領域（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）のサイズを指定します。

プロパティ**DimensionSize**は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

プロパティ**AutoAdjust**は、ウィンドウのサイズ変更時に、側面コンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるべきかどうかを指定します。

以下の例は、プレゼンテーションの**ViewProperties.NormalViewProperties**プロパティにアクセスする方法を示しています。
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// プレゼンテーションのビュー プロパティを復元する
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **デフォルト ズーム値の設定**

Aspose.Slides for C++ は、プレゼンテーションが開かれたときにズームが既に設定された状態になるよう、デフォルト ズーム値を設定できるようになりました。これはプレゼンテーションの[ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/)を設定することで実現できます。スライド ビュー プロパティだけでなく、[get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_notesviewproperties/)もプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する方法を例で示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します
1. プレゼンテーションのビュー[Properties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/)を設定します
1. プレゼンテーションを PPTX ファイルとして保存します

以下の例では、スライドビューとノートビューのズーム値を設定しています。
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// プレゼンテーションのビュー プロパティを設定する
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // スライドビューのズーム値（パーセンテージ）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // ノートビューのズーム値（パーセンテージ） 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **よくある質問**

**プレゼンテーションの異なるセクションごとに異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/)はプレゼンテーション レベル（[Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)）で定義されており、セクション単位ではありません。そのため、ドキュメントが開かれるときは単一のパラメーターセットが全体に適用されます。

**異なるユーザー向けに異なるビュー状態を事前に定義できますか？**

できません。設定はファイルに保存され、共有されます。ビューア アプリケーションはユーザーの好みを尊重することはありますが、ファイル自体には1つのビュー プロパティしか含まれません。

**テンプレートに事前定義された View Properties を埋め込めば、新しいプレゼンテーションが同じ方法で開くようにできますか？**

はい。[view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/)はプレゼンテーション レベルに保存されるため、テンプレートに埋め込んでおけば、そのテンプレートから作成された新しいドキュメントは同じ初期ビュー設定で開きます。