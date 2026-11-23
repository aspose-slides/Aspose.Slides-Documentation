---
title: Automatisieren der Präsentationspersonalisierung mit Serienbrief
linktitle: Serienbrief
type: docs
weight: 233
url: /de/net/mail-merge/
keywords:
- Serienbrief
- Präsentationspersonalisierung
- Präsentationsvorlage
- Textplatzhalter
- Datenquelle
- CSV
- Excel
- XLSX
- JSON
- XML
- Daten zusammenführen
- Präsentationen erzeugen
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie den Serienbrief in Aspose.Slides für .NET verwenden, um Präsentationsvorlagen mit Daten zu füllen und personalisierte PowerPoint-Präsentationen aus CSV-, Excel-, JSON- und XML-Quellen zu erzeugen."
---
# Serienbrief in PowerPoint‑Präsentationen

Aspose.Slides for .NET ermöglicht das automatische Erzeugen von PowerPoint‑Präsentationen mithilfe einer Vorlage und einer Datenquelle. Der Serienbrief füllt Platzhalter in der Vorlage mit Daten und erstellt entweder eine einzelne Präsentation mit wiederholten Vorlagenfolien für jeden Datensatz oder eine separate Präsentation für jeden Datensatz.

Diese Funktion ist nützlich zum Erstellen von Produktkatalogen, personalisierten Präsentationen, Berichten, Zertifikaten, Angeboten, Preislisten und anderen Dokumenten, bei denen die Präsentationsstruktur gleich bleibt, während sich der Inhalt ändert.

![Serienbrief: Vorher und Nachher](mail-merge-before-after.png)


## Wie der Serienbrief funktioniert

Der Serienbrief verwendet eine PowerPoint‑Präsentation als Vorlage und ersetzt Platzhalter durch Werte aus einer Datenquelle.

![Serienbrief‑Workflow](mail-merge-workflow.png)

Ein Platzhalter ist ein Feldname, der in doppelte geschweifte Klammern eingeschlossen ist, z. B. `{{title}}` oder `{{price}}`. Platzhalter können im Text von Formen, Tabellenzellen, gruppierten Formen und Sprechernotizen platziert werden.

Beispielsweise kann eine Vorlagenfolie den folgenden Text enthalten:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

Wenn die Datenquelle die folgenden Werte enthält:

| Feld | Wert |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14‑Zoll‑Display, 16 GB RAM |

Ersetzt der Serienbrief die Platzhalter durch die entsprechenden Werte und erzeugt eine Folie mit den tatsächlichen Produktinformationen.

Feldnamen sind nicht groß‑/kleinschreibungsabhängig, sodass `{{title}}` und `{{Title}}` dasselbe Feld bezeichnen.

Folgende Regeln gelten beim Ersetzen von Platzhaltern:

- Platzhalter werden auf Folien, einschließlich gruppierter Formen und Tabellenzellen, sowie in Sprechernotizen ersetzt.
- Platzhalter auf Master‑Folien und Layout‑Folien werden **nicht** ersetzt.
- Ein Platzhalter, dessen Feld im Datensatz nicht vorhanden ist, bleibt unverändert.
- Ein leerer Feldwert ersetzt seinen Platzhalter durch eine leere Zeichenkette.
- Der eingefügte Text übernimmt die Formatierung des ersten Zeichens des Platzhalters.
- Werte dürfen keinen Platzhaltertext enthalten, da der eingefügte Text sonst erneut verarbeitet und durch ein anderes Feld ersetzt werden könnte.

Die ursprüngliche Vorlagenpräsentation wird während des Merge‑Vorgangs nicht verändert und muss mindestens eine Folie enthalten.

## Unterstützte Datenquellen

Der Serienbrief unterstützt zwei Arten der Datenbereitstellung:

- Erstellen einer Datenquelle programmatisch mit `IMailMergeDataSource`.
- Lesen von Daten aus einer CSV‑, XLSX‑, JSON‑ oder XML‑Datei bzw. einem Stream.

