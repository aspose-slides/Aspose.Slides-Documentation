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
description: "Anpassa typsnitt i PowerPoint-bilder med Aspose.Slides för .NET för att hålla dina presentationer skarpa och konsekventa på alla enheter."
---
## **Översikt**

Aspose.Slides låter dig använda anpassade typsnitt i presentationer utan att installera dem i operativsystemet. Du kan läsa in typsnitt från anpassade mappar, tillhandahålla typsnitt för en specifik presentation via dokumentnivå‑typsnittskällor, eller läsa in externa typsnitt direkt från binär data.

Inlästa typsnitt används när en presentation renderas eller exporteras, till exempel till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdata konsistent över olika miljöer. Artikeln förklarar också hur du granskar de typsnittsmappor som används av Aspose.Slides och hur du rensar typsnittscachen efter att ha arbetat med externa typsnitt.

Registrering av anpassade typsnitt för renderning är separat från inbäddning av typsnitt i en PPTX‑fil. Om ett typsnitt måste lagras i själva presentationen, använd inbäddningsfunktionerna för typsnitt explicit.

{{% alert color="primary" %}} 

Aspose Slides låter dig läsa in dessa typsnitt med metoden [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) och TrueType Collection (.ttc) typsnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) typsnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Läs in anpassade typsnitt**

Aspose.Slides låter dig läsa in typsnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata — såsom PDF, bilder och andra stödda format — så de resulterande dokumenten ser konsistenta ut i olika miljöer. Typsnitt läses in från anpassade kataloger.

1. Ange en eller flera mappar som innehåller typsnitts‑filerna.
2. Anropa den statiska metoden [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/) för att läsa in typsnitt från dessa mappar.
3. Läs in och rendera/exportera presentationen.
4. Anropa [FontsLoader.ClearCache](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/clearcache/) för att rensa typsnittscachen.

Följande kodexempel demonstrerar processen för att läsa in typsnitt:

```cs
// Definiera mappar som innehåller anpassade typsnittsfiler.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Läs in anpassade typsnitt från de angivna mapparna.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de inlästa typsnitten.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Rensa typsnittscachen när arbetet är klart.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/) lägger till ytterligare mappar i typsnittssökvägarna, men ändrar inte ordningen för typsnittsinitiering.
Typsnitt initieras i följande ordning:

1. Standard‑operativsystemets typsnittsväg.
1. Vägarna som lästs in via [FontsLoader](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Hämta anpassade typsnittsmappor**
Aspose.Slides tillhandahåller metoden [GetFontFolders](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/getfontfolders/) för att låta dig hitta typsnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets typsnittsmappar.

Denna C#‑kod visar hur du använder [GetFontFolders](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/getfontfolders/):

```c#
// Den här raden skriver ut mapparna som kontrolleras för typsnittsfiler.
// Det är mappar som lagts till via LoadExternalFonts-metoden och systemets typsnittsmappor.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Ange anpassade typsnitt som används med en presentation**
Aspose.Slides tillhandahåller egenskapen [DocumentLevelFontSources](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/documentlevelfontsources/) för att låta dig specificera externa typsnitt som ska användas med presentationen.

Denna C#‑kod visar hur du använder egenskapen [DocumentLevelFontSources](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Arbeta med presentationen
    // CustomFont1, CustomFont2 och typsnitt från mapparna assets\fonts & global\fonts samt deras undermappar är tillgängliga för presentationen
}
```

## **Hantera typsnitt externt**

Aspose.Slides tillhandahåller metoden [LoadExternalFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) för att låta dig läsa in externa typsnitt från binär data.

Denna C#‑kod demonstrerar processen för att läsa in typsnitt från en byte‑array: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // externt typsnitt laddat under presentationens livstid
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Påverkar anpassade typsnitt export till alla format (PDF, PNG, SVG, HTML)?**

Ja. Anslutna typsnitt används av renderaren för alla exportformat.

**Inbäddas anpassade typsnitt automatiskt i den resulterande PPTX‑filen?**

Nej. Att registrera ett typsnitt för rendering är inte detsamma som att bädda in det i en PPTX. Om du behöver att typsnittet ska finnas i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/net/embedded-font/).

**Kan jag kontrollera fallback‑beteende när ett anpassat typsnitt saknar vissa tecken?**

Ja. Konfigurera [font substitution](/slides/sv/net/font-substitution/), [replacement rules](/slides/sv/net/font-replacement/) och [fallback sets](/slides/sv/net/fallback-font/) för att exakt ange vilket typsnitt som ska användas när den begärda tecknet saknas.

**Kan jag använda typsnitt i Linux/Docker‑behållare utan att installera dem systemomfattande?**

Ja. Peka på dina egna typsnittsmappar eller läs in typsnitt från byte‑arrayer. Detta tar bort alla beroenden på systemets typsnittskataloger i behållaravbilden.

**Hur är det med licensiering—kan jag bädda in vilket anpassat typsnitt som helst utan restrictioner?**

Du ansvarar för att följa typsnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid typsnittets EULA innan du distribuerar resultat.