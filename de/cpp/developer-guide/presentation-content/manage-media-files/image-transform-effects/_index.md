---
title: Bildtransformations-Effekte in Präsentationen mit C++ verwalten
linktitle: Bildtransformations-Effekte
type: docs
weight: 11
url: /de/cpp/image-transform-effects/
keywords:
- Bildtransformation
- Bildeffekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Farbton
- HSL
- Farbersatz
- Weichzeichnung
- Transparenz
- Alpha-Effekt
- Effektkette
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Anwenden, verketten, prüfen, entfernen und verifizieren Sie Bildtransformations-Effekte für Bildrahmen mit Aspose.Slides für C++."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformationsoperationen dar. Für einen Bildrahmen beginnen Sie mit dem Rahmen‑[ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) und greifen auf [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/) zu. Die zurückgegebene [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Prüfen, Entfernen und Leeren von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Workflow für Helligkeit und Kontrast, Farbtransformationen, Weichzeichnung, Transparenz, geordnete Effektketten, effektive Werte, Entfernung und PPTX‑Rundweg‑Verifikation.

## **Verstehen von Effekt‑Eigentümerschaft und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) speichert oder referenziert die Quelldaten des Bildes, die zur Präsentation gehören.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformationssammlung speichert.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und weitere rahmenbezogene Formatierungen besitzt.

