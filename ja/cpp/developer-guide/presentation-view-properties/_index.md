---
title: C++ でプレゼンテーション ビュー プロパティを取得および更新
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
- シングルビュー
- バーの状態
- 次元サイズ
- 自動調整
- デフォルトズーム
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のビュー プロパティを活用して、PPT、PPTX、ODP スライドの形式をカスタマイズし、レイアウト、ズームレベル、表示設定を調整できます。"
---
## **はじめに**

通常ビューは 3 つのコンテンツ領域で構成されています: スライド自体、サイドコンテンツ領域、そして下部コンテンツ領域です。各コンテンツ領域の位置に関するプロパティです。この情報により、アプリケーションはビュー状態をファイルに保存でき、再度開いたときにプレゼンテーションが最後に保存されたときと同じ状態で表示されます。

メソッド[IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/get_normalviewproperties/)が追加され、プレゼンテーションの通常ビュー プロパティにアクセスできるようになりました。

[INormalViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/inormalviewrestoredproperties/) インターフェイスとその子孫、および[SplitterBarStateType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/splitterbarstatetype/) 列挙体が追加されました。

## **INormalViewProperties について**

通常ビュー プロパティを表します。

プロパティ **ShowOutlineIcons** は、通常ビュー モードの任意のコンテンツ領域でアウトライン コンテンツを表示する際に、アプリケーションがアイコンを表示するかどうかを指定します。

プロパティ **SnapVerticalSplitter** は、サイド領域が十分に小さい場合に、垂直スプリッタが最小化状態にスナップするかどうかを指定します。

プロパティ **PreferSingleView** は、ユーザーが 3 つのコンテンツ領域を持つ標準の通常ビューではなく、ウィンドウ全体に単一のコンテンツ領域を表示することを好むかどうかを指定します。有効にすると、アプリケーションはウィンドウ全体にいずれかのコンテンツ領域を表示することを選択できる場合があります。

プロパティ **VerticalBarState** と **HorizontalBarState** は、水平または垂直スプリッタ バーの表示状態を指定します。水平スプリッタ バーはスライドとスライド下のコンテンツ領域を分割し、垂直スプリッタ バーはスライドとサイド コンテンツ領域を分割します。可能な値は **SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** および **SplitterBarStateType.Restored** です。

プロパティ **RestoredLeft** と **RestoredTop** は、**VerticalBarState** および **HorizontalBarState** に **SplitterBarStateType.Restored** が適用された場合に、通常ビューの上部またはサイド スライド領域のサイズを指定します。

## **INormalViewProperties の復元について**

通常ビューにおいて、領域が可変の復元サイズ（最小化でも最大化でもない）である場合に、スライド領域のサイズ（RestoredTop の子の場合は幅、RestoredLeft の子の場合は高さ）を指定します。

プロパティ **DimensionSize** は、スライド領域のサイズ（restoredTop の子の場合は幅、restoredLeft の子の場合は高さ）を指定します。

プロパティ **AutoAdjust** は、アプリケーション内でビューを含むウィンドウのサイズを変更する際に、サイド コンテンツ領域のサイズが新しいサイズに合わせて自動調整されるかどうかを指定します。

以下の例では、プレゼンテーションの **ViewProperties.NormalViewProperties** プロパティにアクセスする方法を示します。

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

// プレゼンテーションのビュー プロパティを復元する
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **デフォルトのズーム値を設定する**

Aspose.Slides for C++ は、プレゼンテーションを開いたときにすでにズームが設定された状態になるように、デフォルトのズーム値を設定できるようになりました。これは、プレゼンテーションの[ViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/) を設定することで実現できます。スライドビュー プロパティおよび[get_NotesViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/get_notesviewproperties/) もプログラムから設定可能です。このトピックでは、例を通じて Aspose.Slides でプレゼンテーションのビュー プロパティを設定する方法を見ていきます。

ビュー プロパティを設定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成する
2. プレゼンテーションのビュー[Properties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/) を設定する
3. プレゼンテーションを PPTX ファイルとして保存する

以下の例では、スライドビューとノートビューのズーム値を設定しています。

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// プレゼンテーションのビュー プロパティを設定する
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // スライド ビューのズーム値（パーセンテージ）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // ノート ビューのズーム値（パーセンテージ）

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **グリッド間隔の設定**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_viewproperties/) を使用して、プレゼンテーション全体のビュー設定にアクセスします。[IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/get_gridspacing/) および[IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iviewproperties/set_gridspacing/) メソッドは、基礎となる編集グリッドの間隔を取得または変更します。この設定は個々のスライドではなく、プレゼンテーション全体に適用されます。グリッド間隔はポイントで指定し、72 ポイントが 1 インチに相当します。API ドキュメントの指示どおり、正の値を使用してください。

以下の例では、既存の `demo.pptx` を開き、現在のグリッド間隔を出力し、1/4 インチの間隔に設定して結果を保存します。

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

グリッドは[drawing guides](/slides/ja/cpp/drawing-guides/) とは異なります。グリッド間隔は一定の間隔を制御しますが、描画ガイドは個別に配置された水平または垂直のガイドラインです。描画ガイドを追加、移動、または削除してもグリッド間隔は変わりません。

グリッドと描画ガイドはどちらも編集支援機能です。PDF、画像、SVG、またはスライドショーとしてスライドコンテンツに描画されることはありません。グリッド間隔をファイルに保存しても、エディタがグリッドを表示することが保証されるわけではなく、表示はビューアやエディタの設定に依存します。

## **よくある質問**

**プレゼンテーションを再度開いたときにグリッドが表示されないのはなぜですか？**

ファイルにはグリッド間隔が保存されていますが、エディタがグリッドの表示を制御します。エディタのグリッド表示設定を確認してください。

**描画ガイドを削除するとグリッド間隔が変わりますか？**

いいえ。描画ガイドとグリッド間隔は独立した設定です。ガイドを削除しても、保存されているグリッド間隔は変わりません。

**プレゼンテーションの異なるセクションごとに異なるビュー設定を設定できますか？**

[View settings](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_viewproperties/) はプレゼンテーション レベルで定義されており（[Normal View](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ja/cpp/aspose.slides/viewproperties/get_slideviewproperties/)）、セクションごとではありません。そのため、開く際にはドキュメント全体に同じパラメータが適用されます。

**異なるユーザー向けに異なるビュー状態を事前に定義できますか？**

いいえ。設定はファイルに保存され、すべてのユーザーで共有されます。ビューア アプリケーションはユーザーの設定を尊重することがありますが、ファイル自体は単一のビュー プロパティを保持しています。

**事前にビュー プロパティが設定されたテンプレートを用意すれば、新しいプレゼンテーションを同じ設定で開くことができますか？**

はい。[view properties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_viewproperties/) はプレゼンテーション レベルで保存されるため、テンプレートに埋め込んでおけば、新規ドキュメントを作成した際に同じ初期ビュー設定で開くことができます。