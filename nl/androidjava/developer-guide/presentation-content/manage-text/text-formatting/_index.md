---
title: Opmaak van presentatietekst op Android
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
- lettertype‑eigenschappen
- lettertype‑familie
- tekstrotatie
- rotatie‑hoek
- tekstkader
- regelafstand
- autofit‑eigenschap
- tekstkader‑anker
- tekst‑tabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Opmaak en stijl van tekst in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Android via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Android via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak, en de eerste alinea bevat de onderstaande tekst. Zowel dia‑ als vorm‑indexen zijn nul‑gebaseerd. Voorbeelden die vette gedeelten selecteren gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Zoeken en vervangen van tekst](/slides/nl/androidjava/search-and-replace-text/).

## **Stel achtergrondkleur van tekst in**

Gebruik [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) voor individuele tekstgedeelten.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele gedeelten hebben voorrang op deze standaard:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de markeerkleur in voor de gehele alinea.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

De onderstaande code‑voorbeeld demonstreert hoe u de achtergrondkleur instelt voor **tekstgedeelten met een vet lettertype**:

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
            // Stel de markeerkleur in voor het tekstgedeelte.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst‑alinea’s uitlijnen**

Gebruik [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) om de alinea‑uitlijning binnen een tekstkader in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enzovoort zijn.

Het volgende code‑voorbeeld toont hoe u de alinea naar het **centrum** uitlijnt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de uitlijning van de alinea in op het midden.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Lettertype‑uitlijning binnen een regel**

Gebruik [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) om tekstgedeelden met verschillende lettergroottes verticaal uit te lijnen binnen een regel. Deze instelling geldt voor de volledige alinea en regelt de uitlijning binnen elke regel.

Het volgende zelfstandige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst op 18, 36 en 54 punten, met een verschillende lettertype‑uitlijning. Het gebruikt Arial, schakelt autofit en omloop uit, en houdt de tekstkaders groot genoeg voor één regel.

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

![Vergelijking van basislijn, bovenkant, midden en onderkant lettertype‑uitlijning met gemengde lettergroottes](font_alignment.png)

De lettertype‑uitlijning maakt gebruik van font‑metingen, waardoor de zichtbare randen van individuele letters niet noodzakelijk precies uitgelijnd zijn. Het voorbeeld bevat zowel een hoofdletter als een afdalende letter om het verschil tussen basislijn‑ en onderkant‑uitlijning te illustreren. Beschikbaarheid en substitutie van lettertypen, de gebruikte tekens, en het verschil in lettergroottes beïnvloeden het resultaat. Kaderafmetingen, marges, regelafstand, omloop en autofit hebben ook invloed op de lay‑out; gebruik dezelfde lettertypen en lay‑outinstellingen bij het vergelijken van de modi.

