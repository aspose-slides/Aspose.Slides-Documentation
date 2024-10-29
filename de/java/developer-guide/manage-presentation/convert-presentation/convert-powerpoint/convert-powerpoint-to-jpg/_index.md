---
title: PowerPoint in JPG konvertieren
type: docs
weight: 60
url: /de/java/convert-powerpoint-to-jpg/
keywords: "PowerPoint in JPG konvertieren, PPTX in JPEG, PPT in JPEG"
description: "PowerPoint in JPG konvertieren: PPT in JPG, PPTX in JPG in Java"
---

## **Über die Konvertierung von PowerPoint zu JPG**
Mit der [**Aspose.Slides API**](https://products.aspose.com/slides/java/) können Sie eine PowerPoint PPT- oder PPTX-Präsentation in ein JPG-Bild konvertieren. Es ist auch möglich, PPT/PPTX in JPEG, PNG oder SVG zu konvertieren. Mit diesen Funktionen ist es einfach, Ihren eigenen Präsentationsbetrachter zu implementieren und für jede Folie ein Thumbnail zu erstellen. Dies kann nützlich sein, wenn Sie Präsentationsfolien vor Urheberrechtsverletzungen schützen oder die Präsentation im Nur-Lese-Modus anzeigen möchten. Aspose.Slides ermöglicht es, die gesamte Präsentation oder eine bestimmte Folie in Bildformate zu konvertieren.

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG-Bilder konvertiert, möchten Sie möglicherweise diese kostenlosen Online-Konverter ausprobieren: PowerPoint [PPTX in JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT in JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX in JPG konvertieren**
Hier sind die Schritte zum Konvertieren von PPT/PPTX in JPG:

1. Erstellen Sie eine Instanz des Typs [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie sich das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) .
3. Erstellen Sie das Thumbnail jeder Folie und konvertieren Sie es dann in JPG. Die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) wird verwendet, um ein Thumbnail einer Folie zu erhalten, sie gibt ein [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images)-Objekt als Ergebnis zurück. Die Methode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) muss von der benötigten Folie des Typs [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) aufgerufen werden, die Maßstäbe des resultierenden Thumbnails werden in die Methode übergeben.
4. Nachdem Sie das Folien-Thumbnail erhalten haben, rufen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) vom Thumbnail-Objekt aus auf. Übergeben Sie den resultierenden Dateinamen und das Bildformat.

{{% alert color="primary" %}}

**Hinweis**: Die Konvertierung von PPT/PPTX in JPG unterscheidet sich von der Konvertierung in andere Typen in der Aspose.Slides API. Für andere Typen verwenden Sie normalerweise die Methode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), aber hier müssen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) verwenden.

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Präsentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Erstellt ein Vollbildbild
        IImage slideImage = sld.getImage(1f, 1f);

        // Speichert das Bild auf der Festplatte im JPEG-Format
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint PPT/PPTX in JPG mit benutzerdefinierten Abmessungen konvertieren**
Um die Dimensionen des resultierenden Thumbnails und des JPG-Bildes zu ändern, können Sie die Werte *ScaleX* und *ScaleY* setzen, indem Sie sie in die [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) Methoden übergeben:

```java
Presentation pres = new Presentation("PowerPoint-Präsentation.pptx");
try {
    // Definiert Dimensionen
    int desiredX = 1200;
    int desiredY = 800;
    // Holt skalierten Werte von X und Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Erstellt ein Vollbildbild
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Speichert das Bild auf der Festplatte im JPEG-Format
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kommentare beim Speichern der Präsentation in ein Bild rendern**
Aspose.Slides für Java bietet eine Funktion, die es Ihnen ermöglicht, Kommentare in den Folien einer Präsentation zu rendern, wenn Sie diese Folien in Bilder konvertieren. Dieser Java-Code demonstriert die Operation:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Web-App](https://products.aspose.app/slides/collage). Mit diesem Onlinedienst können Sie [JPG in JPG](https://products.aspose.app/slides/collage/jpg) oder PNG in PNG-Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

Mit denselben Prinzipien, die in diesem Artikel beschrieben sind, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: konvertieren Sie [Bild in JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); konvertieren Sie [JPG in Bild](https://products.aspose.com/slides/java/conversion/jpg-to-image/); konvertieren Sie [JPG in PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), konvertieren Sie [PNG in JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); konvertieren Sie [PNG in SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), konvertieren Sie [SVG in PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **Siehe auch**

Siehe andere Optionen für die Konvertierung von PPT/PPTX in Bilder wie:

- [PPT/PPTX in SVG-Konvertierung](/slides/de/java/render-a-slide-as-an-svg-image/).