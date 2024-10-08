---
title: Präsentation Öffnen
linktitle: Präsentation Öffnen
type: docs
weight: 20
url: /de/php-java/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Präsentation Öffnen, Präsentation Laden, Java"
description: "Öffnen oder Laden der Präsentation PPT, PPTX, ODP"
---

Neben der Erstellung von PowerPoint-Präsentationen von Grund auf ermöglicht es Aspose.Slides, bestehende Präsentationen zu öffnen. Nachdem Sie eine Präsentation geladen haben, können Sie Informationen über die Präsentation abrufen, die Präsentation bearbeiten (Inhalte auf den Folien), neue Folien hinzufügen oder bestehende entfernen usw. 

## Präsentation Öffnen

Um eine vorhandene Präsentation zu öffnen, müssen Sie einfach die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse instanziieren und den Dateipfad (der Präsentation, die Sie öffnen möchten) an ihren Konstruktor übergeben.

Dieser PHP-Code zeigt, wie man eine Präsentation öffnet und die Anzahl der Folien herausfindet:

```php
  # Instanziiert die Presentation-Klasse und übergibt den Dateipfad an ihren Konstruktor
  $pres = new Presentation("Presentation.pptx");
  try {
    # Gibt die Gesamtzahl der Folien in der Präsentation aus
    echo($pres->getSlides()->size());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Passwortgeschützte Präsentation Öffnen**

Wenn Sie eine passwortgeschützte Präsentation öffnen müssen, können Sie das Passwort über die [Password](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getPassword--) Eigenschaft (aus der [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) Klasse) übergeben, um die Präsentation zu entschlüsseln und sie zu laden. Dieser PHP-Code demonstriert die Operation:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("YOUR_PASSWORD");
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
    # Führen Sie einige Arbeiten mit der entschlüsselten Präsentation durch
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Große Präsentation Öffnen

Aspose.Slides bietet Optionen (insbesondere die [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) Eigenschaft) unter der [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) Klasse, um Ihnen das Laden großer Präsentationen zu ermöglichen.

Dieser Java-Code demonstriert eine Operation, bei der eine große Präsentation (sagen wir, 2 GB groß) geladen wird:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(0);
  $pres = new Presentation("veryLargePresentation.pptx", $loadOptions);
  try {
    # Die große Präsentation wurde geladen und kann verwendet werden, aber der Speicherverbrauch ist weiterhin niedrig.
    # Änderungen an der Präsentation vornehmen.
    $pres->getSlides()->get_Item(0)->setName("Sehr große Präsentation");
    # Die Präsentation wird in die andere Datei gespeichert. Der Speicherverbrauch bleibt während der Operation niedrig
    $pres->save("veryLargePresentation-copy.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="info" title="Info" %}}

Um bestimmte Einschränkungen beim Interagieren mit einem Stream zu umgehen, kann Aspose.Slides den Inhalt des Streams kopieren. Das Laden einer großen Präsentation über ihren Stream führt dazu, dass die Inhalte der Präsentation kopiert werden und das Laden verlangsamt wird. Daher empfehlen wir Ihnen dringend, wenn Sie eine große Präsentation laden möchten, den Dateipfad der Präsentation und nicht ihren Stream zu verwenden.

Wenn Sie eine Präsentation erstellen möchten, die große Objekte (Video, Audio, große Bilder usw.) enthält, können Sie die [Blob-Funktionalität](https://docs.aspose.com/slides/php-java/manage-blob/) verwenden, um den Speicherverbrauch zu reduzieren.

{{%/alert %}} 

## Präsentation Laden

Aspose.Slides bietet [IResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/iresourceloadingcallback/) mit einer einzigen Methode, um Ihnen die Verwaltung externer Ressourcen zu ermöglichen. Dieser PHP-Code zeigt Ihnen, wie Sie das `IResourceLoadingCallback`-Interface verwenden:

```php

class ImageLoadingHandler {
    function resourceLoading($args) {
      if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
        # Lädt ein Ersatzbild
        $file = new Java("java.io.File", "aspose-logo.jpg");
        $Array = new JavaClass("java.lang.reflect.Array");
        $Byte = new JavaClass("java.lang.Byte");
        $imageBytes = $Array->newInstance($Byte, $Array->getLength($file));
        try {
            $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
            $dis->readFully($imageBytes);
        } finally {
            if (!java_is_null($dis)) $dis->close();
        }
          $args->setData($imageBytes);
          return ResourceLoadingAction::UserProvided;
      } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
        # Setzt die Ersatz-URL
        $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
        return ResourceLoadingAction::Default;
      }
      # überspringt alle anderen Bilder
      return ResourceLoadingAction::Skip;
    }
  }

  $opts = new LoadOptions();
  $loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));
  $opts->setResourceLoadingCallback($loadingHandler);
  $pres = new Presentation("presentation.pptx", $opts);
```

## Präsentation Laden, ohne Eingebettete Binärobjekte

Die PowerPoint-Präsentation kann die folgenden Arten von eingebetteten binären Objekten enthalten:

- VBA-Projekt ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- OLE-Objekt eingebettete Daten ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveX-Steuerungsbinärdaten ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

Mit der [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) Eigenschaft können Sie die Präsentation ohne irgendwelche eingebetteten binären Objekte laden.

Diese Eigenschaft kann nützlich sein, um potenziell schädliche binäre Inhalte zu entfernen.

Der Code demonstriert, wie man eine Präsentation ohne Malware-Inhalte lädt und speichert:

```java
  $loadOptions = new LoadOptions();
  $loadOptions->setDeleteEmbeddedBinaryObjects(true);

  $pres = new Presentation("malware.ppt", $loadOptions);
  try {
    $pres->save("clean.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null(pres)) { 
      $pres->dispose();
    }
  }
```

## Präsentation Öffnen und Speichern

Schritte zum Öffnen und Speichern einer Präsentation:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse und übergeben Sie die Datei, die Sie öffnen möchten.
2. Speichern Sie die Präsentation.  

```php
  # Instanziiert ein Presentation-Objekt, das eine PPT-Datei darstellt
  $pres = new Presentation();
  try {
    # ...arbeiten Sie hier...
    # Speichert Ihre Präsentation in einer Datei
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```