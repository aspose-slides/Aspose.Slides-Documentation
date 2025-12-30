---
title: Получить и обновить свойства представления презентации в PHP
linktitle: Свойства представления
type: docs
weight: 80
url: /ru/php-java/presentation-view-properties/
keywords:
- свойства представления
- обычный вид
- контурное содержание
- значки контура
- привязка вертикального разделителя
- одиночное представление
- состояние полосы
- размер измерения
- автоматическая настройка
- масштаб по умолчанию
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Откройте возможности Aspose.Slides для PHP через Java, используя свойства представления, чтобы настраивать форматы слайдов PPT, PPTX и ODP — регулировать макеты, уровни масштабирования и параметры отображения."
---

{{% alert color="primary" %}} 

Обычный вид состоит из трех областей содержимого: самого слайда, боковой области содержимого и нижней области содержимого. Свойства, относящиеся к позиционированию различных областей содержимого. Эта информация позволяет приложению сохранять состояние представления в файл, чтобы при повторном открытии представление было в том же состоянии, что и при последнем сохранении презентации.

Метод[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам обычного представления презентации.  

Интерфейсы[INormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties) и их потомки, а также перечисление[SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) были добавлены.

{{% /alert %}} 

## **О INormalViewProperties**

Представляет свойства обычного представления.

Методы[getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) и[setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) указывают, должен ли приложение показывать значки при отображении контурного содержимого в любой из областей содержимого режима обычного представления.

Методы[getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и[setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) определяют, должен ли вертикальный разделитель переходить в свернутое состояние, когда боковая область достаточно мала.

Свойства[getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) и[setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) указывают, предпочитает ли пользователь видеть одно содержимое на весь экран вместо стандартного обычного представления с тремя областями. Если включено, приложение может выбрать отображать одну из областей содержимого на весь экран.

Методы[getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) и[getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) задают состояние, в котором должна отображаться горизонтальная или вертикальная полоса разделителя. Горизонтальный разделитель отделяет слайд от области содержимого под слайдом, вертикальный — от боковой области содержимого. Возможные значения: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized) и [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored).

Методы[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) и[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) определяют размеры верхней или боковой области слайда обычного представления, когда для[getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) и[getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) применено значение[SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) соответственно.

## **О восстановлении INormalViewProperties**

Указывает размеры области слайда (ширина, когда является дочерним элементом[getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда является дочерним элементом[getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--)) обычного представления, когда область имеет переменный восстановленный размер (не свернута и не развернута).  

Метод[getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) указывает размер области слайда (ширина, когда дочерний элемент restoredTop, высота, когда дочерний элемент restoredLeft).  

Метод[getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) определяет, должна ли размер боковой области содержимого компенсировать новый размер при изменении размеров окна, содержащего представление в приложении.  

Ниже приведен пример, показывающий, как получить доступ к свойствам[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.  
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


## **Установить значение масштаба по умолчанию**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java теперь поддерживает установку значения масштаба по умолчанию для презентации, так что при открытии презентации масштаб уже установлен. Это можно сделать, задав[ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) могут быть установлены программно. В этой статье мы покажем на примере, как задать[View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) для[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) в[Aspose.Slides](/slides/ru/).  

{{% /alert %}} 

Для установки свойств представления выполните следующие шаги:

1. Создайте экземпляр класса[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. Задайте[View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) для[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. Запишите презентацию как файл[PPTX](https://docs.fileformat.com/presentation/pptx/). В приведенном ниже примере мы задали значение масштаба для просмотра слайдов, а также для заметок.  
```php
  $presentation = new Presentation();
  try {
    # Установка свойств представления презентации
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Значение масштаба в процентах для просмотра слайда
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Значение масштаба в процентах для просмотра заметок

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Часто задаваемые вопросы**

**Могу ли я задать разные настройки представления для разных разделов презентации?**

Настройки представления определяются на уровне презентации ([Normal View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)), а не для отдельного раздела, поэтому один набор параметров применяется ко всему документу при открытии.

**Могу ли я заранее определить разные состояния представления для разных пользователей?**

Нет. Настройки хранятся в файле и являются общими. Приложения‑просмотрщики могут учитывать предпочтения пользователя, но сам файл содержит один набор свойств представления.

**Могу ли я подготовить шаблон с предопределенными свойствами представления, чтобы новые презентации открывались одинаково?**

Да. Поскольку свойства представления хранятся на уровне презентации, их можно включить в шаблон и создавать из него новые документы с той же начальной конфигурацией представления.