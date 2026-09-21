---
title: Beheer tekstvelden in PowerPoint-presentaties in JavaScript
linktitle: Tekstvelden
type: docs
weight: 52
url: /nl/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak, inspecteer, wijzig en verwijder tekstvelden in PowerPoint-presentaties met Aspose.Slides voor Node.js via Java. Behoud de opmaak en verifieer opgeslagen PPTX- en PPT-bestanden."
---
## **Overzicht**

Een tekstparagraaf bestaat uit delen. Een gewone [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) bevat letterlijke tekst; een velddeel heeft ook een [Field](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/field/) waarvan het type een automatisch bijgewerkte waarde identificeert, zoals een slide‑nummer of datum. Twee delen kunnen dezelfde tekens weergeven terwijl slechts één een veld bevat.

Gebruik [Portion.getField](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#getField) om ze te onderscheiden: het is `null` voor gewone tekst. [Portion.addField](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#addField) zet een bestaande portion om in een veld. Houd een label en zijn dynamische waarde in afzonderlijke portions zodat het omzetten van de waarde het label niet ook vervangt.

Deze gids behandelt velden in tekst, hun opmaak, en het opslaan ervan in PPTX en PPT. Voor tekstframes en alinea's, zie [Manage Text](/slides/nl/nodejs-java/manage-text/).

## **Maak een Slide‑nummer‑veld**

Het volgende volledige voorbeeld maakt een tekstvak met een letterlijke `Slide `‑label, gevolgd door een automatisch bijgewerkt nummer. Het stelt de grootte, dikte en kleur van het nummer in voordat het veld wordt toegevoegd, opent daarna de opgeslagen presentatie opnieuw en controleert het veldtype, de tekst en de opmaak. Er is geen invoerbestand vereist.

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

De nieuwe presentatie begint met slide‑nummer 1, dus de tekst is `Slide 1`, en beide controles geven `true` weer. Het nummer blijft een veld na het opnieuw openen; het is geen letterlijke `1`. De indices in de verificatie verwijzen naar de vorm en de portions die door dit voorbeeld zijn gemaakt.

## **Kies een veldtype**

[FieldType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/) biedt de volgende methoden om vooraf gedefinieerde waarden op te halen. Geef de juiste waarde door aan [addField](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#addField).

| Methode | Doel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Het huidige slide‑nummer. |
| [getDateTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Datum/tijd in het standaardformaat van de rendering‑applicatie. |
| [getDateTime1](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Vooraf gedefinieerde datum‑ of gecombineerde datum/tijd‑formaten. |
| [getDateTime10](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Vooraf gedefinieerde tijdformaten, met opties voor seconden en een 12‑uur klok. |
| [getHeader](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getHeader) | Een header‑veld; zie de placeholder‑ en format‑beperkingen hieronder. |
| [getFooter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getFooter) | Een footer‑veld. |

Bijvoorbeeld, [getDateTime3](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getDateTime3) staat voor een dag, volledige maandnaam en jaar in het Engels. Dit zijn vooraf gedefinieerde veldformaten, geen willekeurige datum‑formatteer‑strings. De taal die met [setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) is ingesteld en de applicatie die de presentatie verwerkt, kunnen het weergegeven resultaat beïnvloeden.

## **Maak een veld aan vanuit een interne string**

De string‑overload van [addField](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#addField) accepteert een interne veld‑identifier. Gebruik deze wanneer je een identifier wilt behouden die door een andere applicatie is geleverd en geen vooraf gedefinieerde waarde heeft. Je kunt ook een [FieldType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/) uit de identifier construeren. [FieldType.getInternalString](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fieldtype/#getInternalString) maakt die identifier beschikbaar voor inspectie.

Dit voorbeeld slaat een toepassingsspecifiek `custom-report-id`‑veld op met de fallback‑tekst `Report-042`. De identifier registreert geen berekening: Aspose.Slides genereert geen rapport‑IDs voor een onbekend type. De applicatie die deze identifier begrijpt, moet de betekenis leveren en de waarde bijwerken.

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

Na deze PPTX‑ronde‑trip is het type `custom-report-id` en de tekst `Report-042`. Het doorgeven van een string zoals `yyyy-MM-dd` zou een veldtype benoemen; het zou geen aangepast datumformaat configureren. Voor een vaste datum in een willekeurig formaat, gebruik gewone tekst.

## **Inspecteer, wijzig en verwijder datum/tijd‑velden**

Wijzig een bestaand veld via [Field.setType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/field/#setType). Controleer dat het veld bestaat voordat je het type benadert. Om automatische updates te stoppen, roep [Portion.removeField](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#removeField) aan. Hiermee behoud je de portion en de huidige tekst terwijl de veld‑associatie wordt verwijderd. Als je een specifieke vaste waarde nodig hebt, wijs die tekst toe na het verwijderen van het veld.

Voor de API‑instelling die verband houdt met de verwerking van datum/tijd‑velden, zie [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Het onderstaande voorbeeld gebruikt een expliciete goedkeuringdatum bij het omzetten van een veld naar gewone tekst.

Download [sample.pptx](sample.pptx) en plaats het in de werkmap. Het bevat twee benoemde tekstvormen, `UpdatedAt` en `ApprovedDate`, elk met een datum/tijd‑veld, plus gewone tekstlabels. Het volgende voorbeeld doorloopt de top‑level tekstvormen op gewone slides. Het wijzigt datum/tijd‑velden naar een lang‑datumnotatie en maakt ze cursief, terwijl de overige opmaak behouden blijft. Alleen velden in `ApprovedDate` worden vaste tekst.

De goedkeuringdatum is 5 april 2030; JavaScript‑maandindices beginnen bij nul, dus april is `3`. UTC wordt gebruikt voor zowel constructie als opmaak om de datum onafhankelijk van de lokale tijdzone te houden.

Het voorbeeld herkent de ingebouwde interne identifiers `datetime` en `datetime1` tot `datetime13`. Groepen, tabellen, notities, lay-outs en masters vereisen een doorloop van hun eigen tekstelementen en vallen buiten de reikwijdte van dit voorbeeld.

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

Na het opnieuw openen heeft `UpdatedAt` type `datetime3` en blijft dynamisch. `ApprovedDate` heeft geen veld en bevat `05 April 2030`. Beide datum‑portions zijn cursief, en hun oorspronkelijke lettergrootte, vetinstelling en kleur blijven behouden. De gewone tekstlabels blijven ongewijzigd. De verificatie leest de eerste portion van de twee bekende vormen in het meegeleverde voorbeeld.

## **Behoud tekstopmaak**

Werk met de bestaande portion bij het toevoegen, wijzigen of verwijderen van een veld. Deze operaties behouden de opmaak van die portion. Gebruik [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#getPortionFormat) om alleen de benodigde eigenschappen te wijzigen, zoals de voorbeelden doen voor kleur of cursief.

Vermijd het herbouwen van een geheel tekstframe alleen om één veld bij te werken: dit kan de oorspronkelijke portion‑grenzen en hun afzonderlijke opmaak verliezen. Onderscheid ook expliciet ingestelde opmaak van opmaak die geërfd is van de alinea, lay-out of thema. Zie [Text Formatting](/slides/nl/nodejs-java/text-formatting/) voor bredere opmaakopties.

## **Velden en header/footer‑placeholders**

Een veld is onderdeel van een tekst‑portion. Een placeholder is een vorm met een presentatie‑rol, zoals een footer of slide‑nummer. Het toevoegen van een veld aan een gewone tekstbox maakt die vorm niet tot een placeholder.

De header/footer‑managers beheren de placeholder‑tekst en zichtbaarheid op slides, lay-outs en masters, inclusief voortplanting naar afhankelijke slides. Een nummer‑veld in een aangepaste tekstbox kan daarom nuttig zijn, zelfs wanneer je de slide‑nummer placeholder niet gebruikt. Omgekeerd verwijdert het wijzigen van de placeholder‑zichtbaarheid geen veld uit een niet‑gerelateerde tekstbox.

De vooraf gedefinieerde header‑ en footertype maken de bijbehorende placeholders niet aan en leveren hun inhoud niet. In het bijzonder heeft een gewone PowerPoint‑slide geen header‑placeholder; headers behoren tot notitiepagina's en hand‑outs. Neem niet aan dat een header‑ of footer‑veld in een willekeurige vorm automatisch de via een placeholder‑manager geconfigureerde tekst krijgt. Voor die werkwijze, zie [Presentation Headers and Footers](/slides/nl/nodejs-java/presentation-header-and-footer/).

## **PPTX‑ en PPT‑beperkingen**

Controleer zowel het veldtype als de resulterende tekst na opslaan en opnieuw openen. Het behouden van een identifier bewijst niet dat een applicatie de waarde kan berekenen of weergeven.

| Formaat | Gedrag van veld en beperkingen |
|---|---|
| PPTX | Slaat interne veld‑identifiers op naast de veldtekst. In round‑trip‑controles overleefden de vooraf gedefinieerde types en de hierboven gebruikte aangepaste identifier het opslaan en opnieuw openen. Het onbekende aangepaste type behield zijn fallback‑tekst; het kreeg geen automatische berekeningslogica. Een andere applicatie kan onbekende identifiers anders behandelen. |
| PPT | Gebruikt legacy‑veld‑representaties en heeft een beperktere compatibiliteit. In round‑trip‑controles overleefden slide‑nummer‑ en vooraf gedefinieerde datum/tijd‑velden het opslaan en opnieuw openen. Een aangepast veld in een gewone slide‑tekstbox werd opnieuw geopend met zijn identifier maar met `*` als tekst; een header‑veld in dezelfde context produceerde ook `*`. Vertrouw niet op aangepaste velden of niet‑ondersteunde veld‑contexten die hun zichtbare tekst behouden. |

Voor draagbare, vaste output, converteer niet‑ondersteunde velden naar gewone tekst en wijs expliciet de gewenste waarde toe vóór het opslaan. Dit behoudt de gekozen tekst maar stopt bewust automatische updates. Test de doelapplicatie ook wanneer haar eigen veldherberekening deel uitmaakt van je workflow.

## **FAQ**

**Hoe kan ik zien of een weergegeven nummer of datum een veld is?**

Inspecteer [Portion.getField](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#getField). Een niet‑null waarde identificeert een veld; alleen de weergegeven tekst kan het niet laten zien.

**Verwijdert het verwijderen van een veld de tekst of opmaak?**

Nee. [removeField](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#removeField) zet de bestaande portion om naar gewone tekst. Wijs daarna een expliciete waarde toe als je een specifieke vaste datum of fallback‑waarde nodig hebt.

**Kan een interne string een nieuw datumformaat of formule definiëren?**

Nee. Het identificeert een veldtype. Een onbekende identifier levert geen evaluator of datum‑formaat‑patroon. Gebruik een ondersteund vooraf gedefinieerd type of formatteer een waarde zelf als gewone tekst.

**Waarom een presentatie opnieuw controleren na het opslaan?**

Veld‑identifiers, berekende tekst en opmaak zijn afzonderlijke zaken die gecontroleerd moeten worden. Formaatconversie kan het zichtbare resultaat wijzigen, zelfs wanneer de veld‑identifier nog aanwezig is.