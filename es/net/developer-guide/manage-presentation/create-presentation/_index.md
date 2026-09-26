---
title: Crear presentaciones en .NET
linktitle: Crear presentación
type: docs
weight: 10
url: /es/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Crea presentaciones en .NET con Aspose.Slides—produce archivos PPT, PPTX y ODP, aprovecha el soporte OpenDocument y guárdalos programáticamente para obtener resultados fiables."
---
## **Visión general**

Este artículo muestra cómo crear una presentación en Aspose.Slides, añadir un cuadro de texto a su primera diapositiva y guardar el resultado como un archivo. También muestra cómo crear y guardar una presentación vacía, y cómo abrir una presentación existente en un formato compatible y guardarla en otro formato. Al final se incluye una breve FAQ que cubre preguntas comunes sobre formatos, plantillas, tamaño de diapositivas, unidades, uso de memoria, subprocesos, licencias, firmas digitales y compatibilidad con VBA.

Antes de comenzar, añada Aspose.Slides a su proyecto desde NuGet. Consulte [Instalación](/slides/es/net/installation/) para el paquete que se utiliza en Windows, Linux y macOS.

## **Crear una presentación de PowerPoint**

Para crear una presentación y colocar un cuadro de texto en su primera diapositiva, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). Una nueva presentación ya contiene una diapositiva vacía.
2. Obtenga esa diapositiva de la colección [Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) por su índice, 0.
3. Añada un rectángulo con el método [AddAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addautoshape/) y establezca su [text](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/text/).
4. Guarde la presentación como un archivo PPTX con el método [Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

La esquina superior izquierda del rectángulo está a 50 puntos del borde izquierdo y a 50 puntos del borde superior de la diapositiva, y el rectángulo tiene 400 puntos de ancho y 100 puntos de alto. El archivo guardado contiene una diapositiva con ese rectángulo y su texto. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a cada diapositiva que guarda; consulte [Licencias](/slides/es/net/licensing/).

## **Crear y guardar una presentación**

<a name="csharp-create-save-presentation"></a>

Para crear una presentación vacía y guardarla, cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y guárdela en cualquier formato de la enumeración [SaveFormat](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveformat/). El resultado es una presentación con una diapositiva vacía.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Abrir y guardar una presentación**

<a name="csharp-open-save-presentation"></a>

Para convertir una presentación de un formato a otro, ábrala pasando su ruta al constructor de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/presentation/), y luego guárdela en el formato destino. Aspose.Slides detecta el formato de entrada, como PPT, PPTX u ODP, a partir del propio archivo.

El ejemplo siguiente espera una presentación OpenDocument llamada *Sample.odp* en el directorio de trabajo y la guarda como PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

### ¿En qué formatos puedo guardar una nueva presentación?

Puede guardar en [PPTX, PPT y ODP](/slides/es/net/save-presentation/), y exportar a [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [XPS](/slides/es/net/convert-powerpoint-to-xps/), [HTML](/slides/es/net/convert-powerpoint-to-html/), [SVG](/slides/es/net/render-a-slide-as-an-svg-image/) y [images](/slides/es/net/convert-powerpoint-to-png/), entre otros.

### ¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/net/supported-file-formats/).

### ¿Cómo controlo el tamaño/rela­ción de aspecto de la diapositiva al crear una presentación?

Establezca el [tamaño de diapositiva](/slides/es/net/slide-size/) (incluyendo valores predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

### ¿En qué unidades se miden los tamaños y coordenadas?

En puntos: 1 pulgada equivale a 72 unidades.

### ¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?

Utilice [estrategias de gestión de BLOB](/slides/es/net/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos de trabajo basados en archivos en lugar de flujos puramente en memoria.

### ¿Puedo crear/guardar presentaciones en paralelo?

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/net/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

### ¿Cómo elimino la marca de agua de prueba y las limitaciones?

[Aplique una licencia](/slides/es/net/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si hay múltiples hilos involucrados.

### ¿Puedo firmar digitalmente el PPTX que creo?

Sí. Las [firmas digitales](/slides/es/net/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

### ¿Se admiten macros (VBA) en presentaciones creadas?

Sí. Puede [crear/editar proyectos VBA](/slides/es/net/presentation-via-vba/) y guardar archivos con macros como PPTM/PPSM.