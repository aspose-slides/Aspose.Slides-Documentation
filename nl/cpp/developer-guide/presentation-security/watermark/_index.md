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
description: "Beheer tekst- en afbeeldingswatermerken in PowerPoint- en OpenDocument-presentaties in C++ om een concept, vertrouwelijke informatie, auteursrechten en meer aan te duiden."
---
## **Inleiding**

**Een watermerk** in een presentatie is een tekst‑ of afbeeldingsstempel die op een dia of in alle presentatiedia’s wordt gebruikt. Meestal wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Concept” watermerk), dat hij vertrouwelijke informatie bevat (bijv. een “Vertrouwelijk” watermerk), om te vermelden tot welk bedrijf hij behoort (bijv. een “Bedrijfsnaam” watermerk), om de auteur van de presentatie te identificeren, enzovoort. Een watermerk helpt auteursrechtinbreuk te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden zowel in PowerPoint‑ als OpenOffice‑presentatieformaten gebruikt. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice‑ODP‑bestanden.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/cpp/), zijn er verschillende manieren om watermerken in PowerPoint‑ of OpenOffice‑documenten te maken en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke aspect is dat je voor tekst‑watermerken de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/)-interface moet gebruiken, en voor afbeelding‑watermerken de [PictureFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pictureframe/)-klasse of een watermerk‑vorm kunt vullen met een afbeelding. `PictureFrame` implementeert de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)-interface, waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Omdat `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt het ingepakt in een [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)-object.

Er zijn twee manieren waarop een watermerk kan worden toegepast: op één enkele dia of op alle presentatiedia’s. De Slide Master wordt gebruikt om een watermerk op alle dia’s toe te passen — het watermerk wordt aan de Slide Master toegevoegd, daar volledig ontworpen, en op alle dia’s toegepast zonder de mogelijkheid om het watermerk op individuele dia’s te wijzigen.

Een watermerk wordt normaal gesproken beschouwd als niet bewerkbaar door andere gebruikers. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides functionaliteit voor het vergrendelen van vormen. Een specifieke vorm kan worden vergrendeld op een normale dia of op een Slide Master. Wanneer de watermerk‑vorm op de Slide Master wordt vergrendeld, wordt deze op alle presentatiedia’s vergrendeld.

Je kunt een naam aan het watermerk geven zodat je later, als je het wilt verwijderen, de vorm in de dia’s kunt vinden op naam.

Je kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter meestal algemene kenmerken van watermerken, zoals centrering, rotatie, voorgrondpositie, enzovoort. We zullen hieronder laten zien hoe je deze kunt gebruiken in de voorbeelden.

## **Tekst‑watermerk**

### **Tekst‑watermerk aan een dia toevoegen**

Om een tekst‑watermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen en vervolgens een tekst‑frame aan die vorm. Het tekst‑frame wordt vertegenwoordigd door de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/)-interface. Dit type erft niet van [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/), dat een breed scala aan eigenschappen biedt voor het flexibel positioneren van het watermerk. Daarom wordt het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/)-object ingepakt in een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/)-object. Om tekst aan de vorm toe te voegen, gebruik je de [AddTextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/addtextframe/)-methode zoals hieronder weergegeven.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/nl/cpp/text-formatting/)
{{% /alert %}}

### **Tekst‑watermerk aan een presentatie toevoegen**

Wil je een tekst‑watermerk toevoegen aan de volledige presentatie (dus aan alle dia’s tegelijk), voeg het dan toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/masterslide/). De rest van de logica is hetzelfde als bij het toevoegen van een watermerk aan één dia — maak een [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/)-object en voeg vervolgens het watermerk toe met de [AddTextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/addtextframe/)-methode.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/nl/cpp/slide-master/)
{{% /alert %}}

### **Transparantie van de watermerk‑vorm instellen**

Standaard wordt de rechthoekige vorm opgemaakt met vul‑ en lijnkleuren. De volgende code maakt de vorm transparant.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Lettertype voor een tekst‑watermerk instellen**

Je kunt het lettertype van het tekst‑watermerk wijzigen zoals hieronder weergegeven.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Kleur van de watermerk‑tekst instellen**

Om de kleur van de watermerk‑tekst in te stellen, gebruik je deze code:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Een tekst‑watermerk centreren**

Het is mogelijk om het watermerk te centreren op een dia; doe daarvoor het volgende:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

De afbeelding hieronder toont het uiteindelijke resultaat.

![The text watermark](text_watermark.png)

## **Afbeeldings‑watermerk**

### **Afbeeldings‑watermerk aan een presentatie toevoegen**

Om een afbeelding‑watermerk toe te voegen aan een presentatiedia, kun je het volgende doen:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Een watermerk tegen bewerken vergrendelen**

Indien het noodzakelijk is om een watermerk te beschermen tegen bewerken, gebruik je de [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/get_autoshapellock/)-methode op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selectie, herschalen, verplaatsen, groeperen met andere elementen, het tekstgedeelte vergrendelen, enzovoort:

```cpp
// Vergrendel de watermerkvorm tegen bewerken
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Een watermerk naar voren brengen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de [IShapeCollection::Reorder](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/reorder/)-methode. Hiervoor roep je deze methode aan vanuit de lijst met presentatiedia’s en geef je zowel de vormreferentie als het order‑nummer door. Op deze manier kun je een vorm naar de voorgrond brengen of naar de achtergrond van de dia verplaatsen. Deze functie is vooral handig wanneer je een watermerk voor de rest van de presentatie wilt plaatsen:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Rotatie van het watermerk instellen**

