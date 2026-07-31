---
title: Anpassa PowerPoint‑teckensnitt i C++
linktitle: Anpassat teckensnitt
type: docs
weight: 20
url: /sv/cpp/custom-font/
keywords:
- teckensnitt
- anpassat teckensnitt
- externt teckensnitt
- läs in teckensnitt
- hantera teckensnitt
- teckensnittsmapp
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Anpassa teckensnitt i PowerPoint‑bilder med Aspose.Slides för C++ för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade teckensnitt i presentationer utan att installera dem på operativsystemet. Du kan läsa in teckensnitt från egna mappar, tillhandahålla teckensnitt för en specifik presentation via dokumentnivå‑teckensnittskällor, eller läsa in externa teckensnitt direkt från binära data.

Inlästa teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdataen konsekvent över olika miljöer. Artikeln förklarar också hur du granskar de teckensnittsmappar som Aspose.Slides använder och hur du rensar teckensnittscachen efter att ha arbetat med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är separat från att bädda in teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd teckensnittsbäddningsfunktionerna explicit.

{{% alert color="primary" %}} 
Aspose Slides låter dig läsa in dessa teckensnitt med hjälp av [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) och TrueType Collection (.ttc) teckensnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) teckensnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Läs in anpassade teckensnitt**

Aspose.Slides låter dig läsa in teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata — som PDF, bilder och andra stödda format — så de resulterande dokumenten ser konsekventa ut över olika miljöer. Teckensnitt läses in från anpassade kataloger.

1. Ange en eller flera mappar som innehåller teckensnitts‑filerna.  
2. Anropa den statiska metoden [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) för att läsa in teckensnitt från dessa mappar.  
3. Läs in och rendera/exportera presentationen.  
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/clearcache/) för att rensa teckensnittscachen.

Följande kodexempel visar teckensnitts‑inläsningsprocessen:

```cpp
// Definiera mappar som innehåller anpassade teckensnittsfiler.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Läs in anpassade teckensnitt från de angivna mapparna.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa teckensnitten.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Rensa teckensnittscachen efter att arbetet är slutfört.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) lägger till ytterligare mappar till teckensnittets sökvägar, men ändrar inte ordningen för teckensnittsinialisering.  
Teckensnitt initieras i följande ordning:

1. Den standardoperativsystemets teckensnittssökväg.  
1. Sökvägarna som laddas via [FontsLoader](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Hämta anpassade teckensnittsmappar**
Aspose.Slides tillhandahåller [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/getfontfolders/) för att låta dig hitta teckensnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets teckensnittsmappar.

Denna C++‑kod visar hur du använder [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/getfontfolders/) metoden:

``` cpp
// Den här raden skriver ut mapparna som kontrolleras för teckensnittsfiler.
// Det är mappar som lagts till via LoadExternalFonts‑metoden och systemets teckensnittsmapp.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Ange anpassade teckensnitt som används med en presentation**
Aspose.Slides tillhandahåller egenskapen [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) för att låta dig ange externa teckensnitt som ska användas med presentationen.

Denna C++‑kod visar hur du använder egenskapen [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //arbeta med presentationen
    //CustomFont1, CustomFont2 samt teckensnitt från assets\fonts & global\fonts samt deras undermappar är tillgängliga för presentationen
}
```

## **Hantera teckensnitt externt**
Aspose.Slides tillhandahåller metoden [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfont/) för att låta dig läsa in externa teckensnitt i en byte‑array.

Denna C++‑kod demonstrerar processen för inläsning av teckensnitt som byte‑array:

```cpp
// Sökvägen till dokumentkatalogen
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **Vanliga frågor**

**Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?**

Ja. Anslutna teckensnitt används av renderaren i alla exportformat.

**Bäddas anpassade teckensnitt automatiskt i den resulterande PPTX‑filen?**

Nej. Att registrera ett teckensnitt för rendering är inte samma sak som att bädda in det i en PPTX. Om du behöver att teckensnittet finns i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/cpp/embedded-font/).

**Kan jag styra fallback‑beteende när ett anpassat teckensnitt saknar vissa tecken?**

Ja. Konfigurera [teckensnittssubstitution](/slides/sv/cpp/font-substitution/), [ersättningsregler](/slides/sv/cpp/font-replacement/) och [fallback‑uppsättningar](/slides/sv/cpp/fallback-font/) för att exakt ange vilket teckensnitt som ska användas när den begärda glyphen saknas.

**Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?**

Ja. Peka på dina egna teckensnittsmappar eller läs in teckensnitt från byte‑arrays. Detta tar bort beroendet av systemteckensnittskataloger i container‑avbilden.

**Hur är det med licensiering—kan jag bädda in valfritt anpassat teckensnitt utan restriktioner?**

Du är ansvarig för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets licensavtal (EULA) innan du distribuerar resultat.