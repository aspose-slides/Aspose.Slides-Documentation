---
title: Управляйте образцами слайдов PowerPoint в Python
linktitle: Образец слайда
type: docs
weight: 80
url: /ru/python-net/slide-master/
keywords:
- образец слайда
- мастер-слайд
- образец слайда PPT
- несколько образцов слайдов
- сравнение образцов слайдов
- фон
- заполнитель
- клонировать образец слайда
- копировать образец слайда
- дублировать образец слайда
- неиспользуемый образец слайда
- Python
- Aspose.Slides
description: "Автоматизируйте работу с образцами слайдов PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET, чтобы максимизировать эффективность разработки. Полное руководство для начинающих и продвинутых пользователей."
---

## **Что такое слайд-мастер в PowerPoint**

**Слайд-Мастер** — это шаблон слайда, который определяет макет, стили, тему, шрифты, фон и другие свойства слайдов в презентации. Если вы хотите создать презентацию (или серию презентаций) с одинаковым стилем и шаблоном для вашей компании, вы можете использовать слайд-мастер.

Слайд-мастер полезен, потому что позволяет вам устанавливать и изменять внешний вид всех слайдов презентации одновременно. Aspose.Slides поддерживает механизм слайд-мастера из PowerPoint.

VBA также позволяет вам управлять слайд-мастером и выполнять те же операции, которые поддерживаются в PowerPoint: изменять фоны, добавлять фигуры, настраивать макет и т. д. Aspose.Slides предоставляет гибкие механизмы для использования слайд-мастера и выполнения базовых задач с ними.

Вот основные операции с слайд-мастером:

- Создать или редактировать слайд-мастер.
- Применить слайд-мастер к слайдам презентации.
- Изменить фон слайд-мастера.
- Добавить изображение, заполнитель, Smart Art и т. д. на слайд-мастер.

Вот более сложные операции с слайд-мастерами:

- Сравнить слайд-мастеры.
- Объединить слайд-мастеры.
- Применить несколько слайд-мастеров.
- Скопировать слайд с слайд-мастером в другую презентацию.
- Найти дублирующие слайд-мастеры в презентациях.
- Установить слайд-мастер как вид по умолчанию для презентации.

{{% alert color="primary" %}} 

