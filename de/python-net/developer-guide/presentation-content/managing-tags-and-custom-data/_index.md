---
title: "Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit Python"
linktitle: "Tags und benutzerdefinierte Daten"
type: docs
weight: 300
url: /de/python-net/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte Daten in Aspose.Slides für Python via .NET hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Elemente mit der Endung .pptx — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Das Office Open XML‑Format definiert die Struktur der in Präsentationen enthaltenen Daten.

Ein *Slide* ist eines der Elemente in Präsentationen; ein *Slide‑Part* enthält den Inhalt einer einzelnen Folie. Ein Slide‑Part darf explizite Beziehungen zu vielen Teilen haben — wie z. B. benutzerdefinierten Tags — die nach ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten (spezifisch für eine Präsentation) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)) vorliegen.

{{% alert color="primary" %}} 
Tags sind im Wesentlichen Schlüssel‑Wert‑Paare vom Typ Zeichenfolge. 
{{% /alert %}} 

## **Werte von Tags abrufen**

In Folien entspricht ein Tag der Eigenschaft IDocumentProperties.Keywords. Dieser Beispielcode zeigt, wie Sie den Wert eines Tags mit Aspose.Slides für Python via .NET für [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) erhalten:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```


## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- der Name einer benutzerdefinierten Eigenschaft - `MyTag` 
- der Wert der benutzerdefinierten Eigenschaft - `My Tag Value`

Wenn Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren möchten, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Zum Beispiel können Sie, um alle Präsentationen aus nordamerikanischen Ländern zu gruppieren, einen Tag „NorthAmerican“ erstellen und die relevanten Länder (USA, Mexiko und Kanada) als Werte zuweisen.

Dieser Beispielcode zeigt, wie Sie einem [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) mit Aspose.Slides für Python via .NET einen Tag hinzufügen:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```


Tags können auch für [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) gesetzt werden:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```


Oder für ein einzelnes [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```


## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) unterstützt die [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie die [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/)‑Methode der [TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu entfernen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) auf der [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.