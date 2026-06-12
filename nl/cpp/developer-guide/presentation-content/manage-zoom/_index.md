---
title: Beheer presentatizoom in C++
linktitle: Zoom beheren
type: docs
weight: 60
url: /nl/cpp/manage-zoom/
keywords:
- zoom
- zoomframe
- diazoom
- sectiezoom
- samenvattingszoom
- zoom toevoegen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak en personaliseer Zoom met Aspose.Slides voor C++ — spring tussen secties, voeg miniaturen en overgangen toe aan PPT-, PPTX- en ODP-presentaties."
---
## **Introductie**

Zooms in PowerPoint stellen je in staat om naar specifieke dia's, secties en delen van een presentatie te springen en van deze terug te keren. Wanneer je presenteert, kan deze mogelijkheid om snel door de inhoud te navigeren zeer nuttig blijken. 

![overview_image](Overview.png)

* Om een volledige presentatie op één dia samen te vatten, gebruik je een [Samenvattingszoom](#Summary-Zoom).
* Om alleen geselecteerde dia's weer te geven, gebruik je een [Diazoom](#Slide-Zoom).
* Om slechts één sectie weer te geven, gebruik je een [Sectiezoom](#Section-Zoom).

## **Diazoom**
Een diazoom kan je presentatie dynamischer maken, waardoor je vrij tussen dia's kunt navigeren in elke gewenste volgorde zonder de stroom van je presentatie te onderbreken. Diazooms zijn ideaal voor korte presentaties zonder veel secties, maar je kunt ze ook in verschillende presentsituaties gebruiken.

Diazooms helpen je om in meerdere stukjes informatie te duiken terwijl je het gevoel hebt op één enkel canvas te werken. 

![overview_image](slidezoomsel.png)

Voor diazoom-objecten biedt Aspose.Slides de enumeratie [ZoomImageType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/zoomimagetype/), de interface [IZoomFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/izoomframe/) en enkele methoden onder de interface [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/).

### **Zoomframes maken**

Zo kun je een zoomframe aan een dia toevoegen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak nieuwe dia's aan waar je de zoomframes aan wilt koppelen. 
3. Voeg een identificatietekst en achtergrond toe aan de gemaakte dia's.
4. Voeg zoomframes (die naar de gemaakte dia's verwijzen) toe aan de eerste dia.
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Voegt nieuwe dia's toe aan de presentatie
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Maakt een achtergrond voor de tweede dia
SetSlideBackground(slide2, Color::get_Cyan());

// Maakt een tekstvak voor de tweede dia
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Maakt een achtergrond voor de derde dia
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Maak een tekstvak voor de derde dia
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Voegt ZoomFrame-objecten toe
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zoomframes maken met aangepaste afbeeldingen**
Met Aspose.Slides for C++ kun je een zoomframe met een andere dia‑preview‑afbeelding maken op de volgende manier: 
1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak een nieuwe dia aan waar je het zoomframe aan wilt koppelen. 
3. Voeg een identificatietekst en achtergrond toe aan de dia.
4. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) object aan door een afbeelding toe te voegen aan de Images‑collectie die gekoppeld is aan het [Presentation]‑object, die gebruikt zal worden om het frame te vullen.
5. Voeg zoomframes (die naar de gemaakte dia verwijzen) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Voegt een nieuwe dia toe aan de presentatie
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Maakt een achtergrond voor de tweede dia
SetSlideBackground(slide, Color::get_Cyan());

// Maakt een tekstvak voor de derde dia
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Maakt een nieuwe afbeelding voor het zoomobject
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Voegt het ZoomFrame-object toe
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zoomframes opmaken**
In de vorige secties hebben we je laten zien hoe je eenvoudige zoomframes maakt. Om meer complexe zoomframes te maken, moet je de opmaak van een simpel frame aanpassen. Er zijn verschillende opmaakopties die je op een zoomframe kunt toepassen. 

Je kunt de opmaak van een zoomframe op een dia op de volgende manier regelen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak nieuwe dia's aan waar je het zoomframe aan wilt koppelen. 
3. Voeg een identificatietekst en achtergrond toe aan de gemaakte dia's.
4. Voeg zoomframes (die naar de gemaakte dia's verwijzen) toe aan de eerste dia.
5. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) object aan door een afbeelding toe te voegen aan de Images‑collectie die gekoppeld is aan het [Presentation]‑object, die gebruikt zal worden om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het eerste zoomframe‑object.
7. Wijzig het lijndefinitie voor het tweede zoomframe‑object.
8. Verwijder de achtergrond van de afbeelding van het tweede zoomframe‑object.
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Voegt nieuwe dia's toe aan de presentatie
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// Maakt een achtergrond voor de tweede dia
SetSlideBackground(slide2, Color::get_Cyan());

// Maakt een tekstvak voor de tweede dia
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Maakt een achtergrond voor de derde dia
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Maakt een tekstvak voor de derde dia
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Voegt ZoomFrame-objecten toe
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Maakt een nieuwe afbeelding voor het zoomobject
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// Stelt aangepaste afbeelding in voor zoomFrame1-object
zoomFrame1->set_Image(image);

// Stelt een zoomframe-opmaak in voor zoomFrame2-object
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// Instelling om de achtergrond niet weer te geven voor zoomFrame2-object
zoomFrame2->set_ShowBackground(false);

// Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Sectiezoom**

Een sectiezoom is een koppeling naar een sectie in je presentatie. Je kunt sectiezooms gebruiken om terug te gaan naar secties die je echt wilt benadrukken. Of je kunt ze gebruiken om te laten zien hoe bepaalde delen van je presentatie met elkaar verbonden zijn. 

![overview_image](seczoomsel.png)

Voor sectiezoom-objecten biedt Aspose.Slides de interface [ISectionZoomFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isectionzoomframe/) en enkele methoden onder de interface [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/).

### **Sectiezoom‑frames maken**

Zo kun je een sectiezoom‑frame aan een dia toevoegen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak een nieuwe dia. 
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waar je het zoomframe aan wilt koppelen. 
5. Voeg een sectiezoom‑frame (dat verwijst naar de gemaakte sectie) toe aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Voegt een nieuwe dia toe aan de presentatie
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

//Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 1", slide);

//Voegt een SectionZoomFrame-object toe
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

//Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Sectiezoom‑frames maken met aangepaste afbeeldingen**

Met Aspose.Slides for C++ kun je een sectiezoom‑frame met een andere dia‑preview‑afbeelding maken op de volgende manier: 

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waar je het zoomframe aan wilt koppelen. 
5. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) object aan door een afbeelding toe te voegen aan de Images‑collectie die gekoppeld is aan het [Presentation]‑object, die gebruikt zal worden om het frame te vullen.
5. Voeg een sectiezoom‑frame toe (dat een referentie naar de gemaakte sectie bevat) aan de eerste dia.
6. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Voegt een nieuwe dia toe aan de presentatie
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 1", slide);

// Maakt een nieuwe afbeelding voor het zoomobject
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Voegt SectionZoomFrame-object toe
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Sectiezoom‑frames opmaken**

Om meer complexe sectiezoom‑frames te maken, moet je de opmaak van een simpel frame aanpassen. Er zijn verschillende opmaakopties die je op een sectiezoom‑frame kunt toepassen. 

Je kunt de opmaak van een sectiezoom‑frame op een dia op de volgende manier regelen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak een nieuwe dia.
3. Voeg een identificatie‑achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waar je het zoomframe aan wilt koppelen. 
5. Voeg een sectiezoom‑frame (dat verwijst naar de gemaakte sectie) toe aan de eerste dia.
6. Wijzig de grootte en positie van het gemaakte sectiezoom‑object.
7. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) object aan door een afbeelding toe te voegen aan de Images‑collectie die gekoppeld is aan het [Presentation]‑object, die gebruikt zal worden om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het gemaakte sectiezoom‑frame‑object.
9. Stel de *terugkeer naar de oorspronkelijke dia van de gekoppelde sectie* functionaliteit in. 
10. Verwijder de achtergrond van de afbeelding van het sectiezoom‑frame‑object.
11. Wijzig het lijndefinitie voor het tweede zoomframe‑object.
12. Wijzig de duur van de overgang.
13. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Voegt een nieuwe dia toe aan de presentatie
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 1", slide);

