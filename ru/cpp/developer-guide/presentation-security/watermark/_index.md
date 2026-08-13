---
title: Добавление водяных знаков в презентации на C++
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/cpp/watermark/
keywords:
- водяной знак
- текстовый водяной знак
- изображение водяного знака
- добавить водяной знак
- изменить водяной знак
- удалить водяной знак
- удалить водяной знак
- добавить водяной знак в PPT
- добавить водяной знак в PPTX
- добавить водяной знак в ODP
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на C++, чтобы обозначать черновик, конфиденциальную информацию, авторские права и многое другое."
---
## **Введение**

**Водяной знак** в презентации — это текстовая или графическая метка, используемая на отдельном слайде или на всех слайдах презентации. Обычно водяной знак используется, чтобы указать, что презентация является черновиком (например, водяной знак «Черновик»), содержит конфиденциальную информацию (например, водяной знак «Конфиденциально»), указать, к какой компании относится документ (например, водяной знак «Название компании»), идентифицировать автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию не следует копировать. Водяные знаки используются как в форматах PowerPoint, так и в формате OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/ru/cpp/) есть различные способы создания водяных знаков в документах PowerPoint или OpenOffice и изменения их дизайна и поведения. Общий аспект состоит в том, что для добавления текстовых водяных знаков следует использовать интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/), а для добавления графических водяных знаков — класс [PictureFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/pictureframe/) или заполнить форму водяного знака изображением. `PictureFrame` реализует интерфейс [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/), позволяя использовать все гибкие настройки объекта формы. Поскольку `ITextFrame` не является формой и его настройки ограничены, он обёрнут в объект [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) .

Существует два способа применения водяного знака: к отдельному слайду или ко всем слайдам презентации. Для применения водяного знака ко всем слайдам используется мастер‑слайд — водяной знак добавляется в мастер‑слайд, полностью разрабатывается там и применяется ко всем слайдам без ограничения возможности изменения водяного знака на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (а точнее формы, содержащей его), Aspose.Slides предоставляет возможность блокировки формы. Конкретную форму можно заблокировать на обычном слайде или на мастер‑слайде. Когда форма водяного знака заблокирована на мастер‑слайде, она будет заблокирована на всех слайдах презентации.

Для водяного знака можно задать имя, чтобы в будущем, при необходимости удаления, найти его среди форм слайда по имени.

Водяной знак можно оформить любым образом; однако обычно у водяных знаков есть общие характеристики, такие как выравнивание по центру, вращение, расположение спереди и т.д. Мы рассмотрим, как использовать эти свойства в приведённых ниже примерах.

## **Текстовый водяной знак**

### **Добавить текстовый водяной знак на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала можно добавить форму на слайд, а затем добавить к ней текстовый кадр. Текстовый кадр представлен интерфейсом [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/), который предоставляет широкий набор свойств для гибкого позиционирования водяного знака. Поэтому объект [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) оборачивается в объект [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [AddTextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/addtextframe/) , как показано ниже.

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

{{% alert color="info" title="Смотрите также" %}} 
- [Как использовать класс TextFrame](/slides/ru/cpp/text-formatting/)
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**

Если нужно добавить текстовый водяной знак ко всей презентации (т.е. ко всем слайдам сразу), добавьте его в [MasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/masterslide/). Остальная логика такая же, как при добавлении водяного знака на один слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) , а затем добавьте к нему водяной знак, используя метод [AddTextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/addtextframe/) .

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

{{% alert color="info" title="Смотрите также" %}} 
- [Как использовать мастер‑слайд](/slides/ru/cpp/slide-master/)
{{% /alert %}}

### **Установить прозрачность формы водяного знака**

По умолчанию прямоугольная форма имеет заливку и цвет линий. Следующий код делает форму прозрачной.

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

### **Установить шрифт для текстового водяного знака**

Вы можете изменить шрифт текстового водяного знака, как показано ниже.

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

### **Установить цвет текста водяного знака**

Для установки цвета текста водяного знака используйте следующий код:

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

### **Центрировать текстовый водяной знак**

Можно центрировать водяной знак на слайде, для чего выполните следующее:

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

Изображение ниже показывает окончательный результат.

![Текстовый водяной знак](text_watermark.png)

## **Графический водяной знак**

### **Добавить графический водяной знак в презентацию**

Чтобы добавить графический водяной знак на слайд презентации, можно выполнить следующее:

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

## **Заблокировать водяной знак от редактирования**

Если необходимо предотвратить редактирование водяного знака, используйте метод [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/get_autoshapelock/) у формы. С помощью этого свойства можно защитить форму от выбора, изменения размера, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:

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

// Заблокировать форму водяного знака от изменения
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Переместить водяной знак на передний план**

В Aspose.Slides порядок наложения форм (Z‑order) можно задать с помощью метода [IShapeCollection::Reorder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/reorder/) . Для этого нужно вызвать этот метод из списка слайдов презентации, передав в него ссылку на форму и её порядковый номер. Таким образом можно переместить форму на передний план или отправить её на задний план слайда. Эта возможность особенно полезна, когда необходимо разместить водяной знак спереди презентации:

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

## **Установить вращение водяного знака**

Ниже приведён пример кода, показывающий, как изменить вращение водяного знака, чтобы он располагался по диагонали слайда:

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

## **Задать имя для водяного знака**

Aspose.Slides позволяет задавать имя формы. Используя имя формы, можно в дальнейшем получить к ней доступ для изменения или удаления. Чтобы задать имя форме водяного знака, присвойте его методу [IAutoShape::set_Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_name/) :

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

## **Удалить водяной знак**

Чтобы удалить форму водяного знака, используйте метод [IAutoShape::get_Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_name/) для её поиска среди форм слайда. Затем передайте форму водяного знака в метод [IShapeCollection::Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/remove/) :

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

## **Пример в реальном времени**

Возможно, вам будет интересна бесплатная онлайн‑утилита **Aspose.Slides free** для [добавления водяного знака](https://products.aspose.app/slides/ru/watermark) и [удаления водяного знака](https://products.aspose.app/slides/ru/watermark/remove-watermark) .

![Онлайн‑инструменты для добавления и удаления водяных знаков](online_tools.png)

## **FAQ**

### Что такое водяной знак и зачем его использовать?

Водяной знак — это наложенный поверх слайдов текст или изображение, который помогает защищать интеллектуальную собственность, повышать узнаваемость бренда или предотвращать несанкционированное использование презентаций.

### Можно ли добавить водяной знак ко всем слайдам презентации?

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Вы можете пройтись по всем слайдам и применить настройки водяного знака к каждому отдельно.

### Как можно изменить прозрачность водяного знака?

Вы можете изменить прозрачность водяного знака, изменив настройки заливки ([FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/get_fillformat/)) формы. Это обеспечивает мягкость водяного знака и не отвлекает внимание от содержимого слайда.

### Какие форматы изображений поддерживаются для водяных знаков?

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и другие.

### Можно ли настроить шрифт и стиль текстового водяного знака?

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и сохраняли согласованность бренда.

### Как изменить позицию или ориентацию водяного знака?

Вы можете программно изменить позицию и ориентацию водяного знака, изменяя координаты, размеры и свойства вращения формы.