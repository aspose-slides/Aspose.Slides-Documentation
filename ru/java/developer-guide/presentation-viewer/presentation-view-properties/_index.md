---
title: Свойства представления
type: docs
url: /ru/java/presentation-view-properties/
---

{{% alert color="primary" %}} 

Обычное представление состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, касающиеся позиционирования различных областей содержимого. Эта информация позволяет приложению сохранять свое состояние представления в файл, чтобы при повторном открытии представление находилось в том же состоянии, что и в последний раз, когда презентация была сохранена.

Метод [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для доступа к свойствам нормального представления презентации. 

Добавлены интерфейсы [**INormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) и их потомки, а также перечисление [**SplitterBarStateType**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType).

{{% /alert %}} 

## **О INormalViewProperties** #
Представляет свойства нормального представления.

Методы [**getShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [**setShowOutlineIcons**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) определяют, должно ли приложение отображать значки, если отображать контент в виде схемы в любой из областей содержимого в режиме нормального представления.

Методы [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) определяют, должен ли вертикальный разделитель "прилипать" к минимизированному состоянию, когда боковая область достаточно мала.

Свойство [**getPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и [**setPreferSingleView**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) определяет, предпочитает ли пользователь видеть полноэкранную одну область содержимого, а не стандартное нормальное представление с тремя областями содержимого. Если включено, приложение может выбрать отображение одной из областей содержимого во всем окне.

Методы [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) определяют состояние, в котором следует отображать горизонтальную или вертикальную полосу разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого ниже слайда, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) и [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

Методы [**getRestoredLeft**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и [**getRestoredTop**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) определяют размеры верхней или боковой области слайда нормального представления, когда применяется значение [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) для [**getVerticalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [**getHorizontalBarState**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) соответственно.


## **О восстановлении INormalViewProperties** 
Определяет размеры области слайда (ширина, когда это потомок [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда это потомок [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) нормального представления, когда область имеет переменный восстановленный размер (ни минимизированный, ни максимизированный). 

Метод [**getDimensionSize**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) определяет размер области слайда (ширина, когда это потомок restoredTop, высота, когда это потомок restoredLeft).

Метод [**getAutoAdjust**](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) определяет, должна ли ширина боковой области содержимого компенсироваться под новый размер при изменении размера окна, содержащего представление в приложении.

Пример приведен ниже и показывает, как вы можете получить доступ к [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) свойствам для презентации.

```java
// Создание объекта Presentation, представляющего файл презентации
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Восстановление свойств представления презентации
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Установка значения по умолчанию для масштаба**
{{% alert color="primary" %}} 

Aspose.Slides для Java теперь поддерживает установку значения масштаба по умолчанию для презентации, чтобы, когда презентация открыта, масштаб уже был установлен. Это можно сделать, установив [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) для презентации. [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) также могут быть установлены программно. В этой теме мы увидим на примере, как установить [Свойства представления](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) для [Презентации](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) в [Aspose.Slides](/slides/ru/).

{{% /alert %}} 

Для установки свойств представления. Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Установите [Свойства представления](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) для [Презентации](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Запишите презентацию в формате [PPTX ](https://docs.fileformat.com/presentation/pptx/).
   В приведенном ниже примере мы установили значение масштаба для перехода слайда, а также для примечаний.

```java
// Создание объекта Presentation, представляющего файл презентации
Presentation presentation = new Presentation();
try {
    // Установка свойств представления презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштаба в процентах для просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштаба в процентах для просмотра примечений 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```