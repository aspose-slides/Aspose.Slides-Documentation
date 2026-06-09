---
title: Renderizado como Tiff
type: docs
weight: 30
url: /pt/net/rendered-as-tiff/
---
O formato TIFF é conhecido por sua flexibilidade em acomodar imagens e dados multipágina. Considerando a importância e popularidade do formato TIFF, o Aspose.Slides for .NET oferece suporte para converter apresentações em documentos TIFF.  
Este artigo explica como diferentes opções de exportação TIFF:

- Convertendo a apresentação para TIFF com tamanho padrão.  
- Convertendo a apresentação para TIFF com tamanho personalizado.

O método **Save** exposto pela classe **Presentation** pode ser chamado pelos desenvolvedores para converter toda a apresentação em um documento **TIFF**. Além disso, a classe TiffOptions expõe a propriedade ImageSize, permitindo que o desenvolvedor defina o tamanho da imagem, se necessário.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instanciar um objeto Presentation que representa um arquivo de apresentação

using (Presentation pres = new Presentation(srcFileName))

{

    //Salvando a apresentação em um documento TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)