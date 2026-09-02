---
title: Anpassa PowerPoint-teckensnitt i C++
linktitle: Anpassat teckensnitt
type: docs
weight: 20
url: /sv/cpp/custom-font/
keywords:
- teckensnitt
- anpassat teckensnitt
- externt teckensnitt
- ladda teckensnitt
- hantera teckensnitt
- teckensnittsmapp
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Anpassa teckensnitt i PowerPoint-bilder med Aspose.Slides för C++ för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade teckensnitt i presentationer utan att installera dem på operativsystemet. Du kan ladda teckensnitt från anpassade mappar, tillhandahålla teckensnitt för en specifik presentation genom dokumentnivå‑teckensnittskällor, eller ladda externa teckensnitt direkt från binära data.

Laddade teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsresultatet konsekvent över olika miljöer. Artikeln förklarar också hur man granskar teckensnittsmapparna som används av Aspose.Slides och hur man rensar teckensnittscachet efter arbete med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är skild från inbäddning av teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd inbäddningsfunktionerna för teckensnitt explicit.

Ett presentationstema kan referera till olika teckensnittsfamiljer för enskilda skriftsystem. Dessa mappningar lagrar teckensnittsnamn men installerar eller laddar inte teckensnittsfilernna. Se [Script-Specific Theme Fonts](/slides/sv/cpp/script-specific-font-mappings/) för att hantera mappningarna, och använd laddningsalternativen nedan för att göra de refererade teckensnitten tillgängliga för konsekvent rendering.

{{% alert color="info" title="Obs" %}}
Aspose Slides låter dig ladda dessa teckensnitt med [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) och TrueType Collection (.ttc) teckensnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) teckensnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Ladda anpassade teckensnitt**

Aspose.Slides låter dig ladda teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportresultatet – till exempel PDF, bilder och andra stödda format – så de resulterande dokumenten ser konsekventa ut över olika miljöer. Teckensnitt laddas från anpassade kataloger.

1. Ange en eller flera mappar som innehåller teckensnittsfilerna.
2. Anropa den statiska metoden [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) för att ladda teckensnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/clearcache/) för att rensa teckensnittscachet.

Följande kodexempel demonstrerar processen för teckensnittsladdning:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Definiera mappar som innehåller anpassade teckensnittsfiler.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Ladda anpassade teckensnitt från de angivna mapparna.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa teckensnitten.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Rensa teckensnittscachet efter att arbetet är slutfört.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Obs" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) lägger till ytterligare mappar i teckensnittssökvägarna, men ändrar inte ordningen för teckensnittsinitialisering.
Teckensnitt initieras i följande ordning:

1. Operativsystemets standardteckensnittssökväg.
1. Sökvägar som laddats via [FontsLoader](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **Hämta anpassade teckensnittsmappar**

Aspose.Slides tillhandahåller [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/getfontfolders/) för att låta dig hitta teckensnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets teckensnittsmappar.

Denna C++‑kod visar hur du använder metoden [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Denna rad skriver ut mapparna som kontrolleras för teckensnittsfiler.
// Det är mappar som lagts till via LoadExternalFonts‑metoden och systemets teckensnittsmapp.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Ange anpassade teckensnitt som används med en presentation**

Aspose.Slides tillhandahåller egenskapen [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) för att låta dig ange externa teckensnitt som ska användas med presentationen.

Denna C++‑kod visar hur du använder egenskapen [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //arbeta med presentationen
    //CustomFont1, CustomFont2 samt teckensnitt från assets\fonts & global\fonts mappar och deras undermappar är tillgängliga för presentationen
}
```

## **Hantera teckensnitt externt**

Aspose.Slides tillhandahåller metoden [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfont/) för att låta dig ladda externa teckensnitt till en byte‑array.

Denna C++‑kod demonstrerar processen för att ladda teckensnitt från en byte‑array:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

### Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?

Ja. Anslutna teckensnitt används av renderaren för alla exportformat.

### Bäddas anpassade teckensnitt automatiskt in i den resulterande PPTX‑filen?

Nej. Att registrera ett teckensnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att teckensnittet finns i presentationsfilen måste du använda de explicita [inbäddningsfunktioner](/slides/sv/cpp/embedded-font/).

### Kan jag kontrollera fallback‑beteende när ett anpassat teckensnitt saknar vissa tecken?

Ja. Konfigurera [font substitution](/slides/sv/cpp/font-substitution/), [replacement rules](/slides/sv/cpp/font-replacement/), och [fallback sets](/slides/sv/cpp/fallback-font/) för att exakt ange vilket teckensnitt som används när den begärda glyphen saknas.

### Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?

Ja. Peka på dina egna teckensnittsmappar eller ladda teckensnitt från byte‑arrayer. Detta tar bort alla beroenden av systemets teckensnittskataloger i container‑avbilden.

### Hur är det med licensiering—kan jag bädda in vilket anpassat teckensnitt som helst utan restriktioner?

Du är ansvarig för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar resultat.