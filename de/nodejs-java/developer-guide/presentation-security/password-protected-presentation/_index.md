---
title: Passwortschutz für Präsentationen in JavaScript
linktitle: Passwortschutz
type: docs
weight: 20
url: /de/nodejs-java/password-protected-presentation/
keywords:
  - passwortgeschützte Präsentation
  - Öffnungskennwort
  - PowerPoint verschlüsseln
  - PowerPoint entschlüsseln
  - Präsentationskennwort validieren
  - Präsentationskennwort prüfen
  - verschlüsselte Präsentation öffnen
  - Verschlüsselung entfernen
  - PowerPoint
  - PPT
  - PPTX
  - Präsentation
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Verschlüsseln, erkennen, validieren, öffnen und entschlüsseln Sie passwortgeschützte PowerPoint PPT- und PPTX-Präsentationen in JavaScript mit Aspose.Slides."
---
## **Übersicht**

Ein Öffnungskennwort verschlüsselt eine Präsentation. Das korrekte Kennwort ist erforderlich, um den Präsentationsinhalt zu laden und anzuzeigen, sodass dieser Schutz Vertraulichkeit gewährleistet.

Ein Öffnungskennwort unterscheidet sich von einem Schreibschutzkennwort. Schreibschutz beschränkt Änderungen, verschlüsselt jedoch nicht den Inhalt und verhindert nicht das Laden der Präsentation. Um Kennwörter für die Änderung von Präsentationen zu verwalten, siehe [Write-Protect Presentations](/slides/de/nodejs-java/write-protected-presentation/).

Die nachfolgenden Workflows gelten für PPT- und PPTX-Präsentationen. Die Beispiele verwenden beide Formate, wo ihr dateibasiertes und streambasiertes Verhalten wichtig ist.

## **Verschlüsseln einer Präsentation mit einem Öffnungskennwort**

