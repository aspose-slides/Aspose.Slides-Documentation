---
title: Skapa diagram med VSTO och Aspose.Slides för Java
linktitle: Skapa diagram
type: docs
weight: 70
url: /sv/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- skapa diagram
- migrering
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du automatiserar skapandet av PowerPoint‑diagram i Java. Denna steg‑för‑steg‑guide visar varför Aspose.Slides för Java är ett snabbare, kraftfullare alternativ till Microsoft.Office.Interop."
---
{{% alert color="primary" %}} 

Diagram är visuella representationer av data som används flitigt i presentationer. Denna artikel visar koden för att skapa ett diagram i Microsoft PowerPoint programmässigt genom att använda [VSTO](/slides/sv/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) och [Aspose.Slides for Java](/slides/sv/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Skapa ett diagram**
Kodexemplen nedan beskriver processen för att lägga till ett enkelt 3D‑klustrat stapeldiagram med VSTO. Du skapar ett presentations‑instans, lägger till ett standarddiagram i den. Därefter använder du en Microsoft Excel‑arbetsbok för att komma åt och ändra diagramdata samt ställa in diagramegenskaper. Slutligen sparas presentationen.
### **VSTO‑exempel**
Med VSTO utförs följande steg:

1. Skapa en instans av en Microsoft PowerPoint‑presentation.
1. Lägg till en tom bild i presentationen.
1. Lägg till ett **3D‑klustrat stapeldiagram** och kom åt det.
1. Skapa en ny Microsoft Excel‑arbetsboksinstans och läs in diagramdata.
1. Kom åt diagramdata‑arbetsbladet med hjälp av Microsoft Excel‑arbetsboksinstansen instancefromworkbook.
1. Ställ in diagramområdet i arbetsbladet och ta bort serierna 2 och 3 från diagrammet.
1. Ändra diagrammets kategoridata i diagramdata‑arbetsbladet.
1. Ändra diagramserie‑1s data i diagramdata‑arbetsbladet.
1. Nu kommer du åt diagrammets titel och setthefontrelatedproperties.
1. Kom åt diagrammets värdeaxel och ställ in huvud‑enheten, mindre enheter, maxvärde och minvärden.
1. Kom åt diagramdjupet eller serieaxeln och ta bort det, eftersom i detta exempel onlyoneserieisused.
1. Nu ställer du in diagrammets rotationsvinklar i X‑ och Y‑riktning.
1. Spara presentationen.
1. Stäng instanserna av Microsoft Excel och PowerPoint.

**Den resulterande presentationen, skapad med VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java‑exempel**
Med Aspose.Slides for Java utförs följande steg:

1. Skapa en instans av en Microsoft PowerPoint‑presentation.
1. Lägg till en tom bild i presentationen.
1. Lägg till ett **3D‑klustrat stapeldiagram** och kom åt det.
1. Kom åt diagramdata‑arbetsbladet med en Microsoft Excel‑arbetsboksinstans instancefromworkbook.
1. Ta bort oanvända serier 2 och 3.
1. Kom åt diagramkategorier och ändra etiketterna.
1. Accesseries1 och ändra serievärdena.
1. Nu kommer du åt diagrammets titel och ställer in teckensnittsegenskaperna.
1. Kom åt diagrammets värdeaxel och ställ in huvud‑enheten, mindre enheter, maxvärde och minvärden.
1. Nu ställer du in diagrammets rotationsvinklar i X‑ och Y‑riktning.
1. Spara presentationen i PPTX‑format.

**Den resulterande presentationen, skapad med Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

**Kan jag skapa andra typer av diagram, såsom paj-, linje- eller stapeldiagram med Aspose.Slides?**

Ja. Aspose.Slides stöder ett brett sortiment av [diagramtyper](/slides/sv/java/create-chart/), inklusive pajdiagram, linjediagram, stapeldiagram, spridningsdiagram, bubbeldiagram och mer. Du kan ange önskad diagramtyp med hjälp av klassen [ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/) när du lägger till ett diagram.

**Kan jag applicera egna stilar eller teman på diagrammet?**

Ja. Du kan anpassa diagrammets utseende helt, inklusive färger, teckensnitt, fyllningar, konturer, rutnät och layout. Att tillämpa Office‑teman exakt som de visas i PowerPoint kräver dock att du manuellt ställer in enskilda stilar.

**Kan jag exportera diagrammet som en bild separat från bilden?**

Ja, Aspose.Slides låter dig exportera vilken form som helst — inklusive diagram — som en separat bild (t.ex. PNG, JPEG) med hjälp av `getImage`‑metoden på diagrammets [shape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/).