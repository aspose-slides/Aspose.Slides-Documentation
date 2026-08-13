---
title: PPT und PPTX in Java in JPG konvertieren
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
description: "Konvertieren Sie PowerPoint‑Folien (PPT, PPTX) in hochqualitative JPG‑Bilder in Java mit Aspose.Slides für Java mithilfe schneller, zuverlässiger Codebeispiele."
---
## **Einleitung**

Das Konvertieren von PowerPoint- und OpenDocument-Präsentationen in JPG‑Bilder erleichtert das Teilen von Folien, die Leistungsoptimierung und das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides ermöglicht die Umwandlung von PPTX-, PPT- und ODP‑Dateien in hochqualitative JPEG‑Bilder. Dieser Leitfaden erläutert verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen ist es einfach, einen eigenen Präsentations‑Viewer zu implementieren und für jede Folie ein Vorschaubild zu erstellen. Dies kann nützlich sein, wenn Sie Präsentationsfolien vor dem Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer einzelnen Folie in Bildformate.

## **PowerPoint PPT/PPTX nach JPG konvertieren**

Hier sind die Schritte, um PPT/PPTX nach JPG zu konvertieren:

1. Erstellen Sie eine Instanz des Typs [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation).
2. Holen Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlide) aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getSlides--) .
3. Erstellen Sie für jede Folie ein Vorschaubild und konvertieren Sie es anschließend in JPG. Die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlide#getImage-float-float-) wird verwendet, um ein Vorschaubild einer Folie zu erhalten; sie gibt ein [Images](https://reference.aspose.com/slides/de/java/com.aspose.slides/Images)-Objekt zurück. Die Methode [getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) muss von der gewünschten Folie des Typs [ISlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlide) aufgerufen werden, wobei die Skalierungsfaktoren für das resultierende Vorschaubild an die Methode übergeben werden.
4. Nachdem Sie das Folien‑Vorschaubild erhalten haben, rufen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/de/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) vom Vorschaubild‑Objekt auf. Übergeben Sie dabei den resultierenden Dateinamen und das Bildformat.

{{% alert color="info" %}}
**Hinweis**: Die Konvertierung von PPT/PPTX nach JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides‑API. Für andere Formate verwenden Sie in der Regel die Methode [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/de/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), hier müssen Sie jedoch die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/de/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) verwenden.
{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Erstellt ein Vollskalebild
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

Um die Abmessungen des resultierenden Vorschaubilds und JPG‑Bildes zu ändern, können Sie die Werte *ScaleX* und *ScaleY* übergeben, indem Sie sie an die Methode [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlide#getImage-float-float-) übergeben:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Definiert die Abmessungen
    int desiredX = 1200;
    int desiredY = 800;
    // Erhält skalierte Werte von X und Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Erstellt ein Vollskalebild
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

## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides for Java bietet eine Funktion, mit der Kommentare in den Folien einer Präsentation gerendert werden können, wenn Sie diese Folien in Bilder konvertieren. Der folgende Java‑Code demonstriert die Vorgehensweise:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

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

{{% alert title="Tip" color="info" %}}
Aspose bietet eine [KOSTENLOSE Collage-Web‑App](https://products.aspose.app/slides/de/collage). Mit diesem Online‑Dienst können Sie [JPG‑zu‑JPG](https://products.aspose.app/slides/de/collage/jpg) oder PNG‑zu‑PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/de/collage/photo-grid) erstellen und vieles mehr. 

Mit den in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf folgenden Seiten: konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/de/java/conversion/image-to-jpg/); konvertieren Sie [JPG zu Bild](https://products.aspose.com/slides/de/java/conversion/jpg-to-image/); konvertieren Sie [JPG zu PNG](https://products.aspose.com/slides/de/java/conversion/jpg-to-png/), konvertieren Sie [PNG zu JPG](https://products.aspose.com/slides/de/java/conversion/png-to-jpg/); konvertieren Sie [PNG zu SVG](https://products.aspose.com/slides/de/java/conversion/png-to-svg/), konvertieren Sie [SVG zu PNG](https://products.aspose.com/slides/de/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

### Unterstützt diese Methode die Stapelkonvertierung?

Ja, Aspose.Slides ermöglicht die Stapelkonvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

### Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagramme, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriften.

### Gibt es Einschränkungen hinsichtlich der Anzahl der zu verarbeitenden Folien?

Aspose.Slides selbst legt keine strikten Grenzen für die Anzahl der Folien fest, die Sie verarbeiten können. Allerdings können bei großen Präsentationen oder hochauflösenden Bildern Out‑Of‑Memory‑Fehler auftreten.

## **Siehe auch**

Weitere Optionen, PPT/PPTX in Bilder zu konvertieren, finden Sie hier:

- [PPT/PPTX‑zu‑SVG‑Konvertierung](/slides/de/java/render-a-slide-as-an-svg-image/).