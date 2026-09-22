---
title: Получить и обновить свойства представления презентации на Android
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/androidjava/presentation-view-properties/
keywords: 
- свойства представления
- обычный режим
- контурное содержимое
- значки контура
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
description: "Откройте свойства представления Aspose.Slides для Android через Java, чтобы настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштаба и параметры отображения."
---
## **Введение**

Обычный режим отображения состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к расположению различных областей содержимого. Эта информация позволяет приложению сохранять состояние представления в файл, так что при повторном открытии представление находится в том же состоянии, что и при последнем сохранении презентации.

Метод [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного представления презентации. 

[INormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties) интерфейсы и их потомки, [SplitterBarStateType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType) перечисление были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного представления.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, следует ли приложению показывать значки при отображении контурного содержимого в любой из областей содержимого режима обычного представления.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) указывают, должен ли вертикальный разделитель переходить в свернутое состояние, когда боковая область достаточно мала.

Свойство [getPreferSingleView](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) определяют, предпочитает ли пользователь видеть одностраничный полноэкранный режим вместо стандартного обычного режима с тремя областями содержимого. Если включено, приложение может выбрать отображение одной из областей содержимого во всем окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) указывают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого ниже слайда, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) задают размер верхней или боковой области слайда в обычном режиме, когда для [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Restored) применяется значение [getVerticalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) соответственно.

## **О восстановлении INormalViewProperties**

Определяет размер области слайда (ширина, когда является дочерним элементом [getRestoredTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда является дочерним элементом [getRestoredLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного представления, когда область имеет переменный восстановленный размер (не свернутый и не развернутый). 

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) задает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) указывает, должна ли размер боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.

Ниже приведен пример, показывающий, как получить доступ к свойствам [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

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

## **Установить значение масштаба по умолчанию**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) могут быть заданы программно. В этой статье мы покажем на примере, как установить [View Properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) в Aspose.Slides.

{{% /alert %}} 

Чтобы установить свойства представления, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Установите [View Properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).
   В приведенном ниже примере мы задали значение масштаба для просмотра слайдов, а также для просмотра заметок.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Установка свойств представления презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштаба в процентах для просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштаба в процентах для просмотра заметок 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить интервал сетки**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) для доступа к настройкам представления, применяемым ко всей презентации. Методы [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) и [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки задается в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как требует документация API.

Следующий пример открывает существующий `demo.pptx`, выводит текущий интервал сетки, задает интервал в четверть дюйма и сохраняет результат.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Сетка отличается от [drawing guides](/slides/ru/androidjava/drawing-guides/). Интервал сетки задает регулярный интервал, тогда как направляющие рисования представляют собой индивидуально расположенные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не изменяют интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или слайд-шоу. Сохранение интервала сетки не гарантирует, что редактор отобразит сетку: её видимость также зависит от настроек просмотрщика или редактора.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но редактор управляет тем, отображается ли сетка. Проверьте настройки видимости сетки в редакторе.

**Удаление направляющих изменяет интервал сетки?**

Нет. Направляющие и интервал сетки — независимые параметры. Очистка направляющих не меняет сохранённый интервал сетки.

**Могу ли я задать разные настройки представления для разных разделов презентации?**

Настройки [View settings](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Могу ли я заранее определить разные состояния представления для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств представления.

**Могу ли я подготовить шаблон с предопределёнными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) хранятся на уровне презентации, их можно встроить в шаблон и создавать новые документы с тем же начальным конфигурированием представления.