---  
title: Visionneuse de Présentation  
type: docs  
weight: 50  
url: /fr/net/presentation-viewer/  
keywords:  
- voir présentation PowerPoint  
- voir ppt  
- voir PPTX  
- C#  
- Csharp  
- Aspose.Slides pour .NET  
description: "Voir la présentation PowerPoint en C# ou .NET"  
---  

Aspose.Slides pour .NET est utilisé pour créer des fichiers de présentation, complets avec des diapositives. Ces diapositives peuvent être visualisées en ouvrant les présentations avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent également avoir besoin de voir les diapositives sous forme d'images dans leur visionneuse d'images préférée ou de créer leur propre visionneuse de présentation. Dans de tels cas, Aspose.Slides pour .NET vous permet d'exporter une diapositive individuelle en une image. Cet article décrit comment le faire.  
## **Exemple en Direct**  
Vous pouvez essayer l'application gratuite [**Visionneuse Aspose.Slides**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l'API Aspose.Slides :  

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)  

## **Générer une Image SVG à partir d'une Diapositive**  
Pour générer une image SVG à partir d'une diapositive souhaitée avec Aspose.Slides.PPTX pour .NET, veuillez suivre les étapes ci-dessous :  

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.  
- Obtenez l'image SVG dans un flux mémoire.  
- Enregistrez le flux mémoire dans un fichier.  

```c#  
// Instancier une classe Presentation qui représente le fichier de présentation  

using (Presentation pres = new Presentation("CreateSlidesSVGImage.pptx"))  
{  
    // Accéder à la première diapositive  
    ISlide sld = pres.Slides[0];  

    // Créer un objet de flux mémoire  
    MemoryStream SvgStream = new MemoryStream();  

    // Générer l'image SVG de la diapositive et la sauvegarder dans le flux mémoire  
    sld.WriteAsSvg(SvgStream);  
    SvgStream.Position = 0;  

    // Sauvegarder le flux mémoire dans un fichier  
    using (Stream fileStream = System.IO.File.OpenWrite("Aspose_out.svg"))  
    {  
        byte[] buffer = new byte[8 * 1024];  
        int len;  
        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)  
        {  
            fileStream.Write(buffer, 0, len);  
        }  
    }  
    SvgStream.Close();  
}  
```  

## **Générer un SVG avec des IDS de Forme Personnalisés**  
Aspose.Slides pour .NET peut être utilisé pour générer [SVG ](https://docs.fileformat.com/page-description-language/svg/) à partir de diapos avec un ID de forme personnalisé. Pour cela, utilisez la propriété ID de [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape), qui représente l'ID personnalisé des formes dans le SVG généré. CustomSvgShapeFormattingController peut être utilisé pour définir l'ID de la forme.  

```c#  
using (Presentation pres = new Presentation("pptxFileName.pptx"))  
{  
    using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate))  
    {  
        SVGOptions svgOptions = new SVGOptions  
        {  
            ShapeFormattingController = new CustomSvgShapeFormattingController()  
        };  

        pres.Slides[0].WriteAsSvg(stream, svgOptions);  
    }  
}  
```  

```c#  
class CustomSvgShapeFormattingController : ISvgShapeFormattingController  
{  
    private int m_shapeIndex;  

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)  
    {  
        m_shapeIndex = shapeStartIndex;  
    }  

    public void FormatShape(ISvgShape svgShape, IShape shape)  
    {  
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);  
    }  
}  
```  

## **Créer une Image de Miniature des Diapositives**  
Aspose.Slides pour .NET vous aide à générer des images miniatures des diapositives. Pour générer la miniature d'une diapositive souhaitée à l'aide d'Aspose.Slides pour .NET :  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.  
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.  
1. Sauvegardez l'image miniature dans n'importe quel format d'image souhaité.  

```c#  
// Instancier une classe Presentation qui représente le fichier de présentation  
using (Presentation pres = new Presentation("ThumbnailFromSlide.pptx"))  
{  
    // Accéder à la première diapositive  
    ISlide sld = pres.Slides[0];  

    // Créer une image à l'échelle complète  
    using (IImage image = sld.GetImage(1f, 1f))  
    {  
        // Sauvegarder l'image sur le disque au format JPEG  
        image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);  
    }  
}  
```  

## **Créer une Miniature avec des Dimensions Définies par l'Utilisateur**  
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.  
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée.  
1. Sauvegardez l'image miniature dans n'importe quel format d'image souhaité.  

```c#  
// Instancier une classe Presentation qui représente le fichier de présentation  
using (Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx"))  
{  
    // Accéder à la première diapositive  
    ISlide sld = pres.Slides[0];  

    // Dimension définie par l'utilisateur  
    int desiredX = 1200;  
    int desiredY = 800;  

    // Obtenir la valeur mise à l'échelle de X et Y  
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;  
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;  

    // Créer une image à l'échelle complète  
    using (IImage image = sld.GetImage(ScaleX, ScaleY))  
    {  
        // Sauvegarder l'image sur le disque au format JPEG  
        image.Save("Thumbnail2_out.jpg", ImageFormat.Jpeg);  
    }  
}  
```  

## **Créer une Miniature à partir d'une Diapositive en Vue de Notes**  
Pour générer la miniature de toute diapositive souhaitée en Vue de Notes à l'aide d'Aspose.Slides pour .NET :  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Obtenez la référence de n'importe quelle diapositive souhaitée en utilisant son ID ou son index.  
1. Obtenez l'image miniature de la diapositive référencée à une échelle spécifiée en Vue de Notes.  
1. Sauvegardez l'image miniature dans n'importe quel format d'image souhaité.  

Le code ci-dessous produit une miniature de la première diapositive d'une présentation en Vue de Notes.  

```c#  
// Instancier une classe Presentation qui représente le fichier de présentation  
using (Presentation pres = new Presentation("ThumbnailFromSlideInNotes.pptx"))  
{  
    // Accéder à la première diapositive  
    ISlide sld = pres.Slides[0];  

    // Dimension définie par l'utilisateur  
    int desiredX = 1200;  
    int desiredY = 800;  

    // Obtenir la valeur mise à l'échelle de X et Y  
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;  
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;  

    // Créer une image à l'échelle complète                
    using (IImage image = sld.GetImage(ScaleX, ScaleY))  
    {  
        // Sauvegarder l'image sur le disque au format JPEG  
        image.Save("Notes_tnail_out.jpg", ImageFormat.Jpeg);  
    }  
}  
```  