---
title: Hantera bildspel i C++
linktitle: Bildspel
type: docs
weight: 90
url: /sv/cpp/manage-slide-show/
keywords:
- visningstyp
- presenterad av talare
- bläddrad av individ
- bläddrad i kioskläge
- visningsalternativ
- upprepa kontinuerligt
- visning utan berättarröst
- visning utan animation
- penfärg
- visa bilder
- anpassad visning
- avancera bilder
- manuellt
- med tidsinställningar
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hanterar bildspel i Aspose.Slides för C++. Kontrollera bildövergångar, tidsinställningar och mer över PPT, PPTX och ODP-format med lätthet."
---
## **Introduktion**

I Microsoft PowerPoint är **Slide Show**‑inställningarna ett viktigt verktyg för att förbereda och leverera professionella presentationer. En av de mest betydelsefulla funktionerna i detta avsnitt är **Set Up Show**, som låter dig anpassa din presentation efter specifika förutsättningar och målgrupper, vilket ger både flexibilitet och bekvämlighet. Med denna funktion kan du välja visningstyp (t.ex. presenterad av en talare, bläddrad av en individ eller bläddrad i kioskläge), aktivera eller inaktivera loopning, välja specifika bilder att visa och använda tidsinställningar. Detta steg i förberedelsen är avgörande för att göra din presentation mer effektiv och professionell.

`get_SlideShowSettings` är en metod i [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen som returnerar ett objekt av typen [SlideShowSettings](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slideshowsettings/), vilket låter dig hantera slide‑show‑inställningarna i en PowerPoint‑presentation. I den här artikeln kommer vi att gå igenom hur du använder metoden för att konfigurera och kontrollera olika aspekter av slide‑show‑inställningarna. 

## **Välj visningstyp**

`SlideShowSettings.set_SlideShowType` definierar vilken typ av slide‑show som ska användas, och kan vara en instans av någon av följande klasser: [PresentedBySpeaker](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/sv/cpp/aspose.slides/browsedbyindividual/), eller [BrowsedAtKiosk](https://reference.aspose.com/slides/sv/cpp/aspose.slides/browsedatkiosk/). Med denna metod kan du anpassa presentationen för olika användningsscenarier, såsom automatiska kiosker eller manuella presentationer.

Kodexemplet nedan skapar en ny presentation och sätter visningstypen till “Browsed by an individual” utan att visa rullningslisten.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Aktivera visningsalternativ**

`SlideShowSettings.set_Loop` bestämmer om slide‑showen ska upprepas i en loop tills den stoppas manuellt. Detta är användbart för automatiserade presentationer som måste köras kontinuerligt. `SlideShowSettings.set_ShowNarration` bestämmer om röstberättelser ska spelas upp under slide‑showen. Det är praktiskt för automatiserade presentationer som innehåller röstinstruktioner för publiken. `SlideShowSettings.set_ShowAnimation` bestämmer om animationer som lagts till i bildobjekt ska spelas upp. Detta är viktigt för att ge hela den visuella effekten av presentationen.

Följande kodexempel skapar en ny presentation och loopar slide‑showen.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Välj bilder att visa**

`SlideShowSettings.set_Slides`‑metoden låter dig välja ett intervall av bilder som ska visas under presentationen. Detta är användbart när du bara vill visa en del av presentationen snarare än alla bilder. Kodexemplet nedan skapar en ny presentation och anger bildintervallet att visas från bild `2` till `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Använd förinställda tidsinställningar**

`SlideShowSettings.set_UseTimings`‑metoden låter dig aktivera eller inaktivera användning av fördefinierade tidsinställningar för varje bild. Detta är praktiskt för att automatiskt visa bilder med förutbestämda visningstider. Kodexemplet nedan skapar en ny presentation och inaktiverar användning av tidsinställningar.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Visa mediakontroller**

`SlideShowSettings.set_ShowMediaControls`‑metoden bestämmer om mediakontroller (såsom spela, pausa och stoppa) ska visas under slide‑showen när multimediainnehåll (t.ex. video eller ljud) spelas upp. Detta är användbart när du vill ge presentatören kontroll över mediastreamen under presentationen.

Följande kodexempel skapar en ny presentation och aktiverar visning av mediakontroller.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Kan jag spara en presentation så att den öppnas direkt i slide‑show‑läge?**

Ja. Spara filen som PPSX eller PPSM; dessa format startar direkt i slide‑show när de öppnas i PowerPoint. I Aspose.Slides väljer du motsvarande spara‑format [under export](/slides/sv/cpp/save-presentation/).

**Kan jag utesluta enskilda bilder från visningen utan att ta bort dem från filen?**

Ja. Markera en bild som [hidden](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/set_hidden/). Dolda bilder finns kvar i presentationen men visas inte under slide‑showen.

**Kan Aspose.Slides spela upp en slide‑show eller kontrollera en live‑presentation på skärmen?**

Nej. Aspose.Slides redigerar, analyserar och konverterar presentationsfiler; den faktiska uppspelningen hanteras av en visningsapplikation såsom PowerPoint.