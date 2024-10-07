---
title: Häufige Ausnahmen und Fehler im Zusammenhang mit Schriftarten unter Linux
type: docs
weight: 200
url: /php-java/technical-articles/common-errors-involving-fonts
keywords: "Schriftarten-Ausnahme, Schriftarten-Fehler, Linux, Java, Aspose.Slides für PHP über Java"
description: "Ausnahmen und Fehler bei Schriftarten unter Linux"
---

## **Fehlender Text oder Bilder (emf oder wmf) bei der Ausführung von Code unter Linux**

Dieses Problem tritt in Systemen mit Einschränkungen in folgenden Fällen auf:

1. Wenn keine Schriftarten installiert sind oder wenn der Schriftartenordner für den Java-Prozess nicht zugänglich ist
2. Wenn das TEMP-Verzeichnis nicht zugänglich ist.

### Lösung

Überprüfen und bestätigen Sie, dass der Zugriff auf das TEMP-Verzeichnis und den Schriftartenordner gewährt wurde. 

{{% alert color="warning" %}}

In einigen Fällen sind Sie möglicherweise nicht in der Lage, den Zugriff auf Ordner aufgrund von Einschränkungen der Umgebung oder einer Sicherheitsrichtlinie zu gewähren. Versuchen Sie diese Lösungen: 

{{% /alert %}}

**E workaround**

Verwenden Sie [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader), um die erforderlichen Schriftarten zu laden, ohne sie zu installieren:

```php

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

```

Wenn das TEMP-Verzeichnis nicht zugänglich ist, verwenden Sie diesen Code, um ein anderes Verzeichnis als TEMP für Java anzugeben:
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

## **Ausnahme: InvalidOperationException: Keine installierten Schriftarten auf dem System gefunden**

Diese Ausnahme tritt auf, wenn:

1) der Java-Prozess nicht auf den Schriftartenordner zugreifen kann
2) keine Schriftarten installiert sind.

### Lösung

1. Überprüfen und bestätigen Sie, dass der Zugriff auf den Schriftartenordner für den Java-Prozess gewährt wurde.

2. Installieren Sie einige Schriftarten oder verwenden Sie [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

3. Installieren Sie Schriftarten.

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

   * Verwenden Sie [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader):

```php

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

     ```

## **Ausnahme: NoClassDefFoundError: Klasse com.aspose.slides.internal.ey.this konnte nicht initialisiert werden**

Diese Ausnahme tritt auf einem Linux-System auf, dem fontconfig und Schriftarten fehlen. 

### Lösung:

Installieren Sie fontconfig:

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

Zusätzlich erfordern einige open-jdk Versionen (zum Beispiel ** Alpine JDK**) ebenfalls **installierte Schriftarten**.

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

## **Ausnahme: UnsatisfiedLinkError: libfreetype.so.6: kann die geteilte Objektdatei nicht öffnen: Datei oder Verzeichnis nicht gefunden**

Diese Ausnahme tritt auf einem Linux-System auf, dem die libfreetype-Bibliothek fehlt. 

### Lösung:

Installieren Sie libfreetype und fontconfig:

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

{{% alert title="TIPP" color="primary" %}} 

Vergessen Sie nicht, Schriftarten zu installieren oder FontsLoader zu verwenden.

{{% /alert %}}  