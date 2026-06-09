---
title: Gerenciar objetos OLE em apresentações no .NET
linktitle: Gerenciar OLE
type: docs
weight: 40
url: /pt/net/manage-ole/
keywords:
- objeto OLE
- Vinculação e Incorporação de Objetos
- adicionar OLE
- incorporar OLE
- adicionar objeto
- incorporar objeto
- adicionar arquivo
- incorporar arquivo
- objeto vinculado
- arquivo vinculado
- alterar OLE
- ícone OLE
- título OLE
- extrair OLE
- extrair objeto
- extrair arquivo
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Otimize o gerenciamento de objetos OLE no PowerPoint e em arquivos OpenDocument com Aspose.Slides para .NET. Incorpore, atualize e exporte o conteúdo OLE de forma contínua."
---
## **Introdução**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) é uma tecnologia da Microsoft que permite que dados e objetos criados em um aplicativo sejam colocados em outro aplicativo por meio de link ou incorporação. 

{{% /alert %}} 

Considere um gráfico criado no MS Excel. O gráfico é então colocado dentro de um slide do PowerPoint. Esse gráfico do Excel é considerado um objeto OLE. 

- Um objeto OLE pode aparecer como um ícone. Nesse caso, ao clicar duas vezes no ícone, o gráfico é aberto em seu aplicativo associado (Excel), ou é solicitado que você selecione um aplicativo para abrir ou editar o objeto. 
- Um objeto OLE pode exibir seu conteúdo real, como o conteúdo de um gráfico. Nesse caso, o gráfico é ativado no PowerPoint, a interface do gráfico é carregada e você pode modificar os dados do gráfico dentro do PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/pt/net/) permite inserir OLE Objects em slides como quadros de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe)).

## **Adicionar Quadros de Objeto OLE a Slides**

Assumindo que você já criou um gráfico no Microsoft Excel e deseja incorporá‑lo em um slide como um quadro de objeto OLE usando Aspose.Slides for .NET, você pode fazer isso da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Leia o arquivo Excel como um array de bytes.
4. Adicione o [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe) ao slide contendo o array de bytes e outras informações sobre o objeto OLE.
5. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um gráfico de um arquivo Excel a um slide como um [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe) usando Aspose.Slides for .NET.  
**Nota** que o construtor de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/pt/net/aspose.slides.dom.ole/oleembeddeddatainfo/) recebe uma extensão de objeto incorporável como segundo parâmetro. Essa extensão permite que o PowerPoint interprete corretamente o tipo de arquivo e escolha o aplicativo correto para abrir esse objeto OLE.

```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // Preparar dados para o objeto OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // Adicionar o quadro de objeto OLE ao slide.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **Adicionar Quadros de Objeto OLE Vinculados**

Aspose.Slides for .NET permite adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe) sem incorporar dados, mas apenas com um link para o arquivo.

Este código C# mostra como adicionar um [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe) com um arquivo Excel vinculado a um slide:

```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicionar um quadro de objeto OLE com um arquivo Excel vinculado.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Acessar Quadros de Objeto OLE**

Se um objeto OLE já está incorporado em um slide, você pode encontrá‑lo ou acessá‑lo facilmente desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Obtenha a referência do slide usando seu índice.
3. Acesse a forma [OleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe).  
   No nosso exemplo, usamos o PPTX criado anteriormente que contém apenas uma forma no primeiro slide. Em seguida, *cast* esse objeto como um [IOleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ioleobjectframe). Esse era o quadro de objeto OLE desejado para ser acessado.
4. Uma vez que o quadro de objeto OLE esteja acessado, você pode executar qualquer operação nele.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) e seus dados de arquivo são acessados.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obter a primeira forma como um quadro de objeto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // Obter os dados do arquivo incorporado.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // Obter a extensão do arquivo incorporado.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **Acessar Propriedades do Quadro de Objeto OLE Vinculado**

Aspose.Slides permite acessar propriedades de quadros de objeto OLE vinculados.

Este código C# mostra como verificar se um objeto OLE está vinculado e então obter o caminho para o arquivo vinculado:

```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // Obter a primeira forma como um quadro de objeto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // Verificar se o objeto OLE está vinculado.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // Imprimir o caminho completo do arquivo vinculado.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // Imprimir o caminho relativo do arquivo vinculado, se presente.
        // Apenas apresentações PPT podem conter o caminho relativo.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **Alterar Dados do Objeto OLE**

{{% alert color="primary" %}} 

Nesta seção, o exemplo de código abaixo usa [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

Se um objeto OLE já está incorporado em um slide, você pode acessar esse objeto e modificar seus dados desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Obtenha a referência do slide pelo seu índice. 
3. Acesse a forma [OLEObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe).  
   No nosso exemplo, usamos o PPTX criado anteriormente que contém uma forma no primeiro slide. Em seguida, *cast* esse objeto como um [IOleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ioleobjectframe). Esse era o quadro de objeto OLE desejado para ser acessado.
4. Uma vez que o quadro de objeto OLE esteja acessado, você pode executar qualquer operação nele.
5. Crie um objeto `Workbook` e acesse os dados OLE.
6. Acesse a `Worksheet` desejada e altere os dados.
7. Salve o `Workbook` atualizado em um stream.
8. Altere os dados do objeto OLE a partir do stream.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) é acessado e seus dados de arquivo são modificados para atualizar os dados do gráfico.

```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obter a primeira forma como um quadro de objeto OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // Ler os dados do objeto OLE como um objeto Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // Modificar os dados da Workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // Alterar os dados do objeto quadro OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Incorporar Outros Tipos de Arquivo em Slides**

