---
title: Exportar a XAML
type: docs
weight: 30
url: /es/net/export-to-xaml/
keywords: "Exportar presentación de PowerPoint, Convertir PowerPoint, XAML, PowerPoint a XAML, PPT a XAML, PPTX a XAML, C#, Csharp, .NET"
description: "Exportar o convertir presentación de PowerPoint a XAML"
---

# Exportación de Presentaciones a XAML

{{% alert title="Info" color="info" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), implementamos soporte para exportación a XAML. Ahora puedes exportar tus presentaciones a XAML. 

{{% /alert %}} 

# Acerca de XAML

XAML es un lenguaje de programación descriptivo que te permite construir o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Plataforma Universal de Windows) y formularios de Xamarin.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Es probable que utilices un diseñador para trabajar en archivos XAML la mayor parte del tiempo, pero aún puedes escribir y editar tu GUI. 

## Exportación de Presentaciones a XAML Con Opciones Predeterminadas

Este código C# te muestra cómo exportar una presentación a XAML con ajustes predeterminados:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## Exportación de Presentaciones a XAML Con Opciones Personalizadas

Puedes seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML. 

Por ejemplo, si deseas que Aspose.Slides agregue diapositivas ocultas de tu presentación al exportarla a XAML, puedes establecer la propiedad [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) en true. Mira este código C# de ejemplo: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```