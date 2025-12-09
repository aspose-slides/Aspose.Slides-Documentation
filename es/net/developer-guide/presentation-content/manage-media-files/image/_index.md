---
title: Optimizar la gestión de imágenes en presentaciones en .NET
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/net/image/
keywords:
- añadir imagen
- añadir foto
- añadir mapa de bits
- reemplazar imagen
- reemplazar foto
- desde la web
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- añadir EMF
- añadir WMF
- añadir TIFF
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Optimiza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para .NET, mejorando el rendimiento y automatizando tu flujo de trabajo."
---

## **Imágenes en diapositivas en presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar fotos desde un archivo, internet u otras ubicaciones en las diapositivas. De forma similar, Aspose.Slides te permite agregar imágenes a las diapositivas de tus presentaciones mediante diferentes procedimientos.

{{% alert title="Consejo" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas agregar una imagen como un objeto de marco—especialmente si planeas usar opciones de formato estándar para cambiar su tamaño, agregar efectos, etc.—consulta [Marco de imagen](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes manipular operaciones de entrada/salida involucrando imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, BMP, GIF y otros. 

## **Agregar imágenes almacenadas localmente a diapositivas**

Puedes agregar una o varias imágenes desde tu computadora a una diapositiva de una presentación. Este fragmento de código en C# muestra cómo agregar una imagen a una diapositiva:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Agregar imágenes desde la web a diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes añadirla directamente desde la web. 

Este fragmento de código muestra cómo agregar una imagen desde la web a una diapositiva en C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Agregar imágenes a maestros de diapositivas**

Un maestro de diapositiva es la diapositiva superior que almacena y controla la información (tema, diseño, etc.) de todas las diapositivas que dependen de él. Por lo tanto, cuando agregas una imagen a un maestro de diapositiva, esa imagen aparece en cada diapositiva bajo ese maestro. 

Este fragmento de código en C# muestra cómo agregar una imagen a un maestro de diapositiva:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Agregar imágenes como fondo de diapositiva**

Puedes decidir usar una foto como fondo para una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Establecer imágenes como fondos de diapositivas](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación usando el método [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de la siguiente manera:

1. Crear el objeto SvgImage para insertarlo en ImageShapeCollection  
2. Crear el objeto PPImage a partir de ISvgImage  
3. Crear el objeto PictureFrame usando la interfaz IPPImage  

Este fragmento de código muestra cómo implementar los pasos anteriores para agregar una imagen SVG a una presentación:
``` csharp 
// La ruta al directorio de documentos
string dataDir = @"D:\Documents\";

// Nombre del archivo SVG de origen
string svgFileName = dataDir + "sample.svg";

// Nombre del archivo de presentación de salida
string outPptxPath = dataDir + "presentation.pptx";

// Crear nueva presentación
using (var p = new Presentation())
{
    // Leer el contenido del archivo SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Crear objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Crear objeto PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Crea un nuevo PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Guardar la presentación en formato PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Convertir SVG a un conjunto de formas**
La conversión de SVG a un conjunto de formas en Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:

![PowerPoint Popup Menu](img_01_01.png)

La funcionalidad se proporciona mediante una de las sobrecargas del método [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) que toma un objeto [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) como primer argumento.

Este fragmento de código muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de formas:
``` csharp 
// La ruta al directorio de documentos
string dataDir = @"D:\Documents\";

// Nombre del archivo SVG de origen
string svgFileName = dataDir + "sample.svg";

// Nombre del archivo de presentación de salida
string outPptxPath = dataDir + "presentation.pptx";

// Crear nueva presentación
using (IPresentation presentation = new Presentation())
{
    // Leer el contenido del archivo SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Crear objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtener el tamaño de la diapositiva
    SizeF slideSize = presentation.SlideSize.Size;

    // Convertir la imagen SVG a un grupo de formas escalándola al tamaño de la diapositiva
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Guardar la presentación en formato PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Agregar imágenes como EMF en diapositivas**
Aspose.Slides para .NET permite generar imágenes EMF a partir de hojas de Excel y agregar esas imágenes como EMF en diapositivas con Aspose.Cells.  

Este fragmento de código muestra cómo realizar la tarea descrita:
``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Guardar el libro de trabajo en el flujo
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```


## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación (incluidas las usadas por formas de diapositiva). Esta sección muestra varios enfoques para actualizar imágenes en la colección. La API proporciona métodos directos para reemplazar una imagen usando datos binarios sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) o otra imagen que ya exista en la colección.

Sigue los pasos a continuación:

1. Cargar el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
1. Cargar una nueva imagen desde un archivo a un arreglo de bytes.  
1. Reemplazar la imagen objetivo con la nueva imagen usando el arreglo de bytes.  
1. En el segundo enfoque, cargar la imagen en un objeto [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) y reemplazar la imagen objetivo con ese objeto.  
1. En el tercer enfoque, reemplazar la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.  
1. Guardar la presentación modificada como archivo PPTX.  
```cs
// Instanciar la clase Presentation que representa un archivo de presentación.
using Presentation presentation = new Presentation("sample.pptx");

// La primera forma.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// La segunda forma.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// La tercera forma.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Guardar la presentación en un archivo.
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="Información" color="info" %}}

Usando el convertidor GRATUITO de Aspose [Texto a GIF](https://products.aspose.app/slides/text-to-gif), puedes animar textos fácilmente, crear GIFs a partir de textos, etc. 

{{% /alert %}}

## **FAQ**

**¿Se mantiene la resolución original de la imagen después de insertarla?**

Sí. Los píxeles de origen se conservan, pero la apariencia final depende de cómo se escale la [imagen](/slides/es/net/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en docenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en un diseño y reemplázalo en la colección de imágenes de la presentación; los cambios se propagarán a todos los elementos que usen ese recurso.

**¿Se puede convertir un SVG insertado en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, después de lo cual cada parte individual se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo para varias diapositivas a la vez?**

[Asignar la imagen como fondo](/slides/es/net/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use esa maestra/diseño heredará el fondo.

**¿Cómo evito que la presentación "inflado" de tamaño por la gran cantidad de imágenes?**

Reutiliza un solo recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.