---
title: Crear presentaciones en Android
linktitle: Crear presentación
type: docs
weight: 10
url: /es/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Crear presentaciones en Java con Aspose.Slides para Android - produzca archivos PPT, PPTX y ODP, aproveche la compatibilidad con OpenDocument y guárdelas programáticamente para obtener resultados fiables."
---
## **Descripción general**

Este artículo muestra cómo crear una presentación en Aspose.Slides para Android mediante Java, añadir un cuadro de texto a su primera diapositiva y guardar el resultado como un archivo en el almacenamiento de su aplicación. Para abrir una presentación existente o guardarla en otro formato, consulte [Abrir presentación](/slides/es/androidjava/open-presentation/) y [Guardar presentación](/slides/es/androidjava/save-presentation/). Al final hay una breve sección de Preguntas frecuentes que cubre preguntas habituales sobre formatos, plantillas, tamaño de diapositivas, unidades, uso de memoria, subprocesos, licencias, firmas digitales y compatibilidad con VBA.

Antes de comenzar, añada Aspose.Slides a su proyecto Android desde el repositorio Maven de Aspose. Vea [Instalación](/slides/es/androidjava/install-aspose-slides-for-android-via-java/).

## **Crear una presentación de PowerPoint**

Para crear una presentación y colocar un cuadro de texto en su primera diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Una nueva presentación ya contiene una diapositiva vacía.
1. Obtenga esa diapositiva de la [colección de diapositivas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) por su índice, 0.
1. Agregue un rectángulo con el método [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) de la [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/), y establezca el texto de su [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) mediante el método [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).
1. Guarde la presentación como un archivo PPTX con el método [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), en el formato [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/).

El código se ejecuta dentro de una `Activity`, por ejemplo en su método `onCreate`. Guarda el archivo en el directorio devuelto por el método [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) : el almacenamiento privado de su aplicación, al que puede escribir sin solicitar ningún permiso.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La esquina superior izquierda del rectángulo está a 50 puntos del borde izquierdo y a 50 puntos del borde superior de la diapositiva, y el rectángulo mide 400 puntos de ancho y 100 puntos de alto. El archivo guardado contiene una diapositiva con ese rectángulo y su texto. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a cada diapositiva que guarda; consulte [Licencias](/slides/es/androidjava/licensing/).

Para ver el archivo, abra el [Device Explorer] de Android Studio y busque *hello.pptx* bajo *data/data/*, en la carpeta *files* de su aplicación. En una aplicación real, procese las presentaciones en un hilo en segundo plano para que la interfaz de usuario permanezca receptiva.

## **Preguntas frecuentes**

### ¿En qué formatos puedo guardar una nueva presentación?

Puede guardarla en [PPTX, PPT y ODP](/slides/es/androidjava/save-presentation/), y exportarla a [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/es/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/es/androidjava/convert-powerpoint-to-html/), [SVG](/slides/es/androidjava/render-a-slide-as-an-svg-image/) y [imágenes](/slides/es/androidjava/convert-powerpoint-to-png/), entre otros.

### ¿Puedo comenzar a partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/androidjava/supported-file-formats/).

### ¿Cómo controlo el tamaño/aspecto de la diapositiva al crear una presentación?

Establezca el [tamaño de diapositiva](/slides/es/androidjava/slide-size/) (incluyendo preajustes como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

### ¿En qué unidades se miden los tamaños y coordenadas?

En puntos: 1 pulgada equivale a 72 unidades.

### ¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?

Utilice [BLOB management strategies](/slides/es/androidjava/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos basados en archivos en lugar de flujos completamente en memoria.

### ¿Puedo crear/guardar presentaciones en paralelo?

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) desde [varios hilos](/slides/es/androidjava/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

### ¿Cómo elimino la marca de agua de prueba y las limitaciones?

[Aplique una licencia](/slides/es/androidjava/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si hay varios hilos involucrados.

### ¿Puedo firmar digitalmente el PPTX que creo?

Sí. Las [firmas digitales](/slides/es/androidjava/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

### ¿Se admiten macros (VBA) en presentaciones creadas?

Sí. Puede [crear/editar proyectos VBA](/slides/es/androidjava/presentation-via-vba/) y guardar archivos con macros como PPTM/PPSM.