---
title: Gerenciar nós de forma SmartArt em apresentações no .NET
linktitle: Nó de Forma SmartArt
type: docs
weight: 30
url: /pt/net/manage-smartart-shape-node/
keywords:
- nó SmartArt
- nó filho
- adicionar nó
- posição do nó
- acessar nó
- remover nó
- posição personalizada
- nó assistente
- formato de preenchimento
- renderizar nó
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie nós de forma SmartArt em PPT e PPTX com Aspose.Slides for .NET. Obtenha exemplos de código claros e dicas para otimizar suas apresentações."
---
## **Visão geral**

Os gráficos SmartArt em apresentações do PowerPoint são organizados por nós que contêm texto e definem a estrutura do diagrama. O Aspose.Slides permite trabalhar com esses nós SmartArt programaticamente: adicionar novos nós e nós filhos, inserir nós filhos em uma posição específica, acessar nós existentes e ler seu texto, nível e posição.

Este artigo explica como gerenciar os nós de forma SmartArt. Ele mostra como remover nós, trabalhar com nós filhos por índice ou posição, alterar um nó assistente para um nó normal, ajustar a posição, tamanho e rotação das formas de nó SmartArt, definir formatos de preenchimento dos nós e gerar uma imagem miniatura para um nó filho SmartArt.

## **Adicionar um Nó SmartArt**
Aspose.Slides for .NET tem a API mais simples para gerenciar as formas SmartArt da maneira mais fácil. O código de exemplo a seguir ajudará a adicionar nó e nó filho dentro da forma SmartArt.

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) e carregue a apresentação com a Forma SmartArt.  
- Obtenha a referência do primeiro slide usando seu Índice.  
- Percorra todas as formas dentro do primeiro slide.  
- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArt se for SmartArt.  
- Adicione um novo Nó na NodeCollection da forma SmartArt e defina o texto no TextFrame.  
- Agora, adicione um Nó Filho no Nó SmartArt recém‑adicionado e defina o texto no TextFrame.  
- Salve a Apresentação.

```c#
// Carregue a apresentação desejada
Presentation pres = new Presentation("AddNodes.pptx");

// Percorra todas as formas dentro do primeiro slide
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verifique se a forma é do tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Converta a forma para SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Adicionando um novo nó SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Adicionando texto
        TemNode.TextFrame.Text = "Test";

        // Adicionando um novo nó filho no nó pai. Ele será adicionado no final da coleção
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Adicionando texto
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Salvando a apresentação
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Adicionar um Nó SmartArt em uma Posição Específica**
No exemplo de código a seguir explicamos como adicionar os nós filhos pertencentes a nós específicos da forma SmartArt em uma posição determinada.

- Crie uma instância da classe `Presentation`.  
- Obtenha a referência do primeiro slide usando seu Índice.  
- Adicione uma forma SmartArt do tipo StackedList no slide acessado.  
- Acesse o primeiro nó na forma SmartArt adicionada.  
- Agora, adicione o Nó Filho para o Nó selecionado na posição 2 e defina seu texto.  
- Salve a Apresentação.

```c#
// Criando uma instância de apresentação
Presentation pres = new Presentation();

// Acessando o slide da apresentação
ISlide slide = pres.Slides[0];

// Adicionando IShape SmartArt
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Acessando o nó SmartArt no índice 0
ISmartArtNode node = smart.AllNodes[0];

// Adicionando novo nó filho na posição 2 no nó pai
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Adicionar texto
chNode.TextFrame.Text = "Sample Text Added";

// Salvar apresentação
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Acessar um Nó SmartArt**
O código de exemplo a seguir ajudará a acessar nós dentro da forma SmartArt. Observe que você não pode alterar o LayoutType do SmartArt, pois ele é somente leitura e é definido apenas quando a forma SmartArt é adicionada.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a Forma SmartArt.  

- Obtenha a referência do primeiro slide usando seu Índice.  

- Percorra todas as formas dentro do primeiro slide.  

- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArt se for SmartArt.  

- Percorra todos os nós dentro da Forma SmartArt.  

- Acesse e exiba informações como posição do Nó SmartArt, nível e Texto.

  ```c#
  // Carregue a apresentação desejada
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Percorra todas as formas dentro do primeiro slide
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Verifique se a forma é do tipo SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Converta a forma para SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Percorra todos os nós dentro do SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Acessando o nó SmartArt no índice i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Imprimindo os parâmetros do nó SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```

