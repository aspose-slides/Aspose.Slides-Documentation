---
title: Exportar presentaciones a XAML con Python
linktitle: Exportar a XAML
type: docs
weight: 30
url: /es/python-net/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- PowerPoint a XAML
- OpenDocument a XAML
- presentación a XAML
- PPT a XAML
- PPTX a XAML
- ODP a XAML
- Python
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint y OpenDocument a XAML en Python usando Aspose.Slides—solución rápida y sin Office que mantiene intacto el diseño."
---

## **Visión general**

{{% alert title="Info" color="info" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/), hemos implementado soporte para la exportación a XAML. Ahora puede exportar sus presentaciones a XAML. 

{{% /alert %}} 

XAML es un lenguaje de programación descriptivo que le permite crear o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin Forms.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Lo más probable es que utilice un diseñador para trabajar con archivos XAML la mayor parte del tiempo, pero también puede escribir y editar su GUI. 

## **Exportar presentaciones a XAML con opciones predeterminadas**

Este código Python le muestra cómo exportar una presentación a XAML con la configuración predeterminada:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **Exportar presentaciones a XAML con opciones personalizadas**

Puede seleccionar opciones de la clase [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta su presentación a XAML. 

Por ejemplo, si desea que Aspose.Slides añada diapositivas ocultas de su presentación al exportarla a XAML, puede establecer la propiedad [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) a `True`. Vea este código de ejemplo en Python: 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en la máquina?**

Establezca [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) en [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/); se utiliza como fuente de respaldo cuando falta la original. Esto ayuda a evitar sustituciones inesperadas.

**¿El XAML exportado está destinado solo a WPF, o puede usarse también en otras pilas XAML?**

XAML es un lenguaje de marcado de UI general que se utiliza en WPF, UWP y Xamarin.Forms. La exportación apunta a la compatibilidad con las pilas XAML de Microsoft; el comportamiento exacto y el soporte de construcciones específicas dependen de la plataforma de destino. Pruebe el marcado en su entorno.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puede controlar este comportamiento mediante [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) en [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/); manténgalo desactivado si no necesita exportarlas.