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
- watermerk aanpassen
- watermerk verwijderen
- watermerk wissen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen van PPT
- watermerk verwijderen van PPTX
- watermerk verwijderen van ODP
- watermerk wissen van PPT
- watermerk wissen van PPTX
- watermerk wissen van ODP
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer tekst- en afbeeldingswatermerken in PowerPoint- en OpenDocument-presentaties in .NET om een concept, vertrouwelijke informatie, copyright en meer aan te geven."
---
## **Introductie**

**Een watermerk** in een presentatie is een tekst‑ of afbeeldingstempel die op een dia of op alle dia’s van een presentatie wordt gebruikt. Meestal wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Concept”-watermerk), dat deze vertrouwelijke informatie bevat (bijv. een “Vertrouwelijk”-watermerk), om aan te geven bij welk bedrijf het hoort (bijv. een “Bedrijfsnaam”-watermerk), om de auteur van de presentatie te identificeren, enz. Een watermerk helpt auteursrechtschendingen te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden gebruikt in zowel PowerPoint‑ als OpenDocument‑presentatieformaten. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenDocument‑ODP‑bestandsformaten.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/net/), zijn er verschillende manieren om watermerken te maken in PowerPoint‑ of OpenDocument‑documenten en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke aspect is dat om tekstwatermerken toe te voegen, je de [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) interface moet gebruiken, en om afbeeldingwatermerken toe te voegen, gebruik je de [PictureFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/pictureframe/) klasse of vul je een watermerkvorm met een afbeelding. `PictureFrame` implementeert de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape) interface, waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Aangezien `ITextFrame` geen vorm is en de instellingen beperkt zijn, wordt deze gewikkeld in een [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape) object.

Er zijn twee manieren waarop een watermerk kan worden toegepast: op één enkele dia of op alle diavoorstellingen. De Slide Master wordt gebruikt om een watermerk toe te passen op alle diavoorstellingen — het watermerk wordt toegevoegd aan de Slide Master, daar volledig ontworpen, en toegepast op alle dia’s zonder de mogelijkheid om het watermerk op individuele dia’s te wijzigen.

Een watermerk wordt gewoonlijk beschouwd als niet bewerkbaar door andere gebruikers. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) wordt bewerkt, biedt Aspose.Slides vergrendelingsfunctionaliteit voor vormen. Een specifieke vorm kan worden vergrendeld op een gewone dia of op een Slide Master. Wanneer de watermerkvorm op de Slide Master wordt vergrendeld, is deze vergrendeld op alle diavoorstellingen.

Je kunt een naam aan het watermerk geven zodat je het later, wanneer je het wilt verwijderen, kunt vinden in de vormen van de dia op naam.

Je kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter meestal gemeenschappelijke eigenschappen in watermerken, zoals centreren, rotatie, voorste positie, enz. We zullen bekijken hoe je deze in de onderstaande voorbeelden kunt toepassen.

## **Tekstwatermerk**

### **Een tekstwatermerk toevoegen aan een dia**

Om een tekstwatermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen en vervolgens een tekstframe aan die vorm. Het tekstframe wordt weergegeven door de [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe) interface. Dit type is niet afgeleid van [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/), die een breed scala aan eigenschappen biedt voor het flexibel positioneren van het watermerk. Daarom wordt het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe) object gewikkeld in een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) object. Om watermerktekst aan de vorm toe te voegen, gebruik je de [AddTextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/methods/addtextframe) methode zoals hieronder weergegeven.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Voeg het watermerk toe aan de dia.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de TextFrame‑klasse gebruiken?](/slides/nl/net/text-formatting/)
{{% /alert %}}

### **Een tekstwatermerk toevoegen aan een presentatie**

Als je een tekstwatermerk wilt toevoegen aan de volledige presentatie (dwz alle dia’s tegelijk), voeg je het toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/masterslide/). De rest van de logica is dezelfde als bij het toevoegen van een watermerk aan een enkele dia — maak een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) object en voeg vervolgens het watermerk toe met behulp van de [AddTextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/methods/addtextframe) methode.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Voeg het watermerk toe aan de masterdia.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Zie ook" %}} 
- [Hoe de Slide Master gebruiken?](/slides/nl/net/slide-master/)
{{% /alert %}}

### **Transparantie van de watermerkvorm instellen**

Standaard is de rechthoekige vorm opgemaakt met vullings‑ en lijnkleuren. Dit betekent dat wanneer het watermerk wordt toegevoegd, het mogelijk een effen achtergrond of rand heeft die afleidend kan zijn van de inhoud van de dia. Om ervoor te zorgen dat het watermerk subtiel blijft en niet interfereert met het visuele ontwerp van de presentatie, kun je de vorm volledig transparant maken.

De volgende codefragmenten maken de vorm transparant door zowel de vulling als de randkleur te verwijderen:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Lettertype voor een tekstwatermerk instellen**

Voordat je het tekstwatermerk op je dia toepast, is het belangrijk om het uiterlijk aan te passen zodat het harmonieert met het algehele ontwerp. Je kunt het lettertype en de grootte wijzigen om ervoor te zorgen dat het watermerk zowel leesbaar als esthetisch aantrekkelijk is. Het aanpassen van het lettertype kan ook helpen de merkidentiteit te versterken of simpelweg bij de stijl van de presentatie te passen.

Het onderstaande codefragment toont hoe je de lettertype‑instellingen van het watermerk aanpast door een specifiek Latijns lettertype te selecteren en een geschikte letterhoogte in te stellen:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Kleur van de watermerktekst instellen**

