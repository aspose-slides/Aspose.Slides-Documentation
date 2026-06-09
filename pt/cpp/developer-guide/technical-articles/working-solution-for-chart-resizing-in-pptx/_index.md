---
title: Solução Funcional para Redimensionamento de Gráficos no PPTX
type: docs
weight: 60
url: /pt/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionamento de gráfico
- gráfico do Excel
- objeto OLE
- incorporar gráfico
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Corrija o redimensionamento inesperado de gráficos em PPTX ao usar objetos OLE do Excel incorporados com Aspose.Slides para C++. Aprenda dois métodos com código para manter os tamanhos consistentes."
---
## **Contexto**

Observou‑se que gráficos do Excel incorporados como objetos OLE em uma apresentação do PowerPoint por meio dos componentes Aspose são redimensionados para uma escala não especificada após sua primeira ativação. Esse comportamento causa uma diferença visual perceptível na apresentação entre os estados pré‑ e pós‑ativação do gráfico. A equipe da Aspose investigou o problema em detalhes e encontrou uma solução. Este artigo descreve as causas do problema e a correção correspondente.

No [artigo anterior](/slides/pt/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), explicamos como criar um gráfico do Excel com Aspose.Cells for C++ e incorporá‑lo em uma apresentação do PowerPoint usando Aspose.Slides for C++. Para resolver o [problema de visualização do objeto](/slides/pt/cpp/object-preview-issue-when-adding-oleobjectframe/), atribuimos a imagem do gráfico ao quadro do objeto OLE do gráfico. Na apresentação resultante, ao dar um duplo‑clique no quadro do objeto OLE que exibe a imagem do gráfico, o gráfico do Excel é ativado. Os usuários finais podem fazer quaisquer alterações desejadas na pasta de trabalho do Excel subjacente e, em seguida, retornar ao slide correspondente clicando fora da pasta de trabalho ativada. O tamanho do quadro do objeto OLE muda quando o usuário volta ao slide, e o fator de redimensionamento varia dependendo dos tamanhos originais tanto do quadro do objeto OLE quanto da pasta de trabalho do Excel incorporada.

## **Causa do Redimensionamento**

Como a pasta de trabalho do Excel possui seu próprio tamanho de janela, ela tenta manter seu tamanho original na primeira ativação. O quadro do objeto OLE, porém, tem seu próprio tamanho. Segundo a Microsoft, quando a pasta de trabalho do Excel é ativada, Excel e PowerPoint negociam o tamanho e mantêm as proporções corretas como parte do processo de incorporação. Dependendo das diferenças entre o tamanho da janela do Excel e o tamanho ou a posição do quadro do objeto OLE, ocorre o redimensionamento.

## **Solução Funcional**

Existem dois cenários possíveis para criar apresentações do PowerPoint usando Aspose.Slides for C++.

**Cenário 1:** Criar uma apresentação a partir de um modelo existente.

**Cenário 2:** Criar uma apresentação do zero.

A solução que fornecemos aqui se aplica a ambos os cenários. O fundamento de todas as abordagens de solução é o mesmo: ** o tamanho da janela do objeto OLE incorporado deve corresponder ao quadro do objeto OLE no slide do PowerPoint**. Agora discutiremos as duas abordagens para essa solução.

## **Primeira Abordagem**

Nessa abordagem, aprenderemos a definir o tamanho da janela da pasta de trabalho do Excel incorporada para que corresponda ao tamanho do quadro do objeto OLE no slide do PowerPoint.

**Cenário 1** 

Suponha que tenhamos definido um modelo e queremos criar apresentações baseadas nele. Imagine que exista uma forma no índice 2 do modelo onde queremos colocar um quadro OLE contendo uma pasta de trabalho do Excel incorporada. Nesse cenário, o tamanho do quadro do objeto OLE é predefinido — corresponde ao tamanho da forma no índice 2 do modelo. Tudo o que precisamos fazer é definir o tamanho da janela da pasta de trabalho igual ao tamanho dessa forma. O trecho de código a seguir cumpre esse propósito:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Defina o tamanho do gráfico com uma janela. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Defina a largura da janela da pasta de trabalho em polegadas (dividida por 72, pois o PowerPoint usa 72 pixels por polegada).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Defina a altura da janela da pasta de trabalho em polegadas.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Salve a pasta de trabalho em um fluxo de memória.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crie um quadro de objeto OLE com os dados do Excel incorporados.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Cenário 2** 

Digamos que queiramos criar uma apresentação do zero e incluir um quadro OLE de qualquer tamanho com uma pasta de trabalho do Excel incorporada. No trecho de código a seguir, criamos um quadro OLE com 4 polegadas de altura e 9,5 polegadas de largura em x = 0,5 polegada e y = 1 polegada no slide. Em seguida, definimos a janela da pasta de trabalho do Excel para o mesmo tamanho — 4 polegadas de altura e 9,5 polegadas de largura.

