---
title: Автоматизация локализации презентаций в PHP
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/php-java/presentation-localization/
keywords:
- смена языка
- проверка правописания
- идентификатор языка
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument с помощью Aspose.Slides для PHP через Java, используя практические примеры кода и рекомендации для более быстрого глобального развертывания."
---

## **Изменение языка для презентации и текста формы**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) на слайд.
- Добавьте текст в TextFrame.
- [Установка Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) к тексту.
- Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов показана ниже в примере.
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


## **FAQ**

**Вызывает ли Language ID автоматический перевод текста?**

Нет. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) в Aspose.Slides хранит язык для проверки правописания и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли Language ID на переносы слов и разрывы строк при рендеринге?**

В Aspose.Slides [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) используется только для проверки. Качество переноса слов и перенос строк в основном зависят от наличия [соответствующих шрифтов](/slides/ru/php-java/powerpoint-fonts/) и настроек разметки/переноса для системы письма. Чтобы обеспечить правильный рендеринг, сделайте необходимые шрифты доступными, настройте [правила замены шрифтов](/slides/ru/php-java/font-substitution/) и/или [встраивание шрифтов](/slides/ru/php-java/embedded-font/) в презентацию.

**Можно ли задать разные языки в одном абзаце?**

Да. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с разными настройками проверки.