---
title: Adicionando Formas à Apresentação
type: docs
weight: 30
url: /pt/net/adding-shapes-to-presentation/
---
## **VSTO**
A seguir está o trecho de código para adicionar uma forma de linha:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
Para adicionar uma linha simples a um slide selecionado da apresentação, siga os passos abaixo:

- Crie uma instância da classe Presentation
- Obtenha a referência de um slide usando seu Índice
- Adicione um AutoShape do tipo Linha usando o método AddAutoShape exposto pelo objeto Shapes
- Grave a apresentação modificada como um arquivo PPTX

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

``` csharp

   //Instancia a classe Presentation que representa o PPTX

  Presentation pres = new Presentation();

  //Obtém o primeiro slide

  ISlide slide = pres.Slides[0];

  //Adiciona um autoshape do tipo linha

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Baixar Código em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)