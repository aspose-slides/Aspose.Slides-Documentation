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
description: "Настраивайте шрифты в слайдах PowerPoint с помощью Aspose.Slides для PHP через Java, чтобы ваши презентации были четкими и одинаковыми на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентациях, без необходимости их установки. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) и вызовите метод [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Загрузите презентацию, которая будет отрисована.
3. [Очистите кэш](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) в классе [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

Это PHP‑пример, демонстрирующий процесс загрузки шрифтов:
```php
  # Папки для поиска шрифтов
  $folders = array($externalFontsDir );
  # Загружает шрифты из пользовательского каталога шрифтов
  FontsLoader->loadExternalFonts($folders);
  # Выполняет некоторую работу и рендеринг презентации/слайда
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # Очищает кеш шрифтов
    FontsLoader->clearCache();
  }
```


## **Получить папки пользовательских шрифтов**

Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) , который позволяет находить папки шрифтов. Этот метод возвращает папки, добавленные с помощью метода `LoadExternalFonts`, а также системные папки шрифтов.

Этот PHP‑пример показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):
```php
  # Эта строка выводит папки, где ищутся файлы шрифтов.
  # Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
  $fontFolders = FontsLoader->getFontFolders();

```


## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) , позволяющее указать внешние шрифты, которые будут использоваться в презентации.

Этот PHP‑пример показывает, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
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
    # CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts и их подпапок доступны для презентации
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Управление шрифтами внешне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), который позволяет загружать внешние шрифты из бинарных данных.

Этот PHP‑пример демонстрирует процесс загрузки шрифта из массива байтов:
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
      # внешний шрифт, загруженный во время жизни презентации
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **FAQ**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключенные шрифты используются рендерером во всех форматах экспорта.

**Автоматически ли пользовательские шрифты встраиваются в полученный PPTX?**

Нет. Регистрация шрифта для рендеринга не является встраиванием его в PPTX. Если необходимо, чтобы шрифт был включён в файл презентации, следует использовать явные [возможности встраивания](/slides/ru/php-java/embedded-font/).

**Можно ли контролировать поведение резервирования, если у пользовательского шрифта отсутствуют некоторые глифы?**

Да. Настройте [замену шрифтов](/slides/ru/php-java/font-substitution/), [правила замены](/slides/ru/php-java/font-replacement/) и [наборы резервных шрифтов](/slides/ru/php-java/fallback-font/), чтобы точно определить, какой шрифт использовать, когда запрашиваемый глиф отсутствует.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их системной установки?**

Да. Укажите свои папки со шрифтами или загрузите шрифты из массивов байтов. Это устраняет любую зависимость от системных директорий шрифтов в образе контейнера.

**Что насчёт лицензирования — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте пользовательское соглашение (EULA) шрифта перед распространением результатов.
