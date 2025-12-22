---
title: Получить и обновить свойства представления презентации на Android
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/androidjava/presentation-view-properties/
keywords:
- свойства представления
- обычный режим
- содержание конспекта
- значки конспекта
- привязка вертикального разделителя
- одиночный режим
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
description: "Откройте для себя Aspose.Slides для Android через Java, свойства представления позволяют настраивать форматы PPT, PPTX и ODP слайды — корректировать макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Обычный режим просмотра состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, что и при последнем сохранении презентации.

Метод [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного режима просмотра презентации.  

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) и их наследники, а также перечисление [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) были добавлены.

{{% /alert %}} 

## **Об INormalViewProperties**

Представляет свойства обычного режима просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, должен ли приложение отображать значки при выводе содержания конспекта в любой из областей содержимого обычного режима просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) указывают, должен ли вертикальный разделитель переходить в свернутое состояние, когда боковая область достаточно мала.

Свойства [getPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) указывают, предпочитает ли пользователь видеть одноблочную область во весь экран вместо стандартного обычного режима просмотра с тремя областями содержимого. При включении приложение может выбрать отображение одной из областей содержимого на весь экран.

Методы [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) определяют состояние, в котором должна отображаться горизонтальная или вертикальная полоска разделителя. Горизонтальная полоска разделителя отделяет слайд от области содержимого под слайдом, вертикальная — от боковой области. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) определяют размеры верхней или боковой области слайда в обычном режиме просмотра, когда значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) применено к [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) соответственно.

## **О восстановлении INormalViewProperties**

Определяет размеры области слайда (ширина, когда это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного режима просмотра, когда область имеет переменный восстановленный размер (не свернута и не развернута).  

Метод [getDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) определяет размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).  

Метод [getAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) определяет, должна ли размер боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.  

Приведенный ниже пример показывает, как получить доступ к свойствам [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.  
```java
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

{{% alert color="primary" %}} 

Aspose.Slides для Android через Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) могут быть заданы программно. В этой статье мы покажем на примере, как установить [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) в [Aspose.Slides](/slides/ru/).  

{{% /alert %}} 

Чтобы установить свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Задайте [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштабирования для просмотра слайда, а также для просмотра заметок.  
```java
Presentation presentation = new Presentation();
try {
    // Установка свойств просмотра презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштабирования в процентах для просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштабирования в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Можно ли задать разные параметры просмотра для разных секций презентации?**

Параметры просмотра ([Normal View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)) определяются на уровне презентации, а не для каждой секции, поэтому один набор параметров применяется ко всему документу при его открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку свойства просмотра хранятся на уровне презентации, их можно включить в шаблон и создавать из него новые документы с той же начальной конфигурацией просмотра.