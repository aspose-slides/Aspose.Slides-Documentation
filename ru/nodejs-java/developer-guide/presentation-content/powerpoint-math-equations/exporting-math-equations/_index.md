---
title: Экспорт математических уравнений
type: docs
weight: 30
url: /ru/nodejs-java/exporting-math-equations/
---

## **Экспорт математических уравнений из презентаций**

Aspose.Slides for Node.js via Java позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 
Вы можете экспортировать уравнения в MathML — популярный формат или стандарт для математических уравнений и аналогичного контента, используемого в вебе и во многих приложениях. 
{{% /alert %}}

В то время как люди легко пишут код для некоторых форматов уравнений, например LaTeX, им трудно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код находится в XML, поэтому MathML широко используется в качестве формата вывода и печати во многих областях. 

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Что именно экспортируется в MathML — параграф или отдельный блок формулы?**

Вы можете экспортировать либо целый математический параграф ([MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)), либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)) в MathML. Оба типа предоставляют метод для записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), и имеет [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) не являются экспортируемыми формулами.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или это стандарт?**

Экспорт направлен на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, предназначенное для презентаций, которое широко используется в приложениях и в вебе.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.п.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) (т. е. реальные формулы PowerPoint), они экспортируются. Если формула внедрена как изображение, она не экспортируется.

**Изменяется ли оригинальная презентация при экспорте в MathML?**

Нет. Запись MathML представляет собой сериализацию содержимого формулы; она не изменяет файл презентации.