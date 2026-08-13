---
title: Watermerken toevoegen aan presentaties in .NET
linktitle: Watermerk
type: docs
weight: 40
url: /nl/net/watermark/
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
- .NET
- C#
- Aspose.Slides
description: "Beheer tekst- en afbeeldingwatermerken in PowerPoint- en OpenDocument-presentaties in .NET om een concept, vertrouwelijke informatie, auteursrechten en meer aan te duiden."
---
## **Introductie**

**Een watermerk** in een presentatie is een tekst‑ of afbeeldingstempel die op een dia of op alle dia’s van een presentatie wordt toegepast. Gewoonlijk wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijvoorbeeld een “Concept‑watermerk”), dat deze vertrouwelijke informatie bevat (bijvoorbeeld een “Vertrouwelijk‑watermerk”), om aan te geven van welk bedrijf hij afkomstig is (bijvoorbeeld een “Bedrijfsnaam‑watermerk”), om de auteur van de presentatie te identificeren, enz. Een watermerk helpt auteursrechtenschendingen te voorkomen door te tonen dat de presentatie niet gekopieerd mag worden. Watermerken worden gebruikt in zowel PowerPoint‑ als OpenDocument‑presentatieformaten. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT‑, PPTX‑ en OpenDocument‑ODP‑bestanden.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/net/), zijn er verschillende manieren om watermerken te maken in PowerPoint‑ of OpenDocument‑documenten en hun ontwerp en gedrag te wijzigen. Het gemeenschappelijke aspect is dat je voor tekstwatermerken de [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/)‑interface moet gebruiken, en voor afbeeldingwatermerken de [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/)‑klasse of de vulling van een watermerkvorm met een afbeelding. `PictureFrame` implementeert de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape)‑interface, waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Omdat `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt het ingepakt in een [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape)‑object.

Er zijn twee manieren waarop een watermerk kan worden toegepast: op één enkele dia of op alle dia’s van de presentatie. De Slide Master wordt gebruikt om een watermerk op alle dia’s toe te passen — het watermerk wordt toegevoegd aan de Slide Master, daar volledig vormgegeven, en vervolgens op alle dia’s toegepast zonder de mogelijkheid om het watermerk op individuele dia’s te wijzigen.

Een watermerk wordt doorgaans als niet‑bewerkbaar door andere gebruikers beschouwd. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides functionaliteit voor het vergrendelen van vormen. Een specifieke vorm kan vergrendeld worden op een gewone dia of op een Slide Master. Wanneer de watermerk‑vorm vergrendeld is op de Slide Master, is hij vergrendeld op alle dia’s van de presentatie.

Je kunt een naam aan het watermerk toekennen zodat je het later, wanneer je het wilt verwijderen, kunt vinden op naam in de vormen van de dia.

Je kunt het watermerk op elke gewenste manier vormgeven; doorgaans hebben watermerken echter gemeenschappelijke kenmerken, zoals centreren, roteren, voorgrondpositie, enz. We zullen in de onderstaande voorbeelden laten zien hoe je deze eigenschappen kunt gebruiken.

## **Tekstwatermerk**

### **Een tekstwatermerk aan een dia toevoegen**

Om een tekstwatermerk toe te voegen aan een PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen en vervolgens een tekstframe aan die vorm. Het tekstframe wordt vertegenwoordigd door de [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe)‑interface. Dit type erft niet van [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/), welke een breed scala aan eigenschappen biedt voor het flexibel positioneren van het watermerk. Daarom wordt het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe)‑object ingepakt in een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/)‑object. Om watermerktekst aan de vorm toe te voegen, gebruik je de [AddTextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/methods/addtextframe)‑methode zoals hieronder weergegeven.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Voeg het watermerk toe aan de dia.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Zie ook" %}} 
- [Hoe de TextFrame‑klasse te gebruiken?](/slides/nl/net/text-formatting/)
{{% /alert %}}

### **Een tekstwatermerk aan een presentatie toevoegen**

Als je een tekstwatermerk wilt toevoegen aan de volledige presentatie (dus aan alle dia’s tegelijk), voeg je het toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/masterslide/). De rest van de logica is hetzelfde als bij het toevoegen van een watermerk aan één dia — maak een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/)‑object en voeg het watermerk toe met de [AddTextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/methods/addtextframe)‑methode.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Voeg het watermerk toe aan de masterdia.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Zie ook" %}} 
- [Hoe de Slide Master te gebruiken?](/slides/nl/net/slide-master/)
{{% /alert %}}

### **Transparantie van watermerkvorm instellen**

Standaard heeft de rechthoekige vorm een vul‑ en lijnkleur. Dit betekent dat wanneer het watermerk wordt toegevoegd, het een vullende achtergrond of rand kan hebben die mogelijk afleidt van de inhoud van de dia. Om ervoor te zorgen dat het watermerk subtiel blijft en de visuele vormgeving van de presentatie niet verstoort, kun je de vorm volledig transparant maken.

De onderstaande code maakt de vorm transparant door zowel de vul‑ als de randkleur te verwijderen:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Lettertype voor een tekstwatermerk instellen**

Voordat je het tekstwatermerk op je dia toepast, is het belangrijk het uiterlijk aan te passen zodat het harmonieert met het algemene ontwerp. Je kunt het lettertype en de grootte wijzigen om ervoor te zorgen dat het watermerk goed leesbaar en esthetisch aantrekkelijk is. Het aanpassen van het lettertype kan ook helpen de merkidentiteit te versterken of simpelweg aan de stijl van de presentatie te voldoen.

De codefragment hieronder toont hoe je de lettertype‑instellingen van het watermerk wijzigt door een specifiek Latijns lettertype te selecteren en een passende letterhoogte in te stellen:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Kleur van watermerktekst instellen**

Voordat je je watermerk toepast, moet je ervoor zorgen dat de tekstkleur op de juiste manier is ingesteld zodat deze goed samengaat met de inhoud van je dia zonder deze te overweldigen. Het aanpassen van de transparantie (alpha) van de kleur samen met de rood‑, groen‑ en blauwe componenten stelt je in staat een subtiel, halfdoorzichtig watermerk te maken dat zichtbaar maar niet storend is. Deze aanpak helpt de focus op je hoofd­presentatie te behouden terwijl je toch je inhoud beschermt.

Gebruik de volgende code om de kleur van de watermerktekst in te stellen:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Een tekstwatermerk centreren**

Het correct centreren van je tekstwatermerk kan de algehele esthetiek van je presentatie aanzienlijk verbeteren doordat het watermerk symmetrisch gepositioneerd wordt, ongeacht de afmetingen van de dia. Deze aanpak geeft je dia’s een professioneel uiterlijk en zorgt ervoor dat het watermerk de hoofdinhoud van de dia niet hindert.

De codefragment hieronder laat zien hoe je de middelste positie van een dia berekent en het tekstwatermerk daarop plaatst:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

De afbeelding hieronder toont het eindresultaat.

![The text watermark](text_watermark.png)

## **Afbeeldings‑watermerk**

### **Een afbeelding‑watermerk aan een presentatie toevoegen**

In veel gevallen kan een afbeelding‑watermerk een uniek branding‑element of een visueel aantrekkelijker alternatief voor een tekst‑watermerk bieden. Zorg er voordat je het watermerk toevoegt voor dat het afbeeldingsbestand beschikbaar is (bijvoorbeeld PNG voor transparantie). Het volgende voorbeeld toont hoe je een afbeelding uit je bestandssysteem laadt, deze aan de presentatie toevoegt en vervolgens als watermerk toepast via de vul‑eigenschappen van de vorm.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Een watermerk vergrendelen tegen bewerken**

Indien je moet voorkomen dat een watermerk bewerkt wordt, gebruik je de [IAutoShape.ShapeLock](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/properties/shapelock)‑eigenschap op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selecteren, herschalen, verplaatsen, groeperen met andere elementen, de tekst vergrendelen tegen bewerken, en nog veel meer:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Vergrendel de watermerkvorm tegen wijzigen.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Een watermerk naar de voorgrond halen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de [IShapeCollection.Reorder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/reorder/#reorder)‑methode. Roep deze methode aan vanuit de lijst met presentatiedia’s en geef de vormreferentie en het gewenste volgordenummer door. Op diese manier kun je een vorm naar de voorgrond brengen of naar de achtergrond verplaatsen. Deze functionaliteit is vooral handig als je een watermerk voor de rest van de presentatie wilt plaatsen:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Rotatie van een watermerk instellen**

Het aanpassen van de rotatie van je watermerk kan de visuele impact en subtiliteit van je presentatie aanzienlijk verbeteren. Een diagonaal watermerk is bijvoorbeeld minder storend, terwijl het toch een robuuste bescherming biedt tegen ongeoorloofd gebruik. Het volgende voorbeeld berekent de juiste hoek op basis van de afmetingen van de dia zodat het watermerk diagonaal over de dia wordt geplaatst. Deze dynamische berekening zorgt ervoor dat het watermerk effectief blijft, ongeacht variërende dia‑groottes.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Een naam aan een watermerk toekennen**

Aspose.Slides stelt je in staat de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kun je later de vorm vinden om deze te wijzigen of te verwijderen. Om de naam van de watermerk‑vorm in te stellen, ken je deze toe aan de [IAutoShape.Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/name)‑eigenschap:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Een watermerk verwijderen**

Om de watermerk‑vorm te verwijderen, gebruik je de [IAutoShape.Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/name)‑eigenschap om de vorm in de dia‑vormen te vinden. Vervolgens geef je de watermerk‑vorm door aan de [IShapeCollection.Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/remove/)‑methode:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.ShapesToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Een live‑voorbeeld**

Je kunt de **Aspose.Slides free** online‑tools [Add Watermark](https://products.aspose.app/slides/nl/watermark) en [Remove Watermark](https://products.aspose.app/slides/nl/watermark/remove-watermark) uitproberen.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

### Wat is een watermerk en waarom zou ik het gebruiken?

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia’s wordt toegepast en helpt intellectueel eigendom te beschermen, merkherkenning te versterken of ongeoorloofd gebruik van presentaties te voorkomen.

### Kan ik een watermerk aan alle dia’s van een presentatie toevoegen?

Ja, Aspose.Slides maakt het mogelijk om programmatically een watermerk toe te voegen aan elke dia in een presentatie. Je kunt door alle dia’s itereren en de watermerk‑instellingen afzonderlijk toepassen.

### Hoe kan ik de transparantie van het watermerk aanpassen?

Je kunt de transparantie van het watermerk aanpassen door de vulinstellingen ([FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/fillformat/)) van de vorm te wijzigen. Hierdoor blijft het watermerk subtiel en afleidt het niet van de inhoud van de dia.

### Welke beeldformaten worden ondersteund voor watermerken?

Aspose.Slides ondersteunt diverse beeldformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

### Kan ik het lettertype en de stijl van een tekstwatermerk aanpassen?

Ja, je kunt elk lettertype, elke grootte en elke stijl kiezen om het ontwerp van je presentatie te laten overeenkomen en de merkconsistentie te behouden.

### Hoe wijzig ik de positie of oriëntatie van een watermerk?

Je kunt de positie en oriëntatie van het watermerk programmatically aanpassen door de coördinaten, de grootte en de rotatie‑eigenschappen van de vorm te wijzigen.