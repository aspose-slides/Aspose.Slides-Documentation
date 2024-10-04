---
title: Imagen
type: docs
weight: 10
url: /es/net/image/
keywords: "Agregar imagen, Agregar foto, presentación de PowerPoint, EMF, SVG, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar imagen a una diapositiva o presentación de PowerPoint en C# o .NET"
---

## **Imágenes en Diapositivas de Presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, internet u otras ubicaciones en las diapositivas. De manera similar, Aspose.Slides te permite agregar imágenes a las diapositivas de tus presentaciones a través de diferentes procedimientos.

{{% alert title="Consejo" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas agregar una imagen como un objeto de marco—especialmente si planeas usar opciones de formato estándar en ella para cambiar su tamaño, agregar efectos, etc.—consulta [Marco de Imagen](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides soporta operaciones con imágenes en estos formatos populares: JPEG, PNG, BMP, GIF y otros. 

## **Agregando Imágenes Almacenadas Localmente a Diapositivas**

Puedes agregar una o varias imágenes en tu computadora a una diapositiva en una presentación. Este código de ejemplo en C# te muestra cómo agregar una imagen a una diapositiva:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Agregando Imágenes Desde la Web a Diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes agregar la imagen directamente desde la web. 

Este código de ejemplo te muestra cómo agregar una imagen de la web a una diapositiva en C#:

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

## **Agregando Imágenes a Diseños de Diapositiva**

Un diseño de diapositiva es la diapositiva superior que almacena y controla la información (tema, diseño, etc.) sobre todas las diapositivas que están bajo ella. Entonces, cuando agregas una imagen a un diseño de diapositiva, esa imagen aparece en cada diapositiva bajo ese diseño.

Este código de ejemplo en C# te muestra cómo agregar una imagen a un diseño de diapositiva:

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

## **Agregando Imágenes como Fondo de Diapositiva**

Puedes decidir usar una imagen como el fondo de una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Configuración de Imágenes como Fondos para Diapositivas](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregando SVG a Presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación utilizando el método [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de esta manera:

1. Crear un objeto SvgImage para insertarlo en ImageShapeCollection.
2. Crear un objeto PPImage a partir de ISvgImage.
3. Crear un objeto PictureFrame utilizando la interfaz IPPImage.

Este código de ejemplo te muestra cómo implementar los pasos anteriores para agregar una imagen SVG en una presentación:
``` csharp 
// La ruta al directorio de documentos
string dataDir = @"D:\Documents\";

// Nombre del archivo SVG fuente
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

    // Guardar presentación en formato PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Convirtiendo SVG a un Conjunto de Formas**
La conversión de SVG a un conjunto de formas en Aspose.Slides es similar a la funcionalidad de PowerPoint utilizada para trabajar con imágenes SVG:


![Menú Emergente de PowerPoint](img_01_01.png)

La funcionalidad es proporcionada por uno de los sobrecargas del método [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) que toma un objeto [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) como primer argumento.

Este código de ejemplo te muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de formas:

``` csharp 
// La ruta al directorio de documentos
string dataDir = @"D:\Documents\";

// Nombre del archivo SVG fuente
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

    // Obtener tamaño de diapositiva
    SizeF slideSize = presentation.SlideSize.Size;

    // Convertir imagen SVG a grupo de formas escalándola al tamaño de la diapositiva
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Guardar presentación en formato PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Agregando Imágenes como EMF en Diapositivas**
Aspose.Slides para .NET te permite generar imágenes EMF desde hojas de Excel y agregar las imágenes como EMF en diapositivas con Aspose.Cells. 

Este código de ejemplo te muestra cómo realizar la tarea descrita:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Guardar el libro en un flujo
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

{{% alert title="Información" color="info" %}}

Usando el convertidor gratuito de Aspose [Texto a GIF](https://products.aspose.app/slides/text-to-gif), puedes animar fácilmente textos, crear GIFs a partir de textos, etc. 

{{% /alert %}}