// Voegt SectionZoomFrame-object toe
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Opmaak voor SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

//Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **Samenvattingszoom**

Een samenvattingszoom is als een landingspagina waarop alle onderdelen van je presentatie tegelijk worden weergegeven. Wanneer je presenteert, kun je de zoom gebruiken om van de ene naar de andere plek in je presentatie te gaan in elke gewenste volgorde. Je kunt creatief zijn, vooruit springen of delen van je diavoorstelling opnieuw bezoeken zonder de stroom van je presentatie te onderbreken.

![overview_image](sumzoomsel.png)

Voor samenvattingszoom-objecten biedt Aspose.Slides de interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isummaryzoomsection/) en [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isummaryzoomsectioncollection/), en enkele methoden onder de interface [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/) .

### **Samenvattingszoom maken**

Zo kun je een samenvattingszoom‑frame aan een dia toevoegen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak nieuwe dia's met een identificatie‑achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg het samenvattingszoom‑frame toe aan de eerste dia.
4. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Voegt een nieuwe dia toe aan de presentatie
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 1", slide);

// Voegt een nieuwe dia toe aan de presentatie
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 2", slide);

// Voegt een nieuwe dia toe aan de presentatie
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 3", slide);

// Voegt een nieuwe dia toe aan de presentatie
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 4", slide);

