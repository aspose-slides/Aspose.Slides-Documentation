---
title: Hantera textfält i PowerPoint-presentationer i .NET
linktitle: Textfält
type: docs
weight: 52
url: /sv/net/text-fields/
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
- C#
- Aspose.Slides
description: "Skapa, inspektera, ändra och ta bort textfält i PowerPoint-presentationer med Aspose.Slides för .NET. Bevara formatering och verifiera sparade PPTX- och PPT-filer."
---
## **Översikt**

Ett textstycke består av portioner. En vanlig [IPortion](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/) innehåller bokstavlig text; en fältportion har också en [IField](https://reference.aspose.com/slides/sv/net/aspose.slides/ifield/) vars typ identifierar ett automatiskt uppdaterat värde, såsom ett bildnummer eller datum. Två portioner kan visa samma tecken medan endast en innehåller ett fält.

Använd [IPortion.Field](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/field/) för att skilja dem åt: den är `null` för vanlig text. [IPortion.AddField](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/addfield/) konverterar en befintlig portion till ett fält. Håll en etikett och dess dynamiska värde i separata portioner så att konverteringen av värdet inte också ersätter etiketten.

Den här guiden täcker fält i text, deras formatering och sparande i PPTX och PPT. För textramar och stycken, se [Manage Text](/slides/sv/net/manage-text/).

## **Skapa ett bildnummerfält**

Följande kompletta exempel skapar en textruta som innehåller en bokstavlig `Slide `-etikett följd av ett automatiskt uppdaterat nummer. Det sätter numrets storlek, tjocklek och färg innan fältet läggs till, öppnar sedan den sparade presentationen igen och kontrollerar fälttyp, text och formatering. Ingen indatafil krävs.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Den nya presentationen startar med bildnummer 1, så texten är `Slide 1`, och båda kontrollerna skriver ut `True`. Numret förblir ett fält efter omöppning; det är inte en bokstavlig `1`. Typkonverteringarna och indexerna i verifieringen hänvisar till formen och portionerna som skapades av detta exempel.

## **Välj en fälttyp**

[FieldType](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/) implementerar [IFieldType](https://reference.aspose.com/slides/sv/net/aspose.slides/ifieldtype/) och tillhandahåller följande fördefinierade värden. Skicka det lämpliga värdet till [AddField](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/addfield/).

| Värde | Syfte |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/slidenumber/) | Det aktuella bildnumret. |
| [DateTime](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/datetime/) | Datum/tid i renderingsapplikationens standardformat. |
| [DateTime1](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/datetime9/) | Fördefinierade datum- eller kombinerade datum/tid-format. |
| [DateTime10](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/datetime13/) | Fördefinierade tidsformat, med alternativ för sekunder och en 12‑timmarsklocka. |
| [Header](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/header/) | Ett sidhuvudfält; se platshållar‑ och formatbegränsningarna nedan. |
| [Footer](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/footer/) | Ett sidfotfält. |

Till exempel representerar [DateTime3](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/datetime3/) en dag, fullt månadsnamn och år på engelska. Detta är fördefinierade fältformat, inte godtyckliga .NET‑datumformatsträngar. Portionens [LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseportionformat/languageid/) och applikationen som bearbetar presentationen kan påverka det visade resultatet.

## **Skapa ett fält från en intern sträng**

Strängöverladdningen av [AddField](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/addfield/) accepterar en intern fältidentifierare. Använd den när du bevarar en identifierare som levererats av en annan applikation som saknar fördefinierat värde. Du kan också konstruera en [FieldType](https://reference.aspose.com/slides/sv/net/aspose.slides/fieldtype/fieldtype/) från identifieraren. [IFieldType.InternalString](https://reference.aspose.com/slides/sv/net/aspose.slides/ifieldtype/internalstring/) visar den identifieraren för inspektion.

Detta exempel lagrar ett applikationsspecifikt `custom-report-id`‑fält med reservtexten `Report-042`. Identifieraren registrerar ingen beräkning: Aspose.Slides genererar inte rapport‑ID:n för en okänd typ. Applikationen som förstår denna identifierare måste tillhandahålla dess betydelse och uppdatera dess värde.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Efter denna PPTX‑rundresa är typen `custom-report-id` och texten `Report-042`. Att skicka en sträng som `yyyy-MM-dd` skulle namnge en fälttyp; den skulle inte konfigurera ett eget datumformat. För ett fast datum i ett godtyckligt format, använd vanlig text.

## **Inspektera, ändra och ta bort datum/tid-fält**

Läs och ändra ett befintligt fält via [IField.Type](https://reference.aspose.com/slides/sv/net/aspose.slides/ifield/type/). Kontrollera att fältet finns innan du får åtkomst till dess typ. För att stoppa automatiska uppdateringar, anropa [IPortion.RemoveField](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/removefield/). Detta behåller portionen och dess nuvarande text samtidigt som fältassociationen tas bort. Om du behöver ett specifikt fast värde, tilldela den texten efter att ha tagit bort fältet.

För API‑inställningen som är kopplad till behandling av datum/tid‑fält, se [Presentation.CurrentDateTime](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/currentdatetime/). Exemplet nedan använder ett explicit godkännandedatum när ett fält konverteras till vanlig text.

Ladda ner [sample.pptx](sample.pptx) och placera den i arbetskatalogen. Den innehåller två namngivna textformer, `UpdatedAt` och `ApprovedDate`, vardera med ett datum/tid‑fält, samt vanliga textetiketter. Följande exempel går igenom top‑nivå textformer på vanliga bilder. Det ändrar datum/tid‑fält till ett långt datumformat och gör dem kursiva, samtidigt som deras övriga formatering bevaras. Endast fält i `ApprovedDate` blir fast text.

Exemplet känner igen de inbyggda interna identifierarna `datetime` och `datetime1` till `datetime13`. Grupper, tabeller, noteringar, layout‑ och master‑slides kräver traversering av sina egna textbehållare och ligger utanför detta exempel.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Efter omöppning har `UpdatedAt` typ `datetime3` och förblir dynamisk. `ApprovedDate` har inget fält och innehåller `05 April 2030`. Båda datumportionerna är kursiva, och deras ursprungliga teckenstorlek, fetstil och färg förblir intakta. De vanliga textetiketterna är oförändrade. Verifieringen läser den första portionen av de två kända formerna i det medföljande exempelfilen.

## **Bevara textformatering**

Arbeta med den befintliga portionen när du lägger till ett fält, ändrar dess typ eller tar bort det. Dessa operationer behåller portionens formatering. Använd [IPortion.PortionFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/portionformat/) för att bara ändra de nödvändiga egenskaperna, som exemplen gör för färg eller kursiv.

Undvik att bygga om en hel textruta bara för att uppdatera ett fält: det kan leda till att de ursprungliga portionsgränserna och deras individuella formatering förloras. Skilj också på explicit angiven formatering och formatering som ärvs från stycket, layouten eller temat. Se [Text Formatting](/slides/sv/net/text-formatting/) för bredare formateringsalternativ.

## **Fält och platshållare för sidhuvud/sidfots**

Ett fält är en del av en textportion. En platshållare är en form med en presentationsroll, såsom en sidfot eller bildnummer. Att lägga till ett fält i en vanlig textruta förvandlar inte den formen till en platshållare.

Sidhuvud-/sidfot‑hanterarna styr platshållartext och synlighet på bilder, layouter och master‑slides, inklusive spridning till beroende bilder. Ett nummerfält i en anpassad textruta kan därför vara användbart även när du inte använder bildnummer‑platshållaren. Omvänt, att ändra platshållarens synlighet tar inte bort ett fält från en orelaterad textruta.

De fördefinierade sidhuvud‑ och sidfottyperna skapar inte motsvarande platshållare eller tillhandahåller deras innehåll. Speciellt har en vanlig PowerPoint‑bild ingen sidhuvuds‑platshållare; sidhuvuden hör till notssidor och utdelningar. Anta inte att ett sidhuvuds‑ eller sidfotsfält i en godtycklig form automatiskt får den text som konfigurerats via en platshållarhanterare. För det arbetsflödet, se [Presentation Headers and Footers](/slides/sv/net/presentation-header-and-footer/).

## **PPTX‑ och PPT‑begränsningar**

Kontrollera både fälttypen och dess resulterande text efter att ha sparat och öppnat igen. Att bevara en identifierare bevisar inte att en applikation kan beräkna eller visa dess värde.

| Format | Fältbeteende och begränsningar |
|---|---|
| PPTX | Lagrar interna fältidentifierare tillsammans med fälttexten. Vid rundresan‑kontroller överlevde de fördefinierade typerna och den anpassade identifieraren som användes ovan att sparas och öppnas igen. Den okända anpassade typen behöll sin reservtext; den fick ingen automatisk beräkningslogik. En annan applikation kan hantera ej stödda identifierare på annat sätt. |
| PPT | Använder äldre fältrepresentationer och har mer begränsad kompatibilitet. Vid rundresan‑kontroller överlevde bildnummer‑ och fördefinierade datum/tid‑fält att sparas och öppnas igen. Ett anpassat fält i en vanlig bildtextruta öppnades igen med sin identifierare men med `*` som text; ett sidhuvudsfält i samma sammanhang producerade också `*`. Lita inte på att anpassade fält eller ej stödda fältkontexter behåller sin synliga text. |

För portabel, fast output, konvertera ej stödjade fält till vanlig text och tilldela explicit det värde du vill ha innan du sparar. Detta bevarar den valda texten men stoppar avsiktligt automatiska uppdateringar. Testa även målapplikationen när dess egna fältomräkningar är en del av ditt arbetsflöde.

## **FAQ**

**Hur kan jag avgöra om ett visat nummer eller datum är ett fält?**  
Inspektera [IPortion.Field](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/field/). Ett icke‑null‑värde identifierar ett fält; den visade texten ensam kan inte säga det.

**Tar bort ett fält bort dess text eller formatering?**  
Nej. [RemoveField](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/removefield/) konverterar den befintliga portionen till vanlig text. Tilldela ett explicit värde efteråt om du behöver ett särskilt fryst datum eller reservtext.

**Kan en intern sträng definiera ett nytt datumformat eller en formel?**  
Nej. Den identifierar en fälttyp. En okänd identifierare ger ingen evaluator eller ett .NET‑datumformatmönster. Använd en stödd fördefinierad typ eller formatera ett värde själv som vanlig text.

**Varför kontrollera en presentation igen efter att ha sparat den?**  
Fältidentifierare, beräknad text och formatering är separata saker att verifiera. Formatkonvertering kan ändra det synliga resultatet även när fältidentifieraren fortfarande finns.