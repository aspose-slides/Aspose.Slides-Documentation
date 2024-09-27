---
title: Раздел слайдов
type: docs
weight: 90
url: /ru/php-java/slide-section/
---

С помощью Aspose.Slides для PHP через Java вы можете организовать презентацию PowerPoint в разделы. Вы можете создавать разделы, которые содержат конкретные слайды.

Вам может понадобиться создать разделы и использовать их для организации или разделения слайдов в презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией с другими людьми или командой — и вам нужно назначить определенные слайды коллеге или некоторым членам команды.
- Когда вы работаете с презентацией, которая содержит много слайдов — и вам трудно управлять или редактировать ее содержимое одновременно.

Идеально, если вы создадите раздел, который будет содержать похожие слайды — слайды имеют что-то общее или могут существовать в группе на основе определенного правила — и дадите разделу имя, которое описывает содержащиеся в нем слайды.

## Создание разделов в презентациях

Чтобы добавить раздел, который будет содержать слайды в презентации, Aspose.Slides для PHP через Java предоставляет метод [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-), который позволяет вам указать имя раздела, который вы собираетесь создать, и слайд, с которого начинается раздел.

Этот образец кода показывает, как создать раздел в презентации:

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Раздел 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Раздел 2", $newSlide3);// раздел1 закончится на newSlide2, а после него начнется раздел2

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Последний пустой раздел");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Изменение имен разделов

После того как вы создадите раздел в презентации PowerPoint, вы можете решить изменить его имя.

Этот образец кода показывает, как изменить имя раздела в презентации с использованием Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("Мой раздел");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```