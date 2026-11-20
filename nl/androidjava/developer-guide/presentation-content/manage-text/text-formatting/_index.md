---
title: Opmaak van presentatie-tekst op Android
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/androidjava/text-formatting/
keywords:
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype-eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit-eigenschap
- tekstframe-anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Formatteer en styleer tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe je tekst in PowerPoint‑ en OpenDocument‑presentaties kunt opmaken met Aspose.Slides voor Android via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑verankering, tab‑stops en taalin­stellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak en de eerste alinea bevat de hieronder getoonde tekst. Zowel dia‑ als vorm‑indexen beginnen bij nul. Voorbeelden die vette delen selecteren gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expresie‑overeenkomsten te vinden en te markeren, zie [Zoeken en Vervangen van tekst](/slides/nl/androidjava/search-and-replace-text/).

## **Tekstachtergrondkleur instellen**

Gebruik [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) voor individuele tekst‑porties.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele porties hebben voorrang op deze standaard:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de markeerkleur voor de gehele alinea in.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het onderstaande code‑voorbeeld toont hoe je de achtergrondkleur voor **tekst‑porties met een vet lettertype** instelt:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Stel de markeerkleur in voor de tekstportie.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De grijze tekstporties](gray_text_portions.png)

## **Tekst‑alinea’s uitlijnen**

Gebruik [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) om de alinea‑uitlijning binnen een tekstframe in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, uitgevuld, enz. zijn.

Het volgende code‑voorbeeld laat zien hoe je de alinea **centraalt**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de uitlijning van de alinea in op gecentreerd.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Lettertypen binnen een regel uitlijnen**

Gebruik [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) om tekst‑porties met verschillende lettergrootten verticaal uit te lijnen binnen een regel. Deze instelling geldt voor de gehele alinea en regelt de uitlijning binnen elke regel.

Het volgende zelf‑standige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst in 18, 36 en 54 punten, met een andere lettertype‑uitlijning. Het gebruikt Arial, schakelt autofit en omloop uit, en houdt de tekstframes groot genoeg voor één regel.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Vergelijking van Basislijn, Boven, Midden en Onder lettertype‑uitlijning met gemengde lettergroottes](font_alignment.png)

Lettertype‑uitlijning maakt gebruik van lettertype‑metriek, zodat de zichtbare randen van individuele letters niet per se precies op één lijn liggen. Het voorbeeld bevat zowel een hoofdletter als een afdalende letter om het verschil tussen basislijn‑ en onder‑uitlijning te tonen. Beschikbaarheid en substitutie van lettertypen, de gebruikte tekens en het verschil in lettergrootte beïnvloeden het resultaat. Frame‑afmetingen, marges, regelafstand, omloop en autofit hebben ook invloed op de lay‑out; gebruik dezelfde lettertypen en lay‑out‑instellingen bij het vergelijken van modi.

Deze instelling verschilt van [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), die horizontale alinea‑uitlijning regelt, en van [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), die het tekstblok verticaal binnen de vorm positioneert. Superscript‑ en subscript‑opmaak via [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) verschuift individuele porties ten opzichte van de basislijn in plaats van de lettertype‑uitlijning voor de regels van de alinea in te stellen.

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑onderdeel van de kleur die aan [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) is toegewezen. In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑waarde op de schaal 0–255, geen transparantie‑percentage.

Het volgende code‑voorbeeld toont hoe je transparantie op de **hele alinea** toepast:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de opvulkleur van de tekst in op een transparante kleur.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende code‑voorbeeld toont hoe je transparantie toepast op **tekst‑porties met een vet lettertype**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Stel de transparantie van de tekstportie in.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante tekstporties](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) om de afstand tussen tekens in een tekstvak te vergroten of te verkleinen. De voorbeelden voegen 3 punten afstand toe; negatieve waarden verkleinen de tekst.

