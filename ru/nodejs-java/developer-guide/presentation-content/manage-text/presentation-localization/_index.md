---
title: Локализация презентации
type: docs
weight: 100
url: /ru/nodejs-java/presentation-localization/
---

## **Изменение языка для текста в презентации и фигуре**

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте на слайд [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) типа [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle).
- Добавьте текст в TextFrame.
- [Установка Language Id](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) к тексту.
- Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов продемонстрирована ниже в примере.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Вызывает ли language ID автоматический перевод текста?**

Нет. [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) в Aspose.Slides сохраняет язык для проверки орфографии и грамматики, но не переводит и не меняет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли language ID на переносы и разрывы строк при отображении?**

В Aspose.Slides [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) используется для проверки. Качество переносов и разрывов строк в основном зависит от наличия [proper fonts](/slides/ru/nodejs-java/powerpoint-fonts/) и настроек макета/переноса строк для системы письма. Чтобы обеспечить правильное отображение, предоставьте необходимые шрифты, настройте [font substitution rules](/slides/ru/nodejs-java/font-substitution/), и/или [embed fonts](/slides/ru/nodejs-java/embedded-font/) в презентацию.

**Можно ли установить разные языки в одном абзаце?**

Да. [setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с разными настройками проверки.