---
title: Конвертация PowerPoint в XPS 
type: docs
weight: 70
url: /python-net/convert-powerpoint-to-xps
keywords: "Конвертация презентации PowerPoint, PowerPoint в XPS, PPT в XPS, PPTX в XPS, Конверсия, Python, Aspose.Slides"
description: "Конвертируйте презентацию PowerPoint в XPS на Python."
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) как альтернативу [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать контент, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура файла XPS остается одинаковой на всех операционных системах и принтерах. 

## Когда использовать формат Microsoft XPS

{{% alert color="primary" %}} 

Чтобы узнать, как Aspose.Slides конвертирует презентацию PPT или PPTX в формат XPS, вы можете проверить [это бесплатное онлайн-приложение для конвертации](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить расходы на хранение, вы можете конвертировать вашу презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет проще сохранять, делиться и печатать ваши документы. 

Microsoft продолжает внедрять надежную поддержку XPS в Windows (даже в Windows 10), поэтому стоит рассмотреть возможность сохранения файлов в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может быть вашим лучшим вариантом для определенных операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS является стандартизированной версией оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/читалка XPS и функция печати в XPS доступны. 
  - **PDF**: Доступен просмотрщик PDF, но функции печати в PDF нет. 

-  **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS**: Встроенный просмотрщик XPS и функция печати в XPS доступны. 
  - **PDF**: Нет просмотрщика PDF. Нет функции печати в PDF. 

|<p>**Входящий PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходящий XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



В конечном итоге Microsoft реализовала поддержку операций печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи должны были печатать документы через формат XPS. 

## Конверсия XPS с помощью Aspose.Slides

В [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) для .NET вы можете использовать метод [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) для конвертации всей презентации в документ XPS. 

При конвертации презентации в XPS вам необходимо сохранить презентацию, используя любые из этих настроек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **Конвертация презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода на Python показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:

```py
import aspose.slides as slides

# Создание объекта Presentation, представляющего файл презентации
pres = slides.Presentation("Convert_XPS.pptx")

# Сохранение презентации в документ XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Конвертация презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя пользовательские настройки на Python:

```py
import aspose.slides as slides

# Создание объекта Presentation, представляющего файл презентации
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Создание класса TiffOptions
options = slides.export.XpsOptions()

# Сохранить метафайлы в формате PNG
options.save_metafiles_as_png = True

# Сохранение презентации в документ XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```