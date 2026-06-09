---
title: Gerenciar Tags e Dados Personalizados em Apresentações Usando JavaScript
linktitle: Tags e Dados Personalizados
type: docs
weight: 300
url: /pt/nodejs-java/managing-tags-and-custom-data/
keywords:
- propriedades de documento
- tag
- dados personalizados
- adicionar tag
- valores de pares
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como adicionar, ler, atualizar e remover tags e dados personalizados no Aspose.Slides para Node.js, com exemplos para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como o Aspose.Slides trabalha com tags e dados personalizados em apresentações do PowerPoint. Ele descreve brevemente como os dados são armazenados em arquivos PPTX, observa que dados específicos da apresentação podem existir como tags e partes XML personalizadas, e descreve as tags como pares de string chave‑valor.

Ele também mostra como ler valores de tags e como adicionar tags a uma apresentação, a um slide individual ou a uma forma. Além disso, o artigo cobre tarefas comuns de gerenciamento de tags, como limpar todas as tags, remover uma tag por nome e recuperar a lista de nomes de tags.

## **Armazenamento de Dados em Arquivos de Apresentação**

Arquivos PPTX — itens com a extensão .pptx — são armazenados no formato PresentationML, que faz parte da especificação Office Open XML. O formato Office Open XML define a estrutura dos dados contidos nas apresentações. 

Com um *slide* sendo um dos elementos nas apresentações, uma *parte de slide* contém o conteúdo de um único slide. Uma parte de slide pode ter relacionamentos explícitos com várias partes — como Tags Definidas pelo Usuário — definidas pela ISO/IEC 29500. 

Dados personalizados (específicos de uma apresentação) ou do usuário podem existir como tags ([TagCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TagCollection)) e CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
As tags são essencialmente pares de valor de string‑chave. 
{{% /alert %}} 

## **Obtendo os Valores das Tags**

Nos slides, uma tag corresponde aos métodos [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) e [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) . Este exemplo de código mostra como obter o valor de uma tag com Aspose.Slides para Node.js via Java para [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adicionando Tags a Apresentações**

O Aspose.Slides permite adicionar tags a apresentações. Uma tag normalmente consiste em dois itens:

- o nome de uma propriedade personalizada - `MyTag` 
- o valor da propriedade personalizada - `My Tag Value`

Se precisar classificar algumas apresentações com base em uma regra ou propriedade específica, pode ser útil adicionar tags a essas apresentações. Por exemplo, se quiser categorizar ou agrupar todas as apresentações de países da América do Norte, pode criar uma tag América do Norte e então atribuir os países relevantes (EUA, México e Canadá) como valores. 

Este exemplo de código mostra como adicionar uma tag a um [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) usando Aspose.Slides para Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tags também podem ser definidas para [Slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ou qualquer [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) individual:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Limitações**

Tags adicionadas por meio da coleção de tags de dados personalizados usando `getCustomData().getTags()` são armazenadas apenas dentro do arquivo PowerPoint. Elas **não** são transferidas para a estrutura de tags do PDF quando a apresentação é exportada para PDF. Consequentemente, um identificador personalizado atribuído como tag não pode ser recuperado do PDF marcado.

**Solução alternativa**: Você pode armazenar um identificador personalizado no **Alt Text** do objeto (por exemplo, `shape.setAlternativeText("MyId")`). Após a exportação para PDF, o Alt Text pode aparecer na estrutura de tags do PDF.

## **Perguntas Frequentes**

**Posso remover todas as tags de uma apresentação, slide ou forma em uma única operação?**

Sim. A [tag collection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/) suporta a operação [clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/clear/) que exclui todos os pares chave‑valor de uma vez.

**Como excluir uma única tag pelo nome sem iterar sobre toda a coleção?**

Use a operação [remove(name)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/remove/) em [TagCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/) para excluir a tag pelo seu identificador.

**Como posso recuperar a lista completa de nomes de tags para análise ou filtragem?**

Use [getNamesOfTags](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tagcollection/); ela retorna um array com todos os nomes de tags.