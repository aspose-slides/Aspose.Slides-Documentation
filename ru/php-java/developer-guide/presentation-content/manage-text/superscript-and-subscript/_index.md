---
title: Управление надстрочным и подстрочным текстом в презентациях с помощью PHP
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
description: "Освойте надстрочный и подстрочный текст в Aspose.Slides для PHP через Java и повысите уровень ваших презентаций с профессиональным форматированием текста для максимального воздействия."
---

## **Управление надстрочным и подстрочным текстом**
Вы можете добавлять надстрочный и подстрочный текст в любую часть абзаца. Для добавления надстрочного или подстрочного текста в текстовый фрейм Aspose.Slides необходимо использовать метод [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) класса [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

Это свойство возвращает или задает надстрочный или подстрочный текст (значение от -100% (подстрочный) до 100% (надстрочный)). Например:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) на слайд.
- Получите доступ к [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame), связанному с [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
- Очистите существующие абзацы
- Создайте новый объект абзаца для надстрочного текста и добавьте его в коллекцию [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) объекта [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- Создайте новый объект части (portion)
- Установите свойство Escapement для части в диапазоне от 0 до 100, чтобы добавить надстрочный текст. (0 означает отсутствие надстрочного)
- Установите некоторый текст для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Создайте новый объект абзаца для подстрочного текста и добавьте его в коллекцию IParagraphs объекта ITextFrame.
- Создайте новый объект части (portion)
- Установите свойство Escapement для части в диапазоне от 0 до -100, чтобы добавить подстрочный текст. (0 означает отсутствие подстрочного)
- Установите некоторый текст для [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) и затем добавьте его в коллекцию частей абзаца.
- Сохраните презентацию в файл PPTX.

Реализация вышеописанных шагов приведена ниже.
```php
  # Создать экземпляр класса Presentation, представляющего PPTX
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

**Сохраняются ли надстрочный и подстрочный текст при экспорте в PDF или другие форматы?**

Да, Aspose.Slides корректно сохраняет форматирование надстрочного и подстрочного текста при экспорте презентаций в PDF, PPT/PPTX, изображения и другие поддерживаемые форматы. Специальное форматирование остаётся неизменным во всех выходных файлах.

**Можно ли сочетать надстрочный и подстрочный текст с другими стилями форматирования, например полужирным или курсивом?**

Да, Aspose.Slides позволяет комбинировать различные стили текста внутри одной части. Вы можете включать полужирный, курсив, подчёркивание и одновременно применять надстрочный или подстрочный текст, настраивая соответствующие свойства в [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

**Работает ли форматирование надстрочного и подстрочного текста для текста внутри таблиц, диаграмм или SmartArt?**

Да, Aspose.Slides поддерживает форматирование в большинстве объектов, включая таблицы и элементы диаграмм. При работе с SmartArt необходимо получить доступ к соответствующим элементам (например, к [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) и их контейнерам текста, а затем настроить свойства [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) аналогичным образом.