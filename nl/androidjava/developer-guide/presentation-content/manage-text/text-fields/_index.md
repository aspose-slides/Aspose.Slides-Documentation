---
title: Beheer Tekstvelden in PowerPoint-presentaties op Android
linktitle: Tekstvelden
type: docs
weight: 52
url: /nl/androidjava/text-fields/
keywords:
- tekstveld
- automatische tekst
- dia-nummer
- datum en tijd
- koptekst
- voettekst
- tekstsegment
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Maak, inspecteer, wijzig en verwijder tekstvelden in PowerPoint-presentaties met Aspose.Slides voor Android via Java. Behoud opmaak en verifieer opgeslagen PPTX- en PPT-bestanden."
---
## **Overzicht**

Een tekstparagraaf bestaat uit segmenten. Een gewone [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/) bevat letterlijke tekst; een veldsegment heeft ook een [IField](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifield/) waarvan het type een automatisch bijgewerkte waarde identificeert, zoals een diapositienummer of datum. Twee segmenten kunnen dezelfde tekens tonen terwijl slechts één een veld bevat.

Gebruik [IPortion.getField](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#getField--) om ze te onderscheiden: het is `null` voor gewone tekst. [IPortion.addField](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) zet een bestaand segment om in een veld. Houd een label en de dynamische waarde in gescheiden segmenten, zodat het omzetten van de waarde niet ook het label vervangt.

Deze gids behandelt velden binnen tekst, hun opmaak en het opslaan ervan in PPTX en PPT. Voor tekstframes en alinea's, zie [Manage Text](/slides/nl/androidjava/manage-text/).

## **Maak een dia‑nummer veld**

Het volgende volledige voorbeeld maakt een tekstvak met een letterlijke `Slide `‑label gevolgd door een automatisch bijgewerkt nummer. Het stelt de grootte, dikte en kleur van het nummer in vóór het toevoegen van het veld, opent daarna de opgeslagen presentatie opnieuw en controleert het veldtype, de tekst en de opmaak. Er is geen invoerbestand nodig.

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

De nieuwe presentatie start met dia‑nummer 1, dus de tekst is `Slide 1`, en beide controles geven `true` weer. Het nummer blijft een veld na het heropenen; het is geen letterlijke `1`. De casts en indices in de verificatie verwijzen naar de vorm en segmenten die door dit voorbeeld zijn aangemaakt.

## **Kies een veldtype**

[FieldType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/) implementeert [IFieldType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifieldtype/) en biedt de volgende methoden om vooraf gedefinieerde waarden te verkrijgen. Geef de juiste waarde door aan [addField](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Methode | Doel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Het huidige dia‑nummer. |
| [getDateTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Datum/tijd in het standaardformaat van de renderende toepassing. |
| [getDateTime1](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Vooraf gedefinieerde datum- of gecombineerde datum/tijd‑formaten. |
| [getDateTime10](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Vooraf gedefinieerde tijdformaten, met opties voor seconden en een 12‑uur klok. |
| [getHeader](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Een koptekstveld; zie de onderstaande beperkingen voor placeholders en opmaak. |
| [getFooter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Een voettekstveld. |

Bijvoorbeeld, [getDateTime3](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) vertegenwoordigt een dag, volledige maandnaam en jaar in het Engels. Dit zijn vooraf gedefinieerde veldformaten, geen willekeurige Java‑datumnotatiestrings. De taal die ingesteld is met [setLanguageId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) en de toepassing die de presentatie verwerkt, kan het weergegeven resultaat beïnvloeden.

## **Maak een veld van een interne string**

De string‑overload van [addField](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) accepteert een interne veld‑identifier. Gebruik deze wanneer je een identifier wilt behouden die door een andere toepassing is geleverd en geen vooraf gedefinieerde waarde heeft. Je kunt ook een [FieldType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) uit de identifier construeren. [IFieldType.getInternalString](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) maakt die identifier zichtbaar voor inspectie.

Dit voorbeeld slaat een toepassingsspecifiek `custom-report-id`‑veld op met de fallback‑tekst `Report-042`. De identifier registreert geen berekening: Aspose.Slides genereert geen rapport‑ID’s voor een onbekend type. De toepassing die deze identifier begrijpt moet de betekenis leveren en de waarde bijwerken.

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

Na deze PPTX‑ronde is het type `custom-report-id` en de tekst `Report-042`. Het doorgeven van een string zoals `yyyy-MM-dd` zou een veldtype benoemen; het zou geen aangepast datumformaat configureren. Voor een vaste datum in een willekeurig formaat, gebruik gewone tekst.

## **Inspecteer, wijzig en verwijder datum/tijd‑velden**

Wijzig een bestaand veld via [IField.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Controleer dat het veld bestaat voordat je het type benadert. Om automatische updates te stoppen, roep je [IPortion.removeField](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#removeField--). Dit behoudt het segment en de huidige tekst terwijl de veld‑associatie wordt verwijderd. Als je een specifieke vaste waarde nodig hebt, ken die tekst dan toe na het verwijderen van het veld.

Voor de API‑instelling die verband houdt met de verwerking van datum/tijd‑velden, zie [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Het onderstaande voorbeeld gebruikt een expliciete goedkeuringsdatum bij het omzetten van een veld naar gewone tekst.

Download [sample.pptx](sample.pptx) en plaats het in de werkmap. Het bevat twee benoemde tekstvormen, `UpdatedAt` en `ApprovedDate`, elk met een datum/tijd‑veld, plus gewone tekstlabels. Het volgende voorbeeld doorloopt de tekstvormen op top‑niveau op reguliere dia’s. Het wijzigt datum/tijd‑velden naar een lang‑datumnotatie en maakt ze cursief, terwijl de overige opmaak behouden blijft. Alleen velden in `ApprovedDate` worden vaste tekst.

Het voorbeeld herkent de ingebouwde interne identifiers `datetime` en `datetime1` tot en met `datetime13`. Groepen, tabellen, aantekeningen, lay-outs en masters vereisen een doorloop van hun eigen tekstopslag en vallen buiten de reikwijdte van dit voorbeeld.

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

Na het heropenen heeft `UpdatedAt` type `datetime3` en blijft dynamisch. `ApprovedDate` heeft geen veld en bevat `05 April 2030`. Beide datumsegmenten zijn cursief, en hun oorspronkelijke lettergrootte, vetinstelling en kleur blijven ongewijzigd. De gewone tekstlabels blijven onveranderd. De verificatie leest het eerste segment van de twee bekende vormen in het meegeleverde voorbeeld.

## **Behoud tekstopmaak**

Werk met het bestaande segment bij het toevoegen, wijzigen of verwijderen van een veld. Deze bewerkingen behouden de opmaak van dat segment. Gebruik [IPortion.getPortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#getPortionFormat--) om alleen de benodigde eigenschappen te wijzigen, zoals de voorbeelden doen voor kleur of cursief.

Vermijd het opnieuw opbouwen van een volledig tekstframe alleen om één veld bij te werken: dat kan de oorspronkelijke segmentgrenzen en hun individuele opmaak doen verloren gaan. Maak ook onderscheid tussen expliciet ingestelde opmaak en opmaak die is geërfd van de alinea, lay‑out of thema. Zie [Text Formatting](/slides/nl/androidjava/text-formatting/) voor bredere opmaakopties.

## **Velden en kop‑/voettekst‑placeholders**

Een veld maakt deel uit van een tekstsegment. Een placeholder is een vorm met een presentatierol, zoals een voettekst of dia‑nummer. Een veld toevoegen aan een gewoon tekstvak maakt die vorm niet tot een placeholder.

De kop‑/voettekst‑beheerders regelen placeholder‑tekst en zichtbaarheid op dia’s, lay-outs en masters, inclusief voortzetting naar afhankelijke dia’s. Een nummer‑veld in een aangepast tekstvak kan daarom nuttig zijn, zelfs wanneer je de dia‑nummer‑placeholder niet gebruikt. Omgekeerd verwijdert het wijzigen van de zichtbaarheid van een placeholder geen veld uit een niet‑gerelateerd tekstvak.

De vooraf gedefinieerde kop‑ en voettekst‑types creëren niet de overeenkomstige placeholders of leveren hun inhoud. In het bijzonder heeft een reguliere PowerPoint‑dia geen kop‑placeholder; koppen behoren tot notitie‑pagina’s en hand‑outs. Ga er niet van uit dat een kop‑ of voettekst‑veld in een willekeurige vorm automatisch de via een placeholder‑manager ingestelde tekst krijgt. Voor die werkwijze, zie [Presentation Headers and Footers](/slides/nl/androidjava/presentation-header-and-footer/).

## **PPTX‑ en PPT‑beperkingen**

Controleer zowel het veldtype als de resulterende tekst na het opslaan en opnieuw openen. Het behouden van een identifier bewijst niet dat een toepassing de waarde kan berekenen of weergeven.

| Formaat | Veldgedrag en beperkingen |
|---|---|
| PPTX | Slaat interne veld‑identifiers op naast veldtekst. In round‑trip‑controles overleefden de vooraf gedefinieerde types en de hierboven gebruikte aangepaste identifier het opslaan en opnieuw openen. Het onbekende aangepaste type behield zijn fallback‑tekst; het verwierf geen automatische berekeningslogica. Een andere toepassing kan onbekende identifiers anders behandelen. |
| PPT | Gebruikt legacy‑veldrepresentaties en heeft een beperktere compatibiliteit. In round‑trip‑controles overleefden dia‑nummer‑ en vooraf gedefinieerde datum/tijd‑velden het opslaan en opnieuw openen. Een aangepast veld in een gewoon tekstvak van een dia werd heropend met zijn identifier maar met `*` als tekst; een kop‑veld in dezelfde context produceerde eveneens `*`. Vertrouw niet op dat aangepaste velden of niet‑ondersteunde veld‑contexten hun zichtbare tekst behouden. |

Voor draagbare, vaste output, zet niet‑ondersteunde velden om naar gewone tekst en ken expliciet de gewenste waarde toe vóór het opslaan. Dit behoudt de gekozen tekst maar stopt opzettelijk automatische updates. Test de doeltoepassing ook wanneer haar eigen veldherberekening deel uitmaakt van je werkwijze.

## **FAQ**

**Hoe kan ik zien of een weergegeven nummer of datum een veld is?**

Inspecteer [IPortion.getField](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#getField--). Een niet‑null waarde geeft aan dat het een veld is; de weergegeven tekst alleen kan dat niet aantonen.

**Verwijdert het verwijderen van een veld zijn tekst of opmaak?**

Nee. [removeField](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#removeField--) zet het bestaande segment om naar gewone tekst. Ken daarna een expliciete waarde toe als je een specifieke vaste datum of fallback‑waarde nodig hebt.

**Kan een interne string een nieuw datumformaat of formule definiëren?**

Nee. Het identificeert een veldtype. Een onbekende identifier levert geen evaluator of een Java‑datumnotatie‑patroon. Gebruik een ondersteund vooraf gedefinieerd type of formatteer een waarde zelf als gewone tekst.

**Waarom een presentatie opnieuw controleren na het opslaan?**

Veldidentifiers, berekende tekst en opmaak zijn afzonderlijke zaken die moeten worden gecontroleerd. Formaatconversie kan het zichtbare resultaat wijzigen, zelfs wanneer de veld‑identifier nog aanwezig is.