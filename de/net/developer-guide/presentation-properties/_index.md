---
title: Verwaltung von Präsentationseigenschaften in .NET
linktitle: Präsentationseigenschaften
type: docs
weight: 70
url: /de/net/presentation-properties/
keywords:
- PowerPoint-Eigenschaften
- Präsentationseigenschaften
- Dokumenteigenschaften
- integrierte Eigenschaften
- benutzerdefinierte Eigenschaften
- erweiterte Eigenschaften
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
description: "Verwalten Sie Präsentationseigenschaften in Aspose.Slides für .NET und optimieren Sie Suche, Branding und Workflows in Ihren PowerPoint- und OpenDocument-Dateien."
---
## **Einführung**

Aspose.Slides für .NET unterstützt zwei Arten von Dokumenteigenschaften: **Built-in** und **Custom**. Beide Eigenschaftstypen können problemlos über die Aspose.Slides für .NET API zugegriffen und verwaltet werden.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über das [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/) Interface. Eine Instanz dieses Interfaces wird von [IPresentation.DocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/documentproperties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}
Bitte beachten Sie, dass die Felder **Application** und **Producer** nicht geändert werden können, da diese Felder stets "Aspose Ltd." und "Aspose.Slides for .NET x.x.x" anzeigen.
{{% /alert %}} 

## **Verwalten von Präsentationseigenschaften**

Microsoft PowerPoint bietet eine Funktion zum Hinzufügen von Eigenschaften zu Präsentationsdateien. Diese Dokumenteigenschaften ermöglichen es, nützliche Informationen zusammen mit den Dateien zu speichern. Es gibt zwei Arten von Dokumenteigenschaften:

- Systemdefinierte (built-in) Eigenschaften
- Benutzerdefinierte (custom) Eigenschaften

**Built-in** Eigenschaften enthalten allgemeine Informationen zum Dokument, wie den Dokumenttitel, den Namen des Autors, Dokumentstatistiken und mehr.

**Custom** Eigenschaften werden von Benutzern als **Name/Value**-Paare definiert, wobei sowohl Name als auch Wert vom Benutzer angegeben werden.

Mit Aspose.Slides für .NET können Entwickler sowohl built-in als auch custom Eigenschaften zu‑ und ändern.

Microsoft PowerPoint ermöglicht es Benutzern, Dokumenteigenschaften zu verwalten, indem sie auf das Office‑Symbol klicken und dann **Datei → Info → Eigenschaften** auswählen. Nach dem Auswählen von **Erweiterte Eigenschaften** erscheint ein Dialog, in dem Sie alle Dokumenteigenschaften der Präsentationsdatei verwalten können.

Im Dialog **Eigenschaften** gibt es mehrere Registerkarten, wie **Allgemein**, **Zusammenfassung**, **Statistiken**, **Inhalt** und **Custom**. Jede Registerkarte bietet Optionen zum Konfigurieren bestimmter Informationstypen, die sich auf die PowerPoint‑Datei beziehen. Die Registerkarte **Custom** wird verwendet, um benutzerdefinierte Eigenschaften zu verwalten.

## **Öffentliche Eigenschaften einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation mit [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) auf `false` verschlüsselt wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) auf `true` setzen und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

`OnlyLoadDocumentProperties` steuert, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die komplette Präsentation geladen.

