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
description: "Aplicar, gerenciar e solucionar problemas de licenças no Aspose.Slides para Java. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Visão geral**

Aspose.Slides pode ser usado no modo de avaliação ou com uma licença válida. A versão de avaliação oferece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d'água de avaliação a cada slide de cada apresentação que salva e trunca o texto que seu código lê através da API.

Este artigo explica como o licenciamento funciona no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo, fluxo ou recurso incorporado usando a classe `License`. O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Avaliar Aspose.Slides**

{{% alert color="info" title="Note" %}}

Você pode baixar uma versão de avaliação do **Aspose.Slides for Java** a partir da sua [página de download](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). A versão de avaliação fornece as mesmas funcionalidades da versão licenciada do produto. O pacote de avaliação é o mesmo do pacote adquirido. A versão de avaliação simplesmente se torna licenciada depois que você adiciona algumas linhas de código a ela (para aplicar a licença).

Depois de ficar satisfeito com a avaliação do **Aspose.Slides**, você pode [adquirir uma licença](https://purchase.aspose.com/pricing/slides/java/). Recomendamos que você analise os diferentes tipos de assinatura. Se tiver dúvidas, entre em contato com a equipe de vendas da Aspose.

Toda licença Aspose inclui uma assinatura de um ano para atualizações gratuitas para novas versões ou correções lançadas dentro do período de assinatura. Usuários com produtos licenciados (ou até mesmo versões de avaliação) recebem suporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitações da versão de avaliação**

* A versão de avaliação (sem uma licença especificada) oferece funcionalidade total do produto, mas adiciona uma caixa de texto de marca d'água de avaliação a cada slide de cada apresentação que salva.
* O texto que seu código lê através da API, incluindo o texto que acabou de definir, é truncado para os primeiros caracteres, seguido por um aviso sobre a limitação de avaliação. O texto que seu código grava é salvo integralmente.

{{% alert color="info" title="Note" %}}

Para testar Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Consulte a página [Como obter uma Licença Temporária](https://purchase.aspose.com/temporary-license) para mais informações.

{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliação se torna licenciada após você adquirir uma licença e adicionar algumas linhas de código (para aplicar a licença).
* A licença é um arquivo XML de texto simples que contém detalhes como nome do produto, número de desenvolvedores licenciados, data de expiração da assinatura, etc.
* O arquivo de licença é assinadigitalmente, portanto você não deve modificá‑lo. Mesmo a adição inadvertida de uma quebra de linha extra ao conteúdo do arquivo o invalidará.
* Aspose.Slides for Java normalmente tenta localizar a licença nos seguintes locais:
  * Um caminho explícito
  * A pasta que contém Aspose.Slides.jar
* Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar **Aspose.Slides**. Você só precisa definir a licença uma vez por aplicação ou processo.

{{% alert color="info" title="Note" %}}

Talvez você queira ver [Licenciamento Medido](/slides/pt/java/metered-licensing/).

{{% /alert %}} 


## **Aplicando uma Licença**

Uma licença pode ser carregada a partir de um **arquivo** ou **fluxo**.

{{% alert color="info" title="Note" %}}

Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/) para operações de licenciamento.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Novas licenças podem ativar Aspose.Slides somente a partir da versão 21.4 ou posterior. Versões anteriores usam um sistema de licenciamento diferente e não reconhecerão essas licenças.

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

{{% alert color="warning" title="Warning" %}}

Se você colocar o arquivo de licença em um diretório diferente, ao chamar o método [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-), o nome do arquivo de licença ao final do caminho especificado deve ser o mesmo do seu arquivo de licença.

Por exemplo, você pode alterar o nome do arquivo de licença para *Aspose.Slides.Java.lic.xml*. Então, no seu código, você deverá passar o caminho para o arquivo (terminando com *Aspose.Slides.Java.lic.xml*) ao método [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-).

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

Se você usar Aspose.Slides para PHP via Java, pode definir uma licença através de uma ponte PHP/Java. Essa ponte permite usar classes Java na sintaxe PHP. Para mais informações, veja [Licença em PHP](/slides/pt/php-java/licensing/).

## **Validando uma Licença**

Para verificar se uma licença foi configurada corretamente, você pode validá‑la. Este código Java mostra como validar uma licença:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Segurança de Threads**

{{% alert color="warning" title="Warning" %}}

O método [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) não é seguro para uso em múltiplas threads. Se este método precisar ser chamado simultaneamente por várias threads, considere usar primitivas de sincronização (como um lock) para evitar problemas.

{{% /alert %}}

## **Perguntas Frequentes**

### Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?

Sim. A validação da licença é feita localmente usando o arquivo de licença; não é necessária conexão com a internet.

### O que acontece após a expiração da assinatura de um ano? A biblioteca deixa de funcionar?

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não terá direito a versões mais recentes sem renovação.