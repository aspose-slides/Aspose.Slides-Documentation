---
title: Agregar marcas de agua a presentaciones en C++
linktitle: Marca de agua
type: docs
weight: 40
url: /es/cpp/watermark/
keywords:
- marca de agua
- marca de agua de texto
- marca de agua de imagen
- agregar marca de agua
- cambiar marca de agua
- eliminar marca de agua
- borrar marca de agua
- agregar marca de agua a PPT
- agregar marca de agua a PPTX
- agregar marca de agua a ODP
- eliminar marca de agua de PPT
- eliminar marca de agua de PPTX
- eliminar marca de agua de ODP
- borrar marca de agua de PPT
- borrar marca de agua de PPTX
- borrar marca de agua de ODP
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Administre marcas de agua de texto e imagen en presentaciones PowerPoint y OpenDocument en C++ para indicar un borrador, información confidencial, derechos de autor y más."
---

## **Visión general**

**Una marca de agua** en una presentación es un sello de texto o imagen utilizado en una diapositiva o en todas las diapositivas de la presentación. Normalmente, una marca de agua se usa para indicar que la presentación es un borrador (p. ej., una marca de agua "Borrador"), que contiene información confidencial (p. ej., una marca de agua "Confidencial"), para especificar a qué empresa pertenece (p. ej., una marca de agua "Nombre de la empresa"), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir infracciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se usan tanto en los formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides, puedes agregar una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/cpp/), existen varias formas de crear marcas de agua en documentos PowerPoint u OpenOffice y modificar su diseño y comportamiento. El aspecto común es que, para agregar marcas de agua de texto, debe usar la interfaz [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), y para agregar marcas de agua de imagen, use la clase [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) o rellene una forma de marca de agua con una imagen. `PictureFrame` implementa la interfaz [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), lo que le permite usar todas las configuraciones flexibles del objeto forma. Dado que `ITextFrame` no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/).

Hay dos formas de aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El Slide Master se usa para aplicar una marca de agua a todas las diapositivas — la marca de agua se agrega al Slide Master, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la posibilidad de modificar la marca de agua en diapositivas individuales.

Una marca de agua suele considerarse no disponible para su edición por otros usuarios. Para evitar que la marca de agua (o más bien la forma padre de la marca de agua) sea editada, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma específica puede bloquearse en una diapositiva normal o en un Slide Master. Cuando la forma de la marca de agua está bloqueada en el Slide Master, quedará bloqueada en todas las diapositivas de la presentación.

Puede establecer un nombre para la marca de agua de modo que, en el futuro, si desea eliminarla, pueda encontrarla entre las formas de la diapositiva por nombre.

Puede diseñar la marca de agua de cualquier manera; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición al frente, etc. Consideraremos cómo usar estas en los ejemplos a continuación.

## **Marca de agua de texto**

### **Agregar una marca de agua de texto a una diapositiva**

Para agregar una marca de agua de texto en PPT, PPTX u ODP, primero puede añadir una forma a la diapositiva y luego agregar un marco de texto a esa forma. El marco de texto está representado por la interfaz [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/). Este tipo no hereda de [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), que posee un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por lo tanto, el objeto [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) se envuelve en un objeto [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Para agregar texto de marca de agua a la forma, use el método [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) como se muestra a continuación.
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="Véase también" %}} 
- [Cómo usar la clase TextFrame](/slides/es/cpp/text-formatting/)
{{% /alert %}}

### **Agregar una marca de agua de texto a una presentación**

Si desea agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agréguela al [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). El resto de la lógica es igual que al agregar una marca de agua a una sola diapositiva: cree un objeto [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) y luego agregue la marca de agua a él usando el método [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/).
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="Véase también" %}} 
- [Cómo usar el Slide Master](/slides/es/cpp/slide-master/)
{{% /alert %}}

### **Establecer la transparencia de la forma de la marca de agua**

De forma predeterminada, la forma rectangular tiene colores de relleno y línea. Las siguientes líneas de código hacen que la forma sea transparente.
```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```


### **Establecer la fuente para una marca de agua de texto**

Puede cambiar la fuente de la marca de agua de texto como se muestra a continuación.
```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```


### **Establecer el color del texto de la marca de agua**

Para establecer el color del texto de la marca de agua, use este código:
```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **Centrar una marca de agua de texto**

Es posible centrar la marca de agua en una diapositiva, y para ello puede hacer lo siguiente:
```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```


![La marca de agua de texto](text_watermark.png)

## **Marca de agua de imagen**

### **Agregar una marca de agua de imagen a una presentación**

Para agregar una marca de agua de imagen a una diapositiva de la presentación, puede hacer lo siguiente:
```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```


## **Bloquear una marca de agua para que no se edite**

Si es necesario evitar que una marca de agua sea editada, use el método [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) en la forma. Con esta propiedad, puede proteger la forma de ser seleccionada, redimensionada, reposicionada, agrupada con otros elementos, bloquear su texto contra edición y mucho más:
```cpp
// Bloquear la forma de marca de agua para que no se modifique
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```


## **Traer una marca de agua al frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/). Para ello, debe llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera, es posible traer una forma al frente o enviarla al fondo de la diapositiva. Esta característica es especialmente útil si necesita colocar una marca de agua delante de la presentación:
```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```


## **Establecer la rotación de la marca de agua**

Aquí hay un ejemplo de código de cómo ajustar la rotación de la marca de agua para que quede posicionada diagonalmente a través de la diapositiva:
```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```


## **Establecer un nombre para una marca de agua**

Aspose.Slides le permite establecer el nombre de una forma. Al usar el nombre de la forma, puede acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, asígnelo al método [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/):
```cpp
watermarkShape->set_Name(u"watermark");
```


## **Eliminar una marca de agua**

Para eliminar la forma de la marca de agua, use el método [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) para ubicarla entre las formas de la diapositiva. Luego, pase la forma de la marca de agua al método [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/):
```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```


## **Un ejemplo en vivo**

Es posible que desee consultar las herramientas en línea gratuitas de **Aspose.Slides** [Agregar marca de agua](https://products.aspose.app/slides/watermark) y [Eliminar marca de agua](https://products.aspose.app/slides/watermark/remove-watermark).
![Herramientas en línea para agregar y eliminar marcas de agua](online_tools.png)

## **Preguntas frecuentes**

**¿Qué es una marca de agua y por qué debería usarla?**

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de marca o impedir el uso no autorizado de presentaciones.

**¿Puedo agregar una marca de agua a todas las diapositivas de una presentación?**

Sí, Aspose.Slides le permite agregar programáticamente una marca de agua a cada diapositiva de una presentación. Puede iterar por todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

**¿Cómo puedo ajustar la transparencia de la marca de agua?**

Puede ajustar la transparencia de la marca de agua modificando la configuración de relleno ([FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_fillformat/)) de la forma. Esto garantiza que la marca de agua sea sutil y no distraiga del contenido de la diapositiva.

**¿Qué formatos de imagen son compatibles con las marcas de agua?**

Aspose.Slides admite varios formatos de imagen como PNG, JPEG, GIF, BMP, SVG y más.

**¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?**

Sí, puede elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de su presentación y mantener la consistencia de la marca.

**¿Cómo cambio la posición o la orientación de una marca de agua?**

Puede ajustar la posición y orientación de la marca de agua programáticamente modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.