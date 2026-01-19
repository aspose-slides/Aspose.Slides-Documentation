---
title: Créer une diapositive en image SVG
type: docs
weight: 70
url: /fr/net/create-slide-as-svg-image/
---

Pour générer une image SVG à partir de n'importe quelle diapositive souhaitée avec Aspose.Slides.Pptx pour .NET, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe Presentation.
- Obtenez la référence de la diapositive souhaitée en utilisant son ID ou son index.
- Récupérez l'image SVG dans un flux mémoire.
- Enregistrez le flux mémoire dans un fichier.
## **Exemple**

```

 //Instantiate a Presentation class that represents the presentation file

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Access the second slide

   ISlide sld = pres.Slides[1];

   //Create a memory stream object

   MemoryStream SvgStream = new MemoryStream();

   //Generate SVG image of slide and save in memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Save memory stream to file

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
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Rendre les diapositives de présentation en images SVG dans .NET](/slides/fr/net/render-a-slide-as-an-svg-image/).

{{% /alert %}}