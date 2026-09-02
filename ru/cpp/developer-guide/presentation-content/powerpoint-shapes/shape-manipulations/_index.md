---
title: Управление фигурами презентации в C++
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/cpp/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Поиск фигуры
- Клонирование фигуры
- Удаление фигуры
- Скрытие фигуры
- Изменение порядка фигур
- Получение ID фигуры interop
- Альтернативный текст фигуры
- Форматы макета фигуры
- Фигура как SVG
- Экспорт фигуры в SVG
- Выравнивание фигуры
- Отражение фигуры
- PowerPoint
- Презентация
- C++
- Aspose.Slides
description: "Узнайте, как идентифицировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ представляет элементы на слайде как упорядоченную [IShapeCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/). Коллекция является как местом, где вы находите и модифицируете элементы, так и источником их порядка наложения: индекс `0` — это самый задний элемент, а последний индекс — самый передний.

Эта статья следует этой модели. Сначала она объясняет, как надёжно определить элемент, затем показывает, как клонировать, удалять, скрывать и переупорядочить элементы. В заключительных разделах рассматриваются форматирование уровня макета, экспорт в SVG, выравнивание и параметры отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые требуются вашему рабочему процессу.

## **Определение и поиск элементов**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание элемента могут изменить его индекс. Выберите идентификатор в соответствии с тем, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_name/) полезно для шаблонов, контролируемых разработчиком, и легко просматривается в панели выбора PowerPoint. Имена можно редактировать, и они не гарантированно уникальны, поэтому установите соглашение об именовании, если код зависит от них.
- [AlternativeText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_alternativetext/) полезно, когда описание доступности или тег, предоставленный автором, уже идентифицирует элемент. Оно видно пользователям, может быть локализовано или переписано для доступности и не гарантированно уникально. Не переиспользуйте без уведомления значимый текст доступности в качестве ключа базы данных.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_officeinteropshapeid/) — это идентификатор только для чтения, уникальный в пределах слайда и соответствующий ID элемента, используемому в PowerPoint interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный ссылка в течение жизни элемента. Клонированный или воссозданный элемент — это другой элемент и получает собственный ID.

Связанное свойство [UniqueId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_uniqueid/) имеет область действия презентации, но предназначено для надстроек и может быть переназначено. Его не следует рассматривать как постоянный внешний ключ. Если долгосрочная идентичность важна, храните отображение в данных приложения и проверяйте, что ожидаемый элемент всё ещё существует.

