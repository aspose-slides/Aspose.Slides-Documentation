---
title: Prezentációk tömörítése
description: Csökkentse a prezentáció méretét a képek tömörítésével és a nem használt tartalom eltávolításával.
type: docs
url: /hu/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Áttekintés**

Tömörítse a képeket, távolítsa el a levágott képrészeket, ha már nincs rájuk szükség, és válasszon prezentációs tömörítési beállításokat a mentés előtt. Ez hasznos nagy fényképeket vagy ismétlődő médiát tartalmazó diaképek esetén. A megtakarított mennyiség a tartalomtól és a választott beállításoktól függ.

## **Használati példa**

Ez a C# példa betölti a `input.pptx` fájlt, tömöríti a prezentációt, és elmenti `compressed.pptx` néven.

Használja az Aspose.Slides for .NET 26.11 vagy újabb verziót. A beállításhoz lásd a [Aspose.Slides for .NET telepítése](/slides/hu/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **GYIK**

### **Ez egy egységes, egész fájlt érintő optimalizációs kapcsoló?**

Az Aspose.Slides for .NET 26.11 hozzáadja a [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), amely egyesíti a nem használt elrendezés/mester eltávolítást, a beágyazott betűkészlet részhalmazosítását és a 150 DPI‑s kép tömörítést. Véglegesen eltávolítja a levágott képrészeket. Kép‑csak feldolgozáshoz használja a [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); finomabb vezérléshez tekintse meg az [egyes kép tömörítési példát](/slides/hu/net/examples/optimization-batch/compression/). Ezek az új segédfüggvények az adott .NET verzióra jellemzők; más SDK‑k esetén nézze meg a megfelelő útmutatót.

### **A kép tömörítése megváltoztatja a szerkeszthető szöveget vagy diagramokat?**

A kép tömörítése a képadatokra vonatkozik, nem a szerkeszthető szövegre vagy diagram adatokra. Ellenőrizze a képeket, mivel az átméretezés vagy újbóli tömörítés csökkentheti azok részletességét.

### **Hogyan válasszam ki a felbontást a prezentációs képekhez?**

Válasszon célt a megjelenített kép mérete és a kívánt képernyő vagy nyomtatási használat alapján. Nagy kijelzőkhöz, nyomtatáshoz és részletes diagramokhoz tartson meg több felbontást, és hasonlítsa össze a megjelenített eredményt, mielőtt eldobná az eredetit.

## **Útmutatók**

- [A teljes prezentáció tömörítése .NET-ben](/slides/hu/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Képkezelés optimalizálása prezentációkban .NET-ben](/slides/hu/net/image/)

Kapcsolódó funkció: [Használaton kívüli mesterek, elrendezések és média eltávolítása](/slides/hu/features/remove-unused-content/).

## Futtható .NET példák

- [Prezentáció méretének csökkentése](/slides/hu/net/examples/optimization-batch/compression/)