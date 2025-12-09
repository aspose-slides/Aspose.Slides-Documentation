---
title: Конвертировать презентации PowerPoint в XPS на Python
linktitle: PowerPoint в XPS
type: docs
weight: 70
url: /ru/python-net/convert-powerpoint-to-xps/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- PowerPoint в XPS
- презентация в XPS
- PPT в XPS
- PPTX в XPS
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Конвертировать PowerPoint PPT/PPTX в высококачественный, независимый от платформы XPS на Python с помощью Aspose.Slides. Получите пошаговое руководство и пример кода."
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Это позволяет печатать содержимое, выводя файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах.

## Когда использовать формат Microsoft XPS

{{% alert color="primary" %}} 
Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете посмотреть [это бесплатное онлайн‑приложение‑конвертер](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

Если вы хотите сократить затраты на хранение, вы можете преобразовать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет проще сохранять, делиться и печатать документы.

Microsoft продолжает активно поддерживать XPS в Windows (даже в Windows 10), поэтому вам может быть полезно сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может быть вашим лучшим вариантом для некоторых операций.

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — это стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF.  
  - **XPS:** Встроенный просмотрщик/читалка XPS и возможность печати в XPS доступны.  
  - **PDF:** Доступен просмотрщик PDF, но функция печати в PDF отсутствует.  

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку файлов XPS, чем PDF.  
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны.  
  - **PDF:** Нет просмотрщика PDF. Нет функции печати в PDF.  

|<p>**Вход PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выход XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конечном итоге реализовала поддержку печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи должны были печатать документы через формат XPS.

## Конвертация XPS с помощью Aspose.Slides

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) для .NET вы можете использовать метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), предоставляемый классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), чтобы преобразовать всю презентацию в документ XPS.

При конвертации презентации в XPS вам необходимо сохранять презентацию, используя одну из следующих настроек:
- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **Преобразование презентаций в XPS с использованием настроек по умолчанию**
Этот пример кода на Python показывает, как преобразовать презентацию в документ XPS, используя стандартные настройки:
```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации
pres = slides.Presentation("Convert_XPS.pptx")

# Сохранение презентации в документ XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Преобразование презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как преобразовать презентацию в документ XPS, используя пользовательские настройки в Python:
```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Создайте объект класса TiffOptions
options = slides.export.XpsOptions()

# Сохранить метафайлы как PNG
options.save_metafiles_as_png = True

# Сохранить презентацию в документ XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```


## **Часто задаваемые вопросы**

**Могу ли я сохранять XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально для веб‑API, серверных конвейеров или любого сценария, когда необходимо передать XPS, не взаимодействуя с файловой системой.

**Переносятся ли скрытые слайды в XPS, и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включить или исключить скрытые слайды](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) через [настройки экспорта](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) перед сохранением в XPS, гарантируя, что вывод содержит именно те страницы, которые вы планируете.