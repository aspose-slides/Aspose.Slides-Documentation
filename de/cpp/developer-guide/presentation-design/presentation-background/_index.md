---
title: Verwalten von Präsentationshintergründen in C++
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/cpp/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- Einfarbige Farbe
- Verlaufsfarbe
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für C++ festlegen, inklusive Code-Tipps, um Ihre Präsentationen zu optimieren."
---

## **Übersicht**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Hintergrundfarbe für eine bestimmte Folie in einer Präsentation – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung gilt nur für die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) auf `Solid`.
4. Verwenden Sie die Methode [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) auf [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende C++-Beispiel zeigt, wie man eine blaue einfarbige Hintergrundfarbe für eine normale Folie festlegt:
```cpp
// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Setze die Hintergrundfarbe der Folie auf Blau.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Speichere die Präsentation auf die Festplatte.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Einfarbigen Hintergrund für eine Masterfolie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Hintergrundfarbe für die Masterfolie in einer Präsentation. Die Masterfolie dient als Vorlage, die die Formatierung aller Folien steuert, sodass, wenn Sie eine einfarbige Hintergrundfarbe für die Masterfolie auswählen, diese für jede Folie gilt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) der Masterfolie (über `get_Masters`) auf `OwnBackground`.
3. Setzen Sie den Hintergrund der Masterfolie [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) auf `Solid`.
4. Verwenden Sie die Methode [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/), um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende C++-Beispiel zeigt, wie man eine einfarbige Hintergrundfarbe (Waldgrün) für eine Masterfolie festlegt:
```cpp
// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Setze die Hintergrundfarbe für die Masterfolie auf Waldgrün.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Speichere die Präsentation auf die Festplatte.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Verlaufshintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch eine allmähliche Farbänderung entsteht. Als Folienhintergrund kann ein Verlauf Präsentationen künstlerischer und professioneller erscheinen lassen. Aspose.Slides ermöglicht das Festlegen einer Verlauffarbe als Hintergrund für Folien.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) auf `Gradient`.
4. Verwenden Sie die Methode [get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_gradientformat/) auf [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/), um Ihre gewünschten Verlaufseinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende C++-Beispiel zeigt, wie man eine Verlauffarbe als Hintergrund für eine Folie festlegt:
```cpp
// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Wende einen Verlaufseffekt auf den Hintergrund an.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Speichere die Präsentation auf die Festplatte.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Ein Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlauffüllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergrund.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Methode [get_PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_picturefillformat/) auf [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende C++-Beispiel zeigt, wie man ein Bild als Hintergrund für eine Folie festlegt:
```cpp
// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Lege die Eigenschaften des Hintergrundbildes fest.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Lade das Bild.
auto image = Images::FromFile(u"Tulips.jpg");
// Füge das Bild zur Bildsammlung der Präsentation hinzu.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Speichere die Präsentation auf die Festplatte.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


Das folgende Codebeispiel zeigt, wie man den Hintergrundfülltyp auf ein gekacheltes Bild festlegt und die Kacheligkeitseigenschaften ändert:
```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}}
Lesen Sie mehr: [**Kachelbild als Textur**](/slides/de/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, damit der Inhalt der Folie besser hervorsticht. Der folgende C++-Code zeigt, wie Sie die Transparenz für ein Folienhintergrundbild ändern:
```cpp
auto transparencyValue = 30; // Zum Beispiel.

// Rufe die Sammlung von Bildtransformationsoperationen ab.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Finde einen vorhandenen Transparenzeffekt mit festem Prozentsatz.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Setze den neuen Transparenzwert.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```


## **Wert des Folienhintergrunds abrufen**

Aspose.Slides stellt das Interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/) zum Abrufen der effektiven Hintergrundwerte einer Folie bereit. Dieses Interface gibt das effektive [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) und [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) zurück.

Durch die Verwendung der Methode `get_Background` der Klasse [BaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/) können Sie den effektiven Hintergrund für eine Folie erhalten.

Das folgende C++-Beispiel zeigt, wie man den effektiven Hintergrundwert einer Folie abruft:
```cpp
// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Rufe den effektiven Hintergrund ab, wobei Master, Layout und Theme berücksichtigt werden.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```


## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme-/Layout-Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom entsprechenden [layout](/slides/de/cpp/slide-layout/)/[master](/slides/de/cpp/slide-master/) Folie (d. h. vom [theme background](/slides/de/cpp/presentation-theme/)) geerbt.

**Was passiert mit dem Hintergrund, wenn ich später das Theme der Präsentation ändere?**

Wenn eine Folie ihre eigene Füllung hat, bleibt sie unverändert. Wenn der Hintergrund vom [layout](/slides/de/cpp/slide-layout/)/[master](/slides/de/cpp/slide-master/) geerbt wird, wird er aktualisiert, um dem [new theme](/slides/de/cpp/presentation-theme/) zu entsprechen.