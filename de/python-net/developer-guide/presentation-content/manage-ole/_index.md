---
title: OLE in Präsentationen mit Python verwalten
linktitle: OLE verwalten
type: docs
weight: 40
url: /de/python-net/manage-ole/
keywords:
- OLE-Objekt
- Objektverknüpfung & Einbettung
- OLE hinzufügen
- OLE einbetten
- Objekt hinzufügen
- Objekt einbetten
- Datei hinzufügen
- Datei einbetten
- verknüpftes Objekt
- verknüpfte Datei
- OLE ändern
- OLE-Symbol
- OLE-Titel
- OLE extrahieren
- Objekt extrahieren
- Datei extrahieren
- PowerPoint 
- Präsentation
- Python
- Aspose.Slides
description: "Optimieren Sie die Verwaltung von OLE-Objekten in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides for Python via .NET. Betten Sie OLE-Inhalte nahtlos ein, aktualisieren und exportieren Sie sie."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) ist eine Microsoft-Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, durch Verlinkung oder Einbettung in eine andere Anwendung zu platzieren. 

{{% /alert %}} 

Betrachten Sie ein in MS Excel erstelltes Diagramm. Das Diagramm wird dann in eine PowerPoint-Folie eingefügt. Dieses Excel-Diagramm wird als OLE-Objekt betrachtet. 

- Ein OLE-Objekt kann als Symbol erscheinen. In diesem Fall wird das Diagramm geöffnet, wenn Sie auf das Symbol doppelklicken, sofern das zugehörige Programm (Excel) geöffnet werden kann, oder Sie werden aufgefordert, ein Programm zum Öffnen oder Bearbeiten des Objekts auszuwählen. 
- Ein OLE-Objekt kann tatsächliche Inhalte anzeigen – zum Beispiel die Inhalte eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammoberfläche wird geladen, und Sie können die Daten des Diagramms innerhalb der PowerPoint-Anwendung ändern.

[Aspose.Slides für Python über .NET](https://products.aspose.com/slides/python-net) ermöglicht es Ihnen, OLE-Objekte in Folien als OLE-Objekt-Frames ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)) einzufügen.

## **Hinzufügen von OLE-Objekt-Frames zu Folien**
Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten dieses Diagramm in einer Folie als OLE-Objekt-Frame mit Aspose.Slides für Python über .NET einbetten, können Sie das wie folgt tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz der Folie über ihren Index.
1. Öffnen Sie die Excel-Datei, die das Excel-Diagrammobjekt enthält, und speichern Sie sie in `MemoryStream`.
1. Fügen Sie das OLE-Objekt-Frame zur Folie hinzu, das das Byte-Array und andere Informationen über das OLE-Objekt enthält.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel-Datei in eine Folie als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) mit Aspose.Slides für Python über .NET eingefügt.  
**Hinweis**, dass der [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/) Konstruktor eine einbettbare Objekt-Erweiterung als zweiten Parameter verwendet. Diese Erweiterung ermöglicht es PowerPoint, den Dateityp korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE-Objekts auszuwählen.

```py 
import aspose.slides as slides

# Instanziiert die Presentation-Klasse, die das PPTX repräsentiert
with slides.Presentation() as pres:
    # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Lädt eine Excel-Datei in den Stream
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # Erstellt ein Datenobjekt zum Einbetten
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # Fügt eine Ole-Objekt-Frame-Form hinzu
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # Schreibt die PPTX-Datei auf die Festplatte
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Zugreifen auf OLE-Objekt-Frames**
Wenn ein OLE-Objekt bereits in einer Folie eingebettet ist, können Sie dieses Objekt ganz einfach so finden oder darauf zugreifen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.

1. Erhalten Sie die Referenz der Folie, indem Sie ihren Index verwenden.

1. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Form zu.

   In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die nur eine Form auf der ersten Folie hat. Wir haben dann *casten* dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). Dies war das gewünschte OLE-Objekt-Frame, auf das zugegriffen werden sollte.

1. Sobald das OLE-Objekt-Frame zugänglich ist, können Sie jede Operation daran ausführen.

Im folgenden Beispiel wird ein OLE-Objekt-Frame (ein in eine Folie eingebettetes Excel-Diagrammobjekt) zugegriffen – und dann werden die Dateidaten in eine Excel-Datei geschrieben:

```py 
import aspose.slides as slides

# Lädt das PPTX in ein Präsentationsobjekt
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Castet die Form zu OleObjectFrame
    oleObjectFrame = sld.shapes[0]

    # Liest das OLE-Objekt und schreibt es auf die Festplatte
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # Erhält die eingebetteten Dateidaten
        data = oleObjectFrame.embedded_data.embedded_file_data

        # Erhält die eingebettete Dateierweiterung
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # Erstellt einen Pfad zum Speichern der extrahierten Datei
        extractedPath = "excelFromOLE_out" + fileExtention

        # Speichert die extrahierten Daten
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **Ändern von OLE-Objektdaten**

Wenn ein OLE-Objekt bereits in einer Folie eingebettet ist, können Sie dieses Objekt ganz einfach mit Aspose.Slides für Python über .NET zugreifen und seine Daten wie folgt ändern:

1. Öffnen Sie die gewünschte Präsentation mit dem eingebetteten OLE-Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse erstellen.

1. Erhalten Sie die Referenz der Folie über ihren Index.

1. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Form zu.

   In unserem Beispiel haben wir die zuvor erstellte PPTX verwendet, die nur eine Form auf der ersten Folie hat. Wir haben dann *casten* dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). Dies war das gewünschte OLE-Objekt-Frame, auf das zugegriffen werden sollte.

1. Sobald das OLE-Objekt-Frame zugänglich ist, können Sie jede Operation daran ausführen.

