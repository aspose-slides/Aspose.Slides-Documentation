---
title: Beheer presentatie‑placeholders in Java
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/java/manage-placeholder/
keywords:
- placeholder
- tekst‑placeholder
- afbeelding‑placeholder
- grafiek‑placeholder
- content‑placeholder
- prompt‑tekst
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u tekst‑, afbeelding‑, grafiek‑ en content‑placeholders kunt inspecteren en bewerken en hoe placeholder‑overerving werkt met Aspose.Slides voor Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel-, hoofdtekst-, afbeelding-, grafiek- en algemene content‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een layout‑slide of master‑slide.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑methode. Deze methode retourneert een [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/)‑object of `null` voor een normale vorm. Gebruik [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) om te bepalen wat de placeholder moet bevatten.

De vorm‑interface blijft relevant nadat u het placeholder‑type kent:

- Een lege tekst‑, afbeelding-, grafiek‑ of content‑placeholder wordt meestal weergegeven door een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
- Een ingevulde afbeelding‑placeholder kan worden weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/).
- Een ingevulde grafiek‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/).
- Een content‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) als de runtime‑vorm‑interface in plaats van aan te nemen dat elke placeholder een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) is.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat u toegang krijgt tot tekst-, afbeelding-, grafiek-, tabel- of mediagerichte leden.
{{% /alert %}}

## **Begrijp placeholder‑overerving**

Placeholders vormen een hiërarchie:

1. Een master‑slide definieert herbruikbare stijlen en, in sommige gevallen, placeholders op master‑niveau.
2. Een layout‑slide bepaalt de opmaak die wordt gebruikt door een of meer normale slides en kan erven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan erven van de bijbehorende layout.

Roep [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) aan om één niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder retourneert normaal gesproken zijn layout‑placeholder; een layout‑placeholder kan zijn master‑placeholder retourneren. De methode retourneert `null` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft een lijst van placeholders op de eerste slide weer en meldt hun basis‑placeholders:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Een placeholder bewerken op een normale slide maakt een lokale overschrijving voor die slide aan of wijzigt deze. Het bewerken van de bijbehorende layout of master kan alle slides beïnvloeden die die instelling nog erven. Een lokale gewone vorm heeft geen basis‑placeholder en begint niet met erven alleen omdat het dezelfde coördinaten inneemt.

## **Verwijder placeholder‑status**

Wanneer u een sjabloon aanpast, gebruikt u [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) om een bestaand object als een gewone vorm te behouden. De [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--)‑methode retourneert `null`, maar de vorm blijft in de slide‑collectie. In tegenstelling tot [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) verwijdert dit de vorm uit die collectie.

Het volgende voorbeeld vereist `template.pptx` met ten minste één slide en een niet‑lege tekst‑placeholder op de eerste slide. Gebruik een placeholder met opmaak geërfd van zijn layout of master om het effect van het verwijderen van die relatie te zien. Het voorbeeld controleert dat dezelfde vorm blijft, roept de methode opnieuw aan op de nu gewone vorm, en slaat het resultaat op.

{{% alert color="warning" title="Warning" %}}
Het verwijderen van placeholder‑status behoudt niet automatisch de geërfde weergave‑instellingen. Het onderstaande voorbeeld laat die instellingen opzettelijk onveranderd, waardoor de output er anders uit kan zien. Een vorm waarvan positie en grootte volledig zijn geërfd kan na de oproep nul‑coördinaten en afmetingen hebben en onzichtbaar worden, hoewel deze nog in de collectie aanwezig blijft.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || 
            textFrame == null || 
            textFrame.getText() == null || 
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Methode aanroepen op een gewone vorm heeft geen effect.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Voor een overeenkomstige placeholder geven alle drie controles `true` weer. De tekst blijft behouden, maar geërfde positie, grootte, rotatie, lettertype, alineauslijning, tekst‑frame‑marges, verticale verankering, vul‑ en lijneigenschappen kunnen wijzigen wanneer de placeholder‑relatie wordt verwijderd. Bijvoorbeeld, geërfde titelopmaak kan terugvallen op gewone tekstopmaak. Zie [Slide Layout](/slides/nl/java/slide-layout/) voor meer over layouts.

Om de beoogde weergave te behouden, legt u de opgeloste positie, grootte en rotatie vast vóór de oproep, en kopieert u de vereiste effectieve opmaakwaarden naar afzonderlijke variabelen. Haal die waarden op via [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), en [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--). Vertrouw niet alleen op de effectieve‑formaatobjecten, want hun tekst‑opmaakwaarden kunnen veranderen nadat de relatie is verwijderd. Pas de vastgelegde waarden expliciet toe op de gewone vorm daarna, inclusief lettertypefamilie, grootte, stijl, kleur, alinea‑instellingen, tekst‑frame‑instellingen, vul‑ en lijneigenschappen die uw sjabloon gebruikt.

