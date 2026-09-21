---
title: Beheer tekstvelden in PowerPoint-presentaties in Java
linktitle: Tekstvelden
type: docs
weight: 52
url: /nl/java/text-fields/
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
- Java
- Aspose.Slides
description: "Maak, inspecteer, wijzig en verwijder tekstvelden in PowerPoint-presentaties met Aspose.Slides voor Java. Behoud opmaak en verifieer opgeslagen PPTX- en PPT-bestanden."
---
## **Overzicht**

Een tekstalinea bestaat uit delen. Een gewone [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) bevat letterlijke tekst; een velddeel heeft ook een [IField](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifield/) waarvan het type een automatisch bijgewerkte waarde identificeert, zoals een slidernummer of datum. Twee delen kunnen dezelfde tekens weergeven terwijl slechts één een veld bevat.

Gebruik [IPortion.getField](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#getField--) om ze te onderscheiden: het is `null` voor gewone tekst. [IPortion.addField](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) zet een bestaand deel om in een veld. Houd een label en zijn dynamische waarde in gescheiden delen zodat het converteren van de waarde niet ook het label vervangt.

Deze gids behandelt velden in tekst, hun opmaak en het opslaan ervan in PPTX en PPT. Voor tekstframes en alinea's, zie [Tekst beheren](/slides/nl/java/manage-text/).

## **Maak een dia‑nummer‑veld**

Het volgende volledige voorbeeld maakt een tekstvak dat een letterlijke `Slide `‑label bevat, gevolgd door een automatisch bijgewerkt nummer. Het stelt de grootte, dikte en kleur van het nummer in voordat het veld wordt toegevoegd, opent vervolgens de opgeslagen presentatie opnieuw en controleert het veldtype, de tekst en de opmaak. Er is geen invoerbestand vereist.

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

De nieuwe presentatie start met dia‑nummer 1, dus de tekst is `Slide 1`, en beide controles geven `true` weer. Het nummer blijft een veld na het opnieuw openen; het is geen letterlijke `1`. De casts en indexen in de verificatie verwijzen naar de vorm en de delen die door dit voorbeeld zijn aangemaakt.

## **Kies een veldtype**

[FieldType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/) implementeert [IFieldType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifieldtype/) en biedt de volgende methoden om vooraf gedefinieerde waarden op te halen. Geef de juiste waarde door aan [addField](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Methode | Doel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Het huidige dia‑nummer. |
| [getDateTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getDateTime--) | Datum/tijd in het standaardformaat van de renderende applicatie. |
| [getDateTime1](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getDateTime9--) | Vooraf gedefinieerde datum‑ of gecombineerde datum/tijd‑formaten. |
| [getDateTime10](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getDateTime13--) | Vooraf gedefinieerde tijdformaten, met opties voor seconden en een 12‑urige klok. |
| [getHeader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getHeader--) | Een koptekst‑veld; zie hieronder de beperkingen voor de placeholder en het formaat. |
| [getFooter](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getFooter--) | Een voettekst‑veld. |

Bijvoorbeeld, [getDateTime3](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#getDateTime3--) vertegenwoordigt een dag, de volledige maandnaam en het jaar in het Engels. Dit zijn vooraf gedefinieerde veldformaten, geen willekeurige Java‑datum‑opmaak‑strings. De taal die is ingesteld met [setLanguageId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) en de applicatie die de presentatie verwerkt, kan het weergegeven resultaat beïnvloeden.

## **Maak een veld aan vanuit een interne tekenreeks**

De string‑overload van [addField](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#addField-java.lang.String-) accepteert een interne veld‑identificator. Gebruik deze wanneer je een identificator wilt behouden die door een andere applicatie is geleverd en geen vooraf gedefinieerde waarde heeft. Je kunt ook een [FieldType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) construeren vanuit de identificator. [IFieldType.getInternalString](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifieldtype/#getInternalString--) maakt die identificator zichtbaar voor inspectie.

Dit voorbeeld slaat een toepassingsspecifiek `custom-report-id`‑veld op met de fallback‑tekst `Report-042`. De identificator registreert geen berekening: Aspose.Slides genereert geen rapport‑ID's voor een onbekend type. De applicatie die deze identificator begrijpt, moet de betekenis leveren en de waarde bijwerken.

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

Na deze PPTX‑rondreis is het type `custom-report-id` en de tekst `Report-042`. Het doorgeven van een tekenreeks zoals `yyyy-MM-dd` zou een veldtype benoemen; het zou geen aangepast datumformaat configureren. Voor een vaste datum in een willekeurig formaat, gebruik gewone tekst.

## **Inspecteer, wijzig en verwijder datum‑/tijd‑velden**

Wijzig een bestaand veld via [IField.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Controleer dat het veld bestaat voordat je het type benadert. Om automatische updates te stoppen, roep je [IPortion.removeField](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#removeField--) aan. Dit behoudt het deel en de huidige tekst terwijl de veld‑associatie wordt verwijderd. Als je een specifieke vaste waarde nodig hebt, ken die tekst toe nadat het veld is verwijderd.

Voor de API‑instelling die verband houdt met de verwerking van datum‑/tijd‑velden, zie [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Het onderstaande voorbeeld gebruikt een expliciete goedkeuringsdatum bij het converteren van een veld naar gewone tekst.

Download [sample.pptx](sample.pptx) en plaats het in de werkmap. Het bevat twee benoemde tekstvormen, `UpdatedAt` en `ApprovedDate`, elk met een datum/tijd‑veld, plus gewone tekstlabels. Het volgende voorbeeld doorloopt de tekstvormen op het hoogste niveau op gewone dia's. Het verandert datum/tijd‑velden naar een lange‑datumnotatie en maakt ze cursief, terwijl hun andere opmaak behouden blijft. Alleen velden in `ApprovedDate` worden vaste tekst.

Het voorbeeld herkent de ingebouwde interne identificatoren `datetime` en `datetime1` tot `datetime13`. Groepen, tabellen, notities, lay‑outs en masters vereisen het doorlopen van hun eigen tekstopsluiters en vallen buiten de scope van dit voorbeeld.

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

Na het opnieuw openen heeft `UpdatedAt` type `datetime3` en blijft dynamisch. `ApprovedDate` heeft geen veld en bevat `05 April 2030`. Beide datumdelen zijn cursief, en hun oorspronkelijke lettergrootte, vet‑instelling en kleur blijven ongewijzigd. De gewone tekstlabels blijven hetzelfde. De verificatie leest het eerste deel van de twee bekende vormen in het meegeleverde voorbeeld.

## **Behoud tekstopmaak**

Werk met het bestaande deel bij het toevoegen, wijzigen of verwijderen van een veld. Deze bewerkingen behouden de opmaak van dat deel. Gebruik [IPortion.getPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#getPortionFormat--) om alleen de vereiste eigenschappen te wijzigen, zoals de voorbeelden doen voor kleur of cursief.

Vermijd het volledig opnieuw bouwen van een tekstframe alleen om één veld bij te werken: dit kan de oorspronkelijke deelgrenzen en hun individuele opmaak verliezen. Onderscheid ook expliciet ingestelde opmaak van opmaak die geërfd is van de alinea, lay‑out of thema. Zie [Tekstopmaak](/slides/nl/java/text-formatting/) voor uitgebreidere opmaakopties.

## **Velden en kop‑/voettekst‑plaatsaanduidingen**

Een veld maakt deel uit van een tekstdeel. Een placeholder (plaatsaanduiding) is een vorm met een presentatierol, zoals een voettekst of dia‑nummer. Het toevoegen van een veld aan een gewoon tekstvak maakt die vorm niet tot een placeholder.

De kop‑/voettekst‑beheerders regelen de placeholder‑tekst en -zichtbaarheid op dia's, lay‑outs en masters, inclusief de voortplanting naar afhankelijke dia's. Een nummer‑veld in een aangepast tekstvak kan daarom nuttig zijn, zelfs als je de dia‑nummer‑placeholder niet gebruikt. Omgekeerd verwijdert het wijzigen van de placeholder‑zichtbaarheid geen veld uit een niet‑gerelateerd tekstvak.

De vooraf gedefinieerde header‑ en footer‑types creëren niet de corresponderende placeholders of leveren hun inhoud. Met name heeft een reguliere PowerPoint‑dia geen header‑placeholder; headers behoren tot notitie‑pagina's en hand‑outs. Neem niet aan dat een header‑ of footer‑veld in een willekeurige vorm automatisch de via een placeholder‑manager geconfigureerde tekst krijgt. Voor die werkwijze, zie [Presentatie‑kop‑en‑voetteksten](/slides/nl/java/presentation-header-and-footer/).

## **PPTX‑ en PPT‑beperkingen**

Controleer zowel het veldtype als de resulterende tekst na het opslaan en opnieuw openen. Het behouden van een identificator bewijst niet dat een applicatie de waarde kan berekenen of weergeven.

| Formaat | Gedrag en beperkingen van het veld |
|---|---|
| PPTX | Slaat interne veldidentificatoren op naast de veldtekst. In rondreis‑controles overleefden de vooraf gedefinieerde types en de hierboven gebruikte aangepaste identificator het opslaan en opnieuw openen. Het onbekende aangepaste type behield zijn fallback‑tekst; het kreeg geen automatische berekeningslogica. Een andere applicatie kan niet‑ondersteunde identificatoren anders behandelen. |
| PPT | Gebruikt legacy‑veldrepresentaties en heeft een meer beperkte compatibiliteit. In rondreis‑controles overleefden slide‑number‑ en vooraf gedefinieerde datum/tijd‑velden het opslaan en opnieuw openen. Een aangepast veld in een gewone dia‑tekstbox werd geopend met zijn identificator maar met `*` als tekst; een header‑veld in dezelfde context produceerde eveneens `*`. Reken niet op dat aangepaste velden of niet‑ondersteunde veldcontexten hun zichtbare tekst behouden. |

Voor draagbare, vaste output, converteer niet‑ondersteunde velden naar gewone tekst en ken de gewenste waarde expliciet toe vóór het opslaan. Dit behoudt de gekozen tekst maar stopt opzettelijk automatische updates. Test ook de doelapplicatie wanneer haar eigen veldherberekening deel uitmaakt van je workflow.

## **FAQ**

**Hoe kan ik zien of een weergegeven nummer of datum een veld is?**

Inspecteer [IPortion.getField](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#getField--). Een niet‑nul waarde identificeert een veld; de weergegeven tekst alleen kan dit niet aangeven.

**Verwijdert het verwijderen van een veld de tekst of opmaak?**

Nee. [removeField](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#removeField--) zet het bestaande deel om naar gewone tekst. Ken daarna een expliciete waarde toe als je een specifieke vaste datum of fallback‑tekst nodig hebt.

**Kan een interne tekenreeks een nieuw datumformaat of formule definiëren?**

Nee. Het identificeert een veldtype. Een onbekende identificator biedt geen evaluator of een Java‑datum‑opmaak‑patroon. Gebruik een ondersteund vooraf gedefinieerd type of formatteer een waarde zelf als gewone tekst.

**Waarom een presentatie opnieuw controleren na het opslaan?**

Veld‑identificatoren, berekende tekst en opmaak zijn aparte zaken die je moet verifiëren. Formaatconversie kan het zichtbare resultaat wijzigen, zelfs als de veld‑identificator nog aanwezig is.