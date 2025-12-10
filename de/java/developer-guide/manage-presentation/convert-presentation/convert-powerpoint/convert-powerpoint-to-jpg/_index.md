---
title: PPT und PPTX nach JPG in Java konvertieren
linktitle: PowerPoint nach JPG
type: docs
weight: 60
url: /de/java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint nach JPG
- Präsentation nach JPG
- Folie nach JPG
- PPT nach JPG
- PPTX nach JPG
- PowerPoint als JPG speichern
- Präsentation als JPG speichern
- Folie als JPG speichern
- PPT als JPG speichern
- PPTX als JPG speichern
- PPT nach JPG exportieren
- PPTX nach JPG exportieren
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑Folien (PPT, PPTX) in hochwertige JPG‑Bilder in Java mit Aspose.Slides für Java mithilfe schneller und zuverlässiger Code‑Beispiele."
---

## **Suchen Sie einen Online-PPT-zu-JPG-Konverter?**

Bevor Sie zum Java‑Code springen, falls Sie ein **schnelles Online‑Tool** zum Konvertieren von PowerPoint (PPT, PPTX) nach JPG **ohne Code** benötigen, schauen Sie sich unseren Online‑Konverter an:  
[Aspose PPT to JPG Converter](https://products.aspose.app/slides/conversion/ppt-to-jpg)

Wenn Sie ein **Entwickler sind, der nach einer programmgesteuerten Lösung sucht**, lesen Sie weiter, um zu erfahren, wie Sie PowerPoint‑Folien mit **Aspose.Slides for Java** nach JPG konvertieren.

## **Über die PowerPoint‑zu‑JPG-Konvertierung**

Mit der [**Aspose.Slides API**](https://products.aspose.com/slides/java/) können Sie PowerPoint‑PPT‑ oder PPTX‑Präsentationen in JPG‑Bilder konvertieren. Es ist auch möglich, PPT/PPTX nach JPEG, PNG oder SVG zu konvertieren. Mit diesen Funktionen lässt sich leicht ein eigener Präsentations‑Viewer implementieren, das Vorschaubild jeder Folie erstellen. Das kann nützlich sein, wenn Sie Folien vor Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus zeigen wollen. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einzelner Folien in Bildformate.  

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder umwandelt, probieren Sie die kostenlosen Online‑Konverter: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX nach JPG konvertieren**

So gehen Sie vor, um PPT/PPTX nach JPG zu konvertieren:

1. Erstellen Sie eine Instanz des Typs [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie das Folien‑Objekt vom Typ [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) .
3. Erzeugen Sie das Vorschaubild jeder Folie und konvertieren Sie es dann nach JPG. Die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) liefert ein [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images)-Objekt. Die Methode [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) muss von der gewünschten [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)-Instanz aufgerufen werden, wobei die Skalierungswerte für das resultierende Vorschaubild übergeben werden.
4. Nachdem Sie das Folien‑Vorschaubild erhalten haben, rufen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) des Vorschaubild‑Objekts auf. Übergeben Sie den gewünschten Dateinamen und das Bildformat.

{{% alert color="primary" %}}

**Hinweis**: Die PPT/PPTX‑zu‑JPG‑Konvertierung unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides‑API. Für andere Formate verwenden Sie meist [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), hier benötigen Sie jedoch die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).

{{% /alert %}} 
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Erstellt ein Bild in voller Auflösung
        IImage slideImage = sld.getImage(1f, 1f);

        // Speichert das Bild im JPEG-Format auf die Festplatte
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


## **PowerPoint PPT/PPTX nach JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Abmessungen des resultierenden Vorschaubilds und JPG‑Bildes zu ändern, können Sie die Werte *ScaleX* und *ScaleY* setzen, indem Sie sie an die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) übergeben:
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definiert die Abmessungen
    int desiredX = 1200;
    int desiredY = 800;
    // Ermittelt skalierte Werte für X und Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Erstellt ein Bild in voller Auflösung
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Speichert das Bild im JPEG-Format auf die Festplatte
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


## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides for Java bietet eine Funktion, mit der Sie Kommentare in den Folien einer Präsentation rendern können, wenn Sie diese Folien in Bilder umwandeln. Dieser Java‑Code demonstriert die Vorgehensweise:
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

Aspose stellt eine [FREE Collage‑Web‑App](https://products.aspose.app/slides/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen usw.  

Mit denselben Prinzipien wie in diesem Artikel beschrieben, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie hier: Bild zu JPG konvertieren [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); JPG zu Bild konvertieren [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); JPG zu PNG konvertieren [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/); PNG zu JPG konvertieren [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); PNG zu SVG konvertieren [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/); SVG zu PNG konvertieren [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Batch‑Konvertierung?**

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Wird bei der Konvertierung SmartArt, Diagramme und andere komplexe Objekte unterstützt?**

Ja, Aspose.Slides rendert sämtlichen Inhalt, einschließlich SmartArt, Diagramme, Tabellen, Formen usw. Die Render‑Genauigkeit kann jedoch leicht von PowerPoint abweichen, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Beschränkungen für die Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine harten Grenzen für die Folienzahl fest. Bei sehr großen Präsentationen oder hochauflösenden Bildern kann jedoch ein Out‑of‑Memory‑Fehler auftreten.

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT/PPTX in Bilder:

- [PPT/PPTX to SVG conversion](/slides/de/java/render-a-slide-as-an-svg-image/).