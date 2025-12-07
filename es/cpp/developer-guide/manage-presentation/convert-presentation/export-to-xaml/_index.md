---
title: Exportar presentaciones a XAML en C++
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/cpp/export-to-xaml/
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
- guardar PPT como XAML
- guardar PPTX como XAML
- guardar ODP como XAML
- exportar PPT a XAML
- exportar PPTX a XAML
- exportar ODP a XAML
- C++
- Aspose.Slides
description: "Convierta diapositivas de PowerPoint y OpenDocument a XAML en C++ usando Aspose.Slides—solución rápida, sin Office, que mantiene intacto su diseño."
---

## **Exportar presentaciones a XAML**

{{% alert color="primary" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/), implementamos soporte para la exportación a XAML. Ahora puedes exportar tus presentaciones a XAML. 

{{% /alert %}} 

## **Acerca de XAML**

XAML es un lenguaje de programación descriptivo que permite crear o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin Forms.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Probablemente uses un diseñador para trabajar con archivos XAML la mayor parte del tiempo, pero aún puedes escribir y editar tu GUI. 

## **Exportar presentaciones a XAML con opciones predeterminadas**

Este código C++ muestra cómo exportar una presentación a XAML con la configuración predeterminada:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **Exportar presentaciones a XAML con opciones personalizadas**

Puedes seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML. 

Por ejemplo, si deseas que Aspose.Slides añada diapositivas ocultas de tu presentación al exportarla a XAML, puedes pasar true al método [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Consulta este código de ejemplo en C++: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en la máquina?**

Utiliza [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) en [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — se usa como fuente de respaldo cuando la original falta. Esto ayuda a evitar sustituciones inesperadas.

**¿El XAML exportado está destinado solo a WPF o también se puede usar en otras pilas de XAML?**

XAML es un lenguaje de marcado de UI general que se utiliza en WPF, UWP y Xamarin.Forms. La exportación tiene como objetivo la compatibilidad con las pilas de XAML de Microsoft; el comportamiento exacto y la compatibilidad con constructos específicos dependen de la plataforma de destino. Prueba el marcado en tu entorno.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puedes controlar este comportamiento mediante [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) en [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — mantenlo desactivado si no necesitas exportarlas.