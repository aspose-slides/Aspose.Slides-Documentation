---
title: Agregar una marca de agua a una presentación en C#
linktitle: Marca de agua
type: docs
weight: 40
url: /es/net/watermark/
keywords:
- marca de agua
- marca de agua de texto
- marca de agua de imagen
- agregar marca de agua
- cambiar marca de agua
- eliminar marca de agua
- borrar marca de agua
- agregar marca de agua a la presentación
- agregar marca de agua a PPT
- agregar marca de agua a PPTX
- agregar marca de agua a ODP
- eliminar marca de agua de la presentación
- eliminar marca de agua de PPT
- eliminar marca de agua de PPTX
- eliminar marca de agua de ODP
- borrar marca de agua de la presentación
- borrar marca de agua de PPT
- borrar marca de agua de PPTX
- borrar marca de agua de ODP
- PowerPoint
- OpenDocument
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: "Aprenda a gestionar marcas de agua de texto y de imagen en presentaciones de PowerPoint y OpenDocument en C# para indicar un borrador, información confidencial, derechos de autor y más."
---

## **Descripción general**

**Una marca de agua** en una presentación es un sello de texto o imagen que se utiliza en una diapositiva o en todas las diapositivas de una presentación. Normalmente, una marca de agua se utiliza para indicar que la presentación es un borrador (p. ej., una marca de agua “Borrador”), que contiene información confidencial (p. ej., una marca de agua “Confidencial”), para especificar a qué empresa pertenece (p. ej., una marca de agua “Nombre de la empresa”), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se usan tanto en los formatos de presentación PowerPoint como OpenDocument. En Aspose.Slides, puedes agregar una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenDocument ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/net/), existen varias formas de crear marcas de agua en documentos PowerPoint u OpenDocument y modificar su diseño y comportamiento. El aspecto común es que, para agregar marcas de agua de texto, debes usar la interfaz [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), y para agregar marcas de agua de imagen, usar la clase [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) o rellenar una forma de marca de agua con una imagen. `PictureFrame` implementa la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) , lo que permite utilizar todas las configuraciones flexibles del objeto forma. Dado que `ITextFrame` no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

Hay dos formas de aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El Maestro de diapositivas se usa para aplicar una marca de agua a todas las diapositivas: la marca de agua se agrega al Maestro de diapositivas, se diseña completamente allí y se aplica a todas las diapositivas sin afectar el permiso de modificar la marca de agua en diapositivas individuales.

Una marca de agua suele considerarse no editable por otros usuarios. Para evitar que la marca de agua (o más bien la forma padre de la marca de agua) sea editada, Aspose.Slides proporciona la funcionalidad de bloqueo de forma. Una forma específica puede bloquearse en una diapositiva normal o en un Maestro de diapositivas. Cuando la forma de la marca de agua está bloqueada en el Maestro de diapositivas, quedará bloqueada en todas las diapositivas de la presentación.

Puedes asignar un nombre a la marca de agua para que, en el futuro, si deseas eliminarla, la encuentres entre las formas de la diapositiva por su nombre.

Puedes diseñar la marca de agua de cualquier manera; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición al frente, etc. Consideraremos cómo usar estas características en los ejemplos siguientes.

## **Marca de agua de texto**

### **Agregar una marca de agua de texto a una diapositiva**

Para agregar una marca de agua de texto en PPT, PPTX o ODP, puedes primero agregar una forma a la diapositiva y luego agregar un marco de texto a esa forma. El marco de texto está representado por la interfaz [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe). Este tipo no hereda de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), que posee un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por ello, el objeto [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) se envuelve en un objeto [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Para agregar texto de marca de agua a la forma, usa el método [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) como se muestra a continuación.
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Agregar la marca de agua a la diapositiva.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar la clase TextFrame?](/slides/es/net/text-formatting/)
{{% /alert %}}

### **Agregar una marca de agua de texto a una presentación**

Si deseas agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), añádela al [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). El resto de la lógica es igual que al agregar una marca de agua a una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) y luego agrega la marca de agua usando el método [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe).
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Agregar la marca de agua a la diapositiva maestra.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar el Maestro de diapositivas?](/slides/es/net/slide-master/)
{{% /alert %}}

### **Establecer la transparencia de la forma de la marca de agua**

De forma predeterminada, la forma rectangular tiene estilos de relleno y línea. Esto significa que al agregar la marca de agua, puede aparecer con un fondo sólido o un borde que distraiga del contenido de la diapositiva. Para garantizar que la marca de agua siga siendo sutil y no interfiera con el diseño visual de la presentación, puedes hacer que la forma sea completamente transparente.

Las siguientes líneas de código hacen la forma transparente al eliminar tanto su color de relleno como su color de borde:
```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```


### **Establecer la fuente para una marca de agua de texto**

Antes de aplicar la marca de agua de texto a tu diapositiva, es importante personalizar su apariencia para que armonice con el diseño general. Puedes cambiar el tipo y el tamaño de la fuente para asegurarte de que la marca de agua sea legible y estéticamente agradable. Personalizar la fuente también ayuda a reforzar la identidad de la marca o simplemente a combinar con el estilo de la presentación.

