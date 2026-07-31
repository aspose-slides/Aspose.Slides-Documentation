---
title: Allgemeine Ausnahmen und Fehler im Zusammenhang mit Schriften unter Linux
type: docs
weight: 200
url: /de/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Font-Ausnahme, Font-Fehler, Linux, Java, Aspose.Slides für Java"
description: "Font-Ausnahmen und -Fehler unter Linux"
---
## **Übersicht**

Wenn Aspose.Slides unter Linux verwendet wird, können fontbezogene Probleme auftreten, wenn der Java‑Prozess nicht auf die erforderlichen Schriftordner oder das temporäre Verzeichnis zugreifen kann, wenn keine Schriften auf dem System installiert sind oder wenn erforderliche Systembibliotheken wie fontconfig oder libfreetype fehlen.

Dieser Artikel beschreibt häufige Fehler und Ausnahmen im Zusammenhang mit Schriften unter Linux und bietet Lösungen zu deren Behebung. Er erklärt, wie man den Zugriff auf Schrift‑ und TEMP‑Verzeichnisse prüft, die erforderlichen Schriften und Bibliotheken installiert und `FontsLoader` verwendet, um Schriften zu laden, ohne sie systemweit zu installieren.

## **Fehlender Text oder Bilder (EMF oder WMF) bei Codeausführung unter Linux**

Dieses Problem tritt in Systemen mit Einschränkungen in folgenden Fällen auf:

1. Wenn keine Schriften installiert sind oder der Schriftordner für den Java‑Prozess nicht zugänglich ist
2. Wenn das TEMP‑Verzeichnis nicht zugänglich ist.

### **Lösung**

Überprüfen und bestätigen Sie, dass der Zugriff auf das TEMP‑Verzeichnis und den Schriftordner gewährt wurde. 

{{% alert color="warning" %}}
In einigen Fällen können Sie aufgrund von Einschränkungen, die durch die Umgebung oder eine Sicherheitsrichtlinie auferlegt werden, keinen Zugriff auf Ordner gewähren. Versuchen Sie diese Umgehungen: 
{{% /alert %}}

**Umgehung**

Verwenden Sie [FontsLoader](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsLoader), um die erforderlichen Schriften zu laden, ohne sie zu installieren:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Wenn das TEMP‑Verzeichnis nicht zugänglich ist, verwenden Sie diesen Code, um ein anderes Verzeichnis als TEMP für Java festzulegen:
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

## **Ausnahme: InvalidOperationException: Es können keine Schriften auf dem System gefunden werden**

Diese Ausnahme tritt auf, wenn

1) der Java‑Prozess nicht auf den Schriftordner zugreifen kann  
2) keine Schriften installiert wurden.

### **Lösung**

1. Überprüfen und bestätigen Sie, dass der Zugriff auf den Schriftordner für den Java‑Prozess gewährt wurde.

2. Installieren Sie einige Schriften oder verwenden Sie [FontsLoader](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsLoader).

3. Schriften installieren.

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

   * Verwendung von [FontsLoader](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Ausnahme: NoClassDefFoundError: Klasse com.aspose.slides.internal.ey.this konnte nicht initialisiert werden**

Diese Ausnahme tritt auf einem Linux‑System auf, dem fontconfig und Schriften fehlen. 

### **Lösung**

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

Zusätzlich erfordern einige Open‑JDK‑Versionen (z. B. **alpine JDK**) ebenfalls **installierte Schriften**.

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

## **Ausnahme: UnsatisfiedLinkError: libfreetype.so.6: Kann Shared‑Object‑Datei nicht öffnen: Datei oder Verzeichnis nicht gefunden**

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
Vergessen Sie nicht, Schriften zu installieren oder FontsLoader zu verwenden.
{{% /alert %}}