// Voegt een SummaryZoomFrame-object toe
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Een samenvattingszoom‑sectie toevoegen en verwijderen**

Alle secties in een samenvattingszoom‑frame worden weergegeven door [ISummaryZoomSection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isummaryzoomsection/) objecten, die worden opgeslagen in het [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isummaryzoomsectioncollection/) object. Je kunt een samenvattingszoom‑sectieobject toevoegen of verwijderen via de interface [ISummaryZoomSectionCollection] op de volgende manier:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak nieuwe dia's met een identificatie‑achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg een samenvattingszoom‑frame toe aan de eerste dia.
4. Voeg een nieuwe dia en sectie toe aan de presentatie.
5. Voeg de gemaakte sectie toe aan het samenvattingszoom‑frame.
6. Verwijder de eerste sectie uit het samenvattingszoom‑frame.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Voegt een nieuwe dia toe aan de presentatie
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 1", slide);

//Voegt een nieuwe dia toe aan de presentatie
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 2", slide);

// Voegt SummaryZoomFrame-object toe
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Voegt een nieuwe dia toe aan de presentatie
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Voegt een nieuwe sectie toe aan de presentatie
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Voegt een sectie toe aan de Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Verwijdert sectie uit de Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Samenvattingszoom‑secties opmaken**

Om meer complexe samenvattingszoom‑sectie‑objecten te maken, moet je de opmaak van een simpel frame aanpassen. Er zijn verschillende opmaakopties die je op een samenvattingszoom‑sectie‑object kunt toepassen. 

Je kunt de opmaak van een samenvattingszoom‑sectie‑object in een samenvattingszoom‑frame op de volgende manier regelen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) .
2. Maak nieuwe dia's met een identificatie‑achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg een samenvattingszoom‑frame toe aan de eerste dia.
4. Haal een samenvattingszoom‑sectie‑object op voor het eerste object uit de `ISummaryZoomSectionCollection`.
7. Maak een [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) object aan door een afbeelding toe te voegen aan de images‑collectie die gekoppeld is aan het [Presentation]‑object, die gebruikt zal worden om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het gemaakte sectiezoom‑frame‑object.
9. Stel de *terugkeer naar de oorspronkelijke dia van de gekoppelde sectie* functionaliteit in. 
11. Wijzig het lijndefinitie voor het tweede zoomframe‑object.
12. Wijzig de duur van de overgang.
13. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Voegt een nieuwe dia toe aan de presentatie
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 1", slide);

//Voegt een nieuwe dia toe aan de presentatie
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Voegt een nieuwe sectie toe aan de presentatie
pres->get_Sections()->AddSection(u"Section 2", slide);

// Voegt een SummaryZoomFrame-object toe
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Haalt het eerste SummaryZoomSection-object op
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Opmaak voor SummaryZoomSection-object
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Slaat de presentatie op
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan ik het terugkeren naar de 'ouder' dia regelen nadat het doel is weergegeven?**

Ja. Het [Zoom frame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/zoomframe/) of de [section](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sectionzoomframe/) heeft een `set_ReturnToParent`‑method die kijkers terugstuurt naar de oorspronkelijke dia nadat ze de doelinhoud hebben bezocht.

**Kan ik de 'snelheid' of duur van de Zoom‑overgang aanpassen?**

Ja. Zoom ondersteunt het instellen van een overgangsduur zodat je kunt bepalen hoe lang de spronganimatie duurt.

**Zijn er limieten aan hoeveel Zoom‑objecten een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische limieten hangen af van de algemene complexiteit van de presentatie en de prestaties van de viewer. Je kunt veel Zoom‑frames toevoegen, maar houd rekening met bestandsgrootte en render‑tijd.