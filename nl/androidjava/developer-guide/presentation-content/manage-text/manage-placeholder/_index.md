---
title: "Placeholders in presentaties beheren op Android"
linktitle: "Placeholders beheren"
type: docs
weight: 10
url: /nl/androidjava/manage-placeholder/
keywords:
- placeholder
- tekst‑placeholder
- afbeeldings‑placeholder
- diagram‑placeholder
- inhouds‑placeholder
- prompttekst
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u tekst‑, afbeelding‑, diagram‑ en inhouds‑placeholders kunt inspecteren en bewerken en hoe placeholder‑overerving werkt met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel-, body-, afbeelding-, diagram‑ en algemene inhoudsplaceholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een layoutslide of masterslide.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) methode. De methode retourneert een [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) object of `null` voor een normale vorm. Gebruik [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) om te bepalen wat de placeholder moet bevatten.

De vorm‑interface blijft relevant nadat je het type van de placeholder kent:

- Een lege tekst-, afbeelding-, diagram‑ of inhoudsplaceholder wordt doorgaans weergegeven door een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- Een ingevulde afbeelding‑placeholder kan worden weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- Een ingevulde diagram‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- Een inhoudsplaceholder kan verschillende soorten inhoud bevatten. Controleer zowel [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) als de runtime‑vorm‑interface in plaats van aan te nemen dat elke placeholder een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) is.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat je tekst, afbeelding, diagram, tabel of mediaspecifieke leden benadert.
{{% /alert %}}

## **Begrijp Placeholder‑Overerving**

Placeholders vormen een hiërarchie:

1. Een masterslide definieert herbruikbare stijlen en, in sommige gevallen, masterslide‑placeholders.
2. Een layoutslide definieert de indeling die door één of meer normale slides wordt gebruikt en kan erven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan erven van zijn layout.

Roep [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) aan om één niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder retourneert normaal gesproken zijn layout‑placeholder; een layout‑placeholder kan zijn master‑placeholder retourneren. De methode geeft `null` terug wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld somt de placeholders op de eerste slide op en meldt hun basis‑placeholders:

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

Een placeholder bewerken op een normale slide maakt of wijzigt een lokale override voor die slide. Het bewerken van de gerelateerde layout of master kan alle slides beïnvloeden die die instelling nog erven. Een lokale gewone vorm heeft geen basis‑placeholder en begint niet te erven alleen omdat hij dezelfde coördinaten innemt.

## **Placeholderstatus Verwijderen**

Wanneer je een sjabloon aanpast, gebruik je [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) om een bestaand object als een gewone vorm te behouden. Zijn [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) methode retourneert `null`, maar de vorm blijft in de collectie van de slide. Daarentegen verwijdert [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) de vorm uit die collectie.

Het volgende voorbeeld vereist `template.pptx` met minstens één slide en een niet‑lege tekst‑placeholder op de eerste slide. Gebruik een placeholder met opmaak die is geërfd van zijn layout of master om het effect van het verwijderen van die relatie te zien. Het voorbeeld controleert dat dezelfde vorm blijft, roept de methode opnieuw aan op de nu gewone vorm, en slaat het resultaat op.

{{% alert color="warning" title="Warning" %}}
Het verwijderen van de placeholderstatus behoudt niet automatisch geërfde weergave‑instellingen. Het voorbeeld hieronder laat die instellingen bewust ongewijzigd, waardoor de uitvoer er anders uit kan zien. Een vorm waarvan positie en grootte volledig geërfd zijn, kan na de aanroep nulcoördinaten en -afmetingen hebben en onzichtbaar worden, zelfs als deze in de collectie blijft.
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

        // Het aanroepen van de methode op een gewone vorm heeft geen effect.
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

Voor een overeenkomende placeholder geven alle drie controles `true` weer. De tekst blijft behouden, maar geërfde positie, grootte, rotatie, lettertype, alinea‑uitlijning, marges van het tekst‑frame, verticale verankering, opvulling en lijneigenschappen kunnen wijzigen wanneer de placeholder‑relatie wordt verwijderd. Bijvoorbeeld, geërfde titel‑opmaak kan terugvallen op gewone tekst‑opmaak. Zie [Slide Layout](/slides/nl/androidjava/slide-layout/) voor meer informatie over layouts.

Om de beoogde weergave te behouden, leg je de berekende positie, grootte en rotatie vast vóór de aanroep, en kopieer je de benodigde effectieve opmaakwaarden naar afzonderlijke variabelen. Haal die waarden op via [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), en [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). Vertrouw niet alleen op de effectieve‑format‑objecten, want hun tekst‑opmaakwaarden kunnen wijzigen nadat de relatie is verwijderd. Pas de vastgelegde waarden expliciet toe op de gewone vorm daarna, inclusief lettertypefamilie, -grootte, -stijl, -kleur, alinea‑instellingen, tekst‑frame‑instellingen, opvulling en lijn die door je sjabloon worden gebruikt.

