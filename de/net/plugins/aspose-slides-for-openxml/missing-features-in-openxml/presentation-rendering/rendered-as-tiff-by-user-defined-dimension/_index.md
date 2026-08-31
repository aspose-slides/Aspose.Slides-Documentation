---
title: Als Tiff mit benutzerdefinierter Dimension gerendert
type: docs
weight: 40
url: /de/net/rendered-as-tiff-by-user-defined-dimension/
---
Das folgende Beispiel zeigt, wie man eine Präsentation in ein TIFF-Dokument mit benutzerdefinierter Bildgröße konvertiert, indem man die Klasse **TiffOptions** verwendet.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation(srcFileName);

//Instanziiere die TiffOptions-Klasse
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Festlegen des Kompressionstyps
opts.CompressionType = TiffCompressionTypes.Default;

//Kompressionstypen
//Default - Gibt das Standardschema für die Kompression an (LZW).
//None - Gibt an, dass keine Kompression verwendet wird.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.
//Auflösungseinheit - ist immer gleich "2" (Punkte pro Zoll)
//Festlegen der Bild-DPI
opts.DpiX = 200;

opts.DpiY = 100;

//Bildgröße festlegen
opts.ImageSize = new Size(1728, 1078);

//Speichere die Präsentation als TIFF mit der angegebenen Bildgröße
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
``` 
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)