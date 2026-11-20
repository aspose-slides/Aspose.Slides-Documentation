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
- teckenmellanrum
- teckensnittsegenskaper
- teckensnittsfamilj
- textrotation
- rotationsvinkel
- textram
- radavstånd
- autofit egenskap
- ankare för textram
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Formatera och stilisera text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java. Anpassa teckensnitt, färger, justering och mer."
---
## **Översikt**

Den här artikeln visar hur man formaterar text i PowerPoint‑ och OpenDocument‑presentationer med Aspose.Slides för Android via Java. Den täcker bakgrundsfärger, transparens, teckenmellanrum, teckensnittsegenskaper, rotation, styckeavstånd, autofit‑beteende, textankring, tabbstopp och språkinställningar.

Om inget annat anges använder exemplen [sample.pptx](sample.pptx). Den första formen på den första bilden är en textruta, och dess första stycke innehåller texten som visas nedan. Både bild‑ och formindex är nollbaserade. Exempel som markerar fet text använder effektiv formatering, inklusive ärvd fet formatering:

![Exempeltext](sample_text.png)

För att hitta och markera bokstavlig text eller reguljära uttryck‑matchningar, se [Search and Replace Text](/slides/sv/androidjava/search-and-replace-text/).

## **Ange bakgrundsfärg för text**

Använd [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) för att ange standardmarkeringsfärgen för ett stycke, eller använd [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) för enskilda textdelar.

Följande exempel anger en ljusgrå markering som standard för det första stycket. Explisita markeringsfärger på enskilda delar har företräde framför denna standard:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    //     // Ange markeringsfärgen för hela stycket.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det grå stycket](gray_paragraph.png)

Kodexemplet nedan visar hur man anger bakgrundsfärgen för **textdelar med ett fet stil**:

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
            //            // Ange markeringsfärgen för textdelen.
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

Använd [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) för att ange styckejustering i en textram. Värdet kan vara centrerad, vänsterjusterad, högjerjusterad, marginaljusterad med mera.

Följande kodexempel visar hur man justerar stycket till **centrum**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    //    // Ställ in styckejusteringen till centrum.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det justerade stycket](aligned_paragraph.png)

## **Justera teckensnitt inom en rad**

Använd [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) för att vertikalt justera textdelar med olika teckenstorlekar inom en rad. Denna inställning gäller hela stycket och styr justeringen inom varje rad.

Följande fristående exempel skapar fyra märkta textrutor på en bild. Varje stycke innehåller samma text i 18, 36 och 54 punkter, med olika teckenjustering. Det använder Arial, inaktiverar autofit och radbrytning samt håller textramarna tillräckligt stora för en enda rad.

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

Resultatet:

![Jämförelse av Baseline, Top, Center och Bottom teckenjustering med blandade teckenstorlekar](font_alignment.png)

Teckenjustering använder teckensnittets metriker, så de synliga kanterna på enskilda bokstäver nödvändigtvis inte ligger exakt på samma linje. Exemplet inkluderar både en versal bokstav och en nedgående del för att tydliggöra skillnaden mellan baseline‑ och bottom‑justering. Tillgängliga teckensnitt och ersättningar, de använda tecknen samt skillnaden i teckenstorlekar påverkar resultatet. Ramdimensioner, marginaler, radavstånd, radbrytning och autofit påverkar också layouten; använd samma teckensnitt och layoutinställningar när du jämför lägena.

Denna inställning skiljer sig från [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-), som styr horisontell styckejustering, och [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), som placerar textblocket vertikalt i sin form. Superskript‑ och subskript‑formatering via [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) flyttar enskilda delar relativt till baseline istället för att ange teckenjustering för styckets rader.

## **Ange transparens för text**

Texttransparens styrs via alfakomponenten i färgen som tilldelas [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). I exemplen nedan är `alpha = 50` ett ARGB‑alfavärde på skalan 0–255, inte en transparensprocent.

Kodexemplet nedan visar hur man tillämpar transparens på **hela stycket**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ställ in fyllnadsfärgen för texten till en transparent färg.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur man tillämpar transparens på **textdelar med ett fet stil**:

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
            //            // Ange transparensen för textdelen.
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

## **Ange teckenmellanrum för text**

