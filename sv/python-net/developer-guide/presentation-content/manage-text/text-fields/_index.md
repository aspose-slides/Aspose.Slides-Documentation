---
title: Hantera textfält i PowerPoint-presentationer i Python
linktitle: Textfält
type: docs
weight: 52
url: /sv/python-net/text-fields/
keywords:
- textfält
- automatisk text
- bildnummer
- datum och tid
- rubrik
- sidfot
- textdel
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Skapa, inspektera, ändra och ta bort textfält i PowerPoint-presentationer med Aspose.Slides för Python via .NET. Bevara formatering och verifiera sparade PPTX- och PPT-filer."
---
## **Översikt**

Ett textstycke består av delar. En vanlig [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/) innehåller bokstavlig text; en fältdel har också ett [Field](https://reference.aspose.com/slides/sv/python-net/aspose.slides/field/) vars typ identifierar ett automatiskt uppdaterat värde, till exempel ett bildnummer eller datum. Två delar kan visa samma tecken medan endast en innehåller ett fält.

Använd [Portion.field](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/field/) för att skilja dem åt: den är `None` för vanlig text. [Portion.add_field](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/add_field/) konverterar en befintlig del till ett fält. Behåll en etikett och dess dynamiska värde i separata delar så att konvertering av värdet inte också ersätter etiketten.

Denna guide täcker fält i text, deras formatering och hur man sparar dem i PPTX och PPT. För textramar och stycken, se [Manage Text](/slides/sv/python-net/manage-text/).

## **Skapa ett bildnummerfält**

Det följande kompletta exemplet skapar en textruta som innehåller en bokstavlig `Slide `-etikett följd av ett automatiskt uppdaterat nummer. Det ställer in numrets storlek, tjocklek och färg innan fältet läggs till, öppnar sedan den sparade presentationen igen och kontrollerar fälttyp, text och formatering. Ingen inmatningsfil krävs.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Den nya presentationen startar med bildnummer 1, så texten är `Slide 1`, och båda kontrollerna skriver ut `True`. Numret förblir ett fält efter att presentationen öppnats igen; det är inte en bokstavlig `1`. Indexen i verifieringen hänvisar till formen och delarna som skapades av detta exempel.

## **Välj en fälttyp**

[FieldType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/) tillhandahåller följande fördefinierade värden. Skicka det lämpliga värdet till [add_field](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/add_field/).

| Värde | Syfte |
|---|---|
| [slide_number](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/slide_number/) | Det aktuella bildnumret. |
| [date_time](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/date_time/) | Datum/tid i renderingsprogrammets standardformat. |
| [date_time1](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/date_time9/) | Fördefinierade datum- eller kombinerade datum/tid-format. |
| [date_time10](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/date_time13/) | Fördefinierade tidsformat, med alternativ för sekunder och en 12‑timmarsklocka. |
| [header](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/header/) | Ett rubrikfält; se platshållaren och formatbegränsningarna nedan. |
| [footer](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/footer/) | Ett sidfotfält. |

Till exempel representerar [date_time3](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/date_time3/) en dag, månadens fullständiga namn och år på engelska. Detta är fördefinierade fältformat, inte godtyckliga Python-datumformatsträngar. Delens [language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseportionformat/language_id/) och programmet som bearbetar presentationen kan påverka det visade resultatet.

## **Skapa ett fält från en intern sträng**

Strängöverladdningen av [add_field](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/add_field/) accepterar en intern fältidentifierare. Använd den när du bevarar en identifierare som levererats av ett annat program som saknar fördefinierat värde. Du kan också konstruera en [FieldType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/__init__/) från identifieraren. [FieldType.internal_string](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fieldtype/internal_string/) visar den identifieraren för inspektion.

Detta exempel lagrar ett program‑specifikt `custom-report-id`‑fält med reservtexten `Report-042`. Identifieraren registrerar ingen beräkning: Aspose.Slides genererar inte rapport‑ID:n för en okänd typ. Programmet som förstår denna identifierare måste tillhandahålla dess betydelse och uppdatera dess värde.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

Efter denna PPTX‑rundresa är typen `custom-report-id` och texten `Report-042`. Att skicka en sträng som `%Y-%m-%d` skulle namnge en fälttyp; det skulle inte konfigurera ett anpassat datumformat. För ett fast datum i ett godtyckligt format, använd vanlig text.

## **Inspektera, ändra och ta bort datum/tid‑fält**

Läs och ändra ett befintligt fält via [Field.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/field/type/). Kontrollera att fältet finns innan du får åtkomst till dess typ. För att stoppa automatiska uppdateringar, anropa [Portion.remove_field](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/remove_field/). Detta behåller delen och dess aktuella text medan fältkopplingen tas bort. Om du behöver ett specifikt fast värde, tilldela den texten efter att fältet har tagits bort.

För API‑inställningen som är kopplad till datum/tid‑fältbearbetning, se [Presentation.current_date_time](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/current_date_time/). Exemplet nedan använder ett explicit godkännandedatum när ett fält konverteras till vanlig text. En tuple med engelska månadnamn håller det fasta datumet oberoende av systemets språk.

Ladda ner [sample.pptx](sample.pptx) och placera den i arbetskatalogen. Den innehåller två namngivna textrutor, `UpdatedAt` och `ApprovedDate`, var och en med ett datum/tid‑fält, samt vanliga textetiketter. Följande exempel går igenom top‑nivå textrutor på vanliga bilder. Det ändrar datum/tid‑fält till ett långt datumformat och gör dem kursiva, samtidigt som annan formatering bevaras. Endast fält i `ApprovedDate` blir fast text.

Exemplet känner igen de inbyggda interna identifierarna `datetime` och `datetime1` till `datetime13`. Grupper, tabeller, anteckningar, layouter och master‑bilder kräver genomsökning av sina egna textbehållare och ligger utanför detta exemplars omfattning.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

Efter att ha öppnat igen har `UpdatedAt` typ `datetime3` och förblir dynamisk. `ApprovedDate` har inget fält och innehåller `05 April 2030`. Båda datumdelarna är kursiva, och deras ursprungliga teckenstorlek, fetstil och färg förblir oförändrade. Vanliga textetiketter är oförändrade. Verifieringen läser den första delen av de två kända formerna i det medföljande exemplet.

## **Bevara textformatering**

Arbeta med den befintliga delen när du lägger till ett fält, ändrar dess typ eller tar bort det. Dessa operationer behåller delens formatering. Använd [Portion.portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/portion_format/) för att bara ändra de nödvändiga egenskaperna, som exemplen gör för färg eller kursiv.

Undvik att bygga om en hel textruta bara för att uppdatera ett fält: det kan leda till att de ursprungliga delgränserna och deras individuella formatering går förlorade. Skilj också på explicit inställd formatering från formatering som ärvs från stycke, layout eller tema. Se [Text Formatting](/slides/sv/python-net/text-formatting/) för bredare formateringsalternativ.

## **Fält och rubrik-/sidfot‑platshållare**

Ett fält är en del av en textdel. En platshållare är en form med en presentationsroll, till exempel en sidfot eller bildnummer. Att lägga till ett fält i en vanlig textruta gör inte den formen till en platshållare.

Rubrik‑/sidfot‑hanterarna styr platshållarens text och synlighet på bilder, layouter och master‑bilder, inklusive spridning till beroende bilder. Ett nummerfält i en anpassad textruta kan därför vara användbart även om du inte använder bildnummer‑platshållaren. Omvänt tar inte ändring av platshållarens synlighet bort ett fält från en orelaterad textruta.

De fördefinierade rubrik‑ och sidfottyperna skapar inte motsvarande platshållare eller tillhandahåller deras innehåll. Speciellt har en vanlig PowerPoint‑bild ingen rubrik‑platshållare; rubriker tillhör anteckningssidor och utdelningsmaterial. Anta inte att ett rubrik‑ eller sidfotfält i en godtycklig form automatiskt får den text som konfigurerats via en platshållarhanterare. För det arbetsflödet, se [Presentation Headers and Footers](/slides/sv/python-net/presentation-header-and-footer/).

## **PPTX‑ och PPT‑begränsningar**

Kontrollera både fälttypen och dess resulterande text efter sparning och öppning igen. Att bevara en identifierare bevisar inte att ett program kan beräkna eller visa dess värde.

| Format | Fältbeteende och begränsningar |
|---|---|
| PPTX | Lagrar interna fältidentifierare tillsammans med fälttexten. Vid rundresor klarade de fördefinierade typerna och den anpassade identifieraren som användes ovan att sparas och öppnas igen. Den okända anpassade typen behöll sin reservtext; den fick ingen automatisk beräkningslogik. Ett annat program kan hantera ostödda identifierare på annat sätt. |
| PPT | Använder äldre fältrepresentationer och har mer begränsad kompatibilitet. Vid rundresor klarade bildnummer‑ och fördefinierade datum/tid‑fält att sparas och öppnas igen. Ett anpassat fält i en vanlig bildtextruta öppnades igen med sin identifierare men med `*` som text; ett rubrikfält i samma kontext producerade också `*`. Räkna inte med att anpassade fält eller ostödda fältkontexter behåller sin synliga text. |

För portabel, fast utdata, konvertera ostödda fält till vanlig text och tilldela explicit det värde du vill ha innan du sparar. Detta bevarar den valda texten men stoppar avsiktligt automatiska uppdateringar. Testa även målprogrammet när dess egen fältomräkning är en del av ditt arbetsflöde.

## **Vanliga frågor**

**Hur kan jag avgöra om ett visat nummer eller datum är ett fält?**

Inspektera [Portion.field](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/field/). Ett värde annat än `None` identifierar ett fält; den visade texten ensam kan inte säga det.

**Tar bort av ett fält bort dess text eller formatering?**

Nej. [remove_field](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/remove_field/) konverterar den befintliga delen till vanlig text. Tilldela ett explicit värde efteråt om du behöver ett specifikt fruset datum eller reservtext.

**Kan en intern sträng definiera ett nytt datumformat eller en formel?**

Nej. Den identifierar en fälttyp. En okänd identifierare ger ingen evaluator eller ett Python‑datumformatmönster. Använd en stödd fördefinierad typ eller formatera ett värde själv som vanlig text.

**Varför kontrollera en presentation igen efter att den sparats?**

Fältidentifierare, beräknad text och formatering är separata saker att verifiera. Formatkonvertering kan förändra det synliga resultatet även när fältidentifieraren fortfarande finns.