Voordat je je watermerk toepast, is het essentieel om de tekstkleur passend in te stellen zodat deze goed samengaat met de inhoud van je dia zonder deze te overweldigen. Het aanpassen van de kleurtransparantie (alfa) samen met de rode, groene en blauwe componenten stelt je in staat een subtiel, halfdoorzichtig watermerk te creëren dat zichtbaar maar niet storend is. Deze aanpak helpt de focus op je hoofdpresentatie te behouden terwijl je inhoud toch beschermd blijft.

Om de kleur van de watermerktekst in te stellen, gebruik je de volgende code:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Een tekstwatermerk centreren**

Het correct centreren van je tekstwatermerk kan de algehele esthetiek van je presentatie sterk verbeteren door ervoor te zorgen dat het watermerk symmetrisch gepositioneerd is, ongeacht de afmetingen van de dia. Deze aanpak geeft je dia’s een professionele uitstraling en zorgt ervoor dat het watermerk niet interfereert met de hoofdinhoud van de dia.

Het onderstaande codefragment toont hoe je de centrummpositie van een dia berekent en het tekstwatermerk daar plaatselijk invoegt:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

De onderstaande afbeelding toont het eindresultaat.

![Het tekstwatermerk](text_watermark.png)

## **Afbeeldingswatermerk**

### **Een afbeeldingswatermerk toevoegen aan een presentatie**

In veel gevallen kan een afbeeldingswatermerk een uniek branding‑element bieden of een visueel aantrekkelijker alternatief voor een tekstwatermerk. Zorg ervoor dat het afbeeldingsbestand beschikbaar is (bijv. PNG voor transparantie) voordat je het watermerk toevoegt. Het volgende voorbeeld laat zien hoe je een afbeelding laadt vanuit je bestandssysteem, deze toevoegt aan de presentatie, en vervolgens toepast als watermerk via de vul‑eigenschappen van de vorm.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Een watermerk vergrendelen tegen bewerking**

Als het nodig is om te voorkomen dat een watermerk bewerkt wordt, gebruik dan de eigenschap [IAutoShape.ShapeLock](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/properties/shapelock) op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selecteren, schalen, verplaatsen, groeperen met andere elementen, de tekst vergrendelen tegen bewerking, en nog veel meer:

```cs
// Vergrendel de watermerkvorm tegen bewerken.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Watermerk naar voorgrond brengen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de methode [IShapeCollection.Reorder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/reorder/#reorder). Hiervoor moet je deze methode aanroepen vanuit de lijst met presentatiedia's en de vormreferentie en volgnummer doorgeven aan de methode. Op deze manier kun je een vorm naar de voorgrond brengen of naar de achtergrond sturen van de dia. Deze functie is vooral handig als je een watermerk voor de presentatie wilt plaatsen:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Watermerkrotatie instellen**

Het aanpassen van de rotatie van je watermerk kan de visuele impact en subtiliteit van je presentatie aanzienlijk vergroten. Een diagonaal watermerk kan bijvoorbeeld minder storend zijn terwijl het toch een robuuste bescherming biedt tegen ongeautoriseerd gebruik. Het volgende voorbeeld berekent de juiste hoek op basis van de afmetingen van de dia zodat het watermerk diagonaal over de dia wordt gepositioneerd. Deze dynamische berekening zorgt ervoor dat het watermerk effectief blijft ongeacht verschillende dia‑groottes.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Een naam toekennen aan een watermerk**

Aspose.Slides stelt je in staat de naam van een vorm in te stellen. Door de vormnaam te gebruiken, kun je later de vorm benaderen om deze te wijzigen of te verwijderen. Om de naam van de watermerkvorm in te stellen, wijs je deze toe aan de eigenschap [IAutoShape.Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "watermark";
```

## **Een watermerk verwijderen**

Om de watermerkvorm te verwijderen, gebruik je de eigenschap [IAutoShape.Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/properties/name) om deze in de dia‑vormen te vinden. Vervolgens geef je de watermerkvorm door aan de methode [IShapeCollection.Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/remove/):

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Een live‑voorbeeld**

Je kunt de **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/nl/watermark) en [Remove Watermark](https://products.aspose.app/slides/nl/watermark/remove-watermark) online tools bekijken.

![Online‑tools om watermerken toe te voegen en te verwijderen](online_tools.png)

## **Veelgestelde vragen**

**Wat is een watermerk en waarom zou ik het gebruiken?**

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia’s wordt toegepast en helpt intellectueel eigendom te beschermen, merkherkenning te verbeteren, of ongeautoriseerd gebruik van presentaties te voorkomen.

**Kan ik een watermerk toevoegen aan alle dia’s in een presentatie?**

Ja, Aspose.Slides maakt het mogelijk om programmatically een watermerk toe te voegen aan elke dia in een presentatie. Je kunt door alle dia’s itereren en de watermerkinstellingen individueel toepassen.

**Hoe kan ik de transparantie van het watermerk aanpassen?**

Je kunt de transparantie van het watermerk aanpassen door de vulinstellingen ([FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/fillformat/)) van de vorm te wijzigen. Dit zorgt ervoor dat het watermerk subtiel is en niet afleidt van de dia‑inhoud.

**Welke afbeeldingsformaten worden ondersteund voor watermerken?**

Aspose.Slides ondersteunt verschillende afbeeldingsformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

**Kan ik het lettertype en de stijl van een tekstwatermerk aanpassen?**

Ja, je kunt elk lettertype, grootte en stijl kiezen om aan te sluiten bij het ontwerp van je presentatie en de merkconsistentie te behouden.

**Hoe wijzig ik de positie of oriëntatie van een watermerk?**

Je kunt de positie en oriëntatie van het watermerk programmatically aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de vorm te wijzigen.