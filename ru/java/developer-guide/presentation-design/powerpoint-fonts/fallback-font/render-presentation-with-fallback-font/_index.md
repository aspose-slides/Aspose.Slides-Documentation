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
description: "Отображайте презентации с резервными шрифтами в Aspose.Slides для Java – сохраняйте согласованность текста в PPT, PPTX и ODP с пошаговыми примерами кода на Java."
---
## **Обзор**

Aspose.Slides позволяет отображать презентации, используя правила резервных шрифтов. В этой статье показано, как создать коллекцию правил резервных шрифтов, изменить её правила, удаляя или добавляя резервные шрифты, и назначить коллекцию с помощью метода `FontsManager.setFontFallBackRulesCollection`.

После назначения коллекции правил резервных шрифтов менеджеру `FontsManager` презентации, правила применяются во время операций, таких как сохранение, рендеринг и конвертирование презентации. Пример демонстрирует, как использовать сконфигурированные правила при рендеринге миниатюры слайда и сохранении её в виде изображения JPEG.

## **Отображение слайда с использованием правил резервных шрифтов**

Следующий пример включает следующие шаги:

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/java/create-fallback-fonts-collection/).
2. [Remove](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) правило резервного шрифта и [addFallBackFonts](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) к другому правилу.
3. Установите коллекцию правил в [getFontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) метод.
4. С помощью метода [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#save-java.lang.String-int-) мы можем сохранить презентацию в том же формате или в другом. После того как коллекция правил резервных шрифтов назначена [FontsManager](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsManager), эти правила применяются при любых операциях над презентацией: сохранение, рендеринг, конвертирование и т.д.

```java
import com.aspose.slides.*;

// Создать новый экземпляр коллекции правил
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Пытаемся удалить резервный шрифт "Tahoma" из загруженных правил
    fallBackRule.remove("Tahoma");

    //И обновить правила для указанного диапазона
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

//Также мы можем удалить любые существующие правила из списка, оставив хотя бы одно правило для рендеринга
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Назначаем подготовленный список правил для использования
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
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

{{% alert color="info" %}} 
Узнайте больше о том, как [конвертировать PPT и PPTX в JPG на Java](/slides/ru/java/convert-powerpoint-to-jpg/).
{{% /alert %}}