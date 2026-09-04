---
title: Gerenciar Propriedades da Apresentação em JavaScript
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/nodejs-java/presentation-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for Node.js via Java e otimize a busca, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides oferece suporte a dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser acessados e gerenciados facilmente usando a API do Aspose.Slides.

Aspose.Slides permite que você trabalhe com propriedades de documento de apresentação através da classe [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/) . Uma instância desta classe é retornada pelo método [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Note" %}}
Observe que os campos **Application** e **AppVersion** não podem ser modificados. Aspose.Slides os reescreve a cada gravação, portanto uma apresentação salva sempre relata "Aspose.Slides for Node.js via Java" e a versão da biblioteca que a produziu. Qualquer valor passado para `setNameOfApplication` é descartado quando a apresentação é gravada.
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint oferece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento conforme abaixo

- Propriedades Definidas pelo Sistema (Built-in) 
- Propriedades Definidas pelo Usuário (Custom) 

As propriedades **Built-in** contêm informações gerais sobre o documento, como título do documento, nome do autor, estatísticas do documento etc. As propriedades **Custom** são aquelas definidas pelos usuários como pares **Name/Value**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for Node.js via Java, os desenvolvedores podem acessar e modificar os valores das propriedades built-in assim como das propriedades custom.

## **Propriedades de Documento no PowerPoint**

O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone do Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007, conforme mostrado abaixo:

|**Selecionando o item de menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Depois de selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo permitindo gerenciar as propriedades de documento do arquivo PowerPoint, conforme mostrado na figura abaixo:

|**Caixa de diálogo de Propriedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Na **Caixa de diálogo de Propriedades** acima, você pode ver que há várias guias como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas guias permitem configurar diferentes tipos de informação relacionadas aos arquivos PowerPoint. A guia **Custom** é usada para gerenciar as propriedades custom dos arquivos PowerPoint.

### Trabalhando com Propriedades de Documento Usando Aspose.Slides for Node.js via Java

Como descrito anteriormente, Aspose.Slides for Node.js via Java oferece suporte a dois tipos de propriedades de documento, que são as propriedades **Built-in** e **Custom**. Assim, os desenvolvedores podem acessar ambos os tipos de propriedades usando a API do Aspose.Slides for Node.js via Java. O Aspose.Slides for Node.js via Java fornece a classe [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties) que representa as propriedades de documento associadas a um arquivo de apresentação através da propriedade **Presentation.DocumentProperties**.

Os desenvolvedores podem usar a propriedade **DocumentProperties** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) para acessar as propriedades de documento dos arquivos de apresentação conforme descrito abaixo:

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada passando `false` para [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) , suas propriedades de documento permanecem públicas. Uma aplicação pode então passar `true` para [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) e ler os metadados públicos sem fornecer a senha de abertura.

A opção document-properties-only controla o que o Aspose.Slides carrega; ela não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo a seguir verifica o modo de carregamento através de [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) e então lê as propriedades built-in via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getDocumentProperties) :

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Nesse modo, o conteúdo dos slides não é carregado. Slides, mestre, layouts, formas, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) antes de executar uma operação que requer o modelo de objeto completo da apresentação.

