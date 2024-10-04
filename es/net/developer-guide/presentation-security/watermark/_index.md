---
title: Marca de agua
type: docs
weight: 40
url: /net/watermark/
keywords: "Marca de agua, añadir marca de agua, marca de agua de texto, marca de agua de imagen, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Añadir marcas de agua de texto e imagen a la presentación de PowerPoint en C# o .NET"
---


## **Acerca de la Marca de Agua**
La **marca de agua** en la presentación es un sello de texto o imagen, utilizado en una diapositiva o en todas las diapositivas de la presentación. Por lo general, la marca de agua se utiliza para indicar que la presentación es un borrador (por ejemplo, marca de agua "Borrador"); que contiene información confidencial (por ejemplo, marca de agua "Confidencial"); especificar a qué empresa pertenece (por ejemplo, marca de agua "Nombre de la empresa"); identificar al autor de la presentación, etc. La marca de agua ayuda a prevenir la violación de derechos de autor de la presentación, indicando que la presentación no debe ser copiada. Las marcas de agua se utilizan con los formatos de presentación de PowerPoint y OpenOffice. En Aspose.Slides puedes añadir marcas de agua a los formatos de archivo PPT, PPTX y ODP de PowerPoint.

En [**Aspose.Slides**](https://products.aspose.com/slides/net/) hay diversas maneras de crear una marca de agua en PowerPoint o OpenOffice, para envolverla en diferentes formas, cambiar el diseño y el comportamiento, etc. Lo común es que, para añadir marcas de agua de texto, se debe utilizar la clase [**TextFrame**](https://reference.aspose.com/slides/net/aspose.slides/textframe) y, para añadir marcas de agua de imagen, se debe utilizar [**PictureFrame**](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). PictureFrame implementa la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) y puede utilizar toda la potencia de la configuración flexible del objeto de forma. TextFrame no es una forma y sus configuraciones son limitadas. Por lo tanto, se aconseja envolver el TextFrame en un objeto [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

Existen dos formas en las que se puede aplicar la marca de agua: a una sola diapositiva y a todas las diapositivas de la presentación. Se utiliza el Slide Master para aplicar la marca de agua a todas las diapositivas de la presentación: la marca de agua se añade al Slide Master, se diseña completamente allí y se aplica a todas las diapositivas sin modificar el permiso para modificar la marca de agua en las diapositivas.

La marca de agua generalmente se considera no editable por otros usuarios. Para evitar la edición de la marca de agua (o más bien de la forma madre de la marca de agua), Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma determinada puede ser bloqueada en una diapositiva normal o en un Slide Master. Al bloquear la forma de marca de agua en un Slide Master, estará bloqueada en todas las diapositivas de la presentación.

Puedes establecer el nombre de la marca de agua, por lo que en el futuro, si deseas eliminar la marca de agua, puedes encontrarla en las formas de la diapositiva por su nombre.

Puedes diseñar la marca de agua de cualquier manera; sin embargo, generalmente hay características comunes dentro de las marcas de agua, como: alineación centrada, rotación, posición frontal, etc. A continuación, consideraremos cómo utilizarlas en los ejemplos.
## **Marca de Agua de Texto**
### **Añadir Marca de Agua de Texto a la Diapositiva**
Para añadir una marca de agua de texto en PPT, PPTX o ODP puedes primero agregar una forma a la diapositiva, luego añadir un marco de texto a esta forma. El marco de texto se representa con el tipo [**TextFrame**](https://reference.aspose.com/slides/net/aspose.slides/textframe). Este tipo no hereda de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), que tiene un amplio set de propiedades para establecer la marca de agua de manera flexible. Por lo tanto, se aconseja envolver el objeto [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) en un objeto [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Para añadir la marca de agua a la forma, utiliza el método [**AddTextFrame**](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) con el texto de la marca de agua pasado como argumento:

``` csharp

 using (var presentation = new Presentation())

{

	ISlide slide = presentation.Slides[0];

	IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

	ITextFrame watermarkTextFrame = watermarkShape.AddTextFrame("Marca de agua");

}

```



{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/net/slide-master/)[TextFrame](/slides/net/adding-and-formatting-text/)
{{% /alert %}}

### **Añadir Marca de Agua de Texto a la Presentación**
Si deseas añadir una marca de agua a la presentación (es decir, a todas las diapositivas a la vez), 
añádela en el [**MasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). 
Toda la otra lógica es la misma que al añadir la marca de agua a una sola diapositiva: crea un 
[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) 
objeto y luego añade la marca de agua en él con el 
[**AddTextFrame**](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) método:

``` csharp

 using (var presentation = new Presentation())

{

	IMasterSlide master = pres.Masters[0];

	IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 0, 0, 0, 0);

	ITextFrame watermarkTextFrame = watermarkShape.AddTextFrame("Marca de agua");

}

```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/net/slide-master/)[Slide Master](/slides/net/slide-master/)
{{% /alert %}}

### **Establecer Fuente de la Marca de Agua de Texto**
Puedes cambiar la fuente de la marca de agua de texto:

``` csharp

 int alpha = 150, red = 200, green = 200, blue = 200;

IPortion watermarkPortion = watermarkTextFrame.Paragraphs[0].Portions[0];

watermarkPortion.PortionFormat.FontHeight = 52;

```


### **Establecer Transparencia de la Marca de Agua de Texto**
Para establecer la transparencia de la marca de agua de texto, utiliza este código:

``` csharp

 int alpha = 150, red = 200, green = 200, blue = 200;

IPortion watermarkPortion = watermarkTextFrame.Paragraphs[0].Portions[0];

watermarkPortion.PortionFormat.FillFormat.FillType = FillType.Solid;

watermarkPortion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(alpha, red, green, blue);

```


### **Centrar Marca de Agua de Texto**
Es posible centrar la marca de agua en una diapositiva y para eso puedes hacer lo siguiente:



``` csharp

 PointF center = new PointF(presentation.SlideSize.Size.Width / 2, presentation.SlideSize.Size.Height / 2);

float width = 300;

float height = 300;

float x = center.X - width / 2;

float y = center.Y - height / 2;



//...

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, x, y, width, height);

```


## **Marca de Agua de Imagen**
### **Añadir Marca de Agua de Imagen a la Presentación**
Para añadir una marca de agua de imagen a todas las diapositivas de la presentación, puedes hacer lo siguiente:

``` csharp

 IPPImage image = presentation.Images.AddImage(File.ReadAllBytes("watermark.png"));



// ...

watermarkShape.FillFormat.FillType = FillType.Picture;

watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;

watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

```




## **Bloquear la Marca de Agua de la Edición**
Si es necesario prevenir que la marca de agua sea editada, utiliza la propiedad [**AutoShape.ShapeLock**](https://reference.aspose.com/slides/net/aspose.slides/autoshape/properties/shapelock) en la forma que la envuelve. Con esta propiedad puedes proteger la forma de la selección, redimensionamiento, cambio de posición, agrupamiento con otros elementos, bloquear su texto de edición y muchas otras cosas:

``` csharp

 // Bloquear Formas de modificar

watermarkShape.ShapeLock.SelectLocked = true;

watermarkShape.ShapeLock.SizeLocked = true;

watermarkShape.ShapeLock.TextLocked = true;

watermarkShape.ShapeLock.PositionLocked = true;

watermarkShape.ShapeLock.GroupingLocked = true;

```



{{% alert color="primary" title="Ver también" %}} 
- [Cómo bloquear formas de la edición](/slides/net/presentation-locking/)
{{% /alert %}}

## **Traer la Marca de Agua al Frente**
En Aspose.Slides, el Z-Order de las formas se puede establecer a través del método [**SlideCollection.Reorder**](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/reorder/methods/1). Para eso, necesitas llamar a este método de la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden en el método. De esta manera es posible colocar la forma al frente o atrás de la diapositiva. Esta característica es especialmente útil si necesitas colocar la marca de agua al frente de la presentación:

``` csharp

 slide.Shapes.Reorder(slide.Shapes.Count - 1, watermarkShape);

```


## **Establecer Rotación de la Marca de Agua**
Aquí hay un ejemplo de cómo establecer la rotación de la marca de agua (y su forma madre):

``` csharp

 float h = presentation.SlideSize.Size.Height;

float w = presentation.SlideSize.Size.Width;

watermarkShape.X = Convert.ToInt32((w - watermarkShape.Width) / 2);

watermarkShape.Y = Convert.ToInt32((h - watermarkShape.Height) / 2);

watermarkShape.Rotation = calculateRotation(h, w);



private int calculateRotation(float height, float width)

{

	double pageHeight = Convert.ToDouble(height);

	double pageWidth = Convert.ToDouble(width);

	double rotation = Math.Atan((pageHeight / pageWidth)) * 180 / Math.PI;

	return Convert.ToInt32(rotation);

}

```


## **Establecer Nombre a la Marca de Agua**
Aspose.Slides permite establecer el nombre de la forma. Por nombre de forma puedes acceder a ella en el futuro para modificar o eliminar. Para establecer el nombre de la forma madre de la marca de agua, establécelo en la propiedad [**AutoShape.Name**](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name):


``` csharp

 watermarkShape.Name = "marca de agua";

```


## **Eliminar Marca de Agua**
Para eliminar la forma de marca de agua y sus controles secundarios de la diapositiva, utiliza la propiedad [AutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) para encontrarla en las formas de la diapositiva. Luego pasa la forma de marca de agua al método [**ShapeCollection.Remove**](https://reference.aspose.com/net/cells/aspose.cells.drawing/shapecollection/methods/remove):

``` csharp

 for (int i = 0; i < slide.Shapes.Count; i++)

{

	AutoShape shape = (AutoShape)slide.Shapes[i];

	if (String.Compare(shape.Name, "marca de agua", StringComparison.Ordinal) == 0)

	{

		slide.Shapes.Remove(watermarkShape);

	}

}

```


## **Ejemplo en Vivo**
Puede que quieras consultar las herramientas en línea **gratuitas** [**Añadir Marca de Agua**](https://products.aspose.app/slides/watermark) y [**Eliminar Marca de Agua**](https://products.aspose.app/slides/watermark/remove-watermark) de **Aspose.Slides**. 

![todo:texto alternativo de la imagen](slides-watermark.png)