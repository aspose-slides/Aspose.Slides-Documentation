---
title: Prezentációk tömörítése
description: Csökkentse a prezentáció méretét képtömörítéssel és mentse a beállításokat.
type: docs
url: /hu/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Áttekintés**

Tömörítse a képeket, távolítsa el a már nem szükséges levágott képrészleteket, és válasszon prezentációs tömörítési beállításokat a mentés előtt. Ez nagy fényképeket vagy ismétlődő médiát tartalmazó diák esetében hasznos. A megtakarított mennyiség a tartalomtól és a választott beállításoktól függ.

## **Használati példa**

Ez a C# példa az Aspose.Slides for .NET-et használja. Láthatóan egy 1600 × 900 pixeles gradient PNG-t hoz létre, beilleszti egy kis képkeretbe, és menti a *before.pptx* fájlt. Ezután a képet 96 DPI célfelbontásra tömöríti, és menti a *compressed.pptx* fájlt. Hasonlítsa össze a két fájl méretét és előnézetét: a megtakarítás a bemeneti képtől és a megjelenített mérettől függ.

A beállításhoz tekintse meg a [Telepítse az Aspose.Slides for .NET-et](/slides/hu/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **GYIK**

### **Ez egyetlen, teljes fájlra vonatkozó optimalizációs kapcsoló?**

Az Aspose.Slides for .NET 26.11 hozzáadja a [Compress.CompressPresentation](/slides/hu/net/low-code-presentation-operations/#compress-the-whole-presentation) funkciót, amely egyesíti a nem használt elrendezés/mester eltávolítását, a beágyazott betűkészletek alhalmazolását és a 150 DPI-os kép tömörítést. Tartósan eltávolítja a levágott képterületeket. Képek csak feldolgozásához használja a Compress.CompressImages‑t; finomabb vezérléshez tartsa meg a fent említett képenkénti munkafolyamatot. Ezek az új segédfüggvények a megadott .NET verzióra vonatkoznak; ellenőrizze a megfelelő útmutatót más SDK‑khoz.

### **A kép tömörítése módosítja a szerkeszthető szöveget vagy diagramokat?**

A kép tömörítése a képadatokra irányul, nem a szerkeszthető szövegre vagy diagram adatokra. Ellenőrizze a képeket, mivel az átméretezés vagy újratömörítés csökkentheti a részletességet.

### **Hogyan válasszak felbontást a prezentációs képekhez?**

Válasszon célt a megjelenített kép mérete és a tervezett képernyő- vagy nyomtatási használat alapján. Nagy kijelzők, nyomtatás és részletes diagramok esetén tartson meg több felbontást, és hasonlítsa össze a megjelenített kimenetet, mielőtt eldobná az eredetit.

## **Útmutatók**

- [Képkezelés optimalizálása a prezentációkban .NET-ben](/slides/hu/net/image/)

Kapcsolódó funkció: [Használaton kívüli mesterek, elrendezések és média eltávolítása](/slides/hu/features/remove-unused-content/).

## Futtatható .NET példák

- [Prezentáció méretének csökkentése](/slides/hu/net/examples/optimization-batch/compression/)