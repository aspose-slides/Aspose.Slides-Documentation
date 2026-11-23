---
title: Automatizar a Personalização de Apresentações com Mesclagem de Dados
linktitle: Mesclagem de Dados
type: docs
weight: 233
url: /pt/net/mail-merge/
keywords:
- Mesclagem de Dados
- personalização de apresentações
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
description: "Aprenda a usar a Mesclagem de Dados no Aspose.Slides para .NET para preencher modelos de apresentação com dados e gerar apresentações PowerPoint personalizadas a partir de fontes CSV, Excel, JSON e XML."
---
## **Mesclagem de Dados em Apresentações PowerPoint**

Aspose.Slides for .NET permite gerar automaticamente apresentações PowerPoint usando um modelo e uma fonte de dados. A Mesclagem de Dados preenche os marcadores de posição do modelo com os dados e cria ou uma única apresentação contendo slides do modelo repetidos para cada conjunto de dados ou uma apresentação separada para cada conjunto de dados.

Essa funcionalidade é útil para gerar catálogos de produtos, apresentações personalizadas, relatórios, certificados, propostas, listas de preços e outros documentos em que a estrutura da apresentação permanece a mesma enquanto o conteúdo varia.

![Mesclagem de Dados: antes e depois](mail-merge-before-after.png)


## **Como Funciona a Mesclagem de Dados**

A Mesclagem de Dados usa uma apresentação PowerPoint como modelo e substitui os marcadores de posição por valores de uma fonte de dados.

![Fluxo de trabalho da Mesclagem de Dados](mail-merge-workflow.png)

Um marcador de posição é um nome de campo envolto em chaves duplas, como `{{title}}` ou `{{price}}`. Marcadores de posição podem ser inseridos em texto de formas, células de tabela, formas agrupadas e notas do apresentador.

Por exemplo, um slide modelo pode conter o seguinte texto:

- `Produto: {{title}}`
- `Preço: {{price}}`
- `Descrição: {{description}}`

Quando a fonte de dados contém os seguintes valores:

| Campo | Valor |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | Tela de 14 polegadas, 16 GB RAM |

A Mesclagem de Dados substitui os marcadores de posição pelos valores correspondentes, produzindo um slide com as informações reais do produto.

Os nomes de campo não diferenciam maiúsculas de minúsculas, portanto `{{title}}` e `{{Title}}` referem‑se ao mesmo campo.

As regras a seguir se aplicam ao substituir marcadores de posição:

- Os marcadores de posição são substituídos nos slides, incluindo formas agrupadas e células de tabela, e nas notas do apresentador.
- Os marcadores de posição em slides mestre e em slides de layout não são substituídos.
- Um marcador de posição cujo campo não está presente no conjunto de dados permanece inalterado.
- Um valor de campo vazio substitui seu marcador de posição por uma string vazia.
- O texto inserido herda a formatação do primeiro caractere do marcador de posição.
- Os valores não devem conter texto de marcador de posição, pois o texto inserido pode ser processado novamente e substituído por outro campo.

A apresentação modelo original não é modificada durante a operação de mesclagem e deve conter ao menos um slide.

## **Fontes de Dados Compatíveis**

A Mesclagem de Dados suporta duas formas de fornecer dados:

- Criar uma fonte de dados programaticamente usando `IMailMergeDataSource`.
- Ler dados de um arquivo ou fluxo CSV, XLSX, JSON ou XML.

O formato dos dados é detectado pelo seu conteúdo, não pela extensão do arquivo. Fluxos que não suportam busca (seeking) também são suportados.

A fonte de dados deve conter ao menos um conjunto de dados. Cada conjunto de dados representa uma cópia do modelo a ser preenchida com seus valores.

Se o conteúdo dos dados não puder ser reconhecido como um formato suportado, `NotSupportedException` é lançada. Se o conteúdo for reconhecido, mas não atender aos requisitos de formato, `InvalidDataException` é lançada. A mensagem da exceção contém a localização do erro nos dados.

### **JSON**

