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
- diagram‑placeholder
- inhouds‑placeholder
- prompt‑tekst
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u tekst‑, afbeelding‑, diagram‑ en inhouds‑placeholders kunt inspecteren en bewerken en hoe placeholder‑erfenis werkt met Aspose.Slides voor Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel, tekstvak, afbeelding, diagram en algemene inhouds‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een lay‑slide of master‑slide.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [IShape.getPlaceholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/)‑methode. De methode retourneert een [IPlaceholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholder/)‑object of `null` voor een normale vorm. Gebruik [IPlaceholder.getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholder/) om te bepalen welke inhoud de placeholder hoort te bevatten.

De vorm‑interface blijft belangrijk nadat je het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, diagram‑ of inhouds‑placeholder wordt meestal weergegeven door een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/).
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/).
- Een gevulde diagram‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/).
- Een inhouds‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [IPlaceholder.getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholder/) als de runtime‑vorm‑interface in plaats van aan te nemen dat elke placeholder een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) is.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholder/) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat je tekst-, afbeelding‑, diagram‑, tabel‑ of media‑specifieke leden benadert.
{{% /alert %}}

## **Placeholder‑erfenis Begrijpen**

Placeholders vormen een hiërarchie:

1. Een master‑slide definieert herbruikbare stijlen en, in sommige gevallen, master‑level placeholders.
2. Een lay‑slide definieert de opmaak die door één of meer normale slides wordt gebruikt en kan erven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan erven van zijn lay‑slide.

Roep [IShape.getBasePlaceholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) aan om één niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder geeft normaal gesproken zijn lay‑placeholder terug; een lay‑placeholder kan zijn master‑placeholder retourneren. De methode retourneert `null` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld somt de placeholders op van de eerste slide en meldt hun basis‑placeholders:

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

Een placeholder op een normale slide bewerken creëert of wijzigt een lokale overschrijving voor die slide. Het bewerken van de bijbehorende lay‑ of master‑slide kan alle slides beïnvloeden die die instelling nog erven. Een lokale gewone vorm heeft geen basis‑placeholder en begint niet te erven enkel omdat hij dezelfde coördinaten inneemt.

## **Tekst Wijzigen in een Placeholder**

Titel‑, gecentreerde‑titel‑, ondertitel‑, tekst‑ en inhouds‑placeholders ondersteunen normaal gesproken tekst. Controleer op een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) voordat je zijn [getTextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/)‑methode gebruikt.

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

Dit patroon voorkomt casten van afbeelding‑, diagram‑, tabel‑ of media‑placeholders naar een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/). Het identificeert de placeholder bovendien op basis van doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompt‑tekst Instellen op een Lay‑Slide**

Prompt‑tekst is de ontwerp‑tijd aanwijzing die wordt weergegeven in een lege placeholder, bijvoorbeeld *Klik om titel toe te voegen*. Stel aangepaste prompt‑tekst in op de lay‑placeholder in plaats van deze via de vormcollectie van een normale slide te benaderen. Benader de lay‑slide via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/) en doorloop de collectie die wordt geretourneerd door [ILayoutSlide.getShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de lay‑slide die door de eerste slide wordt gebruikt:

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

Prompt‑tekst is geen inhoud van een normale slide. Het is bedoeld voor lege placeholders in bewerkingsprogramma’s zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt bovendien geen bestaande tekst op slides die de lay‑slide gebruiken.

## **Een Afbeeldings‑Placeholder Bijwerken**

Er zijn twee gevallen die moeten worden afgehandeld:

- Als de afbeelding‑placeholder al is gevuld en wordt weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/), vervang de afbeelding via [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/) en [ISlidesPicture.setImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidespicture/).
- Als het nog een lege placeholder is, voeg een afbeelding‑frame toe op de coördinaten van de placeholder met [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/) en verwijder de lege placeholder.

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

De vervanging die voor een lege placeholder wordt aangemaakt, is een lokaal afbeelding‑frame, geen nieuwe placeholder, omdat [IShape.getPlaceholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) geen setter biedt. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, maak en vul de placeholder eerst in PowerPoint, waarna je het resulterende [IPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/) bijwerkt met Aspose.Slides.

Voor beeld‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/java/picture-frame/). Die bewerkingen behoren tot het afbeelding‑frame of de afbeelding‑vulling, niet tot placeholder‑metadata.

## **Werken met Diagram‑ en Inhouds‑Placeholders**

Een gevulde diagram‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/). Dit voorbeeld zoekt zo’n diagram op zowel basis van placeholder‑type als runtime‑interface, wijzigt de titel en slaat het bestand op:

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

Een algemene inhouds‑placeholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholdertype/). In PowerPoint fungeert deze als lanceerknop voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat hij is gevuld, moet je de feitelijke vorm‑interface inspecteren om te weten wat hij bevat. Gespecialiseerde lay‑slides kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholdertype/), of [PlaceholderType.Diagram](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides converteert een lege [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) placeholder niet naar een [IChart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichart/) door simpelweg [IPlaceholder.getType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/placeholder/) te wijzigen; het type kan niet via de interface worden aangepast. Om een lege diagram‑ of inhouds‑area programmatisch te vullen, voeg je het benodigde object toe op de coördinaten van de placeholder en verwijder je daarna de lege placeholder. Het volgende voorbeeld doet dit voor een diagram:

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

Het toegevoegde diagram is een gewone lokale diagram. Het vult het gebied van de placeholder, maar erft niet van de lay‑placeholder. Gebruik de specifieke [chart management articles](/slides/nl/java/powerpoint-charts/) wanneer je de categorieën, reeksen of werkboek‑data moet vervangen.

## **Compleet Voorbeeld: Tekst of Afbeeldingsinhoud Bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt in de eerste slide naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑types, werkt de juiste inhoud bij en slaat de output op. Het voorbeeld vermijdt bewust aannames over vorm‑indexen of het casten van elke placeholder naar dezelfde interface.

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

Een basis‑placeholder is de overeenkomstige vorm op de lay‑ of master‑slide waarvan een andere placeholder erft. Gebruik [IShape.getBasePlaceholder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat hij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle slide‑titels wijzigen door een lay‑placeholder te bewerken?**

Je kunt geërfde opmaak of prompt‑tekst wijzigen via een lay‑slide, maar bestaande titelinhoud wordt opgeslagen op de normale slides. Om de feitelijke titeltekst in een gehele presentatie te vervangen, moet je over de slides itereren en elke titel‑placeholder bijwerken.

**Hoe beheer ik datum‑, slide‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste niveau: slide, lay‑slide, master, notities of handout. Zie [Manage Presentation Header and Footer](/slides/nl/java/presentation-header-and-footer/) voor volledige voorbeelden.