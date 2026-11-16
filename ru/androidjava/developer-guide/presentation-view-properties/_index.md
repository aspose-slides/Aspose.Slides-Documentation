---
title: Получить и обновить свойства представления презентации на Android
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/androidjava/presentation-view-properties/
keywords:
- свойства представления
- обычный вид
- содержание контура
- значки контура
- фиксировать вертикальный разделитель
- одиночный вид
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Используйте Aspose.Slides для Android через Java, чтобы настроить макет обычного вида, масштаб слайда и заметок, интервал сетки и видимость комментариев в презентациях PowerPoint."
---
## **Введение**

В обычном виде PowerPoint слайд отображается между боковой панелью с миниатюрами или контуром и панелью заметок внизу. Aspose.Slides for Android via Java предоставляет сохранённые параметры редактирования презентации через [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Они включают расположение панелей, уровни масштабирования, интервал сетки и отображение комментариев.

## **О INormalViewProperties**

Используйте [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) для доступа к интерфейсу [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) управляет тем, отображаются ли значки рядом с заголовками слайдов в контуре. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) позволяет боковой панели переходить в свернутое состояние, когда пользователь уменьшает её. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) указывает предпочтение отображать одну панель во всём окне.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) управляет разделителем между боковой панелью и слайдом. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) управляет разделителем над панелью заметок. Оба принимают значение [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) — `Minimized`, `Maximized` или `Restored`.

## **О восстановлении INormalViewProperties**

Когда разделитель восстанавливается, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) возвращает сохранённый размер боковой панели, а [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) — сохранённый размер верхней области слайда. Оба предоставляют доступ к [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Метод [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) принимает процент от 0 до 100, а [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) управляет тем, будет ли редактор автоматически корректировать размер при изменении окна.

В этом примере обновляется существующая презентация. Он восстанавливает горизонтальный разделитель, устанавливает размер, возвращаемый [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--), в 80% с включённой автоматической корректировкой, и разворачивает вертикальный разделитель. Также вызывается [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) чтобы отобразить значки в режиме контура.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить значение масштабирования по умолчанию**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) сохраняют независимые параметры масштабирования для редактора. Эти настройки не влияют на размеры слайдов, воспроизведение показа или разрешение экспорта изображений.

В этом примере открывается существующая презентация и вызывается [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) чтобы подогнать слайд под окно редактирования. Для страницы заметок отключается автоматическое масштабирование и вызывается [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) чтобы установить фиксированный масштаб 80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить интервал сетки**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) задаёт расстояние между линиями сетки редактирования во всей презентации. Принимает положительное значение в пунктах, при этом в дюйме 72 пункта. В этом примере выводится текущее значение интервала в существующей презентации и сохраняется сетка с шагом четверти дюйма, задав интервал в 18 пунктов.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сетка повторяется через фиксированный интервал. [Руководящие линии](/slides/ru/androidjava/drawing-guides/) отмечают отдельные горизонтальные или вертикальные позиции. Оба являются вспомогательными элементами редактирования и отображаются только в редакторах, которые их показывают. При показе слайдов и экспорте в PDF, изображения или SVG они не включаются.

## **Отображать или скрывать комментарии при открытии презентации**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) сохраняет предпочтение, которое совместимые редакторы используют при открытии презентации. Для существующей презентации с комментариями этот пример выводит текущую настройку и сохраняет копию с скрытыми комментариями. Также вызывается [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) с параметром [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView), чтобы копия открылась в виде слайда.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Скрытие комментариев сохраняет их текст, авторов, позиции, ответы и статусы. Чтобы изменить сами комментарии, см. [Комментарии к презентации](/slides/ru/androidjava/presentation-comments/). Параметры экспорта определяют, будут ли комментарии отображаться в PDF, HTML, изображениях, нотатках или раздаточных материалах.

## **FAQ**

**Почему сетка скрыта при повторном открытии презентации?**  
Презентация сохраняет интервал сетки. Чтобы увидеть сетку, включите её отображение в редакторе.

**Изменяет ли очистка направляющих рисунка интервал сетки?**  
Нет. Добавление, перемещение или удаление направляющей не меняет интервал сетки.

**Могут ли разные разделы презентации иметь разные настройки представления?**  
Нет. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) применяется к всей презентации.

**Могу ли я сохранить разные настройки представления для разных пользователей?**  
Файл хранит один набор свойств представления для всех. Редактор также может применять локальные предпочтения пользователя.

**Могу ли я сохранить настройки представления в шаблоне?**  
Да. Презентации, созданные из шаблона, наследуют сохранённые настройки представления.