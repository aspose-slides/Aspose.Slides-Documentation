---
title: Combina presentaciones de forma eficiente en .NET
linktitle: Combinar presentaciones
type: docs
weight: 40
url: /es/net/merge-presentation/
keywords:
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- .NET
- C#
- Aspose.Slides
description: "Aprenda a combinar presentaciones de PowerPoint y OpenDocument en .NET clonando diapositivas, controlando maestros y diseños, redimensionando el contenido de las diapositivas, preservando secciones y gestionando archivos protegidos o de gran tamaño."
---
## **Visión general**

Aspose.Slides para .NET combina presentaciones clonando diapositivas de una [Presentación](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) a otra. La operación principal es [ISlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/), que puede conservar el formato de la diapositiva origen o adjuntar la diapositiva clonada a un maestro o diseño en la presentación de destino.

Este artículo cubre los flujos de trabajo de combinación más habituales:

- combinar todas las diapositivas conservando su formato original;
- combinar diapositivas seleccionadas;
- aplicar un maestro de la presentación de destino;
- aplicar un diseño específico de la presentación de destino;
- normalizar diferentes tamaños de diapositiva antes de combinar;
- añadir diapositivas clonadas a una sección;
- combinar varias presentaciones en un flujo de trabajo de extremo a extremo;
- manejar maestros, recursos, notas, comentarios, medios, fuentes, contraseñas, archivos grandes y consideraciones de multihilo.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

## **Combinar presentaciones completas y conservar el formato original**

La combinación más simple copia cada diapositiva de la presentación origen a la presentación de destino. Esta es la opción adecuada cuando las diapositivas importadas deben mantener su tema, maestro y relaciones de diseño originales.

La presentación resultante puede contener varios maestros cuando el origen y el destino utilizan diseños diferentes. Esto es esperado cuando el formato del origen se conserva intencionadamente.

## **Combinar diapositivas seleccionadas**

No es necesario clonar todas las diapositivas. El siguiente ejemplo importa solo los índices de diapositiva seleccionados de la presentación origen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Valide los índices de diapositiva antes de clonarlos cuando provengan de la entrada del usuario o de una configuración externa.

## **Combinar diapositivas usando un maestro de destino**

Utilice la sobrecarga [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/) cuando las diapositivas importadas deben seguir un maestro que ya pertenece a la presentación de destino.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides selecciona un diseño apropiado bajo el maestro especificado coincidiendo con el tipo o nombre del diseño origen. Si no existe un diseño adecuado y `allowCloneMissingLayout` es `true`, el diseño origen se clona para que la diapositiva pueda añadirse. Si es `false`, se lanza una [PptxEditException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxeditexception/).

Use `false` cuando desee que la combinación falle en lugar de introducir un diseño adicional en el maestro de destino.

## **Combinar diapositivas usando un diseño de destino específico**

Utilice la sobrecarga [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/) cuando sepa exactamente qué diseño de destino deben usar las diapositivas importadas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Aplicar un diseño de destino cambia la relación de diseño heredado; no rediseña el contenido de la diapositiva origen. Si los diseños origen y destino tienen estructuras de marcadores de posición diferentes, inspeccione el resultado para confirmar que el formato heredado y el comportamiento de los marcadores son apropiados.

## **Combinar presentaciones con diferentes tamaños de diapositiva**

Se pueden combinar presentaciones con diferentes dimensiones de diapositiva, pero clonar una diapositiva en una presentación con otro tamaño de diapositiva no rediseña automáticamente su contenido para el nuevo lienzo. Por lo tanto, las formas pueden aparecer desplazadas, escaladas inesperadamente o fuera del área visible de la diapositiva.

