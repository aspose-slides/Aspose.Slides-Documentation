---
title: Anpassa PowerPoint-teckensnitt på Android
linktitle: Anpassat teckensnitt
type: docs
weight: 20
url: /sv/androidjava/custom-font/
keywords:
- teckensnitt
- anpassat teckensnitt
- externt teckensnitt
- läsa in teckensnitt
- hantera teckensnitt
- teckensnittsmapp
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Anpassa teckensnitt i PowerPoint-bilder med Aspose.Slides för Android via Java för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade teckensnitt i presentationer utan att installera dem på operativsystemet. Du kan läsa in teckensnitt från anpassade mappar, tillhandahålla teckensnitt för en specifik presentation via dokumentnivå‑teckensnittskällor, eller läsa in externa teckensnitt direkt från binär data.

Inlästa teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdata konsekvent över olika miljöer. Artikeln förklarar också hur du granskar de teckensnittsmappor som Aspose.Slides använder och hur du rensar teckensnittscachen efter arbete med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är separat från inbäddning av teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd funktionerna för teckensnitts‑inbäddning explicit.

Ett presentationstema kan referera till olika teckensnittsfamiljer för enskilda skriftsystem. Dessa mappningar lagrar teckensnittsnamn men installerar eller läser inte in teckensnitts‑filerna. Se [Skriptspecifika temateckensnitt](/slides/sv/androidjava/script-specific-font-mappings/) för att hantera mappningarna, och använd laddningsalternativen nedan för att göra de refererade teckensnitten tillgängliga för konsekvent rendering.

{{% alert color="info" title="Obs" %}}

Aspose Slides tillåter dig att läsa in dessa teckensnitt med metoden [loadExternalFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) och TrueType Collection (.ttc) teckensnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) teckensnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Läs in anpassade teckensnitt**

Aspose.Slides låter dig läsa in teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportresultat—såsom PDF, bilder och andra stödda format—så att de resulterande dokumenten ser konsekventa ut över olika miljöer. Teckensnitt läses in från anpassade kataloger.

1. Ange en eller flera mappar som innehåller teckensnittsfilerna.
2. Anropa den statiska metoden [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) för att läsa in teckensnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsLoader#clearCache--) för att rensa teckensnittscachen.

Följande kodexempel demonstrerar teckensnitts­laddningsprocessen:

```java
import com.aspose.slides.*;

// Definiera mappar som innehåller anpassade teckensnitts-filer.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Läs in anpassade teckensnitt från de specificerade mapparna.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa teckensnitten.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Rensa teckensnittscachen när arbetet är slutfört.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Obs" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) lägger till ytterligare mappar i teckensnittssökvägarna, men ändrar inte ordningen för teckensnittsinitiering.
Teckensnitt initieras i följande ordning:

1. Operativsystemets standardteckensnittssökväg.
1. Sökvägar som laddats via [FontsLoader](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Hämta anpassade teckensnittsmappor**

Aspose.Slides tillhandahåller metoden [getFontFolders](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) för att låta dig hitta teckensnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets teckensnittsmappor.

Denna Java‑kod visar hur du använder [getFontFolders](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Den här raden skriver ut mappar där teckensnitts-filer söks.
// Det är mappar som lagts till via LoadExternalFonts-metoden och systemets teckensnittsmappar.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Ange anpassade teckensnitt som används med en presentation**

Aspose.Slides tillhandahåller egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) för att låta dig ange externa teckensnitt som ska användas med presentationen.

Denna Java‑kod visar hur du använder egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 och teckensnitt från mapparna assets\fonts & global\fonts samt deras undermappar är tillgängliga för presentationen
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera teckensnitt externt**

Aspose.Slides tillhandahåller metoden [loadExternalFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) för att låta dig läsa in externa teckensnitt från binär data.

Denna Java‑kod demonstrerar processen för teckensnittsladdning från byte‑array:

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
        // extern teckensnitt laddat under presentationens livstid
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?

Ja. Anslutna teckensnitt används av renderaren för alla exportformat.

### Är anpassade teckensnitt automatiskt inbäddade i den resulterande PPTX‑filen?

Nej. Registrering av ett teckensnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att teckensnittet ska finnas i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/androidjava/embedded-font/).

### Kan jag kontrollera fallback‑beteendet när ett anpassat teckensnitt saknar vissa glyfer?

Ja. Konfigurera [teckensnittssubstitution](/slides/sv/androidjava/font-substitution/), [ersättningsregler](/slides/sv/androidjava/font-replacement/) och [fallback‑uppsättningar](/slides/sv/androidjava/fallback-font/) för att exakt ange vilket teckensnitt som används när den begärda glyfen saknas.

### Kan jag använda teckensnitt i Linux/Docker‑containrar utan att installera dem systemomfattande?

Ja. Peka på dina egna teckensnittsmappor eller läs in teckensnitt från byte‑array. Detta tar bort alla beroenden av systemteckensnittskataloger i container‑avbilden.

### Vad gäller licensiering—kan jag bädda in vilket anpassat teckensnitt som helst utan restriktioner?

Du är ansvarig för att följa teckensnittslicenserna. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar resultat.