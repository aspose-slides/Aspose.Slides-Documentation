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
description: "Domine as propriedades de apresentação no Aspose.Slides para PHP via Java e simplifique a pesquisa, a marca e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides for PHP via Java suporta **integradas** e **personalizadas** propriedades de documento. Use essas propriedades para ler e atualizar os metadados da apresentação, como o autor, o título e valores definidos pelo usuário.

Aspose.Slides permite trabalhar com as propriedades de documento da apresentação através da classe [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/). Uma instância dessa classe é retornada por [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades. Eles assumem que o PHP/Java Bridge e o wrapper PHP do Aspose.Slides estão inicializados.

{{% alert color="info" title="Note" %}}
Aspose.Slides gerencia os metadados de aplicativo e produtor ao salvar apresentações; esses campos identificam o software que criou a saída.
{{% /alert %}}

## **Gerenciar Propriedades da Apresentação**

Propriedades de documento armazenam informações descritivas ao lado do conteúdo da apresentação. Elas se dividem em duas categorias:

- **Propriedades integradas** contêm metadados padrão, como título, autor e estatísticas do documento.
- **Propriedades personalizadas** armazenam pares nome/valor definidos pelo usuário.

Aspose.Slides for PHP via Java fornece acesso a ambas as categorias. No PowerPoint, selecione **File → Info → Properties → Advanced Properties** para inspecionar os metadados do documento. A caixa de diálogo agrupa as informações em guias como **Summary**, **Statistics**, **Contents** e **Custom**. Use a guia **Custom** para gerenciar propriedades definidas pelo usuário.

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada após chamar [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) com `false`, suas propriedades de documento permanecem públicas. Uma aplicação pode então chamar [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) com `true` e ler os metadados públicos sem fornecer a senha de abertura.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) controla o que o Aspose.Slides carrega; não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá-las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo requer uma apresentação criptografada cujas propriedades de documento foram deixadas públicas. Ele verifica o modo de carregamento através de [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) e então lê as propriedades integradas através de [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):
```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Nesse modo, o conteúdo dos slides não é carregado. Slides, mestres, layouts, formas, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) antes de executar uma operação que requer o modelo de objetos completo da apresentação.

{{% alert color="warning" title="Warning" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras-chave, informações da empresa, comentários e valores personalizados. Criptografe propriedades sensíveis junto com a apresentação. Mantenha‑as públicas apenas quando sistemas de indexação, classificação, pesquisa ou gerenciamento de documentos tiverem um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada após chamar [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) com `true` destina‑se à leitura de metadados públicos. O Aspose.Slides não pode salvar propriedades alteradas desse objeto apenas de metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo requer uma apresentação PPTX criptografada com propriedades de documento públicas e uma senha de abertura conhecida. Ele abre a apresentação completa com [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), atualiza as propriedades integradas públicas e salva o resultado. Em seguida, usa [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) para verificar que a criptografia foi preservada e reabre os metadados públicos sem senha para validar os novos valores:
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
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
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
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Se uma aplicação não tem permissão para descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente leitura.

## **Acessar Propriedades Integradas**

A classe [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) expõe metadados integrados por meio de métodos getter, incluindo [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) e [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Este exemplo abre uma apresentação existente e imprime seus metadados armazenados no console. Os valores dependem da apresentação de entrada; alguns campos podem estar vazios.
```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Modificar Propriedades Integradas**

Para atualizar metadados integrados, use os métodos setter no objeto retornado por [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Este exemplo abre uma apresentação existente, chama [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) e [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/), e então salva a apresentação atualizada com [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). O PPTX salvo contém os novos metadados.
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gerenciar a Base de Hyperlink**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) devolve a base ao nível do documento para hyperlinks relativos. Use [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) para alterá‑la ou limpá‑la. Isso é útil ao mover uma apresentação e seus arquivos vinculados para outro local. É independente do [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) de um hyperlink individual: alterar a base não reescreve os endereços de link armazenados nem altera destinos absolutos.

O exemplo requer uma apresentação contendo tanto um link relativo, como `target.html`, quanto um link absoluto, como `https://example.org/absolute.html`. Ele lê a base existente, atribui um novo endereço de base e salva e reabre a apresentação para verificar o valor. Em seguida, limpa a base com uma cadeia vazia e verifica o valor vazio em um arquivo salvo separado. Substitua o endereço de base de exemplo pela localização de seus arquivos vinculados.
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

As duas mensagens de verificação devem imprimir `true`. Limpar a base deixa os endereços individuais dos hyperlinks intactos.

Um link relativo para `target.pptx` abriu `old/target.pptx` quando a base apontava para a pasta `old`. Após alterar a base para a pasta `new`, salvar e reabrir a apresentação, o mesmo link abriu `new/target.pptx`. Um link absoluto continuou a abrir o mesmo arquivo. Teste seus links relativos no PowerPoint antes e depois de mover a apresentação ou mudar sua base.

## **Adicionar Propriedades Personalizadas à Apresentação**

Propriedades personalizadas armazenam metadados que não possuem um campo integrado correspondente. O método [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) permite atribuir um valor por nome da propriedade. Este exemplo cria uma apresentação, adiciona dois valores de texto e um valor inteiro de versão, e salva a apresentação com [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Atribuir um valor a um nome existente substitui o valor dessa propriedade.
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Acessar e Modificar Propriedades Personalizadas**

Este exemplo abre uma apresentação contendo propriedades personalizadas e usa [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) para iterar sobre elas. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) aceita um índice baseado em zero e retorna o nome usado por [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). O exemplo imprime cada nome e valor original, substitui cada valor por uma string numerada independentemente do tipo original, e salva as alterações. Se não houver propriedades personalizadas, o loop não faz alterações.
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**Visualizar & Editar Metadados do PowerPoint**](https://products.aspose.app/slides/metadata) para ver como trabalhar com propriedades de documento usando a API Aspose.Slides:
[![Visualizar & Editar Metadados do PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Perguntas Frequentes**

**Como posso remover uma propriedade integrada de uma apresentação?**

As propriedades integradas são parte integrante da apresentação e não podem ser removidas totalmente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se permitido pela propriedade específica.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor existente será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade previamente, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar totalmente a apresentação?**

Sim. Use [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) e depois [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) para ler os metadados de documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/pt/php-java/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A apresentação deve ter sido criptografada após chamar [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) com `false`, e deve ser carregada após chamar [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) com `true`.

**Posso atualizar um arquivo PPTX criptografado no modo apenas de propriedades de documento?**

Não. Os dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto atualizar um arquivo PPTX criptografado requer carregar a apresentação completa com a senha de abertura correta.