---
title: Benutzerdefinierte PowerPoint-Schriftart in Java
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /java/custom-font/
keywords: "Schriftarten, benutzerdefinierte Schriftarten, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "PowerPoint benutzerdefinierte Schriftarten in Java"
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht es Ihnen, diese Schriftarten mit der Methode [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) zu laden:

* TrueType (.ttf) und TrueType Sammlung (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten zu laden, die in Präsentationen dargestellt werden, ohne dass diese Schriftarten installiert werden müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) Klasse und rufen Sie die Methode [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) auf.
2. Laden Sie die Präsentation, die gerendert werden soll.
3. [Leeren Sie den Cache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) in der [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) Klasse.

Dieser Java-Code demonstriert den Schriftartenladungsprozess:

```java
// Verzeichnisse zur Suche nach Schriftarten
String[] folders = new String[] { externalFontsDir };

// Lädt die Schriftarten aus dem Verzeichnis für benutzerdefinierte Schriftarten
FontsLoader.loadExternalFonts(folders);

// Führen Sie einige Arbeiten aus und führen Sie die Präsentation/Folienausgabe durch
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Leert den Schriftarten-Cache
    FontsLoader.clearCache();
}
```

## **Benutzerdefinierte Schriftartenordner abrufen**
Aspose.Slides bietet die Methode [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) an, um Schriftartenordner zu finden. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` und Systemschriftartenordner hinzugefügt wurden.

Dieser Java-Code zeigt Ihnen, wie Sie [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) verwenden können:

```java
// Diese Zeile gibt Ordner aus, in denen Schriftartendateien gesucht werden.
// Das sind Ordner, die über die Methode LoadExternalFonts und Systemschriftartenordner hinzugefügt wurden.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Benutzerdefinierte Schriftarten angeben, die mit der Präsentation verwendet werden**
Aspose.Slides bietet die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) an, um externen Schriftarten anzugeben, die mit der Präsentation verwendet werden sollen. 

Dieser Java-Code zeigt Ihnen, wie Sie die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) verwenden können:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeiten Sie mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts und deren Unterordnern stehen der Präsentation zur Verfügung
} finally {
    if (pres != null) pres.dispose();
}
```

## **Schriftarten extern verwalten**

Aspose.Slides bietet die Methode [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) an, um externe Schriftarten aus Binärdaten zu laden.

Dieser Java-Code demonstriert den Prozess des Ladens von Schriftarten aus einem Byte-Array:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // externe Schriftart während der Lebensdauer der Präsentation geladen
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```