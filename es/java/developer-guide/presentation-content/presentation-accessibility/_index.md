---
title: Gestionar la accesibilidad de presentaciones en Java
linktitle: Accesibilidad de presentaciones
type: docs
weight: 30
url: /es/java/presentation-accessibility/
keywords:
- accesibilidad de presentaciones
- texto alternativo
- título de texto alternativo
- descripción de texto alternativo
- marcar como decorativo
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides for Java ayuda a automatizar la comprobación de accesibilidad de presentaciones en archivos PPT, PPTX y ODP, mejorando la experiencia de los lectores de pantalla y aumentando el cumplimiento."
---
## **Introducción**

El texto alternativo ayuda a las personas que utilizan tecnologías de asistencia a comprender el significado de imágenes, gráficos y otras formas informativas. Este artículo explica cómo leer y actualizar los títulos y descripciones de texto alternativo con Aspose.Slides for Java, distinguir las descripciones de accesibilidad de los nombres de forma usados en el código y comprobar si una forma está marcada como decorativa.

Estas funciones apoyan la accesibilidad de las presentaciones, pero no la garantizan. El orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos de accesibilidad también deben revisarse.

## **Gestionar títulos y descripciones de texto alternativo**

Utilice texto alternativo para explicar el significado de imágenes, gráficos y otras formas informativas a las personas que no pueden verlas. Los siguientes métodos y contenidos sirven a diferentes propósitos:

| Método o contenido | Propósito |
| --- | --- |
| [getAlternativeTextTitle](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getAlternativeTextTitle--) | Un título corto para la descripción alternativa. |
| [getAlternativeText](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getAlternativeText--) | Una descripción significativa del contenido o propósito de la forma en el contexto de la diapositiva. |
| [getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getName--) | El nombre de la forma, que el código puede usar para encontrar una forma específica en la presentación. |
| Texto visible | Contenido mostrado en la diapositiva, como el texto de una forma o el título y las etiquetas de un gráfico. Actualizar el texto alternativo no cambia este contenido. |

Cuando una presentación se reutiliza como plantilla, el código puede encontrar una forma por el nombre devuelto por [getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getName--) antes de actualizarla. Este nombre sirve a un propósito diferente al texto alternativo, que explica lo que lo visual comunica al lector. Buscar por nombre permite a los autores mejorar o traducir descripciones sin cambiar la forma en que el código encuentra la forma. Los nombres pueden editarse y no garantizan ser únicos, por lo que debe comprobar que el nombre coincide con la forma deseada; consulte [Identify and Find Shapes](/slides/es/java/shape-manipulations/#identify-and-find-shapes).

El siguiente ejemplo requiere `input.pptx` con una imagen de la entrada de una oficina como la primera forma de la primera diapositiva. La imagen no debe estar marcada como decorativa. El ejemplo lee e imprime su título y descripción actuales de texto alternativo, actualiza ambos valores y guarda la presentación como `output.pptx`. Adapte la redacción a la imagen real y a la información que transmite.

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

Añadir solo texto alternativo no garantiza la accesibilidad de la presentación ni el cumplimiento de las normas de accesibilidad. Revise las descripciones para comprobar su exactitud y relevancia, y también verifique el orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos de accesibilidad. Los elementos visuales informativos no deben marcarse como decorativos; la siguiente sección muestra cómo comprobar [isDecorative](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#isDecorative--).

## **Marcar como decorativo**

Marcar como decorativo indica que los elementos puramente ornamentales deben ser omitidos por los lectores de pantalla, reduciendo el ruido y centrando la atención en el contenido significativo. Aplíquelo a fondos, adornos y separadores, pero nunca a gráficos, iconos o imágenes que transmitan información. Aspose.Slides expone esta bandera para su detección y validación, lo que permite comprobar y limpiar la accesibilidad de forma automatizada.

![Mark as Decorative](mark_as_decorative.png)

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

## **Preguntas frecuentes**

**¿Qué debo colocar en el título y la descripción del texto alternativo?**

Use un título breve para identificar el tema y una descripción para explicar la información que lo visual transmite en el contexto de la diapositiva. Para un gráfico, describa la tendencia o comparación relevante en lugar de limitarse a decir “gráfico”.

**¿Debo usar texto alternativo para localizar formas en una plantilla?**

Prefiera encontrar la forma por el nombre devuelto por [getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getName--) y comprobar que sea la forma esperada. El texto alternativo puede editarse o traducirse, lo que puede romper el código que busca una descripción exacta; vea [Identify and Find Shapes](/slides/es/java/shape-manipulations/).

**¿Cuándo debe una forma marcarse como decorativa?**

Use la bandera decorativa para elementos visuales que no aportan información, como adornos ornamentales. Las imágenes y gráficos que comunican significado necesitan una descripción adecuada en su lugar.

**¿Agregar texto alternativo hace que una presentación sea completamente accesible?**

No. El texto alternativo solo aborda una parte de la accesibilidad. También revise el orden de lectura, el contraste de colores, la legibilidad del texto y otros requisitos aplicables; establecer solo estas propiedades no garantiza el cumplimiento.