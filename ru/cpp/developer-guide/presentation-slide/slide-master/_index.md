---
title: Управление мастерами слайдов презентации в C++
linktitle: Мастер слайда
type: docs
weight: 80
url: /ru/cpp/slide-master/
keywords:
- мастер слайда
- мастер слайда
- мастер слайда PPT
- множество мастеров слайдов
- сравнение мастеров слайдов
- фон
- заполнитель
- клонировать мастер слайда
- копировать мастер слайда
- дублировать мастер слайда
- неиспользуемый мастер слайда
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управление мастерами слайдов в Aspose.Slides для C++: создание, редактирование и применение макетов, тем и заполнителей к файлам PPT, PPTX и ODP с помощью лаконичных примеров на C++."
---

## **Что такое мастер-слайд в PowerPoint**

**Мастер-слайд** — это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создавать презентацию (или серию презентаций) в едином стиле и шаблоне для вашей компании, вы можете использовать мастер-слайд. 

Мастер-слайд полезен, потому что позволяет задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм мастера-слайдов из PowerPoint. 

VBA также позволяет управлять мастером-слайдом и выполнять те же операции, что поддерживаются в PowerPoint: менять фон, добавлять фигуры, настраивать макет и т.д. Aspose.Slides предоставляет гибкие механизмы, позволяющие использовать мастеры-слайдов и выполнять базовые задачи с ними. 

Базовые операции с мастером-слайдом:

- Создать мастер-слайд.
- Применить мастер-слайд к слайдам презентации.
- Изменить фон мастера-слайда. 
- Добавить изображение, заполнитель, Smart Art и т.п. к мастеру-слайду.

Более продвинутые операции, связанные с мастером-слайдом: 

- Сравнить мастеры-слайды.
- Объединить мастеры-слайды.
- Применить несколько мастеров-слайдов.
- Скопировать слайд с мастером-слайдом в другую презентацию.
- Найти дублирующиеся мастеры-слайды в презентациях.
- Установить мастер-слайд как представление по умолчанию для презентации.

{{% alert color="primary" %}} 
Возможно, вам будет интересно попробовать Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer), так как это живой пример некоторых из описанных здесь процессов.
{{% /alert %}} 

## **Как применяется мастер-слайд**

Прежде чем работать с мастером-слайдом, стоит понять, как они используются в презентациях и применяются к слайдам. 

* Каждая презентация имеет по крайней мере один мастер-слайд по умолчанию. 
* Презентация может содержать несколько мастеров-слайдов. Вы можете добавить несколько мастеров-слайдов и использовать их, чтобы стилизовать разные части презентации по‑разному. 

В **Aspose.Slides** мастер-слайд представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide). 

Объект Aspose.Slides [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) содержит список [**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection), который содержит список всех мастер‑слайдов, определённых в презентации. 

Помимо CRUD‑операций, интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) содержит полезные методы: [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) и [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311). Эти методы унаследованы от базовой функции клонирования слайдов. Но при работе с мастерами‑слайдов они позволяют реализовать сложные настройки. 

Когда в презентацию добавляется новый слайд, к нему автоматически применяется мастер‑слайд. По умолчанию выбирается мастер‑слайд предыдущего слайда. 

**Примечание**: Слайды презентации хранятся в списке [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), и каждый новый слайд добавляется в конец коллекции по умолчанию. Если презентация содержит один мастер‑слайд, этот мастер‑слайд будет выбран для всех новых слайдов. Это объясняет, почему вам не нужно задавать мастер‑слайд для каждого нового слайда. 

Принцип одинаков для PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новый слайд, достаточно кликнуть на строку под последним слайдом, и будет создан новый слайд (с мастером‑слайда последней презентации):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить то же действие с помощью метода [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).

## **Мастер‑слайд в иерархии Slides**

Использование макетов слайдов вместе с мастером‑слайдом обеспечивает максимальную гибкость. Макет слайда позволяет задать все те же стили, что и мастер‑слайд (фон, шрифты, фигуры и т.п.). Однако когда несколько макетов слайдов комбинируются в мастере‑слайде, создаётся новый стиль. При применении макета к отдельному слайду вы можете изменить его стиль, отличающийся от стиля, заданного мастером‑слайдом.

