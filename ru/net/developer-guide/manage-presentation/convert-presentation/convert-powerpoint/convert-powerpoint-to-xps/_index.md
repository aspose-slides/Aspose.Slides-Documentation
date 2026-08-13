---
title: Конвертировать презентации PowerPoint в XPS в .NET
linktitle: PowerPoint в XPS
type: docs
weight: 70
url: /ru/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественный, независимый от платформы XPS в .NET с использованием Aspose.Slides. Получите пошаговое руководство и пример кода C#."
---
## **Обзор**

Aspose.Slides позволяет конвертировать презентации PowerPoint в XPS, сохраняя файл PPT или PPTX в формате XPS. Эта статья объясняет, когда формат XPS может быть полезен, и показывает, как выполнить конвертацию с Aspose.Slides, используя либо настройки по умолчанию, либо пользовательские настройки [XpsOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions/) .

## **Об XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать контент, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="info" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн‑приложение конвертера](https://products.aspose.app/slides/ru/conversion). 

{{% /alert %}} 

Если вы хотите сократить затраты на хранение, можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом вам будет проще сохранять, обмениваться и печатать документы. 

Microsoft продолжает активно поддерживать XPS в Windows (в том числе в Windows 10), поэтому стоит рассмотреть сохранение файлов в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 или Windows Vista, XPS может стать лучшим вариантом для некоторых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 предоставляет лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/чтение XPS и возможность печати в XPS доступны. 
  - **PDF:** Доступен PDF‑просмотрщик, но функция печати в PDF отсутствует. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также предоставляют лучшую поддержку файлов XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF:** Нет PDF‑просмотрщика. Нет функции печати в PDF. 

|<p>**Входной PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге реализовала поддержку печати в PDF через функцию Print to PDF в Windows 10. Ранее пользователи должны были печатать документы через формат XPS. 

## **Конвертация XPS с Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/ru/net/) для .NET вы можете использовать метод [**Save**](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/methods/save/index), предоставляемый классом [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation), чтобы конвертировать всю презентацию в документ XPS. 

При конвертации презентации в XPS вам нужно сохранить презентацию, используя одну из следующих настройек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions))

### **Конвертировать презентации в XPS, используя настройки по умолчанию**

Этот пример кода на C# показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создать объект Presentation, который представляет файл презентации
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Сохранение презентации в документ XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Конвертировать презентации в XPS, используя пользовательские настройки**
Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки в C#:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создать объект Presentation, который представляет файл презентации
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Создать объект класса TiffOptions
    XpsOptions options = new XpsOptions();

    // Сохранить метафайлы как PNG
    options.SaveMetafilesAsPng = true;

    // Сохранить презентацию в документ XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **FAQ**

### Могу ли я сохранить XPS в поток вместо файла?

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любого сценария, когда нужно отправить XPS без обращения к файловой системе.

### Переносятся ли скрытые слайды в XPS и можно ли их исключить?

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions/showhiddenslides/) через [настройки экспорта](https://reference.aspose.com/slides/ru/net/aspose.slides.export/xpsoptions/) перед сохранением в XPS, обеспечивая, что вывод содержит именно те страницы, которые вам нужны.