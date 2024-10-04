---
title: Administrar OLE
type: docs
weight: 40
url: /net/manage-ole/
keywords: "Agregar OLE, Agregar objeto, Integrar objeto Object Linking & Embedding, Marco de objeto OLE, Integrar OLE, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET "
description: "Agregar objeto OLE a presentación de PowerPoint en C# o .NET"
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) es una tecnología de Microsoft que permite que los datos y objetos creados en una aplicación se coloquen en otra aplicación a través de vinculaciones o incrustaciones.

{{% /alert %}}

Considere un gráfico creado en MS Excel. El gráfico se coloca dentro de una diapositiva de PowerPoint. Ese gráfico de Excel se considera un objeto OLE.

- Un objeto OLE puede aparecer como un ícono. En este caso, cuando hace doble clic en el ícono, el gráfico se abre en su aplicación asociada (Excel), o se le solicita que seleccione una aplicación para abrir o editar el objeto.
- Un objeto OLE puede mostrar contenido real; por ejemplo, el contenido de un gráfico. En este caso, el gráfico se activa en PowerPoint, se carga la interfaz del gráfico y puede modificar los datos del gráfico dentro de la aplicación de PowerPoint.

[Aspose.Slides para .NET](https://products.aspose.com/slides/net/) le permite insertar Objetos OLE en diapositivas como Marcos de Objetos OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **Agregar Marcos de Objetos OLE a las Diapositivas**
Suponiendo que ya ha creado un gráfico en Microsoft Excel y desea incrustar ese gráfico en una diapositiva como un Marco de Objeto OLE usando Aspose.Slides para .NET, puede hacerlo de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga una referencia de la diapositiva a través de su índice.
3. Abra el archivo de Excel que contiene el objeto de gráfico de Excel y guárdelo en `MemoryStream`.
4. Agregue el [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) a la diapositiva, conteniendo el array de bytes y otra información sobre el objeto OLE.
5. Escriba la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, agregamos un gráfico de un archivo de Excel a una diapositiva como un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) usando Aspose.Slides para .NET.  
**Nota** que el constructor [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo) toma una extensión de objeto incrustable como segundo parámetro. Esta extensión permite a PowerPoint interpretar correctamente el tipo de archivo y seleccionar la aplicación adecuada para abrir este objeto OLE.

``` csharp 
// Instancia la clase Presentation que representa el archivo PPTX
using (Presentation pres = new Presentation())
{
    // Accede a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Carga un archivo de excel al flujo
    MemoryStream mstream = new MemoryStream();
    using (FileStream fs = new FileStream("book1.xlsx", FileMode.Open, FileAccess.Read))
    {
        byte[] buf = new byte[4096];

        while (true)
        {
            int bytesRead = fs.Read(buf, 0, buf.Length);
            if (bytesRead <= 0)
                break;
            mstream.Write(buf, 0, bytesRead);
        }
    }

    // Crea un objeto de datos para incrustar
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");

    // Agrega una forma de Marco de Objeto Ole
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,
        pres.SlideSize.Size.Height, dataInfo);

    //Escribe el archivo PPTX en disco
    pres.Save("OleEmbed_out.pptx", SaveFormat.Pptx);
}
```
### Agregar Marcos de Objetos OLE vinculados

Aspose.Slides para .NET le permite agregar un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) sin incrustar datos, sino solo con un enlace al archivo.

Este código C# le muestra cómo agregar un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) con un archivo de Excel vinculado a una diapositiva:

``` csharp 
using (Presentation pres = new Presentation())
{
	// Accede a la primera diapositiva
	ISlide slide = pres.Slides[0];

	// Agrega un Marco de Objeto Ole con un archivo de Excel vinculado
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book1.xlsx");

	// Escribe el archivo PPTX en disco
	pres.Save("OleLinked_out.pptx", SaveFormat.Pptx);
}
```

