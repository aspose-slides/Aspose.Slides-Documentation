---
title: Управление фигурами презентации в C++
linktitle: Манипулирование фигурами
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
- Получить interop shape ID
- Альтернативный текст фигуры
- Точка регулировки фигуры
- Регулировка предустановленной фигуры
- Геометрия фигуры
- Форматы макета фигуры
- Фигура как SVG
- Фигура в SVG
- Выравнивание фигуры
- Отражение фигуры
- PowerPoint
- Презентация
- C++
- Aspose.Slides
description: "Узнайте, как идентифицировать, регулировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ представляет фигуры на слайде как упорядоченную [IShapeCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/). Коллекция является как местом, где вы находите и изменяете фигуры, так и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

В этой статье используется эта модель. Сначала объясняется, как надёжно идентифицировать фигуру и изменять предустановленные точки регулировки формы, затем показывается, как клонировать, удалять, скрывать и переупорядочивать фигуры. В заключительных разделах рассматриваются форматирование на уровне макета, экспорт в SVG, выравнивание и настройки отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые нужны вашему рабочему процессу.

## **Идентификация и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигур может изменить их индексы. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_name/) полезен для шаблонов, контролируемых разработчиком, и легко просматривается в панели выбора PowerPoint. Имена можно редактировать, но они не гарантируют уникальность, поэтому установите соглашение об именовании, если код от них зависит.
- [AlternativeText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_alternativetext/) удобен, когда описание доступности или тег, добавленный автором, уже идентифицирует фигуру. Оно видно пользователям, может быть локализовано или перезаписано для доступности и также не гарантирует уникальность. Не используйте осмысленный текст доступности в качестве ключа базы данных без явного согласования.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_officeinteropshapeid/) — только для чтения, уникален внутри слайда и соответствует идентификатору фигуры, используемому в PowerPoint interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный справочник в течение жизни фигуры. Клонированная или воссозданная фигура — это другая фигура и получает свой собственный идентификатор.

Связанное свойство [UniqueId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_uniqueid/) имеет область действия презентации, но предназначено для надстроек и может быть переопределено. Его не следует рассматривать как постоянный внешний ключ. Если требуется долговременная идентификация, храните сопоставление в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Практический пример чтения и обновления заголовка альтернативного текста и описания см. в статье [Manage Alternative Text Titles and Descriptions](/slides/ru/cpp/presentation-accessibility/). Используйте альтернативный текст, чтобы объяснить смысл визуального элемента читателям, и храните его отдельно от имён фигур, используемых кодом для их поиска.

Ниже приведён пример, ищущий по `Name` и выводящий межслайдовый interop‑ID. Когда шаблон не содержит ожидаемой фигуры, код выводит этот результат вместо продолжения работы с неправильным объектом.

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

Когда операция специфична для типа фигуры, проверьте интерфейс перед использованием членов, характерных для типа. Этот пример обновляет текст и альтернативный текст только если именованный объект является [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/).

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

## **Идентификация и изменение предустановленных регулировок фигур**

У фигур предустановленной геометрии могут быть точки регулировки, управляющие такими характеристиками, как размер угла, пропорции стрелки или угол дуги. Доступ к ним осуществляется через только‑для‑чтения коллекцию [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igeometryshape/get_adjustments/). Сама коллекция поставляется фигурой, но каждый [IAdjustValue](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iadjustvalue/) содержит значение, которое можно изменить.

Не полагайтесь только на фиксированный индекс коллекции. Пройдитесь по регулировкам и проверьте только‑для‑чтения свойство [IAdjustValue::get_Type](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iadjustvalue/get_type/), значение которого типа [ShapeAdjustmentType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapeadjustmenttype/) описывает, что регулирует данная настройка. Свойство только‑для‑чтения [IAdjustValue::get_Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iadjustvalue/get_name/) предоставляет дополнительную информацию для идентификации и особенно полезно, когда предустановка содержит более одной регулировки с одинаковым семантическим типом.

Используйте свойство значения, соответствующее смыслу регулировки:

