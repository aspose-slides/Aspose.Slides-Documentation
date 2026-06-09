---
title: Trabalhando com Tamanho e Layout da Apresentação
type: docs
weight: 90
url: /pt/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** e **SlideSize.Size** são as propriedades da classe de apresentação que podem ser definidas ou obtidas conforme mostrado abaixo no exemplo.
## **Exemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Instanciar um objeto Presentation que representa um arquivo de apresentação
Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Salvar a apresentação no disco
auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Baixar Exemplo em Execução**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 
Para mais detalhes, visite [Alterar o tamanho do slide da apresentação em .NET](/slides/pt/net/slide-size/).
{{% /alert %}}