---
title: Imprimir Presentación
type: docs
url: /es/net/print-the-presentation/
---

Aspose.Slides para .NET proporciona cuatro métodos sobrecargados para imprimir las presentaciones. Estos métodos son lo suficientemente flexibles como para imprimir la presentación en la impresora predeterminada o en cualquiera de las impresoras disponibles con configuraciones personalizadas. Solo necesitas seleccionar el método de impresión adecuado de acuerdo con el requerimiento.
## **Impresión en la impresora predeterminada**
Imprimir la presentación en la impresora predeterminada es bastante simple en Aspose.Slides para .NET. Realiza los siguientes pasos para imprimir la presentación en la impresora predeterminada:

- Crea una instancia de la clase Presentation para cargar una presentación que se va a imprimir
- Llama al método Print sin parámetros, tal como lo expone el objeto Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Cargar la presentación

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Llamar al método de impresión para imprimir toda la presentación en la impresora predeterminada

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Cargar la presentación

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Llamar al método de impresión para imprimir toda la presentación en la impresora deseada

    asposePresentation.Print("LaserJet1100");


``` 
## **Impresión en una impresora específica**
Imprimir la presentación en una impresora específica requiere el nombre de la impresora como parámetro para el método Print de la clase Presentation. Realiza los siguientes pasos para imprimir la presentación en la impresora deseada:

- Crea una instancia de la clase Presentation para cargar una presentación que se va a imprimir
- Llama al método Print de la clase Presentation con el nombre de la impresora como parámetro de tipo string para el método Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Cargar la presentación

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Llamar al método de impresión para imprimir toda la presentación en la impresora deseada

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)