---
title: Замена шрифтов - PowerPoint Java API
linktitle: Замена шрифтов
type: docs
weight: 60
url: /androidjava/font-replacement/
description: Узнайте, как заменить шрифты, используя явный метод замены в PowerPoint с помощью Java API.
---

Если вы передумали использовать шрифт, вы можете заменить этот шрифт на другой. Все экземпляры старого шрифта будут заменены новым шрифтом.

Aspose.Slides позволяет заменить шрифт таким образом:

1. Загрузите соответствующую презентацию.
2. Загрузите шрифт, который будет заменен.
3. Загрузите новый шрифт.
4. Замените шрифт.
5. Запишите измененную презентацию в файл PPTX.

Этот код на Java демонстрирует замену шрифта:

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

Чтобы установить правила, определяющие, что происходит в определенных условиях (например, если шрифт недоступен), см. [**Замена шрифтов**](/slides/androidjava/font-substitution/).

{{% /alert %}}