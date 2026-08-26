---
title: Präsentationen in JavaScript passwortschützen
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/nodejs-java/password-protected-presentation/
keywords:
- Passwortgeschützte Präsentation
- Öffnungspasswort
- PowerPoint verschlüsseln
- PowerPoint entschlüsseln
- Präsentationspasswort prüfen
- Präsentationspasswort überprüfen
- Verschlüsselte Präsentation öffnen
- Verschlüsselung entfernen
- PowerPoint
- PPT
- PPTX
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verschlüsseln, erkennen, prüfen, öffnen und entschlüsseln Sie passwortgeschützte PowerPoint‑PPT‑ und PPTX‑Präsentationen in JavaScript mit Aspose.Slides."
---
## **Übersicht**

Ein Öffnungspasswort verschlüsselt eine Präsentation. Das richtige Passwort ist erforderlich, um den Präsentationsinhalt zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit bietet.

Ein Öffnungspasswort unterscheidet sich von einem Schreibschutz‑Passwort. Der Schreibschutz beschränkt Änderungen, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Um Passwörter für die Modifikation von Präsentationen zu verwalten, siehe [Präsentationen schreibschützen](/slides/de/nodejs-java/write-protected-presentation/).

Die nachfolgenden Workflows gelten für PPT- und PPTX‑Präsentationen. Die Beispiele verwenden beide Formate, wenn ihr datei‑ und streambasiertes Verhalten wichtig ist.

## **Eine Präsentation mit einem Öffnungspasswort verschlüsseln**

Verwenden Sie [ProtectionManager.encrypt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#encrypt), um ein Öffnungspasswort zuzuweisen. Anschließend verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX‑Präsentation:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verschlüsselte Präsentation laden**

Setzen Sie [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword) auf das Öffnungspasswort und übergeben Sie die Optionen an [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/), wenn Sie die Datei laden. Das Laden schlägt fehl, wenn ein Öffnungspasswort erforderlich ist, das bereitgestellte Passwort jedoch fehlt oder falsch ist.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Arbeiten Sie mit der entschlüsselten Präsentation.
} finally {
    presentation.dispose();
}
```

## **Verschlüsselung einer Präsentation entfernen**

Laden Sie die Präsentation mit ihrem Öffnungspasswort, rufen Sie [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann dann ohne Passwort geladen werden.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Öffnungspasswort vor dem Laden prüfen**

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo), um [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected), bevor Sie ein Passwort anfordern oder prüfen. Wenn ein Schutz vorhanden ist, prüfen Sie den bereitgestellten Wert mit [PresentationInfo.checkPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Dateipfad‑Workflow**

Das folgende Beispiel prüft ein Öffnungspasswort für eine PPTX‑Datei, übergibt den geprüften Wert an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword) und lädt anschließend die vollständige Präsentation:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Stream‑Workflow**

Verwenden Sie [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream), um einen Node.js lesbaren Stream zu untersuchen. Nachdem der Untersuchungs‑Stream verbraucht wurde, erstellen Sie einen neuen Stream, bevor Sie die vollständige Präsentation mit [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) laden.

Das folgende Beispiel verwendet eine PPT‑Datei:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Rückgabewerte von checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#checkPassword) gibt `true` nur zurück, wenn die Präsentation ein Öffnungspasswort hat und das bereitgestellte Passwort korrekt ist. Es gibt `false` in jedem der folgenden Fälle zurück:

- Das Passwort ist falsch.
- Die Präsentation hat kein Öffnungspasswort.
- Das bereitgestellte Passwort ist `null` oder leer.

Das Verhalten ist bei PPT‑ und PPTX‑Präsentationen identisch.

## **Prüfen, ob eine geladene Präsentation verschlüsselt ist**

Nach dem Laden einer Präsentation mit dem korrekten Passwort prüfen Sie [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#isEncrypted), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungspasswortschutz vor dem Laden zu erkennen, verwenden Sie [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) wie oben gezeigt.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Sicherheitsempfehlungen**

{{% alert color="warning" title="Sicherheit" %}}
Protokollieren Sie keine Öffnungspasswörter und fügen Sie sie nicht in Diagnosemeldungen ein. Vermeiden Sie unnötige wiederholte Prüfungsversuche, halten Sie Passwörter im Speicher nur so lange wie nötig und verwenden Sie ein erfolgreiches Prüfergebnis erneut, wenn die Präsentation sofort geladen wird.
{{% /alert %}}

## **Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
2. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
3. Geben Sie ein Passwort zum Schutz der Ansicht ein.
4. Geben Sie optional ein separates Passwort zum Schutz der Bearbeitung ein.
5. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Präsentationen schreibschützen](/slides/de/nodejs-java/write-protected-presentation/)
- [Digitale Signatur in PowerPoint](/slides/de/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungspasswort und einem Schreibschutz‑Passwort?**

Ein Öffnungspasswort verschlüsselt die Präsentation und ist zum Laden des Inhalts erforderlich. Ein Schreibschutz‑Passwort beschränkt Änderungen, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungspasswort prüfen, ohne alle Folien zu laden?**

Ja. Holen Sie Präsentationsinformationen, prüfen Sie, ob ein Öffnungspasswortschutz vorhanden ist, und validieren Sie das Passwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Unterstützen die Passwort‑Prüf‑Workflows sowohl PPT als auch PPTX?**

Ja. Datei‑Pfad‑ und streambasierte Passwort‑Erkennung und -Validierung verhalten sich bei PPT‑ und PPTX‑Präsentationen identisch.