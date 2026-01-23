---
title: Управление надстрочным и подстрочным текстом в презентациях с использованием PHP
linktitle: Надстрочный и подстрочный
type: docs
weight: 80
url: /ru/php-java/superscript-and-subscript/
keywords:
- надстрочный
- подстрочный
- добавить надстрочный
- добавить подстрочный
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Освойте надстрочный и подстрочный формат в Aspose.Slides для PHP через Java и улучшите свои презентации профессиональным форматированием текста для максимального воздействия."
---

## **Manage Superscript and Subscript Text**
Вы можете добавить надстрочный и подстрочный текст в любую часть абзаца. Для добавления надстрочного или подстрочного текста в текстовый фрейм Aspose.Slides необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) класса [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

Это свойство возвращает или задаёт надстрочный или подстрочный текст (значение от ‑100 % (подстрочный) до 100 % (надстрочный)). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) типа [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) на слайд.
- Получите доступ к [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) — связанного с [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- Очистите существующие абзацы.
- Создайте новый объект абзаца для надстрочного текста и добавьте его в [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
- Создайте новый объект portion.
- Установите свойство Escapement для части в диапазоне от 0 до 100, чтобы добавить надстрочный текст. (0 означает отсутствие надстрочного)
- Установите некоторый текст для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Создайте новый объект абзаца для подстрочного текста и добавьте его в коллекцию IParagraphs ITextFrame.
- Создайте новый объект portion.
- Установите свойство Escapement для части в диапазоне от 0 до ‑100, чтобы добавить подстрочный текст. (0 означает отсутствие подстрочного)
- Установите некоторый текст для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Сохраните презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже.
```php
  # Создать объект класса Presentation, представляющий PPTX
  $pres = new Presentation();
  try {
    # Получить слайд
    $slide = $pres->getSlides()->get_Item(0);
    # Создать текстовое поле
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Создать абзац для надстрочного текста
    $superPar = new Paragraph();
    # Создать часть с обычным текстом
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Создать часть с надстрочным текстом
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Создать абзац для подстрочного текста
    $paragraph2 = new Paragraph();
    # Создать часть с обычным текстом
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Создать часть с подстрочным текстом
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Добавить абзацы в текстовое поле
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Will superscript and subscript be preserved when exporting to PDF or other formats?**

Да, Aspose.Slides правильно сохраняет надстрочный и подстрочный формат при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специальное форматирование остаётся неизменным во всех выходных файлах.

**Can superscript and subscript be combined with other formatting styles such as bold or italics?**

Да, Aspose.Slides позволяет смешивать различные стили текста в одной части. Вы можете включать жирный, курсив, подчёркивание и одновременно применять надстрочный или подстрочный стиль, настраивая соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

**Do superscript and subscript formatting work for text inside tables, charts, or SmartArt?**

Да, Aspose.Slides поддерживает форматирование внутри большинства объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, к [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) и их текстовым контейнерам, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) аналогичным образом.