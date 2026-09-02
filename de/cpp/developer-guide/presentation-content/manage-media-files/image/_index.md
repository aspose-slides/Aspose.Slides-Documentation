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
- SVG-Resolver
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

Bilder machen Präsentationen ansprechender und visuell attraktiver. In Microsoft PowerPoint können Sie Bilder aus Dateien, dem Internet oder anderen Quellen auf Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Präsentationsfolien auf verschiedene Weise. 

{{% alert title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter — [JPEG nach PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt) — mit denen Sie schnell Präsentationen aus Bildern erstellen können. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Bildrahmen einfügen möchten — insbesondere, wenn Sie die Größe ändern, Effekte anwenden oder andere Standardformatierungsoptionen nutzen wollen — siehe [Bildrahmen](/slides/de/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}}

Sie können Bilder von einem Format in ein anderes konvertieren. Siehe die folgenden Seiten: Konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/de/cpp/conversion/image-to-jpg/), [JPG zu Bild](https://products.aspose.com/slides/de/cpp/conversion/jpg-to-image/), [JPG zu PNG](https://products.aspose.com/slides/de/cpp/conversion/jpg-to-png/), [PNG zu JPG](https://products.aspose.com/slides/de/cpp/conversion/png-to-jpg/), [PNG zu SVG](https://products.aspose.com/slides/de/cpp/conversion/png-to-svg/), und [SVG zu PNG](https://products.aspose.com/slides/de/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides unterstützt Bilder in gängigen Formaten wie JPEG, PNG, BMP, GIF und anderen. 

## **Lokale Bilder zu Folien hinzufügen**

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

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer gespeichert ist, können Sie es direkt aus dem Web einbinden. 

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

## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster speichert und steuert Informationen wie Thema und Layout für die Folien, die ihn verwenden. Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint das Bild auf jeder Folie, die auf diesem Master basiert. 

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

Sie können ein Bild als Hintergrund für eine oder mehrere Folien verwenden. Einzelheiten finden Sie unter *[Bilder als Hintergründe für Folien festlegen](/slides/de/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG zu Präsentationen hinzufügen**

SVG‑Inhalte können mit der Klasse [SvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/svgimage/) zu einer Präsentation hinzugefügt werden. Das resultierende [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Objekt kann dann zur Bildsammlung der Präsentation hinzugefügt und verwendet werden, um einen Bildrahmen zu erstellen.

Der folgende C++‑Beispielcode importiert einen eigenständigen SVG‑String. Alle Bilder, Stile und anderen Ressourcen, die von diesem SVG verwendet werden, sind direkt im SVG‑Inhalt eingebettet.

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

## **SVG‑Inhalte mit externen Ressourcen importieren**

SVG‑Dateien, die aus Design‑Tools, Diagrammeditoren, Iconsystemen oder Web‑Pipelines exportiert werden, können Ressourcen referenzieren, die außerhalb des SVG‑Dokuments gespeichert sind. Beispielsweise kann ein SVG einen Bildlink wie `images/photo.png`, einen CSS‑`url(...)`‑Wert oder eine Schrift‑URL enthalten.

Um solche SVG‑Inhalte zu importieren, erstellen Sie eine Implementierung von [IExternalResourceResolver](https://reference.aspose.com/slides/de/cpp/aspose.slides.import/iexternalresourceresolver/) und übergeben Sie sie zusammen mit einer Basis‑URI an den passenden `SvgImage`‑Konstruktor. Die Basis‑URI gibt den Speicherort des SVG‑Dokuments an und wird zum Auflösen relativer Links verwendet.

Die Schnittstelle [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/) bietet Zugriff auf Informationen über das importierte SVG:

- `get_SvgContent()` liefert den SVG‑Markup‑String.
- `get_SvgData()` liefert den SVG‑Inhalt als Byte‑Array.
- `get_BaseUri()` liefert die für relative Links verwendete Basis‑URI.
- `get_ExternalResourceResolver()` liefert den dem SVG‑Bild zugewiesenen Resolver.

### **Einen externen Ressourcen‑Resolver implementieren**

Der Resolver verfügt über zwei Methoden:

- [ResolveUri](https://reference.aspose.com/slides/de/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) kombiniert die Basis‑URI und einen relativen Ressourcen‑Link und gibt eine absolute URI zurück. Gibt einen leeren String zurück, wenn der Link nicht aufgelöst werden kann oder nicht erlaubt ist.
- [GetEntity](https://reference.aspose.com/slides/de/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) gibt einen lesbaren Stream für eine absolute Ressourcen‑URI zurück. Gibt `nullptr` zurück, wenn die Ressource fehlt, blockiert oder nicht verfügbar ist. Bei Bedarf kann auch ein Fallback‑Stream zurückgegeben werden.

Der folgende Resolver lädt verknüpfte Ressourcen ausschließlich aus einem zulässigen lokalen Verzeichnis. Netzwerkressourcen und Pfade außerhalb des erlaubten Verzeichnisses werden blockiert. Für nicht aufgelöste Bildlinks wird optional ein Ersatzbild zurückgegeben.

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

        // Dieser Resolver erlaubt absichtlich nur lokale Dateien.
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

        // Verwenden Sie ein Fallback nur für Bildressourcen. Das Zurückgeben eines Bild-Streams
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

### **Verknüpfte Ressourcen beim SVG‑Import auflösen**

Angenommen, `assets/diagram.svg` enthält einen relativen Verweis wie:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Der folgende C++‑Beispielcode übergibt die SVG‑Datei‑URI als Basis‑URI und verwendet einen eigenen Resolver. Der Resolver wandelt den relativen Bildlink in eine absolute URI um und liefert einen Stream mit der verknüpften Ressource, während Aspose.Slides das SVG verarbeitet.

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

// Die Basis-URI gibt den Speicherort des SVG-Dokuments an.
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage stellt den Quellinhalt, die Binärdaten, die Basis-URI und den Resolver bereit.
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

Die Klasse `SvgImage` bietet zudem Überladungen, die SVG‑Daten als Byte‑Array oder Stream zusammen mit einem externen Ressourcen‑Resolver und einer Basis‑URI akzeptieren.

{{% alert title="Wichtig" color="warning" %}}

Der Ressourcen‑Resolver stellt externe Ressourcen während der Verarbeitung und dem Rendern des SVG durch Aspose.Slides zur Verfügung. Er ändert das ursprüngliche SVG‑Markup nicht und bettet die aufgelösten Ressourcen nicht automatisch ein.

Wenn ein `ISvgImage` zur Bildsammlung der Präsentation hinzugefügt wird, kann die PPTX‑Datei sowohl die originale SVG‑Darstellung als auch ein rasterbasiertes Ersatzbild enthalten. Eine verknüpfte Ressource kann im erzeugten Ersatzbild erscheinen, während ein relativer Link wie `images/photo.png` unverändert im gespeicherten SVG bleibt. Eine Anwendung, die die native SVG‑Darstellung rendert, kann den verknüpften Inhalt daher weglassen, wenn die ursprüngliche externe Ressource nicht verfügbar ist.

{{% /alert %}}

### **Ein portables SVG‑Bild erstellen**

Um ein SVG‑Bild zu erzeugen, das nicht von externen Dateien abhängt, machen Sie das SVG vor der Erstellung des `SvgImage` eigenständig. Ersetzen Sie beispielsweise verknüpfte Bild‑URLs durch `data:`‑URIs, die die Bilddaten enthalten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nachdem alle erforderlichen Ressourcen im SVG‑Inhalt eingebettet sind, erstellen Sie das `SvgImage`, fügen es der Bildsammlung der Präsentation hinzu und setzen es wie im vorherigen Beispiel in einen Bildrahmen ein.

### **Umgang mit fehlenden oder blockierten Ressourcen**

Geben Sie aus `ResolveUri` einen leeren String zurück, wenn eine Ressourcen‑URI ungültig, untersagt oder nicht auflösbar ist. Geben Sie aus `GetEntity` `nullptr` zurück, wenn die Ressource nicht gelesen werden kann. Aspose.Slides verarbeitet das SVG nach Möglichkeit ohne diese Ressource weiter.

Ein Fallback‑Stream kann für eine fehlende Ressource zurückgegeben werden, dessen Inhalt jedoch zum angeforderten Ressourcentyp passen muss. Beispielsweise darf ein Bild‑Stream nur für ein fehlendes Bild zurückgegeben werden, nicht jedoch für eine Schrift oder ein Stylesheet.

{{% alert title="Sicherheit" color="warning" %}}

Lösen Sie keine beliebigen Dateipfade oder uneingeschränkten Netzwerk‑URLs aus nicht vertrauenswürdigen SVG‑Dateien auf. Beschränken Sie zulässige Schemas, Verzeichnisse und Hosts. Für Netzwerkressourcen sollten zudem Verbindungs‑Timeouts, Begrenzungen der Antwortgröße und Inhaltsvalidierungen angewendet werden.

{{% /alert %}}

## **SVG in ein Satz von Formen konvertieren**
Aspose.Slides kann ein SVG in einen Satz von Formen umwandeln, ähnlich wie die entsprechende Funktionalität in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Diese Funktion wird über eine Überladung der Methode [AddGroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/) des Interfaces [IShapeCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/) bereitgestellt, die ein [ISvgImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/isvgimage/)‑Objekt als erstes Argument erhält.

Der folgende C++‑Beispielcode zeigt, wie diese Methode verwendet wird, um eine SVG‑Datei in einen Satz von Formen zu konvertieren:

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

// Quell‑SVG‑Dateiname
auto svgFileName = System::String(u"sample.svg");

// Ausgabedateiname der Präsentation
auto outPptxPath = System::String(u"presentation.pptx");

// Neue Präsentation erstellen
auto presentation = System::MakeObject<Presentation>();

// SVG‑Dateiinhalt lesen
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage‑Objekt erstellen
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// Foliengröße ermitteln
auto slideSize = presentation->get_SlideSize()->get_Size();

// SVG‑Bild in eine Gruppe von Formen konvertieren und auf die Foliengröße skalieren
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Präsentation im PPTX‑Format speichern
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Bilder als EMF zu Folien hinzufügen**
Aspose.Slides für C++ ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Arbeitsblättern mit Aspose.Cells und das Hinzufügen dieser Bilder zu Präsentationsfolien. 

Der folgende C++‑Beispielcode zeigt, wie das durchgeführt wird:

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

// Aspose.Cells für C++ muss gestartet werden, bevor seine Typen verwendet werden.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Das Arbeitsblatt als EMF rendern.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells gibt die gerenderte Seite als Puffer zurück, den Aspose.Slides als Bild hinzufügt.
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

## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides erlaubt das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind, einschließlich der von Folienformen genutzten Bilder. Dieser Abschnitt beschreibt mehrere Möglichkeiten, Bilder in der Sammlung zu aktualisieren. Sie können ein Bild mit rohen Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Instanz oder einem bereits in der Sammlung vorhandenen Bild ersetzen.

Gehen Sie wie folgt vor:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) .
1. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
1. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.
1. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/iimage/)‑Objekt und ersetzen das Zielbild durch dieses Objekt.
1. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation vorhanden ist.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

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

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
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

// Speichern Sie die Präsentation in einer Datei.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}

Mit Asposes kostenlosem [Text‑zu‑GIF](https://products.aspose.app/slides/de/text-to-gif)‑Konverter können Sie Text einfach animieren und GIFs aus Text erstellen. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die Quell‑Pixel werden beibehalten, jedoch hängt das endgültige Erscheinungsbild davon ab, wie das [picture](/slides/de/cpp/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Wie ersetze ich dasselbe Logo in Dutzenden von Folien auf einmal am besten?**

Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation — die Änderungen werden dann auf alle Elemente propagiert, die diese Ressource verwenden.

**Kann ein eingefügtes SVG in bearbeitbare Formen umgewandelt werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, woraufhin einzelne Teile mit den üblichen Form‑Eigenschaften editierbar werden.

**Wie setze ich ein Bild als Hintergrund für mehrere Folien gleichzeitig?**

[Weisen Sie das Bild als Hintergrund](/slides/de/cpp/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu — alle Folien, die diesen Master/Layout verwenden, übernehmen den Hintergrund.

**Wie verhindere ich, dass eine Präsentation wegen vieler Bilder zu groß wird?**

Verwenden Sie ein einzelnes Bild‑Ressource statt Duplikaten, wählen Sie angemessene Auflösungen, aktivieren Sie Kompression beim Speichern und lagern Sie wiederkehrende Grafiken nach Möglichkeit im Master aus.