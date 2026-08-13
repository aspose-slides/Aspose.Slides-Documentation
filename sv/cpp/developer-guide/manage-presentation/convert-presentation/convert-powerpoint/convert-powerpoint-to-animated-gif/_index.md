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

Aspose.Slides låter dig konvertera PowerPoint‑presentationer till animerade GIF‑filer med bara några få rader kod. Detta är användbart när du behöver dela bildinnehåll i ett lättviktigt, allmänt stödt animerat format som kan bäddas in i webbsidor, meddelandeappar eller dokumentation. Denna artikel förklarar hur du exporterar en presentation till GIF med standardinställningar och hur du anpassar resultatet genom att konfigurera alternativ såsom bildstorlek, bildfördröjning och övergångshastighet via [GifOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/gifoptions/).

## **Konvertera presentationer till animerad GIF med standardinställningar**

Denna exempel kod i C++ visar hur du konverterar en presentation till animerad GIF med standardinställningar:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Den animerade GIF‑filen kommer att skapas med standardparametrar.

{{%  alert  title="TIP"  color="info"  %}} 
Om du föredrar att anpassa parametrarna för GIF‑filen kan du använda klassen [GifOptions](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.gif_options). Se exempel koden nedan. 
{{% /alert %}} 

## **Konvertera presentationer till animerad GIF med anpassade inställningar**

Denna exempel kod visar hur du konverterar en presentation till animerad GIF med anpassade inställningar i C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// storleken på den resulterande GIF-filen
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// hur länge varje bild visas innan den byts till nästa
gifOptions->set_DefaultDelay(2000);
// öka FPS för bättre övergångsanimeringskvalitet
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Du kanske vill kolla in en GRATIS [Text to GIF](https://products.aspose.app/slides/sv/text-to-gif) konverterare utvecklad av Aspose. 
{{% /alert %}}

## **Vanliga frågor**

### Vad händer om teckensnitten som används i presentationen inte är installerade på systemet?

Installera de saknade teckensnitten eller [configure fallback fonts](/slides/sv/cpp/powerpoint-fonts/). Aspose.Slides kommer att ersätta dem, men utseendet kan skilja sig. För varumärkesidentitet, se alltid till att de nödvändiga teckensnitten finns explicit tillgängliga.

### Kan jag överlagra ett vattenmärke på GIF‑ramarna?

Ja. [Add a semi-transparent object/logo](/slides/sv/cpp/watermark/) till mastern eller till enskilda bilder innan export — vattenmärket kommer att visas på varje ram.