```cpp
// Nossa altura desejada.
int32_t desiredHeight = 288; // 4 polegadas (4 * 72)

// Nossa largura desejada.
int32_t desiredWidth = 684; // 9,5 polegadas (9.5 * 72)

// Defina o tamanho do gráfico com uma janela. 
chart->SetSizeWithWindow(true);

// Defina a largura da janela da pasta de trabalho em polegadas.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Defina a altura da janela da pasta de trabalho em polegadas.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Salve a pasta de trabalho em um fluxo de memória.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crie um quadro de objeto OLE com os dados do Excel incorporados.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Segunda Abordagem**

Nessa abordagem, aprenderemos a definir o tamanho do gráfico na pasta de trabalho do Excel incorporada para que corresponda ao tamanho do quadro do objeto OLE no slide do PowerPoint. Essa abordagem é útil quando o tamanho do gráfico é conhecido antecipadamente e nunca mudará.

**Cenário 1** 

Suponha que tenhamos definido um modelo e queremos criar apresentações baseadas nele. Imagine que exista uma forma no índice 2 do modelo onde pretendemos colocar um quadro OLE contendo uma pasta de trabalho do Excel incorporada. Nesse cenário, o tamanho do quadro OLE é predefinido — corresponde ao tamanho da forma no índice 2 do modelo. Tudo o que precisamos fazer é definir o tamanho do gráfico na pasta de trabalho igual ao tamanho dessa forma. O trecho de código a seguir cumpre esse propósito:

```cpp
// Defina o tamanho do gráfico sem uma janela. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Defina a largura do gráfico em pixels (multiplique por 96, pois o Excel usa 96 pixels por polegada).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Defina a altura do gráfico em pixels.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Defina o tamanho de impressão do gráfico.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Salve a pasta de trabalho em um fluxo de memória.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crie um quadro de objeto OLE com os dados do Excel incorporados.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Cenário 2** 

Suponha que queiramos criar uma apresentação do zero e incluir um quadro OLE de qualquer tamanho com uma pasta de trabalho do Excel incorporada. No trecho de código a seguir, criamos um quadro OLE com altura de 4 polegadas e largura de 9,5 polegadas no slide em x = 0,5 polegada e y = 1 polegada. Também definimos o tamanho do gráfico correspondente para as mesmas dimensões: altura de 4 polegadas e largura de 9,5 polegadas.

```cpp
// Nossa altura desejada.
int32_t desiredHeight = 288; // 4 polegadas (4 * 576)

// Nossa largura desejada.
int32_t desiredWidth = 684; // 9.5 polegadas(9.5 * 576)

// Defina o tamanho do gráfico sem uma janela. 
chart->SetSizeWithWindow(false);

// Defina a largura do gráfico em pixels.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Defina a altura do gráfico em pixels.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Salve a pasta de trabalho em um fluxo de memória.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Crie um quadro de objeto OLE com os dados do Excel incorporados.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Conclusão**

Existem duas abordagens para corrigir o problema de redimensionamento do gráfico. A escolha da abordagem depende dos requisitos e do caso de uso. Ambas as abordagens funcionam da mesma forma, seja a apresentação criada a partir de um modelo ou do zero. Além disso, não há limite para o tamanho do quadro do objeto OLE nessa solução.

## **FAQ**

**Por que o gráfico do Excel incorporado muda de tamanho após ser ativado no PowerPoint?**

Isso ocorre porque o Excel tenta restaurar o tamanho original da janela na primeira ativação, enquanto o quadro do objeto OLE no PowerPoint tem suas próprias dimensões. PowerPoint e Excel negociam o tamanho para manter a proporção, o que pode causar o redimensionamento.

**É possível evitar esse problema de redimensionamento completamente?**

Sim. Ao fazer coincidir o tamanho da janela da pasta de trabalho do Excel ou o tamanho do gráfico com o tamanho do quadro do objeto OLE antes da incorporação, você pode manter os tamanhos dos gráficos consistentes.

**Qual abordagem devo escolher, definir o tamanho da janela da pasta de trabalho ou definir o tamanho do gráfico?**

Use **Abordagem 1 (tamanho da janela)** se desejar manter a proporção da pasta de trabalho e possivelmente permitir redimensionamento posterior.  
Use **Abordagem 2 (tamanho do gráfico)** se as dimensões do gráfico forem fixas e não mudarem após a incorporação.

**Esses métodos funcionam tanto com apresentações baseadas em modelo quanto com apresentações novas?**

Sim. Ambas as abordagens funcionam da mesma forma para apresentações criadas a partir de modelos e do zero.

**Existe um limite para o tamanho do quadro do objeto OLE?**

Não. Você pode definir o quadro OLE em qualquer tamanho, desde que ele escale adequadamente ao tamanho da pasta de trabalho ou do gráfico.

**Posso usar esses métodos com gráficos criados em outros programas de planilha?**

Os exemplos foram projetados para gráficos do Excel criados com Aspose.Cells, mas os princípios se aplicam a outros programas de planilha compatíveis com OLE, desde que suportem opções de dimensionamento semelhantes.

## **Seções Relacionadas**

- [Criar Gráficos do Excel e Incorporá‑los como Objetos OLE em Apresentações](/slides/pt/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)