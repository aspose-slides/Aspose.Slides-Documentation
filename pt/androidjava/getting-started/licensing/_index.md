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

Aspose.Slides pode ser usado no modo de avaliação ou com uma licença válida. A versão de avaliação fornece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d'água de avaliação a cada slide de cada apresentação que salva e trunca o texto que seu código lê das apresentações.

Este artigo explica como o licenciamento funciona no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo, fluxo ou recurso incorporado usando a classe [License](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/). O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Avaliar Aspose.Slides**

{{% alert color="info" title="Note" %}}
Você pode baixar uma versão de avaliação do **Aspose.Slides for Android via Java** a partir da sua [download page](https://releases.aspose.com/slides/pt/androidjava/). A versão de avaliação fornece as mesmas funcionalidades que a versão licenciada do produto. O pacote de avaliação é o mesmo do pacote adquirido. A versão de avaliação simplesmente se torna licenciada após você adicionar algumas linhas de código (para aplicar a licença).

Depois de ficar satisfeito com sua avaliação do **Aspose.Slides**, você pode [purchase a license](https://purchase.aspose.com/pricing/slides/pt/android-java/). Recomendamos que você analise os diferentes tipos de assinatura. Se tiver dúvidas, entre em contato com a equipe de vendas da Aspose.

Cada licença Aspose inclui uma assinatura de um ano para atualizações gratuitas para novas versões ou correções lançadas dentro do período de assinatura. Usuários com produtos licenciados (ou mesmo versões de avaliação) recebem suporte técnico gratuito e ilimitado.
{{% /alert %}} 

**Limitações da versão de avaliação**

* A versão de avaliação (sem uma licença especificada) fornece funcionalidade completa do produto, mas adiciona uma caixa de texto de marca d'água de avaliação a cada slide de cada apresentação que salva.
* O texto que seu código lê de uma apresentação é truncado para seus primeiros caracteres, seguidos de um aviso sobre a limitação da avaliação. O texto que seu código grava é salvo integralmente.

{{% alert color="info" title="Note" %}}
Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Consulte a página [How to get a Temporary License](https://purchase.aspose.com/temporary-license) para mais informações.
{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliação se torna licenciada após você adquirir uma licença e adicionar algumas linhas de código (para aplicar a licença).
* A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, número de desenvolvedores licenciados, data de expiração da assinatura, etc.
* O arquivo de licença é assinado digitalmente, portanto não deve ser modificado. Até mesmo a inserção inadvertida de uma quebra de linha extra no conteúdo do arquivo o invalidará.
* Aspose.Slides for Android via Java normalmente tenta encontrar a licença nos seguintes locais:
  * Um caminho explícito
  * A pasta que contém Aspose.Slides.jar
* Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar **Aspose.Slides**. Você só precisa definir a licença uma vez por aplicação ou processo.

## **Aplicando uma Licença**

Uma licença pode ser carregada a partir de um **arquivo** ou **fluxo**.

{{% alert color="info" title="Note" %}}
Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/) para operações de licenciamento.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Novas licenças podem ativar o Aspose.Slides somente a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.
{{% /alert %}}

### **Arquivo**

O método mais simples de definir uma licença requer que você coloque o arquivo de licença na pasta que contém Aspose.Slides.jar ou o JAR da sua aplicação.

{{% alert color="info" title="Note" %}}
No Android, a biblioteca e seu aplicativo são empacotados no APK, portanto não há uma pasta que contenha o arquivo JAR da biblioteca, e um caminho relativo como *Aspose.Slides.Android.via.Java.lic* não aponta para um arquivo no seu aplicativo. Adicione o arquivo de licença aos assets do seu aplicativo e carregue-o a partir de um fluxo, como mostrado em [Stream from App Assets](#stream-from-app-assets).
{{% /alert %}}

Este código Java mostra como definir um arquivo de licença:

``` java
// Instancia a classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Define o caminho do arquivo de licença
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
Se você colocar o arquivo de licença em um diretório diferente, ao chamar o método [setLicense](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) o nome do arquivo de licença ao final do caminho especificado deve ser o mesmo que o nome do seu arquivo de licença.

Por exemplo, você pode alterar o nome do arquivo de licença para *Aspose.Slides.Android.via.Java.lic.xml*. Então, no seu código, você deverá passar o caminho para o arquivo (terminando com *Aspose.Slides.Android.via.Java.lic.xml*) ao método [setLicense](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).
{{% /alert %}}

### **Fluxo**

Você pode carregar uma licença a partir de um fluxo. Este código Java mostra como aplicar uma licença a partir de um fluxo:

``` java
// Instancia a classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Define a licença por meio de um fluxo
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Fluxo a partir de Assets do Aplicativo**

Em um aplicativo Android, coloque o arquivo de licença na pasta *assets* do módulo do aplicativo, *app/src/main/assets*, para que ele seja incluído no APK. Abra o arquivo com o método [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) e passe o fluxo ao método [setLicense](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-). O código é executado dentro de uma `Activity`, por exemplo no método `onCreate`, antes que o aplicativo use o Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

O nome do arquivo passado ao método [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) é relativo à pasta *assets*. Se o arquivo não estiver lá, o código registra o erro, e o Aspose.Slides permanece em modo de avaliação. Para verificar se a licença foi aplicada, veja [Validating a License](#validating-a-license).

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

{{% alert color="warning" title="Warning" %}}
O método [setLicense](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) não é seguro para uso em múltiplas threads. Se esse método precisar ser chamado simultaneamente por várias threads, considere usar primitivas de sincronização (como um lock) para evitar problemas.
{{% /alert %}}

## **FAQ**

### Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão com a internet.

### O que acontece depois que a assinatura de um ano expira? A biblioteca deixará de funcionar?

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não poderá usar versões mais recentes sem renovar.