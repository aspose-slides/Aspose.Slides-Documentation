---
title: Use Slides on Android
description: Use the Slides presentation API in an Android application.
type: docs
url: /features/android-api/
weight: 410
feature_id: android-api
feature_group: languages
translationKey: slides-feature-android-api
feature_catalogue_version: 3
feature_guides:
- /slides/androidjava/install-aspose-slides-for-android-via-java/
---

## **Overview**

Add Aspose.Slides for Android via Java to an Android project to work with presentation files through its local API. Use the Android-specific documentation for installation and examples, including the platform requirements that apply to the application.

## **Usage example**

This example uses **Aspose.Slides for Android via Java**. Add the Android product to your app using its [installation instructions](/slides/androidjava/install-aspose-slides-for-android-via-java/). Save this complete helper class as *CreatePresentation.java* and call its save method with your app's Context from the presentation-processing code. It creates a slide with a text box and writes *hello.pptx* in app-private internal storage.

```java
import android.content.Context;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.io.File;

public class CreatePresentation {
    public static void save(Context context) {
        File output = new File(context.getFilesDir(), "hello.pptx");
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape title = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            title.getTextFrame().setText("Hello from Android");
            presentation.save(output.getAbsolutePath(), SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

No input file or shared-storage permission is needed for this destination. The coordinates and dimensions are in points. Evaluation output carries a watermark. Package and run the helper as part of an Android app rather than as a desktop Java program.

## **FAQ**

### **Should I follow the desktop Java setup instructions?**

Use the Android via Java instructions. The presentation tasks are similar, but packaging and platform setup belong to the Android product.

### **Where can an Android app save the generated presentation?**

The example uses app-private internal storage, which is available through the app Context and does not require a shared-storage permission. To let another app or a user export the file, use the appropriate Android sharing or document-access workflow separately.

### **How can I load a presentation packaged as an Android application asset?**

Open the asset through the app's asset manager, pass the resulting input stream to the presentation constructor and close the stream when loading is finished. Follow the [Android-specific guides](/slides/androidjava/install-aspose-slides-for-android-via-java/) for packaging the product and integrating it with the app lifecycle.

## **Guides**

- [Install Aspose.Slides for Android via Java (Android via Java)](/slides/androidjava/install-aspose-slides-for-android-via-java/)
