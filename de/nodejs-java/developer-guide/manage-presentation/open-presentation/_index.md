---
title: Präsentationen in JavaScript öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/nodejs-java/open-presentation/
keywords:
- PowerPoint öffnen
- Präsentation öffnen
- PPTX öffnen
- PPT öffnen
- ODP öffnen
- Präsentation laden
- PPTX laden
- PPT laden
- ODP laden
- geschützte Präsentation
- große Präsentation
- externe Ressource
- binäres Objekt
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument‑Präsentationen in JavaScript öffnen, Öffnungspasswörter bereitstellen, das Laden von Ressourcen steuern und den Speicherverbrauch mit Aspose.Slides für Node.js via Java reduzieren."
---
## **Einleitung**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/de/nodejs-java/) kann PowerPoint- und OpenDocument‑Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie ihre Struktur untersuchen, Folien bearbeiten, Ressourcen verwalten und sie im ursprünglichen oder einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/) angepasst werden. Beispielsweise können Sie ein Öffnungspasswort angeben, große Binärobjekte außerhalb des Node.js‑Speichers halten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, übergeben Sie ihren Dateipfad dem Konstruktor [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/). Entsorgen Sie die Präsentation nach der Verwendung, damit Dateihandles, temporäre Daten und andere Ressourcen sofort freigegeben werden.

Das folgende JavaScript‑Beispiel zeigt, wie man eine Präsentation öffnet und die Folienanzahl ermittelt:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungspasswort verschlüsselt den Inhalt der Präsentation. Um die gesamte Präsentation zu laden, übergeben Sie das richtige Passwort an [LoadOptions.setPassword](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setPassword) und stellen Sie die Optionen dem Konstruktor [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) zur Verfügung. Das Laden schlägt fehl, wenn das Passwort fehlt oder falsch ist.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Für Passwort‑Erkennung, Validierung und Verschlüsselungs‑Workflows siehe [Password‑Protect Presentations](/slides/de/nodejs-java/password-protected-presentation/). Wenn eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteigenschaften gespeichert wurde, können diese Eigenschaften ohne Passwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/nodejs-java/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) liefert Optionen, die steuern, wie Aspose.Slides große binäre Objekte wie Bilder, Audio und Video behandelt. Sie können die Quelldatei gesperrt halten, temporäre Dateien zulassen und die Menge der im Speicher gehaltenen BLOB‑Daten begrenzen.

Der folgende JavaScript‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Mit [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) bleibt die Quelldatei gesperrt, bis die Präsentationsinstanz freigegeben wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange diese Instanz aktiv ist.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Bei großen Präsentationen ist ein Dateipfad daher im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/nodejs-java/manage-blob/) für zusätzliche Speicher‑ und Speicherverwaltungs‑Optionen.
{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) akzeptiert eine Implementierung von [IResourceLoadingCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iresourceloadingcallback/). Der Callback kann Ersatzdaten bereitstellen, eine Ressource umleiten, den Standard‑Lader verwenden oder die Ressource überspringen. Dies ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemäß anwendungsspezifischen Sicherheits‑ oder Speicherregeln aufgelöst werden müssen.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benötigt oder nicht behalten möchte. Beispiele sind:

- VBA‑Projekte, verfügbar über [Presentation.getVbaProject](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getVbaProject);
- eingebettete OLE‑Daten, verfügbar über [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑Steuerungsdaten, verfügbar über [Control.getActiveXControlBinary](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Setzen Sie [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) auf `true`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu erhalten.

Diese Option verringert das Risiko unerwünschter eingebetteter Payloads, ist jedoch kein vollständiges Malware‑Erkennungs‑ oder Inhalts‑Sanitärsystem.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wie kann ich feststellen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parsing‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler getrennt von einem falschen‑Passwort‑Fehler, damit die Anwendung die Ursache genau melden kann.

**Was passiert, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann weiterhin geladen werden, aber Rendering und Export können Schriftarten substituieren. Sie können [configure font substitution](/slides/de/nodejs-java/font-substitution/) oder [provide custom fonts](/slides/de/nodejs-java/custom-font/) nutzen, um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch deren eingebettete Medien?**

Eingebettetes Audio und Video werden über das Präsentations‑Objektmodell verfügbar. Externe Ressourcen werden gemäß dem konfigurierten Ressourcen‑Ladeverhalten aufgelöst und können nicht verfügbar sein, wenn ihre Standorte nicht zugänglich sind.