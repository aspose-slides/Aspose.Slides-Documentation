---
title: Solução Funcional para Redimensionamento de Gráficos em PPTX
type: docs
weight: 60
url: /pt/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para .NET. Aprenda dois métodos com código para manter os tamanhos consistentes."
---
## **Contexto**

Observou‑se que os gráficos do Excel incorporados como objetos OLE em uma apresentação do PowerPoint por meio dos componentes Aspose são redimensionados para uma escala não especificada após a primeira ativação. Esse comportamento causa uma diferença visual perceptível na apresentação entre os estados antes e depois da ativação do gráfico. A equipe da Aspose investigou o problema em detalhe e encontrou uma solução. Este artigo descreve as causas do problema e a correção correspondente.

No [artigo anterior](/slides/pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells para .NET e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides para .NET. Para resolver o [problema de visualização do objeto](/slides/pt/net/object-preview-issue-when-adding-oleobjectframe/), atribuímos a imagem do gráfico ao quadro do objeto OLE do gráfico. Na apresentação resultante, ao clicar duas vezes no quadro do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários finais podem fazer as alterações desejadas na pasta de trabalho do Excel subjacente e, em seguida, retornar ao slide correspondente clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE muda quando o usuário retorna ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro do objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel tem seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. Entretanto, o quadro do objeto OLE tem seu próprio tamanho. De acordo com a Microsoft, quando a pasta de trabalho do Excel é ativada, o Excel e o PowerPoint negociam o tamanho e mantêm as proporções corretas como parte do processo de incorporação. Dependendo das diferenças entre o tamanho da janela do Excel e o tamanho ou posição do quadro do objeto OLE, ocorre o redimensionamento.

## **Solução Funcional**

Existem dois cenários possíveis para criar apresentações do PowerPoint usando Aspose.Slides para .NET.

**Cenário 1:** Criar uma apresentação com base em um modelo existente.

**Cenário 2:** Criar uma apresentação do zero.

A solução que fornecemos aqui se aplica a ambos os cenários. A base de todas as abordagens de solução é a mesma: **o tamanho da janela do objeto OLE incorporado deve corresponder ao quadro do objeto OLE no slide do PowerPoint**. Agora discutiremos as duas abordagens para essa solução.

## **Primeira Abordagem**

Nessa abordagem, aprenderemos como definir o tamanho da janela da pasta de trabalho do Excel incorporada para que corresponda ao tamanho do quadro do objeto OLE no slide do PowerPoint.

**Cenário 1**

Suponha que tenhamos definido um modelo e queiramos criar apresentações com base nele. Presuma que exista uma forma no índice 2 do modelo onde desejamos colocar um quadro OLE contendo uma pasta de trabalho do Excel incorporada. Nesse cenário, o tamanho do quadro do objeto OLE é predefinido—corresponde ao tamanho da forma no índice 2 do modelo. Tudo o que precisamos fazer é definir o tamanho da janela da pasta de trabalho igual ao tamanho dessa forma. O trecho de código a seguir cumpre esse propósito:

```cs
// Defina o tamanho do gráfico com uma janela. 
chart.SizeWithWindow = true;

// Defina a largura da janela da pasta de trabalho em polegadas (dividido por 72, pois o PowerPoint usa 72 pixels por polegada).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Defina a altura da janela da pasta de trabalho em polegadas.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Salve a pasta de trabalho em um fluxo de memória.
MemoryStream workbookStream = workbook.SaveToStream();

// Crie um quadro de objeto OLE com os dados do Excel incorporados.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Cenário 2**

Vamos supor que queiramos criar uma apresentação do zero e incluir um quadro de objeto OLE de qualquer tamanho com uma pasta de trabalho do Excel incorporada. No trecho de código a seguir, criamos um quadro de objeto OLE com 4 polegadas de altura e 9,5 polegadas de largura em x = 0,5 polegadas e y = 1 polegada no slide. Em seguida, definimos a janela da pasta de trabalho do Excel para o mesmo tamanho—4 polegadas de altura e 9,5 polegadas de largura.

```cs
// Nossa altura desejada.
int desiredHeight = 288; // 4 polegadas (4 * 72)

// Nossa largura desejada.
int desiredWidth = 684;//9,5 polegadas (9,5 * 72)

// Defina o tamanho do gráfico com uma janela.
chart.SizeWithWindow = true;

// Defina a largura da janela da pasta de trabalho em polegadas.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Defina a altura da janela da pasta de trabalho em polegadas.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Salve a pasta de trabalho em um fluxo de memória.
MemoryStream workbookStream = workbook.SaveToStream();

// Crie um quadro de objeto OLE com os dados do Excel incorporados.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Segunda Abordagem**

Nessa abordagem, aprenderemos como definir o tamanho do gráfico na pasta de trabalho do Excel incorporada para que corresponda ao tamanho do quadro do objeto OLE no slide do PowerPoint. Essa abordagem é útil quando o tamanho do gráfico é conhecido antecipadamente e nunca mudará.

**Cenário 1**

Suponha que tenhamos definido um modelo e queiramos criar apresentações com base nele. Presuma que exista uma forma no índice 2 do modelo onde pretendemos colocar um quadro OLE contendo uma pasta de trabalho do Excel incorporada. Nesse cenário, o tamanho do quadro OLE é predefinido—corresponde ao tamanho da forma no índice 2 do modelo. Tudo o que precisamos fazer é definir o tamanho do gráfico na pasta de trabalho igual ao tamanho dessa forma. O trecho de código a seguir cumpre esse propósito:

```cs
// Defina o tamanho do gráfico sem janela. 
chart.SizeWithWindow = false;

// Defina a largura do gráfico em pixels (multiplique por 96, pois o Excel usa 96 pixels por polegada).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Defina a altura do gráfico em pixels.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Defina o tamanho de impressão do gráfico.
chart.PrintSize = PrintSizeType.Custom;

// Salve a pasta de trabalho em um fluxo de memória.
MemoryStream workbookStream = workbook.SaveToStream();

// Crie um quadro de objeto OLE com os dados do Excel incorporados.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Cenário 2**

Suponha que queiramos criar uma apresentação do zero e incluir um quadro de objeto OLE de qualquer tamanho com uma pasta de trabalho do Excel incorporada. No trecho de código a seguir, criamos um quadro de objeto OLE com altura de 4 polegadas e largura de 9,5 polegadas no slide em x = 0,5 polegadas e y = 1 polegada. Também definimos o tamanho do gráfico correspondente para as mesmas dimensões: altura de 4 polegadas e largura de 9,5 polegadas.

```cs
 // Nossa altura desejada.
int desiredHeight = 288; // 4 polegadas (4 * 576)

// Nossa largura desejada.
int desiredWidth = 684; // 9,5 polegadas (9,5 * 576)

// Defina o tamanho do gráfico sem janela. 
chart.SizeWithWindow = false;

// Defina a largura do gráfico em pixels.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Defina a altura do gráfico em pixels.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Save the workbook to a memory stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
 workbookStream.ToArray());