Använd [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) för att bredda eller krympa mellanrummet mellan tecken i en textruta. Exemplen lägger till 3 punkter mellanrum; negativa värden krymper texten.

Följande Java‑kod visar hur man breddar teckenmellanrummet i **hela stycket**:

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

![Teckenmellanrummet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur man breddar teckenmellanrummet i **textdelar med ett fet stil**:

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

![Teckenmellanrummet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika teckensnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tajtare ut än samma text i PowerPoint. Detta kan bero på att PowerPoint ignorerar kerning‑data för vissa teckensnitt, även när teckensnittet innehåller giltig kerninginformation och kerning är aktiverad i PowerPoint‑inställningarna.

För att få den renderade utskriften närmare PowerPoint‑resultatet i sådana fall kan du inaktivera kerning för textdelar som använder det berörda teckensnittet. Ange [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) till ett värde som är större än den faktiska teckensnittsstorleken. Detta exempel kräver ”presentation.pptx” med en textruta som den första formen på den första bilden. Det kontrollerar effektiva teckensnittsnamn, inklusive ärvda teckensnitt, och sätter en tröskel på 100 punkter för delar som använder Roboto. Detta inaktiverar kerning för matchande delar med en teckenstorlek under 100 punkter:

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

För matchande text under tröskelvärdet förhindrar denna inställning kerning och kan hjälpa till att anpassa Aspose.Slides‑renderingen till PowerPoints visuella resultat för teckensnitt som påverkas av detta PowerPoint‑specifika beteende.

## **Hantera teckensnitts egenskaper för text**

Teckensnitts‑egenskaper kan sättas på styckennivå via [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) eller på enskilda delar via [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/).

Följande exempel sätter det första styckets standardteckensnitt till 12‑punkt Times New Roman med fet, kursiv och prickad understrykning. Explisit formatering på enskilda delar har företräde framför dessa standardvärden.

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

Följande exempel applicerar 13‑punkt Times New Roman, kursiv formatering och en prickad understrykning på delar vars effektiva formatering är fet:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ställ in teckensnittsegenskaper för textdelen.
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

## **Styr normalisering av teckenhöjd**

Använd [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) när du reproducerar mall‑typografi eller undersöker skillnader i teckenhöjd. I PowerPoint sträcker eller komprimerar aktivering av normalisering enskilda tecken vertikalt för att ge dem en enhetlig synlig höjd inom textdelen. Det garanterar inte lika texthöjder mellan olika teckensnitt.

Ange egenskapen till [NullableBool.True eller False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) för att explicit aktivera eller inaktivera normalisering. `NullableBool.NotDefined` lämnar den lokala inställningen odefinierad så att delen ärver värdet, exempelvis från styckets [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--). Det betyder inte `False`. Använd [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) och läs [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) för att erhålla det lösta Boolean‑värdet.

Följande fristående exempel kräver **Arial** installerat. Det skapar två textblock med samma versaler, gemener, nerhängande delar och akcentuerade tecken i 54 punkter. Båda styckena har normalisering aktiverad som standard. Den övre delen inaktiverar den explicit; den nedre ärver den. Ramstorlekar, marginaler och styckeavstånd är identiska, med radbrytning och autofit inaktiverade för att hålla jämförelsen konsekvent. Exemplet skriver ut `False: false` och `NotDefined: true` och sparar ”text_height_normalization.pptx”.

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

Jämförelsen nedan exporterades från den sparade presentationen. Den övre raden har normalisering inaktiverad (`False`); den nedre raden ärver den aktiverade inställningen (`NotDefined` → `True`). Behåll Arial installerat för att reproducera detta utseende.

![Arial‑text på 54 punkter med normalisering inaktiverad ovan och ärvd normalisering aktiverad nedan](text_height_normalization.png)

Normalisering ändrar teckenhöjd utan att ändra det tilldelade [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--)‑värdet, som specificerar teckensnittsstorlek i punkter. Stycke‑[setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) styr radavstånd, medan textram‑[setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) styr hur text eller dess behållare justeras för att passa. Dessa inställningar har olika syften och kan påverka layouten oberoende av varandra. För mer om styckeformatering och arv, se [Manage Paragraph](/slides/sv/androidjava/manage-paragraph/).

## **Applicera och ta bort genomstrykning**

Använd [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) på en textdel för att visa korrigeringar, annullerade termer eller tidigare priser utan att radera originaltexten. Ange den till [TextStrikethroughType.Single eller Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) för en eller två linjer genom texten.

För att ta bort genomstrykning, ange [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None). Detta inaktiverar effekten explicit, även om omgivande formatering specificerar genomstrykning. Däremot lämnar [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) den lokala inställningen odefinierad, så att delen kan ärva formatering, exempelvis från stycket. Det garanterar inte att genomstrykning tas bort. Använd [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) för att läsa den resulterande formateringen, inklusive ärvda värden.

Följande fristående exempel skapar tre prisjämförelser. Varje stycke har separata delar för etikett, tidigare pris och aktuellt pris, så endast det tidigare priset påverkas. Den första raden applicerar och sedan tar bort genomstrykning; de andra raderna behåller enkel respektive dubbel genomstrykning. Att ändra denna inställning bevarar texten och dess övriga formatering, inklusive det feta tidigare priset.

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

Resultatet, uppifrån och ner: ingen genomstrykning, enkel genomstrykning och dubbel genomstrykning.

![Tidigare priser utan genomstrykning, med enkel genomstrykning och med dubbel genomstrykning](strikethrough.png)

## **Ange textrotation**

Använd [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) för att ange en fördefinierad textorientering inom en form.

Följande kodexempel sätter textorienteringen i formen till [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/), vilket roterar texten **90 grader moturs**:

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

## **Ange anpassad rotation för textramar**

Använd [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) för att ange en egen rotationsvinkel för en [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).

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

Aspose.Slides tillhandahåller [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) och [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) för att kontrollera styckeavstånd. Dessa egenskaper används så här:

* Ange ett positivt värde för att specificera radavstånd som en procentandel av radens höjd.
* Ange ett negativt värde för att specificera radavstånd i punkter.

Följande exempel sätter avståndet inom det första stycket till 200 % av radens höjd (dubbel radavstånd):

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

![Radavstånd inom stycket](line_spacing.png)

## **Styr radbrytning**

Regler för radbrytning i stycken är användbara i smala textblock och presentationer som blandar latinsk och östasisk text. Följande metoder tillhör [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/), så de gäller ett helt stycke:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) styr latinska radbrytningsregler. I blandad text kan en ändring också påverka var angränsande östasiatisk text och skiljetecken bryts.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) styr östasiatiska radbrytningsregler, inklusive begränsningar för tecken i början och slutet av en rad.

