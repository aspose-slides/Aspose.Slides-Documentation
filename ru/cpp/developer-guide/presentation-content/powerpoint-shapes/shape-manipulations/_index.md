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
- Найти фигуру
- Клонировать фигуру
- Удалить фигуру
- Скрыть фигуру
- Изменить порядок фигур
- Получить Interop ID фигуры
- Альтернативный текст фигуры
- Форматы размещения фигуры
- Фигура в формате SVG
- Фигура в SVG
- Выровнять фигуру
- PowerPoint
- Презентация
- C++
- Aspose.Slides
description: "Узнайте, как создавать, редактировать и оптимизировать фигуры в Aspose.Slides для C++ и создавать высокопроизводительные презентации PowerPoint."
---

## **Найти объект на слайде**
Эта статья опишет простую технику, позволяющую разработчикам легче находить конкретный объект на слайде без использования его внутреннего Id. Важно знать, что файлы презентаций PowerPoint не предоставляют способа идентифицировать объекты на слайде, кроме внутреннего уникального Id. Разработчикам часто сложно находить объект по его внутреннему уникальному Id. Всем объектам, добавленным на слайды, присваивается некоторый альтернативный текст. Мы советуем использовать альтернативный текст для поиска конкретного объекта. Вы можете задать альтернативный текст объектам в MS PowerPoint, которые планируете изменять в будущем.

После задания альтернативного текста нужному объекту вы можете открыть эту презентацию с помощью Aspose.Slides for C++ и пройтись по всем объектам, добавленным на слайд. На каждой итерации можно проверять альтернативный текст объекта, и объект с совпадающим альтернативным текстом будет нужным вам объектом. Чтобы продемонстрировать эту технику, мы создали метод [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) , который ищет конкретный объект на слайде и возвращает его.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Клонирование объекта**
Для клонирования объекта на слайд с помощью Aspose.Slides for C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Доступ к коллекции объектов исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте объекты из коллекции объектов исходного слайда в новый слайд.
1. Сохраните изменённую презентацию в файл PPTX.

В примере ниже добавляется групповый объект на слайд.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Удаление объекта**
Aspose.Slides for C++ позволяет разработчикам удалять любые объекты. Чтобы удалить объект с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Найдите объект с определённым AlternativeText.
1. Удалите объект.
1. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Сокрытие объекта**
Aspose.Slides for C++ позволяет разработчикам скрывать любые объекты. Чтобы скрыть объект на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Найдите объект с определённым AlternativeText.
1. Сокройте объект.
1. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Изменение порядка объектов**
Aspose.Slides for C++ позволяет разработчикам переупорядочивать объекты. Переупорядочивание определяет, какой объект находится спереди, а какой — сзади. Чтобы изменить порядок объектов на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Добавьте объект.
1. Добавьте некоторый текст в текстовый фрейм объекта.
1. Добавьте другой объект с теми же координатами.
1. Переупорядочьте объекты.
1. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Получение Interop Shape ID**
Aspose.Slides for C++ позволяет разработчикам получать уникальный идентификатор объекта в пределах слайда, в отличие от свойства UniqueId, которое возвращает уникальный идентификатор в пределах всей презентации. Свойство OfficeInteropShapeId было добавлено к интерфейсам IShape и классу Shape. Значение, возвращаемое свойством OfficeInteropShapeId, соответствует значению Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведён пример кода.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **Установка свойства AlternativeText**
Aspose.Slides for C++ позволяет разработчикам задавать AlternateText любого объекта. Чтобы задать AlternateText для объекта, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Добавьте любой объект на слайд.
1. Выполните необходимые действия с только что добавленным объектом.
1. Пройдитесь по объектам, чтобы найти нужный.
1. Установите AlternativeText.
1. Сохраните файл на диск.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **Доступ к форматам размещения для объекта**
Aspose.Slides for C++ позволяет разработчикам получать доступ к форматам размещения для объекта. Эта статья демонстрирует, как получить свойства **FillFormat** и **LineFormat** объекта.

Ниже приведён пример кода.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Отрисовка объекта в формате SVG**
Теперь Aspose.Slides for C++ поддерживает рендеринг объекта в формате SVG. Метод WriteAsSvg (и его перегрузка) был добавлен к классу Shape и интерфейсу IShape. Этот метод позволяет сохранять содержимое объекта в SVG‑файл. Фрагмент кода ниже показывает, как экспортировать объект слайда в SVG‑файл.
``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```


## **Выравнивание объектов**
Aspose.Slides позволяет выравнивать объекты либо относительно полей слайда, либо относительно друг друга. Для этой цели была добавлена перегруженная версия метода [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) определяет возможные варианты выравнивания.

**Пример 1**

Исходный код ниже выравнивает объекты с индексами 1, 2 и 4 по верхнему краю слайда. 
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```


**Пример 2**

В примере ниже показано, как выровнять всю коллекцию объектов относительно самого нижнего объекта в коллекции.
``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```


## **Свойства зеркального отражения**

В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) предоставляет управление горизонтальным и вертикальным зеркальным отражением объектов через свои свойства `flipH` и `flipV`. Оба свойства имеют тип [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/), позволяющий задавать `True` для отражения, `False` — без отражения, или `NotDefined` для использования поведения по умолчанию. Эти значения доступны из [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) объекта.

Чтобы изменить настройки отражения, создаётся новый экземпляр [ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) с текущими позицией и размерами объекта, желаемыми значениями `flipH` и `flipV` и углом вращения. Присвоив этот экземпляр свойству [Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) объекта и сохранив презентацию, вы применяете зеркальные трансформации и фиксируете их в выходном файле.

Предположим, у нас есть файл sample.pptx, в котором первый слайд содержит один объект со настройками отражения по умолчанию, как показано ниже.

![The shape to be flipped](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения объекта и отражает его как по горизонтали, так и по вертикали.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Получить свойство горизонтального отражения формы.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Получить свойство вертикального отражения формы.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Отразить по горизонтали.
auto flipV = NullableBool::True; // Отразить по горизонтали.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Результат:

![The flipped shape](flipped_shape.png)

## **Вопросы и ответы**

**Можно ли объединять объекты (union/intersect/subtract) на слайде, как в настольном редакторе?**

Встроенного API для булевых операций нет. Можно приближённо реализовать это, построив нужный контур вручную — например, вычислив результирующую геометрию с помощью [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) и создав новый объект с этим контурами, при необходимости удалив исходные.

**Как управлять порядком наложения (z‑order), чтобы объект всегда оставался «на вершине»?**

Изменяйте порядок вставки/перемещения в коллекции [shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) слайда. Для предсказуемого результата выполните финализирующее изменение z‑order после всех остальных правок слайда.

**Можно ли «запереть» объект, чтобы пользователи не могли редактировать его в PowerPoint?**

Да. Установите флаги защиты на уровне объекта / shape (например, блокировать выбор, перемещение, изменение размера, редактирование текста). При необходимости примените аналогичные ограничения к мастеру или макету. Учтите, что это защита на уровне UI, а не безопасность; для более надёжной защиты комбинируйте с ограничениями на уровне файла, такими как рекомендации «только для чтения» или пароли.