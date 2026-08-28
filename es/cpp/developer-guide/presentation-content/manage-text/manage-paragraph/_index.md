---
title: Gestionar párrafos de texto de PowerPoint en C++
linktitle: Gestionar párrafo
type: docs
weight: 40
url: /es/cpp/manage-paragraph/
aliases:
  - /cpp/parrafo/
  - /cpp/porcion/
keywords:
  - añadir texto
  - añadir párrafo
  - gestionar texto
  - gestionar párrafo
  - gestionar viñeta
  - sangría de párrafo
  - sangría colgante
  - viñeta de párrafo
  - lista numerada
  - lista con viñetas
  - propiedades del párrafo
  - importar HTML
  - texto a HTML
  - párrafo a HTML
  - párrafo a imagen
  - texto a imagen
  - exportar párrafo
  - PowerPoint
  - presentación
  - C++
  - Aspose.Slides
description: "Aprenda cómo crear y dar formato a párrafos, fragmentos, viñetas, listas numeradas, sangrías, contenido HTML e imágenes de párrafos con Aspose.Slides para C++."
---
## **Visión general**

Aspose.Slides for C++ representa el texto como una jerarquía de marcos de texto, párrafos y fragmentos:

* [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) representa el contenedor de texto en una forma y proporciona acceso a su colección de párrafos.
* [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/) representa un párrafo en un marco de texto y proporciona acceso a sus fragmentos y al formato a nivel de párrafo.
* [IPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/) representa una secuencia de texto dentro de un párrafo. Cada fragmento puede tener su propio texto y formato a nivel de carácter.

Por lo tanto, un párrafo puede contener texto con diferentes fuentes, colores, tamaños y otros formatos mediante varios fragmentos.

## **Crear y dar formato a los párrafos**

### **Crear párrafos con varios fragmentos**

Los siguientes pasos crean un marco de texto con tres párrafos, cada uno con tres fragmentos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la forma.
5. Utilice el párrafo predeterminado y añada dos objetos [IParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/) más al marco de texto.
6. Añada suficientes objetos [IPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/) para que cada párrafo contenga tres fragmentos. El párrafo predeterminado ya contiene un fragmento vacío.
7. Establezca el texto de cada fragmento.
8. Aplique formato a nivel de carácter mediante [IPortion::get_PortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/get_portionformat/).
9. Guarde la presentación modificada.

Este ejemplo en C++ implementa los pasos:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Crear listas con viñetas y numeradas**

### **Crear una lista con viñetas o numerada**

