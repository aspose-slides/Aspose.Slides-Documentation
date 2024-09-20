---
title: Добавьте слайд в презентацию
type: docs
weight: 10
url: /php-java/add-slide-to-presentation/
---

## **Добавьте слайд в презентацию**
{{% alert color="primary" %}} 

Перед тем как говорить о добавлении слайдов в файлы презентаций, давайте обсудим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит **Мастер / Макет** слайд и другие **Обычные** слайды. Это означает, что файл презентации содержит по крайней мере один или несколько слайдов. Важно знать, что файлы презентации без слайдов не поддерживаются Aspose.Slides для PHP через Java. Каждый слайд имеет уникальный идентификатор, и все Обычные слайды расположены в порядке, определяемом индексом, начинающимся с нуля.

{{% /alert %}} 

Aspose.Slides для PHP через Java позволяет разработчикам добавлять пустые слайды в их презентации. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection), установив ссылку на свойство [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (коллекция объектов слайдов) объекта [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Добавьте пустой слайд в презентацию в конец коллекции контентных слайдов, вызвав методы [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection).
- Выполните некоторые действия с только что добавленным пустым слайдом.
- Наконец, сохраните файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).

```php
  # Создайте экземпляр класса Presentation, представляющего файл презентации
  $pres = new Presentation();
  try {
    # Создайте экземпляр класса SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Добавьте пустой слайд в коллекцию слайдов
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Выполните некоторые действия с только что добавленным слайдом
    # Сохраните файл PPTX на диск
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```