Além de gráficos Excel, Aspose.Slides for .NET permite incorporar outros tipos de arquivos em slides. Por exemplo, você pode inserir arquivos HTML, PDF e ZIP como objetos. Quando o usuário clica duas vezes no objeto inserido, ele é aberto automaticamente no programa relevante, ou o usuário é solicitado a selecionar um programa apropriado para abri‑lo.

Este código C# mostra como incorporar HTML e ZIP em um slide:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Definir Tipos de Arquivo para Objetos Incorporados**

Ao trabalhar com apresentações, pode ser necessário substituir objetos OLE antigos por novos ou substituir um objeto OLE não suportado por um suportado. Aspose.Slides for .NET permite definir o tipo de arquivo para um objeto incorporado, permitindo atualizar os dados do quadro OLE ou sua extensão.

Este código C# mostra como definir o tipo de arquivo para um objeto OLE incorporado como `zip`:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // Alterar o tipo de arquivo para ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Definir Imagens de Ícone e Títulos para Objetos Incorporados**

Depois de incorporar um objeto OLE, uma pré‑visualização composta por uma imagem de ícone é adicionada automaticamente. Essa pré‑visualização é o que os usuários veem antes de acessar ou abrir o objeto OLE. Se você quiser usar uma imagem e um texto específicos como elementos na pré‑visualização, pode definir a imagem de ícone e o título usando Aspose.Slides for .NET.

Este código C# mostra como definir a imagem de ícone e o título para um objeto incorporado: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // Adicionar uma imagem aos recursos da apresentação.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // Definir um título e a imagem para a pré-visualização OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Impedir que um Quadro de Objeto OLE seja Redimensionado e Reposicionado**

Depois de adicionar um objeto OLE vinculado a um slide de apresentação, ao abrir a apresentação no PowerPoint, pode aparecer uma mensagem solicitando a atualização dos links. Clicar no botão “Update Links” pode alterar o tamanho e a posição do quadro do objeto OLE porque o PowerPoint atualiza os dados do objeto OLE vinculado e renova a pré‑visualização do objeto. Para impedir que o PowerPoint solicite a atualização dos dados do objeto, defina a propriedade `UpdateAutomatic` da interface [IOleObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ioleobjectframe/) como `false`:

```cs
oleFrame.UpdateAutomatic = false;
```

## **Extrair Arquivos Incorporados**

Aspose.Slides for .NET permite extrair os arquivos incorporados em slides como objetos OLE da seguinte forma:
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) contendo os objetos OLE que você pretende extrair.
2. Percorra todas as formas na apresentação e acesse as formas [OLEObjectFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/oleobjectframe).
3. Acesse os dados dos arquivos incorporados a partir dos quadros de objeto OLE e grave‑os no disco.

Este código C# mostra como extrair arquivos incorporados em um slide como objetos OLE:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **FAQ**

**O conteúdo OLE será renderizado ao exportar slides para PDF/imagens?**

O que está visível no slide é renderizado — o ícone/imagem substituta (pré‑visualização). O conteúdo OLE “ao vivo” não é executado durante a renderização. Se necessário, defina sua própria imagem de pré‑visualização para garantir a aparência esperada no PDF exportado.

**Como posso bloquear um objeto OLE em um slide para que os usuários não possam movê‑lo/editar no PowerPoint?**

Bloqueie a forma: Aspose.Slides fornece [bloqueios ao nível da forma](/slides/pt/net/applying-protection-to-presentation/). Não se trata de criptografia, mas impede efetivamente edições e movimentações acidentais.

**Por que um objeto Excel vinculado “salta” ou altera o tamanho quando eu abro a apresentação?**

O PowerPoint pode atualizar a pré‑visualização do OLE vinculado. Para uma aparência estável, siga as práticas da [Solução de Redimensionamento de Planilha](/slides/pt/net/working-solution-for-worksheet-resizing/): ajuste o quadro ao intervalo ou escale o intervalo para um quadro fixo e defina uma imagem substituta apropriada.

**Caminhos relativos para objetos OLE vinculados serão preservados no formato PPTX?**

No PPTX, a informação de “caminho relativo” não está disponível — apenas o caminho completo. Caminhos relativos são encontrados no formato mais antigo PPT. Para portabilidade, prefira caminhos absolutos confiáveis/URIs acessíveis ou incorporação.