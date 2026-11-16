---
title: Получить и обновить свойства просмотра презентации в JavaScript
linktitle: Свойства просмотра
type: docs
weight: 80
url: /ru/nodejs-java/presentation-view-properties/
keywords:
- свойства просмотра
- обычный вид
- содержание схемы
- значки схемы
- привязка вертикального разделителя
- одиночный вид
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Используйте Aspose.Slides для Node.js через Java, чтобы настроить расположение обычного вида, масштаб слайда и заметок, интервал сетки и видимость комментариев в презентациях PowerPoint."
---
## **Введение**

В обычном представлении PowerPoint слайд отображается между боковой панелью с миниатюрами или схемой и панелью заметок снизу. Aspose.Slides для Node.js через Java предоставляет сохранённые параметры редактирования презентации через [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Они включают расположение панелей, уровни масштабирования, интервалы сетки и видимость комментариев.

## **О NormalViewProperties**

Используйте [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) для доступа к классу [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) управляет тем, отображаются ли значки рядом с названиями слайдов в схеме. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) позволяет боковой панели автоматически переходить в свернутое состояние, когда пользователь уменьшает её ширину. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) указывает предпочтение отображения одной панели в полном окне.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) управляет разделителем между боковой панелью и слайдом. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) управляет разделителем над панелью заметок. Оба принимают значение [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) — `Minimized`, `Maximized` или `Restored`.

## **О восстановлении NormalViewProperties**

Когда разделитель восстанавливается, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) возвращает сохранённый размер боковой панели, а [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) — сохранённый размер верхней области слайда. Оба предоставляют доступ к [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Его метод [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) принимает процент от 0 до 100, а [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) управляет тем, автоматически ли редактор изменяет размер при изменении размеров окна.

В этом примере обновляется существующая презентация. Он восстанавливает горизонтальный разделитель, устанавливает размер, возвращаемый [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop), в 80 % с включённым автоматическим регулированием, и разворачивает вертикальный разделитель. Также вызывается [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons), чтобы отображать значки в представлении схемы.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить значение масштаба по умолчанию**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) и [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) хранят независимые настройки масштабирования для редактора. Эти настройки не влияют на размеры слайдов, воспроизведение презентации или разрешение при экспорте изображений.

В этом примере открывается существующая презентация и вызывается [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale), чтобы подогнать слайд под окно редактирования. Для страницы заметок отключается автоматическое масштабирование и вызывается [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale), чтобы установить фиксированный масштаб 80 %.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить интервал сетки**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) задает расстояние между линиями редактирующей сетки во всей презентации. Принимает положительное значение в пунктах, при этом в дюйме 72 пункта. В этом примере выводится текущий интервал в существующей презентации и сохраняется сетка с шагом в четверть дюйма, задав интервал 18 пунктов.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сетка повторяется с фиксированным интервалом. [Руководства по рисованию](/slides/ru/nodejs-java/drawing-guides/) отмечают отдельные горизонтальные или вертикальные позиции. Оба служат подсказками при редактировании и отображаются только в редакторах, которые их поддерживают. Слайд-шоу и экспорты в PDF, изображения или SVG их не включают.

## **Показать или скрыть комментарии при открытии презентации**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) сохраняет предпочтение, которое совместимые редакторы используют при открытии презентации. Для существующей презентации с комментариями этот пример выводит текущее значение и сохраняет копию с скрытыми комментариями. Также вызывается [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) с [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView), чтобы копия открывалась в представлении слайда.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Скрытие комментариев сохраняет их текст, авторов, позиции, ответы и статусы. Чтобы изменить сами комментарии, смотрите [Комментарии к презентации](/slides/ru/nodejs-java/presentation-comments/). Параметры экспорта определяют, будут ли комментарии отображаться в PDF, HTML, изображениях, заметках или раздаточных материалах.

## **FAQ**

**Почему сетка скрыта при повторном открытии презентации?**  
Презентация сохраняет интервал сетки. Чтобы увидеть сетку, включите её отображение в редакторе.

**Удаление руководств по рисованию меняет интервал сетки?**  
Нет. Добавление, перемещение или удаление руководства не изменяют интервал сетки.

**Могут ли разные разделы презентации иметь разные настройки представления?**  
Нет. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) применяется ко всей презентации.

**Могу ли я сохранить разные настройки представления для разных пользователей?**  
Файл сохраняет один набор свойств представления для всех. Редактор может также применять локальные предпочтения пользователя.

**Могу ли я сохранить настройки представления в шаблоне?**  
Да. Презентации, созданные из шаблона, наследуют сохранённые настройки представления.