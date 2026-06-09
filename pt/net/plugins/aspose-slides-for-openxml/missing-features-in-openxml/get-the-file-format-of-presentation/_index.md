---
title: Obter o Formato do Arquivo da Apresentação
type: docs
weight: 50
url: /pt/net/get-the-file-format-of-presentation/
---
Para obter o formato do arquivo, siga as etapas abaixo:

- Crie uma instância da classe **IPresentationInfo**
- Obtenha informações sobre a apresentação

No exemplo abaixo, obtivemos o formato do arquivo.
## **Exemplo**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Baixar Exemplo em Execução**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)