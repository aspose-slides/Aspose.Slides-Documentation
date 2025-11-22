---
title: PPT, PPTX und ODP in JPG mit Python konvertieren
linktitle: Folien in JPG-Bilder konvertieren
type: docs
weight: 60
url: /de/python-net/convert-powerpoint-to-jpg/
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
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Ihre Folien aus PowerPoint- und OpenDocument-Präsentationen mit nur wenigen Codezeilen in Python in hochwertige JPEG-Bilder umwandeln. Optimieren Sie Präsentationen für die Webnutzung, das Teilen und die Archivierung. Lesen Sie jetzt den vollständigen Leitfaden!"
---

## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument-Präsentationen in JPG-Bilder erleichtert das Teilen von Folien, die Leistungsoptimierung und das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für Python ermöglicht das Umwandeln von PPTX-, PPT- und ODP-Dateien in JPEG-Bilder in hoher Qualität. Dieser Leitfaden erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen ist es einfach, einen eigenen Präsentationsbetrachter zu implementieren und für jede Folie ein Thumbnail zu erstellen. Das kann nützlich sein, wenn Sie Folien vor dem Kopieren schützen oder die Präsentation im Nur-Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer einzelnen Folie in Bildformate.

## **Präsentationsfolien in JPG-Bilder konvertieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie das Folienobjekt vom Typ [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) aus der Sammlung [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/).
1. Erzeugen Sie ein Bild der Folie mit der Methode [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float).
1. Rufen Sie die Methode [IImage.save(filename, format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="primary" %}}
**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP nach JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides‑Python‑API. Für andere Formate verwenden Sie normalerweise die Methode [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions). Für die JPG‑Konvertierung müssen Sie jedoch die Methode [IImage.save(filename, format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) verwenden.
{{% /alert %}}
```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # Bild im JPEG-Format auf der Festplatte speichern.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **Folien in JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Abmessungen der erzeugten JPG‑Bilder zu ändern, können Sie die Bildgröße übergeben, indem Sie sie an die Methode [Slide.get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) übergeben. Dadurch können Sie Bilder mit bestimmten Breiten‑ und Höhenwerten erzeugen und sicherstellen, dass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich beim Erzeugen von Bildern für Web‑Anwendungen, Berichte oder Dokumentationen, bei denen präzise Bildabmessungen erforderlich sind.
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # Erstelle ein Folienbild mit der angegebenen Größe.
        with slide.get_image(image_size) as thumbnail:
            # Bild im JPEG-Format auf der Festplatte speichern.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides für Python bietet eine Funktion, mit der Sie Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG‑Bilder rendern können. Diese Funktion ist besonders nützlich, um Anmerkungen, Rückmeldungen oder Diskussionen, die von Mitarbeitern in PowerPoint‑Präsentationen hinzugefügt wurden, zu erhalten. Durch Aktivieren dieser Option werden Kommentare in den erzeugten Bildern sichtbar, was das Überprüfen und Teilen von Rückmeldungen erleichtert, ohne die Originalpräsentationsdatei öffnen zu müssen.

Der folgende Python‑Code konvertiert die Folie in ein JPG‑Bild und bewahrt dabei die Kommentare:
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # Optionen für die Folienkommentare festlegen.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # Erste Folie in ein Bild konvertieren.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```


Das Ergebnis:
![Das JPG‑Bild mit Kommentaren](image_with_comments.png)

## **Siehe auch**

- [PowerPoint nach GIF konvertieren](/slides/de/python-net/convert-powerpoint-to-animated-gif/)
- [PowerPoint nach PNG konvertieren](/slides/de/python-net/convert-powerpoint-to-png/)
- [PowerPoint nach TIFF konvertieren](/slides/de/python-net/convert-powerpoint-to-tiff/)
- [PowerPoint nach SVG konvertieren](/slides/de/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter aus: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Kostenloser Online‑PPTX‑zu‑JPG‑Konverter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

Mit denselben in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Bild zu JPG konvertieren [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); JPG zu Bild konvertieren [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); JPG zu PNG konvertieren [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), PNG zu JPG konvertieren [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); PNG zu SVG konvertieren [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), SVG zu PNG konvertieren [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Stapelkonvertierung?**

Ja, Aspose.Slides ermöglicht die Stapelkonvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagrammen, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriften.

**Gibt es Einschränkungen bezüglich der Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine festen Beschränkungen für die Anzahl der zu verarbeitenden Folien fest. Allerdings können bei großen Präsentationen oder hochauflösenden Bildern Speicher‑Ausnahmefehler auftreten.