---
title: "Hantera textfält i PowerPoint-presentationer i PHP"
linktitle: "Textfält"
type: docs
weight: 52
url: /sv/php-java/text-fields/
keywords:
- textfält
- automatisk text
- bildnummer
- datum och tid
- sidhuvud
- sidfot
- textdel
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Skapa, inspektera, ändra och ta bort textfält i PowerPoint-presentationer med Aspose.Slides för PHP via Java. Bevara formatering och verifiera sparade PPTX- och PPT-filer."
---
## **Översikt**

Ett textstycke består av delar. En vanlig [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) innehåller bokstavlig text; ett fältavsnitt har också ett [Field](https://reference.aspose.com/slides/sv/php-java/aspose.slides/field/) vars typ identifierar ett automatiskt uppdaterat värde, såsom ett bildnummer eller datum. Två delar kan visa samma tecken medan endast en innehåller ett fält.

Använd [Portion::getField](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getField) för att särskilja dem: den är `null` för vanlig text. [Portion::addField](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#addField) konverterar en befintlig del till ett fält. Behåll en etikett och dess dynamiska värde i separata delar så att konverteringen av värdet inte också ersätter etiketten.

Denna guide täcker fält i text, deras formatering och sparande i PPTX och PPT. För textramar och stycken, se [Manage Text](/slides/sv/php-java/manage-text/).

## **Skapa ett bildnummerfält**

Det följande kompletta exemplet skapar en textruta som innehåller en bokstavlig `Slide ` etikett följd av ett automatiskt uppdaterat nummer. Det sätter numrets storlek, tyngd och färg innan fältet läggs till, öppnar sedan den sparade presentationen igen och kontrollerar fälttyp, text och formatering. Ingen inmatningsfil krävs.

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

Nya presentationen börjar med bildnummer 1, så texten är `Slide 1`, och båda kontrollerna skriver ut `true`. Numret förblir ett fält efter att presentationen öppnats igen; det är inte en bokstavlig `1`. Indexen i verifieringen refererar till formen och delarna som skapats av detta exempel.

## **Välj en fälttyp**

[FieldType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/) tillhandahåller följande metoder för att erhålla fördefinierade värden. Skicka det lämpliga värdet till [addField](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#addField).

| Metod | Syfte |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getSlideNumber) | Det aktuella bildnumret. |
| [getDateTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getDateTime) | Datum/tid i renderingapplikationens standardformat. |
| [getDateTime1](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getDateTime9) | Fördefinierade datum- eller kombinerade datum/tid-format. |
| [getDateTime10](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getDateTime13) | Fördefinierade tidsformat, med alternativ för sekunder och en 12‑timmarsklocka. |
| [getHeader](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getHeader) | Ett sidhuvudfält; se platshållar- och formatbegränsningarna nedan. |
| [getFooter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getFooter) | Ett sidfotsfält. |

Till exempel representerar [getDateTime3](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getDateTime3) en dag, fullt månadsnamn och år på engelska. Detta är fördefinierade fältformat, inte godtyckliga PHP datumformatsträngar. Språket som ställs in med [setLanguageId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) och applikationen som bearbetar presentationen kan påverka det visade resultatet.

## **Skapa ett fält från en intern sträng**

Strängöverladdningen av [addField](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#addField) accepterar en intern fältidentifierare. Använd den när du bevarar en identifierare som levererats av en annan applikation som saknar fördefinierat värde. Du kan också konstruera en [FieldType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#FieldType) från identifieraren. [FieldType::getInternalString](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fieldtype/#getInternalString) avslöjar den identifieraren för inspektion.

Detta exempel lagrar ett applikationsspecifikt `custom-report-id`‑fält med reservtexten `Report-042`. Identifieraren registrerar ingen beräkning: Aspose.Slides genererar inte rapport‑ID:n för en okänd typ. Applikationen som förstår denna identifierare måste tillhandahålla dess betydelse och uppdatera dess värde.

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

Efter denna PPTX‑rundresa är typen `custom-report-id` och texten `Report-042`. Att skicka en sträng såsom `Y-m-d` skulle namnge en fälttyp; det skulle inte konfigurera ett anpassat datumformat. För ett fast datum i ett godtyckligt format, använd vanlig text.

## **Inspektera, ändra och ta bort datum/tid-fält**

Ändra ett befintligt fält genom [Field::setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/field/#setType). Kontrollera att fältet finns innan du får åtkomst till dess typ. För att stoppa automatiska uppdateringar, anropa [Portion::removeField](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#removeField). Detta behåller delen och dess nuvarande text medan fältassociationen tas bort. Om du behöver ett specifikt fast värde, tilldela den texten efter att fältet tagits bort.

För API‑inställningen som är associerad med datum/tid‑fältbearbetning, se [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#setCurrentDateTime). Exemplet nedan använder ett explicit godkännandedatum när ett fält konverteras till vanlig text.

Ladda ner [sample.pptx](sample.pptx) och placera det i JavaBridge‑arbetskatalogen, eller skicka dess absoluta sökväg till presentationskonstruktorn. Det innehåller två namngivna textformer, `UpdatedAt` och `ApprovedDate`, var och en med ett datum/tid‑fält, samt vanliga textetiketter. Följande exempel går igenom top‑nivå‑textformer på vanliga bilder. Det ändrar datum/tid‑fält till ett långtids‑datumformat och gör dem kursiva, samtidigt som annan formatering bevaras. Endast fält i `ApprovedDate` blir fast text.

Exemplet känner igen de inbyggda interna identifierarna `datetime` och `datetime1` genom `datetime13`. Grupper, tabeller, anteckningar, layouter och masters kräver traversering av deras egna textbehållare och ligger utanför detta exempel.

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

Efter att presentationen öppnats igen har `UpdatedAt` typen `datetime3` och förblir dynamisk. `ApprovedDate` har inget fält och innehåller `05 April 2030`. Båda datumdelarna är kursiva, och deras ursprungliga teckenstorlek, fetinställning och färg förblir intakta. De vanliga textetiketterna är oförändrade. Verifieringen läser den första delen av de två kända formerna i den medföljande provfilen.

## **Bevara textformatering**

Arbeta med den befintliga delen när du lägger till ett fält, ändrar dess typ eller tar bort det. Dessa operationer behåller den delens formatering. Använd [Portion::getPortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getPortionFormat) för att ändra endast de egenskaper som krävs, som exemplen gör för färg eller kursiv.

Undvik att bygga om en hel textruta enbart för att uppdatera ett fält: det kan leda till att de ursprungliga delgränserna och deras individuella formatering förloras. Skilj också på explicit angiven formatering och formatering som ärvts från stycke, layout eller tema. Se [Text Formatting](/slides/sv/php-java/text-formatting/) för bredare formateringsalternativ.

## **Fält och platshållare för sidhuvud/sidfötter**

Ett fält är en del av ett textavsnitt. En platshållare är en form med en presentationsroll, såsom en sidfot eller bildnummer. Att lägga till ett fält i en vanlig textruta gör inte formen till en platshållare.

Sidhuvud‑/sidfots‑hanterarna styr platshållartext och synlighet på bilder, layouter och masters, inklusive spridning till beroende bilder. Ett nummerfält i en anpassad textruta kan därför vara användbart även när du inte använder bildnummer‑platshållaren. Omvänt tar förändring av platshållarens synlighet inte bort ett fält från en orelaterad textruta.

De fördefinierade sidhuvuds‑ och sidfots‑typerna skapar inte motsvarande platshållare eller levererar deras innehåll. Speciellt har en vanlig PowerPoint‑bild ingen sidhuvuds‑platshållare; sidhuvuden hör till anteckningssidor och handouts. Anta inte att ett sidhuvuds‑ eller sidfots‑fält i en godtycklig form automatiskt får den text som konfigurerats via en platshållar‑hanterare. För det arbetsflödet, se [Presentation Headers and Footers](/slides/sv/php-java/presentation-header-and-footer/).

## **PPTX- och PPT-begränsningar**

Kontrollera både fälttyp och dess resulterande text efter att filen sparats och öppnats igen. Att bevara en identifierare bevisar inte att en applikation kan beräkna eller visa dess värde.

| Format | Fältbeteende och begränsningar |
|---|---|
| PPTX | Lagrar interna fältidentifierare tillsammans med fälttext. Vid rundreskontroller överlevde de fördefinierade typerna och den anpassade identifieraren som användes ovan sparandet och öppnandet igen. Den okända anpassade typen behöll sin reservtext; den erhöll ingen automatisk beräkningslogik. En annan applikation kan behandla ej stödda identifierare annorlunda. |
| PPT | Använder äldre fältrepresentationer och har mer begränsad kompatibilitet. Vid rundreskontroller överlevde bildnummer‑ och fördefinierade datum/tid‑fält sparandet och öppnandet igen. Ett anpassat fält i en vanlig bildtext‑ruta öppnades med sin identifierare men med `*` som text; ett sidhuvuds‑fält i samma sammanhang producerade också `*`. Lita inte på att anpassade fält eller ej stödda fältkontexter behåller sin synliga text. |

För portabelt, fast output, konvertera ej stödda fält till vanlig text och tilldela explicit det värde du vill ha innan du sparar. Detta bevarar den valda texten men stoppar avsiktligt automatiska uppdateringar. Testa även målapplikationen när dess egen fält‑omberäkning är en del av ditt arbetsflöde.

## **FAQ**

**Hur kan jag avgöra om ett visat nummer eller datum är ett fält?**

Inspektera [Portion::getField](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getField). Ett icke‑null‑värde identifierar ett fält; den visade texten ensam kan inte säga det.

**Tar bort ett fält dess text eller formatering?**

Nej. [removeField](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#removeField) konverterar den befintliga delen till vanlig text. Tilldela ett explicit värde efteråt om du behöver ett specifikt fryst datum eller reservtext.

**Kan en intern sträng definiera ett nytt datumformat eller en formel?**

Nej. Den identifierar en fälttyp. En okänd identifierare ger ingen evaluator eller ett PHP datumformatmönster. Använd en stödd fördefinierad typ eller formatera ett värde själv som vanlig text.

**Varför kontrollera en presentation igen efter att den sparats?**

Fältidentifierare, beräknad text och formatering är separata saker att verifiera. Formatkonvertering kan förändra det synliga resultatet även när fältidentifieraren fortfarande finns.