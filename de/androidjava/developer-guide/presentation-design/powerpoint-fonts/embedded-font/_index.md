---
title: Schriftarten in Präsentationen auf Android einbetten
linktitle: Eingebettete Schriftarten
type: docs
weight: 40
url: /de/androidjava/embedded-font/
keywords:
- Schriftart hinzufügen
- Schriftart einbetten
- Schriftart-Einbettung
- Eingebettete Schriftart abrufen
- Eingebettete Schriftart hinzufügen
- Eingebettete Schriftart entfernen
- Eingebettete Schriftart komprimieren
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie eingebettete Schriftarten in PowerPoint mit Aspose.Slides für Android via Java. Fügen Sie Schriftarten hinzu, rufen Sie sie ab, entfernen Sie sie und komprimieren Sie sie, um das Erscheinungsbild des Textes beizubehalten und die Dateigröße zu reduzieren."
---
## **Einführung**

Das Einbetten von Schriften speichert Schriftartdaten innerhalb einer PowerPoint-Präsentation. Wenn ein Betrachter eingebettete Schriften unterstützt, kann er Text mit diesen Schriften anzeigen, selbst wenn sie nicht auf dem Zielsystem installiert sind. Dies hilft, Zeilenumbrüche, Textabstände und das Folienlayout beizubehalten.

Aspose.Slides for Android via Java ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriftarten über die [IFontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/) Schnittstelle, die von [Presentation.getFontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getFontsManager--) zurückgegeben wird. Sie können die Größe der eingebetteten Schriftartdaten außerdem reduzieren, indem Sie Zeichen entfernen, die in der Präsentation nicht verwendet werden.

Die untenstehenden Beispiele arbeiten mit PPTX-Dateien. Vor dem Einbetten einer Schriftart sollten Sie sicherstellen, dass deren Schriftartdaten für Aspose.Slides verfügbar sind und die Lizenz das Einbetten zulässt.

## **Abrufen und Entfernen eingebetteter Schriftarten**

Verwenden Sie [getEmbeddedFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) , um die in einer Präsentation gespeicherten Schriften aufzulisten. Um eine zu entfernen, übergeben Sie eine Schrift aus dieser Liste an [removeEmbeddedFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), und speichern anschließend die Präsentation.

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

Das Entfernen einer eingebetteten Schriftart löscht deren gespeicherte Schriftartdaten; es ändert nicht die dem Text zugewiesene Schriftart. Ist die Schriftart auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann das Rendern eine [Schriftarten-Substitution](/slides/de/androidjava/font-substitution/) erfordern, was das Layout beeinträchtigen kann.

## **Untersuchen von Schriftartdaten und Einbettungsberechtigungen**

