---
title: Presentación de Impresión
type: docs
weight: 50
url: /es/python-net/print-presentation/
keywords: "Imprimir PowerPoint, PPT, PPTX, Presentación de Impresión, Python, Impresora, Opciones de Impresión"
description: "Imprimir Presentación de PowerPoint en Python"
---
Aspose.Slides para Python proporciona 4 métodos `print` sobrecargados que permiten imprimir presentaciones. Los métodos sobrecargados aceptan diferentes argumentos, por lo que siempre encontrará un método que se ajuste a sus necesidades de impresión.

## **Imprimir en la Impresora Predeterminada**

Esta operación de impresión simple se utiliza para imprimir todas las diapositivas en una presentación de PowerPoint a través de la impresora predeterminada del sistema.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pase la presentación que desea imprimir.
2. Llame al método `print` (sin parámetros).

Este código de Python le muestra cómo imprimir una presentación de PowerPoint:

```python
import aspose.slides as slides

# Cargar la presentación
presentation = slides.Presentation("Print.ppt")

# Llamar al método de impresión para imprimir toda la presentación en la impresora predeterminada
presentation.print()
```

## **Imprimir en una Impresora Específica**

Esta operación se utiliza para imprimir todas las diapositivas en una presentación de PowerPoint a través de una impresora específica.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pase la presentación que desea imprimir.
2. Llame al método `print` y pase el nombre de la impresora como una cadena.

Este código de Python le muestra cómo imprimir una presentación de PowerPoint utilizando una impresora específica:

```python
import aspose.slides as slides

try:
    # Cargar la presentación
    with slides.Presentation("pres.pptx") as pres:
        # Llamar al método de impresión para imprimir toda la presentación en la impresora deseada
        pres.print("Por favor, establezca el nombre de su impresora aquí")
except:
    print("Por favor, establezca el nombre de la impresora como parámetro de cadena para el método de impresión de la presentación")
```

## **Establecer Opciones de Impresión Dinámicamente**

Usando propiedades de la clase `PrinterSettings`, puede aplicar parámetros que definen la operación de impresión. Puede especificar cuántas copias deben imprimirse, si las diapositivas deben imprimirse en orientación horizontal o vertical, sus márgenes preferidos, etc.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pase la presentación que desea imprimir.
2. Instancie la clase `PrinterSettings`.
3. Especifique sus parámetros preferidos para la operación de impresión:
   * el número de copias
   * orientación de página
   * cifras de márgenes, etc.
4. Llame al método `print`.

Este código de Python le muestra cómo imprimir una presentación de PowerPoint con ciertas opciones de impresión:

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