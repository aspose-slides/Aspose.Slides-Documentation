---
title: PPT und PPTX auf Android in JPG konvertieren
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
description: "Konvertieren Sie PowerPoint‑Folien (PPT, PPTX) in hochwertige JPG‑Bilder in Java mit Aspose.Slides für Android mithilfe schneller, zuverlässiger Codebeispiele."
---
## **Einleitung**

Das Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen in JPG‑Bilder erleichtert das Teilen von Folien, verbessert die Leistung und ermöglicht das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für Android via Java erlaubt Ihnen, PPTX‑, PPT‑ und ODP‑Dateien in hochwertige JPEG‑Bilder zu verwandeln. Dieser Leitfaden erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen lässt sich leicht ein eigener Präsentations‑Viewer implementieren und für jede Folie ein Miniaturbild erstellen. Das kann nützlich sein, wenn Sie Präsentationsfolien vor Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einzelner Folien in Bildformate.

## **Präsentationsfolien in JPG‑Bilder konvertieren**

So konvertieren Sie eine PPT‑, PPTX‑ oder ODP‑Datei in JPG:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)‑Klasse.  
2. Holen Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/) aus der Sammlung, die von der Methode [Presentation.getSlides()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSlides--) zurückgegeben wird.  
3. Erzeugen Sie ein Bild der Folie mit der Methode [ISlide.getImage(float,float)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#getImage-float-float-) .  
4. Rufen Sie die Methode [IImage.save(string,ImageFormat)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="info" %}} 

**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP zu JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides Android via Java API. Für andere Formate verwenden Sie typischerweise die Methode [IPresentation.save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Für die JPG‑Konvertierung müssen Sie jedoch die Methode [IImage.save(string,ImageFormat)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) verwenden.

{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Erstelle ein Folienbild mit dem angegebenen Maßstab.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // Speichere das Bild auf der Festplatte im JPEG-Format.
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

Um die Abmessungen der resultierenden JPG‑Bilder zu ändern, können Sie die Bildgröße übergeben, indem Sie die Methode [ISlide.getImage(Size)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) verwenden. Damit lassen sich Bilder mit bestimmten Breiten‑ und Höhenwerten erzeugen, sodass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich, wenn Bilder für Web‑Anwendungen, Berichte oder Dokumentationen erstellt werden, bei denen präzise Bildgrößen erforderlich sind.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Erstelle ein Folienbild mit der angegebenen Größe.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Speichere das Bild auf der Festplatte im JPEG-Format.
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

Aspose.Slides für Android via Java bietet eine Funktion, mit der Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG‑Bilder gerendert werden können. Diese Funktion ist besonders hilfreich, um Anmerkungen, Feedback oder Diskussionen von Mitwirkenden in PowerPoint‑Präsentationen zu erhalten. Durch Aktivieren dieser Option werden Kommentare in den erzeugten Bildern sichtbar, sodass sie leichter geprüft und geteilt werden können, ohne die Original‑Präsentationsdatei öffnen zu müssen.

Angenommen, wir haben die Präsentationsdatei **sample.pptx** mit einer Folie, die Kommentare enthält:

![Die Folie mit Kommentaren](slide_with_comments.png)

Der folgende Java‑Code konvertiert die Folie in ein JPG‑Bild und bewahrt dabei die Kommentare:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

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

Weitere Optionen zum Konvertieren von PPT, PPTX oder ODP in Bilder finden Sie hier:

- [Convert PowerPoint to GIF](/slides/de/androidjava/convert-powerpoint-to-animated-gif/)  
- [Convert PowerPoint to PNG](/slides/de/androidjava/convert-powerpoint-to-png/)  
- [Convert PowerPoint to TIFF](/slides/de/androidjava/convert-powerpoint-to-tiff/)  
- [Convert PowerPoint to SVG](/slides/de/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint‑Präsentationen in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter aus: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/de/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/de/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Kostenloser Online‑PPTX‑zu‑JPG‑Konverter](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose stellt eine [FREE Collage web app](https://products.aspose.app/slides/de/collage) bereit. Mit diesem Onlinedienst können Sie [JPG to JPG](https://products.aspose.app/slides/de/collage/jpg) oder PNG‑zu‑PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/de/collage/photo-grid) erstellen und vieles mehr.  

Nach denselben Prinzipien, die in diesem Artikel beschrieben werden, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Bild zu JPG konvertieren [image to JPG](https://products.aspose.com/slides/de/java/conversion/image-to-jpg/); JPG zu Bild konvertieren [JPG to image](https://products.aspose.com/slides/de/java/conversion/jpg-to-image/); JPG zu PNG konvertieren [JPG to PNG](https://products.aspose.com/slides/de/java/conversion/jpg-to-png/); PNG zu JPG konvertieren [PNG to JPG](https://products.aspose.com/slides/de/java/conversion/png-to-jpg/); PNG zu SVG konvertieren [PNG to SVG](https://products.aspose.com/slides/de/java/conversion/png-to-svg/); SVG zu PNG konvertieren [SVG to PNG](https://products.aspose.com/slides/de/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Unterstützt diese Methode die Batch‑Konvertierung?

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

### Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagrammen, Tabellen, Formen und mehr. Die Render‑Genauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

### Gibt es Einschränkungen hinsichtlich der Anzahl der verarbeitbaren Folien?

Aspose.Slides selbst setzt keine strikten Grenzen für die Anzahl der Folien, die Sie verarbeiten können. Bei sehr großen Präsentationen oder hochauflösenden Bildern können jedoch Out‑of‑Memory‑Fehler auftreten.