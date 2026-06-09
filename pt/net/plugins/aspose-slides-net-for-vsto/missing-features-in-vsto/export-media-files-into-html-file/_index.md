---
title: Exportar arquivos de mídia em arquivo HTML
type: docs
weight: 80
url: /pt/net/export-media-files-into-html-file/
---
Para exportar arquivos de mídia para HTML, siga os passos abaixo:

- Criar uma instância da classe Presentation
- Obter referência do slide
- Definir o efeito de transição
- Salvar a apresentação como um arquivo PPTX

No exemplo abaixo, exportamos os arquivos de mídia para HTML.
## **Exemplo**
``` 
 //Carregando uma apresentação

using (Presentation pres = new Presentation("example.pptx"))

{
   const string path = "path";
   const string fileName = "video.html";
   const string baseUri = "http://www.example.com/";
   VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);
   //Definindo opções HTML
   HtmlOptions htmlOptions = new HtmlOptions(controller);
   SVGOptions svgOptions = new SVGOptions(controller);
   htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
   htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);
   //Salvando o arquivo
   pres.Save(path + fileName, SaveFormat.Html, htmlOptions);
}
``` 
## **Baixar Exemplo em Execução**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Export%20media%20files%20into%20html)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)