## **Accediendo a Marcos de Objetos OLE**
Si un objeto OLE ya está incrustado en una diapositiva, puede encontrar o acceder a ese objeto fácilmente de esta manera:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga la referencia de la diapositiva usando su índice.
3. Acceda a la forma [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   En nuestro ejemplo, usamos el PPTX previamente creado que tiene solo una forma en la primera diapositiva. Luego *convertimos* ese objeto como un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). Este era el Marco de Objeto OLE deseado para ser accedido.
4. Una vez que se accede al Marco de Objeto OLE, puede realizar cualquier operación sobre él.
En el ejemplo a continuación, un Marco de Objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) es accedido—y luego se escriben sus datos de archivo en un archivo de Excel:
``` csharp 
// Carga el PPTX a un objeto de presentación
using (Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx"))
{
    // Accede a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Convierte la forma a OleObjectFrame
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;

    // Lee el objeto OLE y lo escribe en disco
    if (oleObjectFrame != null)
    {
        // Obtiene los datos de archivo incrustados
        byte[] data = oleObjectFrame.EmbeddedData.EmbeddedFileData;

        // Obtiene la extensión del archivo incrustado
        string fileExtention = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;

        // Crea una ruta para guardar el archivo extraído
        string extractedPath = "excelFromOLE_out" + fileExtention;

        // Guarda los datos extraídos
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
        {
            fstr.Write(data, 0, data.Length);
        }
    }
}
```

### Accediendo a las Propiedades de Marcos de Objetos OLE Vinculados

Aspose.Slides le permite acceder a las propiedades del Marco de Objeto OLE vinculado.

Este código C# le muestra cómo verificar si un objeto OLE está vinculado y luego obtener la ruta al archivo vinculado:
```csharp
using (Presentation pres = new Presentation("OleLinked.ppt"))
{
	// Accede a la primera diapositiva
	ISlide slide = pres.Slides[0];

	// Obtiene la primera forma como Marco de Objeto Ole
	OleObjectFrame oleObjectFrame = slide.Shapes[0] as OleObjectFrame;

	// Verifica si el objeto Ole está vinculado.
	if (oleObjectFrame != null && oleObjectFrame.IsObjectLink)
	{
		// Imprime la ruta completa a un archivo vinculado
		Console.WriteLine("El Marco de Objeto Ole está vinculado a: " + oleObjectFrame.LinkPathLong);

		// Imprime la ruta relativa a un archivo vinculado si está presente.
		// Solo las presentaciones de PPT pueden contener la ruta relativa.
		string relativePath = oleObjectFrame.LinkPathRelative;
		if (!string.IsNullOrEmpty(relativePath))
		{
			Console.WriteLine("Ruta relativa del Marco de Objeto Ole: " + oleObjectFrame.LinkPathRelative);
		}
	}
}
```
## **Cambiar los Datos del Objeto OLE**

Si un objeto OLE ya está incrustado en una diapositiva, puede acceder fácilmente a ese objeto y modificar sus datos de esta manera:

