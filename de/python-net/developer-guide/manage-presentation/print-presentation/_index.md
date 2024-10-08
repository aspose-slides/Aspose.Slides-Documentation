---
title: Druckpräsentation
type: docs
weight: 50
url: /de/python-net/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Präsentation, Python, Drucker, Druckoptionen"
description: "Druck PowerPoint-Präsentation in Python"
---
Aspose.Slides für Python bietet 4 überladene `print`-Methoden, mit denen Sie Präsentationen drucken können. Die überladenen Methoden nehmen unterschiedliche Argumente entgegen, sodass Sie immer eine Methode finden werden, die Ihren Druckanforderungen entspricht.

## **Drucken auf dem Standarddrucker**

Dieser einfache Druckvorgang wird verwendet, um alle Folien einer PowerPoint-Präsentation über den Standarddrucker des Systems zu drucken.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und übergeben Sie die Präsentation, die Sie drucken möchten.
2. Rufen Sie die `print`-Methode (ohne Parameter) auf. 

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation drucken:

```python
import aspose.slides as slides

# Präsentation laden
presentation = slides.Presentation("Print.ppt")

# Rufen Sie die Druckmethode auf, um die gesamte Präsentation an den Standarddrucker zu drucken
presentation.print()
```

## **Drucken auf einem bestimmten Drucker**

Dieser Vorgang wird verwendet, um alle Folien einer PowerPoint-Präsentation über einen bestimmten Drucker zu drucken.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und übergeben Sie die Präsentation, die Sie drucken möchten.
2. Rufen Sie die `print`-Methode auf und übergeben Sie den Druckernamen als Zeichenfolge.

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation mit einem bestimmten Drucker drucken:

```python
import aspose.slides as slides

try:
    # Präsentation laden
    with slides.Presentation("pres.pptx") as pres:
        # Rufen Sie die Druckmethode auf, um die gesamte Präsentation an den gewünschten Drucker zu drucken
        pres.print("Bitte geben Sie hier Ihren Druckernamen ein")
except:
    print("Bitte setzen Sie den Druckernamen als Zeichenfolgenparameter für die Druckmethode der Präsentation")
```

## **Druckoptionen dynamisch festlegen**

Mit Eigenschaften der `PrinterSettings`-Klasse können Sie Parameter anwenden, die den Druckvorgang definieren. Sie können angeben, wie viele Exemplare gedruckt werden sollen, ob die Folien im Quer- oder Hochformat gedruckt werden sollen, Ihre bevorzugten Ränder usw.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und übergeben Sie die Präsentation, die Sie drucken möchten.
2. Erstellen Sie eine Instanz der `PrinterSettings`-Klasse.
3. Geben Sie Ihre bevorzugten Parameter für den Druckvorgang an:
   * die Anzahl der Exemplare
   * Seitenorientierung
   * Randangaben usw.
4. Rufen Sie die `print`-Methode auf.

Dieser Python-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation mit bestimmten Druckoptionen drucken:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    printerSettings = drawing.printing.PrinterSettings()
    printerSettings.copies = 2
    printerSettings.default_page_settings.landscape = True
    printerSettings.default_page_settings.margins.left = 10
    pres.print(printerSettings)
```