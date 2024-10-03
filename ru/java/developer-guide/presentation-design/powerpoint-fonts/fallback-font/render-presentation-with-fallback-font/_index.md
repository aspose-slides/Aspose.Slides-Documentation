---
title: Отображение презентации с запасным шрифтом
type: docs
weight: 30
url: /ru/java/render-presentation-with-fallback-font/
---

Следующий пример включает в себя следующие шаги:

1. Мы [создаем коллекцию правил запасных шрифтов](/slides/ru/java/create-fallback-fonts-collection/).
1. [Удаляем](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) правило запасного шрифта и [добавляем запасные шрифты](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) к другому правилу.
1. Устанавливаем коллекцию правил в метод [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--).
1. С помощью метода [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) мы можем сохранить презентацию в том же формате или сохранить ее в другом. После установки коллекции правил запасного шрифта в [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), эти правила применяются при любых операциях с презентацией: сохранение, отображение, конвертация и т.д.

```java
// Создание нового экземпляра коллекции правил
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// создание ряда правил
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Попытка удалить запасной шрифт "Tahoma" из загруженных правил
    fallBackRule.remove("Tahoma");

    // И обновление правил для заданного диапазона
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

// Также мы можем удалить любые существующие правила из списка
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    // Присвоение подготовленного списка правил для использования
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Отображение миниатюры с использованием инициализированной коллекции правил и сохранение в JPEG
   IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);

   // Сохранение изображения на диск в формате JPEG
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
Узнайте больше о [Сохранении и конвертации в презентации](/slides/ru/java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}