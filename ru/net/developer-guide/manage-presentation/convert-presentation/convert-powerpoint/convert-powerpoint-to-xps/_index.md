---
title: "Конвертировать PowerPoint в XPS"
type: docs
weight: 70
url: /ru/net/convert-powerpoint-to-xps
keywords: "Конвертировать презентацию PowerPoint, PowerPoint в XPS, PPT в XPS, PPTX в XPS, Преобразование, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертировать презентацию PowerPoint в XPS на C# или .NET."
---

## **Об XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/).  Он позволяет печатать содержимое, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн‑приложение‑конвертер](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить затраты на хранение, вы можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет проще сохранять, делиться и печатать ваши документы. 

Microsoft продолжает активно поддерживать XPS в Windows (включая Windows 10), поэтому стоит рассматривать сохранение файлов в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 или Windows Vista, XPS может стать лучшим вариантом для некоторых задач. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/ридер XPS и возможность печати в XPS доступны. 
  - **PDF:** Доступен PDF‑чтитель, но функция печати в PDF отсутствует. 

- **Windows 7** и **Windows Vista** используют оригинальный формат XPS. Эти ОС также предоставляют лучшую поддержку файлов XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF:** Нет PDF‑чтителя. Нет функции печати в PDF. 

|<p>**Вход PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выход XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft в конечном итоге реализовала поддержку печати в PDF через функцию «Print to PDF» в Windows 10. Ранее пользователи печатали документы через формат XPS. 

## **Конвертация XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/net/) для .NET вы можете использовать метод [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index), предоставляемый классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), чтобы преобразовать всю презентацию в документ XPS. 

При конвертации презентации в XPS необходимо сохранять её, используя один из следующих вариантов:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Конвертация презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода на C# показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:
```c#
// Создайте объект Presentation, который представляет файл презентации
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Сохранение презентации в документ XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```



### **Конвертация презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки на C#:
```c#
// Создать объект Presentation, который представляет файл презентации
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Создать экземпляр класса TiffOptions
    XpsOptions options = new XpsOptions();

    // Сохранить метафайлы как PNG
    options.SaveMetafilesAsPng = true;

    // Сохранить презентацию в документ XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **Вопросы и ответы**

**Можно ли сохранять XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для web‑API, серверных конвейеров или любых сценариев, когда нужно передать XPS без обращения к файловой системе.

**Переносятся ли скрытые слайды в XPS и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) через [настройки экспорта](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что вывод будет содержать именно те страницы, которые вам нужны.