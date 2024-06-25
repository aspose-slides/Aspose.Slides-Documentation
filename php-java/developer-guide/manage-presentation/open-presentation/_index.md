---
title: Open Presentation
linktitle: Open Presentation
type: docs
weight: 20
url: /php-java/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, Open Presentation, Load Presentation, Java"
description: "Open or load Presentation PPT, PPTX, ODP "
---

Besides creating PowerPoint presentations from scratch, Aspose.Slides allows you to open existing presentations. After you load a presentation, you can get information about the presentation, edit the presentation (content on its slides), add new slides or remove existing ones, etc. 

## Open Presentation

To open an existing presentation, you simply have to instantiate the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class and pass the file path (of the presentation you want to open) to its constructor.

This PHP code shows you how to open a presentation and also find out the number of slides it contains:

```php
  // Instantiates the Presentation class and passes the file path to its constructor
  $pres = new Presentation("Presentation.pptx");
  try {
    // Prints the total number of slides present in the presentation
    echo($pres->getSlides()->size());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Open Password Protected Presentation**

When you have to open a password-protected presentation, you can pass the password through the [Password](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getPassword--) property (from the [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) class) to decrypt the presentation and load the presentation. This PHP code demonstrates the operation:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("YOUR_PASSWORD");
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
    // Do some work with the decrypted presentation
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Open Large Presentation

Aspose.Slides provides options (the [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-) property in particular) under the [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) class to allow you to load large presentations.

This Java demonstrates an operation in which a large presentation (say 2GB in size) is loaded:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(0);
  $pres = new Presentation("veryLargePresentation.pptx", $loadOptions);
  try {
    // The large presentation has been loaded and can be used, but the memory consumption is still low.
    // makes changes to the presentation.
    $pres->getSlides()->get_Item(0)->setName("Very large presentation");
    // The presentation will be saved to the other file. The memory consumption stays low during the operation
    $pres->save("veryLargePresentation-copy.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="info" title="Info" %}}

To circumvent certain limitations when interacting with a stream, Aspose.Slides may copy the stream's content. Loading a large presentation through its stream will result in the copying of the presentation's contents and cause slow loading. Therefore, when you intend to load a large presentation, we strongly recommend that you use the presentation file path and not its stream.

When you want to create a presentation that contains large objects (video, audio, big images, etc.), you can use the [Blob facility](https://docs.aspose.com/slides/php-java/manage-blob/) to reduce memory consumption.

{{%/alert %}} 


## Load Presentation

Aspose.Slides provides [IResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/iresourceloadingcallback/) with a single method to allow you to manage external resources. This PHP code shows you how to use the `IResourceLoadingCallback` interface:

```php
  $opts = new LoadOptions();
  $opts->setResourceLoadingCallback(new ImageLoadingHandler());
  $pres = new Presentation("presentation.pptx", $opts);

```

```php
  class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
      if ($args->getOriginalUri()->endsWith(".jpg")) {
        // loads substitute image
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
          return ResourceLoadingAction->UserProvided;
        } catch (JavaException $ex) {
          return ResourceLoadingAction->Skip;
        } catch (JavaException $ex) {
          $ex->printStackTrace();
        }
      } else if ($args->getOriginalUri()->endsWith(".png")) {
        // sets substitute url
        $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
        return ResourceLoadingAction->Default;
      }
      // skips all other images
      return ResourceLoadingAction->Skip;
    }
  }
```

<h2>Open and Save Presentation</h2>

<a name="Java-open-save-presentation"><strong>Steps: Open and Save Presentation </strong></a>

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class and pass the file you want to open.
2. Save the presentation.  

```php
  // Instantiates a Presentation object that represents a PPT file
  $pres = new Presentation();
  try {
    // ...do some work here...
    // Saves your presentation to a file
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
