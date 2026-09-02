---
title: Convert PowerPoint Presentaties naar XML in C++
linktitle: PowerPoint naar XML
type: docs
weight: 145
url: /nl/cpp/convert-powerpoint-to-xml/
keywords:
- convert PowerPoint naar XML
- convert presentatie naar XML
- PPT naar XML
- PPTX naar XML
- ODP naar XML
- PowerPoint XML Presentation
- SaveFormat::Xml
- presentatie opslaan als XML
- presentatie exporteren naar XML
- XML-stream
- C++
- Aspose.Slides
description: "Converteer PowerPoint- en OpenDocument‑presentaties naar PowerPoint‑XML‑bestanden of -streams in C++ met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides for C++ kan PowerPoint‑presentaties converteren naar het PowerPoint XML‑presentatieformaat. XML‑output is handig wanneer je een tekstgebaseerde weergave nodig hebt om de structuur van de presentatie te inspecteren, gegenereerde documenten te troubleshooten, output te vergelijken in geautomatiseerde tests, of te integreren met een workflow die XML consumeert in plaats van een presentatiepakket.

Gebruik de [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/)‑methode met de `Xml`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/)‑enumeratie. Je kunt het resultaat direct naar een bestand of naar een stream schrijven.

{{% alert color="info" title="Note" %}}

`SaveFormat::Xml` maakt een PowerPoint XML‑presentatie. Het extraheert niet de afzonderlijke Office Open XML‑onderdelen die in een PPTX‑pakket zijn opgeslagen. Als je de exacte PPTX‑pakketonderdelen nodig hebt, zoals `ppt/presentation.xml` of individuele slide‑XML‑bestanden, inspecteer dan het PPTX‑pakket zelf.

{{% /alert %}}

## **Converteer een presentatie naar een XML‑bestand**

Laad een bronpresentatie met de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse en geef vervolgens het uitvoerpad en `SaveFormat::Xml` door aan [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/). De bron kan elk presentatieformaat zijn dat ondersteund wordt voor laden, zoals PPT, PPTX of ODP.

Het volgende voorbeeld converteert een PPTX‑presentatie naar een XML‑bestand:

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

## **Schrijf de XML‑output naar een stream**

Gebruik de stream‑overload van [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/) wanneer de XML in het geheugen moet blijven of moet worden doorgegeven aan een ander component, zoals een webservice, opslagprovider of XML‑verwerkingspipeline. Het onderstaande voorbeeld schrijft het resultaat naar een [MemoryStream](https://reference.aspose.com/slides/nl/cpp/system.io/memorystream/) en zet het terug naar het begin voor daaropvolgend lezen:

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

// Geef xmlStream door aan de volgende component in de workflow.
```

## **Vergelijk XML met presentatie‑ en exportformaten**

Kies het uitvoerformaat op basis van hoe het resultaat wordt gebruikt:

| Formaat | Output | Typisch gebruik |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Een PowerPoint XML‑presentatie | Structuur inspecteren, troubleshooten, gegenereerde output vergelijken en XML‑gebaseerde integratie |
| PPT (`.ppt`) | Een legacy binair presentatiedocument | Compatibiliteit met oudere PowerPoint‑workflows |
| PPTX (`.pptx`) | Een Office Open XML‑pakket met meerdere onderdelen | Reguliere PowerPoint‑bewerking en presentatiewisseling |
| PDF of TIFF | Pagina’s met vaste lay-out of een meer‑paginabeeld | Bekijken, afdrukken en archiveren |
| PNG, JPEG of SVG | Een gerenderde weergave van een enkele slide | Miniaturen, voorvertoningen en beeld‑assets |
| HTML of HTML5 | Web‑gerichte presentatie‑output | Browserweergave en webpublicatie |

In tegenstelling tot PPT en PPTX is XML‑output primair bedoeld voor inspectie en data‑gerichte workflows. In tegenstelling tot PDF, TIFF, HTML en slide‑beeldformaten vertegenwoordigt het presentatie‑data in plaats van slides te renderen als pagina’s of visuele assets. De tabel met [ondersteunde bestandsformaten](/slides/nl/cpp/supported-file-formats/) vermeldt PowerPoint XML‑presentatie als een alleen‑opslaan‑formaat; gebruik het dus niet wanneer een workflow het geëxporteerde bestand moet laden in Aspose.Slides voor verdere bewerking.

## **FAQ**

**Is `SaveFormat::Xml` hetzelfde als het opslaan van een PPTX‑bestand?**

Nee. PPTX is een pakket dat meerdere Office Open XML‑onderdelen bevat, terwijl `SaveFormat::Xml` een PowerPoint XML‑presentatiebestand maakt.

**Kan ik de XML‑output opslaan zonder een bestand op schijf te maken?**

Ja. Geef een schrijfbare stream door aan [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/). Gebruik bijvoorbeeld een [MemoryStream](https://reference.aspose.com/slides/nl/cpp/system.io/memorystream/) voor verwerking in het geheugen.

**Kan Aspose.Slides het geëxporteerde XML‑bestand opnieuw laden?**

Nee. PowerPoint XML‑presentatie wordt momenteel alleen ondersteund voor opslaan, niet voor laden. Gebruik PPTX of een ander ondersteund presentatiefomaat wanneer round‑trip bewerking vereist is.

**Renderen XML‑conversies elke slide als een pagina of afbeelding?**

Nee. XML‑conversie schrijft gestructureerde presentatiedata. Gebruik PDF of TIFF voor paginageoriënteerde output, of PNG, JPEG en SVG voor afbeeldingen van individuele slides.