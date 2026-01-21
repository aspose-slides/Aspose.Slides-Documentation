---
title: Extraer texto de presentaciones
type: docs
weight: 60
url: /es/cpp/extracting-text-from-the-presentation/
keywords:
- extraer texto
- recuperar texto
- diapositiva
- cuadro de texto
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo extraer texto de diapositivas o de presentaciones completas en Aspose.Slides para C++ y procesar el contenido de PPT, PPTX y ODP de forma programática."
---

{{% alert color="primary" %}} 

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para ello, es necesario extraer el texto de todas las formas de todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones Microsoft PowerPoint PPTX usando Aspose.Slides. El texto puede extraerse de las siguientes maneras:

[Extrayendo texto de una diapositiva](/slides/es/cpp/extracting-text-from-the-presentation/)
[Extrayendo texto mediante el método GetAllTextBoxes](/slides/es/cpp/extracting-text-from-the-presentation/)
[Extracción de texto categorizada y rápida](/slides/es/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extracción de texto de una diapositiva**
Aspose.Slides para C++ proporciona el espacio de nombres Aspose.Slides.Util que incluye la clase PresentationScanner. Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, use el método estático sobrecargado [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextboxes/) expuesto por la clase PresentationScanner. Este método acepta el objeto Slide como parámetro.  
Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve una matriz de objetos TextFrame. Esto significa que cualquier formato de texto asociado está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

**C#**
``` cpp

 //Instanciar la clase PresentationEx que representa un archivo PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//Obtener una matriz de objetos TextFrameEx de la primera diapositiva

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//Recorrer la matriz de TextFrames

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //Recorrer los párrafos del TextFrame actual

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //Recorrer las porciones del párrafo actual

        foreach (Portion port in para.Portions)

        {

            //Mostrar el texto de la porción actual

            Console.WriteLine(port.Text);

            //Mostrar la altura de fuente del texto

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Mostrar el nombre de fuente del texto

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```


## **Extracción de texto de toda la presentación**
Para escanear el texto de toda la presentación, use el método estático [GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/) expuesto por la clase PresentationScanner. Toma dos parámetros:

1. Primero, un objeto Presentation que representa la presentación PPTX de la que se extrae el texto.  
1. Segundo, un valor Boolean que determina si la diapositiva maestra debe incluirse al escanear el texto de la presentación.  

El método devuelve una matriz de objetos TextFrame, completa con información de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluidas las diapositivas maestras.

**C#**
``` cpp

 //Instanciar la clase Presentation que representa un archivo PPTX
Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//Obtener una matriz de objetos ITextFrame de todas las diapositivas del PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Recorrer la matriz de TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)
    //Recorrer los párrafos del ITextFrame actual
    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
        //Recorrer las porciones del IParagraph actual
        foreach (IPortion port in para.Portions)
        {
            //Mostrar el texto de la porción actual
            Console.WriteLine(port.Text);
            //Mostrar la altura de fuente del texto
            Console.WriteLine(port.PortionFormat.FontHeight);
            //Mostrar el nombre de fuente del texto
            if (port.PortionFormat.LatinFont != null)
                Console.WriteLine(port.PortionFormat.LatinFont.FontName);
        }

```


## **Extracción de texto categorizada y rápida**
Se ha añadido el nuevo método estático GetPresentationText a la clase Presentation. Hay dos sobrecargas para este método:
``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```


El argumento del enum ExtractionMode indica el modo para organizar la salida del resultado de texto y puede establecerse en los siguientes valores:
Desordenado - El texto bruto sin respetar la posición en la diapositiva  
Ordenado - El texto está posicionado en el mismo orden que en la diapositiva  

El modo Desordenado puede usarse cuando la velocidad es crítica; es más rápido que el modo Ordenado.

PresentationText representa el texto bruto extraído de la presentación. Contiene una propiedad SlidesText del espacio de nombres Aspose.Slides.Util que devuelve una matriz de objetos ISlideText. Cada objeto representa el texto de la diapositiva correspondiente. El objeto ISlideText tiene las siguientes propiedades:

ISlideText.Text - El texto de las formas de la diapositiva  
ISlideText.MasterText - El texto de las formas de la página maestra para esta diapositiva  
ISlideText.LayoutText - El texto de las formas de la página de diseño para esta diapositiva  
ISlideText.NotesText - El texto de las formas de la página de notas para esta diapositiva  

También existe la clase SlideText que implementa la interfaz ISlideText.

La nueva API puede usarse así:
``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```
