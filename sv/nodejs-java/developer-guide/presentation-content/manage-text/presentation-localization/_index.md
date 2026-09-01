---
title: Automatisera lokalisering av presentationer i JavaScript
linktitle: Presentationens lokalisering
type: docs
weight: 100
url: /sv/nodejs-java/presentation-localization/
keywords:
- byta språk
- stavningskontroll
- undertrycka stavningskontroll
- korrekturspråk
- språks-ID
- flerspråkig text
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ställ in korrekturspråk för PowerPoint- och OpenDocument-presentationstext i JavaScript med Aspose.Slides, inklusive standardvärden och flerspråkiga stycken."
---
## **Översikt**

Aspose.Slides för Node.js via Java låter dig konfigurera korrekturmetadata för enskilda textdelar. Använd [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) för att identifiera korrekturspråket, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) för att tillåta eller undertrycka stavningskontroller och [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) för att kontrollera det bredare ingen‑korrigering‑tillståndet. Eftersom dessa inställningar tillämpas på delnivå kan ett stycke innehålla flera språk och olika korrekturregler.

Den här artikeln förklarar hur du tilldelar ett språk till specifik text, anger standardspråket för ny text med [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), skapar flerspråkiga stycken, väljer mellan `SpellCheck` och `ProofDisabled` och bevarar de avsedda inställningarna när du använder [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Dessa egenskaper lagrar metadata för presentationsprogram; de översätter inte text, utför inte ordboksbaserad stavningskontroll eller returnerar felstavade ord.

## **Ange korrekturspråk för text**

Skapa eller öppna en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/), få åtkomst till den önskade textdelen via [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#getPortionFormat-- ) och tilldela dess språksidentifierare. Följande exempel skapar en form, anger brittisk engelska som korrekturspråk och sparar resultatet med [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange standardspråk för ny text**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) för att ange korrekturspråket som Aspose.Slides tilldelar ny skapad text. Denna inställning är användbar när det mesta eller hela den nya texten i en presentation använder samma språk. Den ändrar inte språkmetadata för text som redan har ett explicit språk.

Följande exempel skapar en presentation där den nya texten använder tyska korrekturregler:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Använd flera språk i ett stycke**

Ett [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) innehåller en samling av textdelar. Skapa en separat [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) för varje språk och sätt dess `LanguageId` oberoende av varandra.

Detta exempel skapar ett stycke med engelska och franska delar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aktivera eller undertryck stavningskontroll för enskilda delar**

[PortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/) ärver de gemensamma textegenskaperna som definieras av [BasePortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/). Få åtkomst till en portions format via [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#getPortionFormat--) och använd [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) för att styra om ett presentationsprogram får kontrollera stavning för den delen. Standardvärdet är `false`: `true` tillåter stavningskontroll, medan `false` undertrycker den.

Inställningen gäller för enskilda textdelar. Olika delar i samma stycke kan därför använda olika värden. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) och `setSpellCheck` har kompletterande syften: `setLanguageId` identifierar korrekturspråket, medan `setSpellCheck` bestämmer om stavningskontroller är tillåtna för delen.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) styr också korrektur, men den representerar det bredare "do not proof"‑tillståndet som en [NullableBool](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/nullablebool/). Använd `setSpellCheck` när du behöver en direkt Boolesk växel specifikt för stavningskontroller. Använd `setProofDisabled` när du behöver bevara eller explicit kontrollera presentationens ingen‑korrigering‑metadata, inklusive dess `NotDefined`‑tillstånd. Om du anger båda egenskaperna, håll deras värden konsekventa; kombinera inte `setSpellCheck(true)` med `setProofDisabled(NullableBool.True)`.

Dessa egenskaper konfigurerar korrekturmetadata som används av PowerPoint och andra presentationsprogram. Aspose.Slides använder dem inte för att utföra ordboksbaserad stavningskontroll eller returnera en lista över felstavade ord.

Följande kompletta exempel skapar en inmatningspresentation, laddar den, tilldelar olika stavningskontrollinställningar och korrekturspråk till två delar i samma stycke, sparar resultatet, öppnar det igen och verifierar de lagrade värdena:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) kombinerar intilliggande delar som har samma formatering. En skillnad i `SpellCheck` ensam håller inte sådana delar separata; efter att de har kombinerats behåller den resulterande delen `SpellCheck`‑värdet från den första delen. Om delar behöver olika stavningskontrollinställningar, anropa `joinPortionsWithSameFormatting` innan du tilldelar dessa inställningar, eller inspektera de resulterande delgränserna och återapplicera inställningarna efteråt. Delar med olika `LanguageId`‑värden förblir separata eftersom deras korrektur‑språkformatering skiljer sig.

## **FAQ**

**Översätter ett språk-ID texten?**

Nej. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) lagrar korrekturmetadata för stavning och grammatik; den ändrar inte textinnehållet. Översätt texten separat och ange sedan rätt språkidentifierare för varje översatt del.

**Styr korrekturspråket typsnitt, bindestreck eller radbrytning?**

Nej. Språkidentifieraren är avsedd för korrektur. Textrendering och layout beror främst på tillgängliga [fonts](/slides/sv/nodejs-java/powerpoint-fonts/), skriftsystemet och inställningarna för textramen. För pålitlig rendering, tillhandahåll de nödvändiga typsnitten, konfigurera [font substitution](/slides/sv/nodejs-java/font-substitution/) eller [embed fonts](/slides/sv/nodejs-java/embedded-font/) i presentationen.

**Kan ett stycke använda flera korrekturspråk?**

Ja. Tilldela varje språk till en separat del, som visas i exemplet med flerspråkigt stycke.

**Ska jag använda `setDefaultTextLanguage` eller `setLanguageId`?**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) när du vill ha ett standardvärde för ny skapad text. Använd [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) när en specifik del behöver ett explicit korrekturspråk eller när ett stycke innehåller flera språk.