---  
title: Slide als Miniaturansicht zu JPEG rendern  
type: docs  
weight: 60  
url: /net/render-slide-as-thumbnail-to-jpeg/  
---  

**Aspose.Slides für .NET** wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können angezeigt werden, indem man Präsentationsdateien mit Microsoft PowerPoint öffnet. Manchmal müssen Entwickler jedoch Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen. In solchen Fällen hilft Ihnen Aspose.Slides für .NET, Miniaturansichten der Folien zu erstellen.  

Um die Miniaturansicht einer gewünschten Folie mit Aspose.Slides für .NET zu generieren:  

1. Erstellen Sie eine Instanz der **Presentation**-Klasse.  
1. Abrufen der Referenz einer gewünschten Folie, indem Sie deren ID oder Index verwenden.  
1. Holen Sie sich das Miniaturbild der referenzierten Folie in einem bestimmten Maßstab.  
1. Speichern Sie das Miniaturbild in einem beliebigen gewünschten Bildformat.  

``` csharp  
string filePath = @"..\..\..\Sample Files\";  
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";  
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";  

//Instanziieren Sie die Presentation-Klasse, die die Präsentationsdatei darstellt  
using (Presentation pres = new Presentation(srcFileName))  
{  
    //Zugriff auf die erste Folie  
    ISlide sld = pres.Slides[0];  

    //Erstellen Sie ein Bild im vollen Maßstab  
    using (IImage image = sld.GetImage(1f, 1f))  
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
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)  