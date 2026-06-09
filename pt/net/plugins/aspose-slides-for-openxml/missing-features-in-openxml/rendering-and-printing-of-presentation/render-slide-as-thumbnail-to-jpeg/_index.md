---
title: Renderizar slide como miniatura para JPEG
type: docs
weight: 60
url: /pt/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** é usado para criar arquivos de apresentação contendo slides. Esses slides podem ser visualizados ao abrir os arquivos de apresentação usando o Microsoft PowerPoint. Mas, às vezes, os desenvolvedores podem precisar visualizar os slides como imagens usando seu visualizador de imagens favorito. Nesses casos, o Aspose.Slides for .NET ajuda a gerar imagens em miniatura dos slides.

Para gerar a miniatura de qualquer slide desejado usando o Aspose.Slides for .NET:

1. Crie uma instância da classe **Presentation**.
1. Obtenha a referência de qualquer slide desejado usando seu ID ou índice.
1. Obtenha a imagem em miniatura do slide referenciado em uma escala especificada.
1. Salve a imagem em miniatura em qualquer formato de imagem desejado.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instancie a classe Presentation que representa o arquivo de apresentação
using (Presentation pres = new Presentation(srcFileName))
{
    //Acesse o primeiro slide
    ISlide sld = pres.Slides[0];

    //Crie uma imagem em escala completa
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Salve a imagem no disco no formato JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)