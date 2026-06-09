---
title: Gerenciar Propriedades da Apresentação em Java
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/java/presentation-properties/
keywords:
- Propriedades do PowerPoint
- propriedades da apresentação
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
- Java
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides para Java e simplifique a pesquisa, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides oferece dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser acessados e gerenciados facilmente usando a API do Aspose.Slides.

Aspose.Slides permite que você trabalhe com as propriedades de documento da apresentação através da interface [IDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/) . Uma instância desta interface é retornada pelo método [Presentation.getDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getDocumentProperties--) . Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="primary" %}} 
Observe que os campos **Application** e **Producer** não podem ser modificados, pois esses campos sempre exibirão "Aspose Ltd." e "Aspose.Slides for Java x.x.x".
{{% /alert %}} 

## **Propriedades do Documento no PowerPoint**

Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone do Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007, como mostrado abaixo:

|**Selecionando o item de menu Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Após selecionar o item de menu **Advanced Properties**, será exibida uma caixa de diálogo que permite gerenciar as propriedades de documento do arquivo PowerPoint, como mostrado abaixo na figura:

|**Caixa de Diálogo de Propriedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Na **Properties Dialog** acima, você pode ver que há várias abas como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas abas permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A aba **Custom** é usada para gerenciar as propriedades personalizadas dos arquivos PowerPoint.

## **Trabalhando com Propriedades de Documento Usando Aspose.Slides para Java**

Como descrevemos anteriormente, o Aspose.Slides para Java oferece dois tipos de propriedades de documento, que são propriedades **Built-in** e **Custom**. Assim, os desenvolvedores podem acessar ambos os tipos de propriedades usando a API do Aspose.Slides para Java. O Aspose.Slides para Java fornece uma classe [IDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties) que representa as propriedades de documento associadas a um arquivo de apresentação através da propriedade **Presentation.DocumentProperties**.

Os desenvolvedores podem usar a propriedade **IDocumentProperties** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) para acessar as propriedades de documento dos arquivos de apresentação, como descrito abaixo:

## **Acessar Propriedades Built-in**

Essas propriedades expostas pelo objeto [IDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties) incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**.

```java
// Instanciar a classe Presentation que representa a apresentação
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Exibir as propriedades integradas
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificar Propriedades Built-in**

Modificar as propriedades built-in dos arquivos de apresentação é tão fácil quanto acessá‑las. Você pode simplesmente atribuir um valor string a qualquer propriedade desejada e o valor da propriedade será alterado. No exemplo abaixo, demonstramos como podemos modificar as propriedades de documento built-in do arquivo de apresentação usando Aspose.Slides para Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Definir as propriedades integradas
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Salvar sua apresentação em um arquivo
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este exemplo modifica as propriedades built-in da apresentação, que podem ser visualizadas conforme mostrado abaixo:

|**Propriedades de documento Built-in após modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Adicionar Propriedades de Documento Personalizadas**

O Aspose.Slides para Java também permite que os desenvolvedores adicionem valores personalizados às propriedades de documento da apresentação. Um exemplo é apresentado abaixo, mostrando como definir propriedades personalizadas para uma apresentação.

```java
Presentation pres = new Presentation();
try {
    // Obtendo propriedades do documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Adicionando propriedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Obtendo o nome da propriedade em um índice específico
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Removendo a propriedade selecionada
    dProps.removeCustomProperty(getPropertyName);
    
    // Salvando a apresentação
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propriedades de Documento Personalizadas Adicionadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acessar e Modificar Propriedades Personalizadas**

O Aspose.Slides para Java também permite que os desenvolvedores acessem os valores das propriedades personalizadas. Um exemplo é apresentado abaixo, mostrando como você pode acessar e modificar todas essas propriedades personalizadas de uma apresentação.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto DocumentProperties associado à Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Acessar e modificar propriedades personalizadas
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Exibir nomes e valores das propriedades personalizadas
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modificar valores das propriedades personalizadas
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Salvar sua apresentação em um arquivo
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este exemplo modifica as propriedades personalizadas da [PPTX ](https://docs.fileformat.com/presentation/pptx/) apresentação. As figuras a seguir mostram as propriedades personalizadas da apresentação antes e depois da modificação:

|**Propriedades Personalizadas antes da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriedades Personalizadas depois da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriedades Avançadas de Documento**

{{% alert color="primary" %}} 
Novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) foram adicionados ao [IPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo); a lógica do setter da propriedade [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) foi alterada.
{{% /alert %}} 

Os dois novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) foram adicionados à interface [IPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPPresentationInfo). Eles fornecem acesso rápido às propriedades de documento e permitem mudar e atualizar propriedades sem carregar uma apresentação inteira.

O cenário típico de carregar as propriedades, alterar algum valor e atualizar o documento pode ser implementado da seguinte forma:

```java
// ler as informações da apresentação
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Existe outra maneira de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Um novo modelo pode ser criado do zero e então usado para atualizar várias apresentações:

```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade LanguageId (exposta pela classe PortionFormat) para permitir que você defina o idioma de revisão para um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.

Este código Java mostra como definir o idioma de revisão para um PowerPoint: xxx Por que o LanguageId está ausente na classe Java PortionFormat?

```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // defina o Id de um idioma de revisão

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir Idioma Padrão**

Este código Java mostra como definir o idioma padrão para uma apresentação PowerPoint inteira:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Adiciona uma nova forma retângulo com texto
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Verifica o idioma da primeira porção
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## ***Perguntas Frequentes**

**Como posso remover uma propriedade built-in de uma apresentação?**

As propriedades built-in são parte integrante da apresentação e não podem ser removidas totalmente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar totalmente a apresentação?**

Sim, você pode acessar as propriedades da apresentação sem carregá‑la completamente usando o método `getPresentationInfo` da classe [PresentationFactory](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/). Em seguida, utilize o método `readDocumentProperties` fornecido pela interface [IPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/) para ler as propriedades de forma eficiente, economizando memória e melhorando o desempenho.