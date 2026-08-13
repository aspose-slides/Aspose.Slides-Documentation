---
title: Verwalten von Präsentationseigenschaften in .NET
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/net/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Integrierte Eigenschaften
- Benutzerdefinierte Eigenschaften
- Erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokumentmetadaten
- Metadaten bearbeiten
- Korrektursprache
- Standardsprache
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Beherrschen Sie die Präsentationseigenschaften in Aspose.Slides für .NET und optimieren Sie Suche, Markenbildung und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides for .NET unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides for .NET API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit den Dokumenteigenschaften von Präsentationen über das Interface [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/) . Eine Instanz dieses Interfaces wird über die Eigenschaft [Presentation.DocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/documentproperties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" %}} 

Bitte beachten Sie, dass die Felder **Application** und **Producer** nicht geändert werden können, da diese Felder stets "Aspose Ltd." und "Aspose.Slides for .NET x.x.x" anzeigen.

{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet die Möglichkeit, Eigenschaften zu Präsentationsdateien hinzuzufügen. Diese Dokumenteigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dateien. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (built-in) Eigenschaften
- Benutzerdefinierte Eigenschaften

**Built-in** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie den Dokumenttitel, den Namen des Autors, Dokumentstatistiken und mehr.

**Custom** Eigenschaften werden vom Benutzer als **Name/Wert**‑Paare definiert, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden.

Mit Aspose.Slides for .NET können Entwickler sowohl integrierte als auch benutzerdefinierte Eigenschaften abrufen und ändern.

Microsoft PowerPoint ermöglicht es Benutzern, Dokumenteigenschaften zu verwalten, indem sie auf das Office‑Symbol klicken und dann **Datei → Info → Eigenschaften** wählen. Nach Auswahl von **Erweiterte Eigenschaften** erscheint ein Dialog, in dem Sie alle Dokumenteigenschaften der Präsentationsdatei verwalten können.

In dem Dialog **Properties** gibt es mehrere Registerkarten, wie **General**, **Summary**, **Statistics**, **Contents** und **Custom**. Jede Registerkarte bietet Optionen zur Konfiguration bestimmter Arten von Informationen, die sich auf die PowerPoint‑Datei beziehen. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften zu verwalten.

## **Auf integrierte Eigenschaften zugreifen**

Diese Eigenschaften, die über das Interface [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/) bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Letztes Druckdatum), **LastModifiedBy**, **SharedDoc** (zeigt an, ob das Dokument zwischen verschiedenen Produzenten geteilt wird), **PresentationFormat**, **Subject**, **Title** und weitere.

```cs
using Aspose.Slides;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Integrierte Eigenschaften ändern**

Das Ändern integrierter Eigenschaften von Präsentationsdateien ist genauso einfach wie das Abrufen. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen, und der Wert wird aktualisiert. Im nachfolgenden Beispiel zeigen wir, wie man die integrierten Dokumenteigenschaften einer Präsentationsdatei ändert.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Holen Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Setzen Sie die integrierten Eigenschaften.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Speichern Sie die Präsentation in einer Datei.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Benutzerdefinierte Präsentationseigenschaften ermöglichen es Entwicklern, zusätzliche Metadaten oder spezifische Informationen in einer Präsentationsdatei zu speichern. Aspose.Slides erleichtert das programmgesteuerte Erstellen und Verwalten dieser benutzerdefinierten Eigenschaften. Die folgenden Beispiele zeigen, wie Sie benutzerdefinierte Eigenschaften zu Ihren Präsentationen hinzufügen.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse.
using Presentation presentation = new Presentation();

// Holen Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Benutzerdefinierte Eigenschaften hinzufügen.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Speichern Sie die Präsentation in einer Datei.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Benutzerdefinierte Eigenschaften abrufen und ändern**

Aspose.Slides ermöglicht Entwicklern zudem, vorhandene benutzerdefinierte Eigenschaften abzurufen und deren Werte einfach zu ändern. Diese Funktionalität hilft, genaue Metadaten zu pflegen und unterstützt dynamische Aktualisierungen basierend auf Benutzereingaben oder Geschäftslogik. Die Beispiele unten zeigen, wie man benutzerdefinierte Eigenschaftswerte innerhalb einer Präsentation abruft und aktualisiert.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Holen Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Zugriff auf und Änderung der benutzerdefinierten Eigenschaften.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Zeigen Sie den Namen und den Wert der benutzerdefinierten Eigenschaft an.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Ändern Sie den Wert der benutzerdefinierten Eigenschaft.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Speichern Sie die Präsentation in einer Datei.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live‑Beispiel**

Probieren Sie die [**Ansicht & Bearbeitung von PowerPoint-Metadaten**](https://products.aspose.app/slides/de/metadata)‑Web‑App aus, um zu sehen, wie Sie mit Dokumenteigenschaften mithilfe der Aspose.Slides‑API arbeiten können:

[![Ansicht & Bearbeitung von PowerPoint-Metadaten](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## ***FAQ**

### Wie kann ich eine integrierte Eigenschaft aus einer Präsentation entfernen?

Integrierte Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, falls von der jeweiligen Eigenschaft erlaubt, auf leer setzen.

### Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

### Kann ich Präsentationseigenschaften abrufen, ohne die Präsentation vollständig zu laden?

Ja, Sie können Präsentationseigenschaften abrufen, ohne die gesamte Präsentation zu laden, indem Sie die Methode `GetPresentationInfo` der Klasse [PresentationFactory](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/) verwenden. Anschließend nutzen Sie die Methode `ReadDocumentProperties` des Interfaces [IPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/), um die Eigenschaften effizient zu lesen, Speicher zu sparen und die Leistung zu verbessern.