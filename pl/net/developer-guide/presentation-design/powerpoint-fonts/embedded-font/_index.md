---
title: Osadzanie czcionek w prezentacjach w .NET
linktitle: Osadzanie czcionki
type: docs
weight: 40
url: /pl/net/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionki
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- kompresuj osadzoną czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Osadź czcionki TrueType w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET, zapewniając dokładne renderowanie na wszystkich platformach."
---
## **Wprowadzenie**

**Osadzanie czcionek w PowerPoint** zapewnia, że Twoja prezentacja zachowuje zamierzony wygląd na różnych systemach. Bez względu na to, czy używasz unikalnych czcionek dla kreatywności, czy standardowych, osadzanie czcionek zapobiega zakłóceniom tekstu i układu.

Jeśli użyłeś czcionki firm trzecich lub niestandardowej, ponieważ byłeś kreatywny w swojej pracy, masz jeszcze więcej powodów, aby osadzić swoją czcionkę. W przeciwnym razie (bez osadzonych czcionek) teksty lub liczby na slajdach, układ, stylizacja itp. mogą się zmienić lub zamienić w mylące prostokąty.

Użyj klas [FontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/pl/net/aspose.slides/fontdata/), i [Compress](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/) aby zarządzać osadzonymi czcionkami.

## **Pobieranie i usuwanie osadzonych czcionek**

Łatwo pobieraj lub usuwaj osadzone czcionki z prezentacji przy użyciu metod [GetEmbeddedFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getembeddedfonts) i [RemoveEmbeddedFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/removeembeddedfont).

Ten kod C# pokazuje, jak pobrać i usunąć osadzone czcionki z prezentacji:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Renderuje slajd zawierający ramkę tekstową, która używa osadzonej "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Znajduje czcionkę "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Usuwa czcionkę "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Renderuje prezentację; czcionka "Calibri" zostaje zastąpiona istniejącą
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Zapisuje prezentację bez osadzonej "Calibri" font do dysku
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Dodawanie osadzonych czcionek**

Korzystając z wyliczenia [EmbedFontCharacters](https://reference.aspose.com/slides/pl/net/aspose.slides.export/embedfontcharacters/) oraz dwóch przeciążeń metody [AddEmbeddedFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/addembeddedfont/), możesz wybrać preferowaną regułę (osadzania), aby osadzić czcionki w prezentacji. Ten kod C# pokazuje, jak osadzić i dodać czcionki do prezentacji:

```c#
 // Ładuje prezentację
 Presentation presentation = new Presentation("Fonts.pptx");

 IFontData[] allFonts = presentation.FontsManager.GetFonts();
 IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
 foreach (IFontData font in allFonts)
 {
     if (!embeddedFonts.Contains(font))
     {
         presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
     }
 }

 // Zapisuje prezentację na dysku
 presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Kompresja osadzonych czcionek**

Optymalizuj rozmiar pliku, kompresując osadzone czcionki za pomocą [CompressEmbeddedFonts](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Przykładowy kod kompresji:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Jak mogę sprawdzić, że konkretna czcionka w prezentacji będzie nadal zastępowana podczas renderowania pomimo osadzenia?**

Sprawdź [informacje o substytucji](/slides/pl/net/font-substitution/) w menedżerze czcionek oraz [zasady zastępowania/fallback](/slides/pl/net/fallback-font/): jeśli czcionka jest niedostępna lub ograniczona, zostanie użyty fallback.

**Czy warto osadzać czcionki systemowe, takie jak Arial/Calibri?**

Zazwyczaj nie - są prawie zawsze dostępne. Jednak w celu pełnej przenośności w "cienkich" środowiskach (Docker, serwer Linux bez preinstalowanych czcionek) osadzanie czcionek systemowych może wyeliminować ryzyko nieoczekiwanych substytucji.