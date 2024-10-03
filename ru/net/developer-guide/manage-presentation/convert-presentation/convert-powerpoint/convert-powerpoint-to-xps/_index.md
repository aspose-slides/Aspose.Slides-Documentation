---
title: Преобразование PowerPoint в XPS
type: docs
weight: 70
url: /ru/net/convert-powerpoint-to-xps
keywords: "Преобразовать презентацию PowerPoint, PowerPoint в XPS, PPT в XPS, PPTX в XPS, Конверсия, C#, Csharp, .NET, Aspose.Slides"
description: "Преобразовать презентацию PowerPoint в XPS на C# или .NET."
---

## **О XPS**
Microsoft разработал [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах.

## Когда использовать формат Microsoft XPS

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн-приложение для конвертации](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

Если вы хотите сократить затраты на хранение, вы можете преобразовать свою презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет легче сохранять, делиться и печатать ваши документы. 

Microsoft продолжает внедрять сильную поддержку XPS в Windows (даже в Windows 10), поэтому вы можете рассмотреть возможность сохранения файлов в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может на самом деле быть вашим лучшим вариантом для определенных операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS является стандартизированной версией оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Доступен встроенный просмотрщик/ридер XPS и функция печати в XPS. 
  - **PDF**: Доступен ридер PDF, но функция печати в PDF отсутствует. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку файлов XPS, чем PDF. 
  - **XPS**: Доступен встроенный просмотрщик XPS и функция печати в XPS. 
  - **PDF**: Нет ридера PDF. Нет функции печати в PDF. 

|<p>**Входной PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге внедрил поддержку операций печати в PDF через функцию Печать в PDF в Windows 10. Ранее от пользователей ожидалось, что они будут печатать документы через формат XPS.

## Конверсия XPS с Aspose.Slides

В [**Aspose.Slides**](https://products.aspose.com/slides/net/) для .NET вы можете использовать метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index), предоставляемый классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), чтобы преобразовать всю презентацию в документ XPS.

При преобразовании презентации в XPS вам необходимо сохранить презентацию, используя любой из этих параметров:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Преобразование презентаций в XPS с использованием стандартных настроек**

Этот пример кода на C# показывает, как преобразовать презентацию в документ XPS, используя стандартные настройки:

```c#
// Создание объекта Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Сохранение презентации в документ XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Преобразование презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как преобразовать презентацию в документ XPS, используя пользовательские настройки на C#:

```c#
// Создание объекта Presentation, представляющего файл презентации
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Создание класса XpsOptions
    XpsOptions options = new XpsOptions();

    // Сохранение метафайлов в формате PNG
    options.SaveMetafilesAsPng = true;

    // Сохранение презентации в документ XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```