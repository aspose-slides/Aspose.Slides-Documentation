---
title: Automatizar a Personalização de Apresentações com Mala Direta
linktitle: Mala Direta
type: docs
weight: 233
url: /pt/net/mail-merge/
keywords:
- Mala Direta
- personalização de apresentação
- modelo de apresentação
- marcadores de texto
- fonte de dados
- CSV
- Excel
- XLSX
- JSON
- XML
- mesclar dados
- gerar apresentações
- .NET
- C#
- Aspose.Slides
description: "Aprenda como usar a Mala Direta no Aspose.Slides para .NET para preencher modelos de apresentação com dados e gerar apresentações PowerPoint personalizadas a partir de fontes CSV, Excel, JSON e XML."
---
# Mala Direta em Apresentações PowerPoint

Aspose.Slides for .NET permite gerar apresentações PowerPoint automaticamente usando um modelo e uma fonte de dados. Mala Direta preenche os marcadores de posição do modelo com dados e cria ou uma única apresentação contendo slides de modelo repetidos para cada conjunto de dados, ou uma apresentação separada para cada conjunto de dados.

Essa funcionalidade é útil para gerar catálogos de produtos, apresentações personalizadas, relatórios, certificados, propostas, listas de preços e outros documentos em que a estrutura da apresentação permanece a mesma enquanto o conteúdo varia.

![Mala Direta: antes e depois](mail-merge-before-after.png)


## Como a Mala Direta Funciona

Mala Direta usa uma apresentação PowerPoint como modelo e substitui marcadores de posição por valores de uma fonte de dados.

![Fluxo de trabalho da Mala Direta](mail-merge-workflow.png)

Um marcador de posição é um nome de campo envolto em chaves duplas, como `{{title}}` ou `{{price}}`. Marcadores de posição podem ser inseridos em texto em formas, células de tabela, formas agrupadas e notas do apresentador.

Por exemplo, um slide de modelo pode conter o seguinte texto:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

Quando a fonte de dados contém os seguintes valores:

| Campo | Valor |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

Mala Direta substitui os marcadores pelos valores correspondentes, produzindo um slide com as informações reais do produto.

Os nomes de campo não diferenciam maiúsculas de minúsculas, portanto `{{title}}` e `{{Title}}` referem‑se ao mesmo campo.

As regras a seguir se aplicam ao substituir marcadores:

- Marcadores são substituídos nos slides, incluindo formas agrupadas e células de tabela, e nas notas do apresentador.
- Marcadores em slides mestre e slides de layout não são substituídos.
- Um marcador cujo campo não esteja presente no conjunto de dados permanece inalterado.
- Um valor de campo vazio substitui seu marcador por uma string vazia.
- O texto inserido herda a formatação do primeiro caractere do marcador.
- Valores não devem conter texto de marcador, pois o texto inserido pode ser processado novamente e substituído por outro campo.

A apresentação modelo original não é modificada durante a operação de mesclagem e deve conter ao menos um slide.

## Fontes de Dados Compatíveis

Mala Direta oferece duas maneiras de fornecer dados:

- Criar uma fonte de dados programaticamente usando `IMailMergeDataSource`.
- Ler dados de um arquivo ou stream CSV, XLSX, JSON ou XML.

O formato dos dados é detectado pelo seu conteúdo, não pela extensão do arquivo. Streams que não suportam busca (seeking) também são compatíveis.

A fonte de dados deve conter ao menos um conjunto de dados. Cada conjunto representa uma cópia do modelo a ser preenchida com seus valores.

Se o conteúdo dos dados não puder ser reconhecido como um formato suportado, `NotSupportedException` é lançada. Se o conteúdo for reconhecido mas não atender aos requisitos de formato, `InvalidDataException` é lançada. A mensagem da exceção contém a localização do erro nos dados.

### JSON

A fonte de dados JSON deve ter um objeto raiz contendo um array `sets`. Cada elemento do array representa um conjunto de dados e deve conter um array `fields`. Cada campo deve ter as strings `name` e `value`.

