---
title: Конвертировать презентации PowerPoint в XPS на Java
linktitle: PowerPoint в XPS
type: docs
weight: 70
url: /ru/java/convert-powerpoint-to-xps/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в XPS
- презентацию в XPS
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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественный, независимый от платформы XPS на Java с помощью Aspose.Slides. Получите пошаговое руководство и пример кода."
---
## **Обзор**

Aspose.Slides позволяет конвертировать презентации PowerPoint в XPS, сохраняя файл PPT или PPTX в формате XPS. Эта статья объясняет, когда формат XPS может быть полезен, и показывает, как выполнить конвертацию с помощью Aspose.Slides, используя либо настройки по умолчанию, либо пользовательские настройки [XpsOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xpsoptions/) .

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="info" %}} 
Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн‑приложение конвертера](https://products.aspose.app/slides/ru/conversion). 
{{% /alert %}} 

Если вы хотите сократить расходы на хранение, можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом будет проще сохранять, делиться и печатать документы. 

Microsoft продолжает активно поддерживать XPS в Windows (включая Windows 10), поэтому имеет смысл сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может стать лучшим вариантом для некоторых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/читалка XPS и возможность печати в XPS доступны. 
  - **PDF:** Читалка PDF доступна, но возможности печати в PDF нет. 

- **Windows 7** и **Windows Vista** используют оригинальный формат XPS. Эти операционные системы также предоставляют лучшую поддержку файлов XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF:** Читалки PDF нет. Возможности печати в PDF нет. 

|<p>**Входной PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft впоследствии реализовала поддержку печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи ожидали печатать документы через формат XPS. 

## **Конвертация XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/ru/java/) для Java вы можете использовать метод [**Save**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) для преобразования всей презентации в документ XPS. 

При конвертации презентации в XPS необходимо сохранять презентацию, используя одну из следующих настройк :
- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xpsoptions))

### **Конвертировать презентации в XPS, используя настройки по умолчанию**

Этот пример кода на Java показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:

```java
import com.aspose.slides.*;

// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Сохранение презентации в документ XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Конвертировать презентации в XPS, используя пользовательские настройки**
Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки в Java:

```java
import com.aspose.slides.*;

// Создайте объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Создайте объект класса XpsOptions
    XpsOptions options = new XpsOptions();

    // Сохранить метафайлы как PNG
    options.setSaveMetafilesAsPng(true);

    // Сохранить презентацию в документ XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Часто задаваемые вопросы**

### Можно ли сохранять XPS в поток вместо файла?

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любой ситуации, когда требуется передать XPS без обращения к файловой системе.

### Переносятся ли скрытые слайды в XPS, и можно ли их исключить?

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) через [настройки экспорта](https://reference.aspose.com/slides/ru/java/com.aspose.slides/xpsoptions/) перед сохранением в XPS, обеспечивая, что вывод содержит точно те страницы, которые вам нужны.