## **Acessar um Nó Filho SmartArt**
O código de exemplo a seguir ajudará a acessar os nós filhos pertencentes a nós específicos da forma SmartArt.

- Crie uma instância da classe PresentationEx e carregue a apresentação com a Forma SmartArt.  
- Obtenha a referência do primeiro slide usando seu Índice.  
- Percorra todas as formas dentro do primeiro slide.  
- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArtEx se for SmartArt.  
- Percorra todos os nós dentro da Forma SmartArt.  
- Para cada Nó da forma SmartArt selecionado, percorra todos os Nós Filhos dentro do nó específico.  
- Acesse e exiba informações como posição do Nó Filho, nível e Texto.

```c#
// Carregue a apresentação desejada
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Percorra todas as formas dentro do primeiro slide
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verifique se a forma é do tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Converta a forma para SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Percorra todos os nós dentro do SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Acessando o nó SmartArt no índice i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Percorrendo os nós filhos no nó SmartArt no índice i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Acessando o nó filho no nó SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Imprimindo os parâmetros do nó filho SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **Acessar um Nó Filho SmartArt em uma Posição Específica**
Neste exemplo, aprenderemos a acessar os nós filhos em posições específicas pertencentes a nós da forma SmartArt.

- Crie uma instância da classe `Presentation`.  
- Obtenha a referência do primeiro slide usando seu Índice.  
- Adicione uma forma SmartArt do tipo StackedList.  
- Acesse a forma SmartArt adicionada.  
- Acesse o nó no índice 0 da forma SmartArt acessada.  
- Agora, acesse o Nó Filho na posição 1 do nó SmartArt acessado usando o método GetNodeByPosition().  
- Acesse e exiba informações como posição do Nó Filho, nível e Texto.

```c#
// Instancie a apresentação
Presentation pres = new Presentation();

// Acesse o primeiro slide
ISlide slide = pres.Slides[0];

// Adicione a forma SmartArt no primeiro slide
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Acesse o nó SmartArt  no índice 0
ISmartArtNode node = smart.AllNodes[0];

// Acesse o nó filho na posição 1 no nó pai
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Imprima os parâmetros do nó filho SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **Remover um Nó SmartArt**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a Forma SmartArt.  
- Obtenha a referência do primeiro slide usando seu Índice.  
- Percorra todas as formas dentro do primeiro slide.  
- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArt se for SmartArt.  
- Verifique se o SmartArt possui mais de 0 nós.  
- Selecione o nó SmartArt a ser excluído.  
- Agora, remova o nó selecionado usando o método RemoveNode()* Salve a Apresentação.

```c#
// Carregue a apresentação desejada
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Percorra todas as formas dentro do primeiro slide
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Verifique se a forma é do tipo SmartArt
        if (shape is ISmartArt)
        {
            // Converta a forma para SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Acessando o nó SmartArt no índice 0
                ISmartArtNode node = smart.AllNodes[0];

                // Removendo o nó selecionado
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Salvar apresentação
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Remover um Nó SmartArt em uma Posição Específica**
Neste exemplo, aprenderemos a remover os nós dentro da forma SmartArt em uma posição determinada.

- Crie uma instância da classe `Presentation` e carregue a apresentação com a Forma SmartArt.  
- Obtenha a referência do primeiro slide usando seu Índice.  
- Percorra todas as formas dentro do primeiro slide.  
- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArt se for SmartArt.  
- Selecione o nó da forma SmartArt no índice 0.  
- Agora, verifique se o nó SmartArt selecionado possui mais de 2 nós filhos.  
- Em seguida, remova o nó na Posição 1 usando o método RemoveNodeByPosition().  
- Salve a Apresentação.

```c#
// Carregue a apresentação desejada             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Traverse through every shape inside first slide
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Verifique se a forma é do tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Converta a forma para SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Acessando o nó SmartArt no índice 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Removendo o nó filho na posição 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Salvar apresentação
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Definir uma Posição Personalizada para um Nó Filho em um Objeto SmartArt**
Agora o Aspose.Slides for .NET oferece suporte para definir as propriedades X e Y da SmartArtShape. O trecho de código abaixo mostra como definir a posição, tamanho e rotação personalizados da SmartArtShape; observe que a adição de novos nós provoca um recálculo das posições e tamanhos de todos os nós.

