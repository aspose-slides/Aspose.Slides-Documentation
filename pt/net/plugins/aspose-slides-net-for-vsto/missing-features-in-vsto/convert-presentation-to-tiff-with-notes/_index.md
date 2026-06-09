---
title: Converter apresentação para Tiff com notas
type: docs
weight: 50
url: /pt/net/convert-presentation-to-tiff-with-notas/
---
TIFF é um dos vários formatos de imagem amplamente utilizados que o Aspose.Slides para .NET oferece suporte para converter uma apresentação com notas em imagens. Você também pode gerar miniaturas de slides na visualização de Slides de Notas. Abaixo estão dois trechos de código que mostram como gerar imagens TIFF de uma apresentação na visualização de Slides de Notas.

O método [Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/methods/save) exposto pela classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) pode ser usado para converter toda a apresentação na visualização de Slides de Notas para TIFF. Você também pode gerar uma miniatura de slide na visualização de Slides de Notas para slides individuais.
## **Exemplo**

``` 

  //Instanciar um objeto Presentation que representa um arquivo de apresentação

 Presentation pres = new Presentation("Conversion.pptx");

 //Salvar a apresentação em notas TIFF

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Para mais detalhes, visite [Converter Apresentações PowerPoint para TIFF com Notas em .NET](/slides/pt/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}