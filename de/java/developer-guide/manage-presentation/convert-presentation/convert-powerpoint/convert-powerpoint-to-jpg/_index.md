---
title: PPT und PPTX in Java zu JPG konvertieren
linktitle: PowerPoint zu JPG
type: docs
weight: 60
url: /de/java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu JPG
- Präsentation zu JPG
- Folie zu JPG
- PPT zu JPG
- PPTX zu JPG
- PowerPoint als JPG speichern
- Präsentation als JPG speichern
- Folie als JPG speichern
- PPT als JPG speichern
- PPTX als JPG speichern
- PPT nach JPG exportieren
- PPTX nach JPG exportieren
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑Folien (PPT, PPTX) in Java mit Aspose.Slides for Java zu hochwertigen JPG‑Bildern mithilfe schneller, zuverlässiger Code‑Beispiele."
---

## Suchen Sie einen Online-PPT-zu-JPG-Konverter?
Bevor Sie zum Java‑Code springen, wenn Sie ein **schnelles Online‑Tool** benötigen, um PowerPoint (PPT, PPTX) ohne Code in JPG zu konvertieren, schauen Sie sich unseren Online‑Konverter an:  
[Aspose PPT‑zu‑JPG‑Konverter](https://products.aspose.app/slides/conversion/ppt-to-jpg)

Wenn Sie ein **Entwickler sind, der nach einer programmgesteuerten Lösung sucht**, lesen Sie weiter, um zu erfahren, wie Sie PowerPoint‑Folien mit **Aspose.Slides for Java** in JPG konvertieren.

## **Über die PowerPoint‑zu‑JPG‑Konvertierung**
Mit [**Aspose.Slides API**](https://products.aspose.com/slides/java/) können Sie PowerPoint‑PPT‑ oder PPTX‑Präsentationen in JPG‑Bilder konvertieren. Es ist außerdem möglich, PPT/PPTX in JPEG, PNG oder SVG zu konvertieren. Mit diesen Funktionen lässt sich leicht ein eigener Präsentations‑Viewer implementieren, Thumbnail für jede Folie erstellen. Das kann nützlich sein, wenn Sie Folien vor Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einzelner Folien in Bildformate.

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, können Sie diese kostenlosen Online‑Konverter testen: PowerPoint [PPTX zu JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT zu JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX in JPG konvertieren**
So konvertieren Sie PPT/PPTX in JPG:

1. Erzeugen Sie eine Instanz des Typs [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie das Folienobjekt des Typs [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) aus der [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)‑Sammlung.
3. Erstellen Sie das Thumbnail jeder Folie und konvertieren Sie es anschließend in JPG. Die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) wird verwendet, um ein Thumbnail einer Folie zu erhalten; sie gibt ein [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images)‑Objekt zurück. Die [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-)‑Methode muss vom gewünschten [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)‑Objekt aufgerufen werden, wobei die Skalierungswerte des resultierenden Thumbnails übergeben werden.
4. Nachdem Sie das Folien‑Thumbnail erhalten haben, rufen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) vom Thumbnail‑Objekt auf. Übergeben Sie dabei den gewünschten Dateinamen und das Bildformat.

{{% alert color="primary" %}}

**Hinweis**: Die Konvertierung von PPT/PPTX nach JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides‑API. Für andere Formate verwenden Sie normalerweise [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), hier benötigen Sie jedoch die [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat))‑Methode.

{{% /alert %}} 
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Erzeugt ein Bild in voller Größe
        IImage slideImage = sld.getImage(1f, 1f);

        // Speichert das Bild im JPEG-Format auf der Festplatte
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
Um die Abmessungen des resultierenden Thumbnails und JPG‑Bildes zu ändern, setzen Sie die *ScaleX*‑ und *ScaleY*‑Werte, indem Sie sie an die [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-)‑Methoden übergeben:
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definiert die Abmessungen
    int desiredX = 1200;
    int desiredY = 800;
    // Ermittelt skalierte Werte von X und Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Erstellt ein Bild in voller Größe
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Speichert das Bild im JPEG-Format auf der Festplatte
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


## **Kommentare beim Speichern der Präsentation als Bild rendern**
Aspose.Slides for Java bietet eine Funktion, mit der Sie Kommentare in den Folien einer Präsentation rendern können, wenn Sie diese Folien in Bilder konvertieren. Dieser Java‑Code demonstriert die Vorgehensweise:
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


{{% alert title="Tip" color="primary" %}}

Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) zur Verfügung. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg)‑ oder PNG‑zu‑PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und mehr. 

Unter Anwendung der in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Bild nach JPG konvertieren ([image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)); JPG nach Bild ([JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/)); JPG nach PNG ([JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)); PNG nach JPG ([PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)); PNG nach SVG ([PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)); SVG nach PNG ([SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)).

{{% /alert %}}

## Häufig gestellte Fragen (FAQ)

### Wie kann ich PowerPoint (PPT, PPTX) in JPG konvertieren?  
Sie können PowerPoint‑Folien mit Aspose.Slides for Java in JPG konvertieren. Dadurch erhalten Sie hochwertige Bildkonvertierungen mit voller Kontrolle über die Ausgabeeinstellungen.

### Unterstützt diese Methode die Batch‑Konvertierung?  
Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien in JPG in einem einzigen Vorgang.

### Kann ich eine benutzerdefinierte Auflösung für das Ausgabe‑JPG festlegen?  
Ja, Sie können benutzerdefinierte Bildauflösung und Qualitäts‑Einstellungen über die Aspose.Slides‑API definieren.

### Gibt es einen Online‑PowerPoint‑zu‑JPG‑Konverter?  
Aspose bietet sowohl programmgesteuerte Lösungen als auch Online‑Konverter. Sehen Sie sich den [Aspose Online PPT‑zu‑JPG‑Konverter](https://products.aspose.app/slides/conversion/ppt-to-jpg) für schnelle Konvertierungen an.

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT/PPTX in Bilder finden Sie hier:

- [PPT/PPTX zu SVG‑Konvertierung](/slides/de/java/render-a-slide-as-an-svg-image/)