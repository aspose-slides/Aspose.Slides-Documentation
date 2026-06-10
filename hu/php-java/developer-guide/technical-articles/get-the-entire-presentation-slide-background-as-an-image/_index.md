---
title: Az egész dia háttér kinyerése egy prezentációból képként
linktitle: Teljes dia háttér
type: docs
weight: 95
url: /hu/php-java/get-the-entire-presentation-slide-background-as-an-image/
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
- PHP
- Aspose.Slides
description: "Teljes diák háttereit képként extrahálja PowerPoint és OpenDocument prezentációkból az Aspose.Slides for PHP via Java használatával, egyszerűsítve a vizuális munkafolyamatokat."
---
## **Áttekintés**

A PowerPoint‑prezentációkban a dia háttér több elemből állhat, beleértve a dia háttérképet, a prezentáció témáját, a színsémát és a mester‑diára vagy elrendezési diára helyezett objektumokat.

Ez a cikk bemutatja, hogyan lehet az egész dia hátteret képként kinyerni az Aspose.Slides segítségével. Mivel erre a feladatra nincs egyetlen beépített módszer, a megközelítés a kiválasztott dia egy ideiglenes prezentációba klónozását, a dia alakzatainak eltávolítását, majd a kapott dia háttér képpé konvertálását tartalmazza.

## **Az egész dia háttér lekérése**

Az Aspose.Slides for PHP via Java nem biztosít egyszerű módszert a teljes prezentációs dia háttér képként történő kinyerésére, de az alábbi lépéseket követve ezt megteheti:
1. Töltsd be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztállyal.
1. Szerezd meg a dia méretét a prezentációból.
1. Válassz ki egy diát.
1. Hozz létre egy ideiglenes prezentációt.
1. Állítsd be ugyanazt a dia méretet az ideiglenes prezentációban.
1. Klónozd a kiválasztott diát az ideiglenes prezentációba.
1. Töröld az alakzatokat a klónozott diáról.
1. Konvertáld a klónozott diát képpé.

Az alábbi kódrészlet kinyeri a teljes prezentációs dia hátteret képként.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```

## **GYIK**

**Megőrződnek-e a mester diáról származó összetett színátmenetek, textúrák vagy képtöltések a kapott háttérképen?**

Igen. Az Aspose.Slides rendereli a dián, elrendezésen vagy mesteren definiált színátmenet, kép és textúra töltéseket. Ha szeretnéd elszeparálni a megjelenést az örökölt mesterektől, állíts be egy saját hátteret a jelenlegi diára a [állíts be egy saját hátteret](/slides/hu/php-java/presentation-background/) exportálás előtt.

**Hozzáadhatok-e vízjelet a kapott háttérképhez mentés előtt?**

Igen. [vízjelet hozzáadni](/slides/hu/php-java/watermark/) alakzatot vagy képet egy működő [dia másolata](/slides/hu/php-java/clone-slides/) (más tartalom mögé helyezve), majd exportálhatod. Ez lehetővé teszi, hogy a vízjellel beégetett háttérképet generálj.

**Kérhetek-e háttérképet egy adott elrendezéshez vagy mesterhez anélkül, hogy meglévő diához kötötném?**

Igen. Hozzáférhetsz a kívánt mesterhez vagy elrendezéshez, alkalmazd egy [ideiglenes diára](/slides/hu/php-java/clone-slides/) a szükséges mérettel, majd exportáld azt a diát, hogy megkapd az elrendezésből vagy mesterből származó hátteret.

**Vannak-e licencelési korlátozások, amelyek befolyásolják a képexportot?**

A renderelési funkciók teljes mértékben elérhetők egy [érvényes licenccel](/slides/hu/php-java/licensing/). Értékelő módban a kimenet tartalmazhat korlátozásokat, például vízjelet. Aktiváld a licencet egyszer a folyamat során, mielőtt kötegelt exportot indítanál.