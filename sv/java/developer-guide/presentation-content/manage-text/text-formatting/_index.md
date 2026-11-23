---
title: Formatera presentationstext i Java
linktitle: Textformatering
type: docs
weight: 50
url: /sv/java/text-formatting/
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
- autofit-egenskap
- textram-ankare
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Formatera och stilisera text i PowerPoint‑ och OpenDocument‑presentationer med Aspose.Slides för Java. Anpassa teckensnitt, färger, justering och mer."
---
## **Översikt**

Denna artikel visar hur man formaterar text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java. Den behandlar bakgrundsfärger, transparens, teckenavstånd, teckensnittsegenskaper, rotation, styckeavstånd, autofit‑beteende, textankring, tabbstopp och språkinställningar.

Om inget annat anges använder exemplen [sample.pptx](sample.pptx). Den första formen på den första bilden är en textruta, och dess första stycke innehåller texten som visas nedan. Både bild- och formindex är nollbaserade. Exempel som markerar fetstilta delar använder effektiv formatering, inklusive ärvd fetstil:

![Exempeltext](sample_text.png)

För att hitta och markera exakt text eller reguljära uttryck, se [Sök och ersätt text](/slides/sv/java/search-and-replace-text/).

## **Ange textbakgrundsfärg**

Använd [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) för att ange standardmarkeringsfärg för ett stycke, eller använd [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) för enskilda textdelar.

Följande exempel anger en ljusgrå markering som standard för det första stycket. Explicit markeringsfärg på enskilda delar har företräde framför detta standardvärde:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ange markeringsfärgen för hela stycket.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan visar hur man anger bakgrundsfärg för **textdelar med fet stil**:

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
            // Ange markeringsfärgen för textdelen.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De gråa textdelarna](gray_text_portions.png)

## **Justera textstycken**

Använd [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) för att ange styckejustering inom en textram. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, justerat med fyllning osv.

Följande kodexempel visar hur man justerar stycket till **center**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ställ in styckets justering till centrerad.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det centrerade stycket](aligned_paragraph.png)

## **Justera teckensnitt inom en rad**

Använd [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) för att vertikalt justera textdelar med olika teckenstorlekar inom en rad. Denna inställning gäller hela stycket och styr justeringen inom varje rad.

Följande fristående exempel skapar fyra märkta textrutor på en bild. Varje stycke innehåller samma text i 18, 36 och 54 punkter, med olika teckensnittjustering. Det använder Arial, inaktiverar autofit och radbrytning, samt håller textramarna tillräckligt stora för en enda rad.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Resultatet:

![Jämförelse av Baseline, Top, Center och Bottom teckensnittjustering med blandade teckenstorlekar](font_alignment.png)

Teckensnittjustering använder teckensnittsmått, så de synliga kanterna på enskilda bokstäver nödvändigtvis inte linjerar exakt. Exemplet inkluderar både en stor bokstav och en nedåtrsänkt del för att tydligt visa skillnaden mellan baseline‑ och bottenjustering. Tillgänglighet och ersättning av teckensnitt, de använda tecknen samt skillnad i teckenstorlekar påverkar resultatet. Ramstorlek, marginaler, radavstånd, radbrytning och autofit påverkar också layouten; använd samma teckensnitt och layoutinställningar när du jämför lägen.

Denna inställning skiljer sig från [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), som styr horisontell styckejustering, och [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), som placerar textblocket vertikalt inom sin form. Upphöjd och nedsänkt formatering via [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) förskjuter enskilda delar relativt baseline istället för att ange teckensnittjustering för styckets rader.

## **Ange transparens för text**

Texttransparens styrs via alfakomponenten i färgen som tilldelas [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). I exemplen nedan är `alpha = 50` ett ARGB‑alfavärde på skalan 0–255, inte en transparensprocent.

Kodexemplet nedan visar hur man applicerar transparens på **hela stycket**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // An

    // Ange fyllningsfärgen för texten till transparent färg.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur man applicerar transparens på **textdelar med fet stil**:

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
            // Ange transparensen för textdelen.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De transparenta textdelarna](transparent_text_portions.png)

## **Ange teckenavstånd för text**

Använd [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) för att utöka eller minska avståndet mellan tecken i en textruta. Exemplen lägger till 3 punkters avstånd; negativa värden minskar avståndet.

Följande Java‑kod visar hur man utökar teckenavståndet i **hela stycket**:

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

Kodexemplet nedan visar hur man utökar teckenavståndet i **textdelar med fet stil**:

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

