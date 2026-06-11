---
title: Hämta och uppdatera presentationsinformation i C++
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/cpp/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- undersök PPTX
- undersök PPT
- undersök ODP
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med C++ för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Den här artikeln visar hur du inspekterar presentationsinformation i Aspose.Slides. Den förklarar hur du bestämmer en presentations aktuella format utan att läsa in hela filen, läser dess dokumentegenskaper och uppdaterar dessa egenskaper vid behov.

Exemplen är baserade på API:erna [PresentationInfo](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationinfo/) och [DocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/documentproperties/) samt demonstrerar typiska operationer för att arbeta med presentationsmetadata.

## **Kontrollera presentationsformat**

Innan du arbetar med en presentation kan du vilja ta reda på vilket format (PPT, PPTX, ODP och andra) presentationen för närvarande har.

Du kan kontrollera en presentations format utan att läsa in presentationen. Se den här C++-koden:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Hämta presentationsegenskaper**

Den här C++-koden visar hur du hämtar presentationsegenskaper (information om presentationen):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ...
```

## **Uppdatera presentationsegenskaper**

Aspose.Slides tillhandahåller metoden [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) som låter dig göra ändringar i presentationsegenskaper.

Låt oss säga att vi har en PowerPoint-presentation med dokumentegenskaperna som visas nedan.

![Originala dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Detta kodexempel visar hur du redigerar vissa presentationsegenskaper:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Resultaten av att ändra dokumentegenskaperna visas nedan.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För att få mer information om en presentation och dess säkerhetsattribut kan du finna dessa länkar användbara:

- [Kontrollera om en presentation är krypterad](https://docs.aspose.com/slides/sv/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrollera om en presentation är skrivskyddad (endast läsning)](https://docs.aspose.com/slides/sv/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrollera om en presentation är lösenordsskyddad innan den läses in](https://docs.aspose.com/slides/sv/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bekräfta lösenordet som används för att skydda en presentation](https://docs.aspose.com/slides/sv/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Hur kan jag kontrollera om typsnitt är inbäddade och vilka de är?**

Leta efter [information om inbäddade typsnitt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getembeddedfonts/) på presentationsnivå, jämför sedan dessa poster med uppsättningen av [typsnitt som faktiskt används i innehållet](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsmanager/getfonts/) för att identifiera vilka typsnitt som är kritiska för rendering.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

Iterera genom [bildsamlingen](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidecollection/) och inspektera varje bilds [synlighetsflagga](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slide/get_hidden/).

**Kan jag upptäcka om en anpassad bildstorlek och orientering används, och om de skiljer sig från standardinställningarna?**

Ja. Jämför den aktuella [bildstorleken och orienteringen](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_slidesize/) med standardförinställningarna; detta hjälper dig att förutse beteendet vid utskrift och export.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Gå igenom alla [diagram](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chart/), kontrollera deras [datakälla](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), och notera om data är intern eller länkbunden, inklusive eventuella brutna länkar.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ner rendering eller PDF-export?**

För varje bild räknar du antalet objekt och letar efter stora bilder, transparens, skuggor, animationer och multimedia; tilldela ett grovt komplexitetspoäng för att flagga potentiella prestandaproblem.