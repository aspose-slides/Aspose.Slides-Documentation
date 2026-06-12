---
title: Hyperlinks in presentaties beheren in C++
linktitle: Hyperlink beheren
type: docs
weight: 20
url: /nl/cpp/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- teksthyperlink
- diahyperlink
- vormhyperlink
- afbeeldinghyperlink
- videohyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer hyperlinks moeiteloos in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++ — verbeter de interactiviteit en workflow in enkele minuten."
---
## **Inleiding**

Een hyperlink is een verwijzing naar een object, gegevens of een plek in iets. Dit zijn veelvoorkomende hyperlinks in PowerPoint‑presentaties:

* Links naar websites in tekst, vormen of media
* Links naar dia's

Aspose.Slides for C++ stelt u in staat om tal van taken met hyperlinks in presentaties uit te voeren. 

{{% alert color="primary" %}} 

U wilt misschien Aspose Simple, de [gratis online PowerPoint-editor.](https://products.aspose.app/slides/nl/editor)

{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

### **URL‑hyperlinks toevoegen aan tekst**

Deze C++‑code laat zien hoe u een website‑hyperlink aan een tekst toevoegt:

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

### **URL‑hyperlinks toevoegen aan vormen of frames**

Deze voorbeeldcode in C++ laat zien hoe u een website‑hyperlink aan een vorm toevoegt:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **URL‑hyperlinks toevoegen aan media**

Aspose.Slides stelt u in staat om hyperlinks toe te voegen aan afbeeldingen, audio‑ en videobestanden. 

Deze voorbeeldcode laat zien hoe u een hyperlink aan een **afbeelding** toevoegt:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Voegt afbeelding toe aan presentatie
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Maakt een afbeeldingsframe op dia 1 aan op basis van eerder toegevoegde afbeelding
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 Deze voorbeeldcode laat zien hoe u een hyperlink aan een **audio‑bestand** toevoegt:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 Deze voorbeeldcode laat zien hoe u een hyperlink aan een **video** toevoegt:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}} 

U wilt misschien *[OLE beheren](https://docs.aspose.com/slides/nl/cpp/manage-ole/)*.

{{% /alert %}}



## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Aangezien hyperlinks u in staat stellen om verwijzingen naar objecten of plekken toe te voegen, kunt u ze gebruiken om een inhoudsopgave te maken. 

Deze voorbeeldcode laat zien hoe u een inhoudsopgave met hyperlinks maakt:

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


## **Hyperlinks opmaken**

### **Kleur**

Met de [set_ColorSource()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac)‑ en [get_ColorSource()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494)‑methoden in de [IHyperlink](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink)‑interface kunt u de kleur voor hyperlinks instellen en ook de kleurinformatie van hyperlinks opvragen. De functie werd voor het eerst geïntroduceerd in PowerPoint 2019, dus wijzigingen met betrekking tot de eigenschap gelden niet voor oudere PowerPoint‑versies.

Deze voorbeeldcode demonstreert een bewerking waarbij hyperlinks met verschillende kleuren aan dezelfde dia werden toegevoegd:

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


## **Hyperlinks uit presentaties verwijderen**

### **Hyperlinks uit tekst verwijderen**

Deze C++‑code laat zien hoe u de hyperlink uit een tekst in een presentatiedia verwijdert:

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

### **Hyperlinks uit vormen of frames verwijderen**

Deze C++‑code laat zien hoe u de hyperlink uit een vorm in een presentatiedia verwijdert: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```



## **Aanpasbare hyperlink**

De [Hyperlink](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.hyperlink)‑klasse is aanpasbaar. Met deze klasse kunt u de waarden voor de volgende methoden aanpassen:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

Het codefragment laat zien hoe u een hyperlink aan een dia toevoegt en later de tooltip bewerkt:

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




## **Ondersteunde methoden in IHyperlinkQueries**

U kunt IHyperlinkQueries benaderen vanuit een presentatie, dia of tekst waarvoor de hyperlink is gedefinieerd. 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

De IHyperlinkQueries‑klasse ondersteunt deze methoden: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **FAQ**

**Hoe kan ik interne navigatie creëren, niet alleen naar een dia, maar naar een “sectie” of de eerste dia van een sectie?**

Secties in PowerPoint zijn groepen dia's; navigatie richt zich technisch op een specifieke dia. Om “naar een sectie te navigeren”, linkt u doorgaans naar de eerste dia ervan.

**Kan ik een hyperlink toevoegen aan elementen van de masterdia zodat deze op alle dia's werkt?**

Ja. Elementen van de masterdia en indelingsdia’s ondersteunen hyperlinks. Dergelijke links verschijnen op onderliggende dia’s en zijn klikbaar tijdens de diavoorstelling.

**Blijven hyperlinks behouden bij het exporteren naar PDF, HTML, afbeeldingen of video?**

In [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/cpp/convert-powerpoint-to-html/) ja — links worden over het algemeen behouden. Bij het exporteren naar [afbeeldingen](/slides/nl/cpp/convert-powerpoint-to-png/) en [video](/slides/nl/cpp/convert-powerpoint-to-video/) blijft de klikbaarheid niet behouden vanwege de aard van die formaten (raster‑frames/video ondersteunen geen hyperlinks).