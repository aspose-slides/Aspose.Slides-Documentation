---
title: Получить и обновить свойства представления презентации в Java
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/java/presentation-view-properties/
keywords:
- свойства представления
- обычный режим
- содержимое контура
- значки контура
- привязка вертикального разделителя
- один режим
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Откройте свойства представления Aspose.Slides for Java для настройки форматов PPT, PPTX и ODP—корректируйте макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычное представление состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию разных областей содержимого. Эта информация позволяет приложению сохранять состояние представления в файл, чтобы при повторном открытии представление было в том же состоянии, в котором презентация была сохранена в последний раз.

Метод[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного представления презентации.

Интерфейсы[INormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties),[INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties) и их потомки, [SplitterBarStateType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType) enum были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного представления.

Методы[getShowOutlineIcons](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и[setShowOutlineIcons](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, должна ли приложение показывать значки при отображении содержимого контура в любой из областей содержимого режима обычного представления.

Методы[getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и[setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) указывают, должен ли вертикальный разделитель переходить в минимизированное состояние, когда боковая область достаточно мала.

Свойства[getPreferSingleView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и[setPreferSingleView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) указывают, предпочитает ли пользователь видеть единую полноэкранную область содержимого вместо стандартного обычного представления с тремя областями. При включении приложение может отобразить одну из областей содержимого во всём окне.

Методы[getVerticalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и[getHorizontalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) определяют состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд и область содержимого под слайдом, вертикальная — слайд и боковую область содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Restored).

Методы[getRestoredLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и[getRestoredTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) определяют размеры верхней или боковой области слайда обычного представления, когда для[getVerticalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и[getHorizontalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) применяется значение[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении INormalViewProperties**

Определяет размеры области слайда (ширина, когда является дочерним элементом[getRestoredTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда является дочерним элементом[getRestoredLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного представления, когда область имеет переменный восстановленный размер (ни минимизирована, ни максимизирована).

Метод[getDimensionSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) задаёт размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Метод[getAutoAdjust](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) указывает, должна ли область бокового содержимого компенсировать новый размер при изменении размера окна, содержащего представление в приложении.

Ниже приведён пример, показывающий, как получить свойства[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) презентации.

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

Aspose.Slides for Java теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) можно задать программно. В этой статье мы рассмотрим пример, как задать [View Properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) объекта [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation) в Aspose.Slides.

{{% /alert %}} 

Для установки свойств представления выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) объекта [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
1. Сохраните презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштаба как для просмотра слайдов, так и для просмотра заметок.

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

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--) для доступа к настройкам представления всей презентации. Методы[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iviewproperties/#getGridSpacing--) и[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки задаётся в пунктах, где 72 пункта = один дюйм. Используйте положительное значение, как указано в документации API.

Следующий пример открывает существующий `demo.pptx`, выводит текущий интервал сетки, задаёт интервал в четверть дюйма и сохраняет результат.

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

Сетка отличается от [drawing guides](/slides/ru/java/drawing-guides/). Интервал сетки задаёт регулярный шаг, тогда как направляющие рисуются как отдельные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или в демонстрации. Сохранение интервала сетки не гарантирует, что редактор отобразит сетку: её видимость также зависит от настроек просмотрщика или редактора.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет значение интервала сетки, но отображение сетки контролирует редактор. Проверьте настройки видимости сетки в используемом редакторе.

**Изменяется ли интервал сетки при удалении направляющих?**

Нет. Направляющие и интервал сетки — независимые параметры. Очистка направляющих не меняет сохранённый интервал сетки.

**Можно ли задать разные настройки представления для разных разделов презентации?**

Настройки представления([View settings](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--)) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли предварительно определить разные состояния представления для разных пользователей?**

Нет. Параметры хранятся в файле и общие для всех. Приложения‑просмотрщики могут учитывать пользовательские предпочтения, но в самом файле хранится один набор свойств представления.

**Можно ли подготовить шаблон с предустановленными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--) сохраняются на уровне презентации, их можно включить в шаблон и создавать новые документы на его основе с теми же начальными настройками представления.