```c#
// Carregue a apresentação desejada
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Mova a forma SmartArt para uma nova posição
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Altere as larguras da forma SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Altere a altura da forma SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Altere a rotação da forma SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **Verificar um Nó Assistente**
No código de exemplo a seguir investigaremos como identificar Nós Assistentes na coleção de nós SmartArt e alterá‑los.

- Crie uma instância da classe PresentationEx e carregue a apresentação com a Forma SmartArt.  
- Obtenha a referência do segundo slide usando seu Índice.  
- Percorra todas as formas dentro do primeiro slide.  
- Verifique se a forma é do tipo SmartArt e converta a forma selecionada para SmartArtEx se for SmartArt.  
- Percorra todos os nós dentro da forma SmartArt e verifique se são Nós Assistentes.  
- Altere o status do Nó Assistente para nó normal.  
- Salve a Apresentação.

```c#
 // Criando uma instância de apresentação
 using (Presentation pres = new Presentation("AssistantNode.pptx"))
 {
     // Percorra todas as formas dentro do primeiro slide
     foreach (IShape shape in pres.Slides[0].Shapes)
     {
         // Verifique se a forma é do tipo SmartArt
         if (shape is Aspose.Slides.SmartArt.ISmartArt)
         {
             // Converta a forma para SmartArtEx
             Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
             // Percorrendo todos os nós da forma SmartArt

             foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
             {
                 String tc = node.TextFrame.Text;
                 // Verifique se o nó é um nó Assistente
                 if (node.IsAssistant)
                 {
                     // Definindo o nó Assistente como false e tornando-o nó normal
                     node.IsAssistant = false;
                 }
             }
         }
     }
     // Salvar apresentação
     pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Definir o Formato de Preenchimento de um Nó**
Aspose.Slides for .NET permite adicionar formas SmartArt personalizadas e definir seus formatos de preenchimento. Este artigo explica como criar e acessar formas SmartArt e definir seu formato de preenchimento usando Aspose.Slides for .NET.

Siga os passos abaixo:

- Crie uma instância da classe `Presentation`.  
- Obtenha a referência de um slide usando seu índice.  
- Adicione uma forma SmartArt definindo seu LayoutType.  
- Defina o FillFormat para os nós da forma SmartArt.  
- Grave a apresentação modificada como arquivo PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Acessando o slide
    ISlide slide = presentation.Slides[0];

    // Adicionando forma SmartArt e nós
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Definindo a cor de preenchimento do nó
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Salvando a apresentação
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **Gerar uma Miniatura de um Nó Filho SmartArt**
Os desenvolvedores podem gerar uma miniatura do nó filho de um SmartArt seguindo os passos abaixo:

1. Instancie a classe `Presentation` que representa o arquivo PPTX.  
2. Adicione SmartArt.  
3. Obtenha a referência de um nó usando seu Índice.  
4. Recupere a imagem da miniatura.  
5. Salve a imagem da miniatura no formato desejado.

O exemplo abaixo gera uma miniatura do nó filho SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **FAQ**

**A animação SmartArt é suportada?**

Sim. SmartArt é tratado como uma forma comum, portanto você pode [aplicar animações padrão](/slides/pt/net/shape-animation/) (entrada, saída, ênfase, caminhos de movimento) e ajustar o tempo. Também é possível animar formas dentro dos nós SmartArt quando necessário.

**Como localizar de forma confiável um SmartArt específico em um slide se seu ID interno for desconhecido?**

Atribua e pesquise por [texto alternativo](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/alternativetext/). Definir um AltText distintivo no SmartArt permite encontrá‑lo programaticamente sem depender de identificadores internos.

**A aparência do SmartArt será preservada ao converter a apresentação para PDF?**

Sim. O Aspose.Slides renderiza SmartArt com alta fidelidade visual durante a [exportação para PDF](/slides/pt/net/convert-powerpoint-to-pdf/), preservando layout, cores e efeitos.

**Posso extrair uma imagem de todo o SmartArt (para pré‑visualizações ou relatórios)?**

Sim. Você pode renderizar uma forma SmartArt para [formatos raster](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/getimage/) ou para [SVG](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/writeassvg/) para saída vetorial escalável, tornando-a adequada para miniaturas, relatórios ou uso na web.