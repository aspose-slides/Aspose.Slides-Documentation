---
title: Eingebettete Schriftart
type: docs
weight: 40
url: /de/cpp/embedded-font/
keywords: "Schriftarten, eingebettete Schriftarten, Schriftarten hinzufügen, PowerPoint-Präsentation C++, CPP, Aspose.Slides für C++"
description: "Verwenden Sie eingebettete Schriftarten in PowerPoint-Präsentationen in C++"
---

**Eingebettete Schriftarten in PowerPoint** sind nützlich, wenn Sie möchten, dass Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt wird. Wenn Sie eine Drittanbieter- oder nicht standardisierte Schriftart verwendet haben, weil Sie kreativ bei Ihrer Arbeit waren, haben Sie umso mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können sich die Texte oder Zahlen auf Ihren Folien, das Layout, das Design usw. ändern oder in verwirrende Rechtecke verwandeln.

Die [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) Klasse, die [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) Klasse, die [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) Klasse und ihre Schnittstellen enthalten die meisten der Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriftarten in PowerPoint-Präsentationen zu arbeiten.

## **Eingebettete Schriftarten aus der Präsentation abrufen oder entfernen**

Aspose.Slides bietet die [GetEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) Methode (aus der [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) Klasse), um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten abzurufen (oder herauszufinden). Um Schriftarten zu entfernen, wird die [RemoveEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/removeembeddedfont/) Methode (aus derselben Klasse) verwendet.

Dieser C++-Code zeigt Ihnen, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:

```c++
// Erstellt ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
auto presentation = System::MakeObject<Presentation>(u"EingebetteteSchriftarten.pptx");
// Rendert eine Folie, die einen Textrahmen enthält, der die eingebettete Schriftart "FunSized" verwendet
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"bild1_out.png", ImageFormat::Png);

auto fontsManager = presentation->get_FontsManager();

// Alle eingebetteten Schriftarten abrufen
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// Die Schriftart "Calibri" finden
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// Die Schriftart "Calibri" entfernen
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// Rendert die Präsentation; die Schriftart "Calibri" wird durch eine vorhandene ersetzt
presentation->get_Slides()->idx_get(0)->GetImage(Size(960, 720))->Save(u"bild2_out.png", ImageFormat::Png);

// Speichert die Präsentation ohne die eingebettete Schriftart "Calibri" auf der Festplatte
presentation->Save(u"OhneEingebetteteSchriftarten_out.ppt", SaveFormat::Ppt);
```

## **Eingebettete Schriftarten zur Präsentation hinzufügen**

Mit dem [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) Enum und zwei Überladungen der [AddEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/) Methode können Sie Ihre bevorzugte (Einbettungs-) Regel auswählen, um die Schriftarten in einer Präsentation einzubetten. Dieser C++-Code zeigt Ihnen, wie Sie Schriftarten in eine Präsentation einbetten und hinzufügen:

```c++
// Lädt die Präsentation
auto presentation = System::MakeObject<Presentation>(u"Schriftarten.pptx");

// Lädt die Quellenschriftart, die ersetzt werden soll
auto sourceFont = System::MakeObject<FontData>(u"Arial");

auto allFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (SharedPtr<IFontData> font : allFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&font](SharedPtr<IFontData> data) -> bool
    {
        return data == font;
    };

    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        presentation->get_FontsManager()->AddEmbeddedFont(font, EmbedFontCharacters::All);
    }
}

// Speichert die Präsentation auf der Festplatte
presentation->Save(u"EingebetteteSchriftart_hinzufügen_out.pptx", SaveFormat::Pptx);
```

## **Eingebettete Schriftarten komprimieren**

Um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten zu komprimieren und die Dateigröße zu reduzieren, bietet Aspose.Slides die [CompressEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) Methode (aus der [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) Klasse).

Dieser C++-Code zeigt Ihnen, wie Sie eingebettete PowerPoint-Schriftarten komprimieren:

```c++
auto pres = System::MakeObject<Presentation>(u"präsentation.pptx");

Aspose::Slides::LowCode::Compress::CompressEmbeddedFonts(pres);
pres->Save(u"präsentation-out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```