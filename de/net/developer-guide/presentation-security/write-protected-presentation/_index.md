---
title: Schreibgeschützte Präsentationen in .NET
linktitle: Schreibschutz
type: docs
weight: 25
url: /de/net/write-protected-presentation/
keywords:
- Schreibschutz
- PowerPoint-Schreibschutz
- Passwort zum Ändern
- Bearbeitung der Präsentation einschränken
- Schreibschutz entfernen
- Änderungs-Passwort validieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Schreibschutz-Passwörter in PowerPoint PPT- und PPTX-Präsentationen setzen, erkennen, prüfen und entfernen mit Aspose.Slides für .NET."
---
## **Einleitung**

Ein Schreibschutz‑Passwort schränkt die Änderungen an einer Präsentation ein, verschlüsselt jedoch nicht deren Inhalt. Benutzer können eine schreibgeschützte Präsentation ohne das Passwort laden und anzeigen. Je nach Anwendung können sie den Inhalt auch bearbeiten und unter einem anderen Namen speichern, sodass der Schreibschutz nicht als Vertraulichkeitsmechanismus betrachtet werden sollte.

Ein Öffnungs‑Passwort hat einen anderen Zweck: Es verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Um eine Präsentation zu verschlüsseln oder ein Öffnungs‑Passwort zu prüfen, siehe [Password-Protect Presentations](/slides/de/net/password-protected-presentation/).

Die in diesem Artikel beschriebenen Arbeitsabläufe gelten für PPT‑ und PPTX‑Präsentationen. Die Beispiele verwenden PPTX‑Dateien; beim Speichern als PPT verwenden Sie die Erweiterung `.ppt` und das entsprechende PPT‑Speicherformat.

## **Schreibschutz für eine Präsentation festlegen**

Verwenden Sie [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/setwriteprotection/), um ein Passwort für die Änderung einer Präsentation zuzuweisen. Beim Speichern der Präsentation wird die Schutzeinstellung beibehalten.

Das folgende Beispiel legt einen Schreibschutz für eine PPTX‑Präsentation fest:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Schreibgeschützte Präsentation laden**

Da der Schreibschutz den Präsentationsinhalt nicht verschlüsselt, ist zum Laden der Präsentation kein Passwort erforderlich. Das Passwort ist nur relevant, wenn die Berechtigung zur Änderung der geschützten Präsentation geprüft wird.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Übergeben Sie kein Schreibschutz‑Passwort an [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/). Diese Eigenschaft akzeptiert ein Öffnungs‑Passwort für verschlüsselten Inhalt. Hat eine Präsentation beide Schutzarten, geben Sie das Öffnungs‑Passwort zum Laden an und behandeln Sie das Schreibschutz‑Passwort separat.

## **Schreibschutz von einer Präsentation entfernen**

Verwenden Sie [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/removewriteprotection/), um die Änderungsbeschränkung zu entfernen, und speichern Sie anschließend die Präsentation.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Um eine Datei zu untersuchen, ohne eine vollständige [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)-Instanz zu erzeugen, rufen Sie [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationfactory/getpresentationinfo/) auf und prüfen Sie [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/iswriteprotected/). Die Eigenschaft verwendet [NullableBool](https://reference.aspose.com/slides/de/net/aspose.slides/nullablebool/) und gibt `NullableBool.True` zurück, wenn ein Schreibschutz erkannt wird.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

Die Stream‑Überladung von [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationfactory/getpresentationinfo/) liefert dieselben Informationen für eine als Stream bereitgestellte Präsentation.

## **Schreibschutz‑Passwort prüfen**

Verwenden Sie [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/checkwriteprotection/), um ein Änderungs‑Passwort zu prüfen, ohne die vollständige Präsentation zu laden. Prüfen Sie zunächst [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/iswriteprotected/), damit die Anwendung ein Passwort nur anfordert oder prüft, wenn ein Schreibschutz vorhanden ist.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/checkwriteprotection/) prüft nur das Schreibschutz‑Passwort. Es prüft kein Öffnungs‑Passwort und ermittelt nicht, ob verschlüsselter Inhalt geladen werden kann. Im Gegensatz dazu prüft [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentationinfo/checkpassword/) nur ein Öffnungs‑Passwort. Wurde bereits eine komplette Präsentation geladen, liefert [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/de/net/aspose.slides/iprotectionmanager/checkwriteprotection/) die äquivalente Schreibschutzprüfung über seinen Schutz‑Manager.

In Produktionsanwendungen sollten Passwörter nicht protokolliert oder in Diagnosemeldungen eingebettet werden. Vermeiden Sie unnötige wiederholte Prüfungen und behalten Sie Passwörter im Speicher nur so lange, wie sie benötigt werden.

{{% alert color="info" title="Siehe auch" %}}
- [Präsentationen mit Passwort schützen](/slides/de/net/password-protected-presentation/)
- [Nur-Lese-Präsentationen](/slides/de/net/read-only-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Verschlüsselt der Schreibschutz eine Präsentation?**

Nein. Er schränkt Änderungen ein, lässt jedoch den Präsentationsinhalt zum Laden und Anzeigen verfügbar.

**Ist das Schreibschutz‑Passwort zum Öffnen einer Präsentation erforderlich?**

Nein. Nur ein Öffnungs‑Passwort ist erforderlich, um verschlüsselten Präsentationsinhalt zu laden.

**Kann eine Präsentation sowohl ein Öffnungs‑Passwort als auch ein Schreibschutz‑Passwort haben?**

Ja. Geben Sie das Öffnungs‑Passwort über die Ladeoptionen an, um die verschlüsselte Präsentation zu öffnen, und prüfen Sie das Schreibschutz‑Passwort separat, wenn eine Änderungsberechtigung erforderlich ist.