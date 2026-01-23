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
description: "Convierte diapositivas de PowerPoint y OpenDocument a XAML usando Aspose.Slides para PHP mediante Java — solución rápida, sin necesidad de Office, que mantiene intacto el diseño."
---

## **Exportar presentaciones a XAML**

Aspose.Slides admite la exportación a XAML. Puedes convertir tus presentaciones a XAML.

## **Acerca de XAML**

XAML es un lenguaje de programación descriptivo que permite crear o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin Forms.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Lo más probable es que utilices un diseñador para trabajar con archivos XAML la mayor parte del tiempo, pero también puedes escribir y editar tu GUI. 

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

Por ejemplo, si deseas que Aspose.Slides añada diapositivas ocultas de tu presentación al exportarla a XAML, puedes usar el método [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) con el valor `true`. Consulta este ejemplo de código PHP:
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


## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes previsibles si la fuente original no está disponible en la máquina?**

Establece [una fuente regular predeterminada](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — se utiliza como fuente alternativa cuando la original falta. Esto ayuda a evitar sustituciones inesperadas.

**¿El XAML exportado está pensado solo para WPF, o puede usarse también en otras pilas de XAML?**

XAML es un lenguaje de marcado UI general usado en WPF, UWP y Xamarin.Forms. La exportación está orientada a la compatibilidad con las pilas de XAML de Microsoft; el comportamiento exacto y el soporte de constructos específicos dependen de la plataforma de destino. Prueba el marcado en tu entorno.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puedes controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) en [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — mantenlo desactivado si no necesitas exportarlas.