---
title: Отображение презентаций с резервными шрифтами на Android
linktitle: Отображение презентаций
type: docs
weight: 30
url: /ru/androidjava/render-presentation-with-fallback-font/
keywords:
- резервный шрифт
- отображение PowerPoint
- отображение презентации
- отображение слайда
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Отображение презентаций с резервными шрифтами в Aspose.Slides для Android — сохраняйте одинаковый вид текста в PPT, PPTX и ODP с помощью пошаговых примеров кода на Java."
---
## **Обзор**

Aspose.Slides позволяет выводить презентации, используя правила резервных шрифтов. Эта статья показывает, как создать коллекцию правил резервных шрифтов, изменить её правила, удаляя или добавляя резервные шрифты, и назначить коллекцию с помощью метода `FontsManager.setFontFallBackRulesCollection`.

После того как коллекция правил резервных шрифтов будет назначена `FontsManager` презентации, правила применяются при таких операциях, как сохранение, рендеринг и конвертация презентации. В примере показано, как использовать настроенные правила при рендеринге миниатюры слайда и сохранении её в виде изображения JPEG.

## **Отрисовать слайд с использованием правил резервных шрифтов**

В следующем примере содержатся следующие шаги:

1. Мы [создаём коллекцию правил резервных шрифтов](/slides/ru/androidjava/create-fallback-fonts-collection/).
1. [Удалить](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) правило резервного шрифта и [addFallBackFonts](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) к другому правилу.
1. Установите коллекцию правил, используя [getFontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) метод.
1. С помощью метода [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) мы можем сохранить презентацию в том же формате или в другом. После того как коллекция правил резервных шрифтов назначена [FontsManager](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/FontsManager), эти правила применяются при любых операциях над презентацией: сохранение, рендеринг, конвертация и т.д.

```java
import com.aspose.slides.*;

// Создать новый экземпляр коллекции правил
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// создать набор правил
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    // Пытаемся удалить резервный шрифт "Tahoma" из загруженных правил
    fallBackRule.remove("Tahoma");

    // И обновить правила для указанного диапазона
    if ((fallBackRule.getRangeEndIndex() >= 0x400) && (fallBackRule.getRangeStartIndex() < 0x500))
        fallBackRule.addFallBackFonts("Verdana");
}

// Также можно удалить любые существующие правила из списка, оставив как минимум одно правило для рендеринга
if (rulesList.size() > 1)
    rulesList.remove(rulesList.get_Item(1));

Presentation pres = new Presentation("input.pptx");
try {
    //Назначаем подготовленный список правил для использования
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Рендеринг миниатюры с использованием инициализированной коллекции правил и сохранение в JPEG
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
Подробнее о [Конвертация PPT и PPTX в JPG на Android](/slides/ru/androidjava/convert-powerpoint-to-jpg/).
{{% /alert %}}