---
title: Anpassa PowerPoint-typsnitt i Java
linktitle: Anpassat typsnitt
type: docs
weight: 20
url: /sv/java/custom-font/
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
- Java
- Aspose.Slides
description: "Anpassa typsnitt i PowerPoint-bilder med Aspose.Slides för Java för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade typsnitt i presentationer utan att installera dem på operativsystemet. Du kan ladda typsnitt från anpassade mappar, tillhandahålla typsnitt för en specifik presentation via dokumentnivå‑typsnittskällor, eller ladda externa typsnitt direkt från binär data.

Laddade typsnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationens utdata konsistent i olika miljöer. Artikeln förklarar också hur du granskar typsnittsmapparna som används av Aspose.Slides och hur du rensar typsnittscache efter arbete med externa typsnitt.

Registrering av anpassade typsnitt för rendering är separat från inbäddning av typsnitt i en PPTX‑fil. Om ett typsnitt måste lagras i själva presentationen, använd inbäddningsfunktionerna för typsnitt explicit.

{{% alert color="info" %}} 

Aspose Slides låter dig ladda dessa typsnitt med hjälp av metoden [loadExternalFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf)- och TrueType Collection (.ttc)-typsnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf)-typsnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ladda anpassade typsnitt**

Aspose.Slides låter dig ladda typsnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportresultatet – såsom PDF, bilder och andra stödda format – så de resulterande dokumenten ser likadana ut i alla miljöer. Typsnitten laddas från anpassade kataloger.

1. Ange en eller flera mappar som innehåller typsnittsfilerna.  
2. Anropa den statiska metoden [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) för att ladda typsnitt från dessa mappar.  
3. Ladda och rendera/exportera presentationen.  
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsLoader#clearCache--) för att rensa typsnittscachen.

Följande kodexempel demonstrerar processen för att ladda typsnitt:

```java
import com.aspose.slides.*;

// Definiera mappar som innehåller anpassade typsnittsfiler.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Ladda anpassade typsnitt från de angivna mapparna.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de laddade typsnitten.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Rensa typsnittscachen när arbetet är klart.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Observera" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) lägger till ytterligare mappar i sökvägarna för typsnitt, men ändrar inte ordningen för typsnittsinitialisering. Typsnitt initieras i följande ordning:

1. Operativsystemens standard‑typsnittssökväg.  
1. Sökvägarna som laddats via [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Hämta anpassade typsnittsmappar**
Aspose.Slides tillhandahåller metoden [getFontFolders](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#getFontFolders--) för att låta dig hitta typsnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets typsnittsmappar.

Denna Java‑kod visar hur du använder [getFontFolders](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Denna rad skriver ut mappar där typsnittsfiler söks.
// Detta är mappar som lagts till via LoadExternalFonts‑metoden och systemets typsnittsmappar.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Ange anpassade typsnitt som ska användas med en presentation**
Aspose.Slides tillhandahåller egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) för att låta dig ange externa typsnitt som ska användas med presentationen.

Denna Java‑kod visar hur du använder egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeta med presentationen
    // CustomFont1, CustomFont2 och typsnitt från mapparna assets\fonts & global\fonts samt deras undermappar är tillgängliga för presentationen
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera typsnitt externt**

Aspose.Slides tillhandahåller metoden [loadExternalFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) för att låta dig ladda externa typsnitt från binär data.

Denna Java‑kod demonstrerar processen för att ladda ett typsnitt från en byte‑array:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // externt typsnitt laddat under presentationens livstid
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Påverkar anpassade typsnitt export till alla format (PDF, PNG, SVG, HTML)?

Ja. Anslutna typsnitt används av renderaren för alla exportformat.

### Bäddas anpassade typsnitt automatiskt i den resulterande PPTX‑filen?

Nej. Att registrera ett typsnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att typsnittet ska finnas i presentationsfilen måste du använda de explicita [embedding features](/slides/sv/java/embedded-font/).

### Kan jag kontrollera fallback‑beteendet när ett anpassat typsnitt saknar vissa tecken?

Ja. Konfigurera [font substitution](/slides/sv/java/font-substitution/), [replacement rules](/slides/sv/java/font-replacement/) och [fallback sets](/slides/sv/java/fallback-font/) för att exakt definiera vilket typsnitt som används när den begärda teckenkombinationen saknas.

### Kan jag använda typsnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?

Ja. Peka på dina egna typsnittsmappar eller ladda typsnitt från byte‑arrayer. Detta eliminerar alla beroenden på systemets typsnittskataloger i container‑avbilden.

### Hur är det med licensiering—kan jag bädda in vilket anpassat typsnitt som helst utan restriktioner?

Du är ansvarig för att följa typsnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid typsnittets EULA innan du distribuerar resultat.