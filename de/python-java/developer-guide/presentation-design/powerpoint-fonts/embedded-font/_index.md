---
title: Schriftarten in Präsentationen in Python via Java einbetten
linktitle: Eingebettete Schriftarten
type: docs
weight: 40
url: /de/python-java/embedded-font/
keywords:
- Schriftart hinzufügen
- Schriftart einbetten
- Schriftart-Einbettung
- eingebettete Schriftart abrufen
- eingebettete Schriftart hinzufügen
- eingebettete Schriftart entfernen
- eingebettete Schriftart komprimieren
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie eingebettete Schriftarten in PowerPoint mit Aspose.Slides für Python via Java. Hinzufügen, abrufen, entfernen und komprimieren von Schriftarten, um das Textaussehen zu erhalten und die Dateigröße zu reduzieren."
---
## **Einführung**

Das Einbetten von Schriftarten speichert die Schriftartdaten innerhalb einer PowerPoint‑Präsentation. Wenn ein Viewer eingebettete Schriftarten unterstützt, kann er den Text mit diesen Schriftarten anzeigen, selbst wenn sie nicht im Zielsystem installiert sind. Dies hilft, Zeilenumbrüche, Textabstände und das Folienlayout beizubehalten.

Aspose.Slides for Python via Java ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriftarten über die [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/)‑Klasse, die von [Presentation.getFontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getFontsManager) zurückgegeben wird. Sie können die Größe der eingebetteten Schriftartdaten auch reduzieren, indem Sie Zeichen entfernen, die in der Präsentation nicht verwendet werden.

Die nachfolgenden Beispiele arbeiten mit PPTX‑Dateien. Vor dem Einbetten einer Schriftart stellen Sie sicher, dass deren Schriftartdaten für Aspose.Slides verfügbar sind und dass die Lizenz das Einbetten erlaubt.

## **Abrufen und Entfernen eingebetteter Schriftarten**

Verwenden Sie [getEmbeddedFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts), um die in einer Präsentation gespeicherten Schriftarten aufzulisten. Um eine Schriftart zu entfernen, übergeben Sie eine Schriftart aus dieser Liste an [removeEmbeddedFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) und speichern anschließend die Präsentation.

Das folgende Beispiel listet die eingebetteten Schriftarten in `EmbeddedFonts.pptx` auf und entfernt Calibri, falls sie vorhanden ist:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Das Entfernen einer eingebetteten Schriftart löscht die gespeicherten Schriftartdaten; die der Text zugewiesene Schriftart bleibt unverändert. Ist die Schriftart auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann beim Rendern eine Schriftartsubstitution erfolgen, was das Layout beeinflussen kann.

## **Untersuchen von Schriftartdaten und Einbettungsrechten**

Verwenden Sie die [FontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/)‑Klasse, um Schriftarten vor dem Einbetten zu inspizieren. Rufen Sie [FontsManager.getFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getFonts) auf, um die in der Präsentation verwendeten Schriftarten zu erhalten. Für jede Schriftart übergeben Sie ein [FontData](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontdata/)‑Objekt und den erforderlichen [FontStyleType](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontstyletype/)‑Wert an [FontsManager.getFontBytes](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getFontBytes). Die Methode liefert die Binärdaten für diesen Schriftstil oder `None`, wenn die angeforderte Schriftart bzw. der Stil nicht verfügbar ist. Übergeben Sie kein `None`‑Ergebnis an [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), da diese Methode ein Byte‑Array erwartet.

