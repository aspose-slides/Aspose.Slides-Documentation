---
title: Получить и обновить свойства представления презентации в Python
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/python-net/presentation-view-properties/
keywords:
- свойства представления
- обычный вид
- содержание структуры
- значки структуры
- привязка вертикального разделителя
- одиночный вид
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Используйте Aspose.Slides для Python через .NET, чтобы настроить расположение в обычном виде, масштаб слайда и примечаний, интервалы сетки и отображение комментариев в презентациях PowerPoint."
---
## **Введение**

В обычном виде PowerPoint слайд отображается между боковой панелью для миниатюр или структуры и панелью примечаний снизу. Aspose.Slides для Python через .NET предоставляет сохранённые параметры редактирования презентации через [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Эти параметры включают расположение панелей, уровни масштабирования, интервал сетки и отображение комментариев.

## **О NormalViewProperties**

Используйте [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) для доступа к объекту [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) управляет тем, появляются ли значки рядом с названиями слайдов в структуре. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) позволяет боковой панели автоматически переходить в свернутое состояние, когда пользователь её сжимает. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) указывает предпочтение отображать одну панель во весь размер окна.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) управляет разделителем между боковой панелью и слайдом. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) управляет разделителем над панелью примечаний. Оба принимают значение [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) `MINIMIZED`, `MAXIMIZED` или `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Концептуальный редактор разделяет боковую панель, область слайда и нижнюю область, отмеченные вертикальными и горизонтальными разделителями.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*В обычном виде вертикальный разделитель управляет шириной боковой панели. Горизонтальный разделитель управляет пространством над панелью примечаний.*
<!-- visual-explanation:presentation-view-properties:end -->

## **О восстановлении NormalViewProperties**

Когда разделитель восстанавливается, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) предоставляет сохранённый размер боковой панели, а [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) — сохранённый размер верхней области слайда. Оба раскрывают объект [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Его свойство [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) принимает процент от 0 до 100, а [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) управляет тем, будет ли редактор автоматически корректировать размер при изменении окна.

Этот пример обновляет существующую презентацию. Он восстанавливает горизонтальный разделитель, задаёт [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) = 80 % с включённым автоматическим подгонкой и разворачивает вертикальный разделитель. Также включается [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) для режима структуры.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить значение масштаба по умолчанию**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) и [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) хранят независимые параметры масштабирования для редактора. Эти параметры не влияют на размеры слайдов, воспроизведение слайд‑шоу или разрешение при экспорте изображений.

В этом примере открывается существующая презентация и включается [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) для подгонки слайда под окно редактирования. Для страницы примечаний отключается автоматическое масштабирование и задаётся фиксированный масштаб [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) = 80 %.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить интервал сетки**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) задаёт расстояние между линиями редактирующей сетки во всей презентации. Принимает положительное значение в пунктах, где 72 пункта = дюйм. Этот пример выводит текущее значение интервала в существующей презентации и сохраняет сетку с интервалом в четверть дюйма, задав значение = 18 пунктов.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Сетка повторяется с фиксированным интервалом. [Руководящие линии](/slides/ru/python-net/drawing-guides/) отмечают отдельные горизонтальные или вертикальные позиции. Оба являются вспомогательными элементами редактирования и отображаются только в редакторах, которые их показывают. Слайды и экспорты в PDF, изображения или SVG их не включают.

## **Показать или скрыть комментарии при открытии презентации**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) хранит предпочтение, которое совместимые редакторы используют при открытии презентации. Для существующей презентации с комментариями этот пример выводит текущую настройку и сохраняет копию с скрытыми комментариями. Также задаётся [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) = [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/), чтобы копия открылась в режиме просмотра слайда.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Скрытие комментариев сохраняет их текст, авторов, позиции, ответы и статусы. Чтобы изменить сами комментарии, см. раздел [Комментарии к презентации](/slides/ru/python-net/presentation-comments/). Параметры экспорта определяют, будут ли комментарии включены в PDF, HTML, изображения, примечания или раздаточные материалы.

## **Вопросы и ответы**

**Почему сетка скрыта при повторном открытии презентации?**

Презентация сохраняет интервал сетки. Чтобы увидеть сетку, включите её отображение в редакторе.

**Изменяет ли удаление руководящих линий интервал сетки?**

Нет. Добавление, перемещение или удаление руководящей линии не меняет интервал сетки.

**Могут ли разные разделы презентации иметь разные настройки вида?**

Нет. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) применяется к всей презентации.

**Могу ли я сохранить разные настройки вида для разных пользователей?**

Файл хранит один набор параметров вида для всех. Редактор может также применять локальные предпочтения пользователя.

**Могу ли я сохранить настройки вида в шаблоне?**

Да. Презентации, созданные из шаблона, наследуют сохранённые в нём параметры вида.