---
title: Verwalten von Textfeldern in PowerPoint-Präsentationen in .NET
linktitle: Textfelder
type: docs
weight: 52
url: /de/net/text-fields/
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
- C#
- Aspose.Slides
description: "Erstellen, inspizieren, ändern und entfernen von Textfeldern in PowerPoint-Präsentationen mit Aspose.Slides für .NET. Formatierung beibehalten und gespeicherte PPTX- und PPT-Dateien überprüfen."
---
## **Übersicht**

Ein Textabsatz besteht aus Portionen. Ein gewöhnlicher [IPortion](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/) enthält Literaltext; eine Feldportion besitzt zusätzlich ein [IField](https://reference.aspose.com/slides/de/net/aspose.slides/ifield/), dessen Typ einen automatisch aktualisierten Wert wie Foliennummer oder Datum identifiziert. Zwei Portionen können dieselben Zeichen anzeigen, wobei nur eine ein Feld enthält.

Verwenden Sie [IPortion.Field](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/field/), um sie zu unterscheiden: Sie ist `null` für gewöhnlichen Text. [IPortion.AddField](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/addfield/) wandelt eine vorhandene Portion in ein Feld um. Bewahren Sie ein Beschriftungs‑ und sein dynamisches Wert‑Element in separaten Portionen, damit das Konvertieren des Werts nicht auch die Beschriftung ersetzt.

Dieser Leitfaden behandelt Felder im Text, ihre Formatierung und das Speichern in PPTX und PPT. Für Textfelder und Absätze siehe [Manage Text](/slides/de/net/manage-text/).

## **Ein Foliennummern‑Feld erstellen**

Das folgende vollständige Beispiel erstellt ein Textfeld, das das Literal `Slide `‑Label gefolgt von einer automatisch aktualisierten Nummer enthält. Es legt die Größe, Stärke und Farbe der Nummer fest, bevor das Feld hinzugefügt wird, öffnet dann die gespeicherte Präsentation erneut und prüft Feldtyp, Text und Formatierung. Keine Eingabedatei ist erforderlich.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Die neue Präsentation beginnt mit Foliennummer 1, sodass der Text `Slide 1` lautet und beide Prüfungen `True` ausgeben. Die Nummer bleibt nach dem erneuten Öffnen ein Feld; sie ist kein Literal‑`1`. Die Casts und Indizes in der Verifikation beziehen sich auf die Shape und Portionen, die in diesem Beispiel erstellt wurden.

## **Einen Feldtyp auswählen**

[FieldType](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/) implementiert [IFieldType](https://reference.aspose.com/slides/de/net/aspose.slides/ifieldtype/) und bietet die folgenden vordefinierten Werte. Übergeben Sie den passenden Wert an [AddField](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/addfield/).

| Wert | Zweck |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/slidenumber/) | Die aktuelle Foliennummer. |
| [DateTime](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/datetime/) | Datum/Uhrzeit im Standardformat der rendernden Anwendung. |
| [DateTime1](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/datetime9/) | Vorgefertigte Datums‑ oder kombinierte Datum/Uhrzeit‑Formate. |
| [DateTime10](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/datetime13/) | Vorgefertigte Zeitformate, mit Optionen für Sekunden und 12‑Stunden‑Uhr. |
| [Header](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/header/) | Ein Kopfzeilenfeld; siehe die Platzhalter‑ und Formatbeschränkungen unten. |
| [Footer](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/footer/) | Ein Fußzeilenfeld. |

Zum Beispiel repräsentiert [DateTime3](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/datetime3/) einen Tag, den vollen Monatsnamen und das Jahr auf Englisch. Dies sind vordefinierte Feldformate, keine beliebigen .NET‑Datumsformat‑Zeichenketten. Der [LanguageId](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseportionformat/languageid/) der Portion und die Anwendung, die die Präsentation verarbeitet, können das angezeigte Ergebnis beeinflussen.

## **Ein Feld aus einem internen String erstellen**

Die String‑Überladung von [AddField](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/addfield/) akzeptiert einen internen Feld‑Bezeichner. Verwenden Sie sie, wenn Sie einen von einer anderen Anwendung bereitgestellten Bezeichner erhalten, für den es keinen vordefinierten Wert gibt. Sie können außerdem ein [FieldType](https://reference.aspose.com/slides/de/net/aspose.slides/fieldtype/fieldtype/) aus dem Bezeichner konstruieren. [IFieldType.InternalString](https://reference.aspose.com/slides/de/net/aspose.slides/ifieldtype/internalstring/) gibt diesen Bezeichner zur Inspektion frei.

Dieses Beispiel speichert ein anwendungsspezifisches Feld `custom-report-id` mit dem Fallback‑Text `Report-042`. Der Bezeichner löst keine Berechnung aus: Aspose.Slides generiert keine Bericht‑IDs für unbekannte Typen. Die Anwendung, die diesen Bezeichner versteht, muss seine Bedeutung bereitstellen und seinen Wert aktualisieren.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Nach diesem PPTX‑Round‑Trip ist der Typ `custom-report-id` und der Text `Report-042`. Die Übergabe eines Strings wie `yyyy-MM-dd` würde einen Feldtyp benennen; sie würde kein benutzerdefiniertes Datumsformat konfigurieren. Für ein festes Datum in einem beliebigen Format verwenden Sie gewöhnlichen Text.

## **Datum/Uhrzeit‑Felder inspizieren, ändern und entfernen**

Lesen und ändern Sie ein vorhandenes Feld über [IField.Type](https://reference.aspose.com/slides/de/net/aspose.slides/ifield/type/). Prüfen Sie, dass das Feld existiert, bevor Sie auf seinen Typ zugreifen. Um automatische Updates zu stoppen, rufen Sie [IPortion.RemoveField](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/removefield/) auf. Dadurch bleibt die Portion erhalten und ihr aktueller Text wird beibehalten, während die Feldzugehörigkeit entfernt wird. Wenn Sie einen bestimmten festen Wert benötigen, weisen Sie nach dem Entfernen des Feldes diesen Text zu.

Für die API‑Einstellung, die die Verarbeitung von Datum/Uhrzeit‑Feldern steuert, siehe [Presentation.CurrentDateTime](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/currentdatetime/). Das untenstehende Beispiel verwendet ein explizites Genehmigungsdatum, wenn ein Feld in gewöhnlichen Text umgewandelt wird.

Laden Sie [sample.pptx](sample.pptx) herunter und legen Sie es im Arbeitsverzeichnis ab. Es enthält zwei benannte Text‑Shapes, `UpdatedAt` und `ApprovedDate`, jeweils mit einem Datum/Uhrzeit‑Feld sowie gewöhnliche Text‑Labels. Das folgende Beispiel durchläuft die Text‑Shapes auf regulären Folien. Es wandelt Datum/Uhrzeit‑Felder in ein Langdatum‑Format um und macht sie kursiv, wobei die übrige Formatierung erhalten bleibt. Nur Felder in `ApprovedDate` werden zu festem Text.

Die Probe erkennt die eingebauten internen Bezeichner `datetime` und `datetime1` bis `datetime13`. Gruppen, Tabellen, Notizen, Layouts und Master‑Folien erfordern das Durchlaufen ihrer eigenen Text‑Container und liegen außerhalb des Umfangs dieses Beispiels.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

Nach dem erneuten Öffnen hat `UpdatedAt` den Typ `datetime3` und bleibt dynamisch. `ApprovedDate` hat kein Feld und enthält `05 April 2030`. Beide Datums‑Portionen sind kursiv, während ihre ursprüngliche Schriftgröße, Fett‑Einstellung und Farbe unverändert bleiben. Die gewöhnlichen Text‑Labels bleiben unverändert. Die Verifikation liest die erste Portion der beiden bekannten Shapes im mitgelieferten Beispiel.

## **Textformatierung erhalten**

Arbeiten Sie mit der bestehenden Portion, wenn Sie ein Feld hinzufügen, dessen Typ ändern oder es entfernen. Diese Vorgänge bewahren die Formatierung der Portion. Nutzen Sie [IPortion.PortionFormat](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/portionformat/), um nur die erforderlichen Eigenschaften zu ändern, wie die Beispiele für Farbe oder Kursivschrift zeigen.

Vermeiden Sie das Neuaufbauen eines gesamten Text‑Frames nur zum Aktualisieren eines einzigen Felds: Dadurch können die ursprünglichen Portionsgrenzen und deren individuelle Formatierung verloren gehen. Unterscheiden Sie zudem explizit gesetzte Formatierung von der Vererbung aus Absatz, Layout oder Theme. Siehe [Text Formatting](/slides/de/net/text-formatting/) für weiterführende Formatierungsoptionen.

## **Felder und Platzhalter für Kopf‑/Fußzeile**

Ein Feld ist Teil einer Text‑Portion. Ein Platzhalter ist ein Shape mit einer Präsentations‑Rolle, etwa einer Fußzeile oder Foliennummer. Das Hinzufügen eines Feldes zu einem gewöhnlichen Textfeld macht das Shape nicht zu einem Platzhalter.

Die Header‑/Footer‑Manager steuern den Platzhalter‑Text und die Sichtbarkeit auf Folien, Layouts und Master‑Folien, einschließlich der Weitergabe an abhängige Folien. Ein Zahlenfeld in einem benutzerdefinierten Textfeld kann daher nützlich sein, selbst wenn Sie den Foliennummer‑Platzhalter nicht verwenden. Umgekehrt entfernt das Ändern der Platzhalter‑Sichtbarkeit kein Feld aus einem nicht zugehörigen Textfeld.

Die vordefinierten Header‑ und Footer‑Typen erzeugen nicht die entsprechenden Platzhalter oder liefern deren Inhalt. Insbesondere hat eine reguläre PowerPoint‑Folien keine Header‑Platzhalter; Header gehören zu Notizseiten und Handouts. Gehen Sie nicht davon aus, dass ein Header‑ oder Footer‑Feld in einem beliebigen Shape automatisch den über einen Platzhalter‑Manager konfigurierten Text übernimmt. Für diesen Workflow siehe [Presentation Headers and Footers](/slides/de/net/presentation-header-and-footer/).

## **PPTX‑ und PPT‑Einschränkungen**

Prüfen Sie sowohl den Feldtyp als auch den resultierenden Text nach dem Speichern und erneuten Öffnen. Das Beibehalten eines Bezeichners beweist nicht, dass eine Anwendung dessen Wert berechnen oder anzeigen kann.

| Format | Verhalten und Einschränkungen des Felds |
|---|---|
| PPTX | Speichert interne Feld‑Bezeichner zusammen mit dem Feld‑Text. In Round‑Trip‑Prüfungen überlebten die vordefinierten Typen und der oben verwendete benutzerdefinierte Bezeichner das Speichern und Öffnen. Der unbekannte benutzerdefinierte Typ behielt seinen Fallback‑Text; er erhielt keine automatische Berechnungslogik. Andere Anwendungen können nicht unterstützte Bezeichner anders behandeln. |
| PPT | Verwendet ältere Feld‑Darstellungen und hat eingeschränktere Kompatibilität. In Round‑Trip‑Prüfungen überlebten Folien‑Nummer‑ und vordefinierte Datum/Uhrzeit‑Felder das Speichern und Öffnen. Ein benutzerdefiniertes Feld in einem gewöhnlichen Folientext wurde nach dem Öffnen mit seinem Bezeichner, aber mit `*` als Text wiedergegeben; ein Header‑Feld im selben Kontext erzeugte ebenfalls `*`. Verlassen Sie sich nicht darauf, dass benutzerdefinierte Felder oder nicht unterstützte Feld‑Kontexte ihren sichtbaren Text behalten. |

Für portable, feste Ausgaben konvertieren Sie nicht unterstützte Felder zu gewöhnlichem Text und weisen Sie vor dem Speichern explizit den gewünschten Wert zu. Dadurch bleibt der gewählte Text erhalten, automatisierte Updates werden jedoch bewusst gestoppt. Testen Sie auch die Zielanwendung, wenn deren eigene Feld‑Neuberechnung Teil Ihres Workflows ist.

## **FAQ**

**Wie kann ich feststellen, ob eine angezeigte Zahl oder ein Datum ein Feld ist?**

Untersuchen Sie [IPortion.Field](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/field/). Ein von `null` abweichender Wert identifiziert ein Feld; der angezeigte Text allein gibt keinen Aufschluss.

**Entfernt das Entfernen eines Feldes dessen Text oder Formatierung?**

Nein. [RemoveField](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/removefield/) wandelt die vorhandene Portion in gewöhnlichen Text um. Weisen Sie anschließend einen expliziten Wert zu, wenn Sie ein bestimmtes festes Datum oder einen Fallback‑Wert benötigen.

**Kann ein interner String ein neues Datumsformat oder eine Formel definieren?**

Nein. Er identifiziert nur einen Feldtyp. Ein unbekannter Bezeichner liefert keinen Evaluator oder ein .NET‑Datumsformat‑Muster. Verwenden Sie einen unterstützten vordefinierten Typ oder formatieren Sie den Wert selbst als gewöhnlichen Text.

**Warum sollte man eine Präsentation nach dem Speichern erneut prüfen?**

Feld‑Bezeichner, berechneter Text und Formatierung sind separate Dinge, die verifiziert werden müssen. Eine Formatkonvertierung kann das sichtbare Ergebnis ändern, obwohl der Feld‑Bezeichner noch vorhanden ist.