---
title: Extraer texto de la presentación
type: docs
weight: 90
url: /cpp/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, es necesario extraer el texto de todas las formas en todas las diapositivas de la presentación. Este artículo explica cómo extraer texto de presentaciones de Microsoft PowerPoint PPTX utilizando Aspose.Slides. Se puede extraer texto de las siguientes maneras:

- [Extracción de texto de una diapositiva](/slides/cpp/extracting-text-from-the-presentation/)
- [Extracción de texto utilizando el método GetAllTextBoxes](/slides/cpp/extracting-text-from-the-presentation/)
- [Extracción de texto categorizada y rápida](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraer texto de la diapositiva**
Aspose.Slides para C++ proporciona el espacio de nombres Aspose.Slides.Util que incluye la clase SlideUtil. Esta clase expone una serie de métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, utiliza el método estático sobrecargado [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) expuesto por la clase SlideUtil. Este método acepta el objeto Slide como parámetro. Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve un array de objetos TextFrame. Esto significa que cualquier formato de texto asociado con el texto está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

``` cpp
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Instanciar la clase Presentation que representa un archivo PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Obtener un array de objetos ITextFrame de todas las diapositivas en el PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Recorrer el array de TextFrames
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

			// Mostrar la altura de la fuente del texto
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Mostrar el nombre de la fuente del texto
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **Extraer texto de la presentación**
Para escanear el texto de toda la presentación, utiliza el método estático [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) expuesto por la clase SlideUtil. Este método acepta dos parámetros:

1. Primero, un objeto Presentation que representa la presentación PPTX de la cual se está extrayendo el texto.
1. Segundo, un valor booleano que determina si la diapositiva maestra debe ser incluida al escanear el texto de la presentación. El método devuelve un array de objetos TextFrame, completo con información de formato de texto. El siguiente código escanea el texto y la información de formato de una presentación, incluyendo las diapositivas maestras.

``` cpp
// La ruta al directorio de documentos.
System::String dataDir = GetDataPath();

// Instanciar la clase Presentation que representa un archivo PPTX
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// Obtener un array de objetos ITextFrame de todas las diapositivas en el PPTX
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// Recorrer el array de TextFrames
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

			// Mostrar la altura de la fuente del texto
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// Mostrar el nombre de la fuente del texto
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

El argumento de enumeración TextExtractionArrangingMode indica el modo para organizar la salida del resultado de texto y se puede establecer en los siguientes valores:  
No organizado - El texto bruto sin respetar la posición en la diapositiva  
Organizado - El texto se posiciona en el mismo orden que en la diapositiva

El modo no organizado puede usarse cuando la velocidad es crítica, es más rápido que el modo organizado.

PresentationText representa el texto bruto extraído de la presentación. Contiene un método get_SlidesText() del espacio de nombres Aspose.Slides.Util que devuelve un array de objetos ISlideText. Cada objeto representa el texto en la diapositiva correspondiente. Los objetos ISlideText tienen los siguientes métodos:

get_Text() - El texto en las formas de la diapositiva.  
get_MasterText() - El texto en las formas de la página maestra para esta diapositiva.  
get_LayoutText() - El texto en las formas de la página de diseño para esta diapositiva.  
get_NotesText() - El texto en las formas de la página de notas para esta diapositiva.

También hay una clase SlideText que implementa la interfaz ISlideText.

La nueva API se puede usar así:

``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```