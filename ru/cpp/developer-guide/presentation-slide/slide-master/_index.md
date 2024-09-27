---
title: Мастер Слайдов
type: docs
weight: 80
url: /ru/cpp/slide-master/
keywords: "Добавить Мастер Слайдов, мастер-слайд PPT, мастер-слайд PowerPoint, изображение в Мастере Слайдов, Заполнитель, Несколько Мастеров Слайдов, Сравнить Мастера Слайдов, C++, CPP, Aspose.Slides для C++"
description: "Добавить или редактировать мастер слайдов в презентации PowerPoint на C++"
---

## **Что такое Мастер Слайдов в PowerPoint**

**Мастер Слайдов** — это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства для слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать мастер слайдов.

Мастер слайдов полезен тем, что позволяет настроить и изменить внешний вид всех слайдов презентации сразу. Aspose.Slides поддерживает механизм Мастера Слайдов из PowerPoint.

VBA также позволяет вам манипулировать Мастером Слайдов и выполнять те же операции, которые поддерживаются в PowerPoint: изменять фоны, добавлять формы, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы, позволяющие использовать Мастера Слайдов и выполнять с ними основные задачи.

Это основные операции с Мастером Слайдов:

- Создать или редактировать Мастер Слайдов.
- Применить Мастера Слайдов к слайдам презентации.
- Изменить фон Мастера Слайдов.
- Добавить изображение, заполнитель, Умное Искусство и т.д. в Мастер Слайдов.

Это более сложные операции с Мастером Слайдов:

- Сравнить Мастера Слайдов.
- Объединить Мастера Слайдов.
- Применить несколько Мастеров Слайдов.
- Скопировать слайд с Мастером Слайдов в другую презентацию.
- Найти дублирующиеся Мастера Слайдов в презентациях.
- Установить Мастер Слайдов как просмотр по умолчанию для презентации.

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться с Aspose [**Онлайн Просмотрщиком PowerPoint**](https://products.aspose.app/slides/viewer), потому что это живая реализация некоторых из основных процессов, описанных здесь.

{{% /alert %}} 

## **Как применяется Мастер Слайдов**

Перед тем как работать с мастером слайдов, вы можете захотеть понять, как они используются в презентациях и применяются к слайдам.

* Каждая презентация по умолчанию имеет хотя бы один Мастер Слайдов.
* Презентация может содержать несколько Мастеров Слайдов. Вы можете добавить несколько Мастеров Слайдов и использовать их для стилизации разных частей презентации различными способами.

В **Aspose.Slides** Мастер Слайдов представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide).

Объект [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Aspose.Slides содержит список [**get_Masters()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection), который содержит список всех мастер-слайдов, определенных в презентации.

Помимо операций CRUD, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) содержит следующие полезные методы: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) и [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311). Эти методы унаследованы от базовой функции клонирования слайдов. Но при работе с Мастерами Слайдов эти методы позволяют вам реализовать сложные настройки.

Когда новый слайд добавляется в презентацию, к нему автоматически применяется Мастер Слайдов. По умолчанию выбирается Мастер Слайдов предыдущего слайда.

**Примечание**: Слайды презентации хранятся в списке [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), и каждый новый слайд добавляется в конец коллекции по умолчанию. Если презентация содержит один Мастер Слайдов, этот мастер выбирается для всех новых слайдов. Вот почему вам не нужно определять Мастер Слайдов для каждого нового слайда, который вы создаете.

