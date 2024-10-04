---
title: Exportar a XAML
type: docs
weight: 30
url: /php-java/export-to-xaml/

---

# Exportación de presentaciones a XAML

{{% alert color="primary" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/), implementamos soporte para la exportación a XAML. Ahora puedes exportar tus presentaciones a XAML.

{{% /alert %}} 

# Acerca de XAML

XAML es un lenguaje de programación descriptivo que te permite construir o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Plataforma Universal de Windows) y formularios de Xamarin.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una interfaz gráfica de usuario. Es probable que utilices un diseñador para trabajar en archivos XAML la mayor parte del tiempo, pero aún puedes escribir y editar tu interfaz gráfica.

## Exportando presentaciones a XAML con opciones predeterminadas

Este código PHP te muestra cómo exportar una presentación a XAML con configuraciones predeterminadas:

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

## Exportando presentaciones a XAML con opciones personalizadas

Puedes seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML.

Por ejemplo, si deseas que Aspose.Slides agregue diapositivas ocultas de tu presentación al exportarla a XAML, puedes establecer la propiedad [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) en verdadero. Ve este ejemplo de código PHP:

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