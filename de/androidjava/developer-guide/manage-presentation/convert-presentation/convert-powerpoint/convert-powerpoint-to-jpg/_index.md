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
description: "Konvertieren Sie PowerPoint‑Folien (PPT, PPTX) in hochwertige JPG‑Bilder in Java mit Aspose.Slides für Android mithilfe schneller, zuverlässiger Code‑Beispiele."
---

## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument-Präsentationen in JPG-Bilder erleichtert das Teilen von Folien, die Optimierung der Leistung und das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für Android über Java ermöglicht es, PPTX-, PPT- und ODP-Dateien in hochqualitative JPEG‑Bilder zu transformieren. Dieses Handbuch erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen ist es einfach, Ihren eigenen Präsentations‑Viewer zu implementieren und für jede Folie ein Miniaturbild zu erstellen. Dies kann nützlich sein, wenn Sie Präsentationsfolien vor dem Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht es, die gesamte Präsentation oder eine bestimmte Folie in Bildformate zu konvertieren.

## **Präsentationsfolien in JPG‑Bilder konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Holen Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) aus der Sammlung, die von der Methode [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) zurückgegeben wird.
1. Erstellen Sie ein Bild der Folie mithilfe der Methode [ISlide.getImage(float, float)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-).
1. Rufen Sie die Methode [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="primary" %}} 
**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP zu JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides Android über Java‑API. Für andere Formate verwenden Sie typischerweise die Methode [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). Für die JPG‑Konvertierung müssen Sie jedoch die Methode [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) verwenden.
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
            // Speichere das Bild im JPEG-Format auf die Festplatte.
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


## **Folien mit benutzerdefinierten Abmessungen in JPG konvertieren**

Um die Abmessungen der resultierenden JPG‑Bilder zu ändern, können Sie die Bildgröße festlegen, indem Sie sie an die Methode [ISlide.getImage(Size)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) übergeben. Dadurch können Sie Bilder mit bestimmten Breiten‑ und Höhenwerten erzeugen, sodass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich beim Erzeugen von Bildern für Webanwendungen, Berichte oder Dokumentationen, bei denen präzise Bildabmessungen erforderlich sind.
```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Erstelle ein Folienbild mit der angegebenen Größe.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // Speichere das Bild im JPEG-Format auf die Festplatte.
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

Aspose.Slides für Android über Java bietet eine Funktion, die es ermöglicht, Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG‑Bilder zu rendern. Diese Funktion ist besonders nützlich, um Anmerkungen, Rückmeldungen oder Diskussionen, die von Mitwirkenden in PowerPoint‑Präsentationen hinzugefügt wurden, zu erhalten. Durch Aktivieren dieser Option stellen Sie sicher, dass Kommentare in den erzeugten Bildern sichtbar sind, wodurch das Überprüfen und Teilen von Feedback erleichtert wird, ohne die Originalpräsentationsdatei öffnen zu müssen.

Angenommen, wir haben eine Präsentationsdatei „sample.pptx“, die eine Folie mit Kommentaren enthält:
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

Weitere Optionen zum Konvertieren von PPT, PPTX oder ODP in Bilder, z. B.:
- [PowerPoint in GIF konvertieren](/slides/de/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint in PNG konvertieren](/slides/de/androidjava/convert-powerpoint-to-png/)
- [PowerPoint in TIFF konvertieren](/slides/de/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint in SVG konvertieren](/slides/de/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PowerPoint‑Präsentationen in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter: PowerPoint [PPTX zu JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT zu JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Kostenloser Online‑PPTX‑zu‑JPG‑Konverter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder [PNG zu PNG‑Bilder](https://products.aspose.app/slides/collage/png) zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und so weiter. 

Unter Anwendung derselben Prinzipien aus diesem Artikel können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Bild zu JPG konvertieren [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); JPG zu Bild konvertieren [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); JPG zu PNG konvertieren [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), PNG zu JPG konvertieren [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); PNG zu SVG konvertieren [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), SVG zu PNG konvertieren [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Stapelkonvertierung?**

Ja, Aspose.Slides ermöglicht die Stapelkonvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert sämtlichen Inhalt, einschließlich SmartArt, Diagrammen, Tabellen, Formen und mehr. Die Rendergenauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Begrenzungen für die Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine strikten Grenzen für die Anzahl der verarbeitbaren Folien fest. Allerdings können bei großen Präsentationen oder hochauflösenden Bildern Speicher‑Out‑of‑Memory‑Fehler auftreten.