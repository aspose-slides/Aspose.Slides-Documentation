---
title: Präsentationen in PHP öffnen
linktitle: Präsentation öffnen
type: docs
weight: 20
url: /de/php-java/open-presentation/
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
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen in PHP öffnen, Öffnungskennwörter bereitstellen, das Laden von Ressourcen steuern und den Speicherverbrauch mit Aspose.Slides für PHP über Java reduzieren."
---
## **Einführung**

[Aspose.Slides für PHP über Java](https://products.aspose.com/slides/de/php-java/) kann PowerPoint- und OpenDocument‑Präsentationen aus Dateien und Streams laden. Nachdem eine Präsentation geladen wurde, können Sie deren Struktur prüfen, Folien bearbeiten, Ressourcen verwalten und sie im Originalformat oder in einem anderen unterstützten Format speichern.

Das Ladeverhalten kann über die Klasse [LoadOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/) angepasst werden. Sie können beispielsweise ein Öffnungskennwort angeben, große Binärobjekte außerhalb des Java‑Heap‑Speichers behalten, externe Ressourcen steuern oder eingebettete Binärdaten weglassen.

## **Präsentationen öffnen**

Nach dem Laden einer Datei oder eines Streams können Sie das ursprüngliche Präsentationsformat bestimmen, um zu entscheiden, wie Ihre Anwendung damit umgeht.

Um eine vorhandene Präsentation zu öffnen, übergeben Sie deren Dateipfad an den [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Konstruktor. Entsorgen Sie die Präsentation nach der Verwendung, damit Dateihandles, temporäre Daten und weitere Ressourcen umgehend freigegeben werden.

Das folgende PHP‑Beispiel zeigt, wie eine Präsentation geöffnet und die Folienanzahl ermittelt wird:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Passwortgeschützte Präsentationen öffnen**

Ein Öffnungskennwort verschlüsselt den Präsentationsinhalt. Um die gesamte Präsentation zu laden, übergeben Sie das korrekte Kennwort an [LoadOptions::setPassword](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setPassword) und geben die Optionen dem [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)‑Konstruktor. Das Laden schlägt fehl, wenn das Kennwort fehlt oder falsch ist.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Für Kennworterkennung, -validierung und Verschlüsselungs‑Workflows siehe [Password‑Protect Presentations](/slides/de/php-java/password-protected-presentation/). Wurde eine verschlüsselte Präsentation bewusst mit öffentlichen Dokumenteigenschaften gespeichert, können diese ohne Kennwort gelesen werden; siehe [Manage Presentation Properties](/slides/de/php-java/presentation-properties/).

## **Große Präsentationen öffnen**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) gibt Optionen zurück, die steuern, wie Aspose.Slides große binäre Objekte wie Bilder, Audio und Video behandelt. Sie können die Quelldatei gesperrt lassen, temporäre Dateien zulassen und die Menge der im Speicher gehaltenen BLOB‑Daten begrenzen.

Der folgende PHP‑Code demonstriert das Laden einer großen Präsentation (z. B. 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Hinweis" %}}

Mit [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) bleibt die Quelldatei gesperrt, bis die Präsentationsinstanz entsorgt wird. Verschieben, überschreiben oder löschen Sie die Quelldatei nicht, solange diese Instanz aktiv ist.

Aspose.Slides kann beim Laden den Inhalt eines Eingabestreams kopieren. Für große Präsentationen ist ein Dateipfad daher im Allgemeinen effizienter als ein Stream. Siehe [Manage BLOBs](/slides/de/php-java/manage-blob/) für zusätzliche Speicher‑ und Speicherverwaltungsoptionen.

{{% /alert %}}

## **Externe Ressourcen steuern**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) akzeptiert eine Implementierung des Java‑Interfaces [IResourceLoadingCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/iresourceloadingcallback/) über PHP/Java‑Bridge. Der Callback kann Ersatzdaten bereitstellen, eine Ressource umleiten, den Standard‑Loader verwenden oder die Ressource überspringen. Das ist nützlich, wenn Präsentationen externe Bilder enthalten, die gemäß anwendungsspezifischer Sicherheits‑ oder Speicher‑richtlinien aufgelöst werden müssen.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Präsentationen ohne eingebettete Binärobjekte laden**

Eine Präsentation kann eingebettete Binärdaten enthalten, die eine Anwendung nicht benötigt oder nicht behalten möchte. Beispiele sind:

- VBA‑Projekte, verfügbar über [Presentation::getVbaProject](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getVbaProject);
- eingebettete OLE‑Daten, verfügbar über [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/de/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX‑Steuerungsdaten, verfügbar über [Control::getActiveXControlBinary](https://reference.aspose.com/slides/de/php-java/aspose.slides/control/#getActiveXControlBinary).

Setzen Sie [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/de/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) auf `true`, um diese Binärdaten beim Laden zu entfernen. Speichern Sie die geladene Präsentation, um das bereinigte Ergebnis zu erhalten.

Diese Option reduziert das Risiko unerwünschter eingebetteter Nutzdaten, stellt jedoch kein vollständiges **Malware**‑‑‑Erkennungssystem dar.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wie kann ich feststellen, dass eine Datei beschädigt ist und nicht geöffnet werden kann?**

Aspose.Slides wirft beim Laden eine Parsing‑ oder Format‑Ausnahme. Behandeln Sie diesen Fehler getrennt von einem falschen Kennwort‑Fehler, damit die Anwendung die Ursache korrekt melden kann.

**Was passiert, wenn erforderliche Schriftarten fehlen?**

Die Präsentation kann weiterhin geladen werden, jedoch können beim Rendern und Export Schriftarten substituiert werden. Sie können die Schriftarten‑Substitution konfigurieren oder eigene Schriftarten bereitstellen, um die Ausgabe vorhersehbarer zu machen.

**Lädt das Laden einer Präsentation auch deren eingebettete Medien?**

Eingebettete Audio‑ und Videodateien stehen über das Präsentations‑Objektmodell zur Verfügung. Externe Ressourcen werden gemäß dem konfigurierten Ressourcen‑Ladeverhalten aufgelöst und können nicht verfügbar sein, wenn ihre Speicherorte nicht erreichbar sind.