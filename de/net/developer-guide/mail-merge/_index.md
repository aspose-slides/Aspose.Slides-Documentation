---
title: Automatisieren Sie die Personalisierung von Präsentationen mit Mail Merge
linktitle: Mail Merge
type: docs
weight: 233
url: /de/net/mail-merge/
keywords:
- Mail Merge
- Personalisierung von Präsentationen
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
description: "Erfahren Sie, wie Sie Mail Merge in Aspose.Slides für .NET verwenden, um Präsentationsvorlagen mit Daten zu füllen und personalisierte PowerPoint-Präsentationen aus CSV-, Excel-, JSON- und XML-Quellen zu erstellen."
---
## **Mail Merge in PowerPoint-Präsentationen**

Aspose.Slides für .NET ermöglicht das automatische Erstellen von PowerPoint-Präsentationen mithilfe einer Vorlage und einer Datenquelle. Mail Merge füllt Platzhalter in der Vorlage mit Daten und erzeugt entweder eine einzelne Präsentation, die für jeden Datensatz wiederholte Vorlagenfolien enthält, oder eine separate Präsentation für jeden Datensatz.

Diese Funktion ist nützlich zum Erstellen von Produktkatalogen, personalisierten Präsentationen, Berichten, Zertifikaten, Angeboten, Preislisten und anderen Dokumenten, bei denen die Struktur der Präsentation gleich bleibt, während sich der Inhalt ändert.

![Serienbrief: Vorher und danach](mail-merge-before-after.png)


## **Wie Mail Merge funktioniert**

Mail Merge verwendet eine PowerPoint-Präsentation als Vorlage und ersetzt Platzhalter durch Werte aus einer Datenquelle.

![Mail Merge‑Arbeitsablauf](mail-merge-workflow.png)

Ein Platzhalter ist ein Feldname, der in doppelte geschweifte Klammern eingeschlossen ist, z. B. `{{title}}` oder `{{price}}`. Platzhalter können im Text von Formen, Tabellenzellen, Gruppierungen und Sprecher‑Notizen platziert werden.

Beispielhafter Text einer Vorlagenfolie:

- `Produkt: {{title}}`
- `Preis: {{price}}`
- `Beschreibung: {{description}}`

Wenn die Datenquelle die folgenden Werte enthält:

| Feld | Wert |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Mail Merge ersetzt die Platzhalter durch die entsprechenden Werte und erzeugt eine Folie mit den tatsächlichen Produktinformationen.

Feldnamen sind case‑insensitive, sodass `{{title}}` und `{{Title}}` auf dasselbe Feld verweisen.

Die folgenden Regeln gelten beim Ersetzen von Platzhaltern:

- Platzhalter werden in Folien ersetzt, einschließlich gruppierter Formen und Tabellenzellen, sowie in Sprecher‑Notizen.
- Platzhalter auf Master‑Folien und Layout‑Folien werden nicht ersetzt.
- Ein Platzhalter, dessen Feld im Datensatz nicht vorhanden ist, bleibt unverändert.
- Ein leerer Feldwert ersetzt seinen Platzhalter durch eine leere Zeichenkette.
- Der eingefügte Text übernimmt die Formatierung des ersten Zeichens des Platzhalters.
- Werte dürfen keinen Platzhalter‑Text enthalten, da der eingefügte Text erneut verarbeitet und durch ein anderes Feld ersetzt werden könnte.

Die ursprüngliche Vorlagenpräsentation wird während des Merge‑Vorgangs nicht verändert und muss mindestens eine Folie enthalten.

## **Unterstützte Datenquellen**

Mail Merge unterstützt zwei Möglichkeiten, Daten bereitzustellen:

- Erstellen einer Datenquelle programmgesteuert mithilfe von `IMailMergeDataSource`.
- Lesen von Daten aus einer CSV-, XLSX-, JSON- oder XML-Datei bzw. einem Stream.

Das Datenformat wird anhand des Inhalts erkannt, nicht anhand der Dateierweiterung. Streams, die kein Seek‑Verhalten unterstützen, werden ebenfalls unterstützt.

