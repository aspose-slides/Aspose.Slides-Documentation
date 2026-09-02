---
title: Tags und benutzerdefinierte Daten in Präsentationen in .NET verwalten
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/net/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- benutzerdefiniertes XML
- benutzerdefinierter XML-Teil
- XML-Metadaten
- ItemId
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint-Präsentationen mit Aspose.Slides für .NET verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML-Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑String‑Paare, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads speichern können.

Aspose.Slides stellt APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen von benutzerdefinierten XML‑Teilen auf Präsentations‑, Folien‑ und Shape‑Ebene bereit. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokument‑Management‑Kennungen, Workflow‑Status, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten in einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Dateien mit der Erweiterung `.pptx` — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und Beziehungen, die zum Speichern von Präsentationsinhalten und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Ein Folien‑Teil enthält beispielsweise den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen besitzen, definiert durch ISO/IEC 29500.

Benutzerdefinierte Daten können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/net/aspose.slides/itagcollection)) oder benutzerdefinierte XML‑Teile ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection)) gespeichert werden. Beide sind über das[`ICustomData`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomdata/)‑Interface verfügbar.

{{% alert color="primary" %}}
Tags speichern einfache String‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder einem Shape zugeordnet werden.
{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Eigenschaft[`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomdata/customxmlparts/) gibt die Sammlung benutzerdefinierter XML‑Teile zurück, die einem bestimmten Präsentationsobjekt zugeordnet sind. Zum Beispiel:

- `presentation.CustomData.CustomXmlParts` enthält benutzerdefinierte XML‑Teile, die der Präsentation selbst zugeordnet sind.
- `slide.CustomData.CustomXmlParts` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Folie zugeordnet sind.
- `shape.CustomData.CustomXmlParts` enthält benutzerdefinierte XML‑Teile, die einem bestimmten Shape zugeordnet sind.

Verwenden Sie[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/allcustomxmlparts/), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen möchten, unabhängig davon, wo sie zugeordnet sind.

### **Einen benutzerdefinierten XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie[`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection/add/), um XML‑Daten zu einer benutzerdefinierten XML‑Teilsammlung hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur Präsentations‑Level‑Sammlung benutzerdefinierter Daten hinzu:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add weist automatisch eine Kennung zu. Setzen Sie eine bestimmte GUID nur bei Bedarf.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Die `Add`‑Methode kann auch XML als Byte‑Array oder Stream akzeptieren, was nützlich ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Einen benutzerdefinierten XML‑Teil zu einer Folie oder einem Shape hinzufügen**

Benutzerdefinierte XML‑Daten können einem bestimmten Folien‑ oder Shape‑Objekt zugeordnet werden, anstatt der gesamten Präsentation. Das ist nützlich, wenn Metadaten nur ein Objekt beschreiben, z. B. einen Vorlagenschlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einen benutzerdefinierten XML‑Teil zu einer Folie und einen weiteren zu einem Shape hinzu:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche`CustomData.CustomXmlParts`‑Sammlung des Objekts die Beziehung zu diesem Teil enthält. Daten auf Präsentationsebene eignen sich für dokumentweite Metadaten, Daten auf Folienebene für Informationen, die zu einer bestimmten Folie gehören, und Daten auf Shape‑Ebene für Metadaten, die an ein einzelnes Shape gebunden sind.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/allcustomxmlparts/), um alle benutzerdefinierten XML‑Teile aus einer Präsentation abzurufen. Jeder[`ICustomXmlPart`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/) stellt seine Kennung, den XML‑Inhalt und die zugehörigen Namespace‑Schemas bereit.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und ihre Namespace‑Schemas auf:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/namespaceschemas/) gibt die XML‑Schemas zurück, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen nützlich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie[`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/xmlasstring/), um mit XML als UTF‑8‑String zu arbeiten, oder[`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/xmldata/), um mit den rohen XML‑Bytes zu arbeiten. Beide Eigenschaften können gelesen und aktualisiert werden.

