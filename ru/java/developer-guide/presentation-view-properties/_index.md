---
title: Получить и обновить свойства просмотра презентации в Java
linktitle: Свойства просмотра
type: docs
weight: 80
url: /ru/java/presentation-view-properties/
keywords:
- свойства просмотра
- обычный просмотр
- содержание плана
- значки плана
- фиксировать вертикальный разделитель
- единый просмотр
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Откройте возможности Aspose.Slides для Java по настройке свойств просмотра, позволяющие изменять форматы PPT, PPTX и ODP слайдов — регулировать макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный режим просмотра состоит из трёх областей содержимого: самого слайда, боковой области и нижней области. Свойства, касающиеся позиционирования различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, что и при последнем сохранении презентации.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного режима просмотра презентации.  

[INormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties) интерфейсы и их потомки, [SplitterBarStateType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType) перечисление были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного режима просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, следует ли приложению показывать значки при отображении содержания плана в любой из областей обычного режима просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) указывают, должна ли вертикальная разделительная полоса переходить в минимизированное состояние, когда боковая область достаточно мала.

Свойство [getPreferSingleView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) указывает, предпочитает ли пользователь видеть одну полноэкранную область содержимого вместо стандартного обычного режима с тремя областями. При включении приложение может выбрать отображение одной из областей на весь экран.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) определяют состояние, в котором должна отображаться горизонтальная или вертикальная разделительная полоса. Горизонтальная полоса отделяет слайд от области содержимого под слайдом, вертикальная – от боковой области. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) задают размеры верхней или боковой области слайда в обычном режиме, когда для [getVerticalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) применено значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении INormalViewProperties** 

Указывает размеры области слайда (ширина, когда это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного режима, когда область имеет переменный восстановленный размер (не минимизирована и не максимизирована).  

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) задаёт размер области слайда (ширина при дочернем элементе restoredTop, высота при дочернем элементе restoredLeft).  

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размера окна, содержащего просмотр в приложении.  

Ниже приведён пример, демонстрирующий, как получить свойства [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Восстановить свойства просмотра презентации
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Установить значение масштабирования по умолчанию**

{{% alert color="info" %}} 

Aspose.Slides for Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) могут быть заданы программно. В этой теме мы покажем на примере, как задать [View Properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation) в [Aspose.Slides](/slides/ru/).

{{% /alert %}} 

Чтобы задать свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштабирования для просмотра слайда, а также для просмотра заметок.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Установка свойств просмотра презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение увеличения в процентах для просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение увеличения в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Можно ли задать разные настройки просмотра для разных разделов презентации?

[View settings](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), а не на уровне раздела, поэтому один набор параметров применяется ко всему документу при открытии.

### Можно ли заранее определить разные состояния просмотра для разных пользователей?

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

### Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--) хранятся на уровне презентации, их можно включить в шаблон и создавать новые документы на его основе с той же начальной конфигурацией просмотра.