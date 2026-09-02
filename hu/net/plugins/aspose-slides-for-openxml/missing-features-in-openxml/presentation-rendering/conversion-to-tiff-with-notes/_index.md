---
title: Konvertálás Tiff formátumba jegyzetekkel
type: docs
weight: 10
url: /hu/net/conversion-to-tiff-with-notes/
---
A TIFF a számos széles körben használt képformátum egyike, amelyet az Aspose.Slides for .NET támogat a jegyzetekkel rendelkező prezentáció képekké konvertálásához. Jegyzetdiapozitív nézetben is előállíthatja a diák miniatűrjét. Az alábbiakban két kódrészlet látható, amely bemutatja, hogyan lehet TIFF képeket generálni egy prezentációról a Jegyzetdiapozitív nézetben.

A **Save** metódus, amelyet a **Presentation** osztály biztosít, felhasználható a teljes prezentáció Jegyzetdiapozitív nézetben történő TIFF formátumba való konvertálásához. Ezenkívül egyes diáknál is előállítható a diaminatűr a Jegyzetdiapozitív nézetben.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Példányosít egy Presentation objektumot, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation(srcFileName))
{
    //Elhelyezi a beszélőjegyzeteket minden megjelenített dia alá
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //A prezentáció mentése TIFF formátumba jegyzetekkel
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)