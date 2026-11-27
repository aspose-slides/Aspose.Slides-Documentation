---
title: Prezentációk tömörítése
description: Csökkentsük a prezentáció méretét képek tömörítésével és a nem használt tartalom eltávolításával.
type: docs
url: /hu/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: műveletek
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Áttekintés**

Tömörítse a képeket, távolítsa el a már nem szükséges levágott képrészleteket, és válassza ki a prezentáció tömörítési beállításait a mentés előtt. Ez nagy fényképeket vagy ismétlődő médiát tartalmazó diavetítéseknél hasznos. A megtakarított mennyiség a tartalomtól és a választott beállításoktól függ.

## **Használati példa**

Ez a C# példa betölti a `input.pptx` fájlt, tömöríti a prezentációt, és `compressed.pptx` néven menti.

Használja az Aspose.Slides for .NET 26.11 vagy újabb verzióját. A beállításhoz tekintse meg a [Telepítsd az Aspose.Slides for .NET-et](/slides/hu/net/installation/) oldalt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Azonos méretben ábrázolt képek a tömörítés előtt és után, majd mérve a PPTX fájlméret sávok és a tárolt képméret.] (visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Mérve egy szintetikus részlet‑rács teszteszközön: 584,030 → 128,323 bájt. Mindkét ábrázolás ugyanazt a méretarányt és 252 × 336 pont méretű keretet használja. A tömörítés eltávolítja a levágott margókat, és a tárolt képet 525 × 700 pixelre csökkenti; a méretmegtakarítás a bemenettől függ.*  
<!-- visual-explanation:compress-presentations:end -->

## **GYIK**

### **Ez egyetlen, teljes‑fájl optimalizálási kapcsoló?**

Az Aspose.Slides for .NET 26.11 hozzáadja a [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), amely egyesíti a nem használt elrendezés/master eltávolítást, a beágyazott betűkészlet alhalmazolását és a 150 DPI‑os képtömörítést. Tartósan eltávolítja a levágott képrészleteket. Kizárólag képek feldolgozásához használja a [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) funkciót; finomabb vezérléshez tekintse meg az [egyedi kép tömörítési példát](/slides/hu/net/examples/optimization-batch/compression/). A 26.11-es verziótól a teljes prezentációra vonatkozó hívás Java, Node.js Java-n keresztül, Python .NET-en keresztül és C++ nyelven is elérhető. A példa és a lapon található hivatkozások .NET-re vonatkoznak.

### **A képtömörítés megváltoztatja a szerkeszthető szöveget vagy a diagramokat?**

A képtömörítés kizárólag a kép adatokat érinti, nem a szerkeszthető szöveget vagy a diagramadatokat. Ellenőrizze a képeket, mivel az átméretezés vagy újratömörítés csökkentheti azok részletességét.

### **Hogyan válasszak felbontást a prezentáció képeihez?**

Válasszon célt a megjelenített kép mérete és a tervezett képernyő‑ vagy nyomtatási használat alapján. Nagy kijelzőkhöz, nyomtatáshoz és részletes diagramokhoz tartson meg több felbontást, és hasonlítsa össze a renderelt eredményt, mielőtt eldobná az eredetit.

## **Útmutatók**

- [A teljes prezentáció tömörítése .NET-ben](/slides/hu/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Képek optimalizálása a prezentációkban .NET-ben](/slides/hu/net/image/)

Kapcsolódó funkció: [Használaton kívüli masterek, elrendezések és média eltávolítása](/slides/hu/features/remove-unused-content/).

## Futtatható .NET példák

- [Prezentáció méretének csökkentése](/slides/hu/net/examples/optimization-batch/compression/)