---
title: Экспорт математических уравнений из презентаций в PHP
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/php-java/exporting-math-equations/
keywords:
- экспорт математических уравнений
- экспорт уравнений в LaTeX
- PowerPoint в LaTeX
- MathML
- LaTeX
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Экспортируйте математические уравнения из презентаций PowerPoint в LaTeX или MathML напрямую с помощью Aspose.Slides for PHP via Java."
---
## **Введение**

Aspose.Slides for PHP via Java позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения напрямую в LaTeX или в MathML — популярный стандарт для математического контента, используемый в интернете и во многих приложениях.

{{% /alert %}}

## **Экспорт математических уравнений в LaTeX**

Aspose.Slides может преобразовать математическое уравнение PowerPoint напрямую в LaTeX; промежуточный файл MathML и внешний конвертер не требуются. Уравнение хранится в текстовом кадре как [MathPortion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathportion/). Используйте [MathPortion::getMathParagraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathportion/#getMathParagraph), чтобы получить [MathParagraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathparagraph/), а затем вызовите [MathParagraph::toLatex](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathparagraph/#toLatex). Метод возвращает строку, которую можно сохранить, отобразить, отправить в другое приложение или далее обработать.

Следующий пример просматривает каждый текстовый кадр на каждом слайде, находит все математические части и записывает каждое уравнение в отдельный файл `.tex`:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/ru/php-java/aspose.slides/slideutil/#getAllTextBoxes) возвращает все текстовые кадры, найденные на слайде. Проверка типа [MathPortion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathportion/) отделяет настоящие редактируемые уравнения от обычного текста и изображений.

Движки LaTeX и шаблоны документов не всегда поддерживают одинаковые команды, пакеты или символы Unicode. Проверьте полученную строку с помощью LaTeX‑движка, используемого в вашем приложении. Если символ или элемент Office Math не имеет подходящего представления в этой среде, замените его в возвращённой строке на команду, специфичную для проекта, или пропустите уравнение и зафиксируйте проблему для дальнейшего рассмотрения.

## **Сохранение математических уравнений в формате MathML**

Хотя люди легко пишут код для таких форматов уравнений, как LaTeX, им трудно писать код для MathML, поскольку последний предполагает автоматическое генерирование приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML часто используется как формат вывода и печати во многих областях. 

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

## **FAQ**

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать как весь математический абзац ([MathParagraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathparagraph/)), так и отдельный блок [MathBlock](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathblock/) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathparagraph/) не являются экспортируемыми формулами.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, широко применяемое в различных приложениях и в вебе.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.д.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/mathparagraph/) (то есть настоящие формулы PowerPoint), они экспортируются. Если формула внедрена как изображение, она не будет экспортирована.

**Изменяется ли оригинальная презентация при экспорте в MathML?**

Нет. Запись MathML представляет собой сериализацию содержимого формулы; оригинальный файл презентации не изменяется.