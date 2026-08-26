---
title: Präsentationen in .NET mit Passwortschutz
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/net/password-protected-presentation/
keywords:
- Passwortgeschützte Präsentation
- Öffnungspasswort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationspasswort validieren
- Präsentationspasswort prüfen
- Verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln von passwortgeschützten PowerPoint PPT- und PPTX-Präsentationen in C# mit Aspose.Slides für .NET."
---
## **Übersicht**

Ein Öffnungspasswort verschlüsselt eine Präsentation. Das korrekte Passwort ist erforderlich, um den Inhalt der Präsentation zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit bietet.

Ein Öffnungspasswort unterscheidet sich von einem Schreibschutz‑Passwort. Der Schreibschutz beschränkt Änderungen, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Zur Verwaltung von Passwörtern für die Bearbeitung von Präsentationen siehe [Write-Protect Presentations](/slides/de/net/write-protected-presentation/).

Die nachstehenden Workflows gelten für PPT‑ und PPTX‑Präsentationen. Die Beispiele verwenden beide Formate, wenn ihr verhaltensbasierter Unterschied zwischen Datei‑ und Stream‑Verarbeitung wichtig ist.

## **Präsentation mit einem Öffnungspasswort verschlüsseln**

Verwenden Sie [IProtectionManager.Encrypt](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/encrypt/), um ein Öffnungspasswort zuzuweisen. Anschließend verwenden Sie [IPresentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/save/), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Verschlüsselte Präsentation laden**

Setzen Sie [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) auf das Öffnungspasswort und übergeben Sie die Optionen beim Laden der Datei an [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/). Das Laden schlägt fehl, wenn ein Öffnungspasswort erforderlich ist, das übermittelte Passwort jedoch fehlt oder falsch ist.

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

## **Öffnungspasswort vor dem Laden prüfen**

Verwenden Sie [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationfactory/getpresentationinfo/), um [IPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erzeugen. Überprüfen Sie [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/ispasswordprotected/), bevor Sie ein Passwort anfordern oder prüfen. Ist ein Schutz vorhanden, validieren Sie den übermittelten Wert mit [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Dateipfad-Workflow**

Das folgende Beispiel prüft ein Öffnungspasswort für eine PPTX‑Datei, übergibt den validierten Wert an [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) und lädt anschließend die komplette Präsentation:

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

### **Stream-Workflow**

Die Stream-Überladung von [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationfactory/getpresentationinfo/) bietet denselben Workflow. Setzen Sie die Position eines durchsuchbaren Streams zurück, bevor Sie die komplette Präsentation aus diesem Stream laden.

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

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/checkpassword/) gibt `true` zurück, nur wenn die Präsentation ein Öffnungspasswort besitzt und das übermittelte Passwort korrekt ist. In den folgenden Fällen wird `false` zurückgegeben:

- Das Passwort ist falsch.
- Die Präsentation hat kein Öffnungspasswort.
- Das übermittelte Passwort ist `null` oder leer.

Das Verhalten ist für PPT‑ und PPTX‑Präsentationen identisch.

## **Prüfen, ob eine geladene Präsentation verschlüsselt ist**

Nachdem Sie eine Präsentation mit dem korrekten Passwort geladen haben, prüfen Sie [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/isencrypted/), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungspasswortschutz vor dem Laden zu erkennen, verwenden Sie `IPresentationInfo.IsPasswordProtected` wie oben gezeigt.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Sicherheits‑Empfehlungen**

{{% alert color="warning" title="Security" %}}
Protokollieren Sie Öffnungspasswörter nicht und geben Sie sie nicht in Diagnosenachrichten aus. Vermeiden Sie unnötige wiederholte Validierungsversuche, halten Sie Passwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn die Präsentation sofort geladen wird.
{{% /alert %}}

## **Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Passwort zum Schutz der Anzeige ein.
1. Geben Sie optional ein separates Passwort zum Schutz der Bearbeitung ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/de/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungspasswort und einem Schreibschutz‑Passwort?**

Ein Öffnungspasswort verschlüsselt die Präsentation und ist erforderlich, um deren Inhalt zu laden. Ein Schreibschutz‑Passwort beschränkt Änderungen, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungspasswort prüfen, ohne alle Folien zu laden?**

Ja. Holen Sie die Präsentationsinformationen ab, prüfen Sie, ob ein Öffnungspasswortschutz vorhanden ist, und validieren Sie das Passwort, bevor Sie eine vollständige Präsentationsinstanz erzeugen.

**Unterstützen die Passwort‑Überprüfungs‑Workflows sowohl PPT als auch PPTX?**

Ja. Die dateipfad- und streambasierte Erkennung sowie Validierung von Passwörtern verhalten sich für PPT‑ und PPTX‑Präsentationen identisch.