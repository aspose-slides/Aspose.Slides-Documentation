---
title: Konvertieren von PPT und PPTX nach JPG in .NET
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

## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument‑Präsentationen in JPG‑Bilder erleichtert das Teilen von Folien, optimiert die Leistung und ermöglicht das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für .NET ermöglicht das Umwandeln von PPTX-, PPT- und ODP‑Dateien in hochqualitative JPEG‑Bilder. Dieser Leitfaden erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen ist es einfach, einen eigenen Präsentations‑Viewer zu implementieren und für jede Folie ein Miniaturbild zu erstellen. Das kann nützlich sein, wenn Sie Präsentationsfolien vor dem Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht das Konvertieren der gesamten Präsentation oder einer einzelnen Folie in Bildformate.

## **Präsentationsfolien in JPG‑Bilder konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Rufen Sie das Folienobjekt des Typs [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) aus der Sammlung [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) ab.
3. Erstellen Sie ein Bild der Folie mit der Methode [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5).
4. Rufen Sie die Methode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="primary" %}} 
**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP zu JPG unterscheidet sich von der Konvertierung zu anderen Formaten in der Aspose.Slides .NET‑API. Für andere Formate verwenden Sie typischerweise die Methode [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). Für die JPG‑Konvertierung müssen Sie jedoch die Methode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) verwenden.
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Erstelle ein Folienbild im angegebenen Maßstab.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Speichere das Bild auf der Festplatte im JPEG-Format.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Folien mit benutzerdefinierten Abmessungen in JPG konvertieren**

Um die Abmessungen der erzeugten JPG‑Bilder zu ändern, können Sie die Bildgröße festlegen, indem Sie sie an die Methode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) übergeben. Dadurch lassen sich Bilder mit spezifischen Breiten‑ und Höhenwerten erzeugen, sodass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich, wenn Bilder für Webanwendungen, Berichte oder Dokumentationen erstellt werden, bei denen genaue Bildabmessungen erforderlich sind.
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Erstelle ein Folienbild mit der angegebenen Größe.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Speichere das Bild auf der Festplatte im JPEG-Format.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides für .NET bietet eine Funktion, mit der Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG‑Bilder gerendert werden können. Diese Funktion ist besonders nützlich, um Anmerkungen, Feedback oder Diskussionen, die von Mitwirkenden in PowerPoint‑Präsentationen hinzugefügt wurden, zu erhalten. Durch Aktivieren dieser Option stellen Sie sicher, dass Kommentare in den erzeugten Bildern sichtbar sind, was das Überprüfen und Teilen von Feedback erleichtert, ohne die ursprüngliche Präsentationsdatei öffnen zu müssen.

Angenommen, wir haben eine Präsentationsdatei "sample.pptx" mit einer Folie, die Kommentare enthält:

![Die Folie mit Kommentaren](slide_with_comments.png)

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

Siehe weitere Optionen zum Konvertieren von PPT, PPTX oder ODP in Bilder, zum Beispiel:

- [PowerPoint in GIF konvertieren](/slides/de/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint in PNG konvertieren](/slides/de/net/convert-powerpoint-to-png/)
- [PowerPoint in TIFF konvertieren](/slides/de/net/convert-powerpoint-to-tiff/)
- [PowerPoint in SVG konvertieren](/slides/de/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter aus: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Kostenloser Online‑PPTX‑zu‑JPG‑Konverter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

Mit den in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: [Bild zu JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); [JPG zu Bild](https://products.aspose.com/slides/net/conversion/jpg-to-image/); [JPG zu PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), [PNG zu JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); [PNG zu SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), [SVG zu PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Batch‑Konvertierung?**

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagramme, Tabellen, Formen und mehr. Allerdings kann die Rendering‑Genauigkeit im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Begrenzungen für die Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine strengen Grenzen für die Anzahl der zu verarbeitenden Folien fest. Allerdings können bei sehr großen Präsentationen oder hochauflösenden Bildern Speicher‑Out‑Of‑Memory‑Fehler auftreten.