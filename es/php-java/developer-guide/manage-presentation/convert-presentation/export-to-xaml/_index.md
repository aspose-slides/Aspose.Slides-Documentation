---
title: Exportar presentaciones a XAML en PHP
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Convierte diapositivas de PowerPoint y OpenDocument a XAML mediante Aspose.Slides para PHP a través de Java — solución rápida y sin Office que mantiene intacto el diseño."
---

## **Exportar presentaciones a XAML**

{{% alert color="primary" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/), implementamos la compatibilidad con la exportación a XAML. Ahora puedes exportar tus presentaciones a XAML.

{{% /alert %}} 

## **Acerca de XAML**

XAML es un lenguaje de programación descriptivo que permite crear o escribir interfaces de usuario para aplicaciones, especialmente aquellas que usan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin Forms.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Lo más probable es que uses un diseñador para trabajar con archivos XAML la mayor parte del tiempo, pero aún puedes escribir y editar tu GUI. 

## **Exportar presentaciones a XAML con opciones predeterminadas**

Este código PHP muestra cómo exportar una presentación a XAML con la configuración predeterminada:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Exportar presentaciones a XAML con opciones personalizadas**

Puedes seleccionar opciones de la clase [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML.

Por ejemplo, si deseas que Aspose.Slides añada diapositivas ocultas de tu presentación al exportarla a XAML, puedes usar el método [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) con el valor `true`. Consulta este código de muestra en PHP:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en la máquina?**

Establece [una fuente regular predeterminada](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — se utiliza como fuente de reserva cuando falta la original. Esto ayuda a evitar sustituciones inesperadas.

**¿El XAML exportado está destinado solo a WPF, o puede usarse también en otras pilas XAML?**

XAML es un lenguaje de marcado UI general utilizado en WPF, UWP y Xamarin.Forms. La exportación apunta a la compatibilidad con las pilas XAML de Microsoft; el comportamiento exacto y el soporte de construcciones específicas dependen de la plataforma de destino. Prueba el marcado en tu entorno.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puedes controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) en [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — mantenlo desactivado si no necesitas exportarlas.