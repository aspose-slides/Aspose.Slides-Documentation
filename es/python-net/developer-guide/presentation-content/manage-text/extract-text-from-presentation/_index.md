---
title: Extraer texto de la presentación
type: docs
weight: 90
url: /python-net/extract-text-from-presentation/
keywords: "Extraer texto de la diapositiva, Extraer texto de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Extraer texto de la diapositiva o presentación de PowerPoint en Python"
---

{{% alert color="primary" %}} 

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, necesitas extraer texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones PPTX de Microsoft PowerPoint usando Aspose.Slides. Se puede extraer texto de las siguientes maneras:

- [Extracción de texto de una diapositiva](/slides/python-net/extracting-text-from-the-presentation/)
- [Extracción de texto usando el método GetAllTextBoxes](/slides/python-net/extracting-text-from-the-presentation/)
- [Extracción de texto categorizada y rápida](/slides/python-net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extraer texto de la diapositiva**
Aspose.Slides para Python a través de .NET proporciona el espacio de nombres Aspose.Slides.Util que incluye la clase SlideUtil. Esta clase expone una serie de métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, 
utiliza el método estático sobrecargado [GetAllTextBoxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) expuesto por la clase SlideUtil. Este método acepta el objeto Slide como parámetro.
Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve un arreglo de objetos TextFrame. Esto significa que cualquier formato de texto asociado con el texto está disponible. La siguiente pieza de código extrae todo el texto de la primera diapositiva de la presentación:

```py
import aspose.slides as slides

#Instanciar la clase Presentation que representa un archivo PPTX
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_boxes(pptxPresentation.slides[0])
    
    # Iterar a través del arreglo de TextFrames
    for i in range(len(textFramesPPTX)):
	    # Iterar a través de los párrafos en el ITextFrame actual
        for para in textFramesPPTX[i].paragraphs:
            # Iterar a través de las porciones en el IParagraph actual
            for port in para.portions:
			    # Mostrar texto en la porción actual
                print(port.text)

    			# Mostrar altura de fuente del texto
                print(port.portion_format.font_height)

			    # Mostrar nombre de fuente del texto
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Extraer texto de la presentación**
Para escanear el texto de toda la presentación, utiliza el
 [GetAllTextFrames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) método estático expuesto por la clase SlideUtil. Toma dos parámetros:

1. Primero, un objeto Presentation que representa la presentación PPTX de la que se extrae el texto.
1. Segundo, un valor booleano que determina si se debe incluir la diapositiva maestra cuando se escanea el texto de la presentación.
   El método devuelve un arreglo de objetos TextFrame, completo con información de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluyendo las diapositivas maestras.

```py
import aspose.slides as slides

#Instanciar la clase Presentation que representa un archivo PPTX
with slides.Presentation("pres.pptx") as pptxPresentation:
    # Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX
    textFramesPPTX = slides.util.SlideUtil.get_all_text_frames(pptxPresentation, True)
    
    # Iterar a través del arreglo de TextFrames
    for i in range(len(textFramesPPTX)):
	    # Iterar a través de los párrafos en el ITextFrame actual
        for para in textFramesPPTX[i].paragraphs:
            # Iterar a través de las porciones en el IParagraph actual
            for port in para.portions:
			    # Mostrar texto en la porción actual
                print(port.text)

    			# Mostrar altura de fuente del texto
                print(port.portion_format.font_height)

			    # Mostrar nombre de fuente del texto
                if port.portion_format.latin_font != None:
                    print(port.portion_format.latin_font.font_name)
```




## **Extracción de texto categorizada y rápida**
Se ha agregado el nuevo método estático GetPresentationText a la clase Presentation. Hay dos sobrecargas para este método:

```py
slides.Presentation.get_presentation_text(stream)
slides.Presentation.get_presentation_text(stream, mode)      
```

El argumento de enumeración ExtractionMode indica el modo para organizar la salida del resultado de texto y se puede establecer en los siguientes valores:
Desorganizado - El texto sin un respeto a la posición en la diapositiva
Organizado - El texto está posicionado en el mismo orden que en la diapositiva

El modo desorganizado puede usarse cuando la velocidad es crítica, es más rápido que el modo organizado.

PresentationText representa el texto sin procesar extraído de la presentación. Contiene una propiedad `slides_text` del espacio de nombres Aspose.Slides.Util que devuelve un arreglo de objetos SlideText. Cada objeto representa el texto en la diapositiva correspondiente. El objeto SlideText tiene las siguientes propiedades:

SlideText.text - El texto en las formas de la diapositiva
SlideText.master_text - El texto en las formas de la página maestra para esta diapositiva
SlideText.layout_text - El texto en las formas de la página de diseño para esta diapositiva
SlideText.notes_text - El texto en las formas de la página de notas para esta diapositiva


La nueva API se puede usar de esta manera:

```py
import aspose.slides as slides

text1 = slides.PresentationFactory().get_presentation_text("pres.pptx", slides.TextExtractionArrangingMode.UNARRANGED)
print(text1.slides_text[0].text)
print(text1.slides_text[0].layout_text)
print(text1.slides_text[0].master_text)
print(text1.slides_text[0].notes_text)
```