De volgende Java‑code toont hoe je de tekenafstand in de **hele alinea** vergroot:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Opmerking: gebruik negatieve waarden om de tekenafstand te comprimeren.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het onderstaande code‑voorbeeld toont hoe je de tekenafstand vergroot in **tekst‑porties met een vet lettertype**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Opmerking: gebruik negatieve waarden om de tekenafstand te comprimeren.
            portion.getPortionFormat().setSpacing(3); // Vergroot de tekenafstand.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekenafstand in de tekstporties](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd iets strakker lijken dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de uitvoer dichter bij PowerPoint te krijgen, kun je kerning uitschakelen voor tekst‑porties die het betreffende lettertype gebruiken. Stel [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) in op een waarde die groter is dan de werkelijke lettergrootte. Dit voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve letternaampjes, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor porties die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende porties met een lettergrootte onder 100 punten:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor overeenkomende tekst onder de drempel voorkomt deze instelling kerning en kan helpen om de weergave van Aspose.Slides beter op te lijnen met de visuele uitvoer van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) of op individuele porties via [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op Times New Roman 12 punt met vet, cursief en punt‑onderstrepen. Expliciete opmaak op individuele porties heeft voorrang op deze standaarden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de lettertype‑eigenschappen voor de alinea in.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past Times New Roman 13 punt, cursieve opmaak en een punt‑onderstrepen toe op porties waarvan de effectieve opmaak vet is:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Stel de lettertype‑eigenschappen in voor de tekstportie.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De lettertype‑eigenschappen voor tekstporties](font_properties_for_text_portions.png)

## **Normalisatie van teksthoogte regelen**

Gebruik [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) bij het reproduceren van sjabloon‑typografie of het onderzoeken van verschillen in tekenhoogte. In PowerPoint strekt het inschakelen van normalisatie individuele tekens verticaal uit of comprimeert ze zodat ze een uniforme zichtbare hoogte binnen de tekst‑portie hebben. Het garandeert geen gelijke teksthoogtes tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool.True of False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) om normalisatie expliciet in of uit te schakelen. `NullableBool.NotDefined` laat de lokale instelling ongedefinieerd, zodat de portie de waarde erft, bijvoorbeeld van de alinea‑[getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--). Het betekent niet `False`. Gebruik [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) en lees [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) om de opgeloste Boolean‑waarde te verkrijgen.

Het volgende zelf‑standige voorbeeld vereist **Arial** geïnstalleerd. Het maakt twee tekstblokken met dezelfde hoofdletters, kleine letters, afdalende letters en accenten op 54 punt. Beide alinea’s schakelen normalisatie standaard in. Het bovenste deel schakelt het expliciet uit; het onderste erft het. De frame‑groottes, marges en alinea‑afstand zijn identiek, met omloop en autofit uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld drukt `False: false` en `NotDefined: true` af en slaat “text_height_normalization.pptx” op.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De onderstaande vergelijking is geëxporteerd uit de opgeslagen presentatie. De bovenste rij heeft normalisatie uitgeschakeld (`False`); de onderste rij erft de ingeschakelde instelling (`NotDefined` → `True`). Houd Arial geïnstalleerd om dit uiterlijk te reproduceren.

![Arial‑tekst 54 punt met normalisatie uitgeschakeld boven en geërfde normalisatie ingeschakeld hieronder](text_height_normalization.png)

