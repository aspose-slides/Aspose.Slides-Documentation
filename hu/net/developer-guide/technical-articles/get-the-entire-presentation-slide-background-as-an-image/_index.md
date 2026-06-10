---
title: Az egész dia háttér kinyerése a prezentációból kép formájában
linktitle: Teljes dia háttér
type: docs
weight: 95
url: /hu/net/get-the-entire-presentation-slide-background-as-an-image/
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
- .NET
- C#
- Aspose.Slides
description: "Az egész dia hátterek kinyerése képként PowerPoint és OpenDocument prezentációkból az Aspose.Slides for .NET használatával, egyszerűsítve a vizuális munkafolyamatokat."
---
## **Áttekintés**

A PowerPoint‑prezentációkban a dia háttér több elemből állhat, beleértve a dia háttérképet, a prezentáció témáját, a színsémát és a mester‑ vagy elrendezésdia‑ra elhelyezett objektumokat.

Ez a cikk bemutatja, hogyan lehet az egész dia hátteret képként kinyerni az Aspose.Slides for .NET segítségével. Mivel nincs egyetlen módszer erre a feladatra, a megközelítés magában foglalja a kiválasztott dia klónozását egy ideiglenes prezentációba, a dia alakzatainak eltávolítását, majd a kapott dia háttér képpé konvertálását.

## **Az egész dia hátterének lekérése**

Az Aspose.Slides for .NET nem kínál egyszerű módszert az egész prezentációs dia háttér képként történő kinyerésére, de az alábbi lépésekkel ezt megteheti:
1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály segítségével.
1. Szerezze meg a dia méretét a prezentációból.
1. Válasszon ki egy diát.
1. Hozzon létre egy ideiglenes prezentációt.
1. Állítsa be ugyanazt a dia méretet az ideiglenes prezentációban.
1. Klónozza a kiválasztott diát az ideiglenes prezentációba.
1. Törölje az alakzatokat a klónozott diáról.
1. Konvertálja a klónozott diát képpé.

Az alábbi kódrészlet kinyeri az egész prezentációs dia hátteret képként.
```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```

## **GYIK**

**Megmaradnak a mester diaból származó komplex színátmenetek, textúrák vagy képpel kitöltött elemek a kapott háttérképen?**

Igen. Az Aspose.Slides megjeleníti a dia, elrendezés vagy mester által definiált színátmenetes, képes és textúrával kitöltött elemeket. Ha el akarja különíteni a megjelenést az örökölt mesterektől, akkor [állítson be saját hátteret](/slides/hu/net/presentation-background/) az aktuális dián az exportálás előtt.

**Hozzáadhatok vízjelet a kapott háttérképhez mentés előtt?**

Igen. Hozzáadhat egy [vízjel](/slides/hu/net/watermark/) alakzatot vagy képet egy működő [dia másolatához](/slides/hu/net/clone-slides/) (a többi tartalom mögé helyezve), majd exportálhatja. Így létrehozhat egy háttérképet, amelyben a vízjel már be van égetve.

**Lekérhetem egy adott elrendezés vagy mester háttérképet anélkül, hogy egy meglévő diához kötném?**

Igen. Hozzáférhet a kívánt mesterhez vagy elrendezéshez, alkalmazza egy [ideiglenes diára](/slides/hu/net/clone-slides/) a szükséges mérettel, majd exportálja azt a diát, hogy megkapja az adott elrendezés vagy mester alapján létrehozott hátteret.

**Vannak licencelési korlátozások, amelyek befolyásolják a képexportálást?**

A renderelési funkciók teljes mértékben elérhetők egy [érvényes licenccel](/slides/hu/net/licensing/). Kiértékelési módban a kimenet korlátozásokkal, például vízjellel járhat. Aktiválja a licencet folyamatonként egyszer, mielőtt kötegelt exportálást végezne.