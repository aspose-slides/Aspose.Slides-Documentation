---
title: Свойства просмотра презентации
type: docs
weight: 80
url: /ru/nodejs-java/presentation-view-properties/
keywords:
- свойства просмотра
- обычный просмотр
- контент плана
- значки плана
- фиксировать вертикальный разделитель
- единый просмотр
- состояние полосы
- размер измерения
- автонастройка
- масштаб по умолчанию
- PowerPoint
- презентация
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "Управляйте свойствами просмотра презентаций PowerPoint в JavaScript"
---

{{% alert color="primary" %}} 

Обычный просмотр состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию разных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр оказался в том же состоянии, что и при последнем сохранении презентации.

Метод [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного просмотра презентации. 

[NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties) классы и их потомки, [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType) перечисление были добавлены.

{{% /alert %}} 

## **О NormalViewProperties**

Представляет свойства обычного просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) указывают, следует ли приложению показывать значки при отображении контурного содержимого в любой из областей содержимого режима обычного просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) указывают, следует ли вертикальному разделителю «прищёлкнуться» в свернутое состояние, когда боковая область достаточно мала.

Свойство [getPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) указывает, предпочитает ли пользователь видеть одну область содержимого во весь экран вместо стандартного обычного просмотра с тремя областями содержимого. Если включено, приложение может отобразить одну из областей содержимого на всём окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) задают размеры верхней или боковой области слайда обычного просмотра, когда для [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) применяется значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении NormalViewProperties** 

Указывает размеры области слайда (ширина, когда является дочерним элементом [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), высота, когда является дочерним элементом [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) обычного просмотра, когда область имеет переменный восстановленный размер (не свернута и не развернута). 

Метод [getDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) задаёт размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Метод [getAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить свойства [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.
```javascript

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


## **Установить значение масштаба по умолчанию**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) могут быть установлены программно. В этой статье мы покажем на примере, как задать [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) объекта [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) в [Aspose.Slides](/slides/ru/).

{{% /alert %}} 

Чтобы установить свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) объекта [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задаём значение масштаба для просмотра слайда и для просмотра заметок.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Установка свойств просмотра презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштаба в процентах для просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштаба в процентах для просмотра заметок
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Можно ли задать разные настройки просмотра для разных секций презентации?**

[Настройки просмотра](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), а не для каждой секции, поэтому один набор параметров применяется ко всему документу при его открытии.

**Можно ли предварительно задать разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [свойства просмотра](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getviewproperties/) хранятся на уровне презентации, их можно включить в шаблон и создавать новые документы на его основе с той же начальной конфигурацией просмотра.