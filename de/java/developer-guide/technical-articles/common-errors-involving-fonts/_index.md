---
title: Allgemeine Ausnahmen und Fehler im Zusammenhang mit Schriftarten unter Linux
type: docs
weight: 200
url: /de/java/technical-articles/common-errors-involving-fonts
keywords: "Schriftart-Ausnahme, Schriftart-Fehler, Linux, Java, Aspose.Slides für Java"
description: "Schriftart-Ausnahmen und -Fehler unter Linux"
---

## **Fehlender Text oder Bilder (EMF oder WMF), wenn Code unter Linux ausgeführt wird**

Dieses Problem tritt in Systemen mit Einschränkungen in den folgenden Fällen auf:

1. Wenn keine Schriftarten installiert sind oder der Schriftartenordner für den Java‑Prozess nicht zugänglich ist
2. Wenn das TEMP‑Verzeichnis nicht zugänglich ist.

### **Lösung**

Prüfen Sie und bestätigen Sie, dass der Zugriff auf das TEMP‑Verzeichnis und den Schriftartenordner gewährt wurde. 

{{% alert color="warning" %}}
In einigen Fällen können Sie aufgrund von Beschränkungen durch die Umgebung oder einer Sicherheitsrichtlinie keinen Zugriff auf Ordner gewähren. Versuchen Sie diese Umgehungen: 
{{% /alert %}}

**Umgehung**

Verwenden Sie [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader), um die erforderlichen Schriftarten zu laden, ohne sie zu installieren:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```


Wenn das TEMP‑Verzeichnis nicht zugänglich ist, verwenden Sie diesen Code, um ein anderes Verzeichnis als TEMP für Java anzugeben:
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


## **Ausnahme: InvalidOperationException: Keine installierten Schriftarten im System gefunden**

Diese Ausnahme tritt auf, wenn

1) der Java‑Prozess keinen Zugriff auf den Schriftartenordner hat
2) keine Schriftarten installiert sind.

### **Lösung**

1. Prüfen Sie und bestätigen Sie, dass der Zugriff auf den Schriftartenordner für den Java‑Prozess gewährt wurde.

2. Installieren Sie einige Schriftarten oder verwenden Sie [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

3. Schriftarten installieren.

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


   * Verwendung von [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader): 
```
     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ``` 
```


## **Ausnahme: NoClassDefFoundError: Klasse com.aspose.slides.internal.ey.this konnte nicht initialisiert werden**

Diese Ausnahme tritt auf einem Linux‑System auf, dem fontconfig und Schriftarten fehlen. 

### **Lösung**

fontconfig installieren:

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


Zusätzlich erfordern einige Open‑JDK‑Versionen (z. B. **alpine JDK**) ebenfalls installierte Schriftarten.

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


## **Ausnahme: UnsatisfiedLinkError: libfreetype.so.6: Gemeinsame Objektdatei kann nicht geöffnet werden: Datei oder Verzeichnis nicht gefunden**

Diese Ausnahme tritt auf einem Linux‑System auf, dem die libfreetype‑Bibliothek fehlt. 

### **Lösung**

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


{{% alert title="TIP" color="primary" %}} 
Vergessen Sie nicht, Schriftarten zu installieren oder FontsLoader zu verwenden.
{{% /alert %}}