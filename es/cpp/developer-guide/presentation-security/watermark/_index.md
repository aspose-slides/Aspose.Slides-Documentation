---
title: Añadir marcas de agua a presentaciones en C++
linktitle: Marca de agua
type: docs
weight: 40
url: /es/cpp/watermark/
keywords:
- marca de agua
- marca de agua de texto
- marca de agua de imagen
- añadir marca de agua
- cambiar marca de agua
- eliminar marca de agua
- borrar marca de agua
- añadir marca de agua a PPT
- añadir marca de agua a PPTX
- añadir marca de agua a ODP
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
description: "Gestiona marcas de agua de texto e imagen en presentaciones de PowerPoint y OpenDocument en C++ para indicar un borrador, información confidencial, derechos de autor y más."
---
## **Introducción**

**Una marca de agua** en una presentación es una estampilla de texto o imagen que se utiliza en una diapositiva o en todas las diapositivas de la presentación. Normalmente, una marca de agua se usa para indicar que la presentación es un borrador (p. ej., una marca de agua «Borrador»), que contiene información confidencial (p. ej., una marca de agua «Confidencial»), para especificar a qué empresa pertenece (p. ej., una marca de agua «Nombre de la empresa»), para identificar al autor de la presentación, etc. Una marca de agua ayuda a evitar infracciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se utilizan tanto en los formatos de presentación de PowerPoint como en los de OpenOffice. En Aspose.Slides, puedes añadir una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/es/cpp/), existen varias formas de crear marcas de agua en documentos PowerPoint o OpenOffice y de modificar su diseño y comportamiento. El aspecto común es que, para añadir marcas de agua de texto, debes usar la interfaz [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/), y para añadir marcas de agua de imagen, usar la clase [PictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/pictureframe/) o rellenar una forma de marca de agua con una imagen. `PictureFrame` implementa la interfaz [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/), lo que permite utilizar todas las configuraciones flexibles del objeto forma. Como `ITextFrame` no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/).

Hay dos maneras de aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El patrón de diapositivas (Slide Master) se usa para aplicar una marca de agua a todas las diapositivas: la marca de agua se añade al Slide Master, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la posibilidad de modificar la marca de agua en diapositivas individuales.

Una marca de agua suele considerarse no editable por otros usuarios. Para evitar que la marca de agua (o mejor dicho, la forma que la contiene) sea editada, Aspose.Slides ofrece funcionalidad de bloqueo de formas. Una forma concreta puede bloquearse en una diapositiva normal o en un Slide Master. Cuando la forma de la marca de agua está bloqueada en el Slide Master, quedará bloqueada en todas las diapositivas de la presentación.

Puedes asignar un nombre a la marca de agua para que, en el futuro, si deseas eliminarla, puedas encontrarla entre las formas de la diapositiva por su nombre.

Puedes diseñar la marca de agua de cualquier manera; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición al frente, etc. Consideraremos cómo usar estas opciones en los ejemplos siguientes.

## **Marca de agua de texto**

### **Añadir una marca de agua de texto a una diapositiva**

Para añadir una marca de agua de texto en PPT, PPTX o ODP, puedes primero agregar una forma a la diapositiva y luego añadir un marco de texto a esa forma. El marco de texto está representado por la interfaz [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/). Este tipo no hereda de [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/), que dispone de un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por ello, el objeto [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) se envuelve en un objeto [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/). Para añadir texto de marca de agua a la forma, usa el método [AddTextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/addtextframe/) como se muestra a continuación.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Ver también" %}} 
- [Cómo usar la clase TextFrame](/slides/es/cpp/text-formatting/)
{{% /alert %}}

### **Añadir una marca de agua de texto a una presentación**

Si quieres añadir una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agrégala al [MasterSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/masterslide/). El resto de la lógica es idéntico al de añadir una marca de agua a una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) y luego añade la marca de agua mediante el método [AddTextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Ver también" %}} 
- [Cómo usar el Slide Master](/slides/es/cpp/slide-master/)
{{% /alert %}}

### **Definir la transparencia de la forma de la marca de agua**

Por defecto, la forma rectangular tiene colores de relleno y de línea. Las siguientes líneas de código hacen que la forma sea transparente.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Definir la fuente de una marca de agua de texto**

Puedes cambiar la fuente del texto de la marca de agua como se muestra a continuación.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Definir el color del texto de la marca de agua**

Para establecer el color del texto de la marca de agua, usa este código:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrar una marca de agua de texto**

Es posible centrar la marca de agua en una diapositiva; para ello, puedes hacer lo siguiente:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

La imagen siguiente muestra el resultado final.

![The text watermark](text_watermark.png)

## **Marca de agua de imagen**

### **Añadir una marca de agua de imagen a una presentación**

Para añadir una marca de agua de imagen a una diapositiva de la presentación, puedes hacer lo siguiente:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Bloquear una marca de agua para que no se edite**

Si es necesario impedir que una marca de agua se edite, usa el método [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/get_autoshapelock/) sobre la forma. Con esta propiedad, puedes proteger la forma contra la selección, el cambio de tamaño, el reposicionamiento, el agrupamiento con otros elementos, bloquear su texto contra la edición y mucho más:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Bloquear la forma de la marca de agua para que no se modifique
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Traer una marca de agua al frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [IShapeCollection::Reorder](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/reorder/). Para hacerlo, debes llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De este modo, es posible llevar una forma al frente o enviarla al fondo de la diapositiva. Esta función resulta especialmente útil si necesitas colocar una marca de agua delante del contenido de la presentación:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Definir la rotación de la marca de agua**

A continuación se muestra un ejemplo de código que ajusta la rotación de la marca de agua para que quede posicionada diagonalmente a lo largo de la diapositiva:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Asignar un nombre a una marca de agua**

Aspose.Slides permite establecer el nombre de una forma. Mediante el nombre de la forma, puedes acceder a ella en el futuro para modificarla o eliminarla. Para asignar el nombre a la forma de la marca de agua, utiliza el método [IAutoShape::set_Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/set_name/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Eliminar una marca de agua**

Para eliminar la forma de la marca de agua, usa el método [IAutoShape::get_Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_name/) para encontrarla entre las formas de la diapositiva. Después, pasa la forma de la marca de agua al método [IShapeCollection::Remove](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Ejemplo en vivo**

Puedes probar las herramientas en línea gratuitas de **Aspose.Slides** **Add Watermark** y **Remove Watermark**.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

### ¿Qué es una marca de agua y por qué debería usarla?

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de la marca o impedir el uso no autorizado de las presentaciones.

### ¿Puedo añadir una marca de agua a todas las diapositivas de una presentación?

Sí, Aspose.Slides permite añadir programáticamente una marca de agua a cada diapositiva de una presentación. Puedes iterar sobre todas las diapositivas y aplicar los ajustes de la marca de agua individualmente.

### ¿Cómo puedo ajustar la transparencia de la marca de agua?

Puedes ajustar la transparencia de la marca de agua modificando la configuración de relleno ([FillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/get_fillformat/)) de la forma. De este modo, la marca de agua será sutil y no distraerá del contenido de la diapositiva.

### ¿Qué formatos de imagen son compatibles para las marcas de agua?

Aspose.Slides admite varios formatos de imagen, como PNG, JPEG, GIF, BMP, SVG y otros.

### ¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?

Sí, puedes elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de tu presentación y mantengan la coherencia de la marca.

### ¿Cómo cambio la posición o la orientación de una marca de agua?

Puedes ajustar la posición y orientación de la marca de agua programáticamente modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.