| Тип регулировки | Назначение | Значение для изменения |
|---|---|---|
| `CornerSize` | Размер скруглённых углов | [RawValue](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Толщина хвоста стрелки | `RawValue` |
| `ArrowheadLength` | Длина наконечника стрелки | `RawValue` |
| `ArrowheadWidth` | Ширина наконечника стрелки | `RawValue` |
| `StartAngle` | Начальный угол сектора или дуги | [AngleValue](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Конечный угол сектора или дуги | `AngleValue` |

`Type` и `Name` нельзя назначать. `RawValue` — целое число с правом чтения/записи в родных единицах геометрии предустановки, в то время как `AngleValue` — угол в градусах с правом чтения/записи. Количество, порядок, смысл и допустимый диапазон регулировок зависят от предустановки [ShapeType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/igeometryshape/get_shapetype/). Значение, допустимое для одной предустановки, может быть недопустимым или иметь иной эффект для другой.

Когда `Type` — `ShapeAdjustmentType::Custom`, API не распознаёт стандартный семантический смысл. Проверьте `Name`, тип предустановки и существующее значение, и оставьте регулировку без изменений, если ожидаемый смысл и диапазон неизвестны. Даже для распознанных типов проверяйте, встречается ли тот же тип более одного раза, прежде чем выбирать значение. Статья [Connector](/slides/ru/cpp/connector/) демонстрирует эту ситуацию с регулировками изгибов соединителей.

Ниже полный пример, создающий стандартные и изменённые версии трёх предустановленных фигур. Он проходит по каждой регулировке, выводит её `Name` и `Type`, меняет размеры через `RawValue`, углы через `AngleValue` и сохраняет результат. Левая колонка сохраняет стандартную геометрию; правая показывает скорректированный закруглённый прямоугольник, четырёхстороннюю стрелку и сектор.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Добавляет заголовки для столбцов фигур по умолчанию и с изменёнными параметрами.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Проверка семантического типа перед изменением значения делает код явным в своих намерениях и избавляет от предположения, что определённый индекс коллекции имеет одинаковый смысл для разных предустановок фигур.

## **Модификация коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания работают с коллекцией немедленно. Если операция меняет количество или порядок фигур, не продолжайте полагаться на индексы, захваченные до этой операции.

### **Клонирование фигуры**

[AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/addclone/) создаёт независимую копию и добавляет её в конец целевой коллекции. [InsertClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/insertclone/) также создаёт копию, но помещает её по заданному индексу z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения его размера; перегрузки с шириной и высотой могут изменить его размер.

Пример создаёт целевой слайд, клонирует помеченный прямоугольник спереди и вставляет второй клон сзади. Изменения любого из клонов не влияют на исходную фигуру.

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

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новым логическим идентификаторам клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[Remove](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/remove/) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений во время итерации по индексам обходите коллекцию с конца, чтобы каждый оставшийся индекс оставался корректным.

В этом примере удаляются все фигуры с заданным именем. Он читает текущую фигурy по индексу, а не фиксированный элемент коллекции, и не выполняет ненужных привидений типа.

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

После удаления количество фигур и индексы последующих фигур меняются. Ссылки на неизменённые фигуры остаются надёжнее, чем сохранённые индексы. Также учитывайте соединители, анимации и другие элементы презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить не только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_hidden/) в `true` оставляет фигуру в коллекции, но препятствует её отображению в обычном показе слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для опциональных элементов, которые могут быть восстановлены позже.

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

Скрытие — это не удаление и не механизм безопасности. Объект всё ещё может быть найден и сделан видимым пользователем или кодом, и он остаётся частью файла презентации.

### **Изменение Z‑порядка**

Перекрывающиеся фигуры отрисовываются в порядке их расположения в коллекции. [Reorder](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `Count - 1` — передний.

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

Прямоугольник создаётся первым и изначально находится за эллипсом. Перемещение его к конечному индексу помещает его спереди. Завершайте настройку Z‑порядка после добавления или клонирования всех связанных фигур, поскольку эти операции добавляют или вставляют новые элементы коллекции и могут изменить задуманную стековость.

## **Просмотр фигур на макетных слайдах**

Обычные слайды, макетные слайды и слайды‑шаблоны имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогично расположенная фигура на обычном слайде. Анализируйте фигуры макета, когда необходимо понять или изменить форматирование, заданное макетом.

Следующий пример читает для каждой фигуры макета её [FillFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_fillformat/) и [LineFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/get_lineformat/) без предположения, что каждая фигура является `AutoShape`.

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

Редактирование макета может затронуть несколько слайдов, использующих его. Перед изменением фигуры макета определите, наследует ли обычный слайд объект или содержит локальное переопределение, и проверьте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/writeassvg/) записывает отрисованное содержимое одной фигуры в поток. Результат содержит только эту фигуру, а не фон всего слайда или соседние фигуры.

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

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Вызывающая сторона владеет потоком и должна закрыть или освободить его.

## **Выравнивание фигур**

Перегрузки [SlideUtil::AlignShapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/alignshapes/) выравнивают либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapesalignmenttype/) задаёт краёк, центральную линию или режим распределения. Установите `alignToSlide` в `true`, чтобы использовать края слайда; установите в `false`, чтобы выравнивать выбранные фигуры относительно друг друга.

Этот пример выравнивает три фигуры по верхнему краю слайда. Ссылка на фигуру приводится к её текущему индексу непосредственно перед выравниванием.

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

Выравнивание меняет позиции, а не Z‑порядок. Относительное выравнивание обычно требует как минимум две фигуры, тогда как горизонтальное или вертикальное распределение нуждается в достаточном количестве фигур для определения промежутков. Пересчитайте индексы, если изменяете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapeframe/) хранит позицию, размер, настройки горизонтального и вертикального отражения и вращения. Его свойства `FlipH` и `FlipV` используют [NullableBool](https://reference.aspose.com/slides/ru/cpp/aspose.slides/nullablebool/): `True` включает отражение, `False` отключает, а `NotDefined` сохраняет неустановленное/по‑умолчанию состояние.

Входная презентация ниже содержит одну неотражённую фигуру.

![The shape before flipping](shape_to_be_flipped.png)

Пример сохраняет все остальные значения кадра и меняет только две настройки отражения. Это важно, потому что присваивание нового [Frame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/set_frame/) заменяет полный кадр.

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

Сохранённая фигура отражена по горизонтали и вертикали, при этом сохраняются её позиция, размер и вращение.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Следует ли использовать индекс коллекции в качестве идентификатора фигуры?**

Только для краткосрочной обработки, когда коллекция не изменится до использования индекса. Предпочтительнее использовать проверенный `Name` или соглашение о `AlternativeText` для шаблонов, созданных вручную, либо `OfficeInteropShapeId` для работы с межслайдовым interop.

**Удаляет ли скрытие фигуры её из Z‑порядка?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно находить, переупорядочивать, редактировать или снова сделать видимой.

**Почему клон фигуры появился перед другой фигурой?**

`AddClone` добавляет клон в конец коллекции, а конец — передний слой Z‑порядка. Используйте `InsertClone`, чтобы задать начальный индекс, или `Reorder` после добавления всех фигур.

**Можно ли использовать фиксированный индекс для идентификации предустановленной регулировки фигуры?**

Только после проверки точной предустановки и раскладки коллекции. Предпочтительно итерировать `IGeometryShape::get_Adjustments` и проверять `IAdjustValue::get_Type`; используйте `IAdjustValue::get_Name` как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.