---
title: PPT und PPTX zu JPG auf Android konvertieren
linktitle: PowerPoint zu JPG
type: docs
weight: 60
url: /de/androidjava/convert-powerpoint-to-jpg/
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie PowerPoint‑Folien (PPT, PPTX) in hochwertige JPG‑Bilder in Java mit Aspose.Slides für Android mithilfe schneller, zuverlässiger Code‑Beispiele."
---

## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument-Präsentationen in JPG‑Bilder erleichtert das Teilen von Folien, die Leistungsoptimierung und das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für Android via Java ermöglicht das Transformieren von PPTX-, PPT- und ODP-Dateien in hochqualitative JPEG‑Bilder. Dieser Leitfaden erklärt verschiedene Methoden für die Konvertierung.

Mit diesen Funktionen lässt sich leicht ein eigener Präsentationsbetrachter implementieren und ein Miniaturbild für jede Folie erstellen. Dies kann nützlich sein, wenn Sie Präsentationsfolien vor Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer einzelnen Folie in Bildformate.

## **Präsentationsfolien in JPG‑Bilder konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Holen Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) aus der Sammlung, die von der Methode [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) zurückgegeben wird.
1. Erzeugen Sie ein Bild der Folie mit der Methode [ISlide.getImage(float, float)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) .
1. Rufen Sie die Methode [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) für das Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="primary" %}} 
**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP nach JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides Android via Java‑API. Für andere Formate verwenden Sie typischerweise die Methode [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Für die JPG‑Konvertierung müssen Sie jedoch die Methode [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) verwenden.
{{% /alert %}} 
```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Erstelle ein Folienbild mit dem angegebenen Maßstab.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Speichere das Bild auf die Festplatte im JPEG-Format.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **Folien in JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Abmessungen der resultierenden JPG‑Bilder zu ändern, können Sie die Bildgröße festlegen, indem Sie sie an die Methode [ISlide.getImage(Size)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) übergeben. Damit lassen sich Bilder mit spezifischen Breiten‑ und Höhenwerten erzeugen, sodass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich beim Erzeugen von Bildern für Web‑Anwendungen, Berichte oder Dokumentationen, bei denen genaue Bildabmessungen erforderlich sind.
```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Erstelle ein Folienbild mit der angegebenen Größe.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Speichere das Bild auf die Festplatte im JPEG-Format.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides für Android via Java bietet eine Funktion, mit der Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG‑Bilder gerendert werden können. Diese Funktion ist besonders nützlich, um Anmerkungen, Feedback oder Diskussionen, die von Mitwirkenden in PowerPoint‑Präsentationen hinzugefügt wurden, zu erhalten. Durch Aktivieren dieser Option stellen Sie sicher, dass Kommentare in den erzeugten Bildern sichtbar sind, was das Überprüfen und Teilen von Feedback erleichtert, ohne die Original‑Präsentationsdatei öffnen zu müssen.

Angenommen, wir haben eine Präsentationsdatei "sample.pptx" mit einer Folie, die Kommentare enthält:

![Die Folie mit Kommentaren](slide_with_comments.png)

Der folgende Java‑Code konvertiert die Folie in ein JPG‑Bild und bewahrt dabei die Kommentare:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // Konvertiere die erste Folie in ein Bild.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![Das JPG‑Bild mit Kommentaren](image_with_comments.png)

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT, PPTX oder ODP in Bilder finden Sie unter anderem:

- [PowerPoint nach GIF konvertieren](/slides/de/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint nach PNG konvertieren](/slides/de/androidjava/convert-powerpoint-to-png/)
- [PowerPoint nach TIFF konvertieren](/slides/de/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint nach SVG konvertieren](/slides/de/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PowerPoint‑Präsentationen in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter: PowerPoint [PPTX nach JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT nach JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Kostenloser Online‑Konverter PPTX zu JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Onlinedienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und so weiter. 

Mit den gleichen Prinzipien, die in diesem Artikel beschrieben werden, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); konvertieren Sie [JPG zu Bild](https://products.aspose.com/slides/java/conversion/jpg-to-image/); konvertieren Sie [JPG zu PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), konvertieren Sie [PNG zu JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); konvertieren Sie [PNG zu SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), konvertieren Sie [SVG zu PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Batch‑Konvertierung?**

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagramme, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch leicht von PowerPoint abweichen, insbesondere bei benutzerdefinierten oder fehlenden Schriften.

**Gibt es Beschränkungen für die Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine strengen Beschränkungen für die Anzahl der zu verarbeitenden Folien fest. Allerdings können bei sehr großen Präsentationen oder hochauflösenden Bildern Speicher‑Out‑Of‑Memory‑Fehler auftreten.