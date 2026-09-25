---
title: Gestionar accesibilidad de presentaciones en C++
linktitle: Accesibilidad de presentaciones
type: docs
weight: 30
url: /es/cpp/presentation-accessibility/
keywords:
- accesibilidad de presentaciones
- texto alternativo
- título de texto alternativo
- descripción de texto alternativo
- marcar como decorativo
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Automatiza la comprobación de accesibilidad de presentaciones en archivos PPT, PPTX y ODP con Aspose.Slides para C++ - mejora la experiencia del lector de pantalla y aumenta el cumplimiento."
---
## **Introducción**

El texto alternativo ayuda a las personas que utilizan tecnologías de asistencia a comprender el significado de imágenes, gráficos y otras formas informativas. Este artículo explica cómo leer y actualizar los títulos y descripciones de texto alternativo con Aspose.Slides for C++, cómo distinguir las descripciones de accesibilidad de los nombres de forma usados en el código y cómo comprobar si una forma está marcada como decorativa.

Estas funciones respaldan la accesibilidad de presentaciones, pero no la garantizan. El orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos de accesibilidad también deben revisarse.

## **Gestionar títulos y descripciones de texto alternativo**

Utilice texto alternativo para explicar el significado de imágenes, gráficos y otras formas informativas a las personas que no pueden verlas. Las siguientes propiedades sirven a diferentes propósitos:

| Propiedad o contenido | Propósito |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_alternativetexttitle/) | Un título breve para la descripción alternativa. |
| [AlternativeText](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_alternativetext/) | Una descripción significativa del contenido o propósito de la forma en el contexto de la diapositiva. |
| [Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_name/) | El nombre de la forma, que el código puede usar para encontrar una forma específica en la presentación. |
| Texto visible | Contenido mostrado en la diapositiva, como el texto de una forma o el título y etiquetas de un gráfico. Actualizar el texto alternativo no cambia este contenido. |

Cuando una presentación se reutiliza como plantilla, el código puede encontrar una forma por su [Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_name/) antes de actualizarla. Este nombre sirve a un propósito distinto del texto alternativo, que explica lo que lo visual comunica al lector. Buscar por nombre permite a los autores mejorar o traducir descripciones sin cambiar la forma en que el código localiza la forma. Los nombres pueden editarse y no están garantizados como únicos, así que compruebe que el nombre coincide con la forma prevista; vea [Identificar y encontrar formas](/slides/es/cpp/shape-manipulations/#identify-and-find-shapes).

El siguiente ejemplo requiere `input.pptx` con una imagen de la entrada de una oficina como primera forma en la primera diapositiva. La imagen no debe estar marcada como decorativa. El ejemplo lee e imprime su título y descripción de texto alternativo actuales, actualiza ambos valores y guarda la presentación como `output.pptx`. Adapte la redacción a la imagen real y a la información que transmite.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Agregar solo texto alternativo no garantiza la accesibilidad de la presentación ni el cumplimiento de normas de accesibilidad. Revise las descripciones para que sean precisas y pertinentes, y también compruebe el orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos de accesibilidad. Los recursos informativos no deben marcarse como decorativos; la siguiente sección muestra cómo leer [IsDecorative](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_isdecorative/).

## **Marcar como decorativo**

Marcar como decorativo indica que los recursos puramente ornamentales deben ser omitidos por los lectores de pantalla, reduciendo el ruido y centrando la atención en el contenido significativo. Aplíquelo a fondos, adornos y separadores, pero nunca a gráficos, íconos o imágenes que transmiten información. Aspose.Slides expone esta marca para su detección y validación, lo que permite comprobaciones automáticas de accesibilidad y limpieza.

![Marca como decorativo](mark_as_decorative.png)

El siguiente fragmento de código muestra cómo determinar si una forma está marcada como decorativa.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Qué debo poner en el título y la descripción del texto alternativo?**

Utilice un título breve para identificar el asunto y una descripción para explicar la información que la visualización transmite en el contexto de la diapositiva. Para un gráfico, describa la tendencia o comparación relevante en lugar de limitarse a decir “gráfico”.

**¿Debo usar texto alternativo para localizar formas en una plantilla?**

Prefiera localizar la forma por su [Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_name/) y compruebe que sea la forma esperada. El texto alternativo puede editarse o traducirse, lo que podría romper el código que busca una descripción exacta; vea [Identificar y encontrar formas](/slides/es/cpp/shape-manipulations/).

**¿Cuándo debe marcarse una forma como decorativa?**

Use la marca decorativa para recursos que no aportan información, como adornos ornamentales. Las imágenes y gráficos que comunican significado necesitan una descripción adecuada en su lugar.

**¿Agregar texto alternativo hace que una presentación sea totalmente accesible?**

No. El texto alternativo solo aborda una parte de la accesibilidad. También revise el orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos aplicables; establecer solo estas propiedades no garantiza el cumplimiento.