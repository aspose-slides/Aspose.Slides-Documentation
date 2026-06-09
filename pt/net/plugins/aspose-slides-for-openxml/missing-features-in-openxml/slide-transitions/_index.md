---
title: Transições de Slides
type: docs
weight: 80
url: /pt/net/slide-transitions/
---
Para facilitar a compreensão, demonstramos o uso do Aspose.Slides for .NET para gerenciar transições de slides simples. Os desenvolvedores podem não apenas aplicar diferentes efeitos de transição de slides nos slides, mas também personalizar o comportamento desses efeitos de transição.Para criar um efeito simples de transição de slide, siga as etapas abaixo:

- Crie uma instância da classe Presentation
- Aplique um Tipo de Transição de Slide no slide a partir de um dos efeitos de transição oferecidos pelo Aspose.Slides for .NET através do enum **TransitionType**
- Grave o arquivo de apresentação modificado.
## **Exemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instancie a classe Presentation que representa um arquivo de apresentação

using (Presentation pres = new Presentation(FileName))

{

    //Aplique a transição do tipo círculo no slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Aplique a transição do tipo pente no slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Aplique a transição do tipo zoom no slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Grave a apresentação no disco

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Baixar Exemplo em Execução**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

Para mais detalhes, visite [Managing Slides Transitions](/slides/pt/net/slide-transition/).

{{% /alert %}}