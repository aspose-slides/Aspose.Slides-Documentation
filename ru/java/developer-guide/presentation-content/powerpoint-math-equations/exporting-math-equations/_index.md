---
title: Экспорт математических уравнений из презентаций на Java
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/java/exporting-math-equations/
keywords:
- экспорт математических уравнений
- MathML
- LaTeX
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Обеспечьте бесшовный экспорт математических уравнений из PowerPoint в MathML с помощью Aspose.Slides for Java — сохраните форматирование и повышайте совместимость."
---

## Экспорт математических уравнений из презентаций

Aspose.Slides for Java позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе. 

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения в MathML, популярный формат или стандарт для математических уравнений и похожего контента, используемого в Интернете и во многих приложениях. 

{{% /alert %}}

Хотя люди легко пишут код для некоторых форматов уравнений, таких как LaTeX, им сложно написать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML часто используется как выходной и печатный формат во многих областях. 

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:
```java
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


## **FAQ**

**Что именно экспортируется в MathML — параграф или отдельный блок формулы?**

Вы можете экспортировать либо целый математический параграф ([MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/)), либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) не являются экспортируемыми формулами.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или это стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, распространённое в приложениях и в Интернете.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.д.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) (т. е. настоящие формулы PowerPoint), они экспортируются. Если формула внедрена как изображение, экспорт не производится.

**Изменяется ли оригинальная презентация при экспорте в MathML?**

Нет. Запись MathML — это сериализация содержимого формулы; она не изменяет файл презентации.