---
title: Imprimir Apresentação
type: docs
url: /pt/net/print-the-presentation/
---
Aspose.Slides for .NET fornece quatro métodos sobrecarregados para impressão de apresentações. Esses métodos são flexíveis o suficiente para imprimir a apresentação na impressora padrão ou em qualquer impressora disponível com configurações personalizadas. Você só precisa selecionar o método de impressão apropriado de acordo com a necessidade.
## **Imprimir na Impressora Padrão**
Imprimir a apresentação na impressora padrão é bastante simples no Aspose.Slides for .NET. Execute as etapas a seguir para imprimir a apresentação na impressora padrão:

- Crie uma instância da classe Presentation para carregar uma apresentação que será impressa
- Chame o método Print sem parâmetros, conforme exposto pelo objeto Presentation

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Carregar a apresentação

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Chamar o método de impressão para imprimir toda a apresentação na impressora padrão

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Carregar a apresentação

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Chamar o método de impressão para imprimir toda a apresentação na impressora desejada

    asposePresentation.Print("LaserJet1100");


``` 
## **Imprimir em uma Impressora Específica**
Imprimir a apresentação em uma impressora específica requer o nome da impressora como parâmetro para o método Print da classe Presentation. Execute as etapas a seguir para imprimir a apresentação na impressora desejada:

- Crie uma instância da classe Presentation para carregar uma apresentação que será impressa
- Chame o método Print da classe Presentation passando o nome da impressora como parâmetro string para o método Print

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Carregar a apresentação

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Chamar o método de impressão para imprimir toda a apresentação na impressora desejada

    asposePresentation.Print("LaserJet1100");

}

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)