---
title: A teljes diaháttér kinyerése a prezentációból képként
linktitle: Teljes diaháttér
type: docs
weight: 95
url: /hu/androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- dia háttér
- végső háttér
- háttér kinyerése
- teljes háttér
- háttér képként
- PPT háttér
- PPTX háttér
- ODP háttér
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Teljes diaháttér kinyerése képként PowerPoint és OpenDocument prezentációkból az Aspose.Slides for Android via Java használatával, megkönnyítve a vizuális munkafolyamatokat."
---
## **Áttekintés**

A PowerPoint‑prezentációkban egy dia háttér több elemből állhat, többek között a diaháttér‑képből, a prezentáció témájából, a színsémából és a mester‑ vagy elrendezés‑dián elhelyezett objektumokból.

Ez a cikk bemutatja, hogyan lehet kinyerni a teljes diaháttér képet az Aspose.Slides for .NET használatával. Mivel erre a feladatra nincs egyetlen beépített metódus, a megközelítés a kiválasztott dia klónozását egy ideiglenes prezentációba, a dia alakzatainak eltávolítását, majd a kapott diaháttér kép formátumba konvertálását tartalmazza.

## **A teljes diaháttér lekérése**

Aspose.Slides for Android via Java nem biztosít egyszerű metódust a teljes prezentációs diaháttér képként történő kinyerésére, de az alábbi lépések követésével megvalósítható:
1. Töltsd be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztály használatával.
1. Szerezd meg a dia méretét a prezentációból.
1. Válassz ki egy diát.
1. Hozz létre egy ideiglenes prezentációt.
1. Állítsd be ugyanazt a dia méretet az ideiglenes prezentációban.
1. Klónozd a kiválasztott diát az ideiglenes prezentációba.
1. Töröld az alakzatokat a klónozott diákról.
1. Konvertáld a klónozott diát képpé.

Az alábbi kódrészlet a teljes prezentációs diaháttért képként nyeri ki.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```

## **GYIK**

**Megmaradnak a mesterdiáról származó összetett színátmenetek, textúrák vagy kép kitöltések a létrehozott háttérképben?**

Igen. Az Aspose.Slides megjeleníti a dián, elrendezésen vagy mesteren definiált színátmenet, kép és textúra kitöltéseket. Ha el akarod különíteni a megjelenést az örökölt mesterektől, akkor a [saját háttér beállítása](/slides/hu/androidjava/presentation-background/) az aktuális dián exportálás előtt.

**Hozzáadhatok vízjelet a létrehozott háttérképhez a mentés előtt?**

Igen. Hozzáadhatsz egy [vízjel](/slides/hu/androidjava/watermark/) alakzatot vagy képet egy működő [diamásolat](/slides/hu/androidjava/clone-slides/) (a többi tartalom mögé helyezve), majd exportálhatod. Így olyan háttérképet kapsz, amelyben a vízjel be van égetve.

**Lekérhetem egy adott elrendezés vagy mester háttérképét anélkül, hogy egy meglévő diához kötöm?**

Igen. Elérheted a kívánt mestert vagy elrendezést, alkalmazhatod egy [ideiglenes diát](/slides/hu/androidjava/clone-slides/) a szükséges mérettel, majd exportálhatod azt a diát, hogy megkapd az elrendezésből vagy mesterből származó háttérképet.

**Vannak licenckorlátok, amelyek befolyásolják a kép exportálást?**

A renderelési funkciók teljes mértékben elérhetők egy [érvényes licenccel](/slides/hu/androidjava/licensing/). Kiértékelési módban a kimenet tartalmazhat korlátozásokat, például vízjelet. A licencet a folyamat elindítása előtt egyszer aktiváld, mielőtt kötegelt exportálást indítasz.