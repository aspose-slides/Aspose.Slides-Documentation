---
title: Exportar a XAML
type: docs
weight: 30
url: /es/python-net/export-to-xaml/
keywords: "Exportar presentación de PowerPoint, Convertir PowerPoint, XAML, PowerPoint a XAML, PPT a XAML, PPTX a XAML, Python"
description: "Exportar o convertir presentación de PowerPoint a XAML"
---

# Exportando presentaciones a XAML

{{% alert title="Info" color="info" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/), implementamos soporte para la exportación a XAML. Ahora puedes exportar tus presentaciones a XAML. 

{{% /alert %}} 

# Acerca de XAML

XAML es un lenguaje de programación descriptivo que te permite construir o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Plataforma Universal de Windows) y formularios de Xamarin.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Es probable que uses un diseñador para trabajar en archivos XAML la mayor parte del tiempo, pero aún puedes escribir y editar tu GUI. 

## Exportando presentaciones a XAML con opciones predeterminadas

Este código de Python te muestra cómo exportar una presentación a XAML con configuraciones predeterminadas:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## Exportando presentaciones a XAML con opciones personalizadas

Puedes seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML. 

Por ejemplo, si deseas que Aspose.Slides agregue diapositivas ocultas de tu presentación al exportarla a XAML, puedes establecer la propiedad [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) en verdadero. Mira este código de Python de ejemplo: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```