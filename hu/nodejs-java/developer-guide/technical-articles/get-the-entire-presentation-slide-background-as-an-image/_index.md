---
title: A teljes dia háttér lekérése a prezentációból képként
linktitle: Teljes dia háttér
type: docs
weight: 95
url: /hu/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia háttér
- végső háttér
- háttér kinyerés
- teljes háttér
- háttér képbe
- PPT háttér
- PPTX háttér
- ODP háttér
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "A PowerPoint és OpenDocument prezentációkból teljes dia hátterek képként történő kinyerése az Aspose.Slides for Node.js via Java segítségével, leegyszerűsítve a vizuális munkafolyamatokat."
---
## **Áttekintés**

A PowerPoint prezentációkban a dia háttér több elemből állhat, beleértve a dia háttérképét, a prezentáció témáját, színsémáját és a mester- vagy elrendezési diára helyezett objektumokat.

Ez a cikk bemutatja, hogyan lehet az egész dia háttérképet képként kinyerni az Aspose.Slides használatával. Mivel ehhez nincs egyetlen módszer, a megközelítés a kiválasztott dia klónozását egy ideiglenes prezentációba, a dia alakzatainak eltávolítását, majd a kapott dia háttér átalakítását képpé foglalja.

## **Az egész dia háttér kinyerése**

Az Aspose.Slides for Node.js via Java nem biztosít egyszerű módszert a teljes prezentációs dia háttér képként történő kinyerésére, de az alábbi lépésekkel megteheti:
1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály segítségével.
1. Szerezze meg a dia méretét a prezentációból.
1. Válasszon ki egy diát.
1. Hozzon létre egy ideiglenes prezentációt.
1. Állítsa be ugyanazt a dia méretet az ideiglenes prezentációban.
1. Klónozza a kiválasztott diát az ideiglenes prezentációba.
1. Törölje az alakzatokat a klónozott diáról.
1. Alakítsa át a klónozott diát képpé.

Az alábbi kódrészlet kinyeri a teljes prezentációs dia hátteret képként.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```

## **GYIK**

**Megmaradnak-e a komplex gradientek, textúrák vagy képpel kitöltött részek a mester diáról a keletkező háttérképen?**

Igen. Az Aspose.Slides megjeleníti a dián, elrendezésen vagy mesteren definiált gradient, kép és textúra kitöltéseket. Ha el szeretné különíteni a megjelenést az örökölt mesterektől, akkor [állítson be saját háttérképet](/slides/hu/nodejs-java/presentation-background/) az aktuális diára az exportálás előtt.

**Hozzáadhatok-e vízjelet a keletkező háttérképhez a mentés előtt?**

Igen. [Hozzáadhat](/slides/hu/nodejs-java/watermark/) egy vízjel alakzatot vagy képet egy munkaként használt [dia másolathoz](/slides/hu/nodejs-java/clone-slides/) (a többi tartalom mögé helyezve), majd exportálhatja. Ez lehetővé teszi, hogy a vízjellel ellátott háttérképet állítson elő.

**Kaphatok-e háttérképet egy adott elrendezéshez vagy mesterhez anélkül, hogy egy meglévő diához kötöm?**

Igen. Hozzáférhet a kívánt mesterhez vagy elrendezéshez, alkalmazza egy [ideiglenes diára](/slides/hu/nodejs-java/clone-slides/) a szükséges mérettel, majd exportálja azt a diát, hogy megkapja az adott elrendezés vagy mester alapján létrehozott háttérképet.

**Vannak-e licencelési korlátozások, amelyek befolyásolják a kép exportálását?**

A renderelési funkciók teljes mértékben elérhetők egy [érvényes licenc](/slides/hu/nodejs-java/licensing/) meglétével. Értékelő módban a kimenet korlátozásokkal, például vízjellel járhat. Aktiválja a licencet egyszer a folyamatban, mielőtt kötegelt exportálást indít.