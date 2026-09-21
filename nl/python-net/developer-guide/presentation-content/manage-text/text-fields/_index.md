---
title: Beheer tekstvelden in PowerPoint-presentaties met Python
linktitle: Tekstvelden
type: docs
weight: 52
url: /nl/python-net/text-fields/
keywords:
- tekstveld
- automatische tekst
- dia-nummer
- datum en tijd
- koptekst
- voettekst
- tekstdeel
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Maak, inspecteer, wijzig en verwijder tekstvelden in PowerPoint-presentaties met Aspose.Slides voor Python via .NET. Behoud de opmaak en controleer opgeslagen PPTX- en PPT-bestanden."
---
## **Overzicht**

Een tekstparagraaf bestaat uit gedeelten. Een gewone [Portion](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/) bevat letterlijke tekst; een veldgedeelte heeft bovendien een [Field](https://reference.aspose.com/slides/nl/python-net/aspose.slides/field/) waarvan het type een automatisch bijgewerkte waarde aangeeft, zoals een dia‑nummer of datum. Twee gedeelten kunnen dezelfde tekens weergeven terwijl slechts één een veld bevat.

Gebruik [Portion.field](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/field/) om ze te onderscheiden: het is `None` voor gewone tekst. [Portion.add_field](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/add_field/) zet een bestaand gedeelte om in een veld. Houd een label en de dynamische waarde in afzonderlijke gedeelten zodat het omzetten van de waarde niet ook het label vervangt.

Deze gids behandelt velden in tekst, hun opmaak en het opslaan in PPTX en PPT. Voor tekstframes en alinea's, zie [Manage Text](/slides/nl/python-net/manage-text/).

## **Een dia‑nummerveld maken**

Het volgende volledige voorbeeld maakt een tekstvak met een letterlijke `Slide `‑label gevolgd door een automatisch bijgewerkt nummer. Het stelt de grootte, dikte en kleur van het nummer in voordat het veld wordt toegevoegd, opent vervolgens de opgeslagen presentatie opnieuw en controleert het veldtype, de tekst en de opmaak. Er is geen invoerbestand vereist.

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

De nieuwe presentatie begint met dia‑nummer 1, dus de tekst is `Slide 1`, en beide controles printen `True`. Het nummer blijft een veld na het heropenen; het is geen letterlijke `1`. De indices in de verificatie verwijzen naar de vorm en de gedeelten die door dit voorbeeld zijn aangemaakt.

## **Een veldtype kiezen**

[FieldType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/) levert de volgende vooraf gedefinieerde waarden. Geef de juiste waarde door aan [add_field](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/add_field/).

| Waarde | Doel |
|---|---|
| [slide_number](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/slide_number/) | Het huidige dia‑nummer. |
| [date_time](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/date_time/) | Datum/tijd in het standaardformaat van de rendering‑applicatie. |
| [date_time1](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/date_time9/) | Vooraf gedefinieerde datum‑ of gecombineerde datum/tijd‑formaten. |
| [date_time10](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/date_time13/) | Vooraf gedefinieerde tijdformaten, met opties voor seconden en een 12‑uur klok. |
| [header](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/header/) | Een header‑veld; zie de placeholder‑ en formaatbeperkingen hieronder. |
| [footer](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/footer/) | Een footer‑veld. |

Bijvoorbeeld, [date_time3](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/date_time3/) staat voor een dag, volledige maandnaam en jaar in het Engels. Dit zijn vooraf gedefinieerde veldformaten, geen willekeurige Python‑datum‑formatstrings. De [language_id](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/language_id/) van het gedeelte en de applicatie die de presentatie verwerkt, kunnen het weergegeven resultaat beïnvloeden.

## **Een veld maken vanuit een interne tekenreeks**

De tekenreeks‑overload van [add_field](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/add_field/) accepteert een interne veld‑identifier. Gebruik deze wanneer u een identifier wilt behouden die door een andere applicatie is opgegeven en waarvoor geen vooraf gedefinieerde waarde bestaat. U kunt ook een [FieldType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/__init__/) construeren vanuit de identifier. [FieldType.internal_string](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fieldtype/internal_string/) maakt die identifier beschikbaar voor inspectie.

Dit voorbeeld slaat een toepassingsspecifiek `custom-report-id`‑veld op met de fallback‑tekst `Report-042`. De identifier registreert geen berekening: Aspose.Slides genereert geen rapport‑IDs voor een onbekend type. De applicatie die deze identifier begrijpt, moet de betekenis leveren en de waarde bijwerken.

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

Na deze PPTX‑ronde is het type `custom-report-id` en de tekst `Report-042`. Het doorgeven van een tekenreeks zoals `%Y-%m-%d` zou een veldtype benoemen; het zou geen aangepast datumformaat configureren. Voor een vaste datum in een willekeurig formaat, gebruik gewone tekst.

## **Datum/tijd‑velden inspecteren, wijzigen en verwijderen**

Lees en wijzig een bestaand veld via [Field.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/field/type/). Controleer dat het veld bestaat voordat u het type benadert. Om automatische updates te stoppen, roep [Portion.remove_field](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/remove_field/) aan. Dit behoudt het gedeelte en de huidige tekst terwijl de veldassociatie wordt verwijderd. Als u een specifieke vaste waarde nodig heeft, kent u die tekst toe na het verwijderen van het veld.

Voor de API‑instelling die verband houdt met de verwerking van datum/tijd‑velden, zie [Presentation.current_date_time](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/current_date_time/). Het onderstaande voorbeeld gebruikt een expliciete goedkeuringsdatum bij het omzetten van een veld naar gewone tekst. Een Engelstalige maandnaam‑tuple houdt de vaste datum onafhankelijk van de systeem‑locale.

Download [sample.pptx](sample.pptx) en plaats het in de werkmap. Het bevat twee benoemde tekstvormen, `UpdatedAt` en `ApprovedDate`, elk met een datum/tijd‑veld, plus gewone tekstlabels. Het volgende voorbeeld doorloopt top‑level tekstvormen op reguliere dia’s. Het verandert datum/tijd‑velden naar een lange datum‑indeling en maakt ze cursief, terwijl de overige opmaak behouden blijft. Alleen velden in `ApprovedDate` worden vaste tekst.

De voorbeeld‑code herkent de ingebouwde interne identifiers `datetime` en `datetime1` tot `datetime13`. Groepen, tabellen, notities, lay‑outs en masters vereisen traverseren van hun eigen tekstcontainers en vallen buiten de reikwijdte van dit voorbeeld.

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

Na het heropenen heeft `UpdatedAt` type `datetime3` en blijft dynamisch. `ApprovedDate` heeft geen veld en bevat `05 April 2030`. Beide datum‑gedeelten zijn cursief, en hun oorspronkelijke lettergrootte, vetinstelling en kleur blijven ongewijzigd. De gewone tekstlabels blijven ongewijzigd. De verificatie leest het eerste gedeelte van de twee bekende vormen in het meegeleverde voorbeeld.

## **Tekstopmaak behouden**

Werk met het bestaande gedeelte wanneer u een veld toevoegt, het type wijzigt of het verwijdert. Deze bewerkingen behouden de opmaak van dat gedeelte. Gebruik [Portion.portion_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/portion_format/) om alleen de benodigde eigenschappen te wijzigen, zoals de voorbeelden doen voor kleur of cursief.

Vermijd het opnieuw bouwen van een compleet tekstframe alleen om één veld bij te werken: dat kan de oorspronkelijke grenzen van gedeelten en hun individuele opmaak verliezen. Onderscheid ook expliciet ingestelde opmaak van opmaak die is geërfd van de alinea, lay‑out of thema. Zie [Text Formatting](/slides/nl/python-net/text-formatting/) voor bredere opmaakopties.

## **Velden en header/footer‑placeholders**

Een veld is onderdeel van een tekstgedeelte. Een placeholder is een vorm met een presentatierol, zoals een footer of dia‑nummer. Het toevoegen van een veld aan een gewone tekstbox maakt die vorm niet tot een placeholder.

De header/footer‑managers regelen placeholder‑tekst en zichtbaarheid op dia’s, lay‑outs en masters, inclusief voortplanting naar afhankelijke dia’s. Een nummer‑veld in een aangepaste tekstbox kan daarom nuttig zijn, zelfs als u de dia‑nummer‑placeholder niet gebruikt. Omgekeerd verwijdert het wijzigen van de placeholder‑zichtbaarheid geen veld uit een niet‑gerelateerde tekstbox.

De vooraf gedefinieerde header‑ en footertype maken de corresponderende placeholders niet aan en leveren hun inhoud niet. Met name heeft een gewone PowerPoint‑dia geen header‑placeholder; headers behoren tot notitie‑pagina’s en hand-outs. Ga er niet vanuit dat een header‑ of footer‑veld in een willekeurige vorm automatisch de via een placeholder‑manager ingestelde tekst krijgt. Voor die workflow, zie [Presentation Headers and Footers](/slides/nl/python-net/presentation-header-and-footer/).

## **PPTX‑ en PPT‑beperkingen**

Controleer zowel het veldtype als de resulterende tekst na het opslaan en opnieuw openen. Het behouden van een identifier bewijst niet dat een applicatie de waarde kan berekenen of weergeven.

| Formaat | Gedrag van het veld en beperkingen |
|---|---|
| PPTX | Slaat interne veld‑identifiers op naast veld‑tekst. In ronde‑trip‑controles overleefden de vooraf gedefinieerde types en de hierboven gebruikte aangepaste identifier het opslaan en heropenen. Het onbekende aangepaste type behield zijn fallback‑tekst; het kreeg geen automatische berekeningslogica. Een andere applicatie kan onbekende identifiers anders behandelen. |
| PPT | Gebruikt verouderde veld‑representaties en heeft een meer beperkte compatibiliteit. In ronde‑trip‑controles overleefden dia‑nummer‑ en vooraf gedefinieerde datum/tijd‑velden het opslaan en heropenen. Een aangepast veld in een gewone dia‑tekstbox werd heropend met zijn identifier maar met `*` als tekst; een header‑veld in dezelfde context leverde eveneens `*`. Vertrouw niet op aangepaste velden of niet‑ondersteunde veld‑contexten om hun zichtbare tekst te behouden. |

Voor draagbare, vaste output, converteer niet‑ondersteunde velden naar gewone tekst en ken expliciet de gewenste waarde toe vóór het opslaan. Dit behoudt de gekozen tekst maar stopt opzettelijk automatische updates. Test de doelapplicatie eveneens wanneer diens eigen veld‑hercalculatie deel uitmaakt van uw workflow.

## **FAQ**

**Hoe kan ik zien of een getoonde nummer of datum een veld is?**

Inspecteer [Portion.field](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/field/). Een waarde anders dan `None` duidt een veld aan; de getoonde tekst alleen kan dat niet onthullen.

**Verwijdert het verwijderen van een veld de tekst of opmaak?**

Nee. [remove_field](https://reference.aspose.com/slides/nl/python-net/aspose.slides/portion/remove_field/) zet het bestaande gedeelte om naar gewone tekst. Ken later een expliciete waarde toe als u een specifieke bevroren datum of fallback‑tekst nodig heeft.

**Kan een interne tekenreeks een nieuw datumformaat of formule definiëren?**

Nee. Het identificeert een veldtype. Een onbekende identifier levert geen evaluator of een Python‑datum‑formatpatroon. Gebruik een ondersteund vooraf gedefinieerd type of formatteer de waarde zelf als gewone tekst.

**Waarom een presentatie opnieuw controleren na het opslaan?**

Veld‑identifiers, berekende tekst en opmaak zijn afzonderlijke zaken die geverifieerd moeten worden. Formaatconversie kan het zichtbare resultaat wijzigen, zelfs wanneer de veld‑identifier nog aanwezig is.