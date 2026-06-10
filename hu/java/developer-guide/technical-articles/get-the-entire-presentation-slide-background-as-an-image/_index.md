---
title: A teljes dia háttérének lekérése prezentációból képként
linktitle: Teljes dia háttér
type: docs
weight: 95
url: /hu/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia háttér
- végső háttér
- háttér kinyerése
- teljes háttér
- háttér képpé
- PPT háttér
- PPTX háttér
- ODP háttér
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Teljes diák hátterek képként való kinyerése PowerPoint és OpenDocument prezentációkból az Aspose.Slides for Java használatával, felgyorsítva a vizuális munkafolyamatokat."
---
## **Áttekintés**

PowerPoint előadásokban egy dia háttér több elemből állhat, beleértve a dia háttérképét, a prezentáció témáját, a színsémát és a mesterdia vagy elrendezésdia elhelyezett objektumait.

Ez a cikk bemutatja, hogyan lehet az egész diaszakasz hátterét képként kinyerni az Aspose.Slides for .NET használatával. Mivel nincs egyetlen beépített metódus erre a feladatra, a megközelítés a következő: a kiválasztott dia klónozása egy ideiglenes prezentációba, a dia alakzatainak eltávolítása, majd a kapott dia háttér konvertálása képpé.

## **A teljes dia háttér lekérése**

Az Aspose.Slides for Java nem biztosít egyszerű módszert a teljes prezentációs dia háttér képként történő kinyerésére, de az alábbi lépéseket követve megvalósítható:
1. Töltsd be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal.
1. Szerezd meg a dia méretét a prezentációból.
1. Válassz ki egy diát.
1. Hozz létre egy ideiglenes prezentációt.
1. Állítsd be ugyanazt a dia méretet az ideiglenes prezentációban.
1. Klónozd a kiválasztott diát az ideiglenes prezentációba.
1. Töröld a klónozott dia alakzatait.
1. Konvertáld a klónozott diát képpé.

Az alábbi kódrészlet a teljes prezentációs dia hátterét képként nyeri ki.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **GYIK**

**A mesterdia komplex gradientjei, textúrái vagy képpárnázott kitöltései megmaradnak a létrehozott háttérképen?**

Igen. Az Aspose.Slides megjeleníti a dián, elrendezésen vagy mesteren definiált gradient, kép és textúra kitöltéseket. Ha el szeretnéd különíteni a megjelenést az örökölt mesterektől, [állíts be saját háttérképet](/slides/hu/java/presentation-background/) az aktuális diára exportálás előtt.

**Hozzáadhatok-e vízjelet a létrehozott háttérképhez mentés előtt?**

Igen. Hozzáadhatsz egy [vízjel](/slides/hu/java/watermark/) alakzatot vagy képet egy munkaköri [dia másolatához](/slides/hu/java/clone-slides/) (a többi tartalom mögé helyezve), majd exportálhatod. Így a vízjelet beépített háttérképet kapsz.

**Lekérhetem-e egy adott elrendezés vagy mester háttérképét anélkül, hogy egy meglévő diára kötném?**

Igen. Nyisd meg a kívánt mestert vagy elrendezést, alkalmazd egy [ideiglenes diára](/slides/hu/java/clone-slides/) a megfelelő mérettel, és exportáld azt a diát, hogy megkapd az adott elrendezés vagy mester alapján létrehozott hátteret.

**Vannak-e licencelési korlátozások, amelyek befolyásolják a képkiexportálást?**

A megjelenítési funkciók teljes körűen elérhetők egy [érvényes licenccel](/slides/hu/java/licensing/). Értékelő módban a kimenet tartalmazhat korlátozásokat, például vízjelet. Aktiváld a licencet egyszer a folyamat indítása előtt, mielőtt kötegelt exportálásokat hajtasz végre.