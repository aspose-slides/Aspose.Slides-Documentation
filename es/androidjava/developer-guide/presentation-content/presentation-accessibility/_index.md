---
title: Gestionar la accesibilidad de presentaciones en Android
linktitle: Accesibilidad de presentaciones
type: docs
weight: 30
url: /es/androidjava/presentation-accessibility/
keywords:
- accesibilidad de presentaciones
- texto alternativo
- título de texto alternativo
- descripción de texto alternativo
- marcar como decorativo
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Android mediante Java ayuda a automatizar las comprobaciones de accesibilidad de presentaciones en archivos PPT, PPTX y ODP—mejore la experiencia de los lectores de pantalla y aumente el cumplimiento."
---
## **Introducción**

El texto alternativo ayuda a las personas que utilizan tecnologías de asistencia a comprender el significado de imágenes, gráficos y otras formas informativas. Este artículo explica cómo leer y actualizar los títulos y descripciones de texto alternativo con Aspose.Slides para Android mediante Java, distinguir las descripciones de accesibilidad de los nombres de forma utilizados en el código y comprobar si una forma está marcada como decorativa.

Estas funciones apoyan la accesibilidad de las presentaciones, pero no la garantizan. También es necesario revisar el orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos de accesibilidad.

## **Administrar títulos y descripciones de texto alternativo**

Utilice texto alternativo para explicar el significado de imágenes, gráficos y otras formas informativas a las personas que no pueden verlas. Los siguientes métodos y contenidos sirven a diferentes propósitos:

| Método o contenido | Propósito |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Un título corto para la descripción alternativa. |
| [getAlternativeText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getAlternativeText--) | Una descripción significativa del contenido o propósito de la forma en el contexto de la diapositiva. |
| [getName](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getName--) | El nombre de la forma, que el código puede usar para encontrar una forma específica en la presentación. |
| Texto visible | Contenido mostrado en la diapositiva, como el texto de una forma o el título y etiquetas de un gráfico. Actualizar el texto alternativo no cambia este contenido. |

Cuando una presentación se reutiliza como plantilla, el código puede encontrar una forma por el nombre devuelto por [getName](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getName--) antes de actualizarla. Este nombre cumple una función diferente al texto alternativo, que explica lo que lo visual comunica al lector. Buscar por nombre permite a los autores mejorar o traducir descripciones sin cambiar la forma en que el código localiza la forma. Los nombres pueden editarse y no están garantizados como únicos, por lo que hay que comprobar que el nombre coincida con la forma prevista; consulte [Identificar y Encontrar Formas](/slides/es/androidjava/shape-manipulations/#identify-and-find-shapes).

El siguiente ejemplo requiere `input.pptx` con una imagen de la entrada de una oficina como la primera forma en la primera diapositiva. La imagen no debe estar marcada como decorativa. El ejemplo lee e imprime el título y la descripción actuales del texto alternativo, actualiza ambos valores y guarda la presentación como `output.pptx`. Adapte la redacción a la imagen real y a la información que transmite.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    System.out.println("Alternative text title: " + shape.getAlternativeTextTitle());
    System.out.println("Alternative text description: " + shape.getAlternativeText());

    shape.setAlternativeTextTitle("Office entrance");
    shape.setAlternativeText("The office entrance has a wheelchair ramp to the right of the steps.");

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Añadir solo texto alternativo no garantiza la accesibilidad de la presentación ni el cumplimiento de normas de accesibilidad. Revise las descripciones para asegurar su exactitud y relevancia, y también verifique el orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos de accesibilidad. Los elementos visuales informativos no deben marcarse como decorativos; la siguiente sección muestra cómo comprobar [isDecorative](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#isDecorative--).

## **Marcar como decorativo**

Marcar como decorativo indica que los elementos visuales puramente ornamentales deben ser omitidos por los lectores de pantalla, reduciendo el ruido y manteniendo el foco en el contenido significativo. Aplíquese a fondos, adornos y separadores, nunca a gráficos, íconos o imágenes que transmitan información. Aspose.Slides expone esta bandera para su detección y validación, permitiendo comprobaciones automatizadas de accesibilidad y limpieza.

![Marcar como decorativo](mark_as_decorative.png)

El siguiente fragmento de código muestra cómo determinar si una forma está marcada como decorativa.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**¿Qué debo incluir en el título y la descripción del texto alternativo?**

Utilice un título breve para identificar el asunto y una descripción para explicar la información que lo visual transmite en el contexto de la diapositiva. Para un gráfico, describa la tendencia o comparación relevante en lugar de limitarse a decir "gráfico".

**¿Debo usar el texto alternativo para localizar formas en una plantilla?**

Preferiblemente busque la forma por el nombre devuelto por [getName](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getName--) y compruebe que sea la forma esperada. El texto alternativo puede editarse o traducirse, lo que puede romper el código que busca una descripción exacta; consulte [Identificar y Encontrar Formas](/slides/es/androidjava/shape-manipulations/).

**¿Cuándo debe marcarse una forma como decorativa?**

Utilice la bandera decorativa para elementos visuales que no aportan información, como adornos ornamentales. Las imágenes y los gráficos que comunican significado necesitan una descripción adecuada en su lugar.

**¿Agregar texto alternativo hace que una presentación sea totalmente accesible?**

No. El texto alternativo solo aborda una parte de la accesibilidad. También es necesario revisar el orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos aplicables; establecer solo estas propiedades no garantiza el cumplimiento.