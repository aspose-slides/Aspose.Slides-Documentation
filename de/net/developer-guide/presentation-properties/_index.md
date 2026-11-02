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
- Eingebaute Eigenschaften
- Benutzerdefinierte Eigenschaften
- Erweiterte Eigenschaften
- Eigenschaften verwalten
- Eigenschaften ändern
- Dokument-Metadaten
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

Aspose.Slides für .NET unterstützt **eingebaute** und **benutzerdefinierte** Dokumenteigenschaften. Verwenden Sie diese Eigenschaften, um Metadaten der Präsentation zu lesen und zu aktualisieren, z. B. Autor, Titel und benutzerdefinierte Werte.

Aspose.Slides ermöglicht die Arbeit mit Dokumenteigenschaften von Präsentationen über das [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/)‑Interface. Eine Instanz dieses Interfaces wird von [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) zurückgegeben. Die folgenden Beispiele zeigen, wie man diese Eigenschaften liest, ändert und verwaltet.

{{% alert color="info" title="Note" %}}

Aspose.Slides verwaltet die Anwendungs‑ und Produzent‑Metadaten beim Speichern von Präsentationen; diese Felder geben die Software an, die die Ausgabe erstellt hat.

{{% /alert %}}

## **Verwalten von Präsentationseigenschaften**

Dokumenteigenschaften speichern beschreibende Informationen zusammen mit dem Präsentationsinhalt. Sie fallen in zwei Kategorien:

- **Eingebaute Eigenschaften** enthalten Standard‑Metadaten wie Titel, Autor und Dokumentstatistiken.
- **Benutzerdefinierte Eigenschaften** speichern vom Benutzer definierte Name‑/Wert‑Paare.

Aspose.Slides für .NET bietet Zugriff auf beide Kategorien. In PowerPoint wählen Sie **Datei → Informationen → Eigenschaften → Erweiterte Eigenschaften**, um die Dokument‑Metadaten zu inspizieren. Der Dialog gruppiert Informationen in Registerkarten wie **Zusammenfassung**, **Statistiken**, **Inhalte** und **Benutzerdefiniert**. Verwenden Sie die Registerkarte **Benutzerdefiniert**, um benutzerdefinierte Eigenschaften zu verwalten.

## **Öffentliche Eigenschaften aus einer verschlüsselten Präsentation lesen**

Ein Öffnungspasswort schützt normalerweise sowohl den Präsentationsinhalt als auch die Dokumenteigenschaften. Wenn eine Präsentation mit [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) auf `false` verschlüsselt wird, bleiben ihre Dokumenteigenschaften öffentlich. Eine Anwendung kann dann [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) auf `true` setzen und die öffentlichen Metadaten lesen, ohne das Öffnungspasswort anzugeben.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) bestimmt, was Aspose.Slides lädt; es entschlüsselt nichts. Wenn die Eigenschaften in die Verschlüsselung einbezogen wurden, schlägt das Laden ohne Passwort fehl. Ist die Präsentation nicht verschlüsselt, wird die Option ignoriert und die komplette Präsentation geladen.

