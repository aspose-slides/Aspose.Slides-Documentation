---
title: Adicionar Imagem em Célula de Tabela
type: docs
weight: 10
url: /pt/net/add-image-in-table-cell/
---
## **VSTO**
Abaixo está o código para adicionar uma imagem em uma célula de tabela:

``` csharp

    //Abra a classe Presentation que contém a tabela

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Obtenha o primeiro slide

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
Aspose.Slides for .NET forneceu a API mais simples para criar tabelas da maneira mais fácil. Para adicionar uma imagem em uma célula de tabela ao criar uma nova tabela, siga as etapas abaixo:

- Crie uma instância da classe Presentation
- Obtenha a referência de um slide usando seu Índice
- Defina um array de colunas com largura
- Defina um array de linhas com altura
- Adicione uma Tabela ao slide usando o método AddTable exposto pelo objeto IShapes
- Crie um objeto Bitmap para armazenar o arquivo de imagem
- Adicione a imagem Bitmap ao objeto IPPImage
- Defina o formato de preenchimento da célula da tabela como Imagem
- Adicione a imagem à primeira célula da tabela
- Salve a apresentação modificada como um arquivo PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Obtenha o Primeiro Slide

  ISlide sld = MyPresentation.Slides[0];

  //Criando um objeto de imagem Bitmap para armazenar o arquivo de imagem

  using IImage image = Images.FromFile(ImageFile);

  //Crie um objeto IPPImage usando o objeto bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Adicionar imagem à primeira célula da tabela

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Salvar PPTX no Disco

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download do Código em Execução**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download do Código de Exemplo**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)