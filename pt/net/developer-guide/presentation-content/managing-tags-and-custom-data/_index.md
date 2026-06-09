---
title: Gerenciar Tags e Dados Personalizados em Apresentações em .NET
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/net/managing-tags-and-custom-data/
keywords:
- propriedades de documento
- tag
- dados personalizados
- adicionar tag
- pares de valores
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como adicionar, ler, atualizar e remover tags e dados personalizados no Aspose.Slides para .NET, com exemplos para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Ele descreve brevemente como os dados são armazenados em arquivos PPTX, observa que dados específicos da apresentação podem existir como tags e partes XML personalizadas, e descreve as tags como pares de strings chave‑valor.

Ele também mostra como ler valores de tags e como adicionar tags a uma apresentação, a um slide individual ou a uma forma. Além disso, o artigo aborda tarefas comuns de gerenciamento de tags, como limpar todas as tags, remover uma tag pelo nome e recuperar a lista de nomes de tags.

## **Armazenamento de Dados em Arquivos de Apresentação**

Arquivos PPTX — itens com a extensão .pptx — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O formato Office Open XML define a estrutura dos dados contidos nas apresentações. 

Com um *slide* sendo um dos elementos nas apresentações, uma *parte de slide* contém o conteúdo de um único slide. Uma parte de slide pode ter relacionamentos explícitos com várias partes — como User Defined Tags — definidas pela ISO/IEC 29500. 

Dados personalizados (específicos de uma apresentação) ou de usuário podem existir como tags ([ITagCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/itagcollection)) e CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 
Tags são essencialmente pares de string‑chave. 
{{% /alert %}} 

## **Obter Valores de Tags**

Nos slides, uma tag corresponde à propriedade IDocumentProperties.Keywords. Este exemplo de código mostra como obter o valor de uma tag usando o Aspose.Slides para .NET para [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Adicionar Tags a Apresentações**

O Aspose.Slides permite que você adicione tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada - `MyTag` 
- o valor da propriedade personalizada - `My Tag Value`

Se precisar classificar algumas apresentações com base em uma regra ou propriedade específica, você pode se beneficiar ao adicionar tags a essas apresentações. Por exemplo, se desejar categorizar ou agrupar todas as apresentações de países da América do Norte, pode criar uma tag América do Norte e então atribuir os países relevantes (EUA, México e Canadá) como valores. 

Este exemplo de código mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) usando o Aspose.Slides para .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Tags também podem ser definidas para [Slide](https://reference.aspose.com/slides/pt/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Ou qualquer [Shape](https://reference.aspose.com/slides/pt/net/aspose.slides/shape) individual:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Limitações**

Tags adicionadas via a coleção `CustomData.Tags` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado do PDF com tags.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, `shape.AlternativeText = "MyId"`). Após exportar para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou shape em uma única operação?**

Sim. A [tag collection](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/) suporta a operação [clear](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/clear/) que exclui todos os pares chave‑valor de uma só vez.

**Como excluir uma única tag pelo seu nome sem iterar sobre toda a coleção?**

Use a operação [Remove(name)](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/remove/) em [TagCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/) para excluir a tag pelo seu identificador.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [GetNamesOfTags](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/pt/net/aspose.slides/tagcollection/); ela retorna um array com todos os nomes de tags.