---
title: Gerenciar Propriedades da Apresentação em PHP
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
- apresentação
- PHP
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for PHP via Java e otimize busca, branding e fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides oferece dois tipos de propriedades de documento: **Integradas** e **Personalizadas**. Ambos os tipos de propriedade podem ser facilmente acessados e gerenciados usando a API do Aspose.Slides.

Aspose.Slides permite que você trabalhe com as propriedades de documento da apresentação através da classe [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/) . Uma instância dessa classe é retornada pelo método [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDocumentProperties) . Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Nota" %}}
Observe que os campos **Application** e **AppVersion** não podem ser modificados. Aspose.Slides os reescreve a cada salvamento, de modo que uma apresentação salva sempre relata "Aspose.Slides for PHP via Java" e a versão da biblioteca que a gerou. Qualquer valor passado para `setNameOfApplication` é descartado quando a apresentação é gravada.
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento, conforme segue:

- Propriedades Definidas pelo Sistema (Integradas)
- Propriedades Definidas pelo Usuário (Personalizadas)

As propriedades **Integradas** contêm informações gerais sobre o documento, como título, nome do autor, estatísticas do documento etc. As propriedades **Personalizadas** são aquelas definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for PHP via Java, os desenvolvedores podem acessar e modificar os valores das propriedades integradas assim como das propriedades personalizadas.

## **Propriedades de Documento no PowerPoint**

O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo que você precisa fazer é clicar no ícone do Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007, como mostrado abaixo:

|**Selecionando o item de menu Propriedades Avançadas**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Após selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo permitindo que você gerencie as propriedades de documento do arquivo PowerPoint, conforme ilustrado abaixo:

|**Caixa de Diálogo de Propriedades**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Na **Caixa de Diálogo de Propriedades** acima, você pode ver várias abas como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas abas permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A aba **Custom** é usada para gerenciar as propriedades personalizadas dos arquivos PowerPoint.

### Trabalhando com Propriedades de Documento usando Aspose.Slides for PHP via Java

Como descrito anteriormente, o Aspose.Slides for PHP via Java suporta dois tipos de propriedades de documento: **Integradas** e **Personalizadas**. Assim, os desenvolvedores podem acessar ambos os tipos de propriedades usando a API do Aspose.Slides for PHP via Java. O Aspose.Slides for PHP via Java fornece a classe [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties) que representa as propriedades de documento associadas a um arquivo de apresentação através da propriedade **Presentation.DocumentProperties**.

Os desenvolvedores podem usar a propriedade **DocumentProperties** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) para acessar as propriedades de documento dos arquivos de apresentação, conforme descrito abaixo:

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada passando `false` para [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) , suas propriedades de documento permanecem públicas. Uma aplicação pode então passar `true` para [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) e ler os metadados públicos sem precisar fornecer a senha de abertura.

A opção **document-properties-only** controla o que o Aspose.Slides carrega; ela não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo a seguir verifica o modo de carregamento via [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) e então lê as propriedades integradas via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getDocumentProperties) :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

Neste modo, o conteúdo dos slides não é carregado. Slides, mestres, layouts, formas, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) antes de executar uma operação que exija o modelo de objeto completo da apresentação.

{{% alert color="warning" title="Aviso" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados. Criptografe propriedades sensíveis junto com a apresentação. Deixe‑as públicas somente quando sistemas de indexação, classificação, busca ou gerenciamento de documentos tiverem um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada no modo **document-properties-only** destina‑se à leitura de metadados públicos. O Aspose.Slides não pode salvar propriedades alteradas desse objeto somente‑metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha correta de abertura e um carregamento completo.

O exemplo a seguir abre a apresentação com [LoadOptions::setPassword](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setPassword) , atualiza as propriedades integradas públicas e salva o resultado. Em seguida, usa [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#isEncrypted) para verificar que a criptografia foi preservada e reabre os metadados públicos sem senha para validar os novos valores:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Se uma aplicação não tem permissão para descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente‑leitura.

## **Acessar Propriedades Integradas**

Essas propriedades, conforme expostas pelo objeto [DocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties) , incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**.

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

## **Modificar Propriedades Integradas**

Modificar as propriedades integradas de arquivos de apresentação é tão fácil quanto acessá‑las. Basta atribuir um valor string à propriedade desejada e o valor será alterado. No exemplo abaixo, demonstramos como modificar as propriedades integradas de documento da apresentação usando Aspose.Slides for PHP via Java.

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

Este exemplo modifica as propriedades integradas da apresentação, que podem ser vistas como mostrado abaixo:

|**Propriedades de documento integradas após modificação**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Adicionar Propriedades de Documento Personalizadas**

Aspose.Slides for PHP via Java também permite que os desenvolvedores adicionem valores personalizados às propriedades de documento da apresentação. O exemplo abaixo mostra como definir propriedades personalizadas para uma apresentação.

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

|**Propriedades de Documento Personalizadas Adicionadas**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acessar e Modificar Propriedades Personalizadas**

Aspose.Slides for PHP via Java também permite que os desenvolvedores acessem os valores das propriedades personalizadas. O exemplo abaixo mostra como acessar e modificar todas essas propriedades personalizadas de uma apresentação.

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

Este exemplo modifica as propriedades personalizadas do [PPTX](https://docs.fileformat.com/presentation/pptx/) . As figuras a seguir mostram as propriedades personalizadas da apresentação antes e depois da modificação:

|**Propriedades Personalizadas antes da Modificação**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriedades Personalizadas após Modificação**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriedades avançadas de documento**

{{% alert color="info" title="Nota" %}}
Novos métodos [readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) e [writeBindedPresentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) foram adicionados ao [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo) ; a lógica do setter da propriedade [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/#setLastSavedTime) foi alterada.
{{% /alert %}} 

Os dois novos métodos [readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) e [updateDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) foram adicionados à classe [PresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PresentationInfo). Eles fornecem acesso rápido às propriedades de documento e permitem alterar e atualizar propriedades sem carregar a apresentação completa.

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

Existe outra forma de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:

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

Um novo modelo pode ser criado do zero e então usado para atualizar múltiplas apresentações:

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

Aspose.Slides fornece a propriedade LanguageId (exposta pela classe PortionFormat) para permitir que você defina o idioma de revisão para um documento PowerPoint. O idioma de revisão é o idioma para o qual ortografia e gramática do PowerPoint são verificadas.

Este código PHP mostra como definir o idioma de revisão para um PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

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

Este código PHP mostra como definir o idioma padrão para uma apresentação PowerPoint inteira:

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

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API do Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **FAQ**

**Como remover uma propriedade integrada de uma apresentação?**

Propriedades integradas fazem parte integrante da apresentação e não podem ser removidas completamente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor existente será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar a apresentação completa?**

Sim. Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationfactory/) e então [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentationinfo/#readDocumentProperties) para ler os metadados de documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) . Consulte [Build a Lightweight Presentation Inventory](/slides/pt/php-java/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A criptografia das propriedades de documento deve ter sido desativada antes da apresentação ser criptografada, e a apresentação deve ser carregada no modo **document-properties-only**.

**Posso atualizar um arquivo PPTX criptografado no modo document-properties-only?**

Não. Dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto atualizar um arquivo PPTX criptografado requer o carregamento completo da apresentação com a senha correta de abertura.