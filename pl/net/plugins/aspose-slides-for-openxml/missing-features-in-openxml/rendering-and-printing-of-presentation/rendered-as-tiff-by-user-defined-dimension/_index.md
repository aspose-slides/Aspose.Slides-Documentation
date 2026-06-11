---
title: Renderowane jako TIFF o wymiarach określonych przez użytkownika
type: docs
weight: 40
url: /pl/net/rendered-as-tiff-by-user-defined-dimension/
---
Poniższy przykład pokazuje, jak przekonwertować prezentację na dokument TIFF z niestandardowym rozmiarem obrazu przy użyciu klasy **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Utwórz obiekt Presentation, który reprezentuje plik prezentacji

Presentation pres = new Presentation(srcFileName);

//Utwórz obiekt klasy TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Ustawianie typu kompresji

opts.CompressionType = TiffCompressionTypes.Default;

//Typy kompresji

//Default - Określa domyślny schemat kompresji (LZW).

//None - Określa brak kompresji.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - zależy od typu kompresji i nie może być ustawiony ręcznie.

//Resolution unit - zawsze jest równe "2" (punkty na cal)

//Ustawianie DPI obrazu

opts.DpiX = 200;

opts.DpiY = 100;

//Ustaw rozmiar obrazu

opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)