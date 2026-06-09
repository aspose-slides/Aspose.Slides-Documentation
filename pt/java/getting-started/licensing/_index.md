---
title: Licenciamento
type: docs
weight: 90
url: /pt/java/licensing/
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
- Java
- Aspose.Slides
description: "Aplicar, gerenciar e solucionar problemas de licenças no Aspose.Slides for Java. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Visão geral**

Aspose.Slides pode ser usado no modo de avaliação ou com uma licença válida. A versão de avaliação fornece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d'água de avaliação quando as apresentações são abertas ou salvas e limita a extração de texto a um slide.

Este artigo explica como funciona o licenciamento no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo, fluxo ou recurso incorporado usando a classe `License`. O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Avaliar Aspose.Slides**

{{% alert color="primary" %}} 

Você pode baixar uma versão de avaliação do **Aspose.Slides for Java** a partir de sua [página de download](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). A versão de avaliação fornece as mesmas funcionalidades que a versão licenciada do produto. O pacote de avaliação é o mesmo que o pacote adquirido. A versão de avaliação simplesmente se torna licenciada depois que você adiciona algumas linhas de código (para aplicar a licença).

Quando estiver satisfeito com sua avaliação do **Aspose.Slides**, você pode [comprar uma licença](https://purchase.aspose.com/buy). Recomendamos que você analise os diferentes tipos de assinatura. Se tiver dúvidas, entre em contato com a equipe de vendas da Aspose.

Cada licença Aspose inclui uma assinatura de um ano para atualizações gratuitas para novas versões ou correções lançadas dentro do período de assinatura. Usuários com produtos licenciados (ou mesmo versões de avaliação) recebem suporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitações da versão de avaliação**

* Embora a versão de avaliação do Aspose.Slides (sem uma licença especificada) forneça a funcionalidade completa do produto, ela insere uma marca d'água de avaliação no topo do documento nas operações de abertura e salvamento. 
* Você está limitado a um slide ao extrair textos de apresentações.

{{% alert color="primary" %}} 

Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Consulte a página [Como obter uma Licença Temporária](https://purchase.aspose.com/temporary-license) para mais informações.

{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliação se torna licenciada depois que você compra uma licença e adiciona algumas linhas de código (para aplicar a licença).
* A licença é um arquivo XML em texto simples que contém detalhes como o nome do produto, número de desenvolvedores licenciados, data de vencimento da assinatura, etc. 
* O arquivo de licença é assinado digitalmente, portanto você não deve modificar o arquivo. Mesmo a inserção inadvertida de uma quebra de linha extra no conteúdo do arquivo o invalidará.
* Aspose.Slides for Java normalmente tenta encontrar a licença nos seguintes locais:
  * Um caminho explícito
  * A pasta que contém Aspose.Slides.jar
* Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar **Aspose.Slides**. Você só precisa definir a licença uma vez por aplicação ou processo.

{{% alert color="primary" %}} 

Você pode querer ver [Licenciamento Medido](/slides/pt/java/metered-licensing/).

{{% /alert %}} 


## **Aplicando uma Licença**

Uma licença pode ser carregada a partir de um **arquivo** ou **fluxo**.

{{% alert color="primary" %}}

Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/java/com.aspose.slides/License) para operações de licenciamento.

{{% /alert %}} 

{{% alert color="warning" %}}

Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.

{{% /alert %}}

### **Arquivo**

O método mais simples de definir uma licença requer que você coloque o arquivo de licença na pasta que contém Aspose.Slides.jar ou o jar da sua aplicação.

Este código Java mostra como definir um arquivo de licença:

``` java
// Instancia a classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Define o caminho do arquivo de licença
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Se você colocar o arquivo de licença em um diretório diferente, ao chamar o método [SetLicense](https://reference.aspose.com/slides/pt/java/com.aspose.slides/License#setLicense-java.lang.String-), o nome do arquivo de licença no final do caminho explícito especificado deve ser o mesmo do seu arquivo de licença.

Por exemplo, você pode mudar o nome do arquivo de licença para *Aspose.Slides.Java.lic.xml*. Então, no seu código, você deve passar o caminho para o arquivo (terminando com *Aspose.Slides.Java.lic.xml*) para o método [SetLicense](https://reference.aspose.com/slides/pt/java/com.aspose.slides/License#setLicense-java.lang.String-).

{{% /alert %}}

### **Fluxo**

Você pode carregar uma licença a partir de um fluxo. Este código Java mostra como aplicar uma licença a partir de um fluxo:

``` java
// Instancia a classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Define a licença por meio de um fluxo
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Se você usar Aspose.Slides para PHP via Java, pode definir uma licença através de uma ponte PHP/Java. Essa ponte permite usar classes Java com sintaxe PHP. Para mais informações, consulte [Licença em PHP](/slides/pt/php-java/licensing/).

## **Validando uma Licença**

Para verificar se uma licença foi definida corretamente, você pode validá‑la. Este código Java mostra como validar uma licença:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Segurança de Thread**

{{% alert title="Note" color="warning" %}} 

O método [SetLicense](https://reference.aspose.com/slides/pt/java/com.aspose.slides/License#setLicense-java.io.InputStream-) não é seguro para uso simultâneo em múltiplas threads. Se esse método precisar ser chamado simultaneamente por várias threads, você pode querer usar primitivas de sincronização (como um lock) para evitar problemas. 

{{% /alert %}}

## **FAQ**

**Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?**

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão com a internet.

**O que acontece após a expiração da assinatura de um ano? A biblioteca deixará de funcionar?**

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; simplesmente não poderá usar versões mais recentes sem renovação.