1. Abra la presentación deseada con el objeto OLE incrustado creando una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenga la referencia de la diapositiva a través de su índice.
3. Acceda a la forma [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   En nuestro ejemplo, usamos el PPTX previamente creado que tiene una forma en la primera diapositiva. Luego *convertimos* ese objeto como un [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). Este era el Marco de Objeto OLE deseado para ser accedido.
4. Una vez que se accede al Marco de Objeto OLE, puede realizar cualquier operación sobre él.
5. Cree el objeto Workbook y acceda a los datos OLE.
6. Acceda a la hoja de trabajo deseada y enmiende los datos.
7. Guarde el Workbook actualizado en flujos.
8. Cambie los datos del objeto OLE de datos de flujo.
En el ejemplo a continuación, se accede a un Marco de Objeto OLE (un objeto de gráfico de Excel incrustado en una diapositiva) y luego se modifican sus datos de archivo para cambiar los datos del gráfico:
``` csharp 
using (Presentation pres = new Presentation("ChangeOLEObjectData.pptx"))
{
    ISlide slide = pres.Slides[0];

    OleObjectFrame ole = null;

    // Recorre todas las formas en busca del marco Ole
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is OleObjectFrame)
        {
            ole = (OleObjectFrame)shape;
        }
    }

    if (ole != null)
    {
        using (MemoryStream msln = new MemoryStream(ole.EmbeddedData.EmbeddedFileData))
        {
            // Lee los datos del objeto en el Workbook
            Workbook Wb = new Workbook(msln);

            using (MemoryStream msout = new MemoryStream())
            {
                // Modifica los datos del libro de trabajo
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                Wb.Save(msout, so1);

                // Cambia los datos del objeto del marco Ole
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.ToArray(), ole.EmbeddedData.EmbeddedFileExtension);
                ole.SetEmbeddedData(newData);
            }
        }
    }

    pres.Save("OleEdit_out.pptx", SaveFormat.Pptx);
}
```
## **Incrustar Otros Tipos de Archivos en Diapositivas**

Además de gráficos de Excel, Aspose.Slides para .NET le permite incrustar otros tipos de archivos en diapositivas. Por ejemplo, puede insertar archivos HTML, PDF y ZIP como objetos en una diapositiva. Cuando un usuario hace doble clic en el objeto insertado, el objeto se lanza automáticamente en el programa relevante, o se le dirige al usuario para seleccionar un programa apropiado para abrir el objeto.

Este código C# le muestra cómo incrustar HTML y ZIP en una diapositiva:

```c#
using (Presentation pres = new Presentation())
{
  ISlide slide = pres.Slides[0];
  
  byte[] htmlBytes = File.ReadAllBytes("embedOle.html");
  IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
  IOleObjectFrame oleFrameHtml = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
  oleFrameHtml.IsObjectIcon = true;

  byte[] zipBytes = File.ReadAllBytes("embedOle.zip");
  IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
  IOleObjectFrame oleFrameZip = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, dataInfoZip);
  oleFrameZip.IsObjectIcon = true;

  pres.Save("embeddedOle.pptx", SaveFormat.Pptx);
}
```
## **Configuración de Tipos de Archivo para Objetos Incrustados**

Al trabajar en presentaciones, puede que necesite reemplazar objetos OLE antiguos por nuevos. O puede que necesite reemplazar un objeto OLE no compatible por uno compatible. 

Aspose.Slides para .NET le permite establecer el tipo de archivo para un objeto incrustado. De esta manera, puede cambiar los datos del marco OLE o su extensión.

Este código C# le muestra cómo establecer el tipo de archivo para un objeto OLE incrustado:

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    Console.WriteLine($"La extensión de datos incrustados actual es: {oleObjectFrame.EmbeddedData.EmbeddedFileExtension}");
   
    oleObjectFrame.SetEmbeddedData(new OleEmbeddedDataInfo(File.ReadAllBytes("embedOle.zip"), "zip"));
   
    pres.Save("embeddedChanged.pptx", SaveFormat.Pptx);
}
```
## **Configuración de Imágenes y Títulos de Icono para Objetos Incrustados**

Después de incrustar un objeto OLE, se agrega automáticamente una vista previa que consiste en una imagen de ícono y un título. La vista previa es lo que los usuarios ven antes de acceder o abrir el objeto OLE.

Si desea usar una imagen específica y texto como elementos en la vista previa, puede establecer la imagen del ícono y el título usando Aspose.Slides para .NET.

Este código C# le muestra cómo establecer la imagen del ícono y el título para un objeto incrustado:

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];

    IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    oleObjectFrame.SubstitutePictureTitle = "Mi título";
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleObjectFrame.IsObjectIcon = false;

    pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```
## **Extracción de Archivos Incrustados**

Aspose.Slides para .NET le permite extraer los archivos incrustados en diapositivas como objetos OLE de esta manera:
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga el objeto OLE que pretende extraer.
2. Recorra todas las formas en la presentación y acceda a la forma [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. Acceda a los datos del archivo incrustado desde el Marco de Objeto OLE y escríbalo en disco. 
Este código C# le muestra cómo extraer un archivo incrustado en una diapositiva como un objeto OLE:
```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];

    for (var index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;
        
        if (oleFrame != null)
        {
            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
            
            File.WriteAllBytes($"oleFrame{index}{extension}", data);
        }
    }
}
```