Las viñetas y la numeración facilitan la revisión de elementos relacionados. En Aspose.Slides, la configuración de listas se define a través de [IBulletFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/).

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva seleccionada.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la forma.
5. Elimine el párrafo predeterminado del marco de texto.
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraph/) para una viñeta de símbolo.
7. Establezca [IBulletFormat::set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Symbol](https://reference.aspose.com/slides/es/cpp/aspose.slides/bullettype/) y especifique el carácter de la viñeta.
8. Defina el texto del párrafo, la sangría, el color de la viñeta y la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Cree un segundo párrafo y establezca [IBulletFormat::set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Numbered](https://reference.aspose.com/slides/es/cpp/aspose.slides/bullettype/).
11. Configure el estilo de la viñeta numerada y añada el párrafo al marco de texto.
12. Guarde la presentación.

Este ejemplo en C++ crea una viñeta de símbolo y una viñeta numerada:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Utilizar viñetas con imagen**

Las viñetas con imagen le permiten usar una imagen personalizada en lugar de un símbolo o número.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la referencia de la diapositiva correspondiente mediante su índice.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) y acceda a su [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/).
4. Elimine el párrafo predeterminado del marco de texto.
5. Cargue la imagen de la viñeta y añádala a la colección de imágenes de la presentación como un [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/).
6. Cree un [Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraph/) y establezca su texto.
7. Establezca [IBulletFormat::set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Picture](https://reference.aspose.com/slides/es/cpp/aspose.slides/bullettype/).
8. Asigne la imagen mediante [ISlidesPicture::set_Image](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidespicture/set_image/) y defina la altura de la viñeta.
9. Añada el párrafo al marco de texto.
10. Guarde la presentación modificada.

Este ejemplo en C++ crea una viñeta con imagen:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Crear una lista multinivel**

Establezca [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_depth/) para colocar los párrafos en diferentes niveles de una lista. El nivel superior tiene una profundidad de `0`.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y acceda a una diapositiva.
2. Añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) y elimine el párrafo predeterminado de su marco de texto.
3. Cree cuatro párrafos y configure sus símbolos de viñeta.
4. Establezca sus valores [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_depth/) a `0`, `1`, `2` y `3`.
5. Añada los párrafos al marco de texto y guarde la presentación.

Este ejemplo en C++ crea una lista con viñetas de cuatro niveles:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Iniciar elementos de lista numerada con valores personalizados**

Utilice [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) para definir el número inicial que se muestra en un párrafo numerado.

1. Cree una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a una diapositiva.
2. Elimine el párrafo predeterminado del marco de texto de la forma.
3. Cree tres párrafos numerados.
4. Establezca [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) a `2`, `3` y `7` para los párrafos correspondientes.
5. Añada los párrafos al marco de texto y guarde la presentación.

Este ejemplo en C++ asigna un número inicial personalizado a cada párrafo:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Controlar el diseño del párrafo y sus propiedades finales**

### **Establecer una sangría de primera línea**

Utilice [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) para controlar la sangría de la primera línea de un párrafo. Este método desplaza solo la primera línea respecto al margen izquierdo del párrafo. Un valor positivo mueve la primera línea a la derecha, mientras que el resto de las líneas permanecen alineadas con el cuerpo del párrafo.

Utilice [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_marginleft/) cuando necesite mover todo el párrafo. Utilice [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) cuando necesite mover solo la primera línea.

El siguiente ejemplo crea varios párrafos y aplica diferentes valores de [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) para demostrar cómo la sangría de primera línea afecta al diseño del párrafo.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la forma y elimine el párrafo predeterminado.
5. Cree varios párrafos y establezca diferentes valores de [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) para ellos.
6. Añada los párrafos al marco de texto.
7. Guarde la presentación modificada.

Este código muestra cómo establecer una sangría de párrafo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![La sangría de primera línea de los párrafos](first_line_indent.png)

### **Establecer una sangría colgante**

Una sangría colgante es un diseño de párrafo en el que la primera línea comienza a la izquierda del resto de las líneas. En Aspose.Slides, crea este efecto con [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/). Establezca la sangría a un valor negativo para mover la primera línea a la izquierda respecto al cuerpo del párrafo.

En la práctica, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_marginleft/) define la posición izquierda del cuerpo del párrafo, y [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) define la posición de la primera línea respecto a ese margen. Para crear una sangría colgante, establezca un margen‑left positivo y una sangría negativa.

Este formato es útil para bibliografías, referencias, entradas de glosario y otros párrafos donde las líneas envueltas deben alinearse bajo el cuerpo del párrafo y no bajo el primer carácter de la primera línea.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la diapositiva objetivo.
3. Añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) rectangular a la diapositiva.
4. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la forma y elimine el párrafo predeterminado.
5. Cree párrafos y establezca un valor positivo de [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_marginleft/) para cada párrafo.
6. Establezca un valor negativo de [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_indent/) para crear el efecto de sangría colgante.
7. Añada los párrafos al marco de texto.
8. Guarde la presentación modificada.

Este código muestra cómo establecer una sangría colgante para un párrafo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![La sangría colgante de los párrafos](hanging_indent.png)

### **Establecer propiedades de ejecución al final del párrafo**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) controla el formato del carácter de fin de párrafo. El siguiente ejemplo asigna un tamaño de fuente y una fuente latina al carácter de fin del segundo párrafo:

1. Cargue una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y acceda a una diapositiva.
2. Añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) y elimine su párrafo predeterminado.
3. Cree dos párrafos y añada fragmentos de texto a cada uno.
4. Cree un [PortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/portionformat/) para el carácter de fin del segundo párrafo.
5. Establezca [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_fontheight/) y [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Asigne el formato con [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) y guarde la presentación.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importar y exportar contenido de párrafos**

### **Importar texto HTML en párrafos**

Utilice [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphcollection/addfromhtml/) para convertir marcado HTML en párrafos y fragmentos dentro de un marco de texto.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a una diapositiva y añada una [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/).
3. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la forma y elimine el párrafo predeterminado.
4. Lea el archivo HTML fuente.
5. Pase la cadena HTML a [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Guarde la presentación modificada.

Este ejemplo en C++ importa HTML en un marco de texto:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Exportar texto de párrafo a HTML**

Utilice [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphcollection/exporttohtml/) para exportar un rango seleccionado de párrafos como HTML.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y cargue la presentación deseada.
2. Acceda a la diapositiva y encuentre la [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) que contiene el texto.
3. Acceda al [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) de la forma.
4. Llame a [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphcollection/exporttohtml/) con el índice del párrafo inicial y el número de párrafos a exportar.
5. Escriba la cadena HTML devuelta en un archivo.

Este ejemplo en C++ exporta todos los párrafos de la primera forma de texto:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Renderizar un párrafo como imagen**

[IParagraph::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/getimage/) renderiza directamente un párrafo individual y devuelve un [IImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/). Guarde el resultado en un archivo o flujo con [IImage::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/iimage/save/). No necesita renderizar la forma que contiene el párrafo ni recortar un mapa de bits manualmente.

[IParagraph::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/getimage/) puede devolver `nullptr` si el párrafo no se encuentra en su colección padre, no tiene límites de renderizado válidos o no puede renderizarse. Compruebe el resultado antes de guardarlo y libere la imagen devuelta después de su uso.

#### **Renderizar un párrafo a escala predeterminada**

Supongamos que disponemos de un archivo de presentación llamado sample.pptx con una diapositiva, donde la primera forma es un cuadro de texto que contiene tres párrafos.

![El cuadro de texto con tres párrafos](paragraph_to_image_input.png)

El siguiente ejemplo renderiza el segundo párrafo en una forma de texto normal a escala predeterminada y guarda la imagen resultante en formato PNG.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

El resultado:

![Imagen del párrafo](paragraph_to_image_output.png)

#### **Renderizar un párrafo en una celda de tabla con escalado**

Utilice la sobrecarga de [IParagraph::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/getimage/) que acepta los parámetros `float scaleX` y `float scaleY` para establecer los factores de escala horizontal y vertical. El siguiente ejemplo crea una tabla, renderiza el párrafo en su primera celda con el doble de su ancho y altura predeterminados, y guarda el resultado como una imagen PNG.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

Un factor de escala de `1` mantiene ese eje en su tamaño de píxel predeterminado. Por ejemplo, `2` para ambos factores produce una imagen cuya anchura y altura son aproximadamente el doble de las dimensiones predeterminadas, lo que genera cuatro veces más píxeles. Factores mayores suelen producir texto más nítido para ampliaciones o salidas de alta resolución, pero también aumentan el uso de memoria y el tamaño del archivo. Los factores inferiores a `1` generan imágenes más pequeñas con menos detalle. Use factores iguales para preservar la proporción del párrafo; factores horizontales y verticales diferentes estiran la salida de forma independiente.

Renderizar una forma completa con [IShape::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/getimage/) sigue siendo útil cuando la salida debe incluir el relleno, el borde u otro contexto visual de la forma. Para una imagen únicamente del párrafo, use [IParagraph::GetImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/getimage/).

## **Preguntas frecuentes**

**¿Puedo desactivar completamente el ajuste de línea dentro de un marco de texto?**

Sí. Utilice [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/set_wraptext/) para desactivar el ajuste de modo que las líneas no se rompan en los bordes del marco de texto.

**¿Cómo puedo obtener los límites exactos en la diapositiva de un párrafo concreto?**

Utilice [IParagraph::GetRect](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/getrect/) para obtener el rectángulo delimitador del párrafo. [IPortion::GetRect](https://reference.aspose.com/slides/es/cpp/aspose.slides/iportion/getrect/) proporciona los límites de un fragmento individual.

**¿Dónde se controla la alineación del párrafo (izquierda, derecha, centrado o justificado)?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_alignment/) es una configuración a nivel de párrafo y se aplica a todo el párrafo independientemente del formato de los fragmentos individuales.

**¿Puedo establecer el idioma de corrección para parte de un párrafo?**

Sí. Utilice [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibaseportionformat/set_languageid/) para fragmentos individuales, de modo que un párrafo pueda contener texto en varios idiomas.