Das Beispiel benötigt eine verschlüsselte Präsentation, deren Dokumenteigenschaften öffentlich bleiben. Es prüft den Lademodus über [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) und liest dann eingebaute Eigenschaften über [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

In diesem Modus wird der Folieninhalt nicht geladen. Folien, Masterfolien, Layouts, Formen, Medien und andere Präsentationsobjekte stehen nicht zur Verfügung. Anwendungen sollten stets [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) prüfen, bevor sie eine Operation ausführen, die das komplette Präsentations‑Objektmodell erfordert.

{{% alert color="warning" title="Security" %}}
Öffentliche Metadaten können Autorennamen, Titel, Themen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte preisgeben. Verschlüsseln Sie sensible Eigenschaften zusammen mit der Präsentation. Lassen Sie sie nur dann öffentlich, wenn Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokumenten‑Management‑Systeme einen spezifischen Bedarf haben, ohne Passwort darauf zuzugreifen.
{{% /alert %}}

## **Eigenschaften einer verschlüsselten Präsentation aktualisieren**

Für eine verschlüsselte PPTX‑Datei ist eine Präsentation, die mit [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) geladen wurde, zum Lesen öffentlicher Metadaten vorgesehen. Aspose.Slides kann geänderte Eigenschaften aus diesem reinen Metadaten‑Objekt nicht speichern, weil die öffentlichen Eigenschaften mit den entsprechenden Daten in der verschlüsselten Präsentation konsistent bleiben müssen. Die Aktualisierung erfordert daher das korrekte Öffnungspasswort und ein vollständiges Laden.

Das Beispiel benötigt eine verschlüsselte PPTX‑Präsentation mit öffentlichen Dokumenteigenschaften und einem bekannten Öffnungspasswort. Es öffnet die komplette Präsentation mit [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), aktualisiert öffentliche eingebaute Eigenschaften und speichert das Ergebnis. Anschließend wird über [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) verifiziert, dass die Verschlüsselung erhalten bleibt, und die öffentlichen Metadaten werden ohne Passwort erneut geöffnet, um die neuen Werte zu prüfen:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

Ist einer Anwendung das Entschlüsseln oder Laden des Präsentationsinhalts nicht gestattet, muss sie öffentliche Eigenschaften einer verschlüsselten PPTX‑Datei als schreibgeschützt behandeln.

## **Zugriff auf eingebaute Eigenschaften**

Das [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/)‑Interface stellt eingebaute Metadaten über typisierte Eigenschaften bereit, darunter [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/) und [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Dieses Beispiel öffnet eine vorhandene Präsentation und gibt deren gespeicherte Metadaten auf der Konsole aus. Die Werte hängen von der Eingabepäsentation ab; einige Felder können leer sein.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **Eingebaute Eigenschaften ändern**

Um eingebaute Metadaten zu aktualisieren, weisen Sie den schreibbaren Eigenschaften zu, die von [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) bereitgestellt werden. Dieses Beispiel öffnet eine vorhandene Präsentation, setzt [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/) und [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), und speichert die aktualisierte Präsentation mit [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Die gespeicherte PPTX‑Datei enthält die neuen Metadaten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Verwalten der Hyperlink‑Basis**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) speichert die dokumentweite Basis für relative Hyperlinks. Dies ist nützlich, wenn eine Präsentation und ihre verknüpften Dateien an einen anderen Ort verschoben werden. Sie ist unabhängig von der einzelnen Hyperlink‑Eigenschaft [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/): Das Ändern der Basis überschreibt nicht die gespeicherten Linkadressen und ändert keine absoluten Ziele.

Das Beispiel benötigt eine Präsentation, die sowohl einen relativen Link wie `target.html` als auch einen absoluten Link wie `https://example.org/absolute.html` enthält. Es liest die vorhandene Basis, weist eine neue Basis‑Adresse zu und speichert sowie öffnet die Präsentation erneut, um den Wert zu prüfen. Anschließend wird die Basis mit `string.Empty` geleert und der leere Wert in einer separaten Datei überprüft. Ersetzen Sie die Beispiel‑Basis‑Adresse durch den Ort Ihrer verknüpften Dateien.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

Die beiden Verifizierungsnachrichten sollten `True` ausgeben. Das Leeren der Basis lässt die einzelnen Hyperlink‑Adressen unverändert.

Ein relativer Link zu `target.pptx` öffnete `old/target.pptx`, als die Basis auf den Ordner `old` zeigte. Nach dem Ändern der Basis auf den Ordner `new`, dem Speichern und erneutem Öffnen der Präsentation öffnete derselbe Link `new/target.pptx`. Ein absoluter Link öffnete weiterhin dieselbe Datei. Testen Sie Ihre relativen Links in PowerPoint vor und nach dem Verschieben der Präsentation oder dem Ändern ihrer Basis.

## **Benutzerdefinierte Präsentationseigenschaften hinzufügen**

Benutzerdefinierte Eigenschaften speichern Metadaten, für die es kein entsprechendes eingebautes Feld gibt. Der [IDocumentProperties‑Indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) ermöglicht das Zuweisen eines Werts über den Eigenschaftsnamen. Dieses Beispiel erstellt eine Präsentation, fügt zwei Textwerte und einen ganzzahligen Versionswert hinzu und speichert die Präsentation mit [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Das Zuweisen eines Werts zu einem bestehenden Namen überschreibt den Wert dieser Eigenschaft.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Zugriff auf und Ändern benutzerdefinierter Eigenschaften**

Dieses Beispiel öffnet eine Präsentation mit benutzerdefinierten Eigenschaften und verwendet [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/), um über sie zu iterieren. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) akzeptiert einen nullbasierten Index und gibt den Namen zurück, der vom [IDocumentProperties‑Indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) verwendet wird. Das Beispiel gibt jeden ursprünglichen Namen und Wert aus, ersetzt jeden Wert durch einen nummerierten String, unabhängig vom ursprünglichen Typ, und speichert die Änderungen. Gibt es keine benutzerdefinierten Eigenschaften, führt die Schleife keine Änderungen durch.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live‑Beispiel**

Probieren Sie die Online‑App [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) aus, um zu sehen, wie man mit Dokumenteigenschaften über die Aspose.Slides‑API arbeitet:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Wie kann ich eine eingebaute Eigenschaft aus einer Präsentation entfernen?**

Eingebaute Eigenschaften sind ein integraler Bestandteil der Präsentation und können nicht vollständig entfernt werden. Sie können jedoch deren Werte ändern oder, sofern die jeweilige Eigenschaft es zulässt, auf leer setzen.

**Was passiert, wenn ich eine benutzerdefinierte Eigenschaft hinzufüge, die bereits existiert?**

Wird eine bereits vorhandene benutzerdefinierte Eigenschaft hinzugefügt, wird ihr vorhandener Wert durch den neuen überschrieben. Sie müssen die Eigenschaft nicht vorher entfernen oder prüfen, da Aspose.Slides den Wert automatisch aktualisiert.

**Kann ich auf Präsentationseigenschaften zugreifen, ohne die komplette Präsentation zu laden?**

Ja. Verwenden Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) und anschließend [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/), um gespeicherte Dokumentmetadaten zu lesen, ohne eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz zu erstellen. Siehe [Build a Lightweight Presentation Inventory](/slides/de/net/examine-presentation/) für ein vollständiges Berichtsexempel und formatspezifische Einschränkungen.

**Kann ich öffentliche Eigenschaften einer verschlüsselten Präsentation ohne ihr Öffnungspasswort lesen?**

Ja. Die Präsentation muss mit [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) auf `false` verschlüsselt sein und mit [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) auf `true` geladen werden.

**Kann ich eine verschlüsselte PPTX‑Datei im Nur‑Dokument‑Eigenschaften‑Modus aktualisieren?**

Nein. Öffentliche und verschlüsselte Eigenschaftsdaten müssen konsistent bleiben, daher erfordert das Aktualisieren einer verschlüsselten PPTX‑Datei das vollständige Laden der Präsentation mit dem korrekten Öffnungspasswort.