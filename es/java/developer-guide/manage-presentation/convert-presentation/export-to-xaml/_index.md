---
title: Exportar a XAML
type: docs
weight: 30
url: /es/java/export-to-xaml/

---

# Exportando presentaciones a XAML

{{% alert color="primary" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-6-release-notes/), implementamos soporte para la exportación a XAML. Ahora puedes exportar tus presentaciones a XAML. 

{{% /alert %}} 

# Acerca de XAML

XAML es un lenguaje de programación descriptivo que te permite crear o escribir interfaces de usuario para aplicaciones, especialmente aquellas que utilizan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y formularios de Xamarin.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Es probable que uses un diseñador para trabajar en archivos XAML la mayor parte del tiempo, pero aún puedes escribir y editar tu GUI. 

## Exportando presentaciones a XAML con opciones predeterminadas

Este código Java te muestra cómo exportar una presentación a XAML con la configuración predeterminada:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## Exportando presentaciones a XAML con opciones personalizadas

Puedes seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML. 

Por ejemplo, si deseas que Aspose.Slides añada diapositivas ocultas de tu presentación al exportarla a XAML, puedes establecer la propiedad [ExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) en true. Ve este ejemplo de código Java: 

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