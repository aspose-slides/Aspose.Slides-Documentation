---
title: Gerenciar Propriedades da Apresentação no .NET
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/net/presentation-properties/
keywords:
- Propriedades do PowerPoint
- propriedades de apresentação
- propriedades do documento
- propriedades integradas
- propriedades personalizadas
- propriedades avançadas
- gerenciar propriedades
- modificar propriedades
- metadados do documento
- editar metadados
- idioma de revisão
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Domine as propriedades de apresentações no Aspose.Slides for .NET e otimize a pesquisa, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides for .NET suporta dois tipos de propriedades de documento: **Integradas** e **Personalizadas**. Ambos os tipos de propriedade podem ser facilmente acessados e gerenciados usando a API Aspose.Slides for .NET.

Aspose.Slides permite que você trabalhe com as propriedades de documento de apresentação através da interface [IDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/). Uma instância dessa interface é retornada pela propriedade [Presentation.DocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/documentproperties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="primary" %}} 
Por favor, observe que os campos **Application** e **Producer** não podem ser modificados, pois esses campos sempre exibirão "Aspose Ltd." e "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar propriedades a arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas juntamente com os arquivos. Existem dois tipos de propriedades de documento:

- Propriedades definidas pelo sistema (integradas)
- Propriedades definidas pelo usuário (personalizadas)

As propriedades **integradas** contêm informações gerais sobre o documento, como o título do documento, o nome do autor, estatísticas do documento e mais.

As propriedades **personalizadas** são definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são especificados pelo usuário.

Usando Aspose.Slides for .NET, os desenvolvedores podem acessar e modificar tanto propriedades integradas quanto personalizadas.

O Microsoft PowerPoint permite que os usuários gerenciem as propriedades de documento clicando no ícone do Office e, em seguida, selecionando **Arquivo → Informações → Propriedades**. Após escolher **Propriedades avançadas**, uma caixa de diálogo aparece onde você pode gerenciar todas as propriedades de documento do arquivo de apresentação.

Na caixa de diálogo **Propriedades**, há várias abas, como **Geral**, **Resumo**, **Estatísticas**, **Conteúdo** e **Personalizado**. Cada aba fornece opções para configurar tipos específicos de informação relacionados ao arquivo PowerPoint. A aba **Personalizado** é usada para gerenciar propriedades definidas pelo usuário.

## **Acessar Propriedades Integradas**

Essas propriedades, expostas pela interface [IDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/), incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **SharedDoc** (indica se o documento está compartilhado entre diferentes produtores), **PresentationFormat**, **Subject**, **Title**, entre outras.

```cs
// Instanciar a classe Presentation que representa um arquivo de apresentação.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Obter uma referência ao objeto do tipo IDocumentProperties associado à apresentação.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Exibir as propriedades integradas.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Modificar Propriedades Integradas**

Modificar as propriedades integradas de arquivos de apresentação é tão fácil quanto acessá‑las. Você pode simplesmente atribuir um valor string a qualquer propriedade desejada, e o valor da propriedade será atualizado. No exemplo abaixo, demonstramos como modificar as propriedades de documento integradas de um arquivo de apresentação.

```cs
// Instanciar a classe Presentation que representa um arquivo de apresentação.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Obter uma referência ao objeto do tipo IDocumentProperties associado à apresentação.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Definir as propriedades integradas.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Salvar a apresentação em um arquivo.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Adicionar Propriedades Personalizadas à Apresentação**

As propriedades personalizadas de apresentação permitem que os desenvolvedores armazenem metadados adicionais ou informações específicas dentro de um arquivo de apresentação. Aspose.Slides facilita a criação e o gerenciamento dessas propriedades personalizadas programaticamente. Os exemplos a seguir demonstram como adicionar propriedades personalizadas às suas apresentações.

```cs
// Instanciar a classe Presentation.
using Presentation presentation = new Presentation();

// Obter uma referência ao objeto do tipo IDocumentProperties associado à apresentação.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Adicionar propriedades personalizadas.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Salvar a apresentação em um arquivo.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Acessar e Modificar Propriedades Personalizadas**

Aspose.Slides também permite que os desenvolvedores acessem propriedades personalizadas existentes e modifiquem seus valores facilmente. Essa funcionalidade ajuda a manter metadados precisos e suporta atualizações dinâmicas com base na entrada do usuário ou na lógica de negócios. Os exemplos abaixo ilustram como recuperar e atualizar valores de propriedades personalizadas dentro de uma apresentação.

```cs
// Instanciar a classe Presentation que representa um arquivo PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Exibir o nome e o valor da propriedade personalizada.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modificar o valor da propriedade personalizada.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Salvar a apresentação em um arquivo.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento usando a API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## ***Perguntas Frequentes**

**Como posso remover uma propriedade integrada de uma apresentação?**

As propriedades integradas são parte integrante da apresentação e não podem ser removidas completamente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade previamente, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar completamente a apresentação?**

Sim, você pode acessar as propriedades da apresentação sem carregá‑la completamente usando o método `GetPresentationInfo` da classe [PresentationFactory](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/). Em seguida, utilize o método `ReadDocumentProperties` fornecido pela interface [IPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/) para ler as propriedades de forma eficiente, economizando memória e melhorando o desempenho.