Принцип такой же как в PowerPoint, так и в Aspose.Slides. Например, в PowerPoint, когда вы добавляете новую презентацию, вы можете просто нажать на нижнюю линию под последним слайдом, и тогда будет создан новый слайд (с Мастером Слайдов последней презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить эквивалентную задачу с помощью метода [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

## **Мастер Слайдов в иерархии Слайдов**

Использование Макетов Слайдов с Мастером Слайдов обеспечивает максимальную гибкость. Макет Слайда позволяет установить все те же стили, что и Мастер Слайдов (фон, шрифты, формы и т.д.). Однако, когда несколько Макетов Слайдов комбинируются на Мастере Слайдов, создается новый стиль. Когда вы применяете Макет Слайда к одному слайду, вы можете изменить его стиль из того, который применен Мастером Слайдов.

Мастер Слайдов имеет более высокий приоритет, чем все элементы настройки: Мастер Слайдов -> Макет Слайда -> Слайд:

![todo:image_alt_text](slide-master_2)

Каждый [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) объект имеет свойство [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) с списком Макетов Слайдов. Тип [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) имеет свойство [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) с ссылкой на Макет Слайда, примененный к слайду. Взаимодействие между слайдом и Мастером Слайдов происходит через Макет Слайда.

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайдов (Мастер Слайдов, Макет Слайда и сам слайд) фактически являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).
* Следовательно, Мастер Слайдов и Макет Слайда могут реализовать одни и те же свойства, и вам нужно знать, как их значения будут применяться к объекту [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide). Мастер Слайдов применяется сначала к слайду, а потом применяется Макет Слайда. Например, если Мастер Слайдов и Макет Слайда оба имеют значение фона, слайд в конечном итоге получит фон от Макета Слайда.

{{% /alert %}}

## **Что включает в себя Мастер Слайдов**

Чтобы понять, как может быть изменен Мастер Слайдов, вам нужно знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/).

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - получить/установить фон слайда.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - получить/установить текстовые стили тела слайда.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - получить/установить все формы Мастера Слайдов (заполнители, рамки для изображений и т.д.).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - получить/установить элементы управления ActiveX.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - получить менеджер темы.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - получить менеджер заголовков и колонтитулов.

Методы Мастера Слайдов:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - получить все слайды, зависящие от Мастера Слайдов.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - позволяет создать новый Мастер Слайдов на основе текущего Мастера Слайдов и новой темы. Новый Мастер Слайдов затем будет применяться ко всем зависимым слайдам.

## **Получить Мастер Слайдов**

В PowerPoint доступ к Мастеру Слайдов можно получить из меню Вид -> Мастер Слайдов:

![todo:image_alt_text](slide-master_3.jpg)

Используя Aspose.Slides, вы можете получить доступ к Мастеру Слайдов таким образом:

```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```

