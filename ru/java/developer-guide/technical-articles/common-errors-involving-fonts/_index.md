---
title: "Общие исключения и ошибки, связанные со шрифтами в Linux"
type: docs
weight: 200
url: /ru/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Исключения шрифтов, Ошибки шрифтов, Linux, Java, Aspose.Slides for Java"
description: "Исключения и ошибки шрифтов в Linux"
---
## **Обзор**

При использовании Aspose.Slides в Linux могут возникать проблемы, связанные со шрифтами, если процесс Java не может получить доступ к требуемым папкам шрифтов или временной директории, если в системе не установлены шрифты, или если отсутствуют необходимые системные библиотеки, такие как fontconfig или libfreetype.

В этой статье описаны распространённые ошибки и исключения, связанные со шрифтами в Linux, а также предоставлены решения по их устранению. В ней объясняется, как проверить доступ к каталогам шрифтов и TEMP, установить необходимые шрифты и библиотеки и использовать `FontsLoader` для загрузки шрифтов без их установки в систему.

## **Отсутствие текста или изображений (EMF или WMF) при выполнении кода в Linux**

Эта проблема возникает в системах с ограничениями в следующих случаях:

1. Когда шрифты не установлены или папка шрифтов для процесса java недоступна
2. Когда директория TEMP недоступна.

### **Решение**

Проверьте и убедитесь, что доступ к директории TEMP и папке шрифтов предоставлен. 

{{% alert color="warning" %}}

В некоторых случаях вы не сможете предоставить доступ к папкам из‑за ограничений, наложенных окружением или политикой безопасности. Попробуйте следующие обходные решения: 

{{% /alert %}}

**Обходной путь**

Используйте [FontsLoader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsLoader) для загрузки требуемых шрифтов без их установки:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Если директория TEMP недоступна, используйте этот код, чтобы указать другую директорию в качестве TEMP для Java:
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

## **Исключение: InvalidOperationException: Не удалось найти установленные в системе шрифты**

Это исключение возникает, когда

1) процесс Java не может получить доступ к папке шрифтов  
2) шрифты не установлены.

### **Решение**

1. Проверьте и убедитесь, что процессу Java предоставлен доступ к папке шрифтов.  

2. Установите некоторые шрифты или используйте [FontsLoader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsLoader).  

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

   * Using [FontsLoader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsLoader):  

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Исключение: InternalError: InvocationTargetException**

При конвертации файла PPTX в PDF в Linux преобразование может завершиться ошибкой `java.lang.InternalError: java.lang.reflect.InvocationTargetException`. Если базовая ошибка гласит `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, конфигурация шрифтов Linux недоступна или её кеш не был инициализирован.

### **Решение**

Установите fontconfig и перестройте кеш шрифтов:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Исключение: NoClassDefFoundError: Не удалось инициализировать класс com.aspose.slides.internal.ey.this**

Это исключение возникает в системе Linux, в которой отсутствуют fontconfig и шрифты. 

### **Решение**

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

Кроме того, некоторые версии open‑jdk (например, **alpine JDK**) также **требуют установленные шрифты**.

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

## **Исключение: UnsatisfiedLinkError: libfreetype.so.6: Не удалось открыть файл shared object: Нет такого файла или каталога**

Это исключение возникает в системе Linux, в которой отсутствует библиотека libfreetype. 

### **Решение**

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

{{% alert title="TIP" color="info" %}} 

Не забудьте установить шрифты или использовать FontsLoader.

{{% /alert %}}