El fragmento de código a continuación muestra cómo ajustar la configuración de fuente de la marca de agua seleccionando una fuente latina específica y estableciendo una altura de fuente adecuada:
```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```


### **Establecer el color del texto de la marca de agua**

Antes de aplicar tu marca de agua, es fundamental asegurarse de que el color del texto esté configurado adecuadamente para que se mezcle bien con el contenido de la diapositiva sin sobresalir. Ajustar la transparencia (alfa) del color junto con los componentes rojo, verde y azul permite crear una marca de agua sutil y semitransparente que sea visible pero discreta. Este enfoque ayuda a mantener la atención en la presentación principal mientras se protege el contenido.

Para establecer el color del texto de la marca de agua, usa el siguiente código:
```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```


### **Centrar una marca de agua de texto**

Centrar correctamente tu marca de agua de texto puede mejorar significativamente la estética general de tu presentación al garantizar que la marca de agua esté posicionada de forma simétrica, independientemente de las dimensiones de la diapositiva. Este enfoque no solo aporta un aspecto profesional, sino que también asegura que la marca de agua no interfiera con el contenido principal de la diapositiva.

El fragmento de código a continuación muestra cómo calcular la posición central de una diapositiva y colocar la marca de agua de texto en esa posición:
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

## **Marca de agua de imagen**

### **Agregar una marca de agua de imagen a una presentación**

En muchos casos, una marca de agua de imagen puede proporcionar un elemento de marca único o una alternativa visualmente más atractiva a una marca de agua de texto. Antes de agregar la marca de agua, asegúrate de que el archivo de imagen esté disponible (p. ej., PNG para transparencia). El siguiente ejemplo muestra cómo cargar una imagen desde el sistema de archivos, agregarla a la presentación y luego aplicarla como marca de agua mediante las propiedades de relleno de la forma.
```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```


## **Bloquear una marca de agua para que no se edite**

Si es necesario evitar que una marca de agua sea editada, usa la propiedad [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) de la forma. Con esta propiedad puedes proteger la forma de ser seleccionada, redimensionada, reposicionada, agrupada con otros elementos, bloquear su texto contra la edición y mucho más:
```cs
// Bloquear la forma de marca de agua para que no se modifique.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```


## **Traer una marca de agua al frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder). Para ello, debes llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden. De esta manera, es posible traer una forma al frente o enviarla al fondo de la diapositiva. Esta característica es especialmente útil si necesitas colocar una marca de agua delante del contenido de la presentación:
```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```


## **Establecer la rotación de la marca de agua**

Ajustar la rotación de tu marca de agua puede mejorar significativamente el impacto visual y la sutileza de tu presentación. Una marca de agua diagonal, por ejemplo, puede ser menos intrusiva mientras sigue proporcionando una protección robusta contra el uso no autorizado. El siguiente ejemplo calcula el ángulo adecuado basado en las dimensiones de la diapositiva para que la marca de agua quede diagonalmente a través de la diapositiva. Este cálculo dinámico garantiza que la marca de agua siga siendo eficaz independientemente del tamaño de la diapositiva.
```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```


## **Asignar un nombre a una marca de agua**

Aspose.Slides permite establecer el nombre de una forma. Mediante el nombre de la forma, puedes acceder a ella en el futuro para modificarla o eliminarla. Para asignar el nombre a la forma de la marca de agua, establézcalo en la propiedad [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name):
```cs
watermarkShape.Name = "watermark";
```


## **Eliminar una marca de agua**

Para eliminar la forma de la marca de agua, usa la propiedad [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) para encontrarla entre las formas de la diapositiva. Luego, pasa la forma de la marca de agua al método [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) :
```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```


## **Ejemplo en vivo**

Puedes probar las herramientas en línea gratuitas de **Aspose.Slides** [Agregar marca de agua](https://products.aspose.app/slides/watermark) y [Eliminar marca de agua](https://products.aspose.app/slides/watermark/remove-watermark).

![Herramientas en línea para agregar y eliminar marcas de agua](online_tools.png)

## **Preguntas frecuentes**

**¿Qué es una marca de agua y por qué debería usarla?**

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de marca o prevenir el uso no autorizado de presentaciones.

**¿Puedo agregar una marca de agua a todas las diapositivas de una presentación?**

Sí, Aspose.Slides permite agregar programáticamente una marca de agua a cada diapositiva de una presentación. Puedes iterar sobre todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

**¿Cómo puedo ajustar la transparencia de la marca de agua?**

Puedes ajustar la transparencia de la marca de agua modificando la configuración de relleno ([FillFormat](https://reference.aspose.com/slides/net/aspose.slides/shape/fillformat/)) de la forma. Esto asegura que la marca de agua sea sutil y no distraiga del contenido de la diapositiva.

**¿Qué formatos de imagen son compatibles con las marcas de agua?**

Aspose.Slides admite varios formatos de imagen como PNG, JPEG, GIF, BMP, SVG y más.

**¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?**

Sí, puedes elegir cualquier fuente, tamaño y estilo para que coincida con el diseño de tu presentación y mantenga la coherencia de la marca.

**¿Cómo cambio la posición o orientación de una marca de agua?**

Puedes ajustar la posición y orientación de la marca de agua programáticamente modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.