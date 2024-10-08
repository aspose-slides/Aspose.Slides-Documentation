---
title: Powerpoint in JPG umwandeln
type: docs
weight: 60
url: /de/androidjava/convert-powerpoint-to-jpg/
keywords:
- PowerPoint-Präsentation umwandeln
- JPG
- JPEG
- PowerPoint in JPG
- PowerPoint in JPEG
- PPT in JPG
- PPTX in JPG
- PPT in JPEG
- PPTX in JPEG
- Android
- Aspose.Slides
description: "PowerPoint in JPG umwandeln: PPT in JPG, PPTX in JPG in Java"
---

## **Über die Konvertierung von PowerPoint zu JPG**
Mit der [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) können Sie PowerPoint PPT oder PPTX-Präsentationen in JPG-Bilder umwandeln. Es ist auch möglich, PPT/PPTX in JPEG, PNG oder SVG zu konvertieren. Mit dieser Funktion ist es einfach, einen eigenen Präsentationsbetrachter zu implementieren und für jede Folie ein Thumbnail zu erstellen. Dies kann nützlich sein, wenn Sie Präsentationsfolien vor Urheberrechtsverletzungen schützen oder die Präsentation im Nur-Lese-Modus demonstrieren möchten. Aspose.Slides erlaubt es, die gesamte Präsentation oder eine bestimmte Folie in Bildformate umzuwandeln.

{{% alert color="primary" %}}

Um zu sehen, wie Aspose.Slides PowerPoint in JPG-Bilder umwandelt, können Sie diese kostenlosen Online-Konverter ausprobieren: PowerPoint [PPTX in JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT in JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg).

{{% /alert %}}

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX in JPG umwandeln**
Hier sind die Schritte, um PPT/PPTX in JPG umzuwandeln:

1. Erstellen Sie eine Instanz vom Typ [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Erhalten Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) aus der [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) Sammlung.
3. Erstellen Sie das Thumbnail jeder Folie und konvertieren Sie es dann in JPG. Die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) wird verwendet, um ein Thumbnail einer Folie zu erhalten; sie gibt ein [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) Objekt als Ergebnis zurück. Die Methode [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) muss von der benötigten Folie des Typs [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) aufgerufen werden, die Skalen des resultierenden Thumbnails werden in die Methode übergeben.
4. Nachdem Sie das Folien-Thumbnail erhalten haben, rufen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) vom Thumbnail-Objekt auf. Übergeben Sie den resultierenden Dateinamen und das Bildformat.

{{% alert color="primary" %}}

**Hinweis**: Die Konvertierung von PPT/PPTX in JPG unterscheidet sich von der Konvertierung in andere Typen in der Aspose.Slides API. Für andere Typen verwenden Sie normalerweise die Methode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), aber hier müssen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) verwenden.

{{% /alert %}}

```java
Presentation pres = new Presentation("PowerPoint-Präsentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Erstellt ein vollskaliertes Bild
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

## **PowerPoint PPT/PPTX in JPG mit benutzerdefinierten Abmessungen umwandeln**
Um die Abmessungen des resultierenden Thumbnails und des JPG-Bildes zu ändern, können Sie die Werte *ScaleX* und *ScaleY* festlegen, indem Sie sie in die [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) Methoden übergeben:

```java
Presentation pres = new Presentation("PowerPoint-Präsentation.pptx");
try {
    // Definiert die Abmessungen
    int desiredX = 1200;
    int desiredY = 800;
    // Erhält die skalierten Werte von X und Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Erstellt ein vollskaliertes Bild
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

## **Kommentare rendern beim Speichern der Präsentation in ein Bild**
Aspose.Slides für Android über Java bietet eine Funktion, die es ermöglicht, Kommentare in den Folien einer Präsentation zu rendern, wenn Sie diese Folien in Bilder umwandeln. Der folgende Java-Code demonstriert die Operation:

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

Aspose bietet eine [KOSTENLOSE Collage-Webanwendung](https://products.aspose.app/slides/collage). Mit diesem Onlinedienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG-Bildern zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und mehr.

Mit den in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: konvertieren [Bild in JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/); konvertieren [JPG in Bild](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/); konvertieren [JPG in PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/), konvertieren [PNG in JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/); konvertieren [PNG in SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/), konvertieren [SVG in PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

## **Siehe auch**

Siehe andere Optionen, um PPT/PPTX in Bilder umzuwandeln, wie:

- [PPT/PPTX zu SVG-Konvertierung](/slides/de/androidjava/render-a-slide-as-an-svg-image/).