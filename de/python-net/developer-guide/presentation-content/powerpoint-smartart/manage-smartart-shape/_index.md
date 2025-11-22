---
title: SmartArt-Grafiken in Präsentationen mit Python verwalten
linktitle: SmartArt-Grafiken
type: docs
weight: 20
url: /de/python-net/manage-smartart-shape/
keywords:
- SmartArt-Objekt
- SmartArt-Grafik
- SmartArt-Stil
- SmartArt-Farbe
- SmartArt erstellen
- SmartArt hinzufügen
- SmartArt bearbeiten
- SmartArt ändern
- SmartArt zugreifen
- SmartArt-Layouttyp
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Automatisieren Sie die Erstellung, Bearbeitung und Gestaltung von PowerPoint‑SmartArt in Python über .NET mit Aspose.Slides, inklusive knapper Code‑Beispiele und leistungsorientierter Anleitung."
---

## **SmartArt‑Formen erstellen**

Aspose.Slides für Python via .NET ermöglicht das Hinzufügen benutzerdefinierter SmartArt‑Formen zu Folien von Grund auf. Die API macht dies einfach. So fügen Sie einer Folie eine SmartArt‑Form hinzu:

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Rufen Sie die Ziel‑Folie über ihren Index ab.
3. Fügen Sie eine SmartArt‑Form hinzu und geben Sie deren Layout‑Typ an.
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:
    # Greifen Sie auf die Präsentationsfolie zu.
    slide = presentation.slides[0]
    # Fügen Sie eine SmartArt-Form hinzu.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **SmartArt‑Formen auf Folien zugreifen**

Der folgende Code zeigt, wie Sie auf SmartArt‑Formen einer Folie zugreifen können. Das Beispiel iteriert über jede Form auf der Folie und prüft, ob es sich um ein [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)-Objekt handelt.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Laden Sie eine Präsentationsdatei.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Durchlaufen Sie jede Form auf der ersten Folie.
    for shape in presentation.slides[0].shapes:
        # Prüfen Sie, ob die Form eine SmartArt-Form ist.
        if isinstance(shape, smartart.SmartArt):
            # Geben Sie den Namen der Form aus.
            print("Shape name:", shape.name)
```


## **Zugriff auf SmartArt‑Formen mit einem angegebenen Layout‑Typ**

Das folgende Beispiel zeigt, wie Sie auf eine SmartArt‑Form mit einem angegebenen Layout‑Typ zugreifen können. Beachten Sie, dass Sie den Layout‑Typ einer SmartArt nicht ändern können – er ist schreibgeschützt und wird beim Erstellen der Form festgelegt.

1. Erstellen Sie eine Instanz von [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), und laden Sie die Präsentation, die die SmartArt‑Form enthält.
2. Rufen Sie über den Index die erste Folie ab.
3. Iterieren Sie über jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form ein [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)-Objekt ist.
5. Wenn der Layout‑Typ der SmartArt‑Form mit dem gewünschten übereinstimmt, führen Sie die erforderlichen Aktionen aus.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Durchlaufen Sie jede Form auf der ersten Folie.
    for shape in presentation.slides[0].shapes:
        # Prüfen Sie, ob die Form eine SmartArt-Form ist.
        if isinstance(shape, smartart.SmartArt):
            # Prüfen Sie den SmartArt-Layouttyp.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```


## **SmartArt‑Formstil ändern**

Das folgende Beispiel zeigt, wie Sie SmartArt‑Formen finden und deren Stil ändern können:

1. Erstellen Sie eine [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Datei, die die SmartArt‑Form(en) enthält.
2. Rufen Sie über den Index die erste Folie ab.
3. Iterieren Sie über jede Form auf der ersten Folie.
4. Suchen Sie die SmartArt‑Form mit dem angegebenen Stil.
5. Weisen Sie der SmartArt‑Form den neuen Stil zu.
6. Speichern Sie die Präsentation.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Durchlaufen Sie jede Form auf der ersten Folie.
    for shape in presentation.slides[0].shapes:
        # Prüfen Sie, ob die Form eine SmartArt-Form ist.
        if isinstance(shape, smartart.SmartArt):
            # Prüfen Sie den SmartArt-Stil.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Ändern Sie den SmartArt-Stil.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Speichern Sie die Präsentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Farbstil von SmartArt‑Formen ändern**

Dieses Beispiel zeigt, wie Sie den Farbstil einer SmartArt‑Form ändern können. Der Beispielcode findet eine SmartArt‑Form mit einem angegebenen Farbstil und aktualisiert sie.

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und laden Sie die Präsentation, die die SmartArt‑Form(en) enthält.
2. Rufen Sie über den Index die erste Folie ab.
3. Iterieren Sie über jede Form auf der ersten Folie.
4. Prüfen Sie, ob die Form ein [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)-Objekt ist.
5. Suchen Sie die SmartArt‑Form mit dem angegebenen Farbstil.
6. Legen Sie den neuen Farbstil für diese SmartArt‑Form fest.
7. Speichern Sie die Präsentation.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Durchlaufen Sie jede Form auf der ersten Folie.
    for shape in presentation.slides[0].shapes:
        # Prüfen Sie, ob die Form eine SmartArt-Form ist.
        if isinstance(shape, smartart.SmartArt):
            # Prüfen Sie den Farbtyp.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Ändern Sie den Farbtyp.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Speichern Sie die Präsentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich SmartArt als einzelnes Objekt animieren?**

Ja. SmartArt ist eine Form, sodass Sie über die Animations‑API [Standardanimationen](/slides/de/python-net/powerpoint-animation/) (Eintritt, Austritt, Hervorhebung, Bewegungspfad) genauso wie bei anderen Formen anwenden können.

**Wie finde ich ein bestimmtes SmartArt auf einer Folie, wenn ich seine interne ID nicht kenne?**

Legen Sie den Alternativtext (AltText) fest und verwenden Sie ihn, um die Form nach diesem Wert zu suchen – das ist ein empfohlener Weg, um die Ziel‑Form zu finden.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und anschließend die Gruppe [manipulieren](/slides/de/python-net/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie ein Thumbnail/Bild der Form; die Bibliothek kann einzelne Formen [in Rasterdateien (PNG/JPG/TIFF)](/slides/de/python-net/create-shape-thumbnails/) rendern.

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF erhalten bleiben?**

Ja. Die Rendering‑Engine zielt auf hohe Treue beim [PDF‑Export](/slides/de/python-net/convert-powerpoint-to-pdf/) ab und bietet diverse Qualitäts‑ und Kompatibilitätsoptionen.