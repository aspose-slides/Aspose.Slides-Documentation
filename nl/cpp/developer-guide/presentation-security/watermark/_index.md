---
title: Watermerken toevoegen aan presentaties in C++
linktitle: Watermerk
type: docs
weight: 40
url: /nl/cpp/watermark/
keywords:
- watermerk
- tekstwatermerk
- afbeeldingswatermerk
- watermerk toevoegen
- watermerk wijzigen
- watermerk verwijderen
- watermerk wissen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen uit PPT
- watermerk verwijderen uit PPTX
- watermerk verwijderen uit ODP
- watermerk wissen uit PPT
- watermerk wissen uit PPTX
- watermerk wissen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer tekst- en afbeelding-watermerken in PowerPoint- en OpenDocument-presentaties in C++ om een concept, vertrouwelijke informatie, auteursrecht en meer aan te geven."
---
## **Introductie**

**Een watermerk** in een presentatie is een tekst‑ of afbeeldingstempel die op een dia of op alle dia's van een presentatie wordt gebruikt. Meestal wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Concept” watermerk), dat deze vertrouwelijke informatie bevat (bijv. een “Vertrouwelijk” watermerk), om te vermelden van welk bedrijf deze afkomstig is (bijv. een “Bedrijfsnaam” watermerk), om de auteur van de presentatie te identificeren, enz. Een watermerk helpt auteursrechtschendingen te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden zowel in PowerPoint‑ als OpenOffice‑presentatieformaten gebruikt. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice‑ODP‑bestanden.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/cpp/), zijn er verschillende manieren om watermerken te maken in PowerPoint‑ of OpenOffice‑documenten en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke aspect is dat je voor tekst‑watermerken de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) interface gebruikt, en voor afbeelding‑watermerken de [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/) klasse of een watermerk‑vorm vult met een afbeelding. `PictureFrame` implementeert de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) interface, waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Omdat `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt deze ingepakt in een [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) object.

Er zijn twee manieren waarop een watermerk kan worden toegepast: op één enkele dia of op alle dia's van de presentatie. De Slide Master wordt gebruikt om een watermerk op alle dia's toe te passen — het watermerk wordt aan de Slide Master toegevoegd, daar volledig ontworpen, en vervolgens op alle dia's toegepast zonder de mogelijkheid om het watermerk op individuele dia's te wijzigen.

Een watermerk wordt meestal als niet‑bewerkbaar voor andere gebruikers beschouwd. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides vergrendelingsfunctionaliteit voor vormen. Een specifieke vorm kan worden vergrendeld op een normale dia of op een Slide Master. Wanneer de watermerk‑vorm op de Slide Master wordt vergrendeld, is deze op alle dia's vergrendeld.

Je kunt een naam aan het watermerk toekennen zodat je het later, wanneer je het wilt verwijderen, kunt vinden in de vormen van de dia op basis van die naam.

Je kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter meestal gemeenschappelijke kenmerken in watermerken, zoals centreren, roteren, voorgrondpositie, enz. We zullen bekijken hoe we deze in de onderstaande voorbeelden kunnen gebruiken.

## **Tekst‑watermerk**

### **Een tekst‑watermerk aan een dia toevoegen**

Om een tekst‑watermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen en vervolgens een tekstframe aan die vorm. Het tekstframe wordt weergegeven door de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) interface. Dit type is niet afgeleid van [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/), die een breed scala aan eigenschappen biedt voor het flexibel positioneren van het watermerk. Daarom wordt het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) object ingepakt in een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) object. Om tekst aan de vorm toe te voegen, gebruik je de [AddTextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/addtextframe/) methode zoals hieronder getoond.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Zie ook" %}} 
- [Hoe de TextFrame‑klasse te gebruiken](/slides/nl/cpp/text-formatting/)
{{% /alert %}}

### **Een tekst‑watermerk aan een presentatie toevoegen**

Wil je een tekst‑watermerk toevoegen aan de gehele presentatie (dus aan alle dia’s tegelijk), voeg je het toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/masterslide/). De rest van de logica is dezelfde als bij het toevoegen van een watermerk aan één dia — maak een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) object en voeg vervolgens het watermerk toe met de [AddTextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/addtextframe/) methode.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Zie ook" %}} 
- [Hoe de Slide Master te gebruiken](/slides/nl/cpp/slide-master/)
{{% /alert %}}

