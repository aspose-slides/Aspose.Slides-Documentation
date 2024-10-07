---
title: Benutzerdefinierte PowerPoint-Schriftart in Java
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /androidjava/custom-font/
keywords: "Schriftarten, benutzerdefinierte Schriftarten, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Benutzerdefinierte PowerPoint-Schriftarten in Java"
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht es Ihnen, diese Schriftarten mit der [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) Methode zu laden:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten zu laden, die in Präsentationen angezeigt werden, ohne dass diese Schriftarten installiert werden müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen.

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) Klasse und rufen Sie die [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) Methode auf.
2. Laden Sie die Präsentation, die angezeigt werden soll.
3. [Leeren Sie den Cache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) in der [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader) Klasse.

Dieser Java-Code demonstriert den Prozess des Schriftartenladens:

```java
// Verzeichnisse zur Suche nach Schriftarten
String[] folders = new String[] { externalFontsDir };

// Lädt die Schriftarten aus dem benutzerdefinierten Schriftartenverzeichnis
FontsLoader.loadExternalFonts(folders);

// Führen Sie einige Arbeiten aus und zeigen Sie die Präsentation/Slides an
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Leert den Schriftarten-Cache
    FontsLoader.clearCache();
}
```

## **Ordner für benutzerdefinierte Schriftarten abrufen**
Aspose.Slides bietet die [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) Methode, um Ihnen zu ermöglichen, Schriftartenordner zu finden. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts` Methode und Systemschriftartenordner hinzugefügt wurden.

Dieser Java-Code zeigt Ihnen, wie Sie [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) verwenden können:

```java
// Diese Zeile gibt die Ordner aus, in denen nach Schriftartdateien gesucht wird.
// Dies sind Ordner, die über die LoadExternalFonts Methode und Systemschriftartenordner hinzugefügt wurden.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Benutzerdefinierte Schriftarten für Präsentationen angeben**
Aspose.Slides bietet die [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) Eigenschaft, um Ihnen zu ermöglichen, externe Schriftarten anzugeben, die mit der Präsentation verwendet werden sollen.

Dieser Java-Code zeigt Ihnen, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) Eigenschaft verwenden können:

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

Aspose.Slides bietet die [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) Methode, um Ihnen zu ermöglichen, externe Schriftarten aus Binärdaten zu laden.

Dieser Java-Code demonstriert den Prozess des Laden von Schriftarten aus einem Byte-Array:

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