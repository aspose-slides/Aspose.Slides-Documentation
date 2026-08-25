---
title: Anpassa PowerPoint-typsnitt i .NET
linktitle: Anpassat typsnitt
type: docs
weight: 20
url: /sv/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Anpassa typsnitt i PowerPoint-bilder med Aspose.Slides för .NET för att hålla dina presentationer skarpa och konsistenta på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade teckensnitt i presentationer utan att installera dem på operativsystemet. Du kan läsa in teckensnitt från egna mappar, tillhandahålla teckensnitt för en specifik presentation via dokumentnivå‑teckensnittskällor, eller läsa in externa teckensnitt direkt från binär data.

Inlästa teckensnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdata konsekvent över olika miljöer. Artikeln förklarar också hur du inspekterar de teckensnittsmappor som används av Aspose.Slides och hur du rensar teckensnittscache efter arbete med externa teckensnitt.

Registrering av anpassade teckensnitt för rendering är separat från inbäddning av teckensnitt i en PPTX‑fil. Om ett teckensnitt måste lagras i själva presentationen, använd inbäddningsfunktionerna för teckensnitt explicit.

Ett presentationstema kan referera till olika teckensnittsfamiljer för enskilda skriftsystem. Dessa mappningar lagrar teckensnittsnamn men installerar eller läser inte in teckensnitts‑filerna. Se [Script‑Specific Theme Fonts](/slides/sv/net/script-specific-font-mappings/) för att hantera mappningarna, och använd laddningsalternativen nedan för att göra de refererade teckensnitten tillgängliga för konsekvent rendering.

{{% alert color="info" title="Obs" %}}
Aspose Slides låter dig läsa in dessa teckensnitt med metoden [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType‑teckensnitt (.ttf) och TrueType‑Collection‑teckensnitt (.ttc). Se [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType‑teckensnitt (.otf). Se [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Läs in anpassade teckensnitt**

Aspose.Slides låter dig läsa in teckensnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata—till exempel PDF, bilder och andra stödda format—så att de resulterande dokumenten ser konsekventa ut över olika miljöer. Teckensnitt läses in från egna kataloger.

1. Ange en eller flera mappar som innehåller teckensnitts‑filerna.
2. Anropa den statiska metoden [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/) för att läsa in teckensnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader.ClearCache](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/clearcache/) för att rensa teckensnittscache.

Följande kodexempel visar teckensnittsladdningsprocessen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definiera mappar som innehåller anpassade teckensnittsfiler.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Läs in anpassade teckensnitt från de angivna mapparna.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa teckensnitten.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Rensa teckensnittscachen efter att arbetet är klart.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Obs" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/) lägger till extra mappar i teckensnittssökvägarna, men ändrar inte ordningen för teckensnittsinitialisering.
Teckensnitt initieras i följande ordning:

1. Den standardteckensnittssökväg som operativsystemet använder.
1. Sökvägarna som lästs in via [FontsLoader](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Hämta anpassade teckensnittsmappar**
Aspose.Slides tillhandahåller metoden [GetFontFolders](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/getfontfolders/) för att låta dig hitta teckensnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets teckensnittsmappar.

Denna C#‑kod visar hur du använder [GetFontFolders](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Den här raden skriver ut mapparna som kontrolleras för teckensnittsfiler.
// Det är mappar som lagts till via LoadExternalFonts-metoden och systemets teckensnittsmappor.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Specificera anpassade teckensnitt som används med en presentation**
Aspose.Slides tillhandahåller egenskapen [DocumentLevelFontSources](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/documentlevelfontsources/) så att du kan ange externa teckensnitt som ska användas med presentationen.

Denna C#‑kod visar hur du använder egenskapen [DocumentLevelFontSources](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Arbeta med presentationen
    // CustomFont1, CustomFont2 och teckensnitt från mapparna assets\fonts och global\fonts samt deras undermappar är tillgängliga för presentationen
}
```

## **Hantera teckensnitt externt**

Aspose.Slides tillhandahåller metoden [LoadExternalFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) så att du kan läsa in externa teckensnitt från binär data.

Denna C#‑kod demonstrerar processen för att läsa in teckensnitt från en byte‑array:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // externt teckensnitt laddat under presentationens livstid
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **Vanliga frågor**

**Påverkar anpassade teckensnitt export till alla format (PDF, PNG, SVG, HTML)?**

Ja. Anslutna teckensnitt används av renderaren för alla exportformat.

**Bäddas anpassade teckensnitt automatiskt in i den resulterande PPTX‑filen?**

Nej. Att registrera ett teckensnitt för rendering är inte samma sak som att bädda in det i en PPTX. Om du behöver att teckensnittet finns i själva presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/net/embedded-font/).

**Kan jag kontrollera fallback‑beteende när ett anpassat teckensnitt saknar vissa tecken?**

Ja. Konfigurera [teckensnittssubstitution](/slides/sv/net/font-substitution/), [ersättningsregler](/slides/sv/net/font-replacement/) och [fallback‑uppsättningar](/slides/sv/net/fallback-font/) för att exakt ange vilket teckensnitt som ska användas när den begärda tecknet saknas.

**Kan jag använda teckensnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?**

Ja. Peka på dina egna teckensnittsmappar eller läs in teckensnitt från byte‑arrayer. Detta eliminerar alla beroenden på systemets teckensnittskataloger i container‑avbilden.

> **Obs för Linux/Docker**: När du anropar `FontsLoader.LoadExternalFonts` ska du se till att varje element i `directories`‑arrayen innehåller en icke‑tom sökväg till en befintlig katalog. Om en miljövariabel som används för att konstruera en teckensnittssökväg är odefinierad eller tom kan Aspose.Slides försöka lösa det tomma värdet som en fullständig sökväg, vilket resulterar i `System.ArgumentException`.

**Hur är det med licensiering—kan jag bädda in vilket anpassat teckensnitt som helst utan restriktioner?**

Du är ansvarig för att följa teckensnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid teckensnittets EULA innan du distribuerar resultaten.