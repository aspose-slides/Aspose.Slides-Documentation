---
title: "Verwalten von Präsentationshintergründen in C++"
linktitle: "Folienhintergrund"
type: docs
weight: 20
url: /de/cpp/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- einfarbige Farbe
- Verlauffarbe
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für C++ festlegen, inklusive Code-Tipps zur Verbesserung Ihrer Präsentationen."
---
## **Einleitung**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung gilt nur für die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/cpp/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) auf `Solid`.
4. Verwenden Sie die Methode [get_SolidFillColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/get_solidfillcolor/) auf [FillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende C++‑Beispiel zeigt, wie Sie eine blaue einfarbige Farbe als Hintergrund für eine normale Folie festlegen:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Einfarbigen Hintergrund für eine Masterfolie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Farbe als Hintergrund für die Masterfolie einer Präsentation. Die Masterfolie dient als Vorlage, die die Formatierung aller Folien steuert, sodass die Wahl einer einfarbigen Farbe für den Hintergrund der Masterfolie auf jede Folie angewendet wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/cpp/aspose.slides/backgroundtype/) der Masterfolie (über `get_Masters`) auf `OwnBackground`.
3. Setzen Sie den Hintergrund der Masterfolie [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) auf `Solid`.
4. Verwenden Sie die Methode [get_SolidFillColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/get_solidfillcolor/), um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende C++‑Beispiel zeigt, wie Sie eine einfarbige (waldgrüne) Farbe als Hintergrund für eine Masterfolie festlegen:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Set the background color for the Master slide to Forest Green.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Save the presentation to disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Verlaufshintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch eine schrittweise Farbänderung entsteht. Als Folienhintergrund verwendet, kann ein Verlauf Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht das Festlegen einer Verlauffarbe als Hintergrund für Folien.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/cpp/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) auf `Gradient`.
4. Verwenden Sie die Methode [get_GradientFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/get_gradientformat/) auf [FillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/), um Ihre bevorzugten Verlaufseinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende C++‑Beispiel zeigt, wie Sie eine Verlauffarbe als Hintergrund für eine Folie festlegen:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlauffüllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergrund.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/cpp/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/de/cpp/aspose.slides/filltype/) auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Methode [get_PictureFillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/get_picturefillformat/) auf [FillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende C++‑Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Setze Hintergrundbild-Eigenschaften.
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

Das folgende Codebeispiel zeigt, wie Sie den Hintergrundfülltyp auf ein gekacheltes Bild setzen und die Kachel‑Eigenschaften anpassen:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

{{% alert color="info" %}}
Mehr lesen: [**Tile Picture As Texture**](/slides/de/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, um den Inhalt der Folie stärker hervorzuheben. Der folgende C++‑Code zeigt, wie Sie die Transparenz eines Folienhintergrundbildes ändern:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Zum Beispiel.

// Erstelle eine Instanz der Presentation-Klasse.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Hole die Sammlung der Bildtransformationsoperationen.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Suche nach einem vorhandenen festen prozentualen Transparenzeffekt.
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

// Speichere die Präsentation auf die Festplatte.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Den Folienhintergrundwert abrufen**

Aspose.Slides stellt das Interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibackgroundeffectivedata/) zur Verfügung, um die effektiven Hintergrundwerte einer Folie abzurufen. Dieses Interface gibt das effektive [FillFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) und [EffectFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) preis.

Mit der `get_Background`‑Methode der Klasse [BaseSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende C++‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie erhalten:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

### Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme-/Layout-Hintergrund wiederherstellen?

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom entsprechenden [layout](/slides/de/cpp/slide-layout/)/[master](/slides/de/cpp/slide-master/) übernommen (d. h. vom [theme background](/slides/de/cpp/presentation-theme/)).

### Was passiert mit dem Hintergrund, wenn ich das Theme der Präsentation später ändere?

Hat eine Folie eine eigene Füllung, bleibt diese unverändert. Wird der Hintergrund von einem [layout](/slides/de/cpp/slide-layout/)/[master](/slides/de/cpp/slide-master/) übernommen, wird er auf das [new theme](/slides/de/cpp/presentation-theme/) aktualisiert.