### **Inaktivera kerning för specifika teckensnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tajtare ut än samma text i PowerPoint. Detta kan hända eftersom PowerPoint kan ignorera kerning‑data för vissa teckensnitt, även när teckensnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoint‑inställningarna.

För att få den renderade utdata närmare PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det påverkade teckensnittet. Sätt [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) till ett värde som är större än den faktiska teckenstorleken. Detta exempel kräver "presentation.pptx" med en textruta som den första formen på den första bilden. Det kontrollerar effektiva teckensnittsnamn, inklusive ärvda teckensnitt, och sätter ett tröskelvärde på 100 punkter för delar som använder Roboto. Detta inaktiverar kerning för matchande delar med en teckenstorlek under 100 punkter:

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

För matchande text under tröskeln förhindrar denna inställning kerning och kan hjälpa till att anpassa Aspose.Slides‑rendering till PowerPoints visuella utdata för teckensnitt som påverkas av detta PowerPoint‑specifika beteende.

## **Hantera textteckensnittsegenskaper**

Teckensnittsegenskaper kan anges på styckelnivå via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) eller på enskilda delar via [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

Följande exempel anger första stycket standardteckensnitt till 12‑punkts Times New Roman med fet, kursiv och prickad understrykning. Explicit formatering på enskilda delar har företräde framför dessa standardvärden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ställ in teckensnittsegenskaper för stycket.
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

![Teckensnittsegenskaper för stycket](font_properties_for_paragraph.png)

Följande exempel tillämpar 13‑punkts Times New Roman, kursiv formatering och prickad understrykning på delar vars effektiva formatering är fet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ange teckensnittsegenskaper för textdelen.
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

![Teckensnittsegenskaper för textdelar](font_properties_for_text_portions.png)

## **Styr normalisering av texthöjd**

Använd [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) när du återger typografi från mallar eller undersöker skillnader i teckenhöjd. I PowerPoint sträcker eller komprimerar aktivering av normalisering enskilda tecken vertikalt för att ge dem en enhetlig synlig höjd inom textdelen. Det garanterar inte lika texthöjder mellan olika teckensnitt.

Sätt egenskapen till [NullableBool.True eller False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) för att explicit aktivera eller inaktivera normalisering. `NullableBool.NotDefined` lämnar den lokala inställningen odefinierad så att delen ärver värdet, till exempel från styckets [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--). Det betyder inte `False`. Använd [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) och läs [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) för att erhålla det lösta booleska värdet.

Följande fristående exempel kräver att **Arial** är installerat. Det skapar två textblock med samma versaler, gemener, nedåtrsänkta tecken och akuterade tecken på 54 punkter. Båda styckena har normalisering aktiverad som standard. Den övre delen inaktiverar den uttryckligt; den nedre ärver den. Ramstorlekar, marginaler och styckeavstånd är identiska, med radbrytning och autofit inaktiverade för att hålla jämförelsen konsekvent. Exemplet skriver ut `False: false` och `NotDefined: true`, och sparar sedan "text_height_normalization.pptx".

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Jämförelsen nedan exporterades från den sparade presentationen. Den övre raden har normalisering inaktiverad (`False`); den nedre raden ärver den aktiverade inställningen (`NotDefined` → `True`). Behåll Arial installerat för att reproducera detta utseende.

![Arial 54‑punkts text med normalisering inaktiverad ovanför och ärvd normalisering aktiverad nedanför](text_height_normalization.png)

Normalisering ändrar teckenhöjd utan att förändra det tilldelade [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--)‑värdet, som anger teckenstorlek i punkter. Stycke‑[setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) styr radavstånd, medan textram‑[setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) styr hur text eller behållare justeras för att passa. Dessa inställningar har olika syften och kan påverka layouten oberoende av varandra. Läs mer om styckeformatering och arv under [Hantera stycke](/slides/sv/java/manage-paragraph/).

## **Tillämpa och ta bort genomstrykning**

Använd [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) på en textdel för att visa korrigeringar, avbrutna termer eller tidigare priser utan att ta bort originaltexten. Sätt den till [TextStrikethroughType.Single eller Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) för en eller två linjer genom texten.

För att ta bort genomstrykning, skicka [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None). Detta inaktiverar effekten explicit, även om omgivande formatering anger genomstrykning. Däremot lämnar [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) den lokala inställningen odefinierad, så att delen kan ärva formatering, exempelvis från stycket. Det garanterar inte att genomstrykning tas bort. Använd [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) för att läsa den resulterande formateringen, inklusive ärvda värden.

Följande fristående exempel skapar tre prisjämförelser. Varje stycke har separata delar för etikett, tidigare pris och aktuellt pris, så endast det tidigare priset påverkas. Den första raden tillämpar och tar sedan bort genomstrykning; de andra raderna behåller enkel respektive dubbel genomstrykning. Att ändra denna inställning bevarar texten och dess övriga formatering, inklusive den feta tidigare priset.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Applicera genomstrykning, och ta sedan bort den explicit från det första föregående priset.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet, från topp till botten: ingen genomstrykning, enkel genomstrykning och dubbel genomstrykning.

![Tidigare priser utan genomstrykning, med enkel genomstrykning och med dubbel genomstrykning](strikethrough.png)

## **Ange textrotation**

Använd [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) för att ange en fördefinierad textriktning inom en form.

Följande kodexempel sätter textriktningen i formen till [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), vilket roterar texten **90 grader moturs**:

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

![Textrotation](text_rotation.png)

## **Visa siffror sida vid sida i vertikal text**

För att hålla ett tvåsiffrigt tal ihop i en vertikal japansk etikett, placera båda siffrorna i en textrad och anropa [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) på den delen. Exemplet använder [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) och 40‑punkts MS Gothic för båda etiketterna. Enbart värdet på [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) som skickas till den numeriska delen skiljer sig.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

I PowerPoint visar den vänstra etiketten (`True`) siffrorna upprätt och sida vid sida mellan 和 och 年. I den högra etiketten (`False`) roteras paret 90 grader medurs. De omgivande japanska tecknen förblir upprätt i båda etiketterna.

![PowerPoint‑jämförelse av vertikala datumetiketter med upprätta siffror till vänster och roterade siffror till höger.](vertical_date.png)

## **Ange anpassad rotation för textramar**

Använd [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) för att ange en anpassad rotationsvinkel för en [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

Kodexemplet nedan roterar textramen 3 grader medurs inom formen:

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

![Anpassad textrotation](custom_text_rotation.png)

## **Ange radavstånd för stycken**

Aspose.Slides tillhandahåller [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) och [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) för att styra styckeavstånd. Dessa egenskaper används så här:

* Använd ett positivt värde för att ange radavstånd som en procentandel av radhöjden.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande exempel anger avståndet inom det första stycket till 200 % av radhöjden (dubbelt radavstånd):

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

![Radavståndet inom stycket](line_spacing.png)

## **Styr radbrytning**

Regler för radbrytning i stycken är användbara i smala textblock och presentationer som blandar latinsk och östasiatisk text. Följande metoder tillhör [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/), så de gäller ett helt stycke:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) styr radbrytningsregler för latinsk text. I blandad text kan en förändring också påverka var östasiatisk text och interpunktion bryts.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) styr radbrytningsregler för östasiatisk text, inklusive begränsningar för tecken i början och slutet av en rad.

