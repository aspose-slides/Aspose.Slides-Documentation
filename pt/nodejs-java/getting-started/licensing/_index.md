---
title: Licenciamento
type: docs
weight: 80
url: /pt/nodejs-java/licensing/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar, gerenciar e solucionar problemas de licenças no Aspose.Slides para Node.js. Garanta acesso ininterrupto a todos os recursos com nosso guia de licenciamento passo a passo."
---
## **Introdução**

Às vezes, para obter os melhores resultados de avaliação, pode ser necessária uma abordagem prática. Por esse motivo, Aspose.Slides oferece diferentes planos de compra e também fornece um Teste Gratuito e uma Licença Temporária de 30 dias para avaliação.

{{% alert color="info" title="Note" %}}
Observe que existem diversas políticas e práticas gerais que orientam como avaliar, licenciar corretamente e comprar nossos produtos. Você pode encontrá‑las na seção ["Purchase Policies and FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Avaliar Aspose.Slides**
Você pode baixar Aspose.Slides facilmente para avaliação. O pacote de avaliação é o mesmo que o pacote adquirido. A versão de avaliação simplesmente se torna licenciada após você adicionar algumas linhas de código para aplicar a licença. 

## **Limitação da Versão de Avaliação**
A versão de avaliação do Aspose.Slides (sem uma licença especificada) fornece a funcionalidade completa do produto, com duas limitações:

* Adiciona uma caixa de texto com marca d'água de avaliação a cada slide de cada apresentação que salva.
* Texto com mais de cinco caracteres que seu código lê de uma apresentação é truncado para os primeiros cinco caracteres, seguido por `... text has been truncated due to evaluation version limitation.` Texto com cinco caracteres ou menos é retornado sem alterações, e texto que seu código grava é salvo integralmente.

{{% alert color="info" title="Note" %}}
Se você quiser testar Aspose.Slides sem as limitações da versão de avaliação, pode solicitar uma **Licença Temporária de 30 Dias**. Consulte [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) para obter mais informações.
{{% /alert %}}

## **Sobre a Licença**
Você pode baixar facilmente uma versão de avaliação do Aspose.Slides para Node.js via Java a partir da sua [download page](https://releases.aspose.com/slides/nodejs-java/). A versão de avaliação tem os mesmos recursos da versão licenciada, com as limitações descritas acima. Além disso, a versão de avaliação simplesmente se torna licenciada após você adquirir uma licença e adicionar algumas linhas de código para aplicar a licença.

A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, número de desenvolvedores para os quais está licenciada, data de expiração da assinatura, etc. O arquivo é digitalmente assinado, portanto não o modifique. Mesmo a adição inadvertida de uma quebra de linha extra ao conteúdo do arquivo o invalidará.

Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar **Aspose.Slides**. É necessário definir a licença apenas uma vez por aplicação ou processo.

{{% alert color="info" title="Note" %}}
Você pode querer ver [Metered Licensing](/slides/pt/nodejs-java/metered-licensing/).
{{% /alert %}}

## **Licença Adquirida**

Após a compra, você precisa aplicar o arquivo ou stream da licença. 

{{% alert color="info" title="Note" %}}
Você precisa definir a licença:
* apenas uma vez por processo
* antes de usar quaisquer outras classes do Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Você pode encontrar informações de preços na página [“Pricing Information”](https://purchase.aspose.com/pricing/slides/family).
{{% /alert %}}

### **Definindo uma Licença no Aspose.Slides para Node.js via Java**

Licenças podem ser aplicadas a partir destes locais:

* Caminho explícito
* Stream
* Como Licença Medida – um novo mecanismo de licenciamento

{{% alert color="info" title="Note" %}}
Use o método **setLicense** para licenciar um componente.

Embora várias chamadas ao **setLicense** não sejam prejudiciais, elas são um desperdício de recursos (processador).
{{% /alert %}}

#### **Aplicando uma Licença Usando um Arquivo**

Este trecho de código é usado para definir um arquivo de licença:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides roda em uma máquina virtual Java que mantém o Node.js em execução, portanto termine o processo explicitamente.
process.exit(0);
```

Ao chamar o método setLicense, o nome da licença deve ser o mesmo do seu arquivo de licença. Por exemplo, você pode mudar o nome do arquivo de licença para "Aspose.Slides.lic.xml". Em seguida, no seu código, você deve passar o novo nome da licença (Aspose.Slides.lic.xml) para o método setLicense. Se o arquivo estiver ausente ou não contiver uma licença válida, [setLicense](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/) lança uma exceção, que finaliza o script com um erro.

#### **Aplicando uma Licença a partir de um Stream**

Para aplicar uma licença a partir de um stream, passe o objeto [License](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/) e um stream legível para o método estático [setLicenseFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/license/setlicense/). O stream é lido de forma assíncrona, e o callback recebe um erro se o stream não contiver uma licença válida:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides roda em uma máquina virtual Java que mantém o Node.js em execução, portanto encerre o processo explicitamente.
    process.exit(0);
});
```

A licença é aplicada quando todo o stream foi lido, imediatamente antes do callback ser executado, então inicie outras tarefas do Aspose.Slides a partir do callback.

Ambos os exemplos chamam `process.exit(0)` ao terminar, porque a máquina virtual Java que executa o Aspose.Slides mantém o Node.js em execução. Em uma aplicação, continue com seu código Aspose.Slides ao invés de encerrar o processo.

## **FAQ**

### Posso aplicar a licença em um ambiente completamente offline (sem acesso à internet)?

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão à internet.

### O que acontece depois que a assinatura de um ano expira? A biblioteca deixará de funcionar?

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não poderá usar versões mais recentes sem renovar.