---
title: Abrindo uma Apresentação no VSTO e Aspose.Slides
type: docs
weight: 120
url: /pt/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Abaixo está o trecho de código para abrir a apresentação:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


```
## **Aspose.Slides**
Aspose.Slides para .NET fornece a classe **Presentation** que é usada para abrir uma apresentação existente. Ela oferece alguns construtores sobrecarregados e podemos usar um dos construtores adequados da classe **Presentation** para criar seu objeto com base em uma apresentação existente. No exemplo abaixo, passamos o nome do arquivo de apresentação (a ser aberto) para o construtor da classe Presentation. Depois que o arquivo é aberto, obtemos o número total de slides presentes na apresentação para exibir na tela.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

```
## **Baixar Código em Execução**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)