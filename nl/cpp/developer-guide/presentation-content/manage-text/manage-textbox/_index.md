---
title: Beheer tekstvakken in presentaties met C++
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/cpp/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- kolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Aspose.Slides voor C++ maakt het eenvoudig om tekstvakken te maken, bewerken en dupliceren in PowerPoint- en OpenDocument-bestanden, waardoor uw presentatie-automatisering wordt verbeterd."
---
## **Introductie**

Teksten op dia's bestaan doorgaans in tekstvakken of vormen. Daarom moet je, om tekst aan een dia toe te voegen, een tekstvak toevoegen en vervolgens wat tekst in het tekstvak plaatsen. Aspose.Slides voor C++ biedt de [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) interface die je in staat stelt een vorm met tekst toe te voegen.

{{% alert title="Info" color="info" %}}
Aspose.Slides biedt ook de [IShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_shape) interface waarmee je vormen aan dia's kunt toevoegen. Niet alle vormen die via de `IShape`-interface worden toegevoegd, kunnen tekst bevatten. Vormen die via de [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) interface worden toegevoegd, kunnen echter tekst bevatten. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Daarom, wanneer je werkt met een vorm waaraan je tekst wilt toevoegen, wil je wellicht controleren en bevestigen dat deze via de `IAutoShape`-interface is gecast. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.text_frame), die een eigenschap is van `IAutoShape`. Zie de sectie [Update Text](https://docs.aspose.com/slides/nl/cpp/manage-textbox/#update-text) op deze pagina. 
{{% /alert %}}

## **Maak een tekstvak op een dia**

Om een tekstvak op een dia te maken, volg je deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse. 
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_auto_shape) object toe met [ShapeType](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg de referentie naar het nieuw toegevoegde `IAutoShape`-object. 
4. Voeg een `TextFrame`-eigenschap toe aan het `IAutoShape`-object die tekst zal bevatten. In het onderstaande voorbeeld hebben we deze tekst toegevoegd: *Aspose TextBox*
5. Schrijf tenslotte het PPTX‑bestand weg via het `Presentation`-object. 

Deze C++‑code – een implementatie van de bovenstaande stappen – laat zien hoe je tekst aan een dia toevoegt:

```cpp
// Instantieert Presentation
auto pres = System::MakeObject<Presentation>();

// Haalt de eerste dia op in de presentatie
auto sld = pres->get_Slides()->idx_get(0);

// Voegt een AutoShape toe met type ingesteld op Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Voegt een TextFrame toe aan de Rectangle
ashp->AddTextFrame(u" ");

// Toegang tot het tekstframe
auto txtFrame = ashp->get_TextFrame();

// Creëert het Paragraph-object voor het tekstframe
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Creëert een Portion-object voor de paragraaf
auto portion = para->get_Portions()->idx_get(0);

// Stelt de tekst in
portion->set_Text(u"Aspose TextBox");

// Slaat de presentatie op naar schijf
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Controleer op een tekstvakvorm**

Aspose.Slides biedt de [get_IsTextBox](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/get_istextbox/) methode van de [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) interface, waarmee je vormen kunt onderzoeken en tekstvakken kunt identificeren.

![Tekstvak en vorm](istextbox.png)

Deze C++‑code laat zien hoe je controleert of een vorm als tekstvak is aangemaakt: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Merk op dat als je gewoon een autoshape toevoegt met de `AddAutoShape`‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/) interface, de `get_IsTextBox`‑methode van de autoshape `false` zal retourneren. Zodra je echter tekst toevoegt aan de autoshape met de `AddTextFrame`‑methode of de `set_Text`‑methode, retourneert de `get_IsTextBox`‑methode `true`.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() geeft false terug
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() geeft true terug

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() geeft false terug
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() geeft true terug

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() geeft false terug
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() geeft false terug

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() geeft false terug
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() geeft false terug
```

## **Kolommen toevoegen aan een tekstvak**

Aspose.Slides biedt de [set_ColumnCount](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) en [set_ColumnSpacing](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) methoden (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_text_frame_format) interface en de [TextFrameFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_text_frame_format) klasse) die je in staat stellen kolommen aan tekstvakken toe te voegen. Je kunt het aantal kolommen in een tekstvak opgeven en de tussenruimte in punten tussen de kolommen instellen. 