Das Datenformat wird anhand seines Inhalts erkannt, nicht anhand der Dateierweiterung. Streams, die kein Seek‑Unterstützung bieten, werden ebenfalls unterstützt.

Die Datenquelle muss mindestens einen Datensatz enthalten. Jeder Datensatz entspricht einer Kopie der Vorlage, die mit seinen Werten gefüllt wird.

Wenn der Dateninhalt nicht als unterstütztes Format erkannt wird, wird `NotSupportedException` ausgelöst. Wird das Format erkannt, aber entspricht nicht den Anforderungen, wird `InvalidDataException` ausgelöst. Die Fehlermeldung enthält den Ort des Fehlers in den Daten.

### JSON

Die JSON‑Datenquelle muss ein Root‑Objekt mit einem `sets`‑Array enthalten. Jedes Element des Arrays stellt einen Datensatz dar und muss ein `fields`‑Array enthalten. Jedes Feld muss über die Zeichenketten `name` und `value` verfügen.

Die optionale Eigenschaft `version` muss `"1.0"` sein, und die optionale Eigenschaft `type` eines Feldes muss `"text"` sein. Eigenschaftsnamen sind groß‑/kleinschreibungsabhängig. Unbekannte Eigenschaften werden ignoriert.

JSON‑Daten werden als UTF‑8 gelesen, oder als UTF‑16, wenn die Daten mit einer Byte‑Order‑Markierung (BOM) beginnen.

Das folgende Beispiel enthält zwei Datensätze:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### XML

Die XML‑Datenquelle muss ein `template`‑Root‑Element mit dem `sets`‑Element enthalten. Jedes `set`‑Element enthält `field`‑Elemente, und jedes Feld muss `name`‑ und `value`‑Elemente besitzen.

Ein leeres `value`‑Element wird als leere Zeichenkette behandelt. Elementnamen sind groß‑/kleinschreibungsabhängig. Unbekannte Elemente und Kommentare werden ignoriert. Die Kodierung wird durch die XML‑Deklaration bestimmt. Dokumenttyp‑Definitionen (DTD) sind nicht erlaubt.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### CSV

CSV‑Daten verwenden Semikolons als Werttrenner.

Die erste Zeile enthält Feldnamen und endet beim ersten leeren Feldnamen. Jede nachfolgende Zeile stellt einen Datensatz dar. Daten enden bei der ersten leeren Zeile.

Es gelten folgende Regeln:

- Fehlende Werte am Ende einer Zeile werden als leere Zeichenketten behandelt.
- Werte jenseits der definierten Feldnamen werden ignoriert.
- Ein Wert, der ein Semikolon, Anführungszeichen oder einen Zeilenumbruch enthält, muss in Anführungszeichen gesetzt werden.
- Anführungszeichen innerhalb eines mit Anführungszeichen umschlossenen Werts müssen verdoppelt werden.
- Daten werden als UTF‑8 gelesen, oder als UTF‑16, wenn sie mit einer BOM beginnen.

Beispiel:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

XLSX‑Daten werden aus dem ersten Arbeitsblatt gelesen.

Das Arbeitsblatt folgt denselben Regeln wie CSV:

- Die erste Zeile enthält Feldnamen und endet bei der ersten leeren Zelle.
- Jede nachfolgende Zeile stellt einen Datensatz dar.
- Daten enden bei der ersten leeren Zeile.
- Leere Zellen werden als leere Zeichenketten behandelt.
- Numerische Werte werden mit der invariant culture in Text konvertiert.

## Erstellen einer einzelnen Präsentation

Die Methode `MergeToSinglePresentation` erzeugt eine Präsentation, die für jeden Datensatz eine Kopie der Vorlagenfolien enthält. Jede Kopie wird mit den entsprechenden Daten gefüllt.

Die Reihenfolge der Datensätze bestimmt die Reihenfolge der Foliengruppen in der resultierenden Präsentation.

### Zusammenführen von Daten aus einer Datei