Normalisatie verandert de tekenhoogte zonder de toegewezen [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) waarde te wijzigen, die de lettergrootte in punten aangeeft. Alinea‑[setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) regelt de regelafstand, terwijl tekst‑frame‑[setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bepaalt hoe tekst of de container zich aanpast. Deze instellingen dienen verschillende doelen en kunnen de algemene lay‑out onafhankelijk van elkaar beïnvloeden. Zie voor meer informatie over alinea‑opmaak en overerving [Alinea beheren](/slides/nl/androidjava/manage-paragraph/).

## **Doorstrepen toepassen en verwijderen**

Gebruik [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) op een tekst‑portie om correcties, geannuleerde termen of eerdere prijzen weer te geven zonder de oorspronkelijke tekst te verwijderen. Stel in op [TextStrikethroughType.Single of Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) voor één of twee lijnen door de tekst.

Om doorhalen te verwijderen, geef je [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None) door. Hiermee wordt het effect expliciet uitgeschakeld, zelfs als de omringende opmaak doorhaling specificeert. Daarentegen laat [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) de lokale instelling ongedefinieerd, waardoor de portie de opmaak erft, bijvoorbeeld van de alinea. Het garandeert niet dat doorhalen wordt verwijderd. Gebruik [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) om de resulterende opmaak, inclusief geërfde waarden, te lezen.

Het volgende zelf‑standige voorbeeld maakt drie prijsovereenkomsten. Elke alinea heeft afzonderlijke porties voor het label, de oude prijs en de huidige prijs, zodat alleen de oude prijs wordt beïnvloed. De eerste rij past doorhalen toe en verwijdert het vervolgens; de andere rijen behouden enkel‑ of dubbel‑doorhalen. Het wijzigen van deze instelling behoudt de tekst en de overige opmaak, inclusief de vetgedrukte oude prijs.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Pas doorhaling toe, en verwijder die vervolgens expliciet van de eerste vorige prijs.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat, van boven naar beneden: geen doorhalen, enkel‑doorhalen en dubbel‑doorhalen.

![Oude prijzen zonder doorhalen, met enkel‑doorhalen en met dubbel‑doorhalen](strikethrough.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), wat de tekst **90 graden tegen de klok in** roteert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) om een aangepaste rotatie‑hoek voor een [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) in te stellen.

Het onderstaande code‑voorbeeld roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) en [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) om alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om regelafstand als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om regelafstand in punten op te geven.

Het volgende voorbeeld stelt de afstand binnen de eerste alinea in op 200 % van de regelhoogte (dubbele regelafstand):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Regelafbreking beheren**

Regels voor alinea‑regelafbreking zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Azijatische tekst combineren. De volgende methoden behoren tot [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), dus ze gelden voor een volledige alinea:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) regelt regels voor Latijnse regelafbreking. In gemengde tekst kan het wijzigen hiervan ook de plaats waar aangrenzende Oost‑Azijatische tekst en interpunctie afbreken beïnvloeden.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) regelt regels voor Oost‑Azijatische regelafbreking, inclusief beperkingen op tekens aan het begin of einde van een regel.