Hier is een code‑voorbeeld hoe je de rotatie van het watermerk kunt aanpassen zodat het diagonaal over de dia wordt geplaatst:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Een naam aan een watermerk geven**

Aspose.Slides stelt je in staat de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kun je later de vorm vinden om deze te wijzigen of te verwijderen. Om de naam van de watermerk‑vorm in te stellen, wijs je deze toe via de [IAutoShape::set_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/set_name/)-methode:

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Een watermerk verwijderen**

Om de watermerk‑vorm te verwijderen, gebruik je de [IAutoShape::get_Name](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_name/)-methode om deze in de dia‑vormen te vinden. Vervolgens geef je de watermerk‑vorm door aan de [IShapeCollection::Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/remove/)-methode:

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Een live‑voorbeeld**

Je kunt de **Aspose.Slides free**‑tools [Add Watermark](https://products.aspose.app/slides/nl/watermark) en [Remove Watermark](https://products.aspose.app/slides/nl/watermark/remove-watermark) online uitproberen.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Wat is een watermerk en waarom zou ik het gebruiken?**

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia’s wordt toegepast om intellectueel eigendom te beschermen, merkherkenning te versterken of ongeoorloofd gebruik van presentaties te voorkomen.

**Kan ik een watermerk toevoegen aan alle dia’s van een presentatie?**

Ja, Aspose.Slides maakt het mogelijk om programmatisch een watermerk toe te voegen aan elke dia van een presentatie. Je kunt door alle dia’s itereren en de watermerk‑instellingen per dia toepassen.

**Hoe kan ik de transparantie van het watermerk aanpassen?**

Je kunt de transparantie van het watermerk aanpassen door de vulinstellingen ([FillFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/get_fillformat/)) van de vorm te wijzigen. Zo blijft het watermerk subtiel en afleidt het niet van de inhoud.

**Welke afbeeldingsformaten worden ondersteund voor watermerken?**

Aspose.Slides ondersteunt diverse afbeeldingsformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

**Kan ik het lettertype en de stijl van een tekst‑watermerk aanpassen?**

Ja, je kunt elk lettertype, grootte en stijl kiezen die passen bij het ontwerp van je presentatie en de merkconsistentie behouden.

**Hoe wijzig ik de positie of oriëntatie van een watermerk?**

Je kunt de positie en oriëntatie van het watermerk programmatisch aanpassen door de coördinaten, afmetingen en rotatie‑eigenschappen van de vorm te bewerken.