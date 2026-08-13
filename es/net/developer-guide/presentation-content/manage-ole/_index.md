---
title: Administrar objetos OLE en presentaciones en .NET
linktitle: Administrar OLE
type: docs
weight: 40
url: /es/net/manage-ole/
keywords:
- objeto OLE
- Enlace y inserción de objetos
- añadir OLE
- incrustar OLE
- añadir objeto
- incrustar objeto
- añadir archivo
- incrustar archivo
- objeto vinculado
- archivo vinculado
- cambiar OLE
- icono OLE
- título OLE
- extraer OLE
- extraer objeto
- extraer archivo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: Optimice la gestión de objetos OLE en archivos PowerPoint y OpenDocument con Aspose.Slides para .NET. Incruste, actualice y exporte contenido OLE sin problemas.
---
## **Introducción**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación se coloquen en otra aplicación mediante vínculo o incrustación. 

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se coloca luego dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un ícono. En este caso, al hacer doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita seleccionar una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, la interfaz del gráfico se carga y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/es/net/) permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe)).

## **Agregar marcos de objetos OLE a diapositivas**

Suponiendo que ya ha creado un gráfico en Microsoft Excel y quiere incrustarlo en una diapositiva como un marco de objeto OLE usando Aspose.Slides for .NET, puede hacerlo de esta manera:

1. Crear una instancia de la [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) clase.  
2. Obtener una referencia a la diapositiva mediante su índice.  
3. Leer el archivo Excel como una matriz de bytes.  
4. Añadir el [OleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe) a la diapositiva que contiene la matriz de bytes y otra información sobre el objeto OLE.  
5. Guardar la presentación modificada como un archivo PPTX.  

En el ejemplo a continuación, añadimos un gráfico de un archivo Excel a una diapositiva como [OleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe) usando Aspose.Slides for .NET.  
**Nota** que el constructor de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/es/net/aspose.slides.dom.ole/oleembeddeddatainfo/) recibe una extensión de objeto incrustable como segundo parámetro. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Preparar los datos para el objeto OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Añadir el marco del objeto OLE a la diapositiva.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Agregar marcos de objetos OLE vinculados**

Aspose.Slides for .NET permite agregar un [OleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe) sin incrustar datos, sino sólo con un vínculo al archivo.

Este código C# le muestra cómo agregar un [OleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe) con un archivo Excel vinculado a una diapositiva:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Añadir un marco de objeto OLE con un archivo Excel vinculado.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Acceder a los marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de esta manera:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) clase.  
2. Obtener la referencia de la diapositiva usando su índice.  
3. Acceder a la forma [OleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe).  
   En nuestro ejemplo, usamos el PPTX creado previamente que tiene sólo una forma en la primera diapositiva. Luego *convertimos* ese objeto a [IOleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ioleobjectframe). Este era el marco de objeto OLE deseado para acceder.  
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él.  

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto de gráfico Excel incrustado en una diapositiva) y a sus datos de archivo.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtener la primera forma como un marco de objeto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Obtener los datos del archivo incrustado.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Obtener la extensión del archivo incrustado.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Acceder a las propiedades del marco de objeto OLE vinculado**

Aspose.Slides permite acceder a las propiedades del marco de objeto OLE vinculado.

Este código C# le muestra cómo comprobar si un objeto OLE está vinculado y, a continuación, obtener la ruta al archivo vinculado:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Obtener la primera forma como un marco de objeto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Comprobar si el objeto OLE está vinculado.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Imprimir la ruta completa del archivo vinculado.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Imprimir la ruta relativa del archivo vinculado si está presente.
        // Sólo las presentaciones PPT pueden contener la ruta relativa.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Cambiar los datos del objeto OLE**

{{% alert color="info" %}} 

