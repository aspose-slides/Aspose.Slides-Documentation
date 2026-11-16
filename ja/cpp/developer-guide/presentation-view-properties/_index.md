---
title: C++ でプレゼンテーションのビュー プロパティを取得および更新
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
description: "C++ 用 Aspose.Slides を使用して、PowerPoint プレゼンテーションの標準ビュー レイアウト、スライドとノートのズーム、グリッド間隔、コメントの表示を構成します。"
---
## **導入**

PowerPoint の標準ビューでは、スライドはサムネイルまたはアウトライン用のサイドペインと、下部のノートペインの間に表示されます。Aspose.Slides for C++ は、[Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) を介して、保存された編集設定を公開します。これには、ペインのレイアウト、ズームレベル、グリッド間隔、コメントの表示可否が含まれます。

## **INormalViewPropertiesについて**

[get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) を使用して、[INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) インターフェイスにアクセスします。[set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) は、アウトラインのスライドタイトル横にアイコンを表示するかどうかを制御します。[set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) は、ユーザーがサイドペインを狭めたときに最小化状態にスナップさせます。[set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) は、ウィンドウ全体で 1 つのペインを表示することを優先するかどうかを示します。

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) は、サイドペインとスライドの間の分割バーを制御します。[set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) は、ノートペイン上部の分割バーを制御します。両方とも `Minimized`、`Maximized`、または `Restored` のいずれかの [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) 値を受け取ります。

## **INormalViewPropertiesの復元について**

分割バーが復元されると、[get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) はサイドペインの保存されたサイズを、[get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) は上部スライド領域の保存されたサイズを提供します。両方とも [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) を公開します。その [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) メソッドは 0 から 100 のパーセンテージを受け取り、[set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) はウィンドウのサイズ変更時にエディタがサイズを自動調整するかどうかを制御します。

この例は既存のプレゼンテーションを更新します。水平分割バーを復元し、[get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) で公開される上部スライド領域のサイズを自動調整を有効にした状態で 80% に設定し、垂直分割バーを最大化します。また、アウトラインビューで[set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) を使用してアウトラインアイコンを有効にします。

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```
## **デフォルトズーム値の設定**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) と [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) はエディタ用に個別のズーム設定を保存します。これらの設定はスライドのサイズ、スライドショーの再生、または画像エクスポートの解像度には影響しません。

この例は既存のプレゼンテーションを開き、[set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) を使用して編集ウィンドウに合わせてスライドを自動的に拡大縮小するように有効にします。ノートページでは自動拡大縮小を無効にし、[set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) で固定 80% ズームを設定します。

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```
## **グリッド間隔の設定**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) はプレゼンテーション全体の編集グリッド線間の距離を設定します。1 インチあたり 72 ポイントで、正のポイント値を受け取ります。この例は既存のプレゼンテーションで現在の間隔を出力し、間隔を 18 ポイントに設定して 1/4 インチのグリッドを保存します。

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```
グリッドは固定間隔で繰り返されます。[Drawing guides](/slides/ja/cpp/drawing-guides/) は個別の水平または垂直位置をマークします。両方とも編集支援機能であり、表示するエディタでのみ見えます。スライドショーや PDF、画像、SVG へのエクスポートでは表示されません。

## **プレゼンテーションを開くときにコメントを表示または非表示にする**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) は、互換性のあるエディタがプレゼンテーションを開く際に使用する設定を保存します。コメント付きの既存プレゼンテーションに対して、この例は現在の設定を出力し、コメントを非表示にしたコピーを保存します。また、[set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) に[ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) を渡して、コピーをスライドビューで開くようにします。

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```
コメントを非表示にすると、テキスト、作者、位置、返信、ステータスは保持されます。コメント自体を変更するには、[Presentation Comments](/slides/ja/cpp/presentation-comments/) を参照してください。エクスポート設定は、PDF、HTML、画像、ノート、ハンドアウトにコメントを表示するかどうかを制御します。

## **FAQ**

**Why is the grid hidden when I reopen the presentation?**

プレゼンテーションはグリッド間隔を保存しています。グリッドを表示するには、エディタでグリッドの表示を有効にしてください。

**Does clearing drawing guides change the grid spacing?**

いいえ。ガイドを追加、移動、またはクリアしてもグリッド間隔は変わりません。

**Can different sections of a presentation have different view settings?**

いいえ。[Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) はプレゼンテーション全体に適用されます。

**Can I save different view settings for different users?**

ファイルはすべてのユーザーに対して 1 つのビュー設定のみを保存します。エディタはユーザー固有のローカル設定を適用することもあります。

**Can I save view settings in a template?**

はい。テンプレートから作成されたプレゼンテーションは、保存されたビュー設定を継承します。