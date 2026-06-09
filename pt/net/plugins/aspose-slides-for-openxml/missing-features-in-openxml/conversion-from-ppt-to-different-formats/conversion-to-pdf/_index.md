---
title: Conversão para PDF
type: docs
weight: 30
url: /pt/net/conversion-to-pdf/
---
Documentos PDF são amplamente usados como formato padrão para troca de documentos entre organizações, setores governamentais e indivíduos. É um formato popular, portanto os desenvolvedores frequentemente recebem solicitações para converter arquivos de apresentações do Microsoft PowerPoint em documentos PDF. Reconhecendo essa possível necessidade, o Aspose.Slides for .NET oferece suporte à conversão de apresentações em documentos PDF sem a necessidade de usar qualquer outro componente.

**Aspose.Slides for .NET** oferece a classe Presentation que representa um arquivo de apresentação. A classe **Presentation** expõe o método Save que pode ser chamado para converter toda a apresentação em um documento **PDF**. A classe **PdfOptions** fornece opções para a criação do **PDF**, como JpegQuality, TextCompression, Compliance e outras. Essas opções podem ser usadas para alcançar o padrão desejado de PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instanciar um objeto Presentation que representa um arquivo de apresentação

Presentation pres = new Presentation(srcFileName);

//Salvar a apresentação em PDF com as opções padrão

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)