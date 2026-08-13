---
title: Beheer presentatie‑eigenschappen in C++
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/cpp/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document‑metadata
- metadata bewerken
- proof‑taal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatie‑eigenschappen in Aspose.Slides voor C++ en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Introductie**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides‑API.

Aspose.Slides maakt het mogelijk om met presentatiedocumenteigenschappen te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_document_properties)‑interface. Een instantie van deze interface wordt geretourneerd door de [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_documentproperties/)‑methode. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" %}} 

Houd er rekening mee dat u geen waarden kunt instellen voor de **Application**‑ en **Producer**‑velden, omdat Aspose Ltd. en Aspose.Slides for C++ x.x.x in deze velden worden weergegeven.

{{% /alert %}} 

## **Presentatie‑eigenschappen beheren**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan presentatie‑bestanden toe te voegen. Deze documenteigenschappen maken het mogelijk om nuttige informatie samen met de documenten (presentatie‑bestanden) op te slaan. Er zijn twee soorten documenteigenschappen:

- Systeem‑gedefinieerde (Ingebouwde) eigenschappen  
- Gebruiker‑gedefinieerde (Aangepaste) eigenschappen  

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, naam van de auteur, documentstatistieken, enzovoort. **Aangepaste** eigenschappen zijn diegenen die door gebruikers worden gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel naam als waarde door de gebruiker worden opgegeven. Met Aspose.Slides voor C++ kunnen ontwikkelaars zowel de waarden van ingebouwde eigenschappen als van aangepaste eigenschappen benaderen en wijzigen. Microsoft PowerPoint 2007 maakt het beheer van de documenteigenschappen van presentatie‑bestanden mogelijk. Het enige wat u hoeft te doen is op het Office‑pictogram klikken en vervolgens **Voorbereiden | Eigenschappen | Geavanceerde eigenschappen** kiezen in Microsoft PowerPoint 2007. Nadat u **Geavanceerde eigenschappen** hebt geselecteerd, verschijnt er een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren. In het **Eigenschappen‑dialoogvenster** ziet u verschillende tabbladen zoals **Algemeen, Samenvatting, Statistieken, Inhoud en Aangepast**. Al deze tabbladen maken het mogelijk verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het tabblad **Aangepast** wordt gebruikt om aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Ingebouwde eigenschappen benaderen**

Deze eigenschappen, zoals ze beschikbaar worden gesteld door het **IDocumentProperties**‑object, omvatten: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Laatste afdrukdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wordt gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentatie‑bestanden is net zo eenvoudig als ze benaderen. U kunt eenvoudig een tekenreeks‑waarde toewijzen aan elke gewenste eigenschap en de eigenschapswaarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe u de ingebouwde documenteigenschappen van het presentatie‑bestand kunt wijzigen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aspose.Slides voor C++ maakt het ook mogelijk voor ontwikkelaars om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Een voorbeeld wordt hieronder gegeven dat laat zien hoe u de aangepaste eigenschappen voor een presentatie instelt.

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

// Naam van eigenschap op een bepaalde index ophalen
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Geselecteerde eigenschap verwijderen
documentProperties->RemoveCustomProperty(getPropertyName);

// Presentatie opslaan
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides voor C++ maakt het ook mogelijk voor ontwikkelaars om de waarden van aangepaste eigenschappen te benaderen. Een voorbeeld wordt hieronder gegeven dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Proof‑taal instellen**

Aspose.Slides biedt de [LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides.baseportionformat/set_languageid/)‑eigenschap (beschikbaar via de [PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/)‑klasse) om de proof‑taal voor een PowerPoint‑document in te stellen. De proof‑taal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze C++‑code laat zien hoe u de proof‑taal voor een PowerPoint instelt:

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
// stel het id van een proefleestaal in

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standaardtaal instellen**

Deze C++‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie instelt:

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

// Voegt een nieuwe rechthoekvorm met tekst toe
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Controleert de taal van de eerste portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑voorbeeld**

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## ***FAQ**

### Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien de betreffende eigenschap dit toestaat, leegmaken.

### Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. U hoeft de eigenschap niet eerst te verwijderen of te controleren; Aspose.Slides werkt de eigenschapswaarde automatisch bij.

### Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?

Ja, u kunt presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden door gebruik te maken van de `GetPresentationInfo`‑methode van de [PresentationFactory](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationfactory/)‑klasse. Vervolgens kunt u de `ReadDocumentProperties`‑methode van de [IPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/)‑interface gebruiken om de eigenschappen efficiënt uit te lezen, waardoor geheugen wordt bespaard en de prestaties verbeteren.