Die Datenquelle muss mindestens einen Datensatz enthalten. Jeder Datensatz stellt eine Kopie der Vorlage dar, die mit seinen Werten gefüllt wird.

Wenn der Dateninhalt nicht als unterstütztes Format erkannt werden kann, wird `NotSupportedException` ausgelöst. Wird der Inhalt erkannt, entspricht er aber nicht den Formatvorgaben, wird `InvalidDataException` ausgelöst. Die Fehlermeldung enthält den Ort des Fehlers in den Daten.

### **JSON**

Die JSON‑Datenquelle muss ein Root‑Objekt enthalten, das ein `sets`‑Array beinhaltet. Jedes Element des Arrays stellt einen Datensatz dar und muss ein `fields`‑Array enthalten. Jedes Feld muss über einen `name`‑ und einen `value`‑String verfügen.

Die optionale Eigenschaft `version` muss `"1.0"` sein, und die optionale Eigenschaft `type` eines Feldes muss `"text"` sein. Eigenschaftsnamen sind case‑sensitive. Unbekannte Eigenschaften werden ignoriert.

JSON‑Daten werden als UTF‑8 gelesen, oder als UTF‑16, wenn die Daten mit einer Byte‑Order‑Mark (BOM) beginnen.

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

### **XML**

Die XML‑Datenquelle muss ein Root‑Element `template` besitzen, das das Element `sets` enthält. Jedes `set`‑Element enthält `field`‑Elemente, und jedes Feld muss `name`‑ und `value`‑Elemente enthalten.

Ein leeres `value`‑Element wird als leere Zeichenkette behandelt. Elementnamen sind case‑sensitive. Unbekannte Elemente und Kommentare werden ignoriert. Die Kodierung wird durch die XML‑Deklaration bestimmt. Dokumenttypdefinitionen (DTD) sind nicht zulässig.

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

### **CSV**

CSV‑Daten verwenden Semikolons als Werte­trennzeichen.

Die erste Zeile enthält Feldnamen und endet beim ersten leeren Feldnamen. Jede nachfolgende Zeile stellt einen Datensatz dar. Die Daten enden beim ersten leeren Zeilen.

Die folgenden Regeln gelten:

- Fehlende Werte am Ende einer Zeile werden als leere Zeichenketten behandelt.
- Werte, die über die definierten Feldnamen hinausgehen, werden ignoriert.
- Ein Wert, der ein Semikolon, Anführungszeichen oder einen Zeilenumbruch enthält, muss in Anführungszeichen gesetzt werden.
- Anführungszeichen innerhalb eines zitierten Werts müssen verdoppelt werden.
- Daten werden als UTF‑8 gelesen, oder als UTF‑16, wenn sie mit einer Byte‑Order‑Mark (BOM) beginnen.

Beispiel:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX‑Daten werden aus dem ersten Arbeitsblatt gelesen.

Das Arbeitsblatt folgt denselben Regeln wie CSV:

- Die erste Zeile enthält Feldnamen und endet bei der ersten leeren Zelle.
- Jede nachfolgende Zeile stellt einen Datensatz dar.
- Die Daten enden bei der ersten leeren Zeile.
- Leere Zellen werden als leere Zeichenketten behandelt.
- Numerische Werte werden mithilfe der Invariant‑Culture in Text konvertiert.

## **Erstellen einer einzelnen Präsentation**

Die Methode `MergeToSinglePresentation` erstellt eine Präsentation, die für jeden Datensatz eine Kopie der Vorlagenfolien enthält. Jede Kopie wird mit den entsprechenden Daten gefüllt.

Die Reihenfolge der Datensätze bestimmt die Reihenfolge der Foliengruppen in der resultierenden Präsentation.

### **Daten aus einer Datei zusammenführen**

Das folgende Beispiel lädt eine Vorlage und eine JSON‑Datendatei, erstellt eine einzelne Präsentation, die die Folien für alle Datensätze enthält, und speichert das Ergebnis.

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

