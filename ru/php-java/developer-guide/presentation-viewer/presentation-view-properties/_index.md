---
title: Свойства нормального представления
type: docs
url: /php-java/presentation-view-properties/
---

{{% alert color="primary" %}} 

Нормальное представление состоит из трех областей контента: самого слайда, области бокового контента и области нижнего контента. Свойства, касающиеся позиционирования различных областей контента. Эта информация позволяет приложению сохранить состояние своего представления в файл, чтобы при повторном открытии представление находилось в том же состоянии, что и при последнем сохранении презентации.

Метод [**IViewProperties.*getNormalViewProperties***](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--) был добавлен для предоставления доступа к свойствам нормального представления презентации. 

Добавлены интерфейсы [**INormalViewProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties) и их потомки, перечисление [**SplitterBarStateType**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType).

{{% /alert %}} 


## **О INormalViewProperties** #
Представляет свойства нормального представления.

Методы [**getShowOutlineIcons**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) и [**setShowOutlineIcons**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) определяют, должна ли программа показывать значки при отображении контента в виде схематического представления в любой из областей контента режима нормального представления.

Методы [**getSnapVerticalSplitter**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) и [**setSnapVerticalSplitter**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) определяют, должен ли вертикальный разделитель "прилипать" к минимизированному состоянию, когда боковая область достаточно мала.

Свойство [**getPreferSingleView**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) и [**setPreferSingleView**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) определяет, предпочитает ли пользователь видеть область контента на весь экран вместо стандартного нормального представления с тремя областями контента. Если включено, приложение может выбрать отображение одной из областей контента на весь экран.

Методы [**getVerticalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) и [**getHorizontalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) определяют состояние, в котором должна быть показана горизонтальная или вертикальная панель разделителя. Горизонтальная панель разделителя отделяет слайд от области контента под слайдом, а вертикальная панель разделителя отделяет слайд от боковой области контента. Возможные значения: [**SplitterBarStateType::Minimized**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized), [**SplitterBarStateType::Maximized**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized) и [**SplitterBarStateType::Restored**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored).

Методы [**getRestoredLeft**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) и [**getRestoredTop**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) определяют размеры верхней или боковой области слайда нормального представления, когда значение [**SplitterBarStateType::Restored**](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) применяется для [**getVerticalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) и [**getHorizontalBarState**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) соответственно.


## **О восстановлении INormalViewProperties** 
Определяет размеры области слайда (ширина, когда она является дочерней к [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--), высота, когда она является дочерней к [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--)) нормального представления, когда регион имеет переменный восстановленный размер (не минимизированный и не максимизированный). 

Метод [**getDimensionSize**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) определяет размер области слайда (ширина, когда она является дочерней к restoredTop, высота, когда она является дочерней к restoredLeft).

Метод [**getAutoAdjust**](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) определяет, должна ли размер боковой области контента компенсироваться новым размером при изменении размера окна, содержащего представление в приложении.

Пример, приведенный ниже, показывает, как можно получить доступ к свойствам [**ViewProperties.getNormalViewProperties**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) для презентации.

```php
  # Создайте объект Presentation, представляющий файл презентации
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

## **Установить значение по умолчанию для зума**
{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java теперь поддерживает установку значения по умолчанию для зума презентации так, чтобы при открытии презентации зум был установлен заранее. Это можно сделать, установив [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) презентации. [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) и [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) могут быть установлены программно. В этой теме мы увидим на примере, как установить [Свойства представления](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) для [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) в [Aspose.Slides](/slides/).

{{% /alert %}} 

Чтобы установить свойства представления, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Установите [Свойства представления](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) презентации.
1. Запишите презентацию в файл [PPTX ](https://docs.fileformat.com/presentation/pptx/)файла.
   В приведенном ниже примере мы установили значение зума для представления слайда, а также представления заметок.

```php
  # Создайте объект Presentation, представляющий файл презентации
  $presentation = new Presentation();
  try {
    # Установка свойств представления презентации
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100);// Значение зума в процентах для представления слайда

    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100);// Значение зума в процентах для представления заметок

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```