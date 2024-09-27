---
title: Замена Шрифтов - PowerPoint Java API
linktitle: Замена Шрифтов
type: docs
weight: 60
url: /ru/java/font-replacement/
description: Узнайте, как заменить шрифты с помощью метода явной замены в PowerPoint с использованием Java API.
---

Если вы передумали использовать определенный шрифт, вы можете заменить его на другой шрифт. Все экземпляры старого шрифта будут заменены новым шрифтом.

Aspose.Slides позволяет заменить шрифт таким образом:

1. Загрузите соответствующую презентацию. 
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт. 
4. Замените шрифт. 
5. Запишите измененную презентацию в файл PPTX.

Этот Java код демонстрирует замену шрифта:

```java
// Загружает презентацию
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Загружает исходный шрифт, который будет заменен
    IFontData sourceFont = new FontData("Arial");
    
    // Загружает новый шрифт
    IFontData destFont = new FontData("Times New Roman");
    
    // Заменяет шрифты
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Сохраняет презентацию
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Примечание" color="warning" %}} 

Чтобы установить правила, определяющие, что происходит в определенных условиях (если шрифт недоступен, например), смотрите [**Замена Шрифтов**](/slides/ru/java/font-substitution/).

{{% /alert %}}