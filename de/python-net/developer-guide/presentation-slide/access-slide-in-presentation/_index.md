---
title: Folien in Präsentationen mit Python zugreifen
linktitle: Folie zugreifen
type: docs
weight: 20
url: /de/python-net/access-slide-in-presentation/
keywords:
- Folie zugreifen
- Folienindex
- Folien-ID
- Folienposition
- Position ändern
- Folieneigenschaften
- Foliennummer
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folien in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET zugreifen und verwalten. Steigern Sie die Produktivität mit Code‑Beispielen."
---

## **Übersicht**

Dieser Artikel erklärt, wie Sie mit Aspose.Slides für Python auf bestimmte Folien in einer PowerPoint‑Präsentation zugreifen. Er zeigt, wie Sie eine Präsentation öffnen, Folien per Index oder eindeutiger ID referenzieren und grundlegende Folieninformationen auslesen, die für die Navigation innerhalb der Datei benötigt werden. Mit diesen Techniken können Sie zuverlässig die exakte Folie finden, die Sie prüfen oder verarbeiten wollen.

## **Folie nach Index öffnen**

Folien in einer Präsentation sind nach ihrer Position indiziert, beginnend bei 0. Die erste Folie hat den Index 0, die zweite Folie den Index 1 usw.

Die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse (die eine Präsentationsdatei repräsentiert) stellt Folien über eine [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) von [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)‑Objekten bereit.

Der folgende Python‑Code zeigt, wie Sie eine Folie über ihren Index zugreifen:

```python
import aspose.slides as slides

# Erstellen einer Presentation, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("sample.pptx") as presentation:
    # Folie über ihren Index abrufen.
    slide = presentation.slides[0]
```

## **Folie nach ID öffnen**

Jede Folie in einer Präsentation besitzt eine eindeutige ID. Sie können die Methode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse) verwenden, um diese ID anzusprechen.

Der folgende Python‑Code zeigt, wie Sie eine gültige Folien‑ID ermitteln und die Folie über die Methode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) zugreifen:

```python
import aspose.slides as slides

# Erstellen einer Presentation, die eine Präsentationsdatei repräsentiert.
with slides.Presentation("sample.pptx") as presentation:
    # Folien‑ID ermitteln.
    id = presentation.slides[0].slide_id
    # Folie über ihre ID zugreifen.
    slide = presentation.get_slide_by_id(id)
```

## **Position einer Folie ändern**

Aspose.Slides ermöglicht das Ändern der Position einer Folie. Zum Beispiel können Sie die erste Folie zur zweiten machen.

1. Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse erstellen.  
2. Referenz auf die Folie holen, deren Position Sie per Index ändern möchten.  
3. Neue Position für die Folie über die Eigenschaft [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) festlegen.  
4. Die geänderte Präsentation speichern.

Der folgende Python‑Code verschiebt die Folie an Position 1 zu Position 2:

```python
import aspose.slides as slides

# Instanziieren eines Presentation‑Objekts, das eine Präsentationsdatei repräsentiert.
with slides.Presentation("sample.pptx") as presentation:
    # Folie holen, deren Position geändert werden soll.
    slide = presentation.slides[0]
    # Neue Position für die Folie festlegen.
    slide.slide_number = 2
    # Geänderte Präsentation speichern.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Die erste Folie wird zur zweiten; die zweite Folie wird zur ersten. Beim Ändern der Position einer Folie werden andere Folien automatisch angepasst.

## **Foliennummer festlegen**

Über die Eigenschaft [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang bewirkt, dass die übrigen Foliennummern neu berechnet werden.

1. Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse erstellen.  
2. Foliennummer festlegen.  
3. Geänderte Präsentation speichern.

Der folgende Python‑Code demonstriert die Festlegung der ersten Foliennummer auf 10:

```python
import aspose.slides as slides

# Instanziieren eines Presentation‑Objekts, das eine Präsentationsdatei repräsentiert.
with slides.Presentation("sample.pptx") as presentation:
    # Foliennummer festlegen.
    presentation.first_slide_number = 10
    # Geänderte Präsentation speichern.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummer auf der ersten Folie ausblenden) wie folgt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Nummer für die erste Folie in der Präsentation festlegen.
    presentation.first_slide_number = 0

    # Foliennummern für alle Folien anzeigen.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Foliennummer auf der ersten Folie ausblenden.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Geänderte Präsentation speichern.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Stimmt die vom Benutzer gesehene Foliennummer mit dem nullbasierten Index der Sammlung überein?**

Die auf einer Folie angezeigte Nummer kann von einem beliebigen Wert (z. B. 10) starten und muss nicht dem Index entsprechen; die Beziehung wird über die Einstellung [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) der Präsentation gesteuert.

**Beeinflussen versteckte Folien die Indizierung?**

Ja. Eine versteckte Folie bleibt in der Sammlung und wird bei der Indizierung gezählt; „versteckt“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfügen, Löschen und Verschieben neu berechnet.