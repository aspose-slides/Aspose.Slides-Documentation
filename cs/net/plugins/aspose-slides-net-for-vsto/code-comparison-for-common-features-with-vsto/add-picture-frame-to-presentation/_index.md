---
title: Přidat rámeček s obrázkem do prezentace
type: docs
weight: 50
url: /cs/net/add-picture-frame-to-presentation/
---
## **VSTO**
Níže je kód pro přidání obrázku do VSTO prezentace:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Chcete-li přidat jednoduchý rámeček s obrázkem do snímku, postupujte podle následujících kroků:

1. Vytvořte instanci třídy Presentation.
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Vytvořte objekt Image přidáním obrázku do kolekce Images, která je součástí objektu Presentation a bude použita k vyplnění tvaru (Shape).
1. Vypočítejte šířku a výšku obrázku.
1. Vytvořte PictureFrame podle šířky a výšky obrázku pomocí metody AddPictureFrame, která je součástí objektu Shapes přidruženého k odkazovanému snímku.
1. Přidejte rámeček s obrázkem (obsahující obrázek) do snímku.
1. Uložte upravenou prezentaci jako soubor PPTX.

Výše uvedené kroky jsou implementovány v příkladu uvedeném níže.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instancovat třídu Presentation, která představuje PPTX

  Presentation pres = new Presentation();

  //Získat první snímek

  ISlide sld = pres.Slides[0];

  //Instancovat třídu ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Přidat rámeček s obrázkem se stejnou výškou a šířkou jako obrázek

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Stáhnout běžící kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)