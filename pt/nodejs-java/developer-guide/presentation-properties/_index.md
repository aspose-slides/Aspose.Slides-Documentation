---
title: Gerenciar Propriedades de Apresentação em JavaScript
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/nodejs-java/presentation-properties/
keywords:
- Propriedades do PowerPoint
- Propriedades da apresentação
- Propriedades do documento
- Propriedades incorporadas
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
- Apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for Node.js via Java e simplifique a pesquisa, a marca e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides suporta dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser acessados e gerenciados facilmente usando a API Aspose.Slides.

Aspose.Slides permite que você trabalhe com as propriedades de documento de apresentações através da classe [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/) . Uma instância desta classe é retornada pelo método [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Note" %}}
Observe que os campos **Application** e **AppVersion** não podem ser modificados. O Aspose.Slides os reescreve a cada salvamento, de modo que uma apresentação salva sempre indica "Aspose.Slides for Node.js via Java" e a versão da biblioteca que a gerou. Qualquer valor passado para `setNameOfApplication` é descartado quando a apresentação é gravada.
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento, conforme a seguir

- Propriedades Definidas pelo Sistema (Built-in)
- Propriedades Definidas pelo Usuário (Custom)

As propriedades **Built-in** contêm informações gerais sobre o documento, como título do documento, nome do autor, estatísticas do documento etc. As propriedades **Custom** são aquelas definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for Node.js via Java, os desenvolvedores podem acessar e modificar os valores das propriedades integradas assim como das propriedades personalizadas.

## **Propriedades de Documento no PowerPoint**

O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone do Office e depois no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007, como mostrado abaixo:

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Depois de selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo permitindo gerenciar as propriedades de documento do arquivo PowerPoint, como mostrado na figura abaixo:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

No **Properties Dialog** acima, você pode ver que há várias guias como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas guias permitem configurar diferentes tipos de informação relacionados aos arquivos PowerPoint. A guia **Custom** é usada para gerenciar as propriedades personalizadas dos arquivos PowerPoint.

### Trabalhando com Propriedades de Documento Usando Aspose.Slides for Node.js via Java

Como descrito anteriormente, o Aspose.Slides for Node.js via Java suporta dois tipos de propriedades de documento, que são **Built-in** e **Custom**. Portanto, os desenvolvedores podem acessar ambos os tipos de propriedades usando a API Aspose.Slides for Node.js via Java. O Aspose.Slides for Node.js via Java fornece a classe [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties) que representa as propriedades de documento associadas a um arquivo de apresentação por meio da propriedade **Presentation.DocumentProperties**.

Os desenvolvedores podem usar a propriedade **DocumentProperties** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) para acessar as propriedades de documento dos arquivos de apresentação, conforme descrito abaixo:

## **Acessar Propriedades Built-in**

Essas propriedades expostas pelo objeto [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties) incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar a classe Presentation que representa a apresentação
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Presentation
    var dp = pres.getDocumentProperties();
    // Exibir as propriedades built-in
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modificar Propriedades Built-in**

Modificar as propriedades built-in de arquivos de apresentação é tão fácil quanto acessá‑las. Você pode simplesmente atribuir um valor string a qualquer propriedade desejada e o valor será modificado. No exemplo abaixo, demonstramos como modificar as propriedades de documento built-in do arquivo de apresentação usando Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Presentation
    var dp = pres.getDocumentProperties();
    // Definir as propriedades built-in
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Salvar sua apresentação em um arquivo
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este exemplo modifica as propriedades built-in da apresentação, que podem ser visualizadas como mostrado abaixo:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Adicionar Propriedades de Documento Personalizadas**

Aspose.Slides for Node.js via Java também permite que os desenvolvedores adicionem valores personalizados às propriedades de documento da apresentação. O exemplo abaixo mostra como definir as propriedades personalizadas para uma apresentação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Obtendo propriedades do documento
    var dProps = pres.getDocumentProperties();
    // Adicionando propriedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Obtendo o nome da propriedade em um índice específico
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Removendo a propriedade selecionada
    dProps.removeCustomProperty(getPropertyName);
    // Salvando a apresentação
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acessar e Modificar Propriedades Personalizadas**

Aspose.Slides for Node.js via Java também permite que os desenvolvedores acessem os valores das propriedades personalizadas. O exemplo abaixo mostra como acessar e modificar todas essas propriedades personalizadas de uma apresentação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto DocumentProperties associado à Presentation
    var dp = pres.getDocumentProperties();
    // Acessar e modificar propriedades personalizadas
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Exibir nomes e valores das propriedades personalizadas
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modificar valores das propriedades personalizadas
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Salvar sua apresentação em um arquivo
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este exemplo modifica as propriedades personalizadas da [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. As figuras a seguir mostram as propriedades personalizadas da apresentação antes e depois da modificação:

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriedades de Documento Avançadas**

{{% alert color="info" title="Note" %}}
Novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) foram adicionados a [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo); a lógica do setter da propriedade [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) foi alterada.
{{% /alert %}} 

Os dois novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) foram adicionados à classe [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo). Eles fornecem acesso rápido às propriedades de documento e permitem mudar e atualizar propriedades sem carregar toda a apresentação.

O cenário típico de carregar as propriedades, alterar algum valor e atualizar o documento pode ser implementado da seguinte forma:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ler as informações da apresentação
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obter as propriedades atuais
var props = info.readDocumentProperties();
// definir os novos valores dos campos Author e Title
props.setAuthor("New Author");
props.setTitle("New Title");
// atualizar a apresentação com novos valores
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Existe outra maneira de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Um novo modelo pode ser criado do zero e então usado para atualizar múltiplas apresentações:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade LanguageId (exposta pela classe PortionFormat) para permitir que você defina o idioma de revisão para um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.

Este código JavaScript mostra como definir o idioma de revisão para um PowerPoint: xxx Por que LanguageId está ausente da classe JavaScript PortionFormat?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// definir o Id de um idioma de revisão
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Idioma Padrão**

Este código JavaScript mostra como definir o idioma padrão para uma apresentação PowerPoint inteira:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Adiciona uma nova forma retangular com texto
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Verifica o idioma da primeira porção
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **Perguntas Frequentes**

**Como posso remover uma propriedade built-in de uma apresentação?**

As propriedades built-in são parte integrante da apresentação e não podem ser removidas totalmente. No entanto, você pode mudar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor existente será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar a apresentação completa?**

Sim. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) e depois [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) para ler os metadados do documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/). Veja [Build a Lightweight Presentation Inventory](/slides/pt/nodejs-java/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.