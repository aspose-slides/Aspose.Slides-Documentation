---
title: Licenciamento Medido
type: docs
weight: 100
url: /pt/python-java/metered-licensing/
keywords:
- licença
- licença medida
- chaves de licença
- chave pública
- chave privada
- quantidade de consumo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Saiba como o licenciamento medido do Aspose.Slides para Python via Java permite processar arquivos PowerPoint e OpenDocument de forma flexível, pagando apenas pelo que você usar."
---
## **Introdução**

Licenciamento medido é um mecanismo de licenciamento que pode ser usado juntamente com os métodos de licenciamento existentes. Se você deseja ser cobrado com base no uso dos recursos da API Aspose.Slides, escolha o licenciamento medido.

## **Aplicar chaves medidas**

{{% alert color="info" title="Nota" %}}

Licenciamento medido é um novo mecanismo de licenciamento que pode ser usado juntamente com os métodos de licenciamento existentes. Se você deseja ser cobrado com base no uso dos recursos da API Aspose.Slides, escolha o licenciamento medido.

Ao comprar uma licença medida, você recebe chaves (e não um arquivo de licença). Essa chave medida pode ser aplicada usando a classe [Metered](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/) fornecida pela Aspose para operações de medição. Para mais detalhes, consulte a [FAQ de Licenciamento Medido](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Crie uma instância da classe [Metered](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/).

1. Passe suas chaves pública e privada para o método [setMeteredKey](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/#setMeteredKey).

1. Execute algum processamento (realize tarefas).

1. Chame o método [getConsumptionQuantity](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/#getConsumptionQuantity) da classe [Metered](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/).

Você deverá ver a quantidade de solicitações de API consumidas até o momento.

Este código de exemplo mostra como usar o licenciamento medido:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Crie uma instância da classe Metered.
metered = Metered()

try:
    # Passe as chaves pública e privada para o objeto Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Obtenha a quantidade consumida antes das chamadas da API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Faça algo com a API Aspose.Slides aqui.
    # ...

    # Obtenha a quantidade consumida após as chamadas da API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Aviso"  %}}

Para usar o licenciamento medido, você precisa de uma conexão de internet estável, pois o mecanismo de licenciamento usa a internet para interagir constantemente com nossos serviços e executar cálculos.

{{% /alert %}}

## **FAQ**

**Posso usar uma licença medida junto com uma licença regular (perpétua ou temporária) na mesma aplicação?**

Sim. Licenciamento medido é um mecanismo adicional que pode ser usado juntamente com os [métodos de licenciamento](/slides/pt/python-java/licensing/). Você escolhe qual mecanismo aplicar quando a aplicação inicia.

**O que exatamente conta como consumo em uma licença medida: operações ou arquivos?**

O consumo conta o uso da API, ou seja, o número de solicitações ou operações. Você pode obter o consumo atual via [métodos de acompanhamento de consumo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/).

**Licenciamento medido é adequado para microsserviços e ambientes serverless onde as instâncias reiniciam com frequência?**

Sim. Como a contabilização é feita no nível de chamada de API, cenários com reinícios frequentes são compatíveis, desde que haja acesso de rede estável para os cálculos medidos.

**A funcionalidade da biblioteca difere ao usar uma licença medida comparada a uma licença perpétua?**

Não. Isso afeta apenas o mecanismo de licenciamento e cobrança; as capacidades do produto permanecem as mesmas.

**Como o licenciamento medido se relaciona com a versão de avaliação e a licença temporária?**

A versão de avaliação tem limitações e marcas d'água, a [licença temporária](https://purchase.aspose.com/temporary-license/) remove as limitações por 30 dias, e o licenciamento medido remove as limitações e cobra com base no uso real.

**Posso controlar o orçamento reagindo automaticamente quando um limite de consumo for ultrapassado?**

Sim. Uma prática comum é ler periodicamente o consumo atual via [métodos de acompanhamento](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/) e implementar seus próprios limites ou alertas no nível da aplicação ou de monitoramento.