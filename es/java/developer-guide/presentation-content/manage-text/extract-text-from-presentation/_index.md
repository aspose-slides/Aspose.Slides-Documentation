---
title: Extraer texto de la presentación
type: docs
weight: 90
url: /es/java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

No es infrecuente que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, se necesita extraer el texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones PPTX de Microsoft PowerPoint utilizando Aspose.Slides. 

{{% /alert %}} 
## **Extraer texto de la diapositiva**
Aspose.Slides para Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Esta clase expone una serie de métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, 
utiliza el método estático sobrecargado [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Este método acepta el objeto Slide como parámetro.
Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve un arreglo de objetos [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Esto significa que cualquier formato de texto asociado con el texto está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```java
//Instanciar la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Recorrer el arreglo de TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Recorrer los párrafos en el ITextFrame actual
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Recorrer las porciones en el IParagraph actual
                for (IPortion port : para.getPortions()) {
                    //Mostrar el texto en la porción actual
                    System.out.println(port.getText());

                    //Mostrar la altura de la fuente del texto
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Mostrar el nombre de la fuente del texto
                    if (port.getPortionFormat().getLatinFont() != null)
                        System.out.println(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```

## **Extraer texto de la presentación**
Para escanear el texto de toda la presentación, utiliza el método estático [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) expuesto por la clase SlideUtil. Acepta dos parámetros:

1. Primero, un objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) que representa la presentación de la cual se está extrayendo el texto.
1. Segundo, un valor booleano que determina si la diapositiva maestra debe ser incluida al escanear el texto de la presentación.
   El método devuelve un arreglo de objetos [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), completo con información de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluyendo las diapositivas maestras.

```java
//Instanciar la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Obtener un arreglo de objetos ITextFrame de todas las diapositivas en el PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Recorrer el arreglo de TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Recorrer los párrafos en el ITextFrame actual
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Recorrer las porciones en el IParagraph actual
            for (IPortion port : para.getPortions())
            {
                //Mostrar el texto en la porción actual
                System.out.println(port.getText());

                //Mostrar la altura de la fuente del texto
                System.out.println(port.getPortionFormat().getFontHeight());

                //Mostrar el nombre de la fuente del texto
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```

## **Extracción de texto categorizada y rápida**
Se ha añadido un nuevo método estático getPresentationText a la clase Presentation. Hay tres sobrecargas para este método:

```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

El argumento de enumeración [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) indica el modo para organizar el resultado de texto y puede establecerse en los siguientes valores:
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - El texto sin procesar sin tener en cuenta la posición en la diapositiva
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - El texto se posiciona en el mismo orden que en la diapositiva

El modo **Unarranged** puede ser utilizado cuando la velocidad es crítica, es más rápido que el modo Arranged.

[IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) representa el texto sin procesar extraído de la presentación. Contiene un método [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) que devuelve un arreglo de objetos [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText). Cada objeto representa el texto en la diapositiva correspondiente. El objeto [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) tiene los siguientes métodos:

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - El texto en las formas de la diapositiva
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - El texto en las formas de la página maestra para esta diapositiva
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - El texto en las formas de la página de diseño para esta diapositiva
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - El texto en las formas de la página de notas para esta diapositiva

También hay una clase [SlideText](https://reference.aspose.com/slides/java/com.aspose.slides/SlideText) que implementa la interfaz [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText).

La nueva API puede ser utilizada de la siguiente manera:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```