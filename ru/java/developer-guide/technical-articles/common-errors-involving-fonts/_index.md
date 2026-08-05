---
title: "Общие исключения и ошибки, связанные со шрифтами в Linux"
type: docs
weight: 200
url: /ru/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Исключение шрифта, Ошибка шрифта, Linux, Java, Aspose.Slides для Java"
description: "Исключения и ошибки шрифтов в Linux"
---
## **Обзор**

При использовании Aspose.Slides на Linux могут возникать проблемы, связанные со шрифтами, если процесс Java не может получить доступ к необходимым папкам со шрифтами или временному каталогу, если на системе не установлено ни одного шрифта, либо если отсутствуют необходимые системные библиотеки, такие как fontconfig или libfreetype.

В этой статье описываются распространённые ошибки и исключения, связанные со шрифтами в Linux, а также предлагаются решения их устранения. Она объясняет, как проверить доступ к каталогам с шрифтами и TEMP, установить необходимые шрифты и библиотеки, и использовать `FontsLoader` для загрузки шрифтов без их установки в системе.

## **Отсутствие текста или изображений (EMF или WMF) при выполнении кода на Linux**

Эта проблема возникает в системах с ограничениями в следующих случаях:

1. При отсутствии установленных шрифтов или недоступности папки со шрифтами для процесса Java  
2. При недоступности каталога TEMP.

### **Решение**

Проверьте и подтвердите, что доступ к каталогу TEMP и папке со шрифтами предоставлен.  

{{% alert color="warning" %}}
В некоторых случаях вы не сможете предоставить доступ к папкам из‑за ограничений среды или политики безопасности. Попробуйте следующие обходные пути:
{{% /alert %}}

**Обходной путь**

Используйте [FontsLoader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsLoader) для загрузки необходимых шрифтов без их установки:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Если каталог TEMP недоступен, используйте следующий код, чтобы указать другой каталог как TEMP для Java:
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

1) процесс Java не может получить доступ к папке со шрифтами  
2) шрифты не установлены.

### **Решение**

1. Проверьте и подтвердите, что доступ к папке со шрифтами для процесса Java предоставлен.  

2. Установите несколько шрифтов или используйте [FontsLoader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsLoader).  

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

   * С помощью [FontsLoader](https://reference.aspose.com/slides/ru/java/com.aspose.slides/FontsLoader):  

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Исключение: NoClassDefFoundError: Не удалось инициализировать класс com.aspose.slides.internal.ey.this**

Это исключение возникает в системе Linux, где отсутствуют fontconfig и шрифты.

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

## **Исключение: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

Это исключение возникает в системе Linux, где отсутствует библиотека libfreetype.

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

{{% alert title="TIP" color="primary" %}} 
Не забывайте устанавливать шрифты или использовать FontsLoader. 
{{% /alert %}}