Мастер‑слайд превышает по приоритету все элементы настройки: Мастер‑слайд → Макет‑слайда → Слайд:

![todo:image_alt_text](slide-master_2)

Каждый объект [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) имеет свойство [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) со списком макетов слайдов. Тип [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) имеет свойство [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8), указывающее на макет‑слайда, применённый к слайду. Взаимодействие между слайдом и мастером‑слайдом происходит через макет‑слайда.

{{% alert color="info" title="Note" %}}
* В Aspose.Slides все настройки слайда (мастер‑слайд, макет‑слайда и сам слайд) являются объектами слайдов, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide).
* Поэтому мастер‑слайд и макет‑слайда могут реализовать одинаковые свойства, и вам нужно знать, как их значения будут применяться к объекту [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide). Сначала к слайду применяется мастер‑слайд, затем — макет‑слайда. Например, если и мастер‑слайд, и макет‑слайда задают значение фона, в итоге у слайда будет фон из макета‑слайда.
{{% /alert %}}

## **Из чего состоит мастер‑слайд**

Чтобы понять, как можно изменить мастер‑слайд, необходимо знать его составные части. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/):

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) — получить/установить фон слайда.
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) — получить/установить стили текста тела слайда.
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) — получить/установить все фигуры мастера‑слайда (заполнители, рамки изображений и т.п.).
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) — получить/установить элементы ActiveX.
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) — получить менеджер тем.
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) — получить менеджер колонтитулов.

Методы мастера‑слайда:

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) — получить все слайды, зависящие от мастера‑слайда.
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) — позволяет создать новый мастер‑слайд на основе текущего и новой темы. Новый мастер‑слайд затем будет применён ко всем зависимым слайдам.

## **Получить мастер‑слайд**

В PowerPoint мастер‑слайд доступен через меню Вид → Мастер‑слайд:

![todo:image_alt_text](slide-master_3.jpg)

С помощью Aspose.Slides вы можете получить мастер‑слайд так:
```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```


Интерфейс [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) представляет мастер‑слайд. Свойство [get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) (относящееся к типу [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)) содержит список всех мастер‑слайдов, определённых в презентации. 

## **Добавить изображение в мастер‑слайд**

Когда вы добавляете изображение в мастер‑слайд, оно будет отображаться на всех слайдах, зависящих от этого мастера. 

Например, вы можете разместить логотип компании и несколько изображений на мастере‑слайде, а затем вернуться в режим редактирования слайдов. Вы увидите изображение на каждом слайде. 

![todo:image_alt_text](slide-master_4.png)

Вы можете добавить изображения в мастер‑слайд с помощью Aspose.Slides:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 
Для получения дополнительной информации о добавлении изображений на слайд см. статью [Picture Frame](/slides/ru/cpp/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Добавить заполнитель в мастер‑слайд**

Эти текстовые поля являются стандартными заполнителями на мастере‑слайде: 

* Щёлкните, чтобы изменить стиль заголовка мастера
* Изменить стили текста мастера
* Второй уровень
* Третий уровень 

Они также отображаются на слайдах, основанных на мастере‑слайде. Вы можете редактировать эти заполнители на мастере‑слайде, и изменения автоматически применятся к слайдам. 

В PowerPoint вы можете добавить заполнитель через путь Мастер‑слайда → Вставить заполнитель:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей с Aspose.Slides. Представьте слайд с заполнителями, шаблонными из мастера‑слайда:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка на мастере‑слайде следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем содержимое заполнителя заголовка из объекта мастера‑слайда и затем используем поле `PlaceHolder.FillFormat`:
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


Стиль и форматирование заголовка изменятся для всех слайдов, основанных на данном мастере‑слайде:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/cpp/text-formatting/)
{{% /alert %}}

## **Изменить фон на мастере‑слайде**

