---
title: Als Tiff Nach Benutzerdefinierter Größe Gerendert
type: docs
weight: 40
url: /de/net/rendered-as-tiff-by-user-defined-dimension/
---

Das folgende Beispiel zeigt, wie man eine Präsentation in ein TIFF-Dokument mit angepasster Bildgröße unter Verwendung der **TiffOptions**-Klasse konvertiert.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Konvertierung zu Tiff im definierten Format.tiff";

//Ein Presentation-Objekt instanziieren, das eine Präsentationsdatei repräsentiert

Presentation pres = new Presentation(srcFileName);

//Die TiffOptions-Klasse instanziieren

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Kompressionstyp festlegen

opts.CompressionType = TiffCompressionTypes.Default;

//Kompressionstypen

//Default - Gibt das Standard-Kompressionsschema (LZW) an.

//None - Gibt keine Kompression an.

//CCITT3

//CCITT4

//LZW

//RLE

//Tiefe - hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.

//Auflösungseinheit - ist immer gleich "2" (Punkte pro Zoll)

//Bild DPI festlegen

opts.DpiX = 200;

opts.DpiY = 100;

//Bildgröße festlegen

opts.ImageSize = new Size(1728, 1078);

//Die Präsentation als TIFF mit der angegebenen Bildgröße speichern

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)