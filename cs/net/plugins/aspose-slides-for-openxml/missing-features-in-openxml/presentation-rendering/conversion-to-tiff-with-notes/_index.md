---
title: Konverze na Tiff s poznámkami
type: docs
weight: 10
url: /cs/net/conversion-to-tiff-with-notes/
---
TIFF je jedním z několika široce používaných formátů obrázků, které Aspose.Slides pro .NET podporuje při konverzi prezentace s poznámkami na obrázky. Můžete také generovat miniatury snímků v zobrazení Poznámky ke snímku. Níže jsou dva úryvky kódu, které ukazují, jak generovat TIFF obrázky prezentace v zobrazení Poznámky ke snímku.

Metoda **Save** vystavená třídou **Presentation** může být použita k převodu celé prezentace v zobrazení Poznámky ke snímku na TIFF. Můžete také generovat miniaturu snímku v zobrazení Poznámky ke snímku pro jednotlivé snímky.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//    Vytvořte objekt Presentation, který představuje soubor prezentace
using (Presentation pres = new Presentation(srcFileName))
{
    //    Umístěte poznámky řečníka pod každý vykreslený snímek
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //    Ukládání prezentace do TIFF s poznámkami
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Stáhněte si ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)