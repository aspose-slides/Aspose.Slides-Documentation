---
title: Клонирование слайдов презентации в PHP
linktitle: Клонировать слайды
type: docs
weight: 35
url: /ru/php-java/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранить слайд
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides for PHP. Следуйте нашим понятным примерам кода, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---

## **Клонирование слайдов в презентации**
Клонирование – это процесс создания точной копии чего‑нибудь. Aspose.Slides for PHP via Java также позволяет создать копию или клон любого слайда, а затем вставить этот клон в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который может быть изменён разработчиком без изменения исходного слайда. Существует несколько способов клонировать слайд:

- Клонирование в конец внутри презентации.
- Клонирование в другую позицию внутри презентации.
- Клонирование в конец в другой презентации.
- Клонирование в другую позицию в другой презентации.
- Клонирование в конкретную позицию в другой презентации.

В Aspose.Slides for PHP via Java (коллекция объектов [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) ), доступная через объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), предоставляет методы [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) и [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone) для выполнения перечисленных типов клонирования слайдов.

## **Клонирование слайда в конец презентации**
Если необходимо клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) согласно шагам, перечисленным ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите объект [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides), ссылаясь на коллекцию слайдов, доступную через объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
3. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone), доступный у объекта [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides), передав в него слайд, который необходимо клонировать, в качестве параметра.
4. Сохраните изменённый файл презентации.

В примере ниже мы клонировали слайд (расположенный на первой позиции – нулевой индекс – презентации) в конец презентации.
```php
  # Создайте объект класса Presentation, представляющий файл презентации
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Клонируйте выбранный слайд в конец коллекции слайдов в той же презентации
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Запишите изменённую презентацию на диск
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Клонирование слайда в другую позицию внутри презентации**
Если необходимо клонировать слайд и затем использовать его в том же файле презентации, но в другой позиции, используйте метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Получите объект [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection), ссылаясь на коллекцию **Slides**([**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)), доступную через объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
3. Вызовите метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone), доступный у объекта [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides), и передайте в него слайд для клонирования вместе с индексом новой позиции в качестве параметров.
4. Сохраните изменённую презентацию в формате PPTX.

В примере ниже мы клонировали слайд (на нулевом индексе – позиция 1 – презентации) в индекс 1 – позицию 2 – презентации.
```php
  # Создайте объект класса Presentation, представляющий файл презентации
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Клонируйте выбранный слайд в конец коллекции слайдов в той же презентации
    $slds = $pres->getSlides();
    # Клонируйте выбранный слайд в указанный индекс в той же презентации
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Запишите изменённую презентацию на диск
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Клонирование слайда в конец другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащий презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащий целевую презентацию, в которую будет добавлен слайд.
3. Получите объект [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection), ссылаясь на коллекцию **Slides**([**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides)), доступную через объект Presentation целевой презентации.
4. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone), доступный у объекта [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides), и передайте в него слайд из исходной презентации в качестве параметра.
5. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.
```php
  # Создайте объект класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Создайте объект класса Presentation для целевого PPTX (куда будет клонирован слайд)
    $destPres = new Presentation();
    try {
      # Клонируйте выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Запишите целевую презентацию на диск
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Клонирование слайда в другую позицию в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации в конкретной позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащий презентацию, в которую будет добавлен слайд.
3. Получите класс [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides), ссылаясь на коллекцию Slides, доступную через объект Presentation целевой презентации.
4. Вызовите метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone), доступный у объекта [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides), и передайте в него слайд из исходной презентации вместе с желаемой позицией в качестве параметров.
5. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.
```php
  # Создайте объект класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Создайте объект класса Presentation для целевого PPTX (куда будет клонирован слайд)
    $destPres = new Presentation();
    try {
      # Клонируйте выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Запишите целевую презентацию на диск
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Клонирование слайда в конкретную позицию в другой презентации**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать требуемый мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд для клонирования слайда с мастер‑слайдом. Метод [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащий целевую презентацию, в которую будет клонирован слайд.
3. Получите доступ к слайду, который будет клонироваться, вместе с его мастер‑слайдом.
4. Инстанцируйте класс [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection), ссылаясь на коллекцию Masters, доступную через объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) целевой презентации.
5. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone), доступный у объекта [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection), и передайте в него мастер‑слайд из исходного PPTX в качестве параметра.
6. Инстанцируйте класс [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides), задав ссылку на коллекцию Slides, доступную через объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) целевой презентации.
7. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone), доступный у объекта [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides), и передайте в него слайд из исходной презентации и мастер‑слайд в качестве параметров.
8. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд с мастер‑слайдом (расположенный на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.
```php
  # Создайте объект класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Создайте объект класса Presentation для целевой презентации (куда будет клонирован слайд)
    $destPres = new Presentation();
    try {
      # Получите ISlide из коллекции слайдов исходной презентации вместе с
      # Мастер‑слайдом
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Склонируйте требуемый мастер‑слайд из исходной презентации в коллекцию мастеров в
      # целевой презентации
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Склонируйте требуемый мастер‑слайд из исходной презентации в коллекцию мастеров в
      # целевой презентации
      $iSlide = $masters->addClone($SourceMaster);
      # Склонируйте требуемый слайд из исходной презентации с нужным мастером в конец
      # коллекции слайдов целевой презентации
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Сохраните целевую презентацию на диск
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Клонирование слайда в конец указанного раздела**
Если необходимо клонировать слайд и затем использовать его в той же презентации, но в другом разделе, используйте метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone), доступный у класса [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java позволяет клонировать слайд из первого раздела и затем вставить его в второй раздел той же презентации.

Следующий фрагмент кода демонстрирует, как клонировать слайд и вставить его в указанный раздел.
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Сохраните целевую презентацию на диск
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**Клонируются ли примечания выступающего и комментарии рецензентов?**

Да. Страницы заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/php-java/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, встроенной в OLE книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/php-java/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Могу ли я управлять позицией вставки и разделами для клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и поместить его в выбранный [раздел](/slides/ru/php-java/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд в него.