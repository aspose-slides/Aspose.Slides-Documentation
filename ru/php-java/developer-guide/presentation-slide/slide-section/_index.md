---
title: Управление разделами слайдов в презентациях с помощью PHP
linktitle: Раздел слайда
type: docs
weight: 90
url: /ru/php-java/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- имя раздела
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Оптимизируйте управление разделами слайдов в PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java — разделяйте, переименовывайте и переупорядочивайте для улучшения процессов работы с PPTX и ODP."
---

С помощью Aspose.Slides для PHP через Java вы можете организовать презентацию PowerPoint в разделы. Вы получаете возможность создавать разделы, содержащие определённые слайды.

Вы можете захотеть создать разделы и использовать их для организации или деления слайдов презентации на логические части в следующих ситуациях:

- Когда вы работаете над большой презентацией совместно с другими людьми или командой — и вам нужно назначить определённые слайды коллеге или нескольким членам команды. 
- Когда вы имеете дело с презентацией, содержащей много слайдов, — и вам трудно управлять или редактировать её содержимое одновременно.

Оптимально создать раздел, в котором находятся схожие слайды — слайды имеют что‑то общее или могут быть сгруппированы по правилу — и дать разделу название, описывающее содержащиеся в нём слайды. 

## **Создание разделов в презентациях**

Чтобы добавить раздел, в котором будут размещены слайды презентации, Aspose.Slides для PHP через Java предоставляет метод [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-), позволяющий указать название создаваемого раздела и слайд, с которого начинается раздел.

В этом примере показано, как создать раздел в презентации:
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 завершится на newSlide2, а после него начнётся section2

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Изменение названий разделов**

После создания раздела в презентации PowerPoint вы можете решить изменить его название. 

В этом примере показано, как изменить название раздела в презентации с помощью Aspose.Slides:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Сохраняются ли разделы при сохранении в формате PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью «скрыть» раздел?**

Нет. Скрыть можно только отдельные слайды. У раздела как объекта нет состояния «скрыт».

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется своим начальным слайдом; по данному слайду можно определить, к какому разделу он принадлежит, а для раздела можно получить его первый слайд.