Die Eigenschaft[`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/itemid/) enthält die GUID, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument identifiziert. Sie kann ebenfalls geändert werden, wenn eine Integration eine neue Kennung benötigt.

Das folgende Beispiel aktualisiert den XML‑Inhalt und die Kennung:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Lese das aktuelle XML als Text.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Aktualisiere das XML als UTF-8-String.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData liefert denselben XML-Inhalt als rohe Bytes.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Ersetze die Kennung, wenn die Integration sie benötigt.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Beim Zuweisen von `XmlAsString` oder `XmlData` muss gültiges, nicht leeres XML bereitgestellt werden. Verwenden Sie die eine oder andere Darstellung, je nachdem, ob die Anwendung hauptsächlich mit Strings oder Byte‑Daten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/remove/) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection/remove/) entfernt einen bestimmten Teil aus einer benutzerdefinierten XML‑Teilsammlung.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection/removeat/) entfernt den Teil an einem angegebenen Sammlungs‑Index.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection/clear/) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen präsentations‑level benutzerdefinierten XML‑Teil per Referenz:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Wenn Sie bereits ein `ICustomXmlPart` besitzen und diesen Teil aus der Präsentation entfernen möchten, anstatt eine bestimmte Sammlung anzusprechen, rufen Sie `customXmlPart.Remove()` auf.

Sie können ein Element auch nach Index entfernen:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Alle benutzerdefinierten XML‑Teile einer Sammlung leeren**

Verwenden Sie `Clear`, wenn alle benutzerdefinierten XML‑Teile, die einem bestimmten Präsentationsobjekt zugeordnet sind, entfernt werden sollen.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` wirkt nur auf die ausgewählte Sammlung. Das Leeren der Sammlung einer Folie etwa entfernt nicht die Sammlungen auf Präsentations‑ oder Shape‑Ebene.

Um jeden benutzerdefinierten XML‑Teil in der Präsentation zu entfernen, iterieren Sie über `AllCustomXmlParts` und entfernen jeden Teil:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Verknüpfte oder gemeinsam genutzte benutzerdefinierte XML‑Teile behandeln**

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine vorhandene Datei Beziehungen von mehreren Folien oder Shapes zum selben zugrunde liegenden benutzerdefinierten XML‑Teil enthalten.

Ein gemeinsam genutzter Teil sollte als ein Datenobjekt mit mehreren Referenzen behandelt werden:

- Das Aktualisieren von `XmlAsString`, `XmlData` oder `ItemId` ändert den zugrunde liegenden benutzerdefinierten XML‑Teil, sodass die Änderung überall dort wirksam wird, wo dieser Teil referenziert wird.
- `ItemId` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil beim Prüfen von Sammlungen auf Objektebene zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten`CustomXmlParts`‑Sammlung entfernt ihn nur aus dieser Sammlung. Verwenden Sie `ICustomXmlPart.Remove()`, wenn der Teil selbst aus der Präsentation entfernt werden soll.
- Vor dem Löschen oder Ersetzen eines gemeinsam genutzten Teils sollten Sie die Sammlungen auf Objektebene prüfen, um festzustellen, ob andere Folien oder Shapes ihn noch referenzieren.

Die `Add`‑Überladungen erstellen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen bestehenden`ICustomXmlPart`. Daher begegnet man gemeinsam genutzten Beziehungen am häufigsten beim Laden von Präsentationen, die bereits solche Beziehungen enthalten.

Das folgende Beispiel prüft Präsentations‑, Folien‑ und Shape‑Sammlungen nach `ItemId` und meldet Teile, die von mehr als einer Stelle referenziert werden:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Diese Art von Prüfung ist vor dem Ändern oder Löschen von benutzerdefinierten XML‑Daten in von externen Systemen erstellten Präsentationen nützlich, da derselbe Metadaten‑Teil an mehreren Beziehungen teilnehmen kann.

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Eigenschaft `IDocumentProperties.Keywords`. Dieser Beispielcode zeigt, wie man mit Aspose.Slides für .NET den Wert eines Tags einer[Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) abruft:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft, z. B. `MyTag`;
- dem Wert der benutzerdefinierten Eigenschaft, z. B. `My Tag Value`.

Wenn Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie dafür Tags hinzufügen. Beispielsweise können Sie für Präsentationen aus nordamerikanischen Ländern ein Tag „North America“ erstellen und das entsprechende Land als Wert zuweisen.

Dieser Beispielcode zeigt, wie man ein Tag zu einer[Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) mit Aspose.Slides für .NET hinzufügt:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tags können auch für eine[Slide](https://reference.aspose.com/slides/de/net/aspose.slides/slide) gesetzt werden:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Oder für ein einzelnes[Shape](https://reference.aspose.com/slides/de/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Einschränkungen**

Durch die`CustomData.Tags`‑Sammlung hinzugefügte Tags werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation nach PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Identifier nicht aus dem getaggten PDF abgerufen werden.

**Workaround**: Sie können einen benutzerdefinierten Identifier im**Alt‑Text** des Objekts speichern (z. B. `shape.AlternativeText = "MyId"`). Nach dem Export nach PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder eines Shapes in einem Vorgang entfernen?**

Ja. Die[Tag‑Sammlung](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/) unterstützt eine[Clear](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie[Remove(name)](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/remove/) auf der[TagCollection](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie[GetNamesOfTags](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/getnamesoftags/) auf der[Tag‑Sammlung](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie[`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/allcustomxmlparts/), um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Sollte ich `XmlAsString` oder `XmlData` zum Aktualisieren eines benutzerdefinierten XML‑Teils verwenden?**

Verwenden Sie `XmlAsString`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `XmlData`, wenn das XML bereits als Byte‑Array vorliegt oder die Verarbeitung binärorientiert bequemer ist. Beide Eigenschaften repräsentieren den XML‑Inhalt desselben benutzerdefinierten XML‑Teils.