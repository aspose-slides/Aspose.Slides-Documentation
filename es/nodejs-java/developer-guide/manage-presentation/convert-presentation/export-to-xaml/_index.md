---
title: Exportar presentaciones a XAML en JavaScript
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convierte diapositivas de PowerPoint y OpenDocument a XAML en JavaScript usando Aspose.Slides para Node.js—solución rápida, sin Office, que conserva intacto el diseño."
---

## **Exportar presentaciones a XAML**

Aspose.Slides admite la exportación a XAML. Puedes convertir tus presentaciones a XAML.

## **Acerca de XAML**

XAML es un lenguaje de programación descriptivo que permite crear o escribir clases de usuario para aplicaciones, especialmente aquellas que usan WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin Forms.

XAML, que es un lenguaje basado en XML, es la variante de Microsoft para describir una interfaz gráfica de usuario (GUI). Lo más probable es que utilices un diseñador para trabajar con archivos XAML la mayor parte del tiempo, pero también puedes escribir y editar tu GUI.

## **Exportar presentaciones a XAML con opciones predeterminadas**

Este código JavaScript muestra cómo exportar una presentación a XAML con la configuración predeterminada:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Exportar presentaciones a XAML con opciones personalizadas**

Puedes seleccionar opciones de la clase [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) que controlan el proceso de exportación y determinan cómo Aspose.Slides exporta tu presentación a XAML.

Por ejemplo, si deseas que Aspose.Slides añada diapositivas ocultas de tu presentación al exportarla a XAML, puedes establecer el método [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) a true. Consulta este código de muestra JavaScript:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en la máquina?**

Utiliza [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — se usa como fuente de reserva cuando la original falta. Esto ayuda a evitar sustituciones inesperadas.

**¿El XAML exportado está pensado solo para WPF o también puede usarse en otras pilas XAML?**

XAML es un lenguaje de marcado de UI general que se utiliza en WPF, UWP y Xamarin.Forms. La exportación apunta a la compatibilidad con las pilas XAML de Microsoft; el comportamiento exacto y la compatibilidad con constructos específicos dependen de la plataforma de destino. Prueba el marcado en tu entorno.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puedes controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) en [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — mantenlo desactivado si no necesitas exportarlas.