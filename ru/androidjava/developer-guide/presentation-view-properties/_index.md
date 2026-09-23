---
title: "Получение и обновление свойств представления презентации на Android"
linktitle: "Свойства представления"
type: docs
weight: 80
url: /ru/androidjava/presentation-view-properties/
keywords:
- "свойства представления"
- "обычный режим"
- "содержание контура"
- "значки контура"
- "привязка вертикального разделителя"
- "одиночный просмотр"
- "состояние полосы"
- "размер измерения"
- "автоматическая настройка"
- "масштаб по умолчанию"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Откройте для себя Aspose.Slides для Android через Java свойства представления, чтобы настраивать форматы слайдов PPT, PPTX и ODP — изменять макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный режим просмотра состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр был в том же состоянии, в котором презентация была сохранена в последний раз.

Метод [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного режима просмотра презентации. 

Интерфейсы [INormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties) и их наследники, а также перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType) были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного режима просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, следует ли приложению показывать значки при отображении контента контура в любой из областей содержимого обычного режима просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) определяют, должен ли вертикальный разделитель переходить в свёрнутое состояние, когда боковая область достаточно мала.

Свойства [getPreferSingleView](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) и [setPreferSingleView](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) указывают, предпочитает ли пользователь видеть одн регион содержимого на весь экран вместо стандартного обычного режима просмотра с тремя областями содержимого. Если включено, приложение может выбрать отображать одну из областей содержимого во всём окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) и [getRestoredTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) задают размеры верхней или боковой области слайда в обычном режиме просмотра, когда для [getVerticalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) применяется значение [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

## **О восстановлении INormalViewProperties**

Определяет размеры области слайда (ширина, когда является дочерним элементом [getRestoredTop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда является дочерним элементом [getRestoredLeft](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного режима просмотра, когда область имеет переменный восстановленный размер (ни свернута, ни развернута). 

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) задает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) указывает, должна ли ширина боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

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

Aspose.Slides for Android via Java теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) можно установить программно. В этой статье мы рассмотрим пример, как задать [View Properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) в Aspose.Slides.

{{% /alert %}} 

Чтобы задать свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Сохраните презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/). В приведённом ниже примере мы задали значение масштаба для просмотра слайда, а также для просмотра заметок.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Установка свойств представления презентации
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Значение масштаба в процентах для режима просмотра слайда
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Значение масштаба в процентах для режима просмотра заметок 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить интервал сетки**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) для доступа к настройкам представления, применяемым ко всей презентации. Методы [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) и [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как указано в документации API.

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

Сетка отличается от [drawing guides](/slides/ru/androidjava/drawing-guides/). Интервал сетки регулирует регулярный шаг, тогда как направляющие рисуются отдельными горизонтальными или вертикальными линиями выравнивания. Добавление, перемещение или очистка направляющих не меняет интервал сетки.

И сетка, и направляющие служат вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или слайд-шоу. Сохранение интервала сетки неGuarantee? Wait Russian: "Сохранение интервала сетки не гарантирует, что редактор отобразит сетку: её видимость также зависит от настроек просмотрщика или редактора." Let's write correctly.

И сетка, и направляющие служат вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или слайд‑шоу. Сохранение интервала сетки не гарантирует, что редактор отобразит сетку: её видимость также зависит от настроек просмотрщика или редактора.

## **Показать или скрыть комментарии при открытии презентации**

Используйте [Presentation.getViewProperties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) для доступа к настройкам представления, применяемым ко всей презентации. Используйте [IViewProperties.getShowComments](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) и [IViewProperties.setShowComments](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) для чтения или изменения сохранённого предпочтения, показывать ли комментарии при открытии презентации в PowerPoint или другом совместимом редакторе.

Эта настройка управляет только сохранённым предпочтением отображения. Она не добавляет, не удаляет, не редактирует и не разрешает комментарии. Сокрытие комментариев сохраняет их содержимое, авторов, позиции, ответы и статусы. Смотрите раздел [Presentation Comments](/slides/ru/androidjava/presentation-comments/) для операций, изменяющих сами комментарии.

Следующий пример требует наличия файла `comments.pptx` с комментариями. Он выводит текущую настройку видимости, запрашивает скрытие комментариев и сохраняет новый PPTX без удаления комментариев. Также используется [IViewProperties.setLastView](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) совместно с [ViewType.SlideView](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewtype/#SlideView) для настройки начального режима редактирования вместе с видимостью комментариев.

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

Эта настройка не определяет, включаются ли комментарии в экспорты PDF, HTML, изображения, заметки или раздаточные материалы. Настройте соответствующие параметры экспорта отдельно.

## **Часто задаваемые вопросы**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет значение интервала сетки, но отображение сетки контролируется редактором. Проверьте настройки видимости сетки в редакторе.

**Удаление направляющих изменяет интервал сетки?**

Нет. Направляющие и интервал сетки — независимые настройки. Очистка направляющих не меняет сохранённый интервал сетки.

**Могу ли я задать разные настройки просмотра для разных разделов презентации?**

Настройки просмотра [View settings](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), а не для каждого раздела, поэтому один набор параметров применяется к документу в целом при открытии.

**Могу ли я заранее задать разные состояния просмотра для разных пользователей?**

Нет. Настройки сохраняются в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Могу ли я подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getViewProperties--) сохраняются на уровне презентации, их можно включить в шаблон и создавать новые документы на его основе с одинаковой начальной конфигурацией просмотра.