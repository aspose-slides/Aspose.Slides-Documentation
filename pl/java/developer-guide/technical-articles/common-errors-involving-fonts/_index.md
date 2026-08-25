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

Ten artykuł opisuje typowe błędy i wyjątki związane z czcionkami w systemie Linux oraz oferuje rozwiązania ich usunięcia. Wyjaśnia, jak sprawdzić dostęp do katalogów czcionek i TEMP, zainstalować wymagane czcionki i biblioteki oraz używać `FontsLoader` do ładowania czcionek bez instalacji ich w całym systemie.

## **Brak Tekstu lub Obrazów (EMF lub WMF) Podczas Wykonywania Kodu w Linux**

Problem ten występuje w systemach z ograniczeniami w następujących przypadkach:

1. Gdy nie zainstalowano żadnych czcionek lub gdy folder czcionek dla procesu java jest niedostępny
2. Gdy katalog TEMP jest niedostępny.

### **Rozwiązanie**

Sprawdź i potwierdź, że dostęp do katalogu TEMP oraz folderu czcionek został przyznany. 

{{% alert color="warning" %}}

W niektórych przypadkach możesz nie być w stanie przyznać dostępu do folderów z powodu ograniczeń narzuconych przez środowisko lub politykę bezpieczeństwa. Wypróbuj te obejścia: 

{{% /alert %}}

**Obejście**

Użyj [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsLoader), aby wczytać wymagane czcionki bez ich instalacji:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Jeśli katalog TEMP jest niedostępny, użyj tego kodu, aby określić inny katalog jako TEMP dla Java:
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

1. Sprawdź i potwierdź, że dostęp do folderu czcionek dla procesu Java został przyznany.

2. Zainstaluj kilka czcionek lub użyj [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsLoader).

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

   * Używając [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Wyjątek: InternalError: InvocationTargetException**

Podczas konwertowania pliku PPTX do PDF w systemie Linux konwersja może się nie powieść z komunikatem `java.lang.InternalError: java.lang.reflect.InvocationTargetException`. Jeśli podstawowy błąd mówi `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, konfiguracja czcionek w Linux jest niedostępna lub jej pamięć podręczna nie została zainicjowana.

### **Rozwiązanie**

Zainstaluj fontconfig i odbuduj pamięć podręczną czcionek:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Wyjątek: NoClassDefFoundError: Nie można zainicjować klasy com.aspose.slides.internal.ey.this**

Ten wyjątek występuje w systemie Linux, w którym brakuje fontconfig oraz czcionek. 

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

{{% alert title="TIP" color="info" %}} 

Nie zapomnij zainstalować czcionek lub użyć FontsLoader.

{{% /alert %}}