---
title: Imprimir presentación
type: docs
url: /es/net/print-the-presentation/
---

Aspose.Slides for .NET proporciona cuatro sobrecargas de métodos para la impresión de presentaciones. Estos métodos son lo suficientemente flexibles como para imprimir la presentación en la impresora predeterminada o en cualquiera de las impresoras disponibles con configuraciones personalizadas. Sólo necesita seleccionar el método de impresión adecuado según el requisito.
## **Imprimir en la impresora predeterminada**
Imprimir la presentación en la impresora predeterminada es bastante sencillo en Aspose.Slides for .NET. Realice los siguientes pasos para imprimir la presentación en la impresora predeterminada:

- Crear una instancia de la clase Presentation para cargar la presentación que se va a imprimir
- Llamar al método Print sin parámetros que expone el objeto Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Cargar la presentación

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Llamar al método Print para imprimir toda la presentación en la impresora predeterminada

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Cargar la presentación

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Llamar al método Print para imprimir toda la presentación en la impresora deseada

    asposePresentation.Print("LaserJet1100");


``` 
## **Imprimir en una impresora específica**
Imprimir la presentación en una impresora específica requiere el nombre de la impresora como parámetro del método Print de la clase Presentation. Realice los siguientes pasos para imprimir la presentación en la impresora deseada:

- Crear una instancia de la clase Presentation para cargar la presentación que se va a imprimir
- Llamar al método Print de la clase Presentation con el nombre de la impresora como parámetro de tipo cadena

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Cargar la presentación

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Llamar al método Print para imprimir toda la presentación en la impresora deseada

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Descargar código de ejemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)