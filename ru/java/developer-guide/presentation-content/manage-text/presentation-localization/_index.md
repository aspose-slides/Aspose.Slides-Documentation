---
title: Автоматизация локализации презентаций в Java
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/java/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- идентификатор языка
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Автоматизировать локализацию слайдов PowerPoint и OpenDocument в Java с помощью Aspose.Slides, используя практические примеры кода и советы для ускоренного глобального развертывания."
---

## **Смена языка для текста презентации и фигуры**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте на слайд [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle).
- Добавьте некоторый текст в TextFrame.
- [Setting Language Id](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) для текста.
- Сохраните презентацию в файл PPTX.

Реализация вышеописанных шагов показана ниже в примере.
```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Вызывает ли Language ID автоматический перевод текста?**

Нет. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) в Aspose.Slides сохраняет язык для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли Language ID на переносы слов и разрывы строк при рендеринге?**

В Aspose.Slides [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) используется для проверки. Качество переносов и перенос строк в основном зависит от наличия [proper fonts](/slides/ru/java/powerpoint-fonts/) и настроек разметки/разрывов строк для системы письма. Чтобы обеспечить корректный рендеринг, сделайте необходимые шрифты доступными, настройте [font substitution rules](/slides/ru/java/font-substitution/), и/или [embed fonts](/slides/ru/java/embedded-font/) в презентацию.

**Можно ли задать разные языки в одном абзаце?**

Да. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с разными параметрами проверки.