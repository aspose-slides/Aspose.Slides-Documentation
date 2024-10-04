---
title: Fuente Predeterminada
type: docs
weight: 30
url: /cpp/default-font/
keywords: 
- fuente
- fuente predeterminada
- presentación de renderizado
- PowerPoint
- presentación
- C++
- Aspose.Slides para C++
description: La API de PowerPoint C++ te permite establecer la fuente predeterminada para renderizar presentaciones a PDF, XPS o miniaturas
---

## **Establecer Fuente Predeterminada**
Usando Aspose.Slides para C++ puedes establecer la fuente predeterminada en presentaciones de PowerPoint. Se ha añadido un nuevo método [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) a la clase [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/). Permite establecer la fuente predeterminada utilizada en lugar de todas las fuentes faltantes al guardar presentaciones en diferentes formatos sin recargar las presentaciones.

El fragmento de código a continuación demuestra cómo guardar una presentación en [HTML](https://docs.fileformat.com/web/html/) y [PDF](https://docs.fileformat.com/pdf/) con diferentes fuentes regulares predeterminadas.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **Usar Fuentes Predeterminadas para Renderizar la Presentación**
Aspose.Slides te permite establecer la fuente predeterminada para renderizar la presentación a PDF, XPS o miniaturas. Este artículo muestra cómo definir la FuenteRegularPredeterminada y la FuenteAsiáticaPredeterminada para usarlas como fuentes predeterminadas. Sigue los pasos a continuación para cargar fuentes desde directorios externos utilizando la API de Aspose.Slides para C++:

1. Crea una instancia de LoadOptions.
1. Establece la FuenteRegularPredeterminada a la fuente deseada. En el siguiente ejemplo, he utilizado Wingdings.
1. Establece la FuenteAsiáticaPredeterminada a la fuente deseada. He utilizado Wingdings en el siguiente ejemplo.
1. Carga la presentación usando Presentation y estableciendo las opciones de carga.
1. Ahora, genera la miniatura de la diapositiva, PDF y XPS para verificar los resultados.

La implementación de lo anterior se presenta a continuación.

```cpp
// Usa las opciones de carga para especificar fuentes regulares y asiáticas predeterminadas
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