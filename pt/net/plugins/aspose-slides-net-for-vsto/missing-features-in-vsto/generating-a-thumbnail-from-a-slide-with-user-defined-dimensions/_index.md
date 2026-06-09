---
title: Gerando uma Miniatura de um Slide com Dimensões Definidas pelo Usuário
type: docs
weight: 100
url: /pt/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Para gerar a miniatura de qualquer slide desejado usando Aspose.Slides para .NET:

- Crie uma instância da classe Presentation.
- Obtenha a referência de qualquer slide desejado usando seu ID ou índice.
- Obtenha os fatores de escala X e Y com base nas dimensões X e Y definidas pelo usuário.
- Obtenha a imagem em miniatura do slide referenciado em uma escala especificada.
- Salve a imagem em miniatura em qualquer formato de imagem desejado.

## **Exemplo**
```cs
//Instanciar a classe Presentation que representa o arquivo de apresentação
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Acessar o primeiro slide
    ISlide sld = pres.Slides[0];

    //Dimensão definida pelo usuário
    int desiredX = 1200;
    int desiredY = 800;

    //Obtendo os valores escalados de X e Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Criar uma imagem em escala total
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Salvar a imagem no disco no formato JPEG
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Para mais detalhes, visite [Converter Slide](/slides/pt/net/convert-slide/).

{{% /alert %}}