Das folgende Beispiel lädt eine Vorlage und eine JSON‑Datendatei, erstellt eine einzelne Präsentation mit den Folien für alle Datensätze und speichert das Ergebnis.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Die Daten können auch aus einem Stream gelesen werden. Der Stream wird ab seiner aktuellen Position gelesen und vom Serienbrief‑Vorgang nicht geschlossen.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### Erstellen einer Datenquelle im Code

Sie können eine Datenquelle programmgesteuert mit `MailMergeDataSource` und `MailMergeDataSet` aufbauen. Fügen Sie für jeden Datensatz ein Dataset hinzu und definieren Sie dessen Felder mit der Methode `AddText`.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

In diesem Beispiel werden die Vorlagenfolien zweimal wiederholt: einmal für den Laptop und einmal für das Tablet. Die Platzhalter werden mit den in jedem Datensatz definierten Werten gefüllt.

## Erstellen mehrerer Präsentationen

Falls Sie für jeden Datensatz eine separate Präsentation benötigen, verwenden Sie die Methode `MergeToMultiplePresentations`.

Diese Methode verarbeitet die Datensätze nacheinander, erstellt aus der Vorlage eine Präsentation, füllt sie mit den aktuellen Daten und übergibt die resultierende Präsentation an einen Handler.

Der Handler wird einmal pro Datensatz in der ursprünglichen Datenreihenfolge aufgerufen.

### Speichern jeder Präsentation

Das folgende Beispiel liest Daten aus einer CSV‑Datei und speichert jede erzeugte Präsentation als separate Datei.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

Die Eigenschaft `args.Index` liefert den nullbasierten Index des aktuellen Datensatzes. Im Beispiel wird sie verwendet, um fortlaufende Dateinamen ab `product_1.pptx` zu erzeugen.

Die Daten können auch aus einem Stream gelesen werden:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### Verwendung von Datensatzwerten zum Benennen von Dateien

Der Handler erhält sowohl die erzeugte Präsentation als auch Informationen über den zum Erzeugen verwendeten Datensatz. Sie können die Datensatzwerte nutzen, um sinnvolle Dateinamen zu erstellen.

Beispielhaft speichert der folgende Code jede Präsentation anhand des Produkttitels:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

Die Eigenschaft `DataSet` gibt den Datensatz zurück, der zur Befüllung der aktuellen Präsentation verwendet wurde. Die Methode `GetText` liefert den Wert eines angegebenen Feldes oder `null`, wenn das Feld nicht vorhanden ist.

Damit können Sie Feldwerte für Dateinamen, die Organisation von Ausgaben oder zusätzliche Verarbeitung im Handler verwenden.

## Verarbeitung erzeugter Präsentationen

`MergeToMultiplePresentations` verwendet das Delegat `MailMergedPresentationHandler`, um jede erzeugte Präsentation zu verarbeiten.

Der Handler erhält zwei Argumente:

- `presentation` — die aus der Vorlage erstellte Präsentation, gefüllt mit dem aktuellen Datensatz.
- `args` — Informationen über die erzeugte Präsentation, einschließlich des Datensatz‑Indexes und des Datensatzes selbst.

Die erzeugte Präsentation gehört zum Serienbrief‑Vorgang und wird sofort nach Rückkehr des Handlers verworfen. Sie müssen sie also innerhalb des Handlers speichern oder benötigte Daten kopieren. Halten Sie nach dem Rücklauf keine Referenz mehr und entsorgen Sie sie nicht manuell.

Der Handler wird im Aufrufer‑Thread ausgeführt, jeweils eine Präsentation, in der Reihenfolge der Datensätze. Zu jedem Zeitpunkt wird nur eine erzeugte Präsentation im Speicher gehalten, sodass dieses Vorgehen für große Datenquellen geeignet ist, ohne alle Präsentationen gleichzeitig zu laden.

Wirft der Handler eine Ausnahme, wird der Serienbrief‑Vorgang abgebrochen und die Ausnahme unverändert an den Aufrufer weitergereicht. Bereits verarbeitete Präsentationen bleiben unverändert, die übrigen Datensätze werden nicht verarbeitet.

