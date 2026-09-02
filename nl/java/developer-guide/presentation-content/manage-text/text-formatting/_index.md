---
title: Tekst opmaken in presentaties met Java
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/java/text-formatting/
keywords:
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype‑eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit‑eigenschap
- tekstframe‑anker
- tekst‑tabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Formateer en style tekst in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe je tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides for Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

In de voorbeelden hieronder gebruiken we een bestand met de naam **sample.pptx**, dat een enkele tekstvak bevat op de eerste dia met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te zoeken en te markeren, zie [Zoeken en vervangen van tekst](/slides/nl/java/search-and-replace-text/).

## **Achtergrondkleur van tekst instellen**

Gebruik [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) voor individuele tekstgedeelten.

De volgende code‑voorbeeld laat zien hoe je de achtergrondkleur voor de **hele alinea** instelt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de markeerkleur in voor de hele alinea.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De grijze alinea](gray_paragraph.png)

De code‑voorbeeld hieronder toont hoe je de achtergrondkleur voor **tekstgedeelten met een vet lettertype** instelt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Stel de markeerkleur in voor het tekstgedeelte.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Alinea‑tekst uitlijnen**

Gebruik [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) om de alineauitlijning binnen een tekstframe in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enzovoort zijn.

De volgende code‑voorbeeld laat zien hoe je de alinea naar het **midden** uitlijnt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de uitlijning van de alinea in op midden.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑component van de kleur die is toegewezen aan [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). In de voorbeelden hieronder is `alpha = 50` een ARGB‑alfa‑waarde op de 0–255‑schaal, geen transparantie‑percentage.

De code‑voorbeeld hieronder toont hoe je transparantie toepast op de **hele alinea**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de vulkleur van de tekst in op een transparante kleur.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De transparante alinea](transparent_paragraph.png)

De volgende code‑voorbeeld laat zien hoe je transparantie toepast op **tekstgedeelten met een vet lettertype**:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen.

De volgende Java‑code laat zien hoe je de tekenafstand in de **hele alinea** vergroot:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Vergroot tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

De code‑voorbeeld hieronder laat zien hoe je de tekenafstand vergroot in **tekstgedeelten met een vet lettertype**:

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
            portion.getPortionFormat().setSpacing(3); // Vergroot tekenafstand.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dat kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer dichter bij PowerPoint te brengen, kun je kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) in op een waarde die aanzienlijk groter is dan de werkelijke lettergrootte:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstgedeelten en kan helpen de weergave van Aspose.Slides te laten overeenkomen met die van PowerPoint voor de betrokken lettertypen.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) of per afzonderlijk gedeelte via [IPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportionformat/).

De volgende code stelt het lettertype en de tekststijl in voor de hele alinea: het past lettergrootte, vet, cursief, gestippelde onderstreping en het lettertype Times New Roman toe op alle gedeelten in de alinea.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de lettertype‑eigenschappen in voor de alinea.
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

Resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

De code‑voorbeeld hieronder past soortgelijke eigenschappen toe op **tekstgedeelten met een vet lettertype**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Stel de lettertype‑eigenschappen in voor het tekstgedeelte.
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

Resultaat:

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

De volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op `Vertical270`, waardoor de tekst **90 graden tegen de klok in** wordt gedraaid:

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

Resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) om een aangepaste rotatiehoek in te stellen voor een [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/).

De code‑voorbeeld hieronder roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

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

Resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) en [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) om de afstand tussen alinea’s te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

De volgende code‑voorbeeld laat zien hoe je de regelafstand binnen de alinea specificeert:

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

Resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Autofit‑type voor tekstframes instellen**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overstroomt of de vorm automatisch herschaalt.

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

## **Anker van tekstframes instellen**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan.

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

## **Tabulatie voor tekst instellen**

Gebruik [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) en [IParagraphFormat.getTabs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getTabs--) om tab‑stops in een alinea te configureren.

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

Resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Controleertaal instellen**

Aspose.Slides biedt [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), waarmee je de controle‑taal voor een tekstgedeelte kunt instellen. De controle‑taal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

De volgende code‑voorbeeld laat zien hoe je de controle‑taal voor een tekstgedeelte instelt:

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

    // Stel de Id in van een proefleestaal.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie.

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

    // Controleer de taal van de eerste tekstgedeelte.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standaardtekststijl instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

De volgende code‑voorbeeld laat zien hoe je een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst op alle dia’s in een nieuwe presentatie.

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

In PowerPoint zorgt het toepassen van het **All Caps**‑schrift­effect ervoor dat tekst op de dia in hoofdletters wordt weergegeven, zelfs als deze oorspronkelijk in kleine letters is getypt. Wanneer je een dergelijk tekstgedeelte ophaalt met Aspose.Slides, retourneert de bibliotheek de tekst exact zoals ingevoerd. Controleer [TextCapType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textcaptype/) en zet de geretourneerde string om naar hoofdletters wanneer de waarde `All` is.

Stel dat we het volgende tekstvak hebben op de eerste dia van het bestand **sample2.pptx**.

![Het All Caps‑effect](all_caps_effect.png)

De code‑voorbeeld hieronder toont hoe je de tekst met het **All Caps**‑effect kunt extraheren:

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

Gebruik [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itable/). Doorloop de cellen en werk elke cel bij via [ICell.getTextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icell/#getTextFrame--) en de alinea‑opmaak via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Hoe pas ik een gradientkleur toe op tekst in een PowerPoint‑dia?**

Gebruik [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Stel [IFillFormat.setFillType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifillformat/#setFillType-byte-) in op [FillType.Gradient](https://reference.aspose.com/slides/nl/java/com.aspose.slides/filltype/) en configureer de gradient‑stops, richting en transparantie.