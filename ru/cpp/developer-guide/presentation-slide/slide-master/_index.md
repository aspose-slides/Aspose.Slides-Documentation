---
title: Главный слайд
type: docs
weight: 80
url: /cpp/главный-слайд/
keywords: "Добавить главный слайд, мастер-слайд PPT, мастер-слайд PowerPoint, изображение в мастер-слайд, заполнитель, несколько мастер-слайдов, сравнить мастер-слайды, C++, CPP, Aspose.Slides для C++"
description: "Добавьте или измените главный слайд в презентации PowerPoint на C++"
---

## **Что такое главный слайд в PowerPoint**

**Главный слайд** — это шаблон слайда, который определяет макет, стили, темы, шрифты, фон и другие свойства для слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать мастер-слайд.

Мастер-слайд полезен тем, что позволяет вам задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм мастер-слайда из PowerPoint.

VBA также позволяет вам манипулировать мастер-слайдом и выполнять те же операции, которые поддерживаются в PowerPoint: изменять фоны, добавлять фигуры, настраивать макет и т. д. Aspose.Slides предоставляет гибкие механизмы, чтобы позволить вам использовать мастер-слайды и выполнять основные задачи с ними.

Вот основные операции с мастер-слайдами:

- Создать или изменить мастер-слайд.
- Применить мастер-слайды к слайдам презентации.
- Изменить фон мастер-слайда.
- Добавить изображение, заполнитель, Smart Art и т. д. в мастер-слайд.

Вот более сложные операции с мастер-слайдами:

- Сравнить мастер-слайды.
- Объединить мастер-слайды.
- Применить несколько мастер-слайдов.
- Скопировать слайд с мастер-слайдом в другую презентацию.
- Найти дублирующиеся мастер-слайды в презентациях.
- Установить мастер-слайд как вид по умолчанию для презентации.

{{% alert color="primary" %}} 

Вам может быть интересно ознакомиться с Aspose [**Онлайн-просмотрщиком PowerPoint**](https://products.aspose.app/slides/viewer), так как это живая реализация некоторых основных процессов, описанных здесь.

{{% /alert %}} 

## **Как применяется мастер-слайд**

Перед тем как работать с мастер-слайдом, вам может быть полезно понять, как они используются в презентациях и применяются к слайдам.

* Каждая презентация по умолчанию имеет как минимум один мастер-слайд.
* Презентация может содержать несколько мастер-слайдов. Вы можете добавить несколько мастер-слайдов и использовать их для оформления различных частей презентации по-разному.

В **Aspose.Slides** мастер-слайд представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide).

Объект Aspose.Slides [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) содержит список [**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection), который содержит список всех мастер-слайдов, определенных в презентации.

Помимо операций CRUD, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) содержит эти полезные методы: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) и [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311). Эти методы наследуются от базовой функции клонирования слайдов. Но при работе с мастер-слайдами эти методы позволяют реализовать сложные настройки.

Когда новый слайд добавляется в презентацию, к нему автоматически применяется мастер-слайд. По умолчанию выбирается мастер-слайд предыдущего слайда.

**Примечание**: Слайды презентации хранятся в списке [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), и каждый новый слайд по умолчанию добавляется в конец коллекции. Если в презентации есть единственный мастер-слайд, то этот мастер-слайд будет выбран для всех новых слайдов. По этой причине вам не нужно определять мастер-слайд для каждого нового создаваемого слайда.

