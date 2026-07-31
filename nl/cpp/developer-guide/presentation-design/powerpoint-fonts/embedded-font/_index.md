---
title: Lettertypen insluiten in presentaties met C++
linktitle: Lettertype insluiten
type: docs
weight: 40
url: /nl/cpp/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- insluiten van lettertype
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Sluit TrueType-lettertypen in PowerPoint- en OpenDocument-presentaties in met Aspose.Slides voor C++, zodat ze op alle platformen nauwkeurig worden weergegeven."
---
## **Inleiding**

**Ingesloten lettertypen in PowerPoint** helpen ervoor te zorgen dat uw presentatie zijn beoogde uiterlijk behoudt wanneer deze op elk systeem of apparaat wordt geopend. Dit is vooral belangrijk bij het gebruik van aangepaste, derden‑ of niet‑standaard lettertypen voor branding of creatieve doeleinden. Zonder ingesloten lettertypen kan tekst worden vervangen, lay‑outs kunnen breken en kunnen tekens verschijnen als onleesbare symbolen of rechthoeken, wat het algehele ontwerp ondermijnt.

Aspose.Slides for C++ biedt een reeks krachtige API’s om ingesloten lettertypen programmatisch te beheren. U kunt de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/)‑ en [FontData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontdata/)‑klassen gebruiken om ingesloten lettertypen in uw presentatie‑bestanden te inspecteren, toe te voegen of te verwijderen. Bovendien maakt de [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/)‑klasse het mogelijk de bestandsgrootte te optimaliseren door lettertype‑data te comprimeren zonder invloed op kwaliteit of uiterlijk.

Deze hulpmiddelen geven u volledige controle over het insluiten van lettertypen, zodat u consistente typografie over verschillende platformen kunt behouden en tegelijkertijd de bestandsgrootte kunt verkleinen wanneer dat nodig is.

## **Ingesloten lettertypen ophalen uit een presentatie**

Aspose.Slides for C++ biedt de `GetEmbeddedFonts`‑methode via de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/)‑klasse, waarmee u een lijst kunt ophalen van lettertypen die in een PowerPoint‑presentatie zijn ingesloten. Dit kan nuttig zijn voor het auditen van lettertype‑gebruik, het waarborgen van naleving van branding‑richtlijnen, of het verifiëren dat alle benodigde lettertypen correct zijn opgenomen voordat het bestand wordt gedeeld.

De volgende C++‑code laat zien hoe u ingesloten lettertypen uit een presentatiebestand kunt ophalen:

```cpp
// Instantieer de Presentation-klasse die een presentatiedocument voorstelt.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Print names of the embedded fonts.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Ingesloten lettertypen toevoegen aan een presentatie**

Aspose.Slides for C++ stelt u in staat om lettertypen in een PowerPoint‑presentatie in te sluiten met de [AddEmbeddedFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/addembeddedfont/)‑methode, die twee overloads biedt voor flexibel gebruik. U kunt bepalen hoeveel van het lettertype wordt ingesloten door gebruik te maken van de [EmbedFontCharacters](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/embedfontcharacters/)‑enumeratie — bijvoorbeeld door alleen de gebruikte tekens of de volledige lettertype‑set in te sluiten. Deze functie is vooral handig bij het voorbereiden van een presentatie voor distributie, zodat aangepaste of niet‑standaard lettertypen correct verschijnen op alle systemen, zelfs als die lettertypen niet geïnstalleerd zijn.

De volgende C++‑code controleert alle lettertypen die in een presentatie worden gebruikt en sluit alle lettertypen in die nog niet zijn ingesloten.

```cpp
// Laad een presentatiebestand.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Controleer of het lettertype al is ingesloten.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Sluit het lettertype in de presentatie in.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Sla de presentatie op naar schijf.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ingesloten lettertypen verwijderen uit een presentatie**

Aspose.Slides for C++ biedt de `RemoveEmbeddedFont`‑methode via de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/)‑klasse, waarmee u specifieke ingesloten lettertypen uit een PowerPoint‑presentatie kunt verwijderen. Dit kan helpen de algehele bestandsgrootte te verminderen, vooral als de ingesloten lettertypen niet meer worden gebruikt of niet meer nodig zijn. Het verwijderen van ongebruikte lettertypen kan bovendien de prestaties verbeteren en ervoor zorgen dat uw presentatie alleen de essentiële bronnen bevat.

De volgende C++‑code laat zien hoe u een ingesloten lettertype uit een presentatie kunt verwijderen:

```cpp
auto fontName = u"Calibri";

// Instantieer de Presentation-klasse die een presentatiedocument voorstelt.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Haalt alle ingesloten lettertypen op.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Verwijder het ingesloten lettertype.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Ingesloten lettertypen comprimeren**

Aspose.Slides for C++ biedt de `CompressEmbeddedFonts`‑methode via de [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/)‑klasse, waarmee u de totale bestandsgrootte van een presentatie kunt verkleinen door de ingesloten lettertype‑data te optimaliseren. Dit is bijzonder nuttig wanneer uw presentatie grote of meerdere lettertypen bevat en u het bestand lichtgewicht wilt houden voor delen, opslag of online gebruik — zonder concessies te doen aan de visuele getrouwheid van de inhoud.

De volgende C++‑code laat zien hoe u ingesloten lettertypen in een PowerPoint‑presentatie kunt comprimeren:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Hoe kan ik zien dat een specifiek lettertype in de presentatie toch wordt vervangen tijdens het renderen ondanks het insluiten?**

Controleer de [substitution information](/slides/nl/cpp/font-substitution/) in de font‑manager en de [fallback/substitution rules](/slides/nl/cpp/fallback-font/): als het lettertype niet beschikbaar of beperkt is, wordt er een fallback‑lettertype gebruikt.

**Is het de moeite waard om “systeem‑lettertypen” zoals Arial/Calibri in te sluiten?**

Meestal niet — ze zijn bijna overal beschikbaar. Maar voor volledige draagbaarheid in “dunne” omgevingen (Docker, een Linux‑server zonder vooraf geïnstalleerde lettertypen) kan het insluiten van systeem‑lettertypen het risico op onverwachte substituties wegnemen.