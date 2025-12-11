---
title: Exportar presentaciones a XAML en Android
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/androidjava/export-to-xaml/
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
- Android
- Java
- Aspose.Slides
description: "Convierta diapositivas de PowerPoint y OpenDocument a XAML en Java usando Aspose.Slides para Android: una solución rápida y sin Office que mantiene intacto el diseño."
---

## **Exportar presentaciones a XAML**

{{% alert color="primary" %}} 

En [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/), implementamos soporte para la exportación a XAML. Ahora puede exportar sus presentaciones a XAML.

{{% /alert %}} 

## **Acerca de XAML**

XAML es un lenguaje de programación descriptivo que le permite crear o escribir interfaces de usuario para aplicaciones, especialmente aquellas que usan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin Forms.  

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una GUI. Es probable que utilice un diseñador para trabajar con archivos XAML la mayor parte del tiempo, pero también puede escribir y editar su GUI. 

## **Exportar presentaciones a XAML con opciones predeterminadas**

Este código Java muestra cómo exportar una presentación a XAML con la configuración predeterminada:
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **Exportar presentaciones a XAML con opciones personalizadas**

Puede seleccionar opciones de la interfaz [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta su presentación a XAML.

Por ejemplo, si desea que Aspose.Slides agregue diapositivas ocultas de su presentación al exportarla a XAML, puede establecer la propiedad [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) en true. Vea este código Java de ejemplo:
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


## **Preguntas frecuentes**

**¿Cómo puedo asegurar fuentes predecibles si la fuente original no está disponible en la máquina?**

Establezca [una fuente regular predeterminada](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) en [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — se usa como fuente de reserva cuando la original falta. Esto ayuda a evitar sustituciones inesperadas.

**¿El XAML exportado está destinado solo a WPF, o puede usarse también en otras pilas de XAML?**

XAML es un lenguaje de marcado UI general usado en WPF, UWP y Xamarin.Forms. La exportación apunta a la compatibilidad con las pilas de XAML de Microsoft; el comportamiento exacto y el soporte para construcciones específicas dependen de la plataforma de destino. Pruebe el marcado en su entorno.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puede controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) en [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — manténgalo desactivado si no necesita exportarlas.