A propriedade opcional `version` deve ser `"1.0"` e a propriedade opcional `type` de um campo deve ser `"text"`. Nomes de propriedades diferenciam maiúsculas de minúsculas. Propriedades desconhecidas são ignoradas.

Dados JSON são lidos como UTF-8, ou como UTF-16 quando os dados iniciam com marca de ordem de bytes (BOM).

O exemplo a seguir contém dois conjuntos de dados:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### XML

A fonte de dados XML deve ter um elemento raiz `template` contendo o elemento `sets`. Cada elemento `set` contém elementos `field`, e cada campo deve conter os elementos `name` e `value`.

Um elemento `value` vazio é tratado como string vazia. Nomes de elementos diferenciam maiúsculas de minúsculas. Elementos e comentários desconhecidos são ignorados. A codificação é determinada pela declaração XML. Definições de tipo de documento (DTD) não são permitidas.

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### CSV

Dados CSV utilizam ponto e vírgula como separador de valores.

A primeira linha contém nomes de campo e termina no primeiro nome de campo vazio. Cada linha subsequente representa um conjunto de dados. Os dados terminam na primeira linha vazia.

As regras a seguir se aplicam:

- Valores ausentes ao final de uma linha são tratados como strings vazias.
- Valores além dos nomes de campo definidos são ignorados.
- Um valor que contém ponto e vírgula, aspas ou quebra de linha deve ser colocado entre aspas.
- Aspas dentro de um valor citado devem ser duplicadas.
- Dados são lidos como UTF-8, ou como UTF-16 quando iniciam com marca de ordem de bytes (BOM).

Exemplo:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

Dados XLSX são lidos da primeira planilha.

A planilha segue as mesmas regras do CSV:

- A primeira linha contém nomes de campo e termina na primeira célula vazia.
- Cada linha subsequente representa um conjunto de dados.
- Os dados terminam na primeira linha vazia.
- Células vazias são tratadas como strings vazias.
- Valores numéricos são convertidos para texto usando a cultura invariável.

## Criando uma Única Apresentação

O método `MergeToSinglePresentation` cria uma apresentação contendo uma cópia dos slides do modelo para cada conjunto de dados. Cada cópia é preenchida com os dados correspondentes.

A ordem dos conjuntos de dados determina a ordem dos grupos de slides na apresentação resultante.

### Mesclando Dados de um Arquivo

O exemplo a seguir carrega um modelo e um arquivo de dados JSON, cria uma única apresentação contendo os slides de todos os conjuntos de dados e salva o resultado.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Os dados também podem ser lidos de um stream. O stream é lido a partir da posição atual e não é fechado pela operação de Mala Direta.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### Criando uma Fonte de Dados em Código

Você pode montar uma fonte de dados programaticamente usando `MailMergeDataSource` e `MailMergeDataSet`. Adicione um conjunto de dados para cada registro e defina seus campos usando o método `AddText`.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

Neste exemplo, os slides do modelo são repetidos duas vezes: uma para o laptop e outra para o tablet. Os marcadores são preenchidos usando os valores definidos em cada conjunto de dados.

## Criando Múltiplas Apresentações

Se precisar de uma apresentação separada para cada conjunto de dados, use o método `MergeToMultiplePresentations`.

Esse método processa os conjuntos de dados um por um, cria uma apresentação a partir do modelo, preenche-a com os dados atuais e passa a apresentação resultante a um manipulador.

O manipulador é invocado uma vez para cada conjunto de dados, na ordem original dos dados.

### Salvando Cada Apresentação

O exemplo a seguir lê dados de um arquivo CSV e salva cada apresentação gerada como um arquivo separado.

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

A propriedade `args.Index` fornece o índice baseado em zero do conjunto de dados atual. No exemplo, ela é usada para gerar nomes de arquivos sequenciais a partir de `product_1.pptx`.

Os dados também podem ser lidos de um stream:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### Usando Valores do Conjunto de Dados para Nomear Arquivos

O manipulador recebe tanto a apresentação gerada quanto informações sobre o conjunto de dados usado para criá‑la. Você pode usar os valores do conjunto de dados para construir nomes de arquivos significativos.