Das folgende Beispiel speichert erzeugte Präsentationen in einem eigenen Verzeichnis:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## Arbeiten mit Serienbrief‑Daten

Die Klasse `MailMergeDataSource` stellt eine geordnete Sammlung von Datensätzen dar. Sie kann zum Erzeugen von Daten im Code, zum Prüfen der Anzahl von Datensätzen und zum Zugriff auf einzelne Datensätze nach Index verwendet werden.

### Ermitteln der Anzahl von Datensätzen

Die Eigenschaft `Count` gibt die Anzahl der Datensätze in der Quelle zurück.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### Zugriff auf einen Datensatz per Index

Die Eigenschaft `Item(int)` ermöglicht den Zugriff auf einen Datensatz am angegebenen nullbasierten Index.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Dieses Beispiel gibt den Titel des zweiten Datensatzes zurück.

### Hinzufügen von Textfeldern

Die Methode `AddText` fügt einem Datensatz ein benanntes Textfeld hinzu. Der Feldwert ersetzt alle passenden Platzhalter in der Vorlage.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Ein leerer Wert entfernt den entsprechenden Platzhalter aus dem resultierenden Text. Wird das Feld nicht zum Datensatz hinzugefügt, bleibt der Platzhalter unverändert.

### Auslesen von Textfeldern

Die Methode `GetText` liefert den Wert eines Feldes anhand seines Namens. Feldnamen sind nicht groß‑/kleinschreibungsabhängig.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Existiert das Feld nicht oder ist der angegebene Feldname `null`, liefert `GetText` `null`.

## Zusammenfassung

Der Serienbrief in Aspose.Slides for .NET bietet eine bequeme Möglichkeit, datengetriebene Präsentationen aus einer wiederverwendbaren Vorlage zu erzeugen.

Sie können ihn einsetzen, um:

- Präsentationsvorlagen mit Werten aus Datenquellen zu belegen.
- Eine einzelne Präsentation mit wiederholten Vorlagenfolien für mehrere Datensätze zu erzeugen.
- Für jeden Datensatz eine separate Präsentation zu erstellen.
- Daten aus CSV‑, XLSX‑, JSON‑ und XML‑Dateien bzw. Streams zu lesen.
- Datenquellen direkt im Code zu bauen.
- Erzeugte Präsentationen sequenziell mithilfe eines Handlers zu verarbeiten und zu speichern.

Durch die Kombination wiederverwendbarer Vorlagen mit strukturierten Daten können Sie die Erstellung großer Mengen von Präsentationen automatisieren, während Design und Datenverarbeitung getrennt bleiben.

## Häufig gestellte Fragen

### Kann ich denselben Platzhalter mehrfach in einer Vorlage verwenden?

Ja. Jede Instanz eines Platzhalters mit übereinstimmendem Feldnamen wird durch den entsprechenden Wert des aktuellen Datensatzes ersetzt.

### Sind Feldnamen groß‑/kleinschreibungsabhängig?

Nein. Platzhalter‑ und Feldnamen sind nicht groß‑/kleinschreibungsabhängig. Beispielsweise beziehen sich `{{title}}`, `{{Title}}` und `{{TITLE}}` auf dasselbe Feld.

### Was passiert, wenn ein Feld in einem Datensatz fehlt?

Enthält der Datensatz kein Feld, das von einem Platzhalter referenziert wird, bleibt dieser Platzhalter in der erzeugten Präsentation unverändert.

### Was passiert, wenn ein Feld einen leeren Wert hat?

Ein leerer Feldwert ersetzt den Platzhalter durch eine leere Zeichenkette. Der Platzhaltertext wird entfernt, sodass an seiner Stelle kein Text erscheint.

### Kann ich die Formatierung eines Platzhalters beim Ersetzen beibehalten?

Der ersetzte Text übernimmt die Formatierung des ersten Zeichens des Platzhalters. Formatieren Sie den Platzhaltertext in der Vorlage nach Wunsch, bevor Sie den Merge ausführen.

### Ersetzt der Serienbrief Platzhalter auf Master‑ oder Layout‑Folien?