Dessa regler ersätter inte [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), som möjliggör automatiskt radbrytning inom en textram. De påverkar layouten när radbrytning sker; de infogar inte radbrytningstecken. Ett explicit radbrytningstecken tvingar en ny rad inom stycket oberoende av tillgänglig bredd.

Följande fristående exempel skapar ett smalt textblock som innehåller kinesiska och latinska tecken. Det sätter båda radbrytningsalternativen explicit och sparar ”line_breaking.pptx”. För att experimentera med någon av reglerna, ändra motsvarande värde medan du behåller den andra inställningen oförändrad. Exemplet använder 24‑punkt Arial och SimSun med en rambredd på 160 punkter och noll horisontella textram‑marginaler. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) anropas med [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) så att textstorlek och ramdimensioner förblir fasta.

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

## **Styr hängande skiljetecken**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) låter behöriga skiljetecken sträcka sig utanför textlinjens högra kant istället för att placeras på nästa rad. Det gäller hela stycket och är annorlunda än ett hängande indrag.

Följande fristående exempel aktiverar hängande skiljetecken i en 100‑punkt bredd textram och sparar ”hanging_punctuation.pptx”. Med 24‑punkt Arial och noll horisontella textram‑marginaler ligger den sista punkten kvar efter ”sentence” och sträcker sig utanför den högra textkanten. Ange egenskapen till [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) för att jämföra: med dessa inställningar hamnar punkten på en separat rad. Radbrytning är aktiverad och autofit är inaktiverad för att hålla den tillgängliga bredden fast.

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

