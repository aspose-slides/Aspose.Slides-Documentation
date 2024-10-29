---
title: Замена шрифта - PowerPoint Java API
linktitle: Замена шрифта
type: docs
weight: 70
url: /ru/java/font-substitution/
keywords: "Шрифт, заменяющий шрифт, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Замена шрифта в PowerPoint на Java"
---

Aspose.Slides позволяет вам устанавливать правила для шрифтов, которые определяют, что должно быть сделано в определенных условиях (например, когда шрифт недоступен) следующим образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Добавьте правило для замены.
5. Добавьте правило в коллекцию правил замены шрифтов презентации.
6. Сгенерируйте изображение слайда, чтобы увидеть эффект.

Этот код на Java демонстрирует процесс замены шрифта:

```java
// Загружает презентацию
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Загружает исходный шрифт, который будет заменен
    IFontData sourceFont = new FontData("НекоторыйРедкийШрифт");
    
    // Загружает новый шрифт
    IFontData destFont = new FontData("Arial");
    
    // Добавляет правило шрифта для замены шрифта
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Добавляет правило в коллекцию правил замены шрифтов
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Добавляет коллекцию правил шрифта в список правил
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Шрифт Arial будет использоваться вместо НекоторыйРедкийШрифт, когда последний будет недоступен
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Сохраняет изображение на диск в формате JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Вам может быть интересно посмотреть [**Замена шрифта**](/slides/ru/java/font-replacement/). 

{{% /alert %}}