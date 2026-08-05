---
title: Especificar fuentes predeterminadas de presentación en C++
linktitle: Fuente predeterminada
type: docs
weight: 30
url: /es/cpp/default-font/
keywords:
- fuente predeterminada
- fuente regular
- fuente normal
- fuente asiática
- exportación PDF
- exportación XPS
- exportación de imágenes
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Establezca fuentes predeterminadas en Aspose.Slides para C++ para asegurar una conversión correcta de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---
## **Visión general**

Aspose.Slides permite especificar fuentes predeterminadas que se utilizan cuando una presentación se renderiza. Esto es útil al generar miniaturas de diapositivas o exportar una presentación a formatos como PDF y XPS. Las fuentes predeterminadas se configuran a través de `LoadOptions` antes de cargar la presentación.

El método `set_DefaultRegularFont` define la fuente predeterminada para el texto normal, mientras que `set_DefaultAsianFont` define la fuente predeterminada para el texto asiático. Después de establecer estas opciones, la presentación puede cargarse y renderizarse utilizando las fuentes especificadas.

## **Usar fuentes predeterminadas para renderizar una presentación**
Aspose.Slides le permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegularFont y DefaultAsianFont para utilizarlas como fuentes predeterminadas. Siga los pasos a continuación para cargar fuentes desde directorios externos mediante la API de Aspose.Slides para C++:

1. Cree una instancia de `LoadOptions`.
1. Establezca `DefaultRegularFont` a la fuente que desee. En el siguiente ejemplo, he utilizado Wingdings.
1. Establezca `DefaultAsianFont` a la fuente que desee. He utilizado Wingdings en el siguiente ejemplo.
1. Cargue la presentación usando `Presentation` y estableciendo las opciones de carga.
1. Ahora, genere la miniatura de la diapositiva, el PDF y el XPS para verificar los resultados.

La implementación anterior se muestra a continuación.

```cpp
// Utilice las opciones de carga para especificar fuentes regulares y asiáticas predeterminadas
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **Preguntas frecuentes**

**¿Qué afectan exactamente DefaultRegularFont y DefaultAsianFont: solo la exportación o también las miniaturas, PDF, XPS, HTML y SVG?**

Participan en la cadena de renderizado para todas las salidas compatibles. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/es/cpp/convert-powerpoint-to-xps/), [imágenes rasterizadas](/slides/es/cpp/convert-powerpoint-to-png/), [HTML](/slides/es/cpp/convert-powerpoint-to-html/), y [SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de diseño y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar simplemente un PPTX sin ningún renderizado?**

No. Las fuentes predeterminadas sólo son relevantes cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no modifica las ejecuciones de fuente almacenadas ni la estructura del archivo. Las fuentes predeterminadas entran en juego durante operaciones que renderizan o reflujo del texto.

**Si añado mis propias carpetas de fuentes o suministro fuentes desde la memoria, ¿se tendrán en cuenta al elegir las fuentes predeterminadas?**

Sí. [Fuentes personalizadas](/slides/es/cpp/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede utilizar. Las fuentes predeterminadas y cualquier [regla de reserva](/slides/es/cpp/fallback-font/) se resolverán contra esas fuentes primero, ofreciendo una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas de texto (kerning, avances) y, por tanto, a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para mantener la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/cpp/embedded-font/) o seleccione familias predeterminadas y de reserva compatibles métricamente.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes utilizadas en la presentación están incrustadas?**

A menudo no es necesario, porque las [fuentes incrustadas](/slides/es/cpp/embedded-font/) ya garantizan una apariencia coherente. Las fuentes predeterminadas siguen siendo útiles como medida de seguridad para los caracteres que no están cubiertos por el subconjunto incrustado o cuando un archivo combina texto incrustado y no incrustado.