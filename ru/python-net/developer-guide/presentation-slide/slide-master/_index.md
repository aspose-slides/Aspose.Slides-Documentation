---  
title: Управление слайд-мастерами PowerPoint в Python  
linktitle: Слайд-мастер  
type: docs  
weight: 80  
url: /ru/python-net/slide-master/  
keywords:  
- слайд-мастер  
- мастер-слайд  
- PPT-мастер-слайд  
- несколько мастер-слайдов  
- сравнение мастер-слайдов  
- фон  
- заполнитель  
- клонирование мастер-слайда  
- копирование мастер-слайда  
- дублирование мастер-слайда  
- неиспользуемый мастер-слайд  
- Python  
- Aspose.Slides  
description: "Автоматизируйте работу с слайд-мастерами PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, чтобы максимизировать эффективность разработки. Полное руководство для начинающих и опытных пользователей."  
---

## **Обзор**

**Slide Master** — это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать **Slide Master**.

**Slide Master** полезен тем, что позволяет задать и изменить внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм **Slide Master** PowerPoint.

VBA также позволяет управлять **Slide Master** и выполнять те же операции, что поддерживает PowerPoint: изменять фон, добавлять фигуры, настраивать макеты и т.д. Aspose.Slides предоставляет гибкие API, которые позволяют работать с **Slide Master** и выполнять типичные задачи.

Это базовые операции с **Slide Master**:

- Создать **Slide Master**.
- Применить **Slide Master** к слайдам презентации.
- Изменить фон **Slide Master**.
- Добавить изображение, заполнитель, SmartArt и т.п. к **Slide Master**.

Это более продвинутые операции, связанные с **Slide Master**:

- Сравнивать **Slide Master**.
- Объединять **Slide Master**.
- Применять несколько **Slide Master**.
- Копировать слайд вместе с его **Slide Master** в другую презентацию.
- Выявлять дублирующиеся **Slide Master** в презентациях.
- Установить **Slide Master** как представление презентации по умолчанию.