Inte varje skiljetecken kan hänga. [Teckensnitts‑ och layoutvillkoren som beskrivits ovan](#control-line-breaking) gäller också för denna jämförelse: att byta teckensnitt, tillgänglig bredd, marginaler eller autofit‑inställningar kan ta bort den synliga skillnaden.

## **Ange autofit‑typ för textramar**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att styra om texten ska krympas, överflöda eller om formen ska anpassas automatiskt. Följande exempel konfigurerar formen att anpassa storleken för att rymma sin text och sparar resultatet till ”autofit_type.pptx”.

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

För att räkna rader efter automatisk radbrytning och se hur text‑ eller formbredd förändrar resultatet, se [Count Rendered Lines](/slides/sv/androidjava/manage-paragraph/). Antalet rader indikerar inte i sig om texten överflödar sin behållare.

## **Ange ankare för textramar**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definierar hur text placeras vertikalt i en form, t.ex. ovanst, i mitten eller nederst. Följande exempel ankaretexten till botten av den första formen och sparar resultatet till ”text_anchor.pptx”.

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

## **Ange tabulatorer för text**

Använd [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) och [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) för att konfigurera tabbstopp i ett stycke. Följande exempel sätter standardtabbsteg till 100 punkter och lägger till ett vänsterjusterat tabbstopp vid 30 punkter. Dessa inställningar påverkar text som innehåller tabulatortecken.

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

![Stycke‑tabbar](paragraph_tabs.png)

## **Ange korrekturspråk**

Aspose.Slides tillhandahåller [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), vilket låter dig ange korrekturspråket för en textdel. Korrekturspråket bestämmer vilket språk som används för stavnings‑ och grammatikkontroller i PowerPoint.

Följande exempel kräver ”presentation.pptx” med en textruta som den första formen på den första bilden och minst ett stycke. Det ersätter det första styckets innehåll med ”1。”, sätter SimSun som teckensnitt och tilldelar det förenklade kinesiska korrekturspråket (`zh-CN`). Det sparar resultatet till ”proofing_language.pptx”:

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

    // Ange Id för ett korrekturspråk.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kopiera språkmetadata**

När du kopierar flerspråkig text från en mall, bevara både [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) och [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Följande fristående exempel skapar en källtextdel med amerikansk engelska som språk och franska som alternativt språk och kopierar texten och identifierarna till en del i en ny presentation.

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

För att testa en källa utan alternativt språk, utelämna tilldelningen av `"fr-FR"`. Det alternativa identifieraren blir då `null`, och samma kopieringsuttryck bevarar dess frånvaro utan att införa ett standardvärde, även om destinationen tidigare hade ett alternativt språk tilldelat.

Dessa identifierare lagrar språkmetadata. Att bevara dem fastställer inte vilket ordförråd PowerPoint väljer för stavnings‑ eller grammatikkontroller.

## **Ange standardspråk**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) för att definiera standardspråket för text som skapas när en presentation laddas eller skapas. Följande exempel skapar en presentation med amerikansk engelska som standardspråk för text, lägger till en textruta och skriver ut `en-US` för dess första textdel.

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

    // Kontrollera språk för den första textdelen.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ange standardtextstil**

För att applicera standardtextformatering på presentationsnivå, använd [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Följande exempel sätter ett 14‑punkt fet stil som standard för toppnivå‑stycken i en ny presentation och sparar den till ”default_text_style.pptx”. Text kan ärva dessa standardvärden såvida inte mer specifik formatering åsidosätter dem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Hämta styckeformat för översta nivån.
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

I PowerPoint får man texten att visas med **All Caps**‑effekt, vilket gör att texten visas i versaler på bilden även om den ursprungligen skrevs med gemener. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den matades in. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `All`.

Detta exempel kräver ”sample2.pptx” med en textruta som den första formen på den första bilden. Dess första stycke‑första del innehåller ”Hello, Aspose!” med All Caps‑effekt applicerad, som visas nedan.

![All Caps‑effekt](all_caps_effect.png)

Kodexemplet nedan visar hur man extraherar texten med **All Caps**‑effekt applicerad:

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

**Hur modifierar jag text i en tabell på en bild?**

För att modifiera text i en tabell på en bild, använd [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Iterera genom cellerna och uppdatera varje cell via [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) och styckeformatering via [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Hur applicerar jag en gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text, använd [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Ange [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) till [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.