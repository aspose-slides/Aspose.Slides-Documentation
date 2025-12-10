---
title: Получение и обновление свойств представления презентации в Java
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/java/presentation-view-properties/
keywords:
- свойства представления
- обычный просмотр
- содержание конспекта
- значки конспекта
- привязка вертикального разделителя
- одиночный просмотр
- состояние полосы
- размер измерения
- автонастройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте о свойствах представления Aspose.Slides для Java, позволяющих настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Обычный просмотр состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию разных областей содержимого. Эта информация позволяет приложению сохранять состояние своего просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, в котором презентация была сохранена в последний раз.

Метод [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного просмотра презентации.  

[INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) интерфейсы и их наследники, [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType) перечисление были добавлены.

{{% /alert %}} 

## **Об INormalViewProperties**

Представляет свойства обычного просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, следует ли приложению показывать значки при отображении содержания конспекта в любой из областей содержимого режима обычного просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) указывают, должна ли вертикальная полоса разделителя переходить в свернутое состояние, когда боковая область достаточно мала.

Свойства [getPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) указывают, предпочитает ли пользователь видеть единую полноэкранную область содержимого вместо стандартного обычного просмотра с тремя областями. При включении приложение может отобразить одну из областей содержимого на всем окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) определяют состояние, в котором должна отображаться вертикальная или горизонтальная полоса разделителя. Горизонтальная полоса разделяет слайд от области содержимого под слайдом, вертикальная — слайд от боковой области содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) задают размеры верхней или боковой области слайда обычного просмотра, когда для [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) применено значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении INormalViewProperties** 

Указывает размеры области слайда (ширина, если дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), высота, если дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного просмотра, когда область имеет переменный восстановленный размер (не свернута и не развернута).  

Метод [getDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) задаёт размер области слайда (ширина, если дочерний элемент restoredTop, высота, если дочерний элемент restoredLeft).  

Метод [getAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) определяет, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.  

Ниже приведён пример, показывающий, как получить свойства [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.
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


## **Установить значение масштаба по умолчанию**

{{% alert color="primary" %}} 

Aspose.Slides for Java теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) могут быть заданы программно. В этой теме мы покажем на примере, как задать [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) в [Aspose.Slides](/slides/ru/).

{{% /alert %}} 

Для установки свойств просмотра выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. Задайте [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
3. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштаба для просмотра слайда, а также для просмотра заметок.
```java
Presentation presentation = new Presentation();
try {
    // Установка свойств просмотра презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштаба в процентах для просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштаба в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Могу ли я задать разные параметры просмотра для разных секций презентации?**

[View settings](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), а не для каждой секции, поэтому один набор параметров применяется ко всему документу при его открытии.

**Могу ли я заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Могу ли я подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) хранятся на уровне презентации, их можно включить в шаблон и создавать новые документы на его основе с той же начальной конфигурацией просмотра.