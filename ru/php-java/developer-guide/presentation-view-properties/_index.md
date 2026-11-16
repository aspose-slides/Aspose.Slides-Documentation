---
title: Получить и обновить свойства представления презентации в PHP
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/php-java/presentation-view-properties/
keywords:
- свойства представления
- обычный режим
- содержание схемы
- значки схемы
- привязка вертикального разделителя
- одиночное представление
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Используйте Aspose.Slides for PHP через Java для настройки расположения обычного режима, масштабирования слайдов и заметок, интервала сетки и видимости комментариев в презентациях PowerPoint."
---
## **Введение**

В обычном представлении PowerPoint слайд отображается между боковой панелью с миниатюрами или схемой и панелью заметок снизу. Aspose.Slides for PHP через Java предоставляет сохранённые предпочтения редактирования презентации через [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Включают они расположение панелей, уровни масштабирования, интервал сетки и видимость комментариев.

## **О NormalViewProperties**

Используйте [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) чтобы получить доступ к классу [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) управляет тем, отображаются ли значки рядом с названиями слайдов в схеме. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) позволяет боковой панели переходить в свернутое состояние, когда пользователь её сужает. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) указывает предпочтение отображать одну панель во весь окно.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) управляет разделителем между боковой панелью и слайдом. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) управляет разделителем над панелью заметок. Оба принимают значение [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` или `Restored`.

## **О восстановлении NormalViewProperties**

Когда разделитель восстанавливается, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) предоставляет сохранённый размер боковой панели, а [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) — сохранённый размер верхней области слайда. Оба раскрывают [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Его метод [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) принимает процент от 0 до 100, а [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) управляет тем, будет ли редактор автоматически корректировать размер при изменении окна.

В этом примере обновляется существующая презентация. Он восстанавливает горизонтальный разделитель, устанавливает размер, возвращаемый [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/), в 80 % с включённой автоматической настройкой, и разворачивает вертикальный разделитель. Также вызывается [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/), чтобы отображать значки в представлении схемы.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **Установить значение масштаба по умолчанию**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) и [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) сохраняют независимые настройки масштаба для редактора. Эти настройки не влияют на размеры слайдов, воспроизведение показа слайдов или разрешение при экспорте изображений.

В этом примере открывается существующая презентация и вызывается [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/), чтобы подогнать слайд под окно редактирования. Для страницы заметок отключается автоматическое масштабирование и вызывается [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/), чтобы установить фиксированный масштаб 80 %.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **Установить интервал сетки**

Метод `setGridSpacing` класса [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) задаёт расстояние между линиями сетки редактирования во всей презентации. Он принимает положительное значение в пунктах, при этом в дюйме 72 пункта. В этом примере выводится текущее значение интервала в существующей презентации и сохраняется сетка с шагом четверти дюйма, задав интервал 18 пунктов.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сетка повторяется с фиксированным интервалом. [Руководства по рисованию](/slides/ru/php-java/drawing-guides/) отмечают отдельные горизонтальные или вертикальные позиции. Оба служат вспомогательными средствами редактирования и отображаются только в редакторах, которые их показывают. При показе слайдов и экспорте в PDF, изображения или SVG они опускаются.

## **Показать или скрыть комментарии при открытии презентации**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) сохраняет предпочтение, которое совместимые редакторы используют при открытии презентации. Для существующей презентации с комментариями этот пример выводит текущее значение и сохраняет копию с скрытыми комментариями. Также вызывается [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) с [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView), чтобы копия открывалась в режиме просмотра слайда.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Скрытие комментариев сохраняет их текст, авторов, позиции, ответы и статусы. Чтобы изменить сами комментарии, см. [Комментарии к презентации](/slides/ru/php-java/presentation-comments/). Параметры экспорта определяют, будут ли комментарии отображаться в PDF, HTML, изображениях, заметках или раздаточных материалах.

## **FAQ**

**Почему сетка скрыта при повторном открытии презентации?**

Презентация сохраняет интервал сетки. Чтобы увидеть сетку, включите её отображение в редакторе.

**Изменяет ли удаление руководств по рисованию интервал сетки?**

Нет. Добавление, перемещение или удаление руководства не меняет интервал сетки.

**Могут ли разные разделы презентации иметь разные настройки просмотра?**

Нет. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) применяется ко всей презентации.

**Могу ли я сохранить разные настройки просмотра для разных пользователей?**

Файл хранит один набор свойств просмотра для всех. Редактор также может применять локальные предпочтения пользователя.

**Могу ли я сохранить настройки просмотра в шаблоне?**

Да. Презентации, созданные из шаблона, наследуют сохранённые в нём настройки просмотра.