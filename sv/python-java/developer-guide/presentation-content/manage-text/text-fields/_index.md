---
title: Hantera textfält i PowerPoint-presentationer i Python via Java
linktitle: Textfält
type: docs
weight: 52
url: /sv/python-java/text-fields/
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
- Python
- Java
- Aspose.Slides
description: "Skapa, inspektera, modifiera och ta bort textfält i PowerPoint-presentationer med Aspose.Slides för Python via Java. Bevara formatering och verifiera sparade PPTX- och PPT-filer."
---
## **Översikt**

Ett textavsnitt består av portioner. En vanlig [Portion](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/) innehåller bokstavlig text; en fältportion har också en [Field](https://reference.aspose.com/slides/sv/python-java/aspose.slides/field/) vars typ identifierar ett automatiskt uppdaterat värde, såsom ett bildnummer eller datum. Två portioner kan visa samma tecken medan endast en innehåller ett fält.

Använd [Portion.getField](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getField) för att särskilja dem: den är `None` för vanlig text. [Portion.addField](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#addField) konverterar en befintlig portion till ett fält. Håll en etikett och dess dynamiska värde i separata portioner så att konverteringen av värdet inte också ersätter etiketten.

Denna guide täcker fält i text, deras formatering och sparande i PPTX och PPT. För textramlar och -avsnitt, se [Hantera text](/slides/sv/python-java/manage-text/).

## **Skapa ett bildnummerfält**

Följande kompletta exempel skapar en textruta som innehåller en bokstavlig `Slide `-etikett följt av ett automatiskt uppdaterat tal. Det anger talets storlek, vikt och färg innan fältet läggs till, öppnar sedan den sparade presentationen igen och kontrollerar fälttyp, text och formatering. Ingen indatafil krävs.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Den nya presentationen startar med bildnummer 1, så texten blir `Slide 1`, och båda kontrollerna skriver ut `True`. Numret förblir ett fält efter återöppning; det är inte en bokstavlig `1`. Indexen i verifieringen hänvisar till formen och portionerna som skapades av detta exempel.

## **Välj en fälttyp**

[FieldType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/) tillhandahåller följande metoder för att erhålla fördefinierade värden. Skicka det lämpliga värdet till [addField](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#addField).

| Metod | Syfte |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getSlideNumber) | Det aktuella bildnumret. |
| [getDateTime](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getDateTime) | Datum/tid i renderingsapplikationens standardformat. |
| [getDateTime1](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getDateTime9) | Fördefinierade datum- eller kombinerade datum/tidsformat. |
| [getDateTime10](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getDateTime13) | Fördefinierade tidsformat, med alternativ för sekunder och en 12‑timmarsklocka. |
| [getHeader](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getHeader) | Ett sidhuvudfält; se platshållar- och formatbegränsningarna nedan. |
| [getFooter](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getFooter) | Ett sidfotsfält. |

Till exempel representerar [getDateTime3](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getDateTime3) en dag, fullt månadnamn och år på engelska. Detta är fördefinierade fältformat, inte godtyckliga Python-datumformatsträngar. Språket som ställs in med [setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseportionformat/#setLanguageId) och applikationen som bearbetar presentationen kan påverka det visade resultatet.

## **Skapa ett fält från en intern sträng**

Strängöverladdningen av [addField](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#addField) accepterar en intern fältidentifierare. Använd den när du bevarar en identifierare som levererats av en annan applikation som saknar fördefinierat värde. Du kan också konstruera en [FieldType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#FieldType) från identifieraren. [FieldType.getInternalString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fieldtype/#getInternalString) visar den identifieraren för inspektion.

Detta exempel lagrar ett applikationsspecifikt `custom-report-id`-fält med reservtexten `Report-042`. Identifieraren registrerar ingen beräkning: Aspose.Slides genererar inte rapport‑ID:n för en okänd typ. Applikationen som förstår denna identifierare måste tillhandahålla dess betydelse och uppdatera dess värde.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Efter denna PPTX‑rundresa är typen `custom-report-id` och texten `Report-042`. Att skicka en sträng som `yyyy-MM-dd` skulle namnge en fälttyp; den skulle inte konfigurera ett anpassat datumformat. För ett fast datum i ett godtyckligt format, använd vanlig text.

## **Inspektera, modifiera och ta bort datum/tid‑fält**

Ändra ett befintligt fält via [Field.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/field/#setType). Kontrollera att fältet finns innan du får åtkomst till dess typ. För att stoppa automatiska uppdateringar, anropa [Portion.removeField](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#removeField). Detta behåller portionen och dess aktuella text medan fältkopplingen tas bort. Om du behöver ett specifikt fast värde, tilldela den texten efter att ha tagit bort fältet.

För API‑inställningen som är associerad med datum/tid‑fältbearbetning, se [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#setCurrentDateTime). Exemplet nedan använder ett explicit godkännandedatum när ett fält konverteras till vanlig text.

Ladda ner [sample.pptx](sample.pptx) och placera den i arbetskatalogen. Den innehåller två namngivna textramar, `UpdatedAt` och `ApprovedDate`, var och en med ett datum/tid‑fält, samt vanliga textetiketter. Följande exempel går igenom top‑nivå textramar på vanliga bilder. Det ändrar datum/tid‑fält till ett långt datumformat och gör dem kursiva, samtidigt som annan formatering bevaras. Endast fält i `ApprovedDate` blir fast text.

Exemplet känner igen de inbyggda interna identifierarna `datetime` och `datetime1` till `datetime13`. Grupper, tabeller, anteckningar, layouter och master‑bilder kräver traversering av sina egna textbehållare och ligger utanför detta exempel.

```python
import re
from datetime import date

import jpake
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Använd engelska månadsnamn oberoende av systemets språk.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Efter återöppning har `UpdatedAt` typen `datetime3` och förblir dynamisk. `ApprovedDate` har inget fält och innehåller `05 April 2030`. Båda datumportionerna är kursiva, och deras ursprungliga teckenstorlek, fetstil och färg förblir intakta. De vanliga textetiketterna är oförändrade. Verifieringen läser den första portionen av de två kända formerna i det medföljande exemplet.

## **Bevara textformatering**

Arbeta med den befintliga portionen när du lägger till ett fält, ändrar dess typ eller tar bort det. Dessa operationer behåller portionens formatering. Använd [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getPortionFormat) för att ändra endast de nödvändiga egenskaperna, som exemplen gör för färg eller kursiv.

Undvik att bygga om en hel textram bara för att uppdatera ett fält: det kan leda till förlust av de ursprungliga portionsgränserna och deras individuella formatering. Skilj också på explicit inställd formatering från formatering som ärvs från stycke, layout eller tema. Se [Text Formatting](/slides/sv/python-java/text-formatting/) för bredare formateringsalternativ.

## **Fält och platshållare för sidhuvud/sidfot**

Ett fält är en del av en textportion. En platshållare är en form med en presentationsroll, såsom en sidfot eller bildnummer. Att lägga till ett fält i en vanlig textruta gör inte formen till en platshållare.

Sidhuvuds-/sidfots‑hanterarna styr platshållartext och synlighet på bilder, layouter och master‑bilder, inklusive spridning till beroende bilder. Ett nummerfält i en anpassad textruta kan därför vara användbart även om du inte använder bildnummer‑platshållaren. Omvänt tar förändring av platshållarens synlighet inte bort ett fält från en orelaterad textruta.

De fördefinierade sidhuvuds‑ och sidfots‑typerna skapar inte motsvarande platshållare eller tillhandahåller deras innehåll. Speciellt har en vanlig PowerPoint‑bild ingen sidhuvuds‑platshållare; sidhuvuden tillhör anteckningssidor och utdelningar. Anta inte att ett sidhuvuds‑ eller sidfotsfält i en godtycklig form automatiskt får den text som konfigurerats via en platshållarhanterare. För det arbetsflödet, se [Presentation Headers and Footers](/slides/sv/python-java/presentation-header-and-footer/).

## **PPTX‑ och PPT‑begränsningar**

Kontrollera både fälttypen och dess resulterande text efter sparande och återöppning. Att bevara en identifierare bevisar inte att en applikation kan beräkna eller visa dess värde.

| Format | Fältbeteende och begränsningar |
|---|---|
| PPTX | Lagrar interna fältidentifierare tillsammans med fälttexten. I rundresa‑kontroller överlevde de fördefinierade typerna och den anpassade identifieraren som användes ovan sparning och återöppning. Den okända anpassade typen behöll sin reservtext; den fick ingen automatisk beräkningslogik. En annan applikation kan hantera ej stödjade identifierare på ett annat sätt. |
| PPT | Använder äldre fältrepresentationer och har mer begränsad kompatibilitet. I rundresa‑kontroller överlevde bildnummer‑ och fördefinierade datum/tid‑fält sparning och återöppning. Ett anpassat fält i en vanlig bildtextruta öppnades igen med sin identifierare men med `*` som text; ett sidhuvuds‑fält i samma kontext producerade också `*`. Räkna inte med att anpassade fält eller ej‑stödda fältkontexter behåller sin synliga text. |

För portabel, fast utdata, konvertera ej‑stödda fält till vanlig text och tilldela explicit det värde du önskar innan sparning. Detta bevarar den valda texten men stoppar avsiktligt automatiska uppdateringar. Testa även målapplikationen när dess egna fältomräkningar ingår i ditt arbetsflöde.

## **FAQ**

**Hur kan jag avgöra om ett visat nummer eller datum är ett fält?**

Inspektera [Portion.getField](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#getField). Ett värde som inte är `None` identifierar ett fält; den visade texten ensam kan inte säga dig det.

**Tar bort ett fält bort dess text eller formatering?**

Nej. [removeField](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portion/#removeField) konverterar den befintliga portionen till vanlig text. Tilldela ett explicit värde efteråt om du behöver ett specifikt fruset datum eller en reservtext.

**Kan en intern sträng definiera ett nytt datumformat eller en formel?**

Nej. Den identifierar en fälttyp. En okänd identifierare ger ingen evaluator eller ett Python‑datumformatmönster. Använd en understödd fördefinierad typ eller formatera ett värde själv som vanlig text.

**Varför kontrollera en presentation igen efter att den sparats?**

Fältidentifierare, beräknad text och formatering är separata saker att verifiera. Formatkonvertering kan förändra det synliga resultatet även om fältidentifieraren fortfarande finns.