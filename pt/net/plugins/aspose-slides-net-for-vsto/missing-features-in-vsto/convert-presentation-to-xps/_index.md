---
title: Converter Apresentação para XPS
type: docs
weight: 60
url: /pt/net/convert-presentation-to-xps/
---
O formato **XPS** também é amplamente usado para troca de dados. O Aspose.Slides for .NET cuida de sua importância e oferece suporte interno para converter uma apresentação em documento **XPS**.

O método **Save** exposto pela classe Presentation pode ser usado para converter toda a apresentação em documento **XPS**. Além disso, a classe **XpsOptions** expõe a propriedade **SaveMetafileAsPng**, que pode ser definida como true ou false conforme a necessidade.
## **Exemplo**

``` 
 //Instanciar um objeto Presentation que representa um arquivo de apresentação

Presentation pres = new Presentation("Conversion.ppt");

//Salvar a apresentação em documento TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Baixar Código Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Para mais detalhes, visite [Converter apresentações PowerPoint para XPS em .NET](/slides/pt/net/convert-powerpoint-to-xps/).

{{% /alert %}}