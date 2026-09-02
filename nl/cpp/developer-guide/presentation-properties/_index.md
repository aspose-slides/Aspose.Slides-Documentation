---
title: Beheer presentatie‑eigenschappen in C++
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/cpp/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- document‑eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document‑metadata
- metadata bewerken
- proefleestaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatie‑eigenschappen in Aspose.Slides for C++ en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Built-in** en **Custom**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd met de Aspose.Slides API.

Aspose.Slides stelt u in staat om met documenteigenschappen van presentaties te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_document_properties) interface. Een instantie van deze interface wordt geretourneerd door de [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_documentproperties/) methode. De volgende voorbeelden laten zien hoe deze eigenschappen gelezen, aangepast en beheerd kunnen worden.

{{% alert color="info" title="Note" %}}
Houd er rekening mee dat u geen waarden kunt instellen voor de velden **Application** en **Producer**, omdat Aspose Ltd. en Aspose.Slides for C++ x.x.x weergegeven zullen worden in deze velden.
{{% /alert %}} 

## **Beheer presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om enkele eigenschappen toe te voegen aan de presentatiebestanden. Deze documenteigenschappen maken het mogelijk om nuttige informatie op te slaan samen met de documenten (presentatiebestanden). Er zijn twee soorten documenteigenschappen, namelijk:

- Systeemgedefinieerde (Built-in) eigenschappen
- Gebruikersgedefinieerde (Custom) eigenschappen

**Built-in** eigenschappen bevatten algemene informatie over het document, zoals de titel van het document, de naam van de auteur, documentstatistieken, enzovoort. **Custom** eigenschappen zijn die welke door de gebruikers worden gedefinieerd als **Name/Value**‑paren, waarbij zowel naam als waarde door de gebruiker worden opgegeven. Met Aspose.Slides for C++ kunnen ontwikkelaars de waarden van zowel ingebouwde als aangepaste eigenschappen benaderen en wijzigen. Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentatiebestanden te beheren. Het enige wat u hoeft te doen is op het Office‑pictogram klikken en vervolgens het menu‑item **Prepare | Properties | Advanced Properties** van Microsoft PowerPoint 2007 selecteren. Nadat u het menu‑item **Advanced Properties** hebt gekozen, verschijnt er een dialoogvenster waarin u de documenteigenschappen van het PowerPoint‑bestand kunt beheren. In het **Properties Dialog** ziet u verschillende tabbladen, zoals **General, Summary, Statistics, Contents and Custom**. Al deze tabbladen maken het configureren van verschillende soorten informatie gerelateerd aan de PowerPoint‑bestanden mogelijk. Het **Custom**‑tabblad wordt gebruikt om aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Toegang tot Built-in eigenschappen**

Deze eigenschappen, zoals blootgelegd door het object **IDocumentProperties**, omvatten: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Wijzigen van Built-in eigenschappen**

Het wijzigen van de ingebouwde eigenschappen van presentatiebestanden is net zo eenvoudig als het benaderen ervan. U kunt eenvoudig een tekenreekswaarde toewijzen aan een gewenste eigenschap en de eigenschapswaarde wordt aangepast. In het onderstaande voorbeeld hebben we laten zien hoe we de ingebouwde documenteigenschappen van het presentatiebestand kunnen wijzigen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Toevoegen van Custom presentatie‑eigenschappen**

Aspose.Slides for C++ stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen voor de documenteigenschappen van een presentatie. Hieronder staat een voorbeeld dat laat zien hoe u de aangepaste eigenschappen voor een presentatie kunt instellen.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();

// Documenteigenschappen ophalen
auto documentProperties = presentation->get_DocumentProperties();

// Aangepaste eigenschappen toevoegen
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Eigenschapsnaam ophalen op een bepaalde index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Geselecteerde eigenschap verwijderen
documentProperties->RemoveCustomProperty(getPropertyName);

// Presentatie opslaan
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Toegang tot en wijzigen van Custom eigenschappen**

Aspose.Slides for C++ stelt ontwikkelaars ook in staat om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u al deze aangepaste eigenschappen voor een presentatie kunt benaderen en wijzigen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Instellen van proefleestaal**

Aspose.Slides levert de eigenschap [LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/) (blootgelegd door de klasse [PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/)) om de proefleestaal voor een PowerPoint‑document in te stellen. De proefleestaal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze C++‑code toont hoe u de proefleestaal voor een PowerPoint kunt instellen:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// stel de Id in van een proefleestaal

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standaardtaal instellen**

Deze C++‑code toont hoe u de standaardtaal voor een volledige PowerPoint‑presentatie kunt instellen:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Voegt een nieuw rechthoekvorm toe met tekst
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Controleert de taal van de eerste portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑voorbeeld**

Probeer de online‑app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides API:

[![Bekijk & bewerk PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **Veelgestelde vragen**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien toegestaan door de betreffende eigenschap, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) en vervolgens [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) om de opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/cpp/examine-presentation/) voor een volledig rapportage‑voorbeeld en formaat‑specifieke beperkingen.