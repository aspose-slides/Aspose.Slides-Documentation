---
title: Open Presentations in PHP
linktitle: Open Presentation
type: docs
weight: 20
url: /php-java/open-presentation/
keywords:
- open PowerPoint
- open presentation
- open PPTX
- open PPT
- open ODP
- load presentation
- load PPTX
- load PPT
- load ODP
- protected presentation
- large presentation
- external resource
- binary object
- PHP
- Aspose.Slides
description: "Learn how to open PowerPoint and OpenDocument presentations in PHP, supply opening passwords, control resource loading, and reduce memory use with Aspose.Slides for PHP via Java."
---

## **Introduction**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) can load PowerPoint and OpenDocument presentations from files and streams. After a presentation is loaded, you can inspect its structure, edit slides, manage resources, and save it in the original or another supported format.

Loading behavior can be customized through the [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) class. For example, you can supply an opening password, keep large binary objects outside Java heap memory, control external resources, or omit embedded binary data.

## **Open Presentations**

To open an existing presentation, pass its file path to the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) constructor. Dispose the presentation after use so that file handles, temporary data, and other resources are released promptly.

The following PHP example shows how to open a presentation and get its slide count:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Open Password-Protected Presentations**

An opening password encrypts presentation content. To load the complete presentation, pass the correct password to [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) and provide the options to the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) constructor. Loading fails when the password is missing or incorrect.

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

For password detection, validation, and encryption workflows, see [Password-Protect Presentations](/slides/php-java/password-protected-presentation/). If an encrypted presentation was deliberately saved with public document properties, those properties can be read without a password; see [Manage Presentation Properties](/slides/php-java/presentation-properties/).

## **Open Large Presentations**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) returns options that control how Aspose.Slides handles binary large objects such as images, audio, and video. You can keep the source file locked, allow temporary files, and limit the amount of BLOB data retained in memory.

The following PHP code demonstrates loading a large presentation (for example, 2 GB):

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

{{% alert color="info" title="Note" %}}

With [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), the source file remains locked until the presentation instance is disposed. Do not move, overwrite, or delete the source file while that instance is alive.

Aspose.Slides may copy the contents of an input stream while loading it. For large presentations, a file path is therefore generally more efficient than a stream. See [Manage BLOBs](/slides/php-java/manage-blob/) for additional storage and memory-management options.

{{% /alert %}}

## **Control External Resources**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) accepts an implementation of the Java [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) interface through PHP/Java Bridge. The callback can supply replacement data, redirect a resource, use the default loader, or skip the resource. This is useful when presentations contain external images that must be resolved according to application-specific security or storage rules.

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

## **Load Presentations without Embedded Binary Objects**

A presentation may contain embedded binary data that an application does not need or does not want to retain. Examples include:

- VBA projects, available through [Presentation::getVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject);
- embedded OLE data, available through [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ActiveX control data, available through [Control::getActiveXControlBinary](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getActiveXControlBinary).

Set [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) to `true` to remove this binary data while loading. Save the loaded presentation to persist the sanitized result.

This option reduces exposure to unwanted embedded payloads, but it is not a complete malware-detection or content-sanitization system.

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

**How can I tell that a file is corrupted and cannot be opened?**

Aspose.Slides throws a parsing or format exception during loading. Handle that failure separately from an incorrect-password error so that the application can report the cause accurately.

**What happens if required fonts are missing?**

The presentation can still load, but rendering and export may substitute fonts. You can [configure font substitution](/slides/php-java/font-substitution/) or [provide custom fonts](/slides/php-java/custom-font/) to make output more predictable.

**Does loading a presentation also load its embedded media?**

Embedded audio and video become available through the presentation object model. External resources are resolved according to the configured resource-loading behavior and may be unavailable if their locations cannot be accessed.
