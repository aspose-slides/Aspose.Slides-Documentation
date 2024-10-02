---
title: Конвертация PowerPoint в XPS
type: docs
weight: 70
url: /ru/cpp/convert-powerpoint-to-xps
keywords: "Конвертировать, PowerPoint в XPS, Конверсия, PPT в XPS, PPTX в XPS"
description: "Конвертируйте документы PowerPoint PPT, PPTX в XPS с помощью API Aspose.Slides."
---

## **Что такое XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура XPS-файла остаются неизменными на всех операционных системах и принтерах.

## Когда следует использовать формат Microsoft XPS

{{% alert color="primary" %}}

Чтобы увидеть, как Aspose.Slides конвертирует презентации PPT или PPTX в формат XPS, вы можете ознакомиться с [этим бесплатным онлайн-конвертером](https://products.aspose.app/slides/conversion).

{{% /alert %}}

Если вы хотите сократить расходы на хранение, вы можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет удобнее сохранять, делиться и печатать ваши документы.

Microsoft продолжает реализовывать сильную поддержку XPS в Windows (даже в Windows 10), поэтому вы можете рассмотреть возможность сохранения файлов в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может быть наилучшим вариантом для определенных операций.

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — это стандартизированная версия оригинального формата XPS. Windows 8 предлагает лучшую поддержку файлов XPS, чем файлов PDF.
  - **XPS:** Доступен встроенный просмотрщик/читалка XPS и функция печати в XPS.
  - **PDF**: Доступен читалка PDF, но функция печати в PDF отсутствует.

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку файлов XPS, чем PDF.
  - **XPS**: Доступен встроенный просмотрщик XPS и функция печати в XPS.
  - **PDF**: Нет читалки PDF. Нет функции печати в PDF.

|<p>**Входные PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходные XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

В конечном итоге Microsoft реализовала поддержку операций печати в PDF через функцию Печать в PDF в Windows 10. Ранее от пользователей ожидалось, что они будут печатать документы через формат XPS.

## Конвертация XPS с помощью Aspose.Slides

В [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) для C++ вы можете использовать метод [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e), предоставленный классом [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), для конвертации всей презентации в документ XPS.

При конвертации презентации в XPS, вы должны сохранить презентацию с использованием одной из этих настроек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Конвертирование презентаций в XPS с использованием настроек по умолчанию**

Этот образец кода на C++ показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:

``` cpp
// Создаем объект Presentation, представляющий файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Сохраняем презентацию в XPS-документ
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Конвертирование презентаций в XPS с использованием пользовательских настроек**
Этот образец кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки на C++:

``` cpp
// Создаем объект Presentation, представляющий файл презентации
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Создаем объект класса TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Сохраняем метафайлы как PNG
options->set_SaveMetafilesAsPng(true);

// Сохраняем презентацию в XPS-документ
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```