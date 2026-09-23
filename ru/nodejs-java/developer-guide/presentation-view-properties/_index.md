---
title: Получить и обновить свойства представления презентации в JavaScript
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/nodejs-java/presentation-view-properties/
keywords:
- свойства представления
- обычный просмотр
- контурное содержимое
- значки контура
- привязка вертикального разделителя
- одиночный просмотр
- состояние полосы
- размер измерения
- автонастройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте о свойствах представления Aspose.Slides для Node.js через Java, позволяющих настраивать форматы слайдов PPT, PPTX и ODP — корректировать макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный просмотр состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию разных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при открытии просмотр находился в том же состоянии, в котором презентация была сохранена в последний раз.

Метод [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного просмотра презентации.

Классы [NormalViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewRestoredProperties) и их наследники, а также перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType) были добавлены.

## **О NormalViewProperties**

Представляет свойства обычного просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) указывают, следует ли показывать значки при отображении контурного содержимого в любой из областей обычного режима просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) задают, следует ли вертикальному разделителю переходить в минимизированное состояние, когда боковая область становится достаточно небольшой.

Свойства [getPreferSingleView](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) указывают, предпочитает ли пользователь видеть единственную область содержимого во всё окне вместо стандартного обычного просмотра с тремя областями. При включённом параметре приложение может отображать одну из областей содержимого во всём окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса‑разделитель. Горизонтальная полоса отделяет слайд от области содержимого под слайдом, вертикальная — от боковой области. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) задают размер верхней или боковой области слайда обычного просмотра, когда для [getVerticalBarState](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) применено значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении NormalViewProperties**

Задает размер области слайда (ширина, когда является дочерним элементом [getRestoredTop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), высота, когда является дочерним элементом [getRestoredLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) обычного просмотра, когда область имеет переменный восстановленный размер (ни минимизированный, ни максимизированный).

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) указывает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) определяет, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить свойства [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Восстановить свойства представления презентации
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Установка значения масштабирования по умолчанию**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) могут быть установлены программно. В этой статье мы покажем на примере, как установить [View Properties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation) в Aspose.Slides.

{{% /alert %}} 

Чтобы задать свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/). В примере ниже мы задали значение масштабирования как для просмотра слайдов, так и для просмотра заметок.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Установка свойств представления презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштабирования в процентах для просмотра слайдов
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштабирования в процентах для просмотра заметок
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установка сетки**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getViewProperties--) для доступа к настройкам просмотра на уровне всей презентации. Методы [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) и [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Сетка задаётся в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как указано в документации API.

В следующем примере открывается существующий файл `demo.pptx`, выводится текущий интервал сетки, задаётся интервал в четверть дюйма и сохраняется результат.

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

Сетка отличается от [drawing guides](/slides/ru/nodejs-java/drawing-guides/). Сетка задаёт регулярный интервал, а направляющие — это индивидуально расположенные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или показе слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит её: её видимость зависит от настроек пользователя редактора или просмotrщика.

## **Показ или скрытие комментариев при открытии презентации**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getViewProperties--) для доступа к настройкам просмотра на уровне презентации. Методы [ViewProperties.getShowComments](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#getShowComments--) и [ViewProperties.setShowComments](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) позволяют читать или менять сохранённую настройку, указывающую, следует ли показывать комментарии при открытии презентации в PowerPoint или другом совместимом редакторе.

Эта настройка контролирует только сохранённую предпочтительность просмотра. Она не добавляет, не удаляет, не редактирует и не решает комментарии. Скрытие комментариев сохраняет их содержимое, авторов, позиции, ответы и статусы. См. раздел [Presentation Comments](/slides/ru/nodejs-java/presentation-comments/) для операций, изменяющих сами комментарии.

В следующем примере используется существующий файл `comments.pptx` с комментариями. Пример выводит текущую настройку видимости, задаёт скрытие комментариев и сохраняет новый PPTX без удаления комментариев. Также используется [ViewProperties.setLastView](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) с [ViewType.SlideView](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewtype/#SlideView) для конфигурации начального режима редактирования вместе с видимостью комментариев.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Эта настройка не определяет, будут ли комментарии включены в экспорт в PDF, HTML, изображение, заметки или раздаточные материалы. Настройте соответствующие параметры экспорта отдельно.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но редактор определяет, будет ли сетка отображаться. Проверьте настройки видимости сетки в редакторе.

**Изменяется ли интервал сетки при удалении направляющих?**

Нет. Направляющие и интервал сетки — независимые параметры. Очистка направляющих не меняет сохранённый интервал сетки.

**Можно ли задать разные настройки просмотра для разных разделов презентации?**

[View settings](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getviewproperties/) задаются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), а не для отдельных разделов, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и совместно используются. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными View Properties, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getviewproperties/) хранятся на уровне презентации, их можно встроить в шаблон и создавать новые документы из него с одинаковой начальной конфигурацией просмотра.