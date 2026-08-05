---
title: Schriftarten in Präsentationen mit C++ einbetten
linktitle: Schriftart einbetten
type: docs
weight: 40
url: /de/cpp/embedded-font/
keywords:
- Schriftart hinzufügen
- Schriftart einbetten
- Schriftarteinbettung
- eingebettete Schriftart abrufen
- eingebettete Schriftart hinzufügen
- eingebettete Schriftart entfernen
- eingebettete Schriftart komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "TrueType-Schriftarten in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für C++ einbetten, um ein genaues Rendering auf allen Plattformen zu gewährleisten."
---
## **Einleitung**

**Eingebettete Schriftarten in PowerPoint** helfen sicherzustellen, dass Ihre Präsentation ihr beabsichtigtes Aussehen beibehält, wenn sie auf jedem System oder Gerät geöffnet wird. Dies ist besonders wichtig, wenn benutzerdefinierte, fremde oder nicht standardmäßige Schriftarten für Branding‑ oder Kreativzwecke verwendet werden. Ohne eingebettete Schriftarten kann Text substituiert werden, Layouts können brechen und Zeichen können als unlesbare Symbole oder Rechtecke erscheinen, was das Gesamtdesign beeinträchtigt.

Aspose.Slides für C++ bietet ein leistungsstarkes API‑Set zur programmgesteuerten Verwaltung eingebetteter Schriftarten. Sie können die [FontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/) und [FontData](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontdata/) Klassen verwenden, um eingebettete Schriftarten in Ihren Präsentationsdateien zu untersuchen, hinzuzufügen oder zu entfernen. Zusätzlich ermöglicht die [Compress](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/) Klasse, die Dateigröße zu optimieren, indem Sie Schriftartdaten komprimieren, ohne Qualität oder Aussehen zu beeinträchtigen.

Diese Werkzeuge geben Ihnen die volle Kontrolle über das Einbetten von Schriftarten und helfen Ihnen, eine konsistente Typografie über Plattformen hinweg beizubehalten, während Sie bei Bedarf die Dateigröße reduzieren.

## **Eingebettete Schriftarten aus einer Präsentation abrufen**

Aspose.Slides für C++ stellt die Methode `GetEmbeddedFonts` über die [FontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/) Klasse bereit, mit der Sie eine Liste der in einer PowerPoint‑Präsentation eingebetteten Schriftarten abrufen können. Dies kann nützlich sein, um die Schriftartnutzung zu auditieren, die Einhaltung von Branding‑Richtlinien sicherzustellen oder zu überprüfen, dass alle notwendigen Schriftarten vor dem Teilen der Datei ordnungsgemäß enthalten sind.

Der folgende C++‑Code demonstriert, wie Sie eingebettete Schriftarten aus einer Präsentationsdatei abrufen:

```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Alle eingebetteten Schriftarten abrufen.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Namen der eingebetteten Schriftarten ausgeben.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Eingebettete Schriftarten zu einer Präsentation hinzufügen**

Aspose.Slides für C++ ermöglicht das Einbetten von Schriftarten in eine PowerPoint‑Präsentation mittels der [AddEmbeddedFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/addembeddedfont/) Methode, die mit zwei Überladungen für flexible Nutzung bereitsteht. Sie können steuern, wie viel der Schriftart eingebettet wird, indem Sie die Aufzählung [EmbedFontCharacters](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/embedfontcharacters/) verwenden – zum Beispiel, nur verwendete Zeichen oder das gesamte Schriftartenset einzubetten. Diese Funktion ist besonders nützlich, wenn Sie eine Präsentation zum Teilen oder Verteilen vorbereiten, um sicherzustellen, dass benutzerdefinierte oder nicht‑standardmäßige Schriftarten auf allen Systemen korrekt angezeigt werden, selbst wenn diese Schriftarten nicht installiert sind.

Der folgende C++‑Code prüft alle in einer Präsentation verwendeten Schriftarten und bettet alle Schriftarten ein, die noch nicht eingebettet sind.

```cpp
// Laden Sie eine Präsentationsdatei.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Überprüfen, ob die Schriftart bereits eingebettet ist.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Die Schriftart in die Präsentation einbetten.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Die Präsentation auf die Festplatte speichern.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Eingebettete Schriftarten aus einer Präsentation entfernen**

Aspose.Slides für C++ stellt die Methode `RemoveEmbeddedFont` über die [FontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsmanager/) Klasse bereit, mit der Sie bestimmte in einer PowerPoint‑Präsentation eingebettete Schriftarten entfernen können. Dies kann helfen, die Gesamtdateigröße zu reduzieren, insbesondere wenn die eingebetteten Schriftarten nicht mehr verwendet oder benötigt werden. Das Entfernen nicht genutzter Schriftarten kann zudem die Leistung verbessern und sicherstellen, dass Ihre Präsentation nur noch essenzielle Ressourcen enthält.

Der folgende C++‑Code demonstriert, wie Sie eine eingebettete Schriftart aus einer Präsentation entfernen:

```cpp
auto fontName = u"Calibri";

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Alle eingebetteten Schriftarten abrufen.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Die eingebettete Schriftart entfernen.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Eingebettete Schriftarten komprimieren**

Aspose.Slides für C++ stellt die Methode `CompressEmbeddedFonts` über die [Compress](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/) Klasse bereit, mit der Sie die Gesamtdateigröße einer Präsentation reduzieren können, indem Sie die eingebetteten Schriftartdaten optimieren. Dies ist besonders nützlich, wenn Ihre Präsentation große oder mehrere Schriftarten enthält und Sie die Datei für das Teilen, die Speicherung oder die Online‑Nutzung leichtgewichtig halten möchten – ohne die visuelle Treue des Inhalts zu beeinträchtigen.

Der folgende C++‑Code demonstriert, wie Sie eingebettete Schriftarten in einer PowerPoint‑Präsentation komprimieren:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Wie kann ich erkennen, dass eine bestimmte Schriftart in der Präsentation trotz Einbettung beim Rendern noch substituiert wird?**

Prüfen Sie die [Substitutionsinformationen](/slides/de/cpp/font-substitution/) im Font‑Manager und die [Fallback‑/Substitutionsregeln](/slides/de/cpp/fallback-font/): Wenn die Schriftart nicht verfügbar oder eingeschränkt ist, wird ein Fallback verwendet.

**Lohnt es sich, „System“-Schriftarten wie Arial/Calibri einzubetten?**

In der Regel nicht – sie sind fast immer verfügbar. Aber für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von Systemschriftarten das Risiko unerwarteter Substitutionen eliminieren.