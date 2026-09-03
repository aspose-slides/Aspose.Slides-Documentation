---
title: Schriften in Präsentationen mit Python einbetten
linktitle: Eingebettete Schriften
type: docs
weight: 40
url: /de/python-net/embedded-font/
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
- Python
- Aspose.Slides
description: "Verwalten Sie eingebettete Schriften in PowerPoint mit Aspose.Slides für Python via .NET. Verwenden Sie Python, um Schriften hinzuzufügen, abzurufen, zu entfernen und zu komprimieren, um das Aussehen des Textes zu bewahren und die Dateigröße zu reduzieren."
---
## **Einführung**

Einbetten von Schriften speichert Schriftartdaten innerhalb einer PowerPoint‑Präsentation. Wenn ein Viewer eingebettete Schriften unterstützt, kann er den Text mit diesen Schriften anzeigen, selbst wenn sie nicht auf dem Zielsystem installiert sind. Das hilft, Zeilenumbrüche, Zeichenabstände und das Folienlayout beizubehalten.

Aspose.Slides für Python via .NET ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriften über die [fonts_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/fonts_manager/)‑Eigenschaft eines [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)-Objekts. Sie können außerdem die Größe der eingebetteten Schriftartdaten reduzieren, indem Sie Zeichen entfernen, die in der Präsentation nicht verwendet werden.

Die nachfolgenden Beispiele arbeiten mit PPTX‑Dateien. Stellen Sie vor dem Einbetten einer Schrift sicher, dass die Schriftartdaten Aspose.Slides zur Verfügung stehen und die Lizenz das Einbetten erlaubt.

## **Abrufen und Entfernen eingebetteter Schriften**

