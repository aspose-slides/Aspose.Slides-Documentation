---
title: Administrar objetos OLE en presentaciones en .NET
linktitle: Administrar OLE
type: docs
weight: 40
url: /es/net/manage-ole/
keywords:
- Objeto OLE
- Vinculación y incrustación de objetos
- Agregar OLE
- Incrustar OLE
- Agregar objeto
- Incrustar objeto
- Agregar archivo
- Incrustar archivo
- Objeto vinculado
- Archivo vinculado
- Cambiar OLE
- Icono OLE
- Título OLE
- Extraer OLE
- Extraer objeto
- Extraer archivo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Optimice la gestión de objetos OLE en PowerPoint y archivos OpenDocument con Aspose.Slides para .NET. Incruste, actualice y exporte contenido OLE sin problemas."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que datos y objetos creados en una aplicación se coloquen en otra aplicación mediante enlaces o incrustaciones. 

{{% /alert %}} 

Considere un gráfico creado en MS Excel. El gráfico se inserta luego dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE. 

- Un objeto OLE puede aparecer como un ícono. En este caso, al hacer doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita que seleccione una aplicación para abrir o editar el objeto. 
- Un objeto OLE puede mostrar su contenido real, como el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) le permite insertar objetos OLE en diapositivas como marcos de objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Agregar marcos de objetos OLE a diapositivas**

Suponiendo que ya haya creado un gráfico en Microsoft Excel y quiera incrustarlo en una diapositiva como un marco de objeto OLE usando Aspose.Slides for .NET, puede hacerlo de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga una referencia a la diapositiva mediante su índice.
3. Lea el archivo de Excel como una matriz de bytes.
4. Agregue el [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) a la diapositiva que contiene la matriz de bytes y otra información sobre el objeto OLE.
5. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo siguiente, agregamos un gráfico de un archivo de Excel a una diapositiva como un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) usando Aspose.Slides for .NET.  
**Nota** que el constructor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) toma una extensión de objeto incrustable como segundo parámetro. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y elegir la aplicación adecuada para abrir este objeto OLE.
```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Preparar los datos para el objeto OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Agregar el marco del objeto OLE a la diapositiva.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **Agregar marcos de objetos OLE vinculados**

Aspose.Slides for .NET le permite agregar un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) sin incrustar datos, sino solo con un enlace al archivo.

Este código C# le muestra cómo agregar un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) con un archivo de Excel vinculado a una diapositiva:
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Agregar un marco de objeto OLE con un archivo Excel vinculado.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Acceder a marcos de objetos OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede encontrarlo o acceder a él fácilmente de esta manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga la referencia de la diapositiva usando su índice.
3. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene solo una forma en la primera diapositiva. Luego *convertir* ese objeto como un [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Este era el marco de objeto OLE deseado al que se accedía.
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él.

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y a sus datos de archivo.
```csharp 
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


### **Acceder a propiedades del marco de objeto OLE vinculado**

Aspose.Slides le permite acceder a las propiedades del marco de objeto OLE vinculado.

Este código C# le muestra cómo verificar si un objeto OLE está vinculado y luego obtener la ruta al archivo vinculado:
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Obtener la primera forma como un marco de objeto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Verificar si el objeto OLE está vinculado.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Imprimir la ruta completa al archivo vinculado.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Imprimir la ruta relativa al archivo vinculado si está presente.
        // Solo las presentaciones PPT pueden contener la ruta relativa.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **Cambiar datos del objeto OLE**

{{% alert color="primary" %}} 

