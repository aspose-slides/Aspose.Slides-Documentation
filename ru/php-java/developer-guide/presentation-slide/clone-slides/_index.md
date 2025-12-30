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

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for PHP via Java также позволяет создать копию или клон любого слайда и затем вставить этот клонированный слайд в текущую или любую другую открывшуюся презентацию. Процесс клонирования слайда создаёт новый слайд, который может быть изменён разработчиком без изменения оригинального слайда. Существует несколько способов клонирования слайда:

- Клонировать в конец текущей презентации.
- Клонировать в другое положение в текущей презентации.
- Клонировать в конец другой презентации.
- Клонировать в другое положение в другой презентации.
- Клонировать в конкретное положение в другой презентации.

В Aspose.Slides for PHP via Java (коллекция объектов [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide), доступная через объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)) предоставляются методы [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) для выполнения указанных типов клонирования слайдов.

## **Клонирование слайда в конец презентации**
Если нужно клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) согласно перечисленным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) через коллекцию Slides, доступную в объекте [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд, который нужно клонировать, в качестве параметра.
1. Запишите изменённый файл презентации.

В приведённом ниже примере мы клонировали слайд (расположенный на первой позиции — индекс 0 — презентации) в конец презентации.
```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
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


## **Клонирование слайда в другое положение внутри презентации**
Если нужно клонировать слайд и затем использовать его в том же файле презентации, но в другом месте, используйте метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Получите объект, ссылающийся на коллекцию **Slides** через объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд для клонирования вместе с индексом новой позиции в качестве параметров.
1. Сохраните изменённую презентацию в формате PPTX.

В приведённом ниже примере мы клонировали слайд (расположенный на нулевом индексе — позиция 1 — презентации) в индекс 1 — позицию 2 — презентации.
```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
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
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, вставив в конец существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего целевую презентацию, в которую будет добавлен слайд.
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) через коллекцию **Slides**, доступную в объекте Presentation целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации в качестве параметра.
1. Запишите изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.
```php
  # Создайте экземпляр класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
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


## **Клонирование слайда в другое положение в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, вставив в конкретную позицию:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего целевую презентацию, в которую будет добавлен слайд.
1. Получите объект [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) через коллекцию Slides целевой презентации.
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметров.
1. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.
```php
  # Создайте экземпляр класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    $destPres = new Presentation();
    try {
      # Клонируйте выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Запишите целевую презентацию на диск
      $destPres->save("Asp2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **Клонирование слайда в конкретное положение в другой презентации**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала следует клонировать требуемый мастер‑слайд из исходной презентации в целевую, а затем использовать этот мастер‑слайд для клонирования самого слайда. Метод [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего целевую презентацию, в которую будет клонирован слайд.
1. Получите доступ к клонируемому слайду вместе с его мастер‑слайдом.
1. Получите объект [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) через коллекцию Masters целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [IMasterSlideCollection] и передайте мастер‑слайд из исходного PPTX в качестве параметра.
1. Получите объект [ISlideCollection] через коллекцию Slides целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection] и передайте слайд из исходной презентации вместе с мастер‑слайдом в качестве параметров.
1. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд с мастер‑слайдом (расположенный на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.
```php
  # Создайте экземпляр класса Presentation для загрузки исходного файла презентации
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Создайте экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    $destPres = new Presentation();
    try {
      # Получите ISlide из коллекции слайдов исходной презентации вместе с
      # мастер‑слайдом
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Клонируйте нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
      # целевой презентации
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Клонируйте нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
      # целевой презентации
      $iSlide = $masters->addClone($SourceMaster);
      # Клонируйте нужный слайд из исходной презентации с требуемым мастером в конец
      # коллекции слайдов в целевой презентации
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
Если нужно клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) интерфейса [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection). Aspose.Slides for PHP via Java позволяет клонировать слайд из первого раздела и затем вставить его во второй раздел той же презентации.

Ниже приведён фрагмент кода, показывающий, как клонировать слайд и вставить его в указанный раздел.
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

**Клонируются ли заметки спикера и комментарии рецензента?**

Да. Страница заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/php-java/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, книгой Excel, встроенной через OLE), эта связь сохраняется как [OLE‑объект](/slides/ru/php-java/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Можно ли контролировать позицию вставки и разделы для клона?**

Да. Клон можно вставить в конкретный индекс слайда и разместить его в выбранном [разделе](/slides/ru/php-java/slide-section/). Если целевой раздел не существует, создайте его предварительно, а затем переместите слайд.