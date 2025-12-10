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
- сохранять PPT как XPS
- сохранять PPTX как XPS
- экспортировать PPT в XPS
- экспортировать PPTX в XPS
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественный, платформенно-независимый XPS на C++ с использованием Aspose.Slides. Получите пошаговое руководство и пример кода."
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, создав файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн-приложение конвертера](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить расходы на хранение, можете преобразовать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет проще сохранять, делиться и печатать документы. 

Microsoft продолжает активно поддерживать XPS в Windows (даже в Windows 10), поэтому возможно стоит сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может быть лучшим вариантом для некоторых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — это стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает более лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/читалка XPS и возможность печати в XPS доступны. 
  - **PDF:** Доступен PDF‑читалка, но функции печати в PDF нет. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти ОС также предоставляют более лучшую поддержку файлов XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF:** Нет PDF‑читалки. Нет функции печати в PDF. 

|<p>**Входной PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге реализовала поддержку печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи ожидали печатать документы через формат XPS. 

## **Конвертация XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) для C++ вы можете использовать метод [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставляемый классом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), чтобы преобразовать всю презентацию в документ XPS. 

При конвертации презентации в XPS вам нужно сохранять презентацию, используя один из следующих параметров:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Преобразование презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода на C++ показывает, как преобразовать презентацию в документ XPS, используя стандартные настройки:
``` cpp
// Создать объект Presentation, представляющий файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Сохранение презентации в документ XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Преобразование презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как преобразовать презентацию в документ XPS, используя пользовательские настройки в C++:
``` cpp
// Создать объект Presentation, представляющий файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Создать объект класса TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Сохранить MetaFiles как PNG
options->set_SaveMetafilesAsPng(true);

// Сохранить презентацию в документ XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **Часто задаваемые вопросы**

**Можно ли сохранять XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любой ситуации, когда необходимо отправить XPS, не взаимодействуя с файловой системой.

**Переносятся ли скрытые слайды в XPS и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) с помощью [настроек экспорта](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что вывод будет содержать именно те страницы, которые вам нужны.