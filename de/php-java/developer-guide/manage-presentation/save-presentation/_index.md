---
title: Präsentation speichern
type: docs
weight: 80
url: /php-java/save-presentation/
---

## **Überblick**
{{% alert color="primary" %}} 

[Präsentation öffnen](/slides/php-java/open-presentation/) beschreibt, wie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse verwendet wird, um eine Präsentation zu öffnen. Dieser Artikel erklärt, wie man Präsentationen erstellt und speichert.

{{% /alert %}} 

Die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse enthält den Inhalt einer Präsentation. Ob Sie eine Präsentation von Grund auf neu erstellen oder eine bestehende ändern, am Ende möchten Sie die Präsentation speichern. Mit Aspose.Slides für PHP über Java kann sie als **Datei** oder **Stream** gespeichert werden. Dieser Artikel erklärt, wie man eine Präsentation auf verschiedene Arten speichert:

## **Präsentation in eine Datei speichern**
Um eine Präsentation in eine Datei zu speichern, rufen Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) Methode auf. Übergeben Sie einfach den Dateinamen und [**SaveFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveFormat) an die [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) Methode.

Die folgenden Beispiele zeigen, wie man eine Präsentation mit Aspose.Slides für PHP über Java speichert.

```php
  # Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei repräsentiert
  $pres = new Presentation();
  try {
    # ...hier arbeiten...
    # Speichern Sie Ihre Präsentation in einer Datei
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Präsentation in einen Stream speichern**
Es ist möglich, eine Präsentation in einen Stream zu speichern, indem man einen Ausgabestrom an die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.io.OutputStream-int-) Methode übergibt. Es gibt viele Arten von Streams, in die eine Präsentation gespeichert werden kann. Im folgenden Beispiel haben wir eine neue Präsentationsdatei erstellt, Text in eine Form hinzugefügt und die Präsentation in den Stream gespeichert.

```php
  # Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei repräsentiert
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 200, 200);
    # Text zur Form hinzufügen
    $shape->getTextFrame()->setText("Dieses Beispiel zeigt, wie man eine PowerPoint-Datei erstellt und sie in einen Stream speichert.");
    $os = new Java("java.io.FileOutputStream", "Save_As_Stream_out.pptx");
    $pres->save($os, SaveFormat::Pptx);
    $os->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Präsentation mit vordefiniertem Ansichtstyp speichern**
Aspose.Slides für PHP über Java bietet die Möglichkeit, den Ansichtstyp für die generierte Präsentation festzulegen, wenn sie in PowerPoint über die [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) Klasse geöffnet wird. Die [**setLastView**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#setLastView-int-) Eigenschaft wird verwendet, um den Ansichtstyp mithilfe des [**ViewType**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewType) Enumerators festzulegen.

```php
  # Öffnen der Präsentationsdatei
  $pres = new Presentation();
  try {
    # Einstellung des Ansichtstyps
    $pres->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Speichern der Präsentation
    $pres->save("newDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Präsentationen im strengen Office Open XML-Format speichern**
Aspose.Slides ermöglicht es Ihnen, die Präsentation im strengen Office Open XML-Format zu speichern. Zu diesem Zweck bietet es die [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) Klasse, in der Sie die Conformance Eigenschaft beim Speichern der Präsentationsdatei festlegen können. Wenn Sie ihren Wert auf [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict) festlegen, wird die Ausgabedatei der Präsentation im strengen Open XML-Format gespeichert.

Der folgende Beispielcode erstellt eine Präsentation und speichert sie im strengen Office Open XML-Format. Beim Aufrufen der [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode für die Präsentation wird das [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) Objekt mit der Conformance-Eigenschaft, die auf [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict) eingestellt ist, übergeben.

```php
  # Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine Autohilfe vom Typ Linie hinzu
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    #Setzen Sie die Speicheroptionen für das strenge Office Open XML-Format
    $options = new PptxOptions();
    $options->setConformance(Conformance->Iso29500_2008_Strict);
    # Speichern Sie Ihre Präsentation in einer Datei
    $pres->save("demoPass.pptx", SaveFormat::Pptx, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Präsentationen im Office Open XML-Format im Zip64-Modus speichern**
Eine Office Open XML-Datei ist ein ZIP-Archiv, das eine Grenze von 4 GB (2^32 Bytes) für die unkomprimierte Dateigröße, die komprimierte Dateigröße und die Gesamtgröße des Archivs sowie eine Grenze von 65.535 (2^16-1) Dateien im Archiv hat. Die ZIP64-Format-Erweiterungen erhöhen die Grenzen auf 2^64.

Die neue [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/) Eigenschaft ermöglicht es Ihnen zu entscheiden, wann die ZIP64-Format-Erweiterungen für die gespeicherte Office Open XML-Datei verwendet werden sollen.

Diese Eigenschaft bietet die folgenden Modi:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) bedeutet, dass die ZIP64-Format-Erweiterungen nur verwendet werden, wenn die Präsentation außerhalb der oben genannten Einschränkungen fällt. Dies ist der Standardmodus.
- [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) bedeutet, dass ZIP64-Format-Erweiterungen nicht verwendet werden.
- [Zip64Mode.Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) bedeutet, dass ZIP64-Format-Erweiterungen immer verwendet werden.

Der folgende Code zeigt, wie man die Präsentation im PPTX-Format mit ZIP64-Format-Erweiterungen speichert:

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $pptxOptions = new PptxOptions();
    $pptxOptions->setZip64Mode(Zip64Mode::Always);
    
    $pres->save("Sample-zip64.pptx", SaveFormat::Pptx, $pptxOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="HINWEIS" color="warning" %}}

Das Speichern im Zip64Mode.Never-Modus löst eine [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/) aus, wenn die Präsentation nicht im ZIP32-Format gespeichert werden kann.

{{% /alert %}}

## **Speichern von Fortschrittsaktualisierungen in Prozent**
Das neue [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) Interface wurde zum [**ISaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISaveOptions) Interface und zur [**SaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveOptions) abstrakten Klasse hinzugefügt. Das [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) Interface stellt ein Callback-Objekt zur Verfügung, um Fortschrittsaktualisierungen in Prozent zu speichern.

Die folgenden Codebeispiele zeigen, wie das [IProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) Interface verwendet wird:

```php
  class ExportProgressHandler {
    function reporting($progressValue) {
      # Verwenden Sie den Fortschrittsprozentwert hier
      $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
      echo($progress . "% Datei konvertiert");
    }
  }

  # Öffnen der Präsentationsdatei
  $pres = new Presentation("ConvertToPDF.pptx");
  try {
    $saveOptions = new PdfOptions();
    $progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));
    $saveOptions->setProgressCallback($progressHandler);
    $pres->save("ConvertToPDF.pdf", SaveFormat::Pdf, $saveOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="Info" color="info" %}}

Mit seiner eigenen API hat Aspose eine [kostenlose PowerPoint Splitter-App](https://products.aspose.app/slides/splitter) entwickelt, die es den Benutzern ermöglicht, ihre Präsentationen in mehrere Dateien zu splitten. Grundsätzlich speichert die App ausgewählte Folien aus einer gegebenen Präsentation als neue PowerPoint (PPTX oder PPT) Dateien. 

{{% /alert %}}