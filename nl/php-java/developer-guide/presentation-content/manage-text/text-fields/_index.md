---
title: Tekstvelden beheren in PowerPoint-presentaties in PHP
linktitle: Tekstvelden
type: docs
weight: 52
url: /nl/php-java/text-fields/
keywords:
- tekstveld
- automatische tekst
- dia-nummer
- datum en tijd
- koptekst
- voettekst
- tekstgedeelte
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Maak, inspecteer, wijzig en verwijder tekstvelden in PowerPoint-presentaties met Aspose.Slides voor PHP via Java. Behoud de opmaak en verifieer de opgeslagen PPTX- en PPT-bestanden."
---
## **Overzicht**

Een tekstparagraaf bestaat uit portions. Een gewone [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) bevat letterlijke tekst; een veld‑portion heeft ook een [Field](https://reference.aspose.com/slides/nl/php-java/aspose.slides/field/) waarvan het type een automatisch bijgewerkte waarde identificeert, zoals een dia‑nummer of datum. Twee portions kunnen dezelfde tekens weergeven terwijl slechts één een veld bevat.

Gebruik [Portion::getField](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getField) om ze te onderscheiden: het is `null` voor gewone tekst. [Portion::addField](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#addField) zet een bestaande portion om in een veld. Houd een label en de dynamische waarde in afzonderlijke portions, zodat het converteren van de waarde het label niet ook vervangt.

Deze gids behandelt velden in tekst, hun opmaak en het opslaan ervan in PPTX en PPT. Voor tekstframes en paragrafen, zie [Manage Text](/slides/nl/php-java/manage-text/).

## **Maak een dia‑nummer veld**

Het volgende volledige voorbeeld maakt een tekstvak met een letterlijk `Slide ` label gevolgd door een automatisch bijgewerkt nummer. Het stelt de grootte, het gewicht en de kleur van het nummer in voordat het veld wordt toegevoegd, opent vervolgens de opgeslagen presentatie opnieuw en controleert het veldtype, de tekst en de opmaak. Er is geen invoerbestand vereist.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

De nieuwe presentatie start met dia‑nummer 1, dus de tekst is `Slide 1`, en beide controles geven `true` weer. Het nummer blijft een veld na het opnieuw openen; het is geen letterlijk `1`. De indices in de verificatie verwijzen naar de vorm en de portions die door dit voorbeeld zijn gemaakt.

## **Kies een veldtype**

[FieldType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/) biedt de volgende methoden om vooraf gedefinieerde waarden op te halen. Geef de juiste waarde door aan [addField](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#addField).

| Methode | Doel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getSlideNumber) | Het huidige dia‑nummer. |
| [getDateTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getDateTime) | Datum/tijd in het standaardformaat van de renderende applicatie. |
| [getDateTime1](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getDateTime9) | Vooraf gedefinieerde datum‑ of gecombineerde datum/tijd‑formaten. |
| [getDateTime10](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getDateTime13) | Vooraf gedefinieerde tijdformaten, met opties voor seconden en een 12‑uur klok. |
| [getHeader](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getHeader) | Een header‑veld; zie de placeholder‑ en format‑beperkingen hieronder. |
| [getFooter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getFooter) | Een footer‑veld. |

Bijvoorbeeld, [getDateTime3](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getDateTime3) vertegenwoordigt een dag, volledige maandnaam en jaar in het Engels. Dit zijn vooraf gedefinieerde veldformaten, geen willekeurige PHP‑datum‑formatteer‑strings. De taal die met [setLanguageId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) is ingesteld en de applicatie die de presentatie verwerkt, kunnen het weergegeven resultaat beïnvloeden.

## **Maak een veld vanuit een interne string**

De string‑overload van [addField](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#addField) accepteert een interne veld‑identifier. Gebruik deze wanneer u een identifier behoudt die door een andere applicatie is geleverd en waarvoor geen vooraf gedefinieerde waarde bestaat. U kunt ook een [FieldType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#FieldType) uit de identifier samenstellen. [FieldType::getInternalString](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fieldtype/#getInternalString) maakt die identifier beschikbaar voor inspectie.

Dit voorbeeld slaat een applicatiespecifiek `custom-report-id` veld op met de fallback‑tekst `Report-042`. De identifier registreert geen berekening: Aspose.Slides genereert geen rapport‑ID’s voor een onbekend type. De applicatie die deze identifier begrijpt, moet de betekenis leveren en de waarde bijwerken.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Na deze PPTX‑round‑trip is het type `custom-report-id` en de tekst `Report-042`. Het doorgeven van een string zoals `Y-m-d` zou een veldtype benoemen; het zou geen aangepast datumformaat configureren. Voor een vaste datum in een willekeurig formaat, gebruik gewone tekst.

## **Inspecteer, wijzig en verwijder datum/tijd‑velden**

Wijzig een bestaand veld via [Field::setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/field/#setType). Controleer dat het veld bestaat vóór u zijn type benadert. Om automatische updates te stoppen, roep [Portion::removeField](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#removeField) aan. Dit behoudt de portion en de huidige tekst terwijl de veldassociatie wordt verwijderd. Als u een specifieke vaste waarde nodig heeft, ken die tekst toe nadat het veld is verwijderd.

Voor de API‑instelling die verband houdt met de verwerking van datum/tijd‑velden, zie [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#setCurrentDateTime). Het onderstaande voorbeeld gebruikt een expliciete goedkeuringsdatum bij het omzetten van een veld naar gewone tekst.

Download [sample.pptx](sample.pptx) en plaats het in de JavaBridge‑werkmap, of geef het absolute pad door aan de presentatie‑constructor. Het bevat twee benoemde tekstvormen, `UpdatedAt` en `ApprovedDate`, elk met een datum/tijd‑veld, plus gewone tekstlabels. Het volgende voorbeeld doorloopt de bovenliggende tekstvormen op gewone dia’s. Het verandert datum/tijd‑velden naar een lange‑datumnotatie en maakt ze cursief, terwijl andere opmaak behouden blijft. Alleen velden in `ApprovedDate` worden vaste tekst.

Het voorbeeld herkent de ingebouwde interne identifiers `datetime` en `datetime1` t/m `datetime13`. Groepen, tabellen, notities, lay‑outs en masters vereisen een eigen doorloop van hun tekstcontainers en vallen buiten de scope van dit voorbeeld.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Na het opnieuw openen heeft `UpdatedAt` type `datetime3` en blijft dynamisch. `ApprovedDate` heeft geen veld en bevat `05 April 2030`. Beide datum‑portions zijn cursief, en hun oorspronkelijke lettergrootte, vetinstelling en kleur blijven ongewijzigd. De gewone tekstlabels blijven ongewijzigd. De verificatie leest de eerste portion van de twee bekende vormen in het meegeleverde voorbeeld.

## **Behoud tekstopmaak**

Werk met de bestaande portion bij het toevoegen, wijzigen of verwijderen van een veld. Deze bewerkingen behouden de opmaak van die portion. Gebruik [Portion::getPortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getPortionFormat) om alleen de benodigde eigenschappen te wijzigen, zoals de voorbeelden voor kleur of cursief doen.

Vermijd het opnieuw opbouwen van een volledig tekstframe alleen om één veld bij te werken: dat kan de oorspronkelijke portion‑grenzen en hun individuele opmaak verliezen. Onderscheid ook expliciet ingestelde opmaak van opmaak die geërfd wordt van de paragraaf, lay‑out of thema. Zie [Text Formatting](/slides/nl/php-java/text-formatting/) voor bredere opmaakopties.

## **Velden en header/footer placeholders**

Een veld maakt deel uit van een tekst‑portion. Een placeholder is een vorm met een presentatierol, zoals een footer of dia‑nummer. Het toevoegen van een veld aan een gewone tekstbox verandert die vorm niet in een placeholder.

De header/footer‑managers regelen placeholder‑tekst en zichtbaarheid op dia’s, lay‑outs en masters, inclusief voortplanting naar afhankelijke dia’s. Een nummer‑veld in een aangepaste tekstbox kan daarom nuttig zijn, zelfs wanneer u de dia‑nummer‑placeholder niet gebruikt. Omgekeerd verwijdert het wijzigen van de placeholder‑zichtbaarheid geen veld uit een niet‑gerelateerde tekstbox.

De vooraf gedefinieerde header‑ en footertype maken de overeenkomstige placeholders niet aan en leveren hun inhoud niet. Een gewone PowerPoint‑dia heeft bijvoorbeeld geen header‑placeholder; headers behoren tot notitie‑pagina’s en handouts. Neem niet aan dat een header‑ of footer‑veld in een willekeurige vorm automatisch de via een placeholder‑manager geconfigureerde tekst krijgt. Voor die werkwijze, zie [Presentation Headers and Footers](/slides/nl/php-java/presentation-header-and-footer/).

## **PPTX- en PPT-beperkingen**

Controleer zowel het veldtype als de resulterende tekst na het opslaan en opnieuw openen. Het behouden van een identifier bewijst niet dat een applicatie de waarde kan berekenen of weergeven.

| Formaat | Gedrag van veld en beperkingen |
|---|---|
| PPTX | Slaat interne veld‑identifiers op naast de veld‑tekst. In round‑trip‑controles overleefden de vooraf gedefinieerde types en de aangepaste identifier die hierboven werd gebruikt het opslaan en opnieuw openen. Het onbekende aangepaste type behield zijn fallback‑tekst; het verwierf geen automatische berekeningslogica. Een andere applicatie kan onbekende identifiers anders behandelen. |
| PPT | Gebruikt legacy‑veldrepresentaties en heeft beperktere compatibiliteit. In round‑trip‑controles overleefden dia‑nummer‑ en vooraf gedefinieerde datum/tijd‑velden het opslaan en opnieuw openen. Een aangepast veld in een gewone tekstbox opende met zijn identifier maar met `*` als tekst; een header‑veld in dezelfde context produceerde eveneens `*`. Vertrouw niet op aangepaste velden of niet‑ondersteunde veld‑contexten om hun zichtbare tekst te behouden. |

Voor draagbare, vaste output, converteer niet‑ondersteunde velden naar gewone tekst en wijs expliciet de gewenste waarde toe vóór het opslaan. Dit behoudt de gekozen tekst maar stopt opzettelijk automatische updates. Test de doelapplicatie ook wanneer haar eigen veld‑herberekening onderdeel is van uw workflow.

## **Veelgestelde vragen**

**Hoe kan ik zien of een weergegeven nummer of datum een veld is?**

Inspecteer [Portion::getField](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getField). Een niet‑null waarde identificeert een veld; de weergegeven tekst alleen kan dit niet aantonen.

**Verwijdert het verwijderen van een veld de tekst of opmaak?**

Nee. [removeField](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#removeField) zet de bestaande portion om in gewone tekst. Wijs daarna een expliciete waarde toe als u een specifieke bevroren datum of fallback‑tekst nodig heeft.

**Kan een interne string een nieuw datumformaat of formule definiëren?**

Nee. Het identificeert een veldtype. Een onbekende identifier levert geen evaluator of PHP‑datum‑formatteerpatroon. Gebruik een ondersteund vooraf gedefinieerd type of formatteer een waarde zelf als gewone tekst.

**Waarom de presentatie opnieuw controleren na het opslaan?**

Veld‑identifiers, berekende tekst en opmaak zijn afzonderlijke zaken die geverifieerd moeten worden. Formaatconversie kan het zichtbare resultaat wijzigen, zelfs wanneer de veld‑identifier nog aanwezig is.