{{% alert color="primary" %}}
Возможно, вам будет интересно посмотреть Aspose [Online PowerPoint Viewer](https://products.aspose.app/slides/viewer), так как он представляет живую реализацию некоторых из описанных здесь основных процессов.
{{% /alert %}}

## **Как применяется Slide Master**

Перед тем как работать с **Slide Master**, вам может быть полезно понять, как **Slide Master** используются в презентациях и применяются к слайдам.

- Каждая презентация имеет как минимум один **Slide Master** по умолчанию.
- Презентация может содержать несколько **Slide Master**. Вы можете добавить несколько **Slide Master** и использовать их для стилизации разных частей презентации разными способами.

В Aspose.Slides **Slide Master** представлен типом [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

Объект Aspose.Slides [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) содержит коллекцию [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) типа [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/), в которой хранятся все мастер‑слайды, определённые в презентации.

Помимо CRUD‑операций, класс [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) предоставляет полезные методы, такие как [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) и [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/insert_clone/). Они расширяют базовую функциональность клонирования слайдов и, при работе с **Slide Master**, позволяют реализовать более сложные настройки.

Когда в презентацию добавляется новый слайд, к нему автоматически применяется **Slide Master**. По умолчанию выбирается **Slide Master** предыдущего слайда.

**Примечание:** Слайды презентации хранятся в коллекции [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/), и каждый новый слайд добавляется в конец этой коллекции по умолчанию. Если в презентации присутствует единственный **Slide Master**, он будет выбран для всех новых слайдов. По этой причине вам не нужно указывать **Slide Master** для каждого создаваемого слайда.

Тот же принцип работает в PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новый слайд, вы можете кликнуть область под последним слайдом, и будет создан новый слайд (использующий **Slide Master** предыдущего слайда).

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить эквивалентную задачу, используя метод [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) класса [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).

## **Slide Master в иерархии Slides**

Использование **Slide Layouts** совместно с **Slide Master** предоставляет максимальную гибкость. **Slide Layout** может определять те же типы стилей, что и **Slide Master** (фон, шрифты, фигуры и т.д.). Когда под **Slide Master** определено несколько **Slide Layout**, они совместно образуют единую систему стилей. Применяя **Slide Layout** к отдельному слайду, вы можете корректировать его стиль относительно того, что предоставляет **Slide Master**.

Приоритет следующий: **Slide Master** → **Slide Layout** → **Slide**.

![todo:image_alt_text](slide-master_2.jpg)

Каждый объект [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) имеет свойство [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/), содержащее список макетов слайдов. У объекта [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) есть свойство [layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/), которое ссылается на применённый к нему макет слайда. Взаимодействие между слайдом и **Slide Master** происходит через его **Slide Layout**.

{{% alert color="info" title="Note" %}}
- В Aspose.Slides все построения слайдов (Slide Master, Slide Layout и сам слайд) являются объектами слайдов, наследующими класс [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/).
- Поскольку **Slide Master** и **Slide Layout** раскрывают многие одинаковые свойства, вам необходимо знать, как их значения применяются к объекту [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Сначала применяется **Slide Master**, затем **Slide Layout**. Например, если и **Slide Master**, и **Slide Layout** задают фон, слайд использует фон из **Slide Layout**.
{{% /alert %}}

## **Из чего состоит Slide Master**

Чтобы понять, как можно изменять **Slide Master**, необходимо знать его компоненты. Это основные свойства [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/):

- `background` — получает/устанавливает фон слайда.
- `body_style` — получает/устанавливает стили текста тела слайда.
- `shapes` — получает/устанавливает все фигуры на **Slide Master** (заполнители, рамки изображений и т.д.).
- `controls` — получает/устанавливает элементы управления ActiveX.
- `theme_manager` — получает менеджер темы.
- `header_footer_manager` — получает менеджер верхнего и нижнего колонтитула.

Методы **Slide Master**:

- `get_depending_slides()` — возвращает все слайды, зависящие от данного **Slide Master**.
- `apply_external_theme_to_depending_slides(fname)` — создаёт новый **Slide Master** на основе текущего и внешней темы, затем применяет новый **Slide Master** ко всем зависимым слайдам.

## **Получить Slide Master**

В PowerPoint доступ к **Slide Master** осуществляется через **View** → **Slide Master**:

![todo:image_alt_text](slide-master_3.jpg)

С помощью Aspose.Slides вы можете получить **Slide Master** следующим образом:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Получить первый мастер‑слайд в презентации.
    master_slide = presentation.masters[0]
```


Класс [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) представляет **Slide Master**. Свойство [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) (это [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) содержит все **Slide Master**, определённые в презентации.

## **Добавить изображение в Slide Master**

Когда вы добавляете изображение в **Slide Master**, оно появляется на всех слайдах, зависящих от данного мастера.

Например, разместите логотип вашей компании или другие изображения на **Slide Master**, затем вернитесь в обычный режим просмотра. Вы увидите изображение на каждом зависимом слайде.

![todo:image_alt_text](slide-master_4.png)

Вы можете добавить изображения в **Slide Master** с помощью Aspose.Slides:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    with open("image.png", "rb") as image_stream:
        image = presentation.images.add_image(image_stream.read())

    master_slide = presentation.masters[0]
    master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="See also" %}}
Для получения дополнительной информации о добавлении изображений в слайд см. статью [Add Picture Frames to Presentations with Python](/slides/ru/python-net/picture-frame/).
{{% /alert %}}

## **Добавить заполнитель в Slide Master**

Эти текстовые поля — стандартные заполнители на **Slide Master**:

- Click to edit Master title style
- Edit Master text styles
- Second level
- Third level

Эти заполнители также отображаются на слайдах, основанных на **Slide Master**. Вы можете редактировать их на **Slide Master**, и изменения автоматически применятся к слайдам.

В PowerPoint добавить заполнитель можно через **Slide Master** → **Insert Placeholder**:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример заполнителей в Aspose.Slides. Предположим, есть слайд с заполнителями, унаследованными от **Slide Master**:

![todo:image_alt_text](slide-master_6.png)

Нужно обновить форматирование заголовка и подзаголовка на **Slide Master** следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала получаем заполнитель заголовка из **Slide Master**, затем используем свойство `PlaceHolder.fill_format`:
```python
# Получить ссылку на заполнитель заголовка мастер‑слайда.
title_placeholder = master_slide.shapes[0]

# Установить тип заливки градиентом.
title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
title_placeholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
title_placeholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
title_placeholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```


Стиль и форматирование заголовка изменятся на всех слайдах, основанных на **Slide Master**:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}}
* [Manage Placeholders in Presentations with Python](/slides/ru/python-net/manage-placeholder/)
* [Format PowerPoint Text in Python](/slides/ru/python-net/text-formatting/)
{{% /alert %}}

## **Изменить фон Slide Master**

Когда вы меняете цвет фона **Slide Master**, все обычные слайды в презентации наследуют новый цвет. Ниже приведён пример кода на Python:

```python
master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
master_slide.background.fill_format.fill_type = slides.FillType.SOLID
master_slide.background.fill_format.solid_fill_color.color = draw.Color.gray
```


{{% alert color="primary" title="See also" %}}
- [Manage Presentation Backgrounds in Python](/slides/ru/python-net/presentation-background/)
- [Manage PowerPoint Presentation Themes in Python](/slides/ru/python-net/presentation-theme/)
{{% /alert %}}

## **Добавить несколько Slide Masters в презентацию**

Aspose.Slides позволяет добавлять несколько **Slide Master** и **Slide Layout** в любую презентацию. Это даёт возможность настраивать стили, макеты и параметры форматирования слайдов разными способами.

В PowerPoint новые **Slide Master** и **Slide Layout** можно добавить через меню **Slide Master** следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

С помощью Aspose.Slides вы можете добавить новый **Slide Master**, вызвав метод `add_clone`:
```python
# Добавить новый мастер‑слайд.
master_slide2 = presentation.masters.add_clone(master_slide1)
```


## **Сравнить Slide Masters**

**Slide Master** наследует класс [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), который включает метод `equals(slide)` для сравнения слайдов. Этот метод возвращает **true**, когда **Slide Masters** идентичны по структуре и статическому содержимому.

Два **Slide Master** считаются равными, если их фигуры, стили, тексты, анимации и другие настройки совпадают. При сравнении игнорируются уникальные идентификаторы (например, `slide_id`) и динамическое содержимое (например, текущая дата в заполнителе даты).

## **Установить Slide Master как представление презентации по умолчанию**

Aspose.Slides позволяет установить **Slide Master** как представление презентации по умолчанию. Представление по умолчанию — это то, что пользователь видит первым при открытии презентации. Ниже пример на Python, показывающий, как установить **Slide Master** как представление по умолчанию:

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:
    # Установить представление по умолчанию как представление мастера слайдов.
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Сохранить презентацию.
    presentation.save("presentation_view.pptx", slides.export.SaveFormat.PPTX)
```


## **Удалить неиспользуемый Master Slide**

Aspose.Slides предоставляет метод `remove_unused_master_slides` (в классе [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) для удаления нежелательных, неиспользуемых мастер‑слайдов. Ниже пример кода на Python, показывающий, как удалить неиспользуемые мастер‑слайды из презентации PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Что такое Slide Master в PowerPoint?**

**Slide Master** — это шаблон слайда, который определяет макет, стили, темы, шрифты, фон и другие свойства слайдов в презентации. Он позволяет задать и изменить внешний вид всех слайдов презентации сразу.

**Как Slide Masters связаны с Slide Layouts?**

**Slide Layouts** работают совместно с **Slide Master**, обеспечивая гибкость в дизайне слайдов. Пока **Slide Master** задаёт глобальные стили и темы, [Slide Layouts](/slides/ru/python-net/slide-layout/) позволяют варьировать расположение контента. Иерархия выглядит так:

- **Slide Master** → определяет глобальные стили.
- **Slide Layout** → предоставляет различные варианты расположения контента.
- **Slide** → наследует дизайн от своего **Slide Layout**.

**Можно ли иметь несколько Slide Masters в одной презентации?**

Да, презентация может содержать несколько **Slide Masters**. Это позволяет стилизовать разные секции презентации различными способами, предоставляя гибкость в дизайне.  

**Как получить доступ к Slide Master и изменить его с помощью Aspose.Slides?**

В Aspose.Slides **Slide Master** представлен классом [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Вы можете получить **Slide Master**, используя свойство [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) объекта [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).