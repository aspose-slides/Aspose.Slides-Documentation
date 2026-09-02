---
title: Verwalten von Bildtransformations-Effekten in Präsentationen mit C++
linktitle: Bildtransformations-Effekte
type: docs
weight: 11
url: /de/cpp/image-transform-effects/
keywords:
- Bildtransformation
- Bild-Effekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Tönung
- HSL
- Farbersetzung
- Unschärfe
- Transparenz
- Alpha-Effekt
- Effektkette
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Anwenden, Ketten bilden, Untersuchen, Entfernen und Verifizieren von Bildtransformations-Effekten für Bildrahmen mit Aspose.Slides für C++."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformationsoperationen dar. Für einen Bildrahmen beginnen Sie mit dem [ISlidesPicture](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/) des Rahmens und greifen auf [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/get_imagetransform/) zu. Die zurückgegebene [IImageTransformOperationCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/) ermöglicht das Anhängen, Auflisten, Untersuchen, Entfernen und Leeren von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Arbeitsablauf für Helligkeit und Kontrast, Farbtransformationen, Weichzeichnung, Transparenz, geordnete Effektketten, effektive Werte, Entfernung und PPTX‑Round‑Trip‑Verifikation.

## **Verstehen von Effekt‑Eigentum und Bild‑Wiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) speichert oder referenziert die Quelldaten des Bildes, die der Präsentation gehören.
- [ISlidesPicture](https://reference.aspose.com/slides/de/cpp/aspose.slides/islidespicture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformationssammlung speichert.
- [IPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipictureframe/) ist das Folien‑Shape, das die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und weitere rahmenspezifische Formatierungen besitzt.

Daher verändern Bildtransformationsoperationen die Bytes in [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/) nicht. Wenn das gleiche `IPPImage` mehr als einmal an [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addpictureframe/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes `ISlidesPicture` und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht zu Graustufen, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Dasselbe `ISlidesPicture::get_ImageTransform`‑Modell wird auch von anderen Bildfüllungen genutzt, z. B. einer Form‑ oder Folienhintergrundfüllung. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden gültiger Parameterbereiche und Einheiten**

Die gezeigten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, auch wenn eine bestimmte Bibliotheksversion nicht sofort jeden außerhalb‑des‑Bereichs‑Wert ablehnt; das Ziel‑Präsentationsformat kann beim Speichern oder beim Öffnen der Datei in PowerPoint Daten normalisieren, weglassen oder ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle in `System::Drawing::Color` verwenden `0` bis `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Farbton ist `0` inkl. bis `360` excl., in Grad; Betrag ist `-100` bis `100`, Prozent. |
| [AddHSLEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Farbton ist `0` inkl. bis `360` excl., in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Die Ersetzungsfarbe verwendet Kanalwerte von `0` bis `255`. Bestehende Alpha‑Werte bleiben unverändert. |
| [AddBlurEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius ist nicht‑negativ und wird in Punkten gemessen; `grow` steuert, ob verwischter Inhalt außerhalb der ursprünglichen Grenzen erweitert werden darf. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Nicht‑negativer Prozentsatz. Verwenden Sie `0` bis `100` für gewöhnliche Deckkraft‑Skalierung: `0` ist vollständig transparent und `100` erhält das vorhandene Alpha. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` bis `100`, Prozent‑Deckkraft. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwelle. Werte darunter werden transparent; Werte an oder über der Schwelle werden opaque. |

Für feste Alpha‑Modulation sind Transparenz und Deckkraft komplementär. Zum Beispiel entspricht 35 % Transparenz einem Alpha‑Modulationswert von 65 %.

## **Anwenden von Helligkeit und Kontrast**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) gibt eine [IBrightnessContrast](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/ibrightnesscontrast/)‑Operation zurück. Ihre Skalar‑Einstellungen werden beim Erzeugen der Operation bereitgestellt. Die Methode `IBrightnessContrast::GetEffective` liefert berechnete Nur‑Lese‑Werte, die untersucht oder protokolliert werden können.

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

[BrightnessContrast](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der standardmäßige DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einem PPTX‑Round‑Trip editierbar bleiben sollen, verwenden Sie [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) und prüfen das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt zu Format‑Einschränkungen erklärt diesen Unterschied ausführlicher.

## **Anwenden von Farb‑Transformationen**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Tönung, HSL‑Anpassung und Farb‑Ersetzung an.

[IDuotone](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iduotone/) enthält zwei unabhängig editierbare Farbparameter: `get_Color1` ordnet dunklen Pixeln zu, während `get_Color2` hellen Pixeln zuordnet. Das macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) ersetzt die Farbe jedes Pixels durch eine feste Farbe und erhält dabei das Alpha. Es unterscheidet sich von [AddColorChangeEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), das eine Quellfarbe auf eine Ziel­farbe abbildet und beide Farbformate offenlegt.

## **Weichzeichnen, Transparenz und Alpha‑Effekte hinzufügen**

[AddBlurEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) wirkt auf alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `true`, wenn die verwischte Kante über die ursprünglichen Bildgrenzen hinausgehen kann.

Für gleichmäßige Transparenz verwenden Sie [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Es multipliziert jeden vorhandenen Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) weist hingegen allen Pixeln denselben Alpha‑Wert zu. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) konvertiert Alpha in zwei Stufen basierend auf einer Schwelle.

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

Weitere parameterfreie Alpha‑Operationen umfassen [AddAlphaCeilingEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), das jedes von Null verschiedene Alpha vollständig undurchsichtig macht; [AddAlphaFloorEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), das jedes Alpha unter 100 % vollständig transparent macht; und [AddAlphaInverseEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), das Alpha in `100% - alpha` umwandelt.

## **Erstellen einer geordneten Effektkette**

Jede `Add...Effect`‑Methode fügt am Ende der Sammlung eine neue Operation hinzu. Der Renderer verwendet die Sammlung als geordnete Pipeline: Die Ausgabe von Operation 0 wird Eingabe von Operation 1 usw. Daher kann dieselbe Menge an Operationen in einer anderen Reihenfolge ein unterschiedliches Bild erzeugen.

Beispielsweise entfernt Graustufen gefolgt von Tönung zuerst chromatische Informationen und färbt dann das Luminanz‑Ergebnis um. Tönung gefolgt von Graustufen entfernt die Tönung wieder. Analog kann Alpha‑Ersetzung Alpha‑Werte überschreiben, die von früheren Operationen berechnet wurden, während Alpha‑Modulation deren relative Unterschiede beibehält.

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

Die Sammlung erzwingt keine Kompatibilität Matrix, die Farb‑, Alpha‑ und Weichzeichnungs‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, jedoch sind nicht alle Kombinationen sinnvoll. Eine feste Farb‑Ersetzung entfernt RGB‑Variationen, die frühere Farbeffekte erzeugt haben; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling,‑Floor,‑Replacement oder‑BiLevel‑Operationen können Alpha‑Details verwerfen, die vorher erzeugt wurden. Bauen Sie die Kette nach der gewünschten Pixel‑Verarbeitungsreihenfolge auf, anstatt ihre Elemente als ungeordnete Format‑Flags zu betrachten.

## **Untersuchen editierbarer und effektiver Werte**

Eine editierbare Operation ist das Objekt, das in `ISlidesPicture::get_ImageTransform` gespeichert ist. Je nach Effekt kann sie direkt beschreibbare Member offenlegen. Zum Beispiel stellt [IBlur](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iblur/) `set_Radius` und `set_Grow` bereit, [IAlphaModulateFixed](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/ialphamodulatefixed/) stellt `set_Amount` bereit, und [IAlphaBiLevel](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/ialphabilevel/) stellt `set_Threshold` bereit. Farbeffekte wie [IDuotone](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iduotone/) geben veränderbare [IColorFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/icolorformat/)‑Objekte frei.

Einige Operations‑Interfaces, darunter [IBrightnessContrast](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/itint/) und [IAlphaReplace](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/ialphareplace/), geben ihre Erstellungs‑Skalare nicht als beschreibbare Eigenschaften frei. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `GetEffective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, stellen jedoch keine weitere Bearbeitungsoberfläche dar. Das folgende Beispiel listet die Kette auf und untersucht effektive Werte für mehrere gängige Operationen:

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

Parameterfreie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein effektives‑Daten‑Objekt, jedoch gibt es keine Skalar‑Einstellungen zum Ausgeben. Ihr Vorhandensein und ihre Position in der Sammlung sind die relevanten Informationen.

## **Entfernen oder Leeren von Bild‑Transformationen**

Verwenden Sie [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/), um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach einer Entfernung verschieben, suchen Sie zuerst das Ziel und entfernen es nach dem Auflisten. Verwenden Sie `Clear()`, um die gesamte Kette zu entfernen.

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

Das Entfernen oder Leeren von Transformationen ändert nur die Bildformatierung. Es löscht, komprimiert oder verändert die wiederverwendete [IPPImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ippimage/)‑Ressource nicht.

## **Berücksichtigung von Präsentationsformaten und Exportzielen**

Bild‑Transformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX hat nicht jede Operation identische Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Tönung, HSL, Weichzeichnung und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Round‑Trip zu überstehen. Öffnen Sie immer die erzeugte Datei erneut und prüfen Sie die Sammlung, wenn die Erhaltung ein Anspruch ist.
- [BrightnessContrast](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und nicht der standardmäßige DrawingML‑Luminanz‑Effekt. Er kann für In‑Memory‑Rendering genutzt werden, ist aber nicht garantiert als editierbares [IBrightnessContrast](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/ibrightnesscontrast/) nach dem Speichern und erneuten Öffnen von PPTX erhalten zu bleiben. Verwenden Sie bevorzugt [AddLuminanceEffect](https://reference.aspose.com/slides/de/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) für dauerhafte Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effekt‑Modell. Das Speichern nach PPT kann nicht unterstützte Operationen weglassen, eine Kette auf ein unterstütztes Subset reduzieren oder das Erscheinungsbild approximieren. Verwenden Sie PPT nicht als Verifikations‑Format für eine komplexe editierbare Kette.
- Das Rendern nach PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare `IImageTransformOperationCollection`; Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑ bzw. Vektorexporte speichern ihre eigene Render‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Consumer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Round‑Trip als auch das endgültige Export‑Format mit derselben Aspose.Slides‑Version, die in der Produktion verwendet wird.

## **FAQ**

**Ändern Bild‑Transformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zu dem `ISlidesPicture`, das von der Bildfüllung verwendet wird. Die zugrunde liegenden `IPPImage`‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dasselbe Bild wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden eines `IPPImage` vermeidet doppelte Bilddaten, aber jeder Bildrahmen hat normalerweise ein separates `ISlidesPicture` und eine eigene Bild‑Transformations‑Sammlung.

**Können Farb‑, Weichzeichnungs‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer einzigen geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellen‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformations‑Sammlung gespeicherte Operation, wo beschreibbare Member vorhanden sind; andernfalls entfernen Sie sie und fügen mit neuen Erstellungs‑Parametern eine Ersatz‑Operation hinzu.

**Welches Format sollte ich verwenden, um eine Transformations‑Kette zu erhalten?**

Verwenden Sie PPTX und prüfen Sie die Datei, indem Sie sie erneut öffnen. Das ältere PPT‑Format kann das vollständige DrawingML‑Effekt‑Modell nicht darstellen, und gerenderte Export‑Formate bewahren nur das Erscheinungsbild, nicht editierbare Transformations‑Operationen.