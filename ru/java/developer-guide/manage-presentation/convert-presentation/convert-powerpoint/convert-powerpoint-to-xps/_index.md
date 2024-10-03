---
title: Конвертация PowerPoint в XPS
type: docs
weight: 70
url: /ru/java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX в XPS"
description: "Конвертация PowerPoint PPT(X) в XPS на Java"
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура XPS файла остаются одинаковыми на всех операционных системах и принтерах.

## Когда использовать формат Microsoft XPS

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует презентации PPT или PPTX в формат XPS, вы можете ознакомиться с [этим бесплатным онлайн-конвертером](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить затраты на хранение, вы можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет проще сохранять, делиться и печатать ваши документы.

Microsoft продолжает внедрять сильную поддержку XPS в Windows (даже в Windows 10), так что вам может стоить рассмотреть возможность сохранения файлов в этом формате. Если вы имеете дело с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может стать вашим лучшим выбором для определенных операций.

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS является стандартизированной версией оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку для файлов XPS, чем для PDF.
  - **XPS:** Доступен встроенный просмотрщик/читалка XPS и возможность печати в XPS.
  - **PDF**: Доступен читалка PDF, но отсутствует возможность печати в PDF.

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку для файлов XPS, чем для PDF.
  - **XPS**: Доступен встроенный просмотрщик XPS и возможность печати в XPS.
  - **PDF**: Нет читалки PDF. Нет возможности печати в PDF.

|<p>**Входные PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходные XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft в конечном итоге внедрила поддержку операций печати в PDF через функцию "Печать в PDF" в Windows 10. Ранее от пользователей ожидали, что они будут печатать документы через формат XPS.

## Конвертация XPS с Aspose.Slides

В [**Aspose.Slides**](https://products.aspose.com/slides/java/) для Java вы можете использовать метод [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), чтобы конвертировать всю презентацию в документ XPS.

При конвертации презентации в XPS вам нужно сохранить презентацию, используя один из этих параметров:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))

### **Конвертация презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода на Java показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:

```java
// Создаем объект Presentation, который представляет файл презентации
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Сохраняем презентацию в документ XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Конвертация презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки на Java:

```java
// Создаем объект Presentation, который представляет файл презентации
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Создаем класс XpsOptions
    XpsOptions options = new XpsOptions();

    // Сохраняем метафайлы как PNG
    options.setSaveMetafilesAsPng(true);

    // Сохраняем презентацию в документ XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```