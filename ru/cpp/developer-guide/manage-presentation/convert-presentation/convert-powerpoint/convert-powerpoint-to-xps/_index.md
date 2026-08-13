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
- презентацию в XPS
- слайд в XPS
- PPT в XPS
- PPTX в XPS
- сохранить PPT как XPS
- сохранить PPTX как XPS
- экспортировать PPT в XPS
- экспортировать PPTX в XPS
- PowerPoint
- презентацию
- C++
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественный, независимый от платформы XPS на C++ с использованием Aspose.Slides. Получите пошаговое руководство и пример кода."
---
## **Обзор**

Aspose.Slides позволяет конвертировать презентации PowerPoint в XPS, сохраняя файл PPT или PPTX в формате XPS. В этой статье объясняется, когда формат XPS может быть полезен, и показывается, как выполнить конвертацию с помощью Aspose.Slides, используя либо параметры по умолчанию, либо пользовательские [XpsOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/xpsoptions/) настройки.

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах.

## **Когда использовать формат Microsoft XPS**

{{% alert color="info" %}} 
Чтобы увидеть, как Aspose.Slides конвертирует презентацию PPT или PPTX в формат XPS, вы можете воспользоваться [этим бесплатным онлайн‑конвертером](https://products.aspose.app/slides/ru/conversion). 
{{% /alert %}} 

Если вы хотите сократить затраты на хранение, можете конвертировать свою презентацию Microsoft PowerPoint в формат XPS. Это упростит сохранение, совместное использование и печать ваших документов.

Microsoft продолжает активно поддерживать XPS в Windows (включая Windows 10), поэтому имеет смысл сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, XPS может стать лучшим выбором для некоторых операций.

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик/чтение XPS и возможность печати в XPS доступны. 
  - **PDF:** Доступен просмотрщик PDF, но функция печати в PDF отсутствует. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF:** Нет просмотрщика PDF. Функция печати в PDF отсутствует. 

|<p>**Входной PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге внедрила поддержку печати в PDF через функцию «Print to PDF» в Windows 10. Ранее пользователи должны были печатать документы через формат XPS.

## **Конвертация XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/ru/cpp/) для C++ вы можете использовать метод [**Save**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставляемый классом [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation), чтобы преобразовать всю презентацию в документ XPS.

При конвертации презентации в XPS необходимо сохранять её, используя одну из следующих настроек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.export.xps_options))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.export.xps_options))

### **Конвертировать презентации в XPS, используя настройки по умолчанию**

Этот пример кода на C++ показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Создать объект Presentation, который представляет файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Сохранение презентации в документ XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Конвертировать презентации в XPS, используя пользовательские настройки**

Этот пример кода показывает, как конвертировать презентацию в документ XPS с пользовательскими настройками на C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Создать объект Presentation, который представляет файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Создать объект класса TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Сохранить метафайлы как PNG
options->set_SaveMetafilesAsPng(true);

// Сохранить презентацию в документ XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **FAQ**

### Можно ли сохранять XPS в поток вместо файла?

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любых сценариев, когда необходимо передать XPS без обращения к файловой системе.

### Переносятся ли скрытые слайды в XPS, и можно ли их исключить?

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) через [настройки экспорта](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что вывод будет содержать именно те страницы, которые вам нужны.