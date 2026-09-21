---
title: Verwalten von Textfeldern in PowerPoint-Präsentationen unter Android
linktitle: Textfelder
type: docs
weight: 52
url: /de/androidjava/text-fields/
keywords:
- Textfeld
- automatischer Text
- Foliennummer
- Datum und Uhrzeit
- Kopfzeile
- Fußzeile
- Textabschnitt
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Erstellen, untersuchen, ändern und entfernen Sie Textfelder in PowerPoint-Präsentationen mit Aspose.Slides für Android via Java. Formatierung beibehalten und gespeicherte PPTX- und PPT-Dateien überprüfen."
---
## **Übersicht**

Ein Textabsatz besteht aus Abschnitten. Ein gewöhnlicher [IPortion](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/) enthält wörtlichen Text; ein Feld‑Abschnitt hat zusätzlich ein [IField](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifield/), dessen Typ einen automatisch aktualisierten Wert identifiziert, z. B. eine Foliennummer oder ein Datum. Zwei Abschnitte können dieselben Zeichen anzeigen, während nur einer ein Feld enthält.

Verwenden Sie [IPortion.getField](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#getField--) zum Unterscheiden: Für normalen Text ist der Rückgabewert `null`. [IPortion.addField](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) konvertiert einen bestehenden Abschnitt in ein Feld. Bewahren Sie ein Etikett und seinen dynamischen Wert in separaten Abschnitten auf, damit das Konvertieren des Wertes nicht gleichzeitig das Etikett ersetzt.

Dieser Leitfaden behandelt Felder im Text, deren Formatierung und das Speichern in PPTX und PPT. Für Textfelder und Absätze siehe [Text verwalten](/slides/de/androidjava/manage-text/).

## **Ein Foliennummern‑Feld erstellen**

Das folgende vollständige Beispiel erstellt ein Textfeld, das ein wörtliches `Slide `‑Etikett und anschließend eine automatisch aktualisierte Nummer enthält. Es legt Größe, Gewicht und Farbe der Nummer fest, bevor das Feld hinzugefügt wird, öffnet dann die gespeicherte Präsentation erneut und prüft Feldtyp, Text und Formatierung. Keine Eingabedatei ist erforderlich.

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

Die neue Präsentation beginnt mit Foliennummer 1, sodass der Text `Slide 1` lautet und beide Prüfungen `true` ausgeben. Die Nummer bleibt nach dem erneuten Öffnen ein Feld; sie ist nicht der wörtliche `1`. Die Cast‑Operationen und Indizes in der Verifizierung beziehen sich auf die Form und die Abschnitte, die in diesem Beispiel erstellt wurden.

## **Feldtyp auswählen**

[FieldType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/) implementiert [IFieldType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifieldtype/) und stellt die folgenden Methoden zum Abrufen vordefinierter Werte bereit. Übergeben Sie den jeweiligen Wert an [addField](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Methode | Zweck |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Die aktuelle Foliennummer. |
| [getDateTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Datum/Uhrzeit im Standardformat der renderten Anwendung. |
| [getDateTime1](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Vordefinierte Datums‑ oder kombinierte Datum‑/Uhrzeit‑Formate. |
| [getDateTime10](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Vordefinierte Zeitformate mit Optionen für Sekunden und 12‑Stunden‑Uhr. |
| [getHeader](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Ein Kopfzeilen‑Feld; siehe die Platzhalter‑ und Formatbeschränkungen unten. |
| [getFooter](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Ein Fußzeilen‑Feld. |

Zum Beispiel stellt [getDateTime3](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) einen Tag, den vollständigen Monatsnamen und das Jahr in Englisch dar. Dabei handelt es sich um vordefinierte Feldformate, nicht um beliebige Java‑Datum‑Format‑Zeichenketten. Die mit [setLanguageId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) festgelegte Sprache und die Anwendung, die die Präsentation verarbeitet, können das angezeigte Ergebnis beeinflussen.

## **Ein Feld aus einem internen Zeichenfolgenwert erstellen**

Die String‑Überladung von [addField](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) akzeptiert einen internen Feld‑Bezeichner. Verwenden Sie sie, wenn Sie einen von einer anderen Anwendung bereitgestellten Bezeichner erhalten, für den es keinen vordefinierten Wert gibt. Sie können außerdem ein [FieldType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) aus dem Bezeichner erstellen. [IFieldType.getInternalString](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) gibt diesen Bezeichner zur Inspektion zurück.

Dieses Beispiel speichert ein anwendungs­spezifisches Feld `custom-report-id` mit dem Fallback‑Text `Report-042`. Der Bezeichner registriert keine Berechnung: Aspose.Slides erzeugt keine Bericht‑IDs für einen unbekannten Typ. Die Anwendung, die diesen Bezeichner versteht, muss seine Bedeutung bereitstellen und seinen Wert aktualisieren.

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

Nach diesem PPTX‑Durchlauf ist der Typ `custom-report-id` und der Text `Report-042`. Wird eine Zeichenkette wie `yyyy-MM-dd` übergeben, wird damit ein Feldtyp benannt; sie konfiguriert jedoch kein benutzerdefiniertes Datumsformat. Für ein festes Datum in einem beliebigen Format verwenden Sie normalen Text.

## **Datums‑/Uhrzeit‑Felder untersuchen, ändern und entfernen**

Ändern Sie ein vorhandenes Feld über [IField.setType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Prüfen Sie, ob das Feld existiert, bevor Sie seinen Typ abfragen. Um automatische Aktualisierungen zu stoppen, rufen Sie [IPortion.removeField](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#removeField--) auf. Dadurch bleibt der Abschnitt und sein aktueller Text erhalten, während die Feldzuordnung entfernt wird. Benötigen Sie einen bestimmten festen Wert, weisen Sie nach dem Entfernen des Feldes den gewünschten Text zu.

Für die API‑Einstellung, die die Verarbeitung von Datums‑/Uhrzeit‑Feldern betrifft, siehe [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Das nachfolgende Beispiel verwendet ein explizites Genehmigungsdatum, wenn ein Feld in normalen Text umgewandelt wird.

Laden Sie [sample.pptx](sample.pptx) herunter und legen Sie die Datei im Arbeitsverzeichnis ab. Sie enthält zwei benannte Text‑Formen, `UpdatedAt` und `ApprovedDate`, jeweils mit einem Datums‑/Uhrzeit‑Feld sowie normale Text‑Etiketten. Das folgende Beispiel durchläuft die obersten Textelemente auf regulären Folien. Es wandelt Datums‑/Uhrzeit‑Felder in ein Langdatums‑Format um und macht sie kursiv, wobei andere Formatierungen erhalten bleiben. Nur Felder in `ApprovedDate` werden zu festem Text.

Die Probe erkennt die eingebauten internen Bezeichner `datetime` und `datetime1` bis `datetime13`. Gruppen, Tabellen, Notizen, Layouts und Master‑Folien erfordern das Durchlaufen ihrer eigenen Text‑Container und liegen außerhalb des Umfangs dieses Beispiels.

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

Nach dem erneuten Öffnen hat `UpdatedAt` den Typ `datetime3` und bleibt dynamisch. `ApprovedDate` besitzt kein Feld und enthält `05 April 2030`. Beide Datums‑Abschnitte sind kursiv, und ihre ursprüngliche Schriftgröße, Fett‑Einstellung und Farbe bleiben unverändert. Die normalen Text‑Etiketten bleiben unverändert. Die Verifizierung liest den ersten Abschnitt der beiden bekannten Formen im bereitgestellten Beispiel.

## **Textformatierung beibehalten**

Arbeiten Sie mit dem bestehenden Abschnitt, wenn Sie ein Feld hinzufügen, dessen Typ ändern oder es entfernen. Diese Vorgänge erhalten die Formatierung des jeweiligen Abschnitts. Nutzen Sie [IPortion.getPortionFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#getPortionFormat--) um nur die erforderlichen Eigenschaften zu ändern, wie die Beispiele für Farbe oder Kursivschrift zeigen.

Vermeiden Sie das Neu‑Erstellen eines gesamten Textfelds nur, um ein Feld zu aktualisieren: Dadurch können ursprünglich gesetzte Abschnittsgrenzen und deren individuelle Formatierung verloren gehen. Unterscheiden Sie zudem ausdrücklich gesetzte Formatierungen von solchen, die vom Absatz, Layout oder Design geerbt werden. Siehe [Textformatierung](/slides/de/androidjava/text-formatting/) für umfassendere Formatierungsoptionen.

## **Felder und Platzhalter für Kopf‑/Fußzeile**

Ein Feld ist Teil eines Text‑Abschnitts. Ein Platzhalter ist ein Shape mit einer Präsentations‑Rolle, z. B. Fußzeile oder Foliennummer. Das Hinzufügen eines Feldes zu einem normalen Textfeld macht dieses Shape nicht zu einem Platzhalter.

Die Kopf‑/Fußzeilen‑Manager steuern den Platzhalter‑Text und die Sichtbarkeit auf Folien, Layouts und Master‑Folien, einschließlich der Weitergabe an abhängige Folien. Ein Zahlen‑Feld in einem benutzerdefinierten Textfeld kann daher nützlich sein, selbst wenn Sie den Folien‑Nummern‑Platzhalter nicht verwenden. Umgekehrt entfernt das Ändern der Platzhalter‑Sichtbarkeit kein Feld aus einem nicht verwandten Textfeld.

Die vordefinierten Kopf‑ und Fußzeilen‑Typen erzeugen weder die entsprechenden Platzhalter noch liefern sie deren Inhalt. Insbesondere besitzt eine normale PowerPoint‑Folie keinen Kopfzeilen‑Platzhalter; Kopfzeilen gehören zu Notiz‑Seiten und Handouts. Gehen Sie nicht davon aus, dass ein Kopf‑ oder Fußzeilen‑Feld in einem beliebigen Shape automatisch den über den Platzhalter‑Manager konfigurierten Text übernimmt. Für diesen Ablauf siehe [Präsentations‑Kopf‑ und Fußzeilen](/slides/de/androidjava/presentation-header-and-footer/).

## **Einschränkungen für PPTX und PPT**

Prüfen Sie sowohl den Feldtyp als auch den daraus resultierenden Text nach dem Speichern und erneuten Öffnen. Das Beibehalten eines Bezeichners beweist nicht, dass eine Anwendung den Wert berechnen oder anzeigen kann.

| Format | Verhalten und Beschränkungen des Feldes |
|---|---|
| PPTX | Speichert interne Feld‑Bezeichner zusammen mit dem Feld‑Text. In Rundreise‑Prüfungen blieben die vordefinierten Typen und der oben verwendete benutzerdefinierte Bezeichner erhalten. Der unbekannte benutzerdefinierte Typ behielt seinen Fallback‑Text; er erhielt keine automatische Berechnungslogik. Eine andere Anwendung kann nicht unterstützte Bezeichner unterschiedlich behandeln. |
| PPT | Verwendet ältere Feld‑Darstellungen und hat eingeschränktere Kompatibilität. In Rundreise‑Prüfungen überlebten Folien‑Nummern‑ und vordefinierte Datums‑/Uhrzeit‑Felder das Speichern und Öffnen. Ein benutzerdefiniertes Feld in einem normalen Folientext‑Box wurde mit seinem Bezeichner, jedoch mit `*` als Text, wieder geöffnet; ein Kopfzeilen‑Feld im selben Kontext erzeugte ebenfalls `*`. Verlassen Sie sich nicht darauf, dass benutzerdefinierte Felder oder nicht unterstützte Feld‑Kontexte ihren sichtbaren Text behalten. |

Für portable, feste Ausgaben konvertieren Sie nicht unterstützte Felder in normalen Text und weisen Sie vor dem Speichern explizit den gewünschten Wert zu. Damit bleibt der gewählte Text erhalten, während automatische Updates bewusst deaktiviert werden. Testen Sie auch die Zielanwendung, wenn deren eigene Feld‑Neuberechnung Teil Ihres Workflows ist.

## **FAQ**

**Wie kann ich feststellen, ob eine angezeigte Nummer oder ein Datum ein Feld ist?**

Untersuchen Sie [IPortion.getField](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#getField--). Ein von `null` verschiedenes Ergebnis kennzeichnet ein Feld; der angezeigte Text allein liefert keinen Hinweis.

**Entfernt das Entfernen eines Feldes dessen Text oder Formatierung?**

Nein. [removeField](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iportion/#removeField--) wandelt den bestehenden Abschnitt in normalen Text um. Weisen Sie danach bei Bedarf explizit einen Wert zu, wenn Sie ein festes Datum oder einen Fallback‑Text benötigen.

**Kann ein interner String ein neues Datumsformat oder eine Formel definieren?**

Nein. Er identifiziert lediglich einen Feldtyp. Ein unbekannter Bezeichner liefert keinen Evaluator oder ein Java‑Datum‑Format‑Muster. Verwenden Sie einen unterstützten vordefinierten Typ oder formatieren Sie den Wert selbst als normalen Text.

**Warum sollte man eine Präsentation nach dem Speichern erneut prüfen?**

Feld‑Bezeichner, berechneter Text und Formatierung sind getrennte Aspekte, die überprüft werden müssen. Eine Formatkonvertierung kann das sichtbare Ergebnis ändern, obwohl der Feld‑Bezeichner noch vorhanden ist.