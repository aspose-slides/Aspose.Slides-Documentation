---
title: "Преобразование презентаций PowerPoint в XPS в .NET"
linktitle: "PowerPoint в XPS"
type: docs
weight: 70
url: /ru/net/convert-powerpoint-to-xps/
keywords:
- "конвертировать PowerPoint"
- "конвертировать презентацию"
- "конвертировать слайд"
- "конвертировать PPT"
- "конвертировать PPTX"
- "PowerPoint в XPS"
- "презентацию в XPS"
- "слайд в XPS"
- "PPT в XPS"
- "PPTX в XPS"
- "сохранить PPT как XPS"
- "сохранить PPTX как XPS"
- "экспортировать PPT в XPS"
- "экспортировать PPTX в XPS"
- "PowerPoint"
- "презентация"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Преобразуйте PowerPoint PPT/PPTX в высококачественный, независимый от платформы XPS в .NET с помощью Aspose.Slides. Получите пошаговое руководство и пример кода C#."
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Она позволяет печатать содержимое, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Разметка или структура файла XPS остаётся одинаковой на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете проверить [это бесплатное онлайн‑приложение конвертера](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить расходы на хранение, вы можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Так вам будет проще сохранять, делиться и печатать документы. 

Microsoft продолжает активно поддерживать XPS в Windows (даже в Windows 10), поэтому стоит рассмотреть сохранение файлов в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 или Windows Vista, XPS может быть лучшим вариантом для некоторых задач. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — это стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/чтение XPS и возможность печати в XPS доступны. 
  - **PDF:** Доступен PDF‑чтение, но нет функции печати в PDF. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти ОС также предлагают лучшую поддержку XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF:** Нет PDF‑чтения. Нет функции печати в PDF. 

|<p>**Входной PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft в конечном итоге внедрила поддержку печати в PDF через функцию «Печать в PDF» в Windows 10. Ранее пользователям предлагалось печатать документы через формат XPS. 

## **Преобразование XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/net/) для .NET вы можете использовать метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index), предоставляемый классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), чтобы преобразовать всю презентацию в документ XPS. 

При преобразовании презентации в XPS необходимо сохранять её, используя один из следующих вариантов настроек:

- Стандартные настройки (без [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Преобразование презентаций в XPS с использованием стандартных настроек**

Этот пример кода на C# показывает, как преобразовать презентацию в документ XPS, используя стандартные настройки:
```c#
// Создать объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Сохранение презентации в документ XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Преобразование презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как преобразовать презентацию в документ XPS, используя пользовательские настройки в C#:
```c#
// Создать объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Создать объект класса TiffOptions
    XpsOptions options = new XpsOptions();

    // Сохранить метафайлы в PNG
    options.SaveMetafilesAsPng = true;

    // Сохранить презентацию в документ XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **FAQ**

**Могу ли я сохранять XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любой ситуации, когда нужно передать XPS, не взаимодействуя с файловой системой.

**Переносятся ли скрытые слайды в XPS и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) через [настройки экспорта](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что вывод содержит ровно те страницы, которые вам нужны.