Вы можете проверить Aspose [**Онлайн просмотрщик PowerPoint**](https://products.aspose.app/slides/viewer), так как это живая реализация некоторых основных процессов, описанных здесь.

{{% /alert %}} 

## **Как применяется слайд-мастер**

Прежде чем работать со слайд-мастером, вам может быть полезно понять, как они используются в презентациях и применяются к слайдам.

* Каждая презентация по умолчанию имеет как минимум один слайд-мастер.
* Презентация может содержать несколько слайд-мастеров. Вы можете добавить несколько слайд-мастеров и использовать их для стилизации различных частей презентации различными способами.

В **Aspose.Slides** слайд-мастер представлен типом [**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/).

Объект [Презентация](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Aspose.Slides содержит список [**masters**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) типа [**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/), который содержит список всех мастер-слайдов, определенных в презентации.

Кроме CRUD-операций интерфейс [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) содержит следующие полезные методы: [**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) и [**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/). Эти методы унаследованы от базовой функции клонирования слайдов. Но при работе со слайд-мастерами эти методы позволяют реализовать сложные настройки.

Когда новый слайд добавляется в презентацию, слайд-мастер автоматически применяется к нему. По умолчанию выбирается слайд-мастер предыдущего слайда.

**Примечание**: Слайды презентации хранятся в списке [Слайды](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), и каждый новый слайд по умолчанию добавляется в конец коллекции. Если в презентации содержится только один слайд-мастер, этот слайд-мастер будет выбран для всех новых слайдов. Поэтому вам не нужно определять слайд-мастер для каждого нового слайда, который вы создаете.

Принцип такой же для PowerPoint и Aspose.Slides. Например, в PowerPoint, когда вы добавляете новую презентацию, вы можете просто нажать на нижнюю границу под последним слайдом, и затем будет создан новый слайд (с последним слайдом-мастером):

![todo:image_alt_text](slide-master_1.jpg)

В Aspose.Slides вы можете выполнить аналогичную задачу с помощью метода [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) из класса [Презентация](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

## **Слайд-мастер в иерархии слайдов**

Использование макетов слайдов с слайд-мастером обеспечивает максимальную гибкость. Макет слайда позволяет устанавливать все те же стили, что и слайд-мастер (фон, шрифты, фигуры и т. д.). Однако, когда несколько макетов слайдов комбинируются на слайд-мастере, создается новый стиль. Когда вы применяете макет слайда к отдельному слайду, вы можете изменить его стиль, отличая от примененного слайд-мастером.

Слайд-мастер имеет более высокий приоритет, чем все элементы настроек: Слайд-мастер -> Макет слайда -> Слайд:

![todo:image_alt_text](slide-master_2)

Каждый [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) имеет свойство [**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) со списком макетов слайдов. Тип [Слайд](https://reference.aspose.com/slides/python-net/aspose.slides/slide) имеет свойство [**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) с ссылкой на макет слайда, примененный к слайду. Взаимодействие между слайдом и слайд-мастером происходит через макет слайда.

{{% alert color="info" title="Примечание" %}}

* В Aspose.Slides все настройки слайдов (слайд-мастер, макет слайда и сам слайд) фактически являются объектами слайда, реализующими интерфейс [**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/).
* Поэтому слайд-мастер и макет слайда могут реализовывать одни и те же свойства, и вам нужно понимать, как их значения будут применяться к объекту [Слайд](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Сначала слайд-мастер применяется к слайду, а затем применяется макет слайда. Например, если слайд-мастер и макет слайда оба имеют значение фона, слайд в итоге будет иметь фон от макета слайда.

{{% /alert %}}

## **Что включает в себя слайд-мастер**

Чтобы понять, как можно изменить слайд-мастер, необходимо знать его составные части. Вот основные свойства [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/).

- `background` получить/установить фон слайда.
- `body_style` получить/установить текстовые стили тела слайда.
- `shapes` получить/установить все фигуры слайд-мастера (заполнители, рамки для изображений и т. д.).
- `controls` - получить/установить элементы управления ActiveX.
- `theme_manager` - получить менеджер тем.
- `header_footer_manager` - получить менеджер заголовков и подвалов.

Методы слайд-мастера:

- `get_depending_slides()` - получить все слайды, зависимые от слайд-мастера.
- `apply_external_theme_to_depending_slides(fname)` - позволяет создать новый слайд-мастер на основе текущего слайд-мастера и новой темы. Новый слайд-мастер потом будет применен ко всем зависимым слайдам.

## **Получить слайд-мастер**

В PowerPoint слайд-мастер можно получить через меню Вид -> Слайд-мастер:

![todo:image_alt_text](slide-master_3.jpg)

Используя Aspose.Slides, вы можете получить доступ к слайд-мастеру следующим образом:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    # Получаем доступ к мастер-слайду презентации
    masterSlide = pres.masters[0]
```

Интерфейс [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) представляет слайд-мастер. Свойство `masters` (связанное с типом [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) содержит список всех слайд-мастеров, определенных в презентации.

## **Добавить изображение на слайд-мастер**

Когда вы добавляете изображение на слайд-мастер, это изображение появится на всех слайдах, зависящих от этого слайд-мастера.

Например, вы можете разместить логотип вашей компании и несколько изображений на слайд-мастере, а затем вернуться в режим редактирования слайдов. Вы должны увидеть изображение на каждом слайде.

![todo:image_alt_text](slide-master_4.png)

Вы можете добавлять изображения на слайд-мастер с помощью Aspose.Slides:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = pres.images.add_image(open("image.png", "rb").read())
    pres.masters[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" title="См. также" %}} 

Для получения дополнительной информации о добавлении изображений на слайд, см. статью [Рамка изображения](/slides/ru/python-net/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Добавить заполнитель на слайд-мастер**

Эти текстовые поля являются стандартными заполнителями на слайд-мастере:

* Нажмите для редактирования стиля заголовка мастера

* Редактировать стили текста мастера

* Второй уровень

* Третий уровень

Они также появляются на слайдах, основанных на слайд-мастере. Вы можете редактировать эти заполнители на слайд-мастере, и изменения будут автоматически применены к слайдам.

В PowerPoint вы можете добавить заполнитель через путь Слайд-мастер -> Вставить заполнитель:

![todo:image_alt_text](slide-master_5.png)

Рассмотрим более сложный пример для заполнителей с помощью Aspose.Slides. Рассмотрим слайд с заполнителями, шаблонированными с слайд-мастера:

![todo:image_alt_text](slide-master_6.png)

Мы хотим изменить форматирование заголовка и подзаголовка на слайд-мастере следующим образом:

![todo:image_alt_text](slide-master_7.png)

Сначала мы извлекаем содержимое заполнителя заголовка из объекта слайд-мастера, а затем используем поле `PlaceHolder.FillFormat`:

```python
# Получаем ссылку на заполнители заголовка мастера
titlePlaceholder = masterSlide.shapes[0]

# Устанавливаем формат заполнения как градиентное заполнение
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```

Стиль и форматирование заголовка изменятся для всех слайдов, основанных на слайд-мастере:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="См. также" %}} 

* [Установить текст подсказки в заполнителе](https://docs.aspose.com/slides/python-net/manage-placeholder/)
* [Форматирование текста](https://docs.aspose.com/slides/python-net/text-formatting/)

{{% /alert %}}

## **Изменить фон на слайд-мастере**

Когда вы изменяете цвет фона слайд-мастера, все обычные слайды в презентации получат новый цвет. Этот код на Python демонстрирует операцию:

```python
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="См. также" %}} 

- [Фон презентации](https://docs.aspose.com/slides/python-net/presentation-background/)

- [Тема презентации](https://docs.aspose.com/slides/python-net/presentation-theme/)

  {{% /alert %}}

## **Клонировать слайд-мастер в другую презентацию**

Чтобы клонировать слайд-мастер в другую презентацию, вызовите метод `add_clone(source_slide, dest_master, allow_clone_missing_layout)` из целевой презентации рядом с переданным слайд-мастером. Этот код на Python показывает, как клонировать слайд-мастер в другую презентацию:

```python
# Добавляет новый слайд-мастер 
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **Добавить несколько слайд-мастеров в презентацию**

Aspose.Slides позволяет добавлять несколько слайд-мастеров и макетов слайдов в любую данную презентацию. Это позволяет настраивать стили, макеты и параметры форматирования для слайдов презентации различными способами.

В PowerPoint вы можете добавить новые слайд-мастеры и макеты (из меню "Слайд-мастер") следующим образом:

![todo:image_alt_text](slide-master_9.jpg)

Используя Aspose.Slides, вы можете добавить новый слайд-мастер, вызвав метод `add_clone`:

```python
# Добавляет новый слайд-мастер
secondMasterSlide = pres.masters.add_clone(masterSlide)
```

## **Сравнить слайд-мастеры**

Слайд-мастер реализует интерфейс [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/), содержащий метод `equals(slide)`, который можно использовать для сравнения слайдов. Метод возвращает `true` для слайд-мастеров, идентичных по структуре и статическому содержимому.

Два слайд-мастера равны, если их фигуры, стили, тексты, анимация и другие настройки и т. д. равны. Сравнение не учитывает значения уникальных идентификаторов (например, SlideId) и динамическое содержание (например, текущее значение даты в заполнителе даты).

## **Установить слайд-мастер как вид по умолчанию для презентации**

Aspose.Slides позволяет установить слайд-мастер в качестве вида по умолчанию для презентации. Вид по умолчанию — это то, что вы видите в первую очередь, когда открываете презентацию.

Этот код показывает, как установить слайд-мастер в качестве вида по умолчанию для презентации на Python:

```py
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющего файл презентации
with slides.Presentation() as presentation:
    # Устанавливает последний вид как SlideMasterView
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Сохраняет презентацию
    presentation.save("PresView.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить неиспользуемый слайд-мастер**

Aspose.Slides предоставляет метод `remove_unused_master_slides` (из класса [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)), который позволяет вам удалить нежелательные и неиспользуемые слайд-мастеры. Этот код на Python показывает, как удалить слайд-мастер из презентации PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```