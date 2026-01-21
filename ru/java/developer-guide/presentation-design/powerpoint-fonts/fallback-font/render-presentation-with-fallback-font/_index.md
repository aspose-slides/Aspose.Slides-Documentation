---
title: Отображение презентаций с резервными шрифтами в Java
linktitle: Отображение презентаций
type: docs
weight: 30
url: /ru/java/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- отображение PowerPoint
- отображение презентации
- отображение слайда
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Отображение презентаций с резервными шрифтами в Aspose.Slides для Java - сохраняйте единообразие текста в PPT, PPTX и ODP с пошаговыми примерами кода на Java."
---

В следующем примере приведены эти шаги:

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/java/create-fallback-fonts-collection/).
1. [Удалить](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) правило резервного шрифта и [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) к другому правилу.
1. Установите коллекцию правил в [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) метод.
1. С помощью метода [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) мы можем сохранить презентацию в том же формате или в другом. После установки коллекции правил резервных шрифтов в [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) эти правила применяются при любых операциях с презентацией: сохранение, рендеринг, конвертация и т.д.
```java
// Создать новый экземпляр коллекции правил
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// создать несколько правил
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Пытаемся удалить шрифт FallBack "Tahoma" из загруженных правил
    fallBackRule.remove("Tahoma");

    // И обновить правила для указанного диапазона
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Также мы можем удалить любые существующие правила из списка
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Присваивание подготовленного списка правил для использования
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Рендеринг миниатюры с использованием инициализированной коллекции правил и сохранением в JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Сохранить изображение на диск в формате JPEG
   try {
         slideImage.save("Slide_0.jpg", ImageFormat.Jpeg);
   } finally {
        if (slideImage != null) slideImage.dispose();
   }
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Подробнее о том, как [конвертировать PPT и PPTX в JPG на Java](/slides/ru/java/convert-powerpoint-to-jpg/).
{{% /alert %}}