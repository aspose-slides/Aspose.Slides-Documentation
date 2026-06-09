---
title: Gerenciar tags e dados personalizados em apresentações usando C++
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/cpp/managing-tags-and-custom-data/
keywords:
- propriedades do documento
- etiqueta
- dados personalizados
- adicionar etiqueta
- valores de pares
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a adicionar, ler, atualizar e remover tags e dados personalizados no Aspose.Slides para C++, com exemplos para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Ele descreve brevemente como os dados são armazenados em arquivos PPTX, observa que dados específicos da apresentação podem existir como tags e partes XML personalizadas, e descreve as tags como pares de strings chave‑valor.

Ele também mostra como ler valores de tags e como adicionar tags a uma apresentação, a um slide individual ou a uma forma. Além disso, o artigo cobre tarefas comuns de gerenciamento de tags, como limpar todas as tags, remover uma tag por nome e recuperar a lista de nomes de tags.

## **Armazenamento de Dados em Arquivos de Apresentação**

Os arquivos PPTX — itens com a extensão .pptx — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O formato Office Open XML define a estrutura dos dados contidos em apresentações.

Com um *slide* sendo um dos elementos nas apresentações, uma *parte de slide* contém o conteúdo de um único slide. Uma parte de slide pode ter relações explícitas com muitas partes — como User Defined Tags — definidas pela ISO/IEC 29500.

Dados personalizados (específicos de uma apresentação) ou do usuário podem existir como tags ([ITagCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itagcollection/)) e CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
Tags são essencialmente pares de valores de chave‑string. 
{{% /alert %}} 

## **Obter Valores das Tags**

Nos slides, uma tag corresponde à propriedade IDocumentProperties.Keywords. Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides para C++ para [Apresentação](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Adicionar Tags a Apresentações**

O Aspose.Slides permite que você adicione tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada - `MyTag`
- o valor da propriedade personalizada - `My Tag Value`

Se precisar classificar algumas apresentações com base em uma regra ou propriedade específica, poderá se beneficiar ao adicionar tags a essas apresentações. Por exemplo, se quiser categorizar ou agrupar todas as apresentações de países da América do Norte, pode criar uma tag América do Norte e então atribuir os países relevantes (EUA, México e Canadá) como valores.

Este código de exemplo mostra como adicionar uma tag a uma [Apresentação](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) usando Aspose.Slides para C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Tags também podem ser definidas para [Slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Ou qualquer [Forma](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/) individual:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitações**

Tags adicionadas através da coleção de tags de dados personalizados usando `get_CustomData()->get_Tags()` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags do PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado a partir do PDF marcado.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (ex., `shape->set_AlternativeText(u"MyId")`). Após exportar para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **Perguntas Frequentes**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [coleção de tags](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/) oferece uma operação [clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/clear/) que exclui todos os pares chave‑valor de uma só vez.

**Como excluir uma única tag pelo seu nome sem iterar sobre toda a coleção?**

Use a operação [Remove(name)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/remove/) em [TagCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [GetNamesOfTags](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/getnamesoftags/) na [coleção de tags](https://reference.aspose.com/slides/pt/cpp/aspose.slides/tagcollection/); ela retorna um array com todos os nomes de tags.