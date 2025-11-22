---
title: Imagen
type: docs
weight: 10
url: /es/net/image/
keywords:
- agregar imagen
- agregar foto
- agregar mapa de bits
- reemplazar imagen
- reemplazar foto
- desde web
- fondo
- agregar PNG
- agregar JPG
- agregar SVG
- agregar EMF
- agregar WMF
- agregar TIFF
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Optimiza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para .NET, mejorando el rendimiento y automatizando tu flujo de trabajo."
---

## **Imágenes en Diapositivas en Presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, internet u otras ubicaciones en las diapositivas. De manera similar, Aspose.Slides permite agregar imágenes a las diapositivas en tus presentaciones mediante diferentes procedimientos.

{{% alert  title="Consejo" color="primary" %}} 

Aspose ofrece convertidores gratuitos—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas agregar una imagen como objeto de marco—especialmente si planeas usar opciones de formato estándar en ella para cambiar su tamaño, agregar efectos, etc.—consulta [Picture Frame](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, BMP, GIF y otros. 

## **Agregar Imágenes Almacenadas Localmente a Diapositivas**

Puedes agregar una o varias imágenes de tu computadora a una diapositiva en una presentación. Este código de ejemplo en C# muestra cómo agregar una imagen a una diapositiva:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Agregar Imágenes Desde la Web a Diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes agregarla directamente desde la web. 

Este código de ejemplo muestra cómo agregar una imagen desde la web a una diapositiva en C#:
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


## **Agregar Imágenes a los Master de Diapositivas**

Un maestro de diapositiva es la diapositiva principal que almacena y controla información (tema, diseño, etc.) sobre todas las diapositivas bajo él. Por lo tanto, cuando agregas una imagen a un maestro de diapositiva, esa imagen aparece en cada diapositiva bajo ese maestro. 

Este código de ejemplo en C# muestra cómo agregar una imagen a un maestro de diapositiva:
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


## **Agregar Imágenes como Fondo de Diapositiva**

Puede decidir usar una imagen como fondo para una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a Presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación usando el método [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection). 

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de esta manera:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crear un objeto PPImage a partir de ISvgImage
3. Crear un objeto PictureFrame usando la interfaz IPPImage

Este código de ejemplo muestra cómo implementar los pasos anteriores para agregar una imagen SVG a una presentación:
```csharp
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

    // Crear un nuevo PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Guardar la presentación en formato PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Convertir SVG a un Conjunto de Formas**
La conversión de SVG a un conjunto de formas en Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:

![PowerPoint Popup Menu](img_01_01.png)

La funcionalidad la proporciona una de las sobrecargas del método [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) que toma un objeto [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) como primer argumento.

Este código de ejemplo muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de formas:
```csharp
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


## **Agregar Imágenes como EMF en Diapositivas**
Aspose.Slides for .NET permite generar imágenes EMF a partir de hojas de Excel y agregar las imágenes como EMF en diapositivas con Aspose.Cells. 

Este código de ejemplo muestra cómo realizar la tarea descrita:
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


## **Reemplazar Imágenes en la Colección de Imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación (incluidas las usadas por formas de diapositivas). Esta sección muestra varios enfoques para actualizar imágenes en la colección. La API ofrece métodos sencillos para reemplazar una imagen usando datos de bytes sin procesar, una instancia [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) o otra imagen que ya exista en la colección.

1. Cargar el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Cargar una nueva imagen desde un archivo en un arreglo de bytes.
3. Reemplazar la imagen objetivo con la nueva imagen usando el arreglo de bytes.
4. En el segundo enfoque, cargar la imagen en un objeto [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) y reemplazar la imagen objetivo con ese objeto.
5. En el tercer enfoque, reemplazar la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
Guardar la presentación modificada como un archivo PPTX.
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

Usando el conversor GRATUITO de Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif) puedes animar fácilmente textos, crear GIFs a partir de textos, etc. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se mantiene intacta la resolución original de la imagen después de la inserción?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [picture](/slides/es/net/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en docenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en una plantilla y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usen ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, tras lo cual las partes individuales se vuelven editables con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo para varias diapositivas a la vez?**

[Asignar la imagen como fondo](/slides/es/net/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use esa maestra/diseño heredará el fondo.

**¿Cómo evito que la presentación "infle" de tamaño debido a muchas imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.