{{% alert color="warning" title="Warning" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores customizados. Criptografe propriedades sensíveis junto com a apresentação. Mantenha‑as públicas somente quando a indexação, classificação, busca ou sistemas de gerenciamento de documentos exigirem acesso sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada no modo document-properties-only destina‑se à leitura de metadados públicos. O Aspose.Slides não pode salvar propriedades alteradas desse objeto somente‑metadata porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo a seguir abre a apresentação com [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setPassword) , atualiza as propriedades built-in públicas e salva o resultado. Em seguida, usa [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) para verificar que a criptografia foi preservada e reabre os metadados públicos sem senha para verificar os novos valores :

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Se uma aplicação não tem permissão para descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente‑leitura.

## **Acessar Propriedades Built-in**

Essas propriedades, conforme expostas pelo objeto [DocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties) , incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title** 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar a classe Presentation que representa a apresentação
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à apresentação
    var dp = pres.getDocumentProperties();
    // Exibir as propriedades incorporadas
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

Modificar as propriedades built-in de arquivos de apresentação é tão fácil quanto acessá‑las. Você pode simplesmente atribuir um valor string a qualquer propriedade desejada e o valor da propriedade será modificado. No exemplo abaixo, demonstramos como podemos modificar as propriedades de documento built-in do arquivo de apresentação usando Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Apresentação
    var dp = pres.getDocumentProperties();
    // Definir as propriedades incorporadas
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

|**Propriedades de documento Built-in após modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Adicionar Propriedades de Documento Custom**

O Aspose.Slides for Node.js via Java também permite que os desenvolvedores adicionem valores customizados para as propriedades de documento da apresentação. Um exemplo é apresentado abaixo, mostrando como definir as propriedades custom para uma apresentação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Obtendo Propriedades do Documento
    var dProps = pres.getDocumentProperties();
    // Adicionando propriedades customizadas
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

|**Propriedades de Documento Custom Adicionadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acessar e Modificar Propriedades Custom**

O Aspose.Slides for Node.js via Java também permite que os desenvolvedores acessem os valores das propriedades custom. Um exemplo é apresentado abaixo, mostrando como você pode acessar e modificar todas essas propriedades custom para uma apresentação.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto DocumentProperties associado à Apresentação
    var dp = pres.getDocumentProperties();
    // Acessar e modificar propriedades customizadas
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Exibir nomes e valores das propriedades customizadas
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modificar valores das propriedades customizadas
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

Este exemplo modifica as propriedades custom da apresentação [PPTX ](https://docs.fileformat.com/presentation/pptx/) . As figuras a seguir mostram as propriedades custom da apresentação antes e depois da modificação:

|**Propriedades Custom antes da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriedades Custom após Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriedades Avançadas de Documento**

{{% alert color="info" title="Note" %}}
Novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) foram adicionados a [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo), a lógica do setter da propriedade [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) foi alterada.
{{% /alert %}} 

Os dois novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) foram adicionados à classe [PresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/PresentationInfo). Eles fornecem acesso rápido às propriedades de documento e permitem alterar e atualizar propriedades sem carregar uma apresentação completa.

O cenário típico de carregar as propriedades, alterar algum valor e atualizar o documento pode ser implementado da seguinte forma:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// ler as informações da apresentação
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obter as propriedades atuais
var props = info.readDocumentProperties();
// definir os novos valores dos campos Autor e Título
props.setAuthor("New Author");
props.setTitle("New Title");
// atualizar a apresentação com novos valores
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Há outra forma de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:

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

O Aspose.Slides fornece a propriedade LanguageId (exposta pela classe PortionFormat) para permitir que você defina o idioma de revisão para um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.

Este código JavaScript mostra como definir o idioma de revisão para um PowerPoint: xxx Por que o LanguageId está ausente na classe JavaScript PortionFormat?

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
    portionFormat.setLanguageId("zh-CN");// definir o ID de um idioma de revisão
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

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API do Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **FAQ**

**Como posso remover uma propriedade built-in de uma apresentação?**

As propriedades built-in são parte integrante da apresentação e não podem ser removidas totalmente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade custom que já existe?**

Se você adicionar uma propriedade custom que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregá‑la totalmente?**

Sim. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) e depois [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) para ler os metadados de documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) . Consulte [Build a Lightweight Presentation Inventory](/slides/pt/nodejs-java/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A criptografia das propriedades do documento deve ter sido desativada antes da apresentação ser criptografada, e a apresentação deve ser carregada no modo document-properties-only.

**Posso atualizar um arquivo PPTX criptografado no modo document-properties-only?**

Não. Os dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto atualizar um arquivo PPTX criptografado requer o carregamento completo da apresentação com a senha de abertura correta.