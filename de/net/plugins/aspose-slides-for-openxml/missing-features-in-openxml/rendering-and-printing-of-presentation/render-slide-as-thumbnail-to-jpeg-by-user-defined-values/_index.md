---  
title: Rendern Sie die Folie als Miniaturansicht im JPEG-Format mit benutzerdefinierten Werten  
type: docs  
weight: 70  
url: /de/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/  
---  

Um die Miniaturansicht einer beliebigen gewünschten Folie mit Aspose.Slides für .NET zu generieren:  

1. Erstellen Sie eine Instanz der **Presentation**-Klasse.  
1. Erhalten Sie die Referenz der gewünschten Folie anhand ihrer ID oder ihres Index.  
1. Holen Sie die X- und Y-Skalierungsfaktoren basierend auf den benutzerdefinierten X- und Y-Abmessungen.  
1. Holen Sie das Miniaturbild der referenzierten Folie in einem bestimmten Maßstab.  
1. Speichern Sie das Miniaturbild im gewünschten Bildformat.  

``` csharp  
string filePath = @"..\..\..\Sample Files\";  
string srcFileName = filePath + "Benutzerdefinierte Miniaturansicht.pptx";  
string destFileName = filePath + "Benutzerdefinierte Miniaturansicht.jpg";  

//Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt  
using (Presentation pres = new Presentation(srcFileName))  
{  
    //Zugriff auf die erste Folie  
    ISlide sld = pres.Slides[0];  

    //Benutzerdefinierte Dimension  
    int desiredX = 1200;  
    int desiredY = 800;  

    //Ermitteln Sie den skalierten Wert von X und Y  
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;  
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;  

    //Erstellen Sie ein Bild im Vollmaßstab  
    using (IImage image = sld.GetImage(scaleX, scaleY))  
    {  
        //Speichern Sie das Bild auf der Festplatte im JPEG-Format  
        image.Save(destFileName, ImageFormat.Jpeg);  
    }  
}  
```  
## **Beispielcode herunterladen**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)  