---
title: 檢索與更新 C++ 簡報檢視屬性
linktitle: 檢視屬性
type: docs
weight: 80
url: /zh-hant/cpp/presentation-view-properties/
keywords: 
- 檢視屬性
- 常規檢視
- 大綱內容
- 大綱圖示
- 對齊垂直分割條
- 單一檢視
- 條狀狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++ 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

常規視圖由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。相關於不同內容區域定位的屬性。此資訊允許應用程式將視圖狀態儲存至檔案中，以便重新開啟時，視圖與上次儲存簡報時的狀態相同。

已新增方法 [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) 以提供對簡報常規視圖屬性的存取。

已新增介面 [INormalViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inormalviewrestoredproperties/)，以及其衍生類別，還有列舉型別 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/splitterbarstatetype/)。

## **關於 INormalViewProperties**

代表常規視圖的屬性。

屬性 **ShowOutlineIcons** 指定應用程式在常規視圖模式的任何內容區域顯示大綱內容時，是否顯示圖示。

屬性 **SnapVerticalSplitter** 指定當側邊區域足夠小時，垂直分割條是否自動縮至最小化狀態。

屬性 **PreferSingleView** 指定使用者是否偏好以全畫面單一內容區域取代具有三個內容區域的標準常規視圖。啟用後，應用程式可能會選擇將其中一個內容區域填滿整個視窗。

屬性 **VerticalBarState** 與 **HorizontalBarState** 指定水平或垂直分割條應呈現的狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條則將投影片與側邊內容區域分開。可能的值包括：**SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized** 與 **SplitterBarStateType.Restored**。

屬性 **RestoredLeft** 與 **RestoredTop** 在 **VerticalBarState** 與 **HorizontalBarState** 均設定為 **SplitterBarStateType.Restored** 時，指定常規視圖中側邊或上方投影片區域的大小。

## **關於還原 INormalViewProperties**

在常規視圖中，當區域為可變的還原大小（既非最小化亦非最大化）時，指定投影片區域（若為 RestoredTop 的子項則為寬度，若為 RestoredLeft 的子項則為高度）的尺寸。

屬性 **DimensionSize** 指定投影片區域的大小（若為 restoredTop 的子項則為寬度，若為 restoredLeft 的子項則為高度）。

屬性 **AutoAdjust** 指定在調整包含視圖之應用程式視窗大小時，側邊內容區域的尺寸是否應自動補償。

以下範例示範如何存取簡報的 **ViewProperties.NormalViewProperties** 屬性。

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

// 復原簡報的檢視屬性
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **設定預設縮放值**

Aspose.Slides for C++ 現已支援設定簡報的預設縮放值，使得開啟簡報時已自動套用縮放。這可透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/) 來完成。投影片檢視屬性以及 [get_NotesViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_notesviewproperties/) 皆可以程式方式設定。在本主題中，我們將透過範例說明如何在 Aspose.Slides 中設定簡報的 View Properties。

要設定檢視屬性，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例
1. 設定簡報的 View [Properties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/) 
1. 將簡報寫入為 PPTX 檔案

以下範例中，我們已設定投影片檢視與備註檢視的縮放值。

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 設定簡報的檢視屬性
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // 投影片檢視的縮放值（百分比）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // 備註檢視的縮放值（百分比）

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **設定格線間距**

使用 [Presentation::get_ViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/) 可存取簡報層級的檢視設定。[IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/get_gridspacing/) 與 [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/set_gridspacing/) 方法可讀取或變更底層編輯格線的間隔。此設定套用於整個簡報，而非單一投影片。格線間距以點為單位，72 點等於一英吋。請使用正值，符合 API 文件之要求。

以下範例會開啟現有的 `demo.pptx`，列印其目前的格線間距，設定四分之一英吋的間隔，並將結果儲存。

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

格線與 [drawing guides](/slides/zh-hant/cpp/drawing-guides/) 不同。格線間距控制的是固定間隔，而繪圖參考線是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆屬於編輯輔助功能。它們不會在 PDF、影像、SVG 或投影片放映中以投影片內容呈現。即使儲存了格線間距，也無法保證編輯器會顯示格線；其可見性仍取決於檢視器或編輯器的偏好設定。

## **開啟簡報時顯示或隱藏評論**

使用 [Presentation::get_ViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/) 可取得簡報層級的檢視設定。使用 [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/get_showcomments/) 與 [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/set_showcomments/) 可儲存是否在 PowerPoint 或其他相容編輯器開啟簡報時顯示評論的偏好。

此設定僅控制儲存的檢視偏好，並不會新增、刪除、編輯或解決評論。隱藏評論會保留其內容、作者、位置、回覆與狀態。請參閱 [Presentation Comments](/slides/zh-hant/cpp/presentation-comments/) 了解會變更評論本身的操作。

以下範例需要一個包含評論的現有 `comments.pptx`。它會列印目前的可見性設定，將評論隱藏，並儲存新的 PPTX 而不移除任何評論。範例同時使用 [IViewProperties::set_LastView](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/set_lastview/) 搭配 [ViewType::SlideView](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewtype/) 來配置初始編輯視圖以及評論可見性。

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

此設定不會決定評論是否會包含在 PDF、HTML、影像、備註或講義的匯出中。請分別設定相關的匯出選項。

## **常見問題**

**為何重新開啟簡報後格線不見了？**  
檔案會儲存格線間距，但是否顯示格線由編輯器決定。請檢查編輯器的格線可見性設定。

**清除繪圖參考線會改變格線間距嗎？**  
不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會影響已儲存的格線間隔。

**我能為簡報的不同章節設定不同的檢視設定嗎？**  
檢視設定（[View settings](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/)）在簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_slideviewproperties/)），而非每個章節。因此開啟文件時，整份文件僅使用單一組參數。

**我能為不同使用者預先定義不同的檢視狀態嗎？**  
不能。設定儲存在檔案中，會被所有使用者共享。雖然檢視程式可能會遵守使用者的偏好，但檔案本身僅包含一組檢視屬性。

**我能製作一個預先設定 View Properties 的範本，讓新簡報以相同方式開啟嗎？**  
可以。因為 [view properties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/) 儲存在簡報層級，您可以將它們嵌入範本，並以此建立新文件，使其具有相同的初始檢視配置。