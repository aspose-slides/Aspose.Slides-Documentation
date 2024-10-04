---
title: Exportar a XAML
type: docs
weight: 30
url: /cpp/export-to-xaml/

---

# Exportar Presentaciones a XAML

{{% alert color="primary" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/), implementamos soporte para la exportación a XAML. Ahora puedes exportar tus presentaciones a XAML. 

{{% /alert %}} 

# Acerca de XAML

XAML es un lenguaje de programación descriptivo que te permite construir o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y formularios de Xamarin.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Es probable que utilices un diseñador para trabajar en archivos XAML la mayor parte del tiempo, pero aún puedes escribir y editar tu GUI. 

## Exportar Presentaciones a XAML Con Opciones Predeterminadas

Este código C++ te muestra cómo exportar una presentación a XAML con configuraciones predeterminadas:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## Exportar Presentaciones a XAML Con Opciones Personalizadas

Tienes la opción de seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML. 

Por ejemplo, si deseas que Aspose.Slides agregue diapositivas ocultas de tu presentación al exportarla a XAML, puedes pasar true al método [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Ve este código C++ de ejemplo: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```