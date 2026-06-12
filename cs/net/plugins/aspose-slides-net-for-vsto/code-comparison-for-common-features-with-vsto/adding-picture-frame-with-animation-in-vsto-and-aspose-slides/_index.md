---
title: Přidání rámce obrázku s animací ve VSTO a Aspose.Slides
type: docs
weight: 20
url: /cs/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Níže uvedené ukázky kódu vytvoří prezentaci s jedním snímkem, přidají obrázek s rámcem a použijí na něj animaci.
## **VSTO**
Pomocí VSTO proveďte následující kroky:

1. Vytvořte prezentaci.
1. Přidejte prázdný snímek.
1. Přidejte do snímku tvar obrázku.
1. Použijte animaci na obrázek.
1. Uložte prezentaci na disk.

``` csharp

 //Vytvoření prázdné prezentace

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Přidání prázdného snímku

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Přidání rámce obrázku

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Použití animace na rámci obrázku

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Ukládání prezentace

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Pomocí Aspose.Slides pro .NET proveďte následující kroky:

1. Vytvořte prezentaci.
1. Získejte první snímek.
1. Přidejte obrázek do kolekce obrázků.
1. Přidejte do snímku tvar obrázku.
1. Použijte animaci na obrázek.
1. Uložte prezentaci na disk.

``` csharp

 //Vytvoření prázdné prezentace
Presentation pres = new Presentation();

//Přístup k prvnímu snímku
Slide slide = pres.GetSlideByPosition(1);

//Přidání objektu obrázku do kolekce obrázků prezentace
Picture pic = new Picture(pres, "pic.jpeg");

//Po přidání objektu obrázku je obrázku přiřazen jedinečný Id obrázku
int picId = pres.Pictures.Add(pic);

//Přidání rámce obrázku
Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Použití animace na rámci obrázku
PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Ukládání prezentace
pres.Write("AsposeAnim.ppt");
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)