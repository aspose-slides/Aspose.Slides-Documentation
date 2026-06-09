---
title: Removendo linha ou coluna em tabela no VSTO e Aspose.Slides
type: docs
weight: 130
url: /pt/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
Abaixo está o código para remover linhas ou colunas de uma tabela usando VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Obtenha o primeiro slide

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides para .NET oferece a API mais simples para criar tabelas da maneira mais fácil. Para criar uma tabela em um slide e executar algumas operações básicas na tabela, siga os passos abaixo:

- Criar uma instância da classe Presentation
- Obter a referência de um slide usando seu índice
- Definir array de colunas com largura
- Definir array de linhas com altura
- Adicionar uma tabela ao slide usando o método AddTable exposto pelo objeto IShapes
- Remover linha da tabela
- Remover coluna da tabela
- Salvar a apresentação modificada como um arquivo PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Obter o primeiro slide

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download do Código em Execução**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download do Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)