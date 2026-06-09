---
title: Licenciamento
type: docs
weight: 80
url: /pt/php-java/licensing/
keywords:
- licença
- licença temporária
- definir licença
- usar licença
- validar licença
- arquivo de licença
- versão de avaliação
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Aplique, gerencie e solucione problemas de licenças no Aspose.Slides para PHP via Java. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Introdução**

Às vezes, para obter os melhores resultados de avaliação, pode ser necessário um abordagem prática. Por esse motivo, Aspose.Slides oferece diferentes planos de compra e também disponibiliza um Teste Gratuito e uma Licença Temporária de 30 dias para avaliação.

{{% alert color="primary" %}}

Observe que há várias políticas e práticas gerais que orientam como avaliar, licenciar corretamente e comprar nossos produtos. Você pode encontrá‑las na seção [Políticas de Compra e Perguntas Frequentes](https://purchase.aspose.com/policies).

{{% /alert %}}

## **Avaliar Aspose.Slides**
Você pode baixar facilmente o Aspose.Slides para avaliação. O pacote de avaliação é o mesmo que o pacote adquirido. A versão de avaliação simplesmente se torna licenciada após você adicionar algumas linhas de código para aplicar a licença. 

## **Limitação da Versão de Avaliação**
A versão de avaliação do Aspose.Slides (sem uma licença especificada) oferece toda a funcionalidade do produto, mas insere uma marca d'água de avaliação no topo do documento ao abrir e salvar. Você também está limitado a um slide ao extrair textos dos slides de apresentação.

{{% alert color="primary" %}} 

Se você quiser testar o Aspose.Slides sem as limitações da versão de avaliação, pode solicitar uma **Licença Temporária de 30 Dias**. Consulte [Como obter uma Licença Temporária?](https://purchase.aspose.com/temporary-license) para mais informações.

{{% /alert %}} 

## **Sobre a Licença**
Você pode baixar facilmente uma versão de avaliação do Aspose.Slides para PHP via Java a partir da sua [página de download](https://packagist.org/packages/aspose/slides). A versão de avaliação oferece absolutamente **os mesmos recursos** da versão licenciada do Aspose.Slides. Além disso, a versão de avaliação simplesmente se torna licenciada após a compra de uma licença e a adição de algumas linhas de código para aplicar a licença.

A licença é um arquivo XML em texto simples que contém detalhes como o nome do produto, número de desenvolvedores para os quais está licenciada, data de expiração da assinatura, etc. O arquivo é assinado digitalmente, portanto, não o modifique. Até mesmo a adição inadvertida de uma quebra de linha extra ao conteúdo do arquivo o invalidará.

Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar **Aspose.Slides**. É necessário definir a licença apenas uma vez por aplicação ou processo.

{{% alert color="primary" %}} 

Talvez você queira ver [Licenciamento por Medição](https://docs.aspose.com/slides/pt/php-java/metered-licensing/).

{{% /alert %}} 

## **Licença Adquirida**

Após a compra, você precisa aplicar o arquivo ou fluxo de licença. 

{{% alert color="primary" %}}

Você precisa definir a licença:
* apenas uma vez por domínio de aplicação
* antes de usar qualquer outra classe do Aspose.Slides

{{% /alert %}}

{{% alert color="primary" %}}

Você pode encontrar informações de preços na página [Informações de Preços](https://purchase.aspose.com/pricing/slides/pt/family).

{{% /alert %}}

### **Definir uma Licença no Aspose.Slides para PHP via Java**

As licenças podem ser aplicadas a partir destes locais:

* Caminho explícito
* Fluxo
* Como Licença por Medição – um novo mecanismo de licenciamento

{{% alert color="primary" %}}

Use o método **setLicense** para licenciar um componente.

Embora várias chamadas a **setLicense** não sejam prejudiciais, elas desperdiçam recursos (processador).

{{% /alert %}}

{{% alert color="warning" %}}

Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.

{{% /alert %}}

#### **Aplicar uma Licença Usando um Arquivo**

Este trecho de código é usado para definir um arquivo de licença:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Ao chamar o método setLicense, o nome da licença deve ser o mesmo do seu arquivo de licença. Por exemplo, você pode alterar o nome do arquivo de licença para "Aspose.Slides.lic.xml". Em seguida, no seu código, você deve passar o novo nome da licença (Aspose.Slides.lic.xml) para o método setLicense.

#### **Aplicar uma Licença a partir de um Fluxo**

Este trecho de código é usado para aplicar uma licença a partir de um fluxo:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **Perguntas Frequentes**

**Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?**

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão com a internet.

**O que acontece depois que a assinatura de um ano expira? A biblioteca deixará de funcionar?**

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não será elegível a usar versões mais recentes sem renovar.