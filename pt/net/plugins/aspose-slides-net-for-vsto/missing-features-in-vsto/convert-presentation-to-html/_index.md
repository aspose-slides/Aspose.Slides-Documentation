---
title: Converter Apresentação para HTML
type: docs
weight: 40
url: /pt/net/convert-presentation-to-html/
---
**HTML** é um dos vários formatos amplamente usados para troca de dados. **Aspose.Slides for .NET** oferece suporte para converter uma apresentação para HTML. Abaixo está um trecho de código que mostra como fazer.
## **Exemplo**
``` 

 //Instanciar um objeto Presentation que representa um arquivo de apresentação

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Salvar a apresentação em HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Para obter mais detalhes, visite [Converter Apresentações PowerPoint para HTML em .NET](/slides/pt/net/convert-powerpoint-to-html/).
{{% /alert %}}