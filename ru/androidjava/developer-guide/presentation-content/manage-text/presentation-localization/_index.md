---
title: Автоматизация локализации презентаций на Android
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/androidjava/presentation-localization/
keywords:
- изменение языка
- проверка орфографии
- идентификатор языка
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument на Java с помощью Aspose.Slides для Android, используя практические образцы кода и рекомендации для более быстрого глобального развертывания."
---

## **Изменение языка для презентации и текста формы**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его Index.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapeType#Rectangle) на слайд.
- Добавьте некоторый текст в TextFrame.
- Установите [Setting Language Id](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) для текста.
- Сохраните презентацию как файл PPTX.

Реализация вышеуказанных шагов продемонстрирована ниже в примере.
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

**Вызывает ли идентификатор языка автоматический перевод текста?**

Нет. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) в Aspose.Slides сохраняет язык для проверки правописания и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли идентификатор языка на переносы слов и разрывы строк при рендеринге?**

В Aspose.Slides [language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) используется для проверки правописания. Качество переноса слов и разрыва строк в основном зависит от наличия [proper fonts](/slides/ru/androidjava/powerpoint-fonts/) и настроек разметки/переноса строк для системы письма. Чтобы обеспечить корректный рендеринг, сделайте необходимые шрифты доступными, настройте [font substitution rules](/slides/ru/androidjava/font-substitution/) и/или [embed fonts](/slides/ru/androidjava/embedded-font/) в презентацию.

**Могу ли я задать разные языки в пределах одного абзаца?**

Да. [Language ID](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) применяется на уровне части текста, поэтому один абзац может содержать несколько языков с разными настройками проверки.