```

## **Conclusão**

Existem duas abordagens para corrigir o problema de redimensionamento do gráfico. A escolha da abordagem depende dos requisitos e do caso de uso. Ambas as abordagens funcionam da mesma forma, seja a apresentação criada a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nessa solução.

## **Perguntas Frequentes**

**Por que o gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**  
Isso ocorre porque o Excel tenta restaurar o tamanho original da janela na primeira ativação, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível impedir totalmente esse problema de redimensionamento?**  
Sim. Ao equiparar o tamanho da janela da pasta de trabalho do Excel ou o tamanho do gráfico ao tamanho do quadro do objeto OLE antes da incorporação, você pode manter os tamanhos dos gráficos consistentes.

**Qual abordagem devo usar, definir o tamanho da janela da pasta de trabalho ou definir o tamanho do gráfico?**  
Use **Abordagem 1 (tamanho da janela)** se quiser manter a proporção da pasta de trabalho e possibilitar redimensionamento futuro.  
Use **Abordagem 2 (tamanho do gráfico)** se as dimensões do gráfico forem fixas e não mudarão após a incorporação.

**Esses métodos funcionam tanto com apresentações baseadas em modelo quanto com novas apresentações?**  
Sim. Ambas as abordagens funcionam da mesma forma para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho do quadro do objeto OLE?**  
Não. Você pode definir o quadro OLE em qualquer tamanho, contanto que ele escale adequadamente ao tamanho da pasta de trabalho ou do gráfico.

**Posso usar esses métodos com gráficos criados em outros programas de planilha?**  
Os exemplos são projetados para gráficos do Excel criados com Aspose.Cells, mas os princípios se aplicam a outros programas de planilha compatíveis com OLE, desde que ofereçam opções de dimensionamento semelhantes.

## **Seções Relacionadas**

- [Criar gráficos do Excel e incorporá‑los como objetos OLE em apresentações](/slides/pt/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Atualizar objetos OLE automaticamente usando um suplemento do PowerPoint](/slides/pt/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)