---
title: Hantera textfält i PowerPoint-presentationer i Java
linktitle: Textfält
type: docs
weight: 52
url: /sv/java/text-fields/
keywords:
- textfält
- automatisk text
- bildnummer
- datum och tid
- sidhuvud
- sidfot
- textportion
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Skapa, inspektera, ändra och ta bort textfält i PowerPoint-presentationer med Aspose.Slides för Java. Bevara formatering och verifiera sparade PPTX- och PPT-filer."
---
## **Översikt**

Ett textstycke består av portioner. En vanlig [IPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/) innehåller bokstavlig text; en fältportion har även ett [IField](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifield/) vars typ identifierar ett automatiskt uppdaterat värde, till exempel ett bildnummer eller ett datum. Två portioner kan visa samma tecken medan endast en innehåller ett fält.

Använd [IPortion.getField](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#getField--) för att skilja dem åt: den är `null` för vanlig text. [IPortion.addField](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) konverterar en befintlig portion till ett fält. Håll en etikett och dess dynamiska värde i separata portioner så att konverteringen av värdet inte också ersätter etiketten.

Denna guide behandlar fält i text, deras formatering och hur de sparas i PPTX och PPT. För textramar och stycken, se [Manage Text](/slides/sv/java/manage-text/).

## **Skapa ett bildnummerfält**

Det följande kompletta exemplet skapar en textruta som innehåller en bokstavlig `Slide `‑etikett följt av ett automatiskt uppdaterat nummer. Det sätter numrets storlek, tjocklek och färg innan fältet läggs till, öppnar sedan den sparade presentationen igen och kontrollerar fälttyp, text och formatering. Ingen indatafil krävs.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Den nya presentationen börjar med bildnummer 1, så texten blir `Slide 1`, och båda kontrollerna skriver ut `true`. Numret förblir ett fält efter att presentationen öppnats igen; det är inte en bokstavlig `1`. Kastningarna och indexen i verifieringen hänvisar till formen och de portioner som skapats av detta exempel.

## **Välj en fälttyp**

[FieldType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/) implementerar [IFieldType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifieldtype/) och tillhandahåller följande metoder för att erhålla fördefinierade värden. Skicka lämpligt värde till [addField](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Metod | Syfte |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Det aktuella bildnumret. |
| [getDateTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getDateTime--) | Datum/tid i det rendering‑program som används standardformat. |
| [getDateTime1](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getDateTime9--) | Fördefinierade datum‑ eller kombinerade datum/tids‑format. |
| [getDateTime10](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getDateTime13--) | Fördefinierade tidsformat med alternativ för sekunder och 12‑timmarsklocka. |
| [getHeader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getHeader--) | Ett sidhuvudfält; se platshållare‑ och formatbegränsningarna nedan. |
| [getFooter](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getFooter--) | Ett sidfotfält. |

Till exempel representerar [getDateTime3](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#getDateTime3--) en dag, fullständigt månadsnamn och år på engelska. Detta är fördefinierade fältformat, inte godtyckliga Java‑datumformatsträngar. Språket som sätts med [setLanguageId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) och programmet som bearbetar presentationen kan påverka det visade resultatet.

## **Skapa ett fält från en intern sträng**

Den sträng‑överladdade versionen av [addField](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#addField-java.lang.String-) accepterar en intern fältidentifierare. Använd den när du vill bevara en identifierare som levererats av ett annat program och som saknar fördefinierat värde. Du kan också konstruera ett [FieldType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) från identifieraren. [IFieldType.getInternalString](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifieldtype/#getInternalString--) exponerar den identifieraren för granskning.

Detta exempel lagrar ett applikationsspecifikt fält `custom-report-id` med reservtexten `Report-042`. Identifieraren registrerar ingen beräkning: Aspose.Slides genererar inte rapport‑ID för en okänd typ. Applikationen som förstår identifieraren måste tillhandahålla dess betydelse och uppdatera dess värde.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Efter denna PPTX‑rundresa är typen `custom-report-id` och texten `Report-042`. Att skicka en sträng som `yyyy-MM-dd` skulle namnge en fälttyp; den skulle inte konfigurera ett eget datumformat. För ett fast datum i ett godtyckligt format, använd vanlig text.

## **Inspektera, ändra och ta bort datum‑/tidsfält**

Ändra ett befintligt fält via [IField.setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Kontrollera att fältet finns innan du läser dess typ. För att stoppa automatiska uppdateringar, anropa [IPortion.removeField](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#removeField--). Detta behåller portionen och dess nuvarande text medan fältassociationen tas bort. Om du behöver ett specifikt fast värde, tilldela den texten efter att fältet tagits bort.

För API‑inställningen som är kopplad till datum‑/tidsfält, se [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Exemplet nedan använder ett explicit godkännandedatum när ett fält konverteras till vanlig text.

Ladda ner [sample.pptx](sample.pptx) och placera den i arbetskatalogen. Den innehåller två namngivna textrutor, `UpdatedAt` och `ApprovedDate`, var och en med ett datum‑/tidsfält samt vanliga textetiketter. Följande exempel går igenom top‑nivå‑textrutor på vanliga bilder. Det ändrar datum‑/tidsfält till ett långt datumformat och gör dem kursiva, samtidigt som annan formatering bevaras. Endast fält i `ApprovedDate` blir fast text.

Den inbyggda identifieraren `datetime` samt `datetime1`‑`datetime13` känns igen. Grupper, tabeller, anteckningar, layouter och master‑bilder kräver traversering av sina egna textbehållare och ligger utanför detta exempel.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        String fixedDate = approvalDate.format(dateFormat);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Efter att presentationen öppnats igen har `UpdatedAt` typ `datetime3` och förblir dynamisk. `ApprovedDate` har inget fält och innehåller `05 April 2030`. Båda datumportionerna är kursiva, och deras ursprungliga teckenstorlek, fetstil och färg är intakta. De vanliga textetiketterna är oförändrade. Verifieringen läser den första portionen i de två kända formerna i medföljande exempel.

## **Bevara textformatering**

Arbeta med den befintliga portionen när du lägger till ett fält, ändrar dess typ eller tar bort det. Dessa operationer behåller portionens formatering. Använd [IPortion.getPortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#getPortionFormat--) för att bara ändra de egenskaper som behövs, som exemplen gör för färg eller kursivering.

Undvik att bygga om hela textramen bara för att uppdatera ett fält: det kan leda till att originalportionernas gränser och deras individuella formatering går förlorade. Skilj också på explicit angiven formatering och formatering som ärvs från stycket, layouten eller temat. Se [Text Formatting](/slides/sv/java/text-formatting/) för bredare formateringsalternativ.

## **Fält och platshållare för sidhuvud/sidfot**

Ett fält är en del av en textportion. En platshållare är en form med en presentationsroll, till exempel en sidfot eller ett bildnummer. Att lägga till ett fält i en vanlig textruta förvandlar inte formen till en platshållare.

Platshållar‑hanterarna styr platshållartext och synlighet på bilder, layouter och master‑bilder, inklusive spridning till beroende bilder. Ett nummerfält i en anpassad textruta kan därför vara användbart även när du inte använder bildnummer‑platshållaren. Omvänt tar inte en förändring av platshållarens synlighet bort ett fält från en orelaterad textruta.

De fördefinierade sidhuvuds‑ och sidfots‑typerna skapar inte motsvarande platshållare eller tillhandahåller deras innehåll. Speciellt har en vanlig PowerPoint‑bild ingen sidhuvuds‑platshållare; sidhuvuden tillhör notssidor och utdelningar. Anta inte att ett sidhuvuds‑ eller sidfots‑fält i en godtycklig form automatiskt får den text som konfigurerats via en platshållar‑hanterare. För det arbetsflödet, se [Presentation Headers and Footers](/slides/sv/java/presentation-header-and-footer/).

## **Begränsningar för PPTX och PPT**

Kontrollera både fälttyp och resulterande text efter sparande och återöppning. Att bevara en identifierare bevisar inte att en applikation kan beräkna eller visa dess värde.

| Format | Fältbeteende och begränsningar |
|---|---|
| PPTX | Lagrar interna fältidentifierare tillsammans med fälttext. Vid rundresor överlevde de fördefinierade typerna och den anpassade identifieraren som användes ovan. Den okända anpassade typen behöll sin reservtext; den fick ingen automatisk beräkningslogik. Ett annat program kan hantera icke‑stödda identifierare på annat sätt. |
| PPT | Använder äldre fältrepresentationer och har mer begränsad kompatibilitet. Vid rundresor överlevde bildnummer‑ och fördefinierade datum‑/tidsfält. Ett anpassat fält i en vanlig textbox öppnades med sin identifierare men med `*` som text; ett sidhuvudsfält i samma kontext producerade också `*`. Lita inte på att anpassade fält eller icke‑stödda fältkontexter behåller sin synliga text. |

För portabel, fast output, konvertera icke‑stödda fält till vanlig text och tilldela explicit det värde du vill ha innan du sparar. Detta bevarar den valda texten men stoppar automatiska uppdateringar avsiktligt. Testa även målprogrammet när dess egna fält‑omräkningar är en del av ditt arbetsflöde.

## **FAQ**

**Hur kan jag avgöra om ett visat nummer eller datum är ett fält?**

Inspektera [IPortion.getField](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#getField--). Ett icke‑null‑värde identifierar ett fält; enbart den visade texten kan inte säga det.

**Tar borttagning av ett fält bort dess text eller formatering?**

Nej. [removeField](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#removeField--) konverterar den befintliga portionen till vanlig text. Tilldela ett explicit värde efteråt om du behöver ett specifikt fryst datum eller reservtext.

**Kan en intern sträng definiera ett nytt datumformat eller en formel?**

Nej. Den identifierar en fälttyp. En okänd identifierare ger ingen evaluator eller ett Java‑datumformat. Använd en stödjande fördefinierad typ eller formatera värdet själv som vanlig text.

**Varför kontrollera en presentation igen efter att den sparats?**

Fältidentifierare, beräknad text och formatering är separata saker att verifiera. Formatkonvertering kan ändra det synliga resultatet även när fältidentifieraren fortfarande finns.