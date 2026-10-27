---
title: Use Slides from Java
description: Create and process presentations with the Java library.
type: docs
url: /features/java-api/
weight: 360
feature_id: java-api
feature_group: languages
translationKey: slides-feature-java-api
feature_catalogue_version: 3
feature_guides:
- /slides/java/installation/
---

## **Overview**

Use Aspose.Slides for Java in a JVM application to load, edit, save and render presentations. The Java documentation provides setup instructions and examples using the presentation model. Add the library and its dependencies to the application that performs the processing.

## **Usage example**

This example uses Aspose.Slides for Java. Add the library to the classpath as described in the [installation guide](/slides/java/installation/), save the complete class as *CreatePresentation.java*, then compile and run it. It creates one slide with a text box and writes *hello.pptx* in the working directory without an input file.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

public class CreatePresentation {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape title = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            title.getTextFrame().setText("Hello from Java");
            presentation.save("hello.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

The rectangle is positioned and sized in points. The finally block releases presentation resources after saving. Evaluation output also carries a watermark.

## **FAQ**

### **Is Java support a call to a hosted API?**

No. The Java library processes presentations in your application. Follow its runtime requirements when packaging or deploying it.

### **How do I add the library to a Java project?**

Add the Aspose.Slides JAR and its required dependencies to the build and runtime classpaths, or configure the dependency with your build tool. Follow the [installation guide](/slides/java/installation/) for the package source and setup.

### **How should I release presentation resources in Java?**

Release each presentation when processing is finished, including after an error. The example uses a finally block for this, so resources are released whether saving succeeds or fails.

## **Guides**

- [Installation (Java)](/slides/java/installation/)

Related feature: [Choose a Java runtime](/slides/features/java-runtimes/).