Die Daten können auch aus einem Stream gelesen werden. Der Stream wird ab seiner aktuellen Position gelesen und von der Mail‑Merge‑Operation nicht geschlossen.

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

### **Erstellen einer Datenquelle im Code**

Sie können eine Datenquelle programmgesteuert mithilfe von `MailMergeDataSource` und `MailMergeDataSet` erstellen. Fügen Sie für jeden Datensatz ein DataSet hinzu und definieren Sie dessen Felder über die Methode `AddText`.

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

In diesem Beispiel werden die Vorlagenfolien zweimal wiederholt: einmal für das Notebook und einmal für das Tablet. Die Platzhalter werden mit den in jedem Datensatz definierten Werten gefüllt.

## **Erstellen mehrerer Präsentationen**

Wenn Sie für jeden Datensatz eine separate Präsentation benötigen, verwenden Sie die Methode `MergeToMultiplePresentations`.

Diese Methode verarbeitet die Datensätze nacheinander, erstellt eine Präsentation aus der Vorlage, füllt sie mit den aktuellen Daten und übergibt die resultierende Präsentation an einen Handler.

Der Handler wird einmal für jeden Datensatz in der ursprünglichen Datenreihenfolge aufgerufen.

### **Speichern jeder Präsentation**

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

Die Eigenschaft `args.Index` liefert den nullbasierten Index des aktuellen Datensatzes. Im Beispiel wird sie verwendet, um fortlaufende Dateinamen beginnend mit `product_1.pptx` zu erzeugen.

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

### **Verwenden von Datensatzwerten zum Benennen von Dateien**

Der Handler erhält sowohl die erzeugte Präsentation als auch Informationen über den Datensatz, der zur Erstellung verwendet wurde. Sie können die Datensatzwerte nutzen, um sinnvolle Dateinamen zu erstellen.

Zum Beispiel speichert der folgende Code jede Präsentation unter Verwendung des Produkttitels:

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

Die Eigenschaft `DataSet` gibt den Datensatz zurück, der zum Befüllen der aktuellen Präsentation verwendet wurde. Die Methode `GetText` holt den Wert eines angegebenen Feldes oder `null`, falls das Feld nicht vorhanden ist.

Damit können Sie Datwerte zum Benennen von Dateien, zur Organisation der Ausgabe oder zur zusätzlichen Verarbeitung im Handler verwenden.

## **Verarbeiten erzeugter Präsentationen**

`MergeToMultiplePresentations` verwendet das Delegat `MailMergedPresentationHandler`, um jede erzeugte Präsentation zu verarbeiten.

Der Handler erhält zwei Argumente:

- `presentation` — die aus der Vorlage erstellte Präsentation, die mit dem aktuellen Datensatz gefüllt ist.
- `args` — Informationen über die erzeugte Präsentation, einschließlich des Index des Datensatzes und des Datensatzes selbst.

Die erzeugte Präsentation gehört zum Mail‑Merge‑Vorgang und wird sofort nach Rückkehr des Handlers verworfen. Daher müssen Sie sie im Handler speichern oder benötigte Daten kopieren. Bewahren Sie nach Rückkehr des Handlers keine Referenz darauf auf und entsorgen Sie sie nicht manuell.

Der Handler wird im aufrufenden Thread ausgeführt, jeweils eine Präsentation nach der anderen, in der Reihenfolge der Datensätze. Es wird stets nur eine erzeugte Präsentation gleichzeitig im Speicher gehalten, wodurch dieser Ansatz für die Verarbeitung großer Datenquellen geeignet ist, ohne alle erzeugten Präsentationen gleichzeitig im Speicher zu behalten.

Wird im Handler eine Ausnahme ausgelöst, stoppt der Mail‑Merge‑Vorgang und die Ausnahme wird unverändert an den Aufrufer weitergegeben. Bereits verarbeitete Präsentationen bleiben unverändert, und die restlichen Datensätze werden nicht verarbeitet.

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

## **Arbeiten mit Mail‑Merge‑Daten**

