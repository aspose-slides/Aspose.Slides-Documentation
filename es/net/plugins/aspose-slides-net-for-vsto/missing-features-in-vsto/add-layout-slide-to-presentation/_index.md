---
title: Agregar diapositiva de diseño a la presentación
type: docs
weight: 10
url: /es/net/add-layout-slide-to-presentation/
---

Aspose.Slides para .NET permite a los desarrolladores agregar nuevas diapositivas de diseño en la presentación. Para agregar una diapositiva de diseño, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Acceda a la colección de master slides
- Intente encontrar diapositivas de diseño existentes para ver si la requerida ya está disponible en la colección de diapositivas de diseño o no
- Agregue una nueva diapositiva de diseño si el diseño deseado no está disponible
- Agregue una diapositiva vacía con la nueva diapositiva de diseño añadida
- Finalmente, guarde el archivo de presentación utilizando el objeto Presentation.
## **Ejemplo**
``` csharp

 //Instanciar la clase Presentation que representa el archivo de presentación

using (Presentation p = new Presentation("Test.pptx"))

{

   // Intente buscar por tipo de diapositiva de diseño

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // La situación cuando una presentación no contiene algunos tipos de diseños.

     // La presentación Technographics.pptx solo contiene tipos de diseño en blanco y personalizados.

     // Pero las diapositivas de diseño con tipos personalizados tienen diferentes nombres de diapositivas,

     // como "Título", "Título y contenido", etc. Y es posible usar estos

     // nombres para la selección de diapositivas de diseño.

     // También es posible usar el conjunto de tipos de formas de marcador de posición. Por ejemplo,

     // La diapositiva de título debería tener solo el tipo de marcador de posición de título, etc.

     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

     {

       if (titleAndObjectLayoutSlide.Name == "Título y objeto")

       {

          layoutSlide = titleAndObjectLayoutSlide;

          break;

       }

      }

      if (layoutSlide == null)

      {

         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

         {

            if (titleLayoutSlide.Name == "Título")

            {

                layoutSlide = titleLayoutSlide;

                break;

            }

          }

          if (layoutSlide == null)

          {

             layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

             if (layoutSlide == null)

             {

                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Título y objeto");

             }

          }

      }

  }

  //Agregar diapositiva vacía con la diapositiva de diseño añadida

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Guardar presentación

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Descargar ejemplo en funcionamiento**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Adding Layout Slides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode#content)
## **Descargar código de ejemplo**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Para más detalles, visite [Agregar diapositiva de diseño a la presentación](/slides/es/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}