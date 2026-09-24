---
title: Formatera presentationstext på Android
linktitle: Textformatering
type: docs
weight: 50
url: /sv/androidjava/text-formatting/
keywords:
- justera stycke
- textstil
- textbakgrund
- texttransparens
- teckenavstånd
- teckensnittsegenskaper
- teckensnittsfamilj
- textrotation
- rotationsvinkel
- textram
- radavstånd
- autofit egenskap
- textram ankare
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Formatera och stilisera text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java. Anpassa teckensnitt, färger, justering med mera."
---
## **Översikt**

Den här artikeln visar hur du formaterar text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java. Den täcker bakgrundsfärger, transparens, teckenavstånd, teckensnittsegenskaper, rotation, styckeavstånd, autofit‑beteende, textankring, tabbstopp och språkinställningar.

I exemplen nedan använder vi en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

För att hitta och markera bokstavlig text eller reguljära uttryck, se [Sök och ersätt text](/slides/sv/androidjava/search-and-replace-text/).

## **Ställ in bakgrundsfärg för text**

Använd [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) för att ange standardmarkeringsfärgen för ett stycke, eller använd [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) för enskilda textdelar.

Följande kodexempel visar hur du anger bakgrundsfärgen för **hela stycket**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ange markeringsfärgen för hela stycket.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan demonstrerar hur du anger bakgrundsfärgen för **textdelar med fet stil**:

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
            // Ange markeringsfärgen för textdelen.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De grå textdelarna](gray_text_portions.png)

## **Justera textstycken**

Använd [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) för att ange styckejustering inom en textram. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, blockjusterat osv.

Följande kodexempel visar hur du justerar stycket till **centrum**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ställ in styckejusteringen till centrum.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det justerade stycket](aligned_paragraph.png)

## **Ställ in transparens för text**

Texttransparens styrs genom alfa‑komponenten i färgen som tilldelas [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). I exemplen nedan är `alpha = 50` ett ARGB‑alfa‑värde på skalan 0–255, inte en transparensprocent.

Kodexemplet nedan visar hur du tillämpar transparens på **hela stycket**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ange fyllningsfärgen för texten till transparent färg.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur du tillämpar transparens på **textdelar med fet stil**:

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
            // Ange transparensen för textdelen.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De transparenta textdelarna](transparent_text_portions.png)

## **Ställ in teckenavstånd för text**

Använd [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) för att öka eller minska avståndet mellan tecken i en textram.

Följande Java‑kod visar hur du ökar teckenavståndet i **hela stycket**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Obs: Använd negativa värden för att komprimera teckenavståndet.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Utöka teckenavståndet.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Teckenavståndet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur du ökar teckenavståndet i **textdelar med fet stil**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Obs: Använd negativa värden för att komprimera teckenavståndet.
            portion.getPortionFormat().setSpacing(3); // Utöka teckenavståndet.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Teckenavståndet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika typsnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tätare ut än samma text i PowerPoint. Detta kan ske eftersom PowerPoint kan ignorera kerningdata för vissa typsnitt, även när typsnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoints inställningar.

För att göra den renderade utdata närmare PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det påverkade typsnittet. Ställ in [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) på ett värde som är avsevärt större än den faktiska teckenstorleken:

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

Denna inställning förhindrar att kerning tillämpas på matchande textdelar och kan hjälpa till att anpassa Aspose.Slides rendering till PowerPoints visuella utdata för typsnitt som påverkas av detta PowerPoint‑specifika beteende.

## **Hantera texttypsnittsegenskaper**

Typsnittsegenskaper kan sättas på styckennivå via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) eller på enskilda delar via [IPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportionformat/).

Följande kod sätter typsnittet och textstilen för hela stycket: den tillämpar teckenstorlek, fet, kursiv, prickad understrykning och Times New Roman på alla delar i stycket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ställ in typsnittsegenskaper för stycket.
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

