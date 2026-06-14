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
- 自動對齊垂直分割條
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
description: "探索 Aspose.Slides for C++ 的檢視屬性，以自訂 PPT、PPTX 與 ODP 投影片格式——調整版面配置、縮放層級與顯示設定。"
---
## **簡介**

普通檢視由三個內容區域組成：投影片本身、側邊內容區域以及底部內容區域。屬性與不同內容區域的位置相關。此資訊可讓應用程式將檢視狀態儲存至檔案，因而在重新開啟時，檢視會保持與上次儲存簡報時相同的狀態。

已新增方法 [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) 以提供對簡報普通檢視屬性的存取。

已新增 [INormalViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/inormalviewrestoredproperties/) 介面及其子介面，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/splitterbarstatetype/) 列舉。

## **關於 INormalViewProperties**

代表普通檢視屬性。

屬性 **ShowOutlineIcons** 指定應用程式在普通檢視模式的任何內容區域顯示大綱內容時，是否顯示圖示。

屬性 **SnapVerticalSplitter** 指定當側邊區域足夠小時，垂直分割條是否應自動縮至最小化狀態。

屬性 **PreferSingleView** 指定使用者是否偏好以全視窗單一內容區域取代具有三個內容區域的標準普通檢視。啟用時，應用程式可能會選擇將其中一個內容區域顯示於整個視窗。

屬性 **VerticalBarState** 與 **HorizontalBarState** 指定水平或垂直分割條的顯示狀態。水平分割條將投影片與投影片下方的內容區域分開，垂直分割條則將投影片與側邊內容區域分開。可能的值為：**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** 與 **SplitterBarStateType.Restored**。

屬性 **RestoredLeft** 與 **RestoredTop** 指定普通檢視中上方或側邊投影片區域的大小，當 **VerticalBarState** 與 **HorizontalBarState** 分別套用 **SplitterBarStateType.Restored** 值時。

## **關於還原 INormalViewProperties**

指定普通檢視中投影片區域的大小（作為 RestoredTop 的子項時為寬度，作為 RestoredLeft 的子項時為高度），當該區域處於可變的還原尺寸（既非最小化亦非最大化）時。

屬性 **DimensionSize** 指定投影片區域的尺寸（作為 restoredTop 的子項時為寬度，作為 restoredLeft 的子項時為高度）。

屬性 **AutoAdjust** 指定在調整包含檢視的視窗大小時，側邊內容區域的尺寸是否應自動補償新的大小。

以下範例說明如何存取簡報的 **ViewProperties.NormalViewProperties** 屬性。

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// 還原簡報的檢視屬性
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **設定預設縮放值**

Aspose.Slides for C++ 現已支援設定簡報的預設縮放值，使得開啟簡報時已自動套用縮放。這可以透過設定簡報的 [ViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/) 來完成。投影片檢視屬性以及 [get_NotesViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_notesviewproperties/) 皆可以程式方式設定。在本主題中，我們將透過範例說明如何在 Aspose.Slides 中設定簡報的檢視屬性。

若要設定檢視屬性，請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例
1. 設定簡報的檢視 [Properties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/)
1. 將簡報寫入為 PPTX 檔案

以下範例中，我們已為投影片檢視與附註檢視設定縮放值。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 設定簡報的檢視屬性
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // 投影片檢視的縮放值（以百分比表示）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // 備註檢視的縮放值（以百分比表示） 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **常見問題**

**我可以為簡報的不同章節設定不同的檢視設定嗎？**

[View settings](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/) 於簡報層級定義（[Normal View](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/get_slideviewproperties/)），而非依章節，因此在開啟文件時，會有一組參數套用於整個文件。

**我可以為不同使用者預先定義不同的檢視狀態嗎？**

不行。設定儲存在檔案中且為共用。檢視程式可能會遵守使用者偏好，但檔案本身只包含一組檢視屬性。

**我可以建立含有預先定義檢視屬性的範本，使新簡報以相同方式開啟嗎？**

可以。因為 [檢視屬性](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_viewproperties/) 儲存在簡報層級，您可以將其嵌入範本，並以相同的初始檢視設定建立新文件。