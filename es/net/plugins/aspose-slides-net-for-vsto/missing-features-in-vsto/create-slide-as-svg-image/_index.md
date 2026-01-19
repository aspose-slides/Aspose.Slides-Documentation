---
title: Crear diapositiva como imagen SVG
type: docs
weight: 70
url: /es/net/create-slide-as-svg-image/
---

Para generar una imagen SVG a partir de cualquier diapositiva deseada con Aspose.Slides.Pptx para .NET, siga los pasos a continuación:

- Cree una instancia de la clase Presentation.
- Obtenga la referencia de la diapositiva deseada utilizando su ID o índice.
- Obtenga la imagen SVG en un stream de memoria.
- Guarde el stream de memoria en un archivo.
## **Ejemplo**

```
 //Instanciar una clase Presentation que representa el archivo de presentación

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
   //Acceder a la segunda diapositiva
   ISlide sld = pres.Slides[1];
   //Crear un objeto MemoryStream
   MemoryStream SvgStream = new MemoryStream();
   //Generar la imagen SVG de la diapositiva y guardarla en el stream de memoria
   sld.WriteAsSvg(SvgStream);
   SvgStream.Position = 0;
   //Guardar el stream de memoria en un archivo
   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))
   {
     byte[] buffer = new byte[8 * 1024];
     int len;
     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
     {
       fileStream.Write(buffer, 0, len);
     }
   }
}
SvgStream.Close();
``` 
## **Descargar Ejemplo en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Descargar Código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Para obtener más detalles, visite [Renderizar diapositivas como imágenes SVG en .NET](/slides/es/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}