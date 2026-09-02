---
title: Konvertera PowerPoint-presentationer till XML i C++
linktitle: PowerPoint till XML
type: docs
weight: 145
url: /sv/cpp/convert-powerpoint-to-xml/
keywords:
- konvertera PowerPoint till XML
- konvertera presentation till XML
- PPT till XML
- PPTX till XML
- ODP till XML
- PowerPoint XML Presentation
- SaveFormat::Xml
- spara presentation som XML
- exportera presentation till XML
- XML-ström
- C++
- Aspose.Slides
description: "Konvertera PowerPoint- och OpenDocument-presentationer till PowerPoint XML-filer eller strömmar i C++ med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides för C++ kan konvertera PowerPoint-presentationer till PowerPoint XML Presentation‑formatet. XML‑utdata är användbart när du behöver en textbaserad representation för att granska presentationsstruktur, felsöka genererade dokument, jämföra resultat i automatiserade tester eller integrera med ett arbetsflöde som konsumerar XML istället för ett presentationspaket.

Använd [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/)‑metoden med värdet `Xml` från [SaveFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/)‑enumerationen. Du kan skriva resultatet direkt till en fil eller till en ström.

{{% alert color="info" title="Note" %}}

`SaveFormat::Xml` skapar en PowerPoint XML Presentation. Den extraherar inte de enskilda Office Open XML‑delarna som lagras i ett PPTX‑paket. Om du behöver de exakta PPTX‑paketdelarna, såsom `ppt/presentation.xml` eller enskilda bild‑XML‑filer, inspektera själva PPTX‑paketet.

{{% /alert %}}

## **Konvertera en presentation till en XML‑fil**

Läs in en källpresentation med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och skicka sedan utvägsstigen och `SaveFormat::Xml` till [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/). Källan kan vara vilket presentationsformat som helst som stöds för inläsning, såsom PPT, PPTX eller ODP.

Följande exempel konverterar en PPTX‑presentation till en XML‑fil:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Skriv XML‑utdata till en ström**

Använd ström‑överladdningen av [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/) när XML‑data ska förbli i minnet eller skickas till en annan komponent, såsom en webbtjänst, lagringsleverantör eller XML‑processeringspipeline. Följande exempel skriver resultatet till en [MemoryStream](https://reference.aspose.com/slides/sv/cpp/system.io/memorystream/) och spolar tillbaka den för efterföljande läsning:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Skicka xmlStream till nästa komponent i arbetsflödet.
```

## **Jämför XML med presentations‑ och exportformat**

Välj utskriftsformat efter hur resultatet kommer att användas:

| Format | Utdata | Typisk användning |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | En PowerPoint XML Presentation | Granska struktur, felsökning, jämföra genererad utskrift och XML‑baserad integration |
| PPT (`.ppt`) | En äldre binär presentationsfil | Kompatibilitet med äldre PowerPoint‑arbetsflöden |
| PPTX (`.pptx`) | Ett Office Open XML‑paket som innehåller flera delar | Vanlig PowerPoint‑redigering och presentationsutbyte |
| PDF eller TIFF | Sidor med fast layout eller en flersidig bild | Visning, utskrift och arkivering |
| PNG, JPEG eller SVG | En renderad representation av en enskild bild | Miniatyrer, förhandsgranskningar och bildresurser |
| HTML eller HTML5 | Webborienterad presentationsutdata | Visning i webbläsare och webbpublicering |

Till skillnad från PPT och PPTX är XML‑utdata primärt avsedd för inspektion och datadrivna arbetsflöden. Till skillnad från PDF, TIFF, HTML och bildformat för bilder representerar den presentationsdata snarare än att rendera bilder som sidor eller visuella resurser. Tabellen [supported file formats](/slides/sv/cpp/supported-file-formats/) listar PowerPoint XML Presentation som ett enbart spar‑format, så använd den inte när ett arbetsflöde måste läsa in den exporterade filen igen i Aspose.Slides för fortsatt redigering.

## **FAQ**

**Är `SaveFormat::Xml` samma som att spara en PPTX‑fil?**

Nej. PPTX är ett paket som innehåller flera Office Open XML‑delar, medan `SaveFormat::Xml` skapar en PowerPoint XML Presentation‑fil.

**Kan jag spara XML‑utdata utan att skapa en fil på disk?**

Ja. Skicka en skrivbar ström till [Presentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/save/). Till exempel, använd en [MemoryStream](https://reference.aspose.com/slides/sv/cpp/system.io/memorystream/) för bearbetning i minnet.

**Kan Aspose.Slides läsa in den exporterade XML‑filen igen?**

Nej. PowerPoint XML Presentation stöds för närvarande bara för sparande, inte för inläsning. Använd PPTX eller ett annat stöd­t presentationsformat när rundresa‑redigering krävs.

**Renderar XML‑konvertering varje bild som en sida eller bild?**

Nej. XML‑konvertering skriver strukturerad presentationsdata. Använd PDF eller TIFF för sidorienterad utskrift, eller PNG, JPEG och SVG för enskilda bild­filer.