Следующий пример ищет по `Name` и выводит ID interop в пределах слайда. Когда шаблон не содержит ожидаемого элемента, код выводит этот результат вместо продолжения с неверным объектом.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Когда операция специфична для типа элемента, проверьте интерфейс перед использованием членов, специфичных для типа. Этот пример обновляет текст и альтернативный текст только если именованный объект является [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Изменение коллекции элементов**

Методы добавления, клонирования, удаления и переупорядочивания действуют на коллекцию сразу. Если операция меняет количество или порядок элементов, не продолжайте полагаться на индексы, зафиксированные до этой операции.

### **Клонирование элемента**

[AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addclone/) создаёт независимую копию и добавляет её в целевую коллекцию. [InsertClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/insertclone/) также создаёт копию, но размещает её по заданному индексу порядка Z. Перегрузки, принимающие координаты, перемещают клон без изменения его размера; перегрузки с шириной и высотой могут также изменить размер.

В примере создаётся целевой слайд, клонируется подписанный прямоугольник на передний план и вставляется второй клон в задний план. Изменения любого из клонов не изменяют исходный элемент.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Клонирование копирует содержимое и форматирование элемента, включая его имя и альтернативный текст. Присваивайте новые логические идентификаторы клону, когда эти значения должны быть уникальными. Ресурсы, используемые сложными элементами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью.

### **Удаление элементов**

[Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/remove/) удаляет конкретный объект элемента из его коллекции. При удалении нескольких совпадений во время итерации по индексам перебирайте элементы с конца, чтобы каждый оставшийся индекс оставался валидным.

В этом примере удаляются все элементы с заданным именем. Он считывает текущий элемент по индексу, а не фиксированный элемент коллекции, и не приводит тип элемента без необходимости.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

После удаления количество элементов и индексы последующих элементов изменяются. Ссылки на не затронутые элементы остаются надёжнее, чем сохранённые индексы. Также учитывайте соединители, анимации и другие функции презентации, которые могут ссылаться на удалённый объект; удаление видимого элемента может изменить больше, чем внешний вид слайда.

### **Скрытие элемента**

Установка [Hidden](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_hidden/) в `true` оставляет элемент в коллекции, но предотвращает его отображение в обычной демонстрации слайдов. Его индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Скрытие не является удалением или механизмом защиты. Объект всё ещё может быть найден и раскрыт пользователем или кодом, и он остаётся частью файла презентации.

### **Изменение порядка Z**

Перекрывающиеся элементы отрисовываются в порядке коллекции. [Reorder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/reorder/) перемещает существующий элемент к целевому индексу без его клонирования. Индекс `0` — это задний план; `Count - 1` — передний.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Прямоугольник создаётся первым и изначально находится за эллипсом. Перемещение его к конечному индексу помещает его впереди. Завершайте порядок Z после добавления или клонирования всех связанных элементов, поскольку эти операции добавляют или вставляют новые элементы коллекции и могут изменить задуманную очередь.

## **Проверка элементов на макетных слайдах**

Обычные слайды, макетные слайды и слайды‑шаблоны имеют отдельные коллекции элементов. Элемент в коллекции макета не является тем же объектом, что аналогично расположенный элемент на обычном слайде. Проверяйте элементы макета, когда нужно понять или изменить форматирование, предоставленное макетом.

Следующий пример считывает [FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_fillformat/) и [LineFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_lineformat/) каждого элемента макета, не предполагая, что каждый элемент является `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Редактирование макета может затронуть несколько слайдов, которые его используют. Перед изменением элемента макета определите, наследует ли обычный слайд объект или содержит локальное переопределение, и проверьте каждый слайд, использующий этот макет.

## **Экспорт элемента в SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/writeassvg/) записывает отрисованное содержимое одного элемента в поток. Результат содержит только элемент, а не весь фон слайда или соседние элементы.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Оставляйте презентацию открытой во время рендеринга. Вывод зависит от форматирования элемента и ресурсов, таких как шрифты и изображения. Если требуется вся композиция, экспортируйте слайд, а не отдельный элемент. Поток принадлежит вызывающему коду, который должен закрыть или освободить его.

## **Выравнивание элементов**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/alignshapes/) имеет перегрузки, выравнивающие либо все элементы, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapesalignmenttype/) указывает край, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; установите в `false`, чтобы выравнивать выбранные элементы относительно друг друга.

В этом примере три элемента выравниваются по верхнему краю слайда. Возвращённые ссылки на элементы преобразуются в их текущие индексы непосредственно перед выравниванием.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Выравнивание меняет позиции, а не порядок Z. Относительное выравнивание обычно требует как минимум два элемента, тогда как горизонтальное или вертикальное распределение нуждаются в достаточном количестве элементов для определения промежутков. Пересчитайте индексы, если вы изменяете коллекцию перед вызовом метода.

## **Отражение элемента**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapeframe/) хранит положение, размер, настройки горизонтального и вертикального отражения и вращение. Его значения `FlipH` и `FlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/cpp/aspose.slides/nullablebool/): `True` включает отражение, `False` отключает его, а `NotDefined` сохраняет неуказанное/значение по умолчанию.

Входная презентация ниже содержит один неотражённый элемент.

![Элемент до отражения](shape_to_be_flipped.png)

В примере сохраняются все остальные значения кадра, заменяются только две настройки отражения. Это важно, поскольку присваивание нового [Frame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_frame/) заменяет весь кадр.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Сохранённый элемент зеркально отражён по горизонтали и вертикали, при этом сохраняются его положение, размер и вращение.

![Элемент после отражения](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции в качестве идентификатора элемента?**

Только для кратковременной обработки, когда коллекция не изменится до использования индекса. Предпочтительно использовать проверенную конвенцию `Name` или `AlternativeText` для созданных шаблонов, либо `OfficeInteropShapeId` для работы с interop в рамках слайда.

**Убирает ли скрытие элемента его из порядка Z?**

Нет. Скрытый элемент остаётся в коллекции на том же индексе. Его можно найти, переупорядочить, отредактировать или вновь сделать видимым.

**Почему клонированный элемент оказался перед другим элементом?**

`AddClone` добавляет клон в конец коллекции, что соответствует переднему плану порядка Z. Используйте `InsertClone`, чтобы выбрать начальный индекс, или `Reorder` после того, как все элементы были добавлены.