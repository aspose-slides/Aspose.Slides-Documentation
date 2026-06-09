---
title: Gerenciar Tags e Dados Personalizados em Apresentações Usando PHP
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/php-java/managing-tags-and-custom-data/
keywords:
- propriedades de documento
- tag
- dados personalizados
- adicionar tag
- valores de pares
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a adicionar, ler, atualizar e remover tags e dados personalizados no Aspose.Slides para PHP via Java, com exemplos para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Ele descreve brevemente como os dados são armazenados em arquivos PPTX, observa que dados específicos da apresentação podem existir como tags e partes XML personalizadas, e descreve as tags como pares de string chave‑valor.

Ele também mostra como ler valores de tags e como adicionar tags a uma apresentação, a um slide individual ou a uma forma. Além disso, o artigo aborda tarefas comuns de gerenciamento de tags, como limpar todas as tags, remover uma tag pelo nome e obter a lista de nomes de tags.

## **Armazenamento de Dados em Arquivos de Apresentação**

Os arquivos PPTX — itens com a extensão .pptx — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O formato Office Open XML define a estrutura dos dados contidos nas apresentações. 

Com um *slide* sendo um dos elementos nas apresentações, uma *parte de slide* contém o conteúdo de um único slide. Uma parte de slide pode ter relacionamentos explícitos com várias partes — como User Defined Tags — definidas pela ISO/IEC 29500. 

Dados personalizados (específicos de uma apresentação) ou do usuário podem existir como tags ([TagCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/)) e CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}}Tags são essencialmente pares de chave‑valor de string.{{% /alert %}} 

## **Obter Valores das Tags**

Nos slides, uma tag corresponde aos métodos [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#getKeywords) e [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#setKeywords). Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides para PHP via Java para [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adicionar Tags a Apresentações**

O Aspose.Slides permite que você adicione tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada - `MyTag`
- o valor da propriedade personalizada - `My Tag Value`

Se precisar classificar algumas apresentações com base em uma regra ou propriedade específica, você pode se beneficiar ao adicionar tags a essas apresentações. Por exemplo, se quiser categorizar ou agrupar todas as apresentações dos países da América do Norte, pode criar uma tag América do Norte e atribuir os países relevantes (EUA, México e Canadá) como valores. 

Este código de exemplo mostra como adicionar uma tag a um [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) usando Aspose.Slides para PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tags também podem ser definidas para [Slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ou qualquer [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $pres->getSlides()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Limitações**

Tags adicionadas por meio da coleção de tags de dados personalizados usando `getCustomData()->getTags()` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags do PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado a partir do PDF marcado.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, `$shape->setAlternativeText("MyId")`). Após exportar para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [tag collection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/) suporta a operação [clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/clear/) que exclui todos os pares chave‑valor de uma só vez.

**Como excluir uma única tag pelo seu nome sem iterar por toda a coleção?**

Use a operação [remove(name)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/remove/) na [tag collection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [getNamesOfTags](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tagcollection/); ele retorna um array com todos os nomes de tags.