A fonte de dados JSON deve ter um objeto raiz contendo um array `sets`. Cada elemento do array representa um conjunto de dados e deve conter um array `fields`. Cada campo deve ter as propriedades `name` e `value` como strings.

A propriedade opcional `version` deve ser `"1.0"` e a propriedade opcional `type` de um campo deve ser `"text"`. Nomes de propriedades diferenciam maiúsculas de minúsculas. Propriedades desconhecidas são ignoradas.

Dados JSON são lidos como UTF‑8, ou como UTF‑16 quando os dados começam com uma marca de ordem de bytes (BOM).

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

### **XML**

A fonte de dados XML deve ter um elemento raiz `template` contendo o elemento `sets`. Cada elemento `set` contém elementos `field`, e cada campo deve conter elementos `name` e `value`.

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

### **CSV**

Dados CSV utilizam ponto e vírgula como separadores de valor.

A primeira linha contém os nomes dos campos e termina no primeiro nome de campo vazio. Cada linha subsequente representa um conjunto de dados. Os dados terminam na primeira linha vazia.

As seguintes regras se aplicam:

- Valores ausentes no final de uma linha são tratados como strings vazias.
- Valores além dos nomes de campo definidos são ignorados.
- Um valor que contenha ponto e vírgula, aspas ou quebra de linha deve ser delimitado por aspas.
- Aspas dentro de um valor delimitado devem ser duplicadas.
- Dados são lidos como UTF‑8, ou como UTF‑16 quando começam com uma marca de ordem de bytes (BOM).

Exemplo:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

Dados XLSX são lidos da primeira planilha.

A planilha segue as mesmas regras do CSV:

- A primeira linha contém os nomes dos campos e termina na primeira célula vazia.
- Cada linha subsequente representa um conjunto de dados.
- Os dados terminam na primeira linha vazia.
- Células vazias são tratadas como strings vazias.
- Valores numéricos são convertidos para texto usando a cultura invariável.

## **Criando uma Apresentação Única**

O método `MergeToSinglePresentation` cria uma apresentação contendo uma cópia dos slides do modelo para cada conjunto de dados. Cada cópia é preenchida com os dados correspondentes.

A ordem dos conjuntos de dados determina a ordem dos grupos de slides na apresentação resultante.

### **Mesclando Dados a partir de um Arquivo**

O exemplo a seguir carrega um modelo e um arquivo de dados JSON, cria uma apresentação única contendo os slides para todos os conjuntos de dados e salva o resultado.

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

Os dados também podem ser lidos de um fluxo. O fluxo é lido a partir da sua posição atual e não é fechado pela operação de Mesclagem de Dados.

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

### **Criando uma Fonte de Dados em Código**

Você pode construir uma fonte de dados programaticamente usando `MailMergeDataSource` e `MailMergeDataSet`. Adicione um conjunto de dados para cada registro e defina seus campos usando o método `AddText`.

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

Neste exemplo, os slides do modelo são repetidos duas vezes: uma para o laptop e outra para o tablet. Os marcadores de posição são preenchidos usando os valores definidos em cada conjunto de dados.

## **Criando Múltiplas Apresentações**

Se precisar de uma apresentação separada para cada conjunto de dados, use o método `MergeToMultiplePresentations`.

Esse método processa os conjuntos de dados um a um, cria uma apresentação a partir do modelo, preenche-a com os dados atuais e passa a apresentação resultante para um manipulador.

O manipulador é invocado uma vez para cada conjunto de dados, na ordem original dos dados.

### **Salvando Cada Apresentação**

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

A propriedade `args.Index` fornece o índice baseado em zero do conjunto de dados atual. No exemplo, ele é usado para gerar nomes de arquivos sequenciais a partir de `product_1.pptx`.

Os dados também podem ser lidos de um fluxo:

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

### **Usando Valores do Conjunto de Dados para Nomear Arquivos**

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

A propriedade `DataSet` retorna o conjunto de dados usado para preencher a apresentação atual. O método `GetText` recupera o valor de um campo especificado, ou `null` se o campo não existir.

Isso permite usar valores dos dados para nomear arquivos, organizar a saída ou aplicar processamento adicional no manipulador.

