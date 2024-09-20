---
title: Конвертация PowerPoint в XPS
type: docs
weight: 70
url: /androidjava/convert-powerpoint-to-xps/
keywords: "PPT, PPTX в XPS"
description: "Конвертация PowerPoint PPT(X) в XPS на Java"
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, создавая файл, который очень похож на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются неизменными на всех операционных системах и принтерах.

## Когда использовать формат Microsoft XPS

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует презентации PPT или PPTX в формат XPS, вы можете ознакомится с [этим бесплатным онлайн-конвертером](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить расходы на хранение данных, вы можете конвертировать свою презентацию Microsoft PowerPoint в формат XPS. Это упростит вам сохранение, совместное использование и печать ваших документов.

Microsoft продолжает внедрять надежную поддержку XPS в Windows (даже в Windows 10), поэтому вам стоит рассмотреть возможность сохранения файлов в этом формате. Если вы используете Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может быть вашим лучшим вариантом для определенных операций.

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — это стандартизированная версия оригинального формата XPS. Windows 8 предлагает лучшую поддержку файлов XPS, чем для PDF файлов. 
  - **XPS:** Встроенный просмотрщик/чтец XPS и функция печати в XPS доступны. 
  - **PDF**: Доступен чтец PDF, но функция печати в PDF отсутствует.

-  **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также предлагают лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS**: Встроенный просмотрщик XPS и функция печати в XPS доступны. 
  - **PDF**: Нет чтеца PDF. Функция печати в PDF отсутствует. 

|<p>**Входной PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге внедрила поддержку операций печати в PDF через функцию Печать в PDF в Windows 10. Ранее от пользователей ожидалось, что они будут печатать документы через формат XPS.

## Конвертация XPS с помощью Aspose.Slides

В [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) для Java вы можете использовать метод [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) для конвертации всей презентации в документ XPS.

При конвертации презентации в XPS вы должны сохранить презентацию, используя один из следующих параметров:

- Стандартные настройки (без [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xpsoptions))

### **Конвертация презентаций в XPS с использованием стандартных настроек**

Этот пример кода на Java показывает, как конвертировать презентацию в документ XPS с использованием стандартных настроек:

```java
// Создание объекта Presentation, представляющего файл презентации
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Сохранение презентации в документ XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Конвертация презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как конвертировать презентацию в документ XPS с использованием пользовательских настроек на Java:

```java
// Создание объекта Presentation, представляющего файл презентации
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Создание класса TiffOptions
    XpsOptions options = new XpsOptions();

    // Сохранить метафайлы как PNG
    options.setSaveMetafilesAsPng(true);

    // Сохранение презентации в документ XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```