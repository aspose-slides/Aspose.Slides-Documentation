---
title: Importieren von Präsentationen aus PDF oder HTML in Python via Java
linktitle: Präsentation importieren
type: docs
weight: 60
url: /de/python-java/import-presentation/
keywords:
- Präsentation importieren
- Folie importieren
- PDF importieren
- HTML importieren
- PDF zu Präsentation
- PDF zu PPT
- PDF zu PPTX
- PDF zu ODP
- HTML zu Präsentation
- HTML zu PPT
- HTML zu PPTX
- HTML zu ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PDF- und HTML-Inhalte in PowerPoint-Präsentationen in Python via Java mit Aspose.Slides importieren und die Ergebnisse als PPTX-Dateien speichern."
---
## **Einleitung**

Aspose.Slides für Python via Java kann PDF‑Seiten oder HTML‑Inhalte in PowerPoint‑Folien umwandeln, ohne Microsoft PowerPoint zu benötigen. Die Klasse [SlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/) stellt [addFromPdf](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addFromPdf) und [addFromHtml](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addFromHtml) zum Anhängen importierter Inhalte an eine Präsentation bereit.

Für mehr Kontrolle über die Platzierung von HTML kann [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertFromHtml) erzeugte Folien an einem Sammlungs‑Index einfügen oder beginnen, den verfügbaren Raum einer bestehenden Folie zu füllen. Längeres HTML wird automatisch über zusätzliche Folien paginiert, die Quelle kann als Zeichenkette oder Stream angegeben werden, und externe Ressourcen können über [ExternalResourceResolver](https://reference.aspose.com/slides/de/python-java/aspose.slides/externalresourceresolver/) mit einer Basis‑URI geladen werden. Das zurückgegebene [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/)-Array identifiziert die betroffenen und neu erstellten Folien.

## **Import aus PDF**

Um ein PDF‑Dokument in eine PowerPoint‑Präsentation zu konvertieren, importieren Sie dessen Inhalt in die Folien‑Collection und speichern das Ergebnis als PPTX‑Datei.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Erstellen Sie ein neues [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Objekt.
2. Rufen Sie [addFromPdf](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addFromPdf) mit dem Pfad zur PDF‑Datei auf.
3. Rufen Sie [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx) auf, um die Präsentation in eine PPTX‑Datei zu schreiben.

Das folgende Python‑Beispiel importiert ein PDF‑Dokument und speichert die erzeugten Folien als PowerPoint‑Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die standardmäßige leere Folie bleibt in der Präsentation, weil der Import Folien anhängt. Um nur die importierten Seiten zu behalten, leeren Sie die Folien‑Collection mit [SlideCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#clear) vor dem Import.

Die Methode [addFromPdf](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addFromPdf) gibt die Folien zurück, die sie hinzufügt, was nützlich ist, wenn Sie nur die importierten Folien verarbeiten müssen.

{{% alert title="Tip" color="success" %}}
Probieren Sie die kostenlose Web‑App [PDF to PowerPoint](https://products.aspose.app/slides/de/import/pdf-to-powerpoint), um diesen Konvertierungsablauf in Aktion zu sehen.
{{% /alert %}}

## **Import aus HTML**

Aspose.Slides kann auch Folien aus einem HTML‑Dokument erstellen. Die Quelle kann als HTML‑Text oder als Stream angegeben werden. Die folgenden Schritte verwenden einen Dateistream:

1. Erstellen Sie ein neues [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Objekt.
2. Öffnen Sie die HTML‑Datei zum Lesen und übergeben Sie den Stream an [addFromHtml](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Rufen Sie [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Pptx) auf, um das Ergebnis in eine PPTX‑Datei zu schreiben.

Das folgende Python‑Beispiel importiert ein HTML‑Dokument und speichert die erzeugten Folien als PowerPoint‑Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HTML‑Inhalt einfügen**

Verwenden Sie [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertFromHtml), wenn HTML‑generierte Folien an einer bestimmten Position statt am Ende eingefügt werden sollen. Der Index ist nullbasiert und gibt die Position an, an der der Import beginnt.

Das Argument `useSlideWithIndexAsStart` steuert, wie der Importierer diese Position verwendet:

- Wenn es `False` ist, erstellt der Importierer neue Folien am angegebenen Index und verschiebt die nachfolgenden Folien.
- Wenn es `True` ist, beginnt der Importierer, Inhalte im verfügbaren Raum der bestehenden Folie an diesem Index zu platzieren. Passt das HTML nicht, paginiert Aspose.Slides es automatisch und fügt zusätzliche Folien unmittelbar nach der Ausgangsfolie ein.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#insertFromHtml) gibt ein Array von [Slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/)-Objekten zurück. Beginnt die Einfügung auf neuen Folien, ist jedes zurückgegebene Element neu erstellt. Wird eine bestehende Folie als Start verwendet, enthält das Array diese betroffene Folie gefolgt von allen neuen Überlauf‑Folien. Sie können dieses Array inspizieren, anstatt den betroffenen Bereich aus der Folienzahl der Präsentation zu berechnen.

### **HTML als neue Folien einfügen**

Das folgende Beispiel liefert HTML als Zeichenkette und fügt die erzeugten Folien am Sammlungs‑Index `1` ein. Das Übergeben von `False` lässt die bestehenden Folien unverändert, außer dass sie verschoben werden, um Platz zu schaffen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Auf einer bestehenden Folie beginnen**

Das nächste Beispiel liefert das HTML über einen Stream. Es behält eine Kopfzeilen‑Form auf der bestehenden Vorlagen‑Folie, beginnt den Import unterhalb des belegten Bereichs und lässt den langen Textkörper auf neue Folien weiterfließen.

Das HTML enthält außerdem eine relative Bild‑URL. Ein [ExternalResourceResolver](https://reference.aspose.com/slides/de/python-java/aspose.slides/externalresourceresolver/) ruft die Ressource ab, während die Basis‑URI dem Importierer mitteilt, wie `images/logo.png` aufgelöst werden soll. In diesem Beispiel wird die Datei unter `html-assets/images/logo.png` erwartet.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Ein uneingeschränkter externer Ressourcen‑Resolver kann lokale oder Netzwerk‑Ressourcen lesen, die im HTML referenziert werden. Für nicht vertrauenswürdige Eingaben sollten Ressourcen‑URLs vor dem Import gegen eine Positivliste zulässiger Schemata, Verzeichnisse und Hosts validiert und bereinigt werden.
{{% /alert %}}

## **FAQ**

**Kann Aspose.Slides Tabellen beim Importieren eines PDFs erkennen?**

Ja. Erstellen Sie ein [PdfImportOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfimportoptions/)-Objekt, rufen Sie [setDetectTables](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfimportoptions/#setDetectTables) mit `True` auf und übergeben Sie die Optionen an [addFromPdf](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidecollection/#addFromPdf). Die Qualität der Tabellenerkennung hängt von Struktur und Komplexität des Quell‑PDF ab.

{{% alert title="Note" color="info" %}}
Nach dem Importieren von HTML können Sie die Folien auch in [images](/slides/de/python-java/convert-powerpoint-to-png/), [TIFF](/slides/de/python-java/convert-powerpoint-to-tiff/) oder [SVG](/slides/de/python-java/render-slide-as-svg/) exportieren.
{{% /alert %}}