---
title: Konverze do TIFF s poznámkami
type: docs
weight: 10
url: /cs/net/conversion-to-tiff-with-notes/
---
TIFF je jedním z několika široce používaných formátů obrázků, které Aspose.Slides pro .NET podporuje při konverzi prezentace s poznámkami do obrázků. Také můžete generovat miniatury snímků v zobrazení Poznámkový snímek. Níže jsou dva ukázkové kódy, které ukazují, jak generovat TIFF obrázky prezentace v zobrazení Poznámkový snímek.

Metoda **Save**, kterou poskytuje třída **Presentation**, může být použita k převodu celé prezentace v zobrazení Poznámkový snímek do formátu TIFF. Také můžete generovat miniaturu snímku v zobrazení Poznámkový snímek pro jednotlivé snímky.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Vytvořte objekt Presentation, který představuje soubor prezentace

Presentation pres = new Presentation(srcFileName);

//Ukládání prezentace do TIFF poznámek

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)