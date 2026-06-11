---
title: Animera PowerPoint-text i C++
linktitle: Animera text
type: docs
weight: 60
url: /sv/cpp/animated-text/
keywords:
- animerad text
- textanimation
- animerat stycke
- styckeanimation
- animationseffekt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Skapa dynamisk animerad text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++, med lättbegripliga, optimerade C++-kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med animerad text i Aspose.Slides genom att tillämpa animationseffekter på enskilda stycken och hämta de effekter som redan har tilldelats stycken i en textram. Den fokuserar på API‑metoderna som används för att lägga till stycke‑nivåanimation och inspektera befintliga stycke‑animations­effekter i en presentation.

## **Lägg till animationseffekter på stycken**

Vi har lagt till metoden [**AddEffect()**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) till klasserna [**Sequence**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.sequence) och [**ISequence**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.animation.i_sequence). Den här metoden låter dig lägga till animationseffekter på ett enskilt stycke. Följande exempel visar hur du lägger till en animationseffekt på ett enskilt stycke:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// välj stycke för att lägga till effekt
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// lägg till Fly-animeringseffekt på valt stycke
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Hämta animationseffekter för stycken**

Du kan vilja ta reda på vilka animationseffekter som har lagts till ett stycke; till exempel, i ett scenario vill du hämta animationseffekterna i ett stycke eftersom du planerar att applicera dessa effekter på ett annat stycke eller en annan form.

Aspose.Slides for C++ låter dig hämta alla animationseffekter som tillämpas på stycken som finns i en textram (form). Följande exempel visar hur du hämtar animationseffekterna i ett stycke:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **FAQ**

**Hur skiljer sig textanimationer från bildövergångar, och kan de kombineras?**

Textanimationer styr objektets beteende över tid på en bild, medan [transitions](/slides/sv/cpp/slide-transition/) styr hur bilder förändras. De är oberoende och kan användas tillsammans; uppspelningsordningen bestäms av animationstidslinjen och övergångsinställningarna.

**Behålls textanimationer vid export till PDF eller bilder?**

Nej. PDF‑filer och rasterbilder är statiska, så du ser ett enda tillstånd av bilden utan rörelse. För att behålla rörelsen, använd export till [video](/slides/sv/cpp/convert-powerpoint-to-video/) eller [HTML](/slides/sv/cpp/export-to-html5/).

**Fungerar textanimationer i layouter och bildmästaren?**

Effekter som tillämpas på layout‑/mästare‑objekt ärvs av bilder, men deras timing och samspel med bildnivåanimationer beror på den slutgiltiga sekvensen på bilden.