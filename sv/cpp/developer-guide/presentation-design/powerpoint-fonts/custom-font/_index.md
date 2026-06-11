---
title: Anpassa PowerPoint-typsnitt i C++
linktitle: Anpassat typsnitt
type: docs
weight: 20
url: /sv/cpp/custom-font/
keywords:
- typsnitt
- anpassat typsnitt
- externt typsnitt
- ladda typsnitt
- hantera typsnitt
- typsnittsmapp
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Anpassa typsnitt i PowerPoint-bilder med Aspose.Slides för C++ så att dina presentationer blir skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade typsnitt i presentationer utan att installera dem på operativsystemet. Du kan läsa in typsnitt från anpassade mappar, tillhandahålla typsnitt för en specifik presentation via dokumentnivå‑typsnittskällor, eller läsa in externa typsnitt direkt från binära data.

Inlästa typsnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationens utdata konsekvent över olika miljöer. Artikeln förklarar också hur du inspekterar de typsnittsmappar som används av Aspose.Slides och hur du rensar typsnittscacheminnet efter att ha arbetat med externa typsnitt.

Registrering av anpassade typsnitt för rendering är separat från att bädda in typsnitt i en PPTX‑fil. Om ett typsnitt måste lagras i själva presentationen, använd typsnitts‑inbäddningsfunktionerna explicit.

{{% alert color="primary" %}} 
Aspose Slides låter dig läsa in dessa typsnitt med hjälp av [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType‑typsnitt (.ttf) och TrueType Collection‑typsnitt (.ttc). Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑typsnitt (.otf). Se [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Ladda anpassade typsnitt**

Aspose.Slides låter dig läsa in typsnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata—såsom PDF, bilder och andra stödda format—så att de resulterande dokumenten ser likadana ut i olika miljöer. Typsnitt läses in från anpassade kataloger.

1. Ange en eller flera mappar som innehåller typsnittsfilerna.
2. Anropa den statiska metoden [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) för att läsa in typsnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/clearcache/) för att rensa typsnittscache.

Följande kodexempel visar hur typsnitts‑laddning fungerar:

```cpp
// Definiera mappar som innehåller anpassade typsnittsfiler.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Ladda anpassade typsnitt från de angivna mapparna.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa typsnitten.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Rensa typsnittscache efter att arbetet är klart.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Obs" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) lägger till extra mappar i typsnittssökvägarna, men ändrar inte ordningen för typsnittsinitialisering. Typsnitt initieras i följande ordning:

1. Operativsystemets standardtypsnittssökväg.
2. Sökvägarna som läses in via [FontsLoader](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **Hämta anpassade typsnittsmappar**
Aspose.Slides tillhandahåller [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/getfontfolders/) för att låta dig hitta typsnittsmappar. Denna metod returnerar mappar som lagts till genom `LoadExternalFonts`‑metoden samt systemets typsnittsmappar.

Denna C++‑kod visar hur du använder metoden [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// Den här raden skriver ut de mappar som kontrolleras för typsnittsfiler.
// Det är mappar som lagts till via LoadExternalFonts-metoden och systemets typsnittsmapp.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Ange anpassade typsnitt som används med en presentation**
Aspose.Slides tillhandahåller egenskapen [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) för att låta dig ange externa typsnitt som ska användas med presentationen.

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
    //CustomFont1, CustomFont2 samt typsnitt från mapparna assets\fonts & global\fonts och deras undermappar är tillgängliga för presentationen
}
```

## **Hantera typsnitt externt**
Aspose.Slides tillhandahåller metoden [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfont/) för att låta dig läsa in externa typsnitt i en byte‑array.

Denna C++‑kod demonstrerar hur byte‑array‑typsnitts‑laddning fungerar:

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

## **FAQ**

**Påverkar anpassade typsnitt export till alla format (PDF, PNG, SVG, HTML)?**

Ja. Anslutna typsnitt används av renderaren för alla exportformat.

**Bäddas anpassade typsnitt automatiskt in i den resulterande PPTX‑filen?**

Nej. Att registrera ett typsnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att typsnittet finns i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/cpp/embedded-font/).

**Kan jag kontrollera fallback‑beteendet när ett anpassat typsnitt saknar vissa tecken?**

Ja. Konfigurera [font substitution](/slides/sv/cpp/font-substitution/), [replacement rules](/slides/sv/cpp/font-replacement/) och [fallback sets](/slides/sv/cpp/fallback-font/) för att exakt ange vilket typsnitt som används när den begärda tecknet saknas.

**Kan jag använda typsnitt i Linux/Docker‑containrar utan att installera dem systemomfattande?**

Ja. Peka på dina egna typsnittsmappar eller läs in typsnitt från byte‑arrayer. Detta tar bort alla beroenden på systemets typsnittskataloger i container‑avbilden.

**Hur är det med licensiering — kan jag bädda in valfritt anpassat typsnitt utan restriktioner?**

Du ansvarar för att följa typsnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid typsnittets EULA innan du distribuerar resultat.