---
title: Verwalten von Textfeldern in PowerPoint‑Präsentationen mit Python
linktitle: Textfelder
type: docs
weight: 52
url: /de/python-net/text-fields/
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
- Aspose.Slides
description: "Erstellen, prüfen, ändern und entfernen Sie Textfelder in PowerPoint‑Präsentationen mit Aspose.Slides für Python über .NET. Bewahren Sie die Formatierung und überprüfen Sie die gespeicherten PPTX‑ und PPT‑Dateien."
---
## **Übersicht**

Ein Textabsatz besteht aus Portionen. Eine gewöhnliche [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/) enthält wörtlichen Text; eine Feldportion hat außerdem ein [Field](https://reference.aspose.com/slides/de/python-net/aspose.slides/field/), dessen Typ einen automatisch aktualisierten Wert identifiziert, wie z. B. eine Foliennummer oder ein Datum. Zwei Portionen können dieselben Zeichen anzeigen, während nur eine ein Feld enthält.

Verwenden Sie [Portion.field](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/field/), um sie zu unterscheiden: Für gewöhnlichen Text ist sie `None`. [Portion.add_field](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/add_field/) wird eine vorhandene Portion in ein Feld umgewandelt. Bewahren Sie ein Etikett und seinen dynamischen Wert in separaten Portionen auf, damit die Umwandlung des Werts nicht auch das Etikett ersetzt.

Dieser Leitfaden behandelt Felder im Text, deren Formatierung und das Speichern in PPTX und PPT. Für Textfelder und Absätze siehe [Manage Text](/slides/de/python-net/manage-text/).

## **Erstellen eines Foliennummerfelds**

Das folgende vollständige Beispiel erstellt ein Textfeld, das ein wörtliches `Slide `‑Etikett gefolgt von einer automatisch aktualisierten Nummer enthält. Es legt die Größe, das Gewicht und die Farbe der Nummer fest, bevor das Feld hinzugefügt wird, öffnet dann die gespeicherte Präsentation erneut und überprüft den Feldtyp, den Text und die Formatierung. Keine Eingabedatei ist erforderlich.

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

Die neue Präsentation beginnt mit Foliennummer 1, sodass der Text `Slide 1` lautet und beide Prüfungen `True` ausgeben. Die Nummer bleibt nach dem erneuten Öffnen ein Feld; sie ist nicht das wörtliche `1`. Die Indizes in der Verifikation beziehen sich auf die von diesem Beispiel erstellte Form und die Portionen.

## **Wählen Sie einen Feldtyp**

[FieldType](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/) bietet die folgenden vordefinierten Werte. Übergeben Sie den passenden Wert an [add_field](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/add_field/).

| Wert | Zweck |
|---|---|
| [slide_number](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/slide_number/) | Die aktuelle Foliennummer. |
| [date_time](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/date_time/) | Datum/Uhrzeit im Standardformat der Rendering‑Anwendung. |
| [date_time1](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/date_time9/) | Vordefinierte Datums‑ oder kombinierte Datum/Uhrzeit‑Formate. |
| [date_time10](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/date_time13/) | Vordefinierte Zeitformate, mit Optionen für Sekunden und eine 12‑Stunden‑Uhr. |
| [header](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/header/) | Ein Kopfzeilenfeld; siehe unten die Platzhalter‑ und Formatierungsbeschränkungen. |
| [footer](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/footer/) | Ein Fußzeilenfeld. |

Zum Beispiel stellt [date_time3](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/date_time3/) einen Tag, den vollständigen Monatsnamen und das Jahr in Englisch dar. Dies sind vordefinierte Feldformate, keine beliebigen Python‑Datumsformat‑Zeichenketten. Der [language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/language_id/) der Portion und die Anwendung, die die Präsentation verarbeitet, können das angezeigte Ergebnis beeinflussen.

## **Ein Feld aus einer internen Zeichenkette erstellen**

Die String‑Überladung von [add_field](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/add_field/) akzeptiert einen internen Feldkennzeichner. Verwenden Sie sie, wenn Sie einen von einer anderen Anwendung bereitgestellten Kennzeichner beibehalten, für den kein vordefinierter Wert existiert. Sie können auch ein [FieldType](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/__init__/) aus dem Kennzeichner erstellen. [FieldType.internal_string](https://reference.aspose.com/slides/de/python-net/aspose.slides/fieldtype/internal_string/) stellt diesen Kennzeichner zur Untersuchung bereit.

Dieses Beispiel speichert ein anwendungs­spezifisches Feld `custom-report-id` mit dem Fallback‑Text `Report-042`. Der Kennzeichner registriert keine Berechnung: Aspose.Slides erzeugt keine Bericht‑IDs für einen unbekannten Typ. Die Anwendung, die diesen Kennzeichner versteht, muss dessen Bedeutung bereitstellen und den Wert aktualisieren.

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

Nach diesem PPTX‑Durchlauf ist der Typ `custom-report-id` und der Text `Report-042`. Die Übergabe einer Zeichenkette wie `%Y-%m-%d` würde einen Feldtyp benennen; sie würde kein benutzerdefiniertes Datumsformat konfigurieren. Für ein festes Datum in einem beliebigen Format verwenden Sie gewöhnlichen Text.

## **Untersuchen, Ändern und Entfernen von Datum/Uhrzeit‑Feldern**

Lesen und ändern Sie ein vorhandenes Feld über [Field.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/field/type/). Überprüfen Sie, dass das Feld existiert, bevor Sie auf seinen Typ zugreifen. Um automatische Aktualisierungen zu stoppen, rufen Sie [Portion.remove_field](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/remove_field/) auf. Dies behält die Portion und ihren aktuellen Text bei, während die Feldzuordnung entfernt wird. Wenn Sie einen bestimmten festen Wert benötigen, weisen Sie nach dem Entfernen des Feldes diesen Text zu.

Für die API‑Einstellung, die mit der Verarbeitung von Datum/Uhrzeit‑Feldern zusammenhängt, siehe [Presentation.current_date_time](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/current_date_time/). Das nachstehende Beispiel verwendet ein explizites Genehmigungsdatum beim Konvertieren eines Feldes in gewöhnlichen Text. Ein englisches Monat‑Namens‑Tupel hält das feste Datum unabhängig von der System‑Locale.

Laden Sie [sample.pptx](sample.pptx) herunter und platzieren Sie es im Arbeitsverzeichnis. Es enthält zwei benannte Textformen, `UpdatedAt` und `ApprovedDate`, jeweils mit einem Datum/Uhrzeit‑Feld sowie gewöhnliche Textbeschriftungen. Das folgende Beispiel durchläuft die Textformen der obersten Ebene auf normalen Folien. Es ändert Datum/Uhrzeit‑Felder zu einem Langdatumsformat und formatiert sie kursiv, während andere Formatierungen beibehalten werden. Nur Felder in `ApprovedDate` werden zu festem Text.

Das Beispiel erkennt die integrierten internen Kennzeichner `datetime` und `datetime1` bis `datetime13`. Gruppen, Tabellen, Notizen, Layouts und Master erfordern die Durchquerung ihrer eigenen Textcontainer und liegen außerhalb des Geltungsbereichs dieses Beispiels.

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

Nach dem erneuten Öffnen hat `UpdatedAt` den Typ `datetime3` und bleibt dynamisch. `ApprovedDate` hat kein Feld und enthält `05 April 2030`. Beide Datumsportionen sind kursiv, und ihre ursprüngliche Schriftgröße, Fett‑Einstellung und Farbe bleiben erhalten. Die gewöhnlichen Textbeschriftungen bleiben unverändert. Die Verifikation liest die erste Portion der beiden bekannten Formen im mitgelieferten Beispiel.

## **Textformatierung beibehalten**

Arbeiten Sie mit der vorhandenen Portion, wenn Sie ein Feld hinzufügen, dessen Typ ändern oder es entfernen. Diese Vorgänge behalten die Formatierung dieser Portion bei. Verwenden Sie [Portion.portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/portion_format/), um nur die erforderlichen Eigenschaften zu ändern, wie die Beispiele für Farbe oder Kursivschrift zeigen.

Vermeiden Sie das Neuaufbauen eines gesamten Textrahmens nur zum Aktualisieren eines einzelnen Feldes: Dadurch können die ursprünglichen Portionengrenzen und deren individuelle Formatierung verloren gehen. Unterscheiden Sie außerdem explizit festgelegte Formatierung von der von Absatz, Layout oder Design geerbten Formatierung. Siehe [Text Formatting](/slides/de/python-net/text-formatting/) für umfassendere Formatierungsoptionen.

## **Felder und Kopf-/Fußzeilen‑Platzhalter**

Ein Feld ist Teil einer Textportion. Ein Platzhalter ist eine Form mit einer Präsentationsrolle, wie z. B. eine Fußzeile oder Foliennummer. Das Hinzufügen eines Feldes zu einem gewöhnlichen Textfeld macht diese Form nicht zu einem Platzhalter.

Die Kopf‑/Fußzeilen‑Verwalter steuern den Platzhalter‑Text und die Sichtbarkeit auf Folien, Layouts und Master, einschließlich der Weitergabe an abhängige Folien. Ein Zahlenfeld in einem benutzerdefinierten Textfeld kann daher nützlich sein, auch wenn Sie den Foliennummer‑Platzhalter nicht verwenden. Umgekehrt entfernt das Ändern der Sichtbarkeit von Platzhaltern kein Feld aus einem nicht‑zugehörigen Textfeld.

Die vordefinierten Kopf‑ und Fußzeilen‑Typen erzeugen nicht die entsprechenden Platzhalter oder liefern deren Inhalt. Insbesondere hat eine reguläre PowerPoint‑Folien keine Kopfzeilen‑Platzhalter; Kopfzeilen gehören zu Notizseiten und Handouts. Gehen Sie nicht davon aus, dass ein Kopf‑ oder Fußzeilenfeld in einer beliebigen Form automatisch den über einen Platzhalter‑Manager konfigurierten Text erhält. Für diesen Ablauf siehe [Presentation Headers and Footers](/slides/de/python-net/presentation-header-and-footer/).

## **PPTX- und PPT‑Einschränkungen**

Prüfen Sie sowohl den Feldtyp als auch den daraus resultierenden Text nach dem Speichern und erneuten Öffnen. Das Beibehalten eines Kennzeichners beweist nicht, dass eine Anwendung dessen Wert berechnen oder anzeigen kann.

| Format | Feldverhalten und -einschränkungen |
|---|---|
| PPTX | Speichert interne Feldkennzeichner zusammen mit dem Feldtext. In Rundreise‑Prüfungen überlebten die vordefinierten Typen und der oben verwendete benutzerdefinierte Kennzeichner das Speichern und erneute Öffnen. Der unbekannte benutzerdefinierte Typ behielt seinen Fallback‑Text bei; er erlangte keine automatische Berechnungslogik. Eine andere Anwendung kann nicht unterstützte Kennzeichner anders behandeln. |
| PPT | Verwendet veraltete Feldrepräsentationen und hat eingeschränktere Kompatibilität. In Rundreise‑Prüfungen überlebten Folien‑Nummer‑ und vordefinierte Datum/Uhrzeit‑Felder das Speichern und erneute Öffnen. Ein benutzerdefiniertes Feld in einem gewöhnlichen Folientextfeld wurde mit seinem Kennzeichner, jedoch mit `*` als Text, erneut geöffnet; ein Kopfzeilenfeld im gleichen Kontext produzierte ebenfalls `*`. Verlassen Sie sich nicht darauf, dass benutzerdefinierte Felder oder nicht unterstützte Feldkontexte ihren sichtbaren Text behalten. |

Für portable, feste Ausgaben konvertieren Sie nicht unterstützte Felder in gewöhnlichen Text und weisen Sie vor dem Speichern explizit den gewünschten Wert zu. Dadurch bleibt der gewählte Text erhalten, aber automatische Aktualisierungen werden bewusst gestoppt. Testen Sie auch die Zielanwendung, wenn deren eigene Feldneuberechnung Teil Ihres Workflows ist.

## **FAQ**

**Wie kann ich erkennen, ob eine angezeigte Nummer oder ein Datum ein Feld ist?**

Untersuchen Sie [Portion.field](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/field/). Ein von `None` verschiedener Wert identifiziert ein Feld; der angezeigte Text allein kann dies nicht bestimmen.

**Entfernt das Entfernen eines Feldes dessen Text oder Formatierung?**

Nein. [remove_field](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/remove_field/) wandelt die vorhandene Portion in gewöhnlichen Text um. Weisen Sie anschließend einen expliziten Wert zu, wenn Sie ein bestimmtes festes Datum oder einen Fallback‑Wert benötigen.

**Kann eine interne Zeichenkette ein neues Datumsformat oder eine Formel definieren?**

Nein. Sie identifiziert einen Feldtyp. Ein unbekannter Kennzeichner liefert keinen Evaluator oder ein Python‑Datumsformat‑Muster. Verwenden Sie einen unterstützten vordefinierten Typ oder formatieren Sie den Wert selbst als gewöhnlichen Text.

**Warum die Präsentation nach dem Speichern erneut prüfen?**

Feldkennzeichner, berechneter Text und Formatierung sind getrennte Dinge, die geprüft werden müssen. Eine Formatkonvertierung kann das sichtbare Ergebnis ändern, selbst wenn der Feldkennzeichner noch vorhanden ist.