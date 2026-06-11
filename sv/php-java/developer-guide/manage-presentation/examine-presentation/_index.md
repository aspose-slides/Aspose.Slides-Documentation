---
title: Hämta och uppdatera presentationsinformation i PHP
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Denna artikel visar hur du inspekterar presentationsinformation i Aspose.Slides. Den förklarar hur du bestämmer en presentations nuvarande format utan att läsa in hela filen, läser dess dokumentegenskaper och uppdaterar dessa egenskaper vid behov.

Exemplen är baserade på API:erna [PresentationInfo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentationinfo/) och [DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/) och demonstrerar typiska operationer för att arbeta med presentationsmetadata.

## **Kontrollera presentationsformat**

Innan du arbetar med en presentation kan du vilja ta reda på vilket format (PPT, PPTX, ODP och andra) presentationen för närvarande har.

Du kan kontrollera en presentations format utan att läsa in presentationen. Se denna PHP‑kod:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Hämta presentationsegenskaper**

Denna PHP‑kod visar hur du hämtar presentations‑egenskaper (information om presentationen):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Du kanske vill se [egenskaperna under DocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#DocumentProperties--) klassen.

## **Uppdatera presentationsegenskaper**

Aspose.Slides tillhandahåller metoden [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) som låter dig göra ändringar i presentations‑egenskaper.

Låt oss säga att vi har en PowerPoint‑presentation med dokumentegenskaperna som visas nedan.

![Originala dokumentegenskaper för PowerPoint‑presentationen](input_properties.png)

Detta kodexempel visar hur du redigerar vissa presentations‑egenskaper:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Resultaten av att ändra dokumentegenskaperna visas nedan.

![Ändrade dokumentegenskaper för PowerPoint‑presentationen](output_properties.png)

## **Användbara länkar**

För att få mer information om en presentation och dess säkerhetsattribut kan du finna dessa länkar användbara:

- [Kontrollera om en presentation är krypterad](https://docs.aspose.com/slides/sv/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrollera om en presentation är skrivskyddad (read-only)](https://docs.aspose.com/slides/sv/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrollera om en presentation är lösenordsskyddad innan den laddas](https://docs.aspose.com/slides/sv/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bekräfta lösenordet som används för att skydda en presentation](https://docs.aspose.com/slides/sv/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Vanliga frågor**

**Hur kan jag kontrollera om teckensnitt är inbäddade och vilka de är?**

Sök efter [information om inbäddade teckensnitt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getembeddedfonts/) på presentationsnivå, jämför sedan dessa poster med mängden [teckensnitt som faktiskt används i innehållet](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/getfonts/) för att identifiera vilka teckensnitt som är kritiska för rendering.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

Iterera genom [bildsamlingen](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/) och inspektera varje bilds [synlighetsflagga](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/gethidden/).

**Kan jag upptäcka om anpassad bildstorlek och -orientering används, och om de skiljer sig från standardinställningarna?**

Ja. Jämför den aktuella [bildstorleken](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getslidesize/) och orienteringen med standardinställningarna; detta hjälper dig att förutse beteende vid utskrift och export.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Gå igenom alla [diagram](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/), kontrollera deras [datakälla](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/getdatasourcetype/), och notera om data är intern eller länkbasserad, inklusive eventuella brutna länkar.

**Hur kan jag bedöma “tunga” bilder som kan sakta rendering eller PDF‑export?**

För varje bild räknar du objektantalet och letar efter stora bilder, transparens, skuggor, animationer och multimedia; tilldela en grov komplexitetspoäng för att flagga potentiella prestandaflaskhalsar.