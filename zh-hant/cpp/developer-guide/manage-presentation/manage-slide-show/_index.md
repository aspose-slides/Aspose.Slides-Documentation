---
title: 管理 C++ 中的投影片放映
linktitle: 投影片放映
type: docs
weight: 90
url: /zh-hant/cpp/manage-slide-show/
keywords:
- 投影片類型
- 由講者呈現
- 個人瀏覽
- 資訊亭瀏覽
- 放映選項
- 持續循環
- 無旁白放映
- 無動畫放映
- 筆跡顏色
- 放映投影片
- 自訂放映
- 換片
- 手動
- 使用計時
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中管理投影片放映。輕鬆控制投影片過渡、計時等功能，支援 PPT、PPTX 與 ODP 格式。"
---
## **簡介**

在 Microsoft PowerPoint 中，**投影片放映** 設定是準備與呈現專業簡報的關鍵工具。本節中最重要的功能之一是 **設定放映**，它允許您根據特定條件與觀眾調整簡報，以確保彈性與便利。使用此功能，您可以選擇放映類型（例如，由講者呈現、由個人瀏覽或在資訊亭瀏覽）、啟用或停用循環、選取要顯示的特定投影片，並使用計時。本步驟對於使您的簡報更有效且更具專業水準至關重要。

`get_SlideShowSettings` 是 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的方法，會傳回類型為 [SlideShowSettings](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slideshowsettings/) 的物件，讓您管理 PowerPoint 簡報中的投影片放映設定。本文將探討如何使用此方法來配置與控制投影片放映設定的各種面向。

## **選取放映類型**

`SlideShowSettings.set_SlideShowType` 定義投影片放映的類型，可為以下類別的實例：[PresentedBySpeaker](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentedbyspeaker/)、[BrowsedByIndividual](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/browsedbyindividual/)、或 [BrowsedAtKiosk](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/browsedatkiosk/)。使用此方法可讓您依不同使用情境（例如自動化資訊亭或手動簡報）調整簡報。

以下程式碼範例建立新簡報，並將放映類型設為「由個人瀏覽」且不顯示捲軸。

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **啟用放映選項**

`SlideShowSettings.set_Loop` 決定投影片放映是否重複循環，直到手動停止。這對需要持續執行的自動化簡報很有用。`SlideShowSettings.set_ShowNarration` 決定在放映期間是否播放語音旁白，適用於包含語音指引的自動化簡報。`SlideShowSettings.set_ShowAnimation` 決定是否播放投影片物件的動畫，以提供完整的視覺效果。

以下程式碼範例建立新簡報，並讓投影片放映循環。

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **選取要放映的投影片**

`SlideShowSettings.set_Slides` 方法允許您選取在簡報期間要顯示的投影片範圍。當您只需要顯示簡報的一部分而非全部投影片時，此功能非常實用。以下程式碼範例建立新簡報，並將投影片範圍設定為顯示第 `2` 張至第 `9` 張投影片。

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **使用預設時間進行換片**

`SlideShowSettings.set_UseTimings` 方法允許您啟用或停用每張投影片的預設時間。這對於自動依預先定義的顯示時長播放投影片非常有用。以下程式碼範例建立新簡報，並停用時間使用。

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **顯示媒體控制項**

`SlideShowSettings.set_ShowMediaControls` 方法決定在播放多媒體內容（例如影片或音訊）時，投影片放映期間是否顯示媒體控制項（如播放、暫停與停止）。當您希望讓簡報者在簡報過程中控制媒體播放時，此功能很有幫助。

以下程式碼範例建立新簡報，並啟用顯示媒體控制項。

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**我可以將簡報儲存為直接在投影片放映模式開啟嗎？**

可以。將檔案儲存為 PPSX 或 PPSM；這兩種格式在 PowerPoint 中開啟時會直接以投影片放映模式啟動。在 Aspose.Slides 中，於[匯出期間](/slides/zh-hant/cpp/save-presentation/)選取相應的儲存格式。

**我可以在不刪除檔案內投影片的情況下，將個別投影片排除於放映之外嗎？**

可以。將投影片標記為[隱藏](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/set_hidden/)。隱藏的投影片仍保留於簡報中，但在投影片放映時不會顯示。

**Aspose.Slides 能否播放投影片放映或在螢幕上控制即時簡報？**

不能。Aspose.Slides 只負責編輯、分析與轉換簡報檔案，實際的播放由 PowerPoint 等檢視程式負責。