Geërfde vormgeometrie kan ook expliciet moeten worden toegewezen via [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-). Voor een rechthoekige tekst‑placeholder betekent dit het toewijzen van [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle); alleen de vul‑ en lijninstellingen herstellen, herstelt mogelijk niet de zichtbare rechthoek. Sjablonen met extra effecten of complexere opmaak vereisen dat die instellingen ook worden behandeld.

## **Tekst wijzigen in een placeholder**

Titel‑, gecentreerde‑titel‑, subtitel‑, body‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op een [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) voordat u de [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)‑methode gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste slide bij en slaat het resultaat op:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dit patroon voorkomt het casten van afbeelding‑, grafiek‑, tabel‑ of media‑placeholders naar [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Het identificeert de placeholder bovendien op doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompttekst instellen op een layout**

Prompttekst is de ontwerpinstructie die wordt weergegeven in een lege placeholder, zoals *Click to add title*. Stel aangepaste prompttekst in op de layout‑placeholder in plaats van deze te benaderen via de vormcollectie van een normale slide. Toegang tot de layout krijgt u via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) en u iterereert over de collectie die wordt teruggegeven door [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/).

Het volgende voorbeeld wijzigt de titel‑ en subtitel‑prompts op de layout die door de eerste slide wordt gebruikt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prompttekst is geen normale slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsapplicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet langer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op slides die de layout gebruiken.

## **Een afbeelding‑placeholder bijwerken**

Er zijn twee gevallen om te behandelen:

- Als de afbeelding‑placeholder al is ingevuld en wordt weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/), vervang dan de afbeelding via [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) en [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/).
- Als het nog een lege placeholder is, voeg dan een afbeelding‑frame toe op de coördinaten van de placeholder met [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) en verwijder de lege placeholder.

Het volgende voorbeeld ondersteunt beide gevallen en slaat de presentatie op:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De vervanging die voor een lege placeholder wordt gemaakt, is een lokaal afbeelding‑frame, geen nieuwe placeholder, omdat [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) geen setter biedt. Het behoudt de gereserveerde positie maar erft geen placeholder‑specifiek gedrag meer. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul de placeholder eerst in PowerPoint in en werk vervolgens het resulterende [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) bij met Aspose.Slides.

Voor afbeeldings‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/java/picture-frame/). Die bewerkingen behoren tot het afbeelding‑frame of de afbeelding‑vulling, niet tot placeholder‑metadata.

## **Werken met grafiek‑ en content‑placeholders**

Een ingevulde grafiek‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/). Dit voorbeeld vindt zo’n grafiek zowel op basis van placeholder‑type als runtime‑interface, wijzigt de titel en slaat het bestand op:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Een algemene content‑placeholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). In PowerPoint fungeert deze als lanceerder voor verschillende content‑types, waaronder grafieken, tabellen, diagrammen, afbeeldingen en media. Nadat deze is ingevuld, inspecteert u de werkelijke vorm‑interface om te ontdekken wat er zich in bevindt. Gespecialiseerde layouts kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), of [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides converteert een lege [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) placeholder niet naar een [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) alleen door [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) te wijzigen; het type kan niet via de interface worden veranderd. Om een lege grafiek‑ of content‑zone programmatisch te vullen, voeg het benodigde object toe op de coördinaten van de placeholder en verwijder vervolgens de lege placeholder. Het volgende voorbeeld doet dat voor een grafiek:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De toegevoegde grafiek is een gewone lokale grafiek. Ze beslaat het gebied van de placeholder maar erft niet van de layout‑placeholder. Gebruik de speciale [chart management articles](/slides/nl/java/powerpoint-charts/) wanneer u categorieën, series of werkboekgegevens moet vervangen.

## **Volledig voorbeeld: tekst of afbeelding‑inhoud bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt de eerste slide op naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vormtypes, werkt de juiste inhoud bij en slaat de uitvoer op. Het voorbeeld vermijdt opzettelijk het aannemen van een vorm‑index of het casten van elke placeholder naar dezelfde interface.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wat is een basis‑placeholder?**

Een basis‑placeholder is de overeenkomstige vorm op de layout of master waarvan een andere placeholder erft. Gebruik [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat ze geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle slide‑titels wijzigen door een layout‑placeholder te bewerken?**

U kunt geërfde opmaak of prompttekst via een layout wijzigen, maar de bestaande titelinhoud wordt opgeslagen op de normale slides. Om de daadwerkelijke titeltekst in een hele presentatie te vervangen, moet u over de slides itereren en elke titel‑placeholder bijwerken.

**Hoe beheer ik datum‑, slide‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste niveau van slide, layout, master, notities of handout. Zie [Beheer presentatie‑header en -footer](/slides/nl/java/presentation-header-and-footer/) voor volledige voorbeelden.