---
title: Lettertypen insluiten in presentaties met С++
linktitle: Lettertype insluiten
type: docs
weight: 40
url: /nl/cpp/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- lettertype insluiting
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- OpenDocument
- presentatie
- С++
- Aspose.Slides
description: "Insluit TrueType-lettertypen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor С++, zodat ze nauwkeurig worden weergegeven op alle platformen."
---
## **Inleiding**

**Embedded lettertypen in PowerPoint** zorgen ervoor dat uw presentatie er op elk systeem of apparaat blijft uitzien zoals bedoeld. Dit is vooral belangrijk bij het gebruik van aangepaste, externe of niet‑standaard lettertypen voor branding of creatieve doeleinden. Zonder embedded lettertypen kan tekst worden vervangen, kan de lay-out breken en kunnen tekens verschijnen als onleesbare symbolen of rechthoeken, waardoor het ontwerp wordt aangetast.

Aspose.Slides for C++ biedt een reeks krachtige API’s om embedded lettertypen programmatisch te beheren. U kunt de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/) en [FontData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontdata/) klassen gebruiken om embedded lettertypen in uw presentatiebestanden te inspecteren, toe te voegen of te verwijderen. Bovendien maakt de [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/) klasse het mogelijk om de bestandsgrootte te optimaliseren door lettertype‑data te comprimeren zonder kwaliteits‑ of weergaveverlies.

Met deze tools heeft u volledige controle over het insluiten van lettertypen, waardoor u consistente typografie over platformen heen kunt behouden en desgewenst de bestandsgrootte kunt verkleinen.

## **Embedded lettertypen ophalen uit een presentatie**

Aspose.Slides for C++ levert de `GetEmbeddedFonts`‑methode via de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/) klasse, waarmee u een lijst kunt ophalen van lettertypen die in een PowerPoint‑presentatie zijn ingebed. Dit is handig voor het controleren van lettertype‑gebruik, het waarborgen van naleving van merk‑richtlijnen, of het verifiëren dat alle benodigde lettertypen correct zijn opgenomen voordat u het bestand deelt.

De volgende C++‑code laat zien hoe u embedded lettertypen uit een presentatiebestand haalt:

```cpp
// Initialiseer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Haal alle ingesloten lettertypen op.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Print de namen van de ingesloten lettertypen.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Embedded lettertypen toevoegen aan een presentatie**

Aspose.Slides for C++ maakt het mogelijk om lettertypen in te sluiten in een PowerPoint‑presentatie via de [AddEmbeddedFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/addembeddedfont/) methode, die twee overloads biedt voor flexibel gebruik. U kunt bepalen hoeveel van het lettertype wordt ingesloten met de [EmbedFontCharacters](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/embedfontcharacters/) enumeratie — bijvoorbeeld alleen de gebruikte tekens of de volledige lettertype‑set. Deze functie is vooral nuttig bij het voorbereiden van een presentatie voor distributie, zodat aangepaste of niet‑standaard lettertypen correct worden weergegeven op alle systemen, zelfs wanneer die lettertypen niet geïnstalleerd zijn.

De volgende C++‑code controleert alle lettertypen die in een presentatie worden gebruikt en sluit eventuele lettertypen in die nog niet ingebed zijn.

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

## **Embedded lettertypen verwijderen uit een presentatie**

Aspose.Slides for C++ biedt de `RemoveEmbeddedFont`‑methode via de [FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/) klasse, waarmee u specifieke embedded lettertypen uit een PowerPoint‑presentatie kunt verwijderen. Dit kan helpen de bestandsgrootte te verkleinen, vooral wanneer de ingebedde lettertypen niet meer worden gebruikt of nodig zijn. Het verwijderen van ongebruikte lettertypen kan ook de prestaties verbeteren en ervoor zorgen dat uw presentatie alleen essentiële bronnen bevat.

De volgende C++‑code laat zien hoe u een embedded lettertype uit een presentatie verwijdert:

```cpp
auto fontName = u"Calibri";

// Initialiseer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Haal alle ingesloten lettertypen op.
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

## **Embedded lettertypen comprimeren**

Aspose.Slides for C++ levert de `CompressEmbeddedFonts`‑methode via de [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/) klasse, waarmee u de totale bestandsgrootte van een presentatie kunt verkleinen door de embedded lettertype‑data te optimaliseren. Dit is vooral nuttig wanneer uw presentatie grote of meerdere lettertypen bevat en u het bestand lichtgewicht wilt houden voor delen, opslag of online gebruik — zonder concessies te doen aan de visuele getrouwheid van de inhoud.

De volgende C++‑code demonstreert hoe u embedded lettertypen in een PowerPoint‑presentatie comprimeert:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Hoe kan ik zien dat een bepaald lettertype in de presentatie toch wordt vervangen tijdens het renderen ondanks het insluiten?**

Controleer de [substitutie‑informatie](/slides/nl/cpp/font-substitution/) in de font‑manager en de [fallback/substitutieregels](/slides/nl/cpp/fallback-font/): als het lettertype niet beschikbaar of beperkt is, wordt er een fallback gebruikt.

**Is het de moeite waard om “systeem”‑lettertypen zoals Arial/Calibri in te sluiten?**

Meestal niet — ze zijn bijna overal beschikbaar. Maar voor volledige portabiliteit in “dunne” omgevingen (Docker, een Linux‑server zonder vooraf geïnstalleerde lettertypen) kan het insluiten van systeemlettertypen het risico op onverwachte substituties wegnemen.