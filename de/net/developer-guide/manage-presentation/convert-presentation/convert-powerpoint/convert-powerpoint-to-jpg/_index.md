---
title: PPT und PPTX in .NET zu JPG konvertieren
linktitle: PowerPoint zu JPG
type: docs
weight: 60
url: /de/net/convert-powerpoint-to-jpg/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PowerPoint (PPT, PPTX)-Folien in hochwertige JPG‑Bilder in C# mit Aspose.Slides für .NET mithilfe schneller, zuverlässiger Codebeispiele."
---

## **Übersicht**

Das Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen in JPG‑Bilder erleichtert das Teilen von Folien, verbessert die Leistung und ermöglicht das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für .NET ermöglicht die Umwandlung von PPTX-, PPT‑ und ODP‑Dateien in hochwertige JPEG‑Bilder. Dieser Leitfaden erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen ist es einfach, einen eigenen Präsentationsbetrachter zu implementieren und ein Miniaturbild für jede Folie zu erstellen. Das kann nützlich sein, wenn Sie Präsentationsfolien vor dem Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus darstellen möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer einzelnen Folie in Bildformate.

## **Präsentationsfolien zu JPG‑Bildern konvertieren**

Hier sind die Schritte, um eine PPT‑, PPTX‑ oder ODP‑Datei in JPG zu konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.  
2. Holen Sie das Folienobjekt des Typs [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) aus der [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)-Sammlung.  
3. Erzeugen Sie ein Bild der Folie mit der Methode [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5).  
4. Rufen Sie die Methode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Parameter.

{{% alert color="primary" %}} 
**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP zu JPG unterscheidet sich von der Konvertierung zu anderen Formaten in der Aspose.Slides‑.NET‑API. Für andere Formate verwenden Sie in der Regel die Methode [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). Für die JPG‑Konvertierung müssen Sie jedoch die Methode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) verwenden.  
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Erstelle ein Folienbild mit dem angegebenen Maßstab.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Speichere das Bild im JPEG-Format auf der Festplatte.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Folien zu JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Abmessungen der resultierenden JPG‑Bilder zu ändern, können Sie die Bildgröße über die Methode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) festlegen. Dadurch lassen sich Bilder mit bestimmten Breiten‑ und Höhenwerten erzeugen, sodass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich, wenn Bilder für Web‑Anwendungen, Berichte oder Dokumentationen erstellt werden, bei denen präzise Bildgrößen erforderlich sind.  
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Erstelle ein Folienbild mit der angegebenen Größe.
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

Aspose.Slides für .NET bietet eine Funktion, mit der Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG‑Bilder gerendert werden können. Diese Funktion ist besonders hilfreich, um Anmerkungen, Feedback oder Diskussionen von Mitwirkenden in PowerPoint‑Präsentationen zu erhalten. Durch Aktivieren dieser Option werden Kommentare in den erzeugten Bildern sichtbar, was das Überprüfen und Teilen von Feedback erleichtert, ohne die Originaldatei öffnen zu müssen.

Angenommen, wir haben eine Präsentationsdatei "sample.pptx" mit einer Folie, die Kommentare enthält:

![Die Folie mit Kommentaren](slide_with_comments.png)

Der folgende C#‑Code konvertiert die Folie in ein JPG‑Bild und bewahrt dabei die Kommentare:
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

    // Konvertiere die erste Folie in ein Bild.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```


Das Ergebnis:

![Das JPG‑Bild mit Kommentaren](image_with_comments.png)

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT, PPTX oder ODP in Bilder, beispielsweise:

- [PowerPoint zu GIF konvertieren](/slides/de/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint zu PNG konvertieren](/slides/de/net/convert-powerpoint-to-png/)
- [PowerPoint zu TIFF konvertieren](/slides/de/net/convert-powerpoint-to-tiff/)
- [PowerPoint zu SVG konvertieren](/slides/de/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter aus: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg).  
{{% /alert %}} 

![Kostenloser Online PPTX‑zu‑JPG‑Konverter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und so weiter.  

Mit den gleichen Prinzipien, die in diesem Artikel beschrieben werden, können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Bild zu JPG konvertieren : [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); JPG zu Bild konvertieren : [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); JPG zu PNG konvertieren : [jpg to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/); PNG zu JPG konvertieren : [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); PNG zu SVG konvertieren : [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/); SVG zu PNG konvertieren : [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).  

{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Batch‑Konvertierung?**

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert sämtlichen Inhalt, einschließlich SmartArt, Diagrammen, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Beschränkungen für die Anzahl der Folien, die verarbeitet werden können?**

Aspose.Slides selbst setzt keine strikten Grenzen für die Anzahl der verarbeitbaren Folien. Bei sehr großen Präsentationen oder hochauflösenden Bildern können jedoch Out‑of‑Memory‑Fehler auftreten.