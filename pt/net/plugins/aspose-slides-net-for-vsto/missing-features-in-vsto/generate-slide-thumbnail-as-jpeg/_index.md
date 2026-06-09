---
title: Gerar miniatura de slide como JPEG
type: docs
weight: 90
url: /pt/net/generate-slide-thumbnail-as-jpeg/
---
Para gerar a miniatura de qualquer slide desejado usando Aspose.Slides para .NET:

- Crie uma instância da classe Presentation.
- Obtenha a referência de qualquer slide desejado usando seu ID ou índice.
- Obtenha a imagem em miniatura do slide referenciado em uma escala especificada.
- Salve a imagem em miniatura em qualquer formato de imagem desejado.
## **Exemplo**
```cs
//Instanciar a classe Presentation que representa o arquivo de apresentação
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Acessar o primeiro slide
    ISlide sld = pres.Slides[0];

    //Criar uma imagem em escala completa
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Salvar a imagem no disco no formato JPEG
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Para obter mais detalhes, visite [Converter PPT e PPTX para JPG em .NET](/slides/pt/net/convert-powerpoint-to-jpg/).
{{% /alert %}}