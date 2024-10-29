---
title: Ensamblar Diapositivas
type: docs
weight: 10
url: /es/net/assemble-slides/
---

Cubre las siguientes características:
## **Agregar Diapositiva a la Presentación**
Antes de hablar sobre cómo agregar diapositivas a los archivos de presentación, discutamos algunos hechos sobre las diapositivas. Cada archivo de presentación de PowerPoint contiene una diapositiva Maestro / de Diseño y otras diapositivas Normales. Esto significa que un archivo de presentación contiene al menos una o más diapositivas. Es importante saber que los archivos de presentación sin diapositivas no son compatibles con Aspose.Slides para .NET. Cada diapositiva tiene un Id único y todas las Diapositivas Normales están organizadas en un orden especificado por el índice basado en cero.

Aspose.Slides para .NET permite a los desarrolladores agregar diapositivas vacías a su presentación. Para agregar una diapositiva vacía en la presentación, siga los pasos a continuación:

- Cree una instancia de la clase **Presentation**
- Instancie la clase **SlideCollection** estableciendo una referencia a la propiedad Slides (colección de objetos Slide de contenido) expuesta por el objeto Presentation.
- Agregue una diapositiva vacía a la presentación al final de la colección de diapositivas de contenido llamando al método **AddEmptySlide** expuesto por el objeto **SlideCollection**
- Realice alguna operación con la nueva diapositiva vacía agregada
- Finalmente, escriba el archivo de presentación utilizando el objeto **Presentation**

```csharp
 PresentationEx pres = new PresentationEx();

// Instanciar la clase SlideCollection
SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)
{
    // Agregar una diapositiva vacía a la colección Slides
    slds.AddEmptySlide(pres.LayoutSlides[i]);
}

// Guardar el archivo PPTX en el disco
pres.Write("EmptySlide.pptx");
``` 
## **Accediendo a Diapositivas de la Presentación**
Aspose.Slides para .NET proporciona la clase Presentation que puede ser utilizada para encontrar y acceder a cualquier diapositiva deseada presente en la presentación.

**Usando la Colección de Diapositivas**

La clase **Presentation** representa un archivo de presentación y expone todas las diapositivas en él como una colección **SlideCollection** (que es una colección de objetos **Slide**). Todas estas diapositivas se pueden acceder desde esta colección **Slides** utilizando un índice de diapositiva.

```csharp
// Instanciar un objeto Presentation que representa un archivo de presentación
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

// Accediendo a una diapositiva usando su índice de diapositiva
SlideEx slide = pres.Slides[0];
``` 
## **Eliminar Diapositivas**
Sabemos que la clase Presentation en **Aspose.Slides para .NET** representa un archivo de presentación. La clase Presentation encapsula una **SlideCollection** que actúa como un repositorio de todas las diapositivas que son parte de la presentación. Los desarrolladores pueden eliminar una diapositiva de esta colección de diapositivas de dos maneras:

- Usando la referencia de la diapositiva
- Usando el índice de la diapositiva

**Usando la Referencia de la Diapositiva**

Para eliminar una diapositiva usando su referencia, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva usando su Id o Índice
- Elimine la diapositiva referenciada de la presentación
- Escriba el archivo de presentación modificado

```csharp
// Instanciar un objeto Presentation que representa un archivo de presentación
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

// Accediendo a una diapositiva usando su índice en la colección de diapositivas
SlideEx slide = pres.Slides[0];

// Eliminando una diapositiva usando su referencia
pres.Slides.Remove(slide);

// Escribiendo el archivo de presentación
pres.Write("modified.pptx");
``` 
## **Cambiar la Posición de la Diapositiva:**
Es muy simple cambiar la posición de una diapositiva en la presentación. Simplemente siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva usando su Índice
- Cambie el SlideNumber de la diapositiva referenciada
- Escriba el archivo de presentación modificado

En el ejemplo dado a continuación, hemos cambiado la posición de una diapositiva (ubicada en el índice cero posición 1) de la presentación) al índice 1 (Posición 2).

```csharp
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

    // Instanciar la clase SlideCollection
    ISlideCollection slds = pres.Slides;

    for (int i = 0; i < pres.LayoutSlides.Count; i++)
    {
        // Agregar una diapositiva vacía a la colección Slides
        slds.AddEmptySlide(pres.LayoutSlides[i]);
    }

    // Guardar el archivo PPTX en el disco
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

public static void AccessingSlidesOfPresentation()
{
    // Instanciar un objeto Presentation que representa un archivo de presentación
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

    // Accediendo a una diapositiva usando su índice de diapositiva
    ISlide slide = pres.Slides[0];
}

public static void RemovingSlides()
{
    // Instanciar un objeto Presentation que representa un archivo de presentación
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

    // Accediendo a una diapositiva usando su índice en la colección de diapositivas
    ISlide slide = pres.Slides[0];

    // Eliminando una diapositiva usando su referencia
    pres.Slides.Remove(slide);

    // Escribiendo el archivo de presentación
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

public static void ChangingPositionOfSlide()
{
    // Instanciar la clase Presentation para cargar el archivo de presentación fuente
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

    // Obtener la diapositiva cuya posición se va a cambiar
    ISlide sld = pres.Slides[0];

    // Establecer la nueva posición para la diapositiva
    sld.SlideNumber = 2;

    // Escribir la presentación en el disco
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}
``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)