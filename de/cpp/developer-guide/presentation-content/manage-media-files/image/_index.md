---
title: "Optimieren der Bildverwaltung in Präsentationen mit C++"
linktitle: "Bilder verwalten"
type: docs
weight: 10
url: /de/cpp/image/
keywords:
- Bild hinzufügen
- Grafik hinzufügen
- Bitmap hinzufügen
- Bild ersetzen
- Grafik ersetzen
- aus dem Web
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- externe SVG-Ressourcen
- SVG-Auflöser
- verknüpfte SVG-Bilder
- SVG-Schriften
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Vereinfachen Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für C++, optimieren Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---
## **Einleitung**

Bilder machen Präsentationen ansprechender und visuell attraktiver. In Microsoft PowerPoint können Sie Bilder aus Dateien, dem Internet oder anderen Quellen in Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Präsentationsfolien auf verschiedene Arten. 

{{% alert title="Tipp" color="info" %}} 

Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—die es Ihnen ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Bildrahmen hinzufügen möchten – insbesondere, wenn Sie es skalieren, Effekte anwenden oder andere Standardformatierungsoptionen nutzen wollen – siehe [Bildrahmen](/slides/de/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Bilder von einem Format in ein anderes konvertieren. Siehe die folgenden Seiten: konvertieren [Bild zu JPG](https://products.aspose.com/slides/de/cpp/conversion/image-to-jpg/), [JPG zu Bild](https://products.aspose.com/slides/de/cpp/conversion/jpg-to-image/), [JPG zu PNG](https://products.aspose.com/slides/de/cpp/conversion/jpg-to-png/), [PNG zu JPG](https://products.aspose.com/slides/de/cpp/conversion/png-to-jpg/), [PNG zu SVG](https://products.aspose.com/slides/de/cpp/conversion/png-to-svg/), und [SVG zu PNG](https://products.aspose.com/slides/de/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Bilder in gängigen Formaten wie JPEG, PNG, BMP, GIF und anderen. 

## **Bilder, die lokal gespeichert sind, zu Folien hinzufügen**

Sie können ein oder mehrere auf Ihrem Computer gespeicherte Bilder zu einer Präsentationsfolie hinzufügen. Der folgende C++‑Beispielcode zeigt, wie ein Bild zu einer Folie hinzugefügt wird:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Bilder aus dem Web zu Folien hinzufügen**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer gespeichert ist, können Sie es direkt aus dem Web hinzufügen. 

Der folgende C++‑Beispielcode zeigt, wie ein Bild aus dem Web zu einer Folie hinzugefügt wird:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Bilder zu Folienmastern hinzufügen**

Ein Folienmaster speichert und steuert Informationen wie das Design und Layout für die Folien, die ihn verwenden. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint das Bild auf jeder Folie, die auf diesem Master basiert. 

Der folgende C++‑Beispielcode zeigt, wie ein Bild zu einem Folienmaster hinzugefügt wird:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Bilder als Folienhintergründe hinzufügen**

Sie können ein Bild als Hintergrund für eine oder mehrere Folien verwenden. Weitere Details finden Sie unter *[Bilder als Hintergründe für Folien festlegen](/slides/de/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG zu Präsentationen hinzufügen**

SVG-Inhalte können einer Präsentation mithilfe der Klasse [SvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/svgimage/) hinzugefügt werden. Das resultierende [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Objekt kann dann zur Bildsammlung der Präsentation hinzugefügt und verwendet werden, um einen Bildrahmen zu erstellen.

Das folgende C++‑Beispiel importiert einen eigenständigen SVG‑String. Alle von diesem SVG verwendeten Bilder, Stile und anderen Ressourcen werden direkt in den SVG‑Inhalt eingebettet.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **SVG-Inhalt mit externen Ressourcen importieren**

Aus Design‑Tools, Diagramm‑Editoren, Iconsystemen und Web‑Pipelines exportierte SVG‑Dateien können Ressourcen referenzieren, die außerhalb des SVG‑Dokuments gespeichert sind. Zum Beispiel kann ein SVG ein Bild‑Verknüpfung wie `images/photo.png`, einen CSS‑`url(...)`‑Wert oder eine Schrift‑URL enthalten.

Um einen solchen SVG‑Inhalt zu importieren, erstellen Sie eine [IExternalResourceResolver](https://reference.aspose.com/slides/de/cpp/aspose.slides.import/iexternalresourceresolver/)‑Implementierung und übergeben Sie diese zusammen mit einer Basis‑URI an einen geeigneten `SvgImage`‑Konstruktor. Die Basis‑URI identifiziert den Speicherort des SVG‑Dokuments und wird zum Auflösen relativer Verknüpfungen verwendet.

Die [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Schnittstelle bietet Zugriff auf Informationen über das importierte SVG:

- `get_SvgContent()` gibt das SVG-Markup als Zeichenkette zurück.
- `get_SvgData()` gibt den SVG-Inhalt als Byte-Array zurück.
- `get_BaseUri()` gibt die Basis-URI zurück, die für relative Verknüpfungen verwendet wird.
- `get_ExternalResourceResolver()` gibt den dem SVG-Bild zugewiesenen Auflöser zurück.

### **Implementieren eines externen Ressourcen-Auflösers**

Der Auflöser hat zwei Methoden:

- [ResolveUri](https://reference.aspose.com/slides/de/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) verknüpft die Basis-URI und einen relativen Ressourcen-Link und gibt eine absolute URI zurück. Gibt eine Null-Zeichenkette zurück, wenn der Link nicht aufgelöst werden kann oder nicht erlaubt ist.
- [GetEntity](https://reference.aspose.com/slides/de/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) gibt einen lesbaren Stream für eine absolute Ressourcen-URI zurück. Gibt `nullptr` zurück, wenn die Ressource fehlt, blockiert oder nicht verfügbar ist. Ein optionaler Fallback-Stream kann ebenfalls zurückgegeben werden, wenn angebracht.

Der folgende Auflöser lädt verknüpfte Ressourcen nur aus einem zulässigen lokalen Verzeichnis. Netzwerkressourcen und Pfade außerhalb des zulässigen Verzeichnisses werden blockiert. Für nicht aufgelöste Bildverknüpfungen wird ein optionales Ersatzbild zurückgegeben.

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // Dieser Auflöser erlaubt absichtlich nur lokale Dateien.
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // Verwenden Sie nur ein Fallback für Bildressourcen. Das Zurückgeben eines Bild-Streams
        // für eine fehlende Schriftart oder ein Stylesheet wäre nicht gültig.
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **Verknüpfte Ressourcen während des SVG-Imports auflösen**

Angenommen, `assets/diagram.svg` enthält eine relative Referenz wie:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Der folgende C++‑Beispielcode übergibt die SVG-Datei-URI als Basis-URI und stellt einen benutzerdefinierten Auflöser bereit. Der Auflöser wandelt die relative Bildverknüpfung in eine absolute URI um und gibt einen Stream zurück, der die verknüpfte Ressource enthält, während Aspose.Slides das SVG verarbeitet.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// Der Basis-URI gibt den Speicherort des SVG-Dokuments an.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage stellt den Quellinhalt, die Binärdaten, den Basis-URI und den Auflöser bereit.
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Die `SvgImage`‑Klasse bietet zudem Überladungen, die SVG-Daten als Byte‑Array oder Stream akzeptieren, zusammen mit einem externen Ressourcen-Auflöser und einer Basis-URI.

{{% alert title="Wichtig" color="warning" %}}

Der Ressourcen-Auflöser macht externe Ressourcen während der Verarbeitung und Darstellung des SVG durch Aspose.Slides verfügbar. Er verändert das ursprüngliche SVG-Markup nicht und bettet die aufgelösten Ressourcen nicht automatisch ein.

Wenn ein `ISvgImage` zur Bildsammlung der Präsentation hinzugefügt wird, kann die PPTX‑Datei sowohl die originale SVG-Darstellung als auch ein rasterbasiertes Fallback‑Bild enthalten. Eine verknüpfte Ressource kann im generierten Fallback‑Bild erscheinen, während ein relativer Link wie `images/photo.png` im gespeicherten SVG unverändert bleibt. Eine Anwendung, die die native SVG-Darstellung rendert, kann daher den verknüpften Inhalt weglassen, wenn die originale externe Ressource nicht verfügbar ist.

{{% /alert %}}

### **Erstellen eines portablen SVG-Bildes**

Um ein SVG-Bild zu erstellen, das nicht von externen Dateien abhängt, machen Sie das SVG eigenständig, bevor Sie das `SvgImage` erzeugen. Ersetzen Sie zum Beispiel verknüpfte Bild-URLs durch `data:`‑URIs, die die Bilddaten enthalten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nachdem alle erforderlichen Ressourcen in den SVG-Inhalt eingebettet sind, erstellen Sie das `SvgImage`, fügen es zur Bildsammlung der Präsentation hinzu und setzen es wie im vorherigen Beispiel in einen Bildrahmen ein.

### **Umgang mit fehlenden oder blockierten Ressourcen**

Geben Sie eine Null-Zeichenkette von `ResolveUri` zurück, wenn eine Ressourcen-URI ungültig, verboten oder nicht auflösbar ist. Geben Sie `nullptr` von `GetEntity` zurück, wenn die Ressource nicht gelesen werden kann. Aspose.Slides setzt die Verarbeitung des SVG ohne diese Ressource fort, sofern möglich.

Ein Fallback-Stream kann für eine fehlende Ressource zurückgegeben werden, aber sein Inhalt muss zum angeforderten Ressourcentyp passen. Zum Beispiel geben Sie nur für ein fehlendes Bild einen Bild-Stream zurück, nicht für eine Schriftart oder ein Stylesheet.

{{% alert title="Sicherheit" color="warning" %}}

Lösen Sie keine beliebigen Dateipfade oder uneingeschränkten Netzwerk-URLs aus nicht vertrauenswürdigen SVG-Dateien auf. Beschränken Sie zulässige Schemas, Verzeichnisse und Hosts. Für Netzwerkressourcen sollten zudem Verbindungszeitlimits, Begrenzungen der Antwortgröße und Inhaltsvalidierungen angewendet werden.

{{% /alert %}}

## **SVG in eine Menge von Formen konvertieren**
Aspose.Slides kann ein SVG in eine Menge von Formen konvertieren, ähnlich wie die entsprechende Funktionalität in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Diese Funktionalität wird durch eine Überladung der [AddGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/)‑Methode des [IShapeCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/)‑Interfaces bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Objekt als erstes Argument entgegennimmt.

Der folgende C++‑Beispielcode zeigt, wie diese Methode verwendet wird, um eine SVG‑Datei in eine Menge von Formen zu konvertieren:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// Quell-SVG-Dateiname
auto svgFileName = System::String(u"sample.svg");

// Ausgabe-Präsentationsdateiname
auto outPptxPath = System::String(u"presentation.pptx");

// Neue Präsentation erstellen
auto presentation = System::MakeObject<Presentation>();

// SVG-Dateiinhalt lesen
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage-Objekt erstellen
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Foliengröße abrufen
auto slideSize = presentation->get_SlideSize()->get_Size();

// Das SVG-Bild in eine Gruppe von Formen konvertieren und auf die Foliengröße skalieren
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Präsentation im PPTX-Format speichern
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Bilder als EMF zu Folien hinzufügen**
Aspose.Slides for C++ ermöglicht es Ihnen, EMF‑Bilder aus Excel‑Arbeitsblättern mit Aspose.Cells zu erzeugen und sie zu Präsentationsfolien hinzuzufügen. 

Der folgende C++‑Beispielcode zeigt, wie das geht:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells für C++ muss gestartet werden, bevor einer seiner Typen verwendet wird.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Rendern Sie das Arbeitsblatt als EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells liefert die gerenderte Seite als Puffer, den Aspose.Slides als Bild hinzufügt.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **Bilder in der Bildersammlung ersetzen**

Aspose.Slides lässt Sie Bilder, die in der Bildersammlung einer Präsentation gespeichert sind, ersetzen, einschließlich der von Folienformen genutzten Bilder. Dieser Abschnitt beschreibt mehrere Möglichkeiten, Bilder in der Sammlung zu aktualisieren. Sie können ein Bild mit rohen Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Instanz oder einem anderen bereits in der Sammlung vorhandenen Bild ersetzen.

Befolgen Sie die folgenden Schritte:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mithilfe der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Klasse.
1. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
1. Ersetzen Sie das Zielbild durch das neue Bild mittels des Byte‑Arrays.
1. Laden Sie im zweiten Ansatz das Bild in ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Objekt und ersetzen Sie das Zielbild durch dieses Objekt.
1. Ersetzen Sie im dritten Ansatz das Zielbild durch ein Bild, das bereits in der Bildersammlung der Präsentation existiert.
1. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Der erste Weg.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// Der zweite Weg.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// Der dritte Weg.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Die Präsentation in einer Datei speichern.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Mit Asposes kostenlosem [Text to GIF](https://products.aspose.app/slides/de/text-to-gif)‑Konverter können Sie Text leicht animieren und GIFs aus Text erstellen. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die Ausgangspixel werden beibehalten, aber das endgültige Aussehen hängt davon ab, wie das [picture](/slides/de/cpp/picture-frame/) skaliert wird und welche Kompression beim Speichern angewendet wird.

**Wie ist der beste Weg, dasselbe Logo gleichzeitig auf Dutzenden von Folien zu ersetzen?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildersammlung der Präsentation – die Änderungen werden auf alle Elemente, die diese Ressource verwenden, übertragen.

**Kann ein eingefügtes SVG in bearbeitbare Formen umgewandelt werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, danach werden einzelne Teile mit den üblichen Form‑Eigenschaften editierbar.

**Wie kann ich ein Bild gleichzeitig als Hintergrund für mehrere Folien festlegen?**

Weisen Sie das Bild als Hintergrund auf dem Master‑Slide oder dem entsprechenden Layout zu – alle Folien, die diesen Master/Layout verwenden, erben den Hintergrund.

**Wie verhindere ich, dass eine Präsentation aufgrund vieler Bilder zu groß wird?**

Verwenden Sie eine einzige Bildressource statt Duplikaten, wählen Sie angemessene Auflösungen, wenden Sie Kompression beim Speichern an und halten Sie wiederholte Grafiken, wenn sinnvoll, im Master.