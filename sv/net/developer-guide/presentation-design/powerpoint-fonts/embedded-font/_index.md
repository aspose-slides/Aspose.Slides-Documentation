---
title: Bädda in teckensnitt i presentationer i .NET
linktitle: Inbäddning av teckensnitt
type: docs
weight: 40
url: /sv/net/embedded-font/
keywords:
- lägga till teckensnitt
- bädda in teckensnitt
- teckensnittsinbäddning
- hämta inbäddat teckensnitt
- lägga till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Bädda in TrueType-teckensnitt i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET, så att rendering blir exakt på alla plattformar."
---
## **Inledning**

**Att bädda in teckensnitt i PowerPoint** säkerställer att din presentation behåller sitt avsedda utseende på olika system. Oavsett om du använder unika teckensnitt för kreativitet eller standardteckensnitt, förhindrar inbäddning av teckensnitt text‑ och layoutstörningar.

Om du använde ett tredjeparts‑ eller icke‑standardteckensnitt eftersom du var kreativ i ditt arbete, har du ännu fler skäl att bädda in ditt teckensnitt. Annars (utan inbäddade teckensnitt) kan texten eller siffrorna på dina bilder, layouten, stilen etc. förändras eller bli förvirrande rektanglar. 

Använd klasserna FontsManager, FontData och Compress för att hantera inbäddade teckensnitt.

## **Hämta och Ta bort inbäddade teckensnitt**

Hämta eller ta bort inbäddade teckensnitt från en presentation enkelt med metoderna GetEmbeddedFonts och RemoveEmbeddedFont.

Denna C#‑kod visar hur du hämtar och tar bort inbäddade teckensnitt från en presentation:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Renderar en bild som innehåller en textram som använder inbäddat "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Hittar teckensnittet "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Tar bort teckensnittet "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Renderar presentationen; teckensnittet "Calibri" ersätts med ett befintligt
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Sparar presentationen utan inbäddat "Calibri"-teckensnitt till disk
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Lägg till inbäddade teckensnitt**

Genom att använda enumen EmbedFontCharacters och två överlagringar av metoden AddEmbeddedFont kan du välja din föredragna (inbäddnings)regel för att bädda in teckensnitten i en presentation. Denna C#‑kod visar hur du bäddar in och lägger till teckensnitt i en presentation:

```c#
 // Laddar presentationen
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

// Sparar presentationen till disk
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Komprimera inbäddade teckensnitt**

Optimera filstorleken genom att komprimera inbäddade teckensnitt med CompressEmbeddedFonts.

Exempelkod för komprimering:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Hur kan jag se att ett specifikt teckensnitt i presentationen ändå kommer att ersättas vid rendering trots inbäddning?**

Kontrollera ersättningsinformationen [substitution information](/slides/sv/net/font-substitution/) i teckensnittshanteraren och [fallback/substitution rules](/slides/sv/net/fallback-font/): om teckensnittet är otillgängligt eller begränsat används en reserv.

**Är det värt att bädda in "system"-teckensnitt som Arial/Calibri?**

Vanligtvis nej – de är nästan alltid tillgängliga. Men för full portabilitet i "tunna" miljöer (Docker, en Linux‑server utan förinstallerade teckensnitt) kan inbäddning av systemteckensnitt eliminera risken för oväntade ersättningar.