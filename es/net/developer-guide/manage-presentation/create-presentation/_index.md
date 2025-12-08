---
title: Crear presentación en .NET
linktitle: Crear presentación
type: docs
weight: 10
url: /es/net/create-presentation/
keywords: "Crear PowerPoint, PPTX, PPT, Crear presentación, Inicializar presentación, C#, .NET"
description: "Crear presentaciones de PowerPoint mediante programación en C# p. ej. PPT, PPTX, ODP, etc."
---

## **Crear presentación de PowerPoint**
Para agregar una línea simple y plana a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
1. Obtenga la referencia de una diapositiva usando su índice.
1. Agregue un AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes.
1. Guarde la presentación modificada como un archivo PPTX.

En el ejemplo mostrado a continuación, hemos agregado una línea a la primera diapositiva de la presentación.
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Agregar un AutoShape de tipo línea
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **Crear y guardar presentación**

<a name="csharp-create-save-presentation"><strong>Pasos: crear y guardar presentación en C#</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Guarde _Presentation_ en cualquier formato admitido por [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Abrir y guardar presentación**

<a name="csharp-open-save-presentation"><strong>Pasos: abrir y guardar presentación en C#</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) con cualquier formato, p. ej., PPT, PPTX, ODP, etc.
2. Guarde _Presentation_ en cualquier formato admitido por [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
 // Cargar cualquier archivo compatible en Presentation, p. ej. ppt, pptx, odp, etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿En qué formatos puedo guardar una nueva presentación?**

Puede guardar en [PPTX, PPT y ODP](/slides/es/net/save-presentation/), y exportar a [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [XPS](/slides/es/net/convert-powerpoint-to-xps/), [HTML](/slides/es/net/convert-powerpoint-to-html/), [SVG](/slides/es/net/convert-powerpoint-to-png/), y [imágenes](/slides/es/net/convert-powerpoint-to-png/), entre otros.

**¿Puedo comenzar a partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?**

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/net/supported-file-formats/).

**¿Cómo controlo el tamaño/aspecto de la diapositiva al crear una presentación?**

Establezca el [tamaño de la diapositiva](/slides/es/net/slide-size/) (incluidos los valores predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [estrategias de gestión de BLOB](/slides/es/net/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos de trabajo basados en archivos en lugar de flujos puramente en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) desde [múltiples subprocesos](/slides/es/net/multithreading/). Ejecute instancias separadas y aisladas por subproceso o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Aplique una licencia](/slides/es/net/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si participan varios subprocesos.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/net/digital-signature-in-powerpoint/) (agregar y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en presentaciones creadas?**

Sí. Puede [crear/editar proyectos VBA](/slides/es/net/presentation-via-vba/) y guardar archivos con macros como PPTM/PPSM.