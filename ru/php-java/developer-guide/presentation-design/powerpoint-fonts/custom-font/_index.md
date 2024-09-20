---
title: Пользовательский шрифт PowerPoint
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /php-java/custom-font/
keywords: "Шрифты, пользовательские шрифты, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Пользовательские шрифты PowerPoint"
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, которые отображаются в презентациях, без необходимости их установки. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) и вызовите метод [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Загрузите презентацию, которая будет отображаться.
3. [Очистите кеш](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) в классе [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

Этот PHP-код демонстрирует процесс загрузки шрифтов:

```php
  # Папки для поиска шрифтов
  $folders = array($externalFontsDir );
  # Загружает шрифты из каталога пользовательского шрифта
  FontsLoader->loadExternalFonts($folders);
  # Выполните некоторые действия и выполните рендеринг презентации/слайда
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

## **Получить папку с пользовательскими шрифтами**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) для поиска папок со шрифтами. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот PHP-код показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
  # Эта строка выводит папки, в которых ищутся файлы шрифтов.
  # Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
  $fontFolders = FontsLoader->getFontFolders();

```

## **Указать пользовательские шрифты, используемые с презентацией**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться с презентацией.

Этот PHP-код показывает, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) :

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
    # CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts и их подпапок доступны для презентации
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

Этот PHP-код демонстрирует процесс загрузки шрифтов из массива байтов:

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
      # внешний шрифт загружен в течение времени жизни презентации
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```