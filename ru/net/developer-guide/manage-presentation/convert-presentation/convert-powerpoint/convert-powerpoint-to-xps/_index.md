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
description: "Конвертировать PowerPoint PPT/PPTX в высококачественный, платформо-независимый XPS в .NET с использованием Aspose.Slides. Получите пошаговое руководство и пример кода на C#."
---

## **Об XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Это позволяет печатать контент, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн‑приложение‑конвертер](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить расходы на хранение, вы можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Так вам будет проще сохранять, делиться и печатать ваши документы. 

Microsoft продолжает активно поддерживать XPS в Windows (в том числе в Windows 10), поэтому может иметь смысл сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может стать лучшим вариантом для некоторых задач. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем PDF. 
  - **XPS:** Доступен встроенный просмотрщик/чтение XPS и возможность печати в XPS. 
  - **PDF:** Доступен PDF‑чтение, но нет функции печати в PDF. 

-  **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку XPS, чем PDF. 
  - **XPS:** Доступен встроенный просмотрщик XPS и возможность печати в XPS. 
  - **PDF:** Нет PDF‑чтения. Нет функции печати в PDF. 

|<p>**Входной PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге реализовала поддержку печати в PDF через функцию Print to PDF в Windows 10. Ранее пользователи печатали документы с помощью формата XPS. 

## **Конвертация XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/net/) для .NET вы можете использовать метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index), предоставленный классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), чтобы преобразовать всю презентацию в документ XPS. 

При конвертации презентации в XPS необходимо сохранять презентацию, используя один из следующих вариантов настроек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Конвертация презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода на C# показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:
```c#
// Создать объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Сохранение презентации в документ XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Конвертация презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки на C#:
```c#
// Создать объект Presentation, представляющий файл презентации
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

**Могу ли я сохранить XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать непосредственно в поток, что идеально подходит для веб‑API, серверных конвейеров или любых сценариев, когда необходимо передать XPS, не взаимодействуя с файловой системой.

**Переносятся ли скрытые слайды в XPS, и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) через [настройки экспорта](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что вывод будет содержать именно те страницы, которые вам нужны.