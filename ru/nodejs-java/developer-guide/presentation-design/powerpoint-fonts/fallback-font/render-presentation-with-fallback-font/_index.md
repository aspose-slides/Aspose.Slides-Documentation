---
title: Отображение презентаций с резервными шрифтами в JavaScript
linktitle: Отображение презентаций
type: docs
weight: 30
url: /ru/nodejs-java/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- отображение PowerPoint
- отображение презентации
- отображение слайда
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Отображайте презентации с резервными шрифтами в Aspose.Slides для Node.js — сохраняйте согласованность текста в PPT, PPTX и ODP с пошаговыми примерами кода на JavaScript."
---

Следующий пример включает следующие шаги:

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/nodejs-java/create-fallback-fonts-collection/).
1. [Удалить](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) правило резервного шрифта и [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) к другому правилу.
1. Установите коллекцию правил с помощью метода [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
1. С помощью метода [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) мы можем сохранить презентацию в том же формате или в другом. После того как коллекция правил резервных шрифтов установлена в [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager), эти правила применяются при любых операциях с презентацией: сохранение, рендеринг, конвертация и т.д.
```javascript
// Создать новый экземпляр коллекции правил
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// Создать несколько правил
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Пытаемся удалить резервный шрифт "Tahoma" из загруженных правил
    fallBackRule.remove("Tahoma");
    // И обновить правила для указанного диапазона
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Также мы можем удалить любые существующие правила из списка
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Назначаем подготовленный список правил для использования
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Рендеринг миниатюры с использованием инициализированной коллекции правил и сохранением в JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Сохранить изображение на диск в формате JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 
Узнайте больше о том, как [Convert PPT and PPTX to JPG in JavaScript](/slides/ru/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}