En esta sección, el ejemplo de código a continuación usa [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder a ese objeto y modificar sus datos de esta manera:

1. Cargar una presentación con el objeto OLE incrustado creando una instancia de la [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) clase.  
2. Obtener la referencia de la diapositiva mediante su índice.  
3. Acceder a la forma [OLEObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe).  
   En nuestro ejemplo, usamos el PPTX creado previamente que tiene una forma en la primera diapositiva. Luego *convertimos* ese objeto a [IOleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ioleobjectframe). Este era el marco de objeto OLE deseado para acceder.  
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él.  
5. Crear un objeto `Workbook` y acceder a los datos OLE.  
6. Acceder a la `Worksheet` deseada y modificar los datos.  
7. Guardar el `Workbook` actualizado en un flujo.  
8. Cambiar los datos del objeto OLE desde el flujo.  

En el ejemplo a continuación, se accede a un marco de objeto OLE (un objeto de gráfico Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtener la primera forma como un marco de objeto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Leer los datos del objeto OLE como un objeto Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modificar los datos del libro de trabajo.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Cambiar los datos del objeto del marco OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Incrustar otros tipos de archivo en diapositivas**

Además de los gráficos Excel, Aspose.Slides for .NET permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando un usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita al usuario que seleccione un programa adecuado para abrirlo.

Este código C# le muestra cómo incrustar HTML y ZIP en una diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Definir tipos de archivo para objetos incrustados**

Al trabajar con presentaciones, puede necesitar reemplazar objetos OLE antiguos por nuevos o sustituir un objeto OLE no compatible por uno compatible. Aspose.Slides for .NET permite definir el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión.

Este código C# le muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Cambiar el tipo de archivo a ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Establecer imágenes de ícono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se añade automáticamente una vista previa compuesta por una imagen de ícono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y un texto específicos como elementos en la vista previa, puede establecer la imagen de ícono y el título mediante Aspose.Slides for .NET.

Este código C# le muestra cómo establecer la imagen de ícono y el título para un objeto incrustado: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Añadir una imagen a los recursos de la presentación.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Establecer un título y la imagen para la vista previa OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Evitar que un marco de objeto OLE sea redimensionado y reposicionado**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, al abrir la presentación en PowerPoint, puede aparecer un mensaje solicitando actualizar los vínculos. Al hacer clic en el botón "Update Links" (Actualizar vínculos) el tamaño y la posición del marco del objeto OLE pueden cambiar porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite actualizar los datos del objeto, establezca la propiedad `UpdateAutomatic` de la interfaz [IOleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ioleobjectframe/) a `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // Mantener el tamaño y la posición del marco del objeto OLE cuando PowerPoint actualiza el vínculo.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Extraer archivos incrustados**

Aspose.Slides for .NET permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente manera:
1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) que contenga los objetos OLE que desea extraer.  
2. Recorrer todas las formas de la presentación y acceder a las formas [OLEObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/oleobjectframe).  
3. Acceder a los datos de los archivos incrustados de los marcos de objetos OLE y escribirlos en disco.  

Este código C# le muestra cómo extraer los archivos incrustados en una diapositiva como objetos OLE:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

### ¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imagenes?

Lo que es visible en la diapositiva se renderiza: el ícono/imagen de sustitución (vista previa). El contenido OLE "en vivo" no se ejecuta durante el renderizado. Si es necesario, establezca su propia imagen de vista previa para garantizar la apariencia esperada en el PDF exportado.

### ¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?

Bloquee la forma: Aspose.Slides proporciona [bloqueos a nivel de forma](/slides/es/net/applying-protection-to-presentation/). No es encriptación, pero evita eficazmente ediciones y movimientos accidentales.

### ¿Por qué un objeto Excel vinculado "salta" o cambia de tamaño al abrir la presentación?

PowerPoint puede refrescar la vista previa del OLE vinculado. Para una apariencia estable, siga las prácticas de la [Solución de trabajo para el redimensionado de hojas](/slides/es/net/working-solution-for-worksheet-resizing/): ajuste el marco al rango o escale el rango a un marco fijo y establezca una imagen de sustitución adecuada.

### ¿Se conservarán las rutas relativas para objetos OLE vinculados en el formato PPTX?

En PPTX, la información de "ruta relativa" no está disponible, sólo la ruta completa. Las rutas relativas aparecen en el formato PPT anterior. Para portabilidad, prefiera rutas absolutas fiables/URIs accesibles o la incrustación.