Resultatet:

![Typsnittsegenskaper för stycket](font_properties_for_paragraph.png)

Kodexemplet nedan tillämpar liknande egenskaper på **textdelar med fet stil**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ställ in typsnittsegenskaper för textdelen.
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

Resultatet:

![Typsnittsegenskaper för textdelarna](font_properties_for_text_portions.png)

## **Ställ in textrotation**

Använd [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) för att ange en fördefinierad textorientering inom en form.

Följande kodexempel sätter textorienteringen i formen till [TextVerticalType.Vertical270](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textverticaltype/), vilket roterar texten **90 grader moturs**:

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

Resultatet:

![Textrotationen](text_rotation.png)

## **Ställ in anpassad rotation för textramar**

Använd [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) för att ange en anpassad rotationsvinkel för en [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).

Kodexemplet nedan roterar textramen med 3 grader medurs inom formen:

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

Resultatet:

![Den anpassade textrotationen](custom_text_rotation.png)

## **Ställ in radavstånd för stycken**

Aspose.Slides tillhandahåller [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) och [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) för att kontrollera styckeavstånd. Dessa egenskaper används på följande sätt:

* Använd ett positivt värde för att ange radavstånd som en procent av radens höjd.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande kodexempel visar hur du anger radavståndet inom stycket:

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

Resultatet:

![Radavståndet i stycket](line_spacing.png)

## **Ställ in autofit‑typ för textramar**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att styra om texten ska krympa, gå utanför eller automatiskt anpassa formen.

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

För att räkna rader efter automatisk radbrytning och se hur text‑ eller formbredd förändrar resultatet, se [Räkna renderade rader](/slides/sv/androidjava/manage-paragraph/). Radantalet ensam visar inte om texten går utanför behållaren.

## **Ställ in ankare för textramar**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definierar hur text placeras vertikalt inuti en form, t.ex. högst upp, i mitten eller längst ner.

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

## **Ställ in texttabulering**

Använd [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) och [IParagraphFormat.getTabs](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) för att konfigurera tabbstopp i ett stycke.

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

Resultatet:

![Styckets tabbar](paragraph_tabs.png)

## **Ställ in språk för korrektur**

Aspose.Slides tillhandahåller [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), vilket låter dig ange språk för korrektur för en textdel. Språket för korrektur bestämmer vilket språk som används för stavnings‑ och grammatikkontroller i PowerPoint.

Följande kodexempel visar hur du anger språk för korrektur för en textdel:

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

    // Ange Id för ett korrekturläsningsspråk.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in standardspråk**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) för att definiera standardspråket för text som skapas vid inläsning eller skapande av en presentation.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en ny rektangelform med text.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Kontrollera språk för den första delen.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ställ in standardtextstil**

För att tillämpa standardformatering av text på presentationsnivå, använd [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Följande kodexempel visar hur du anger ett standardtypsnitt i fet stil med storlek 14 pt för all text på alla bilder i en ny presentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Hämta styckeformatet på högsta nivån.
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

## **Extrahera text med versaler‑effekt**

I PowerPoint gör applicering av **All Caps**‑effekten att text visas med stora bokstäver på bilden även om den ursprungligen skrevs med små bokstäver. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den angavs. För att matcha den visade texten, konvertera den returnerade strängen till versaler när värdet är [TextCapType.All](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textcaptype/).

Låt oss säga att vi har följande textruta på den första bilden i filen sample2.pptx.

![Versaler‑effekten](all_caps_effect.png)

Kodexemplet nedan visar hur du extraherar texten med **All Caps**‑effekten tillämpad:

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

Utdata:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar man text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [ITable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itable/). Iterera genom cellerna och uppdatera varje cell via [ICell.getTextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icell/#getTextFrame--) samt styckeformatering via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Hur applicerar man gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text, använd [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Ställ in [IFillFormat.setFillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) till [FillType.Gradient](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.