1. Erstellen Sie das Arbeitsbuchobjekt und greifen Sie auf die OLE-Daten zu.

1. Greifen Sie auf das gewünschte Arbeitsblatt zu und ändern Sie die Daten.

1. Speichern Sie das aktualisierte Arbeitsbuch in Streams.

1. Ändern Sie die OLE-Objektdaten auf Daten aus dem Stream.

Im folgenden Beispiel wird ein OLE-Objekt-Frame (ein in eine Folie eingebettetes Excel-Diagrammobjekt) zugegriffen – und dann werden seine Dateidaten geändert, um die Diagrammdaten zu ändern.

```py 
# [TODO:require Aspose.Cells für Python über .NET]
```

## Andere Dateitypen in Folien einbetten

Neben Excel-Diagrammen ermöglicht Aspose.Slides für Python über .NET das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML-, PDF- und ZIP-Dateien als Objekte in eine Folie einfügen. Wenn ein Benutzer auf das eingefügte Objekt doppelklickt, wird das Objekt automatisch im entsprechenden Programm gestartet, oder der Benutzer wird aufgefordert, ein passendes Programm zum Öffnen des Objekts auszuwählen. 

Dieser Python-Code zeigt Ihnen, wie Sie HTML und ZIP in eine Folie einbetten:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open(path + "index.html", "rb") as fs1:
        htmlBytes = fs1.read()
        dataInfoHtml = slides.dom.ole.OleEmbeddedDataInfo(htmlBytes, "html")
        oleFrameHtml = slide.shapes.add_ole_object_frame(150, 120, 50, 50, dataInfoHtml)
        oleFrameHtml.is_object_icon = True

    with open(path + "archive.zip", "rb") as fs2:
        zipBytes = fs2.read()
        dataInfoZip = slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip")
        oleFrameZip = slide.shapes.add_ole_object_frame(150, 220, 50, 50, dataInfoZip)
        oleFrameZip.is_object_icon = True

    pres.save("embeddedOle.pptx", slides.export.SaveFormat.PPTX)
```

## Dateitypen für eingebettete Objekte festlegen

Wenn Sie an Präsentationen arbeiten, müssen Sie möglicherweise alte OLE-Objekte durch neue ersetzen. Oder Sie müssen ein nicht unterstütztes OLE-Objekt durch ein unterstütztes ersetzen. 

Aspose.Slides für Python über .NET ermöglicht es Ihnen, den Dateityp für ein eingebettetes Objekt festzulegen. Auf diese Weise können Sie die OLE-Frame-Daten oder deren Erweiterung ändern. 

Dieser Python-Code zeigt Ihnen, wie Sie den Dateityp für ein eingebettetes OLE-Objekt festlegen:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("Aktuelle eingebettete Datenerweiterung ist:" + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## Icon-Bilder und Titel für eingebettete Objekte festlegen

Nachdem Sie ein OLE-Objekt eingebettet haben, wird automatisch eine Vorschau mit einem Symbolbild und Titel hinzugefügt. Die Vorschau ist das, was Benutzer sehen, bevor sie auf das OLE-Objekt zugreifen oder es öffnen. 

Wenn Sie ein bestimmtes Bild und einen bestimmten Text als Elemente in der Vorschau verwenden möchten, können Sie das Symbolbild und den Titel mit Aspose.Slides für Python über .NET festlegen. 

Dieser Python-Code zeigt Ihnen, wie Sie das Symbolbild und den Titel für ein eingebettetes Objekt festlegen: 

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    
    with open("img.jpeg", "rb") as in_file:
        oleImage = pres.images.add_image(in_file)

    oleObjectFrame.substitute_picture_title = "Mein Titel"
    oleObjectFrame.substitute_picture_format.picture.image = oleImage
    oleObjectFrame.is_object_icon = False

    pres.save("embeddedOle-newImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Verhindern, dass ein OLE-Objekt-Frame von PowerPoint neu dimensioniert und umpositioniert wird**

Nachdem Sie ein verknüpftes OLE-Objekt zu einer Präsentationsfolie hinzugefügt haben, sehen Sie möglicherweise eine Nachricht, wenn Sie die Präsentation in PowerPoint öffnen, die Sie auffordert, die Links zu aktualisieren. Durch Klicken auf die Schaltfläche "Links aktualisieren" kann sich die Größe und Position des OLE-Objekt-Frames ändern, da PowerPoint die Daten des verknüpften OLE-Objekts aktualisiert und die Objektvorschau aktualisiert. Um zu verhindern, dass PowerPoint dazu aufgefordert wird, setzen Sie die `update_automatic`-Eigenschaft der [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Klasse auf `False`:

```py
oleObjectFrame.update_automatic = False
```

## Extrahieren von eingebetteten Dateien

Aspose.Slides für Python über .NET ermöglicht es Ihnen, die in Folien als OLE-Objekte eingebetteten Dateien wie folgt zu extrahieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), die das OLE-Objekt enthält, das Sie extrahieren möchten.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Form zu.
3. Greifen Sie auf die Daten der eingebetteten Datei vom OLE-Objekt-Frame zu und schreiben Sie sie auf die Festplatte. 

Dieser Python-Code zeigt Ihnen, wie Sie eine in einer Folie als OLE-Objekt eingebettete Datei extrahieren:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    index = 0
    for shape in slide.shapes:

        if type(shape) is slides.OleObjectFrame:
            data = shape.embedded_data.embedded_file_data
            extension = shape.embedded_data.embedded_file_extension
            
            with open("oleFrame{idx}{ex}".format(idx = str(index), ex = extension), "wb") as fs:
                fs.write(data)
        index += 1
```