Das folgende Beispiel überprüft den Lademodus über [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) und liest anschließend built-in Eigenschaften über [IPresentation.DocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Masterfolien, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets `IsOnlyDocumentPropertiesLoaded` prüfen, bevor sie eine Operation ausführen, die das komplette Präsentationsobjektmodell erfordert.

{{% alert color="warning" title="Security" %}}
Öffentliche Metadaten können Autorennamen, Titel, Themen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokumentenverwaltungssysteme eine spezifische Anforderung haben, ohne Passwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine mit `OnlyLoadDocumentProperties` geladene Präsentation zum Lesen öffentlicher Metadaten vorgesehen. Aspose.Slides kann geänderte Eigenschaften dieses rein metadatenbasierten Objekts nicht speichern, da die öffentlichen Eigenschaften konsistent mit den entsprechenden Daten in der verschlüsselten Präsentation bleiben müssen. Das Aktualisieren erfordert daher das korrekte Öffnungspasswort und einen kompletten Ladevorgang.

Das folgende Beispiel öffnet die Präsentation mit [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/), aktualisiert öffentliche built-in Eigenschaften und speichert das Ergebnis. Anschließend wird [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/isencrypted/) verwendet, um zu überprüfen, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Passwort erneut geöffnet, um die neuen Werte zu verifizieren:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Wenn einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet ist, muss sie die öffentlichen Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf built-in Eigenschaften**

Diese Eigenschaften, die über das [IDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/) Interface bereitgestellt werden, umfassen: **Creator** (Autor), **Description**, **Keywords**, **Created** (Erstellungsdatum), **Modified** (Änderungsdatum), **Printed** (Datum des letzten Drucks), **LastModifiedBy**, **SharedDoc** (gibt an, ob das Dokument zwischen verschiedenen Produzenten geteilt wird), **PresentationFormat**, **Subject**, **Title** und weitere.

```cs
using Aspose.Slides;

// Instanzieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Holen Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Zeigen Sie die integrierten Eigenschaften an.
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

Das Ändern der built-in Eigenschaften von Präsentationsdateien ist genauso einfach wie der Zugriff darauf. Sie können einfach einem gewünschten Property einen Zeichenkettenwert zuweisen, und der Wert wird aktualisiert. Im folgenden Beispiel zeigen wir, wie built-in Dokumenteigenschaften einer Präsentationsdatei geändert werden.

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

Benutzerdefinierte Präsentationseigenschaften ermöglichen es Entwicklern, zusätzliche Metadaten oder spezifische Informationen in einer Präsentationsdatei zu speichern. Aspose.Slides erleichtert das programmgesteuerte Erstellen und Verwalten dieser benutzerdefinierten Eigenschaften. Die folgenden Beispiele zeigen, wie benutzerdefinierte Eigenschaften zu Ihren Präsentationen hinzugefügt werden.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse.
using Presentation presentation = new Presentation();

// Holen Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Fügen Sie benutzerdefinierte Eigenschaften hinzu.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Speichern Sie die Präsentation in einer Datei.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Aspose.Slides ermöglicht Entwicklern zudem den Zugriff auf vorhandene benutzerdefinierte Eigenschaften und deren unkompliziertes Ändern. Diese Funktionalität unterstützt die Pflege genauer Metadaten und ermöglicht dynamische Aktualisierungen basierend auf Benutzereingaben oder Geschäftslogik. Die nachstehenden Beispiele zeigen, wie benutzerdefinierte Eigenschaftswerte innerhalb einer Präsentation abgerufen und aktualisiert werden.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Holen Sie eine Referenz auf das Objekt vom Typ IDocumentProperties, das mit der Präsentation verknüpft ist.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Greifen Sie auf die benutzerdefinierten Eigenschaften zu und ändern Sie sie.
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

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/de/metadata) aus, um zu sehen, wie Sie mit Dokumenteigenschaften über die Aspose.Slides‑API arbeiten:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/de/metadata)

## **FAQ**

**Wie kann ich eine built-in Eigenschaft aus einer Präsentation entfernen?**

Built-in Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern von der jeweiligen Eigenschaft erlaubt, auf leer setzen.

**Was passiert, wenn ich eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufüge?**

Wenn Sie eine bereits vorhandene benutzerdefinierte Eigenschaft hinzufügen, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die Präsentation vollständig zu laden?**

Ja. Verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/presentationfactory/getpresentationinfo/) und anschließend [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/readdocumentproperties/), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Instanz zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/net/examine-presentation/) für ein vollständiges Reporting‑Beispiel und formatspezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungspasswort lesen?**

Ja. Die Präsentation muss mit `EncryptDocumentProperties` auf `false` verschlüsselt sein und mit `OnlyLoadDocumentProperties` auf `true` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Nur‑Dokument‑Eigenschaften‑Modus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das Laden der gesamten Präsentation mit dem korrekten Öffnungspasswort.