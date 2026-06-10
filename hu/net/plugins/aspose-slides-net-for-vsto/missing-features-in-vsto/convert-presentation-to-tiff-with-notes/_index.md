---
title: Prezentáció átalakítása TIFF formátumba jegyzetekkel
type: docs
weight: 50
url: /hu/net/convert-presentation-to-tiff-with-notes/
---
A TIFF az Aspose.Slides for .NET által támogatott számos, széles körben használt képfájlformátum egyike, amely a jegyzetekkel ellátott prezentáció képekké konvertálását teszi lehetővé. A Jegyzetek Diája nézetben is létrehozhat diakicsinyeket. Az alábbiakban két kódrészletet talál, amely bemutatja, hogyan lehet TIFF képeket generálni egy prezentációról a Jegyzetek Diája nézetben.

A [Save](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/save) metódus, amelyet a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály biztosít, használható a teljes prezentáció Jegyzetek Diája nézetből történő TIFF formátumba konvertálásához. Egyedi diákhoz is létrehozhat diakicsinyet a Jegyzetek Diája nézetben.
## **Példa**

``` 

  //Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel

 Presentation pres = new Presentation("Conversion.pptx");

 //A prezentáció mentése TIFF jegyzetekkel

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Futó példa letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

További részletekért látogassa meg a [PowerPoint prezentációk konvertálása TIFF-re jegyzetekkel .NET-ben](/slides/hu/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}