Deze instelling verschilt van [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), die horizontale alinea‑uitlijning regelt, en van [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), die het tekstblok verticaal binnen zijn vorm positioneert. Superscript‑ en subscript‑opmaak via [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) verschuift individuele gedeelten ten opzichte van de basislijn in plaats van lettertype‑uitlijning voor de regels van de alinea in te stellen.

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via het alfacomponent van de kleur die is toegewezen aan [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑kanaalwaarde op de schaal 0‑255, geen transparantiepercentage.

Het onderstaande code‑voorbeeld toont hoe u transparantie toepast op de **hele alinea**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de vulkleur van de tekst in op een transparante kleur.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende code‑voorbeeld toont hoe u transparantie toepast op **tekstgedeelten met een vet lettertype**:

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
            // Stel de transparantie van het tekstgedeelte in.
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

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten toe; negatieve waarden verkleinen de tekst.

Het volgende Java‑code toont hoe u de tekenafstand uitbreidt in de **hele alinea**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

De code‑voorbeeld hieronder toont hoe u de tekenafstand uitbreidt in **tekstgedeelten met een vet lettertype**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
            portion.getPortionFormat().setSpacing(3); // Vergroot de tekenafstand.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd iets strakker lijken dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde output dichter bij PowerPoint te brengen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) in op een waarde groter dan de werkelijke lettergrootte. Dit voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertypenamen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende gedeelten met een lettergrootte onder 100 punten:

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

Voor tekst die onder de drempel valt, voorkomt deze instelling kerning en kan het helpen de Aspose.Slides‑rendering af te stemmen op de visuele output van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Tekst‑lettertype‑eigenschappen beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) of op individuele gedeelten via [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaarden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de lettertype-eigenschappen in voor de alinea.
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

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op gedeelten waarvoor de effectieve opmaak vet is:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Stel de lettertype-eigenschappen in voor het tekstgedeelte.
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

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Normalisatie van teksthoogte regelen**

Gebruik [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) bij het reproduceren van sjabloon‑typografie of het onderzoeken van verschillen in tekenhoogte. In PowerPoint maakt inschakelen van normalisatie dat individuele tekens verticaal worden uitgerekt of samengedrukt om een uniforme zichtbare hoogte binnen het tekstgedeelte te geven. Het garandeert geen gelijke teksthoogten tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool.True of False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) om normalisatie expliciet in of uit te schakelen. `NullableBool.NotDefined` laat de lokale instelling ongedefinieerd, zodat het gedeelte de waarde erft, bijvoorbeeld van de alinea‑[getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--). Het betekent niet `False`. Gebruik [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) en lees [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) om de resolved Boolean‑waarde te verkrijgen.

Het volgende zelfstandige voorbeeld vereist **Arial** geïnstalleerd. Het maakt twee tekstblokken aan met dezelfde hoofdletters, kleine letters, aflopende tekens en accenten op 54 punten. Beide alinea's schakelen normalisatie standaard in. Het bovenste gedeelte schakelt het expliciet uit; het onderste gedeelte erft het. De kader‑groottes, marges en alinea‑afstand zijn identiek, met omloop en autofit uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld drukt `False: false` en `NotDefined: true` af, en slaat vervolgens "text_height_normalization.pptx" op.

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

![Arial‑tekst van 54 punt met normalisatie uitgeschakeld boven en geërfde normalisatie ingeschakeld hieronder](text_height_normalization.png)

Normalisatie verandert de tekenhoogte zonder de toegewezen [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--)‑waarde te wijzigen, die de lettergrootte in punten specificeert. Alinea‑[setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) regelt de regelafstand, terwijl tekstkader‑[setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bepaalt hoe tekst of de container zich aanpast om te passen. Deze instellingen dienen verschillende doelen en kunnen de algehele lay‑out onafhankelijk beïnvloeden. Voor meer over alinea‑opmaak en erfenis, zie [Beheer alinea](/slides/nl/androidjava/manage-paragraph/).

## **Doorhalen toepassen en verwijderen**

Gebruik [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) op een tekstgedeelte om correcties, geannuleerde termen of eerdere prijzen weer te geven zonder de oorspronkelijke tekst te verwijderen. Stel het in op [TextStrikethroughType.Single of Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) voor één respectievelijk twee doorhalingslijnen.

Om doorhalen te verwijderen, geef [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None) door. Dit schakelt het effect expliciet uit, zelfs als de omringende opmaak doorhalen specificeert. Daarentegen laat [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) de lokale instelling ongedefinieerd, waardoor het gedeelte de opmaak kan erven, bijvoorbeeld van de alinea. Het garandeert niet dat doorhalen wordt verwijderd. Gebruik [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) om de resulterende opmaak te lezen, inclusief geërfde waarden.

Het volgende zelfstandige voorbeeld maakt drie prijsvergelijkingen. Elke alinea heeft aparte gedeelten voor het label, de vorige prijs en de huidige prijs, zodat alleen de vorige prijs wordt beïnvloed. De eerste rij past doorhalen toe en verwijdert het daarna; de andere rijen behouden respectievelijk enkele en dubbele doorhaling. Het wijzigen van deze instelling behoudt de tekst en de overige opmaak, inclusief de vetgedrukte vorige prijs.

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

    // Pas doorhaling toe, en verwijder deze vervolgens expliciet van de eerste vorige prijs.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat, van boven naar beneden: geen doorhalen, enkele doorhaling, en dubbele doorhaling.

![Vorige prijzen zonder doorhalen, met enkele doorhaling, en met dubbele doorhaling](strikethrough.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) om een voorgedefinieerde tekstrichting binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstrichting in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), die de tekst **90 graden tegen de klok in** roteert:

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