Geïntegreerde vorm‑geometrie moet mogelijk ook expliciet worden toegewezen via [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). Voor een rechthoekige tekst‑placeholder betekent dit het toewijzen van [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle); alleen de opvulling en lijn herstellen, herstelt mogelijk niet het zichtbare rechthoekige frame. Sjablonen met extra effecten of complexere opmaak vereisen dat deze instellingen ook worden afgehandeld.

## **Tekst Wijzigen in een Placeholder**

Titel‑, gecentreerde‑titel‑, ondertitel‑, body‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) voordat je de [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) methode gebruikt.

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

Dit patroon voorkomt het casten van afbeelding‑, diagram‑, tabel‑ of media‑placeholders naar een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Het identificeert de placeholder ook op basis van doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompttekst Instellen op een Layout**

Prompttekst is de ontwerptijd‑instructie die wordt weergegeven in een lege placeholder, bijvoorbeeld *Click to add title*. Stel aangepaste prompttekst in op de layout‑placeholder in plaats van te proberen deze via de vorm‑collectie van een normale slide te bereiken. Benader de layout via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) en loop door de collectie die wordt geretourneerd door [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de layout die door de eerste slide wordt gebruikt:

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

Prompttekst is geen normale slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsprogramma’s zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt bovendien niet de bestaande tekst op slides die de layout gebruiken.

## **Een Afbeeldingsplaceholder Bijwerken**

Er zijn twee situaties om af te handelen:

- Als de afbeeldingsplaceholder al gevuld is en wordt weergegeven door een [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), vervang je de afbeelding via [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) en [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Als het nog een lege placeholder is, voeg je een afbeelding‑frame toe op de coördinaten van de placeholder met [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) en verwijder je de lege placeholder.

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

De vervanging die voor een lege placeholder wordt aangemaakt, is een lokaal afbeelding‑frame, geen nieuwe placeholder, omdat [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) geen setter biedt. Het behoudt de gereserveerde positie, maar erft geen placeholder‑specifiek gedrag meer. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul de placeholder eerst in PowerPoint, en werk daarna het resulterende [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) bij met Aspose.Slides.

Voor afbeeldings‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/androidjava/picture-frame/). Die bewerkingen behoren tot het afbeelding‑frame of de afbeelding‑opvulling, niet tot placeholder‑metadata.

## **Werken met Diagram‑ en Inhoudsplaceholders**

Een ingevulde diagram‑placeholder kan worden weergegeven door een [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). Dit voorbeeld zoekt zo’n diagram op zowel op placeholder‑type als runtime‑interface, wijzigt de titel, en slaat het bestand op:

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

Een algemene inhoudsplaceholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). In PowerPoint fungeert hij als lanceerpunt voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat hij is gevuld, inspecteer je de werkelijke vorm‑interface om te achterhalen wat hij bevat. Gespecialiseerde layouts kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), of [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) blootleggen.

Aspose.Slides converteert een lege [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) placeholder niet naar een [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) alleen door het wijzigen van [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); het type kan niet via de interface worden gewijzigd. Om een leeg diagram of inhoudsgebied programmatisch te vullen, voeg je het benodigde object toe op de coördinaten van de placeholder en verwijder je vervolgens de lege placeholder. Het volgende voorbeeld doet dat voor een diagram:

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

Het toegevoegde diagram is een gewone lokale diagram. Het beslaat het gebied van de placeholder maar erft niet van de layout‑placeholder. Gebruik de speciale [chart management articles](/slides/nl/androidjava/powerpoint-charts/) wanneer je categorieën, series of werkboek‑gegevens moet vervangen.

## **Volledig Voorbeeld: Tekst of Afbeeldingsinhoud Bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt de eerste slide op naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑types, werkt de juiste inhoud bij, en slaat de output op. Het voorbeeld vermijdt bewust aannames over een vorm‑index of het casten van elke placeholder naar dezelfde interface.

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

## **Veelgestelde vragen**

**Wat is een basisplaceholder?**

Een basisplaceholder is de overeenkomstige vorm op de layout of master waarvan een andere placeholder erft. Gebruik [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat ze geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle dia‑titels wijzigen door een layout‑placeholder te bewerken?**

Je kunt geërfde opmaak of prompttekst wijzigen via een layout, maar bestaande titelinhoud wordt opgeslagen op de normale slides. Om de daadwerkelijke titeltekst in een hele presentatie te vervangen, loop je over de slides en werk je elke titel‑placeholder bij.

**Hoe beheer ik datum‑, dia‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footermanagers op het juiste niveau: slide, layout, master, notities of handout. Zie [Manage Presentation Header and Footer](/slides/nl/androidjava/presentation-header-and-footer/) voor volledige voorbeelden.