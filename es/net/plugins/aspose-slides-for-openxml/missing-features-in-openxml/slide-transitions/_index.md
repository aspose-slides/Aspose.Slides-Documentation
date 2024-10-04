---
title: Transiciones de Diapositivas
type: docs
weight: 80
url: /es/net/slide-transitions/
---

Para facilitar la comprensión, hemos demostrado el uso de Aspose.Slides para .NET para gestionar transiciones de diapositivas simples. Los desarrolladores no solo pueden aplicar diferentes efectos de transición de diapositivas en las diapositivas, sino también personalizar el comportamiento de estos efectos de transición. Para crear un efecto de transición de diapositivas simple, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Aplique un Tipo de Transición de Diapositiva en la diapositiva de uno de los efectos de transición ofrecidos por Aspose.Slides para .NET a través de la enumeración **TransitionType**
- Escriba el archivo de presentación modificado.
## **Ejemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instanciar la clase Presentation que representa un archivo de presentación

using (Presentation pres = new Presentation(FileName))

{

    //Aplicar transición tipo círculo en la diapositiva 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Aplicar transición tipo peine en la diapositiva 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Aplicar transición tipo zoom en la diapositiva 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Escribir la presentación en el disco

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Descargar Código de Muestra**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Descargar Ejemplo en Ejecución**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Managing Slides Transitions/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Para más detalles, visite [Managing Slides Transitions](/slides/es/net/slide-transition/).

{{% /alert %}}