---
title: Настройка шрифтов PowerPoint в PHP
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/php-java/custom-font/
keywords:
- шрифт
- пользовательский шрифт
- внешний шрифт
- загрузка шрифта
- управление шрифтами
- папка шрифтов
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для PHP через Java, чтобы ваши презентации были четкими и согласованными на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без установки их в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа, либо загружать внешние шрифты непосредственно из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять вывод презентации одинаковым в разных средах. В статье также объясняется, как проверить папки шрифтов, используемые Aspose.Slides, и как очистить кеш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от встраивания шрифтов в файл PPTX. Если шрифт необходимо хранить внутри самой презентации, используйте функции встраивания шрифтов явно.

{{% alert color="primary" %}} 
Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Шрифты TrueType (.ttf) и TrueType Collection (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например в PDF, изображения и другие поддерживаемые форматы — так что полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) для загрузки шрифтов из этих папок.  
3. Загрузите и отрендерите/экспортируйте презентацию.  
4. Вызовите [FontsLoader::clearCache](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#clearCache--) для очистки кеша шрифтов.

Следующий код демонстрирует процесс загрузки шрифтов:

```php
// Определите папки, содержащие пользовательские файлы шрифтов.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Выполните рендеринг/экспорт презентации (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Очистите кеш шрифтов после завершения работы.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) добавляет дополнительные папки в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов.  
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам операционной системы по умолчанию.  
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/).  
{{%/alert %}}

## **Получение пользовательских папок шрифтов**

Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#getFontFolders--) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Этот PHP‑код показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Эта строка выводит папки, в которых ищутся файлы шрифтов.
# Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
$fontFolders = FontsLoader::getFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет метод [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться с презентацией.

Этот PHP‑код показывает, как использовать метод [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

{{7e3f5bdb-1ca4-4879-a58e-3b9f4f97f4