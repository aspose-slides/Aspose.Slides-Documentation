---
title: Slides aus Präsentationen in Python entfernen
linktitle: Slide entfernen
type: docs
weight: 30
url: /de/python-net/remove-slide-from-presentation/
keywords:
- Slide entfernen
- Slide löschen
- Unbenutzte Folie entfernen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entfernen Sie mühelos Folien aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python über .NET. Erhalten Sie klare Codebeispiele und steigern Sie Ihren Workflow."
---

## **Übersicht**

Wenn eine Folie (oder deren Inhalte) nicht mehr benötigt wird, können Sie sie löschen. Aspose.Slides stellt die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse bereit, die [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) kapselt, das Repository für alle Folien in einer Präsentation. Mit einer Referenz oder einem Index zu einem bekannten [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) Objekt können Sie die Ziel‑Folie entfernen.

## **Folie per Referenz entfernen**

Wenn Sie bereits eine Referenz zur Ziel‑[Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) haben, können Sie sie direkt entfernen. Das vermeidet Index‑Nachschlagen und hält den Code kürzer und klarer.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie eine Referenz auf die Folie, die Sie entfernen möchten, anhand ihrer ID oder ihres Index.
1. Entfernen Sie die referenzierte Folie aus der Präsentation.
1. Speichern Sie die geänderte Präsentation.

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    # Greifen Sie auf eine Folie über ihren Index in der Folienammlung zu.
    slide = presentation.slides[0]

    # Entfernen Sie die Folie per Referenz.
    presentation.slides.remove(slide)

    # Speichern Sie die geänderte Präsentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Folie per Index entfernen**

Wenn Sie die Position der Folie in der Präsentation kennen, löschen Sie sie anhand ihres Index. Das ist besonders praktisch in Schleifen oder Batch‑Operationen, bei denen die Positionen im Voraus bekannt sind.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Entfernen Sie die Folie anhand ihres Index.
1. Speichern Sie die geänderte Präsentation.

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, um eine Präsentationsdatei zu öffnen.
with slides.Presentation("sample.pptx") as presentation:
    # Entfernen Sie die Folie über ihren Index.
    presentation.slides.remove_at(0)

    # Speichern Sie die geänderte Präsentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Unbenutzte Layout‑Folie entfernen**

Aspose.Slides stellt die Methode `remove_unused_layout_slides` in der [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) Klasse bereit, um unerwünschte, unbenutzte Layout‑Folien zu löschen. Das folgende Python‑Beispiel zeigt, wie unbenutzte Layout‑Folien aus einer PowerPoint‑Präsentation entfernt werden:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Unbenutzte Master‑Folie entfernen**

Aspose.Slides stellt die Methode `remove_unused_master_slides` in der [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) Klasse bereit, um unerwünschte, unbenutzte Master‑Folien zu löschen. Das folgende Python‑Beispiel zeigt, wie unbenutzte Master‑Folien aus einer PowerPoint‑Präsentation entfernt werden:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Was passiert mit den Folien‑Indizes, nachdem ich eine Folie gelöscht habe?**

Nach dem Löschen reindiziert die [collection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/): Jede nachfolgende Folie rückt um eine Position nach links, sodass frühere Index‑Nummern veraltet sind. Wenn Sie eine stabile Referenz benötigen, verwenden Sie die beständige ID jeder Folie anstelle ihres Index.

**Unterscheidet sich die ID einer Folie vom Index und ändert sie sich, wenn benachbarte Folien gelöscht werden?**

Ja. Der Index ist die Position der Folie und ändert sich, wenn Folien hinzugefügt oder entfernt werden. Die Folien‑ID ist ein beständiger Bezeichner und ändert sich nicht, wenn andere Folien gelöscht werden.

**Wie wirkt sich das Löschen einer Folie auf Folienabschnitte aus?**

Wenn die Folie zu einem Abschnitt gehörte, enthält dieser Abschnitt einfach eine Folie weniger. Die Abschnittsstruktur bleibt erhalten; wird ein Abschnitt leer, können Sie [Abschnitte entfernen oder neu organisieren](/slides/de/python-net/slide-section/) nach Bedarf durchführen.

**Was passiert mit Notizen und Kommentaren, die an einer Folie angehängt sind, wenn sie gelöscht wird?**

[Notizen](/slides/de/python-net/presentation-notes/) und [Kommentare](/slides/de/python-net/presentation-comments/) sind an diese spezifische Folie gebunden und werden zusammen mit ihr entfernt. Inhalte anderer Folien bleiben unverändert.

**Wie unterscheidet sich das Löschen von Folien vom Aufräumen unbenutzter Layouts/Master?**

Beim Löschen werden bestimmte reguläre Folien aus der Präsentation entfernt. Das Aufräumen unbenutzter Layouts/Master entfernt Layout‑ oder Master‑Folien, auf die nichts verweist, wodurch die Dateigröße reduziert wird, ohne den Inhalt der übrigen Folien zu ändern. Diese Aktionen ergänzen sich: In der Regel zuerst löschen, dann aufräumen.