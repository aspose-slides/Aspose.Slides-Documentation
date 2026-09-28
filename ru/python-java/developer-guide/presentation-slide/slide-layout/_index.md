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
- заголовок и содержимое
- заголовок раздела
- два блока содержимого
- сравнение
- только заголовок
- пустой макет
- содержимое с подписью
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

Макет слайда определяет положения и форматирование заполнителей, таких как заголовки, текст, изображения, диаграммы и таблицы. Применение макета придаёт слайдам единообразную структуру, позволяя каждому слайду содержать собственное содержимое.

Самые распространённые макеты включают:

- **Слайд заголовка**: Содержит заполнители заголовка и подзаголовка.
- **Заголовок и содержимое**: Содержит заполнитель заголовка и универсальный заполнитель содержимого.
- **Пустой**: Не содержит заполнителей содержимого и полезен, когда каждый объект будет размещён вручную.

## **Понимание наследования макетов**

Презентация имеет три связанных уровня:

1. A [главный слайд](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/) определяет тему, общий формат, фон и общие объекты.
1. A [слайд макета](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/) принадлежит главному слайду и определяет конкретное расположение заполнителей.
1. A [обычный слайд](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/) использует один макет и хранит введённое в него содержимое.

Обычный слайд наследует тему и форматирование от своего макета, а макет наследуется от своего главного слайда. Значение, установленное непосредственно на обычном слайде, переопределяет унаследованное значение на этом уровне. При создании обычного слайда его формы‑заполнители генерируются из выбранного макета, в то время как содержимое, введённое в эти заполнители, принадлежит обычному слайду.

Добавьте необходимые заполнители в макет до создания слайдов из него. Добавление другого заполнителя в макет позже не добавит автоматически соответствующую форму‑заполнитель в уже существующие обычные слайды.

Эти отношения имеют два важных следствия:

- Изменение унаследованного форматирования или геометрии существующего заполнителя в макете может обновить каждый слайд, зависящий от него. Перед редактированием уже используемого макета проверьте его зависимые слайды и просмотрите получившуюся презентацию.
- Макет, который всё ещё используется слайдом, нельзя удалить. Сначала переназначьте его зависимые слайды на другой макет или удалите только неиспользуемые макеты.

Для получения дополнительной информации о верхнем уровне этой иерархии см. [Главный слайд](/slides/ru/python-java/slide-master/).

Чтобы скрыть унаследованные логотипы или декоративные элементы главного слайда на отдельном слайде или через общий макет, см. [Управление видимостью графики главного слайда](/slides/ru/python-java/slide-master/). Пример сравнивает два слайда, использующие один и тот же главный слайд.

## **Выбор и применение макета слайда**

Используйте тип макета, когда презентация следует стандартным определениям макетов PowerPoint. Имена макетов редактируются пользователем и могут быть локализованы, поэтому выбор по имени менее надёжен, если вы не контролируете исходный шаблон.

