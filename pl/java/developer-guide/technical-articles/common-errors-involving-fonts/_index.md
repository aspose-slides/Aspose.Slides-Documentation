---
title: Typowe wyjątki i błędy związane z czcionkami w systemie Linux
type: docs
weight: 200
url: /pl/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Wyjątek czcionki, Błąd czcionki, Linux, Java, Aspose.Slides for Java"
description: "Wyjątki i błędy czcionek w systemie Linux"
---
## **Przegląd**

Gdy Aspose.Slides jest używany w systemie Linux, mogą wystąpić problemy związane z czcionkami, jeśli proces Java nie ma dostępu do wymaganych folderów czcionek lub katalogu tymczasowego, jeśli w systemie nie zainstalowano żadnych czcionek lub brakuje wymaganych bibliotek systemowych, takich jak fontconfig lub libfreetype.

Ten artykuł opisuje typowe błędy i wyjątki związane z czcionkami w systemie Linux oraz dostarcza rozwiązania ich usunięcia. Wyjaśnia, jak sprawdzić dostęp do katalogów czcionek i TEMP, jak zainstalować wymagane czcionki i biblioteki oraz jak używać `FontsLoader` do ładowania czcionek bez ich instalacji w całym systemie.

## **Brak tekstu lub obrazów (EMF lub WMF) podczas wykonywania kodu w systemie Linux**

Problem ten występuje w systemach z ograniczeniami w następujących przypadkach:

1. Gdy nie zainstalowano żadnych czcionek lub gdy folder czcionek dla procesu java nie jest dostępny
2. Gdy katalog TEMP nie jest dostępny.

### **Rozwiązanie**

Sprawdź i potwierdź, że przyznano dostęp do katalogu TEMP oraz folderu czcionek. 

{{% alert color="warning" %}}
W niektórych przypadkach możesz nie być w stanie przyznać dostępu do folderów ze względu na ograniczenia narzucone przez środowisko lub politykę bezpieczeństwa. Wypróbuj następujące obejścia: 
{{% /alert %}}

**Obejście**

Użyj [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsLoader), aby załadować wymagane czcionki bez ich instalacji:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Jeśli katalog TEMP nie jest dostępny, użyj tego kodu, aby określić inny katalog jako TEMP dla Javy:
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

## **Wyjątek: InvalidOperationException: Nie można znaleźć żadnych czcionek zainstalowanych w systemie**

Ten wyjątek występuje, gdy

1) proces Java nie ma dostępu do folderu czcionek
2) nie zainstalowano żadnych czcionek.

### **Rozwiązanie**

1. Sprawdź i potwierdź, że przyznano dostęp do folderu czcionek dla procesu Java.
2. Zainstaluj niektóre czcionki lub użyj [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsLoader).
3. Zainstaluj czcionki.

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

   * Using [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Wyjątek: NoClassDefFoundError: Nie można zainicjować klasy com.aspose.slides.internal.ey.this**

Ten wyjątek występuje w systemie Linux, w którym brakuje fontconfig i czcionek. 

### **Rozwiązanie**

Zainstaluj fontconfig:

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

Dodatkowo niektóre wersje open-jdk (na przykład **alpine JDK**) również **wymagają zainstalowanych czcionek**.

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

## **Wyjątek: UnsatisfiedLinkError: libfreetype.so.6: Nie można otworzyć pliku współdzielonego: Nie ma takiego pliku ani katalogu**

Ten wyjątek występuje w systemie Linux, w którym brakuje biblioteki libfreetype. 

### **Rozwiązanie**

Zainstaluj libfreetype i fontconfig:

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
Nie zapomnij zainstalować czcionek lub użyć FontsLoader.
{{% /alert %}}