---
title: Automatisera presentationens lokalisering på Android
linktitle: Presentation Lokalisering
type: docs
weight: 100
url: /sv/androidjava/presentation-localization/
keywords:
- byta språk
- stavningskontroll
- undertrycka stavningskontroll
- korrekturspråk
- språk-id
- flerspråkig text
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Ställ in korrekturspråk för PowerPoint- och OpenDocument-presentationstext på Android med Aspose.Slides för Android via Java, inklusive standardvärden och flerspråkiga stycken."
---
## **Översikt**

Aspose.Slides för Android via Java låter dig konfigurera korrekturmetadata för enskilda textdelar. Använd [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) för att identifiera korrekturspråket, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) för att tillåta eller undertrycka stavningskontroller, och [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) för att styra det bredare "ingen korrektur"-tillståndet. Eftersom dessa inställningar tillämpas på delnivå kan ett stycke innehålla flera språk och olika korrekturregler.

Denna artikel förklarar hur du tilldelar ett språk till specifik text, anger standardspråket för ny text med [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), bygger flerspråkiga stycken, väljer mellan `SpellCheck` och `ProofDisabled`, samt bevarar de avsedda inställningarna när du använder [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Dessa egenskaper lagrar metadata för presentationsprogram; de översätter inte text, utför inte ordboksbaserad stavningskontroll eller returnerar felstavade ord.

## **Ange korrekturspråk för text**

Skapa eller läs in en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/), få åtkomst till den önskade textdelen via [IPortion.getPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#getPortionFormat--), och tilldela dess språkidentifierare. Följande exempel skapar en form, anger brittisk engelska som korrekturspråk och sparar resultatet med [Presentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange standardspråk för ny text**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) för att ange vilket korrekturspråk Aspose.Slides ska tilldela ny skapad text. Denna inställning är användbar när det mesta eller hela nya textinnehållet i en presentation använder samma språk. Den ändrar inte språkmetadata för text som redan har ett explicit språk.

Följande exempel skapar en presentation där ny text använder tyska korrekturregler:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Använd flera språk i ett stycke**

Ett [IParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/) innehåller en samling textdelar. Skapa en separat [Portion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portion/) för varje språk och ange dess `LanguageId` oberoende.

Detta exempel skapar ett stycke med engelska och franska delar:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aktivera eller undertrycka stavningskontroll för enskilda delar**

[IPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportionformat/) ärver de gemensamma textegenskaper som definieras av [IBasePortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/). Få åtkomst till en parts format via [IPortion.getPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#getPortionFormat--) och använd [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) för att styra om ett presentationsprogram får göra stavningskontroll för den delen. Standardvärdet är `false`: `true` tillåter stavningskontroll, medan `false` undertrycker den.

Inställningen gäller enskilda textdelar. Olika delar i samma stycke kan därför använda olika värden. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) och `setSpellCheck` har kompletterande syften: `setLanguageId` identifierar korrekturspråket, medan `setSpellCheck` bestämmer om stavningskontroller är tillåtna för delen.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) styr också korrektur, men den representerar det bredare "gör inte korrektur"-tillståndet som en [NullableBool](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/nullablebool/). Använd `setSpellCheck` när du behöver en direkt boolesk växel specifikt för stavningskontroller. Använd `setProofDisabled` när du behöver bevara eller uttryckligen styra presentationens ingen-korrektur-metadata, inklusive dess `NotDefined`-tillstånd. Om du anger båda egenskaperna, håll deras värden konsekventa; kombinera inte `setSpellCheck(true)` med `setProofDisabled(NullableBool.True)`.

Dessa egenskaper konfigurerar korrekturmetadata som används av PowerPoint och andra presentationsprogram. Aspose.Slides använder dem inte för att utföra ordboksbaserad stavningskontroll eller returnera en lista över felstavade ord.

Följande kompletta exempel skapar en inmatningspresentation, läser in den, tilldelar olika stavningskontrollinställningar och korrekturspråk till två delar i samma stycke, sparar resultatet, öppnar det igen och verifierar de lagrade värdena:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) kombinerar intilliggande delar som har samma formatering. En skillnad i bara `SpellCheck` håller inte sådana delar separata; efter att de har slagits samman behåller den resulterande delen `SpellCheck`-värdet från den första delen. Om delar behöver olika stavningskontrollinställningar, anropa `joinPortionsWithSameFormatting` innan du tilldelar dessa inställningar, eller inspektera de resulterande delgränserna och återapplicera inställningarna efteråt. Delar med olika `LanguageId`-värden förblir separata eftersom deras korrekturspråksformatering skiljer sig.

## **FAQ**

**Översätter ett språk-ID texten?**

Nej. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) lagrar korrekturmetadata för stavning och grammatik; den ändrar inte textinnehållet. Översätt texten separat och ange sedan rätt språkidentifierare för varje översatt del.

**Styr korrekturspråket teckensnitt, bindestreckning eller radbrytning?**

Nej. Språkidentifieraren är avsedd för korrektur. Textrendering och layout beror främst på tillgängliga [fonts](/slides/sv/androidjava/powerpoint-fonts/), skriftsystemet och inställningarna för textramen. För pålitlig rendering, tillhandahåll de erforderliga teckensnitten, konfigurera [font substitution](/slides/sv/androidjava/font-substitution/) eller [embed fonts](/slides/sv/androidjava/embedded-font/) i presentationen.

**Kan ett stycke använda flera korrekturspråk?**

Ja. Tilldela varje språk till en separat del, som visas i exemplet med flerspråkigt stycke.

**Bör jag använda `setDefaultTextLanguage` eller `setLanguageId`?**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) när du vill ha ett standardvärde för ny skapad text. Använd [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) när en specifik del behöver ett explicit korrekturspråk eller när ett stycke innehåller flera språk.