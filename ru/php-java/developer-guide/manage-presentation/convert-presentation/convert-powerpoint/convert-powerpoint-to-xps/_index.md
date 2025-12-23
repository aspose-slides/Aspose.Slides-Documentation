---
title: Конвертация презентаций PowerPoint в XPS на PHP
linktitle: PowerPoint в XPS
type: docs
weight: 70
url: /ru/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "Преобразуйте PowerPoint PPT/PPTX в высококачественный, независимый от платформы XPS с помощью Aspose.Slides для PHP через Java. Получите пошаговое руководство и пример кода."
---

## **О XPS**
Microsoft разработала XPS как альтернативу PDF. Он позволяет печатать содержимое, создавая файл, очень похожий на PDF. Формат XPS основан на XML. Разметка или структура файла XPS остаются одинаковыми на всех операционных системах и принтерах. 

## **Когда использовать Microsoft XPS Format**

{{% alert color="primary" %}} 

Чтобы увидеть, как Aspose.Slides преобразует презентацию PPT или PPTX в формат XPS, вы можете ознакомиться с [этим бесплатным онлайн конвертером](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Если вы хотите снизить расходы на хранение, вы можете преобразовать свою презентацию Microsoft PowerPoint в формат XPS. Таким образом, сохранение, совместное использование и печать документов станут проще. 

Microsoft продолжает активно поддерживать XPS в Windows (даже в Windows 10), поэтому вам может быть полезно сохранять файлы в этом формате. Если вы работаете с Windows 8.1, Windows 8, Windows 7 и Windows Vista, то XPS может стать лучшим вариантом для определённых операций. 

- **Windows 8** использует формат OXPS (Open XPS) для файлов XPS. OXPS — стандартизированная версия оригинального формата XPS. Windows 8 обеспечивает лучшую поддержку файлов XPS, чем файлов PDF. 
  - **XPS:** Встроенный просмотрщик/читалка XPS и возможность печати в XPS доступны. 
  - **PDF:** Читалка PDF доступна, но функции печати в PDF нет. 

- **Windows 7 и Windows Vista** используют оригинальный формат XPS. Эти операционные системы также предоставляют лучшую поддержку файлов XPS, чем PDF. 
  - **XPS:** Встроенный просмотрщик XPS и возможность печати в XPS доступны. 
  - **PDF:** Читалка PDF отсутствует. Функция печати в PDF отсутствует. 

|<p>**Входной PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Выходной XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

В конце концов Microsoft реализовала поддержку печати в PDF через функцию Печать в PDF в Windows 10. Ранее пользователи должны были печатать документы через формат XPS. 

## **Конвертация XPS с помощью Aspose.Slides**

В [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) для Java вы можете использовать метод [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-), предоставляемый классом [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation), чтобы преобразовать всю презентацию в документ XPS.

При конвертации презентации в XPS необходимо сохранять презентацию, используя одну из следующих настроек:

- Настройки по умолчанию (без [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- Пользовательские настройки (с [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **Преобразование презентаций в XPS с использованием настроек по умолчанию**

Этот пример кода показывает, как преобразовать презентацию в документ XPS, используя стандартные настройки:
```php
  # Создать объект Presentation, который представляет файл презентации
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Сохранение презентации в XPS документ
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Преобразование презентаций в XPS с использованием пользовательских настроек**
Этот пример кода показывает, как преобразовать презентацию в документ XPS, используя пользовательские настройки:
```php
  # Создать объект Presentation, который представляет файл презентации
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Создать объект класса TiffOptions
    $options = new XpsOptions();
    # Сохранить MetaFiles как PNG
    $options->setSaveMetafilesAsPng(true);
    # Сохранить презентацию в документ XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Часто задаваемые вопросы**

**Можно ли сохранять XPS в поток вместо файла?**

Да — Aspose.Slides позволяет экспортировать напрямую в поток, что идеально подходит для веб‑API, серверных конвейеров или любой ситуации, когда требуется передать XPS, не взаимодействуя с файловой системой.

**Переносятся ли скрытые слайды в XPS, и можно ли их исключить?**

По умолчанию рендерятся только обычные (видимые) слайды. Вы можете [включать или исключать скрытые слайды](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) с помощью [настроек экспорта](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/) перед сохранением в XPS, гарантируя, что вывод будет содержать именно те страницы, которые вы планировали.