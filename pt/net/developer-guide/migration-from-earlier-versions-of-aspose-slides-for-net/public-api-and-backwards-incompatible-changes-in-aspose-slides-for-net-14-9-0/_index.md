---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 14.9.0
linktitle: Aspose.Slides para .NET 14.9.0
type: docs
weight: 110
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades etc. [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) e outras alterações introduzidas na API do Aspose.Slides for .NET 14.9.0.

{{% /alert %}} 
## **Public API Changes**
#### **Inheritance from ICollection and Generic IEnumerable Interfaces Added to ISmartArtNodeCollection**
A classe Aspose.Slides.SmartArt.SmartArtNodeCollection (e a interface relacionada Aspose.Slides.SmartArt.ISmartArtNodeCollection) herdam a interface genérica IEnumerable<ISmartArtNode> e a interface ICollection.
#### **SmartArtLayoutType.Custom Enum Value Added**
O tipo de layout SmartArt Custom representa um diagrama com um modelo personalizado. Diagramas personalizados só podem ser carregados a partir de um arquivo de apresentação e não podem ser criados via o método ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **SmartArtShape Class and ISmartArtShape Interface Added**
A classe Aspose.Slides.SmartArt.SmartArtShape (e sua interface Aspose.Slides.SmartArt.ISmartArtShape) dão acesso a formas individuais em um diagrama SmartArt. SmartArtShape pode ser usado para alterar FillFormat, LineFormat, adicionar Hyperlinks e outras tarefas.

{{% alert color="info" %}} 

**Observação**: SmartArtShape não suporta as propriedades IShape RawFrame, Frame, Rotation, X, Y, Width, Height e lança uma System.NotSupportedException ao tentar acessá‑las.

Exemplo de uso:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **SmartArtShapeCollection Class, ISmartArtShapeCollection Interface and ISmartArtNode.Shapes Property Added**
A classe Aspose.Slides.SmartArt.SmartArtShapeCollection (e sua interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) adicionam acesso a formas individuais em um diagrama SmartArt. A coleção contém as formas associadas ao SmartArtNode. A propriedade SmartArtNode.Shapes devolve coleções de todas as formas associadas ao nó.

{{% alert color="info" %}} 

**Observação**: dependendo do SmartArtLayoutType, uma SmartArtShape pode ser compartilhada entre vários nós.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Methods for Saving Slides with Page Numbers Keeping Added**
Os seguintes métodos foram adicionados:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Esses métodos permitem que desenvolvedores salvem slides específicos da apresentação em formatos PDF, XPS, TIFF, HTML. O array *slides* é usado para especificar os números das páginas, começando em 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Array de posições dos slides

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Methods for Replacing Images Added to PPImage, IPPImage**
Novos métodos adicionados:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Primeiro método

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Segundo método

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Terceiro método

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```