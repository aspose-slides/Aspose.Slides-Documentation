---
title: Acessar Apresentação OpenDocument
type: docs
weight: 10
url: /pt/net/access-opendocument-presentation/
---
Aspose.Slides for .NET oferece a classe **Presentation** que representa um arquivo de apresentação. A classe **Presentation** agora também pode acessar **ODP** através do construtor **Presentation** quando o objeto é instanciado.
## **Exemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Instanciar um objeto Presentation que representa um arquivo de apresentação

using (Presentation pres = new Presentation(srcFileName))

{

    //Salvar a apresentação PPTX no formato PPTX

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Baixar Exemplo em Execução**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)