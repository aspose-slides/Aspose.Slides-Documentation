---
title: Renderizar slide como miniatura em JPEG por valores definidos pelo usuário
type: docs
weight: 70
url: /pt/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Para gerar a miniatura de qualquer slide desejado usando Aspose.Slides para .NET:

1. Crie uma instância da classe **Presentation**.
1. Obtenha a referência de qualquer slide desejado usando seu ID ou índice.
1. Obtenha os fatores de escala X e Y com base nas dimensões X e Y definidas pelo usuário.
1. Obtenha a imagem em miniatura do slide referenciado em uma escala especificada.
1. Salve a imagem em miniatura em qualquer formato de imagem desejado.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instanciar a classe Presentation que representa o arquivo de apresentação
using (Presentation pres = new Presentation(srcFileName))
{
    //Acessar o primeiro slide
    ISlide sld = pres.Slides[0];

    //Dimensão definida pelo usuário
    int desiredX = 1200;
    int desiredY = 800;

    //Obter valor dimensionado de X e Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Criar uma imagem em escala total
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Salvar a imagem no disco em formato JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)