Принцип тот же для PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новую презентацию, вы можете просто нажать на нижнюю строку под последним слайдом, и тогда будет создан новый слайд (с мастер-слайдом последней презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить эквивалентную задачу с помощью метода [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) в классе [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

## **Мастер-слайд в иерархии слайдов**

Использование макетов слайдов с мастер-слайдом позволяет достичь максимальной гибкости. Макет слайда позволяет задать все те же стили, что и мастер-слайд (фон, шрифты, фигуры и т. д.). Однако, когда несколько макетов слайдов комбинируются на мастер-слайде, создаётся новый стиль. Когда вы применяете макет слайда к одному слайду, вы можете изменить его стиль на тот, который применён мастер-слайдом.

Мастер-слайд имеет преимущество над всеми элементами настройки: Мастер-слайд -> Макет слайда -> Слайд:

![todo:image_alt_text](slide-master_2)

Каждый объект [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) имеет свойство [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) с списком макетов слайдов. Тип [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) имеет свойство [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) с ссылкой на макет слайда, применённый к слайду. Взаимодействие между слайдом и мастер-слайдом происходит через макет слайда.

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайдов (мастер-слайд, макет слайда и сам слайд) фактически являются объектами слайда, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).
* Поэтому мастер-слайд и макет слайда могут реализовывать одни и те же свойства, и вам нужно знать, как их значения будут применяться к объекту [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide). Мастер-слайд применяется сначала к слайду, а затем применяется макет слайда. Например, если у мастер-слайда и макета слайда есть значение фона, то слайд в конечном итоге получит фон от макета слайда.

{{% /alert %}}

## **Что включает в себя мастер-слайд**

Чтобы понять, как может измениться мастер-слайд, вам нужно знать его составные части. Вот основные свойства [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/).

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - получить/установить фон слайда.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - получить/установить стили текста тела слайда.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - получить/установить все фигуры мастер-слайда (заполнители, рамки для изображений и т. д.).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - получить/установить элементы управления ActiveX.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - получить менеджер темы.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - получить менеджер заголовков и подвалов.

Методы мастер-слайда:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - получить все слайды, зависящие от мастер-слайда.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - позволяет создать новый мастер-слайд на основе текущего мастер-слайда и новой темы. Новый мастер-слайд затем будет применен ко всем зависимым слайдам.

## **Получить мастер-слайд**

В PowerPoint мастер-слайд можно получить через меню Вид -> Мастер-слайд:

![todo:image_alt_text](slide-master_3.jpg)

Используя Aspose.Slides, вы можете получить мастер-слайд следующим образом:

```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```

Интерфейс [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) представляет собой мастер-слайд. Свойство [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (связанное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) содержит список всех мастер-слайдов, определённых в презентации.

## **Добавить изображение в мастер-слайд**

Когда вы добавляете изображение в мастер-слайд, это изображение появится на всех слайдах, зависимых от этого мастер-слайда.

Например, вы можете разместить логотип вашей компании и несколько изображений на мастер-слайде, а затем вернуться в режим редактирования слайдов. Вы должны видеть изображение на каждом слайде.

![todo:image_alt_text](slide-master_4.png)

Вы можете добавить изображения в мастер-слайд с помощью Aspose.Slides:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" title="Смотрите также" %}} 

Для получения дополнительной информации о добавлении изображений на слайд смотрите статью [Рамка для изображения](/slides/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Добавить заполнитель в мастер-слайд**

Эти текстовые поля являются стандартными заполнителями на мастер-слайде:

* Нажмите, чтобы изменить стиль заголовка мастера
* Изменить стили текста мастера
* Второй уровень
* Третий уровень

Они также появляются на слайдах, основанных на мастер-слайде. Вы можете редактировать эти заполнители на мастер-слайде, и изменения будут автоматически применены к слайдам.

В PowerPoint вы можете добавить заполнитель через путь Мастер-слайд -> Вставить заполнитель:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример для заполнителей с Aspose.Slides. Рассмотрим слайд с заполнителями, созданными на основе мастер-слайда:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подписи на мастер-сайте следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала мы получаем содержимое заполнителя заголовка из объекта мастер-слайда, а затем используем поле `PlaceHolder.FillFormat`:

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

Стиль и форматирование заголовка изменятся для всех слайдов, основанных на мастер-слайде:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Смотрите также" %}} 

* [Установить текст подсказки в заполнитель](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Форматирование текста](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **Изменить фон на мастер-слайде**

Когда вы изменяете цвет фона мастер-слайда, все обычные слайды в презентации получают новый цвет. Этот код на C++ демонстрирует операцию:

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

## **Клонировать мастер-слайд в другую презентацию**

Чтобы клонировать мастер-слайд в другую презентацию, вызовите метод [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) из целевой презентации вместе с мастер-слайдом, переданным в него. Этот код на C++ показывает, как клонировать мастер-слайд в другую презентацию:

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```

## **Добавить несколько мастер-слайдов в презентацию**

Aspose.Slides позволяет добавлять несколько мастер-слайдов и макетов в любую презентацию. Это позволяет настраивать стили, макеты и параметры форматирования для слайдов презентации разными способами.

В PowerPoint вы можете добавить новые мастер-слайды и макеты (из меню Мастер-слайд) следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

Используя Aspose.Slides, вы можете добавить новый мастер-слайд, вызвав метод [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48):

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```

## **Сравнить мастер-слайды**

Мастер-слайд реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide), содержащий метод [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f), который может использоваться для сравнения слайдов. Он возвращает `true` для мастер-слайдов, идентичных по структуре и статическому содержимому.

Два мастер-слайда равны, если их фигуры, стили, тексты, анимации и другие настройки и т. д. равны. Сравнение не учитывает значения уникальных идентификаторов (например, SlideId) и динамическое содержимое (например, текущее значение даты в заполнитель даты).

## **Установить мастер-слайд как вид по умолчанию для презентации**

Aspose.Slides позволяет установить мастер-слайд в качестве вида по умолчанию для презентации. Вид по умолчанию — это то, что вы видите в первую очередь при открытии презентации.

Этот код покажет вам, как установить мастер-слайд как вид по умолчанию для презентации на C++:

```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```

## **Удалить неиспользуемый мастер-слайд**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)), который позволяет вам удалить нежелательные и неиспользуемые мастер-слайды. Этот код на C++ показывает, как удалить мастер-слайд из презентации PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```