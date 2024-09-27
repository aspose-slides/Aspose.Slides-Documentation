---
title: Манипуляции с Формами
type: docs
weight: 40
url: /ru/cpp/shape-manipulations/
---

## **Найти Форму на Слайде**
Эта тема описывает простую технику, которая упрощает разработчикам поиски определенной формы на слайде без использования ее внутреннего идентификатора. Важно знать, что файлы презентаций PowerPoint не имеют способа идентификации форм на слайде, кроме внутреннего уникального идентификатора. Разработчикам может быть сложно найти форму, используя ее внутренний уникальный идентификатор. Все формы, добавленные на слайды, имеют некоторый альтернативный текст. Мы предлагаем разработчикам использовать альтернативный текст для поиска определенной формы. Вы можете использовать MS PowerPoint для определения альтернативного текста для объектов, которые вы собираетесь изменить в будущем.

После установки альтернативного текста для любой желаемой формы вы можете открыть эту презентацию, используя Aspose.Slides для C++, и перебрать все формы, добавленные на слайд. Во время каждой итерации вы можете проверить альтернативный текст формы, и форма с совпадающим альтернативным текстом будет той формой, которая вам требуется. Чтобы продемонстрировать эту технику наилучшим образом, мы создали метод, [FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f), который выполняет поиск определенной формы на слайде и просто возвращает эту форму.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **Клонировать Форму**
Чтобы клонировать форму на слайд с использованием Aspose.Slides для C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Получите коллекцию форм исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте формы из коллекции форм исходного слайда на новый слайд.
1. Сохраните измененную презентацию в формате PPTX.

В приведенном ниже примере к слайду добавляется групповая форма.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **Удалить Форму**
Aspose.Slides для C++ позволяет разработчикам удалять любую форму. Чтобы удалить форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Найдите форму с определенным альтернативным текстом.
1. Удалите форму.
1. Сохраните файл на диске.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **Скрыть Форму**
Aspose.Slides для C++ позволяет разработчикам скрывать любую форму. Чтобы скрыть форму с любого слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Найдите форму с определенным альтернативным текстом.
1. Скрыть форму.
1. Сохраните файл на диске.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **Изменить Порядок Форм**
Aspose.Slides для C++ позволяет разработчикам изменять порядок форм. Изменение порядка форм определяет, какая форма находится впереди или сзади. Чтобы изменить порядок формы на любом слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Добавьте форму.
1. Добавьте некоторый текст в текстовую рамку формы.
1. Добавьте другую форму с теми же координатами.
1. Измените порядок форм.
1. Сохраните файл на диске.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **Получить Interop Shape ID**
Aspose.Slides для C++ позволяет разработчикам получать уникальный идентификатор формы в области слайда в контексте свойства UniqueId, которое позволяет получить уникальный идентификатор в области презентации. Свойство OfficeInteropShapeId было добавлено к интерфейсам IShape и классу Shape соответственно. Значение, возвращаемое свойством OfficeInteropShapeId, соответствует значению Id объекта Microsoft.Office.Interop.PowerPoint.Shape. Приведен пример кода.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **Установить Свойство AlternativeText**
Aspose.Slides для C++ позволяет разработчикам устанавливать альтернативный текст для любой формы. Чтобы установить альтернативный текст для формы, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Получите доступ к первому слайду.
1. Добавьте любую форму на слайд.
1. Выполните некоторые действия с вновь добавленной формой.
1. Переберите формы, чтобы найти нужную.
1. Установите альтернативный текст.
1. Сохраните файл на диске.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **Получить Форматы Макета для Формы**
Aspose.Slides для C++ позволяет разработчикам получать форматы макета для формы. Эта статья демонстрирует, как вы можете получить свойства **FillFormat** и **LineFormat** для формы.

Приведен пример кода.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Отобразить Форму как SVG**
Теперь Aspose.Slides для C++ поддерживает отображение формы как svg. Метод WriteAsSvg (и его перегрузка) был добавлен в класс Shape и интерфейс IShape. Этот метод позволяет сохранять содержимое формы в виде SVG-файла. Ниже приведен фрагмент кода, показывающий, как экспортировать форму слайда в SVG-файл.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Выравнивание Форм**
Aspose.Slides позволяет выравнивать формы либо относительно полей слайда, либо относительно друг друга. Для этой цели был добавлен перегруженный метод [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab). Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) определяет возможные параметры выравнивания.

**Пример 1**

Исходный код ниже выравнивает формы с индексами 1, 2 и 4 вдоль верхней границы слайда. 

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

Пример ниже показывает, как выровнять всю коллекцию форм относительно самой нижней формы в коллекции.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```