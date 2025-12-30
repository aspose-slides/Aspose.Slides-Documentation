---
title: Экспорт математических уравнений из презентаций в PHP
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/php-java/exporting-math-equations/
keywords:
- экспорт математических уравнений
- MathML
- LaTeX
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Обеспечьте беспроблемный экспорт математических уравнений из PowerPoint в MathML с помощью Aspose.Slides for PHP via Java — сохраняйте форматирование и повышайте совместимость."
---

## **Экспорт математических уравнений из презентаций**

Aspose.Slides for PHP via Java позволяет экспортировать математические уравнения из презентаций. Например, может понадобиться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения в MathML — популярный формат или стандарт для математических уравнений и схожего контента, используемого в вебе и во многих приложениях. 

{{% /alert %}}

Хотя люди легко пишут код для некоторых форматов уравнений, таких как LaTeX, им трудно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, так как его код находится в XML, поэтому MathML часто используется в качестве формата вывода и печати во многих областях. 

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать как целый математический абзац ([MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)), так и отдельный блок ([MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), и имеет [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) не могут быть экспортированы как формулы.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или является стандартом?**

Экспорт нацелен на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, используемое в презентациях, которое широко применяется в различных приложениях и в интернете.

**Поддерживается ли экспорт формул, находящихся внутри таблиц, SmartArt, групп и т.д.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) (т. е. настоящие формулы PowerPoint), они экспортируются. Если формула вставлена как изображение, она не экспортируется.

**Изменяет ли экспорт в MathML исходную презентацию?**

Нет. Запись MathML представляет собой сериализацию содержимого формулы; она не изменяет файл презентации.