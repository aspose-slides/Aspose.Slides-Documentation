---
title: Gerenciar propriedades da apresentação em PHP
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/php-java/presentation-properties/
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
- Apresentação
- PHP
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for PHP via Java e otimize a pesquisa, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides oferece suporte a dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser facilmente acessados e gerenciados usando a API do Aspose.Slides.

Aspose.Slides permite que você trabalhe com propriedades de documentos de apresentação por meio da classe [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/). Uma instância desta classe é retornada pelo método [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDocumentProperties). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Nota" %}}
Observe que os campos **Application** e **AppVersion** não podem ser modificados. Aspose.Slides os reescreve a cada gravação, portanto uma apresentação salva sempre informa "Aspose.Slides for PHP via Java" e a versão da biblioteca que a produziu. Qualquer valor passado para `setNameOfApplication` é descartado quando a apresentação é gravada.
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento:

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

As propriedades **Built-in** contêm informações gerais sobre o documento, como título, nome do autor, estatísticas do documento etc. As propriedades **Custom** são aquelas definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for PHP via Java, os desenvolvedores podem acessar e modificar os valores das propriedades built‑in assim como as propriedades custom.

## **Propriedades de Documento no PowerPoint**

O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone do Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007, como mostrado abaixo:

|**Selecionando o item de menu Propriedades avançadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Após selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo que permite gerenciar as propriedades de documento do arquivo PowerPoint, como ilustrado na figura abaixo:

|**Caixa de Diálogo de Propriedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Na **Caixa de Diálogo de Propriedades** acima, você pode ver que há várias páginas de guia como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas páginas permitem configurar diferentes tipos de informação relacionados aos arquivos PowerPoint. A guia **Custom** é usada para gerenciar as propriedades personalizadas dos arquivos PowerPoint.

### Trabalhando com Propriedades de Documento usando Aspose.Slides for PHP via Java

Conforme descrito anteriormente, Aspose.Slides for PHP via Java oferece suporte a dois tipos de propriedades de documento: **Built-in** e **Custom**. Assim, os desenvolvedores podem acessar ambos os tipos de propriedades usando a API do Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java disponibiliza a classe [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties) que representa as propriedades de documento associadas a um arquivo de apresentação por meio da propriedade **Presentation.DocumentProperties**.

Os desenvolvedores podem usar a propriedade **DocumentProperties** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) para acessar as propriedades de documento dos arquivos de apresentação, como descrito abaixo:

## **Acessar Propriedades Built-in**

Essas propriedades, expostas pelo objeto [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties), incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**.

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

Modificar as propriedades built‑in de arquivos de apresentação é tão simples quanto acessá‑las. Você pode simplesmente atribuir um valor de string a qualquer propriedade desejada e o valor será alterado. No exemplo abaixo, demonstramos como modificar as propriedades de documento built‑in da apresentação usando Aspose.Slides for PHP via Java.

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

Este exemplo modifica as propriedades built‑in da apresentação, que podem ser vistas como mostrado abaixo:

|**Propriedades de documento built-in após modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Adicionar Propriedades de Documento Custom**

Aspose.Slides for PHP via Java também permite que os desenvolvedores adicionem valores custom às propriedades de documento da apresentação. O exemplo abaixo mostra como definir propriedades custom para uma apresentação.

```php
  $pres = new Presentation();
  try {
    # Obtendo propriedades do documento
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

|**Propriedades de Documento Custom adicionadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acessar e Modificar Propriedades Custom**

Aspose.Slides for PHP via Java também permite que os desenvolvedores acessem os valores das propriedades custom. O exemplo abaixo mostra como você pode acessar e modificar todas essas propriedades custom de uma apresentação.

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

Este exemplo modifica as propriedades custom da [PPTX](https://docs.fileformat.com/presentation/pptx/) apresentação. As figuras a seguir mostram as propriedades custom da apresentação antes e depois da modificação:

|**Propriedades Custom antes da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriedades Custom depois da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriedades Avançadas de Documento**

{{% alert color="info" title="Nota" %}}
Novos métodos [readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) e [writeBindedPresentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) foram adicionados ao [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo); a lógica do setter da propriedade [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#setLastSavedTime) foi alterada.
{{% /alert %}} 

Os dois novos métodos [readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) e [updateDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) foram adicionados à classe [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo). Eles fornecem acesso rápido às propriedades de documento e permitem alterar e atualizar propriedades sem carregar uma apresentação completa.

O cenário típico de carregar as propriedades, mudar algum valor e atualizar o documento pode ser implementado da seguinte forma:

```php
  # ler as informações da apresentação
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # obter as propriedades atuais
  $props = $info->readDocumentProperties();
  # definir os novos valores dos campos Autor e Título
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # atualizar a apresentação com novos valores
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Há outra maneira de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:

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

## **Definir Idioma de Revisão Ortográfica**

Aspose.Slides fornece a propriedade LanguageId (exposta pela classe PortionFormat) para permitir que você defina o idioma de revisão ortográfica de um documento PowerPoint. O idioma de revisão ortográfica é o idioma para o qual a ortografia e a gramática são verificadas no PowerPoint.

Este código PHP mostra como definir o idioma de revisão ortográfica para um PowerPoint: xxx Por que LanguageId está ausente na classe Java PortionFormat?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// definir o Id de um idioma de revisão

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
    # Adiciona uma nova forma de retângulo com texto
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

## **FAQ**

**Como posso remover uma propriedade built‑in de uma apresentação?**

Propriedades built‑in são parte integrante da apresentação e não podem ser removidas completamente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade custom que já existe?**

Se você adicionar uma propriedade custom que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar a apresentação completa?**

Sim. Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/) e depois [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#readDocumentProperties) para ler os metadados armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/pt/php-java/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.