## **Manipulando Apresentações Geradas**

`MergeToMultiplePresentations` usa o delegate `MailMergedPresentationHandler` para processar cada apresentação gerada.

O manipulador recebe dois argumentos:

- `presentation` — a apresentação criada a partir do modelo e preenchida com o conjunto de dados atual.
- `args` — informações sobre a apresentação gerada, incluindo o índice do conjunto de dados e o próprio conjunto de dados.

A apresentação gerada é de propriedade da operação de Mesclagem de Dados e é descartada imediatamente após o retorno do manipulador. Portanto, você deve salvá‑la ou copiar quaisquer dados necessários dentro do manipulador. Não retenha uma referência a ela após o retorno do manipulador nem a descarte manualmente.

O manipulador é executado na thread que faz a chamada, uma apresentação por vez, na ordem dos conjuntos de dados. Apenas uma apresentação gerada é mantida em memória de cada vez, tornando essa abordagem adequada para processar grandes fontes de dados sem manter todas as apresentações geradas na memória simultaneamente.

Se o manipulador lançar uma exceção, a operação de Mesclagem de Dados é interrompida e a exceção é propagada ao chamador sem alterações. As apresentações já processadas permanecem intactas, e os conjuntos de dados restantes não são processados.

O exemplo a seguir salva as apresentações geradas em um diretório dedicado:

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

## **Trabalhando com Dados de Mesclagem de Dados**

A classe `MailMergeDataSource` representa uma coleção ordenada de conjuntos de dados. Ela pode ser usada para criar dados em código, inspecionar o número de conjuntos de dados e acessar conjuntos individuais por índice.

### **Obtendo o Número de Conjuntos de Dados**

A propriedade `Count` retorna o número de conjuntos de dados na fonte.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **Acessando um Conjunto de Dados por Índice**

A propriedade `Item(int)` fornece acesso a um conjunto de dados no índice baseado em zero especificado.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

Este exemplo recupera o título do segundo conjunto de dados.

### **Adicionando Campos de Texto**

O método `AddText` adiciona um campo de texto nomeado a um conjunto de dados. O valor do campo substitui todos os marcadores de posição correspondentes no modelo.

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

Um valor vazio remove o marcador de posição correspondente do texto resultante. Se o campo não for adicionado ao conjunto de dados, o marcador de posição permanece inalterado.

### **Lendo Campos de Texto**

O método `GetText` recupera o valor de um campo pelo nome. Nomes de campo não diferenciam maiúsculas de minúsculas.

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

Se o campo não existir ou o nome do campo especificado for `null`, `GetText` retorna `null`.

## **Resumo**

A Mesclagem de Dados no Aspose.Slides for .NET fornece uma maneira prática de gerar apresentações orientadas a dados a partir de um modelo reutilizável.

Você pode usá‑la para:

- Preencher modelos de apresentação com valores de fontes de dados.
- Gerar uma única apresentação contendo slides de modelo repetidos para vários conjuntos de dados.
- Criar uma apresentação separada para cada conjunto de dados.
- Ler dados de arquivos ou fluxos CSV, XLSX, JSON e XML.
- Construir fontes de dados diretamente em código.
- Processar e salvar apresentações geradas sequencialmente usando um manipulador.

Ao combinar modelos reutilizáveis com dados estruturados, você pode automatizar a criação de um grande número de apresentações mantendo o design do modelo e a lógica de processamento de dados separados.

## **Perguntas Frequentes**

**Posso usar o mesmo marcador de posição várias vezes em um modelo?**  
Sim. Cada ocorrência de um marcador de posição com um nome de campo correspondente é substituída pelo valor correspondente do conjunto de dados atual.

**Os nomes dos campos diferenciam maiúsculas de minúsculas?**  
Não. Nomes de marcadores de posição e de campos de dados não diferenciam maiúsculas de minúsculas. Por exemplo, `{{title}}`, `{{Title}}` e `{{TITLE}}` referem‑se ao mesmo campo.

