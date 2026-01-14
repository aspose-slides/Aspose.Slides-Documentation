---
title: Получение и обновление свойств представления презентации в PHP
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/php-java/presentation-view-properties/
keywords:
- свойства представления
- обычный режим
- контурное содержимое
- иконки контура
- привязка вертикального разделителя
- одиночный режим
- состояние полосы
- размер измерения
- автонастройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте о свойствах представления Aspose.Slides для PHP via Java, позволяющих настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Обычный режим просмотра состоит из трёх областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранить состояние просмотра в файл, чтобы при повторном открытии просмотр находился в том же состоянии, что и при последнем сохранении презентации.

Метод [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) был добавлен для предоставления доступа к свойствам обычного режима просмотра презентации. 

Классы [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties) и их наследники, перечисление [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) были добавлены.

{{% /alert %}} 

## **О INormalViewProperties**

Представляет свойства обычного режима просмотра.

Методы [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) и [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) указывают, следует ли приложению показывать значки при отображении контурного содержимого в любой из областей содержимого обычного режима просмотра.

Методы [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) и [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) указывают, должна ли вертикальная разделительная полоса переходить в минимизированное состояние, когда боковая область достаточно мала.

Свойства [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) и [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) указывают, предпочитает ли пользователь видеть одинокую область содержимого во весь экран вместо стандартного обычного режима с тремя областями. При включённом параметре приложение может отобразить одну из областей содержимого на всём окне.

Методы [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) задают состояние, в котором должна отображаться горизонтальная или вертикальная разделительная полоса. Горизонтальная полоса разделяет слайд и область содержимого под слайдом, вертикальная — слайд и боковую область. Возможные значения: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Maximized) и [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored).

Методы [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) и [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties#getRestoredTop) задают размеры верхней или боковой области слайда обычного режима, когда для [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) и [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) применено значение [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored).

## **О восстановлении INormalViewProperties**

Указывает размеры области слайда (ширина, когда это дочерний элемент [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), высота, когда это дочерний элемент [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) обычного режима, когда область имеет переменный восстановленный размер (не минимизирована и не максимизирована). 

Метод [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) указывает размер области слайда (ширина, когда это дочерний элемент restoredTop, высота, когда это дочерний элемент restoredLeft).

Метод [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) указывает, должна ли боковая область содержимого компенсировать новый размер при изменении размеров окна, содержащего просмотр в приложении.

Ниже приведён пример, показывающий, как получить доступ к свойствам [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) презентации.
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
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java теперь поддерживает установку значения масштабирования по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) презентации. Методы [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) и [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) могут быть установлены программно. В этой статье мы покажем на примере, как задать [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) в [Aspose.Slides](/slides/ru/).

{{% /alert %}} 

Чтобы задать свойства просмотра, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Задайте [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Сохраните презентацию как файл [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   В приведённом ниже примере мы задали значение масштабирования для просмотра слайда и просмотра заметок.
```php
  $presentation = new Presentation();
  try {
    # Установка свойств просмотра презентации
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Значение масштабирования в процентах для просмотра слайда
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Значение масштабирования в процентах для просмотра заметок

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Можно ли задать разные настройки просмотра для разных разделов презентации?**

[View settings](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) определяются на уровне всей презентации ([Normal View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)), а не для отдельного раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Можно ли заранее определить разные состояния просмотра для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств просмотра.

**Можно ли подготовить шаблон с предустановленными свойствами просмотра, чтобы новые презентации открывались одинаково?**

Да. Поскольку [view properties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) сохраняются на уровне презентации, их можно включить в шаблон и создавать из него новые документы с тем же начальным конфигурированием просмотра.