Daher verändern Bildtransformationsoperationen die Bytes in [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) nicht. Wenn dasselbe `IPPImage` mehr als einmal an [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `ISlidesPicture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht grau, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Das gleiche `ISlidesPicture::get_ImageTransform`‑Modell wird auch von anderen Bildfüllungen verwendet, z. B. einer Form‑ oder Folienhintergrundfüllung. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden Sie gültige Parameterbereiche und Einheiten**

Die gezeigten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden außerhalb liegenden Wert ablehnt; das Zielformat der Präsentation kann beim Speichern oder beim Öffnen der Datei durch PowerPoint normalisieren, weglassen oder ungültige Daten ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alphakanäle in `System::Drawing::Color` verwenden `0` bis `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Farbton ist `0` (einschließlich) bis `360` (ausschließlich) Grad; Menge ist `-100` bis `100`, Prozent. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Farbton ist `0` bis `360` Grad; Sättigung und Leuchtkraft sind `-100` bis `100`, Prozent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Die Ersatzfarbe verwendet Kanalwerte von `0` bis `255`. Bestehende Alphawerte bleiben unverändert. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius ist nicht negativ und wird in Punkten gemessen; `grow` steuert, ob verwischter Inhalt außerhalb der ursprünglichen Grenzen ausdehnen darf. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nicht‑negative Prozentzahl. Verwenden Sie `0` bis `100` für gewöhnliche Deckkraftskalierung: `0` ist vollständig transparent und `100` erhält das bestehende Alpha. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` bis `100`, Prozent‑Deckkraft. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwelle. Werte darunter werden transparent; Werte an oder über der Schwelle werden undurchsichtig. |

Für feste Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Beispiel: 35 % Transparenz entsprechen einer Alpha‑Modulationsmenge von 65 %.

## **Helligkeit und Kontrast anwenden**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) liefert eine [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)‑Operation. Ihre skalaren Einstellungen werden beim Erstellen der Operation übergeben. Die Methode `IBrightnessContrast::GetEffective` gibt berechnete Nur‑Lese‑Werte zurück, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 % und rendert anschließend eine Vorschau, ohne das eingebettete Bild zu verändern:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) ist eine Office 2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der standardmäßige DrawingML‑Leuchtkraft‑Effekt. Wenn Helligkeit und Kontrast nach einem PPTX‑Rundweg editierbar bleiben sollen, verwenden Sie [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) und prüfen Sie das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt zu Formatbeschränkungen erläutert diesen Unterschied detaillierter.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duoton, Farbton, HSL‑Anpassung und Farb­ersetzung an.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) enthält zwei unabhängig editierbare Farbparameter: `get_Color1` ordnet dunklen Pixeln zu, `get_Color2` ordnet hellen Pixeln zu. Damit ist es ein nützliches Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) ersetzt jede Pixel­farbe durch eine feste Farbe und bewahrt das Alpha. Es unterscheidet sich von [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), das eine Quellfarbe auf eine Ziel­farbe abbildet und beide Farbformate exponiert.

### **Eine Leuchtkraft‑Schwelle anwenden**

Eine Leuchtkraft‑Schwelle kann schwache Markierungen auf einer gescannten Seite leichter vom Hintergrund unterscheiden. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) bewahrt Zwischentöne von Grau. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) bildet die Leuchtkraft auf Schwarz oder Weiß ab, während [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) eine Schwelle auf die Deckkraft anwendet.

Die Leuchtkraft‑Schwelle reicht von 0 % bis 100 %, inklusiv. Pixel unter der Schwelle werden schwarz. Pixel an oder über der Schwelle werden weiß. Erhöht man die Schwelle, werden mehr Grautöne schwarz, weil mehr von ihnen unter die Grenze fallen.

Laden Sie [grayscale-swatches.png](grayscale-swatches.png) in das Arbeitsverzeichnis. Jede Beschriftung gibt das ursprüngliche Graustufen‑Level auf einer Skala von 0 bis 255 an. Das Beispiel platziert das Original neben zwei Kopien und speichert die Schwelle jeder Kopie in der Präsentation.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Öffnen Sie die Ausgabedatei in PowerPoint, um die drei Rahmen zu vergleichen. Der Farb‑Swatch mit der Beschriftung 96 hat etwa 38 % Leuchtkraft (96 von 255). Er wird bei einer Schwelle von 20 % weiß und bei 60 % schwarz.

![Originale Graustufen‑Swatches neben den Schwarz‑Weiß‑Ergebnissen bei Leuchtkraft‑Schwellen von 20 % und 60 %](luminance-threshold.png)

## **Weichzeichnung, Transparenz und Alpha‑Effekte hinzufügen**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) wirkt sich auf alle Farbkanäle, einschließlich Alpha, aus. Setzen Sie `grow` auf `true`, wenn die verwischte Kante über die ursprünglichen Bildgrenzen hinausgehen kann.

Für einheitliche Transparenz verwenden Sie [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Es multipliziert jeden bestehenden Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) weist hingegen allen Pixeln denselben Alpha‑Wert zu. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konvertiert Alpha in zwei Stufen basierend auf einer Schwelle.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Weitere parametrierungsfreie Alpha‑Operationen umfassen [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), das jedes ungleich Null‑Alpha vollständig undurchsichtig macht; [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), das jedes Alpha unter 100 % vollständig transparent macht; und [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), das Alpha in `100 % - alpha` umwandelt.

## **Eine geordnete Effektkette aufbauen**

Jede `Add…Effect`‑Methode hängt eine neue Operation am Ende der Sammlung an. Der Renderer nutzt die Sammlung als geordnete Pipeline: Das Ergebnis von Operation 0 wird zum Eingabe­wert von Operation 1 usw. Folglich kann dieselbe Menge von Operationen in anderer Reihenfolge ein unterschiedliches Bild erzeugen.

Beispiel: Graustufen gefolgt von Farbton entfernt zuerst chromatische Informationen und färbt dann das Leuchtkraft‑Ergebnis um. Farbton gefolgt von Graustufen entfernt den Farbton wieder. Ähnlich kann ein Alpha‑Ersetzungseffekt Alpha‑Werte, die durch frühere Operationen berechnet wurden, überschreiben, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das erneut geöffnete Ergebnis:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

Die Sammlung erzwingt keinen Kompatibilitäts‑Matrix, die Farb‑, Alpha‑ und Weichzeichnungs‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, jedoch sind Kombinationen nicht immer sinnvoll. Ein fester Farb‑Ersetzungseffekt entfernt RGB‑Variationen, die frühere Farbeffekte erzeugt haben; Graustufen nach Duoton entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling, Floor, Replacement oder BiLevel können Alpha‑Details, die zuvor erstellt wurden, verwerfen. Bauen Sie die Kette gemäß der gewünschten Pixel‑Verarbeitungs‑Sequenz, anstatt ihre Elemente als ungeordnete Formatierungs‑Flags zu betrachten.

<!-- visual-explanation:image-transform-effects:start -->
[![Dasselbe Bild wird zuerst durch Graustufen und dann durch Farbton und dann durch Graustufen und Farbton geführt. Die beiden endgültigen Graustufen‑Bilder haben unterschiedliche Töne.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In dieser illustrativen Aspose.Slides for .NET 26.11‑Darstellung lässt ein 220°‑Farbton bei 25 % das Graustufen‑Bild unverändert. Das Anwenden desselben Farbtons vor Graustufen erzeugt andere Töne.*
<!-- visual-explanation:image-transform-effects:end -->

## **Editierbare und effektive Werte prüfen**

Eine editierbare Operation ist das Objekt, das in `ISlidesPicture::get_ImageTransform` gespeichert ist. Je nach Effekt kann es direkt beschreibbare Member offenlegen. Zum Beispiel exponiert [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) `set_Radius` und `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) exponiert `set_Amount` und [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) exponiert `set_Threshold`. Farbeffekte wie [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) exponieren veränderbare [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/)-Objekte.