[EmbeddingLevel](https://reference.aspose.com/slides/de/python-java/aspose.slides/embeddinglevel/) ist eine Flags‑Enumeration, die die in der Schriftart gespeicherten Einbettungsbeschränkungen meldet:

- `Installable` erlaubt das Einbetten und die permanente Installation auf einem anderen System, vorbehaltlich der Schriftlizenz.
- `Restricted` verbietet das Einbetten, es sei denn, es liegt eine Genehmigung des Rechteinhabers vor, wenn es das einzige Nutzungs‑Flag ist.
- `PreviewPrint` erlaubt die temporäre Verwendung zum Anzeigen und Drucken; ein Dokument, das die Schriftart enthält, muss schreibgeschützt sein.
- `Editable` erlaubt die temporäre Verwendung und gestattet das Bearbeiten und Speichern des Dokuments.
- `NoSubsetting` ist eine zusätzliche Beschränkung, die das Einbetten nur eines Teil‑Sets der Glyphen verbietet. In diesem Fall müssen alle Zeichen eingebettet werden.
- `BitmapOnly` ist eine zusätzliche Beschränkung, die nur das Einbetten von Bitmap‑Strikes erlaubt, nicht jedoch von Konturdaten. Hat die Schriftart keine Bitmap‑Strikes, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungs‑Erlaubnis, während `NoSubsetting` und `BitmapOnly` mit ihnen kombiniert werden können. Prüfen Sie die Modifikatoren mit Bit‑Operationen. Da `Installable` den Wert 0 hat, maskieren Sie die Nutzungs‑Bits und vergleichen das Ergebnis mit `Installable`, anstatt das Flag direkt zu prüfen. Aktuelle Schriftarten sollten höchstens ein Nutzungs‑Bit setzen. Für die Kompatibilität mit älteren Schriftarten, die mehrere Bits setzen, wählt die Hilfsmethode unten die am wenigsten restriktive Erlaubnis: `Editable`, dann `PreviewPrint`, dann `Restricted`.

Das folgende Beispiel prüft die regulären, fetten, kursiven und fett‑kursiven Daten jeder von `getFonts` zurückgegebenen Schriftart. Nicht verfügbare Stile, eingeschränkte Schriftarten, ausschließlich Bitmap‑Schriftarten, Schriftarten, die nur für Vorschau und Druck zulässig sind (weil das Ergebnis bearbeitbar bleiben soll), sowie bereits eingebettete Schriftarten werden übersprungen. Hat ein verfügbarer Stil `NoSubsetting`, werden alle Zeichen für diese Schriftfamilie eingebettet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Diese Inspektion meldet die in jeder Schriftartdatei kodierten Beschränkungen. Sie stellt keine Lizenz bereit, beweist nicht, dass Sie die Schriftart legal erworben haben, und ersetzt nicht die Prüfung der Lizenzvereinbarung, bevor Sie eine eingebettete Kopie verbreiten.

## **Eingebettete Schriftarten hinzufügen**

Verwenden Sie [addEmbeddedFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#addEmbeddedFont), um eine Schriftart einzubetten. Die Überladungen akzeptieren entweder ein [FontData](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontdata/)‑Objekt oder ein Byte‑Array mit den Schriftartdaten. Die Enumeration [EmbedFontCharacters](https://reference.aspose.com/slides/de/python-java/aspose.slides/embedfontcharacters/) steuert, welche Zeichen eingeschlossen werden:

- [All](https://reference.aspose.com/slides/de/python-java/aspose.slides/embedfontcharacters/) bettet alle Zeichen der Schriftart ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben müssen.
- [OnlyUsed](https://reference.aspose.com/slides/de/python-java/aspose.slides/embedfontcharacters/) bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zur Anzeige bestimmt ist.

Das folgende Beispiel ruft mit [getFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getFonts) die in `Fonts.pptx` verwendeten Schriftarten ab und bettet diejenigen ein, die noch nicht eingebettet sind. Die hinzuzufügenden Schriftarten müssen auf dem Computer, auf dem der Code ausgeführt wird, verfügbar sein. Bereits eingebettete Schriftarten behalten ihre aktuellen Zeichensätze bei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eingebettete Schriftarten komprimieren**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#compressEmbeddedFonts) reduziert eingebettete Schriftartdaten, indem nicht verwendete Zeichen entfernt werden. Die Methode arbeitet an bereits eingebetteten Schriftarten, sodass die Größenreduktion von der Menge nicht genutzter Schriftartdaten in der Präsentation abhängt.

Das folgende Beispiel komprimiert die Schriftarten in `EmbeddedFonts.pptx` und speichert das Ergebnis als separate Datei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Behalten Sie die Originaldatei, wenn Empfänger später Text hinzufügen müssen. Während der Komprimierung entfernte Zeichen stehen nicht mehr aus der eingebetteten Schriftart zur Verfügung, selbst wenn ursprünglich alle Zeichen eingebettet wurden.

## **FAQ**

**Wie kann ich prüfen, ob eine eingebettete Schriftart beim Rendern trotzdem substituiert wird?**

Rufen Sie [getSubstitutions](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getSubstitutions) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriftarten Aspose.Slides ersetzt. Prüfen Sie außerdem die Schriftart‑Substitutions‑Einstellungen und die Fallback‑Regeln. Fallback verarbeitet fehlende Zeichen, sodass das Einbetten einer Schriftart nicht fehlende Zeichen der Schriftart selbst ergänzt.

**Sollte ich gängige Schriftarten wie Arial und Calibri einbetten?**

Entscheiden Sie basierend auf der Zielumgebung. Wenn die benötigten Schriftarten auf jedem Gerät, das die Präsentation öffnet oder rendert, verfügbar sind, kann das Einbetten unnötig Dateigröße hinzufügen. Fehlen die Schriftarten jedoch bei Empfängern oder Servern, kann das Einbetten helfen, das gewünschte Erscheinungsbild beizubehalten, sofern die Lizenzen dies erlauben.