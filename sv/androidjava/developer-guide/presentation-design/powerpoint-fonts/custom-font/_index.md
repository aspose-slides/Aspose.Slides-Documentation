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
- ladda teckensnitt
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

Aspose.Slides låter dig använda anpassade teckensnitt i presentationer utan att installera dem i operativsystemet. Du kan ladda teckensnitt från egna mappar, tillhandahålla teckensnitt för en specifik presentation via dokumentnivå‑teckensnittskällor, eller ladda externa teckensnitt direkt från binär data.

Laddade teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationens utdata konsekvent i olika miljöer. Artikeln förklarar också hur du kan inspektera teckensnittsmappen som används av Aspose.Slides och hur du rensar teckensnittscachen efter att ha arbetat med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är separat från inbäddning av teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd inbäddningsfunktionerna explicit.

{{% alert color="info" %}} 

Aspose Slides låter dig ladda dessa teckensnitt med metoden [loadExternalFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType‑teckensnitt (.ttf) och TrueType Collection‑teckensnitt (.ttc). Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑teckensnitt (.otf). Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ladda anpassade teckensnitt**

Aspose.Slides låter dig ladda teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportresultat — såsom PDF, bilder och andra stödda format — så att de resulterande dokumenten ser ensamma ut i olika miljöer. Teckensnitt laddas från egna kataloger.

1. Ange en eller flera mappar som innehåller teckensnittsfilen.
2. Anropa den statiska metoden [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) för att ladda teckensnitt från dessa mappar.
3. Ladda och rendera/​exportera presentationen.
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsLoader#clearCache--) för att rensa teckensnittscachen.

Följande kodexempel demonstrerar teckensnitts‑laddningsprocessen:

```java
import com.aspose.slides.*;

// Definiera mappar som innehåller anpassade teckensnitts-filer.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Ladda anpassade teckensnitt från de angivna mapparna.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa teckensnitten.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Rensa teckensnittscachen när arbetet är klart.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Obs" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) lägger till ytterligare mappar i teckensnittssökvägarna, men ändrar inte ordningen för teckensnittsinitalisering.
Teckensnitt initieras i följande ordning:

1. Operativsystemets standardsökväg för teckensnitt.
1. Sökvägar som laddats via [FontsLoader](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Hämta anpassade teckensnittsmappar**
Aspose.Slides tillhandahåller metoden [getFontFolders](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) för att låta dig hitta teckensnittsmappar. Metoden returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets teckensnittsmappar.

Denna Java‑kod visar hur du använder [getFontFolders](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Denna rad skriver ut mappar där teckensnitts-filer söks.
// Dessa är mappar som lagts till via LoadExternalFonts-metoden och systemets teckensnittsmapp.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Ange anpassade teckensnitt som används i en presentation**
Aspose.Slides tillhandahåller egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) för att låta dig ange externa teckensnitt som ska användas med presentationen.

Denna Java‑kod visar hur du använder [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 och teckensnitt från assets\fonts & global\fonts mappar och deras underkataloger är tillgängliga för presentationen
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera teckensnitt externt**

Aspose.Slides tillhandahåller metoden [loadExternalFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) för att låta dig ladda externa teckensnitt från binär data.

Denna Java‑kod demonstrerar inläsning av teckensnitt från en byte‑array:

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

Ja. Anslutna teckensnitt används av renderaren i alla exportformat.

### Bäddas anpassade teckensnitt automatiskt i den resulterande PPTX‑filen?

Nej. Att registrera ett teckensnitt för rendering är inte samma sak som att bädda in det i en PPTX. Om du vill att teckensnittet ska finnas i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/androidjava/embedded-font/).

### Kan jag styra fallback‑beteendet när ett anpassat teckensnitt saknar vissa tecken?

Ja. Konfigurera [teckensnittssubstitution](/slides/sv/androidjava/font-substitution/), [ersättningsregler](/slides/sv/androidjava/font-replacement/) och [fallback‑uppsättningar](/slides/sv/androidjava/fallback-font/) för att exakt ange vilket teckensnitt som ska användas när den efterfrågade glyphen saknas.

### Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?

Ja. Peka på egna teckensnittsmappar eller ladda teckensnitt från byte‑arrayer. Detta tar bort beroendet av systemteckensnittsmappar i behållar‑avbilden.

### Vad gäller licensiering – kan jag bädda in vilket anpassat teckensnitt som helst utan restriktioner?

Du är ansvarig för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar resultat.