Por exemplo, o código a seguir salva cada apresentação usando o título do produto:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

A propriedade `DataSet` devolve o conjunto de dados usado para preencher a apresentação atual. O método `GetText` recupera o valor de um campo especificado, ou `null` se o campo não existir.

Isso permite usar valores dos dados para nomear arquivos, organizar a saída ou aplicar processamento adicional no manipulador.

## Manipulando Apresentações Geradas

`MergeToMultiplePresentations` usa o delegate `MailMergedPresentationHandler` para processar cada apresentação gerada.

O manipulador recebe dois argumentos:

- `presentation` — a apresentação criada a partir do modelo e preenchida com o conjunto de dados atual.
- `args` — informações sobre a apresentação gerada, incluindo o índice do conjunto de dados e o próprio conjunto de dados.

A apresentação gerada é de propriedade da operação de Mala Direta e é descartada imediatamente após o retorno do manipulador. Portanto, você deve salvá‑la ou copiar quaisquer dados necessários dentro do manipulador. Não mantenha referência a ela após o retorno do manipulador nem a descarte manualmente.

O manipulador é executado na thread chamadora, uma apresentação por vez, na ordem dos conjuntos de dados. Apenas uma apresentação gerada é mantida em memória de cada vez, tornando essa abordagem adequada para processar fontes de dados grandes sem manter todas as apresentações em memória simultaneamente.

Se o manipulador lançar uma exceção, a operação de Mala Direta pára e a exceção é propagada ao chamador sem alterações. As apresentações já processadas permanecem inalteradas, e os conjuntos de dados restantes não são processados.

O exemplo a seguir salva apresentações geradas em um diretório dedicado:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## Trabalhando com Dados de Mala Direta

A classe `MailMergeDataSource` representa uma coleção ordenada de conjuntos de dados. Ela pode ser usada para criar dados em código, inspecionar a quantidade de conjuntos de dados e acessar conjuntos individuais por índice.

### Obtendo a Quantidade de Conjuntos de Dados

A propriedade `Count` devolve o número de conjuntos de dados na fonte.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### Acessando um Conjunto de Dados por Índice

A propriedade `Item(int)` fornece acesso a um conjunto de dados no índice baseado em zero especificado.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Este exemplo recupera o título do segundo conjunto de dados.

### Adicionando Campos de Texto

O método `AddText` adiciona um campo de texto nomeado a um conjunto de dados. O valor do campo substitui todos os marcadores correspondentes no modelo.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Um valor vazio remove o marcador correspondente do texto resultante. Se o campo não for adicionado ao conjunto de dados, o marcador permanece inalterado.

### Lendo Campos de Texto

O método `GetText` recupera o valor de um campo pelo nome. Nomes de campo não diferenciam maiúsculas de minúsculas.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Se o campo não existir ou o nome do campo especificado for `null`, `GetText` devolve `null`.

## Resumo

Mala Direta no Aspose.Slides for .NET oferece uma maneira conveniente de gerar apresentações orientadas a dados a partir de um modelo reutilizável.

Você pode usá‑la para:

- Preencher modelos de apresentação com valores de fontes de dados.
- Gerar uma única apresentação contendo slides de modelo repetidos para múltiplos conjuntos de dados.
- Criar uma apresentação separada para cada conjunto de dados.
- Ler dados de arquivos ou streams CSV, XLSX, JSON e XML.
- Construir fontes de dados diretamente em código.
- Processar e salvar apresentações geradas sequencialmente usando um manipulador.

Ao combinar modelos reutilizáveis com dados estruturados, você pode automatizar a criação de grande número de apresentações mantendo o design do modelo e a lógica de processamento de dados separados.

## Perguntas Frequentes

### Posso usar o mesmo marcador várias vezes em um modelo?

Sim. Cada ocorrência de um marcador com um nome de campo correspondente é substituída pelo valor do conjunto de dados atual.

### Os nomes de campo diferenciam maiúsculas de minúsculas?

