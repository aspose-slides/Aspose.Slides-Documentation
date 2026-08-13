---
title: Экспорт математических уравнений из презентаций на Android
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/androidjava/exporting-math-equations/
keywords:
- экспорт математических уравнений
- экспорт уравнений в LaTeX
- PowerPoint в LaTeX
- MathML
- LaTeX
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Экспорт математических уравнений из презентаций PowerPoint в LaTeX или MathML напрямую с помощью Aspose.Slides для Android через Java."
---
## **Введение**

Aspose.Slides for Android via Java позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="info" %}} 
Вы можете экспортировать уравнения непосредственно в LaTeX или в MathML, популярный стандарт для математического контента, используемый в вебе и во многих приложениях.
{{% /alert %}}

## **Экспорт математических уравнений в LaTeX**

Aspose.Slides может напрямую преобразовать математическое уравнение PowerPoint в LaTeX; промежуточный файл MathML и внешний конвертер не требуются. Математическое уравнение хранится в текстовом кадре как [IMathPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathportion/). Используйте [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) чтобы получить [IMathParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathparagraph/), а затем вызовите [IMathParagraph.toLatex](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathparagraph/#toLatex--). Метод возвращает строку, которую вы можете сохранить, отобразить, отправить в другое приложение или обработать дальше.

Следующий пример просматривает каждый текстовый кадр на каждом слайде, находит все математические части и записывает каждое уравнение в отдельный файл `.tex`:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) возвращает все текстовые кадры, найденные на слайде. Проверка типа [IMathPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imathportion/) отделяет настоящие редактируемые уравнения от обычного текста и изображений.

Движки LaTeX и шаблоны документов не все поддерживают одни и те же команды, пакеты или символы Unicode. Проверьте полученную строку с движком LaTeX, используемым в вашем приложении. Если символ или элемент Office Math не имеет подходящего представления в этой среде, замените его в полученной строке командой, специфичной для проекта, либо пропустите уравнение и зафиксируйте проблему для последующего рассмотрения.

## **Сохранение математических уравнений в MathML**

В то время как люди легко пишут код для некоторых форматов уравнений, таких как LaTeX, им сложно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML часто используется в качестве формата вывода и печати во многих областях. 

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Часто задаваемые вопросы**

**Что именно экспортируется в MathML — параграф или отдельный блок формулы?**

Вы можете экспортировать либо весь математический параграф ([MathParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathparagraph/)), либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathportion/), и имеет [MathParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathparagraph/) не являются экспортируемыми формулами.

**Откуда берётся MathML в презентации — является ли он специфичным для PowerPoint или представляет собой стандарт?**

Экспорт нацелен на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, предназначенное для презентаций, которое широко используется в приложениях и в Интернете.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.д.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/mathparagraph/) (т.е. настоящие формулы PowerPoint), они экспортируются. Если формула внедрена как изображение, она не экспортируется.

**Изменяет ли экспорт в MathML оригинальную презентацию?**

Нет. Запись MathML представляет собой сериализацию содержимого формулы; она не изменяет файл презентации.