Un enfoque práctico es cambiar el tamaño de la presentación origen antes de clonar. El método [SlideSize.SetSize](https://reference.aspose.com/slides/es/net/aspose.slides/slidesize/setsize/) puede escalar el contenido existente mientras cambia las dimensiones de la diapositiva. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/es/net/aspose.slides/slidesizescaletype/) escala el contenido para que se ajuste al tamaño solicitado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Cambiar el tamaño modifica el objeto de la presentación origen en memoria. Si necesita que la presentación origen original permanezca sin cambios para otras operaciones, abra una instancia separada para la combinación.

## **Combinar diapositivas en una sección de la presentación**

El bucle básico de clonación de diapositivas no recrea la jerarquía de secciones de la presentación origen. Si las secciones son importantes en el resultado, cree o seleccione secciones en la presentación de destino y clone las diapositivas en ellas explícitamente con [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Las diapositivas clonadas se añaden al final de la sección de destino especificada. Para conservar varias secciones origen, recree esas secciones en el destino y asocie cada diapositiva origen con la sección de destino correspondiente.

## **Combinar múltiples presentaciones de forma segura**

El siguiente ejemplo de extremo a extremo utiliza la primera presentación como destino, normaliza el tamaño de diapositiva de cada origen adicional, mantiene cada origen abierto solo mientras se copia y guarda el archivo final una sola vez.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Esto es una base útil para conservar el formato origen de las diapositivas importadas. Si su salida debe usar un único tema de destino, reemplace la llamada simple `AddClone(slide)` con la sobrecarga de maestro de destino o diseño de destino apropiada mostrada anteriormente.

## **Consideraciones prácticas**

### **Maestros, diseños y fidelidad del formato**

La clonación predeterminada de diapositivas puede incorporar automáticamente un maestro origen necesario en la presentación de destino. Aspose.Slides mantiene un registro interno de los maestros clonados automáticamente para evitar clonar el mismo maestro repetidamente. Los maestros clonados manualmente no se registran en ese registro, por lo que evite preclonar maestros a menos que necesite un control explícito sobre la estructura del maestro.

No asuma que dos maestros o diseños con el mismo nombre son visualmente equivalentes. Si una plantilla corporativa debe controlar la apariencia final, elija un maestro o diseño de destino de forma explícita y verifique el resultado después de combinar.

### **Notas y comentarios**

Las notas del presentador y los comentarios de la diapositiva están asociados al contenido de la diapositiva y se copian cuando se clona una diapositiva. Aspose.Slides también expone API dedicadas para [notas de presentación](https://docs.aspose.com/slides/es/net/presentation-notes/) y [comentarios de presentación](https://docs.aspose.com/slides/es/net/presentation-comments/).

Si el formato de la página de notas es importante, verifique la presentación combinada porque los maestros de notas son objetos a nivel de presentación y pueden diferir entre los archivos origen. Para flujos de trabajo de revisión, también verifique los autores de los comentarios y los comentarios en hilo después de combinar archivos de diferentes autores o plantillas.

### **Imágenes, audio, vídeo, objetos OLE y enlaces externos**

Las diapositivas pueden hacer referencia a recursos a nivel de presentación como imágenes, audio incrustado, vídeo incrustado y datos OLE. Clone la propia diapositiva en lugar de copiar solo sus formas visibles para que Aspose.Slides pueda mantener las relaciones de la diapositiva con sus recursos.

Los recursos incrustados y los enlazados deben tratarse de forma diferente. Un audio, vídeo, objeto OLE o hipervínculo enlazado permanece dependiente de su destino externo; clonar una diapositiva no convierte un enlace externo en contenido incrustado. Pruebe las rutas y URL de los recursos enlazados en el entorno donde se abrirá la presentación combinada.

Aspose.Slides rastrea explícitamente los maestros clonados automáticamente, pero esto no debe considerarse una garantía general de que los recursos binarios idénticos de presentaciones origen no relacionadas se deduplicarán siempre. Si el tamaño del archivo de salida es importante, inspeccione el paquete combinado y mida el resultado en lugar de depender de la deduplicación implícita.

### **Fuentes incrustadas y disponibilidad de fuentes**

Las fuentes se gestionan a nivel de presentación. Si la tipografía debe permanecer constante en diferentes equipos, no asuma que clonar diapositivas por sí solo garantiza que todas las fuentes necesarias estén disponibles en el entorno de destino. Puede inspeccionar las fuentes incrustadas con [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/getembeddedfonts/) y gestionar la incrustación explícitamente como se describe en [Incrustar fuentes en presentaciones](https://docs.aspose.com/slides/es/net/embedded-font/).

También verifique que tenga permiso para incrustar las fuentes utilizadas por los archivos origen. Las licencias de fuentes pueden restringir la incrustación.

### **Presentaciones protegidas con contraseña**

Un origen protegido con contraseña debe abrirse correctamente antes de que sus diapositivas puedan clonarse. Proporcione la contraseña a través de [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Abrir un origen cifrado no aplica automáticamente la misma protección a la presentación de destino. Configure la protección de salida por separado cuando sea necesario.

### **Presentaciones grandes y uso de memoria**

Las presentaciones grandes que contienen imágenes de alta resolución, audio, vídeo u otros objetos binarios grandes pueden consumir una cantidad significativa de memoria. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/blobmanagementoptions/) ofrece controles para la gestión de BLOB y el uso de archivos temporales. Consulte [Gestionar BLOBs de presentación](https://docs.aspose.com/slides/es/net/manage-blob/) para estrategias con archivos grandes.

Para archivos grandes, prefiera cargar desde rutas de archivo cuando sea posible, libere cada presentación origen tan pronto como haya sido combinada y evite guardar repetidamente resultados intermedios a menos que el flujo de trabajo requiera puntos de control.

### **Seguridad en subprocesos**

No cargue, modifique, guarde o clone la misma [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) simultáneamente desde varios subprocesos. Mantenga cada instancia de presentación confinada a una única operación de combinación. Si paraleliza trabajos independientes, utilice instancias de presentación independientes y siga la [guía de multihilo de Aspose.Slides](https://docs.aspose.com/slides/es/net/multithreading/).

## **Preguntas frecuentes**

**¿Cómo conservo el diseño original de cada presentación origen?**

Utilice [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/) sin proporcionar un maestro ni un diseño de destino. Aspose.Slides puede clonar automáticamente el maestro origen cuando la diapositiva importada lo requiera.

**¿Cómo hago que las diapositivas importadas usen el tema de destino?**

Utilice la sobrecarga que acepta un maestro de destino. Pase un maestro de la presentación de destino, no del origen. Aspose.Slides intentará asignar cada diapositiva origen a un diseño apropiado bajo ese maestro.

**¿Cuándo debo usar un diseño de destino específico en lugar de un maestro de destino?**

Utilice un diseño específico cuando cada diapositiva importada deba usar un diseño conocido. Use un maestro cuando desee que Aspose.Slides seleccione entre los diseños de ese maestro basándose en el tipo o nombre del diseño origen.

**¿Se pueden combinar presentaciones con diferentes tamaños de diapositiva?**

Sí, pero el contenido de la diapositiva no se rediseña automáticamente para las dimensiones de destino. Cambie primero el tamaño de la presentación origen cuando necesite una colocación predecible, por ejemplo con [SlideSize.SetSize](https://reference.aspose.com/slides/es/net/aspose.slides/slidesize/setsize/) y [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/es/net/aspose.slides/slidesizescaletype/).

**¿Puedo combinar presentaciones PPT, PPTX y ODP en un solo archivo?**

Sí. Cargue cada presentación origen, clone las diapositivas necesarias en un destino y guarde el destino en un formato de salida compatible. Como los formatos de presentación no admiten exactamente el mismo conjunto de funciones, verifique el contenido complejo después de combinaciones entre formatos. Consulte [Supported File Formats](https://docs.aspose.com/slides/es/net/supported-file-formats/).

**¿Se conservan automáticamente las secciones del origen?**

No, con un bucle básico que solo clona diapositivas. Recree las secciones necesarias en el destino y use la sobrecarga de sección de [AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/addclone/) cuando la estructura de secciones deba conservarse.

**¿Se conservan las notas del presentador y los comentarios?**

Se copian junto con la diapositiva clonada. Para flujos de trabajo que dependan del estilo del maestro de notas, de los autores de comentarios o de datos de revisión en hilo, verifique el resultado combinado porque esos escenarios implican estructuras a nivel de presentación así como contenido a nivel de diapositiva.

**¿Qué ocurre con el audio, vídeo, objetos OLE y hipervínculos?**

El contenido incrustado se transporta como parte de las relaciones de recursos de la diapositiva clonada. Los enlaces externos permanecen externos, por lo que sus archivos o URL de destino deben seguir estando disponibles después de la combinación.

**¿Se garantiza que las fuentes incrustadas de cada origen estén disponibles en la presentación combinada?**

No confíe solo en la clonación de diapositivas para la distribución de fuentes. Inspeccione las fuentes incrustadas del destino y gestione explícitamente la incrustación de fuentes o la disponibilidad de fuentes externas cuando la tipografía sea importante.

**¿Cómo combino un archivo protegido con contraseña?**

Ábralo con la [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/) correcta, luego clone sus diapositivas normalmente. La protección de salida se configura por separado.

**¿Cómo debo gestionar presentaciones muy grandes?**

Utilice la gestión de BLOB cuando los objetos binarios grandes dominen el uso de memoria, prefiera cargar desde rutas de archivo para archivos muy grandes, libere las presentaciones origen rápidamente y guarde el resultado final solo cuando sea necesario.

**¿Puedo combinar diapositivas desde varios subprocesos?**

No use una única instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) simultáneamente desde varios subprocesos. Mantenga cada operación de combinación aislada en sus propias instancias de presentación.