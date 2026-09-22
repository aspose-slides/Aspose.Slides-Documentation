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
- 捕捉垂直分割條
- 單一檢視
- 分割條狀態
- 尺寸大小
- 自動調整
- 預設縮放
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++ 的檢視屬性，以自訂 PPT、PPTX 和 ODP 投影片格式——調整版面配置、縮放比例與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區以及底部內容區。相關的屬性說明了這些內容區域的定位。此資訊使應用程式能將檢視狀態儲存至檔案，讓重新開啟時檢視仍保持在上次儲存時的狀態。

已新增方法 [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) 以取得簡報的普通檢視屬性。

已新增介面 [INormalViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inormalviewrestoredproperties/) 以及其衍生類別，還有列舉型別 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/splitterbarstatetype/)。

## **關於 INormalViewProperties**

代表普通檢視屬性。

屬性 **ShowOutlineIcons** 指定在普通檢視模式的任何內容區域顯示大綱內容時，應否顯示圖示。

屬性 **SnapVerticalSplitter** 指定當側邊區域足夠小時，垂直分割條是否自動縮至最小化狀態。

屬性 **PreferSingleView** 指定使用者是否偏好以全視窗單一內容區取代具有三個內容區的標準普通檢視。啟用後，應用程式可能會選擇將其中一個內容區顯示於整個視窗。

屬性 **VerticalBarState** 與 **HorizontalBarState** 指定水平或垂直分割條的顯示狀態。水平分割條將投影片與下方內容區分開，垂直分割條則將投影片與側邊內容區分開。可能的值有 **SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized** 與 **SplitterBarStateType.Restored**。

屬性 **RestoredLeft** 與 **RestoredTop** 指定在 **VerticalBarState** 和 **HorizontalBarState** 均設定為 **SplitterBarStateType.Restored** 時，普通檢視的側邊或上方投影片區域的尺寸。

## **關於復原 INormalViewProperties**

指定普通檢視中投影片區域的尺寸（若為 RestoredTop 子項則為寬度，若為 RestoredLeft 子項則為高度），當該區域處於可變的復原大小（既非最小化也非最大化）時。

屬性 **DimensionSize** 指定投影片區域的大小（若為 restoredTop 子項則為寬度，若為 restoredLeft 子項則為高度）。

屬性 **AutoAdjust** 指定在調整包含檢視的視窗大小時，側邊內容區的尺寸是否會自動補償新的大小。

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

Aspose.Slides for C++ 現在支援設定簡報的預設縮放值，讓簡報開啟時即已設定縮放。這可透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/) 來達成。投影片檢視屬性以及 [get_NotesViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_notesviewproperties/) 皆可程式化設定。在本主題中，我們將透過範例說明如何在 Aspose.Slides 中設定簡報的檢視屬性。

設定檢視屬性的步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件實例
2. 設定簡報的檢視 [Properties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/)
3. 將簡報寫入為 PPTX 檔案

在以下範例中，我們同時為投影片檢視與備註檢視設定了縮放值。

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

使用 [Presentation::get_ViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/) 取得整個簡報的檢視設定。透過 [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/get_gridspacing/) 與 [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/set_gridspacing/) 方法可讀取或變更基礎編輯格線的間隔。此設定套用於整份簡報，而非單一投影片。格線間距以點為單位，72 點等於一英吋。請使用正值，依 API 文件規定。

以下範例開啟現有的 `demo.pptx`，列印目前的格線間距，將間隔設定為四分之一英吋，然後儲存結果。

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

格線不同於 [drawing guides](/slides/zh-hant/cpp/drawing-guides/)。格線間距控制的是規律的間隔，而繪圖參考線是個別定位的水平或垂直對齊線。新增、移動或清除繪圖參考線不會改變格線間距。

格線與繪圖參考線皆為編輯輔助功能。它們不會在 PDF、影像、SVG 或投影片放映中以投影片內容呈現。儲存格線間距並不保證編輯器一定會顯示格線：其可視性亦取決於檢視器或編輯器的偏好設定。

## **常見問題**

**為什麼重新開啟簡報後格線不見了？**

檔案會儲存格線間距，但是否顯示格線由編輯器決定。請檢查編輯器的格線可視性設定。

**清除繪圖參考線會改變格線間距嗎？**

不會。繪圖參考線與格線間距是獨立的設定。清除參考線不會影響已儲存的格線間隔。

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[View settings](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/) 只在簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_slideviewproperties/)），不會依章節區分，因此在開啟文件時僅有一組參數套用於整個文件。

**我可以預先為不同使用者定義不同的檢視狀態嗎？**

不能。設定儲存在檔案中，所有使用者共用同一套檢視屬性。檢視應用程式可能會遵循使用者偏好，但檔案本身只包含一組檢視屬性。

**我可以製作包含預先定義檢視屬性的範本，以便新簡報以相同方式開啟嗎？**

可以。因為 [view properties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/) 儲存在簡報層級，您可以將它們嵌入範本，然後以該範本建立新文件，讓新簡報具備相同的初始檢視配置。