---
title: Conversion de document OpenOffice
type: docs
weight: 30
url: /fr/net/conversion-of-openoffice-document/
---

Aspose.Slides for .NET propose la classe **Presentation** qui représente un fichier de présentation. La classe **Presentation** peut désormais également accéder à **ODP** via le constructeur Presentation lorsque l'objet est instancié.

Voici un exemple de conversion d'ODP en PPT/PPTX.
## **Exemple**
```

 //Instantiate a Presentation object that represents a presentation file

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Voici un exemple de conversion de PPT/PPTX en ODP.
## **Exemple**
``` 

 //Instantiate a Presentation object that represents a presentation file

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Saving the PPTX presentation to PPTX format

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Télécharger l'exemple d'exécution**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)