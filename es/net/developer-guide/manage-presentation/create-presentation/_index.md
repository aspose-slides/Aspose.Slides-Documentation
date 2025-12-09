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

## **Crear presentación de PowerPoint**
Para agregar una línea simple y plana a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
1. Obtenga la referencia de una diapositiva usando su índice.
1. Añada un AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos añadido una línea a la primera diapositiva de la presentación.
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Añadir una autoshape de tipo línea
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```


## **Crear y guardar presentación**

<a name="csharp-create-save-presentation"><strong>Pasos: crear y guardar presentación en C#</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Guarde _Presentation_ en cualquier formato compatible con [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Abrir y guardar presentación**

<a name="csharp-open-save-presentation"><strong>Pasos: abrir y guardar presentación en C#</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) con cualquier formato, p. ej., PPT, PPTX, ODP, etc.
2. Guarde _Presentation_ en cualquier formato compatible con [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)
```c#
// Cargar cualquier archivo compatible en Presentation, por ejemplo ppt, pptx, odp, etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿En qué formatos puedo guardar una nueva presentación?**

Puede guardar en [PPTX, PPT y ODP](/slides/es/net/save-presentation/), y exportar a [PDF](/slides/es/net/convert-powerpoint-to-pdf/), [XPS](/slides/es/net/convert-powerpoint-to-xps/), [HTML](/slides/es/net/convert-powerpoint-to-html/), [SVG](/slides/es/net/convert-powerpoint-to-png/) y [imágenes](/slides/es/net/convert-powerpoint-to-png/), entre otros.

**¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?**

Sí. Cargue la plantilla y guarde en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/net/supported-file-formats/).

**¿Cómo controlo el tamaño o la relación de aspecto de la diapositiva al crear una presentación?**

Establezca el [tamaño de la diapositiva](/slides/es/net/slide-size/) (incluyendo predefinidos como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

**¿En qué unidades se miden los tamaños y coordenadas?**

En puntos: 1 pulgada equivale a 72 unidades.

**¿Cómo manejo presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?**

Utilice [estrategias de gestión de BLOB](/slides/es/net/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos de trabajo basados en archivos en lugar de solo transmisiones en memoria.

**¿Puedo crear/guardar presentaciones en paralelo?**

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/net/multithreading/). Ejecute instancias separadas e aisladas por hilo o proceso.

**¿Cómo elimino la marca de agua de prueba y las limitaciones?**

[Aplique una licencia](/slides/es/net/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si intervienen varios hilos.

**¿Puedo firmar digitalmente el PPTX que creo?**

Sí. Las [firmas digitales](/slides/es/net/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

**¿Se admiten macros (VBA) en las presentaciones creadas?**

Sí. Puede [crear/editar proyectos VBA](/slides/es/net/presentation-via-vba/) y guardar archivos con macros como PPTM/PPSM.