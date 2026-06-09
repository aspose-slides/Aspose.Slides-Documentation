---
title: Licenciamento
description: "O Aspose.Slides para Node.js via .NET oferece diferentes planos de compra ou disponibiliza um Teste Gratuito e uma Licença Temporária de 30 dias para avaliação, usando políticas de Licenciamento e Assinatura."
type: docs
weight: 80
url: /pt/nodejs-net/licensing/
---
Às vezes, para obter os melhores resultados de avaliação, pode ser necessário um método prático. Por esse motivo, o Aspose.Slides oferece diferentes planos de compra e também disponibiliza um Teste Gratuito e uma Licença Temporária de 30 dias para avaliação.

{{% alert color="primary" %}}
Observe que existem diversas políticas e práticas gerais que orientam como avaliar, licenciar corretamente e adquirir nossos produtos. Você pode encontrá‑las na ["Políticas de Compra e FAQ"](https://purchase.aspose.com/policies) seção.
{{% /alert %}}

## **Avaliar Aspose.Slides**
Você pode baixar o Aspose.Slides facilmente para avaliação. O pacote de avaliação é o mesmo do pacote adquirido. A versão de avaliação simplesmente se torna licenciada após você adicionar algumas linhas de código para aplicar a licença. 

## **Limitação da Versão de Avaliação**
A versão de avaliação do Aspose.Slides (sem uma licença especificada) oferece toda a funcionalidade do produto, mas insere uma marca d'água de avaliação no topo do documento ao abrir e salvar. Você também fica limitado a um slide ao extrair textos de slides de apresentação.

{{% alert color="primary" %}} 
Se você quiser testar o Aspose.Slides sem as limitações da versão de avaliação, pode solicitar uma **Licença Temporária de 30 Dias**. Consulte [Como obter uma Licença Temporária?](https://purchase.aspose.com/temporary-license) para mais informações.
{{% /alert %}} 

## **Sobre a Licença**
Você pode baixar facilmente uma versão de avaliação do Aspose.Slides para Node.js via .NET a partir da sua [página de download](https://releases.aspose.com/slides/pt/nodejs-net/). A versão de avaliação fornece absolutamente **as mesmas capacidades** que a versão licenciada do Aspose.Slides. Além disso, a versão de avaliação simplesmente se torna licenciada após você adquirir uma licença e acrescentar algumas linhas de código para aplicar a licença.

A licença é um arquivo XML em texto puro que contém detalhes como o nome do produto, número de desenvolvedores licenciados, data de validade da assinatura, etc. O arquivo é assinado digitalmente, portanto não modifique o arquivo. Até mesmo a adição inadvertida de uma quebra de linha extra ao conteúdo do arquivo o invalidará.

Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar **Aspose.Slides**. É necessário definir a licença apenas uma vez por aplicação ou processo.

## Licença Adquirida

Após a compra, você precisa aplicar o arquivo ou fluxo de licença. 

{{% alert color="primary" %}}
Você precisa definir a licença:
* apenas uma vez por domínio de aplicação
* antes de usar qualquer outra classe do Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Você pode encontrar informações de preços na página [“Informações de Preços”](https://purchase.aspose.com/pricing/slides/pt/family).
{{% /alert %}}

### **Definindo uma Licença no Aspose.Slides para Node.js via .NET**

As licenças podem ser aplicadas a partir destas localidades:

* Caminho explícito
* Fluxo
* Como Licença por Medição – um novo mecanismo de licenciamento

{{% alert color="primary" %}}
Use o método **setLicense** para licenciar um componente.

Embora chamadas múltiplas ao **setLicense** não sejam prejudiciais, elas desperdiçam recursos (processador).
{{% /alert %}}

{{% alert color="warning" %}}
Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.
{{% /alert %}}

#### **Aplicando uma Licença Usando um Arquivo**

Este trecho de código é usado para definir um arquivo de licença:

**Node.js**

```javascript
// Importe o módulo Aspose.Slides para manipulação de arquivos PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Esta função configura a biblioteca Aspose.Slides com uma licença
function setupAsposeSlidesLicense() {
    
    // Inicialize a classe License do módulo Aspose.Slides
    var license = new asposeSlides.License();
    
    // Aplique a licença a partir de um arquivo
    // Substitua "your_license_file.lic" pelo caminho do seu arquivo de licença real
    license.setLicense("your_license_file.lic");
}

// Execute a função para configurar a licença do Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
Ao chamar o método setLicense, o nome da licença deve ser o mesmo do seu arquivo de licença. Por exemplo, você pode alterar o nome do arquivo de licença para "Aspose.Slides.lic.xml". Em seguida, no seu código, você deve passar o novo nome da licença (Aspose.Slides.lic.xml) para o método setLicense.
{{% /alert %}}