En esta sección, el ejemplo de código a continuación usa [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Cargue una presentación con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga la referencia de la diapositiva mediante su índice. 
3. Acceda a la forma [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   En nuestro ejemplo, utilizamos el PPTX creado previamente que tiene una forma en la primera diapositiva. Luego *convertir* ese objeto como un [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). Este era el marco de objeto OLE deseado al que se accedía.
4. Una vez accedido al marco del objeto OLE, puede realizar cualquier operación sobre él.
5. Cree un objeto `Workbook` y acceda a los datos OLE.
6. Acceda a la `Worksheet` deseada y modifique los datos.
7. Guarde el `Workbook` actualizado en un flujo.
8. Cambie los datos del objeto OLE desde el flujo.

En el ejemplo siguiente, se accede a un marco de objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y se modifican sus datos de archivo para actualizar los datos del gráfico.
```csharp 
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
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modificar los datos del libro de trabajo.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
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

Además de los gráficos de Excel, Aspose.Slides for .NET le permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos. Cuando un usuario hace doble clic en el objeto insertado, se abre automáticamente en el programa correspondiente, o se le solicita al usuario que seleccione un programa adecuado para abrirlo.

Este código C# le muestra cómo incrustar HTML y ZIP en una diapositiva:
```c#
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

Al trabajar con presentaciones, puede necesitar reemplazar objetos OLE antiguos por nuevos o reemplazar un objeto OLE no compatible por uno compatible. Aspose.Slides for .NET le permite establecer el tipo de archivo para un objeto incrustado, lo que le permite actualizar los datos del marco OLE o su extensión.

Este código C# le muestra cómo establecer el tipo de archivo para un objeto OLE incrustado a `zip`:
```c#
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


## **Definir imágenes de ícono y títulos para objetos incrustados**

Después de incrustar un objeto OLE, se agrega automáticamente una vista previa que consiste en una imagen de ícono. Esta vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE. Si desea usar una imagen y texto específicos como elementos en la vista previa, puede establecer la imagen del ícono y el título usando Aspose.Slides for .NET.

Este código C# le muestra cómo establecer la imagen del ícono y el título para un objeto incrustado: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Agregar una imagen a los recursos de la presentación.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Establecer un título y la imagen para la vista previa del OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Impedir que un marco de objeto OLE sea redimensionado y reubicado**

Después de agregar un objeto OLE vinculado a una diapositiva de presentación, al abrir la presentación en PowerPoint, puede ver un mensaje que le pide actualizar los enlaces. Al hacer clic en el botón "Update Links" (Actualizar enlaces) puede cambiar el tamaño y la posición del marco del objeto OLE porque PowerPoint actualiza los datos del objeto OLE vinculado y refresca la vista previa del objeto. Para evitar que PowerPoint solicite actualizar los datos del objeto, establezca la propiedad `UpdateAutomatic` de la interfaz [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) en `false`:
```cs
oleFrame.UpdateAutomatic = false;
```


## **Extraer archivos incrustados**

Aspose.Slides for .NET le permite extraer los archivos incrustados en diapositivas como objetos OLE de la siguiente manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga los objetos OLE que desea extraer.
2. Recorra todas las formas en la presentación y acceda a las formas [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Acceda a los datos de los archivos incrustados de los marcos de objeto OLE y escríbalos en disco.

Este código C# le muestra cómo extraer archivos incrustados en una diapositiva como objetos OLE:
```c#
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


## **Preguntas frecuentes**

**¿Se renderizará el contenido OLE al exportar diapositivas a PDF/imagenes?**

Lo que es visible en la diapositiva se renderiza: el ícono/imagen de sustitución (vista previa). El contenido OLE "en vivo" no se ejecuta durante la renderización. Si es necesario, establezca su propia imagen de vista previa para garantizar la apariencia esperada en el PDF exportado.

**¿Cómo puedo bloquear un objeto OLE en una diapositiva para que los usuarios no puedan moverlo/editarlo en PowerPoint?**

Bloquee la forma: Aspose.Slides ofrece [bloqueos a nivel de forma](/slides/es/net/applying-protection-to-presentation/). No es encriptación, pero impide eficazmente ediciones y movimientos accidentales.

**¿Por qué un objeto Excel vinculado "salta" o cambia de tamaño al abrir la presentación?**

PowerPoint puede actualizar la vista previa del OLE vinculado. Para una apariencia estable, siga las prácticas de la [Solución de trabajo para el redimensionado de hojas de cálculo](/slides/es/net/working-solution-for-worksheet-resizing/): ajuste el marco al rango, o escale el rango a un marco fijo y establezca una imagen de sustitución adecuada.

**¿Se conservarán las rutas relativas para objetos OLE vinculados en el formato PPTX?**

En PPTX, la información de "ruta relativa" no está disponible—solo la ruta completa. Las rutas relativas se encuentran en el formato PPT más antiguo. Para portabilidad, prefiera rutas absolutas confiables/URIs accesibles o la incrustación.