---
title: "Anpassa PowerPoint-typsnitt i C++"
linktitle: "Anpassat typsnitt"
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
description: "Anpassa typsnitt i PowerPoint-bilder med Aspose.Slides för C++ för att hålla dina presentationer tydliga och konsekventa på vilken enhet som helst."
---
## **Översikt**

Aspose.Slides gör det möjligt att använda anpassade typsnitt i presentationer utan att installera dem på operativsystemet. Du kan ladda typsnitt från egna mappar, tillhandahålla typsnitt för en specifik presentation via dokumentnivå‑typsnittskällor, eller ladda externa typsnitt direkt från binär data.

Laddade typsnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdata konsekvent över olika miljöer. Artikeln förklarar också hur du inspekterar typsnittsmapparna som används av Aspose.Slides och hur du rensar typsnittscachen efter arbete med externa typsnitt.

Registrering av anpassade typsnitt för rendering är separat från inbäddning av typsnitt i en PPTX‑fil. Om ett typsnitt måste lagras i själva presentationen, använd funktionerna för typsnitts­inbäddning explicit.

{{% alert color="info" %}} 

Aspose Slides låter dig ladda dessa typsnitt med hjälp av [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) och TrueType Collection (.ttc) typsnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) typsnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ladda anpassade typsnitt**

Aspose.Slides låter dig ladda typsnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata — såsom PDF, bilder och andra stödda format — så att de resulterande dokumenten ser lika ut i olika miljöer. Typsnitt laddas från anpassade kataloger.

1. Ange en eller flera mappar som innehåller typsnittsfilerna.
2. Anropa den statiska [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) metoden för att ladda typsnitt från dessa mappar.
3. Ladda och rendera/exportera presentationen.
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/clearcache/) för att rensa typsnittscachen.

Följande kodexempel demonstrerar processen för att ladda typsnitt:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Definiera mappar som innehåller anpassade typsnitts-filer.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Ladda anpassade typsnitt från de specificerade mapparna.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa typsnitten.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Rensa typsnitts‑cachen när arbetet är klart.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Obs" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfonts/) lägger till extra mappar i typsnittssökvägarna, men ändrar inte ordningen för typsnittsinitialisering. Typsnitt initialiseras i följande ordning:

1. Systemets standard‑typsnittssökväg.
1. Sökvägar som laddats via [FontsLoader](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Hämta anpassade typsnittsmappor**
Aspose.Slides tillhandahåller [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/getfontfolders/) för att låta dig hitta typsnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets typsnittsmappar.

Denna C++‑kod visar hur du använder [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/getfontfolders/)‑metoden:

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Den här raden skriver ut mapparna som kontrolleras för typsnitts-filer.
// Det är mappar som lagts till via LoadExternalFonts-metoden och systemets typsnittsmapp.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Ange anpassade typsnitt som används i en presentation**
Aspose.Slides tillhandahåller egenskapen [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) för att låta dig ange externa typsnitt som ska användas med presentationen.

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
    //Arbeta med presentationen
    //CustomFont1, CustomFont2 samt typsnitt från mapparna assets\fonts & global\fonts och deras underkataloger är tillgängliga för presentationen
}
```

## **Hantera typsnitt externt**
Aspose.Slides tillhandahåller metoden [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/loadexternalfont/) för att låta dig ladda externa typsnitt till en byte‑array.

Denna C++‑kod demonstrerar processen för att ladda typsnitt till en byte‑array:

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

## **Vanliga frågor**

### Påverkar anpassade typsnitt export till alla format (PDF, PNG, SVG, HTML)?

Ja. Anslutna typsnitt används av renderaren för alla exportformat.

### Bäddas anpassade typsnitt automatiskt i den resulterande PPTX‑filen?

Nej. Att registrera ett typsnitt för rendering är inte samma sak som att bädda in det i en PPTX. Om du behöver att typsnittet ska finnas i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/cpp/embedded-font/).

### Kan jag kontrollera fallback‑beteendet när ett anpassat typsnitt saknar vissa tecken?

Ja. Konfigurera [font substitution](/slides/sv/cpp/font-substitution/), [replacement rules](/slides/sv/cpp/font-replacement/) och [fallback sets](/slides/sv/cpp/fallback-font/) för att exakt ange vilket typsnitt som ska användas när den begärda glyphen saknas.

### Kan jag använda typsnitt i Linux/Docker‑containrar utan att installera dem systemomfattande?

Ja. Peka på dina egna typsnittsmappar eller ladda typsnitt från byte‑arrayer. Detta tar bort beroendet av systemets typsnittskataloger i containermiljön.

### Vad gäller licensiering—kan jag bädda in vilket anpassat typsnitt som helst utan restriktioner?

Du ansvarar för att följa typsnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid typsnittets EULA innan du distribuerar resultat.