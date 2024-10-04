---
title: Aplicar un tema a una presentación
type: docs
weight: 30
url: /net/apply-a-theme-to-a-presentation/
---

## **OpenXML Presentación:**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Aplicar Tema a la Presentación.pptx";

string ThemeFileName = FilePath + "Tema.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// Aplicar un nuevo tema a la presentación. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// Aplicar un nuevo tema a la presentación. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // Obtener la parte de presentación del documento de presentación.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // Obtener la parte de maestro de diapositivas existente.

    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // Obtener la nueva parte de maestro de diapositivas.

    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // Eliminar la parte de tema existente.

    presentationPart.DeletePart(presentationPart.ThemePart);

    // Eliminar la parte de maestro de diapositivas antigua.

    presentationPart.DeletePart(slideMasterPart);

    // Importar la nueva parte de maestro de diapositivas y reutilizar el ID de relación antiguo.

    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // Cambiar a la nueva parte de tema.

    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // Insertar el código para el diseño de este ejemplo.

    string defaultLayoutType = "Título y Contenido";

    // Eliminar la relación de diseño de diapositiva en todas las diapositivas. 

    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // Determinar el tipo de diseño de diapositiva para cada diapositiva.

            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // Eliminar la parte de diseño antigua.

            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // Aplicar la nueva parte de diseño.

            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // Aplicar la nueva parte de diseño predeterminada.

            slidePart.AddPart(newLayoutPart);

        }

    }

}

// Obtener el tipo de diseño de la diapositiva.

public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // Observaciones: Si esto se utiliza en código de producción, verifique si hay una referencia nula.

    return slideData.Name;

}   

``` 
## **Aspose.Slides**
Para aplicar un tema, necesitamos clonar la diapositiva con el maestro, siga los pasos a continuación:

- Crear una instancia de la clase Presentation que contenga la presentación de origen de la cual se clonará la diapositiva.
- Crear una instancia de la clase Presentation que contenga la presentación de destino a la cual se clonará la diapositiva.
- Acceder a la diapositiva que se va a clonar junto con la diapositiva maestra.
- Instanciar la clase IMasterSlideCollection referenciando la colección Masters expuesta por el objeto Presentation de la presentación de destino.
- Llamar al método AddClone expuesto por el objeto IMasterSlideCollection y pasar el maestro de la presentación PPTX de origen que se va a clonar como parámetro al método AddClone.
- Instanciar la clase ISlideCollection configurando la referencia a la colección Slides expuesta por el objeto Presentation de la presentación de destino.
- Llamar al método AddClone expuesto por el objeto ISlideCollection y pasar la diapositiva de la presentación de origen que se va a clonar y la diapositiva maestra como parámetro al método AddClone.
- Escribir el archivo de presentación de destino modificado.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Aplicar Tema a la Presentación.pptx";

string ThemeFileName = FilePath + "Tema.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    // Instanciar clase Presentation para cargar el archivo de presentación de origen

    Presentation srcPres = new Presentation(presentationFile);

    // Instanciar clase Presentation para la presentación de destino (donde se clonará la diapositiva)

    Presentation destPres = new Presentation(outputFile);

    // Instanciar ISlide de la colección de diapositivas en la presentación de origen junto con

    // diapositiva maestra

    ISlide SourceSlide = srcPres.Slides[0];

    // Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestros en la

    // presentación de destino

    IMasterSlideCollection masters = destPres.Masters;

    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

    // Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestros en la

    // presentación de destino

    IMasterSlide iSlide = masters.AddClone(SourceMaster);

    // Clonar la diapositiva deseada de la presentación de origen con el maestro deseado al final de la

    // colección de diapositivas en la presentación de destino

    ISlideCollection slds = destPres.Slides;

    slds.AddClone(SourceSlide, iSlide, true);

    // Clonar la diapositiva maestra deseada de la presentación de origen a la colección de maestros en la // presentación de destino

    // Guardar la presentación de destino en el disco

    destPres.Save(outputFile, SaveFormat.Pptx);

}

``` 
## **Descargar Ejemplo de Código en Funcionamiento**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Código de Ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)