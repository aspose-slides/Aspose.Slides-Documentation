---
title: Конвертация презентаций PowerPoint в XPS с помощью Python
linktitle: PowerPoint в XPS
type: docs
weight: 70
url: /ru/python-net/convert-powerpoint-to-xps/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в XPS
- презентацию в XPS
- PPT в XPS
- PPTX в XPS
- PowerPoint
- презентацию
- Python
- Aspose.Slides
description: "Конвертируйте PowerPoint PPT/PPTX в высококачественный, независимый от платформы XPS с помощью Python и Aspose.Slides. Получите пошаговое руководство и пример кода."
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## Когда использовать формат Microsoft XPS

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн‑приложение конвертера](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите снизить затраты на хранение, вы можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет проще сохранять, делиться и печатать свои документы. 

Microsoft продолжает активно поддерживать XPS в Windows (даже в Windows 10), поэтому вам стоит рассмотреть возможность сохранения файлов в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, XPS может быть лучшим выбором для некоторых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — это стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/чтение XPS и возможность печати в XPS доступны. 
  - **PDF:** Доступен PDF‑чтение, но функция печати в PDF отсутствует. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также предоставляют лучшую поддержку файлов XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF:** Нет PDF‑чтения. Нет функции печати в PDF. 

|<p>**Ввод PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Вывод XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге реализовала поддержку печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи должны были печатать документы через формат XPS. 

## Конвертация XPS с помощью Aspose.Slides

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) для .NET вы можете использовать метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), предоставляемый классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), чтобы преобразовать всю презентацию в документ XPS.

При конвертации презентации в XPS вам нужно сохранять презентацию, используя одну из следующих настроек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **Конвертация презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода на Python демонстрирует, как конвертировать презентацию в документ XPS, используя стандартные настройки:

```py
import aspose.slides as slides

# Создать объект Presentation, представляющий файл презентации
pres = slides.Presentation("Convert_XPS.pptx")

# Сохранение презентации в документ XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Конвертация презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки в Python:

```py
import aspose.slides as slides

# Создать объект Presentation, представляющий файл презентации
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Создать объект класса XpsOptions
options = slides.export.XpsOptions()

# Сохранить MetaFiles в формате PNG
options.save_metafiles_as_png = True

# Сохранить презентацию в документ XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **Часто задаваемые вопросы**

**Можно ли сохранять XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любого сценария, когда нужно передать XPS без обращения к файловой системе.

**Переносятся ли скрытые слайды в XPS и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) с помощью [настроек экспорта](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что результат содержит именно те страницы, которые вам нужны.