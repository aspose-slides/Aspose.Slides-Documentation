---
title: Inbädda typsnitt i presentationer med C++
linktitle: Inbäddning av typsnitt
type: docs
weight: 40
url: /sv/cpp/embedded-font/
keywords:
- lägga till typsnitt
- bädda in typsnitt
- typsnitts inbäddning
- hämta inbäddat typsnitt
- lägga till inbäddat typsnitt
- ta bort inbäddat typsnitt
- komprimera inbäddat typsnitt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Bädda in TrueType-typsnitt i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++, så att rendering blir exakt på alla plattformar."
---
## **Introduktion**

**Inbäddade typsnitt i PowerPoint** hjälper till att säkerställa att din presentation behåller sitt avsedda utseende när den öppnas på valfritt system eller enhet. Detta är särskilt viktigt när du använder anpassade, tredjeparts‑ eller icke‑standardtypsnitt för varumärkes‑ eller kreativa ändamål. Utan inbäddade typsnitt kan text ersättas, layouter gå sönder och tecken visas som oläsliga symboler eller rektanglar, vilket äventyrar den övergripande designen.

Aspose.Slides för C++ tillhandahåller ett kraftfullt API för att hantera inbäddade typsnitt programmatically. Du kan använda klasserna [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/) och [FontData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontdata/) för att inspektera, lägga till eller ta bort inbäddade typsnitt i dina presentationsfiler. Dessutom låter klassen [Compress](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/) dig optimera filstorleken genom att komprimera typsnittsdata utan att påverka kvalitet eller utseende.

Dessa verktyg ger dig full kontroll över typsnitts­inbäddning och hjälper dig att behålla enhetlig typografi över plattformar samtidigt som du kan minska filstorleken vid behov.

## **Hämta inbäddade typsnitt från en presentation**

Aspose.Slides för C++ tillhandahåller metoden `GetEmbeddedFonts` via klassen [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/), som låter dig hämta en lista över typsnitt som är inbäddade i en PowerPoint‑presentation. Detta kan vara användbart för att granska typsnittsbruk, säkerställa efterlevnad av varumärkesriktlinjer eller verifiera att alla nödvändiga typsnitt är korrekt inkluderade innan filen delas.

Följande C++‑kod visar hur du hämtar inbäddade typsnitt från en presentationsfil:

```cpp
// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Hämta alla inbäddade typsnitt.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Skriv ut namn på de inbäddade typsnitten.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Lägg till inbäddade typsnitt i en presentation**

Aspose.Slides för C++ gör det möjligt att bädda in typsnitt i en PowerPoint‑presentation med metoden [AddEmbeddedFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/addembeddedfont/), som har två överlagringar för flexibel användning. Du kan styra hur mycket av typsnittet som bäddas in genom att använda uppräkningen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/embedfontcharacters/) — till exempel genom att bara bädda in använda tecken eller hela teckensnittssatsen. Denna funktion är särskilt användbar när du förbereder en presentation för delning eller distribution, så att anpassade eller icke‑standardtypsnitt visas korrekt på alla system, även om dessa typsnitt inte är installerade.

Följande C++‑kod kontrollerar alla typsnitt som används i en presentation och bäddar in eventuella typsnitt som ännu inte är inbäddade.

```cpp
// Läs in en presentationsfil.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Kontrollera om typsnittet redan är inbäddat.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Bädda in typsnittet i presentationen.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Spara presentationen till disk.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ta bort inbäddade typsnitt från en presentation**

Aspose.Slides för C++ tillhandahåller metoden `RemoveEmbeddedFont` via klassen [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/), som låter dig ta bort specifika typsnitt som är inbäddade i en PowerPoint‑presentation. Detta kan hjälpa till att minska den totala filstorleken, särskilt om de inbäddade typsnitten inte längre används eller behövs. Att ta bort oanvända typsnitt kan också förbättra prestanda och säkerställa att din presentation endast innehåller nödvändiga resurser.

Följande C++‑kod visar hur du tar bort ett inbäddat typsnitt från en presentation:

```cpp
auto fontName = u"Calibri";

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Hämta alla inbäddade typsnitt.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Ta bort det inbäddade typsnittet.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Komprimera inbäddade typsnitt**

Aspose.Slides för C++ erbjuder metoden `CompressEmbeddedFonts` via klassen [Compress](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/), vilket låter dig minska den totala filstorleken för en presentation genom att optimera de inbäddade typsnittsdatan. Detta är särskilt användbart när din presentation innehåller stora eller flera typsnitt och du vill hålla filen lättviktig för delning, lagring eller online‑användning — utan att kompromissa med den visuella kvaliteten.

Följande C++‑kod demonstrerar hur du komprimerar inbäddade typsnitt i en PowerPoint‑presentation:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vanliga frågor**

**Hur kan jag avgöra om ett specifikt typsnitt i presentationen ändå kommer att ersättas vid rendering trots inbäddning?**

Kontrollera [information om ersättning](/slides/sv/cpp/font-substitution/) i typsnittshanteraren och [regler för reserv/ersättning](/slides/sv/cpp/fallback-font/): om typsnittet är otillgängligt eller begränsat används en reserv.

**Lönar det sig att bädda in "system"-typsnitt som Arial/Calibri?**

Vanligtvis nej — de är i princip alltid tillgängliga. Men för full portabilitet i “tunna” miljöer (Docker, en Linux‑server utan förinstallerade typsnitt) kan inbäddning av systemtypsnitt eliminera risken för oväntade ersättningar.