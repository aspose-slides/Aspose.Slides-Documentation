---
title: "Настройка шрифтов PowerPoint в PHP"
linktitle: "Пользовательский шрифт"
type: docs
weight: 20
url: /ru/php-java/custom-font/
keywords:
  - "шрифт"
  - "пользовательский шрифт"
  - "внешний шрифт"
  - "загрузка шрифта"
  - "управление шрифтами"
  - "папка шрифтов"
  - "PowerPoint"
  - "OpenDocument"
  - "презентация"
  - "PHP"
  - "Aspose.Slides"
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для PHP через Java, чтобы ваши презентации были чёткими и одинаковыми на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — так что получающиеся документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из этих папок.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader::clearCache](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/clearcache/) для очистки кеша шрифтов.

Следующий пример кода демонстрирует процесс загрузки шрифтов:
```php
// Определите папки, содержащие пользовательские файлы шрифтов.
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentation = new Presentation("sample.pptx");
    
    // Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    $presentation->save("output.pdf", SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Очистите кэш шрифтов после завершения работы.
    FontsLoader::clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не меняет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь шрифтов операционной системы по умолчанию.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Получить пользовательские папки шрифтов**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) для поиска папок с шрифтами. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот PHP‑код показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):
```php
  # Эта строка выводит папки, в которых ищутся файлы шрифтов.
  # Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
  $fontFolders = FontsLoader->getFontFolders();

```


## **Указание пользовательских шрифтов, используемых в презентации**
Aspose.Slides предоставляет метод [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDocumentLevelFontSources) для указания внешних шрифтов, которые будут использоваться с презентацией.

Этот PHP‑код показывает, как использовать метод [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDocumentLevelFontSources):
```php
  $Array = new JavaClass("java.lang.reflect.Array");
  $Byte = new JavaClass("java.lang.Byte");
  $file1 = new Java("java.io.File", "customfonts/CustomFont1.ttf");
  $memoryFont1 = $Array->newInstance($Byte, $Array->getLength($file1));
  try {
      $dis1 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file1));
      $dis1->readFully($memoryFont1);
  } finally {
      if (!java_is_null($dis1)) $dis1->close();
  }
  $file2 = new Java("java.io.File", "customfonts/CustomFont2.ttf");
  $memoryFont2 = $Array->newInstance($Byte, $Array->getLength($file2));
  try {
        $dis2 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file2));
        $dis2->readFully($memoryFont2);
  } finally {
        if (!java_is_null($dis2)) $dis2->close();
  }
  $loadOptions = new LoadOptions();
  $loadOptions->getDocumentLevelFontSources()->setFontFolders(array("assets/fonts", "global/fonts" ));
  $loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));
  $pres = new Presentation("MyPresentation.pptx", $loadOptions);
  try {
    # Работа с презентацией
    # CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts, а также их подпапок доступны в презентации
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

Этот PHP‑код демонстрирует процесс загрузки шрифта из массива байтов:
```php
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALN.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNBI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

  try {
    $pres = new Presentation("");
    try {
      # внешний шрифт загружен в течение жизни презентации
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **FAQ**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в полученный PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если нужен шрифт внутри файла презентации, необходимо использовать явные [возможности встраивания](/slides/ru/php-java/embedded-font/).

**Можно ли управлять поведением fallback, когда у пользовательского шрифта отсутствуют некоторые глифы?**

Да. Настройте [замену шрифтов](/slides/ru/php-java/font-substitution/), [правила замены](/slides/ru/php-java/font-replacement/) и [наборы fallback](/slides/ru/php-java/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии запрашиваемого глифа.

**Можно ли использовать шрифты в Linux/Docker‑контейнерах без их установки в системе?**

Да. Укажите свои папки со шрифтами или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**А как насчёт лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы отвечаете за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.