Когда вы меняете цвет фона мастер‑слайда, все обычные слайды презентации получают новый цвет. Этот C++‑код демонстрирует операцию:
```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/cpp/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/cpp/presentation-theme/)
{{% /alert %}}

## **Клонировать мастер‑слайд в другую презентацию**

Чтобы клонировать мастер‑слайд в другую презентацию, вызовите метод [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) из целевой презентации, передав в него мастер‑слайд. Этот C++‑код показывает, как клонировать мастер‑слайд в другую презентацию:
```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```


## **Добавить несколько мастеров‑слайдов в презентацию**

Aspose.Slides позволяет добавить несколько мастеров‑слайдов и макетов‑слайдов в любую презентацию. Это даёт возможность задавать стили, макеты и параметры форматирования слайдов множеством способов. 

В PowerPoint вы можете добавить новые мастера‑слайды и макеты (через меню «Мастер‑слайд») так:

![todo:image_alt_text](slide-master_9.jpg)

С помощью Aspose.Slides вы можете добавить новый мастер‑слайд, вызвав метод [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48):
```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```


## **Сравнить мастера‑слайды**

Мастер‑слайд реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide), содержащий метод [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f), который можно использовать для сравнения слайдов. Он возвращает `true` для мастеров‑слайдов, идентичных по структуре и статическому содержимому. 

Два мастера‑слайда считаются равными, если их фигуры, стили, тексты, анимация и другие настройки совпадают. При сравнении не учитываются уникальные идентификаторы (например, SlideId) и динамическое содержимое (например, текущая дата в заполнителе даты). 

## **Установить мастер‑слайд как представление по умолчанию для презентации**

Aspose.Slides позволяет установить мастер‑слайд как представление по умолчанию для презентации. Представление по умолчанию — то, что вы видите в первую очередь, открывая презентацию. 

Этот код показывает, как установить мастер‑слайд как представление по умолчанию презентации в C++:
```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```


## **Удалить неиспользуемые мастеры‑слайды**

Aspose.Slides предоставляет метод [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (из класса [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)), позволяющий удалить нежелательные и неиспользуемые мастеры‑слайды. Этот C++‑код показывает, как удалить мастер‑слайд из презентации PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Что такое мастер‑слайд в PowerPoint?**

Мастер‑слайд — шаблон слайда, определяющий макет, стили, темы, шрифты, фон и другие свойства слайдов в презентации. Он позволяет задать и изменить внешний вид всех слайдов презентации одновременно.  

**Как применяется мастер‑слайд в презентации?**

Каждая презентация имеет минимум один мастер‑слайд по умолчанию. При добавлении нового слайда к нему автоматически применяется мастер‑слайд, обычно наследующий мастер предыдущего слайда. Презентация может содержать несколько мастеров‑слайдов для уникального стилизования разных частей.  

**Какие элементы можно настраивать в мастер‑слайде?**

Мастер‑слайд состоит из нескольких основных свойств, которые можно настроить:

- **Background**: установить фон слайда.
- **BodyStyle**: задать стили текста тела слайда.
- **Shapes**: управлять всеми фигурами на мастере‑слайде, включая заполнители и рамки изображений.
- **Controls**: работать с элементами ActiveX.
- **ThemeManager**: получить доступ к менеджеру тем.
- **HeaderFooterManager**: управлять колонтитулами.  

**Как добавить изображение в мастер‑слайд?**

Добавление изображения в мастер‑слайд гарантирует, что оно появится на всех слайдах, зависящих от этого мастера. Например, размещение логотипа компании на мастере‑слайде отобразит его на каждом слайде презентации.  

**Как мастера‑слайды соотносятся с макетами‑слайдов?**

Макеты‑слайдов работают совместно с мастерами‑слайдов, обеспечивая гибкость дизайна. Мастер‑слайд задаёт глобальные стили и темы, а макеты‑слайдов позволяют варьировать расположение контента. Иерархия выглядит так:

- **Мастер‑слайд** → задаёт глобальные стили.
- **Макет‑слайда** → предоставляет различные варианты расположения контента.
- **Слайд** → наследует дизайн от своего макета‑слайда.

**Можно ли иметь несколько мастеров‑слайдов в одной презентации?**

Да, презентация может содержать несколько мастеров‑слайдов. Это позволяет стилизовать разные разделы презентации по‑разному, обеспечивая гибкость дизайна.  

**Как получить доступ к мастер‑слайду и изменить его с помощью Aspose.Slides?**

В Aspose.Slides мастер‑слайд представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/). Вы можете получить мастер‑слайд, вызвав метод [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) объекта [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).