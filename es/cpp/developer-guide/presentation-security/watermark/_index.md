---
title: Marca de agua
type: docs
weight: 40
url: /cpp/watermark/
keywords:
- marca de agua
- agregar marca de agua
- marca de agua de texto
- marca de agua de imagen
- PowerPoint
- presentación
- C++
- Aspose.Slides para C++
description: "Agregue marcas de agua de texto e imagen a presentaciones de PowerPoint en C++"
---

## **Acerca de las Marcas de Agua**

**Una marca de agua** en una presentación es un sello de texto o imagen utilizado en una diapositiva o en todas las diapositivas de la presentación. Generalmente, se utiliza una marca de agua para indicar que la presentación es un borrador (por ejemplo, una marca de agua "Borrador"), que contiene información confidencial (por ejemplo, una marca de agua "Confidencial"), para especificar a qué empresa pertenece (por ejemplo, una marca de agua "Nombre de la Empresa"), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe ser copiada. Las marcas de agua se utilizan en los formatos de presentación de PowerPoint y OpenOffice. En Aspose.Slides, puede agregar una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/cpp/), hay varias formas de crear marcas de agua en documentos de PowerPoint o OpenOffice y modificar su diseño y comportamiento. El aspecto común es que para agregar marcas de agua de texto, debe utilizar la interfaz [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), y para agregar marcas de agua de imagen, use la clase [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) o rellene una forma de marca de agua con una imagen. `PictureFrame` implementa la interfaz [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), lo que le permite utilizar todos los ajustes flexibles del objeto de forma. Dado que `ITextFrame` no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/).

Hay dos formas en que se puede aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El Patrón de Diapositiva se utiliza para aplicar una marca de agua a todas las diapositivas de la presentación: la marca de agua se agrega al Patrón de Diapositiva, se diseña completamente allí y se aplica a todas las diapositivas sin afectar el permiso para modificar la marca de agua en diapositivas individuales.

Una marca de agua suele considerarse no editable por otros usuarios. Para evitar que la marca de agua (o más bien la forma principal de la marca de agua) sea editada, Aspose.Slides proporciona la funcionalidad de bloqueo de forma. Se puede bloquear una forma específica en una diapositiva normal o en un Patrón de Diapositiva. Cuando la forma de marca de agua está bloqueada en el Patrón de Diapositiva, estará bloqueada en todas las diapositivas de la presentación.

Puede establecer un nombre para la marca de agua para que en el futuro, si desea eliminarla, pueda encontrarla en las formas de la diapositiva por su nombre.

Puede diseñar la marca de agua de cualquier manera; sin embargo, generalmente hay características comunes en las marcas de agua, como alineación centrada, rotación, posición frontal, etc. Consideraremos cómo usar estas en los ejemplos a continuación.

## **Marca de Agua de Texto**

### **Agregar una Marca de Agua de Texto a una Diapositiva**

Para agregar una marca de agua de texto en PPT, PPTX u ODP, primero puede agregar una forma a la diapositiva, luego agregar un marco de texto a esta forma. El marco de texto está representado por la interfaz [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/). Este tipo no se hereda de [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), que tiene un amplio conjunto de propiedades para posicionar la marca de agua de manera flexible. Por lo tanto, el objeto [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) se envuelve en un objeto [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Para agregar texto de marca de agua a la forma, use el método [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) como se muestra a continuación.

```cpp
auto watermarkText = u"CONFIDENCIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar la clase TextFrame](/slides/cpp/text-formatting/)
{{% /alert %}}

### **Agregar una Marca de Agua de Texto a una Presentación**

Si desea agregar una marca de agua de texto a toda la presentación (es decir, todas las diapositivas a la vez), agréguela al [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). El resto de la lógica es la misma que cuando se agrega una marca de agua a una sola diapositiva: cree un objeto [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) y luego agregue la marca de agua a él utilizando el método [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENCIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar el Patrón de Diapositiva](/slides/cpp/slide-master/)
{{% /alert %}}

### **Establecer la Transparencia de la Forma de Marca de Agua**

Por defecto, la forma rectangular está estilizada con colores de relleno y línea. Las siguientes líneas de código hacen que la forma sea transparente.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Establecer la Fuente para una Marca de Agua de Texto**

Puede cambiar la fuente de la marca de agua de texto como se muestra a continuación.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Establecer el Color del Texto de la Marca de Agua**

Para establecer el color del texto de la marca de agua, use este código:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrar una Marca de Agua de Texto**

Es posible centrar la marca de agua en una diapositiva, y para eso, puede hacer lo siguiente:

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

La imagen a continuación muestra el resultado final.

![La marca de agua de texto](text_watermark.png)

## **Marca de Agua de Imagen**

### **Agregar una Marca de Agua de Imagen a una Presentación**

Para agregar una marca de agua de imagen a una diapositiva de presentación, puede hacer lo siguiente:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Bloquear una Marca de Agua para Edición**

Si es necesario evitar que una marca de agua sea editada, use el método [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) en la forma. Con esta propiedad, puede proteger la forma de ser seleccionada, redimensionada, reposicionada, agrupada con otros elementos, bloquear su texto de la edición, y mucho más:

```cpp
// Bloquear la forma de marca de agua de modificar
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Traer una Marca de Agua al Frente**

En Aspose.Slides, el orden Z de las formas se puede establecer a través del método [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/). Para hacer esto, necesita llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera, es posible traer una forma al frente o enviarla al fondo de la diapositiva. Esta función es especialmente útil si necesita colocar una marca de agua frente a la presentación:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Establecer la Rotación de la Marca de Agua**

Aquí hay un ejemplo de código sobre cómo ajustar la rotación de la marca de agua para que esté posicionada diagonalmente a través de la diapositiva:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Establecer un Nombre para una Marca de Agua**

Aspose.Slides le permite establecer el nombre de una forma. Al usar el nombre de la forma, puede acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de marca de agua, asígnelo al método [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"marca de agua");
```

## **Eliminar una Marca de Agua**

Para eliminar la forma de marca de agua, use el método [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) para encontrarla en las formas de la diapositiva. Luego, pase la forma de marca de agua al método [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"marca de agua", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Un Ejemplo en Vivo**

Puede que desee consultar las herramientas en línea **Aspose.Slides gratuitas** [Agregar Marca de Agua](https://products.aspose.app/slides/watermark) y [Eliminar Marca de Agua](https://products.aspose.app/slides/watermark/remove-watermark).

![Herramientas en línea para agregar y eliminar marcas de agua](online_tools.png)