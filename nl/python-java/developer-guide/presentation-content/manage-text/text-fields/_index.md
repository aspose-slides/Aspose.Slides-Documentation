---
title: Beheer tekstvelden in PowerPoint-presentaties in Python via Java
linktitle: Tekstvelden
type: docs
weight: 52
url: /nl/python-java/text-fields/
keywords:
- tekstveld
- automatische tekst
- dia-nummer
- datum en tijd
- koptekst
- voettekst
- tekstonderdeel
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Maak, inspecteer, wijzig en verwijder tekstvelden in PowerPoint-presentaties met Aspose.Slides voor Python via Java. Behoud opmaak en controleer de opgeslagen PPTX- en PPT-bestanden."
---
## **Overzicht**

Een tekstparagraaf bestaat uit onderdelen. Een gewone [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) bevat letterlijke tekst; een veldonderdeel heeft ook een [Field](https://reference.aspose.com/slides/nl/python-java/aspose.slides/field/) waarvan het type een automatisch bijgewerkte waarde identificeert, zoals een dia‑nummer of datum. Twee onderdelen kunnen dezelfde tekens weergeven terwijl slechts één een veld bevat.

Gebruik [Portion.getField](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getField) om ze te onderscheiden: voor gewone tekst is het `None`. [Portion.addField](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#addField) zet een bestaand onderdeel om in een veld. Houd een label en de dynamische waarde in aparte onderdelen zodat het omzetten van de waarde het label niet eveneens vervangt.

Deze gids behandelt velden in tekst, hun opmaak en het opslaan daarvan in PPTX en PPT. Voor tekstframes en paragrafen, zie [Manage Text](/slides/nl/python-java/manage-text/).

## **Een dia‑nummerveld maken**

Het volgende complete voorbeeld maakt een tekstvak met een letterlijk `Slide `‑label gevolgd door een automatisch bijgewerkt nummer. Het stelt de grootte, dikte en kleur van het nummer in voordat het veld wordt toegevoegd, opent de opgeslagen presentatie vervolgens opnieuw en controleert het veldtype, de tekst en de opmaak. Er is geen invoerbestand vereist.

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

De nieuwe presentatie begint met dia‑nummer 1, dus de tekst is `Slide 1`, en beide controles geven `True`. Het nummer blijft een veld na het opnieuw openen; het is geen letterlijke `1`. De indices in de verificatie verwijzen naar de vorm en de onderdelen die door dit voorbeeld zijn aangemaakt.

## **Kies een veldtype**

[FieldType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/) biedt de volgende methoden om vooraf gedefinieerde waarden op te halen. Geef de juiste waarde door aan [addField](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#addField).

| Methode | Doel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getSlideNumber) | Het huidige dia‑nummer. |
| [getDateTime](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getDateTime) | Datum/tijd in het standaardformaat van de render‑applicatie. |
| [getDateTime1](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getDateTime9) | Vooraf gedefinieerde datum‑ of gecombineerde datum/tijd‑formaten. |
| [getDateTime10](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getDateTime13) | Vooraf gedefinieerde tijdformaten, met opties voor seconden en een 12‑urige klok. |
| [getHeader](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getHeader) | Een koptekstveld; zie de onderstaande beperkingen voor placeholders en opmaak. |
| [getFooter](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getFooter) | Een voettekstveld. |

Bijvoorbeeld, [getDateTime3](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getDateTime3) vertegenwoordigt een dag, de volledige maandnaam en het jaar in het Engels. Dit zijn vooraf gedefinieerde veldformaten, geen willekeurige Python‑datumnotaties. De taal die met [setLanguageId](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseportionformat/#setLanguageId) is ingesteld en de applicatie die de presentatie verwerkt, kunnen het weergegeven resultaat beïnvloeden.

## **Een veld aanmaken op basis van een interne tekenreeks**

De string‑overload van [addField](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#addField) accepteert een interne veld‑identificator. Gebruik dit wanneer je een identifier moet behouden die door een andere applicatie is geleverd en waarvoor geen vooraf gedefinieerde waarde bestaat. Je kunt ook een [FieldType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#FieldType) uit die identifier construeren. [FieldType.getInternalString](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fieldtype/#getInternalString) onthult die identifier voor inspectie.

Dit voorbeeld slaat een applicatiespecifiek `custom-report-id`‑veld op met de fallback‑tekst `Report-042`. De identifier registreert geen berekening: Aspose.Slides genereert geen rapport‑ID’s voor een onbekend type. De applicatie die deze identifier begrijpt, moet de betekenis leveren en de waarde bijwerken.

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

Na deze PPTX‑rondetrip is het type `custom-report-id` en de tekst `Report-042`. Het doorgeven van een tekenreeks zoals `yyyy-MM-dd` zou een veldtype benoemen; het zou geen aangepast datumformaat configureren. Gebruik gewone tekst voor een vaste datum in een willekeurig formaat.

## **Inspecteer, wijzig en verwijder datum/tijd‑velden**

Wijzig een bestaand veld via [Field.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/field/#setType). Controleer dat het veld bestaat voordat je het type benadert. Om automatische updates te stoppen, roep [Portion.removeField](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#removeField) aan. Dit behoudt het onderdeel en de huidige tekst terwijl de veld‑associatie wordt verwijderd. Als je een specifieke vaste waarde nodig hebt, ken dan die tekst toe na het verwijderen van het veld.

Voor de API‑instelling die gerelateerd is aan datum/tijd‑veldverwerking, zie [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#setCurrentDateTime). Het onderstaande voorbeeld gebruikt een expliciete goedkeuringsdatum bij het omzetten van een veld naar gewone tekst.

Download [sample.pptx](sample.pptx) en plaats het in de werkmap. Het bevat twee benoemde tekstvormen, `UpdatedAt` en `ApprovedDate`, elk met een datum/tijd‑veld, plus gewone tekstlabels. Het volgende voorbeeld doorloopt de bovenliggende tekstvormen op reguliere dia’s. Het verandert datum/tijd‑velden naar een lange‑datumnotatie en maakt ze cursief, terwijl de overige opmaak behouden blijft. Alleen velden in `ApprovedDate` worden vaste tekst.

Het voorbeeld herkent de ingebouwde interne identifiers `datetime` en `datetime1` tot `datetime13`. Groepen, tabellen, notities, lay‑outs en masters vereisen een doorloop van hun eigen tekstdocuments en vallen buiten de reikwijdte van dit voorbeeld.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # Gebruik Engelse maandnamen ongeacht de systeemtaal.
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

Na het opnieuw openen heeft `UpdatedAt` type `datetime3` en blijft dynamisch. `ApprovedDate` heeft geen veld en bevat `05 April 2030`. Beide datumonderdelen zijn cursief, en hun oorspronkelijke lettergrootte, vetinstelling en kleur blijven intact. De gewone tekstlabels blijven ongewijzigd. De verificatie leest het eerste onderdeel van de twee bekende vormen in het meegeleverde voorbeeld.

## **Behoud tekstopmaak**

Werk met het bestaande onderdeel bij het toevoegen, wijzigen of verwijderen van een veld. Deze bewerkingen behouden de opmaak van dat onderdeel. Gebruik [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getPortionFormat) om alleen de benodigde eigenschappen aan te passen, zoals de voorbeelden doen voor kleur of cursivering.

Vermijd het opnieuw opbouwen van een compleet tekstframe alleen om één veld bij te werken: dit kan de originele onderdeel‑grenzen en hun individuele opmaak verliezen. Maak bovendien onderscheid tussen expliciet ingestelde opmaak en opmaak die is geërfd van de paragraaf, lay‑out of thema. Zie [Text Formatting](/slides/nl/python-java/text-formatting/) voor uitgebreidere opmaakopties.

## **Velden en header/footer‑placeholders**

Een veld is onderdeel van een tekstonderdeel. Een placeholder is een vorm met een presentatierol, zoals een voettekst of dia‑nummer. Het toevoegen van een veld aan een gewoon tekstvak maakt die vorm niet tot een placeholder.

De header/footer‑managers regelen placeholder‑tekst en zichtbaarheid op dia’s, lay‑outs en masters, inclusief de voortplanting naar afhankelijke dia’s. Een nummer‑veld in een aangepast tekstvak kan daarom nuttig zijn, zelfs als je de dia‑nummer‑placeholder niet gebruikt. Omgekeerd verwijdert het wijzigen van placeholder‑zichtbaarheid geen veld uit een ongeassocieerd tekstvak.

De vooraf gedefinieerde header‑ en footertype‑waarden creëren de bijbehorende placeholders niet en leveren hun inhoud niet. Een reguliere PowerPoint‑dia heeft bijvoorbeeld geen header‑placeholder; kopteksten behoren tot notitie‑pagina’s en hand-outs. Ga er niet van uit dat een header‑ of footerveld in een willekeurige vorm automatisch de via een placeholder‑manager geconfigureerde tekst krijgt. Zie voor die workflow [Presentation Headers and Footers](/slides/nl/python-java/presentation-header-and-footer/).

## **PPTX- en PPT-beperkingen**

Controleer zowel het veldtype als de resulterende tekst na het opslaan en opnieuw openen. Het behouden van een identifier bewijst niet dat een applicatie de waarde kan berekenen of weergeven.

| Formaat | Gedrag van veld en beperkingen |
|---|---|
| PPTX | Slaat interne veld‑identifiers op naast de veld‑tekst. In round‑trip‑controles overleefden de vooraf gedefinieerde types en de aangepaste identifier uit het voorbeeld het opslaan en heropenen. Het onbekende aangepaste type behield zijn fallback‑tekst; er werd geen automatische berekeningslogica toegevoegd. Een andere applicatie kan onondersteunde identifiers anders behandelen. |
| PPT | Gebruikt legacy‑veldrepresentaties en heeft beperktere compatibiliteit. In round‑trip‑controles overleefden dia‑nummer‑ en vooraf gedefinieerde datum/tijd‑velden het opslaan en heropenen. Een aangepast veld in een gewoon tekstvak werd heropend met zijn identifier maar met `*` als tekst; een header‑veld in dezelfde context produceerde ook `*`. Vertrouw niet op aangepaste velden of niet‑ondersteunde veldcontexten om hun zichtbare tekst te behouden. |

Voor draagbare, vaste uitvoer, zet niet‑ondersteunde velden om in gewone tekst en wijs expliciet de gewenste waarde toe vóór het opslaan. Dit behoudt de gekozen tekst maar stopt bewust automatische updates. Test de doelsysteem‑applicatie ook wanneer diens eigen veld‑herberekening deel uitmaakt van je workflow.

## **FAQ**

**Hoe kan ik zien of een weergegeven nummer of datum een veld is?**

Inspecteer [Portion.getField](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#getField). Een waarde anders dan `None` duidt een veld aan; de weergegeven tekst alleen geeft geen bevestiging.

**Verwijdert het verwijderen van een veld de tekst of opmaak?**

Nee. [removeField](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/#removeField) zet het bestaande onderdeel om naar gewone tekst. Ken daarna een expliciete waarde toe als je een specifieke vaste datum of fallback‑tekst nodig hebt.

**Kan een interne tekenreeks een nieuw datumformaat of formule definiëren?**

Nee. Het identificeert enkel een veldtype. Een onbekende identifier levert geen evaluator of Python‑datumformaat‑patroon. Gebruik een ondersteund vooraf gedefinieerd type of formatteer de waarde zelf als gewone tekst.

**Waarom een presentatie opnieuw controleren na het opslaan?**

Veld‑identifiers, berekende tekst en opmaak zijn afzonderlijke zaken die moeten worden geverifieerd. Een formaatconversie kan het zichtbare resultaat wijzigen, zelfs wanneer de veld‑identifier nog aanwezig is.