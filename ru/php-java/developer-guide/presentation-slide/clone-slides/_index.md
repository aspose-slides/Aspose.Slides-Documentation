---
title: Клонирование слайдов
type: docs
weight: 35
url: /php-java/clone-slides/
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего-либо. Aspose.Slides для PHP через Java также позволяет создать копию или клон любого слайда, а затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создает новый слайд, который может быть изменен разработчиками без изменения оригинального слайда. Существует несколько возможных способов клонирования слайда:

- Клонировать в конце презентации.
- Клонировать в другую позицию внутри презентации.
- Клонировать в конец в другой презентации.
- Клонировать в другую позицию в другой презентации.
- Клонировать на определенной позиции в другой презентации.

В Aspose.Slides для PHP через Java (коллекция объектов [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)) предоставляется объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) методы [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) для выполнения вышеуказанных типов клонирования слайдов.

## **Клонировать в конце внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) в соответствии с шагами, перечисленными ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) ссылаясь на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд, который необходимо клонировать, в качестве параметра методу [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Запишите измененный файл презентации.

В приведенном ниже примере мы клонировали слайд (находящийся на первой позиции – нулевой индекс – презентации) в конец презентации.

```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Клонируйте необходимый слайд в конец коллекции слайдов в той же презентации
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Запишите измененную презентацию на диск
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Клонировать в другую позицию внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но на другой позиции, используйте метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Создайте экземпляр класса, ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) предоставляемую объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд, который необходимо клонировать, а также индекс для новой позиции в качестве параметров методу [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы клонировали слайд (находящийся на нулевом индексе – позиция 1 – презентации) на индекс 1 – позиция 2 – презентации.

```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Клонируйте необходимый слайд в конец коллекции слайдов в той же презентации
    $slds = $pres->getSlides();
    # Клонируйте необходимый слайд на указанный индекс в той же презентации
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Запишите измененную презентацию на диск
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Клонировать в конце в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другом файле презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего целевую презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection), ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) предоставляемую объектом презентации назначения.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации в качестве параметра методу [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд (с первого индекса исходной презентации) в конец целевой презентации.

```php
  # Создайте экземпляр класса Presentation для загрузки файла исходной презентации
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонироваться слайд)
    $destPres = new Presentation();
    try {
      # Клонируйте необходимый слайд из исходной презентации в конец коллекции слайдов целевой презентации
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

## **Клонировать в другую позицию в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации в определенной позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) ссылаясь на коллекцию слайдов, предоставляемую объектом презентации назначения.
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметров методу [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) на индекс 1 (позиция 2) целевой презентации.

```php
  # Создайте экземпляр класса Presentation для загрузки файла исходной презентации
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонироваться слайд)
    $destPres = new Presentation();
    try {
      # Клонируйте необходимый слайд из исходной презентации в конец коллекции слайдов целевой презентации
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

## **Клонировать на определенной позиции в другой презентации**
Если вам нужно клонировать слайд с мастер-слайдом из одной презентации и использовать его в другой презентации, вам необходимо сначала клонировать нужный мастер-слайд из исходной презентации в целевую презентацию. Затем вам нужно использовать этот мастер-слайд для клонирования слайда с мастер-слайдом. Метод [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ожидает мастер-слайд из целевой презентации, а не из исходной презентации. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), содержащего целевую презентацию, в которую будет клонироваться слайд.
1. Получите слайд, который необходимо клонировать, вместе с мастер-слайдом.
1. Создайте экземпляр класса [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) ссылаясь на коллекцию мастеров, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) объекта [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) и передайте мастер из исходного PPTX, который следует клонировать, в качестве параметра методу [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) указывая ссылку на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации для клонирования и мастер-слайд в качестве параметров методу [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Запишите изменённый файл целевой презентации.

В приведенном ниже примере мы клонировали слайд с мастером (находящийся на нулевом индексе исходной презентации) в конец целевой презентации с использованием мастера из исходного слайда.

```php
  # Создайте экземпляр класса Presentation для загрузки файла исходной презентации
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Создайте экземпляр класса Presentation для целевой презентации (куда будет клонироваться слайд)
    $destPres = new Presentation();
    try {
      # Создайте экземпляр ISlide из коллекции слайдов в исходной презентации вместе с
      # мастер-слайдом
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Клонируйте необходимый мастер-слайд из исходной презентации в коллекцию мастеров в
      # целевой презентации
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Клонируйте необходимый мастер-слайд из исходной презентации в коллекцию мастеров в
      # целевой презентации
      $iSlide = $masters->addClone($SourceMaster);
      # Клонируйте необходимый слайд из исходной презентации с необходимым мастером в конец
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

## **Клонировать в конце в определённом разделе**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) объекта [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection). Aspose.Slides для PHP через Java позволяет клонировать слайд из первого раздела и затем вставить этот клонированный слайд во второй раздел той же презентации.

Следующий фрагмент кода показывает, как клонировать слайд и вставить клонированный слайд в указанный раздел.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Раздел 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Раздел 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Сохраните целевую презентацию на диск
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```