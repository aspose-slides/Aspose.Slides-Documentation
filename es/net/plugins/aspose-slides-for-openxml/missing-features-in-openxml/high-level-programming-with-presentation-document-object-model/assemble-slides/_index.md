---
title: Ensambla diapositivas
type: docs
weight: 10
url: /es/net/assemble-slides/
---

## **Agregar una diapositiva a una presentación**
Antes de hablar sobre agregar diapositivas a los archivos de presentación, discutamos algunos datos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva Maestra / de Diseño y otras diapositivas Normales. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides para .NET. Cada diapositiva tiene un Id único y todas las diapositivas Normales se organizan en un orden especificado por el índice basado en cero.

Aspose.Slides para .NET permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Cree una instancia de la clase **Presentation**
- Instancie la clase **SlideCollection** estableciendo una referencia a la propiedad Slides (colección de objetos Slide de contenido) expuesta por el objeto Presentation.
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando a los métodos **AddEmptySlide** expuestos por el objeto **SlideCollection**.
- Realice alguna operación con la diapositiva vacía recién agregada.
- Finalmente, escriba el archivo de presentación usando el objeto **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//Instantiate SlideCollection class

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Add an empty slide to the Slides collection

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Write("EmptySlide.pptx");

``` 
## **Acceder a diapositivas de una presentación**
Aspose.Slides para .NET proporciona la clase Presentation que puede usarse para encontrar y acceder a cualquier diapositiva deseada presente en la presentación.

**Usando la colección Slides**

La clase **Presentation** representa un archivo de presentación y expone todas sus diapositivas como una colección **SlideCollection** (que es una colección de objetos **Slide**). Todas estas diapositivas pueden accederse desde esta colección **Slides** usando un índice de diapositiva.

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its slide index

SlideEx slide = pres.Slides[0];

``` 
## **Eliminar diapositivas**
Sabemos que la clase Presentation en **Aspose.Slides para .NET** representa un archivo de presentación. La clase Presentation encapsula una **SlideCollection** que actúa como un repositorio de todas las diapositivas que forman parte de la presentación. Los desarrolladores pueden eliminar una diapositiva de esta colección Slides de dos maneras:

- Usando referencia de diapositiva
- Usando índice de diapositiva

**Usando referencia de diapositiva**

Para eliminar una diapositiva usando su referencia, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva usando su Id o Índice
- Elimine la diapositiva referenciada de la presentación
- Escriba el archivo de presentación modificado

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its index in the slides collection

SlideEx slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Write("modified.pptx");

``` 
## **Cambiar la posición de una diapositiva**
Es muy sencillo cambiar la posición de una diapositiva en la presentación. Simplemente siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva usando su Índice
- Cambie el SlideNumber de la diapositiva referenciada
- Escriba el archivo de presentación modificado

En el ejemplo a continuación, hemos cambiado la posición de una diapositiva (ubicada en la posición de índice cero 1) de la presentación a índice 1 (Posición 2).

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Instantiate SlideCollection class

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Add an empty slide to the Slides collection

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its slide index

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its index in the slides collection

ISlide slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instantiate Presentation class to load the source presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Get the slide whose position is to be changed

    ISlide sld = pres.Slides[0];

    //Set the new position for the slide

    sld.SlideNumber = 2;

    //Write the presentation to disk

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Descargar código de ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)