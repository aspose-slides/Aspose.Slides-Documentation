---
title: 在 C++ 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/cpp/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 圖片超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆管理 PowerPoint 與 OpenDocument 簡報中的超連結——在數分鐘內提升互動性與工作流程。"
---
## **簡介**

超連結是對某個物件、資料或位置的參考。以下是在 PowerPoint 簡報中常見的超連結：

* 文字、圖形或媒體內的網站連結
* 投影片連結

Aspose.Slides for C++ 允許您在簡報中執行許多與超連結相關的任務。

{{% alert color="primary" %}} 
您可能想查看 Aspose 簡易的 [免費線上 PowerPoint 編輯器。](https://products.aspose.app/slides/zh-hant/editor)
{{% /alert %}} 

## **加入 URL 超連結**

### **將 URL 超連結加入文字**

此 C++ 程式碼示範如何將網站超連結加入文字：

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **將 URL 超連結加入圖形或框架**

此 C++ 範例程式碼示範如何將網站超連結加入圖形：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **將 URL 超連結加入媒體**

Aspose.Slides 允許您為圖片、音訊與影片檔案加入超連結。

此範例程式碼示範如何為 **圖片** 加入超連結：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// 將影像加入簡報
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Creates picture frame on slide 1 based on previously added image
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

此範例程式碼示範如何為 **音訊檔案** 加入超連結：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

此範例程式碼示範如何為 **影片** 加入超連結：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Tip"  color="primary"  %}} 
您可能想查看 *[管理 OLE](https://docs.aspose.com/slides/zh-hant/cpp/manage-ole/)*。
{{% /alert %}}



## **使用超連結建立目錄**

由於超連結允許您加入對物件或位置的參照，您可以利用它們建立目錄。

此範例程式碼示範如何使用超連結建立目錄：

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```


## **格式化超連結**

### **顏色**

使用 [IHyperlink](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink) 介面的 [set_ColorSource()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) 與 [get_ColorSource()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) 方法，您可以設定超連結的顏色，亦可取得超連結的顏色資訊。此功能首次於 PowerPoint 2019 引入，故此屬性的變更不適用於較舊的 PowerPoint 版本。

此範例程式碼示範在同一投影片上加入不同顏色的超連結的操作：

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```


## **從簡報中移除超連結**

### **從文字中移除超連結**

此 C++ 程式碼示範如何從簡報投影片的文字中移除超連結：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **從圖形或框架中移除超連結**

此 C++ 程式碼示範如何從簡報投影片的圖形中移除超連結：

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```



## **Mutable Hyperlink**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.hyperlink) 類別是可變的。使用此類別，您可以變更以下方法的值：

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

此程式碼片段示範如何在投影片中加入超連結，並於之後編輯其工具提示：

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```




## **IHyperlinkQueries 中支援的方法**

您可以從定義了超連結的簡報、投影片或文字取得 IHyperlinkQueries。

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

IHyperlinkQueries 類別支援以下方法：

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**如何在內部導覽時不僅跳至投影片，而是跳至「區段」或區段的第一張投影片？**

PowerPoint 中的區段是投影片的分組；導覽實際上是針對特定投影片。若要「導覽至區段」，通常會連結到該區段的第一張投影片。

**我可以將超連結附加到母片元素，使其在所有投影片上都有效嗎？**

可以。母片與版面配置元素支援超連結。這類連結會出現在子投影片上，且在投影片放映時可被點擊。

**匯出為 PDF、HTML、圖片或影片時，超連結會被保留嗎？**

在 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/) 中，會保留連結——通常會保留。匯出為 [圖片](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 與 [影片](/slides/zh-hant/cpp/convert-powerpoint-to-video/) 時，因為這些格式本身不支援超連結（光柵影格/影片不具備可點擊性），連結將不會保留。