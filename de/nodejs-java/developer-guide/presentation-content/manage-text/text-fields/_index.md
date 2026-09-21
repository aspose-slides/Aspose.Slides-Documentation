---
title: Textfelder in PowerPoint-Präsentationen verwalten in JavaScript
linktitle: Textfelder
type: docs
weight: 52
url: /de/nodejs-java/text-fields/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen, inspizieren, ändern und entfernen Sie Textfelder in PowerPoint-Präsentationen mit Aspose.Slides für Node.js über Java. Bewahren Sie die Formatierung und überprüfen Sie die gespeicherten PPTX- und PPT-Dateien."
---
## **Übersicht**

Ein Textabsatz besteht aus Portionen. Eine gewöhnliche [Portion](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/) enthält wörtlichen Text; eine Feldportion enthält zusätzlich ein [Field](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/field/), dessen Typ einen automatisch aktualisierten Wert identifiziert, z. B. eine Foliennummer oder ein Datum. Zwei Portionen können dieselben Zeichen anzeigen, wobei nur eine ein Feld enthält.

Verwenden Sie [Portion.getField](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#getField) um sie zu unterscheiden: Sie ist `null` für gewöhnlichen Text. [Portion.addField](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#addField) konvertiert eine vorhandene Portion in ein Feld. Halten Sie ein Beschriftungs‑ und dessen dynamischen Wert in separaten Portionen, sodass das Konvertieren des Werts nicht auch die Beschriftung ersetzt.

Dieser Leitfaden behandelt Felder im Text, deren Formatierung und das Speichern in PPTX und PPT. Für Textfelder und Absätze siehe [Manage Text](/slides/de/nodejs-java/manage-text/).

## **Ein Feld für die Foliennummer erstellen**

Das folgende vollständige Beispiel erstellt ein Textfeld, das eine wörtliche Beschriftung `Slide ` gefolgt von einer automatisch aktualisierten Nummer enthält. Es legt Größe, Stärke und Farbe der Nummer fest, bevor das Feld hinzugefügt wird, öffnet dann die gespeicherte Präsentation erneut und prüft Feldtyp, Text und Formatierung. Keine Eingabedatei ist erforderlich.

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

Die neue Präsentation beginnt mit Foliennummer 1, sodass der Text `Slide 1` lautet und beide Prüfungen `true` ausgeben. Die Nummer bleibt nach dem erneuten Öffnen ein Feld; sie ist nicht das wörtliche `1`. Die Indizes in der Verifizierung beziehen sich auf die Form und die Portionen, die von diesem Beispiel erstellt wurden.

## **Feldtyp auswählen**

[FieldType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/) stellt die folgenden Methoden zum Abrufen vordefinierter Werte bereit. Übergeben Sie den passenden Wert an [addField](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#addField).

| Methode | Zweck |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Die aktuelle Foliennummer. |
| [getDateTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Datum/Zeit im Standardformat der Rendering‑Anwendung. |
| [getDateTime1](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Vordefinierte Datums‑ oder kombinierte Datum/Zeit‑Formate. |
| [getDateTime10](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Vordefinierte Zeitformate, mit Optionen für Sekunden und 12‑Stunden‑Uhr. |
| [getHeader](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getHeader) | Ein Kopfzeilenfeld; siehe unten die Platzhalter‑ und Formatbeschränkungen. |
| [getFooter](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getFooter) | Ein Fußzeilenfeld. |

Zum Beispiel repräsentiert [getDateTime3](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getDateTime3) einen Tag, den vollständigen Monatsnamen und das Jahr auf Englisch. Dies sind vordefinierte Feldformate, keine beliebigen Datum‑Format‑Zeichenfolgen. Die mit [setLanguageId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) festgelegte Sprache und die Anwendung, die die Präsentation verarbeitet, können das angezeigte Ergebnis beeinflussen.

## **Ein Feld aus einer internen Zeichenfolge erstellen**

Die Zeichenketten‑Überladung von [addField](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#addField) akzeptiert einen internen Feld‑Bezeichner. Verwenden Sie sie, wenn Sie einen von einer anderen Anwendung bereitgestellten Bezeichner erhalten wollen, für den es keinen vordefinierten Wert gibt. Sie können auch einen [FieldType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/) aus dem Bezeichner konstruieren. [FieldType.getInternalString](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fieldtype/#getInternalString) gibt diesen Bezeichner zur Inspektion frei.

Dieses Beispiel speichert ein anwendungs­spezifisches Feld `custom-report-id` mit dem Ersatztext `Report-042`. Der Bezeichner registriert keine Berechnung: Aspose.Slides erzeugt keine Bericht‑IDs für einen unbekannten Typ. Die Anwendung, die diesen Bezeichner versteht, muss dessen Bedeutung bereitstellen und den Wert aktualisieren.

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

Nach diesem PPTX‑Durchlauf ist der Typ `custom-report-id` und der Text `Report-042`. Das Übergeben einer Zeichenkette wie `yyyy-MM-dd` würde einen Feldtyp benennen; es würde kein benutzerdefiniertes Datumsformat konfigurieren. Für ein fixes Datum in einem beliebigen Format verwenden Sie gewöhnlichen Text.

## **Datums‑/Uhrzeit‑Felder inspizieren, ändern und entfernen**

Ändern Sie ein vorhandenes Feld über [Field.setType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/field/#setType). Prüfen Sie, dass das Feld existiert, bevor Sie seinen Typ abrufen. Um automatische Aktualisierungen zu stoppen, rufen Sie [Portion.removeField](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#removeField) auf. Dies behält die Portion und ihren aktuellen Text bei, während die Feldzuordnung entfernt wird. Wenn Sie einen bestimmten festen Wert benötigen, weisen Sie nach dem Entfernen des Feldes diesen Text zu.

Für die API‑Einstellung im Zusammenhang mit der Verarbeitung von Datums‑/Uhrzeit‑Feldern siehe [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Das nachstehende Beispiel verwendet ein explizites Genehmigungsdatum, wenn ein Feld in gewöhnlichen Text konvertiert wird.

Laden Sie [sample.pptx](sample.pptx) herunter und legen Sie es im Arbeitsverzeichnis ab. Es enthält zwei benannte Textformen, `UpdatedAt` und `ApprovedDate`, jeweils mit einem Datums‑/Uhrzeit‑Feld, plus gewöhnliche Textbeschriftungen. Das folgende Beispiel durchläuft die Textformen der obersten Ebene auf normalen Folien. Es ändert Datums‑/Uhrzeit‑Felder zu einem langen Datumsformat und macht sie kursiv, wobei die übrige Formatierung erhalten bleibt. Nur Felder in `ApprovedDate` werden zu festem Text.

Das Genehmigungsdatum ist der 5. April 2030; JavaScript‑Monatsindizes beginnen bei null, daher ist April `3`. UTC wird sowohl für die Erstellung als auch für die Formatierung verwendet, um das Datum von der lokalen Zeitzone unabhängig zu halten.

Das Beispiel erkennt die eingebauten internen Bezeichner `datetime` und `datetime1` bis `datetime13`. Gruppen, Tabellen, Notizen, Layouts und Master erfordern das Durchlaufen ihrer eigenen Textcontainer und liegen außerhalb des Umfangs dieses Beispiels.

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

Nach dem erneuten Öffnen hat `UpdatedAt` den Typ `datetime3` und bleibt dynamisch. `ApprovedDate` hat kein Feld und enthält `05 April 2030`. Beide Datums‑Portionen sind kursiv, und ihre ursprüngliche Schriftgröße, Fett‑Einstellung und Farbe bleiben unverändert. Die gewöhnlichen Textbeschriftungen bleiben unverändert. Die Verifizierung liest die erste Portion der beiden bekannten Formen im bereitgestellten Beispiel.

## **Textformatierung beibehalten**

Arbeiten Sie mit der vorhandenen Portion, wenn Sie ein Feld hinzufügen, dessen Typ ändern oder es entfernen. Diese Vorgänge bewahren die Formatierung der Portion. Verwenden Sie [Portion.getPortionFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#getPortionFormat), um nur die erforderlichen Eigenschaften zu ändern, wie die Beispiele für Farbe oder Kursivschrift zeigen.

Vermeiden Sie es, einen gesamten Textrahmen nur zum Aktualisieren eines Feldes neu aufzubauen: Das kann die ursprünglichen Portionsgrenzen und deren individuelle Formatierung verlieren. Unterscheiden Sie außerdem explizit festgelegte Formatierung von der aus Absatz, Layout oder Theme geerbten Formatierung. Siehe [Text Formatting](/slides/de/nodejs-java/text-formatting/) für weiterführende Formatierungsoptionen.

## **Felder und Platzhalter für Kopf‑/Fußzeile**

Ein Feld ist Teil einer Textportion. Ein Platzhalter ist eine Form mit einer Präsentationsrolle, wie z. B. Fußzeile oder Foliennummer. Das Hinzufügen eines Feldes zu einem gewöhnlichen Textfeld macht diese Form nicht zu einem Platzhalter.

Die Kopf‑/Fußzeilen‑Manager steuern den Platzhalter‑Text und die Sichtbarkeit auf Folien, Layouts und Master‑Folien, einschließlich der Weitergabe an abhängige Folien. Ein Zahlenfeld in einem benutzerdefinierten Textfeld kann daher nützlich sein, selbst wenn Sie den Foliennummer‑Platzhalter nicht verwenden. Umgekehrt entfernt das Ändern der Platzhalter‑Sichtbarkeit kein Feld aus einem nicht‑zugehörigen Textfeld.

Die vordefinierten Kopf‑ und Fußzeilen‑Typen erzeugen nicht die entsprechenden Platzhalter oder stellen deren Inhalt bereit. Insbesondere hat eine reguläre PowerPoint‑Folien keine Kopfzeilen‑Platzhalter; Kopfzeilen gehören zu Notizseiten und Handzetteln. Gehen Sie nicht davon aus, dass ein Kopf‑ oder Fußzeilenfeld in einer beliebigen Form automatisch den über einen Platzhalter‑Manager konfigurierten Text erhält. Für diesen Arbeitsablauf siehe [Presentation Headers and Footers](/slides/de/nodejs-java/presentation-header-and-footer/).

## **Einschränkungen für PPTX und PPT**

Überprüfen Sie sowohl den Feldtyp als auch den resultierenden Text nach dem Speichern und erneuten Öffnen. Das Beibehalten eines Bezeichners beweist nicht, dass eine Anwendung diesen Wert berechnen oder anzeigen kann.

| Format | Feldverhalten und Einschränkungen |
|---|---|
| PPTX | Speichert interne Feld‑Bezeichner zusammen mit dem Feldtext. Bei Rundreise‑Prüfungen überlebten die vordefinierten Typen und der oben verwendete benutzerdefinierte Bezeichner das Speichern und erneute Öffnen. Der unbekannte benutzerdefinierte Typ behielt seinen Ersatztext bei; er erlangte keine automatische Berechnungslogik. Eine andere Anwendung kann nicht unterstützte Bezeichner anders behandeln. |
| PPT | Verwendet veraltete Feldrepräsentationen und hat eingeschränktere Kompatibilität. Bei Rundreise‑Prüfungen überlebten Folien‑Nummer‑ und vordefinierte Datum/Zeit‑Felder das Speichern und erneute Öffnen. Ein benutzerdefiniertes Feld in einem gewöhnlichen Folientextfeld wurde mit seinem Bezeichner, aber mit `*` als Text wieder geöffnet; ein Kopfzeilenfeld im selben Kontext erzeugte ebenfalls `*`. Verlassen Sie sich nicht darauf, dass benutzerdefinierte Felder oder nicht unterstützte Feldkontexte ihren sichtbaren Text behalten. |

Für portable, feste Ausgaben konvertieren Sie nicht unterstützte Felder in gewöhnlichen Text und weisen Sie vor dem Speichern explizit den gewünschten Wert zu. Dies bewahrt den gewählten Text, stoppt jedoch bewusst automatische Aktualisierungen. Testen Sie auch die Zielanwendung, wenn deren eigene Feldneuberechnung Teil Ihres Arbeitsablaufs ist.

## **FAQ**

**Wie kann ich erkennen, ob eine angezeigte Nummer oder ein Datum ein Feld ist?**

Prüfen Sie [Portion.getField](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#getField). Ein nicht‑null‑Wert identifiziert ein Feld; der angezeigte Text allein kann das nicht bestimmen.

**Entfernt das Entfernen eines Feldes seinen Text oder seine Formatierung?**

Nein. [removeField](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/portion/#removeField) konvertiert die vorhandene Portion in gewöhnlichen Text. Weisen Sie anschließend einen expliziten Wert zu, wenn Sie ein bestimmtes festes Datum oder einen Ersatzwert benötigen.

**Kann eine interne Zeichenfolge ein neues Datumsformat oder eine Formel definieren?**

Nein. Sie identifiziert einen Feldtyp. Ein unbekannter Bezeichner liefert keinen Auswertungsmechanismus oder ein Datumsformat‑Muster. Verwenden Sie einen unterstützten vordefinierten Typ oder formatieren Sie den Wert selbst als gewöhnlichen Text.

**Warum sollte man eine Präsentation nach dem Speichern erneut prüfen?**

Feld‑Bezeichner, berechneter Text und Formatierung sind separate Aspekte, die geprüft werden müssen. Eine Formatkonvertierung kann das sichtbare Ergebnis ändern, obwohl der Feld‑Bezeichner noch vorhanden ist.