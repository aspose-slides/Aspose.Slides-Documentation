---
title: C++ でプレゼンテーションのビュー プロパティを取得および更新
linktitle: ビュー プロパティ
type: docs
weight: 80
url: /ja/cpp/presentation-view-properties/
keywords:
- ビュー プロパティ
- 通常ビュー
- アウトライン コンテンツ
- アウトライン アイコン
- 垂直スプリッタのスナップ
- 単一ビュー
- バーの状態
- 次元サイズ
- 自動調整
- デフォルト ズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のビュー プロパティを活用して、PPT、PPTX、ODP 形式のスライドをカスタマイズし、レイアウトやズームレベル、表示設定を調整します。"
---
## **概要**

通常ビューは、スライド自体、サイドコンテンツ領域、下部コンテンツ領域の3つのコンテンツ領域で構成されます。各コンテンツ領域の配置に関するプロパティです。この情報により、アプリケーションはビューの状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

Method [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) が追加され、プレゼンテーションの通常ビュー プロパティへのアクセスが提供されました。

[INormalViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inormalviewrestoredproperties/) インターフェイスとその派生、[SplitterBarStateType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/splitterbarstatetype/) 列挙体が追加されました。

## **INormalViewProperties について**

通常ビューのプロパティを表します。

プロパティ **ShowOutlineIcons** は、通常ビュー モードの任意のコンテンツ領域にアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示すべきかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さくなったときに垂直スプリッタが最小化状態にスナップするかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが標準の3領域ビューではなく、ウィンドウ全体に単一コンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションは 1 つのコンテンツ領域をウィンドウ全体に表示することを選択できる場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッタ バーが表示される状態を指定します。水平スプリッタ バーはスライドとスライド下のコンテンツ領域を分離し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分離します。可能な値は **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**、**SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** と **HorizontalBarState** に **SplitterBarStateType.Restored** が適用された場合の、通常ビューにおける左側または上側スライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

領域が可変の復元サイズ（最小化でも最大化でもない）である場合の、通常ビューにおけるスライド領域（RestoredTop の子では幅、RestoredLeft の子では高さ）のサイズを指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（restoredTop の子では幅、restoredLeft の子では高さ）を指定します。

プロパティ **AutoAdjust** は、ウィンドウのサイズ変更時にサイド コンテンツ領域のサイズが新しいサイズに合わせて自動的に調整されるかどうかを指定します。

以下の例は、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示しています。

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// プレゼンテーションのビュー プロパティを復元
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **デフォルト ズーム 値の設定**

Aspose.Slides for C++ は、プレゼンテーションを開くと自動的にズームが設定された状態にできるデフォルト ズーム 値の設定をサポートするようになりました。これは、プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/) を設定することで実現できます。スライドビュー プロパティだけでなく、[get_NotesViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/get_notesviewproperties/) もプログラムから設定可能です。このトピックでは、Aspose.Slides でプレゼンテーションのビュー プロパティを設定する例を示します。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成する
2. プレゼンテーションのビュー [Properties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/) を設定する
3. プレゼンテーションを PPTX ファイルとして保存する

以下の例では、スライドビューとノートビューの両方のズーム値を設定しています。

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// プレゼンテーションのビュー プロパティを設定
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // スライドビューのズーム値（パーセンテージ）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // ノートビューのズーム値（パーセンテージ）

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **グリッド間隔の設定**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_viewproperties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。 [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/get_gridspacing/) および [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/set_gridspacing/) メソッドで、基礎となる編集グリッドの間隔を取得または変更できます。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定され、72 ポイントが 1 インチに相当します。API のドキュメントで要求されているように、正の値を使用してください。

以下の例は既存の `demo.pptx` を開き、現在のグリッド間隔を表示し、1/4 インチの間隔に設定して結果を保存します。

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

グリッドは [drawing guides](/slides/ja/cpp/drawing-guides/) とは異なります。グリッド間隔は一定間隔を制御しますが、描画ガイドは個別に配置された水平または垂直の整列線です。描画ガイドを追加、移動、削除してもグリッド間隔は変わりません。

グリッドも描画ガイドも編集支援ツールです。PDF、画像、SVG、スライドショーとしてレンダリングされるスライドコンテンツには含まれません。グリッド間隔を保存しても、エディタがグリッドを表示するかどうかは保証されません。表示はビューアやエディタの設定に依存します。

## **プレゼンテーションを開くときのコメントの表示/非表示**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_viewproperties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。 [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/get_showcomments/) と [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/set_showcomments/) を使用して、PowerPoint や他の互換エディタでプレゼンテーションを開く際にコメントを表示するかどうかの設定を保存できます。

この設定は保存されたビューの好みを制御するだけで、コメントそのものの追加、削除、編集、解決は行いません。コメントを非表示にしても、内容、作者、位置、返信、ステータスは保持されます。コメントそのものを変更する操作については、[Presentation Comments](/slides/ja/cpp/presentation-comments/) を参照してください。

以下の例は、コメントが含まれる既存の `comments.pptx` を使用します。現在の表示設定を出力し、コメントを非表示に設定し、コメントを削除せずに新しい PPTX を保存します。また、[IViewProperties::set_LastView](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/set_lastview/) と [ViewType::SlideView](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewtype/) を組み合わせて、コメントの可視性とともに初期編集ビューを設定します。

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

この設定は、PDF、HTML、画像、ノート、配布資料へのエクスポート時にコメントが含まれるかどうかを決定するものではありません。エクスポート固有のオプションは別途設定してください。

## **FAQ**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルはグリッド間隔を保存しますが、エディタ側でグリッドの表示/非表示を制御します。エディタのグリッド表示設定を確認してください。

**描画ガイドを削除してもグリッド間隔は変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても保存されたグリッド間隔はそのままです。

**プレゼンテーションのセクションごとに異なるビュー設定を行うことはできますか？**

[View settings](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_viewproperties/) はプレゼンテーションレベル（[Normal View](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/get_slideviewproperties/)）で定義され、セクション単位ではありません。そのため、ドキュメント全体に対して一組のパラメータが適用されます。

**ユーザーごとに異なるビュー状態を事前に定義できますか？**

できません。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア側がユーザー設定を優先することはありますが、ファイル自体には単一のビュー プロパティしか含まれません。

**テンプレートに事前定義したビュー プロパティを埋め込んで、新規プレゼンテーションを同じ表示状態で開くことは可能ですか？**

可能です。[view properties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_viewproperties/) はプレゼンテーションレベルで保存されるため、テンプレートに埋め込めば新規作成時に同じ初期ビュー構成で開くことができます。