Einige Operations‑Interfaces, darunter [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/) und [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/), exponieren ihre Erstellungs‑Skalare nicht als beschreibbare Eigenschaften. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `GetEffective()` zurückgegeben werden, sind berechnet und nur lesbar. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, stellen jedoch keine weitere Editierfläche dar. Das folgende Beispiel enumeriert die Kette und prüft effektive Werte für mehrere gängige Operationen:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Parameterfreie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein Effektiv‑Daten‑Objekt, jedoch gibt es keine skalaren Einstellungen zum Ausdrucken. Ihre Existenz und Position in der Sammlung sind die wesentlichen Informationen.

## **Bild‑Transformationen entfernen oder leeren**

Verwenden Sie [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/), um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach einer Entfernung verschieben, suchen Sie zuerst das Ziel und entfernen Sie es anschließend nach der Enumeration. Verwenden Sie `Clear()`, um die gesamte Kette zu entfernen.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Das Entfernen oder Leeren von Transformationen ändert nur die Bildformatierung. Es löscht, komprimiert oder verändert die wiederverwendete [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)‑Ressource nicht.

## **Präsentationsformate und Exportziele berücksichtigen**

Bild‑Transformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX besitzt nicht jede Operation identische Portabilität:

- Standard‑DrawingML‑Operationen wie Leuchtkraft, Graustufen, Duoton, Farbton, HSL, Weichzeichnung und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Rundweg zu überstehen. Öffnen Sie die erzeugte Datei stets erneut und prüfen Sie die Sammlung, wenn die Erhaltung ein Requirement ist.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) ist eine Office 2010‑Erweiterung und nicht die standardmäßige DrawingML‑Leuchtkraft‑Operation. Sie kann für In‑Memory‑Rendering verwendet werden, ist jedoch nicht garantiert als editierbare [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) nach dem Speichern und erneuten Öffnen von PPTX erhalten zu bleiben. Verwenden Sie bevorzugt [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) für dauerhafte Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effekt‑Modell. Beim Speichern nach PPT können nicht unterstützte Operationen ausgelassen, Ketten auf ein unterstütztes Subset reduziert oder das Aussehen approximiert werden. Verwenden Sie PPT nicht als Verifikationsformat für eine komplexe editierbare Kette.
- Das Rendern nach PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare `IImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑ bzw. Vektor‑Exporte speichern ihre eigene Rendering‑Repräsentation.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, besonders wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Rundweg als auch das endgültige Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion verwendet wird.

## **FAQ**

**Modifizieren Bild‑Transform‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zu dem `ISlidesPicture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `IPPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dieselbe Bildressource wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden eines `IPPImage` verhindert doppelte Bilddaten, aber jeder Bildrahmen hat normalerweise ein separates `ISlidesPicture` und eine separate Bild‑Transform‑Sammlung.

**Können Farb‑, Weichzeichnungs‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ergebnis der vorherigen bewirkt, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte nur lesbar?**

Effektive Daten stellen berechnete Werte dar, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transform‑Sammlung gespeicherte Operation dort, wo beschreibbare Member existieren; andernfalls entfernen Sie sie und fügen eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transform‑Kette zu erhalten?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das Legacy‑PPT‑Format kann das vollständige DrawingML‑Effekt‑Modell nicht darstellen, und gerenderte Export‑Formate bewahren nur das Aussehen, nicht editierbare Transform‑Operationen.