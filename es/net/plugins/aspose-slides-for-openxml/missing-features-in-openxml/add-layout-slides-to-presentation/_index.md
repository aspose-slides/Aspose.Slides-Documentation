---
title: Agregar Diapositivas de Diseño a la Presentación
type: docs
weight: 20
url: /es/net/add-layout-slides-to-presentation/
---

Aspose.Slides para .NET permite a los desarrolladores agregar nuevas diapositivas de diseño en la presentación. Para agregar una diapositiva de diseño, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Acceda a la colección de Maestros de Diapositivas
- Intente encontrar las diapositivas de diseño existentes para ver si la requerida ya está disponible en la colección de diapositivas de diseño o no
- Agregue una nueva diapositiva de diseño si el diseño deseado no está disponible
- Agregue una diapositiva vacía con la diapositiva de diseño recién agregada
- Finalmente, escriba el archivo de presentación utilizando el objeto Presentation
## **Ejemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Agregar Diapositivas de Diseño.pptx";

//Instanciar la clase Presentation que representa el archivo de presentación

using (Presentation p = new Presentation(FileName))

{

    // Intenta buscar por tipo de diapositiva de diseño

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // La situación cuando una presentación no contiene algunos tipos de diseños.

        // La presentación Technographics.pptx solo contiene tipos de diseño En Blanco y Personalizado.

        // Pero las diapositivas de diseño con tipos personalizados tienen nombres de diapositivas diferentes,

        // como "Título", "Título y Contenido", etc. Y es posible usar estos

        // nombres para la selección de diapositivas de diseño.

        // También es posible usar el conjunto de tipos de formas de marcador de posición. Por ejemplo,

        // La diapositiva de título debería tener solo el tipo de marcador de posición de Título, etc.

        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

        {

            if (titleAndObjectLayoutSlide.Name == "Título y Objeto")

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

                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Título y Objeto");

                }

            }

        }

    }

    //Agregar diapositiva vacía con la diapositiva de diseño agregada 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Guardar presentación    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Descargar Código de Ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Descargar Ejemplo en Ejecución**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Para más detalles, visite [Agregar Diapositivas de Diseño a la Presentación](/slides/es/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}