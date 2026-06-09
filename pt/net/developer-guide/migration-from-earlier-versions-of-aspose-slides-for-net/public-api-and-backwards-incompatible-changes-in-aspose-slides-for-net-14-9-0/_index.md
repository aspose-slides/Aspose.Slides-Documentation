---
title: Alterações de API Pública e Incompatíveis Retroativas no Aspose.Slides para .NET 14.9.0
linktitle: Aspose.Slides para .NET 14.9.0
type: docs
weight: 110
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legado
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as alterações incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e assim por diante [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/), e outras alterações introduzidas com a API do Aspose.Slides para .NET 14.9.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **Herança das interfaces ICollection e IEnumerable genéricas adicionada ao ISmartArtNodeCollection**
A classe Aspose.Slides.SmartArt.SmartArtNodeCollection (e a interface relacionada Aspose.Slides.SmartArt.ISmartArtNodeCollection) herdam a interface genérica IEnumerable<ISmartArtNode> e a interface ICollection.
#### **Valor Enum SmartArtLayoutType.Custom Adicionado**
O tipo de layout SmartArt Custom representa um diagrama com um modelo personalizado. Diagramas personalizados só podem ser carregados a partir de um arquivo de apresentação e não podem ser criados através do método ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Classe SmartArtShape e Interface ISmartArtShape Adicionadas**
A classe Aspose.Slides.SmartArt.SmartArtShape (e sua interface Aspose.Slides.SmartArt.ISmartArtShape) fornecem acesso a formas individuais em um diagrama SmartArt. SmartArtShape pode ser usado para alterar FillFormat, LineFormat, adicionar hyperlinks e outras tarefas.

{{% alert color="primary" %}} 

**Nota**: SmartArtShape não suporta as propriedades IShape RawFrame, Frame, Rotation, X, Y, Width, Height e lança uma System.NotSupportedException ao tentar acessá‑las.

Exemplo de uso:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Classe SmartArtShapeCollection, Interface ISmartArtShapeCollection e Propriedade ISmartArtNode.Shapes Adicionadas**
A classe Aspose.Slides.SmartArt.SmartArtShapeCollection (e sua interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) fornecem acesso a formas individuais em um diagrama SmartArt. A coleção contém formas associadas ao SmartArtNode. A propriedade SmartArtNode.Shapes devolve coleções de todas as formas associadas ao nó.

{{% alert color="primary" %}} 

**Nota**: dependendo do SmartArtLayoutType, uma SmartArtShape pode ser compartilhada entre vários nós.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Métodos para Salvar Slides com Números de Página Mantidos Adicionados**
Os seguintes métodos foram adicionados:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Esses métodos permitem que os desenvolvedores salvem slides específicos da apresentação para os formatos PDF, XPS, TIFF, HTML. O array 'slides' é usado para especificar os números das páginas, começando em 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array de posições dos slides

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Métodos para Substituir Imagens Adicionados a PPImage, IPPImage**
Novos métodos adicionados:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//Primeiro método

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Segundo método

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Terceiro método

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```