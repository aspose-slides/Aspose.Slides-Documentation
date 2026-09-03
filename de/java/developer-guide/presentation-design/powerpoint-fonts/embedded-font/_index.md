---
title: Einbetten von Schriften in Präsentationen in Java
linktitle: Eingebettete Schriften
type: docs
weight: 40
url: /de/java/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrifteinbettung
- Eingebettete Schrift abrufen
- Eingebettete Schrift hinzufügen
- Eingebettete Schrift entfernen
- Eingebettete Schrift komprimieren
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie eingebettete Schriften in PowerPoint mit Aspose.Slides für Java. Fügen Sie Schriften hinzu, rufen Sie sie ab, entfernen Sie sie und komprimieren Sie sie, um das Aussehen des Textes beizubehalten und die Dateigröße zu reduzieren."
---
## **Einleitung**

Das Einbetten von Schriften speichert Schriftartdaten innerhalb einer PowerPoint‑Präsentation. Wenn ein Betrachter eingebettete Schriften unterstützt, kann er den Text mit diesen Schriften anzeigen, selbst wenn sie nicht auf dem Zielsystem installiert sind. Dies hilft, Zeilenumbrüche, Textabstände und das Folienlayout beizubehalten.

Aspose.Slides for Java ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriften über die [IFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/) Schnittstelle, die von [Presentation.getFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getFontsManager--) zurückgegeben wird. Sie können die Größe der eingebetteten Schriftartdaten auch verringern, indem Sie Zeichen entfernen, die in der Präsentation nicht verwendet werden.

Die nachstehenden Beispiele arbeiten mit PPTX‑Dateien. Vor dem Einbetten einer Schriftart stellen Sie sicher, dass deren Schriftartdaten für Aspose.Slides verfügbar sind und die Lizenz das Einbetten zulässt.

## **Abrufen und Entfernen eingebetteter Schriften**

