---
title: Renderizado como Tiff
type: docs
weight: 30
url: /pt/net/rendered-as-tiff/
---
O formato TIFF é conhecido por sua flexibilidade para acomodar imagens e dados multipáginas. Considerando a importância e popularidade do formato TIFF, o Aspose.Slides para .NET oferece suporte para converter apresentações em documento TIFF.
Este artigo explica as diferentes opções de exportação TIFF:

- Converter a apresentação para TIFF com tamanho padrão.
- Converter a apresentação para TIFF com tamanho personalizado.

O método **Save** exposto pela classe **Presentation** pode ser chamado pelos desenvolvedores para converter toda a apresentação em documento **TIFF**. Além disso, a classe TiffOptions expõe a propriedade ImageSize, permitindo ao desenvolvedor definir o tamanho da imagem, se necessário.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instanciar um objeto Presentation que representa um arquivo de apresentação

using (Presentation pres = new Presentation(srcFileName))

{
    //Salvando a apresentação como documento TIFF
    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);
}
``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)