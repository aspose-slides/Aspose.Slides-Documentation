---
title: "Получить и обновить свойства просмотра презентации в Java"
linktitle: "Свойства просмотра"
type: docs
weight: 80
url: /ru/java/presentation-view-properties/
keywords:
- "свойства просмотра"
- "обычный режим"
- "содержимое конспекта"
- "значки конспекта"
- "фиксация вертикального разделителя"
- "одиночный режим"
- "состояние панели"
- "размер измерения"
- "автоматическая настройка"
- "масштаб по умолчанию"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Java"
- "Aspose.Slides"
description: "Используйте Aspose.Slides for Java для настройки макета обычного режима, масштабирования слайда и заметок, интервала сетки и видимости комментариев в презентациях PowerPoint."
---
## **Введение**

В обычном режиме PowerPoint слайд отображается между боковой панелью миниатюр или конспекта и нижней панелью заметок. Aspose.Slides for Java предоставляет сохранённые параметры редактирования презентации через [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). Это включает расположение панелей, уровни масштабирования, интервал сетки и видимость комментариев.

## **Об INormalViewProperties**

Используйте [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) для доступа к интерфейсу [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) управляет тем, отображаются ли значки рядом с названиями слайдов в конспекте. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) позволяет боковой панели фиксировать своё свернутое состояние, когда пользователь уменьшает её ширину. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) указывает предпочтение отображения одной панели во весь окно.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) управляет разделителем между боковой панелью и слайдом. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) управляет разделителем над панелью заметок. Оба принимают значение [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` или `Restored`.

## **О восстановлении INormalViewProperties**

Когда разделитель восстанавливается, [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) возвращает сохранённый размер боковой панели, а [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) — сохранённый размер верхней области слайда. Оба предоставляют доступ к [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/). Его метод [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) принимает процент от 0 до 100, а [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) управляет тем, будет ли редактор корректировать размер при изменении окна.

Этот пример обновляет существующую презентацию. Он восстанавливает горизонтальный разделитель, задаёт размер, возвращённый [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--), 80 % с включённой автоматической регулировкой и разворачивает вертикальный разделитель. Кроме того, вызывается [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) для отображения значков в виде конспекта.

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

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) хранят независимые параметры масштабирования для редактора. Эти настройки не влияют на размеры слайдов, воспроизведение показа или разрешение экспортируемых изображений.

Этот пример открывает существующую презентацию и вызывает [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) для подгонки слайда под окно редактирования. Для страницы заметок он отключает автоматическое масштабирование и вызывает [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) для установки фиксированного масштабирования 80 %.

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

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) задаёт расстояние между линиями редактирующей сетки по всей презентации. Принимает положительное значение в пунктах, 72 пункта = дюйм. Этот пример выводит текущий интервал в существующей презентации и сохраняет сетку с интервалом четверти дюйма, установив значение 18 пунктов.

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

Сетка повторяется с фиксированным интервалом. [Руководства по рисованию](/slides/ru/java/drawing-guides/) отмечают отдельные горизонтальные или вертикальные положения. Оба являются вспомогательными элементами редактирования и отображаются только в редакторах, которые их показывают. Слайд‑шоу и экспорт в PDF, изображения или SVG их не включают.

## **Показать или скрыть комментарии при открытии презентации**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) сохраняет предпочтение, которое совместимые редакторы используют при открытии презентации. Для существующей презентации с комментариями этот пример выводит текущую настройку и сохраняет копию с скрытыми комментариями. Он также вызывает [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) с [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView), чтобы копия открылась в режиме просмотра слайда.

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

Скрытие комментариев сохраняет их текст, авторов, позиции, ответы и статусы. Чтобы изменить сами комментарии, см. [Presentation Comments](/slides/ru/java/presentation-comments/). Параметры экспорта определяют, будут ли комментарии включены в PDF, HTML, изображения, заметки или раздаточные материалы.

## **FAQ**

**Почему сетка скрыта при повторном открытии презентации?**

Презентация сохраняет интервал сетки. Чтобы увидеть сетку, включите её видимость в редакторе.

**Изменяет ли очистка руководств по рисованию интервал сетки?**

Нет. Добавление, перемещение или удаление руководства не меняет интервал сетки.

**Могут ли разные разделы презентации иметь разные настройки просмотра?**

Нет. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) применяется ко всей презентации.

**Могу ли я сохранять разные настройки просмотра для разных пользователей?**

Файл сохраняет один набор параметров просмотра для всех. Редактор может также применять локальные предпочтения пользователя.

**Могу ли я сохранять настройки просмотра в шаблоне?**

Да. Презентации, созданные из шаблона, наследуют сохранённые в нём параметры просмотра.