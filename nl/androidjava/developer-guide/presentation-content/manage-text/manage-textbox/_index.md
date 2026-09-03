---
title: Beheer tekstvakken in presentaties op Android
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/androidjava/manage-textbox/
keywords:
- tekstvak
- tekstkader
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak, identificeer, formatteer en werk tekstvakken bij in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java."
---
## **Introductie**

In Aspose.Slides for Android via Java wordt de tekst van dia's opgeslagen in tekstkaders die behoren tot vormen. De [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) interface vertegenwoordigt de meest voorkomende tekstdragende vorm en stelt de tekst beschikbaar via de [IAutoShape.getTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) methode.

{{% alert color="info" title="Note" %}}
Elke auto‑vorm implementeert [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/), maar niet elke vorm is een auto‑vorm of ondersteunt een tekstkader. Bij het verwerken van een bestaande presentatie, controleer of een vorm [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) implementeert voordat u toegang krijgt tot de tekst.
{{% /alert %}}

## **Maak een tekstvak op een dia**

Om een tekstvak te maken, voegt u een auto‑vorm toe aan een dia, voegt u tekst toe aan het tekstkader en slaat u de presentatie op. Het volgende voorbeeld maakt een rechthoekig tekstvak:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De coördinaten en afmetingen die worden doorgegeven aan [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) worden gemeten in punten. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) initialiseert het tekstkader met de opgegeven tekst.

## **Controleren op een tekstvakvorm**

Gebruik de [IAutoShape.isTextBox](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#isTextBox--) methode om te bepalen of een auto‑vorm wordt beschouwd als een tekstvak. Dit is handig wanneer een presentatie zowel tekstdragende als louter grafische auto‑vormen bevat.

![Een tekstvak en een vorm](istextbox.png)

Het volgende voorbeeld inspecteert elke auto‑vorm in een presentatie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Een nieuw toegevoegde auto‑vorm wordt pas als tekstvak beschouwd zodra ze niet‑lege tekst bevat. U kunt die tekst leveren via [IAutoShape.addTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) of [ITextFrame.setText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-). Het toevoegen of toewijzen van een lege string laat [IAutoShape.isTextBox](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/#isTextBox--) `false` retourneren:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

De eerste twee aanroepen geven `true` weer; de laatste twee geven `false` weer.

## **Zoek de vorm die een tekstkader bezit**

Generieke tekstverwerkingscode kan een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) ontvangen zonder te weten welk presentatie‑object het bevat. Gebruik de alleen‑lezen [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentShape--) methode om terug te navigeren naar de eigenaar‑[IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/).

Voor een tekstkader dat eigendom is van een auto‑vorm of een andere tekstdragende vorm, retourneert [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentShape--) de eigenaar en retourneert [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null`. Controleer de geretourneerde waarde voordat u deze benadert. Zie [Search and Replace Text](/slides/nl/androidjava/search-and-replace-text/) voor het identificeren van zowel vorm‑ als tabelcel‑eigenaren, inclusief vormen die verbonden zijn met SmartArt‑knooppunten.

## **Kolommen toevoegen aan een tekstvak**

De [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) methode verdeelt het tekstkader in kolommen, terwijl [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) de tussen‑kolomafstand in punten instelt. Beide instellingen behoren tot [ITextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/) en kunnen worden aangepast via het tekstkader van een bestaand tekstvak. Tekst stroomt opnieuw tussen kolommen binnen dezelfde vorm; ze gaat niet door naar een andere vorm.

Het volgende voorbeeld maakt een tekstvak met drie kolommen en 10 punten tussen de kolommen, slaat de presentatie op en leest de opgeslagen instellingen terug uit het uitvoerbestand:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Tekst uit afzonderlijke kolommen extraheren**

Gebruik [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) om de tekst op te halen die aan elke visuele kolom in een bestaand tekstkader is toegewezen. De methode retourneert één string per kolom, in kolom‑gebaseerde leesvolgorde. Een tekstkader met één kolom levert een array met één element op, en een lege kolom wordt weergegeven door een lege string. De strings bevatten alleen platte tekst; opgedeelde opmaak op niveau van tekstgedeelte wordt niet behouden.

Dit is nuttig wanneer u moet:

- Tekst extraheren terwijl de kolomgebaseerde leesvolgorde behouden blijft.
- De inhoud van dia's met meerdere kolommen indexeren of vergelijken.
- Elke kolom exporteren naar een apart bestand, databaseveld of andere bestemming.
- Controleren hoe de tekst wordt herverdeeld na het wijzigen van het aantal kolommen met [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), de afstand met [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), het lettertype of de grootte van het tekstkader.

De methode rapporteert de tekst die binnen het huidige [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) is verdeeld; hij vloeit niet automatisch tekst tussen afzonderlijke vormen of tekstvakken. Kolomverdeling kan afhangen van beschikbare lettertypen en andere tekst‑layout‑instellingen, dus zorg ervoor dat de benodigde lettertypen beschikbaar zijn wanneer consistente resultaten belangrijk zijn.

Het volgende voorbeeld laadt een presentatie, vindt de eerste auto‑vorm met meerdere kolommen en een tekstkader, leest het geconfigureerde kolomaantal, en schrijft de tekst van elke kolom naar een apart bestand. Vormen die geen tekstkader bieden, worden overgeslagen.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tekst bijwerken**

Om tekst door de hele presentatie heen bij te werken, doorloopt u de dia's en vormen, selecteert u auto‑vormen en bewerkt vervolgens hun tekstgedeelten. Werken op gedeelte‑niveau stelt u in staat zowel de tekst als de teken‑opmaak te wijzigen.

Het volgende voorbeeld vervangt elke instantie van `years` door `months` in auto‑vormtekst en maakt elk getroffen gedeelte vet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze traversie werkt alleen tekst bij in auto‑vormen. Tekst die is opgeslagen in tabellen, grafieken, SmartArt of gegroepeerde vormen vereist een traversie van de collecties van die objecten.

## **Een tekstvak met een hyperlink toevoegen**

Een hyperlink kan aan een specifiek tekstgedeelte worden toegewezen, zodat alleen die tekst als klikbare link fungeert. Gebruik [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) om het gedeelte te koppelen aan een externe URL.

Het volgende voorbeeld maakt gelinkte tekst en slaat deze op in een presentatie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder op een hoofd‑ of layouts‑dia?**

Een [placeholder](/slides/nl/androidjava/manage-placeholder/) kan zijn positie en opmaak erven van een [master‑slide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterslide/) of [layout‑slide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslide/). Een regulier tekstvak is een onafhankelijke vorm op de dia waarin het is gemaakt en krijgt geen placeholder‑gedrag wanneer de layout wordt gewijzigd.

**Hoe kan ik tekst vervangen zonder de tekst in grafieken, tabellen of SmartArt te wijzigen?**

Beperk de traversie tot vormen die [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) implementeren, zoals getoond in het voorbeeld Tekst bijwerken. Grafieken, tabellen en SmartArt slaan tekst op in hun eigen objectmodellen, dus die worden niet aangepast door die lus.