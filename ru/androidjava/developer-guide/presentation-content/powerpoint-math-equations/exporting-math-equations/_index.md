---
title: Экспорт математических уравнений из презентаций на Android
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/androidjava/exporting-math-equations/
keywords:
- экспорт математических уравнений
- MathML
- LaTeX
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Обеспечьте беспроблемный экспорт математических уравнений из PowerPoint в MathML с помощью Aspose.Slides для Android через Java — сохраните форматирование и повысите совместимость."
---

## **Экспорт математических уравнений из презентаций**

Aspose.Slides for Android via Java позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 
Вы можете экспортировать уравнения в MathML, популярный формат или стандарт для математических уравнений и аналогичного контента, используемого в вебе и во многих приложениях. 
{{% /alert %}}

Хотя людям легко писать код для некоторых форматов уравнений, таких как LaTeX, им сложно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML часто используется как формат вывода и печати во многих областях. 

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

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать либо целый математический абзац ([MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)), либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)) в MathML. Оба типа предоставляют метод для записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) не экспортируются как формулы.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, предназначенное для презентаций, которое широко применяется в различных приложениях и в вебе.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.д.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/), то есть настоящие формулы PowerPoint, они экспортируются. Если формула внедрена как изображение, она не экспортируется.

**Изменяет ли экспорт в MathML оригинальную презентацию?**

Нет. Запись MathML — это сериализация содержимого формулы; она не изменяет файл презентации.