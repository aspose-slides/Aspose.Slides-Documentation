---
title: Автоматизация локализации презентаций в Java
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/java/presentation-localization/
keywords:
- изменить язык
- проверка орфографии
- идентификатор языка
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument в Java с помощью Aspose.Slides, используя практические примеры кода и рекомендации для более быстрого глобального развертывания."
---

## **Изменение языка для презентации и текста в фигуре**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте к слайду объект [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) типа [Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle).
- Добавьте текст в TextFrame.
- [Установка идентификатора языка](https://reference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) для текста.
- Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов показана ниже в примере.
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


## **Часто задаваемые вопросы**

**Вызывает ли идентификатор языка автоматический перевод текста?**

Нет. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) в Aspose.Slides хранит язык для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint использует для проверки.

**Влияет ли идентификатор языка на переносы и разбиение строк при рендеринге?**

В Aspose.Slides [language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) используется для проверки. Качество переноса и перенаправления строк в основном зависит от наличия [соответствующих шрифтов](/slides/ru/java/powerpoint-fonts/) и настроек разметки/переносов для системы письма. Чтобы обеспечить правильный рендеринг, сделайте необходимые шрифты доступными, настройте [правила замены шрифтов](/slides/ru/java/font-substitution/), и/или [встраивание шрифтов](/slides/ru/java/embedded-font/) в презентацию.

**Можно ли задать разные языки в одном абзаце?**

Да. [Language ID](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) применяется на уровне части текста, поэтому в одном абзаце можно смешивать несколько языков с разными настройками проверки.