Dessa regler ersätter inte [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), som möjliggör automatisk radbrytning inom en textram. De påverkar layouten när radbrytning sker; de infogar inga radbrytningstecken. En explicit radbrytning tvingar en ny rad inom stycket oberoende av tillgänglig bredd.

Följande fristående exempel skapar ett smalt textblock som innehåller kinesisk och latinsk text. Det anger båda radbrytningsalternativen explicit och sparar "line_breaking.pptx". För att experimentera med någon av reglerna, ändra motsvarande värde medan du behåller den andra inställningen oförändrad. Exemplet använder 24‑punkts Arial och SimSun med 160‑punkts rambredd och noll horisontella textram‑marginaler. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) anropas med [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) så att textstorlek och ramdimensioner förblir fasta.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Styr hängande interpunktion**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) låter berättigad interpunkt sträcka sig utanför högra kanten på textraden istället för att ta upp nästa rad. Det gäller hela stycket och skiljer sig från ett hängande indrag.

Följande fristående exempel aktiverar hängande interpunktion i en 100‑punkts bred textram och sparar "hanging_punctuation.pptx". Med 24‑punkts Arial och noll horisontella textram‑marginaler förblir den sista punkten efter ordet "sentence" och sträcker sig utanför den högra textranden. Sätt egenskapen till [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) för att jämföra: med dessa inställningar placeras punkten på en separat rad. Radbrytning är aktiverad och autofit inaktiverad för att hålla tillgänglig bredd fast.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Inte varje interpunktionstecken kan hänga. De [font‑ och layoutvillkor som beskrivs ovan](#control-line-breaking) gäller också för denna jämförelse: att ändra teckensnitt, tillgänglig bredd, marginaler eller autofit‑inställningar kan ta bort den synliga skillnaden.

## **Ange Autofit‑typ för textramar**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att styra om texten krymper, flyter över eller om formen automatiskt anpassas. Följande exempel konfigurerar formen så att den ändras för att passa texten och sparar resultatet till "autofit_type.pptx".

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

För att räkna rader efter automatisk radbrytning och se hur text‑ eller formbredd förändrar resultatet, se [Räkna renderade rader](/slides/sv/java/manage-paragraph/). Endast radantal indikerar inte om texten överskrider sin behållare.

## **Ange ankare för textramar**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definierar hur text placeras vertikalt inuti en form, exempelvis högst upp, i mitten eller längst ner. Följande exempel förankrar texten till botten av den första formen och sparar resultatet till "text_anchor.pptx".

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

## **Ange tabulering för text**

Använd [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) och [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) för att konfigurera tabbstopp i ett stycke. Följande exempel sätter standardtabbsteg till 100 punkter och lägger till ett vänsterjusterat tabbstopp vid 30 punkter. Dessa inställningar påverkar text som innehåller tabulatort tecken.

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

## **Ange språk för korrekturläsning**

Aspose.Slides tillhandahåller [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), vilket låter dig ange korrekturläsningsspråk för en textdel. Korrekturläsningsspråket bestämmer vilket språk som används för stavnings‑ och grammatikkontroller i PowerPoint.

Följande exempel kräver "presentation.pptx" med en textruta som den första formen på den första bilden och minst ett stycke. Det ersätter innehållet i det första stycket med "1。", sätter SimSun som teckensnitt och tilldelar det förenklade kinesiska korrekturläsningsspråket (`zh-CN`). Det sparar resultatet till "proofing_language.pptx":

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

### **Kopiera språkmetadata**

När du kopierar flerspråkig text från en mall, bevara både [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) och [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Följande fristående exempel skapar en källtextdel med amerikansk engelska som språk och franska som alternativt språk och kopierar texten samt identifierarna till en del i en ny presentation.

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
    // Om källan inte har något alternativt språk, rensar null värdet i destinationen.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För att prova en källa utan alternativt språk, utelämna tilldelningen av `"fr-FR"`. Det alternativa identifieraren blir då `null`, och samma kopieringsrad bevarar dess frånvaro utan att införa ett standardvärde, även om destinationen tidigare hade ett alternativt språk tilldelat.

Dessa identifierare lagras som språkmetadata. Att bevara dem fastställer inte vilket ordboks språk PowerPoint väljer för stavnings‑ eller grammatikkontroller.

## **Ange standardspråk**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) för att definiera standardspråk för text som skapas vid inläsning eller skapande av en presentation. Följande exempel skapar en presentation med amerikansk engelska som standardspråk för text, lägger till en textruta och skriver ut `en-US` för dess första textdel.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en ny rektangulär form med text.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Kontrollera språk för den första textdelen.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ange standardtextstil**

För att tillämpa standardtextformatering på presentationsnivå, använd [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Följande exempel sätter ett 14‑punkts fet stil som standard för överordnade stycken i en ny presentation och sparar den till "default_text_style.pptx". Text kan ärva dessa standardvärden såvida inte mer specifik formatering åsidosätter dem.

```java 
import com.aspose.slides.*;

Presentation ... (rest omitted) 
```


## **Extrahera text med versaler‑effekt**

I PowerPoint gör att man applicerar **All Caps**‑teckenseffekten att texten visas i versaler på bilden även om den ursprungligen skrevs med gemener. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket exakt den text som matades in. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `All`.

Detta exempel kräver "sample2.pptx" med en textruta som den första formen på den första bilden. Dess första stycke‑första del innehåller "Hello, Aspose!" med All Caps‑effekten applicerad, som visas nedan.

![All Caps‑effekt](all_caps_effect.png)

Kodexemplet nedan visar hur man extraherar text med **All Caps**‑effekten applicerad:

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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar jag text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Iterera genom cellerna och uppdatera varje cell via [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) och styckeformatering via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Hur applicerar jag en gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text, använd [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Sätt [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) till [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.

Relaterad funktion: [Formatera text inom bilder](/slides/sv/features/text-formatting/).