---
title: Hantera textfält i PowerPoint-presentationer på Android
linktitle: Textfält
type: docs
weight: 52
url: /sv/androidjava/text-fields/
keywords:
- textfält
- automatisk text
- bildnummer
- datum och tid
- sidhuvud
- sidfot
- textdel
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Skapa, inspektera, ändra och ta bort textfält i PowerPoint-presentationer med Aspose.Slides för Android via Java. Bevara formatering och verifiera sparade PPTX- och PPT-filer."
---
## **Översikt**

Ett textavsnitt består av delar. En vanlig [IPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/) innehåller bokstavlig text; en fältdel har också ett [IField](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifield/) vars typ identifierar ett automatiskt uppdaterat värde, såsom ett bildnummer eller datum. Två delar kan visa samma tecken medan endast en innehåller ett fält.

Använd [IPortion.getField](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#getField--) för att skilja dem åt: den är `null` för vanlig text. [IPortion.addField](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) konverterar en befintlig del till ett fält. Håll en etikett och dess dynamiska värde i separata delar så att konvertering av värdet inte också ersätter etiketten.

Denna guide täcker fält i text, deras formatering och sparande i PPTX och PPT. För textramar och stycken, se [Manage Text](/slides/sv/androidjava/manage-text/).

## **Skapa ett bildnummerfält**

Det följande kompletta exemplet skapar en textruta som innehåller en bokstavlig `Slide `-etikett följt av ett automatiskt uppdaterat nummer. Det sätter numrets storlek, vikt och färg innan fältet läggs till, öppnar sedan den sparade presentationen igen och kontrollerar fälttyp, text och formatering. Ingen indatafil krävs.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

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

Den nya presentationen börjar med bildnummer 1, så texten är `Slide 1`, och båda kontrollerna skriver ut `true`. Numret förblir ett fält efter att presentationen öppnats igen; det är inte en bokstavlig `1`. Omvandlingarna och indexen i verifieringen refererar till formen och delarna som skapats av detta exempel.

## **Välj en fälttyp**

[FieldType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/) implementerar [IFieldType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifieldtype/) och tillhandahåller följande metoder för att erhålla fördefinierade värden. Skicka det lämpliga värdet till [addField](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Metod | Syfte |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Det aktuella bildnumret. |
| [getDateTime](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Datum/tid i renderingsapplikationens standardformat. |
| [getDateTime1](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Fördefinierade datum‑ eller kombinerade datum/tidsformat. |
| [getDateTime10](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Fördefinierade tidsformat, med alternativ för sekunder och en 12‑timmarsklocka. |
| [getHeader](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Ett sidhuvudsfält; se platshållar‑ och formatbegränsningarna nedan. |
| [getFooter](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Ett sidfotfält. |

Till exempel representerar [getDateTime3](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) en dag, fullt månadsnamn och år på engelska. Detta är fördefinierade fältformat, inte godtyckliga Java‑datumformatsträngar. Språket som sätts med [setLanguageId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) och applikationen som bearbetar presentationen kan påverka det visade resultatet.

## **Skapa ett fält från en intern sträng**

Strängöverladdningen av [addField](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) accepterar en intern fältidentifierare. Använd den när du bevarar en identifierare som levererats av en annan applikation som saknar fördefinierat värde. Du kan också konstruera ett [FieldType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) från identifieraren. [IFieldType.getInternalString](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) avslöjar den identifieraren för inspektion.

Detta exempel lagrar ett applikationsspecifikt `custom-report-id`‑fält med reservtexten `Report-042`. Identifieraren registrerar ingen beräkning: Aspose.Slides genererar inte rapport‑ID:n för en okänd typ. Applikationen som förstår denna identifierare måste tillhandahålla dess betydelse och uppdatera dess värde.

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

Efter denna PPTX‑rundresa är typen `custom-report-id` och texten är `Report-042`. Att skicka en sträng som `yyyy-MM-dd` skulle namnge en fälttyp; den skulle inte konfigurera ett eget datumformat. För ett fast datum i ett godtyckligt format, använd vanlig text.

## **Inspektera, ändra och ta bort datum/tidsfält**

Ändra ett befintligt fält via [IField.setType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Kontrollera att fältet finns innan du kommer åt dess typ. För att stoppa automatiska uppdateringar, anropa [IPortion.removeField](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#removeField--). Detta behåller delen och dess nuvarande text samtidigt som fältkopplingen tas bort. Om du behöver ett specifikt fast värde, tilldela den texten efter att fältet tagits bort.

För API‑inställningen som är kopplad till datum/tidsfältshantering, se [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Exemplet nedan använder ett explicit godkännandedatum när ett fält konverteras till vanlig text.

Ladda ner [sample.pptx](sample.pptx) och placera den i arbetskatalogen. Den innehåller två namngivna txt‑former, `UpdatedAt` och `ApprovedDate`, var och en med ett datum/tids‑fält, plus vanliga textetiketter. Följande exempel går igenom top‑nivå txt‑former på vanliga bilder. Det ändrar datum/tids‑fält till ett långt datumformat och gör dem kursiva, samtidigt som övrig formatering bevaras. Endast fält i `ApprovedDate` blir fast text.

Exemplet känner igen de inbyggda interna identifierarna `datetime` och `datetime1` till `datetime13`. Grupper, tabeller, anteckningar, layouter och master‑former kräver traversering av sina egna textbehållare och ligger utanför detta exempels omfång.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

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
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
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

Efter att presentationen öppnats igen har `UpdatedAt` typen `datetime3` och förblir dynamisk. `ApprovedDate` har inget fält och innehåller `05 April 2030`. Båda datumdelarna är kursiva, och deras ursprungliga teckenstorlek, fetstil och färg förblir intakta. De vanliga textetiketterna är oförändrade. Verifieringen läser den första delen av de två kända formerna i det medföljande exemplet.

## **Bevara textformatering**

Arbeta med den befintliga delen när du lägger till ett fält, ändrar dess typ eller tar bort det. Dessa operationer behåller den delens formatering. Använd [IPortion.getPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#getPortionFormat--) för att ändra endast de nödvändiga egenskaperna, såsom exemplen gör för färg eller kursiv.

Undvik att bygga om en hel textram enbart för att uppdatera ett fält: det kan leda till att de ursprungliga delgränserna och deras individuella formatering går förlorade. Skilj också på explicit angiven formatering från formatering som ärvts från stycket, layouten eller temat. Se [Text Formatting](/slides/sv/androidjava/text-formatting/) för bredare formateringsalternativ.

## **Fält och platshållare för sidhuvud/sidfötter**

Ett fält är en del av en textdel. En platshållare är en form med en presentationsroll, t.ex. en sidfot eller ett bildnummer. Att lägga till ett fält i en vanlig textruta förvandlar inte den formen till en platshållare.

Huvud‑/sidfotshanterarna styr platshållartext och synlighet på bilder, layouter och master‑former, inklusive spridning till beroende bilder. Ett nummerfält i en anpassad textruta kan därför vara användbart även när du inte använder bildnummer‑platshållaren. Omvänt, att ändra platshållarens synlighet tar inte bort ett fält från en orelaterad textruta.

De fördefinierade huvud‑ och sidfotstyperna skapar inte de motsvarande platshållarna eller tillhandahåller deras innehåll. Speciellt har en vanlig PowerPoint‑bild ingen huvud‑platshållare; huvud finns på notssidor och utdelningsblad. Anta inte att ett huvud‑ eller sidfotfält i en godtycklig form automatiskt får den text som konfigurerats via en platshållarhanterare. För det arbetsflödet, se [Presentation Headers and Footers](/slides/sv/androidjava/presentation-header-and-footer/).

## **PPTX‑ och PPT‑begränsningar**

Kontrollera både fälttypen och dess resulterande text efter sparande och återöppning. Att bevara en identifierare bevisar inte att en applikation kan beräkna eller visa dess värde.

| Format | Fältbeteende och begränsningar |
|---|---|
| PPTX | Lagrar interna fältidentifierare tillsammans med fälttexten. Vid rundreses‑kontroller överlevde de fördefinierade typerna och den anpassade identifieraren som användes ovan att sparas och öppnas igen. Den okända anpassade typen behöll sin reservtext; den fick ingen automatisk beräkningslogik. En annan applikation kan behandla ostödda identifierare annorlunda. |
| PPT | Använder äldre fältrepresentationer och har mer begränsad kompatibilitet. Vid rundreses‑kontroller överlevde bildnummer‑ och fördefinierade datum/tidsfält att sparas och öppnas igen. Ett anpassat fält i en vanlig bildtextruta öppnades igen med sin identifierare men med `*` som text; ett huvudfält i samma kontext producerade också `*`. Lita inte på att anpassade fält eller icke‑stödda fältkontexter behåller sin synliga text. |

För portabelt, fast utdata, konvertera icke‑stödda fält till vanlig text och tilldela explicit det värde du vill ha innan du sparar. Detta bevarar den valda texten men stoppar avsiktligt automatiska uppdateringar. Testa även målapplikationen när dess egen fältomräkning är en del av ditt arbetsflöde.

## **FAQ**

**Hur kan jag se om ett visat nummer eller datum är ett fält?**

Inspektera [IPortion.getField](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#getField--). Ett icke‑null‑värde identifierar ett fält; den visade texten ensam kan inte säga det.

**Tar bort ett fält även bort dess text eller formatering?**

Nej. [removeField](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#removeField--) konverterar den befintliga delen till vanlig text. Tilldela ett explicit värde efteråt om du behöver ett särskilt fryst datum eller reservvärde.

**Kan en intern sträng definiera ett nytt datumformat eller en formel?**

Nej. Den identifierar en fälttyp. En okänd identifierare ger ingen evaluator eller ett Java‑datumformatmönster. Använd en stödd fördefinierad typ eller formatera ett värde själv som vanlig text.

**Varför kontrollera en presentation igen efter att den sparats?**

Fältidentifierare, beräknad text och formatering är separata saker att verifiera. Formatkonvertering kan ändra det synliga resultatet även när fältidentifieraren fortfarande finns.