---
title: Conversão para XPS
type: docs
weight: 40
url: /pt/net/conversion-to-xps/
---
**XPS** formato também é amplamente usado para troca de dados. O Aspose.Slides para .NET reconhece sua importância e oferece suporte incorporado para converter uma apresentação em documento XPS.

O método **Save** exposto pela classe Presentation pode ser usado para converter toda a apresentação em documento **XPS**. Além disso, a classe **XpsOptions** expõe a propriedade **SaveMetafileAsPng**, que pode ser definida como true ou false conforme a necessidade.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instancia um objeto Presentation que representa um arquivo de apresentação

Presentation pres = new Presentation(srcFileName);

//Salvando a apresentação como documento TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)