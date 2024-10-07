---
title: SmartArt verwalten
type: docs
weight: 10
url: /python-net/manage-smartart/
keywords: "SmartArt, Text aus SmartArt, Organigramm, Bildorganigramm, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "SmartArt und Organigramm in PowerPoint-Präsentationen in Python"
---

## **Text aus SmartArt abrufen**
Nachdem die TextFrame-Eigenschaft zur ISmartArtShape-Schnittstelle und zur SmartArtShape-Klasse hinzugefügt wurde, können Sie nun den gesamten Text aus SmartArt abrufen, wenn es nicht nur Text von Knoten gibt. Der folgende Beispielcode hilft Ihnen, Text aus einem SmartArt-Knoten zu extrahieren.

```py
import aspose.slides as slides

with slides.Presentation(path + "SmartArt.pptx") as pres:
    slide = pres.slides[0]
    smartArt = slide.shapes[0]

    for smartArtNode in smartArt.all_nodes:
        for nodeShape in smartArtNode.shapes:
            if nodeShape.text_frame != None:
                print(nodeShape.text_frame.text)
```



## **Layouttyp von SmartArt ändern**
Um den Layouttyp von SmartArt zu ändern, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Erhalten Sie die Referenz einer Folie mithilfe ihres Index.
- Fügen Sie SmartArt BasicBlockList hinzu.
- Ändern Sie LayoutType in BasicProcess.
- Speichern Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Fügen Sie SmartArt BasicProcess hinzu 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Ändern Sie LayoutType in BasicProcess
    smart.layout = art.SmartArtLayoutType.BASIC_PROCESS
    # Präsentation speichern
    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Versteckte Eigenschaft von SmartArt überprüfen**
Bitte beachten Sie, dass die Methode com.aspose.slides.ISmartArtNode.isHidden() true zurückgibt, wenn dieser Knoten ein versteckter Knoten im Datenmodell ist. Um die versteckte Eigenschaft eines beliebigen Knotens von SmartArt zu überprüfen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Fügen Sie SmartArt RadialCycle hinzu.
- Fügen Sie einen Knoten zu SmartArt hinzu.
- Überprüfen Sie die isHidden-Eigenschaft.
- Speichern Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Fügen Sie SmartArt BasicProcess hinzu 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.RADIAL_CYCLE)
    # Fügen Sie einen Knoten zu SmartArt hinzu 
    node = smart.all_nodes.add_node()
    # Überprüfen Sie die isHidden-Eigenschaft
    if node.is_hidden:
        print("versteckt")
        # Führen Sie einige Aktionen oder Benachrichtigungen durch
    # Präsentation speichern
    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Organigrammtyp abrufen oder festlegen**
Die Methoden com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) ermöglichen das Abrufen oder Festlegen des mit dem aktuellen Knoten verbundenen Organigrammtyps. Um den Organigrammtyp abzurufen oder festzulegen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der `Presentation`-Klasse.
- Fügen Sie SmartArt zur Folie hinzu.
- Holen Sie den Organigrammtyp ab oder legen Sie ihn fest.
- Speichern Sie die Präsentation als PPTX-Datei.
  Im folgenden Beispiel haben wir einen Connector zwischen zwei Formen hinzugefügt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Fügen Sie SmartArt BasicProcess hinzu 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.ORGANIZATION_CHART)
    # Holen Sie den Organigrammtyp ab oder legen Sie ihn fest 
    smart.nodes[0].organization_chart_layout = art.OrganizationChartLayoutType.LEFT_HANGING
    # Präsentation speichern
    presentation.save("OrganizeChartLayoutType_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Bildorganigramm erstellen**
Aspose.Slides für Python über .NET bietet eine einfache API zum Erstellen von PictureOrganization Diagrammen auf einfache Weise. Um ein Diagramm auf einer Folie zu erstellen:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Erhalten Sie die Referenz einer Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (ChartType.PictureOrganizationChart) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Der folgende Code wird verwendet, um ein Diagramm zu erstellen.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as pres:
    smartArt = pres.slides[0].shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    pres.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```