Não. Nomes de marcadores e de campos de dados não diferenciam maiúsculas de minúsculas. Por exemplo, `{{title}}`, `{{Title}}` e `{{TITLE}}` referem‑se ao mesmo campo.

### O que acontece se um campo estiver ausente em um conjunto de dados?

Se o conjunto de dados não contiver um campo referenciado por um marcador, esse marcador permanece inalterado na apresentação gerada.

### O que acontece se um campo tiver um valor vazio?

Um valor de campo vazio substitui o marcador por uma string vazia. O texto do marcador é removido, não restando nenhum texto em seu lugar.

### Posso preservar a formatação de um marcador ao substituí‑lo?

O texto de substituição herda a formatação do primeiro caractere do marcador. Aplique a formatação desejada ao texto do marcador no modelo antes de executar a mesclagem.

### A Mala Direta substitui marcadores em slides mestres ou de layout?

Não. Mala Direta substitui marcadores no conteúdo suportado dos slides de apresentação, incluindo formas, formas agrupadas, células de tabela e notas do apresentador. Marcadores em slides mestre e de layout não são substituídos.

### O modelo de apresentação é modificado durante a mesclagem?

Não. O modelo original não é modificado pela operação de mesclagem. Você pode reutilizá‑lo para gerar apresentações a partir da mesma ou de diferentes fontes de dados.

### Posso gerar uma apresentação separada para cada conjunto de dados?

Sim. Use `MergeToMultiplePresentations` e salve cada apresentação gerada dentro do manipulador. O manipulador é chamado sequencialmente para cada conjunto de dados.

### Posso combinar todos os conjuntos de dados em uma única apresentação?

Sim. Use `MergeToSinglePresentation`. Ele cria uma apresentação de saída única contendo uma cópia dos slides do modelo para cada conjunto de dados, na ordem da fonte de dados.

### Posso usar uma fonte de dados sem salvá‑la em arquivo?

Sim. Você pode criar um `MailMergeDataSource` em código, adicionar conjuntos de dados e preencher campos usando `AddText`. Isso é útil quando seus dados já estão disponíveis na aplicação.

### A Mala Direta detecta o formato dos dados pela extensão do arquivo?

Não. O formato dos dados é detectado pelo conteúdo, portanto uma fonte de dados suportada não precisa usar uma extensão de arquivo específica.

### Posso ler dados de um stream que não suporte busca?

Sim. Mala Direta suporta streams não buscáveis.

### O que acontece se a fonte de dados estiver vazia ou não contiver conjuntos de dados?

A fonte de dados deve conter ao menos um conjunto de dados. Certifique‑se de que inclui ao menos um registro antes de iniciar a operação de mesclagem.

### O que acontece se a fonte de dados tiver formato inválido?

Se o conteúdo não for reconhecido como um dos formatos de dados suportados, `NotSupportedException` é lançada. Se for reconhecido mas malformado, `InvalidDataException` é lançada. A mensagem da exceção inclui informações sobre a localização do erro.

### Posso usar a apresentação gerada após o retorno do manipulador?

A apresentação passada ao manipulador de `MergeToMultiplePresentations` pertence ao Mala Direta e é descartada após o retorno do manipulador. Salve‑a ou copie o conteúdo necessário dentro do manipulador e não retenha nem descarte manualmente essa apresentação.

### O manipulador é chamado em paralelo?

Não. Apresentações geradas são processadas sequencialmente, na thread do chamador. Apenas uma apresentação gerada é mantida em memória por vez por essa operação.

### O que acontece se ocorrer uma exceção dentro do manipulador?

A operação de mesclagem para e a exceção é propagada ao chamador sem alterações. Apresentações já processadas não são afetadas e os conjuntos de dados subsequentes não são processados.

### Posso usar valores de campos para gerar nomes de arquivos de saída?

Sim. O manipulador fornece o conjunto de dados atual através de seus argumentos. Use `GetText` para recuperar campos e montar um nome de arquivo para cada apresentação gerada. Certifique‑se de que os valores sejam válidos como nomes de arquivo no seu ambiente alvo.