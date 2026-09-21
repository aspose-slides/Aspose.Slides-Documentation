---
title: Textfelder in PowerPoint-Präsentationen in Java verwalten
linktitle: Textfelder
type: docs
weight: 52
url: /de/java/text-fields/
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
- Java
- Aspose.Slides
description: "Erstellen, inspizieren, ändern und entfernen Sie Textfelder in PowerPoint-Präsentationen mit Aspose.Slides für Java. Formatierung beibehalten und gespeicherte PPTX- und PPT-Dateien überprüfen."
---
## **Übersicht**

Ein Textabsatz besteht aus Portionen. Eine gewöhnliche [IPortion](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/) enthält wörtlichen Text; eine Feldportion hat außerdem ein [IField](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifield/), dessen Typ einen automatisch aktualisierten Wert bezeichnet, z. B. eine Foliennummer oder ein Datum. Zwei Portionen können dieselben Zeichen anzeigen, während nur eine ein Feld enthält.

Verwenden Sie [IPortion.getField](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#getField--) , um sie zu unterscheiden: Sie ist `null` für gewöhnlichen Text. [IPortion.addField](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) wandelt eine vorhandene Portion in ein Feld um. Halten Sie Beschriftung und dynamischen Wert in separaten Portionen, damit das Konvertieren des Wertes nicht gleichzeitig die Beschriftung ersetzt.

Dieses Handbuch behandelt Felder innerhalb von Text, deren Formatierung und das Speichern in PPTX und PPT. Für Textfelder und Absätze siehe [Text verwalten](/slides/de/java/manage-text/).

## **Erstellen eines Foliennummernfelds**

Das folgende vollständige Beispiel erstellt ein Textfeld, das eine wörtliche Beschriftung `Slide ` gefolgt von einer automatisch aktualisierten Nummer enthält. Es legt Größe, Gewicht und Farbe der Nummer fest, bevor das Feld hinzugefügt wird, öffnet anschließend die gespeicherte Präsentation wieder und prüft den Feldtyp, den Text und die Formatierung. Es ist keine Eingabedatei erforderlich.

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

Die neue Präsentation beginnt mit Foliennummer 1, sodass der Text `Slide 1` lautet und beide Prüfungen `true` ausgeben. Die Nummer bleibt nach dem erneuten Öffnen ein Feld; sie ist kein wörtliches `1`. Die Typumwandlungen und Indizes in der Verifikation beziehen sich auf die von diesem Beispiel erstellte Form und die Portionen.

## **Auswahl eines Feldtyps**

[FieldType](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/) implementiert [IFieldType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifieldtype/) und stellt die folgenden Methoden zum Abrufen vordefinierter Werte bereit. Übergeben Sie den entsprechenden Wert an [addField](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Methode | Zweck |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Die aktuelle Foliennummer. |
| [getDateTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getDateTime--) | Datum/Uhrzeit im Standardformat der rendernden Anwendung. |
| [getDateTime1](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getDateTime9--) | Vordefinierte Datum- oder kombinierte Datum/Uhrzeit-Formate. |
| [getDateTime10](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getDateTime13--) | Vordefinierte Zeitformate, mit Optionen für Sekunden und einer 12‑Stunden‑Uhr. |
| [getHeader](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getHeader--) | Ein Kopfzeilenfeld; siehe unten die Platzhalter‑ und Formatbeschränkungen. |
| [getFooter](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getFooter--) | Ein Fußzeilenfeld. |

Zum Beispiel stellt [getDateTime3](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#getDateTime3--) einen Tag, den vollständigen Monatsnamen und das Jahr in Englisch dar. Dies sind vordefinierte Feldformate, keine beliebigen Java‑Datum‑Format‑Zeichenfolgen. Die mit [setLanguageId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) festgelegte Sprache und die Anwendung, die die Präsentation verarbeitet, können das angezeigte Ergebnis beeinflussen.

## **Erstellen eines Feldes aus einem internen String**

Die String‑Überladung von [addField](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#addField-java.lang.String-) akzeptiert einen internen Feld‑Bezeichner. Verwenden Sie sie, wenn Sie einen von einer anderen Anwendung bereitgestellten Bezeichner erhalten wollen, für den es keinen vordefinierten Wert gibt. Sie können auch ein [FieldType](https://reference.aspose.com/slides/de/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) aus dem Bezeichner erstellen. [IFieldType.getInternalString](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifieldtype/#getInternalString--) legt diesen Bezeichner zur Inspektion offen.

Dieses Beispiel speichert ein anwendungsspezifisches Feld `custom-report-id` mit dem Ersatztext `Report-042`. Der Bezeichner registriert keine Berechnung: Aspose.Slides generiert keine Bericht‑IDs für einen unbekannten Typ. Die Anwendung, die diesen Bezeichner versteht, muss seine Bedeutung bereitstellen und seinen Wert aktualisieren.

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

Nach diesem PPTX‑Rundlauf ist der Typ `custom-report-id` und der Text `Report-042`. Das Übergeben einer Zeichenkette wie `yyyy-MM-dd` würde einen Feldtyp benennen; es würde kein benutzerdefiniertes Datumsformat konfigurieren. Verwenden Sie für ein festes Datum in einem beliebigen Format normalen Text.

## **Untersuchen, Ändern und Entfernen von Datum/Uhrzeit‑Feldern**

Ändern Sie ein vorhandenes Feld über [IField.setType](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Prüfen Sie, ob das Feld existiert, bevor Sie auf seinen Typ zugreifen. Um automatische Aktualisierungen zu stoppen, rufen Sie [IPortion.removeField](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#removeField--) auf. Dadurch bleibt die Portion und ihr aktueller Text erhalten, während die Feldzuordnung entfernt wird. Falls Sie einen bestimmten festen Wert benötigen, weisen Sie nach dem Entfernen des Feldes diesen Text zu.

Zur API‑Einstellung, die die Verarbeitung von Datum/Uhrzeit‑Feldern betrifft, siehe [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Das untenstehende Beispiel verwendet ein explizites Genehmigungsdatum, wenn ein Feld in gewöhnlichen Text umgewandelt wird.

Laden Sie [sample.pptx](sample.pptx) herunter und legen Sie es im Arbeitsverzeichnis ab. Es enthält zwei benannte Textformen, `UpdatedAt` und `ApprovedDate`, jeweils mit einem Datum/Uhrzeit‑Feld sowie gewöhnliche Textbeschriftungen. Das folgende Beispiel durchläuft die Textformen der obersten Ebene auf regulären Folien. Es ändert Datum/Uhrzeit‑Felder in ein Langdatumsformat und macht sie kursiv, wobei die übrige Formatierung erhalten bleibt. Nur Felder in `ApprovedDate` werden zu festem Text.

Das Beispiel erkennt die integrierten internen Bezeichner `datetime` und `datetime1` bis `datetime13`. Gruppen, Tabellen, Notizen, Layouts und Master erfordern das Durchlaufen ihrer eigenen Textcontainer und liegen außerhalb des Umfangs dieses Beispiels.

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

Nach dem erneuten Öffnen hat `UpdatedAt` den Typ `datetime3` und bleibt dynamisch. `ApprovedDate` hat kein Feld und enthält `05 April 2030`. Beide Datumsportionen sind kursiv, und ihre ursprüngliche Schriftgröße, Fettdruck‑Einstellung und Farbe bleiben erhalten. Die gewöhnlichen Textbeschriftungen bleiben unverändert. Die Verifikation liest die erste Portion der beiden bekannten Formen im bereitgestellten Beispiel.

## **Textformatierung beibehalten**

Arbeiten Sie mit der bestehenden Portion, wenn Sie ein Feld hinzufügen, dessen Typ ändern oder es entfernen. Diese Vorgänge behalten die Formatierung dieser Portion bei. Verwenden Sie [IPortion.getPortionFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#getPortionFormat--) , um nur die erforderlichen Eigenschaften zu ändern, wie die Beispiele für Farbe oder Kursivschrift zeigen.

Vermeiden Sie das Neuaufbauen eines gesamten Textrahmens nur zum Aktualisieren eines Feldes: Das kann die ursprünglichen Portionsgrenzen und deren individuelle Formatierung verlieren. Unterscheiden Sie zudem explizit gesetzte Formatierungen von denen, die vom Absatz, Layout oder Theme geerbt werden. Siehe [Textformatierung](/slides/de/java/text-formatting/) für umfassendere Formatierungsoptionen.

## **Felder und Platzhalter für Kopf‑/Fußzeilen**

Ein Feld ist Teil einer Textportion. Ein Platzhalter ist eine Form mit einer Präsentationsrolle, z. B. Fußzeile oder Foliennummer. Das Hinzufügen eines Feldes zu einem gewöhnlichen Textfeld macht diese Form nicht zu einem Platzhalter.

Die Header‑/Footer‑Manager steuern den Platzhalter‑Text und die Sichtbarkeit auf Folien, Layouts und Master, einschließlich der Weitergabe an abhängige Folien. Ein Zahlenfeld in einem benutzerdefinierten Textfeld kann daher nützlich sein, selbst wenn Sie den Foliennummern‑Platzhalter nicht verwenden. Umgekehrt entfernt das Ändern der Platzhalter‑Sichtbarkeit kein Feld aus einem nicht zugehörigen Textfeld.

Die vordefinierten Header‑ und Footer‑Typen erzeugen nicht die entsprechenden Platzhalter und stellen deren Inhalt nicht bereit. Insbesondere hat eine reguläre PowerPoint‑Folie keinen Header‑Platzhalter; Header gehören zu Notizseiten und Handouts. Gehen Sie nicht davon aus, dass ein Header‑ oder Footer‑Feld in einer beliebigen Form automatisch den durch einen Platzhalter‑Manager konfigurierten Text übernimmt. Für diesen Workflow siehe [Präsentations‑Header und‑Footer](/slides/de/java/presentation-header-and-footer/).

## **Einschränkungen für PPTX und PPT**

Überprüfen Sie sowohl den Feldtyp als auch den resultierenden Text nach dem Speichern und erneuten Öffnen. Das Beibehalten eines Bezeichners beweist nicht, dass eine Anwendung dessen Wert berechnen oder anzeigen kann.

| Format | Verhalten des Feldes und Einschränkungen |
|---|---|
| PPTX | Speichert interne Feld‑Bezeichner zusammen mit dem Feldtext. Bei Rundlauf‑Prüfungen überlebten die vordefinierten Typen und der oben verwendete benutzerdefinierte Bezeichner das Speichern und erneute Öffnen. Der unbekannte benutzerdefinierte Typ behielt seinen Ersatztext bei; er erlangte keine automatische Berechnungslogik. Eine andere Anwendung kann nicht unterstützte Bezeichner anders behandeln. |
| PPT | Verwendet veraltete Felddarstellungen und hat eine eingeschränktere Kompatibilität. Bei Rundlauf‑Prüfungen überlebten Folien‑Nummern‑ und vordefinierte Datum/Uhrzeit‑Felder das Speichern und erneute Öffnen. Ein benutzerdefiniertes Feld in einem gewöhnlichen Folientextfeld wurde mit seinem Bezeichner, aber mit `*` als Text wieder geöffnet; ein Header‑Feld im selben Kontext erzeugte ebenfalls `*`. Verlassen Sie sich nicht darauf, dass benutzerdefinierte Felder oder nicht unterstützte Feldkontexte ihren sichtbaren Text behalten. |

Für portable, feste Ausgaben konvertieren Sie nicht unterstützte Felder in gewöhnlichen Text und weisen Sie vor dem Speichern explizit den gewünschten Wert zu. Dadurch wird der gewählte Text beibehalten, aber automatische Aktualisierungen bewusst gestoppt. Testen Sie auch die Zielanwendung, wenn deren eigene Feldneuberechnung Teil Ihres Workflows ist.

## **FAQ**

**Wie kann ich feststellen, ob eine angezeigte Nummer oder ein Datum ein Feld ist?**  
Untersuchen Sie [IPortion.getField](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#getField--). Ein Wert ungleich `null` identifiziert ein Feld; der angezeigte Text allein kann das nicht ergeben.

**Entfernt das Entfernen eines Feldes dessen Text oder Formatierung?**  
Nein. [removeField](https://reference.aspose.com/slides/de/java/com.aspose.slides/iportion/#removeField--) wandelt die bestehende Portion in gewöhnlichen Text um. Weisen Sie danach einen expliziten Wert zu, wenn Sie ein bestimmtes eingefrorenes Datum oder einen Ersatzwert benötigen.

**Kann ein interner String ein neues Datumsformat oder eine Formel definieren?**  
Nein. Er identifiziert einen Feldtyp. Ein unbekannter Bezeichner liefert keinen Evaluator oder ein Java‑Datum‑Format‑Muster. Verwenden Sie einen unterstützten vordefinierten Typ oder formatieren Sie einen Wert selbst als gewöhnlichen Text.

**Warum sollte man eine Präsentation nach dem Speichern erneut überprüfen?**  
Feld‑Bezeichner, berechneter Text und Formatierung sind getrennte Dinge, die überprüft werden müssen. Eine Formatkonvertierung kann das sichtbare Ergebnis ändern, auch wenn der Feld‑Bezeichner weiterhin vorhanden ist.