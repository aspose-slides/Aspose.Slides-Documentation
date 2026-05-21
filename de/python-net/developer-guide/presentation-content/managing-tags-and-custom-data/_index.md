---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit Python
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/python-net/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- Tag hinzufügen
- Wertpaare
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte Daten in Aspose.Slides für Python via .NET hinzufügen, lesen, aktualisieren und entfernen, mit Beispielen für PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Er gibt einen kurzen Überblick darüber, wie Daten in PPTX‑Dateien gespeichert werden, weist darauf hin, dass präsentationsspezifische Daten als Tags und benutzerdefinierte XML‑Teile existieren können, und beschreibt Tags als Schlüssel‑Wert‑Zeichenkettenpaare.  

Er zeigt außerdem, wie Tag‑Werte gelesen und wie Tags zu einer Präsentation, einer einzelnen Folie oder einer Form hinzugefügt werden können. Zusätzlich behandelt der Artikel gängige Tag‑Verwaltungsaufgaben wie das Löschen aller Tags, das Entfernen eines Tags nach Namen und das Abrufen der Liste der Tag‑Namen.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien – Objekte mit der Erweiterung .pptx – werden im PresentationML‑Format gespeichert, das Teil der Office‑Open‑XML‑Spezifikation ist. Das Office‑Open‑XML‑Format definiert die Struktur der in Präsentationen enthaltenen Daten.  

Da eine *Folie* eines der Elemente in Präsentationen ist, enthält ein *Folien‑Teil* den Inhalt einer einzelnen Folie. Ein Folien‑Teil darf explizite Beziehungen zu vielen Teilen haben – etwa zu benutzerdefinierten Tags – die von ISO/IEC 29500 definiert werden.  

Benutzerdefinierte Daten (präsentationsspezifisch) oder Benutzer können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/itagcollection/)) und CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/icustomxmlpartcollection/)) existieren.  

{{% alert color="primary" %}}  
Tags sind im Wesentlichen Schlüssel‑Wert‑Paare von Zeichenketten.  
{{% /alert %}}  

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Eigenschaft IDocumentProperties.Keywords. Dieser Beispielcode zeigt, wie man den Wert eines Tags mit Aspose.Slides für Python via .NET für [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) erhält:  

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- den Namen einer benutzerdefinierten Eigenschaft – `MyTag`
- dem Wert der benutzerdefinierten Eigenschaft – `My Tag Value`

Wenn Sie einige Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie davon profitieren, Tags zu diesen Präsentationen hinzuzufügen. Zum Beispiel, wenn Sie alle Präsentationen aus nordamerikanischen Ländern gruppieren möchten, können Sie ein Tag „North American“ erstellen und dann die entsprechenden Länder (USA, Mexiko und Kanada) als Werte zuweisen.  

Dieser Beispielcode zeigt, wie man ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) mit Aspose.Slides für Python via .NET hinzufügt:  

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Tags können auch für [Slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/) gesetzt werden:  

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Oder für jede einzelne [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/):  

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Einschränkungen**

Tags, die über die Sammlung `custom_data.tags` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation als PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.  

**Lösung**: Sie können einen benutzerdefinierten Bezeichner im **Alt Text** des Objekts speichern (z. B. `shape.alternative_text = "MyId"`). Nach dem Exportieren zu PDF kann der Alt Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**  

Ja. Die [tag collection](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.  

**Wie kann ich ein einzelnes Tag nach seinem Namen löschen, ohne die gesamte Sammlung zu iterieren?**  

Verwenden Sie die [remove(name)](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/remove/)‑Operation auf der [TagCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.  

**Wie kann ich die vollständige Liste der Tag-Namen für Analysen oder Filterung abrufen?**  

Verwenden Sie [get_names_of_tags](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/get_names_of_tags/) auf der [tag collection](https://reference.aspose.com/slides/de/python-net/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.