![De tekstrrotatie](text_rotation.png)

## **Cijfers naast elkaar weergeven in verticale tekst**

Om een tweecijferig getal samen te houden in een verticaal Japans label, plaats beide cijfers in één tekstgedeelte en roep [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) aan op dat gedeelte. Het voorbeeld gebruikt [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/#EastAsianVertical) en 40‑punt MS Gothic voor beide labels. Alleen de [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/)‑waarde die aan het numerieke gedeelte wordt doorgegeven, verschilt:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);

        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In PowerPoint toont het linkerlabe (`True`) de cijfers rechtop en naast elkaar tussen 和 en 年. Het rechterlabel (`False`) roteert het paar 90 graden met de klok mee. De omringende Japanse tekens blijven rechtop in beide labels.

![PowerPoint‑vergelijking van verticale datum‑labels met rechtopstaande cijfers links en geroteerde cijfers rechts.](vertical_date.png)

## **Aangepaste rotatie voor tekstkaders instellen**

Gebruik [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) om een aangepaste rotatie‑hoek in te stellen voor een [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

Het code‑voorbeeld hieronder roteert het tekstkader met 3 graden met de klok mee binnen de vorm:

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

![De aangepaste tekstrrotatie](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) en [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) om alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

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

## **Regelafbreking regelen**

Regelafbreekregels voor alinea's zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende methoden behoren tot [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), dus ze gelden voor een volledige alinea:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) regelt de regelafbreekregels voor Latijn. In gemengde tekst kan het wijzigen ervan ook veranderen waar aangrenzende Oost‑Aziatische tekst en interpunctie worden afgebroken.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) regelt de regelafbreekregels voor Oost‑Aziatisch, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), die automatisch omloop binnen een tekstkader inschakelt. Ze beïnvloeden de lay‑out wanneer omloop plaatsvindt; ze voegen geen regelafbreekteken toe. Een expliciete regelafbreking dwingt een nieuwe regel binnen de alinea af, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regelafbreekopties expliciet in en slaat "line_breaking.pptx" op. Om met een regel te experimenteren, wijzig de bijbehorende waarde terwijl de andere instellingen ongewijzigd blijven. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een kaderbreedte van 160 punten en horizontale tekstkader‑marges op nul. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) wordt aangeroepen met [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) zodat tekstgrootte en kaderafmetingen vast blijven.

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

## **Hangende interpunctie regelen**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) maakt het mogelijk dat in aanmerking komende interpunctie zich uitstrekt voorbij de rechterrand van de tekstregel in plaats van de volgende regel in te nemen. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een 100‑punt breed tekstkader in en slaat "hanging_punctuation.pptx" op. Met 24‑punt Arial en horizontale tekstkader‑marges op nul blijft de laatste punt achter "sentence" en strekt zich uit voorbij de rechtertekstrand. Stel de eigenschap in op [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) om te vergelijken: met deze instellingen neemt de punt een aparte regel in. Omloop is ingeschakeld en autofit is uitgeschakeld om de beschikbare breedte vast te houden.

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

Niet elk leesteken kan hangen. De [lettertype‑ en lay‑outcondities beschreven hierboven](#control-line-breaking) gelden ook voor deze vergelijking: het wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil verwijderen.

## **Autofit‑type voor tekstkaders instellen**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst verkleint, overloopt of de vorm automatisch aanpast. Het volgende voorbeeld configureert de vorm om te schalen naar de tekst en slaat het resultaat op in "autofit_type.pptx".

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

Om het aantal regels te tellen na automatisch omloop en te zien hoe tekst‑ of vormbreedte het resultaat verandert, zie [Aantal gerenderde regels](/slides/nl/androidjava/manage-paragraph/). Het aantal regels alleen geeft niet aan of tekst buiten de container overloopt.

## **Anker van tekstkaders instellen**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) bepaalt hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld boven, midden of onder. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op in "text_anchor.pptx".

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

## **Tekst‑tabulatie instellen**

Gebruik [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) en [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaard tab‑interval in op 100 punten en voegt een links‑uitgelijnde tab‑stop toe op 30 punten. Deze instellingen beïnvloeden tekst die tab‑tekens bevat.

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

![De alinea‑tabstops](paragraph_tabs.png)

## **Controlleertaal instellen**

Aspose.Slides biedt [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), waarmee u de controlleertaal voor een tekstgedeelte kunt instellen. De controlleertaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia en minstens één alinea. Het vervangt de inhoud van de eerste alinea door "1。", stelt SimSun in als het lettertype, en wijst de vereenvoudigde Chinese controlleertaal (`zh-CN`) toe. Het slaat het resultaat op in "proofing_language.pptx":

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

    // Stel de Id van een proefleestaal in.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Taal‑metadata kopiëren**

Bij het kopiëren van meertalige tekst uit een sjabloon, behoud zowel [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) als [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Het volgende zelfstandige voorbeeld maakt een bron‑gedeelte met Amerikaans Engels als taal en Frans als alternatieve taal, en kopieert de tekst en identifiers naar een gedeelte in een nieuwe presentatie.

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

Om een bron zonder alternatieve taal te proberen, laat de toewijzing van "fr-FR" weg. De alternatieve identifier is dan `null`, en dezelfde copy‑instructie behoudt de afwezigheid zonder een standaardwaarde toe te voegen, zelfs als de bestemming eerder een alternatieve taal had toegewezen.

Deze identifiers worden opgeslagen als taal‑metadata. Het behouden ervan bepaalt niet welke woordenlijst PowerPoint gebruikt voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie. Het volgende voorbeeld maakt een presentatie met Amerikaans Engels als standaardteksttaal, voegt een tekstvak toe, en drukt `en-US` af voor het eerste tekstgedeelte.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een nieuw rechthoekig vorm toe met tekst.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Controleer de taal van het eerste gedeelte.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standaard‑tekststijl instellen**

Om standaard‑tekstopmaak op presentatie‑niveau toe te passen, gebruik [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor top‑niveau alinea's in een nieuwe presentatie en slaat het op in "default_text_style.pptx". Tekst kan deze standaarden erven tenzij meer specifieke opmaak ze overschrijft.

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

## **Tekst extraheren met het All-Caps‑effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑fonteffect ervoor dat tekst in hoofdletters op de dia verschijnt, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer u zo'n tekstgedeelte ophaalt met Aspose.Slides, geeft de bibliotheek de tekst exact terug zoals ingevoerd. Om overeen te komen met de weergegeven tekst, controleer [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) en zet de geretourneerde tekenreeks om naar hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist "sample2.pptx" met een tekstvak als eerste vorm op de eerste dia. Het eerste gedeelte van de eerste alinea bevat "Hello, Aspose!" met het All Caps‑effect toegepast, zoals hieronder getoond.

![Het All Caps‑effect](all_caps_effect.png)

De code‑voorbeeld hieronder toont hoe u de tekst met het **All Caps**‑effect kunt extraheren:

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

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruik [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Loop door de cellen en werk elke cel bij via [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) en alinea‑opmaak via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Hoe pas ik een kleurverloop toe op tekst op een PowerPoint‑dia?**

Om een kleurverloop op tekst toe te passen, gebruik [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Stel [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) in op [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) en configureer de gradient‑stops, richting en transparantie.