---
title: Управление шаблонами слайдов презентаций в C++
linktitle: Шаблон слайда
type: docs
weight: 80
url: /ru/cpp/slide-master/
keywords:
- шаблон слайда
- главный слайд
- шаблон слайда PPT
- несколько шаблонов слайдов
- сравнение шаблонов слайдов
- фон
- заполнитель
- клонирование шаблона слайда
- копирование шаблона слайда
- дублирование шаблона слайда
- неиспользуемый шаблон слайда
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управление шаблонами слайдов в Aspose.Slides для C++: доступ, редактирование, клонирование, сравнение и удаление шаблонов слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Шаблон слайда** определяет общие настройки дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, настройки темы и настройки подвала. В PowerPoint редактирование шаблона слайда — обычный способ сохранить согласованность презентации без повторения одного и того же форматирования на каждом слайде.

Aspose.Slides for C++ поддерживает ту же модель. Презентация может содержать один или несколько master slide, и каждый master slide может содержать несколько layout slide. Обычные слайды обычно не ссылаются напрямую на master slide. Вместо этого обычный слайд использует layout slide, который принадлежит master slide.

Иерархия выглядит так:

1. **Шаблон слайда** — определяет общий дизайн и тему.  
2. **Макетный слайд** — определяет конкретное расположение заполнителей и форматирование уровня макета.  
3. **Обычный слайд** — содержит фактическое содержание презентации и использует один макетный слайд.

![Иерархия шаблонов слайдов, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides шаблон слайда представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/) . Все master slide в презентации доступны через коллекцию [Presentation::get_Masters](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_masters/) , реализующую [IMasterSlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Если одно и то же свойство определено на более чем одном уровне, приоритет имеет более специфичный уровень. Например, если master slide и layout slide оба определяют фон, слайды, основанные на этом макете, используют фон макета. Для получения дополнительной информации о layout slide см. [Применение или изменение макетов слайдов](/slides/ru/cpp/slide-layout/).
{{% /alert %}}

## **Доступ к шаблонам слайдов**

В PowerPoint можно открыть представление шаблона слайда через **View** > **Slide Master**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `get_Masters()` для доступа к master slide:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

Также можно получить master slide, используемый обычным слайдом, через его макет:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Что содержит шаблон слайда**

Master slide — это объект, похожий на слайд. Он реализует [IBaseSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/), поэтому предоставляет многие свойства слайда, используемые обычными и layout slide. Специфические для master slide члены перечислены на странице API [IMasterSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslide/) .

Часто используемые члены master slide включают:

| Член | Назначение |
| --- | --- |
| `get_Background()` | Устанавливает фон слайда уровня master. |
| `get_Shapes()` | Хранит фигуры, размещённые на master, такие как логотипы, рамки изображений и общий текст. |
| `get_LayoutSlides()` | Хранит layout slide, принадлежащие master. |
| `get_ThemeManager()` | Обеспечивает доступ к API темы master. |
| `get_HeaderFooterManager()` | Управляет колонтитулами, датами и номерами слайдов для master и его дочерних layout. |
| `GetDependingSlides()` | Возвращает обычные слайды, зависящие от master через их layout. |

## **Добавление изображения в шаблон слайда**

Когда вы добавляете изображение в master slide, оно появляется на слайдах, использующих макеты из этого master. Это полезно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип к первому master slide:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Для получения дополнительной информации о рамках изображений см. [Рамка изображения](/slides/ru/cpp/picture-frame/) .

## **Работа с заполнителями**

Заполнители обычно определяются на layout slide. Шаблон слайда предоставляет общий стиль и тему, которые наследуются этими макетами, а каждый макет определяет, какие заполнители доступны и где они размещаются.

В PowerPoint команды заполнителей доступны в представлении Slide Master.

![Команда Insert Placeholder в представлении Slide Master PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с layout slide, который принадлежит master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Вы также можете форматировать формы заполнителей, уже существующие в master slide. Следующий пример находит заполнитель заголовка и применяет линейную градиентную заливку:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Отформатированный заполнитель заголовка, унаследованный обычными слайдами](slide-master_8.png)

Для получения дополнительных вариантов форматирования заполнителей и текста см. [Установка текста подсказки в заполнителе](/slides/ru/cpp/manage-placeholder/) и [Форматирование текста](/slides/ru/cpp/text-formatting/) .

## **Изменение фона шаблона слайда**

Фон master наследуется макетами и слайдами, которые его не переопределяют. Следующий пример задаёт сплошной цвет фона для первого master slide:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Для связанных тем см. [Фон презентации](/slides/ru/cpp/presentation-background/) и [Тема презентации](/slides/ru/cpp/presentation-theme/) .

## **Клонирование шаблона слайда в другую презентацию**

Используйте [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imasterslidecollection/addclone/) , чтобы скопировать master slide в другую презентацию. Скопированный master затем может использоваться макетами и слайдами в целевой презентации.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Если нужно клонировать обычные слайды вместе с их master, см. [Clone Slides](/slides/ru/cpp/clone-slides/) .

## **Добавление нескольких шаблонов слайдов**

Презентация может содержать несколько master slide. Это полезно, когда разные разделы требуют различного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления шаблонами слайдов](slide-master_9.jpg)

Следующий пример клонирует шаблон по умолчанию, задаёт клону другой фон, создаёт layout под этим клонированным master и добавляет новый слайд на основе этого layout:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Сравнение шаблонов слайдов**

Master slide можно сравнить с помощью метода `Equals`, унаследованного от [IBaseSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibaseslide/) . Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, такие как ID слайдов, или динамические значения заполнителей, например текущую дату.

```cpp
auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

Для получения дополнительной информации см. [Сравнение слайдов презентации](/slides/ru/cpp/compare-slides/) .

## **Установка представления шаблона слайда как представления по умолчанию**

Используйте метод `set_LastView` на [ViewProperties](https://reference.aspose.com/slides/ru/cpp/aspose.slides/viewproperties/) , чтобы задать представление, которое PowerPoint открывает первым. Следующий пример открывает презентацию в представлении Slide Master:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Для дополнительных настроек представления см. [Сохранить презентацию](/slides/ru/cpp/save-presentation/) .

## **Удаление неиспользуемых шаблонов слайдов**

Иногда презентации содержат master slide, которые больше не используются ни одним обычным слайдом. Удаление неиспользуемых master может уменьшить размер файла и упростить поддержку шаблона.

Используйте [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/ru/cpp/aspose.slides/masterslidecollection/removeunused/) , чтобы удалить неиспользуемые master из коллекции `get_Masters()` :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Вы также можете воспользоваться методом low‑code [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Часто задаваемые вопросы**

**В чём разница между шаблоном слайда и макетным слайдом?**

Шаблон слайда определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит шаблону слайда и определяет конкретное расположение заполнителей. Обычный слайд использует макетный слайд, поэтому наследует свойства как от макета, так и от шаблона.

**Может ли одна презентация содержать несколько шаблонов слайдов?**

Да. Презентация может содержать несколько master slide. Используйте несколько master, когда разные разделы требуют разных визуальных систем или брендинга.

**Стоит ли добавлять заполнители в шаблон слайда или в макетный слайд?**

В большинстве случаев заполняйте заполнители в макетных слайдах. Общие визуальные элементы и общие форматы размещайте в шаблоне слайда, а заполнители содержимого — в макетах, которые будут использовать обычные слайды.

**Можно ли удалить шаблон слайда, который всё ещё используется?**

Нет. Шаблон слайда, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в макеты под другим шаблоном или используйте метод очистки неиспользуемых master, который удаляет только те master, которые не используются.