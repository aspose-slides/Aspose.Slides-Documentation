---
title: Gerenciar Propriedades de Apresentação em PHP
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/php-java/presentation-properties/
keywords:
- Propriedades do PowerPoint
- propriedades de apresentação
- propriedades de documento
- propriedades integradas
- propriedades personalizadas
- propriedades avançadas
- gerenciar propriedades
- modificar propriedades
- metadados de documento
- editar metadados
- idioma de revisão
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for PHP via Java e otimize a pesquisa, marca e fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides oferece suporte a dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser facilmente acessados e gerenciados usando a API Aspose.Slides.

Aspose.Slides permite que você trabalhe com propriedades de documento de apresentação através da classe [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/). Uma instância dessa classe é retornada pelo método [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDocumentProperties). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="primary" %}} 
Observe que os campos **Application** e **Producer** não podem ser modificados, pois esses campos sempre exibirão "Aspose Ltd." e "Aspose.Slides for PHP via Java x.x.x".
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint oferece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento, a saber:

- Propriedades Definidas pelo Sistema (Built-in)
- Propriedades Definidas pelo Usuário (Custom)

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for PHP via Java, developers can access and modify the values of built-in properties as well as custom properties.

## **Propriedades de Documento no PowerPoint**

Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007, como mostrado abaixo:

|**Selecionar item de menu Propriedades Avançadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Depois de selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo que permite gerenciar as propriedades de documento do arquivo PowerPoint, como mostrado na figura abaixo:

|**Caixa de Diálogo de Propriedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Na **Caixa de Diálogo de Propriedades**, você pode ver várias guias como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas guias permitem configurar diferentes tipos de informação relacionados aos arquivos PowerPoint. A guia **Custom** é usada para gerenciar as propriedades personalizadas dos arquivos PowerPoint.

### Trabalhando com Propriedades de Documento Usando Aspose.Slides para PHP via Java

Conforme descrito anteriormente, Aspose.Slides for PHP via Java suporta dois tipos de propriedades de documento: **Built-in** e **Custom**. Portanto, os desenvolvedores podem acessar ambos os tipos de propriedades usando a API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java fornece a classe [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties) que representa as propriedades de documento associadas a um arquivo de apresentação através da propriedade **Presentation.DocumentProperties**.

Os desenvolvedores podem usar a propriedade **DocumentProperties** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) para acessar as propriedades de documento dos arquivos de apresentação, conforme descrito abaixo:

## **Acessar Propriedades Built-in**

Essas propriedades, expostas pelo objeto [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties), incluem: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** e **Title**.

```php
  # Instanciar a classe Presentation que representa a apresentação
  $pres = new Presentation("Presentation.pptx");
  try {
    # Criar uma referência ao objeto IDocumentProperties associado à Presentation
    $dp = $pres->getDocumentProperties();
    # Exibir as propriedades integradas
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modificar Propriedades Built-in**

Modificar as propriedades built-in de arquivos de apresentação é tão fácil quanto acessá‑las. Basta atribuir um valor string à propriedade desejada que o valor será alterado. No exemplo abaixo, demonstramos como modificar as propriedades de documento built-in da apresentação usando Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Criar uma referência ao objeto IDocumentProperties associado à Presentation
    $dp = $pres->getDocumentProperties();
    # Definir as propriedades integradas
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Salvar sua apresentação em um arquivo
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este exemplo modifica as propriedades built-in da apresentação, que podem ser visualizadas como mostrado abaixo:

|**Propriedades de documento Built-in após modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Adicionar Propriedades de Documento Personalizadas**

Aspose.Slides for PHP via Java também permite que os desenvolvedores adicionem valores personalizados às propriedades de documento da apresentação. O exemplo abaixo mostra como definir propriedades personalizadas para uma apresentação.

```php
  $pres = new Presentation();
  try {
    # Obtendo Propriedades do Documento
    $dProps = $pres->getDocumentProperties();
    # Adicionando propriedades personalizadas
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Obtendo o nome da propriedade em um índice específico
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Removendo a propriedade selecionada
    $dProps->removeCustomProperty($getPropertyName);
    # Salvando a apresentação
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Propriedades de Documento Personalizadas Adicionadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acessar e Modificar Propriedades Personalizadas**

Aspose.Slides for PHP via Java também permite que os desenvolvedores acessem os valores das propriedades personalizadas. O exemplo abaixo mostra como você pode acessar e modificar todas essas propriedades personalizadas para uma apresentação.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Criar uma referência ao objeto DocumentProperties associado à Presentation
    $dp = $pres->getDocumentProperties();
    # Acessar e modificar propriedades personalizadas
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Exibir nomes e valores das propriedades personalizadas
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modificar valores das propriedades personalizadas
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Salvar sua apresentação em um arquivo
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este exemplo modifica as propriedades personalizadas da apresentação [PPTX](https://docs.fileformat.com/presentation/pptx/). As figuras a seguir mostram as propriedades personalizadas da apresentação antes e depois da modificação:

|**Propriedades Personalizadas antes da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriedades Personalizadas após a Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriedades Avançadas de Documento**

{{% alert color="primary" %}} 
Novos métodos [readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) e [writeBindedPresentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) foram adicionados ao [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo); a lógica do setter da propriedade [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#setLastSavedTime) foi alterada.
{{% /alert %}} 

Os dois novos métodos [readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) e [updateDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) foram adicionados à classe [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo). Eles fornecem acesso rápido às propriedades de documento e permitem alterar e atualizar propriedades sem carregar a apresentação completa.

O cenário típico de carregar as propriedades, mudar algum valor e atualizar o documento pode ser implementado da seguinte forma:

```php
  # ler as informações da apresentação
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # obter as propriedades atuais
  $props = $info->readDocumentProperties();
  # definir os novos valores dos campos Author e Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # atualizar a apresentação com novos valores
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Existe outra maneira de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Um novo modelo pode ser criado do zero e então usado para atualizar várias apresentações:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade LanguageId (exposta pela classe PortionFormat) para permitir que você defina o idioma de revisão de um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática do PowerPoint são verificadas.

Este código PHP mostra como definir o idioma de revisão para um PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// definir o Id de um idioma de revisão

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Idioma Padrão**

Este código PHP mostra como definir o idioma padrão para toda a apresentação PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Adiciona uma nova forma retangular com texto
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Verifica o idioma da primeira porção
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **Perguntas Frequentes**

**Como posso remover uma propriedade built-in de uma apresentação?**

Propriedades built-in são parte integral da apresentação e não podem ser removidas completamente. No entanto, você pode alterar seus valores ou defini‑las como vazias, caso a propriedade específica permita.

**O que acontece se eu adicionar uma propriedade custom que já existe?**

Se você adicionar uma propriedade custom que já existe, o valor existente será sobrescrito pelo novo valor. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar propriedades da apresentação sem carregar a apresentação completamente?**

Sim, você pode acessar as propriedades da apresentação sem carregá‑la totalmente usando o método `getPresentationInfo` da classe [PresentationFactory](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/). Em seguida, utilize o método `readDocumentProperties` fornecido pela classe [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/) para ler as propriedades de forma eficiente, economizando memória e melhorando o desempenho.