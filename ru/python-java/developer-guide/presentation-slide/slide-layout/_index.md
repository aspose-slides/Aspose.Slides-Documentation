---
title: Применение или изменение макетов слайдов в Python через Java
linktitle: Макет слайда
type: docs
weight: 60
url: /ru/python-java/slide-layout/
keywords:
- макет слайда
- макет содержимого
- заполнитель
- дизайн презентации
- дизайн слайда
- неиспользуемый макет
- видимость нижнего колонтитула
- слайд заголовка
- заголовок и содержание
- заголовок раздела
- два содержания
- сравнение
- только заголовок
- пустой макет
- содержание с подписью
- изображение с подписью
- заголовок и вертикальный текст
- вертикальный заголовок и текст
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте, создавайте и изменяйте макеты слайдов в Aspose.Slides для Python через Java, добавляйте заполнители, удаляйте неиспользуемые макеты и управляйте видимостью нижнего колонтитула."
---
## **Обзор**

Макет слайда определяет позиции и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета обеспечивает единообразную структуру слайдов, позволяя каждому слайду содержать собственный контент.

Самыми распространёнными макетами являются:

- **Слайд заголовка**: содержит заполнители заголовка и подзаголовка.
- **Заголовок и содержание**: содержит заполнитель заголовка и общий заполнитель содержания.
- **Пустой**: не содержит заполнителей и полезен, когда все объекты размещаются вручную.

## **Понимание наследования макета**

Презентация имеет три связанных уровня:

1. [главный слайд](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/) определяет тему, общие стили, фоны и общие объекты.
1. [макет слайда](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/) принадлежит главному слайду и задаёт конкретное расположение заполнителей.
1. [обычный слайд](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/) использует один макет и хранит введённый для него контент.

Обычный слайд наследует тему и форматирование от своего макета, а макет — от главного слайда. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его заполнительные формы генерируются из выбранного макета, тогда как введённый в эти заполнители контент принадлежит обычному слайду.

Добавьте необходимые заполнители в макет перед созданием слайдов на его основе. Добавление нового заполнителя в макет позже не добавит автоматически соответствующую форму заполнителя в уже существующие обычные слайды.

Эти отношения имеют два важных следствия:

- Изменение унаследованного форматирования или геометрии существующего заполнителя в макете может обновить каждый слайд, зависящий от него. Перед редактированием уже используемого макета проверьте его зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удаляйте только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Slide Master](/slides/ru/python-java/slide-master/).

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируемы пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

В следующем примере ищется **Заголовок и содержание** на первом мастере. Если этот макет недоступен, происходит откат к **Пустому**. Вторичная проверка на `None` необходима, поскольку презентация может содержать только пользовательские макеты. Затем выбранный макет применяется к первому обычному слайду через метод [Slide.setLayoutSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Изменение макета слайда не удаляет обычные формы, добавленные напрямую на слайд. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно разными макетами.

## **Добавление макета слайда**

Выбор и создание — отдельные операции. В предыдущем примере выбирается существующий макет; он не создаётся. Чтобы создать макет, вызовите метод [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterlayoutslidecollection/#add) у коллекции макетов целевого мастера.

В следующем примере всегда добавляется новый макет **Заголовок и содержание** с именем `Report Title and Content`, а затем создаётся обычный слайд на его основе. Имена макетов должны быть уникальными в коллекции.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Добавляйте макет только тогда, когда шаблон действительно нуждается в дополнительной переиспользуемой структуре. Если подходящий макет уже существует, выбирайте и переиспользуйте его вместо создания дубликата.

## **Добавление заполнителей в макет слайда**

Метод [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getPlaceholderManager) предоставляет [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/) для добавления форм‑заполнителей в макет.

| Заполнитель PowerPoint              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/) Метод |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [addTextPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [addPicturePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [addTablePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

В следующем примере проверяется, существует ли макет **Пустой**, к нему добавляются четыре заполнителя, после чего создаётся обычный слайд, использующий изменённый макет. Порядок намеренно выбран так: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides мог генерировать соответствующие формы‑заполнители на этом слайде.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Заполнители на макете слайда](add_placeholders.png)

{{% alert color="warning" title="Предупреждение" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей макета может повлиять на зависимые слайды. Новый заполнитель макета не заполняется автоматически в уже существующих обычных слайдах. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов слайдов**

Используйте метод [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления макетов, на которые не ссылается ни один обычный слайд. Метод оставляет используемые макеты без изменений.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Чтобы удалить конкретный макет, сначала воспользуйтесь его методом [hasDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#hasDependingSlides) или [getDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getDependingSlides). Переназначьте любые зависимые слайды перед вызовом [LayoutSlide.remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#remove). Попытка удалить используемый макет вызовет исключение [PptxEditException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макете слайда**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты/времени. Используйте метод [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) для управления этими заполнителями одного макета. Это полезно, когда, например, макеты содержания должны показывать нижний колонтитул, а макеты заголовков — нет.

В следующем примере безопасно выбирается макет и его элементы нижнего колонтитула делаются видимыми:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Управление видимостью нижнего колонтитула в мастере и его дочерних макетах**

Чтобы применить согласованные настройки нижнего колонтитула к всей иерархии мастера, используйте метод [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Методы распространения из [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslideheaderfootermanager/) работают как с мастером, так и с его зависимыми макетами и обычными слайдами; они не ориентированы только на один обычный слайд.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**В чём разница между главным слайдом и макетом слайда?**

Главный слайд определяет тему презентации и общие стили. Макет слайда принадлежит главному слайду и задаёт один переиспользуемый набор размещения заполнителей. Обычные слайды используют эти макеты и хранят контент, специфичный для конкретного слайда.

**Можно ли скопировать макет слайда из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/globallayoutslidecollection/#addClone). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, когда я изменяю макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если они не переопределяют затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованные стили могут измениться сразу на многих слайдах. Используйте [getDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getDependingSlides), чтобы определить затронутые слайды перед редактированием макета.

**Что происходит, если я пытаюсь удалить макет, который всё ещё используется?**

Aspose.Slides генерирует исключение [PptxEditException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления только неиспользуемых макетов.