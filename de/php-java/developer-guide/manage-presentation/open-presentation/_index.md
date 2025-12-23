---
title: Präsentationen in PHP öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/php-java/open-presentation/
keywords:
- PowerPoint öffnen
- OpenDocument öffnen
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
- PHP
- Aspose.Slides
description: "Öffnen Sie PowerPoint (.pptx, .ppt) und OpenDocument (.odp) Präsentationen mühelos mit Aspose.Slides für PHP über Java — schnell, zuverlässig, voll funktionsfähig."
---

## **Übersicht**

Neben dem Erstellen von PowerPoint‑Präsentationen von Grund auf ermöglicht Aspose.Slides auch das Öffnen vorhandener Präsentationen. Nach dem Laden einer Präsentation können Sie Informationen darüber abrufen, Folgeninhalt bearbeiten, neue Folien hinzufügen, vorhandene Folien entfernen und vieles mehr.

## **Präsentationen öffnen**

Um eine vorhandene Präsentation zu öffnen, instanziieren Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse und übergeben den Dateipfad an ihren Konstruktor.

Das folgende PHP‑Beispiel zeigt, wie Sie eine Präsentation öffnen und die Folienanzahl ermitteln:
```php
// Instanziieren Sie die Presentation-Klasse und übergeben Sie einen Dateipfad an ihren Konstruktor.
$presentation = new Presentation("Sample.pptx");
try {
    // Geben Sie die Gesamtzahl der Folien in der Präsentation aus.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```


## **Passwortgeschützte Präsentationen öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, übergeben Sie das Passwort über die [setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword)-Methode der [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)-Klasse, um sie zu entschlüsseln und zu laden. Der folgende PHP‑Code demonstriert diesen Vorgang:
```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Führen Sie Vorgänge an der entschlüsselten Präsentation aus.
} finally {
    $presentation->dispose();
}
```


## **Große Präsentationen öffnen**

Aspose.Slides stellt Optionen bereit – insbesondere die [getBlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getBlobManagementOptions)-Methode in der [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)-Klasse – um Ihnen beim Laden großer Präsentationen zu helfen.

Der folgende PHP‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):
```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // The large presentation has been loaded and can be used, while memory consumption remains low.

    // Make changes to the presentation.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Save the presentation to another file. Memory consumption remains low during this operation.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// It is OK to do it here. The source file is no longer locked by the presentation object.
unlink($filePath);
```



{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Arbeiten mit Streams zu umgehen, kann Aspose.Slides den Inhalt eines Streams kopieren. Das Laden einer großen Präsentation aus einem Stream führt dazu, dass die Präsentation kopiert wird, was das Laden verlangsamen kann. Daher empfehlen wir, wenn Sie eine große Präsentation laden müssen, stark, den Dateipfad der Präsentation statt eines Streams zu verwenden.

Wenn Sie eine Präsentation erstellen, die große Objekte (Video, Audio, hochauflösende Bilder usw.) enthält, können Sie [BLOB management](/slides/de/php-java/manage-blob/) nutzen, um den Speicherverbrauch zu reduzieren.

{{%/alert %}}

## **Externe Ressourcen steuern**

Aspose.Slides stellt das [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/)‑Interface bereit, mit dem Sie externe Ressourcen verwalten können. Der folgende PHP‑Code zeigt, wie das `IResourceLoadingCallback`‑Interface verwendet wird:
```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Ein Ersatzbild laden.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Eine Ersatz-URL setzen.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Alle anderen Bilder überspringen.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```


## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine PowerPoint‑Präsentation kann folgende Arten eingebetteter Binärobjekte enthalten:

- VBA‑Projekt (zugänglich über [Presentation.getVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject));
- OLE‑Objekt‑eingebettete Daten (zugänglich über [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ActiveX‑Steuerungs‑Binärdaten (zugänglich über [Control.getActiveXControlBinary](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getActiveXControlBinary)).

Durch die Verwendung der [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects)-Methode können Sie eine Präsentation ohne eingebettete Binärobjekte laden.

Diese Methode ist nützlich, um potenziell schädliche Binärinhalte zu entfernen. Der folgende PHP‑Code demonstriert, wie Sie eine Präsentation ohne eingebettete Binärinhalte laden:
```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Vorgänge an der Präsentation ausführen.
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Wie erkenne ich, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Während des Ladens erhalten Sie eine Parsing‑/Formatvalidierungs‑Ausnahme. Solche Fehler erwähnen häufig eine ungültige ZIP‑Struktur oder beschädigte PowerPoint‑Datensätze.

**Was passiert, wenn beim Öffnen erforderliche Schriften fehlen?**

Die Datei wird geöffnet, aber das spätere [Rendering/Export](/slides/de/php-java/convert-presentation/) kann Schriften ersetzen. [Schrift‑Substitutionen konfigurieren](/slides/de/php-java/font-substitution/) oder [erforderliche Schriften hinzufügen](/slides/de/php-java/custom-font/) in der Laufzeitumgebung.

**Wie wird mit eingebetteten Medien (Video/Audio) beim Öffnen umgegangen?**

Sie werden als Präsentationsressourcen verfügbar. Wenn Medien über externe Pfade referenziert werden, stellen Sie sicher, dass diese Pfade in Ihrer Umgebung erreichbar sind; andernfalls kann das [Rendering/Export](/slides/de/php-java/convert-presentation/) die Medien weglassen.