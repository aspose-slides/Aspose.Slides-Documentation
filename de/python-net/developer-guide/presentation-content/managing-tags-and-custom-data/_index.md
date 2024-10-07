---
title: Verwaltung von Tags und benutzerdefinierten Daten
type: docs
weight: 300
url: /python-net/managing-tags-and-custom-data/
keywords: "Tags, Benutzerdefinierte Daten, Wert für Tags, Tags hinzufügen, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Tags und benutzerdefinierte Daten zu PowerPoint-Präsentationen in Python hinzufügen"
---

## Datenspeicherung in Präsentationsdateien

PPTX-Dateien—Elemente mit der .pptx-Erweiterung—werden im PresentationML-Format gespeichert, das Teil der Office Open XML-Spezifikation ist. Das Office Open XML-Format definiert die Struktur für Daten, die in Präsentationen enthalten sind. 

Mit einer *Folie*, die eines der Elemente in Präsentationen ist, enthält ein *Foliensatz* den Inhalt einer einzelnen Folie. Ein Foliensatz darf explizite Beziehungen zu vielen Teilen haben—wie Benutzerdefinierte Tags—die von ISO/IEC 29500 definiert sind. 

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)) existieren. 

{{% alert color="primary" %}} 

Tags sind im Wesentlichen Werte von Schlüssel-Paaren aus Zeichenfolgen. 

{{% /alert %}} 

## Abrufen der Werte für Tags

In Folien entspricht ein Tag der IDocumentProperties.Keywords-Eigenschaft. Dieser Beispielcode zeigt Ihnen, wie Sie den Wert eines Tags mit Aspose.Slides für Python über .NET für [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) abrufen können:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## Tags zu Präsentationen hinzufügen

Aspose.Slides ermöglicht es Ihnen, Präsentationen mit Tags zu versehen. Ein Tag besteht typischerweise aus zwei Elementen: 

- dem Namen einer benutzerdefinierten Eigenschaft - `MyTag` 
- dem Wert der benutzerdefinierten Eigenschaft - `My Tag Value`

Wenn Sie einige Präsentationen basierend auf einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie von der Verwendung von Tags in diesen Präsentationen profitieren. Wenn Sie beispielsweise alle Präsentationen aus nordamerikanischen Ländern kategorisieren oder zusammenstellen möchten, können Sie einen nordamerikanischen Tag erstellen und dann die relevanten Länder (die USA, Mexiko und Kanada) als Werte zuweisen. 

Dieser Beispielcode zeigt Ihnen, wie Sie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) mit Aspose.Slides für Python über .NET hinzufügen können:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Tags können auch für [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) festgelegt werden:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Oder für jede einzelne [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "Mein Text"
    shape.custom_data.tags.add("tag", "value")
```