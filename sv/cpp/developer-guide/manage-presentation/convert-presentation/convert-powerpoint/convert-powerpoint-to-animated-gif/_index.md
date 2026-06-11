---
title: Konvertera PowerPoint-presentationer till animerade GIF-filer i C++
linktitle: PowerPoint till GIF
type: docs
weight: 65
url: /sv/cpp/convert-powerpoint-to-animated-gif/
keywords:
- animerad GIF
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till GIF
- presentation till GIF
- bild till GIF
- PPT till GIF
- PPTX till GIF
- spara PPT som GIF
- spara PPTX som GIF
- exportera PPT som GIF
- exportera PPTX som GIF
- standardinställningar
- anpassade inställningar
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Konvertera enkelt PowerPoint-presentationer (PPT, PPTX) till animerade GIF-filer med Aspose.Slides för C++. Snabba, högkvalitativa resultat."
---
## **Översikt**

Aspose.Slides låter dig konvertera PowerPoint‑presentationer till animerade GIF‑filer med bara några rader kod. Detta är användbart när du behöver dela bildinnehåll i ett lättviktigt, brett stödt animerat format som kan bäddas in i webbsidor, meddelandetjänster eller dokumentation. Denna artikel förklarar hur du exporterar en presentation till GIF med standardinställningar och hur du anpassar resultatet genom att konfigurera alternativ som bildstorlek, bildfördröjning och övergångshastighet via [GifOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/gifoptions/).

## **Konvertera presentationer till animerad GIF med standardinställningar**

Denna exempelkod i C++ visar hur du konverterar en presentation till animerad GIF med standardinställningar:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Den animerade GIF‑en skapas med standardparametrar. 

{{%  alert  title="TIPS"  color="primary"  %}} 

Om du föredrar att anpassa parametrarna för GIF‑en kan du använda klassen [GifOptions](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.gif_options). Se exempelkoden nedan. 

{{% /alert %}} 

## **Konvertera presentationer till animerad GIF med anpassade inställningar**

Denna exempelkod visar hur du konverterar en presentation till animerad GIF med anpassade inställningar i C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// storleken på den resulterande GIF-filen
gifOptions->set_FrameSize(Size(960, 720));
// hur länge varje bild visas innan den byts till nästa
gifOptions->set_DefaultDelay(2000);
// öka FPS för bättre övergångsanimeringskvalitet
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Du kanske vill prova en GRATIS [Text till GIF](https://products.aspose.app/slides/sv/text-to-gif)‑konverterare som utvecklats av Aspose. 

{{% /alert %}}

## **FAQ**

**Vad händer om teckensnitten som används i presentationen inte är installerade på systemet?**

Installera de saknade teckensnitten eller [konfigurera reservtypsnitt](/slides/sv/cpp/powerpoint-fonts/). Aspose.Slides ersätter dem, men utseendet kan skilja sig. För varumärkesprofilering bör du alltid säkerställa att de nödvändiga teckensnitten explicit finns tillgängliga.

**Kan jag lägga ett vattenmärke ovanpå GIF‑bilderna?**

Ja. [Lägg till ett semitransparent objekt/logo](/slides/sv/cpp/watermark/) på huvudbilden eller på enskilda bilder innan export – vattenmärket visas på varje bildruta.