Deze C++‑code demonstreert de beschreven bewerking: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Haalt de eerste dia op in de presentatie
auto slide = presentation->get_Slides()->idx_get(0);

// Voegt een AutoShape toe met type ingesteld op Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Voegt een TextFrame toe aan de Rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Haalt het tekstformaat van TextFrame op
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Specificeert het aantal kolommen in TextFrame
format->set_ColumnCount(3);

// Specificeert de tussenruimte tussen kolommen
format->set_ColumnSpacing(10);

// Slaat de presentatie op
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Kolommen toevoegen aan een tekstframe**

Aspose.Slides voor C++ biedt de [set_ColumnCount](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) methode (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_text_frame_format) interface) die je in staat stelt kolommen in tekstframes toe te voegen. Met deze methode kun je het gewenste aantal kolommen in een tekstframe opgeven. 

Deze C++‑code laat zien hoe je een kolom binnen een tekstframe toevoegt:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Tekst bijwerken**

Aspose.Slides stelt je in staat de tekst in een tekstvak of alle teksten in een presentatie te wijzigen of bij te werken. 

Deze C++‑code demonstreert een bewerking waarbij alle teksten in een presentatie worden bijgewerkt of gewijzigd:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Wijzigt tekst
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Wijzigt opmaak
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Slaat gewijzigde presentatie op
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Een tekstvak met een hyperlink toevoegen**

Je kunt een koppeling in een tekstvak invoegen. Wanneer op het tekstvak wordt geklikt, worden gebruikers doorgestuurd om de koppeling te openen. 

Om een tekstvak met een koppeling toe te voegen, volg je deze stappen:

1. Maak een instantie van de `Presentation`‑klasse. 
2. Verkrijg een referentie naar de eerste dia in de nieuw aangemaakte presentatie. 
3. Voeg een `AutoShape`‑object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape‑object.
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object dat *Aspose TextBox* als standaardtekst bevat. 
5. Instantiateer de `IHyperlinkManager`‑klasse. 
6. Wijs het `IHyperlinkManager`‑object toe aan de [set_HyperlinkClick](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) methode die bij het gewenste gedeelte van het `TextFrame` hoort. 
7. Schrijf tenslotte het PPTX‑bestand weg via het `Presentation`‑object. 

Deze C++‑code – een implementatie van de bovenstaande stappen – laat zien hoe je een tekstvak met een hyperlink aan een dia toevoegt:

```cpp
// Instantieert een Presentation-klasse die een PPTX vertegenwoordigt
auto presentation = System::MakeObject<Presentation>();

// Haalt de eerste dia op in de presentatie
auto slide = presentation->get_Slides()->idx_get(0);

// Voegt een AutoShape-object toe met type ingesteld op Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Casteert de vorm naar AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Benadert de ITextFrame-eigenschap die bij de AutoShape hoort
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Voegt wat tekst toe aan het frame
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Stelt de hyperlink in voor de portion-tekst
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Slaat de PPTX-presentatie op
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **Veelgestelde vragen**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder bij het werken met masterslides?**

Een [placeholder](/slides/nl/cpp/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/cpp/aspose.slides/masterslide/) en kan worden overschreven op [layouts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/layoutslide/), terwijl een regulier tekstvak een onafhankelijk object op een specifieke dia is en niet verandert wanneer je van lay‑out wisselt.

**Hoe kan ik een bulk‑tekstvervanging uitvoeren in de hele presentatie zonder de tekst in grafieken, tabellen en SmartArt aan te raken?**

Beperk je iteratie tot autoshapes die tekstframes hebben en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/nl/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartart/)) uit door hun collecties afzonderlijk te doorlopen of die objecttypen over te slaan.