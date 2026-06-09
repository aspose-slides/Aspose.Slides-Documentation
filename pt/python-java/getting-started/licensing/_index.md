---
title: Licenciamento
description: "Aspose.Slides para Python via Java oferece diferentes planos de compra ou disponibiliza um Teste Gratuito e uma Licença Temporária de 30 dias para avaliação, usando políticas de Licenciamento e Assinatura."
type: docs
weight: 80
url: /pt/python-java/licensing/
---
Às vezes, para obter os melhores resultados de avaliação, pode ser necessário uma abordagem prática. Por esse motivo, a Aspose.Slides oferece diferentes planos de compra e também disponibiliza um Teste Gratuito e uma Licença Temporária de 30 dias para avaliação.

{{% alert color="primary" %}}
Observe que existem diversas políticas e práticas gerais que orientam como avaliar, licenciar adequadamente e comprar nossos produtos. Você pode encontrá‑las na ["Políticas de Compra e FAQ"](https://purchase.aspose.com/policies) seção.
{{% /alert %}}

## **Avaliar Aspose.Slides**
Você pode baixar facilmente o Aspose.Slides para avaliação. O pacote de avaliação é o mesmo que o pacote adquirido. A versão de avaliação simplesmente se torna licenciada após você adicionar algumas linhas de código para aplicar a licença. 

## **Limitação da Versão de Avaliação**
A versão de avaliação do Aspose.Slides (sem uma licença especificada) oferece toda a funcionalidade do produto, mas insere uma marca d'água de avaliação no topo do documento ao abrir e salvar. Você também está limitado a um slide ao extrair textos dos slides de apresentação.

{{% alert color="primary" %}} 
Se você quiser testar o Aspose.Slides sem as limitações da versão de avaliação, pode solicitar uma **Licença Temporária de 30 Dias**. Consulte [Como obter uma Licença Temporária?](https://purchase.aspose.com/temporary-license) para mais informações.
{{% /alert %}} 

## **Sobre a Licença**
Você pode baixar facilmente uma versão de avaliação do Aspose.Slides para Python via Java a partir de sua [página de download](https://releases.aspose.com/slides/pt/python-java/). A versão de avaliação oferece absolutamente **as mesmas capacidades** da versão licenciada do Aspose.Slides. Além disso, a versão de avaliação simplesmente se torna licenciada após você comprar uma licença e adicionar algumas linhas de código para aplicar a licença.

A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, número de desenvolvedores aos quais está licenciada, data de validade da assinatura, entre outros. O arquivo é assinado digitalmente, portanto não modifique o arquivo. Mesmo a adição inadvertida de uma quebra de linha extra ao conteúdo do arquivo invalidará a licença.

Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar **Aspose.Slides**. É necessário definir a licença apenas uma vez por aplicação ou processo.

## Licença Adquirida

Após a compra, você precisa aplicar o arquivo ou stream da licença. 

{{% alert color="primary" %}}
Você precisa definir a licença:
* apenas uma vez por domínio de aplicação
* antes de usar qualquer outra classe do Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Você pode encontrar informações de preço na [“Informações de Preço”](https://purchase.aspose.com/pricing/slides/pt/family) página.
{{% /alert %}}

### **Definindo uma Licença no Aspose.Slides para Python via Java**

Licenças podem ser aplicadas a partir destas fontes:

* Caminho explícito
* Stream
* Como Licença Medida – um novo mecanismo de licenciamento

{{% alert color="primary" %}}
Use o método **setLicense** para licenciar um componente.

Embora várias chamadas ao **setLicense** não sejam prejudiciais, elas desperdiçam recursos (processador).
{{% /alert %}}

{{% alert color="warning" %}}
Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.
{{% /alert %}}

#### **Aplicando uma Licença Usando um Arquivo**

Este trecho de código é usado para definir um arquivo de licença:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Ao chamar o método setLicense, o nome da licença deve ser o mesmo do seu arquivo de licença. Por exemplo, você pode alterar o nome do arquivo de licença para "Aspose.Slides.lic.xml". Em seguida, no seu código, você deve passar o novo nome da licença (Aspose.Slides.lic.xml) para o método setLicense.

#### **Aplicando uma Licença a partir de Bytes**

Este trecho de código é usado para aplicar uma licença a partir de bytes:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Aplicar Licença Medida

O Aspose.Slides permite que desenvolvedores apliquem uma chave medida. Este é um novo mecanismo de licenciamento.

O novo mecanismo de licenciamento será usado juntamente com o método de licenciamento existente. Clientes que desejam ser cobrados com base no uso de recursos da API podem usar o Licenciamento Medido.

Após concluir todas as etapas necessárias para obter esse tipo de licença, você receberá as chaves, não o arquivo de licença. Essa chave medida pode ser aplicada usando a classe **Metered** especialmente introduzida para esse propósito.

O exemplo de código a seguir mostra como definir chaves públicas e privadas medidas:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Crie uma instância da classe CAD Metered
metered = Metered();

# Acesse a propriedade set_metered_key e passe as chaves pública e privada como parâmetros
metered.setMeteredKey("*****", "*****");

# Obtenha a quantidade de dados medidos antes de chamar a API
amountbefore = Metered.getConsumptionQuantity()

# Exiba informações
print("Amount Consumed Before: \" + amountbefore + \"" )

# Carregue o documento do disco.
pres = Presentation();

# Obtenha a contagem de páginas do documento
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# salve como PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Obtenha a quantidade de dados medidos após chamar a API
amountafter = Metered.getConsumptionQuantity()

# Exiba informações
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Observe que você deve ter uma conexão de Internet estável para o uso correto da licença Medida, pois o mecanismo Medido requer interação constante com nossos serviços para cálculos corretos. Para mais detalhes, consulte a [“FAQ de Licenciamento Medido](https://purchase.aspose.com/faqs/licensing/metered) seção.
{{% /alert %}}