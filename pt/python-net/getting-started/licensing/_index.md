---
title: Licenciamento
type: docs
weight: 80
url: /pt/python-net/licensing/
keywords:
- licença
- licença temporária
- definir licença
- usar licença
- validar licença
- arquivo de licença
- versão de avaliação
- Python
- Aspose.Slides
description: "Aprenda a aplicar, gerenciar e solucionar problemas de licenças no Aspose.Slides for Python via .NET. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Visão geral**

O Aspose.Slides pode ser usado no modo de avaliação ou com uma licença válida. A versão de avaliação oferece a mesma funcionalidade da versão licenciada, porém adiciona uma marca d'água de avaliação quando as apresentações são abertas ou salvas e limita a extração de texto a um slide.

## **Avaliar Aspose.Slides**

Você pode baixar uma versão de avaliação do **Aspose.Slides for Python via .NET** em sua [página de download](https://pypi.org/project/Aspose.Slides/). A versão de avaliação oferece os mesmos recursos do produto licenciado. O pacote de avaliação é idêntico ao pacote adquirido e passa a ser licenciado após você adicionar algumas linhas de código para aplicar a licença.

Quando estiver satisfeito com sua avaliação do **Aspose.Slides**, você pode [comprar uma licença](https://purchase.aspose.com/buy). Recomendamos revisar as opções de assinatura disponíveis. Se tiver dúvidas, entre em contato com a equipe de vendas da Aspose.

Toda licença da Aspose inclui uma assinatura de um ano com atualizações gratuitas para novas versões e correções lançadas durante esse período. Usuários licenciados e em avaliação recebem suporte técnico gratuito e ilimitado.

**Limitações da Versão de Avaliação**

* Embora a versão de avaliação do Aspose.Slides (quando nenhuma licença é aplicada) ofereça funcionalidade completa, ela adiciona uma marca d'água de avaliação no topo do documento sempre que você o abre ou salva.
* Ao extrair texto de uma apresentação, você fica limitado a um slide.

{{% alert color="primary" %}}
Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Consulte a página [Como obter uma Licença Temporária](https://purchase.aspose.com/temporary-license) para obter detalhes.
{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliação se torna licenciada após a compra de uma licença e a adição de algumas linhas de código para aplicá‑la.
* A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, o número de desenvolvedores cobertos, a data de expiração da assinatura, etc.
* O arquivo de licença é assinado digitalmente, portanto não deve ser modificado. Mesmo a inserção de uma única quebra de linha o invalidará.
* O Aspose.Slides for Python via .NET normalmente procura a licença nos seguintes locais:
  * Um caminho explícito que você fornece
  * A pasta que contém o script Python que chama o Aspose.Slides for Python via .NET
* Para evitar as limitações da avaliação, defina a licença antes de usar o Aspose.Slides. Você precisa configurá‑la apenas uma vez por aplicação ou processo.

{{% alert color="primary" %}}
Você também pode desejar revisar [Licenciamento Medido](/slides/pt/python-net/metered-licensing/).
{{% /alert %}}

## **Aplicando uma Licença**

Uma licença pode ser carregada a partir de um **arquivo**, **stream** ou **recurso incorporado**. 

{{% alert color="primary" %}}
O Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/) para gerenciar licenças.
{{% /alert %}}

{{% alert color="warning" %}}
Novas licenças podem ativar o Aspose.Slides somente a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.
{{% /alert %}}

### **Arquivo**

A maneira mais simples de definir uma licença é colocar o arquivo de licença na mesma pasta da DLL do componente e especificar apenas o nome do arquivo (sem caminho).

O código Python a seguir demonstra como definir o arquivo de licença:

```py
import aspose.slides as slides

# Instancia a classe License. 
license = slides.License()

# Define o caminho do arquivo de licença.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
Se você colocar o arquivo de licença em um diretório diferente, ao chamar [License.set_license()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/set_license/#str), o nome do arquivo no final do caminho explícito deve corresponder ao nome do seu arquivo de licença.

Por exemplo, você pode renomear o arquivo de licença para *Aspose.Slides.lic.xml*. Em seguida, no seu código, passe o caminho completo para esse arquivo (terminando com Aspose.Slides.lic.xml) ao método [License.set_license()](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Stream**

Você pode carregar uma licença a partir de um stream. O exemplo Python a seguir mostra como aplicar uma licença a partir de um stream:

```py
import aspose.slides as slides

# Instancia a classe License.
license = slides.License()

# Define a licença a partir de um stream.
license.set_license(stream)
```

## **Validando uma Licença**

Para verificar se a licença foi aplicada corretamente, você pode validá‑la. O código Python a seguir demonstra como validar uma licença:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Segurança em Thread**

{{% alert title="Note" color="warning" %}}
Os métodos [License.set_license](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/) não são seguros para uso em múltiplas threads. Se precisar chamá‑los simultaneamente a partir de várias threads, use primitivas de sincronização (por exemplo, `threading.Lock`) para evitar problemas.
{{% /alert %}}

## **FAQ**

**Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?**

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão com a internet.

**O que acontece depois que a assinatura de um ano expira? A biblioteca deixará de funcionar?**

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não será elegível para usar versões mais recentes sem renovação.