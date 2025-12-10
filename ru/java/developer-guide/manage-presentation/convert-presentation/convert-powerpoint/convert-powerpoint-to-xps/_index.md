---
title: Конвертация презентаций PowerPoint в XPS на Java
linktitle: PowerPoint в XPS
type: docs
weight: 70
url: /ru/java/convert-powerpoint-to-xps/
keywords:
- конвертация PowerPoint
- конвертация презентации
- конвертация слайда
- конвертация PPT
- конвертация PPTX
- PowerPoint в XPS
- презентация в XPS
- слайд в XPS
- PPT в XPS
- PPTX в XPS
- сохранить PPT как XPS
- сохранить PPTX как XPS
- экспортировать PPT в XPS
- экспортировать PPTX в XPS
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Конвертируйте PowerPoint PPT/PPTX в высококачественный, кроссплатформенный XPS на Java с помощью Aspose.Slides. Получите пошаговое руководство и пример кода."
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Это позволяет печатать содержимое, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**
{{% alert color="primary" %}} 
Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн-приложение конвертера](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

Если вы хотите сократить расходы на хранение, вы можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет проще сохранять, делиться и печатать документы. 

Microsoft продолжает активно поддерживать XPS в Windows (даже в Windows 10), поэтому вам может быть полезно сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может быть лучшим вариантом для некоторых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлы PDF. 
  - **XPS:** Встроенный просмотрщик/чтец XPS и возможность печати в XPS доступны. 
  - **PDF**: Доступен PDF‑чтец, но нет функции печати в PDF. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти ОС также обеспечивают лучшую поддержку файлов XPS, чем PDF. 
  - **XPS**: Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF**: Нет PDF‑чтения. Нет функции печати в PDF. 

|<p>**Ввод PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Вывод XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге реализовал поддержку операций печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи должны были печатать документы через формат XPS. 

## **Конвертация XPS с помощью Aspose.Slides**
В [**Aspose.Slides**](https://products.aspose.com/slides/java/) для Java вы можете использовать метод [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), предоставляемый классом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), чтобы преобразовать всю презентацию в документ XPS. 

При конвертации презентации в XPS необходимо сохранять презентацию, используя одну из следующих настроек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))

### **Конвертация презентаций в XPS с настройками по умолчанию**
Этот пример кода на Java показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:
```java
// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Сохранение презентации в документ XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Конвертация презентаций в XPS с пользовательскими настройками**
Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки в Java:
```java
// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Создайте экземпляр класса TiffOptions
    XpsOptions options = new XpsOptions();

    // Сохранить MetaFiles как PNG
    options.setSaveMetafilesAsPng(true);

    // Сохранить презентацию в документ XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Часто задаваемые вопросы**

**Можно ли сохранять XPS в поток вместо файла?**  
Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любой ситуации, когда необходимо передать XPS, не взаимодействуя с файловой системой.  

**Переносятся ли скрытые слайды в XPS, и можно ли их исключить?**  
По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) через [настройки экспорта](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/) перед сохранением в XPS, гарантируя, что результат содержит ровно те страницы, которые вы хотите.