---
title: Präsentation in JavaScript öffnen
linktitle: Präsentationen öffnen
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
- Binärobjekt
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für Node.js öffnen - schnell, zuverlässig, voll funktionsfähig."
---

## **Überblick**

Neben dem Erstellen von PowerPoint‑Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nach dem Laden einer Präsentation können Sie Informationen darüber abrufen, Folieninhalte bearbeiten, neue Folien hinzufügen, vorhandene entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse und übergeben den Dateipfad an deren Konstruktor.

Das folgende JavaScript‑Beispiel zeigt, wie man eine Präsentation öffnet und die Folienzahl ermittelt:
```js
// Instanziieren Sie die Presentation‑Klasse und übergeben Sie einen Dateipfad an ihren Konstruktor.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setPassword)‑Methode der [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)‑Klasse, um sie zu entschlüsseln und zu laden. Der folgende JavaScript‑Code demonstriert diesen Vorgang:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Führen Sie Operationen an der entschlüsselten Präsentation durch.
} finally {
    presentation.dispose();
}
```


## **Große Präsentationen öffnen**

Aspose.Slides stellt Optionen bereit – insbesondere die [getBlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions)‑Methode in der [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)‑Klasse –, um das Laden großer Präsentationen zu unterstützen.

Der folgende JavaScript‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):
```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Wählen Sie das KeepLocked-Verhalten – die Präsentationsdatei bleibt für die Lebensdauer der
// Presentation-Instanz gesperrt, muss jedoch nicht in den Speicher geladen oder in eine temporäre Datei kopiert werden.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Die große Präsentation wurde geladen und kann verwendet werden, während der Speicherverbrauch gering bleibt.
    
    // Änderungen an der Präsentation vornehmen.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Speichern Sie die Präsentation in eine andere Datei. Der Speicherverbrauch bleibt während dieses Vorgangs gering.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Nicht tun! Es wird eine I/O-Ausnahme ausgelöst, weil die Datei gesperrt ist, bis das Präsentationsobjekt freigegeben wird.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Es ist in Ordnung, dies hier zu tun. Die Quelldatei ist nicht mehr von dem Präsentationsobjekt gesperrt.
fs.unlinkSync(filePath);
```


{{% alert color="info" title="Info" %}}
Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird und das Laden verlangsamt werden kann. Daher empfehlen wir dringend, beim Laden einer großen Präsentation den Dateipfad der Präsentation anstelle eines Streams zu verwenden.

Beim Erstellen einer Präsentation, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie [BLOB management](/slides/de/nodejs-java/manage-blob/) nutzen, um den Speicherverbrauch zu reduzieren.
{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt das Interface [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) zur Verfügung, mit dem Sie externe Ressourcen verwalten können. Der folgende JavaScript‑Code zeigt, wie das Interface `IResourceLoadingCallback` verwendet wird:
```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Ein Ersatzbild laden.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Eine Ersatz-URL festlegen.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Alle anderen Bilder überspringen.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann die folgenden Arten eingebetteter Binärobjekte enthalten:

- VBA‑Projekt (zugänglich über [Presentation.getVbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [Control.getActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Mit der Methode [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) können Sie eine Präsentation ohne eingebettete Binärobjekte laden.

Diese Methode ist nützlich, um potenziell schädliche Binärinhalte zu entfernen. Der folgende JavaScript‑Code demonstriert, wie man eine Präsentation ohne eingebettete Binärinhalte lädt:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Operationen an der Präsentation durchführen.
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Wie kann ich erkennen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Beim Laden erhalten Sie eine Parsing‑/Format‑Validierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriftarten fehlen?**

Die Datei wird geöffnet, aber beim späteren [rendering/export](/slides/de/nodejs-java/convert-presentation/) können Schriftarten ersetzt werden. [Configure font substitutions](/slides/de/nodejs-java/font-substitution/) oder [add the required fonts](/slides/de/nodejs-java/custom-font/) zur Laufzeitumgebung hinzufügen.

**Wie sieht es mit eingebetteten Medien (Video/Audio) beim Öffnen aus?**

Sie stehen als Präsentationsressourcen zur Verfügung. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung zugänglich sind; andernfalls können beim [rendering/export](/slides/de/nodejs-java/convert-presentation/) Medien weggelassen werden.