Nein. Der Serienbrief ersetzt Platzhalter nur in unterstützten Inhalten von Präsentationsfolien, also Formen, gruppierten Formen, Tabellenzellen und Sprechernotizen. Platzhalter auf Master‑ und Layout‑Folien bleiben unverändert.

### Wird die Vorlagenpräsentation während des Merges geändert?

Nein. Die Originalvorlage wird vom Merge‑Vorgang nicht verändert. Sie können sie wiederverwenden, um Präsentationen aus derselben oder einer anderen Datenquelle zu erzeugen.

### Kann ich für jeden Datensatz eine separate Präsentation erzeugen?

Ja. Verwenden Sie `MergeToMultiplePresentations` und speichern Sie jede erzeugte Präsentation im Handler. Der Handler wird nacheinander für jeden Datensatz aufgerufen.

### Kann ich alle Datensätze zu einer einzigen Präsentation kombinieren?

Ja. Verwenden Sie `MergeToSinglePresentation`. Dabei entsteht eine einzelne Ausgabepresentation, die für jeden Datensatz eine Kopie der Vorlagenfolien enthält, in Reihenfolge der Datenquelle.

### Kann ich eine Datenquelle nutzen, ohne sie in einer Datei zu speichern?

Ja. Sie können im Code ein `MailMergeDataSource` erstellen, Datensätze hinzufügen und Felder mit `AddText` befüllen. Das ist praktisch, wenn die Daten bereits in Ihrer Anwendung verfügbar sind.

### Erkennt der Serienbrief das Datenformat anhand der Dateierweiterung?

Nein. Das Datenformat wird aus dem Inhalt ermittelt, sodass eine unterstützte Datenquelle keine bestimmte Dateierweiterung besitzen muss.

### Kann ich Daten aus einem Stream lesen, der kein Seek‑Verhalten unterstützt?

Ja. Der Serienbrief unterstützt nicht‑suchbare Streams.

### Was passiert, wenn die Datenquelle leer ist oder keine Datensätze enthält?

Die Datenquelle muss mindestens einen Datensatz enthalten. Stellen Sie sicher, dass mindestens ein Datensatz vorhanden ist, bevor Sie den Merge‑Vorgang starten.

### Was passiert, wenn die Datenquelle ein ungültiges Format hat?

Wird der Inhalt nicht als eines der unterstützten Formate erkannt, wird `NotSupportedException` geworfen. Wird das Format erkannt, aber ist es fehlerhaft, wird `InvalidDataException` geworfen. Die Fehlermeldung enthält Informationen über den Ort des Fehlers.

### Kann ich die erzeugte Präsentation nach Rückkehr des Handlers weiterverwenden?

Die an den `MergeToMultiplePresentations`‑Handler übergebene Präsentation gehört dem Serienbrief und wird nach dem Handleraufruf verworfen. Speichern Sie sie oder kopieren Sie den benötigten Inhalt innerhalb des Handlers und behalten Sie danach keine Referenz bei oder entsorgen Sie sie nicht selbst.

### Wird der Handler parallel aufgerufen?

Nein. Erzeugte Präsentationen werden sequenziell im Aufrufer‑Thread verarbeitet. Zu jedem Zeitpunkt wird nur eine Präsentation im Speicher gehalten.

### Was passiert, wenn im Handler eine Ausnahme auftritt?

Der Merge‑Vorgang wird gestoppt und die Ausnahme unverändert an den Aufrufer weitergereicht. bereits verarbeitete Präsentationen bleiben unbeeinflusst, nachfolgende Datensätze werden nicht mehr verarbeitet.

### Kann ich Feldwerte zum Erzeugen von Ausgabedateinamen verwenden?

Ja. Der Handler stellt den aktuellen Datensatz über seine Argumente bereit. Verwenden Sie `GetText`, um Feldwerte abzurufen und daraus Dateinamen für jede erzeugte Präsentation zu bilden. Achten Sie darauf, dass die Werte für Dateinamen im Zielumfeld gültig sind.