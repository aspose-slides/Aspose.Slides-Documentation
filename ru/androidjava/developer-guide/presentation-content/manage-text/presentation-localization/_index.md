---
title: Автоматизация локализации презентаций на Android
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/androidjava/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- идентификатор языка
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument в Java с Aspose.Slides для Android, используя практические примеры кода и советы для более быстрого глобального развертывания."
---

## **Изменение языка для презентации и текста формы**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) на слайд.
- Добавьте некоторый текст в TextFrame.
- [Установка Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) для текста.
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

Нет. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) в Aspose.Slides хранит язык для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые понимает PowerPoint для проверки.

**Влияет ли Language ID на переносы и разрывы строк при рендеринге?**

В Aspose.Slides, [language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) используется для проверки. Качество переноса и разрывы строк в первую очередь зависят от наличия [proper fonts](/slides/ru/androidjava/powerpoint-fonts/) и настроек разметки/разрыва строк для системы письма. Чтобы обеспечить правильный рендеринг, сделайте необходимые шрифты доступными, настройте [font substitution rules](/slides/ru/androidjava/font-substitution/) и/или [embed fonts](/slides/ru/androidjava/embedded-font/) в презентацию.

**Можно ли задать разные языки в одном абзаце?**

Да. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) применяется на уровне части текста, поэтому один абзац может содержать несколько языков с различными настройками проверки.