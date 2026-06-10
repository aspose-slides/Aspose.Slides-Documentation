---
title: PowerPoint diagramok animálása C++-ban
linktitle: Animált diagramok
type: docs
weight: 80
url: /hu/cpp/animated-charts/
keywords:
- diagram
- animált diagram
- diagram animáció
- diagram sorozat
- diagram kategória
- sorozat elem
- kategória elem
- effektus hozzáadása
- effektus típusa
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Hozzon létre lenyűgöző animált diagramokat C++-ban az Aspose.Slides segítségével. Emelje a prezentációkat dinamikus vizuálokkal PPT és PPTX fájlokban— kezdje el most."
---
## **Bevezetés**

Az Aspose.Slides támogatja a diagram elemeinek animálását. **Series**, **Categories**, **Series Elements**, **Categories Elements** animálható a [ISequence::AddEffect](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/isequence/addeffect/) metódussal és a két enummal: [EffectChartMajorGroupingType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) és [EffectChartMinorGroupingType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Diagram-sor animáció**
Ha egy diagram sorozatot szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektum referenciáját.
1. Animálja a sorozatot.
1. Írja a prezentáció fájlt a lemezre.

Az alábbi példában animáltuk a diagram sorozatát.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animáció egy sor elemben**
Ha a sor elemeit szeretné animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektum referenciáját.
1. Animálja a sorozat elemeit.
1. Írja a prezentáció fájlt a lemezre.

Az alábbi példában animáltuk a sorozat elemeit.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Diagram-kategória animáció**
Ha egy diagram kategóriát szeretne animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektum referenciáját.
1. Animálja a kategóriát.
1. Írja a prezentáció fájlt a lemezre.

Az alábbi példában animáltuk a diagram kategóriát.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animáció egy kategória elemben**
Ha a kategória elemeit szeretné animálni, írja meg a kódot az alábbi lépések szerint:

1. Töltsön be egy prezentációt.
1. Szerezze meg a diagram objektum referenciáját.
1. Animálja a kategória elemeket.
1. Írja a prezentáció fájlt a lemezre.

Az alábbi példában animáltuk a kategória elemeket.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Támogatottak-e a különböző effektustípusok (például belépés, hangsúlyozás, kilépés) a diagramoknál, ahogy a normál alakzatoknál?**

Igen. A diagramot alakzatként kezelik, így támogatja a szabványos animációs effektustípusokat, beleértve a belépést, hangsúlyozást és kilépést, teljes ellenőrzéssel a diák idővonalán és animációs sorozataiban.

**Kombinálhatom-e a diagram animációt diaváltásokkal?**

Igen. A [Transitions](/slides/hu/cpp/slide-transition/) a diára vonatkozik, míg az animációs effektusok a dián lévő objektumokra. Mindkettőt használhatja ugyanabban a prezentációban, és külön-külön vezérelheti őket.

**Megmaradnak-e a diagram animációk PPTX mentéskor?**

Igen. Amikor [save to PPTX](/slides/hu/cpp/save-presentation/) műveletet használ, minden animációs effektus és azok sorrendje megmarad, mivel a prezentáció natív animációs modelljének részei.

**Olvashatok-e meglévő diagram animációkat egy prezentációból és módosíthatom őket?**

Igen. Az [API](https://reference.aspose.com/slides/hu/cpp/aspose.slides.animation/) hozzáférést biztosít a dia idővonalához, sorozataihoz és effektusaihoz, lehetővé téve a meglévő diagram animációk ellenőrzését és módosítását anélkül, hogy mindent újra kellene építeni.

**Készíthetek‑e videót, amely tartalmazza a diagram animációkat az Aspose.Slides használatával?**

Igen. A [export a presentation to video](/slides/hu/cpp/convert-powerpoint-to-video/) funkcióval exportálhatja a prezentációt videóra, miközben megőrzi az animációkat, beállítja a időzítéseket és egyéb exportálási beállításokat, így a kész klip a animált lejátszást tükrözi.