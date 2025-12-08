---
title: Folien in Präsentationen mit Python zugreifen
linktitle: Folienzugriff
type: docs
weight: 20
url: /de/python-net/access-slide-in-presentation/
keywords:
- Folienzugriff
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
description: "Erfahren Sie, wie Sie Folien in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET zugreifen und verwalten können. Steigern Sie die Produktivität mit Codebeispielen."
---

## **Übersicht**

Dieser Artikel erklärt, wie man auf bestimmte Folien in einer PowerPoint-Präsentation mit Aspose.Slides für Python zugreift. Er zeigt, wie man eine Präsentation öffnet, Folien nach Index oder eindeutiger ID referenziert und grundlegende Folieninformationen liest, die für die Navigation innerhalb der Datei benötigt werden. Mit diesen Techniken können Sie die genaue Folie, die Sie prüfen oder verarbeiten möchten, zuverlässig finden.

## **Zugriff auf eine Folie nach Index**

Folien in einer Präsentation werden nach ihrer Position indexiert, beginnend bei 0. Die erste Folie hat den Index 0, die zweite Folie hat den Index 1 und so weiter.

Die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (die eine Präsentationsdatei darstellt) stellt Folien über eine [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) von [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)-Objekten bereit.

Der folgende Python-Code zeigt, wie man auf eine Folie nach ihrem Index zugreift:
```python
import aspose.slides as slides

# Erstelle ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
with slides.Presentation("sample.pptx") as presentation:
    # Hole eine Folie anhand ihres Indexes.
    slide = presentation.slides[0]
```


## **Zugriff auf eine Folie nach ID**

Jede Folie in einer Präsentation hat eine eindeutige ID, die ihr zugeordnet ist. Sie können die Methode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (die von der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) bereitgestellt wird) verwenden, um diese ID anzusteuern. 

Der folgende Python-Code zeigt, wie man eine gültige Folien-ID angibt und über die Methode [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) auf diese Folie zugreift:
```python
import aspose.slides as slides

# Erstelle ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
with slides.Presentation("sample.pptx") as presentation:
    # Erhalte die Folien-ID.
    id = presentation.slides[0].slide_id
    # Greife auf die Folie über ihre ID zu.
    slide = presentation.get_slide_by_id(id)
```


## **Ändern der Position einer Folie**

Aspose.Slides ermöglicht es, die Position einer Folie zu ändern. Zum Beispiel können Sie die erste Folie zur zweiten machen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf die Folie, deren Position Sie anhand ihres Index ändern möchten.
1. Setzen Sie eine neue Position für die Folie über die Eigenschaft [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
1. Speichern Sie die geänderte Präsentation.

Der folgende Python-Code verschiebt die Folie von Position 1 nach Position 2:
```python
import aspose.slides as slides

# Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
with slides.Presentation("sample.pptx") as presentation:
    # Hole die Folie, deren Position geändert wird.
    slide = presentation.slides[0]
    # Setze die neue Position für die Folie.
    slide.slide_number = 2
    # Speichere die geänderte Präsentation.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```


Die erste Folie wird zur zweiten; die zweite Folie wird zur ersten. Wenn Sie die Position einer Folie ändern, werden die anderen Folien automatisch angepasst.

## **Festlegen der Foliennummer**

Mit der Eigenschaft [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (die von der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) bereitgestellt wird) können Sie eine neue Nummer für die erste Folie in einer Präsentation festlegen. Dieser Vorgang führt dazu, dass die anderen Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Legen Sie die Foliennummer fest.
1. Speichern Sie die geänderte Präsentation.

Der folgende Python-Code demonstriert einen Vorgang, bei dem die erste Foliennummer auf 10 gesetzt wird:
```python
import aspose.slides as slides

# Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt.
with slides.Presentation("sample.pptx") as presentation:
    # Setze die Foliennummer.
    presentation.first_slide_number = 10
    # Speichere die geänderte Präsentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```


Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummer auf der ersten Folie ausblenden), wie folgt:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Setze die Nummer für die erste Folie in der Präsentation.
    presentation.first_slide_number = 0

    # Zeige Foliennummern für alle Folien an.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Verstecke die Foliennummer auf der ersten Folie.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Speichere die geänderte Präsentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Stimmt die von einem Benutzer sichtbare Foliennummer mit dem nullbasierten Index der Sammlung überein?**

Die auf einer Folie angezeigte Nummer kann bei einem beliebigen Wert beginnen (z. B. 10) und muss nicht mit dem Index übereinstimmen; die Beziehung wird durch die Einstellung [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien die Indexierung?**

Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indexierung gezählt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**

Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfüge-, Lösch- und Verschiebevorgängen neu berechnet.