Verwenden Sie die [IFontsManager](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/) Schnittstelle, um Schriftarten vor dem Einbetten zu untersuchen. Rufen Sie [IFontsManager.getFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) auf, um die in der Präsentation verwendeten Schriftarten zu erhalten. Für jede Schriftart übergeben Sie ein [IFontData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontdata/) Objekt und den erforderlichen [FontStyleType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontstyletype/) Wert an [IFontsManager.getFontBytes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Die Methode gibt die Binärdaten für diesen Schriftschnitt zurück oder `null`, wenn die angeforderte Schriftart oder der Stil nicht verfügbar ist. Übergeben Sie kein `null` Ergebnis an [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), da diese Methode ein Byte‑Array erwartet.

[EmbeddingLevel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/embeddinglevel/) ist eine Flags‑Aufzählung, die die in der Schriftart gespeicherten Einbettungsbeschränkungen meldet:

- `Installable` erlaubt das Einbetten und die dauerhafte Installation auf einem anderen System, vorbehaltlich der Lizenz der Schriftart.
- `Restricted` verbietet das Einbetten, es sei denn, die Erlaubnis wird vom rechtlichen Eigentümer der Schriftart eingeholt, wenn es das einzige Berechtigungs‑Flag ist.
- `PreviewPrint` erlaubt die temporäre Nutzung zum Anzeigen und Drucken; ein Dokument, das die Schriftart enthält, muss schreibgeschützt sein.
- `Editable` erlaubt die temporäre Nutzung und gestattet das Bearbeiten und Speichern des Dokuments.
- `NoSubsetting` ist eine zusätzliche Beschränkung, die das Einbetten nur eines Teilbereichs der Glyphen verbietet. Betten Sie alle Zeichen ein, wenn dieses Flag gesetzt ist.
- `BitmapOnly` ist eine zusätzliche Beschränkung, die nur das Einbetten von Bitmap‑Zeichensätzen erlaubt, nicht von Konturdaten. Hat die Schriftart keine Bitmap‑Zeichensätze, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungsberechtigung, während `NoSubsetting` und `BitmapOnly` mit ihnen kombiniert werden können. Prüfen Sie die Modifikatoren mittels bitweiser Operationen. Da `Installable` den Wert Null hat, maskieren Sie die Nutzungs‑Berechtigungsbits und vergleichen das Ergebnis mit `Installable`, anstatt es als Flag zu prüfen. Aktuelle Schriftarten sollten höchstens ein Nutzungs‑Berechtigungs‑Bit setzen. Für die Kompatibilität mit älteren Schriftarten, die mehr als ein Bit setzen, wählt die nachstehende Hilfsfunktion die am wenigsten restriktive Berechtigung: `Editable`, dann `PreviewPrint`, dann `Restricted`.

Das folgende Beispiel prüft die regulären, fetten, kursiven und fett‑kursiven Daten, die für jede von `getFonts` zurückgegebene Schriftart verfügbar sind. Es überspringt nicht verfügbare Stile, eingeschränkte Schriftarten, reine Bitmap‑Schriftarten, Schriftarten, die auf Vorschau und Druck beschränkt sind (da die Ausgabe editierbar bleibt), und bereits eingebettete Schriftarten. Hat ein verfügbarer Stil `NoSubsetting`, werden alle Zeichen für diese Schriftfamilie eingebettet.

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

Diese Untersuchung meldet die in jeder Schriftdatei codierten Beschränkungen. Sie gewährt keine Lizenz, beweist nicht, dass Sie die Schriftart legal erworben haben, und ersetzt nicht die Prüfung der Lizenzvereinbarung der Schriftart, bevor Sie eine eingebettete Kopie verbreiten.

## **Eingebettete Schriften hinzufügen**

Verwenden Sie [addEmbeddedFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) , um eine Schriftart einzubetten. Die Überladungen akzeptieren entweder ein [IFontData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontdata/) Objekt oder ein Byte‑Array, das die Schriftartdaten enthält. Die Aufzählung [EmbedFontCharacters](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/embedfontcharacters/) steuert, welche Zeichen eingeschlossen werden:

- [All](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/embedfontcharacters/) bettet alle Zeichen der Schriftart ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben müssen.
- [OnlyUsed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/embedfontcharacters/) bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zum Anzeigen gedacht ist.

Das folgende Beispiel verwendet [getFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) , um die in `Fonts.pptx` verwendeten Schriftarten abzurufen und bettet jene ein, die noch nicht eingebettet sind. Die hinzuzufügenden Schriftarten müssen auf dem Android‑Gerät verfügbar oder bei Aspose.Slides registriert sein. Bereits eingebettete Schriftarten behalten ihre aktuellen Zeichensätze bei.

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

## **Komprimieren eingebetteter Schriften**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) reduziert die Daten eingebetteter Schriftarten, indem nicht verwendete Zeichen entfernt werden. Sie arbeitet mit bereits eingebetteten Schriftarten, sodass die Größenreduktion davon abhängt, wie viele unbenutzte Schriftartdaten die Präsentation enthält.

Das folgende Beispiel komprimiert die Schriftarten in `EmbeddedFonts.pptx` und speichert das Ergebnis in einer separaten Datei:

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

Bewahren Sie die Originaldatei auf, falls Empfänger später Text hinzufügen müssen. Während der Komprimierung entfernte Zeichen stehen aus der eingebetteten Schriftart nicht mehr zur Verfügung, selbst wenn Sie ursprünglich alle Zeichen eingebettet haben.

## **FAQ**

**Wie kann ich prüfen, ob eine eingebettete Schriftart während des Renderns weiterhin substituiert wird?**

Rufen Sie [getSubstitutions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriftarten Aspose.Slides ersetzt. Prüfen Sie außerdem die Einstellungen für [Schriftarten-Substitution](/slides/de/androidjava/font-substitution/) und die Regeln für [Schriftarten-Fallback](/slides/de/androidjava/fallback-font/). Fallback behandelt fehlende Zeichen, sodass das Einbetten einer Schriftart nicht die Zeichen löst, die die Schriftart selbst nicht enthält.

**Sollte ich verbreitete Schriftarten wie Arial und Calibri einbetten?**

Treffen Sie die Entscheidung basierend auf der Zielumgebung. Sind die erforderlichen Schriftarten auf jedem Gerät, das die Präsentation öffnet oder rendert, verfügbar, kann das Einbetten unnötig Dateigröße hinzufügen. Fehlen die Schriftarten jedoch bei Empfängern oder Servern, kann das Einbetten helfen, das gewünschte Aussehen zu bewahren, vorausgesetzt, die Lizenz erlaubt dies.