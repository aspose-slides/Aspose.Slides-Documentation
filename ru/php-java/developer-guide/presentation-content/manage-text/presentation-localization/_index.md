---
title: Автоматизация локализации презентаций в PHP
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/php-java/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- идентификатор языка
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java, используя практические примеры кода и советы для более быстрого глобального развертывания."
---

## **Изменить язык для презентации и текста формы**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) типа [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) на слайд.
- Добавьте некоторый текст в TextFrame.
- [Set Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) для текста.
- Сохраните презентацию как файл PPTX.

Реализация указанных шагов демонстрируется ниже в примере.
```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Вызывает ли Language ID автоматический перевод текста?**

Нет. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) в Aspose.Slides хранит язык для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли Language ID на переносы и разбиение строк при рендеринге?**

В Aspose.Slides [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) предназначен для проверки. Качество переноса слов и разбиения строк в основном зависит от наличия [правильные шрифты](/slides/ru/php-java/powerpoint-fonts/) и настроек разметки/разрыва строк для системы письма. Чтобы обеспечить корректный рендеринг, предоставьте необходимые шрифты, настройте [правила замены шрифтов](/slides/ru/php-java/font-substitution/) и/или [встраивание шрифтов](/slides/ru/php-java/embedded-font/) в презентацию.

**Можно ли задать разные языки в одном абзаце?**

Да. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с различными настройками проверки.