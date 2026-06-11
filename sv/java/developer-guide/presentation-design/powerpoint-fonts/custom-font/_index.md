---
title: Anpassa PowerPoint-teckensnitt i Java
linktitle: Anpassat teckensnitt
type: docs
weight: 20
url: /sv/java/custom-font/
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
- Java
- Aspose.Slides
description: "Anpassa teckensnitt i PowerPoint-bilder med Aspose.Slides för Java för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade teckensnitt i presentationer utan att installera dem på operativsystemet. Du kan läsa in teckensnitt från egna mappar, tillhandahålla teckensnitt för en specifik presentation genom dokumentnivåns teckensnittskällor, eller läsa in externa teckensnitt direkt från binär data.

Lästa teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdata konsekvent över olika miljöer. Artikeln förklarar också hur du inspekterar de teckensnittsmappar som används av Aspose.Slides och hur du rensar teckensnittscachen efter att ha arbetat med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är separat från inbäddning av teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd inbäddningsfunktionerna uttryckligen.

{{% alert color="primary" %}} 
Aspose Slides låter dig ladda dessa teckensnitt med metoden [loadExternalFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) och TrueType Collection (.ttc) teckensnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) teckensnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Ladda anpassade teckensnitt**

Aspose.Slides låter dig läsa in teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata – såsom PDF, bilder och andra stödda format – så att de genererade dokumenten ser lika ut i alla miljöer. Teckensnitt läses in från egna kataloger.

1. Ange en eller flera mappar som innehåller teckensnittsfilerna.
2. Anropa den statiska metoden [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) för att läsa in teckensnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader.clearCache](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsLoader#clearCache--) för att rensa teckensnittscachen.

Följande kodexempel demonstrerar teckensnitts‑inläsningsprocessen:

```java
// Definiera mappar som innehåller anpassade teckensnittsfiler.
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
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) lägger till extra mappar i teckensnittssökvägarna, men ändrar inte initieringsordningen för teckensnitt.
Teckensnitt initieras i följande ordning:

1. Operativsystemets standard‑teckensnittssökväg.
1. Sökvägar som lästs in via [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Hämta anpassade teckensnittsmappar**
Aspose.Slides tillhandahåller metoden [getFontFolders](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#getFontFolders--) för att låta dig hitta teckensnittsmappar. Denna metod returnerar mappar som lagts till via metoden `LoadExternalFonts` samt systemets teckensnittsmappar.

Denna Java‑kod visar hur du använder [getFontFolders](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Denna rad skriver ut mappar där teckensnittsfiler söks.
// Det är mappar som lagts till via LoadExternalFonts‑metoden och systemets teckensnittsmapp.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Ange anpassade teckensnitt som används med en presentation**
Aspose.Slides tillhandahåller egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) för att låta dig ange externa teckensnitt som ska användas med presentationen.

Denna Java‑kod visar hur du använder egenskapen [setDocumentLevelFontSources](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeta med presentationen
    // CustomFont1, CustomFont2 och teckensnitt från mapparna assets\fonts & global\fonts samt deras underkataloger är tillgängliga för presentationen
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera teckensnitt externt**

Aspose.Slides tillhandahåller metoden [loadExternalFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) för att låta dig läsa in externa teckensnitt från binära data.

Denna Java‑kod demonstrerar inläsning av teckensnitt från en byte‑array:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // externt teckensnitt laddat under presentationens livstid
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Vanliga frågor**

**Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?**

Ja. Anslutna teckensnitt används av renderaren i alla exportformat.

**Inbäddas anpassade teckensnitt automatiskt i den resulterande PPTX‑filen?**

Nej. Att registrera ett teckensnitt för rendering är inte samma sak som att bädda in det i en PPTX. Om du vill ha teckensnittet med i presentationsfilen måste du använda de explicita inbäddningsfunktionerna.

**Kan jag kontrollera fallback‑beteende när ett anpassat teckensnitt saknar vissa tecken?**

Ja. Konfigurera [font substitution](/slides/sv/java/font-substitution/), [replacement rules](/slides/sv/java/font-replacement/) och [fallback sets](/slides/sv/java/fallback-font/) för att exakt ange vilket teckensnitt som ska användas när den efterfrågade glyphen saknas.

**Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?**

Ja. Peka på dina egna teckensnittsmappar eller läs in teckensnitt från byte‑arrayer. Detta eliminerar beroendet av system‑teckensnittsmappningar i behållar‑imagen.

**Hur är det med licensiering – kan jag bädda in vilket anpassat teckensnitt som helst utan restriktioner?**

Du är ansvarig för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar utdata.