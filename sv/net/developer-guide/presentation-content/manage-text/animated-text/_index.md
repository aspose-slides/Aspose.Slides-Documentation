---
title: Animera PowerPoint-text i .NET
linktitle: Animerad text
type: docs
weight: 60
url: /sv/net/animated-text/
keywords:
- animerad text
- textanimation
- animerat stycke
- styckeanimation
- animeringseffekt
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa dynamisk animerad text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET, med lättförståeliga, optimerade C#-kodexempel."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med animerad text i Aspose.Slides genom att tillämpa animeringseffekter på enskilda stycken och hämta de effekter som redan har tilldelats stycken i en textram. Den fokuserar på API‑metoderna som används för att lägga till animering på stycknivå och inspektera befintliga animeringseffekter för stycken i en presentation.

## **Lägg till animeringseffekter på stycken**

Vi har lagt till metoden [**AddEffect()**](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/sequence/methods/addeffect/index) i klasserna [**Sequence**](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/sequence) och [**ISequence**](https://reference.aspose.com/slides/sv/net/aspose.slides.animation/isequence). Denna metod låter dig lägga till animeringseffekter på ett enskilt stycke. Följande exempel visar hur du lägger till en animeringseffekt på ett stycke:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // välj stycke för att lägga till effekt
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // lägg till Fly-animeringseffekt till valt stycke
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Hämta animeringseffekter för stycken**

Du kanske vill ta reda på vilka animeringseffekter som har lagts till ett stycke – till exempel i ett scenario där du vill hämta animeringseffekterna i ett stycke för att sedan tillämpa dem på ett annat stycke eller en annan form.

Aspose.Slides för .NET låter dig hämta alla animeringseffekter som har applicerats på stycken i en textram (form). Följande exempel visar hur du hämtar animeringseffekterna i ett stycke:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**Hur skiljer sig textanimationer från bildövergångar, och kan de kombineras?**

Textanimationer styr objekts beteende över tid på en bild, medan [transitions](/slides/sv/net/slide-transition/) styr hur bilder byts. De är oberoende och kan användas tillsammans; uppspelningsordningen styrs av animeringstidslinjen och övergångsinställningarna.

**Behålls textanimationer vid export till PDF eller bilder?**

Nej. PDF och rasterbilder är statiska, så du ser ett enda bildläge utan rörelse. För att behålla rörelse, använd [video](/slides/sv/net/convert-powerpoint-to-video/) eller [HTML](/slides/sv/net/export-to-html5/) export.

**Fungerar textanimationer i layouter och bildbakgrunden?**

Effekter som appliceras på layout-/masterobjekt ärvs av bilder, men deras timing och interaktion med bildnivåanimationer beror på den slutliga sekvensen på bilden.