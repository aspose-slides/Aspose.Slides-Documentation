---
title: Exportar a XAML
type: docs
weight: 30
url: /es/net/export-to-xaml/
keywords: "Exportar presentación PowerPoint, Convertir PowerPoint, XAML, PowerPoint a XAML, PPT a XAML, PPTX a XAML, C#, Csharp, .NET"
description: "Exportar o convertir presentación PowerPoint a XAML"
---

# **Exportar presentaciones a XAML**

{{% alert title="Info" color="info" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), implementamos soporte para la exportación a XAML. Ahora puede exportar sus presentaciones a XAML. 

{{% /alert %}} 

# **Acerca de XAML**

XAML es un lenguaje de programación descriptivo que le permite construir o escribir interfaces de usuario para aplicaciones, especialmente aquellas que usan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin Forms.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Lo más probable es que utilice un diseñador para trabajar con archivos XAML la mayor parte del tiempo, pero aún puede escribir y editar su GUI. 

## **Exportar presentaciones a XAML con opciones predeterminadas**

Este código C# le muestra cómo exportar una presentación a XAML con la configuración predeterminada:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Exportar presentaciones a XAML con opciones personalizadas**

Puede seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta su presentación a XAML. 

Por ejemplo, si desea que Aspose.Slides añada diapositivas ocultas de su presentación al exportarla a XAML, puede establecer la propiedad [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) en true. Vea este código de muestra C#: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en la máquina?**

Establezca [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) en [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — se utiliza como fuente de reserva cuando la original falta. Esto ayuda a evitar sustituciones inesperadas.

**¿El XAML exportado está destinado solo a WPF o también puede usarse en otras pilas XAML?**

XAML es un lenguaje de marcado de UI general usado en WPF, UWP y Xamarin.Forms. La exportación apunta a la compatibilidad con las pilas XAML de Microsoft; el comportamiento exacto y el soporte para constructos específicos dependen de la plataforma de destino. Pruebe el marcado en su entorno.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

De forma predeterminada, las diapositivas ocultas no se incluyen. Puede controlar este comportamiento mediante [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) en [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — manténgalo desactivado si no necesita exportarlas.