---
title: Schreibschutz für Präsentationen in JavaScript
linktitle: Schreibschutz
type: docs
weight: 25
url: /de/nodejs-java/write-protected-presentation/
keywords:
- Schreibschutz
- PowerPoint Schreibschutz
- Passwort zum Ändern
- Bearbeitung der Präsentation einschränken
- Schreibschutz entfernen
- Änderungs-Passwort prüfen
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Schreibschutz-Passwörter in PowerPoint PPT- und PPTX-Präsentationen setzen, erkennen, validieren und entfernen mit Aspose.Slides für Node.js über Java."
---
## **Einleitung**

Ein Schreibschutz-Passwort schränkt die Änderung einer Präsentation ein, verschlüsselt jedoch nicht deren Inhalt. Benutzer können eine schreibgeschützte Präsentation ohne das Passwort laden und anzeigen. Je nach Anwendung können sie den Inhalt möglicherweise auch bearbeiten und unter einem anderen Namen speichern, sodass Schreibschutz nicht als Vertraulichkeitsmechanismus betrachtet werden sollte.

Ein Öffnungs­passwort dient einem anderen Zweck: Es verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Um eine Präsentation zu verschlüsseln oder ein Öffnungs­passwort zu prüfen, siehe [Passwortgeschützte Präsentationen](/slides/de/nodejs-java/password-protected-presentation/).

Die Arbeitsabläufe in diesem Artikel gelten sowohl für PPT- als auch PPTX‑Präsentationen. Die Beispiele verwenden PPTX‑Dateien; beim Speichern als PPT verwenden Sie die Erweiterung `.ppt` und das entsprechende PPT‑Speicherformat.

## **Schreibschutz für eine Präsentation festlegen**

Verwenden Sie [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection), um ein Passwort für das Ändern einer Präsentation zuzuweisen. Das Speichern der Präsentation bewahrt die Schutzeinstellung.

Das folgende Beispiel legt Schreibschutz für eine PPTX‑Präsentation fest:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Schreibgeschützte Präsentation laden**

Da Schreibschutz den Präsentationsinhalt nicht verschlüsselt, ist zum Laden der Präsentation kein Passwort erforderlich. Das Passwort ist nur relevant, wenn die Berechtigung zur Änderung der geschützten Präsentation geprüft wird.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Übergeben Sie kein Schreibschutz‑Passwort an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword). Diese Methode akzeptiert ein Öffnungs­passwort für verschlüsselten Inhalt. Hat eine Präsentation beide Schutzarten, geben Sie das Öffnungs­passwort zum Laden an und behandeln Sie das Schreibschutz‑Passwort separat.

## **Schreibschutz von einer Präsentation entfernen**

Verwenden Sie [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection), um die Änderungsbeschränkung zu entfernen, und speichern Sie anschließend die Präsentation.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prüfen, ob eine Präsentation schreibgeschützt ist**

Um eine Datei zu prüfen, ohne eine vollständige [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Instanz zu erstellen, rufen Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) auf und untersuchen Sie [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Die Methode verwendet [NullableBool](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/nullablebool/) und gibt `NullableBool.True` zurück, wenn Schreibschutz erkannt wird.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Die streambasierte Methode [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) liefert dieselben Informationen für eine Präsentation, die als lesbarer Node.js‑Stream bereitgestellt wird.

## **Schreibschutz‑Passwort validieren**

Verwenden Sie [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection), um ein Änderungs‑Passwort zu prüfen, ohne die gesamte Präsentation zu laden. Prüfen Sie zuerst [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected), damit die Anwendung ein Passwort nur anfordert oder prüft, wenn Schreibschutz vorhanden ist.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) prüft nur das Schreibschutz‑Passwort. Es prüft kein Öffnungs­passwort und ermittelt nicht, ob verschlüsselter Inhalt geladen werden kann. Im Gegenteil prüft [PresentationInfo.checkPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#checkPassword) nur ein Öffnungs­passwort. Wurde bereits eine vollständige Präsentation geladen, liefert [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) die entsprechende Schreibschutz‑Prüfung über seinen Protection‑Manager.

In Produktionsanwendungen sollten Passwörter nicht protokolliert oder in Diagnosemeldungen aufgenommen werden. Vermeiden Sie unnötige wiederholte Prüfungen und behalten Sie Passwörter im Speicher nur so lange, wie sie benötigt werden.

{{% alert color="info" title="Siehe auch" %}}
- [Passwortgeschützte Präsentationen](/slides/de/nodejs-java/password-protected-presentation/)
- [Nur‑Lese‑Präsentationen](/slides/de/nodejs-java/read-only-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Verschlüsselt Schreibschutz eine Präsentation?**

Nein. Er schränkt die Änderung ein, lässt jedoch den Präsentationsinhalt zum Laden und Anzeigen verfügbar.

**Ist das Schreibschutz‑Passwort zum Öffnen einer Präsentation erforderlich?**

Nein. Nur ein Öffnungs­passwort ist erforderlich, um verschlüsselten Präsentationsinhalt zu laden.

**Kann eine Präsentation sowohl ein Öffnungs­passwort als auch ein Schreibschutz‑Passwort haben?**

Ja. Geben Sie das Öffnungs­passwort über die Ladeoptionen an, um die verschlüsselte Präsentation zu öffnen, und prüfen Sie das Schreibschutz‑Passwort separat, wenn eine Änderungsberechtigung erforderlich ist.