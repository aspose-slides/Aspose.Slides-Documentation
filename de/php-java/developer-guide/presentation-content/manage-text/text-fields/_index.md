---
title: Textfelder in PowerPoint-Präsentationen in PHP verwalten
linktitle: Textfelder
type: docs
weight: 52
url: /de/php-java/text-fields/
keywords:
- Textfeld
- automatischer Text
- Foliennummer
- Datum und Uhrzeit
- Kopfzeile
- Fußzeile
- Textportion
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Erstellen, untersuchen, ändern und entfernen Sie Textfelder in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java. Bewahren Sie die Formatierung und überprüfen Sie die gespeicherten PPTX- und PPT-Dateien."
---
## **Übersicht**

Ein Textabsatz besteht aus Portionen. Eine gewöhnliche [Portion](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/) enthält wörtlichen Text; eine Feldportion hat außerdem ein [Field](https://reference.aspose.com/slides/de/php-java/aspose.slides/field/) dessen Typ einen automatisch aktualisierten Wert identifiziert, z. B. eine Foliennummer oder ein Datum. Zwei Portionen können die gleichen Zeichen anzeigen, während nur eine ein Feld enthält.

Verwenden Sie [Portion::getField](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#getField) um sie zu unterscheiden: Sie ist `null` für gewöhnlichen Text. [Portion::addField](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#addField) konvertiert eine vorhandene Portion in ein Feld. Halten Sie eine Beschriftung und ihren dynamischen Wert in separaten Portionen, damit das Konvertieren des Werts nicht auch die Beschriftung ersetzt.

Dieser Leitfaden behandelt Felder innerhalb von Text, deren Formatierung und das Speichern in PPTX und PPT. Für Textrahmen und Absätze siehe [Text verwalten](/slides/de/php-java/manage-text/).

## **Erstellen eines Foliennummern-Feldes**

Das folgende vollständige Beispiel erstellt ein Textfeld, das ein wörtliches `Slide `-Label gefolgt von einer automatisch aktualisierten Nummer enthält. Es legt die Größe, Stärke und Farbe der Nummer fest, bevor das Feld hinzugefügt wird, öffnet dann die gespeicherte Präsentation erneut und prüft den Feldtyp, den Text und die Formatierung. Keine Eingabedatei ist erforderlich.

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

Die neue Präsentation beginnt mit Foliennummer 1, sodass der Text `Slide 1` lautet und beide Prüfungen `true` ausgeben. Die Nummer bleibt nach dem erneuten Öffnen ein Feld; sie ist nicht das wörtliche `1`. Die Indizes in der Verifizierung beziehen sich auf die von diesem Beispiel erstellte Form und die Portionen.

## **Auswahl eines Feldtyps**

[FieldType](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/) stellt die folgenden Methoden zum Abrufen vordefinierter Werte bereit. Übergeben Sie den entsprechenden Wert an [addField](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#addField).

| Methode | Zweck |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getSlideNumber) | Die aktuelle Foliennummer. |
| [getDateTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getDateTime) | Datum/Zeit im Standardformat der rendernden Anwendung. |
| [getDateTime1](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getDateTime1)-[getDateTime9](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getDateTime9) | Vordefinierte Datums- oder Kombinationen von Datums-/Zeitformaten. |
| [getDateTime10](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getDateTime10)-[getDateTime13](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getDateTime13) | Vordefinierte Zeitformate, mit Optionen für Sekunden und einer 12‑Stunden‑Uhr. |
| [getHeader](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getHeader) | Ein Header-Feld; siehe unten die Platzhalter- und Formatbeschränkungen. |
| [getFooter](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getFooter) | Ein Footer-Feld. |

Zum Beispiel repräsentiert [getDateTime3](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getDateTime3) einen Tag, den vollen Monatsnamen und das Jahr auf Englisch. Dies sind vordefinierte Feldformate, keine beliebigen PHP‑Datumsformat‑Zeichenketten. Die mit [setLanguageId](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setLanguageId) festgelegte Sprache und die Anwendung, die die Präsentation verarbeitet, können das angezeigte Ergebnis beeinflussen.

## **Erstellen eines Feldes aus einer internen Zeichenkette**

Die String‑Überladung von [addField](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#addField) akzeptiert einen internen Feldidentifikator. Verwenden Sie sie, wenn Sie einen von einer anderen Anwendung bereitgestellten Identifikator erhalten möchten, für den es keinen vordefinierten Wert gibt. Sie können auch ein [FieldType](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#FieldType) aus dem Identifikator erstellen. [FieldType::getInternalString](https://reference.aspose.com/slides/de/php-java/aspose.slides/fieldtype/#getInternalString) gibt diesen Identifikator zur Inspektion aus.

Dieses Beispiel speichert ein anwendungspezifisches Feld `custom-report-id` mit dem Ersatztext `Report-042`. Der Identifikator registriert keine Berechnung: Aspose.Slides erzeugt keine Bericht‑IDs für unbekannte Typen. Die Anwendung, die diesen Identifikator versteht, muss dessen Bedeutung bereitstellen und den Wert aktualisieren.

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

Nach diesem PPTX‑Rundlauf ist der Typ `custom-report-id` und der Text `Report-042`. Die Übergabe einer Zeichenkette wie `Y-m-d` würde einen Feldtyp benennen; sie würde kein benutzerdefiniertes Datumsformat konfigurieren. Für ein festes Datum in einem beliebigen Format verwenden Sie normalen Text.

## **Untersuchen, Ändern und Entfernen von Datums-/Zeit-Feldern**

Ändern Sie ein vorhandenes Feld über [Field::setType](https://reference.aspose.com/slides/de/php-java/aspose.slides/field/#setType). Prüfen Sie, dass das Feld existiert, bevor Sie auf seinen Typ zugreifen. Um automatische Aktualisierungen zu stoppen, rufen Sie [Portion::removeField](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#removeField) auf. Dadurch bleibt die Portion und ihr aktueller Text erhalten, während die Feldzuordnung entfernt wird. Wenn Sie einen bestimmten festen Wert benötigen, weisen Sie diesen Text nach dem Entfernen des Feldes zu.

Für die API‑Einstellung im Zusammenhang mit der Verarbeitung von Datums-/Zeit-Feldern siehe [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#setCurrentDateTime). Das folgende Beispiel verwendet ein explizites Genehmigungsdatum, wenn ein Feld in normalen Text konvertiert wird.

Laden Sie [sample.pptx](sample.pptx) herunter und legen Sie es im Arbeitsverzeichnis von JavaBridge ab, oder übergeben Sie seinen absoluten Pfad an den Präsentations‑Konstruktor. Es enthält zwei benannte Textformen, `UpdatedAt` und `ApprovedDate`, jeweils mit einem Datums-/Zeit‑Feld, plus reguläre Textbeschriftungen. Das folgende Beispiel durchläuft die Textformen der obersten Ebene auf regulären Folien. Es ändert Datums-/Zeit‑Felder in ein Lang-Datum-Format und macht sie kursiv, während andere Formatierungen erhalten bleiben. Nur Felder in `ApprovedDate` werden zu festem Text.

Die Probe erkennt die integrierten internen Identifikatoren `datetime` und `datetime1` bis `datetime13`. Gruppen, Tabellen, Notizen, Layouts und Master erfordern das Durchlaufen ihrer eigenen Textcontainer und liegen außerhalb des Anwendungsbereichs dieses Beispiels.

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

Nach dem erneuten Öffnen hat `UpdatedAt` den Typ `datetime3` und bleibt dynamisch. `ApprovedDate` hat kein Feld und enthält `05 April 2030`. Beide Datums‑Portionen sind kursiv, und ihre ursprüngliche Schriftgröße, Fett‑Einstellung und Farbe bleiben unverändert. Die regulären Textbeschriftungen bleiben unverändert. Die Verifizierung liest die erste Portion der beiden bekannten Formen in der bereitgestellten Probe.

## **Textformatierung beibehalten**

Arbeiten Sie mit der vorhandenen Portion, wenn Sie ein Feld hinzufügen, dessen Typ ändern oder es entfernen. Diese Vorgänge behalten die Formatierung dieser Portion bei. Verwenden Sie [Portion::getPortionFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#getPortionFormat), um nur die erforderlichen Eigenschaften zu ändern, wie die Beispiele für Farbe oder Kursivschrift zeigen.

Vermeiden Sie das Neuaufbauen eines gesamten Textrahmens nur um ein Feld zu aktualisieren: Dabei können die ursprünglichen Portionsgrenzen und deren individuelle Formatierung verloren gehen. Unterscheiden Sie außerdem explizit gesetzte Formatierung von der von Absatz, Layout oder Design geerbten Formatierung. Siehe [Text Formatting](/slides/de/php-java/text-formatting/) für umfangreichere Formatierungsoptionen.

## **Felder und Kopf-/Fußzeilen-Platzhalter**

Ein Feld ist Teil einer Textportion. Ein Platzhalter ist eine Form mit einer Präsentationsrolle, wie z. B. einer Fußzeile oder Foliennummer. Das Hinzufügen eines Feldes zu einem gewöhnlichen Textfeld macht diese Form nicht zu einem Platzhalter.

Die Kopf-/Fußzeilen-Manager steuern den Platzhaltertext und die Sichtbarkeit auf Folien, Layouts und Master, einschließlich der Weitergabe an abhängige Folien. Ein Zahlenfeld in einem benutzerdefinierten Textfeld kann daher nützlich sein, selbst wenn Sie den Foliennummern-Platzhalter nicht verwenden. Umgekehrt entfernt das Ändern der Sichtbarkeit von Platzhaltern kein Feld aus einem nicht zugehörigen Textfeld.

Die vordefinierten Kopf- und Fußzeilentypen erzeugen nicht die entsprechenden Platzhalter oder stellen deren Inhalt bereit. Insbesondere hat eine normale PowerPoint-Folien keine Kopfzeilen-Platzhalter; Kopfzeilen gehören zu Notizseiten und Handouts. Gehen Sie nicht davon aus, dass ein Kopf- oder Fußzeilenfeld in einer beliebigen Form automatisch den über einen Platzhalter-Manager konfigurierten Text erhält. Für diesen Arbeitsablauf siehe [Presentation Headers and Footers](/slides/de/php-java/presentation-header-and-footer/).

## **PPTX‑ und PPT‑Einschränkungen**

Prüfen Sie sowohl den Feldtyp als auch den daraus resultierenden Text nach dem Speichern und erneuten Öffnen. Das Beibehalten eines Identifikators beweist nicht, dass eine Anwendung dessen Wert berechnen oder anzeigen kann.

| Format | Feldverhalten und Einschränkungen |
|---|---|
| PPTX | Speichert interne Feldidentifikatoren zusammen mit dem Feldtext. In Rundlauf‑Prüfungen überlebten die vordefinierten Typen und der oben verwendete benutzerdefinierte Identifikator das Speichern und erneute Öffnen. Der unbekannte benutzerdefinierte Typ behielt seinen Ersatztext bei; er erlangte keine automatische Berechnungslogik. Eine andere Anwendung kann nicht unterstützte Identifikatoren anders behandeln. |
| PPT | Verwendet Legacy‑Felddarstellungen und hat eine stärker eingeschränkte Kompatibilität. In Rundlauf‑Prüfungen überlebten Foliennummer‑ und vordefinierte Datums-/Zeit‑Felder das Speichern und erneute Öffnen. Ein benutzerdefiniertes Feld in einem gewöhnlichen Folientextfeld wurde mit seinem Identifikator, aber mit `*` als Text wieder geöffnet; ein Header‑Feld im selben Kontext erzeugte ebenfalls `*`. Verlassen Sie sich nicht darauf, dass benutzerdefinierte Felder oder nicht unterstützte Feldkontexte ihren sichtbaren Text behalten. |

Für portablen, festen Output konvertieren Sie nicht unterstützte Felder in normalen Text und weisen den gewünschten Wert vor dem Speichern explizit zu. Dies bewahrt den gewählten Text, stoppt jedoch bewusst automatische Aktualisierungen. Testen Sie die Zielanwendung ebenfalls, wenn deren eigene Feldneuberechnung Teil Ihres Arbeitsablaufs ist.

## **FAQ**

**Wie kann ich erkennen, ob eine angezeigte Zahl oder ein Datum ein Feld ist?**

Untersuchen Sie [Portion::getField](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#getField). Ein von null verschiedener Wert identifiziert ein Feld; der angezeigte Text allein kann das nicht bestimmen.

**Entfernt das Entfernen eines Feldes dessen Text oder Formatierung?**

Nein. [removeField](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/#removeField) konvertiert die vorhandene Portion in normalen Text. Weisen Sie danach einen expliziten Wert zu, wenn Sie ein bestimmtes festes Datum oder einen Ersatzwert benötigen.

**Kann eine interne Zeichenkette ein neues Datumsformat oder eine Formel definieren?**

Nein. Sie identifiziert einen Feldtyp. Ein unbekannter Identifikator liefert keinen Evaluator oder ein PHP‑Datumsformat‑Muster. Verwenden Sie einen unterstützten vordefinierten Typ oder formatieren Sie den Wert selbst als normalen Text.

**Warum eine Präsentation nach dem Speichern erneut prüfen?**

Feldidentifikatoren, berechneter Text und Formatierung sind getrennte Dinge, die geprüft werden müssen. Eine Formatkonvertierung kann das sichtbare Ergebnis ändern, selbst wenn der Feldidentifikator noch vorhanden ist.