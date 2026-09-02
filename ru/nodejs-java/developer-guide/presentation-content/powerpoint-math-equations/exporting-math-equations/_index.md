---
title: Экспорт математических уравнений из презентаций на JavaScript
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/nodejs-java/exporting-math-equations/
keywords:
- экспорт математических уравнений
- экспорт уравнений в LaTeX
- PowerPoint в LaTeX
- MathML
- LaTeX
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Экспортируйте математические уравнения из презентаций PowerPoint в LaTeX или MathML напрямую с помощью Aspose.Slides для Node.js через Java."
---
## **Введение**

Aspose.Slides позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе.

{{% alert color="primary" %}} 

Вы можете экспортировать уравнения напрямую в LaTeX или в MathML — популярный стандарт для математического контента, используемый в вебе и во многих приложениях.

{{% /alert %}}

## **Экспорт математических уравнений в LaTeX**

Aspose.Slides может преобразовать математическое уравнение PowerPoint напрямую в LaTeX; промежуточный файл MathML и внешний конвертер не требуются. Математическое уравнение хранится в текстовом кадре как [MathPortion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathportion/). Используйте [MathPortion.getMathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) для получения [MathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/), а затем вызовите [MathParagraph.toLatex](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/#toLatex--). Метод возвращает строку, которую можно сохранить, отобразить, отправить в другое приложение или обработать дальше.

В следующем примере проверяются все текстовые кадры на каждом слайде, находятся все математические части и каждая формула записывается в отдельный файл `.tex`:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) возвращает все текстовые кадры, найденные на слайде. Проверка типа [MathPortion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathportion/) отделяет подлинные редактируемые уравнения от обычного текста и изображений.

LaTeX‑движки и шаблоны документов не всегда поддерживают одинаковые команды, пакеты или символы Unicode. Проверьте полученную строку с LaTeX‑движком, используемым в вашем приложении. Если символ или элемент Office Math не имеет подходящего представления в этой среде, замените его в полученной строке командой, специфичной для проекта, либо пропустите уравнение и зафиксируйте проблему для последующего рассмотрения.

## **Сохранение математических уравнений в MathML**

Хотя человеку легко писать код для некоторых форматов уравнений, таких как LaTeX, написать код для MathML сложнее, поскольку этот формат предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, так как его код представлен в виде XML, поэтому MathML часто используется в качестве формата вывода и печати во многих областях.

В этом примере кода показано, как экспортировать математическое уравнение из презентации в MathML:

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

**Что именно экспортируется в MathML — абзац или отдельный блок формулы?**

Вы можете экспортировать либо весь математический абзац ([MathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/)), либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathblock/)) в MathML. Оба типа предоставляют метод записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/) не являются экспортируемыми формулами.

**Откуда берётся MathML в презентации — это специфично для PowerPoint или это стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, широко применяемое в приложениях и в вебе.

**Поддерживается ли экспорт формул, находящихся в таблицах, SmartArt, группах и т.п.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/mathparagraph/) (то есть подлинные формулы PowerPoint), они экспортируются. Если формула внедрена как изображение, она не экспортируется.

**Модифицирует ли экспорт в MathML исходную презентацию?**

Нет. Запись MathML представляет собой сериализацию содержимого формулы и не изменяет файл презентации.