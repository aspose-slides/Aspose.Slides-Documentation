---
title: Crear presentaciones en Java
linktitle: Crear presentación
type: docs
weight: 10
url: /es/java/create-presentation/
keywords:
- crear presentación
- nueva presentación
- crear PPT
- nuevo PPT
- crear PPTX
- nuevo PPTX
- crear ODP
- nuevo ODP
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Crea presentaciones en Java con Aspose.Slides - genera archivos PPT, PPTX y ODP, aprovecha la compatibilidad con OpenDocument y guárdalos programáticamente para obtener resultados fiables."
---
## **Visión general**

Este artículo muestra cómo crear una presentación en Aspose.Slides, añadir una forma con texto a su primera diapositiva y guardar el resultado como un archivo PPTX. Para abrir una presentación existente y guardarla en otro formato, consulte [Open Presentations](/slides/es/java/open-presentation/) y [Save Presentations](/slides/es/java/save-presentation/). Un breve FAQ al final cubre preguntas comunes sobre formatos, plantillas, tamaño de diapositivas, unidades, uso de memoria, subprocesos, licencias, firmas digitales y compatibilidad con VBA.

Antes de comenzar, añada Aspose.Slides for Java a su proyecto desde el repositorio Maven de Aspose. Consulte [Installation](/slides/es/java/installation/) para la configuración de Maven y lo que Linux necesita adicionalmente.

## **Crear una presentación**

Crear un archivo PowerPoint desde cero en Aspose.Slides for Java comienza con una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). El constructor proporciona una presentación en blanco con una sola diapositiva, lista para formas, texto, gráficos o cualquier otro contenido que su aplicación requiera. Una vez que modifique esa diapositiva o añada nuevas, puede guardar el resultado en formato PPTX, PPT clásico u OpenDocument.

Para crear una presentación y colocar una forma con texto en su primera diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/). Una nueva presentación ya contiene una diapositiva vacía.
1. Obtenga esa diapositiva por su índice, 0, de la colección que devuelve [getSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getSlides--).
1. Añada un [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/) del tipo `Cloud` con el método [addAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) y establezca su texto con [setText](https://reference.aspose.com/slides/es/java/com.aspose.slides/itextframe/#setText-java.lang.String-).
1. Guarde la presentación como archivo PPTX con el método [save](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

El ejemplo a continuación es un programa completo. En el proyecto Maven de [Installation](/slides/es/java/installation/), guárdelo como *src/main/java/HelloSlides.java* y ejecute `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Crear una presentación. Ya contiene una diapositiva vacía.
        Presentation presentation = new Presentation();
        try {
            // Obtener la primera diapositiva.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Añadir una forma de nube y colocar texto en ella.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Guardar la presentación como archivo PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

La esquina superior izquierda de la nube está a 20 puntos del borde izquierdo y a 20 puntos del borde superior de la diapositiva, y la forma tiene 200 puntos de ancho y 80 puntos de alto. El programa guarda *new_presentation.pptx* con una diapositiva que contiene la nube y su texto. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a cada diapositiva que guarda; consulte [Licensing](/slides/es/java/licensing/).

El resultado:

![The new presentation](new_presentation.png)

## **Preguntas frecuentes**

### ¿A qué formatos puedo guardar una nueva presentación?

Puede guardar en [PPTX, PPT y ODP](/slides/es/java/save-presentation/), y exportar a [PDF](/slides/es/java/convert-powerpoint-to-pdf/), [XPS](/slides/es/java/convert-powerpoint-to-xps/), [HTML](/slides/es/java/convert-powerpoint-to-html/), [SVG](/slides/es/java/render-a-slide-as-an-svg-image/) e [imágenes](/slides/es/java/convert-powerpoint-to-png/), entre otros.

### ¿Puedo partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/java/supported-file-formats/).

### ¿Cómo controlo el tamaño/aspecto de la diapositiva al crear una presentación?

Configure el [tamaño de diapositiva](/slides/es/java/slide-size/) (incluyendo preestablecidos como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalarse el contenido.

### ¿En qué unidades se miden los tamaños y coordenadas?

En puntos: 1 pulgada equivale a 72 unidades.

### ¿Cómo gestiono presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?

Utilice [estrategias de gestión de BLOB](/slides/es/java/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos de trabajo basados en archivos sobre streams puramente en memoria.

### ¿Puedo crear/guardar presentaciones en paralelo?

No se puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) desde [múltiples hilos](/slides/es/java/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

### ¿Cómo elimino la marca de agua de prueba y las limitaciones?

[Aplicar una licencia](/slides/es/java/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si intervienen varios hilos.

### ¿Puedo firmar digitalmente el PPTX que creo?

Sí. Las [firmas digitales](/slides/es/java/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

### ¿Se admiten macros (VBA) en las presentaciones creadas?

Sí. Puede [crear/editar proyectos VBA](/slides/es/java/presentation-via-vba/) y guardar archivos con macros activadas como PPTM/PPSM.