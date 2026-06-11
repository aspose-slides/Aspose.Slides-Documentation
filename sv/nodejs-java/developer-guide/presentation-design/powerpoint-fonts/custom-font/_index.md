---
title: Anpassa PowerPoint‑teckensnitt i JavaScript
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
description: "Anpassa teckensnitt i PowerPoint‑presentationer med JavaScript och Aspose.Slides för Node.js via Java för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade teckensnitt i presentationer utan att installera dem i operativsystemet. Du kan läsa in teckensnitt från egna mappar, tillhandahålla teckensnitt för en specifik presentation via dokumentnivå‑teckensnittskällor, eller läsa in externa teckensnitt direkt från binär data.

Inlästa teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationens utdata konsekvent i olika miljöer. Artikeln förklarar också hur du inspekterar de teckensnittsmappar som Aspose.Slides använder och hur du rensar teckensnittscachen efter arbete med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är separat från inbäddning av teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd teckensnittsinbäddningsfunktionerna explicit.

{{% alert color="primary" %}} 

Aspose Slides låter dig läsa in dessa teckensnitt med metoden [loadExternalFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType‑teckensnitt (.ttf) och TrueType‑samlingar (.ttc). Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑teckensnitt (.otf). Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Läs in anpassade teckensnitt**

Aspose.Slides låter dig läsa in teckensnitt som används i en presentation utan att installera dem i systemet. Detta påverkar exportutdata – såsom PDF, bilder och andra stödda format – så att de resulterande dokumenten ser likadana ut i olika miljöer. Teckensnitt läses in från egna kataloger.

1. Ange en eller flera mappar som innehåller teckensnittsfilerna.  
2. Anropa den statiska metoden [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) för att läsa in teckensnitt från dessa mappar.  
3. Läs in och rendera/exportera presentationen.  
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/clearcache/) för att rensa teckensnittscachen.

Följande kodexempel visar hur teckensnittsläsning sker:

```js
// Definiera mappar som innehåller anpassade teckensnittsfiler.
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

    // Rensa teckensnittscachen när arbetet är klart.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Obs" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) lägger till extra mappar i teckensnittssökvägarna, men ändrar inte initieringsordningen för teckensnitt.  
Teckensnitt initieras i följande ordning:

1. Operativsystemets standardsökväg för teckensnitt.  
1. Sökvägar som laddats via [FontsLoader](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Hämta anpassade typsnittsmapp**
Aspose.Slides tillhandahåller metoden [getFontFolders](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) för att låta dig hitta typsnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts` samt systemets typsnittsmappar.

Denna JavaScript‑kod visar hur du använder [getFontFolders](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// Den här raden skriver ut mappar där teckensnittsfiler söks.
// Det är mappar som lagts till via LoadExternalFonts‑metoden och systemets teckensnittsmapp.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Ange anpassade teckensnitt som används med presentationen**
Aspose.Slides tillhandahåller egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) för att låta dig ange externa teckensnitt som ska användas med presentationen.

Denna JavaScript‑kod visar hur du använder egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
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

Aspose.Slides tillhandahåller metoden [loadExternalFont](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) för att låta dig läsa in externa teckensnitt från binär data.

Denna JavaScript‑kod demonstrerar hur teckensnitt läses in från en byte‑array:

```javascript
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

**Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?**

Ja. Anslutna teckensnitt används av renderaren för alla exportformat.

**Bäddas anpassade teckensnitt automatiskt i den resulterande PPTX‑filen?**

Nej. Att registrera ett teckensnitt för rendering är inte samma sak som att bädda in det i en PPTX. Om du vill att teckensnittet ska finnas i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/nodejs-java/embedded-font/).

**Kan jag styra återfallsbeteende när ett anpassat teckensnitt saknar vissa tecken?**

Ja. Konfigurera [font substitution](/slides/sv/nodejs-java/font-substitution/), [replacement rules](/slides/sv/nodejs-java/font-replacement/) och [fallback sets](/slides/sv/nodejs-java/fallback-font/) för att exakt ange vilket teckensnitt som ska användas när den begärda glyphen saknas.

**Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?**

Ja. Peka på egna teckensnittsmappar eller läs in teckensnitt från byte‑arrayer. Detta tar bort beroendet av systemteckensnittskataloger i behållaravbilden.

**Hur är det med licensiering – kan jag bädda in valfritt anpassat teckensnitt utan restriktioner?**

Du ansvarar för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar resultat.