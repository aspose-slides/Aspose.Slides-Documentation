---
title: Bädda in teckensnitt i presentationer med C++
linktitle: Inbäddning av teckensnitt
type: docs
weight: 40
url: /sv/cpp/embedded-font/
keywords:
- lägg till teckensnitt
- bädda in teckensnitt
- teckensnitts-inbäddning
- hämta inbäddat teckensnitt
- lägga till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Bädda in TrueType-teckensnitt i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++, så att rendering blir exakt på alla plattformar."
---
## **Introduktion**

**Inbäddade teckensnitt i PowerPoint** hjälper till att säkerställa att din presentation behåller sitt avsedda utseende när den öppnas på vilken system eller enhet som helst. Detta är särskilt viktigt när du använder anpassade, tredjeparts‑ eller icke‑standardiserade teckensnitt för varumärkes‑ eller kreativa ändamål. Utan inbäddade teckensnitt kan text ersättas, layouter gå sönder och tecken visas som oläsliga symboler eller rektanglar, vilket äventyrar den övergripande designen.

Aspose.Slides for C++ tillhandahåller en uppsättning kraftfulla API:er för att hantera inbäddade teckensnitt programmässigt. Du kan använda [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/) och [FontData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontdata/)‑klasserna för att inspektera, lägga till eller ta bort inbäddade teckensnitt i dina presentationsfiler. Dessutom gör [Compress](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/)‑klassen det möjligt att optimera filstorleken genom att komprimera teckensnittsdatan utan att påverka kvalitet eller utseende.

Dessa verktyg ger dig full kontroll över teckensnitts‑inbäddning och hjälper dig att upprätthålla enhetlig typografi över plattformar samtidigt som du minskar filstorleken vid behov.

## **Hämta inbäddade teckensnitt från en presentation**

Aspose.Slides for C++ tillhandahåller metoden `GetEmbeddedFonts` via [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/)‑klassen, som låter dig hämta en lista över teckensnitt som är inbäddade i en PowerPoint‑presentation. Detta kan vara användbart för att granska teckensnittsbruk, säkerställa efterlevnad av varumärkesriktlinjer eller verifiera att alla nödvändiga teckensnitt är korrekt inkluderade innan filen delas.

Följande C++‑kod demonstrerar hur du hämtar inbäddade teckensnitt från en presentationsfil:

```cpp
// Skapa ett Presentation-objekt som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Hämta alla inbäddade teckensnitt.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Skriv ut namnen på de inbäddade teckensnitten.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Lägg till inbäddade teckensnitt i en presentation**

Aspose.Slides for C++ låter dig bädda in teckensnitt i en PowerPoint‑presentation med hjälp av metoden [AddEmbeddedFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/addembeddedfont/), som har två överlagringar för flexibel användning. Du kan styra hur mycket av teckensnittet som inbäddas genom att använda uppräkningen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/embedfontcharacters/) — till exempel genom att bara bädda in använda tecken eller hela teckensnittssamlingen. Denna funktion är särskilt användbar när du förbereder en presentation för delning eller distribution, så att anpassade eller icke‑standardiserade teckensnitt visas korrekt på alla system, även om teckensnitten inte är installerade.

Följande C++‑kod kontrollerar alla teckensnitt som används i en presentation och bäddar in de teckensnitt som ännu inte är inbäddade.

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

    // Kontrollera om teckensnittet redan är inbäddat.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Bädda in teckensnittet i presentationen.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Spara presentationen till disk.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ta bort inbäddade teckensnitt från en presentation**

Aspose.Slides for C++ tillhandahåller metoden `RemoveEmbeddedFont` via [FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/)‑klassen, som gör det möjligt att ta bort specifika teckensnitt som är inbäddade i en PowerPoint‑presentation. Detta kan hjälpa till att minska den totala filstorleken, särskilt om de inbäddade teckensnitten inte längre används eller behövs. Att ta bort oanvända teckensnitt kan också förbättra prestanda och säkerställa att presentationen endast innehåller nödvändiga resurser.

Följande C++‑kod demonstrerar hur du tar bort ett inbäddat teckensnitt från en presentation:

```cpp
auto fontName = u"Calibri";

// Instansiera Presentation-klassen som representerar en presentationsfil.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Hämta alla inbäddade teckensnitt.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Ta bort det inbäddade teckensnittet.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Komprimera inbäddade teckensnitt**

Aspose.Slides for C++ tillhandahåller metoden `CompressEmbeddedFonts` via [Compress](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/)‑klassen, vilket låter dig minska den totala filstorleken på en presentation genom att optimera den inbäddade teckensnittsdatan. Detta är särskilt användbart när presentationen innehåller stora eller flera teckensnitt och du vill hålla filen lätt för delning, lagring eller online‑användning — utan att kompromissa med den visuella noggrannheten i innehållet.

Följande C++‑kod demonstrerar hur du komprimerar inbäddade teckensnitt i en PowerPoint‑presentation:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Hur kan jag se att ett specifikt teckensnitt i presentationen fortfarande kommer att ersättas vid rendering trots inbäddning?**

Kontrollera [information om ersättning](/slides/sv/cpp/font-substitution/) i teckensnittshanteraren och [fallback‑/ersättningsregler](/slides/sv/cpp/fallback-font/): om teckensnittet är otillgängligt eller begränsat, kommer en reserv att användas.

**Är det värt att bädda in "system"-teckensnitt som Arial/Calibri?**

Vanligtvis nej—de är nästan alltid tillgängliga. Men för full portabilitet i "tunna" miljöer (Docker, en Linux‑server utan förinstallerade teckensnitt) kan inbäddning av systemteckensnitt eliminera risken för oväntade ersättningar.