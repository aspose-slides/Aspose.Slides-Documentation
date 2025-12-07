---
title: Конвертировать презентации PowerPoint в XPS на C++
linktitle: PowerPoint в XPS
type: docs
weight: 70
url: /ru/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "Конвертируйте PowerPoint PPT/PPTX в качественный, независимый от платформы XPS на C++ с помощью Aspose.Slides. Получите пошаговое руководство и пример кода."
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Она позволяет печатать содержимое, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать формат Microsoft XPS**

{{% alert color="primary" %}} 
Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете посетить [это бесплатное онлайн‑приложение‑конвертер](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

Если вы хотите сократить расходы на хранение, вы можете преобразовать вашу презентацию Microsoft PowerPoint в формат XPS. Так вам будет проще сохранять, делиться и печатать документы. 

Microsoft продолжает активно поддерживать XPS в Windows (даже в Windows 10), поэтому вам может быть целесообразно сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может стать лучшим вариантом для некоторых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — это стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает более лучшую поддержку файлов XPS, чем поддержка файлов PDF. 
  - **XPS:** Встроенный просмотрщик/чтец XPS и возможность печати в XPS доступны. 
  - **PDF**: Доступен PDF‑чтец, но функции печати в PDF нет. 

-  **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также предоставляют лучшую поддержку файлов XPS, чем PDF. 
  - **XPS**: Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF**: Нет PDF‑чтения. Нет функции печати в PDF. 

|<p>**Ввод PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Вывод XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конце концов реализовала поддержку печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи ожидалось печатать документы через формат XPS. 

## **Конвертация XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) для C++ вы можете использовать метод [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставляемый классом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), чтобы преобразовать всю презентацию в документ XPS. 

При конвертации презентации в XPS необходимо сохранять её, используя один из следующих параметров:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Преобразовать презентацию в XPS с использованием настроек по умолчанию**

Этот пример кода на C++ показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:
``` cpp
// Создать объект Presentation, представляющий файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Сохранение презентации в документ XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Преобразовать презентацию в XPS с пользовательскими настройками**

Этот пример кода показывает, как конвертировать презентацию в документ XPS с пользовательскими настройками на C++:
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

**Могу ли я сохранить XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любой ситуации, когда необходимо передать XPS без обращения к файловой системе.

**Переносятся ли скрытые слайды в XPS и могу ли я их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/cpp/aspose.slides.export.xpsoptions/set_showhiddenslides/) с помощью [настроек экспорта](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что результат будет содержать ровно те страницы, которые вы намерены.