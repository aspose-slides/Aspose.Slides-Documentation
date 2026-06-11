---
title: Animera PowerPoint-diagram i C++
linktitle: Animerade diagram
type: docs
weight: 80
url: /sv/cpp/animated-charts/
keywords:
- diagram
- animerat diagram
- diagramanimation
- diagramserie
- diagramkategori
- serieelement
- kategorielelement
- lägg till effekt
- effekttyp
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa fantastiska animerade diagram i C++ med Aspose.Slides. Förbättra presentationer med dynamiska visuella element i PPT- och PPTX-filer - kom igång nu."
---
## **Introduktion**

Aspose.Slides stöder att animera diagrammets element. **Series**, **Categories**, **Series Elements**, **Categories Elements** kan animeras med [ISequence::AddEffect](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/isequence/addeffect/) metod och två uppräkningar [EffectChartMajorGroupingType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) och [EffectChartMinorGroupingType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Diagramserieanimation**
Om du vill animera en diagramserie, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera serien.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat diagramserier.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animation i ett serieelement**
Om du vill animera serieelement, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera serieelementen.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat serieelementen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Diagramkategorianimation**
Om du vill animera en diagramkategori, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera kategorin.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat diagramkategorin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animation i ett kategori­element**
Om du vill animera kategori­element, skriv koden enligt stegen nedan:

1. Läs in en presentation.
2. Hämta referensen till diagramobjektet.
3. Animera kategori­elementen.
4. Skriv presentationsfilen till disk.

I exemplet nedan har vi animerat kategori­elementen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Stöds olika effekt­typer (t.ex. inträde, betoning, avslut) för diagram på samma sätt som för vanliga former?**

Ja. Ett diagram behandlas som en form, så det stöder de standardanimationseffekttyperna, inklusive inträde, betoning och avslut, med full kontroll via bildens tidslinje och animationssekvenser.

**Kan jag kombinera diagramanimation med bildövergångar?**

Ja. [Transitions](/slides/sv/cpp/slide-transition/) gäller för bilden, medan animationseffekter gäller för objekt på bilden. Du kan använda båda tillsammans i samma presentation och styra dem oberoende.

**Behålls diagramanimationer när man sparar som PPTX?**

Ja. När du [sparar som PPTX](/slides/sv/cpp/save-presentation/) bevaras alla animationseffekter och deras ordning eftersom de är en del av presentationens inbyggda animationsmodell.

**Kan jag läsa befintliga diagramanimationer från en presentation och ändra dem?**

Ja. [API](https://reference.aspose.com/slides/sv/cpp/aspose.slides.animation/) ger åtkomst till bildens tidslinje, sekvenser och effekter, vilket gör att du kan inspektera befintliga diagramanimationer och justera dem utan att återskapa allt från början.

**Kan jag skapa en video som inkluderar diagramanimationer med Aspose.Slides?**

Ja. Du kan [exportera en presentation till video](/slides/sv/cpp/convert-powerpoint-to-video/) samtidigt som du bevarar animationerna, konfigurerar tidsinställningar och andra exportinställningar så att den färdiga klippet återger den animerade uppspelningen.