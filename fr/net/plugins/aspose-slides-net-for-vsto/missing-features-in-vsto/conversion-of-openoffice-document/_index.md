---
title: Conversion de Document OpenOffice
type: docs
weight: 30
url: /fr/net/conversion-of-openoffice-document/
---

Aspose.Slides pour .NET propose la classe **Presentation** qui représente un fichier de présentation. La classe **Presentation** peut maintenant également accéder à **ODP** via le constructeur Presentation lors de l'instantiation de l'objet.

Voici un exemple de conversion d'ODP vers PPT/PPTX.
## **Exemple**
```
//Instancier un objet Presentation qui représente un fichier de présentation

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))
{
   //Sauvegarder la présentation PPTX au format PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);
}
``` 

Voici un exemple de conversion de PPT/PPTX vers ODP.
## **Exemple**
```
//Instancier un objet Presentation qui représente un fichier de présentation

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))
{
   //Sauvegarder la présentation PPTX au format ODP

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);
}
``` 
## **Télécharger l'Exemple Fonctionnel**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Conversion from ODP to PPTX/Converting From and To ODP/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Télécharger le Code Exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)