Verwenden Sie [get_embedded_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_embedded_fonts/), um die in einer Präsentation gespeicherten Schriften aufzulisten. Um eine zu entfernen, übergeben Sie eine Schrift aus dieser Liste an [remove_embedded_font](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/remove_embedded_font/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel listet die eingebetteten Schriften in `EmbeddedFonts.pptx` auf und entfernt Calibri, falls sie vorhanden ist:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Das Entfernen einer eingebetteten Schrift löscht deren gespeicherte Schriftartdaten; es ändert nicht die dem Text zugewiesene Schrift. Ist die Schrift auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann beim Rendern eine [font substitution](/slides/de/python-net/font-substitution/) erforderlich sein, was das Layout beeinflussen kann.

## **Untersuchen von Schriftartdaten und Einbettungsrechten**

Verwenden Sie die Klasse [FontsManager](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/), um Schriften vor dem Einbetten zu prüfen. Rufen Sie [get_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_fonts/) auf, um die in der Präsentation verwendeten Schriften zu erhalten. Für jede Schrift übergeben Sie ein [FontData](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontdata/)-Objekt und den erforderlichen [FontStyleType](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontstyletype/)-Wert an [get_font_bytes](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_font_bytes/). Die Methode liefert die Binärdaten für diesen Schriftschnitt oder `None`, wenn die angeforderte Schrift oder der Stil nicht verfügbar ist. Übergeben Sie kein `None`‑Ergebnis an [get_font_embedding_level](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), da diese Methode ein Byte‑Array erwartet.

[EmbeddingLevel](https://reference.aspose.com/slides/de/python-net/aspose.slides/embeddinglevel/) ist eine Aufzählung von Flags, die die in der Schrift gespeicherten Einbettungsbeschränkungen melden:

- `INSTALLABLE` erlaubt das Einbetten und die permanente Installation auf einem anderen System, vorbehaltlich der Schriftlizenz.
- `RESTRICTED` verbietet das Einbetten, es sei denn, es wird eine Erlaubnis vom rechtlichen Eigentümer der Schrift eingeholt, wenn es das einzige Nutzungs‑Rechte‑Flag ist.
- `PREVIEW_PRINT` erlaubt die temporäre Nutzung zum Anzeigen und Drucken; ein Dokument, das die Schrift enthält, muss schreibgeschützt sein.
- `EDITABLE` erlaubt die temporäre Nutzung und gestattet das Bearbeiten und Speichern des Dokuments.
- `NO_SUBSETTING` ist eine zusätzliche Beschränkung, die das Einbetten nur eines Teilbereichs der Glyphen verbietet. Betten Sie alle Zeichen ein, wenn dieses Flag gesetzt ist.
- `BITMAP_ONLY` ist eine zusätzliche Beschränkung, die nur das Einbetten von Bitmap‑Strikes erlaubt, nicht von Konturdaten. Hat die Schrift keine Bitmap‑Strikes, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungsrechte, während `NO_SUBSETTING` und `BITMAP_ONLY` mit ihnen kombiniert werden können. Prüfen Sie die Modifikatoren mittels bitweiser Operationen. Da `INSTALLABLE` den Wert 0 hat, maskieren Sie die Nutzungs‑Rechte‑Bits und vergleichen das Ergebnis mit `INSTALLABLE`. Aktuelle Schriften sollten höchstens ein Nutzungs‑Rechte‑Bit setzen. Für die Kompatibilität mit älteren Schriften, die mehr als eines setzen, wählt die Hilfsfunktion unten die am wenigsten restriktive Erlaubnis: `EDITABLE`, dann `PREVIEW_PRINT`, dann `RESTRICTED`.

Das folgende Beispiel prüft die regulären, fetten, kursiven und fett‑kursiven Daten, die für jede von `get_fonts` zurückgegebene Schrift verfügbar sind. Es überspringt nicht verfügbare Stile, eingeschränkte Schriften, nur‑Bitmap‑Schriften, Schriften, die auf Vorschau und Druck beschränkt sind (da die Ausgabe bearbeitbar bleibt) und bereits eingebettete Schriften. Hat ein verfügbarer Stil das Flag `NO_SUBSETTING`, werden alle Zeichen für diese Schriftfamilie eingebettet.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Diese Untersuchung meldet die in jeder Schriftdatei codierten Beschränkungen. Sie gewährt keine Lizenz, beweist nicht, dass Sie die Schrift rechtmäßig erworben haben, und ersetzt nicht die Prüfung der Lizenzvereinbarung der Schrift, bevor Sie eine eingebettete Kopie verbreiten.

## **Einbetten von Schriften**

Verwenden Sie [add_embedded_font](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/add_embedded_font/), um eine Schrift einzubetten. Die Überladungen akzeptieren entweder ein [FontData](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontdata/)-Objekt oder ein Byte‑Array mit den Schriftartdaten. Die Aufzählung [EmbedFontCharacters](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/embedfontcharacters/) steuert, welche Zeichen eingeschlossen werden:

- [ALL](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/embedfontcharacters/) bettet alle Zeichen der Schrift ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben müssen.
- [ONLY_USED](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/embedfontcharacters/) bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zur Ansicht bestimmt ist.

Das folgende Beispiel verwendet [get_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_fonts/), um die in `Fonts.pptx` verwendeten Schriften zu ermitteln, und bettet diejenigen ein, die noch nicht eingebettet sind. Die hinzuzufügenden Schriften müssen auf dem ausführenden Rechner verfügbar sein. Bereits eingebettete Schriften behalten ihre aktuellen Zeichensätze bei.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Komprimieren eingebetteter Schriften**

[compress_embedded_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) reduziert eingebettete Schriftartdaten, indem ungenutzte Zeichen entfernt werden. Sie arbeitet an bereits eingebetteten Schriften, sodass die Größenreduktion davon abhängt, wie viele ungenutzte Schriftartdaten die Präsentation enthält.

Das folgende Beispiel komprimiert die Schriften in `EmbeddedFonts.pptx` und speichert das Ergebnis als separate Datei:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Behalten Sie die Originaldatei, wenn Empfänger später Text hinzufügen müssen. Während der Komprimierung entfernte Zeichen stehen nicht mehr aus der eingebetteten Schrift zur Verfügung, selbst wenn Sie ursprünglich alle Zeichen eingebettet hatten.

## **FAQ**

**Wie kann ich prüfen, ob eine eingebettete Schrift während des Renderns noch substituiert wird?**

Rufen Sie [get_substitutions](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_substitutions/) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriften Aspose.Slides ersetzt. Überprüfen Sie außerdem die Einstellungen zur [font substitution](/slides/de/python-net/font-substitution/) und die Regeln zur [font fallback](/slides/de/python-net/fallback-font/). Fallback behandelt fehlende Zeichen, sodass das Einbetten einer Schrift nicht fehlende Zeichen der Schrift selbst ergänzt.

**Sollte ich gängige Schriften wie Arial und Calibri einbetten?**

Entscheiden Sie anhand der Zielumgebung. Wenn die benötigten Schriften auf jedem Rechner, der die Präsentation öffnet oder rendert, verfügbar sind, kann das Einbetten unnötig Dateigröße hinzufügen. Wenn Empfänger oder Server diese Schriften möglicherweise nicht haben, kann das Einbetten helfen, das beabsichtigte Erscheinungsbild zu bewahren, vorausgesetzt, ihre Lizenzen erlauben dies.