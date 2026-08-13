---
title: PPT und PPTX zu JPG konvertieren in .NET
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
description: "Konvertieren Sie PowerPoint‑Folien (PPT, PPTX) in hochwertige JPG‑Bilder in C# mit Aspose.Slides für .NET mithilfe schneller, zuverlässiger Code‑Beispiele."
---
## **Einleitung**

Das Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen in JPG‑Bilder erleichtert das Teilen von Folien, die Leistungsoptimierung und das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für .NET ermöglicht es Ihnen, PPTX‑, PPT‑ und ODP‑Dateien in hochwertige JPEG‑Bilder zu verwandeln. Dieser Leitfaden erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen ist es einfach, einen eigenen Präsentationsviewer zu implementieren und für jede Folie ein Vorschaubild zu erstellen. Das kann nützlich sein, wenn Sie Präsentationsfolien vor dem Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides erlaubt es Ihnen, die gesamte Präsentation oder eine bestimmte Folie in Bildformate zu konvertieren.

## **Präsentationsfolien in JPG‑Bilder konvertieren**

So konvertieren Sie eine PPT‑, PPTX‑ oder ODP‑Datei in JPG:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation)-Klasse.
1. Holen Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide) aus der [Presentation.Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/properties/slides)-Sammlung.
1. Erstellen Sie ein Bild der Folie mit der [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/#getimage_5)-Methode.
1. Rufen Sie die [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/save/#save_3)-Methode auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="info" %}} 

**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP nach JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides .NET‑API. Für andere Formate verwenden Sie typischerweise die [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/save/#save_5)-Methode. Für die JPG‑Konvertierung müssen Sie jedoch die [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/save/#save_3)-Methode verwenden.

{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Erstelle ein Folienbild mit der angegebenen Skalierung.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Speichere das Bild im JPEG-Format auf die Festplatte.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Folien in JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Abmessungen der erzeugten JPG‑Bilder zu ändern, können Sie die Bildgröße übergeben, indem Sie die [ISlide.GetImage(Size)](https://reference.aspose.com/slides/de/net/aspose.slides/islide/getimage/#getimage_6)-Methode verwenden. Dadurch lassen sich Bilder mit bestimmten Breiten‑ und Höhenwerten erzeugen, sodass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich, wenn Sie Bilder für Webanwendungen, Berichte oder Dokumentationen erzeugen, bei denen genaue Bildgrößen erforderlich sind.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Erstelle ein Folienbild mit der angegebenen Größe.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Speichere das Bild im JPEG-Format auf die Festplatte.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides für .NET bietet eine Funktion, mit der Sie Kommentare einer Präsentationsfolie beim Konvertieren in JPG‑Bilder rendern können. Diese Funktion ist besonders hilfreich, um Anmerkungen, Feedback oder Diskussionen, die von Mitwirkenden in PowerPoint‑Präsentationen hinzugefügt wurden, zu erhalten. Durch Aktivieren dieser Option stellen Sie sicher, dass Kommentare in den erzeugten Bildern sichtbar sind, sodass das Überprüfen und Teilen von Feedback ohne Öffnen der Originaldatei einfacher wird.

Angenommen, wir haben eine Präsentationsdatei „sample.pptx“ mit einer Folie, die Kommentare enthält:

![Die Folie mit Kommentaren](slide_with_comments.png)

Der folgende C#‑Code konvertiert die Folie in ein JPG‑Bild und bewahrt dabei die Kommentare:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Die erste Folie in ein Bild konvertieren.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

Das Ergebnis:

![Das JPG‑Bild mit Kommentaren](image_with_comments.png)

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT, PPTX oder ODP in Bilder, z. B.:

- [Convert PowerPoint to GIF](/slides/de/net/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/de/net/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/de/net/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/de/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter aus: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/de/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/de/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Kostenloser Online‑PPTX‑zu‑JPG‑Konverter](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose bietet eine [FREE Collage‑Web‑App](https://products.aspose.app/slides/de/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/de/collage/jpg) oder PNG zu PNG zusammenführen, [Fotogitter](https://products.aspose.app/slides/de/collage/photo-grid) erstellen und vieles mehr. 

Unter Anwendung der in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Bild zu [JPG](https://products.aspose.com/slides/de/net/conversion/image-to-jpg/); [JPG zu Bild](https://products.aspose.com/slides/de/net/conversion/jpg-to-image/); [JPG zu PNG](https://products.aspose.com/slides/de/net/conversion/jpg-to-png/), [PNG zu JPG](https://products.aspose.com/slides/de/net/conversion/png-to-jpg/); [PNG zu SVG](https://products.aspose.com/slides/de/net/conversion/png-to-svg/), [SVG zu PNG](https://products.aspose.com/slides/de/net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Unterstützt diese Methode die Stapelkonvertierung?

Ja, Aspose.Slides ermöglicht die Stapelkonvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

### Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?

Ja, Aspose.Slides rendert sämtliche Inhalte, einschließlich SmartArt, Diagrammen, Tabellen, Formen und mehr. Die Rendergenauigkeit kann jedoch leicht von PowerPoint abweichen, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

### Gibt es Beschränkungen für die Anzahl der verarbeitbaren Folien?

Aspose.Slides selbst legt keine strikten Limits für die Anzahl der Folien fest, die Sie verarbeiten können. Bei sehr großen Präsentationen oder hochauflösenden Bildern kann jedoch ein Out‑of‑Memory‑Fehler auftreten.