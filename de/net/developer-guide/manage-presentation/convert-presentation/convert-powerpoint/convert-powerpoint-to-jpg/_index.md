---
title: PPT, PPTX und ODP in JPG konvertieren in C#
linktitle: Folien in JPG-Bilder konvertieren
type: docs
weight: 60
url: /de/net/convert-powerpoint-to-jpg/
keywords: 
- PowerPoint in JPG konvertieren
- Präsentation in JPG konvertieren
- Folie in JPG konvertieren
- PPT in JPG konvertieren
- PPTX in JPG konvertieren
- ODP in JPG konvertieren
- PowerPoint zu JPG
- Präsentation zu JPG
- Folie zu JPG
- PPT zu JPG
- PPTX zu JPG
- ODP zu JPG
- PowerPoint in JPEG konvertieren
- Präsentation in JPEG konvertieren
- Folie in JPEG konvertieren
- PPT in JPEG konvertieren
- PPTX in JPEG konvertieren
- ODP in JPEG konvertieren
- PowerPoint zu JPEG
- Präsentation zu JPEG
- Folie zu JPEG
- PPT zu JPEG
- PPTX zu JPEG
- ODP zu JPEG
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ihre Folien aus PowerPoint- und OpenDocument-Präsentationen mit nur wenigen Codezeilen in hochwertige JPEG-Bilder umwandeln. Optimieren Sie Präsentationen für die Webnutzung, das Teilen und die Archivierung. Lesen Sie jetzt den vollständigen Leitfaden!"
---

## **Überblick**

Das Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen in JPG‑Bilder erleichtert das Teilen von Folien, die Optimierung der Leistung und das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für .NET ermöglicht es, PPTX‑, PPT‑ und ODP‑Dateien in hochwertige JPEG‑Bilder zu verwandeln. Dieser Leitfaden erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen ist es einfach, Ihren eigenen Präsentations‑Viewer zu implementieren und für jede Folie ein Miniaturbild zu erstellen. Dies kann nützlich sein, wenn Sie Folien vor dem Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht es, die gesamte Präsentation oder eine bestimmte Folie in Bildformate zu konvertieren.

## **Präsentationsfolien in JPG‑Bilder konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Rufen Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) aus der Sammlung [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) ab.
3. Erstellen Sie ein Bild der Folie mit der Methode [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5).
4. Rufen Sie die Methode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="primary" %}} 
**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP nach JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides .NET‑API. Für andere Formate verwenden Sie typischerweise die Methode [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). Für die JPG‑Konvertierung müssen Sie jedoch die Methode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) verwenden.
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Erstelle ein Bild der Folie mit dem angegebenen Maßstab.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Speichere das Bild im JPEG-Format auf der Festplatte.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Folien in JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Abmessungen der resultierenden JPG‑Bilder zu ändern, können Sie die Bildgröße festlegen, indem Sie sie an die Methode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) übergeben. Dies ermöglicht die Erstellung von Bildern mit spezifischen Breiten‑ und Höhenwerten, sodass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich beim Erzeugen von Bildern für Webanwendungen, Berichte oder Dokumentationen, bei denen präzise Bildabmessungen erforderlich sind.
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Erstelle ein Bild der Folie mit der angegebenen Größe.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Speichere das Bild im JPEG-Format auf der Festplatte.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides für .NET bietet eine Funktion, mit der Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG‑Bilder gerendert werden können. Diese Funktion ist besonders nützlich, um Anmerkungen, Feedback oder Diskussionen, die von Mitwirkenden in PowerPoint‑Präsentationen hinzugefügt wurden, zu erhalten. Durch das Aktivieren dieser Option werden Kommentare in den generierten Bildern sichtbar, sodass Sie das Feedback leichter prüfen und teilen können, ohne die Originalpräsentation öffnen zu müssen.

Angenommen, wir haben eine Präsentationsdatei "sample.pptx" mit einer Folie, die Kommentare enthält:

![The slide with comments](slide_with_comments.png)

Der folgende C#‑Code konvertiert die Folie in ein JPG‑Bild und bewahrt die Kommentare:
```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Optionen für die Folienkommentare festlegen.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Erste Folie in ein Bild konvertieren.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```


Das Ergebnis:

![The JPG image with comments](image_with_comments.png)

## **Siehe auch**

- [PowerPoint in GIF konvertieren](/slides/de/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint in PNG konvertieren](/slides/de/net/convert-powerpoint-to-png/)
- [PowerPoint in TIFF konvertieren](/slides/de/net/convert-powerpoint-to-tiff/)
- [PowerPoint nach SVG rendern](/slides/de/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, testen Sie diese kostenlosen Online‑Konverter: PowerPoint [PPTX zu JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT zu JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Free Online PPTX to JPG Converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

Mit denselben Prinzipien, die in diesem Artikel beschrieben werden, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: konvertieren [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); konvertieren [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); konvertieren [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/); konvertieren [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); konvertieren [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/); konvertieren [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Stapelkonvertierung?**

Ja, Aspose.Slides ermöglicht die Stapelkonvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagramme, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch leicht von PowerPoint abweichen, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Einschränkungen bezüglich der Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine strengen Begrenzungen für die Anzahl der verarbeitbaren Folien fest. Bei sehr großen Präsentationen oder hochauflösenden Bildern können jedoch Out‑Of‑Memory‑Fehler auftreten.