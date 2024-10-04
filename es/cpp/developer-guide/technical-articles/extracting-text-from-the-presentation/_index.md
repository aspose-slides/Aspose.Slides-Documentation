---
title: Extracción de texto de la presentación
type: docs
weight: 60
url: /es/cpp/extracting-text-from-the-presentation/
---

{{% alert color="primary" %}} 

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, es necesario extraer el texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones PPTX de Microsoft PowerPoint utilizando Aspose.Slides. El texto se puede extraer de las siguientes maneras:

[Extracción de texto de una diapositiva](/slides/es/cpp/extracting-text-from-the-presentation/)
[Extracción de texto usando el método GetAllTextBoxes](/slides/es/cpp/extracting-text-from-the-presentation/)
[Extracción de texto categorizada y rápida](/slides/es/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extracción de texto de una diapositiva**
Aspose.Slides para C++ proporciona el espacio de nombres Aspose.Slides.Util que incluye la clase PresentationScanner. Esta clase expone una serie de métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, utilice el método estático sobrecargado [GetAllTextBoxes](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members) expuesto por la clase PresentationScanner. Este método acepta el objeto Slide como parámetro. 
Al ejecutar, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve un arreglo de objetos TextFrame. Esto significa que cualquier formato de texto asociado con el texto está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

**C#**

``` cpp

 //Instanciar la clase PresentationEx que representa un archivo PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//Obtener un arreglo de objetos TextFrameEx de la primera diapositiva

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//Recorrer el arreglo de TextFrames

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //Recorrer los párrafos en el TextFrame actual

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //Recorrer las porciones en el párrafo actual

        foreach (Portion port in para.Portions)

        {

            //Mostrar texto en la porción actual

            Console.WriteLine(port.Text);

            //Mostrar altura de fuente del texto

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Mostrar nombre de fuente del texto

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```


## **Extracción de texto de toda la presentación**
Para escanear el texto de toda la presentación, utilice el método estático [GetAllTextFrames](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members) expuesto por la clase PresentationScanner. Toma dos parámetros:

1. Primero, un objeto Presentation que representa la presentación PPTX de la cual se está extrayendo el texto.
1. En segundo lugar, un valor booleano que determina si se debe incluir la diapositiva maestra al escanear el texto de la presentación.
   El método devuelve un arreglo de objetos TextFrame, completo con información de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluidas las diapositivas maestras.

**C#**

``` cpp

 //Instanciar la clase Presentation que representa un archivo PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");
//Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Recorrer el arreglo de TextFrames

for (int i = 0; i < textFramesPPTX.Length; i++)

    //Recorrer los párrafos en el ITextFrame actual

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //Recorrer las porciones en el IParagraph actual

        foreach (IPortion port in para.Portions)

        {

            //Mostrar texto en la porción actual

            Console.WriteLine(port.Text);

            //Mostrar altura de fuente del texto

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Mostrar nombre de fuente del texto

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }


```


## **Extracción de texto categorizada y rápida**
Se ha añadido un nuevo método estático GetPresentationText a la clase Presentation. Hay dos sobrecargas para este método:

``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```

El argumento de enumeración ExtractionMode indica el modo para organizar el resultado de texto y puede ser establecido en los siguientes valores:
Desordenado - El texto en bruto sin respeto a la posición en la diapositiva
Ordenado - El texto se posiciona en el mismo orden que en la diapositiva

El modo desordenado puede ser utilizado cuando la velocidad es crítica, es más rápido que el modo ordenado.

PresentationText representa el texto en bruto extraído de la presentación. Contiene una propiedad SlidesText del espacio de nombres Aspose.Slides.Util que devuelve un arreglo de objetos ISlideText. Cada objeto representa el texto en la diapositiva correspondiente. El objeto ISlideText tiene las siguientes propiedades:

ISlideText.Text - El texto en las formas de la diapositiva
ISlideText.MasterText - El texto en las formas de la página maestra para esta diapositiva
ISlideText.LayoutText - El texto en las formas de la página de diseño para esta diapositiva
ISlideText.NotesText - El texto en las formas de la página de notas para esta diapositiva

También existe una clase SlideText que implementa la interfaz ISlideText.

La nueva API se puede utilizar de la siguiente manera:

``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```