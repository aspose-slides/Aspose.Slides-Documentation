---
title: PowerPoint-Folien in PNG konvertieren in Python
linktitle: Folie zu PNG
type: docs
weight: 30
url: /de/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint in PNG konvertieren
- Präsentation in PNG konvertieren
- Folie in PNG konvertieren
- PPT in PNG konvertieren
- PPTX in PNG konvertieren
- ODP in PNG konvertieren
- PowerPoint zu PNG
- Präsentation zu PNG
- Folie zu PNG
- PPT zu PNG
- PPTX zu PNG
- ODP zu PNG
- Python
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen schnell in hochwertige PNG-Bilder mit Aspose.Slides für Python via .NET und erzielen Sie präzise, automatisierte Ergebnisse."
---

## **Übersicht**

Aspose.Slides for Python via .NET macht das Konvertieren von PowerPoint‑Präsentationen in PNG ganz einfach. Sie laden eine Präsentation, iterieren durch die Folien, rendern jede Folie zu einem Rasterbild und speichern das Ergebnis als PNG‑Dateien. Das ist ideal für die Erstellung von Folien‑Vorschauen, das Einbetten von Folien in Webseiten oder die Erzeugung statischer Assets für nachgelagerte Verarbeitung.

## **Folien in PNG konvertieren**

Dieser Abschnitt zeigt das einfachste Beispiel für die Konvertierung einer PowerPoint‑Präsentation in PNG‑Bilder mit Aspose.Slides for Python via .NET.

Gehen Sie folgendermaßen vor:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie eine Folie aus der `Presentation.slides`‑Sammlung (siehe die [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)‑Klasse).
3. Verwenden Sie die `Slide.get_image`‑Methode, um ein Miniaturbild der Folie zu erzeugen.
4. Verwenden Sie die `Presentation.save`‑Methode, um das Folien‑Miniaturbild im PNG‑Format zu speichern.

Dieser Python‑Code zeigt, wie man eine PowerPoint‑Präsentation in PNG konvertiert:
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **Folien in PNG mit benutzerdefinierten Abmessungen konvertieren**

Um Folien in PNG mit einem benutzerdefinierten Maßstab zu exportieren, rufen Sie `Slide.get_image` mit horizontalen und vertikalen Skalierungsfaktoren auf. Diese Multiplikatoren ändern die Ausgabe relativ zu den ursprünglichen Folienabmessungen – zum Beispiel verdoppelt `2.0` sowohl Breite als auch Höhe. Verwenden Sie gleiche Werte für `scale_x` und `scale_y`, um das Seitenverhältnis beizubehalten.

Dieser Python‑Code demonstriert die beschriebene Vorgehensweise:
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **Folien in PNG mit benutzerdefinierter Größe konvertieren**

Wenn Sie PNG‑Dateien in einer bestimmten Größe erzeugen möchten, übergeben Sie die gewünschten `width`‑ und `height`‑Werte. Der nachfolgende Code zeigt, wie man eine PowerPoint‑Datei in PNG konvertiert und dabei die Bildgröße festlegt:
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


{{% alert title="Tipp" color="primary" %}}
Vielleicht möchten Sie Asposes kostenlose **PowerPoint‑zu‑PNG‑Konverter** ausprobieren — [PPTX nach PNG](https://products.aspose.app/slides/conversion/pptx-to-png) und [PPT nach PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Sie bieten eine Live‑Implementierung des auf dieser Seite beschriebenen Vorgangs.
{{% /alert %}}

## **FAQ**

**Wie kann ich nur eine bestimmte Form (z. B. ein Diagramm oder Bild) anstelle der gesamten Folie exportieren?**

Aspose.Slides unterstützt das Erzeugen von Miniaturbildern für einzelne Formen; Sie können eine Form in ein PNG‑Bild rendern.

**Wird die parallele Konvertierung auf einem Server unterstützt?**

Ja, aber teilen Sie keine einzelne Präsentationsinstanz über Threads hinweg. Verwenden Sie eine separate Instanz pro Thread oder Prozess.

**Welche Einschränkungen gibt es in der Testversion beim Export nach PNG?**

Der Evaluierungsmodus fügt den Ausgabebildern ein Wasserzeichen hinzu und erzwingt weitere Beschränkungen, bis eine Lizenz angewendet wird.