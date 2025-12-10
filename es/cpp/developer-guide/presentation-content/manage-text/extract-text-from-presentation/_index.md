---
title: Extracción avanzada de texto de presentaciones en C++
linktitle: Extraer texto
type: docs
weight: 90
url: /es/cpp/extract-text-from-presentation/
keywords:
- extraer texto
- extraer texto de diapositiva
- extraer texto de presentación
- extraer texto de PowerPoint
- extraer texto de OpenDocument
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- recuperar texto
- recuperar texto de diapositiva
- recuperar texto de presentación
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Extraiga rápidamente texto de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para C++. Siga nuestra guía simple, paso a paso, para ahorrar tiempo."
---

{{% alert color="primary" %}} 

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para ello, es necesario extraer el texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones Microsoft PowerPoint PPTX usando Aspose.Slides. El texto puede extraerse de las siguientes maneras:

- [Extracting text from one slide](/slides/es/cpp/extracting-text-from-the-presentation/)
- [Extracting text using GetAllTextBoxes method](/slides/es/cpp/extracting-text-from-the-presentation/)
- [Categorized and fast extraction of text](/slides/es/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraer texto de una diapositiva**
Aspose.Slides for C++ proporciona el espacio de nombres Aspose.Slides.Util que incluye la clase SlideUtil. Esta clase expone una serie de métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, 
use el método estático sobrecargado [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) expuesto por la clase SlideUtil. Este método acepta el objeto Slide como parámetro.
Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve una matriz de objetos TextFrame. Esto significa que cualquier formato de texto asociado está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:
``` cpp
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Instanciar la clase Presentation que representa un archivo PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Obtener una matriz de objetos ITextFrame de todas las diapositivas del PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Recorrer la matriz de TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Recorrer los párrafos en el ITextFrame actual
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Recorrer las porciones en el IParagraph actual
		for (const auto& port : para->get_Portions())
		{
			// Mostrar el texto en la porción actual
			Console::WriteLine(port->get_Text());

			// Mostrar la altura de fuente del texto
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Mostrar el nombre de fuente del texto
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **Extraer texto de una presentación**
Para escanear el texto de toda la presentación, use el
[GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) método estático expuesto por la clase SlideUtil. Toma dos parámetros:

1. Primero, un objeto Presentation que representa la presentación PPTX de la que se extrae el texto.
2. Segundo, un valor Boolean que determina si la diapositiva maestra debe incluirse cuando se escanea el texto de la presentación.  
   El método devuelve una matriz de objetos TextFrame, con información completa de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluidas las diapositivas maestras.
``` cpp
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Instanciar la clase Presentation que representa un archivo PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Obtener una matriz de objetos ITextFrame de todas las diapositivas del PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Recorrer la matriz de TextFrames
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// Recorrer los párrafos del ITextFrame actual
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// Recorrer las porciones del IParagraph actual
		for (const auto& port : para->get_Portions())
		{
			// Mostrar el texto de la porción actual
			Console::WriteLine(port->get_Text());

			// Mostrar la altura de fuente del texto
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Mostrar el nombre de fuente del texto
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **Extracción de texto categorizada y rápida**
Se ha añadido el nuevo método estático GetPresentationText a la clase Presentation. Hay dos sobrecargas para este método:
``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```


El argumento del enum TextExtractionArrangingMode indica el modo para organizar la salida del resultado de texto y puede establecerse en los siguientes valores:  
Unarranged - El texto crudo sin respetar la posición en la diapositiva  
Arranged - El texto se posiciona en el mismo orden que en la diapositiva

El modo Unarranged puede usarse cuando la velocidad es crítica; es más rápido que el modo Arranged.

PresentationText representa el texto crudo extraído de la presentación. Contiene un método get_SlidesText() del espacio de nombres Aspose.Slides.Util que devuelve una matriz de objetos ISlideText. Cada objeto representa el texto de la diapositiva correspondiente. El objeto ISlideText tiene los siguientes métodos:

get_Text() - El texto en las formas de la diapositiva.  
get_MasterText() - El texto en las formas de la página maestra para esta diapositiva.  
get_LayoutText() - El texto en las formas de la página de diseño para esta diapositiva.  
get_NotesText() - El texto en las formas de la página de notas para esta diapositiva.

También existe una clase SlideText que implementa la interfaz ISlideText.

La nueva API puede usarse así:
``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```


## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y procesa eficientemente incluso presentaciones grandes, lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de presentaciones?**

Sí, Aspose.Slides admite completamente la extracción de texto de tablas, gráficos y otros elementos complejos de diapositivas, lo que le permite acceder y analizar todo el contenido textual con facilidad.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puede extraer texto usando la versión de prueba gratuita de Aspose.Slides, aunque tendrá ciertas limitaciones, como procesar solo un número limitado de diapositivas. Para uso sin restricciones y para manejar presentaciones más grandes, se recomienda adquirir una licencia completa.