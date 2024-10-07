---
title: OLE Verwaltunng
type: docs
weight: 40
url: /python-net/manage-ole/
keywords:
- OLE hinzufügen
- OLE einbetten
- ein Objekt hinzufügen
- ein Objekt einbetten
- eine Datei einbetten
- verknüpftes Objekt
- Object Linking & Embedding
- OLE Objekt
- PowerPoint 
- Präsentation
- Python
- Aspose.Slides für Python über .NET
description: Fügen Sie OLE-Objekte in PowerPoint-Präsentationen in Python hinzu
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) ist eine Microsoft-Technologie, die es ermöglicht, Daten und Objekte, die in einer Anwendung erstellt wurden, über Verknüpfung oder Einbettung in einer anderen Anwendung zu platzieren.

{{% /alert %}} 

Betrachten Sie ein Diagramm, das in MS Excel erstellt wurde. Das Diagramm wird dann in eine PowerPoint-Folie eingefügt. Dieses Excel-Diagramm wird als OLE-Objekt betrachtet.

- Ein OLE-Objekt kann als Symbol erscheinen. In diesem Fall wird das Diagramm beim Doppelklicken auf das Symbol in der zugehörigen Anwendung (Excel) geöffnet oder Sie werden aufgefordert, eine Anwendung zum Öffnen oder Bearbeiten des Objekts auszuwählen.
- Ein OLE-Objekt kann die tatsächlichen Inhalte anzeigen – z. B. die Inhalte eines Diagramms. In diesem Fall wird das Diagramm in PowerPoint aktiviert, die Diagrammschnittstelle wird geladen und Sie können die Daten des Diagramms innerhalb der PowerPoint-App ändern.

[Aspose.Slides für Python über .NET](https://products.aspose.com/slides/python-net) ermöglicht es Ihnen, OLE-Objekte als OLE-Objekt-Frames ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)) in Folien einzufügen.

## **Hinzufügen von OLE-Objekt-Frames zu Folien**
Angenommen, Sie haben bereits ein Diagramm in Microsoft Excel erstellt und möchten dieses Diagramm als OLE-Objekt-Frame in eine Folie mit Aspose.Slides für Python über .NET einbetten, dann können Sie es folgendermaßen tun:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zur Folie über ihren Index.
1. Öffnen Sie die Excel-Datei, die das Excel-Diagramm-Objekt enthält, und speichern Sie sie in `MemoryStream`.
1. Fügen Sie den OLE-Objekt-Frame zur Folie hinzu, der das Array von Bytes und andere Informationen über das OLE-Objekt enthält.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir ein Diagramm aus einer Excel-Datei zu einer Folie als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) mit Aspose.Slides für Python über .NET hinzugefügt.  
**Hinweis**, dass der [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/) Konstruktor ein einbettbares Objekt-Extension als zweiten Parameter erwartet. Diese Erweiterung ermöglicht es PowerPoint, den Datei-Typ korrekt zu interpretieren und die richtige Anwendung zum Öffnen dieses OLE-Objekts auszuwählen.

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

        # Fügt eine Ole Object Frame-Form hinzu
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # Schreibt die PPTX-Datei auf die Festplatte
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Zugriff auf OLE-Objekt-Frames**
Wenn ein OLE-Objekt bereits in eine Folie eingebettet ist, können Sie dieses Objekt einfach folgendermaßen finden oder darauf zugreifen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.

1. Erhalten Sie die Referenz der Folie, indem Sie ihren Index verwenden.

1. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Form zu.

   In unserem Beispiel verwendeten wir das zuvor erstellte PPTX, das nur eine Form auf der ersten Folie enthält. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) *verwiesen*. Dies war der gewünschte OLE-Objekt-Frame, auf den zugegriffen werden sollte.

1. Sobald der OLE-Objekt-Frame zugegriffen ist, können Sie jede Operation daran durchführen.

Im folgenden Beispiel wird ein OLE-Objekt-Frame (ein Excel-Diagramm-Objekt, das in eine Folie eingebettet ist) zugegriffen – und dann werden die Dateidaten in eine Excel-Datei geschrieben:

```py 
import aspose.slides as slides

# Lädt das PPTX in ein Präsentationsobjekt
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Wandelt die Form in OleObjectFrame um
    oleObjectFrame = sld.shapes[0]

    # Liest das OLE-Objekt und schreibt es auf die Festplatte
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # Holen Sie sich die eingebetteten Dateidaten
        data = oleObjectFrame.embedded_data.embedded_file_data

        # Holen Sie sich die eingebettete Dateierweiterung
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # Erstellt einen Pfad zum Speichern der extrahierten Datei
        extractedPath = "excelFromOLE_out" + fileExtention

        # Speichert die extrahierten Daten
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **Ändern von OLE-Objektdaten**

Wenn ein OLE-Objekt bereits in eine Folie eingebettet ist, können Sie dieses Objekt einfach mit Aspose.Slides für Python über .NET zugreifen und seine Daten auf folgende Weise ändern:

1. Öffnen Sie die gewünschte Präsentation mit dem eingebetteten OLE-Objekt, indem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse erstellen.

1. Holen Sie sich die Referenz der Folie über ihren Index.

1. Greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Form zu.

   In unserem Beispiel verwendeten wir das zuvor erstellte PPTX, das nur eine Form auf der ersten Folie enthält. Wir haben dann dieses Objekt als [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) *verwiesen*. Dies war der gewünschte OLE-Objekt-Frame, auf den zugegriffen werden sollte.

1. Sobald der OLE-Objekt-Frame zugegriffen ist, können Sie jede Operation daran durchführen.

1. Erstellen Sie das Workbook-Objekt und greifen Sie auf die OLE-Daten zu.

1. Greifen Sie auf das gewünschte Arbeitsblatt zu und ändern Sie die Daten.

1. Speichern Sie das aktualisierte Workbook in Streams.

1. Ändern Sie die OLE-Objektdaten aus den Stream-Daten.

Im folgenden Beispiel wird ein OLE-Objekt-Frame (ein Excel-Diagramm-Objekt, das in eine Folie eingebettet ist) zugegriffen – und dann werden seine Dateidaten geändert, um die Diagrammdaten zu ändern.

```py 
# [TODO:require Aspose.Cells for Python via .NET]
```

## Andere Dateitypen in Folien einbetten

Neben Excel-Diagrammen ermöglicht Aspose.Slides für Python über .NET das Einbetten anderer Dateitypen in Folien. Beispielsweise können Sie HTML-, PDF- und ZIP-Dateien als Objekte in eine Folie einfügen. Wenn ein Benutzer auf das eingefügte Objekt doppelklickt, wird das Objekt automatisch im entsprechenden Programm geöffnet, oder der Benutzer wird aufgefordert, ein geeignetes Programm zum Öffnen des Objekts auszuwählen. 

Dieser Python-Code zeigt Ihnen, wie Sie HTML und ZIP in eine Folie einbetten können:

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

## Festlegen von Dateitypen für eingebettete Objekte

Wenn Sie an Präsentationen arbeiten, müssen Sie möglicherweise alte OLE-Objekte durch neue ersetzen. Oder Sie müssen ein nicht unterstütztes OLE-Objekt durch ein unterstütztes ersetzen. 

Aspose.Slides für Python über .NET ermöglicht es Ihnen, den Dateityp für ein eingebettetes Objekt festzulegen. Auf diese Weise können Sie die OLE-Frame-Daten oder deren Erweiterung ändern. 

Dieser Python-Code zeigt Ihnen, wie Sie den Dateityp für ein eingebettetes OLE-Objekt festlegen können:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("Der aktuelle eingebettete Daten-Erweiterung beträgt:" + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## Festlegen von Symbolbildern und Titeln für eingebettete Objekte

Nachdem Sie ein OLE-Objekt eingefügt haben, wird automatisch eine Vorschau mit einem Symbolbild und einem Titel hinzugefügt. Die Vorschau ist das, was die Benutzer sehen, bevor sie auf das OLE-Objekt zugreifen oder es öffnen. 

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

## **Verhindern, dass ein OLE-Objekt-Frame verändert oder repositioniert wird**

Nachdem Sie ein verknüpftes OLE-Objekt zu einer Präsentationsfolie hinzugefügt haben, sehen Sie möglicherweise eine Nachricht, die Sie auffordert, die Links zu aktualisieren, wenn Sie die Präsentation in PowerPoint öffnen. Wenn Sie auf die Schaltfläche "Links aktualisieren" klicken, kann sich die Größe und Position des OLE-Objekt-Frames ändern, da PowerPoint die Daten vom verknüpften OLE-Objekt aktualisiert und die Vorschau des Objekts aktualisiert. Um zu verhindern, dass PowerPoint aufgefordert wird, die Objektdaten zu aktualisieren, setzen Sie die `update_automatic` Eigenschaft der [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Klasse auf `False`:

```py
oleObjectFrame.update_automatic = False
```

## Extrahieren von eingebetteten Dateien

Aspose.Slides für Python über .NET ermöglicht es Ihnen, die in Folien als OLE-Objekte eingebetteten Dateien auf folgende Weise zu extrahieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die das OLE-Objekt enthält, das Sie extrahieren möchten.
2. Durchlaufen Sie alle Formen in der Präsentation und greifen Sie auf die [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) Form zu.
3. Greifen Sie auf die Daten der eingebetteten Datei aus dem OLE-Objekt-Frame zu und schreiben Sie sie auf die Festplatte. 

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