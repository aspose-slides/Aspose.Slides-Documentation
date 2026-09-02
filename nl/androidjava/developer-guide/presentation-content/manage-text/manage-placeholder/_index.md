---
title: Beheer presentatie-placeholders op Android
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/androidjava/manage-placeholder/
keywords:
- plaatsvervanger
- tekstplaatsvervanger
- afbeeldingsplaatsvervanger
- diagramplaatsvervanger
- inhoudsplaatsvervanger
- prompttekst
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe je tekst-, afbeelding-, diagram- en inhoudsplaceholders kunt inspecteren en bewerken, en hoe placeholder-erfenis werkt met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel, tekstvak, afbeelding, diagram en algemene inhouds-placeholder. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen overnemen van een layout-slide of master-slide.

Aspose.Slides maakt placeholder-informatie beschikbaar via de [IShape.getPlaceholder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) methode. De methode retourneert een [IPlaceholder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholder/) object of `null` voor een normale vorm. Gebruik [IPlaceholder.getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholder/) om te bepalen welke inhoud de placeholder moet bevatten.

De vorm-interface blijft relevant nadat je het placeholder-type kent:

- Een lege tekst-, afbeelding-, diagram- of inhouds-placeholder wordt doorgaans weergegeven door een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/).
- Een gevulde afbeelding-placeholder kan worden weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/).
- Een gevulde diagram-placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/).
- Een inhouds-placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [IPlaceholder.getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholder/) als de runtime-vorm-interface in plaats van aan te nemen dat elke placeholder een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) is.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholder/) beschrijft de rol van een placeholder; het garandeert niet het runtime-type van de vorm. Gebruik altijd een type-check voordat je toegang krijgt tot tekst-, afbeelding-, diagram-, tabel- of mediagerichte leden.
{{% /alert %}}

## **Begrijp placeholder-erfenis**

Placeholders vormen een hiërarchie:

1. Een master-slide definieert herbruikbare stijlen en, in sommige gevallen, master-niveau placeholders.
2. Een layout-slide bepaalt de indeling die door een of meer normale slides wordt gebruikt en kan overerven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan overerven van de layout.

Roep [IShape.getBasePlaceholder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) aan om één niveau hoger in deze hiërarchie te gaan. Een slide-placeholder retourneert doorgaans zijn layout-placeholder; een layout-placeholder kan zijn master-placeholder retourneren. De methode retourneert `null` wanneer de vorm geen basis-placeholder heeft.

Het volgende voorbeeld toont de placeholders op de eerste slide en rapporteert hun basis-placeholders:

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

Het bewerken van een placeholder op een normale slide creëert of wijzigt een lokale overschrijving voor die slide. Het bewerken van de bijbehorende layout of master kan alle slides beïnvloeden die die instelling nog overerven. Een lokale gewone vorm heeft geen basis-placeholder en begint niet met overerven alleen omdat hij dezelfde coördinaten bezet.

## **Tekst wijzigen in een placeholder**

Titel-, gecentreerde-titel-, ondertitel-, tekst- en inhouds-placeholders ondersteunen doorgaans tekst. Controleer op [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) voordat je de [getTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) methode gebruikt.

Dit voorbeeld werkt de eerste titel-placeholder op de eerste slide bij en slaat het resultaat op:

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

Dit patroon vermijdt het casten van afbeelding-, diagram-, tabel- of media-placeholders naar [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/). Het identificeert de placeholder ook op basis van het doel in plaats van te vertrouwen op een fragiele vorm-index.

## **Prompt-tekst instellen op een layout**

Prompt-tekst is de ontwerpinstructie die wordt weergegeven in een lege placeholder, bijvoorbeeld *Klik om een titel toe te voegen*. Stel aangepaste prompt-tekst in op de layout-placeholder in plaats van te proberen deze via de vorm-collectie van een normale slide te benaderen. Toegang tot de layout krijg je via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) en je kunt itereren over de collectie die wordt geretourneerd door [ILayoutSlide.getShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/).

Het volgende voorbeeld wijzigt de titel- en ondertitel-prompts op de layout die door de eerste slide wordt gebruikt:

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