Следующий пример ищет **Заголовок и содержимое** на первом главном слайде. Если этот макет недоступен, он намеренно переходит к **Пустой**. Вторая проверка на `None` необходима, потому что презентация может содержать только пользовательские макеты. Выбранный макет затем применяется к первому обычному слайду через метод [Slide.setLayoutSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#setLayoutSlide).

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

Изменение макета слайда не удаляет обычные формы, добавленные непосредственно к слайду. Однако позиции заполнителей, унаследованное форматирование и соответствие между существующими заполнителями и новым макетом могут измениться, поэтому проверяйте результат при переключении между существенно различными макетами.

## **Добавление макета слайда**

Выбор и создание — это отдельные операции. Предыдущий пример выбирает существующий макет; он не создаёт его. Чтобы создать макет, вызовите метод [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterlayoutslidecollection/#add) в коллекции макетов целевого главного слайда.

Следующий пример всегда добавляет новый макет **Заголовок и содержимое** с именем `Report Title and Content`, затем добавляет обычный слайд на его основе. Имена макетов должны быть уникальны в пределах коллекции.

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

Добавляйте макет только тогда, когда шаблон действительно нуждается в новой переиспользуемой структуре. Если подходящий макет уже существует, выберите и переиспользуйте его вместо создания дубликата.

## **Добавление заполнителей к макету слайда**

Метод [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getPlaceholderManager) предоставляет [LayoutPlaceholderManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/) для добавления форм‑заполнителей в макет.

| Заполнитель PowerPoint               | Метод LayoutPlaceholderManager |
| ------------------------------------ | ------------------------------ |
| ![Содержание](content.png)           | [addContentPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Содержание (вертикальное)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Текст](text.png)                   | [addTextPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Текст (вертикальное)](textV.png)   | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Изображение](picture.png)          | [addPicturePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Диаграмма](chart.png)              | [addChartPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Таблица](table.png)                | [addTablePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)            | [addSmartArtPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Медиа](media.png)                  | [addMediaPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Онлайн‑изображение](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Следующий пример проверяет, существует ли макет **Пустой**, добавляет к нему четыре заполнителя, а затем создаёт обычный слайд, использующий изменённый макет. Порядок намеренный: заполнители добавляются до создания обычного слайда, чтобы Aspose.Slides смог сгенерировать соответствующие формы‑заполнители на этом слайде.

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

{{% alert color="warning" title="Warning" %}}
Изменение унаследованного форматирования или геометрии существующих заполнителей в макете может повлиять на зависимые слайды. Недавно добавленный заполнитель макета не заполняет автоматически существующие обычные слайды. Тестируйте изменения макета на копии презентации и проверяйте каждый зависимый слайд.
{{% /alert %}}

## **Удаление неиспользуемых макетов слайдов**

Используйте метод [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления макетов, на которые не ссылается ни один обычный слайд. Метод оставляет в неизменном виде макеты, которые всё ещё используются.

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

Чтобы удалить конкретный макет, сначала используйте его метод [hasDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#hasDependingSlides) или [getDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getDependingSlides). Переназначьте все зависимые слайды перед вызовом [LayoutSlide.remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#remove). Попытка удалить используемый макет вызывает [PptxEditException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxeditexception/).

## **Управление видимостью нижнего колонтитула на макете слайда**

У макета есть собственные заполнители нижнего колонтитула, номера слайда и даты‑времени. Используйте метод [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) для управления этими заполнителями для одного макета. Это полезно, например, когда макеты содержимого должны показывать нижний колонтитул, а макеты заголовков — нет.

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

## **Управление видимостью нижнего колонтитула на главном слайде и его дочерних макетах**

Чтобы применить согласованные настройки нижнего колонтитула во всей иерархии главного слайда, используйте метод [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Методы распространения [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslideheaderfootermanager/) работают и с главным слайдом, и с его зависимыми макетами и обычными слайдами; они не ориентированы только на один обычный слайд.

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

**В чем разница между главным слайдом и макетом слайда?**

Главный слайд определяет тему презентации и общий формат. Макет слайда принадлежит главному слайду и задаёт одну переиспользуемую раскладку заполнителей. Обычные слайды используют эти макеты и хранят содержание, характерное для конкретного слайда.

**Можно ли копировать макет слайда из одной презентации в другую?**

Да. Добавьте копию в целевую коллекцию с помощью метода [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/globallayoutslidecollection/#addClone). При копировании между презентациями также проверьте шрифты, темы, изображения и другие ресурсы, используемые исходным макетом.

**Что происходит, когда я изменяю макет, который уже используется?**

Зависимые слайды наследуют изменения макета, если только они не переопределили затронутое форматирование или объекты локально. Геометрия заполнителей и унаследованный стиль могут измениться сразу на многих слайдах. Используйте [getDependingSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/#getDependingSlides), чтобы определить затронутые слайды перед редактированием макета.

**Что происходит, если удалить макет, который всё ещё используется?**

Aspose.Slides выдаёт [PptxEditException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pptxeditexception/). Сначала переназначьте зависимые слайды или используйте [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) для удаления только нереферентных макетов.