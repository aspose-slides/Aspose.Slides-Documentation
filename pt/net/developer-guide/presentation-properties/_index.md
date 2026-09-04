---
title: Gerenciar propriedades da apresentação em .NET
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/net/presentation-properties/
keywords:
- Propriedades do PowerPoint
- Propriedades da apresentação
- Propriedades do documento
- Propriedades integradas
- Propriedades personalizadas
- Propriedades avançadas
- Gerenciar propriedades
- Modificar propriedades
- Metadados do documento
- Editar metadados
- Idioma de revisão
- Idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Domine as propriedades da apresentação no Aspose.Slides para .NET e simplifique a pesquisa, a marca e o fluxo de trabalho nos seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides for .NET suporta dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser facilmente acessados e gerenciados usando a API do Aspose.Slides for .NET.

Aspose.Slides permite que você trabalhe com as propriedades de documento de apresentações através da interface [IDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/). Uma instância dessa interface é retornada por [IPresentation.DocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/documentproperties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Note" %}}
Observe que os campos **Application** e **Producer** não podem ser modificados, pois esses campos sempre exibirão "Aspose Ltd." e "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar propriedades a arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os arquivos. Existem dois tipos de propriedades de documento:

- Propriedades definidas pelo sistema (built-in)
- Propriedades definidas pelo usuário (custom)

**Built-in** propriedades contêm informações gerais sobre o documento, como o título do documento, nome do autor, estatísticas do documento e mais.

**Custom** propriedades são definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são especificados pelo usuário.

Usando Aspose.Slides for .NET, os desenvolvedores podem acessar e modificar tanto propriedades built-in quanto custom.

O Microsoft PowerPoint permite que os usuários gerenciem as propriedades de documento clicando no ícone Office e, em seguida, selecionando **File → Info → Properties**. Após escolher **Advanced Properties**, aparece uma caixa de diálogo onde você pode gerenciar todas as propriedades de documento do arquivo de apresentação.

Na caixa de diálogo **Properties**, há várias abas, como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Cada aba fornece opções para configurar tipos específicos de informações relacionadas ao arquivo PowerPoint. A aba **Custom** é usada para gerenciar propriedades definidas pelo usuário.

## **Ler Propriedades Públicas de Uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada com [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) definido como `false`, suas propriedades de documento permanecem públicas. Uma aplicação pode então definir [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) como `true` e ler os metadados públicos sem fornecer a senha de abertura.

`OnlyLoadDocumentProperties` controla o que o Aspose.Slides carrega; ele não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo a seguir verifica o modo de carregamento através de [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) e então lê as propriedades built-in através de [IPresentation.DocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Neste modo, o conteúdo dos slides não é carregado. Slides, masters, layouts, shapes, media e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar `IsOnlyDocumentPropertiesLoaded` antes de executar uma operação que exija o modelo de objeto da apresentação completo.

{{% alert color="warning" title="Security" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores customizados. Criptografe propriedades sensíveis juntamente com a apresentação. Mantenha‑as públicas somente quando sistemas de indexação, classificação, busca ou gerenciamento de documentos tiverem um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de Uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada com `OnlyLoadDocumentProperties` destina‑se a ler metadados públicos. O Aspose.Slides não pode salvar propriedades alteradas desse objeto somente de metadados, pois as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo a seguir abre a apresentação com [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/), atualiza propriedades built-in públicas e salva o resultado. Em seguida, usa [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/isencrypted/) para verificar se a criptografia foi preservada e reabre os metadados públicos sem senha para verificar os novos valores:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Se uma aplicação não tem permissão para descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente leitura.

## **Acessar Propriedades Built-in**

Essas propriedades, conforme expostas pela interface [IDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/idocumentproperties/), incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **SharedDoc** (indica se o documento é compartilhado entre diferentes produtores), **PresentationFormat**, **Subject**, **Title**, entre outras.

```cs
using Aspose.Slides;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

## **Modificar Propriedades Built-in**

Modificar as propriedades built-in de arquivos de apresentação é tão simples quanto acessá‑las. Você pode simplesmente atribuir um valor string a qualquer propriedade desejada, e o valor da propriedade será atualizado. No exemplo abaixo, demonstramos como modificar as propriedades built-in de documento de um arquivo de apresentação.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Propriedades personalizadas de apresentação permitem que os desenvolvedores armazenem metadados adicionais ou informações específicas dentro de um arquivo de apresentação. O Aspose.Slides facilita a criação e o gerenciamento dessas propriedades customizadas programaticamente. Os exemplos a seguir demonstram como adicionar propriedades personalizadas às suas apresentações.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

O Aspose.Slides também permite que os desenvolvedores acessem propriedades customizadas existentes e modifiquem seus valores facilmente. Essa funcionalidade ajuda a manter metadados precisos e suporta atualizações dinâmicas com base em entrada do usuário ou lógica de negócios. Os exemplos abaixo ilustram como recuperar e atualizar valores de propriedades customizadas dentro de uma apresentação.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar a classe Presentation que representa um arquivo PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Obter uma referência ao objeto do tipo IDocumentProperties associado à apresentação.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Acessar e modificar as propriedades personalizadas.
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

Experimente o aplicativo online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento usando a API do Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **FAQ**

**Como posso remover uma propriedade built-in de uma apresentação?**

Propriedades built-in são parte integrante da apresentação e não podem ser removidas completamente. Entretanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade customizada que já existe?**

Se você adicionar uma propriedade customizada que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade previamente, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar a apresentação completamente?**

Sim. Use [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/presentationfactory/getpresentationinfo/) e depois [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentationinfo/readdocumentproperties/) para ler os metadados do documento armazenados sem criar uma instância [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Veja [Build a Lightweight Presentation Inventory](/slides/pt/net/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A apresentação deve ter sido criptografada com `EncryptDocumentProperties` definido como `false` e deve ser carregada com `OnlyLoadDocumentProperties` definido como `true`.

**Posso atualizar um arquivo PPTX criptografado no modo somente‑propriedades‑de‑documento?**

Não. Dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto, atualizar um arquivo PPTX criptografado requer o carregamento completo da apresentação com a senha de abertura correta.