Die Klasse `MailMergeDataSource` stellt eine geordnete Sammlung von Datensätzen dar. Sie kann verwendet werden, um Daten im Code zu erstellen, die Anzahl der Datensätze zu prüfen und einzelne Datensätze per Index zuzugreifen.

### **Abrufen der Anzahl von Datensätzen**

Die Eigenschaft `Count` liefert die Anzahl der Datensätze in der Quelle.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Zugriff auf einen Datensatz per Index**

Die Eigenschaft `Item(int)` ermöglicht den Zugriff auf einen Datensatz am angegebenen nullbasierten Index.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Dieses Beispiel ruft den Titel des zweiten Datensatzes ab.

### **Hinzufügen von Textfeldern**

Die Methode `AddText` fügt einem Datensatz ein benanntes Textfeld hinzu. Der Feldwert ersetzt alle passenden Platzhalter in der Vorlage.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Ein leerer Wert entfernt den entsprechenden Platzhalter aus dem Ergebnistext. Wird das Feld nicht zum Datensatz hinzugefügt, bleibt der Platzhalter unverändert.

### **Lesen von Textfeldern**

Die Methode `GetText` gibt den Wert eines Feldes anhand seines Namens zurück. Feldnamen sind case‑insensitive.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Existiert das Feld nicht oder ist der angegebene Feldname `null`, gibt `GetText` `null` zurück.

## **Zusammenfassung**

Mail Merge in Aspose.Slides für .NET bietet eine bequeme Methode, datengetriebene Präsentationen aus einer wiederverwendbaren Vorlage zu erzeugen.

- Füllen von Präsentationsvorlagen mit Werten aus Datenquellen.
- Erstellen einer einzelnen Präsentation, die wiederholte Vorlagenfolien für mehrere Datensätze enthält.
- Erstellen einer separaten Präsentation für jeden Datensatz.
- Lesen von Daten aus CSV-, XLSX-, JSON- und XML-Dateien oder Streams.
- Direktes Erstellen von Datenquellen im Code.
- Verarbeiten und Speichern erzeugter Präsentationen sequenziell mithilfe eines Handlers.

Durch die Kombination wiederverwendbarer Vorlagen mit strukturierten Daten können Sie die Erstellung einer großen Anzahl von Präsentationen automatisieren, während Design der Vorlage und Datenverarbeitungslogik getrennt bleiben.

## **Häufig gestellte Fragen**

**Kann ich denselben Platzhalter mehrmals in einer Vorlage verwenden?**

Ja. Jede Vorkommen eines Platzhalters mit einem passenden Feldnamen wird durch den entsprechenden Wert aus dem aktuellen Datensatz ersetzt.

**Sind Feldnamen case‑sensitive?**

Nein. Platzhalter‑ und Datenfeldnamen sind case‑insensitive. Zum Beispiel verweisen `{{title}}`, `{{Title}}` und `{{TITLE}}` auf dasselbe Feld.

**Was passiert, wenn ein Feld in einem Datensatz fehlt?**

Enthält der Datensatz kein durch einen Platzhalter referenziertes Feld, bleibt dieser Platzhalter in der erzeugten Präsentation unverändert.

**Was passiert, wenn ein Feld einen leeren Wert hat?**

Ein leerer Feldwert ersetzt den Platzhalter durch eine leere Zeichenkette. Der Platzhaltertext wird entfernt, sodass an seiner Stelle kein Text verbleibt.

**Kann ich die Formatierung eines Platzhalters beim Ersetzen beibehalten?**

Der ersetzte Text übernimmt die Formatierung des ersten Zeichens des Platzhalters. Wenden Sie die gewünschte Formatierung auf den Platzhaltertext in der Vorlage an, bevor Sie den Merge ausführen.

**Ersetzt Mail Merge Platzhalter auf Master‑Folien oder Layout‑Folien?**

Nein. Mail Merge ersetzt Platzhalter nur in unterstützten Inhalten von Präsentationsfolien, einschließlich Formen, gruppierten Formen, Tabellenzellen und Sprecher‑Notizen. Platzhalter auf Master‑ und Layout‑Folien werden nicht ersetzt.

