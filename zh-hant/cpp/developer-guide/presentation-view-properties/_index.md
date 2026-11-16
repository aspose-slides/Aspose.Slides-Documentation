---
title: 在 C++ 中檢索與更新簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/cpp/presentation-view-properties/
keywords:
- 檢視屬性
- 普通檢視
- 大綱內容
- 大綱圖示
- 貼齊垂直分割線
- 單一檢視
- 分割線狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中設定普通檢視佈局、投影片與備註的縮放、格線間距以及註解可見性。"
---
## **簡介**

在 PowerPoint 的普通檢視中，投影片顯示在左側的縮圖或大綱窗格與下方的備註窗格之間。Aspose.Slides for C++ 透過 [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) 透露簡報儲存的編輯偏好設定。這些包括窗格佈局、縮放等級、格線間距，以及註解可見性。

## **關於 INormalViewProperties**

使用 [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) 取得 [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) 介面。[set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) 控制是否在大綱中於投影片標題旁顯示圖示。[set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) 允許在使用者縮小側窗格時，使其自動貼齊至最小化狀態。[set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) 表示在全視窗中偏好顯示單一窗格。

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) 控制側窗格與投影片之間的分隔線。[set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) 控制備註窗格上方的分隔線。兩者皆接受 [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) 的值，包含 `Minimized`、`Maximized` 或 `Restored`。

## **關於 還原 INormalViewProperties**

當分隔線被還原時，[get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) 提供側窗格的儲存大小，而 [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) 提供上方投影片區域的儲存大小。兩者皆公開 [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/)。其 [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) 方法接受 0 到 100 的百分比，而 [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) 控制編輯器在視窗調整大小時是否自動調整尺寸。

此範例更新現有的簡報。它還原水平分隔線，將由 [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) 所揭露的上方投影片區域大小設定為 80%，並啟用自動調整，並將垂直分隔線最大化。它亦透過 [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) 為大綱檢視啟用圖示。

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

## **設定預設縮放值**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) 與 [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) 為編輯器儲存獨立的縮放設定。這些設定不會影響投影片尺寸、投影片放映播放，或影像匯出的解析度。

此範例開啟現有的簡報，並使用 [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) 啟用自動縮放，以使投影片符合編輯視窗。對於備註頁面，則關閉自動縮放，並使用 [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) 設定固定的 80% 縮放。

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

## **設定格線間距**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) 設定整個簡報中編輯格線之間的距離。它接受以點 (points) 為單位的正值，1 英吋等於 72 點。此範例列印現有簡報的當前間距，並透過將間隔設定為 18 點，儲存四分之一英吋的格線。

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

格線以固定間隔重複。[Drawing guides](/slides/zh-hant/cpp/drawing-guides/) 標示個別的水平或垂直位置。兩者皆為編輯輔助功能，僅在顯示它們的編輯器中出現。投影片放映以及匯出為 PDF、影像或 SVG 時會省略它們。

## **在開啟簡報時顯示或隱藏註解**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) 儲存相容編輯器在開啟簡報時使用的偏好設定。對於含有註解的現有簡報，此範例列印當前設定，並儲存一個隱藏註解的副本。它也使用 [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) 呼叫 [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/)，使該副本以投影片檢視開啟。

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

隱藏註解會保留其文字、作者、位置、回覆與狀態。若要變更註解本身，請參閱 [Presentation Comments](/slides/zh-hant/cpp/presentation-comments/)。匯出設定則控制註解是否顯示於 PDF、HTML、影像、備註或講義中。

## **常見問題**

**為何重新開啟簡報時格線會被隱藏？**

簡報會儲存格線間隔。若要看到格線，請在編輯器中啟用格線可見性。

**清除繪圖參考線會改變格線間距嗎？**

不會。新增、移動或清除參考線都不會改變格線間隔。

**簡報的不同章節可以有不同的檢視設定嗎？**

不會。[Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) 作用於整個簡報。

**我可以為不同使用者儲存不同的檢視設定嗎？**

檔案僅為所有使用者儲存一組檢視屬性。編輯器可能會套用使用者的本機偏好設定。

**我可以在範本中儲存檢視設定嗎？**

可以。從此範本建立的簡報會繼承其已儲存的檢視設定。