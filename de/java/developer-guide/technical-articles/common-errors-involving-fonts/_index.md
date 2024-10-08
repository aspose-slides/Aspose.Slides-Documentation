---
title: Häufige Ausnahmen und Fehler im Zusammenhang mit Schriftarten unter Linux
type: docs
weight: 200
url: /de/java/technical-articles/common-errors-involving-fonts
keywords: "Schriftarten-Ausnahme, Schriftarten-Fehler, Linux, Java, Aspose.Slides für Java"
description: "Schriftarten-Ausnahmen und -Fehler unter Linux"
---

## **Fehlender Text oder Bilder (emf oder wmf), wenn der Code unter Linux ausgeführt wird**

Dieses Problem tritt in Systemen mit Einschränkungen in diesen Fällen auf:

1. Wenn keine Schriftarten installiert sind oder wenn der Schriftartenordner für den Java-Prozess nicht zugänglich ist
2. Wenn das TEMP-Verzeichnis nicht zugänglich ist.

### Lösung

Überprüfen und bestätigen Sie, dass der Zugriff auf das TEMP-Verzeichnis und den Schriftartenordner gewährt wurde. 

{{% alert color="warning" %}}

In einigen Fällen können Sie möglicherweise den Zugriff auf Ordner aufgrund von Einschränkungen durch die Umgebung oder eine Sicherheitsrichtlinie nicht gewähren. Versuchen Sie diese Umgehungen: 

{{% /alert %}}

**Umgehung**

Verwenden Sie [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader), um die benötigten Schriftarten zu laden, ohne sie zu installieren:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Wenn das TEMP-Verzeichnis nicht zugänglich ist, verwenden Sie diesen Code, um ein anderes Verzeichnis als TEMP für Java anzugeben:
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

## **Ausnahme: InvalidOperationException: Keine Schriftarten auf dem System installiert**

Diese Ausnahme tritt auf, wenn

1) der Java-Prozess nicht auf den Schriftartenordner zugreifen kann
2) keine Schriftarten installiert wurden.

### Lösung

1. Überprüfen und bestätigen Sie, dass der Zugriff auf den Schriftartenordner für den Java-Prozess gewährt wurde.

2. Installieren Sie einige Schriftarten oder verwenden Sie [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

3. Installieren Sie Schriftarten.

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

   * Verwenden von [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Ausnahme: NoClassDefFoundError: Konnte die Klasse com.aspose.slides.internal.ey.this nicht initialisieren**

Diese Ausnahme tritt auf einem Linux-System auf, das fontconfig und Schriftarten vermisst. 

### Lösung:

Installieren Sie fontconfig:

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

Außerdem erfordern einige open-jdk Versionen (z. B. **alpine JDK**) ebenfalls **installierte Schriftarten**.

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

## **Ausnahme: UnsatisfiedLinkError: libfreetype.so.6: kann die gemeinsame Objektdatei nicht öffnen: Datei oder Verzeichnis nicht gefunden**

Diese Ausnahme tritt auf einem Linux-System auf, das die libfreetype-Bibliothek vermisst. 

### Lösung:

Installieren Sie libfreetype und fontconfig:

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

{{% alert title="TIPP" color="primary" %}} 

Vergessen Sie nicht, Schriftarten zu installieren oder FontsLoader zu verwenden.

{{% /alert %}}  