**Wird die Vorlagenpräsentation während des Merges geändert?**

Nein. Die ursprüngliche Vorlage wird durch den Merge‑Vorgang nicht verändert. Sie können sie wiederverwenden, um Präsentationen aus derselben oder einer anderen Datenquelle zu erstellen.

**Kann ich für jeden Datensatz eine separate Präsentation erzeugen?**

Ja. Verwenden Sie `MergeToMultiplePresentations` und speichern Sie jede erzeugte Präsentation im Handler. Der Handler wird für jeden Datensatz sequenziell aufgerufen.

**Kann ich alle Datensätze zu einer Präsentation zusammenfassen?**

Ja. Verwenden Sie `MergeToSinglePresentation`. Sie erstellt eine einzelne Ausgabepäsentation, die für jeden Datensatz eine Kopie der Vorlagenfolien enthält, in der Reihenfolge der Datenquelle.

**Kann ich eine Datenquelle nutzen, ohne sie in einer Datei zu speichern?**

Ja. Sie können in Code ein `MailMergeDataSource` erstellen, Datensätze hinzufügen und Felder mit `AddText` befüllen. Das ist nützlich, wenn Ihre Daten bereits in Ihrer Anwendung verfügbar sind.

**Erkennt Mail Merge das Datenformat anhand der Dateierweiterung?**

Nein. Das Datenformat wird anhand des Inhalts erkannt, sodass eine unterstützte Datenquelle keine bestimmte Dateierweiterung benötigen muss.

**Kann ich Daten aus einem Stream lesen, der kein Seek‑Verhalten unterstützt?**

Ja. Mail Merge unterstützt Streams, die nicht seek‑fähig sind.

**Was passiert, wenn die Datenquelle leer ist oder keine Datensätze enthält?**

Die Datenquelle muss mindestens einen Datensatz enthalten. Stellen Sie sicher, dass sie mindestens einen Datensatz enthält, bevor Sie den Merge‑Vorgang starten.

**Was passiert, wenn die Datenquelle ein ungültiges Format hat?**

Wird der Inhalt nicht als eines der unterstützten Datenformate erkannt, wird `NotSupportedException` ausgelöst. Wird er erkannt, ist jedoch fehlerhaft, wird `InvalidDataException` ausgelöst. Die Fehlermeldung enthält Informationen über den Fehlerort.

**Kann ich die erzeugte Präsentation nach Rückkehr des Handlers benutzen?**

Die an den `MergeToMultiplePresentations`‑Handler übergebene Präsentation gehört zu Mail Merge und wird nach Rückgabe des Handlers verworfen. Speichern Sie sie oder kopieren Sie den benötigten Inhalt im Handler und behalten oder entsorgen Sie die Präsentation nicht selbst.

**Wird der Handler parallel aufgerufen?**

Nein. Erzeugte Präsentationen werden sequenziell im Aufrufer‑Thread verarbeitet. Es wird jeweils nur eine Präsentation gleichzeitig im Speicher gehalten, wodurch dieser Ansatz für die Verarbeitung großer Datenquellen geeignet ist, ohne alle erzeugten Präsentationen gleichzeitig im Speicher zu behalten.

**Was passiert, wenn im Handler eine Ausnahme auftritt?**

Der Merge‑Vorgang stoppt, und die Ausnahme wird unverändert an den Aufrufer weitergegeben. Bereits verarbeitete Präsentationen bleiben unverändert, und nachfolgende Datensätze werden nicht verarbeitet.

**Kann ich Feldwerte zum Erzeugen von Ausgabedateinamen verwenden?**

Ja. Der Handler liefert den aktuellen Datensatz über seine Argumente. Verwenden Sie `GetText`, um Felder zu holen und für jede erzeugte Präsentation einen Dateinamen zu erstellen. Stellen Sie sicher, dass die Werte für Dateinamen in Ihrer Zielumgebung gültig sind.