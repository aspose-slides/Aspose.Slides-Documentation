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
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для PHP через Java, чтобы ваши презентации выглядели чётко и одинаково на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без установки их в операционной системе. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа или загружать внешние шрифты напрямую из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять вывод презентации единообразным в разных средах. Статья также объясняет, как просматривать папки шрифтов, используемые Aspose.Slides, и как очистить кэш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от внедрения шрифтов в файл PPTX. Если шрифт должен быть сохранён внутри самой презентации, используйте функции внедрения шрифтов явно.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем письма. Эти сопоставления хранят имена шрифтов, но не устанавливают и не загружают файлы шрифтов. См. [Script‑Specific Theme Fonts](/slides/ru/php-java/script-specific-font-mappings/) для управления сопоставлениями и используйте варианты загрузки ниже, чтобы сделать указанные шрифты доступными для согласованного рендеринга.

{{% alert color="info" title="Примечание" %}}

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. Смотрите [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) шрифты. Смотрите [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загрузить шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — поэтому полученные документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) для загрузки шрифтов из этих папок.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader::clearCache](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#clearCache--) для очистки кэша шрифтов.

Ниже приведён пример кода, демонстрирующий процесс загрузки шрифтов:

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
    
    // Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Очистите кэш шрифтов после завершения работы.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Примечание" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Получение пользовательских папок шрифтов**

Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#getFontFolders--) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Этот PHP‑код показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Эта строка выводит папки, где ищутся файлы шрифтов.
# Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
$fontFolders = FontsLoader::getFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет метод [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться с презентацией.

Этот PHP‑код показывает, как использовать метод [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Работа с презентацией
    # Шрифты CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts, а также их подпапки доступны презентации
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Управление шрифтами внешне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/ru/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

Этот PHP‑код демонстрирует процесс загрузки шрифта из массива байтов:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        #        внешний шрифт загружен в течение жизни презентации
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

### Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

### Автоматически ли пользовательские шрифты внедряются в получающийся PPTX?

Нет. Регистрация шрифта для рендеринга не то же самое, что его внедрение в PPTX. Если нужен шрифт внутри файла презентации, необходимо воспользоваться явными [возможностями внедрения](/slides/ru/php-java/embedded-font/).

### Можно ли контролировать поведение резервирования, когда у пользовательского шрифта отсутствуют некоторые глифы?

Да. Настройте [font substitution](/slides/ru/php-java/font-substitution/), [replacement rules](/slides/ru/php-java/font-replacement/) и [fallback sets](/slides/ru/php-java/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии запрашиваемого глифа.

### Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?

Да. Укажите свои папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет зависимость от системных каталогов шрифтов в образе контейнера.

### Что насчёт лицензий — могу ли я внедрять любой пользовательский шрифт без ограничений?

Вы отвечаете за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают внедрение или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.