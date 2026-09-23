---
title: Получение и обновление свойств представления презентации в Java
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/java/presentation-view-properties/
keywords:
- свойства представления
- обычный режим
- содержание структуры
- значки структуры
- привязка вертикального разделителя
- одиночный режим
- состояние полосы
- размер измерения
- автоматическая корректировка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Ознакомьтесь со свойствами представления Aspose.Slides для Java, позволяющими настраивать форматы слайдов PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный режим отображения состоит из трех областей содержания: самого слайда, боковой области содержания и нижней области содержания. Свойства, относящиеся к позиционированию различных областей содержания. Эта информация позволяет приложению сохранять состояние представления в файл, чтобы при повторном открытии представление находилось в том же состоянии, что и при последнем сохранении презентации.

Метод [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) добавлен для предоставления доступа к свойствам обычного режима представления презентации. 

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties) и их потомки, [SplitterBarStateType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType) перечисление были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного режима представления.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, следует ли приложению показывать значки при отображении содержания структуры в любой из областей обычного режима представления.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) указывают, следует ли вертикальному разделителю переходить в свернутое состояние, когда боковая область достаточно мала.

Свойство [getPreferSingleView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) определяют, предпочитает ли пользователь видеть одну полноэкранную область содержания вместо стандартного обычного режима с тремя областями. При включении приложение может выбрать отображение одной из областей содержания на весь экран.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд от области содержания под слайдом, вертикальная — слайд от боковой области содержания. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) определяют размер верхней или боковой области слайда обычного режима, когда для [getVerticalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) применено значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/java/com.aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении INormalViewProperties**

Определяет размер области слайда (ширину, когда является дочерним элементом [getRestoredTop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), высоту, когда является дочерним элементом [getRestoredLeft](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного режима, когда область имеет переменный восстановленный размер (ни свернута, ни развернута). 

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) указывает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) определяет, должна ли боковая область содержания компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.

Ниже приведён пример, показывающий, как получить свойства [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

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

## **Установка значения масштабирования по умолчанию**

{{% alert color="info" %}} 

Aspose.Slides for Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже задан. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) могут быть заданы программно. В этой статье мы покажем пример, как установить [View Properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation) в Aspose.Slides.

{{% /alert %}} 

Чтобы установить свойства представления, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задаём значение масштабирования для просмотра слайда и заметок.

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

## **Установка интервала сетки**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--) для доступа к общим настройкам представления презентации. Методы [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iviewproperties/#getGridSpacing--) и [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта = один дюйм. Используйте положительное значение, как требует документация API.

В следующем примере открывается существующий `demo.pptx`, выводится текущий интервал сетки, задаётся интервал в четверть дюйма и сохраняется результат.

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

Сетка отличается от [drawing guides](/slides/ru/java/drawing-guides/). Интервал сетки задаёт регулярный шаг, а направляющие — отдельные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие служат вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или в режиме показа слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит её: видимость также зависит от настроек просмотрщика или редактора.

## **Показ или скрытие комментариев при открытии презентации**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--) для доступа к общим настройкам представления презентации. Методы [IViewProperties.getShowComments](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iviewproperties/#getShowComments--) и [IViewProperties.setShowComments](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) читают или изменяют сохранённую настройку, определяющую, должны ли комментарии показываться при открытии презентации в PowerPoint или другом совместимом редакторе.

Эта настройка управляет только сохранённой предпочтительной визуализацией. Она не добавляет, не удаляет, не изменяет и не решает комментарии. Сокрытие комментариев сохраняет их содержимое, авторов, позиции, ответы и статусы. Смотрите раздел [Presentation Comments](/slides/ru/java/presentation-comments/) для операций, изменяющих сами комментарии.

В следующем примере требуется существующий `comments.pptx` с комментариями. Пример выводит текущую настройку видимости, запрашивает скрытие комментариев и сохраняет новый PPTX без удаления комментариев. Также используется [IViewProperties.setLastView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iviewproperties/#setLastView-int-) с [ViewType.SlideView](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewtype/#SlideView) для конфигурации начального режима редактирования вместе с видимостью комментариев.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Эта настройка не определяет, будут ли комментарии включены в экспорт PDF, HTML, изображений, заметок или раздаточных материалов. Настройте соответствующие параметры экспорта отдельно.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но редактор контролирует её отображение. Проверьте настройки видимости сетки в редакторе.

**Изменит ли очистка направляющих интервал сетки?**

Нет. Направляющие и интервал сетки — независимые настройки. Очистка направляющих не меняет сохранённый интервал сетки.

**Можно ли задать разные настройки представления для разных секций презентации?**

Настройки представления ([View settings](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--)) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ru/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), а не по секциям, поэтому один набор параметров применяется ко всему документу при его открытии.

**Можно ли заранее определить разные состояния представления для разных пользователей?**

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но в самом файле хранится один набор свойств представления.

**Можно ли подготовить шаблон с предустановленными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку свойства представления ([view properties](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getViewProperties--)) сохраняются на уровне презентации, их можно встроить в шаблон и создавать новые документы на его основе с той же начальной конфигурацией представления.