Интерфейс [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) представляет Мастер Слайдов. Свойство [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (связанное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) содержит список всех Мастеров Слайдов, определенных в презентации.

## **Добавить изображение в Мастер Слайдов**

Когда вы добавляете изображение в Мастер Слайдов, это изображение появится на всех слайдах, зависящих от этого мастера слайдов.

Например, вы можете разместить логотип вашей компании и несколько изображений на Мастере Слайдов, а затем вернуться в режим редактирования слайдов. Вы должны увидеть изображение на каждом слайде.

![todo:image_alt_text](slide-master_4.png)

Вы можете добавить изображения в мастер слайдов с помощью Aspose.Slides:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" title="Смотрите также" %}} 

Для получения более подробной информации о добавлении изображений на слайд смотрите статью [Рамка для изображения](/slides/ru/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Добавить Заполнитель в Мастер Слайдов**

Эти текстовые поля являются стандартными заполнителями на Мастере Слайды:

* Нажмите для редактирования стиля заголовка Мастера

* Редактировать текстовые стили Мастера

* Второй уровень

* Третий уровень

Они также появляются на слайдах, основанных на Мастере Слайдов. Вы можете отредактировать эти заполнители на Мастере Слайдов, и изменения будут автоматически применены к слайдам.

В PowerPoint вы можете добавить заполнитель через путь Мастер Слайдов -> Вставить Заполнитель:

![todo:image_alt_text](slide-master_5.png)

Давайте рассмотрим более сложный пример для заполнителей с Aspose.Slides. Рассмотрим слайд с заполнителями, шаблонированными от Мастера Слайдов:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование Заголовка и Подзаголовка на Мастере Слайдов следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала мы извлекаем содержимое заполнителя заголовка из объекта Мастера Слайды, а затем используем поле `PlaceHolder.FillFormat`:

```c++
System::SharedPtr<IAutoShape> FindPlaceholder(System::SharedPtr<IMasterSlide> master, PlaceholderType type)
{
    for (auto& shape : master->get_Shapes())
    {
        System::SharedPtr<IAutoShape> autoShape = System::AsCast<Aspose::Slides::IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            if (autoShape->get_Placeholder()->get_Type() == type)
            {
                return autoShape;
            }
        }
    }
    return nullptr;
}

void Main()
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
    System::SharedPtr<IAutoShape> placeHolder = FindPlaceholder(master, Aspose::Slides::PlaceholderType::Title);
    auto fillFormat = placeHolder->get_FillFormat();
    fillFormat->set_FillType(Aspose::Slides::FillType::Gradient);
    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(Aspose::Slides::GradientShape::Linear);
    gradientFormat->get_GradientStops()->Add(0.0f, System::Drawing::Color::FromArgb(255, 0, 0));
    gradientFormat->get_GradientStops()->Add(255.0f, System::Drawing::Color::FromArgb(128, 0, 128));
    
    pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
}
```

Стиль и форматирование заголовка изменятся для всех слайдов, основанных на мастере слайдов:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Смотрите также" %}} 

* [Установить текст подсказки в Заполнителе](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Форматирование текста](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **Изменить фон на Мастере Слайдов**

Когда вы изменяете цвет фона мастер-слайда, все обычные слайды в презентации получат новый цвет. Этот код на C++ демонстрирует операцию:

```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="primary" title="Смотрите также" %}} 

- [Фон презентации](https://docs.aspose.com/slides/cpp/presentation-background/)

- [Тема презентации](https://docs.aspose.com/slides/cpp/presentation-theme/)

{{% /alert %}}

## **Клонировать Мастер Слайдов в другую презентацию**

Чтобы клонировать Мастер Слайдов в другую презентацию, вызовите метод [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) из целевой презентации вместе с Мастером Слайдов, переданным в него. Этот код на C++ показывает, как клонировать Мастер Слайдов в другую презентацию:

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```

## **Добавить несколько Мастеров Слайдов в презентацию**

Aspose.Slides позволяет добавлять несколько Мастеров Слайдов и Макетов Слайдов в любую данную презентацию. Это позволяет настраивать стили, макеты и параметры форматирования для слайдов презентации различными способами.

В PowerPoint вы можете добавить новые Мастера Слайдов и Макеты (из меню "Мастер Слайдов") следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

Используя Aspose.Slides, вы можете добавить новый Мастер Слайдов вызвав метод [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48):

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```

## **Сравнить Мастеров Слайдов**

Мастер Слайдов реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide), содержащий метод [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f), который затем может быть использован для сравнения слайдов. Он возвращает `true` для Мастеров Слайдов, идентичных по структуре и статическому содержимому.

Два Мастера Слайдов равны, если их формы, стили, тексты, анимация и другие настройки и т.д. равны. Сравнение не учитывает значения уникальных идентификаторов (например, SlideId) и динамическое содержимое (например, текущее значение даты в Заполнителе Даты). 

## **Установить Мастер Слайдов как вид по умолчанию для презентации**

Aspose.Slides позволяет установить Мастер Слайдов как вид по умолчанию для презентации. Вид по умолчанию — это то, что вы видите первым, когда открываете презентацию.

Этот код показывает, как установить Мастер Слайдов как вид по умолчанию для презентации на C++:

```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```

## **Удалить неиспользуемый Мастер Слайдов**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)), позволяющий удалить нежелательные и неиспользуемые мастер-слайды. Этот код C++ демонстрирует, как удалить мастер-слайд из презентации PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```