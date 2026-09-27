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
description: "Aplicar, gerenciar e solucionar problemas de licenças no Aspose.Slides para PHP via Java. Garanta acesso ininterrupto a todos os recursos com nosso guia de licenciamento passo a passo."
---
## **Introdução**

Às vezes, para obter os melhores resultados de avaliação, pode ser necessário um método prático. Por esse motivo, o Aspose.Slides oferece diferentes planos de compra e também oferece um Teste Gratuito e uma Licença Temporária de 30 dias para avaliação.

{{% alert color="info" title="Note" %}}
Observe que há várias políticas e práticas gerais que orientam como avaliar, licenciar adequadamente e comprar nossos produtos. Você pode encontrá‑las na seção [Políticas de Compra e FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Avaliar Aspose.Slides**
Você pode baixar facilmente o Aspose.Slides para avaliação. O pacote de avaliação é o mesmo do pacote adquirido. A versão de avaliação simplesmente se torna licenciada depois que você adiciona algumas linhas de código para aplicar a licença. 

## **Limitação da Versão de Avaliação**
A versão de avaliação do Aspose.Slides (sem uma licença especificada) fornece a funcionalidade completa do produto, com duas limitações:

* Ele adiciona uma caixa de texto com marca d'água de avaliação ao centro de cada slide de cada apresentação que salva.
* O texto que seu código lê de uma apresentação é truncado aos primeiros caracteres, seguido por um aviso sobre a limitação da avaliação. O texto que seu código grava é salvo integralmente.

{{% alert color="info" title="Note" %}}
Se você quiser testar o Aspose.Slides sem as limitações da versão de avaliação, pode solicitar uma **Licença Temporária de 30 Dias**. Consulte [Como obter uma Licença Temporária?](https://purchase.aspose.com/temporary-license) para mais informações.
{{% /alert %}} 

## **Sobre a Licença**
Você pode baixar facilmente uma versão de avaliação do Aspose.Slides para PHP via Java a partir da sua [página de download](https://packagist.org/packages/aspose/slides). A versão de avaliação oferece absolutamente **os mesmos recursos** da versão licenciada do Aspose.Slides. Além disso, a versão de avaliação simplesmente se torna licenciada depois que você compra uma licença e adiciona algumas linhas de código para aplicá‑la.

A licença é um arquivo XML em texto simples que contém detalhes como o nome do produto, número de desenvolvedores a que está licenciada, data de expiração da assinatura, etc. O arquivo é assinado digitalmente, portanto não o modifique. Mesmo a adição acidental de uma quebra de linha extra ao conteúdo do arquivo o tornará inválido.

Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar **Aspose.Slides**. Você só precisa definir a licença uma vez por aplicação ou processo.

{{% alert color="info" title="Note" %}}
Talvez você queira ver [Licenciamento por Medição](/slides/pt/php-java/metered-licensing/).
{{% /alert %}} 

## **Licença Adquirida**

Após a compra, você precisa aplicar o arquivo ou fluxo de licença. 

{{% alert color="info" title="Note" %}}
Você precisa definir a licença:
* apenas uma vez por domínio de aplicação
* antes de usar qualquer outra classe do Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Você pode encontrar informações de preços na página [“Informações de Preços”](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Definir uma Licença no Aspose.Slides para PHP via Java**

Licenças podem ser aplicadas a partir destes locais:

* Caminho explícito
* Fluxo
* Como Licença por Medição – um novo mecanismo de licenciamento

{{% alert color="info" title="Note" %}}
Use o método **setLicense** para licenciar um componente.

Embora várias chamadas ao **setLicense** não causem danos, elas desperdiçam recursos (processador).
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores usam um sistema de licenciamento diferente e não reconhecerão essas licenças.
{{% /alert %}}

#### **Aplicar uma Licença Usando um Arquivo**

Este trecho de código é usado para definir um arquivo de licença:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pt/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

O exemplo espera que o arquivo de licença esteja ao lado do script e passa seu caminho absoluto: o Aspose.Slides roda dentro do Tomcat, portanto não resolve um caminho relativo em relação à pasta do seu script. Ao chamar o método setLicense, o nome da licença deve ser o mesmo do seu arquivo de licença. Por exemplo, você pode mudar o nome do arquivo de licença para "Aspose.Slides.lic.xml". Em seguida, no seu código, você deve passar o novo nome da licença (Aspose.Slides.lic.xml) ao método setLicense.

#### **Aplicar uma Licença a partir de um Fluxo**

Este trecho de código é usado para aplicar uma licença a partir de um fluxo:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/pt/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão à internet.

### O que acontece depois que a assinatura de um ano expira? A biblioteca deixará de funcionar?

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; você simplesmente não estará elegível a usar versões mais recentes sem renovação.