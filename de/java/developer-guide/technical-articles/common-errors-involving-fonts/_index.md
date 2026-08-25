---
title: Gemeinsame Ausnahmen und Fehler im Zusammenhang mit Schriftarten unter Linux
type: docs
weight: 200
url: /de/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Schriftartausnahme, Schriftartfehler, Linux, Java, Aspose.Slides für Java"
description: "Schriftartausnahmen und -fehler unter Linux"
---
## **Übersicht**

Wenn Aspose.Slides unter Linux verwendet wird, können Schriftart‑bezogene Probleme auftreten, wenn der Java‑Prozess keinen Zugriff auf die erforderlichen Schriftordner oder das temporäre Verzeichnis hat, wenn keine Schriftarten auf dem System installiert sind oder wenn benötigte Systembibliotheken wie fontconfig oder libfreetype fehlen.

Dieser Artikel beschreibt häufige Fehler und Ausnahmen im Zusammenhang mit Schriftarten unter Linux und liefert Lösungen zu deren Behebung. Er erklärt, wie man den Zugriff auf Schrift‑ und TEMP‑Verzeichnisse prüft, die erforderlichen Schriftarten und Bibliotheken installiert und `FontsLoader` verwendet, um Schriftarten zu laden, ohne sie systemweit zu installieren.

## **Fehlender Text oder Bilder (EMF oder WMF) wenn Code unter Linux ausgeführt wird**

Dieses Problem tritt in Systemen mit Einschränkungen in folgenden Fällen auf:

1. Wenn keine Schriftarten installiert sind oder der Schriftordner für den Java‑Prozess nicht zugänglich ist
2. Wenn das TEMP‑Verzeichnis nicht zugänglich ist.

### **Lösung**

Überprüfen und bestätigen Sie, dass Zugriff auf das TEMP‑Verzeichnis und den Schriftordner gewährt wurde. 

{{% alert color="warning" %}}
In manchen Fällen können Sie möglicherweise keinen Zugriff auf Ordner gewähren, weil das Umfeld oder eine Sicherheitspolicy Einschränkungen auferlegt. Versuchen Sie diese Umgehungen: 
{{% /alert %}}

**Umgehung**

Verwenden Sie [FontsLoader](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsLoader), um die benötigten Schriftarten zu laden, ohne sie zu installieren:

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

## **Ausnahme: InvalidOperationException: Keine installierten Schriftarten auf dem System gefunden**

Diese Ausnahme tritt auf, wenn

1) der Java‑Prozess keinen Zugriff auf den Schriftordner hat  
2) keine Schriftarten installiert wurden.

### **Lösung**

1. Überprüfen und bestätigen Sie, dass Zugriff auf den Schriftordner für den Java‑Prozess gewährt wurde.

2. Installieren Sie einige Schriftarten oder verwenden Sie [FontsLoader](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsLoader).

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

   * Verwendung von [FontsLoader](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Ausnahme: InternalError: InvocationTargetException**

Beim Konvertieren einer PPTX‑Datei zu PDF unter Linux kann die Konvertierung mit `java.lang.InternalError: java.lang.reflect.InvocationTargetException` fehlschlagen. Wenn der zugrunde liegende Fehler lautet `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, ist die Linux‑Schriftkonfiguration nicht verfügbar oder ihr Cache wurde nicht initialisiert.

### **Lösung**

Installieren Sie fontconfig und bauen Sie den Schrift‑Cache neu:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Ausnahme: NoClassDefFoundError: Klasse com.aspose.slides.internal.ey.this konnte nicht initialisiert werden**

Diese Ausnahme tritt auf einem Linux‑System auf, dem fontconfig und Schriftarten fehlen. 

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

Zusätzlich erfordern einige Open‑JDK‑Versionen (zum Beispiel **alpine JDK**) ebenfalls **installierte Schriftarten**.

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

{{% alert title="TIP" color="info" %}} 
Denken Sie daran, Schriftarten zu installieren oder FontsLoader zu verwenden.
{{% /alert %}}