---
title: Verwalten von PowerPoint-Präsentationseigenschaften in C#
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/net/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Standard-Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
- Zugriff auf Eigenschaften
- Eigenschaften ändern
- Eigenschaften verwalten
- Dokument-Metadaten
- Metadaten bearbeiten
- Korrektursprache
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Erfahren Sie, wie Sie PowerPoint-Dokumenteigenschaften mit Aspose.Slides für .NET in C# einfach verwalten, lesen und bearbeiten können. Steigern Sie die Produktivität und automatisieren Sie Ihren Arbeitsablauf!"
---

## **Übersicht**

Aspose.Slides für .NET unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigentumsarten können problemlos über die Aspose.Slides für .NET API zugegriffen und verwaltet werden.

Um Dokumenteigenschaften zu handhaben, stellt Aspose.Slides die [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/)-Schnittstelle bereit, die über die [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/documentproperties/)-Eigenschaft zugänglich ist. Entwickler können das [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/)-Interface des `Presentation`‑Objekts nutzen, um Präsentationseigenschaften nahtlos zu lesen, zu ändern und zu verwalten, wie in den nachstehenden Beispielen gezeigt.

{{% alert color="primary" %}} 
Bitte beachten Sie, dass die **Application**‑ und **Producer**‑Felder nicht geändert werden können, da diese Felder stets „Aspose Ltd.“ und „Aspose.Slides for .NET x.x.x“ anzeigen.
{{% /alert %}} 

## **Präsentationseigenschaften verwalten**

Microsoft PowerPoint bietet eine Funktion zum Hinzufügen von Eigenschaften zu Präsentationsdateien. Diese Dokumenteigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dateien. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (built-in) Eigenschaften
- Benutzerdefinierte (custom) Eigenschaften

**Built-in**‑Eigenschaften enthalten allgemeine Informationen über das Dokument, wie den Dokumenttitel, den Namen des Autors, Dokumentstatistiken und mehr.

**Custom**‑Eigenschaften werden von Benutzern als **Name/Wert**‑Paare definiert, wobei sowohl der Name als auch der Wert vom Benutzer festgelegt werden.

Mit Aspose.Slides für .NET können Entwickler sowohl built-in‑ als auch custom‑Eigenschaften zugreifen und ändern.

Microsoft PowerPoint ermöglicht Benutzern die Verwaltung von Dokumenteigenschaften, indem sie das Office‑Symbol anklicken und dann **Datei → Info → Eigenschaften** auswählen. Nach dem Wahl von **Erweiterte Eigenschaften** erscheint ein Dialog, in dem alle Dokumenteigenschaften der Präsentationsdatei verwaltet werden können.

Im Dialog **Eigenschaften** gibt es mehrere Registerkarten, wie **Allgemein**, **Zusammenfassung**, **Statistik**, **Inhalte** und **Benutzerdefiniert**. Jede Registerkarte bietet Optionen zur Konfiguration bestimmter Informationstypen, die sich auf die PowerPoint‑Datei beziehen. Die Registerkarte **Benutzerdefiniert** wird verwendet, um benutzerdefinierte Eigenschaften zu verwalten.

## **Zugriff auf Built-in‑Eigenschaften**

Diese Eigenschaften, wie sie von der [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/)-Schnittstelle bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **SharedDoc** (gibt an, ob das Dokument zwischen verschiedenen Produzenten geteilt wird), **PresentationFormat**, **Subject**, **Title** und weitere.
```cs
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


## **Built-in‑Eigenschaften ändern**

Das Ändern der built-in‑Eigenschaften von Präsentationsdateien ist genauso einfach wie ihr Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen, und der Wert wird aktualisiert. Im nachstehenden Beispiel zeigen wir, wie die built-in‑Dokumenteigenschaften einer Präsentationsdatei geändert werden können.
```cs
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Erhalten Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
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

Benutzerdefinierte Präsentationseigenschaften ermöglichen Entwicklern, zusätzliche Metadaten oder spezifische Informationen innerhalb einer Präsentationsdatei zu speichern. Aspose.Slides erleichtert das programmgesteuerte Erstellen und Verwalten dieser benutzerdefinierten Eigenschaften. Die folgenden Beispiele demonstrieren, wie benutzerdefinierte Eigenschaften zu Ihren Präsentationen hinzugefügt werden.
```cs
// Instanziieren Sie die Presentation-Klasse.
using Presentation presentation = new Presentation();

// Erhalten Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Benutzerdefinierte Eigenschaften hinzufügen.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Speichern Sie die Präsentation in einer Datei.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```


## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides ermöglicht es Entwicklern auch, vorhandene benutzerdefinierte Eigenschaften abzurufen und deren Werte einfach zu ändern. Diese Funktionalität unterstützt die Pflege genauer Metadaten und ermöglicht dynamische Aktualisierungen basierend auf Benutzereingaben oder Geschäftslogik. Die nachstehenden Beispiele illustrieren, wie benutzerdefinierte Eigenschaftswerte innerhalb einer Präsentation abgerufen und aktualisiert werden können.
```cs
// Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Zugriff auf und Änderung der benutzerdefinierten Eigenschaften.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Anzeigen des Namens und Wertes der benutzerdefinierten Eigenschaft.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Ändern Sie den Wert der benutzerdefinierten Eigenschaft.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Speichern Sie die Präsentation in einer Datei.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```


## **Live‑Beispiel**

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie Sie mit Dokumenteigenschaften mithilfe der Aspose.Slides‑API arbeiten können:

[![Ansicht & Bearbeiten PowerPoint Metadaten](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Wie kann ich eine built-in‑Eigenschaft aus einer Präsentation entfernen?**

Built-in‑Eigenschaften sind ein integraler Teil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft dies zulässt, auf einen leeren Wert setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wenn Sie eine benutzerdefinierte Eigenschaft hinzufügen, die bereits existiert, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft vorher nicht entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich Präsentationseigenschaften abrufen, ohne die Präsentation vollständig zu laden?**

Ja, Sie können Präsentationseigenschaften abrufen, ohne die Präsentation vollständig zu laden, indem Sie die `GetPresentationInfo`‑Methode der [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/)-Klasse verwenden. Anschließend nutzen Sie die `ReadDocumentProperties`‑Methode der [IPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/)-Schnittstelle, um die Eigenschaften effizient zu lesen, Speicher zu sparen und die Leistung zu verbessern.