### **Transparantie van de watermerk‑vorm instellen**

Standaard heeft de rechthoekige vorm een opvul‑ en lijnkleur. De volgende code maakt de vorm transparant.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Lettertype voor een tekst‑watermerk instellen**

Je kunt het lettertype van het tekst‑watermerk wijzigen zoals hieronder weergegeven.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Kleur van de watermerk‑tekst instellen**

Om de kleur van de watermerk‑tekst in te stellen, gebruik je de volgende code:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Een tekst‑watermerk centreren**

Het is mogelijk om het watermerk te centreren op een dia; hiervoor kun je het volgende doen:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

De afbeelding hieronder toont het eindresultaat.

![The text watermark](text_watermark.png)

## **Afbeeldings‑watermerk**

### **Een afbeelding‑watermerk aan een presentatie toevoegen**

Om een afbeelding‑watermerk aan een presentatiedia toe te voegen, kun je het volgende doen:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Een watermerk tegen bewerking beveiligen**

Indien het nodig is om een watermerk te beschermen tegen bewerking, gebruik je de [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/get_autoshapelock/) methode op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selectie, grootte‑aanpassing, verplaatsing, groeperen met andere elementen, vergrendelen van de tekst tegen bewerking, en meer:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Vergrendel de watermerkvorm tegen bewerken
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Een watermerk naar voren brengen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de [IShapeCollection::Reorder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/reorder/) methode. Hiervoor roep je deze methode aan vanuit de lijst met presentatiedia’s en geef je de vormreferentie en het gewenste volgordenummer door. Op deze manier kun je een vorm naar de voorgrond brengen of naar de achtergrond verplaatsen. Deze functionaliteit is vooral handig wanneer je een watermerk voor de rest van de presentatie wilt plaatsen:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Watermerkrotatie instellen**

Hieronder een codevoorbeeld van hoe je de rotatie van het watermerk kunt aanpassen zodat het diagonaal over de dia wordt geplaatst:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Een naam aan een watermerk toewijzen**

Aspose.Slides stelt je in staat een naam aan een vorm toe te kennen. Met de vormnaam kun je later de vorm benaderen om deze te wijzigen of te verwijderen. Om de naam van de watermerk‑vorm in te stellen, wijs je deze toe via de [IAutoShape::set_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_name/) methode:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Een watermerk verwijderen**

Om de watermerk‑vorm te verwijderen, gebruik je de [IAutoShape::get_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_name/) methode om deze in de dia‑vormen te vinden. Vervolgens geef je de watermerk‑vorm door aan de [IShapeCollection::Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/remove/) methode:

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Een live‑voorbeeld**

Je kunt de **Aspose.Slides free** online‑tools **Add Watermark**[https://products.aspose.app/slides/nl/watermark] en **Remove Watermark**[https://products.aspose.app/slides/nl/watermark/remove-watermark] uitproberen.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

### Wat is een watermerk en waarom zou ik het gebruiken?

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia’s wordt aangebracht om intellectueel eigendom te beschermen, merkherkenning te versterken of ongeoorloofd gebruik van presentaties te voorkomen.

### Kan ik een watermerk aan alle dia’s van een presentatie toevoegen?

Ja, Aspose.Slides stelt je in staat programmatically een watermerk aan elke dia van een presentatie toe te voegen. Je kunt door alle dia’s itereren en de watermerk‑instellingen per dia toepassen.

### Hoe kan ik de transparantie van het watermerk aanpassen?

Je kunt de transparantie van het watermerk aanpassen door de opvulinstellingen ([FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/get_fillformat/)) van de vorm te wijzigen. Zo blijft het watermerk subtiel en niet storend voor de inhoud van de dia.

### Welke afbeeldingformaten worden ondersteund voor watermerken?

Aspose.Slides ondersteunt verschillende afbeeldingformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

### Kan ik het lettertype en de stijl van een tekst‑watermerk aanpassen?

Ja, je kunt elk lettertype, grootte en stijl kiezen die passen bij het ontwerp van je presentatie en de merkconsistentie behouden.

### Hoe wijzig ik de positie of oriëntatie van een watermerk?

Je kunt de positie en oriëntatie van het watermerk programmatically aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de vorm te wijzigen.