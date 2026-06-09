---
title: Gerenciar Tags e Dados Personalizados em Apresentações Usando Java
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/java/managing-tags-and-custom-data/
keywords:
- propriedades do documento
- tag
- dados personalizados
- adicionar tag
- valores de pares
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como adicionar, ler, atualizar e remover tags e dados personalizados no Aspose.Slides para Java, com exemplos para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Ele descreve brevemente como os dados são armazenados em arquivos PPTX, observa que dados específicos de apresentação podem existir como tags e partes XML personalizadas, e descreve as tags como pares de strings chave‑valor.

Ele também mostra como ler valores de tags e como adicionar tags a uma apresentação, a um slide individual ou a uma forma. Além disso, o artigo cobre tarefas comuns de gerenciamento de tags, como limpar todas as tags, remover uma tag pelo nome e recuperar a lista de nomes de tags.

## **Armazenamento de Dados em Arquivos de Apresentação**

Os arquivos PPTX — itens com a extensão .pptx — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O formato Office Open XML define a estrutura dos dados contidos nas apresentações. 

Com um *slide* sendo um dos elementos nas apresentações, uma *parte de slide* contém o conteúdo de um único slide. Uma parte de slide pode ter relacionamentos explícitos com várias partes — como User Defined Tags — definidos pela ISO/IEC 29500. 

Dados personalizados (específicos de uma apresentação) ou do usuário podem existir como tags ([ITagCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITagCollection)) e CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ICustomXmlPartCollection)). 

{{% alert color="primary" %}} 

Tags são essencialmente pares de valores string‑chave. 

{{% /alert %}} 

## **Obter Valores das Tags**

Nos slides, uma tag corresponde aos métodos [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IDocumentProperties#getKeywords--) e [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Este código de exemplo mostra como obter o valor de uma tag com Aspose.Slides for Java para [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adicionar Tags a Apresentações**

Aspose.Slides permite adicionar tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada - `MyTag` 
- o valor da propriedade personalizada - `My Tag Value`

Se precisar classificar algumas apresentações com base em uma regra ou propriedade específica, você pode se beneficiar de adicionar tags a essas apresentações. Por exemplo, se quiser categorizar ou agrupar todas as apresentações de países da América do Norte, pode criar uma tag América do Norte e então atribuir os países relevantes (EUA, México e Canadá) como valores. 

Este código de exemplo mostra como adicionar uma tag a um [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) usando Aspose.Slides for Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tags também podem ser definidas para [Slide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Ou qualquer [Shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Limitações**

Tags adicionadas através da coleção de tags de dados personalizados usando `getCustomData().getTags()` são armazenadas apenas no arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags do PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado a partir do PDF com tags.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, `shape.setAlternativeText("MyId")`). Após exportar para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **FAQ**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [tag collection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/) suporta a operação [clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/#clear--) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo nome sem iterar sobre toda a coleção?**

Use a operação [Remove(name)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [tag collection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/) para excluir a tag pela sua chave.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [getNamesOfTags](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/#getNamesOfTags--) na [tag collection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/tagcollection/); ele retorna um array com todos os nomes de tags.