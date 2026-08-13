---
title: Получить и обновить свойства представления презентации на Android
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/androidjava/presentation-view-properties/
keywords:
- свойства представления
- обычное представление
- содержание конспекта
- значки конспекта
- фиксация вертикального разделителя
- одиночное представление
- состояние панели
- размер измерения
- автонастройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Откройте для себя свойства представления Aspose.Slides для Android через Java, позволяющие настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный вид состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, касающиеся позиционирования различных областей содержимого. Эта информация позволяет приложению сохранять состояние представления в файл, чтобы при повторном открытии представление находилось в том же состоянии, в котором презентация была сохранена в последний раз.

Метод[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного представления презентации.  

[INormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties) интерфейсы и их наследники, [SplitterBarStateType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType) перечисление были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного представления.

Методы[getShowOutlineIcons](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и[setShowOutlineIcons](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, должно ли приложение показывать значки при отображении конспекта в любой из областей содержимого режима обычного представления.

Методы[getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и[setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) определяют, должен ли вертикальный разделитель переходить в минимизированное состояние, когда боковая область достаточно мала.

Свойство[getPreferSingleView](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и[setPreferSingleView](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) указывает, предпочитает ли пользователь видеть одну большую область содержимого во всём окне вместо стандартного обычного представления с тремя областями. Если включено, приложение может отобразить одну из областей содержимого во всём окне.

Методы[getVerticalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и[getHorizontalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд от нижней области содержимого, вертикальная полоса разделяет слайд от боковой области содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Методы[getRestoredLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и[getRestoredTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) задают размеры верхней или боковой области слайда обычного представления, когда для[getVerticalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и[getHorizontalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) используется значение[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении INormalViewProperties**

Указывает размеры области слайда (ширина, когда это дочерний элемент[getRestoredTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда дочерний элемент[getRestoredLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного представления, когда область имеет переменный восстановленный размер (не минимизирована и не максимизирована).  

Метод[getDimensionSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) указывает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).  

Метод[getAutoAdjust](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) определяет, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.  

Ниже приведён пример, показывающий, как получить свойства[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

```java
import com.aspose.slides.*;

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

## **Установить значение масштабирования по умолчанию**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) могут быть заданы программно. В этой статье мы покажем на примере, как задать [View Properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) в [Aspose.Slides](/slides/ru/).

{{% /alert %}} 

Для задания свойств представления выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштабирования как для просмотра слайда, так и для просмотра заметок.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Установка свойств представления презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштабирования в процентах для просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштабирования в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Могу ли я установить разные настройки представления для разных разделов презентации?

[View settings](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при его открытии.

### Могу ли я заранее определить разные состояния представления для разных пользователей?

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств представления.

### Могу ли я подготовить шаблон с предустановленными свойствами представления, чтобы новые презентации открывались одинаково?

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) хранятся на уровне презентации, вы можете встроить их в шаблон и создавать новые документы на его основе с той же начальной конфигурацией представления.