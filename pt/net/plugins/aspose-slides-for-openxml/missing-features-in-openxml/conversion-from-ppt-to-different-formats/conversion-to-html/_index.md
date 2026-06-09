---
title: Conversão para HTML
type: docs
weight: 20
url: /pt/net/conversion-to-html/
---
**HTML** é um dos vários formatos amplamente usados para troca de dados. **Aspose.Slides for .NET** oferece suporte para converter uma apresentação em HTML. Abaixo está um trecho de código que mostra como fazer.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Instancia um objeto Presentation que representa um arquivo de apresentação

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Salvando a apresentação em HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)