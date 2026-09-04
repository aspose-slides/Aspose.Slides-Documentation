---
title: "Passwortschutz für Präsentationen in .NET"
linktitle: "Passwortschutz"
type: docs
weight: 20
url: /de/net/password-protected-presentation/
keywords:
- "passwortgeschützte Präsentation"
- "Öffnungspasswort"
- "PowerPoint verschlüsseln"
- "PowerPoint entschlüsseln"
- "Präsentationspasswort validieren"
- "Präsentationspasswort prüfen"
- "Verschlüsselte Präsentation öffnen"
- "Verschlüsselung entfernen"
- "PowerPoint"
- "PPT"
- "PPTX"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln von passwortgeschützten PowerPoint PPT‑ und PPTX‑Präsentationen in C# mit Aspose.Slides für .NET."
---
## **Übersicht**

Ein Öffnungspasswort verschlüsselt eine Präsentation. Das korrekte Passwort ist erforderlich, um die Präsentationsinhalte zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungspasswort unterscheidet sich von einem Schreibschutz‑Passwort. Der Schreibschutz beschränkt Änderungen, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Um Passwörter für das Ändern von Präsentationen zu verwalten, siehe [Write-Protect Presentations](/slides/de/net/write-protected-presentation/).

Die nachstehenden Workflows gelten für PPT‑ und PPTX‑Präsentationen. Die Beispiele verwenden beide Formate, wenn ihr datei‑basiertes und strom‑basiertes Verhalten wichtig ist.

## **Eine Präsentation mit einem Öffnungspasswort verschlüsseln**

Verwenden Sie [IProtectionManager.Encrypt](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/encrypt/) , um ein Öffnungspasswort festzulegen. Anschließend verwenden Sie [IPresentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/save/) , um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Dokumenteigenschaften öffentlich halten**

Standardmäßig schließt Aspose.Slides Dokumenteigenschaften in die Präsentationsverschlüsselung ein. Die Eigenschaft [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) steuert dieses Verhalten unabhängig von der Folien‑Inhaltsverschlüsselung. Setzen Sie sie auf `false`, bevor Sie [IProtectionManager.Encrypt](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/encrypt/) aufrufen, wenn ein Indexierungs‑, Klassifizierungs‑, Such‑ oder Dokument‑Management‑System Metadaten ohne das Öffnungspasswort lesen muss.

Das folgende Beispiel erstellt eine verschlüsselte PPTX‑Präsentation, wobei die eingebauten Dokumenteigenschaften öffentlich bleiben:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Das Setzen von `EncryptDocumentProperties` auf `false` macht nicht die Folien, Master, Layouts, Formen, Medien oder andere Präsentationsinhalte öffentlich. Es betrifft ausschließlich die Dokumenteigenschaften. Um diese Eigenschaften zu lesen, ohne den verschlüsselten Inhalt zu laden, siehe [Manage Presentation Properties](/slides/de/net/presentation-properties/).

## **Eine verschlüsselte Präsentation laden**

Setzen Sie [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) auf das Öffnungspasswort und übergeben Sie die Optionen an [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) , wenn Sie die Datei laden. Das Laden schlägt fehl, wenn ein Öffnungspasswort erforderlich ist, das übergebene Passwort jedoch fehlt oder falsch ist.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Arbeiten mit der entschlüsselten Präsentation.
```

## **Verschlüsselung einer Präsentation entfernen**

Laden Sie die Präsentation mit ihrem Öffnungspasswort, rufen Sie [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/removeencryption/) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Passwort geladen werden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Ein Öffnungspasswort vor dem Laden prüfen**

Verwenden Sie [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationfactory/getpresentationinfo/) , um [IPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/) zu erhalten, ohne eine komplette Präsentations‑Instanz zu erstellen. Überprüfen Sie [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/ispasswordprotected/) , bevor Sie ein Passwort anfordern oder prüfen. Ist ein Schutz vorhanden, validieren Sie den angegebenen Wert mit [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/checkpassword/) .

### **Dateipfad‑Workflow**

Das folgende Beispiel prüft ein Öffnungspasswort für eine PPTX‑Datei, übergibt den validierten Wert an [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) , und lädt anschließend die komplette Präsentation:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Strom‑Workflow**

Die Stream‑Überladung von [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationfactory/getpresentationinfo/) bietet denselben Workflow. Setzen Sie die Position eines durchsuchbaren Streams zurück, bevor Sie die komplette Präsentation aus diesem Stream laden.

Das folgende Beispiel verwendet eine PPT‑Datei:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Rückgabewerte von CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/checkpassword/) gibt `true` nur zurück, wenn die Präsentation ein Öffnungspasswort hat und das übergebene Passwort korrekt ist. Es gibt `false` in folgenden Fällen zurück:

- Das Passwort ist falsch.
- Die Präsentation hat kein Öffnungspasswort.
- Das übergebene Passwort ist `null` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Prüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem korrekten Passwort geladen haben, prüfen Sie [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/isencrypted/) , um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnung‑Passwort‑Schutz vor dem Laden zu erkennen, verwenden Sie `IPresentationInfo.IsPasswordProtected` wie oben gezeigt.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Sicherheits‑Empfehlungen**

{{% alert color="warning" title="Sicherheit" %}}
Protokollieren Sie Öffnungspasswörter nicht und geben Sie sie nicht in Diagnosenachrichten aus. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Passwörter im Speicher nur so lange wie nötig und nutzen Sie ein erfolgreiches Validierungsergebnis erneut, wenn Sie die Präsentation sofort laden.

Öffentliche Dokumenteigenschaften können Autorennamen, Titel, Themen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte offenbaren, obwohl der Präsentationsinhalt verschlüsselt ist. Verschlüsseln Sie sensible Metadaten zusammen mit der Präsentation. Das Offenlassen von Eigenschaften sollte eine bewusste Entscheidung sein, die nur getroffen wird, wenn Systeme die Datei ohne Öffnungspasswort indizieren, klassifizieren, durchsuchen oder verwalten müssen.
{{% /alert %}}

## **Eine Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
2. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
3. Geben Sie ein Passwort für den Ansichtsschutz ein.
4. Optional geben Sie ein separates Passwort für den Bearbeitungsschutz ein.
5. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Write-Protect Presentations](/slides/de/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungspasswort und einem Schreibschutz‑Passwort?**

Ein Öffnungspasswort verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Ein Schreibschutz‑Passwort beschränkt Änderungen, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungspasswort prüfen, ohne alle Folien zu laden?**

Ja. Holen Sie Präsentationsinformationen, prüfen Sie, ob ein Öffnungspasswort‑Schutz vorhanden ist, und validieren Sie das Passwort, bevor Sie eine komplette Präsentationsinstanz erstellen.

**Kann eine Anwendung Metadaten ohne das Öffnungspasswort lesen?**

Ja, jedoch nur, wenn die Präsentation mit `EncryptDocumentProperties` auf `false` verschlüsselt wurde. Die Anwendung muss dann den ausschließlich Dokument‑Eigenschaften‑Lademodus verwenden, der in [Manage Presentation Properties](/slides/de/net/presentation-properties/) beschrieben ist.

**Unterstützen die Passwort‑Prüf‑Workflows sowohl PPT als auch PPTX?**

Ja. Datei‑Pfad‑ und Stream‑basierte Passwort‑Erkennung und -Validierung verhalten sich bei PPT‑ und PPTX‑Präsentationen identisch.