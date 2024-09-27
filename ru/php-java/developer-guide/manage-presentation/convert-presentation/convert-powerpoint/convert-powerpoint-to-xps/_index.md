---
title: Конвертация PowerPoint в XPS
type: docs
weight: 70
url: /ru/php-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX в XPS"
description: "Конвертация PowerPoint PPT(X) в XPS "
---

## **О XPS**
Microsoft разработала [XPS](https://docs.fileformat.com/page-description-language/xps/) в качестве альтернативы [PDF](https://docs.fileformat.com/pdf/). Он позволяет печатать содержимое, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Макет или структура XPS-файла остаются одинаковыми на всех операционных системах и принтерах.

## Когда использовать формат Microsoft XPS

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides конвертирует презентацию PPT или PPTX в формат XPS, вы можете ознакомиться с [этим бесплатным онлайн конвертером](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите сократить расходы на хранение, вы можете конвертировать свою презентацию Microsoft PowerPoint в формат XPS. Таким образом, вам будет проще сохранять, делиться и печатать ваши документы.

Microsoft продолжает внедрять мощную поддержку XPS в Windows (даже в Windows 10), поэтому вам может быть полезно сохранить файлы в этом формате. Если вы используете Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может быть вашим лучшим вариантом для определенных операций.

- **Windows 8** использует формат OXPS (Open XPS) для XPS-файлов. OXPS является стандартизированной версией оригинального формата XPS. Windows 8 предлагает лучшую поддержку XPS-файлов, чем PDF-файлов.
  - **XPS:** Доступен встроенный просмотрщик/ридер XPS и функция печати в XPS. 
  - **PDF**: Доступен PDF ридер, но нет функции печати в PDF. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также обеспечивают лучшую поддержку XPS-файлов, чем PDF-файлов.
  - **XPS**: Доступен встроенный просмотрщик XPS и функция печати в XPS.
  - **PDF**: Нет PDF ридера. Нет функции печати в PDF.

|<p>**Вход PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выход XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft в конце концов внедрила поддержку операций печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователям предлагалось печатать документы через формат XPS.

## Конвертация XPS с помощью Aspose.Slides

В [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) для Java вы можете использовать метод [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), предоставленный классом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), для конвертации всей презентации в документ XPS.

При конвертации презентации в XPS вы должны сохранить презентацию, используя один из этих параметров:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **Конвертация презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода показывает, как конвертировать презентацию в документ XPS, используя стандартные настройки:

```php
  # Создайте объект Presentation, представляющий файл презентации
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Сохранение презентации в документ XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Конвертация презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как конвертировать презентацию в документ XPS с использованием пользовательских настроек:

```php
  # Создайте объект Presentation, представляющий файл презентации
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Создайте класс TiffOptions
    $options = new XpsOptions();
    # Сохранить метафайлы в формате PNG
    $options->setSaveMetafilesAsPng(true);
    # Сохраните презентацию в документ XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```