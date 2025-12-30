---
title: Добавление слайдов в презентации на PHP
linktitle: Добавить слайд
type: docs
weight: 10
url: /ru/php-java/add-slide-to-presentation/
keywords:
- добавить слайд
- создать слайд
- пустой слайд
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Легко добавляйте слайды в ваши презентации PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java — плавное, эффективное вставление слайдов за секунды."
---

## **Добавить слайд в презентацию**
{{% alert color="primary" %}} 

Прежде чем говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл PowerPoint презентации содержит слайд **Master / Layout** и другие **Normal** слайды. Это означает, что файл презентации содержит минимум один или более слайдов. Важно знать, что файлы презентаций без слайдов не поддерживаются Aspose.Slides for PHP via Java. Каждый слайд имеет уникальный Id, а все **Normal** слайды упорядочены согласно индексу, начинающемуся с нуля.

{{% /alert %}} 

Aspose.Slides for PHP via Java позволяет разработчикам добавлять пустые слайды в свою презентацию. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Создайте объект класса [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection), установив ссылку на свойство [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (коллекция объектов Slide содержимого), предоставляемое объектом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Добавьте пустой слайд в презентацию в конец коллекции слайдов содержимого, вызвав методы [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) , предоставляемые объектом [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection).
- Выполните необходимые действия с только что добавленным пустым слайдом.
- Наконец, запишите файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
```php
  # Создать экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation();
  try {
    # Создать экземпляр класса SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Добавить пустой слайд в коллекцию Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Выполнить некоторые действия с только что добавленным слайдом
    # Сохранить файл PPTX на диск
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Часто задаваемые вопросы**

**Можно ли вставить новый слайд в определённое место, а не только в конец?**

Да. Библиотека поддерживает коллекции слайдов и операции [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/), поэтому вы можете добавить слайд в требуемый индекс, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследуется от выбранного макета и связанного с ним мастера.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

Ново созданная презентация уже содержит один пустой слайд с индексом ноль. Это важно учитывать при вычислении индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у мастера много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/), соответствующий требуемой структуре ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, вы можете [add it to the master](/slides/ru/php-java/slide-layout/) и затем использовать его.