---
title: Hantera presentationshyperlänkar i C++
linktitle: Hantera hyperlänk
type: docs
weight: 20
url: /sv/cpp/manage-hyperlinks/
keywords:
- lägga till URL
- lägga till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- bildhyperlänk
- videohyperlänk
- muterbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Hantera enkelt hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++—förbättra interaktiviteten och arbetsflödet på några minuter."
---
## **Introduktion**

En hyperlänk är en referens till ett objekt eller data eller en plats i något. Detta är vanliga hyperlänkar i PowerPoint‑presentationer:

* Länkar till webbplatser i texter, former eller media
* Länkar till bilder

Aspose.Slides for C++ låter dig utföra många uppgifter som involverar hyperlänkar i presentationer. 

{{% alert color="primary" %}} 

Du kanske vill kolla in Aspose enkla, [gratis online PowerPoint‑redigerare.](https://products.aspose.app/slides/sv/editor)

{{% /alert %}} 

## **Add URL Hyperlinks**

## **Lägg till URL‑hyperlänkar**

### **Add URL Hyperlinks to Text**

### **Lägg till URL‑hyperlänkar till text**

Denna C++‑kod visar hur du lägger till en webbplats‑hyperlänk till en text:

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

### **Add URL Hyperlinks to Shapes or Frames**

### **Lägg till URL‑hyperlänkar till former eller ramar**

Detta exempel i C++ visar hur du lägger till en webbplats‑hyperlänk till en form:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **Add URL Hyperlinks to Media**

### **Lägg till URL‑hyperlänkar till media**

Aspose.Slides låter dig lägga till hyperlänkar till bilder, ljud‑ och videofiler. 

Detta exempel visar hur du lägger till en hyperlänk till en **bild**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Lägger till bild i presentationen
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Skapar bildram på bild 1 baserat på tidigare tillagd bild
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Detta exempel visar hur du lägger till en hyperlänk till en **ljudfil**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

Detta exempel visar hur du lägger till en hyperlänk till en **video**:

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

Du kanske vill se *[Hantera OLE](https://docs.aspose.com/slides/sv/cpp/manage-ole/)*.

{{% /alert %}}



## **Use Hyperlinks to Create a Table of Contents**

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Eftersom hyperlänkar låter dig lägga till referenser till objekt eller platser kan du använda dem för att skapa en innehållsförteckning. 

Detta exempel visar hur du skapar en innehållsförteckning med hyperlänkar:

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


## **Format Hyperlinks**

## **Formatera hyperlänkar**

### **Color**

### **Färg**

Med metoderna [set_ColorSource()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) och [get_ColorSource()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) i gränssnittet [IHyperlink](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink) kan du ange färgen för hyperlänkar och även hämta färginformation från hyperlänkar. Funktionen introducerades först i PowerPoint 2019, så ändringar som involverar egenskapen gäller inte äldre versioner av PowerPoint.

Detta exempel demonstrerar en operation där hyperlänkar med olika färger lades till på samma bild:

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


## **Remove Hyperlinks from Presentations**

## **Ta bort hyperlänkar från presentationer**

### **Remove Hyperlinks from Text**

### **Ta bort hyperlänkar från text**

Denna C++‑kod visar hur du tar bort hyperlänken från en text i en presentationsbild:

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

### **Remove Hyperlinks from Shapes or Frames**

### **Ta bort hyperlänkar från former eller ramar**

Denna C++‑kod visar hur du tar bort hyperlänken från en form i en presentationsbild: 

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

## **Muterbar hyperlänk**

Klassen [Hyperlink](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.hyperlink) är muterbar. Med denna klass kan du ändra värdena för följande metoder:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

Kodsnutten visar hur du lägger till en hyperlänk till en bild och redigerar dess verktygstips senare:

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




## **Supported Methods in IHyperlinkQueries**

## **Stödda metoder i IHyperlinkQueries**

Du kan komma åt IHyperlinkQueries från en presentation, bild eller text där hyperlänken är definierad. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

Klassen IHyperlinkQueries stöder dessa metoder: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

## **FAQ**

**How can I create internal navigation not just to a slide, but to a "section" or the first slide of a section?**

**Hur kan jag skapa intern navigation inte bara till en bild, utan till ett "avsnitt" eller den första bilden i ett avsnitt?**

Sections in PowerPoint are groupings of slides; navigation technically targets a specific slide. To "navigate to a section", you typically link to its first slide.

Avsnitt i PowerPoint är gruppering av bilder; navigation riktar sig tekniskt sett mot en specifik bild. För att "navigera till ett avsnitt" länkar du vanligtvis till dess första bild.

**Can I attach a hyperlink to master slide elements so it works on all slides?**

**Kan jag bifoga en hyperlänk till master‑bildselement så att den fungerar på alla bilder?**

Yes. Master slide and layout elements support hyperlinks. Such links appear on child slides and are clickable during the slideshow.

Ja. Master‑bild‑ och layout‑element stöder hyperlänkar. Sådana länkar visas på underordnade bilder och kan klickas på under bildspelet.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

In [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/) and [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), yes—links are generally preserved. When exporting to [images](/slides/sv/cpp/convert-powerpoint-to-png/) and [video](/slides/sv/cpp/convert-powerpoint-to-video/), clickability will not carry over due to the nature of those formats (raster frames/video do not support hyperlinks).

I [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/cpp/convert-powerpoint-to-html/) ja—länkar bevaras vanligtvis. Vid export till [bilder](/slides/sv/cpp/convert-powerpoint-to-png/) och [video](/slides/sv/cpp/convert-powerpoint-to-video/) kommer klickbarhet inte att följa med på grund av formatens natur (rastrebilder/video stödjer inte hyperlänkar).