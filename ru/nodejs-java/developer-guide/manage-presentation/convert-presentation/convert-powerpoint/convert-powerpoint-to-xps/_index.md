---
title: Конвертировать PowerPoint в XPS
type: docs
weight: 70
url: /ru/nodejs-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX в XPS"
description: "Конвертировать PowerPoint PPT(X) в XPS на JavaScript"
---

## **О XPS**

Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать контент, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн‑приложение конвертера](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить затраты на хранение, вы можете преобразовать вашу презентацию Microsoft PowerPoint в формат XPS. Так вам будет проще сохранять, делиться и печатать документы. 

Microsoft продолжает активно поддерживать XPS в Windows (даже в Windows 10), поэтому вам может быть полезно сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может быть лучшим вариантом для некоторых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/читалка XPS и возможность печати в XPS доступны. 
  - **PDF**: Доступен PDF‑просмотрщик, но нет функции печати в PDF. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку файлов XPS, чем PDF. 
  - **XPS**: Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF**: Нет PDF‑просмотрщика. Нет функции печати в PDF. 

|<p>**Ввод PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Вывод XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft со временем реализовала поддержку печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи могли печатать документы только через формат XPS. 

## **Преобразование XPS с помощью Aspose.Slides**

В [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) вы можете использовать метод [**save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), предоставляемый классом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), чтобы преобразовать всю презентацию в документ XPS.

При преобразовании презентации в XPS необходимо сохранять презентацию, используя один из следующих вариантов настроек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))

### **Преобразование презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода на JavaScript демонстрирует, как преобразовать презентацию в документ XPS, используя стандартные настройки:
```javascript
// Создать объект Presentation, который представляет файл презентации
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Сохранение презентации в документ XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Преобразование презентаций в XPS с использованием пользовательских настроек**

Этот пример кода показывает, как преобразовать презентацию в документ XPS, используя пользовательские настройки в JavaScript:
```javascript
// Создать объект Presentation, который представляет файл презентации
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Создать объект класса XpsOptions
    var options = new aspose.slides.XpsOptions();
    // Сохранить метафайлы как PNG
    options.setSaveMetafilesAsPng(true);
    // Сохранить презентацию в документ XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Можно ли сохранять XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любых сценариев, где требуется передать XPS без обращения к файловой системе.

**Переносятся ли скрытые слайды в XPS и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) через [настройки экспорта](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) перед сохранением в XPS, гарантируя, что результат будет содержать именно те страницы, которые вы планируете.