Deze regels vervangen niet [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), die automatische omloop binnen een tekstframe inschakelt. Ze beïnvloeden de lay‑out wanneer omloop plaatsvindt; ze voegen geen regelafbrekings‑tekens toe. Een expliciete regelafbreking dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelf‑standige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regelafbrekingsopties expliciet in en slaat “line_breaking.pptx” op. Om een van de regels te testen, wijzig je de bijbehorende waarde terwijl je de andere instellingen onveranderd laat. Het voorbeeld gebruikt Arial 24 punt en SimSun met een frame‑breedte van 160 punt en nul horizontale tekst‑frame‑marges. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) wordt aangeroepen met [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) zodat tekstgrootte en frame‑afmetingen vast blijven.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hangende interpunctie beheren**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) maakt het mogelijk dat in aanmerking komende interpunctie voorbij de rechterrand van de tekstregel uitsteekt i.p.v. de volgende regel in te nemen. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelf‑standige voorbeeld schakelt hangende interpunctie in een tekstframe van 100 punt breed in en slaat “hanging_punctuation.pptx” op. Met Arial 24 punt en nul horizontale tekst‑frame‑marges blijft de uiteindelijke punt na “zin” achter “zin” en steekt hij uit voorbij de rechterkant van de tekst. Stel de eigenschap in op [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) om te vergelijken: met deze instellingen neemt de punt een aparte regel in. Omloop wordt ingeschakeld en autofit uitgeschakeld om de beschikbare breedte vast te houden.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Niet elk leesteken kan hangen. De [lettertype‑ en layout‑voorwaarden beschreven hierboven](#control-line-breaking) gelden ook voor deze vergelijking: het wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit‑type voor tekstframes instellen**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt of de vorm automatisch herschaalt. Het volgende voorbeeld configureert de vorm zodat deze wordt aangepast aan de tekst en slaat het resultaat op in “autofit_type.pptx”.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om na automatische omloop het aantal regels te tellen en te zien hoe tekst‑ of vormbreedte het resultaat verandert, zie [Gerekende Lijnen Tellen](/slides/nl/androidjava/manage-paragraph/). Alleen het aantal regels geeft niet aan of tekst de container overlapt.

## **Anker van tekstframes instellen**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld boven, midden of onder. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op in “text_anchor.pptx”.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabulatie van tekst instellen**

Gebruik [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) en [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaard tab‑intervaller in op 100 punten en voegt een links‑uitgelijnde tab‑stop toe op 30 punten. Deze instellingen beïnvloeden tekst met tab‑tekens.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Correctietaal instellen**

Aspose.Slides biedt [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), waarmee je de correctietaal voor een tekst‑portie kunt instellen. De correctietaal bepaalt de taal die voor spelling‑ en grammaticacontrole in PowerPoint wordt gebruikt.

Het volgende voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia en minstens één alinea. Het vervangt de inhoud van de eerste alinea door “1。”, stelt SimSun in als lettertype en kent de vereenvoudigde Chinese correctietaal (`zh-CN`) toe. Het slaat het resultaat op in “proofing_language.pptx”:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Stel de Id van een correctietaal in.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Taalkundige metadata kopiëren**

Wanneer je meertalige tekst uit een sjabloon kopieert, bewaar je zowel [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) als [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Het volgende zelf‑standige voorbeeld maakt een bron‑portie met US English als taal en Frans als alternatieve taal en kopieert de tekst en identifiers naar een portie in een nieuwe presentatie.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Als de bron geen alternatieve taal heeft, maakt null de bestemmingswaarde leeg.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om een bron zonder alternatieve taal te proberen, laat je de toewijzing van `"fr-FR"` weg. De alternatieve identifier is dan `null`, en dezelfde kopie‑instructie behoudt deze afwezigheid zonder een standaardwaarde toe te voegen, zelfs als de bestemming eerder een alternatieve taal had.

Deze identifiers vormen taalkundige metadata. Het behouden ervan bepaalt niet welke woordenlijst PowerPoint selecteert voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) om de standaardtaal voor tekst die tijdens het laden of maken van een presentatie wordt aangemaakt, te definiëren. Het volgende voorbeeld maakt een presentatie met US English als standaardteksttaal, voegt een tekstvak toe en drukt `en-US` af voor de eerste tekst‑portie.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een nieuwe rechthoekvorm toe met tekst.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Controleer de taal van de eerste portie.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standaardtekstopmaak instellen**

Om standaardtekst‑opmaak op presentatieniveau toe te passen, gebruik je [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Het volgende voorbeeld stelt een vet lettertype van 14 punt in als standaard voor top‑niveau alinea’s in een nieuwe presentatie en slaat dit op in “default_text_style.pptx”. Tekst kan deze standaarden erven, tenzij specifiekere opmaak ze overschrijft.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Haal het alineaformaat van het hoogste niveau op.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekst extraheren met het All‑Caps‑effect**

In PowerPoint maakt het toepassen van het **All Caps**‑lettertype‑effect dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer die oorspronkelijk in kleine letters is getypt. Wanneer je zo’n tekst‑portie met Aspose.Slides ophaalt, retourneert de bibliotheek de tekst precies zoals deze is ingevoerd. Om de weergegeven tekst te matchen, controleer je [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) en converteer je de geretourneerde tekenreeks naar hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist “sample2.pptx” met een tekstvak als eerste vorm op de eerste dia. De eerste alinea‑eerste portie bevat “Hello, Aspose!” met het All‑Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All‑Caps‑effect](all_caps_effect.png)

Het code‑voorbeeld hieronder toont hoe je de tekst met het **All Caps**‑effect kunt extraheren:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe bewerk ik tekst in een tabel op een dia?**

Gebruik [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) om tekst in een tabel op een dia te bewerken. Doorloop de cellen en werk elke cel bij via [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) en alinea‑opmaak via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Hoe pas ik een kleurverloop toe op tekst op een PowerPoint‑dia?**

Gebruik [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) om een kleurverloop op tekst toe te passen. Stel [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) in op [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) en configureer de verloop‑stops, richting en transparantie.