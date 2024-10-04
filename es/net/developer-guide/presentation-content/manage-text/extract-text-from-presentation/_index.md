---
title: Extraer Texto de Presentaciones
type: docs
weight: 90
url: /net/extract-text-from-presentation/
keywords: "Extraer texto de diaposiva, Extraer texto de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Extraer texto de una diapositiva o presentación de PowerPoint en C# o .NET"
---

{{% alert color="primary" %}} 

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, es necesario extraer el texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones Microsoft PowerPoint PPTX utilizando Aspose.Slides. El texto se puede extraer de las siguientes maneras:

- [Extracción de texto de una diapositiva](/slides/net/extracting-text-from-the-presentation/)
- [Extracción de texto utilizando el método GetAllTextBoxes](/slides/net/extracting-text-from-the-presentation/)
- [Extracción de texto categorizada y rápida](/slides/net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraer Texto de Diapositiva**
Aspose.Slides para .NET proporciona el espacio de nombres Aspose.Slides.Util que incluye la clase SlideUtil. Esta clase expone una serie de métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, usa el método estático sobrecargado [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextboxes) expuesto por la clase SlideUtil. Este método acepta el objeto Slide como parámetro. Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve un arreglo de objetos TextFrame. Esto significa que cualquier formato de texto asociado con el texto está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```c#
//Instanciar la clase Presentation que representa un archivo PPTX
Presentation pptxPresentation = new Presentation("demo.pptx");

//Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Recorrer el arreglo de TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)
{
	//Recorrer los párrafos en el ITextFrame actual
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)
	{
		//Recorrer las porciones en el IParagraph actual
		foreach (IPortion port in para.Portions)
		{
			//Mostrar el texto en la porción actual
			Console.WriteLine(port.Text);

			//Mostrar la altura de la fuente del texto
			Console.WriteLine(port.PortionFormat.FontHeight);

			//Mostrar el nombre de la fuente del texto
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
	}
}
```

## **Extraer Texto de Presentación**
Para escanear el texto de toda la presentación, usa el método estático [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes) expuesto por la clase SlideUtil. Toma dos parámetros:

1. Primero, un objeto Presentation que representa la presentación PPTX de la cual se está extrayendo el texto.
1. Segundo, un valor booleano que determina si la diapositiva maestra debe ser incluida cuando se escanea el texto de la presentación.
   El método devuelve un arreglo de objetos TextFrame, completo con información de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluyendo las diapositivas maestras.

```c#
//Instanciar la clase Presentation que representa un archivo PPTX
Presentation pptxPresentation = new Presentation("demo.pptx");

//Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX
ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Recorrer el arreglo de TextFrames
for (int i = 0; i < textFramesPPTX.Length; i++)

	//Recorrer los párrafos en el ITextFrame actual
	foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

		//Recorrer las porciones en el IParagraph actual
		foreach (IPortion port in para.Portions)
		{
			//Mostrar el texto en la porción actual
			Console.WriteLine(port.Text);

			//Mostrar la altura de la fuente del texto
			Console.WriteLine(port.PortionFormat.FontHeight);

			//Mostrar el nombre de la fuente del texto
			if (port.PortionFormat.LatinFont != null)
				Console.WriteLine(port.PortionFormat.LatinFont.FontName);
		}
```

## **Extracción de Texto Rápida y Categorizada**
Se ha agregado el nuevo método estático GetPresentationText a la clase Presentation. Hay dos sobrecargas para este método:

``` csharp
PresentationText GetPresentationText(Stream stream)
PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

El argumento de enumeración ExtractionMode indica el modo para organizar la salida del resultado de texto y puede configurarse a los siguientes valores:
Desorganizado - El texto sin respetar la posición en la diapositiva
Organizado - El texto está posicionado en el mismo orden que en la diapositiva

El modo desorganizado puede usarse cuando la velocidad es crítica, es más rápido que el modo organizado.

PresentationText representa el texto crudo extraído de la presentación. Contiene una propiedad SlidesText del espacio de nombres Aspose.Slides.Util que devuelve un arreglo de objetos ISlideText. Cada objeto representa el texto en la diapositiva correspondiente. Los objetos ISlideText tienen las siguientes propiedades:

ISlideText.Text - El texto en las formas de la diapositiva
ISlideText.MasterText - El texto en las formas de la página maestra para esta diapositiva
ISlideText.LayoutText - El texto en las formas de la página de diseño para esta diapositiva
ISlideText.NotesText - El texto en las formas de la página de notas para esta diapositiva

También hay una clase SlideText que implementa la interfaz ISlideText.

La nueva API se puede usar así:

```c#
IPresentationText text1 = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);
```