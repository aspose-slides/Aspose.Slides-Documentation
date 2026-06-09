---
title: Criar Slide como Imagem SVG
type: docs
weight: 70
url: /pt/net/create-slide-as-svg-image/
---
Para gerar uma imagem SVG de qualquer slide desejado com Aspose.Slides.Pptx for .NET, siga as etapas abaixo:

- Crie uma instância da classe Presentation.
- Obtenha a referência do slide desejado usando seu ID ou índice.
- Obtenha a imagem SVG em um fluxo de memória.
- Salve o fluxo de memória em um arquivo.
## **Exemplo**

```

 //Instanciar uma classe Presentation que representa o arquivo de apresentação

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Acessar o segundo slide

   ISlide sld = pres.Slides[1];

   //Criar um objeto MemoryStream

   MemoryStream SvgStream = new MemoryStream();

   //Gerar imagem SVG do slide e salvar no fluxo de memória

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Salvar o fluxo de memória em um arquivo

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **Baixar Exemplo em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Baixar Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Para mais detalhes, visite [Renderizar Slides de Apresentação como Imagens SVG em .NET](/slides/pt/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}