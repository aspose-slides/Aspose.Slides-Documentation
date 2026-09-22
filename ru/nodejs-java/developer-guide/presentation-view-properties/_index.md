---
title: Получить и обновить свойства просмотра презентации в JavaScript
linktitle: Свойства просмотра
type: docs
weight: 80
url: /ru/nodejs-java/presentation-view-properties/
keywords:
- свойства просмотра
- обычный просмотр
- содержание контура
- значки контура
- привязка вертикального разделителя
- единый просмотр
- состояние полосы
- размер измерения
- автоматическая коррекция
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как с помощью Aspose.Slides for Node.js через Java управлять свойствами просмотра, настраивая форматы слайдов PPT, PPTX и ODP — изменяя макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный просмотр состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, так чтобы при повторном открытии просмотр находился в том же состоянии, в котором презентация была последней сохранена.

Метод [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) добавлен для доступа к свойствам обычного просмотра презентации.  

[NormalViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewRestoredProperties) классы и их потомки, [SplitterBarStateType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType) перечисление добавлены.

## **О NormalViewProperties**

Представляет свойства обычного просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) указывают, следует ли отображать значки при показе содержания контура в любой из областей содержимого режима обычного просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) указывают, следует ли вертикальному разделителю переходить в уменьшенное состояние, когда боковая область достаточно мала.

Свойство [getPreferSingleView](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) определяют, предпочитает ли пользователь видеть один регион содержимого во всём окне вместо стандартного обычного просмотра с тремя регионами. При включении приложение может отобразить одну из областей содержимого на весь экран.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) указывают состояние, в котором следует отображать горизонтальный или вертикальный разделитель. Горизонтальный разделитель отделяет слайд от области содержимого под слайдом, вертикальный разделитель отделяет слайд от боковой области содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) задают размеры верхней или боковой области слайда в обычном просмотре, когда для [getVerticalBarState](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) применяется значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении NormalViewProperties**

Определяет размеры области слайда (ширина, если дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), высота, если дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) обычного просмотра, когда область имеет переменный восстановленный размер (ни уменьшенный, ни максимизированный).  

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) задаёт размер области слайда (ширина, если дочерний элемент restoredTop, высота, если дочерний элемент restoredLeft).  

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить свойства [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Восстановить свойства просмотра презентации
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Установить значение масштабирования по умолчанию**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) могут быть заданы программно. В этой статье мы покажем пример, как задать [View Properties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties) объекта [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation) в Aspose.Slides.

{{% /alert %}} 

Для установки свойств просмотра выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties) объекта [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштабирования для просмотра слайдов и для просмотра заметок.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Установка свойств просмотра презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштабирования в процентах для просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштабирования в процентах для просмотра заметок
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Задать интервал сетки**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getViewProperties--) для доступа к настройкам просмотра на уровне всей презентации. Методы [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) и [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как требуется в документации API.

В следующем примере открывается существующий `demo.pptx`, выводится текущий интервал сетки, задаётся интервал в четверть дюжины дюйма и сохраняется результат.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сетка отличается от [drawing guides](/slides/ru/nodejs-java/drawing-guides/). Интервал сетки задаёт регулярный шаг, тогда как направляющие — это индивидуально позиционированные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или в слайд‑шоу. Хранение интервала сетки не гарантирует, что редактор отобразит её: её видимость также зависит от настроек просмотра или редактора.

## **Вопросы и ответы**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но редактор управляет тем, отображается ли сетка. Проверьте настройки видимости сетки в используемом редакторе.

**Изменит ли очистка направляющих интервал сетки?**

Нет. Направляющие и интервал сетки — независимые настройки. Очистка направляющих оставляет сохранённый интервал сетки без изменений.

**Могу ли я задавать разные настройки просмотра для разных секций презентации?**

[View settings](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getviewproperties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), а не для каждой секции, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли предварительно задать разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но файл содержит один набор свойств просмотра.

**Можно ли создать шаблон с предопределёнными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getviewproperties/) хранятся на уровне презентации, их можно включить в шаблон и создавать из него новые документы с той же начальной конфигурацией просмотра.