Prompt-tekst is geen normale slide-inhoud. Het is bedoeld voor lege placeholders in bewerkingsapplicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud levert, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op slides die de layout gebruiken.

## **Een afbeelding-placeholder bijwerken**

Er zijn twee gevallen om af te handelen:

- Als de afbeelding-placeholder al is gevuld en wordt weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/), vervang je de afbeelding via [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/) en [ISlidesPicture.setImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidespicture/).
- Als het nog een lege placeholder is, voeg je een afbeelding-frame toe op de coördinaten van de placeholder met [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/) en verwijder je de lege placeholder.

Het volgende voorbeeld ondersteunt beide gevallen en slaat de presentatie op:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

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

De vervanging die voor een lege placeholder wordt gecreëerd is een lokaal afbeelding-frame, geen nieuwe placeholder, omdat [IShape.getPlaceholder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) geen setter biedt. Het behoudt de gereserveerde positie maar erft geen placeholder-specifiek gedrag meer. Als het behouden van de placeholder-relatie essentieel is, maak en vul de placeholder eerst in PowerPoint aan, en werk daarna het resulterende [IPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) bij met Aspose.Slides.

Voor transparantie, bijsnijden en andere afbeelding-specifieke effecten, zie [Manage Picture Frames](/slides/nl/androidjava/picture-frame/). Die bewerkingen behoren tot het afbeelding-frame of de afbeelding-vulling, niet tot de placeholder-metadata.

## **Werken met diagram- en inhouds-placeholders**

Een gevulde diagram-placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/). Dit voorbeeld vindt zo’n diagram zowel op basis van placeholder-type als runtime-interface, wijzigt de titel en slaat het bestand op:

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

Een algemene inhouds-placeholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholdertype/). In PowerPoint fungeert het als een lanceerder voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat het is gevuld, inspecteer je de daadwerkelijke vorm-interface om te ontdekken wat het bevat. Gespecialiseerde layouts kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholdertype/), of [PlaceholderType.Diagram](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides converteert geen lege [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) placeholder naar een [IChart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichart/) alleen door [IPlaceholder.getType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/placeholder/) te wijzigen; het type kan niet via de interface worden veranderd. Om een leeg diagram- of inhoudsgebied programmatically te vullen, voeg je het benodigde object toe op de coördinaten van de placeholder en verwijder je vervolgens de lege placeholder. Het volgende voorbeeld doet dit voor een diagram:

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

Het toegevoegde diagram is een gewone lokale diagram. Het neemt het gebied van de placeholder in, maar erft niet van de layout-placeholder. Gebruik de speciale [chart management articles](/slides/nl/androidjava/powerpoint-charts/) wanneer je de categorieën, series of werkboek-gegevens moet vervangen.

## **Volledig voorbeeld: tekst of afbeelding-inhoud bijwerken**

Het volgende end-to-end voorbeeld opent een sjabloon, zoekt de eerste slide naar een titel- of afbeelding-placeholder, controleert de placeholder- en vormtypen, werkt de juiste inhoud bij en slaat de uitvoer op. Het voorbeeld vermijdt bewust het aannemen van een vorm-index of het casten van elke placeholder naar dezelfde interface.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

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

**Wat is een basis-placeholder?**

Een basis-placeholder is de overeenkomstige vorm op de layout of master waaruit een andere placeholder erft. Gebruik [IShape.getBasePlaceholder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat deze geen deel uitmaakt van de placeholder-hiërarchie.

**Kan ik alle slide-titels wijzigen door een layout-placeholder te bewerken?**

Je kunt geërfde opmaak of prompt-tekst via een layout wijzigen, maar bestaande titel-inhoud wordt opgeslagen op de normale slides. Om de daadwerkelijke titeltekst in een hele presentatie te vervangen, itereren over de slides en elke titel-placeholder bijwerken.

**Hoe beheer ik datum-, slide-nummer-, header- en footer-placeholders?**

Gebruik de header- en footer-managers op de juiste slide, layout, master, notities of handout-niveau. Zie [Manage Presentation Header and Footer](/slides/nl/androidjava/presentation-header-and-footer/) voor volledige voorbeelden.