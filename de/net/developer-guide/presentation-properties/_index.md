---
title: Präsentationseigenschaften in .NET verwalten
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/net/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- Standard-Eigenschaften
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
description: "Steuern Sie Präsentationseigenschaften in Aspose.Slides für .NET und optimieren Sie Suche, Branding und Arbeitsabläufe in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einleitung**

Aspose.Slides für .NET unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können einfach über die Aspose.Slides für .NET API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Präsentationsdokumenteigenschaften über das Interface [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/) . Eine Instanz dieses Interface wird über die Eigenschaft [Presentation.DocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/documentproperties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Bitte beachten Sie, dass die Felder **Application** und **Producer** nicht geändert werden können, da diese Felder immer "Aspose Ltd." und "Aspose.Slides for .NET x.x.x" anzeigen.
{{% /alert %}} 

## **Verwalten von Präsentationseigenschaften**

Microsoft PowerPoint bietet eine Funktion zum Hinzufügen von Eigenschaften zu Präsentationsdateien. Diese Dokumenteigenschaften ermöglichen das Speichern nützlicher Informationen zusammen mit den Dateien. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (built-in) Eigenschaften
- Benutzerdefinierte (custom) Eigenschaften

**Built-in** Eigenschaften enthalten allgemeine Informationen über das Dokument, wie den Dokumenttitel, den Namen des Autors, Dokumentstatistiken und mehr.

**Custom** Eigenschaften werden von Benutzern als **Name/Wert**-Paare definiert, wobei sowohl Name als auch Wert vom Benutzer festgelegt werden.

Mit Aspose.Slides für .NET können Entwickler sowohl built-in als auch custom Eigenschaften zugreifen und diese ändern.

Microsoft PowerPoint ermöglicht es Benutzern, Dokumenteigenschaften zu verwalten, indem sie das Office‑Symbol anklicken und dann **Datei → Info → Eigenschaften** auswählen. Nach dem Auswählen von **Erweiterte Eigenschaften** erscheint ein Dialog, in dem Sie alle Dokumenteigenschaften der Präsentationsdatei verwalten können.

Im Dialog **Eigenschaften** gibt es mehrere Registerkarten, z. B. **Allgemein**, **Zusammenfassung**, **Statistik**, **Inhalt** und **Custom**.  
Jede Registerkarte bietet Optionen zur Konfiguration spezifischer Informationsarten, die sich auf die PowerPoint‑Datei beziehen. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften zu verwalten.

## **Zugriff auf Built-in Eigenschaften**

Diese Eigenschaften, die über das Interface [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/) bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **SharedDoc** (zeigt an, ob das Dokument zwischen verschiedenen Erstellern geteilt wird), **PresentationFormat**, **Subject**, **Title** und weitere.

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

## **Built-in Eigenschaften ändern**

Das Ändern der built-in Eigenschaften von Präsentationsdateien ist genauso einfach wie deren Zugriff. Sie können einfach einen Zeichenkettenwert einer gewünschten Eigenschaft zuweisen, und der Wert der Eigenschaft wird aktualisiert. Im nachstehenden Beispiel zeigen wir, wie man die built-in Dokumenteigenschaften einer Präsentationsdatei ändert.

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

Benutzerdefinierte Präsentationseigenschaften ermöglichen es Entwicklern, zusätzliche Metadaten oder spezifische Informationen in einer Präsentationsdatei zu speichern. Aspose.Slides erleichtert das programmgesteuerte Erstellen und Verwalten dieser benutzerdefinierten Eigenschaften. Die folgenden Beispiele zeigen, wie man benutzerdefinierte Eigenschaften zu Ihren Präsentationen hinzufügt.

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

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides ermöglicht es Entwicklern zudem, vorhandene benutzerdefinierte Eigenschaften abzurufen und deren Werte einfach zu ändern. Diese Funktion unterstützt die Pflege genauer Metadaten und ermöglicht dynamische Aktualisierungen basierend auf Benutzereingaben oder Geschäftslogik. Die nachstehenden Beispiele zeigen, wie man benutzerdefinierte Eigenschaftswerte in einer Präsentation abruft und aktualisiert.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Holen Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Anzeige des Namens und Werts der benutzerdefinierten Eigenschaft.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Wert der benutzerdefinierten Eigenschaft ändern.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Speichern Sie die Präsentation in einer Datei.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides‑API arbeitet:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine built-in Eigenschaft aus einer Präsentation entfernen?**  
Built-in Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft es zulässt, sie auf einen leeren Wert setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**  
Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert der Eigenschaft automatisch aktualisiert.

**Kann ich Präsentationseigenschaften zugreifen, ohne die gesamte Präsentation zu laden?**  
Ja. Verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/) und anschließend [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Instanz zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/net/examine-presentation/) für ein vollständiges Bericht-Beispiel und formatbezogene Einschränkungen.