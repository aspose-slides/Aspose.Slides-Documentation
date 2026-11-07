---
title: Sekwencja wyboru czcionek w Aspose.Slides dla .NET
linktitle: Wybór czcionki
type: docs
weight: 80
url: /pl/net/font-selection-sequence/
keywords:
- wybór czcionki
- podstawianie czcionki
- zastąpienie czcionki
- reguła podstawiania
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla .NET wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP — popraw swoje slajdy już teraz."
---
## **Przegląd**

When a presentation is loaded, rendered, or converted to another format, Aspose.Slides considers its embedded fonts and the fonts available to the application. If a required font is unavailable, Aspose.Slides selects a replacement font that is as close as possible to the one PowerPoint would use.

Available fonts can include system fonts, fonts loaded by the application and fonts embedded in the presentation. For a matching embedded and registered font, the .NET 26.11 preference described below controls which takes priority. Font substitution rules defined through [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) are a separate mechanism.

You can also add fonts at application runtime, use embedded fonts from a presentation, or load external fonts for output documents such as PDF files.

## **Wybór czcionki**

Text can reference a theme font, such as `+mn-lt`, rather than an explicit family name. See [Rozwiązywanie odwołań do czcionek motywu](/slides/pl/net/presentation-theme/#resolve-theme-font-references) to obtain the family specified by the applicable theme. Resolving that reference is separate from checking font availability and applying rendering-time substitution or glyph fallback; it does not identify the font file ultimately used to render the text.

When rendering slides or converting a presentation, check that the requested fonts are embedded or available from registered sources. Missing fonts can require replacement or substitution; see [**Zamiana czcionek**](/slides/pl/net/font-replacement/) and [**Podstawianie czcionek**](/slides/pl/net/font-substitution/).

When investigating font selection:

1. Resolve the requested family and style, including any theme reference.
2. Check embedded fonts and registered sources, including system fonts and fonts loaded by the application. Use the preference below when matching embedded and registered versions compete.
3. Review [reguły podstawiania czcionek](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) and glyph fallback if the requested font or characters are unavailable.

Aspose.Slides allows you to add fonts to application runtime and then use those fonts. See [**Czcionki niestandardowe**](/slides/pl/net/custom-font/).

When additional fonts are placed within a presentation, they are called [**Czcionki osadzone**](/slides/pl/net/embedded-font/).

Aspose.Slides allows you to add fonts that are applied to *only* output documents. For example, if a presentation you are looking to convert to PDF contains fonts missing from your system and embedded fonts, you can add or load the needed fonts as **external fonts**. 

{{% alert title="Note" color="info" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}

## **Preferowanie czcionek zarejestrowanych nad czcionkami osadzonymi**

Starting with .NET 26.11, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) lets a matching registered font take priority over an embedded font during export. The default is `false`. Matching uses the font name and style; a different family name is not a replacement match. Registered fonts can come from the system or [explicitly loaded font sources](/slides/pl/net/custom-font/).

The following example uses the **Aspose.Slides.NET6.CrossPlatform 26.11** package on .NET 8. Follow the [przewodnik instalacji](/slides/pl/net/installation/) for your environment. Provide `embedded-fonts.pptx` with an embedded font and `preferred.ttf` with the same family name and style. The two font files should differ visibly if you want to compare the output.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

This setting changes font precedence during the export; it does not rename the text's font, remove embedded font data or re-embed the registered file. It is a runtime setting: set it again after reopening a presentation. If no matching registered font is available, enabling the preference does not supply one; verify the resulting font and layout in your target environment.

PNG and PDF output with explicitly loaded regular fonts were checked for the configuration above. Check your own font files, styles, SDK build and output formats before depending on identical results. Font metrics can change line breaks and positioning. Use [zamiana czcionek](/slides/pl/net/font-replacement/) or [podstawianie](/slides/pl/net/font-substitution/) when you need a different family, and [operacje na czcionkach osadzonych](/slides/pl/net/embedded-font/) when you need to change the fonts stored in the presentation.

## **FAQ**

**Jak mogę określić, które czcionki są faktycznie użyte w prezentacji przed konwersją?**

Aspose.Slides umożliwia sprawdzenie używanych czcionek za pomocą [menedżera czcionek](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), dzięki czemu możesz zdecydować, czy [osadzić](/slides/pl/net/embedded-font/), [zastąpić](/slides/pl/net/font-replacement/), czy dodać [zewnętrzne źródła](/slides/pl/net/custom-font/). To pomaga zapobiec niechcianym podstawieniom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [zewnętrzne źródła czcionek](/slides/pl/net/custom-font/), takie jak foldery lub strumienie w pamięci, do renderowania i eksportu. To usuwa zależność od czcionek systemowych i utrzymuje układ przewidywalnym.

**Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj explicite [zamiana czcionek](/slides/pl/net/font-replacement/) i font [reguły zastępowania](/slides/pl/net/fallback-font/) z wyprzedzeniem. Analizując używane czcionki i ustawiając kontrolowany priorytet dla zamienników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.