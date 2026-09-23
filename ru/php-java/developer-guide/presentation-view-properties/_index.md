---
title: "Получить и обновить свойства представления презентации в PHP"
linktitle: "Свойства представления"
type: docs
weight: 80
url: /ru/php-java/presentation-view-properties/
keywords:
- "свойства представления"
- "обычный режим"
- "контент контура"
- "значки контура"
- "привязка вертикального разделителя"
- "одиночный режим"
- "состояние полосы"
- "размер измерения"
- "автоматическая настройка"
- "масштаб по умолчанию"
- PowerPoint
- OpenDocument
- "презентация"
- PHP
- Aspose.Slides
description: "Откройте для себя свойства представления Aspose.Slides для PHP через Java, позволяющие настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный режим просмотра состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, касающиеся позиционирования различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр был в том же состоянии, что и при последнем сохранении презентации.

Метод [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) был добавлен для предоставления доступа к свойствам обычного режима просмотра презентации.  

[NormalViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewRestoredProperties), классы и их наследники, перечисление [SplitterBarStateType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType) были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного режима просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) указывают, следует ли приложению показывать значки при отображении содержимого контура в любой из областей содержимого обычного режима просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) указывают, следует ли вертикальному разделителю переходить в свернутое состояние, когда боковая область достаточно мала.

Свойства [getPreferSingleView](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) и [setPreferSingleView](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) указывают, предпочитает ли пользователь видеть одноконтентную область во весь экран вместо стандартного обычного режима просмотра с тремя областями содержимого. При включении приложение может выбрать отображать одну из областей содержимого на весь экран.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) определяют состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделителя отделяет слайд от области содержимого под слайдом, вертикальная полоса разделителя отделяет слайд от боковой области содержимого. Возможные значения: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType/#Maximized) и [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType/#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) и [getRestoredTop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties#getRestoredTop) задают размеры верхней или боковой области слайда в обычном режиме просмотра, когда значение [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType/#Restored) применяется к [getVerticalBarState](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) соответственно.

## **О восстановлении INormalViewProperties**

Указывает размеры области слайда (ширина, когда является дочерним элементом [getRestoredTop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), высота, когда является дочерним элементом [getRestoredLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) обычного режима просмотра, когда область имеет переменный восстановленный размер (не свернута и не развернута).  

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) задает размер области слайда (ширина, когда является дочерним элементом restoredTop, высота, когда является дочерним элементом restoredLeft).  

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) указывает, должен ли размер боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.  

Ниже приведён пример, показывающий, как получить доступ к свойствам [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) для презентации.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Восстановить свойства представления презентации
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Установить значение масштабирования по умолчанию**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) могут быть установлены программно. В этой теме мы на примере покажем, как установить [View Properties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation) в Aspose.Slides.

{{% /alert %}} 

Чтобы установить свойства просмотра, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
1. Установите [View Properties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштабирования для просмотра слайда, а также для просмотра заметок.

```php
  $presentation = new Presentation();
  try {
    # Установка свойств представления презентации
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Значение масштабирования в процентах для просмотра слайда
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Значение масштабирования в процентах для просмотра заметок

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Установить интервал сетки**

Используйте [Presentation::getViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getViewProperties) для доступа к настройкам просмотра на уровне всей презентации. Методы [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/#getGridSpacing) и [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/#setGridSpacing) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта равняются одному дюйму. Используйте положительное значение, как требуется в документации API.

Следующий пример открывает существующий `demo.pptx`, выводит текущий интервал сетки, задаёт интервал в четверть дюйма и сохраняет результат.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Сетка отличается от [drawing guides](/slides/ru/php-java/drawing-guides/). Интервал сетки задаёт регулярный промежуток, тогда как направляющие рисования — это отдельные горизонтальные или вертикальные линии выравнивания. Добавление, перемещение или удаление направляющих не меняет интервал сетки.

И сетка, и направляющие являются вспомогательными средствами редактирования. Они не отображаются как содержимое слайда в PDF, изображениях, SVG или в показе слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит её: её видимость также зависит от настроек просмоторщика или редактора.

## **Показать или скрыть комментарии при открытии презентации**

Используйте [Presentation::getViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getviewproperties/) для доступа к настройкам просмотра на уровне всей презентации. Используйте [ViewProperties::getShowComments](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/getshowcomments/) и [ViewProperties::setShowComments](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/setshowcomments/) для чтения или изменения сохранённого предпочтения, показывать ли комментарии при открытии презентации в PowerPoint или другом совместимом редакторе.

Эта настройка управляет только сохранённым предпочтением просмотра. Она не добавляет, не удаляет, не редактирует и не разрешает комментарии. Скрытие комментариев сохраняет их содержимое, авторов, позиции, ответы и статусы. См. [Presentation Comments](/slides/ru/php-java/presentation-comments/) для операций, изменяющих сами комментарии.

Следующий пример требует существующий `comments.pptx` с комментариями. Он выводит текущую настройку видимости, запрашивает скрыть комментарии и сохраняет новый PPTX без удаления комментариев. Также используется [ViewProperties::setLastView](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/setlastview/) совместно с [ViewType::SlideView](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewtype/#SlideView) для настройки начального режима редактирования вместе с видимостью комментариев.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Эта настройка не определяет, будут ли комментарии включены в экспорт в PDF, HTML, изображение, заметки или раздаточные материалы. Настройте соответствующие параметры экспорта отдельно.

## **Часто задаваемые вопросы**

**Почему сетка не видна после повторного открытия презентации?**

Файл сохраняет интервал сетки, но отображение сетки контролируется редактором. Проверьте настройки видимости сетки в редакторе.

**Изменит ли очистка направляющих рисования интервал сетки?**

Нет. Направляющие рисования и интервал сетки — независимые настройки. Очистка направляющих оставляет сохранённый интервал сетки без изменений.

**Могу ли я задать разные настройки просмотра для разных разделов презентации?**

[Настройки просмотра](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getviewproperties/) определяются на уровне презентации ([Normal View]/[Slide View]), а не для каждого раздела, поэтому один набор параметров применяется ко всему документу при его открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и общие для всех. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Могу ли я подготовить шаблон с предопределёнными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [свойства просмотра](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getviewproperties/) хранятся на уровне презентации, их можно включить в шаблон и создавать из него новые документы с одинаковой начальной конфигурацией просмотра.