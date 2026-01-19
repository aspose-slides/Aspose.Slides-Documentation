---
title: Transiciones de diapositivas
type: docs
weight: 80
url: /es/net/slide-transitions/
---

Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides para .NET para gestionar transiciones de diapositivas simples. Los desarrolladores pueden no solo aplicar diferentes efectos de transición de diapositivas, sino también personalizar el comportamiento de estos efectos de transición. Para crear un efecto de transición de diapositiva simple, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Aplicar un tipo de transición de diapositiva en la diapositiva a partir de uno de los efectos de transición ofrecidos por Aspose.Slides para .NET mediante el enumerado **TransitionType**
- Escribir el archivo de presentación modificado.
## **Ejemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantiate Presentation class that represents a presentation file

using (Presentation pres = new Presentation(FileName))

{

    //Apply circle type transition on slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Apply comb type transition on slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Apply zoom type transition on slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Write the presentation to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Descargar código de ejemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Descargar ejemplo en ejecución**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
Para obtener más detalles, visite [Gestión de transiciones de diapositivas](/slides/es/net/slide-transition/).
{{% /alert %}}