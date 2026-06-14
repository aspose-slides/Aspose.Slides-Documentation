---
title: 使用 C++ 的 AutoFit 來增強您的簡報
linktitle: AutoFit 設定
type: docs
weight: 30
url: /zh-hant/cpp/manage-autofit-settings/
keywords:
- 文字方塊
- 自動調整
- 不自動調整
- 適合文字
- 縮小文字
- 換行文字
- 調整形狀大小
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中管理 AutoFit 設定，以優化 PowerPoint 與 OpenDocument 簡報中的文字顯示，提升內容可讀性。"
---
## **簡介**

預設情況下，當您新增文字方塊時，Microsoft PowerPoint 會使用 **Resize shape to fix text** 設定──它會自動調整文字方塊的大小，以確保文字始終能完整容納在其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 當文字方塊中的文字變長或變大時，PowerPoint 會自動放大文字方塊──增加其高度──以容納更多文字。  
* 當文字方塊中的文字變短或變小時，PowerPoint 會自動縮小文字方塊──降低其高度──以清除多餘的空間。

在 PowerPoint 中，以下 4 個重要參數或選項會控制文字方塊的自動調整行為：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ 提供類似的選項——某些位於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format) 類別下的方法——讓您能在簡報中控制文字方塊的自動調整行為。

## **將形狀調整以適合文字**

如果您希望文字方塊中的文字在任何變更後都能完整容納於方塊內，必須使用 **Resize shape to fix text** 選項。要指定此設定，請將 [AutofitType](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 屬性（屬於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format) 類別）設為 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 C++ 程式碼示範如何在 PowerPoint 簡報中指定文字必須始終適合其方塊：

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

如果文字變長或變大，文字方塊會自動調整大小（高度增加），以確保所有文字皆能容納。其中，文字變短時則會相反。

## **Do Not Autofit**

如果您希望文字方塊或形狀無論文字內容如何變更，都保持原有尺寸，必須使用 **Do not Autofit** 選項。要指定此設定，請將 [AutofitType](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 屬性（屬於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format) 類別）設為 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 C++ 程式碼示範如何在 PowerPoint 簡報中指定文字方塊必須維持原有尺寸：

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

當文字過長超出方塊時，會溢出顯示。

## **Shrink Text on Overflow**

如果文字過長而無法容納於方塊內，透過 **Shrink text on overflow** 選項，您可以指定縮小文字的大小與間距，使其適合方塊。要指定此設定，請將 [AutofitType](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) 屬性（屬於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format) 類別）設為 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 C++ 程式碼示範如何在 PowerPoint 簡報中指定文字在溢出時縮小：

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 選項時，僅在文字超出方塊時才會套用此設定。
{{% /alert %}}

## **Wrap Text**

如果您希望文字在超出形狀寬度時自動換行，必須使用 **Wrap text in shape** 參數。要指定此設定，請將 [WrapText](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) 屬性（屬於 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame_format) 類別）設為 `true`。

以下 C++ 程式碼示範如何在 PowerPoint 簡報中使用換行文字設定：

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
如果將 `WrapText` 屬性設定為 `False`，當形狀內的文字長度超過形狀寬度時，文字會沿單行延伸至形狀邊界之外。
{{% /alert %}}

## **FAQ**

**文字框的內部邊距會影響 AutoFit 嗎？**

會的。內部邊距（Padding）會縮小可用的文字區域，因此 AutoFit 會較早啟動——會更快縮小字型或調整形狀大小。請先檢查並調整邊距，再進行 AutoFit 的微調。

**AutoFit 與手動換行或軟換行如何互動？**

強制換行會保留原位，AutoFit 會根據這些換行點調整字型大小與間距。移除不必要的換行通常能減少 AutoFit 必須過度縮小文字的情況。

**變更主題字型或觸發字型替換會影響 AutoFit 結果嗎？**

會。替換為字型度量不同的字型會改變文字的寬度/高度，從而影響最終的字型大小與換行。任何字型變更或替換後，請重新檢查投影片的顯示效果。