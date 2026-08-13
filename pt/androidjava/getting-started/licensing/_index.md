---
title: Licenciamento
type: docs
weight: 90
url: /pt/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Aplique, gerencie e solucione problemas de licenças no Aspose.Slides for Android via Java. Garanta acesso ininterrupto a todos os recursos com nosso guia de licenciamento."
---
## **Visão geral**

Aspose.Slides pode ser usado no modo de avaliação ou com uma licença válida. A versão de avaliação fornece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d'água de avaliação quando as apresentações são abertas ou salvas e limita a extração de texto a um slide.

Este artigo explica como funciona o licenciamento no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo, fluxo ou recurso incorporado usando a classe `License`. O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Avaliar Aspose.Slides**

{{% alert color="info" %}} 

Você pode baixar uma versão de avaliação do **Aspose.Slides for Android via Java** a partir da sua [página de download](https://releases.aspose.com/slides/pt/androidjava/). A versão de avaliação fornece as mesmas funcionalidades que a versão licenciada do produto. O pacote de avaliação é o mesmo do pacote adquirido. A versão de avaliação simplesmente se torna licenciada após você adicionar algumas linhas de código a ela (para aplicar a licença).

Uma vez satisfeito com sua avaliação do **Aspose.Slides**, você pode [adquirir uma licença](https://purchase.aspose.com/buy). Recomendamos que você examine os diferentes tipos de assinatura. Se tiver dúvidas, entre em contato com a equipe de vendas da Aspose.

Cada licença Aspose inclui uma assinatura de um ano para atualizações gratuitas para novas versões ou correções lançadas durante o período da assinatura. Usuários com produtos licenciados (ou mesmo versões de avaliação) recebem suporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitações da versão de avaliação**

* Enquanto a versão de avaliação do Aspose.Slides (sem uma licença especificada) fornece a funcionalidade completa do produto, ela insere uma marca d'água de avaliação no topo do documento nas operações de abertura e salvamento. 
* Você está limitado a um slide ao extrair textos das apresentações.

{{% alert color="info" %}} 

Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 Dias**. Veja a página [How to get a Temporary License](https://purchase.aspose.com/temporary-license) para mais informações.

{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliação se torna licenciada após você adquirir uma licença e adicionar algumas linhas de código a ela (para aplicar a licença).
* A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, número de desenvolvedores para os quais está licenciado, data de expiração da assinatura, etc. 
* O arquivo de licença é assinado digitalmente, portanto você não deve modificá-lo. Até mesmo a adição inadvertida de uma quebra de linha extra ao conteúdo do arquivo o invalidará.
* Aspose.Slides for Android via Java normalmente tenta encontrar a licença nesses locais:
  * Um caminho explícito
  * A pasta que contém Aspose.Slides.jar
* Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar o **Aspose.Slides**. Você só precisa definir uma licença uma vez por aplicativo ou processo.

## **Aplicando uma Licença**

Uma licença pode ser carregada a partir de um **arquivo** ou **fluxo**.

{{% alert color="info" %}}

Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/) para operações de licenciamento.

{{% /alert %}} 

{{% alert color="warning" %}}

Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores usam um sistema de licenciamento diferente e não reconhecerão essas licenças.

{{% /alert %}}

### **Arquivo**

O método mais simples de definir uma licença requer que você coloque o arquivo de licença na pasta que contém Aspose.Slides.jar ou o jar do seu aplicativo.

Este código Java mostra como definir um arquivo de licença:

``` java
// Instancia a classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Define o caminho do arquivo de licença
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Se você colocar o arquivo de licença em um diretório diferente, ao chamar o método [SetLicense](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-), o nome do arquivo de licença no final do caminho explícito especificado deve ser o mesmo que o seu arquivo de licença.

Por exemplo, você pode mudar o nome do arquivo de licença para *Aspose.Slides.Android.via.Java.lic.xml*. Então, no seu código, você deve passar o caminho para o arquivo (terminando com *Aspose.Slides.Android.via.Java.lic.xml*) ao método [SetLicense](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Fluxo**

Você pode carregar uma licença a partir de um fluxo. Este código Java mostra como aplicar uma licença a partir de um fluxo:

``` java
// Instancia a classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Define a licença através de um fluxo
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Validando uma Licença**

Para verificar se uma licença foi definida corretamente, você pode validá‑la. Este código Java mostra como validar uma licença:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Segurança de Thread**

{{% alert title="Note" color="warning" %}} 

O método [SetLicense](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) não é seguro para uso em múltiplas threads. Se esse método precisar ser chamado simultaneamente por várias threads, você pode querer usar primitivas de sincronização (como um lock) para evitar problemas. 

{{% /alert %}}

## **FAQ**

### Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão à internet.

### O que acontece depois que a assinatura de um ano expira? A biblioteca deixará de funcionar?

Não. A licença é permanente: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; você simplesmente não poderá usar versões mais recentes sem renovar.