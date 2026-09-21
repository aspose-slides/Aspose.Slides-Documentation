---
title: Hantera textfält i PowerPoint-presentationer i JavaScript
linktitle: Textfält
type: docs
weight: 52
url: /sv/nodejs-java/text-fields/
keywords:
- textfält
- automatisk text
- bildnummer
- datum och tid
- rubrik
- sidfot
- textportion
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa, inspektera, modifiera och ta bort textfält i PowerPoint-presentationer med Aspose.Slides för Node.js via Java. Bevara formatering och verifiera sparade PPTX- och PPT-filer."
---
## **Översikt**

Ett textavsnitt består av portioner. En vanlig [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) innehåller bokstavlig text; en fältportion har också ett [Field](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/field/) vars typ identifierar ett automatiskt uppdaterat värde, t.ex. ett bildnummer eller datum. Två portioner kan visa samma tecken medan endast en innehåller ett fält.

Använd [Portion.getField](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#getField) för att särskilja dem: den är `null` för vanlig text. [Portion.addField](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#addField) konverterar en befintlig portion till ett fält. Håll en etikett och dess dynamiska värde i separata portioner så att konvertering av värdet inte också ersätter etiketten.

Denna guide täcker fält i text, deras formatering och sparande i PPTX och PPT. För textramar och avsnitt, se [Manage Text](/slides/sv/nodejs-java/manage-text/).

## **Skapa ett bildnummerfält**

Det följande kompletta exemplet skapar en textruta som innehåller en bokstavlig `Slide `-etikett följt av ett automatiskt uppdaterat nummer. Det ställer in numrets storlek, vikt och färg innan fältet läggs till, öppnar sedan den sparade presentationen igen och kontrollerar fälttyp, text och formatering. Ingen indatafil krävs.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Den nya presentationen börjar med bildnummer 1, så texten är `Slide 1`, och båda kontrollerna skriver ut `true`. Numret förblir ett fält efter att presentationen öppnats igen; det är inte en bokstavlig `1`. Indexen i verifieringen hänvisar till formen och portionerna som skapats av detta exempel.

## **Välj en fälttyp**

[FieldType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/) tillhandahåller följande metoder för att hämta fördefinierade värden. Skicka det lämpliga värdet till [addField](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#addField).

| Metod | Syfte |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Det aktuella bildnumret. |
| [getDateTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Datum/tid i renderingsapplikationens standardformat. |
| [getDateTime1](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Fördefinierade datum- eller kombinerade datum/tidsformat. |
| [getDateTime10](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Fördefinierade tidsformat, med alternativ för sekunder och en 12‑timmesklocka. |
| [getHeader](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getHeader) | Ett huvudfält; se platshållaren och formatbegränsningarna nedan. |
| [getFooter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getFooter) | Ett sidfotfält. |

Till exempel representerar [getDateTime3](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getDateTime3) en dag, fullt månadsnamn och år på engelska. Detta är fördefinierade fältformat, inte godtyckliga datum‑formatsträngar. Språket som sätts med [setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) och applikationen som bearbetar presentationen kan påverka det visade resultatet.

## **Skapa ett fält från en intern sträng**

Sträng‑överladdningen av [addField](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#addField) accepterar en intern fältidentifierare. Använd den när du bevarar en identifierare som levererats av en annan applikation som saknar fördefinierat värde. Du kan också konstruera en [FieldType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/) från identifieraren. [FieldType.getInternalString](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fieldtype/#getInternalString) visar den identifieraren för inspektion.

Detta exempel lagrar ett applikationsspecifikt `custom-report-id`-fält med reservtexten `Report-042`. Identifieraren registrerar ingen beräkning: Aspose.Slides genererar inte rapport‑ID:n för en okänd typ. Applikationen som förstår denna identifierare måste tillhandahålla dess betydelse och uppdatera dess värde.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Efter denna PPTX‑rundresa är typen `custom-report-id` och texten `Report-042`. Att skicka en sträng som `yyyy-MM-dd` skulle namnge en fälttyp; den skulle inte konfigurera ett eget datumformat. För ett fast datum i ett godtyckligt format, använd vanlig text.

## **Inspektera, ändra och ta bort datum/tidsfält**

Ändra ett befintligt fält via [Field.setType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/field/#setType). Kontrollera att fältet finns innan du hämtar dess typ. För att stoppa automatiska uppdateringar, anropa [Portion.removeField](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#removeField). Detta behåller portionen och dess aktuella text samtidigt som fältassociationen tas bort. Om du behöver ett specifikt fast värde, tilldela den texten efter att ha tagit bort fältet.

För API‑inställningen som är kopplad till datum/tidsfältshantering, se [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Exemplet nedan använder ett explicit godkännandedatum när ett fält konverteras till vanlig text.

Ladda ner [sample.pptx](sample.pptx) och placera den i arbetskatalogen. Den innehåller två namngivna textrutor, `UpdatedAt` och `ApprovedDate`, vardera med ett datum/tidsfält, samt vanliga textetiketter. Följande exempel går igenom top‑nivå textrutor på vanliga bilder. Det ändrar datum/tidsfält till ett långt datumformat och gör dem kursiva, samtidigt som deras övriga formatering bevaras. Endast fält i `ApprovedDate` blir fast text.

Godkännandedatumet är 5 april 2030; JavaScript‑månadindex börjar på noll, så april är `3`. UTC används för både konstruktion och formatering för att hålla datumet oberoende av den lokala tidszonen.

Exemplet känner igen de inbyggda interna identifierarna `datetime` och `datetime1` till `datetime13`. Grupper, tabeller, anteckningar, layouter och master‑bilder kräver traversering av sina egna textbehållare och ligger utanför detta exempts omfattning.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Efter att ha öppnat igen har `UpdatedAt` typ `datetime3` och förblir dynamisk. `ApprovedDate` har inget fält och innehåller `05 April 2030`. Båda datum‑portionerna är kursiva, och deras ursprungliga teckenstorlek, fetstil och färg förblir intakta. De vanliga textetiketterna är oförändrade. Verifieringen läser den första portionen av de två kända formerna i det medföljande exemplet.

## **Bevara textformatering**

Arbeta med den befintliga portionen när du lägger till ett fält, ändrar dess typ eller tar bort det. Dessa operationer behåller portionens formatering. Använd [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#getPortionFormat) för att endast ändra de nödvändiga egenskaperna, som exemplen gör för färg eller kursiv.

Undvik att bygga om en hel textruta bara för att uppdatera ett fält: det kan leda till att de ursprungliga portionsgränserna och deras individuella formatering går förlorade. Skilj också på uttryckligen angiven formatering från formatering som ärvs från avsnittet, layouten eller temat. Se [Text Formatting](/slides/sv/nodejs-java/text-formatting/) för bredare formateringsalternativ.

## **Fält och platshållare för rubrik/sidfot**

Ett fält är en del av en textportion. En platshållare är en form med en presentationsroll, såsom en sidfot eller bildnummer. Att lägga till ett fält i en vanlig textruta förvandlar inte den formen till en platshållare.

Huvud‑/sidfotshanterarna styr platshållartext och synlighet på bilder, layouter och master‑bilder, inklusive spridning till beroende bilder. Ett nummerfält i en anpassad textruta kan därför vara användbart även när du inte använder bildnummer‑platshållaren. Omvänt tar inte förändring av platshållarens synlighet bort ett fält från en orelaterad textruta.

De fördefinierade huvud‑ och sidfotstyperna skapar inte motsvarande platshållare eller tillhandahåller deras innehåll. Specifikt har en vanlig PowerPoint‑bild ingen huvud‑platshållare; huvud är en del av anteckningssidor och utdelningar. Anta inte att ett huvud‑ eller sidfotfält i en godtycklig form automatiskt får den text som konfigurerats via en platshållarhanterare. För det arbetsflödet, se [Presentation Headers and Footers](/slides/sv/nodejs-java/presentation-header-and-footer/).

## **Begränsningar för PPTX och PPT**

Kontrollera både fälttypen och dess resulterande text efter sparande och öppning igen. Att bevara en identifierare bevisar inte att en applikation kan beräkna eller visa dess värde.

| Format | Fältbeteende och begränsningar |
|---|---|
| PPTX | Lagrar interna fältidentifierare tillsammans med fälttext. I rundreseskontroller överlevde de fördefinierade typerna och den anpassade identifieraren som användes ovan att sparas och öppnas igen. Den okända anpassade typen behöll sin reservtext; den fick ingen automatisk beräkningslogik. En annan applikation kan hantera ej stödjade identifierare på annat sätt. |
| PPT | Använder äldre fältrepresentationer och har mer begränsad kompatibilitet. I rundreseskontroller överlevde bildnummer‑ och fördefinierade datum/tidsfält att sparas och öppnas igen. Ett anpassat fält i en vanlig bildtextruta öppnades igen med sin identifierare men med `*` som text; ett huvud‑fält i samma sammanhang producerade också `*`. Lita inte på att anpassade fält eller ej stödjade fältkontexter behåller sin synliga text. |

För bärbar, fast utdata, konvertera ej stödjade fält till vanlig text och tilldela explicit det värde du vill ha innan du sparar. Detta bevarar den valda texten men stoppar avsiktligt automatiska uppdateringar. Testa även målapplikationen när dess egen fältomräkning är en del av ditt arbetsflöde.

## **FAQ**

**Hur kan jag avgöra om ett visat nummer eller datum är ett fält?**

Inspektera [Portion.getField](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#getField). Ett icke‑null‑värde identifierar ett fält; den visade texten ensam kan inte säga det.

**Tar bort ett fält bort dess text eller formatering?**

Nej. [removeField](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/#removeField) konverterar den befintliga portionen till vanlig text. Tilldela ett explicit värde efteråt om du behöver ett specifikt fryst datum eller reservtext.

**Kan en intern sträng definiera ett nytt datumformat eller en formel?**

Nej. Den identifierar en fälttyp. En okänd identifierare ger ingen evaluator eller datum‑formatmönster. Använd en stödjad fördefinierad typ eller formatera ett värde själv som vanlig text.

**Varför kontrollera en presentation igen efter att den sparats?**

Fältidentifierare, beräknad text och formatering är separata saker att verifiera. Formatkonvertering kan ändra det synliga resultatet även när fältidentifieraren fortfarande finns.