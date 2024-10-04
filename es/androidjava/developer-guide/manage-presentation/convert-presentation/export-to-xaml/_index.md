---
title: Exportar a XAML
type: docs
weight: 30
url: /androidjava/export-to-xaml/

---

# Exportando Presentaciones a XAML

{{% alert color="primary" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/), implementamos soporte para la exportación a XAML. Ahora puedes exportar tus presentaciones a XAML.

{{% /alert %}} 

# Acerca de XAML

XAML es un lenguaje de programación descriptivo que te permite construir o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Es probable que utilices un diseñador para trabajar en archivos XAML la mayor parte del tiempo, pero aún puedes escribir y editar tu GUI. 

## Exportando Presentaciones a XAML con Opciones Predeterminadas

Este código Java te muestra cómo exportar una presentación a XAML con la configuración predeterminada:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## Exportando Presentaciones a XAML con Opciones Personalizadas

Puedes seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML.

Por ejemplo, si deseas que Aspose.Slides agregue diapositivas ocultas de tu presentación al exportarla a XAML, puedes establecer la propiedad [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) en true. Mira este código Java de ejemplo:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```