---
title: Beheren van Tekstvelden in PowerPoint-presentaties in .NET
linktitle: Tekstvelden
type: docs
weight: 52
url: /nl/net/text-fields/
keywords:
- tekstveld
- automatische tekst
- dia-nummer
- datum en tijd
- koptekst
- voettekst
- tekstportie
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Maak, inspecteer, wijzig en verwijder tekstvelden in PowerPoint-presentaties met Aspose.Slides voor .NET. Behoud de opmaak en verifieer de opgeslagen PPTX- en PPT-bestanden."
---
## **Overzicht**

Een tekstparagraaf bestaat uit porties. Een gewone [IPortion](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/) bevat letterlijke tekst; een veldportie heeft ook een [IField](https://reference.aspose.com/slides/nl/net/aspose.slides/ifield/) waarvan het type een automatisch bijgewerkte waarde identificeert, zoals een dia‑nummer of datum. Twee porties kunnen dezelfde tekens weergeven terwijl slechts één een veld bevat.

Gebruik [IPortion.Field](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/field/) om ze te onderscheiden: het is `null` voor gewone tekst. [IPortion.AddField](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/addfield/) zet een bestaande portie om in een veld. Houd een label en zijn dynamische waarde in aparte porties zodat het converteren van de waarde het label niet ook vervangt.

Deze gids behandelt velden binnen tekst, hun opmaak, en het opslaan ervan in PPTX en PPT. Voor tekstframes en alinea’s, zie [Manage Text](/slides/nl/net/manage-text/).

## **Een dia‑nummer veld maken**

Het volgende volledige voorbeeld maakt een tekstvak dat een letterlijk `Slide `‑label bevat, gevolgd door een automatisch bijgewerkt nummer. Het stelt de grootte, dikte en kleur van het nummer in vóór het toevoegen van het veld, opent vervolgens de opgeslagen presentatie opnieuw en controleert het veldtype, de tekst en de opmaak. Er is geen invoer‑bestand vereist.

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

De nieuwe presentatie start met dia‑nummer 1, dus de tekst is `Slide 1`, en beide controles geven `True` weer. Het nummer blijft een veld na het heropenen; het is geen letterlijke `1`. De casts en indexen in de verificatie verwijzen naar de vorm en porties die door dit voorbeeld zijn aangemaakt.

## **Kies een veldtype**

[FieldType](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/) implementeert [IFieldType](https://reference.aspose.com/slides/nl/net/aspose.slides/ifieldtype/) en biedt de volgende vooraf gedefinieerde waarden. Geef de juiste waarde door aan [AddField](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/addfield/).

| Waarde | Doel |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/slidenumber/) | Het huidige dia‑nummer. |
| [DateTime](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/datetime/) | Datum/tijd in het standaardformaat van de renderende applicatie. |
| [DateTime1](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/datetime9/) | Vooraf gedefinieerde datum‑ of gecombineerde datum/tijd‑formaten. |
| [DateTime10](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/datetime13/) | Vooraf gedefinieerde tijdformaten, met opties voor seconden en een 12‑uur klok. |
| [Header](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/header/) | Een koptekst‑veld; zie hieronder de placeholder‑ en opmaakbeperkingen. |
| [Footer](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/footer/) | Een voettekst‑veld. |

Bijvoorbeeld, [DateTime3](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/datetime3/) staat voor een dag, volledige maandnaam en jaar in het Engels. Dit zijn vooraf gedefinieerde veldformaten, geen willekeurige .NET-datum‑formaat‑strings. De [LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/languageid/) van de portie en de applicatie die de presentatie verwerkt, kunnen het weergegeven resultaat beïnvloeden.

## **Maak een veld aan vanuit een interne tekenreeks**

De string‑overload van [AddField](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/addfield/) accepteert een interne veld‑identificator. Gebruik deze wanneer u een identifier wilt behouden die door een andere applicatie is geleverd en waarvoor geen vooraf gedefinieerde waarde bestaat. U kunt ook een [FieldType](https://reference.aspose.com/slides/nl/net/aspose.slides/fieldtype/fieldtype/) construeren vanuit de identifier. [IFieldType.InternalString](https://reference.aspose.com/slides/nl/net/aspose.slides/ifieldtype/internalstring/) stelt die identifier beschikbaar voor inspectie.

Dit voorbeeld slaat een toepassingsspecifiek veld `custom-report-id` op met de fallback‑tekst `Report-042`. De identifier registreert geen berekening: Aspose.Slides genereert geen rapport‑ID’s voor een onbekend type. De applicatie die deze identifier begrijpt, moet de betekenis leveren en de waarde bijwerken.

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

Na deze PPTX‑rondreis is het type `custom-report-id` en de tekst `Report-042`. Het doorgeven van een string zoals `yyyy-MM-dd` zou een veldtype benoemen; het zou geen aangepast datumformaat configureren. Voor een vaste datum in een willekeurig formaat, gebruik gewone tekst.

## **Inspecteer, wijzig en verwijder datum/tijd‑velden**

Lees en wijzig een bestaand veld via [IField.Type](https://reference.aspose.com/slides/nl/net/aspose.slides/ifield/type/). Controleer dat het veld bestaat vóór toegang tot het type. Om automatische updates te stoppen, roep [IPortion.RemoveField](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/removefield/) aan. Dit behoudt de portie en de huidige tekst terwijl de veldassociatie wordt verwijderd. Als u een specifieke vaste waarde nodig heeft, ken die tekst dan toe nadat het veld is verwijderd.

Voor de API‑instelling die verband houdt met de verwerking van datum/tijd‑velden, zie [Presentation.CurrentDateTime](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/currentdatetime/). Het onderstaande voorbeeld gebruikt een expliciete goedkeuringsdatum bij het omzetten van een veld naar gewone tekst.

Download [sample.pptx](sample.pptx) en plaats het in de werkmap. Het bevat twee benoemde tekstvormen, `UpdatedAt` en `ApprovedDate`, elk met een datum/tijd‑veld, plus gewone tekstlabels. Het volgende voorbeeld doorloopt bovenliggend tekstvormen op reguliere dia’s. Het verandert datum/tijd‑velden naar een lang‑datumformaat en maakt ze cursief, terwijl de overige opmaak behouden blijft. Alleen velden in `ApprovedDate` worden vaste tekst.

De voorbeeldcode herkent de ingebouwde interne identifiers `datetime` en `datetime1` t/m `datetime13`. Groepen, tabellen, notities, lay‑outs en masters vereisen traversen van hun eigen tekstcontainers en vallen buiten de reikwijdte van dit voorbeeld.

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

Na het heropenen heeft `UpdatedAt` type `datetime3` en blijft dynamisch. `ApprovedDate` heeft geen veld en bevat `05 April 2030`. Beide datum‑porties zijn cursief, en hun oorspronkelijke lettergrootte, vetinstelling en kleur blijven behouden. De gewone tekstlabels blijven ongewijzigd. De verificatie leest de eerste portie van de twee bekende vormen in de geleverde voorbeeldpresentatie.

## **Behoud tekstopmaak**

Werk met de bestaande portie bij het toevoegen, wijzigen of verwijderen van een veld. Deze bewerkingen behouden de opmaak van die portie. Gebruik [IPortion.PortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/portionformat/) om alleen de benodigde eigenschappen te wijzigen, zoals de voorbeelden doen voor kleur of cursivering.

Vermijd het opnieuw bouwen van een compleet tekstframe alleen om één veld bij te werken: dat kan de oorspronkelijke portie‑grenzen en hun individuele opmaak verliezen. Onderscheid ook expliciet ingestelde opmaak van opmaak die geërfd wordt van de alinea, lay‑out of thema. Zie [Text Formatting](/slides/nl/net/text-formatting/) voor bredere opmaakopties.

## **Velden en header/footer‑placeholders**

Een veld is onderdeel van een tekstportie. Een placeholder is een vorm met een presentatie‑rol, zoals een voettekst of dia‑nummer. Het toevoegen van een veld aan een gewone tekstvak maakt die vorm niet tot een placeholder.

De header/footer‑managers regelen placeholder‑tekst en zichtbaarheid op dia’s, lay‑outs en masters, inclusief voortplanting naar afhankelijke dia’s. Een nummer‑veld in een aangepast tekstvak kan daarom nuttig zijn, zelfs wanneer u de dia‑nummer‑placeholder niet gebruikt. Omgekeerd verwijdert het wijzigen van de placeholder‑zichtbaarheid geen veld uit een niet‑gerelateerd tekstvak.

De vooraf gedefinieerde header‑ en footertype maken de overeenkomstige placeholders niet aan en leveren hun inhoud niet. Een reguliere PowerPoint‑dia heeft bijvoorbeeld geen header‑placeholder; headers behoren tot notitie‑pagina’s en hand-outs. Ga er niet van uit dat een header‑ of footerveld in een willekeurige vorm automatisch de tekst verkrijgt die via een placeholder‑manager is geconfigureerd. Zie daarvoor [Presentation Headers and Footers](/slides/nl/net/presentation-header-and-footer/).

## **PPTX- en PPT‑beperkingen**

Controleer zowel het veldtype als de resulterende tekst naïvelijk na het opslaan en opnieuw openen. Het behouden van een identifier bewijst niet dat een applicatie de waarde kan berekenen of weergeven.

| Formaat | Gedrag van veld en beperkingen |
|---|---|
| PPTX | Slaat interne veld‑identifiers op naast de veld‑tekst. In rond‑reis‑controles overleefden de vooraf gedefinieerde typen en de hierboven gebruikte aangepaste identifier het opslaan en heropenen. Het onbekende aangepaste type behield zijn fallback‑tekst; het kreeg geen automatische berekeningslogica. Een andere applicatie kan onbekende identifiers anders behandelen. |
| PPT | Gebruikt legacy‑veldrepresentaties en heeft meer beperkte compatibiliteit. In rond‑reis‑controles overleefden dia‑nummer‑ en vooraf gedefinieerde datum/tijd‑velden het opslaan en heropenen. Een aangepast veld in een gewoon tekstvak op een dia werd heropend met zijn identifier maar met `*` als tekst; een header‑veld in dezelfde context produceerde eveneens `*`. Vertrouw niet op aangepaste velden of niet‑ondersteunde veld‑contexten om hun zichtbare tekst te behouden. |

Voor draagbare, vaste output, zet niet‑ondersteunde velden om in gewone tekst en ken de gewenste waarde expliciet toe vóór het opslaan. Dit behoudt de gekozen tekst maar stopt opzettelijk automatische updates. Test ook de doelapplicatie wanneer diens eigen veld‑herberekening onderdeel is van uw workflow.

## **Veelgestelde vragen**

**Hoe kan ik zien of een weergegeven nummer of datum een veld is?**  
Inspecteer [IPortion.Field](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/field/). Een niet‑null waarde duidt een veld aan; de weergegeven tekst alleen kan dit niet onthullen.

**Verwijdert het verwijderen van een veld de tekst of opmaak?**  
Nee. [RemoveField](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/removefield/) zet de bestaande portie om naar gewone tekst. Ken daarna een expliciete waarde toe als u een specifieke bevroren datum of fallback‑tekst nodig heeft.

**Kan een interne string een nieuw datumformaat of formule definiëren?**  
Nee. Het identificeert een veldtype. Een onbekende identifier levert geen evaluator of .NET‑datum‑formaat‑patroon. Gebruik een ondersteund vooraf gedefinieerd type of formatteer een waarde zelf als gewone tekst.

**Waarom een presentatie opnieuw controleren na het opslaan?**  
Veldidentifiers, berekende tekst en opmaak zijn afzonderlijke zaken die moeten worden geverifieerd. Een formatconversie kan het zichtbare resultaat wijzigen, zelfs wanneer de veldidentifier nog aanwezig is.