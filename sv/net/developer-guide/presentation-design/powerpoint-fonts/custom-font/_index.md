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

Aspose.Slides låter dig använda anpassade typsnitt i presentationer utan att installera dem i operativsystemet. Du kan ladda typsnitt från egna mappar, tillhandahålla typsnitt för en specifik presentation via dokumentnivå‑typsnittskällor, eller ladda externa typsnitt direkt från binär data.

Laddade typsnitt används när en presentation renderas eller exporteras, exempelvis till PDF, bilder och andra stödda format. Detta hjälper till att hålla presentationsutdata konsekvent över olika miljöer. Artikeln förklarar också hur du undersöker de typsnittsmappningar som används av Aspose.Slides och hur du rensar typsnittscachen efter att ha arbetat med externa typsnitt.

Att registrera anpassade typsnitt för rendering är separat från att bädda in typsnitt i en PPTX‑fil. Om ett typsnitt måste lagras i själva presentationen, använd typsnitts‑inbäddningsfunktionerna explicit.

{{% alert color="info" %}} 
Aspose Slides låter dig ladda dessa typsnitt med metoden [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) och TrueType Collection (.ttc) typsnitt. Se [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) typsnitt. Se [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Ladda anpassade typsnitt**

Aspose.Slides låter dig ladda typsnitt som används i en presentation utan att installera dem på systemet. Detta påverkar exportutdata — såsom PDF, bilder och andra stödda format — så att de resulterande dokumenten ser konsistenta ut över olika miljöer. Typsnitt laddas från anpassade kataloger.

1. Ange en eller flera mappar som innehåller typsnittsfilerna.  
2. Anropa den statiska metoden [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/) för att ladda typsnitt från dessa mappar.  
3. Ladda och rendera/exportera presentationen.  
4. Anropa [FontsLoader.ClearCache](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/clearcache/) för att rensa typsnittscachen.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definiera mappar som innehåller anpassade teckensnittsfiler.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Ladda anpassade typsnitt från de angivna mapparna.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Rendera/exportera presentationen (t.ex. till PDF, bilder eller andra format) med de laddade typsnitten.
presentation.Save("output.pdf", SaveFormat.Pdf");

// Rensa typsnittscachen efter att arbetet är slutfört.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Obs" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfonts/) lägger till extra mappar i typsnittssökvägarna, men ändrar inte typsnittens initialiseringsordning.  
Typsnitt initieras i följande ordning:

1. Operativsystemets standardtypsnittssökväg.  
1. Sökvägarna som laddas via [FontsLoader](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Hämta anpassade typsnittsmappar**
Aspose.Slides erbjuder metoden [GetFontFolders](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/getfontfolders/) så att du kan hitta typsnittsmappar. Denna metod returnerar mappar som lagts till via `LoadExternalFonts`‑metoden samt systemets typsnittsmappar.

Denna C#‑kod visar hur du använder [GetFontFolders](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Den här raden skriver ut mapparna som kontrolleras för typsnittsfiler.
// Det är mappar som lagts till via LoadExternalFonts-metoden och systemets typsnittsmapp.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Ange anpassade typsnitt som används med en presentation**
Aspose.Slides tillhandahåller egenskapen [DocumentLevelFontSources](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/documentlevelfontsources/) så att du kan ange externa typsnitt som ska användas med presentationen.

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
    // CustomFont1, CustomFont2, och typsnitt från mapparna assets\fonts & global\fonts samt deras undermappar är tillgängliga för presentationen
}
```

## **Hantera typsnitt externt**

Aspose.Slides erbjuder metoden [LoadExternalFont](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) så att du kan ladda externa typsnitt från binär data.

Denna C#‑kod demonstrerar processen för att ladda typsnitt från en byte‑array: 

```c#
using Aspose.Slides;

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

## **Vanliga frågor**

**Påverkar anpassade typsnitt export till alla format (PDF, PNG, SVG, HTML)?**  
Ja. Anslutna typsnitt används av renderaren för alla exportformat.

**Bäddas anpassade typsnitt automatiskt in i den resulterande PPTX‑filen?**  
Nej. Att registrera ett typsnitt för rendering är inte samma sak som att bädda in det i en PPTX. Om du behöver att typsnittet finns i presentationsfilen måste du använda de explicita [inbäddningsfunktionerna](/slides/sv/net/embedded-font/).

**Kan jag styra fallback‑beteende när ett anpassat typsnitt saknar vissa tecken?**  
Ja. Konfigurera [font substitution](/slides/sv/net/font-substitution/), [replacement rules](/slides/sv/net/font-replacement/) och [fallback sets](/slides/sv/net/fallback-font/) för att exakt ange vilket typsnitt som används när den begärda tecknet saknas.

**Kan jag använda typsnitt i Linux/Docker‑behållare utan att installera dem systembrett?**  
Ja. Peka på dina egna typsnittsmappar eller ladda typsnitt från byte‑arrayer. Detta tar bort alla beroenden på systemets typsnittskataloger i containerns avbild.

> **Obs för Linux/Docker**: När du anropar `FontsLoader.LoadExternalFonts`, se till att varje element i `directories`‑arrayen innehåller en icke‑tom sökväg till en befintlig katalog. Om en miljövariabel som används för att konstruera en typsnittssökväg är odefinierad eller tom, kan Aspose.Slides försöka tolka det tomma värdet som en fullständig sökväg, vilket resulterar i `System.ArgumentException`.

**Hur är det med licensiering — kan jag bädda in valfritt anpassat typsnitt utan restriktioner?**  
Du är ansvarig för att följa typsnittens licensvillkor. Villkoren varierar; vissa licenser förbjuder inbäddning eller kommersiell användning. Granska alltid typsnittets EULA innan du distribuerar resultat.