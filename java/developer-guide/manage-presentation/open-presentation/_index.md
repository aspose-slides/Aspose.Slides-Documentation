---
title: Open Presentation
type: docs
weight: 20
url: /java/open-presentation/
---

## **Overview**
{{% alert color="primary" %}} 

Using Aspose.Slides for Java, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

{{% /alert %}} 

## **Open Presentation**
Aspose.Slides for Java provides [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class to create its object based on an existing presentation. In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class. After the file is opened, we get the total number of slides present in the presentation to print on the screen.

```java
// Opening the presentation file by passing the file path to the constructor of Presentation class
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Printing the total number of slides present in the presentation
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Open Password Protected Presentation**
Aspose.Slides for Java provides a facility to open password-protected presentation using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we are accessing the password-protected presentation. We will use [LoadOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/LoadOptionsOptions) class object to set the access password and then will use [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class to open a presentation.

```java
// Creating instance of load options to set the presentation access password
LoadOptions loadOptions = new LoadOptions();

// Setting the access password
loadOptions.setPassword("pass");

// Opening the presentation file by passing the file path and load
// options to the constructor of Presentation class
Presentation pres = new Presentation("demoPassDocument.pptx", loadOptions);
try {
    // Printing the total number of slides present in the presentation
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Open Large Presentation**
Aspose.Slides for Java provides a facility to open very large presentations using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // the huge presentation is loaded and ready to use, but the memory consumption is still low.
    // make any changes to the presentation.
    pres.getSlides().get_Item(0).setName("Very large presentation");

    // presentation will be saved to the other file, the memory consumptions still low during saving.
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Load Presentation**
New [**IResourceLoadingCallback**](https://apireference.aspose.com/java/slides/com.aspose.slides/IResourceLoadingCallback) interface has been added. 
This callback interface is used to manage external resources loading and has one method.

The code snippet below shows how to use IResourceLoadingCallback interface:

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```
```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // load substitute image
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // set substitute url
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // skip all other images
        return ResourceLoadingAction.Skip;
    }
}
```
