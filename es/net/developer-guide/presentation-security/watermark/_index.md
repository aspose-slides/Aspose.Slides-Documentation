---
title: Marca de Agua
type: docs
weight: 40
url: /net/watermark/
keywords:
- marca de agua
- agregar marca de agua
- marca de agua de texto
- marca de agua de imagen
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: "Agregar marcas de agua de texto e imagen a presentaciones de PowerPoint en C# o .NET"
---

## **Acerca de las Marcas de Agua**

**Una marca de agua** en una presentación es un sello de texto o imagen utilizado en una diapositiva o en todas las diapositivas de la presentación. Por lo general, se utiliza una marca de agua para indicar que la presentación es un borrador (por ejemplo, una marca de agua "Borrador"), que contiene información confidencial (por ejemplo, una marca de agua "Confidencial"), para especificar a qué empresa pertenece (por ejemplo, una marca de agua "Nombre de la Empresa"), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe ser copiada. Las marcas de agua se utilizan tanto en formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides, puede agregar una marca de agua a los formatos de archivo PPT, PPTX y ODP de PowerPoint.

En [**Aspose.Slides**](https://products.aspose.com/slides/net/), hay varias formas de crear marcas de agua en documentos de PowerPoint o OpenOffice y modificar su diseño y comportamiento. El aspecto común es que para agregar marcas de agua de texto, debe utilizar la interfaz [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), y para agregar marcas de agua de imagen, use la clase [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) o llene una forma de marca de agua con una imagen. `PictureFrame` implementa la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape), lo que le permite utilizar todas las configuraciones flexibles del objeto de forma. Dado que `ITextFrame` no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

Hay dos formas en que se puede aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. Se utiliza el Master Slide para aplicar una marca de agua a todas las diapositivas de la presentación: la marca de agua se agrega al Master Slide, se diseña completamente allí y se aplica a todas las diapositivas sin afectar el permiso para modificar la marca de agua en diapositivas individuales.

Se considera que una marca de agua no está disponible para su edición por otros usuarios. Para evitar que la marca de agua (o más bien la forma padre de la marca de agua) se edite, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Se puede bloquear una forma específica en una diapositiva normal o en un Master Slide. Cuando la forma de marca de agua está bloqueada en el Master Slide, estará bloqueada en todas las diapositivas de la presentación.

Puede asignar un nombre a la marca de agua para que en el futuro, si desea eliminarla, pueda encontrarla en las formas de la diapositiva por nombre.

Puede diseñar la marca de agua de cualquier manera; sin embargo, generalmente hay características comunes en las marcas de agua, como la alineación centrada, rotación, posición frontal, etc. A continuación, consideraremos cómo utilizar estos aspectos en los ejemplos.

## **Marca de Agua de Texto**

### **Agregar una Marca de Agua de Texto a una Diapositiva**

Para agregar una marca de agua de texto en PPT, PPTX o ODP, primero puede agregar una forma a la diapositiva y luego agregar un marco de texto a esta forma. El marco de texto está representado por la interfaz [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe). Este tipo no se hereda de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), que tiene un amplio conjunto de propiedades para posicionar la marca de agua de manera flexible. Por lo tanto, el objeto [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) se envuelve en un objeto [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Para agregar texto de marca de agua a la forma, use el método [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) como se muestra a continuación.

```cs
string watermarkText = "CONFIDENCIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar la clase TextFrame](/slides/net/text-formatting/)
{{% /alert %}}

### **Agregar una Marca de Agua de Texto a una Presentación**

Si desea agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agréguela al [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). El resto de la lógica es la misma que al agregar una marca de agua a una sola diapositiva: cree un objeto [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) y luego agregue la marca de agua usando el método [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENCIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar el Slide Master](/slides/net/slide-master/)
{{% /alert %}}

### **Establecer la Transparencia de la Forma de Marca de Agua**

Por defecto, la forma rectangular está estilizada con colores de relleno y línea. Las siguientes líneas de código hacen que la forma sea transparente.

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Establecer la Fuente para una Marca de Agua de Texto**

Puede cambiar la fuente de la marca de agua de texto como se muestra a continuación.

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Establecer el Color del Texto de la Marca de Agua**

Para establecer el color del texto de la marca de agua, use este código:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centrar una Marca de Agua de Texto**

Es posible centrar la marca de agua en una diapositiva, y para eso, puede hacer lo siguiente:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

La imagen a continuación muestra el resultado final.

![La marca de agua de texto](text_watermark.png)

## **Marca de Agua de Imagen**

### **Agregar una Marca de Agua de Imagen a una Presentación**

Para agregar una marca de agua de imagen a una diapositiva de presentación, puede hacer lo siguiente:

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Bloquear una Marca de Agua de la Edición**

Si es necesario evitar que se edite una marca de agua, use la propiedad [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) en la forma. Con esta propiedad, puede proteger la forma de ser seleccionada, redimensionada, reposicionada, agrupada con otros elementos, bloquear su texto de edición y mucho más:

```cs
// Bloquear la forma de marca de agua para modificaciones
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Traer una Marca de Agua al Frente**

En Aspose.Slides, el orden Z de las formas se puede establecer a través del método [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder). Para hacerlo, necesita llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera, es posible traer una forma al frente o enviarla detrás de la diapositiva. Esta función es especialmente útil si necesita colocar una marca de agua frente a la presentación:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Establecer la Rotación de la Marca de Agua**

Aquí hay un ejemplo de código de cómo ajustar la rotación de la marca de agua para que esté posicionada diagonalmente a través de la diapositiva:

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Establecer un Nombre para una Marca de Agua**

Aspose.Slides permite establecer el nombre de una forma. Al usar el nombre de la forma, puede acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de marca de agua, asígnele la propiedad [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "marca de agua";
```

## **Eliminar una Marca de Agua**

Para eliminar la forma de marca de agua, use la propiedad [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) para encontrarla en las formas de la diapositiva. Luego, pase la forma de marca de agua al método [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/):

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "marca de agua", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Un Ejemplo en Vivo**

Puede que desee probar las herramientas en línea **Aspose.Slides gratis** [Agregar Marca de Agua](https://products.aspose.app/slides/watermark) y [Eliminar Marca de Agua](https://products.aspose.app/slides/watermark/remove-watermark).

![Herramientas en línea para agregar y eliminar marcas de agua](online_tools.png)