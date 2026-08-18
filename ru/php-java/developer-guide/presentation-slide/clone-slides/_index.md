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
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides для PHP. Следуйте нашим понятным примерам кода, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---
## **Введение**

Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for PHP via Java также позволяет сделать копию или клон любого слайда, а затем вставить этот клонированный слайд в текущую или любую другую открывшуюся презентацию. Процесс клонирования слайда создаёт новый слайд, который разработчики могут изменять, не затрагивая оригинальный слайд. Существует несколько способов клонирования слайда:

- Клонирование в конец в пределах презентации.
- Клонирование в другое положение в пределах презентации.
- Клонирование в конец в другой презентации.
- Клонирование в другое положение в другой презентации.
- Клонирование в конкретном положении в другой презентации.

В Aspose.Slides for PHP via Java (коллекция объектов [Slide](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Slide)), доступная через объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation), предоставляет методы [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone) и [insertClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#insertClone) для выполнения перечисленных типов клонирования слайдов.

## **Клонирование слайда в конец презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone) согласно шагам, перечисленным ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
1. Получите объект [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides), ссылаясь на коллекцию слайдов, доступную через объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone), доступный у объекта [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides), и передайте слайд, который нужно клонировать, в качестве параметра метода [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone).
1. Сохраните изменённый файл презентации.

В приведённом ниже примере мы клонировали слайд (находящийся на первой позиции — нулевой индекс — презентации) в конец презентации.

```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Клонировать выбранный слайд в конец коллекции слайдов в той же презентации
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Записать изменённую презентацию на диск
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Клонирование слайда в другое положение в пределах презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом положении, используйте метод [insertClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#insertClone):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
1. Получите объект [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection), ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides), доступную через объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation).
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#insertClone), доступный у объекта [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides), и передайте слайд для клонирования вместе с индексом нового положения в качестве параметра метода [insertClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#insertClone).
1. Сохраните изменённый файл презентации в формате PPTX.

В приведённом ниже примере мы клонировали слайд (находящийся на нулевом индексе — позиция 1 — презентации) в индекс 1 — позиция 2 — презентации.

```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Клонировать выбранный слайд в конец коллекции слайдов в той же презентации
    $slds = $pres->getSlides();
    # Клонировать выбранный слайд в указанный индекс в той же презентации
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Записать изменённую презентацию на диск
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Клонирование слайда в конец другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation), содержащий презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation), содержащий целевую презентацию, в которую будет добавлен слайд.
1. Получите объект [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection), ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides), доступную через объект Presentation целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone), доступный у объекта [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides), и передайте слайд из исходной презентации в качестве параметра метода [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone).
1. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

```php
  # Создать экземпляр класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    $destPres = new Presentation();
    try {
      # Клонировать выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Записать целевую презентацию на диск
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Клонирование слайда в другое положение в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, в конкретном положении:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation), содержащий презентацию, в которую будет добавлен слайд.
1. Получите объект [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides), ссылаясь на коллекцию Slides, доступную через объект Presentation целевой презентации.
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#insertClone), передав слайд из исходной презентации вместе с желаемым положением в качестве параметра метода [insertClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#insertClone).
1. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```php
  # Создать экземпляр класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    $destPres = new Presentation();
    try {
      # Клонировать выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Записать целевую презентацию на диск
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Клонирование слайда в конкретном положении в другой презентации**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать нужный мастер‑слайд из исходной презентации в целевую. Затем следует использовать этот мастер‑слайд для клонирования слайда с мастер‑слайдом. Метод [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slidecollection/addclone/) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation), содержащий целевую презентацию, в которую будет клонирован слайд.
1. Получите доступ к слайду, который будет клонирован, вместе с его мастер‑слайдом.
1. Создайте экземпляр класса [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/MasterSlideCollection), ссылаясь на коллекцию Masters, доступную через объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone], доступный у объекта [MasterSlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/MasterSlideCollection), и передайте мастер из исходного PPTX для клонирования в качестве параметра метода [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone).
1. Создайте экземпляр класса [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides), установив ссылку на коллекцию Slides, доступную через объект [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone] у объекта [SlideCollection](https://reference.aspose.com/slides/ru/php-java/aspose.slides/Presentation/#getSlides) и передайте в него слайд из исходной презентации для клонирования и мастер‑слайд в качестве параметров метода [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone).
1. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд с мастером (находящийся на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер из исходного слайда.

```php
  # Создать экземпляр класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Создать экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    $destPres = new Presentation();
    try {
      # Получить ISlide из коллекции слайдов исходной презентации вместе с
      # мастер‑слайдом
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
      # целевой презентации
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
      # целевой презентации
      $iSlide = $masters->addClone($SourceMaster);
      # Клонировать нужный слайд из исходной презентации с выбранным мастером в конец
      # коллекции слайдов в целевой презентации
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Сохранить целевую презентацию на диск
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Клонирование слайда в конец указанного раздела**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [addClone](https://reference.aspose.com/slides/ru/php-java/aspose.slides/SlideCollection/#addClone), предоставляемый классом [SlideCollection]. Aspose.Slides for PHP via Java позволяет клонировать слайд из первого раздела и вставить его в второй раздел той же презентации.

Ниже приведён фрагмент кода, показывающий, как клонировать слайд и вставить клонированный слайд в указанный раздел.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
  # Сохранить целевую презентацию на диск
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Обеспечение совпадения размера слайдов**

При клонировании слайдов в другую презентацию убедитесь, что размер слайдов целевой презентации совпадает с размером исходной. Если размеры различаются, Aspose.Slides не масштабирует автоматически клонированные объекты — их исходные координаты и размеры сохраняются, что может привести к несоответствию содержимого или выходу за границы слайда.

Вы можете установить размер слайдов целевой презентации, соответствующий размеру исходной, перед клонированием мастера и слайда:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Сделайте это до клонирования мастера и слайда.

## **FAQ**

**Клонируются ли заметки выступающего и комментарии рецензентов?**  
Да. Страничка заметок и комментарии рецензентов включаются в клон. Если они вам не нужны, [удалите их](/slides/ru/php-java/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**  
Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/php-java/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Могу ли я управлять положением вставки и разделами для клона?**  
Да. Вы можете вставить клон на определённый индекс слайда и поместить его в выбранный [раздел](/slides/ru/php-java/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд в него.