**O que acontece se um campo estiver ausente de um conjunto de dados?**  
Se o conjunto de dados não contiver um campo referenciado por um marcador de posição, esse marcador de posição permanecerá inalterado na apresentação gerada.

**O que acontece se um campo tiver um valor vazio?**  
Um valor de campo vazio substitui o marcador de posição por uma string vazia. O texto do marcador de posição é removido, não deixando texto no seu lugar.

**Posso preservar a formatação de um marcador de posição ao substituí‑lo?**  
O texto de substituição herda a formatação do primeiro caractere do marcador de posição. Aplique a formatação desejada ao texto do marcador de posição no modelo antes de executar a mesclagem.

**A Mesclagem de Dados substitui marcadores de posição em slides mestres ou de layout?**  
Não. A Mesclagem de Dados substitui marcadores de posição no conteúdo suportado dos slides de apresentação, incluindo formas, formas agrupadas, células de tabela e notas do apresentador. Marcadores de posição em slides mestres e de layout não são substituídos.

**O modelo de apresentação é modificado durante a mesclagem?**  
Não. O modelo original não é modificado pela operação de mesclagem. Você pode reutilizá‑lo para gerar apresentações a partir da mesma ou de diferentes fontes de dados.

**Posso gerar uma apresentação separada para cada conjunto de dados?**  
Sim. Use `MergeToMultiplePresentations` e salve cada apresentação gerada dentro do manipulador. O manipulador é chamado sequencialmente para cada conjunto de dados.

**Posso combinar todos os conjuntos de dados em uma única apresentação?**  
Sim. Use `MergeToSinglePresentation`. Ele cria uma única apresentação de saída contendo uma cópia dos slides do modelo para cada conjunto de dados, na ordem da fonte de dados.

**Posso usar uma fonte de dados sem salvá‑la em um arquivo?**  
Sim. Você pode criar um `MailMergeDataSource` em código, adicionar conjuntos de dados e preencher campos usando `AddText`. Isso é útil quando os dados já estão disponíveis na sua aplicação.

**A Mesclagem de Dados detecta o formato dos dados a partir da extensão do arquivo?**  
Não. O formato dos dados é detectado a partir do conteúdo, portanto uma fonte de dados compatível não precisa ter uma extensão de arquivo específica.

**Posso ler dados de um fluxo que não suporta busca (seeking)?**  
Sim. A Mesclagem de Dados suporta fluxos não buscáveis.

**O que acontece se a fonte de dados estiver vazia ou não contiver conjuntos de dados?**  
A fonte de dados deve conter ao menos um conjunto de dados. Certifique‑se de que ela inclua pelo menos um registro antes de iniciar a operação de mesclagem.

**O que acontece se a fonte de dados tiver um formato inválido?**  
Se o conteúdo não for reconhecido como um dos formatos de dados suportados, `NotSupportedException` será lançada. Se for reconhecido, mas estiver mal formado, `InvalidDataException` será lançada. A mensagem da exceção inclui informações sobre a localização do erro.

**Posso usar a apresentação gerada após o retorno do manipulador?**  
A apresentação passada ao manipulador de `MergeToMultiplePresentations` é de propriedade da Mesclagem de Dados e é descartada após o retorno do manipulador. Salve‑a ou copie o conteúdo necessário dentro do manipulador e não a retenha ou descarte manualmente.

**O manipulador é chamado em paralelo?**  
Não. As apresentações geradas são processadas sequencialmente, na thread do chamador. Apenas uma apresentação gerada é mantida em memória por vez por esta operação.

**O que acontece se uma exceção ocorrer dentro do manipulador?**  
A operação de mesclagem é interrompida e a exceção é propagada ao chamador sem alterações. As apresentações já processadas não são afetadas, e os conjuntos de dados restantes não são processados.

**Posso usar valores de campo para gerar nomes de arquivo de saída?**  
Sim. O manipulador fornece o conjunto de dados atual através de seus argumentos. Use `GetText` para obter campos e montar um nome de arquivo para cada apresentação gerada. Certifique‑se de que os valores sejam válidos como nomes de arquivo no ambiente de destino.