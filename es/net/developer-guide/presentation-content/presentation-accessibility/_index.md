---
title: Gestionar la accesibilidad de presentaciones en .NET
linktitle: Accesibilidad de presentaciones
type: docs
weight: 30
url: /es/net/presentation-accessibility/
keywords:
- accesibilidad de presentaciones
- texto alternativo
- título de texto alternativo
- descripción de texto alternativo
- marcar como decorativo
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Automatiza las comprobaciones de accesibilidad de presentaciones en archivos PPT, PPTX y ODP con Aspose.Slides para .NET—mejora la experiencia de los lectores de pantalla y aumenta el cumplimiento."
---
## **Introducción**

El texto alternativo ayuda a las personas que utilizan tecnologías de asistencia a comprender el significado de imágenes, gráficos y otras formas informativas. Este artículo explica cómo leer y actualizar los títulos y descripciones de texto alternativo con Aspose.Slides para .NET, distinguir las descripciones de accesibilidad de los nombres de forma usados en el código y comprobar si una forma está marcada como decorativa.

Estas funciones respaldan la accesibilidad de las presentaciones, pero no la garantizan. El orden de lectura, el contraste de color, la legibilidad del texto y otros requisitos de accesibilidad también deben revisarse.

## **Gestionar títulos y descripciones de texto alternativo**

Utilice el texto alternativo para explicar el significado de imágenes, gráficos y otras formas informativas a las personas que no pueden verlas. Las siguientes propiedades sirven a diferentes propósitos:

| Propiedad o contenido | Propósito |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/alternativetexttitle/) | Un título breve para la descripción alternativa. |
| [AlternativeText](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/alternativetext/) | Una descripción significativa del contenido o propósito de la forma en el contexto de la diapositiva. |
| [Name](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/name/) | El nombre de la forma, que el código puede usar para encontrar una forma específica en la presentación. |
| Visible text | Contenido visible en la diapositiva, como el texto de una forma o el título y las etiquetas de un gráfico. Actualizar el texto alternativo no cambia este contenido. |

Cuando una presentación se reutiliza como plantilla, el código puede encontrar una forma por su [Name](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/name/) antes de actualizarla. Este nombre sirve a un propósito diferente del texto alternativo, que explica lo que lo visual comunica al lector. Buscar por nombre permite a los autores mejorar o traducir las descripciones sin cambiar la forma en que el código localiza la forma. Los nombres pueden modificarse y no están garantizados como únicos, así que compruebe que el nombre corresponde a la forma prevista; vea [Identificar y encontrar formas](/slides/es/net/shape-manipulations/#identify-and-find-shapes).

El siguiente ejemplo requiere `input.pptx` con una imagen de la entrada de una oficina como la primera forma de la primera diapositiva. La imagen no debe estar marcada como decorativa. El ejemplo lee e imprime su título y descripción actuales de texto alternativo, actualiza ambos valores y guarda la presentación como `output.pptx`. Adapte la redacción a la imagen real y a la información que transmite.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Añadir solo texto alternativo no garantiza la accesibilidad de la presentación ni el cumplimiento de los estándares de accesibilidad. Revise las descripciones para asegurar precisión y relevancia, y también compruebe el orden de lectura, el contraste de color, la legibilidad del texto y otros requisitos de accesibilidad. Los recursos visuales informativos no deben marcarse como decorativos; la siguiente sección muestra cómo leer [IsDecorative](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/isdecorative/).

## **Marcar como decorativo**

Marcar como decorativo indica que los recursos puramente ornamentales deben ser omitidos por los lectores de pantalla, reduciendo el ruido y manteniendo el foco en el contenido significativo. Aplíquelo a fondos, adornos y separadores, nunca a gráficos, iconos o imágenes que transmitan información. Aspose.Slides expone esta bandera para su detección y validación, lo que permite comprobaciones automáticas de accesibilidad y limpieza.

![Marcar como decorativo](mark_as_decorative.png)

El siguiente fragmento de código muestra cómo determinar si una forma está marcada como decorativa.

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **Preguntas frecuentes**

**¿Qué debo incluir en el título y la descripción del texto alternativo?**

Utilice un título breve para identificar el tema y una descripción para explicar la información que el recurso visual comunica en el contexto de la diapositiva. Para un gráfico, describa la tendencia o comparación relevante en lugar de limitarse a decir “gráfico”.

**¿Debo usar texto alternativo para localizar formas en una plantilla?**

Preferiblemente localice la forma por su [Name](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/name/) y verifique que sea la forma esperada. El texto alternativo puede ser editado o traducido, lo que puede romper el código que busca una descripción exacta; vea [Identificar y encontrar formas](/slides/es/net/shape-manipulations/).

**¿Cuándo debe marcarse una forma como decorativa?**

Utilice la bandera decorativa para recursos que no aportan información, como adornos ornamentales. Las imágenes y los gráficos que comunican significado requieren una descripción adecuada en su lugar.

**¿Añadir texto alternativo hace que una presentación sea totalmente accesible?**

No. El texto alternativo aborda solo una parte de la accesibilidad. También revise el orden de lectura, el contraste de color, la legibilidad del texto y otros requisitos aplicables; establecer solo estas propiedades no garantiza el cumplimiento.