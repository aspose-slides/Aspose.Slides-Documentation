---
title: Общие исключения и ошибки, связанные с шрифтами в Linux
type: docs
weight: 200
url: /java/technical-articles/common-errors-involving-fonts
keywords: "Исключение шрифта, Ошибка шрифта, Linux, Java, Aspose.Slides для Java"
description: "Исключения и ошибки шрифтов в Linux"
---

## **Отсутствие текста или изображений (emf или wmf) при выполнении кода в Linux**

Эта проблема возникает в системах с ограничениями в следующих случаях:

1. Когда шрифты не установлены или когда папка шрифтов для процесса Java недоступна.
2. Когда директория TEMP недоступна.

### Решение

Проверьте и подтвердите, что доступ к директории TEMP и папке шрифтов предоставлен.

{{% alert color="warning" %}}

В некоторых случаях вы можете не иметь возможности предоставить доступ к папкам из-за ограничений, наложенных средой или политикой безопасности. Попробуйте следующие обходные пути:

{{% /alert %}}

**Обходной путь**

Используйте [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) для загрузки необходимых шрифтов без их установки:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Если директория TEMP недоступна, используйте этот код для указания другой директории в качестве TEMP для Java:
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
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Исключение: InvalidOperationException: Не удается найти установленные на системе шрифты**

Это исключение возникает, когда

1) процесс Java не может получить доступ к папке шрифтов.
2) шрифты не установлены.

### Решение

1. Проверьте и подтвердите, что доступ к папке шрифтов для процесса Java предоставлен.

2. Установите несколько шрифтов или используйте [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

3. Установите шрифты.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
     ```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * Используя [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Исключение: NoClassDefFoundError: Не удалось инициализировать класс com.aspose.slides.internal.ey.this**

Это исключение возникает на системе Linux, в которой отсутствуют fontconfig и шрифты.

### Решение:

Установите fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

Кроме того, некоторые версии open-jdk (например, **alpine JDK**) также **требуют установленные шрифты**.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Исключение: UnsatisfiedLinkError: libfreetype.so.6: невозможно открыть общий файл объекта: Нет такого файла или каталога**

Это исключение возникает на системе Linux, в которой отсутствует библиотека libfreetype.

### Решение:

Установите libfreetype и fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="СОВЕТ" color="primary" %}} 

Не забудьте установить шрифты или использовать FontsLoader.

{{% /alert %}}  