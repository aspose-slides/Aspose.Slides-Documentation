---
title: Получение и обновление свойств представления презентации в PHP
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/php-java/presentation-view-properties/
keywords:
- свойства представления
- обычный просмотр
- содержание плана
- значки плана
- привязка вертикального разделителя
- одиночный просмотр
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Ознакомьтесь со свойствами представления Aspose.Slides for PHP via Java, чтобы настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---
## **Введение**

Обычный просмотр состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранять состояние просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, в котором презентация была сохранена в последний раз.

Метод [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) был добавлен для доступа к свойствам обычного просмотра презентации. 

Классы [NormalViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewRestoredProperties) и их потомки, enum [SplitterBarStateType](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType) были добавлены.

## **О INormalViewProperties**

Представляет свойства обычного просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) и [setShowOutlineIcons](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) указывают, следует ли приложению показывать значки при отображении содержания плана в любой из областей содержимого режима обычного просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) указывают, должен ли вертикальный разделитель переходить в свернутое состояние, когда боковая область достаточно мала.

Свойства [getPreferSingleView](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) и [setPreferSingleView](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) указывают, предпочитает ли пользователь видеть одну область содержимого на весь экран вместо стандартного обычного просмотра с тремя областями содержимого. Если включено, приложение может отобразить одну из областей содержимого во всём окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) определяют состояние, в котором должна быть отображена горизонтальная или вертикальная полоса разделителя. Горизонтальная полоса разделяет слайд и область содержимого под слайдом, вертикальная полоса разделяет слайд и боковую область содержимого. Возможные значения: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType/#Maximized) и [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType/#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) и [getRestoredTop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties#getRestoredTop) задают размер верхней или боковой области слайда обычного просмотра, когда для [getVerticalBarState](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) применяется значение [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SplitterBarStateType/#Restored).

## **О восстановлении INormalViewProperties**

Определяет размер области слайда (ширина, когда является дочерним элементом [getRestoredTop](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), высота, когда является дочерним элементом [getRestoredLeft](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) обычного просмотра, когда область имеет переменный восстановленный размер (не свернуто и не развернуто). 

Метод [getDimensionSize](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) указывает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).

Метод [getAutoAdjust](https://reference.aspose.com/slides/ru/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить свойства [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) для презентации.

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

## **Установка значения масштабирования по умолчанию**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже задан. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) и [getNotesViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) могут быть установлены программно. В этой статье мы покажем на примере, как задать [View Properties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation) в Aspose.Slides.

{{% /alert %}} 

Для установки свойств просмотра выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/ViewProperties) у [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation).
1. Сохраните презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштабирования для просмотра слайдов, а также для просмотра заметок.

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

## **Установка интервала сетки**

Используйте [Presentation::getViewProperties](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#getViewProperties) для доступа к глобальным настройкам просмотра презентации. Методы [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/#getGridSpacing) и [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/#setGridSpacing) читают или изменяют интервал базовой сетки редактирования. Эта настройка применяется ко всей презентации, а не к отдельному слайду. Интервал сетки указывается в пунктах, где 72 пункта равны одному дюйму. Используйте положительное значение, как требуется в документации API.

В следующем примере открывается существующий файл `demo.pptx`, выводится текущий интервал сетки, устанавливается интервал в четверть дюйма и сохраняется результат.

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

Сетка отличается от [drawing guides](/slides/ru/php-java/drawing-guides/). Интервал сетки задаёт регулярный шаг, а направляющие — это отдельные горизонтальные или вертикальные линии выравнивания, которые позиционируются вручную. Добавление, перемещение или удаление направляющих не изменяют интервал сетки.

И сетка, и направляющие служат вспомогательными средствами редактирования. Они не отрисовываются как содержимое слайда в PDF, изображениях, SVG или в режиме показа слайдов. Сохранение интервала сетки не гарантирует, что редактор отобразит сетку: её видимость также зависит от предпочтений программы‑просмотрщика или редактора.

## **FAQ**

**Почему сетка не видна после повторного открытия презентации?**

Файл хранит значение интервала сетки, но отображение сетки контролируется самим редактором. Проверьте настройки видимости сетки в редакторе.

**Изменит ли очистка направляющих интервал сетки?**

Нет. Направляющие и интервал сетки — независимые параметры. Очистка направляющих не меняет сохранённый интервал сетки.

**Можно ли задать разные настройки просмотра для разных разделов презентации?**

[Настройки просмотра](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getviewproperties/) определяются на уровне всей презентации ([Normal View](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ru/php-java/aspose.slides/viewproperties/getslideviewproperties/)), а не по разделам, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и общие для всех. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [свойства просмотра](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/getviewproperties/) сохраняются на уровне презентации, их можно включить в шаблон, и новые документы, созданные из него, будут иметь ту же начальную конфигурацию просмотра.