Verwenden Sie [ProtectionManager.encrypt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#encrypt), um ein Öffnungskennwort zuzuweisen. Verwenden Sie anschließend [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save), um die verschlüsselte Präsentation zu speichern.

Das folgende Beispiel verschlüsselt eine PPTX-Präsentation:

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

## **Dokumenteigenschaften öffentlich lassen**

Standardmäßig schließt Aspose.Slides Dokumenteigenschaften in die Präsentationsverschlüsselung ein. Die Methode [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) steuert dieses Verhalten unabhängig von der Folieninhaltsverschlüsselung. Übergeben Sie `false` vor dem Aufruf von [ProtectionManager.encrypt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#encrypt), wenn ein Indexierungs-, Klassifikations-, Such- oder Dokumentenmanagementsystem Metadaten ohne das Öffnungskennwort lesen muss.

Das folgende Beispiel erstellt eine verschlüsselte PPTX-Präsentation, wobei die integrierten Dokumenteigenschaften öffentlich bleiben:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Übergeben von `false` an [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) macht nicht Folien, Master, Layouts, Formen, Medien oder anderen Präsentationsinhalt öffentlich. Es wirkt sich nur auf Dokumenteigenschaften aus. Um diese Eigenschaften zu lesen, ohne den verschlüsselten Inhalt zu laden, siehe [Manage Presentation Properties](/slides/de/nodejs-java/presentation-properties/).

## **Laden einer verschlüsselten Präsentation**

Setzen Sie [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword) auf das Öffnungskennwort und übergeben Sie die Optionen beim Laden der Datei an [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/). Das Laden schlägt fehl, wenn ein Öffnungskennwort erforderlich ist, das übermittelte Kennwort jedoch fehlt oder falsch ist.

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

Laden Sie die Präsentation mit ihrem Öffnungskennwort, rufen Sie [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) auf und speichern Sie das Ergebnis. Die gespeicherte Präsentation kann anschließend ohne Kennwort geladen werden.

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

## **Überprüfen eines Öffnungskennworts vor dem Laden**

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo), um [PresentationInfo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/) zu erhalten, ohne eine vollständige Präsentationsinstanz zu erstellen. Prüfen Sie [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected), bevor Sie ein Kennwort anfordern oder prüfen. Ist ein Schutz vorhanden, validieren Sie den übermittelten Wert mit [PresentationInfo.checkPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Dateipfad-Workflow**

Das folgende Beispiel prüft ein Öffnungskennwort für eine PPTX-Datei, übergibt den validierten Wert an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword) und lädt anschließend die vollständige Präsentation:

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

### **Stream-Workflow**

Verwenden Sie [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream), um einen lesbaren Node.js-Stream zu prüfen. Nachdem der Prüf-Stream verbraucht wurde, erstellen Sie einen neuen Stream, bevor Sie die vollständige Präsentation mit [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) laden.

Das folgende Beispiel verwendet eine PPT-Datei:

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#checkPassword) gibt `true` nur zurück, wenn die Präsentation ein Öffnungskennwort hat und das übermittelte Kennwort korrekt ist. Es gibt `false` in jedem dieser Fälle zurück:

- Das Kennwort ist falsch.
- Die Präsentation hat kein Öffnungskennwort.
- Das übermittelte Kennwort ist `null` oder leer.

Das Verhalten ist für PPT- und PPTX-Präsentationen identisch.

## **Überprüfen, ob eine geladene Präsentation verschlüsselt ist**

Nach dem Laden einer Präsentation mit dem korrekten Kennwort prüfen Sie [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/protectionmanager/#isEncrypted), um zu bestätigen, dass die Quellpräsentation verschlüsselt war. Um den Öffnungskennwortschutz vor dem Laden zu erkennen, verwenden Sie [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) wie oben gezeigt.

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
Protokollieren Sie Öffnungskennwörter nicht und fügen Sie sie nicht in Diagnosemeldungen ein. Vermeiden Sie unnötige wiederholte Validierungsversuche, behalten Sie Kennwörter nur so lange im Speicher, wie sie benötigt werden, und verwenden Sie ein erfolgreiches Validierungsergebnis erneut, wenn die Präsentation sofort geladen wird.

Öffentliche Dokumenteigenschaften können Autorennamen, Titel, Themen, Schlüsselwörter, Unternehmensinformationen, Kommentare und benutzerdefinierte Werte offenbaren, obwohl der Präsentationsinhalt verschlüsselt ist. Verschlüsseln Sie sensible Metadaten zusammen mit der Präsentation. Das öffentliche Belassen von Eigenschaften sollte eine bewusste Entscheidung sein, die nur getroffen wird, wenn Systeme die Datei indexieren, klassifizieren, durchsuchen oder verwalten müssen, ohne ein Öffnungskennwort.

{{% /alert %}}

## **Präsentation online passwortschützen**

1. Öffnen Sie die Anwendung [Aspose.Slides Lock](https://products.aspose.app/slides/de/lock).
1. Wählen Sie die Präsentation aus oder laden Sie sie hoch.
1. Geben Sie ein Kennwort zum Schutz der Anzeige ein.
1. Geben Sie optional ein separates Kennwort zum Schutz der Bearbeitung ein.
1. Wenden Sie den Schutz an und laden Sie die resultierende Datei herunter.

{{% alert color="info" title="Siehe auch" %}}
- [Write-Protect Presentations](/slides/de/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/de/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Was ist der Unterschied zwischen einem Öffnungskennwort und einem Schreibschutzkennwort?**

Ein Öffnungskennwort verschlüsselt die Präsentation und ist erforderlich, um deren Inhalt zu laden. Ein Schreibschutzkennwort beschränkt die Bearbeitung, ohne den Inhalt zu verschlüsseln.

**Kann ich ein Öffnungskennwort prüfen, ohne alle Folien zu laden?**

Ja. Holen Sie die Präsentationsinformationen, prüfen Sie, ob ein Öffnungskennwortschutz vorhanden ist, und validieren Sie das Kennwort, bevor Sie eine vollständige Präsentationsinstanz erstellen.

**Kann eine Anwendung Metadaten ohne das Öffnungskennwort lesen?**

Ja, jedoch nur, wenn die Präsentation mit deaktivierter Dokumenten‑Eigenschafts‑Verschlüsselung verschlüsselt wurde. Die Anwendung muss dann den ausschließlich für Dokumenteigenschaften vorgesehenen Lademodus verwenden, wie in [Manage Presentation Properties](/slides/de/nodejs-java/presentation-properties/) beschrieben.

**Unterstützen die Kennwort‑Überprüfungs‑Workflows sowohl PPT als auch PPTX?**

Ja. Die dateipfad‑ und streambasierte Kennwort‑Erkennung und -Validierung verhalten sich bei PPT‑ und PPTX‑Präsentationen gleich.