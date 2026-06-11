---
title: Hämta och uppdatera presentationsvyegenskaper i PHP
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/php-java/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- outlinet innehåll
- inehållsöversiktsikoner
- fästa vertikal delare
- enkel vy
- fältstatus
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Upptäck Aspose.Slides för PHP via Java vyegenskaper för att anpassa PPT-, PPTX- och ODP-formatens bilder — justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Den normala vyn består av tre innehållsregioner: själva bilden, en sidoinnehållsregion och en botteninnehållsregion. Egenskaper som rör placeringen av de olika innehållsregionerna. Denna information gör det möjligt för programmet att spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) har lagts till för att ge åtkomst till normalvypegenskaper för presentationen.  

[NormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties) klasser och deras underklasser, [SplitterBarStateType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType) enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvypegenskaper.

Metoderna [getShowOutlineIcons](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) och [setShowOutlineIcons](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) anger om programmet ska visa ikoner när det visar innehållsöversikt i någon av innehållsregionerna i normalvyläget.

Metoderna [getSnapVerticalSplitter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) och [setSnapVerticalSplitter](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) anger om den vertikala delaren ska fästa i ett minimerat läge när sidoregionen är tillräckligt liten.

Egenskapen [getPreferSingleView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) och [setPreferSingleView](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) anger om användaren föredrar att se ett helfönsterrum med ett enda innehållsområde framför den standardnormala vyn med tre innehållsregioner. Om den är aktiverad kan programmet välja att visa en av innehållsregionerna i hela fönstret.

Metoderna [getVerticalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) specificerar i vilket tillstånd den horisontella eller vertikala delarbalken ska visas. En horisontell delarbalk separerar bilden från innehållsregionen under bilden, en vertikal delarbalk separerar bilden från sidoinnehållsregionen. Möjliga värden är: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Maximized) och [SplitterBarStateType::Restored](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metoderna [getRestoredLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) och [getRestoredTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties#getRestoredTop) specificerar storleken på den övre eller sidobildregionen i normalvyn när värdet [SplitterBarStateType::Restored](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SplitterBarStateType/#Restored) tillämpas för [getVerticalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) och [getHorizontalBarState](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respektive.

## **Om återställning av INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett barn till [getRestoredTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), höjd när den är ett barn till [getRestoredLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).  

Metoden [getDimensionSize](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) specificerar storleken på bildregionen (bredd när den är ett barn till restoredTop, höjd när den är ett barn till restoredLeft).  

Metoden [getAutoAdjust](https://reference.aspose.com/slides/sv/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) anger om storleken på sidoinnehållsregionen ska anpassas till den nya storleken när fönstret som innehåller vyn i programmet ändras i storlek.  

Ett exempel ges nedan som visar hur du kan komma åt [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) egenskaper för en presentation.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Återställ vyegenskaperna för presentationen
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Ställ in standardzoomvärdet**
{{% alert color="primary" %}} 

Aspose.Slides för PHP via Java stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för en presentation. [getSlideViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) samt [getNotesViewProperties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) kan ställas in programmatiskt. I detta avsnitt kommer vi med ett exempel att visa hur man sätter [View Properties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation) i [Aspose.Slides](/slides/sv/).

{{% /alert %}} 

För att ställa in vyegenskaperna följer du stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Ställ in [View Properties](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ViewProperties) för [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Skriv presentationen som en [PPTX ](https://docs.fileformat.com/presentation/pptx/)fil. I exemplet nedan har vi ställt in zoomvärdet för bildvyn samt för notvyn.

```php
  $presentation = new Presentation();
  try {
    # Ställer in vyegenskaperna för presentationen
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Zoomvärde i procent för bildvyn
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Zoomvärde i procent för notvyn

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**Kan jag ange olika vyinställningar för olika sektioner i en presentation?**

View settings (https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getviewproperties/) are defined at the presentation level (https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/(https://reference.aspose.com/slides/sv/php-java/aspose.slides/viewproperties/getslideviewproperties/), not per section, so a single set of parameters applies to the entire document when it opens.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men själva filen innehåller en enda uppsättning vyegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom view properties (https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getviewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.