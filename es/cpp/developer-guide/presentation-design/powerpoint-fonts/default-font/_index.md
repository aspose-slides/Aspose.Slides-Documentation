---
title: Especificar fuentes predeterminadas de la presentación en C++
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
description: "Establezca fuentes predeterminadas en Aspose.Slides para C++ para garantizar una conversión adecuada de PowerPoint (PPT, PPTX) y OpenDocument (ODP) a PDF, XPS e imágenes."
---

## **Establecer una fuente predeterminada**
Usando Aspose.Slides para C++ puedes establecer la fuente predeterminada en presentaciones de PowerPoint. Se ha agregado un nuevo método [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) a la clase [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) . Permite establecer la fuente predeterminada que se usará en lugar de todas las fuentes faltantes al guardar presentaciones en diferentes formatos sin volver a cargar las presentaciones.

El fragmento de código a continuación muestra cómo guardar la presentación en [HTML](https://docs.fileformat.com/web/html/) y [PDF](https://docs.fileformat.com/pdf/) con una fuente regular predeterminada diferente.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}

## **Usar fuentes predeterminadas para renderizar una presentación**
Aspose.Slides permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir DefaultRegular Font y DefaultAsian Font para usarlas como fuentes predeterminadas. Por favor, sigue los pasos a continuación para cargar fuentes desde directorios externos usando la API de Aspose.Slides para C++:

1. Cree una instancia de LoadOptions.
2. Establezca DefaultRegularFont a la fuente que desee. En el siguiente ejemplo, he usado Wingdings.
3. Establezca DefaultAsianFont a la fuente que desee. He usado Wingdings en el siguiente ejemplo.
4. Cargue la presentación usando Presentation y configurando las opciones de carga.
5. Ahora, genere la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se muestra a continuación.
```cpp
// Utilice las opciones de carga para especificar fuentes predeterminadas regulares y asiáticas
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

**¿Qué afectan exactamente DefaultRegularFont y DefaultAsianFont: solo la exportación, o también las miniaturas, PDF, XPS, HTML y SVG?**

Participan en la canalización de renderizado para todas las salidas admitidas. Esto incluye miniaturas de diapositivas, [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/es/cpp/convert-powerpoint-to-xps/), [imágenes raster](/slides/es/cpp/convert-powerpoint-to-png/), [HTML](/slides/es/cpp/convert-powerpoint-to-html/), y [SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/), porque Aspose.Slides utiliza la misma lógica de disposición y resolución de glifos en estos destinos.

**¿Se aplican las fuentes predeterminadas al leer y guardar simplemente un PPTX sin ningún renderizado?**

No. Las fuentes predeterminadas son relevantes cuando el texto debe medirse y dibujarse. Un simple abrir‑guardar de una presentación no modifica las ejecuciones de fuente almacenadas ni la estructura del archivo. Las fuentes predeterminadas intervienen durante operaciones que renderizan o redistribuyen el texto.

**Si añado mis propias carpetas de fuentes o suministro fuentes desde la memoria, ¿se tendrán en cuenta al elegir fuentes predeterminadas?**

Sí. [Fuentes personalizadas](/slides/es/cpp/custom-font/) amplían el catálogo de familias y glifos disponibles que el motor puede usar. Las fuentes predeterminadas y cualquier [reglas de sustitución](/slides/es/cpp/fallback-font/) se resolverán contra esas fuentes primero, proporcionando una cobertura más fiable en servidores y contenedores.

**¿Afectarán las fuentes predeterminadas a las métricas del texto (kerning, avances) y, por tanto, a los saltos de línea y al ajuste?**

Sí. Cambiar la fuente modifica las métricas de los glifos y puede alterar los saltos de línea, el ajuste y la paginación durante el renderizado. Para mantener la estabilidad del diseño, [incorpore las fuentes originales](/slides/es/cpp/embedded-font/) o seleccione familias predeterminadas y de sustitución compatibles métricamente.

**¿Tiene sentido establecer fuentes predeterminadas si todas las fuentes usadas en la presentación están incrustadas?**

A menudo no es necesario, porque [fuentes incrustadas](/slides/es/cpp/embedded-font/) ya garantizan una apariencia coherente. Las fuentes predeterminadas siguen siendo útiles como red de seguridad para los caracteres que no están cubiertos por el subconjunto incrustado o cuando un archivo mezcla texto incrustado y no incrustado.