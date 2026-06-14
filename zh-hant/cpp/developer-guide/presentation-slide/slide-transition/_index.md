---
title: 使用 C++ 管理簡報中的投影片轉場
linktitle: 投影片轉場
type: docs
weight: 80
url: /zh-hant/cpp/slide-transition/
keywords:
- 投影片轉場
- 新增投影片轉場
- 套用投影片轉場
- 進階投影片轉場
- Morph 轉場
- 轉場類型
- 轉場效果
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "探索如何在 Aspose.Slides for C++ 中自訂投影片轉場，並提供針對 PowerPoint 與 OpenDocument 簡報的逐步指南。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報中管理投影片轉場。它展示了如何對投影片套用轉場類型、設定轉場行為（如點擊或在指定時間後前進）、檢查與停用自動前進、使用 Morph 轉場及其類型，以及設定轉場效果選項。範例說明了如何載入或建立簡報、修改選取投影片的轉場設定，並將結果儲存為 PPTX 檔。本文亦回答了關於轉場速度、轉場音效、將相同轉場套用至多張投影片，以及檢查投影片目前設定的轉場等常見問題。

## **新增投影片轉場**
為了更易理解，我們示範了如何使用 Aspose.Slides for C++ 來管理簡單的投影片轉場。開發人員不僅可以在投影片上套用不同的轉場效果，還能自訂這些轉場效果的行為。若要建立簡單的投影片轉場效果，請依照以下步驟執行：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。  
2. 透過 TransitionType 列舉，對投影片套用 Aspose.Slides for C++ 所提供的其中一種轉場效果。  
3. 將修改後的簡報寫入檔案。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **新增進階投影片轉場**
在上述段落中，我們只套用了簡單的轉場效果。現在，若要讓該簡單轉場效果更完善且受控，請依照以下步驟執行：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。  
1. 透過 Aspose.Slides for C++ 的轉場效果，對投影片套用 Slide Transition Type。  
1. 您也可以將轉場設定為「Advance On Click」、在特定時間後或兩者同時啟用。  
1. 若轉場已啟用「Advance On Click」，則只有在滑鼠點擊時才會前進。而若設定了「Advance After Time」屬性，則會在指定的時間過後自動前進。  
1. 將修改後的簡報寫入為簡報檔案。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **Morph 轉場**
Aspose.Slides for C++ 現已支援 Morph 轉場。它代表 PowerPoint 2019 中引入的新型 Morph 轉場。Morph 轉場允許您在兩張投影片之間產生平滑的動畫移動。本文說明此概念及如何使用 Morph 轉場。若要有效使用 Morph 轉場，您需要兩張具有至少一個共同物件的投影片。最簡單的做法是複製投影片，然後將第二張投影片上的物件移至不同位置。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **Morph 轉場類型**
已新增 Aspose.Slides.SlideShow.TransitionMorphType 列舉，代表不同類型的 Morph 投影片轉場。

TransitionMorphType 列舉有三個成員：

- ByObject：Morph 轉場會將形狀視為不可分割的物件來執行。  
- ByWord：Morph 轉場會在可能的情況下以單字為單位傳遞文字。  
- ByChar：Morph 轉場會在可能的情況下以字元為單位傳遞文字。  

以下程式碼片段示範如何為投影片設定 Morph 轉場並變更 Morph 類型：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **設定轉場效果**
Aspose.Slides for C++ 支援設定如「從黑色淡入」、「從左側」或「從右側」等轉場效果。若要設定轉場效果，請依照以下步驟執行：

- 建立 Presentation 類別的實例。  
- 取得投影片的參考。  
- 設定轉場效果。  
- 將簡報寫入為 PPTX 檔案。  

在下方範例中，我們已設定了轉場效果。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **常見問題**

**我可以控制投影片轉場的播放速度嗎？**

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.slideshow/transitionspeed/) 設定來設定轉場的 [speed](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/)（例如 slow/medium/fast）。

**我可以為轉場附加音訊並讓它循環播放嗎？**

是的。您可以為轉場嵌入音效，並透過設定（如音效模式與循環）來控制其行為，例如 [set_Sound](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/)、[set_SoundMode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/)、[set_SoundLoop](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/)，以及其他中繼資料如 [set_SoundIsBuiltIn](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) 和 [set_SoundName](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)。

**將相同的轉場套用到每張投影片的最快方法是什麼？**

在每張投影片的轉場設定中配置所需的轉場類型；轉場是逐投影片儲存的，將相同類型套用於所有投影片即可取得一致的結果。

**我要如何檢查投影片目前設定的轉場是什麼？**

檢視投影片的 [transition settings](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseslide/get_slideshowtransition/) 並讀取其 [transition type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.slideshow/slideshowtransition/get_type/)；該值會精確告訴您套用了哪種效果。