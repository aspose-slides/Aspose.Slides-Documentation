---
title: Общие исключения и ошибки, связанные с шрифтами в Linux
type: docs
weight: 200
url: /php-java/technical-articles/common-errors-involving-fonts
keywords: "Исключение шрифта, Ошибка шрифта, Linux, Java, Aspose.Slides для PHP через Java"
description: "Исключения и ошибки шрифтов в Linux"
---

## **Недостающий текст или изображения (emf или wmf) при выполнении кода в Linux**

Эта проблема возникает в системах с ограничениями в следующих случаях:

1. Когда шрифты не установлены или когда папка со шрифтами для процесса Java недоступна
2. Когда папка TEMP недоступна.

### Решение

Проверьте и подтвердите, что доступ к папке TEMP и папке со шрифтами был предоставлен. 

{{% alert color="warning" %}}

В некоторых случаях вы можете не иметь возможности предоставить доступ к папкам из-за ограничений, наложенных окружением или политикой безопасности. Попробуйте эти обходные пути: 

{{% /alert %}}

**Обходной путь**

Используйте [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader), чтобы загрузить необходимые шрифты без их установки:

```php

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

```

Если к папке TEMP нет доступа, используйте этот код, чтобы указать другую папку в качестве TEMP для Java:
```php

```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    # ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```php

```

## **Исключение: InvalidOperationException: Не удается найти установленные на системе шрифты**

Это исключение возникает, когда

1) процесс Java не может получить доступ к папке со шрифтами
2) шрифты не установлены.

### Решение

1. Проверьте и подтвердите, что доступ к папке со шрифтами для процесса Java был предоставлен.

2. Установите несколько шрифтов или используйте [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

3. Установите шрифты.

   * Ubuntu: 

```php

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```php

     ```

   * CentOS: 

```php

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```php

     ```

   * Используя [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader):

```php

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

     ```

## **Исключение: NoClassDefFoundError: Не удалось инициализировать класс com.aspose.slides.internal.ey.this**

Это исключение возникает в системе Linux, где отсутствуют fontconfig и шрифты. 

### Решение:

Установите fontconfig:

* Ubuntu:

```php

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS:

```php

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
```php

  ```

Кроме того, некоторые версии open-jdk (например, **alpine JDK**) также **требуют установленных шрифтов**.

* Ubuntu:

```php

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```php

  ```

* CentOS:

```php

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
```php

  ```

## **Исключение: UnsatisfiedLinkError: libfreetype.so.6: не удается открыть общий объектный файл: Нет такого файла или каталога**

Это исключение возникает в системе Linux, где отсутствует библиотека libfreetype. 

### Решение:

Установите libfreetype и fontconfig:

* Ubuntu: 

```php

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS: 

```php

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
```php

  ```

{{% alert title="СОВЕТ" color="primary" %}} 

Не забудьте установить шрифты или использовать FontsLoader.

{{% /alert %}}  