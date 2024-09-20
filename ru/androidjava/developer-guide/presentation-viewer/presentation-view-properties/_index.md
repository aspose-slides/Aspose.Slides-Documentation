---
title: Свойства представления нормального вида
type: docs
url: /androidjava/presentation-view-properties/
---

{{% alert color="primary" %}} 

Обычное представление состоит из трех областей контента: самого слайда, боковой области контента и нижней области контента. Свойства, относящиеся к позиционированию различных областей контента. Эта информация позволяет приложению сохранять свое состояние представления в файл, так что при повторном открытии представление будет в том же состоянии, что и при последнем сохранении презентации.

Метод [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для доступа к свойствам нормального вида презентации. 

Интерфейсы [**INormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) и их потомки, перечисление [**SplitterBarStateType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) были добавлены.

{{% /alert %}} 

## **О INormalViewProperties** #
Представляет свойства нормального вида.

Методы [**getShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [**setShowOutlineIcons**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) определяют, должно ли приложение показывать значки, если отображается контент в виде плана в любой из областей контента нормального режима представления.

Методы [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) определяют, должен ли вертикальный разделитель прикрепляться к минимизированному состоянию, когда боковая область достаточно мала.

Свойство [**getPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и [**setPreferSingleView**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) определяет, предпочитает ли пользователь видеть весь экран с одной областью контента, чем стандартный нормальный вид с тремя областями контента. Если включено, приложение может выбрать отображение одной из областей контента на всем окне.

Методы [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) определяют состояние, в котором должен быть показан горизонтальный или вертикальный разделитель. Горизонтальный разделитель отделяет слайд от области контента под слайдом, вертикальный разделитель отделяет слайд от боковой области контента. Возможные значения: [**SplitterBarStateType.Minimized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType.Maximized**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) и [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Методы [**getRestoredLeft**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и [**getRestoredTop**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) определяют размеры верхней или боковой области слайда нормального вида, когда для [**getVerticalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [**getHorizontalBarState**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) применяется значение [**SplitterBarStateType.Restored**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) соответственно.

## **О восстановлении INormalViewProperties** 
Определяет размеры области слайда (ширину, когда она является дочерней для [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), высоту, когда она является дочерней для [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) нормального вида, когда область имеет переменный восстановленный размер (не минимизированный и не развернутый).

Метод [**getDimensionSize**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) определяет размер области слайда (ширину, когда она является дочерней для restoredTop, высоту, когда она является дочерней для restoredLeft).

Метод [**getAutoAdjust**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) определяет, должны ли размеры боковой области контента компенсировать новый размер при изменении размера окна, содержащего представление в приложении.

Ниже приведен пример, который показывает, как вы можете получить доступ к свойствам [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

```java
// Создать объект Presentation, который представляет файл презентации
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Восстановить свойства представления презентации
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Установка значения масштаба по умолчанию**
{{% alert color="primary" %}} 

Aspose.Slides для Android через Java теперь поддерживает установку значения масштаба по умолчанию для презентации, так чтобы при открытии презентации масштаб уже был установлен. Это можно сделать, установив [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) также могут быть установлены программно. В этой теме мы увидим на примере, как задать [Свойства представления](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) в [Aspose.Slides](/slides/).

{{% /alert %}} 

Для установки свойств представления. Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Установите [Свойства представления](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Запишите презентацию в файл [PPTX ](https://docs.fileformat.com/presentation/pptx/).
   В приведенном ниже примере мы установили значение масштаба для представления слайдов, а также для представления заметок.

```java
// Создать объект Presentation, который представляет файл презентации
Presentation presentation = new Presentation();
try {
    // Установка свойств представления для презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштаба в процентах для просмотра слайдов
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштаба в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```