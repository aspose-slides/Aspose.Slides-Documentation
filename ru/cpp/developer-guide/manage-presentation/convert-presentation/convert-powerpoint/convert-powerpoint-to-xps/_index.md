---
title: Конвертировать презентации PowerPoint в XPS на C++
linktitle: PowerPoint в XPS
type: docs
weight: 70
url: /ru/cpp/convert-powerpoint-to-xps
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
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
- C++
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественный, независимый от платформы XPS на C++ с помощью Aspose.Slides. Получите пошаговое руководство и пример кода."
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="primary" %}} 
Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, можете ознакомиться с [этим бесплатным онлайн‑конвертером](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

Если вы хотите сократить затраты на хранение, можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом будет проще сохранять, делиться и печатать ваши документы. 

Microsoft продолжает активно поддерживать XPS в Windows (включая Windows 10), поэтому стоит рассмотреть возможность сохранения файлов в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может стать лучшим выбором для некоторых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 предоставляет более полную поддержку файлов XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик/чтение XPS и возможность печати в XPS. 
  - **PDF:** Доступен просмотрщик PDF, но отсутствует функция печати в PDF. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти ОС также лучше поддерживают файлы XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS. 
  - **PDF:** Нет просмотровщика PDF. Нет функции печати в PDF. 

|<p>**Входной PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге реализовала поддержку печати в PDF через функцию «Print to PDF» в Windows 10. Ранее пользователи ожидали печатать документы через формат XPS. 

## **Конвертация XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) для C++ вы можете использовать метод [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставляемый классом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), чтобы преобразовать всю презентацию в документ XPS. 

При конвертации презентации в XPS необходимо сохранять её, используя один из следующих вариантов:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Преобразование презентаций в XPS с настройками по умолчанию**

Этот пример кода на C++ показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:
``` cpp
// Создать объект Presentation, который представляет файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Сохранить презентацию в документ XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Преобразование презентаций в XPS с пользовательскими настройками**
Этот пример кода демонстрирует, как конвертировать презентацию в документ XPS с пользовательскими настройками в C++:
``` cpp
// Создать объект Presentation, представляющий файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Создать объект класса TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Сохранить метафайлы как PNG
options->set_SaveMetafilesAsPng(true);

// Сохранить презентацию в документ XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **FAQ**

**Можно ли сохранять XPS в поток, а не в файл?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что удобно для веб‑API, серверных конвейеров или любых сценариев, когда необходимо отправить XPS без доступа к файловой системе.

**Переносятся ли скрытые слайды в XPS и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) через [настройки экспорта](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что вывод содержит ровно те страницы, которые вам нужны.