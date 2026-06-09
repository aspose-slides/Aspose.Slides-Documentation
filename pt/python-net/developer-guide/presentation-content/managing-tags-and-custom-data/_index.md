---
title: Gerenciar tags e dados personalizados em apresentações com Python
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/python-net/managing-tags-and-custom-data/
keywords:
- propriedades de documento
- tag
- dados personalizados
- adicionar tag
- pares de valores
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda como adicionar, ler, atualizar e remover tags e dados personalizados no Aspose.Slides for Python via .NET, com exemplos para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Ele descreve brevemente como os dados são armazenados em arquivos PPTX, observa que dados específicos da apresentação podem existir como tags e partes XML personalizadas, e descreve as tags como pares de string chave-valor.

Ele também mostra como ler valores de tags e como adicionar tags a uma apresentação, a um slide individual ou a uma forma. Além disso, o artigo aborda tarefas comuns de gerenciamento de tags, como limpar todas as tags, remover uma tag pelo nome e recuperar a lista de nomes de tags.

## **Armazenamento de Dados em Arquivos de Apresentação**

Arquivos PPTX — itens com a extensão .pptx — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O formato Office Open XML define a estrutura dos dados contidos nas apresentações. 

Com um *slide* sendo um dos elementos nas apresentações, uma *slide part* contém o conteúdo de um único slide. Uma slide part pode ter relacionamentos explícitos com muitas partes — como User Defined Tags — definidas pela ISO/IEC 29500. 

Dados personalizados (específicos de uma apresentação) ou do usuário podem existir como tags ([ITagCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/itagcollection/)) e CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Tags são essencialmente pares de valores string‑chave. 
{{% /alert %}} 

## **Obter os Valores das Tags**

Nos slides, uma tag corresponde à propriedade IDocumentProperties.Keywords. Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides for Python via .NET para [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Adicionar Tags a Apresentações**

O Aspose.Slides permite adicionar tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada - `MyTag` 
- o valor da propriedade personalizada - `My Tag Value`

Se precisar classificar algumas apresentações com base em uma regra ou propriedade específica, você pode se beneficiar adicionando tags a essas apresentações. Por exemplo, se desejar categorizar ou reunir todas as apresentações de países da América do Norte, pode criar uma tag América do Norte e então atribuir os países relevantes (EUA, México e Canadá) como valores. 

Este código de exemplo mostra como adicionar uma tag a uma [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) usando Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Tags também podem ser definidas para [Slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Ou qualquer [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) individual:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limitações**

Tags adicionadas via a coleção `custom_data.tags` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags do PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado do PDF marcado.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, `shape.alternative_text = "MyId"`). Após exportar para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [tag collection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/) oferece uma operação [clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/clear/) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo seu nome sem iterar sobre toda a coleção?**

Use a operação [remove(name)](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/remove/) em [TagCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [get_names_of_tags](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/get_names_of_tags/) na [tag collection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/tagcollection/); ela retorna um array com todos os nomes de tags.