---
title: Créer un diaporama en tant qu'image SVG
type: docs
weight: 70
url: /fr/net/create-slide-as-svg-image/
---

Pour générer une image SVG à partir de n'importe quel diaporama souhaité avec Aspose.Slides.Pptx pour .NET, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe Presentation.
- Obtenez la référence du diaporama souhaité en utilisant son ID ou son index.
- Obtenez l'image SVG dans un flux mémoire.
- Enregistrez le flux mémoire dans un fichier.
## **Exemple**

```
//Instancier une classe Presentation qui représente le fichier de présentation

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Accéder au deuxième diaporama

   ISlide sld = pres.Slides[1];

   //Créer un objet de flux mémoire

   MemoryStream SvgStream = new MemoryStream();

   //Générer l'image SVG du diaporama et la sauvegarder dans le flux mémoire

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Sauvegarder le flux mémoire dans un fichier

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **Télécharger l'exemple en cours d'exécution**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Creating Slide SVG Image/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Télécharger le code d'exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Créer une image SVG de diapositive](/slides/fr/net/presentation-viewer/).

{{% /alert %}}