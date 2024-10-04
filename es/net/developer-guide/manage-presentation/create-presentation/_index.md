---
title: Crear Presentación en .NET
linktitle: Crear Presentación
type: docs
weight: 10
url: /net/create-presentation/
keywords: "Crear PowerPoint, PPTX, PPT, Crear Presentación, Inicializar Presentación, C#, .NET"
description: "Creación de Presentaciones de PowerPoint Programáticamente en C# e.g. PPT, PPTX, ODP etc."
---

## Crear Presentación de PowerPoint
Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

1. Cree una instancia de la clase Presentation.
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Agregue una AutoShape de tipo Línea utilizando el método AddAutoShape expuesto por el objeto Shapes.
1. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una línea a la primera diapositiva de la presentación.

```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation())
{
    // Obtener la primera diapositiva
    ISlide slide = presentation.Slides[0];

    // Agregar una autoshape de tipo línea
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NuevaPresentacion_salida.pptx", SaveFormat.Pptx);
}
```

## Crear y Guardar Presentación

<a name="csharp-create-save-presentation"><strong>Pasos: Crear y Guardar Presentación en C#</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Guarde _Presentación_ en cualquier formato compatible con [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("PresentacionSalida.pptx", SaveFormat.Pptx);
```

## Abrir y Guardar Presentación

<a name="csharp-open-save-presentation"><strong>Pasos: Abrir y Guardar Presentación en C#</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) con cualquier formato i.e. PPT, PPTX, ODP etc.
2. Guarde _Presentación_ en cualquier formato compatible con [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Cargar cualquier archivo compatible en Presentation e.g. ppt, pptx, odp etc.
Presentation presentation = new Presentation("Ejemplo.odp");

presentation.Save("PresentacionSalida.pptx", SaveFormat.Pptx);
```