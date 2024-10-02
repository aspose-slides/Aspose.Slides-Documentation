---
title: Экспортирование математических уравнений
type: docs
weight: 30
url: /ru/androidjava/exporting-math-equations/

---

## Экспортирование математических уравнений из презентаций

Aspose.Slides для Android через Java позволяет экспортировать математические уравнения из презентаций. Например, вам может понадобиться извлечь математические уравнения с слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения в MathML, популярный формат или стандарт для математических уравнений и подобного контента, встречающегося в сети и во многих приложениях. 

{{% /alert %}}

Хотя люди легко пишут код для некоторых форматов уравнений, таких как LaTeX, им сложно написать код для MathML, потому что последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, так как его код написан в XML, поэтому MathML часто используется как выходной и печатный формат во многих областях.

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