---
title: Hämta och uppdatera presentationsinformation på Android
linktitle: Presentationsinformation
type: docs
weight: 30
url: /sv/androidjava/examine-presentation/
keywords:
- presentationsformat
- presentationsegenskaper
- dokumentegenskaper
- hämta egenskaper
- läsa egenskaper
- ändra egenskaper
- modifiera egenskaper
- uppdatera egenskaper
- undersöka PPTX
- undersöka PPT
- undersöka ODP
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Utforska bilder, struktur och metadata i PowerPoint- och OpenDocument-presentationer med Java för snabbare insikter och smartare innehållsgranskningar."
---
## **Översikt**

Den här artikeln visar hur du inspekterar presentationsinformation i Aspose.Slides. Den förklarar hur du avgör en presentations aktuella format utan att läsa in hela filen, läser dess dokumentegenskaper och uppdaterar dessa egenskaper när det behövs.

Exemplen baseras på API:erna [PresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationinfo/) och [DocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/documentproperties/) och demonstrerar typiska operationer för att arbeta med presentationsmetadata.

## **Kontrollera presentationsformat**

Innan du arbetar med en presentation kan du vilja ta reda på vilket format (PPT, PPTX, ODP och andra) presentationen för närvarande har.

Du kan kontrollera en presentations format utan att läsa in presentationen. Se denna Java-kod:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Hämta presentationsegenskaper**

Denna Java-kod visar hur du hämtar presentationsegenskaper (information om presentationen):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Du kanske vill se [egenskaperna under DocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) klassen.

## **Uppdatera presentationsegenskaper**

Aspose.Slides tillhandahåller metoden [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) som låter dig göra ändringar i presentationsegenskaper.

Låt oss säga att vi har en PowerPoint-presentation med dokumentegenskaperna som visas nedan.

![Ursprungliga dokumentegenskaper för PowerPoint-presentationen](input_properties.png)

Detta kodexempel visar hur du redigerar vissa presentationsegenskaper:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Resultaten av att ändra dokumentegenskaperna visas nedan.

![Ändrade dokumentegenskaper för PowerPoint-presentationen](output_properties.png)

## **Användbara länkar**

För att få mer information om en presentation och dess säkerhetsattribut kan du finna dessa länkar användbara:

- [Kontrollera om en presentation är krypterad](https://docs.aspose.com/slides/sv/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrollera om en presentation är skrivskyddad (skrivskyddad)](https://docs.aspose.com/slides/sv/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrollera om en presentation är lösenordsskyddad innan den läses in](https://docs.aspose.com/slides/sv/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bekräfta lösenordet som används för att skydda en presentation](https://docs.aspose.com/slides/sv/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Vanliga frågor**

**Hur kan jag kontrollera om teckensnitt är inbäddade och vilka de är?**

Leta efter [information om inbäddade teckensnitt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) på presentationsnivå, jämför sedan dessa poster med mängden [teckensnitt som faktiskt används i innehållet](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/#getFonts--) för att identifiera vilka teckensnitt som är kritiska för rendering.

**Hur kan jag snabbt avgöra om filen har dolda bilder och hur många?**

Iterera genom [bildsamlingen](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidecollection/) och inspektera varje bilds [synlighetsflagga](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/#getHidden--).

**Kan jag upptäcka om anpassad bildstorlek och orientering används, och om de skiljer sig från standardvärdena?**

Ja. Jämför den aktuella [bildstorleken](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSlideSize--) och orienteringen med standardinställningarna; detta hjälper dig förutse beteende vid utskrift och export.

**Finns det ett snabbt sätt att se om diagram refererar till externa datakällor?**

Ja. Gå igenom alla [diagram](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/), kontrollera deras [datakälla](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) och notera om data är intern eller baserad på en länk, inklusive eventuella brutna länkar.

**Hur kan jag bedöma 'tunga' bilder som kan sakta ner rendering eller PDF-export?**

För varje bild, räkna antalet objekt och leta efter stora bilder, transparens, skuggor, animationer och multimedia; tilldela ett grovt komplexitetspoäng för att flagga potentiella prestandaproblem.