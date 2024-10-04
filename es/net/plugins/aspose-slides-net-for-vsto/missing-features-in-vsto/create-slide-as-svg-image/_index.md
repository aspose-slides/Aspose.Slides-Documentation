---
title: Crear Diapositiva como Imagen SVG
type: docs
weight: 70
url: /net/create-slide-as-svg-image/
---

Para generar una imagen SVG a partir de cualquier diapositiva deseada con Aspose.Slides.Pptx para .NET, siga los siguientes pasos:

- Cree una instancia de la clase Presentation.
- Obtenga la referencia de la diapositiva deseada utilizando su ID o índice.
- Obtenga la imagen SVG en un flujo de memoria.
- Guarde el flujo de memoria en un archivo.
## **Ejemplo**

```csharp
 //Instanciar una clase Presentation que representa el archivo de presentación

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Acceder a la segunda diapositiva

   ISlide sld = pres.Slides[1];

   //Crear un objeto de flujo de memoria

   MemoryStream SvgStream = new MemoryStream();

   //Generar imagen SVG de la diapositiva y guardarla en el flujo de memoria

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Guardar el flujo de memoria en un archivo

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
## **Descargar Ejemplo en Ejecución**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Creating Slide SVG Image/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Descargar Código de Muestra**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Para más detalles, visite [Creando Imagen SVG de Diapositiva](/slides/net/presentation-viewer/).

{{% /alert %}}