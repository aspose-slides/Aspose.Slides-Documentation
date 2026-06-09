---
title: Exportar arquivos de mídia para arquivo HTML
type: docs
weight: 40
url: /pt/net/export-media-files-to-html-file/
---
Para exportar arquivos de mídia para HTML, siga os passos abaixo:

- Crie uma instância da classe Presentation
- Obtenha a referência do slide
- Defina o efeito de transição
- Grave a apresentação como um arquivo PPTX

No exemplo abaixo, exportamos os arquivos de mídia para HTML.
## **Exemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName =  "video.html";

//Carregando uma apresentação

using (Presentation pres = new Presentation(srcFileName))

{

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: FilePath, fileName: destFileName, baseUri: baseUri);

    //Definindo opções HTML

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    //Salvando o arquivo

    pres.Save(destFileName, SaveFormat.Html, htmlOptions);

}

``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Export%20media%20files%20into%20html)

{{% alert color="primary" %}} 

Para obter mais detalhes, visite [Exportando arquivos de mídia para arquivo html](/slides/pt/net/cloning-commenting-and-manipulating-slides/#extracting-video-from-a-slide).

{{% /alert %}}