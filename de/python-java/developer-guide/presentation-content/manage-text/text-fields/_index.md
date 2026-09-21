---
title: Textfelder in PowerPoint-Präsentationen in Python über Java verwalten
linktitle: Textfelder
type: docs
weight: 52
url: /de/python-java/text-fields/
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
- Python
- Java
- Aspose.Slides
description: "Erstellen, inspizieren, ändern und entfernen Sie Textfelder in PowerPoint-Präsentationen mit Aspose.Slides für Python über Java. Bewahren Sie die Formatierung und überprüfen Sie die gespeicherten PPTX- und PPT-Dateien."
---
## **Übersicht**

Ein Textabsatz besteht aus Portionen. Eine gewöhnliche [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) enthält wörtlichen Text; eine Feldportion hat außerdem ein [Field](https://reference.aspose.com/slides/de/python-java/aspose.slides/field/), dessen Typ einen automatisch aktualisierten Wert identifiziert, z. B. eine Foliennummer oder ein Datum. Zwei Portionen können dieselben Zeichen anzeigen, wobei nur eine ein Feld enthält.

Verwenden Sie [Portion.getField](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getField) um sie zu unterscheiden: Sie ist für gewöhnlichen Text `None`. [Portion.addField](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#addField) wandelt eine bestehende Portion in ein Feld um. Halten Sie ein Beschriftung und dessen dynamischen Wert in separaten Portionen, damit das Konvertieren des Werts nicht gleichzeitig die Beschriftung ersetzt.

Diese Anleitung behandelt Felder im Text, deren Formatierung und das Speichern in PPTX und PPT. Für Textfelder und Absätze siehe [Manage Text](/slides/de/python-java/manage-text/).

## **Foliennummer‑Feld erstellen**

Das nachstehende vollständige Beispiel erstellt ein Textfeld, das ein wörtliches `Slide `‑Label gefolgt von einer automatisch aktualisierten Nummer enthält. Es setzt Größe, Stärke und Farbe der Nummer, bevor das Feld hinzugefügt wird, öffnet dann die gespeicherte Präsentation erneut und prüft Feldtyp, Text und Formatierung. Keine Eingabedatei ist erforderlich.

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

Die neue Präsentation beginnt mit Foliennummer 1, sodass der Text `Slide 1` lautet und beide Prüfungen `True` ausgeben. Die Nummer bleibt nach dem Wiederöffnen ein Feld; sie ist nicht das wörtliche `1`. Die Indizes in der Verifizierung beziehen sich auf die Form und die Portionen, die von diesem Beispiel erstellt wurden.

## **Feldtyp wählen**

[FieldType](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/) stellt die folgenden Methoden zum Abrufen vordefinierter Werte bereit. Übergeben Sie den entsprechenden Wert an [addField](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#addField).

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getSlideNumber) | Die aktuelle Foliennummer. |
| [getDateTime](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getDateTime) | Datum/Uhrzeit im Standardformat der Rendering‑Anwendung. |
| [getDateTime1](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getDateTime9) | Vordefinierte Datums‑ oder kombinierte Datum/Uhrzeit‑Formate. |
| [getDateTime10](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getDateTime13) | Vordefinierte Zeitformate, mit Optionen für Sekunden und 12‑Stunden‑Uhr. |
| [getHeader](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getHeader) | Ein Kopfzeilenfeld; siehe die unten genannten Platzhalter‑ und Formatbeschränkungen. |
| [getFooter](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getFooter) | Ein Fußzeilenfeld. |

Zum Beispiel repräsentiert [getDateTime3](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getDateTime3) einen Tag, den vollständigen Monatsnamen und das Jahr auf Englisch. Dies sind vordefinierte Feldformate, keine beliebigen Python‑Datumsformat‑Zeichenketten. Die mit [setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId) festgelegte Sprache und die Anwendung, die die Präsentation verarbeitet, können das angezeigte Ergebnis beeinflussen.

## **Feld aus internem String erstellen**

Die String‑Überladung von [addField](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#addField) akzeptiert einen internen Feld‑Bezeichner. Verwenden Sie sie, wenn ein von einer anderen Anwendung bereitgestellter Bezeichner erhalten bleiben soll, der keinen vordefinierten Wert hat. Sie können auch ein [FieldType](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#FieldType) aus dem Bezeichner erstellen. [FieldType.getInternalString](https://reference.aspose.com/slides/de/python-java/aspose.slides/fieldtype/#getInternalString) gibt diesen Bezeichner zur Inspektion frei.

Dieses Beispiel speichert ein anwendungsspezifisches Feld `custom-report-id` mit dem Ersatztext `Report-042`. Der Bezeichner registriert keine Berechnung: Aspose.Slides erzeugt keine Bericht‑IDs für einen unbekannten Typ. Die Anwendung, die diesen Bezeichner versteht, muss dessen Bedeutung bereitstellen und den Wert aktualisieren.

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

Nach diesem PPTX‑Round‑Trip ist der Typ `custom-report-id` und der Text `Report-042`. Das Übergeben einer Zeichenkette wie `yyyy-MM-dd` würde einen Feldtyp benennen; es würde kein benutzerdefiniertes Datumsformat konfigurieren. Für ein festes Datum in einem beliebigen Format verwenden Sie gewöhnlichen Text.

## **Datum-/Uhrzeit‑Felder inspizieren, ändern und entfernen**

Ändern Sie ein vorhandenes Feld über [Field.setType](https://reference.aspose.com/slides/de/python-java/aspose.slides/field/#setType). Prüfen Sie, ob das Feld existiert, bevor Sie auf dessen Typ zugreifen. Um automatische Updates zu stoppen, rufen Sie [Portion.removeField](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#removeField) auf. Dies bewahrt die Portion und deren aktuellen Text, während die Feldzuordnung entfernt wird. Wenn Sie einen bestimmten festen Wert benötigen, weisen Sie diesen Text nach dem Entfernen des Feldes zu.

Für die API‑Einstellung, die die Verarbeitung von Datum/Uhrzeit‑Feldern betrifft, siehe [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#setCurrentDateTime). Das nachstehende Beispiel verwendet ein explizites Genehmigungsdatum, wenn ein Feld in gewöhnlichen Text umgewandelt wird.

Laden Sie [sample.pptx](sample.pptx) herunter und legen Sie es im Arbeitsverzeichnis ab. Es enthält zwei benannte Textformen, `UpdatedAt` und `ApprovedDate`, jeweils mit einem Datum/Uhrzeit‑Feld, sowie gewöhnliche Textbeschriftungen. Das folgende Beispiel durchläuft Textformen der obersten Ebene auf normalen Folien. Es ändert Datum/Uhrzeit‑Felder in ein Langdatumsformat und macht sie kursiv, wobei die übrige Formatierung erhalten bleibt. Nur Felder in `ApprovedDate` werden zu festem Text.

Das Beispiel erkennt die eingebauten internen Bezeichner `datetime` und `datetime1` bis `datetime13`. Gruppen, Tabellen, Notizen, Layouts und Master erfordern die Durchsuchung ihrer eigenen Textcontainer und liegen außerhalb des Umfangs dieses Beispiels.

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
    # Verwenden Sie englische Monatsnamen unabhängig von der Systemsprache.
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

Nach dem Wiederöffnen hat `UpdatedAt` den Typ `datetime3` und bleibt dynamisch. `ApprovedDate` hat kein Feld und enthält `05 April 2030`. Beide Datumsportionen sind kursiv, und ihre ursprüngliche Schriftgröße, fette Einstellung und Farbe bleiben unverändert. Die gewöhnlichen Textbeschriftungen bleiben unverändert. Die Verifizierung liest die erste Portion der beiden bekannten Formen im bereitgestellten Beispiel.

## **Textformatierung beibehalten**

Arbeiten Sie mit der bestehenden Portion, wenn Sie ein Feld hinzufügen, dessen Typ ändern oder es entfernen. Diese Vorgänge behalten die Formatierung dieser Portion bei. Verwenden Sie [Portion.getPortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getPortionFormat), um nur die erforderlichen Eigenschaften zu ändern, wie die Beispiele für Farbe oder Kursivschrift zeigen.

Vermeiden Sie es, einen kompletten Textframe neu zu erstellen, nur um ein Feld zu aktualisieren: Dabei können die ursprünglichen Portionsgrenzen und deren individuelle Formatierung verloren gehen. Unterscheiden Sie außerdem explizit gesetzte Formatierung von der vererbten Formatierung aus Absatz, Layout oder Theme. Siehe [Text Formatting](/slides/de/python-java/text-formatting/) für weitergehende Formatierungsoptionen.

## **Felder und Platzhalter für Kopf‑/Fußzeile**

Ein Feld ist Teil einer Textportion. Ein Platzhalter ist eine Form mit einer Präsentationsrolle, z. B. einer Fußzeile oder Foliennummer. Das Hinzufügen eines Feldes zu einem gewöhnlichen Textfeld verwandelt diese Form nicht in einen Platzhalter.

Die Header-/Footer‑Manager steuern den Platzhalter‑Text und die Sichtbarkeit auf Folien, Layouts und Master‑Folien, einschließlich der Weitergabe an abhängige Folien. Ein Zahlenfeld in einem benutzerdefinierten Textfeld kann daher nützlich sein, selbst wenn Sie den Foliennummer‑Platzhalter nicht verwenden. Umgekehrt entfernt das Ändern der Platzhalter‑Sichtbarkeit kein Feld aus einem nicht verwandten Textfeld.

Die vordefinierten Header‑ und Footer‑Typen erzeugen nicht die entsprechenden Platzhalter oder liefern deren Inhalt. Insbesondere hat eine reguläre PowerPoint‑Folie keinen Header‑Platzhalter; Header gehören zu Notizseiten und Handouts. Gehen Sie nicht davon aus, dass ein Header‑ oder Footer‑Feld in einer beliebigen Form automatisch den über einen Platzhalter‑Manager konfigurierten Text übernimmt. Für diesen Workflow siehe [Presentation Headers and Footers](/slides/de/python-java/presentation-header-and-footer/).

## **PPTX‑ und PPT‑Einschränkungen**

Überprüfen Sie sowohl den Feldtyp als auch den resultierenden Text nach dem Speichern und Wiederöffnen. Das Beibehalten eines Bezeichners beweist nicht, dass eine Anwendung dessen Wert berechnen oder anzeigen kann.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Speichert interne Feld‑Bezeichner zusammen mit dem Feldtext. In Round‑Trip‑Prüfungen überlebten die vordefinierten Typen und der oben verwendete benutzerdefinierte Bezeichner das Speichern und Wiederöffnen. Der unbekannte benutzerdefinierte Typ behielt seinen Ersatztext bei; er erlangte keine automatische Berechnungslogik. Eine andere Anwendung könnte unbekannte Bezeichner unterschiedlich behandeln. |
| PPT | Verwendet veraltete Feld‑Darstellungen und hat eingeschränktere Kompatibilität. In Round‑Trip‑Prüfungen überlebten Folien‑Nummer‑ und vordefinierte Datum/Uhrzeit‑Felder das Speichern und Wiederöffnen. Ein benutzerdefiniertes Feld in einer gewöhnlichen Folientextbox wurde nach dem Wiederöffnen mit seinem Bezeichner, aber mit `*` als Text wiedergegeben; ein Header‑Feld im selben Kontext erzeugte ebenfalls `*`. Verlassen Sie sich nicht darauf, dass benutzerdefinierte Felder oder nicht unterstützte Feldkontexte ihren sichtbaren Text behalten. |

Für transportierbare, feste Ausgaben konvertieren Sie nicht unterstützte Felder in gewöhnlichen Text und weisen Sie vor dem Speichern explizit den gewünschten Wert zu. Dies bewahrt den gewählten Text, stoppt jedoch bewusst automatische Aktualisierungen. Testen Sie auch die Zielanwendung, wenn deren eigene Feld‑Neuberechnung Teil Ihres Workflows ist.

## **FAQ**

**Wie kann ich erkennen, ob eine angezeigte Zahl oder ein Datum ein Feld ist?**

Untersuchen Sie [Portion.getField](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getField). Ein Wert ungleich `None` kennzeichnet ein Feld; der angezeigte Text allein kann dies nicht erkennen.

**Entfernt das Entfernen eines Feldes dessen Text oder Formatierung?**

Nein. [removeField](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#removeField) wandelt die bestehende Portion in gewöhnlichen Text um. Weisen Sie nachher einen expliziten Wert zu, falls Sie ein bestimmtes festes Datum oder einen Ersatzwert benötigen.

**Kann ein interner String ein neues Datumsformat oder eine Formel definieren?**

Nein. Er identifiziert einen Feldtyp. Ein unbekannter Bezeichner liefert keinen Evaluator oder ein Python‑Datumsformat‑Muster. Verwenden Sie einen unterstützten vordefinierten Typ oder formatieren Sie einen Wert selbst als gewöhnlichen Text.

**Warum die Präsentation nach dem Speichern erneut prüfen?**

Feld‑Bezeichner, berechneter Text und Formatierung sind separate Dinge, die überprüft werden müssen. Eine Formatkonvertierung kann das sichtbare Ergebnis ändern, selbst wenn der Feld‑Bezeichner weiterhin vorhanden ist.