Verwenden Sie [getEmbeddedFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) , um die in einer Präsentation gespeicherten Schriften aufzulisten. Um eine zu entfernen, übergeben Sie eine Schrift aus dieser Liste an [removeEmbeddedFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel listet die eingebetteten Schriften in `EmbeddedFonts.pptx` auf und entfernt Calibri, falls sie vorhanden ist:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Das Entfernen einer eingebetteten Schriftart entfernt deren gespeicherte Schriftartdaten; es ändert nicht die dem Text zugewiesene Schriftart. Ist die Schriftart auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann die Darstellung eine [font substitution](/slides/de/java/font-substitution/) erfordern, was das Layout beeinflussen kann.

## **Untersuchen von Schriftartdaten und Einbettungsrechten**

Verwenden Sie die [IFontsManager](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/) Schnittstelle, um Schriften vor dem Einbetten zu prüfen. Rufen Sie [IFontsManager.getFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getFonts--) auf, um die in der Präsentation verwendeten Schriften zu erhalten. Für jede Schrift übergeben Sie ein [IFontData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontdata/)‑Objekt sowie den erforderlichen [FontStyleType](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontstyletype/)‑Wert an [IFontsManager.getFontBytes](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Die Methode liefert die Binärdaten für diesen Schriftschnitt oder `null`, wenn die angeforderte Schrift oder der Stil nicht verfügbar ist. Übergeben Sie kein `null`‑Ergebnis an [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), da diese Methode ein Byte‑Array erfordert.

[EmbeddingLevel](https://reference.aspose.com/slides/de/java/com.aspose.slides/embeddinglevel/) ist eine Flags‑Enumeration, die die in der Schriftart gespeicherten Einbettungsbeschränkungen meldet:

- `Installable` erlaubt das Einbetten und die permanente Installation auf einem anderen System, vorbehaltlich der Schriftlizenz.
- `Restricted` verbietet das Einbetten, es sei denn, es wird die Erlaubnis vom rechtlichen Eigentümer der Schriftart eingeholt, wenn es das einzige Nutzungs‑Erlaubnis‑Flag ist.
- `PreviewPrint` erlaubt die temporäre Verwendung zum Anzeigen und Drucken; ein Dokument, das die Schriftart enthält, muss schreibgeschützt sein.
- `Editable` erlaubt die temporäre Verwendung und ermöglicht es, das Dokument zu bearbeiten und zu speichern.
- `NoSubsetting` ist eine zusätzliche Einschränkung, die das Einbetten nur eines Teilsets der Glyphen verbietet. Bei Vorhandensein dieses Flags müssen alle Zeichen eingebettet werden.
- `BitmapOnly` ist eine zusätzliche Einschränkung, die nur das Einbetten von Bitmap‑Strikes erlaubt, nicht von Vektordaten. Hat die Schriftart keine Bitmap‑Strikes, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungs‑Erlaubnis, während `NoSubsetting` und `BitmapOnly` damit kombiniert werden können. Überprüfen Sie die Modifikatoren mit Bit‑Operationen. Da `Installable` den Wert 0 hat, maskieren Sie die Nutzungs‑Erlaubnis‑Bits und vergleichen das Ergebnis mit `Installable`, anstatt es als Flag zu prüfen. Aktuelle Schriften sollten höchstens ein Nutzungs‑Erlaubnis‑Bit setzen. Für die Kompatibilität mit älteren Schriften, die mehr als eines setzen, wählt die Hilfsfunktion unten die am wenigsten restriktive Erlaubnis: `Editable`, dann `PreviewPrint`, dann `Restricted`.

Das folgende Beispiel prüft die regulären, fetten, kursiven und fett‑kursiven Daten, die für jede von `getFonts` zurückgegebene Schrift verfügbar sind. Es überspringt nicht verfügbare Stile, restriktive Schriften, rein bitmapbasierte Schriften, Schriften, die nur für Vorschau und Druck eingeschränkt sind (weil die Ausgabe bearbeitbar bleibt) und bereits eingebettete Schriften. Wenn ein verfügbarer Stil `NoSubsetting` aufweist, werden für diese Schriftfamilie alle Zeichen eingebettet.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diese Prüfung meldet die in jeder Schriftdatei kodierten Beschränkungen. Sie gewährt keine Lizenz, beweist nicht, dass Sie die Schrift legal erworben haben, und ersetzt nicht die Prüfung der Lizenzvereinbarung der Schriftart, bevor Sie eine eingebettete Kopie verbreiten.

## **Eingebettete Schriften hinzufügen**

Verwenden Sie [addEmbeddedFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) , um eine Schriftart einzubetten. Die Überladungen akzeptieren entweder ein [IFontData](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontdata/)‑Objekt oder ein Byte‑Array, das die Schriftartdaten enthält. Die [EmbedFontCharacters](https://reference.aspose.com/slides/de/java/com.aspose.slides/embedfontcharacters/)‑Enumeration steuert, welche Zeichen eingeschlossen werden:

- [All](https://reference.aspose.com/slides/de/java/com.aspose.slides/embedfontcharacters/) bettet alle Zeichen der Schriftart ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben müssen.
- [OnlyUsed](https://reference.aspose.com/slides/de/java/com.aspose.slides/embedfontcharacters/) bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zur Ansicht bestimmt ist.

Das folgende Beispiel verwendet [getFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getFonts--) , um die in `Fonts.pptx` verwendeten Schriften zu ermitteln und bettet diejenigen ein, die noch nicht eingebettet sind. Die hinzuzufügenden Schriften müssen auf dem Rechner, auf dem der Code ausgeführt wird, verfügbar sein. Bereits eingebettete Schriften behalten ihre aktuellen Zeichensätze bei.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eingebettete Schriften komprimieren**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) reduziert die eingebetteten Schriftartdaten, indem nicht verwendete Zeichen entfernt werden. Es arbeitet an bereits eingebetteten Schriften, sodass die Größenreduktion davon abhängt, wie viele ungenutzte Schriftartdaten die Präsentation enthält.

Das folgende Beispiel komprimiert die Schriften in `EmbeddedFonts.pptx` und speichert das Ergebnis als separate Datei:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Behalten Sie die Originaldatei, wenn Empfänger später Text hinzufügen müssen. Während der Komprimierung entfernte Zeichen stehen aus der eingebetteten Schriftart nicht mehr zur Verfügung, selbst wenn Sie ursprünglich alle Zeichen eingebettet hatten.

## **FAQ**

**Wie kann ich prüfen, ob eine eingebettete Schriftart bei der Darstellung noch substituiert wird?**

Rufen Sie [getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriften Aspose.Slides ersetzen wird. Überprüfen Sie außerdem die Einstellungen für [font substitution](/slides/de/java/font-substitution/) und die Regeln für [font fallback](/slides/de/java/fallback-font/). Fallback behandelt fehlende Zeichen, sodass das Einbetten einer Schriftart Zeichen, die die Schrift selbst nicht enthält, nicht löst.

**Sollte ich gängige Schriftarten wie Arial und Calibri einbetten?**

Treffen Sie die Entscheidung basierend auf der Zielumgebung. Wenn die erforderlichen Schriften auf jedem Rechner, der die Präsentation öffnet oder rendert, verfügbar sind, kann das Einbetten unnötig die Dateigröße erhöhen. Wenn Empfänger oder Server diese Schriften möglicherweise nicht haben, kann das Einbetten helfen, das beabsichtigte Erscheinungsbild zu bewahren, vorausgesetzt, die Lizenzen erlauben dies.