---
title: Anpassa PowerPoint-teckensnitt i JavaScript
linktitle: Anpassat teckensnitt
type: docs
weight: 20
url: /sv/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Anpassa teckensnitt i PowerPoint‑bilder med JavaScript och Aspose.Slides för Node.js via Java för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides gör det möjligt att använda anpassade teckensnitt i presentationer utan att installera dem på operativsystemet. Du kan läsa in teckensnitt från egna mappar, tillhandahålla teckensnitt för en specifik presentation via dokumentnivå‑teckensnittskällor, eller läsa in externa teckensnitt direkt från binär data.

Inlästa teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödjade format. Detta hjälper till att hålla presentationsresultatet konsistent i olika miljöer. Artikeln beskriver också hur du granskar teckensnittsmapparna som Aspose.Slides använder och hur du rensar teckensnittscache efter arbete med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är separat från inbäddning av teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd teckensnittsinbäddningsfunktionerna explicit.

Ett presentationstema kan referera till olika teckensnittsfamiljer för enskilda skriftsystem. Dessa mappningar lagrar teckensnittsnamn men installerar eller läser inte in teckensnittsfilen. Se [Script-Specific Theme Fonts](/slides/sv/nodejs-java/script-specific-font-mappings/) för att hantera mappningarna, och använd laddningsalternativen nedan för att göra de refererade teckensnitten tillgängliga för konsekvent rendering.

{{% alert color="info" title="Obs" %}}
Aspose Slides låter dig läsa in dessa teckensnitt med metoden [loadExternalFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType‑ (.ttf) och TrueType Collection‑ (.ttc) teckensnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType‑ (.otf) teckensnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Läs in anpassade teckensnitt**

Aspose.Slides gör det möjligt att läsa in teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportresultatet – exempelvis PDF, bilder och andra stödjade format – så att de skapade dokumenten ser lika ut i olika miljöer. Teckensnitt läses in från egna kataloger.

1. Ange en eller flera mappar som innehåller teckensnitts‑filerna.
2. Anropa den statiska metoden [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) för att läsa in teckensnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/clearcache/) för att rensa teckensnittscachen.

Följande kodexempel demonstrerar processen för att läsa in teckensnitt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Definiera mappar som innehåller anpassade teckensnittsfiler.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Läs in anpassade teckensnitt från de angivna mapparna.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa teckensnitten.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Rensa teckensnittscachen när arbetet är slutfört.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Obs" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) lägger till extra mappar i teckensnittssökvägarna, men ändrar inte ordningen för teckensnittsinitiering.
Teckensnitt initieras i följande ordning:

1. Operativsystemets standard‑teckensnittssökväg.
1. Sökvägar som lästs in via [FontsLoader](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Hämta anpassade teckensnittsmapp**
Aspose.Slides tillhandahåller metoden [getFontFolders](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) för att låta dig hitta teckensnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets teckensnittsmappar.

Denna JavaScript‑kod visar hur du använder [getFontFolders](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Den här raden skriver ut mappar där teckensnittsfiler söks.
// Det är mappar som lagts till via LoadExternalFonts-metoden och systemets teckensnittsmapp.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Ange anpassade teckensnitt som används i presentationen**
Aspose.Slides tillhandahåller egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) för att låta dig ange externa teckensnitt som ska användas tillsammans med presentationen.

Denna JavaScript‑kod visar hur du använder egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeta med presentationen
    // CustomFont1, CustomFont2 och teckensnitt från mapparna assets\fonts och global\fonts samt deras undermappar är tillgängliga för presentationen
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hantera teckensnitt externt**

Aspose.Slides erbjuder metoden [loadExternalFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) för att låta dig läsa in externa teckensnitt från binär data.

Denna JavaScript‑kod demonstrerar hur teckensnitt läses in från en byte‑array:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // externt teckensnitt laddat under presentationens livstid
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?

Ja. Anslutna teckensnitt används av renderaren för alla exportformat.

### Inbäddas anpassade teckensnitt automatiskt i den resulterande PPTX‑filen?

Nej. Att registrera ett teckensnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att teckensnittet ska finnas i presentationsfilen måste du använda de explicit angivna [inbäddningsfunktionerna](/slides/sv/nodejs-java/embedded-font/).

### Kan jag styra fallback‑beteendet när ett anpassat teckensnitt saknar vissa tecken?

Ja. Konfigurera [font substitution](/slides/sv/nodejs-java/font-substitution/), [replacement rules](/slides/sv/nodejs-java/font-replacement/) och [fallback sets](/slides/sv/nodejs-java/fallback-font/) för att exakt ange vilket teckensnitt som ska användas när den begärda glyphen saknas.

### Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?

Ja. Peka på egna teckensnittsmappar eller läs in teckensnitt från byte‑arrayer. Detta tar bort alla beroenden på systemteckensnitt i behållarbilden.

### Hur är det med licensiering – kan jag inbädda vilket anpassat teckensnitt som helst utan restriktioner?

Du ansvarar för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar resultaten.