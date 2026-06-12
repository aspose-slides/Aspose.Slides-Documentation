---
title: Beheer presentatie-eigenschappen in C++
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/cpp/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- document-eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- controletaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides voor C++ en optimaliseer zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Built-in** en **Custom**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides API.

Aspose.Slides stelt u in staat om te werken met presentatiedocumenteigenschappen via de [IDocumentProperties](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_document_properties) interface. Een instantie van deze interface wordt geretourneerd door de [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_documentproperties/) methode. De volgende voorbeelden tonen hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="primary" %}} 
Let op: u kunt geen waarden instellen voor de **Application**- en **Producer**-velden, omdat Aspose Ltd. en Aspose.Slides for C++ x.x.x in deze velden worden weergegeven.
{{% /alert %}} 

## **Presentatie‑eigenschappen beheren**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan presentatiebestanden toe te voegen. Deze documenteigenschappen maken het mogelijk om nuttige informatie op te slaan samen met de documenten (presentatiebestanden). Er zijn twee soorten documenteigenschappen, namelijk:

- Systeem‑gedefinieerde (Built-in) eigenschappen
- Gebruiker‑gedefinieerde (Custom) eigenschappen

**Built-in**‑eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, de naam van de auteur, statistieken van het document, enzovoort. **Custom**‑eigenschappen zijn diegene die door de gebruiker worden gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel de naam als de waarde door de gebruiker worden opgegeven. Met Aspose.Slides for C++ kunnen ontwikkelaars zowel de waarden van ingebouwde eigenschappen als van aangepaste eigenschappen benaderen en wijzigen. Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentatiebestanden te beheren. Het enige wat u moet doen is op het Office‑pictogram te klikken en vervolgens **Prepare | Properties | Advanced Properties** te kiezen in Microsoft PowerPoint 2007. Nadat u **Advanced Properties** hebt geselecteerd, verschijnt een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren. In het **Properties Dialog** ziet u verschillende tabbladen zoals **General, Summary, Statistics, Contents and Custom**. Al deze tabbladen maken het mogelijk om verschillende soorten informatie met betrekking tot de PowerPoint‑bestanden te configureren. Het **Custom**‑tabblad wordt gebruikt om aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Ingebouwde eigenschappen benaderen**

Deze eigenschappen die door het **IDocumentProperties**‑object worden blootgesteld zijn onder andere: **Creator(Author)**, **Description**, **KeyWords**, **Created** (creatiedatum), **Modified** (wijzigingsdatum), **Printed** (laatste afdrukdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (is gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentatiebestanden is net zo eenvoudig als het benaderen ervan. U kunt eenvoudig een tekenreekswaarde toewijzen aan elke gewenste eigenschap en de eigenschap wordt aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van het presentatie‑bestand kunnen wijzigen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aspose.Slides for C++ stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Hieronder staat een voorbeeld dat laat zien hoe u aangepaste eigenschappen voor een presentatie kunt instellen.

``` cpp
// Instantieer de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();

// Documenteigenschappen ophalen
auto documentProperties = presentation->get_DocumentProperties();

// Aangepaste eigenschappen toevoegen
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Naam van eigenschap ophalen op specifieke index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Geselecteerde eigenschap verwijderen
documentProperties->RemoveCustomProperty(getPropertyName);

// Presentatie opslaan
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides for C++ maakt het ook mogelijk voor ontwikkelaars om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Controletaal instellen**

Aspose.Slides biedt de [LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/)‑eigenschap (beschikbaar via de [PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/)‑klasse) om de controletaal voor een PowerPoint‑document in te stellen. De controletaal is de taal waarvoor spelling en grammatica in de PowerPoint worden gecontroleerd.

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// stel de Id in van een controletaal

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standaardtaal instellen**

Deze C++‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie kunt instellen:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Voegt een nieuw rechthoekvorm met tekst toe
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Controleert de taal van de eerste portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑voorbeeld**

Probeer de online‑applicatie [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u via de Aspose.Slides‑API met documenteigenschappen kunt werken:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## ***FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie en kunnen niet volledig worden verwijderd. U kunt echter wel hun waarden wijzigen of, indien de betreffende eigenschap dit toestaat, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet eerst te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de presentatie volledig te laden?**

Ja, u kunt presentatie‑eigenschappen benaderen zonder de presentatie volledig te laden door de `GetPresentationInfo`‑methode van de [PresentationFactory](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentationfactory/)‑klasse te gebruiken. Vervolgens kunt u de `ReadDocumentProperties`‑methode van de [IPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/)‑interface gebruiken om de eigenschappen efficiënt te lezen, waardoor geheugen wordt bespaard en de prestaties verbeteren.