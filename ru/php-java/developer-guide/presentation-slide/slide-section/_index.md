---
title: Управление разделами слайдов в презентациях с помощью PHP
linktitle: Раздел слайдов
type: docs
weight: 90
url: /ru/php-java/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- название раздела
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Оптимизируйте разделы слайдов в PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java — разделяйте, переименовывайте и переупорядочивайте для улучшения рабочих процессов PPTX и ODP."
---

С помощью Aspose.Slides for PHP via Java вы можете организовать презентацию PowerPoint по разделам. Вы можете создавать разделы, которые содержат определённые слайды.

В следующих ситуациях вам может потребоваться создать разделы и использовать их для организации или разделения слайдов в презентации на логические части:

- Когда вы работаете над большой презентацией вместе с другими людьми или командой — и вам необходимо назначить определённые слайды коллеге или членам команды. 
- Когда у вас есть презентация, содержащая много слайдов — и вам трудно управлять её содержимым или редактировать его целиком.

Оптимально создавать раздел, в котором находятся схожие слайды — слайды, имеющие что‑то общее или которые могут быть сгруппированы по какому‑то правилу, — и давать разделу название, описывающее содержащиеся в нём слайды. 

## **Создание разделов в презентациях**
Чтобы добавить раздел, содержащий слайды в презентации, Aspose.Slides for PHP via Java предоставляет метод [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection), который позволяет указать имя создаваемого раздела и слайд, с которого начинается раздел.

Этот пример кода показывает, как создать раздел в презентации:
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 будет завершён на newSlide2, а после него начнётся section2

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


## **Изменение имён разделов**
После создания раздела в презентации PowerPoint вы можете решить изменить его имя. 

Этот пример кода показывает, как изменить имя раздела в презентации с помощью Aspose.Slides:
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


## **Часто задаваемые вопросы**
**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли "скрыть" весь раздел?**

Нет. Можно скрывать только отдельные слайды. У раздела как объекта нет состояния "скрыт".

**Можно ли быстро найти раздел по слайду и, наоборот, первый слайд раздела?**

Да. Раздел однозначно определяется своим первым слайдом; по слайду можно определить, к какому разделу он относится, а для раздела можно получить его первый слайд.