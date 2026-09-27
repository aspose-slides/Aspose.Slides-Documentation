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
description: "Aprenda como aplicar, gerenciar e solucionar problemas de licenças no Aspose.Slides para Python via .NET. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Visão geral**

Aspose.Slides pode ser usado no modo de avaliação ou com uma licença válida. A versão de avaliação fornece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d’água de avaliação a cada slide de cada apresentação que salva e trunca o texto que seu código lê das apresentações.

## **Avaliar Aspose.Slides**

Você pode baixar uma versão de avaliação do **Aspose.Slides for Python via .NET** na sua [página de download](https://pypi.org/project/Aspose.Slides/). A versão de avaliação fornece os mesmos recursos do produto licenciado. O pacote de avaliação é idêntico ao pacote adquirido e passa a ser licenciado após você adicionar algumas linhas de código para aplicar a licença.

Quando estiver satisfeito com a avaliação do **Aspose.Slides**, você pode [adquirir uma licença](https://purchase.aspose.com/pricing/slides/pt/python-net/). Recomendamos rever as opções de assinatura disponíveis. Se tiver dúvidas, entre em contato com a equipe de vendas da Aspose.

Toda licença Aspose inclui uma assinatura de um ano com upgrades gratuitos para novas versões e correções lançadas durante esse período. Tanto usuários licenciados quanto de avaliação recebem suporte técnico gratuito e ilimitado.

**Limitações da Versão de Avaliação**

* A versão de avaliação (quando nenhuma licença é aplicada) oferece funcionalidade completa, mas adiciona uma caixa de texto de marca d’água de avaliação a cada slide de cada apresentação que salva.
* O texto que seu código lê de uma apresentação é truncado para os primeiros caracteres, seguido de um aviso sobre a limitação da avaliação. O texto que seu código grava é salvo integralmente.

{{% alert color="info" title="Note" %}}
Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Consulte a página [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) para detalhes.
{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliação se torna licenciada após você comprar uma licença e adicionar algumas linhas de código para aplicá‑la.
* A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, o número de desenvolvedores cobertos, a data de expiração da assinatura, etc.
* O arquivo de licença é assinado digitalmente, portanto não deve ser modificado. Mesmo a inserção de uma única quebra de linha o invalidará.
* Aspose.Slides for Python via .NET procura a licença no caminho que você fornece. Um caminho relativo ou um nome de arquivo sem caminho é resolvido em relação ao diretório de trabalho atual, que nem sempre é a pasta que contém seu script Python.
* Para evitar as limitações da avaliação, defina a licença antes de usar o Aspose.Slides. Você só precisa defini‑la uma vez por aplicação ou processo.

{{% alert color="info" title="Note" %}}
Você também pode querer consultar [Metered Licensing](/slides/pt/python-net/metered-licensing/).
{{% /alert %}}

## **Aplicando uma Licença**

Uma licença pode ser carregada a partir de um **arquivo** ou de um **stream**.

{{% alert color="info" title="Note" %}}
Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/) para lidar com licenciamento.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores usam um sistema de licenciamento diferente e não reconhecerão essas licenças.
{{% /alert %}}

### **Arquivo**

A maneira mais simples de definir uma licença é passar o caminho do arquivo de licença para o método [set_license](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/set_license/). Se você passar apenas o nome do arquivo, como no exemplo abaixo, o Aspose.Slides procura o arquivo no diretório de trabalho atual.

O código Python a seguir mostra como definir o arquivo de licença:

```py
import aspose.slides as slides

# Instancia a classe License.
license = slides.License()

# Define o caminho do arquivo de licença.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
Se você colocar o arquivo de licença em outro diretório, ao chamar [License.set_license](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/set_license/#str), o nome do arquivo ao final do caminho explícito deve coincidir com o nome do seu arquivo de licença.

Por exemplo, você pode renomear o arquivo de licença para *Aspose.Slides.lic.xml*. Então, no seu código, passe o caminho completo para esse arquivo (terminando com Aspose.Slides.lic.xml) ao método [License.set_license](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Stream**

Você pode carregar uma licença a partir de um stream. O exemplo Python a seguir demonstra como aplicar uma licença a partir de um stream:

```py
import aspose.slides as slides

# Instancia a classe License.
license = slides.License()

# Define a licença a partir de um stream.
with open("Aspose.Slides.lic", "rb") as stream:
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

## **Segurança de Thread**

{{% alert color="warning" title="Warning" %}}
O método [License.set_license](https://reference.aspose.com/slides/pt/python-net/aspose.slides/license/set_license/) não é seguro para uso em múltiplas threads. Se precisar chamá‑lo simultaneamente a partir de várias threads, use um mecanismo de sincronização, como `threading.Lock`, para evitar problemas.
{{% /alert %}}

## **FAQ**

### Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?

Sim. A validação da licença é feita localmente usando o arquivo de licença; não é necessária conexão com a internet.

### O que acontece depois que a assinatura de um ano expira? A biblioteca deixa de funcionar?

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não será elegível a usar versões mais recentes sem renovação.