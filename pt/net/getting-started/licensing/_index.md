---
title: Licenciamento
type: docs
weight: 80
url: /pt/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Aplique, gerencie e solucione problemas de licenças no Aspose.Slides for .NET. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Visão geral**

Aspose.Slides pode ser usado no modo de avaliação ou com uma licença válida. A versão de avaliação fornece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d'água de avaliação a cada slide de cada apresentação que salva e trunca o texto que seu código lê das apresentações.

Este artigo explica como o licenciamento funciona no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo, fluxo ou recurso incorporado usando a classe `License`. O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Evaluate Aspose.Slides**
{{% alert color="info" title="Note" %}}

Você pode baixar uma versão de avaliação do **Aspose.Slides for .NET** a partir da [sua página de download no NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). A versão de avaliação fornece as mesmas funcionalidades da versão licenciada do produto. O pacote de avaliação é o mesmo que o pacote adquirido. A versão de avaliação simplesmente torna-se licenciada depois que você adiciona algumas linhas de código (para aplicar a licença).

Quando ficar satisfeito com sua avaliação do **Aspose.Slides**, você pode [adquirir uma licença](https://purchase.aspose.com/pricing/slides/pt/net/). Recomendamos que você analise os diferentes tipos de assinatura. Se tiver dúvidas, entre em contato com a equipe de vendas da Aspose.

Todas as licenças Aspose vêm com uma assinatura de um ano para atualizações gratuitas a novas versões ou correções lançadas dentro do período de assinatura. Usuários com produtos licenciados ou mesmo versões de avaliação recebem suporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitações da versão de avaliação**

* A versão de avaliação (sem uma licença especificada) fornece a funcionalidade completa do produto, mas adiciona uma caixa de texto de marca d'água de avaliação a cada slide de cada apresentação que salva.
* O texto que seu código lê de uma apresentação é truncado aos primeiros caracteres, seguido por um aviso sobre a limitação da avaliação. O texto que seu código grava é salvo integralmente.

{{% alert color="info" title="Note" %}}

Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Consulte a página [How to get a Temporary License](https://purchase.aspose.com/temporary-license) para mais informações.

{{% /alert %}}

## **Licensing in Aspose.Slides**
* Uma versão de avaliação torna‑se licenciada depois que você adquire uma licença e adiciona algumas linhas de código (para aplicar a licença).
* A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, número de desenvolvedores para os quais está licenciada, data de expiração da assinatura, entre outros.
* O arquivo de licença é assinado digitalmente, portanto você não deve modificá‑lo. Até mesmo a adição inadvertida de uma quebra de linha extra ao conteúdo do arquivo o invalidará.
* Aspose.Slides for .NET normalmente tenta encontrar a licença nesses locais:
  * Um caminho explícito
  * A pasta que contém o dll do componente (incluída no Aspose.Slides)
  * A pasta que contém o assembly que chamou o dll do componente (incluída no Aspose.Slides)
  * A pasta que contém o assembly de entrada (seu .exe)
  * Um recurso incorporado no assembly que chamou o dll do componente (incluído no Aspose.Slides).
* Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar o Aspose.Slides. Você só precisa definir uma licença uma vez por aplicação ou processo.

{{% alert color="info" title="Note" %}}

Você pode querer ver [Metered Licensing](/slides/pt/net/metered-licensing/).

{{% /alert %}} 


## **Apply a License**
Uma licença pode ser carregada a partir de um **arquivo**, **fluxo** ou **recurso incorporado**. 

{{% alert color="info" title="Note" %}}

O Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/net/aspose.slides/license) para operações de licenciamento.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.

{{% /alert %}}

### **Arquivo**
O método mais simples de definir uma licença requer que você coloque o arquivo de licença na mesma pasta que contém o DLL do componente (incluído no Aspose.Slides) e especifique apenas o nome do arquivo sem o caminho.

Este código C# demonstra como definir um arquivo de licença:

``` csharp
// Instancia a classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Define o caminho do arquivo de licença
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}

Se você colocar o arquivo de licença em um diretório diferente, ao chamar o método [SetLicense](https://reference.aspose.com/slides/pt/net/aspose.slides/license/setlicense/#setlicense_1), o nome do arquivo de licença ao final do caminho especificado deve ser o mesmo que o nome do seu arquivo de licença.

Por exemplo, você pode alterar o nome do arquivo de licença para *Aspose.Slides.lic.xml*. Então, no seu código, você deve passar o caminho para o arquivo (terminando com *Aspose.Slides.lic.xml*) ao método [SetLicense](https://reference.aspose.com/slides/pt/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Fluxo**
Você pode carregar uma licença a partir de um fluxo. Este código C# demonstra como aplicar uma licença a partir de um fluxo:

``` csharp
// Instancia a classe License
Aspose.Slides.License license = new Aspose.Slides.License();

// Abre o arquivo de licença como um fluxo
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Define a licença através de um fluxo
license.SetLicense(licenseStream);
```

### **Recurso Incorporado**
Você pode empacotar a licença com sua aplicação (para evitar perdê‑la) adicionando a licença como um recurso incorporado em um dos assemblies que chamam o DLL do componente (incluído no Aspose.Slides). 

Veja como adicionar um arquivo de licença como recurso incorporado:

1. No Visual Studio, adicione o arquivo de licença (.lic) ao projeto desta forma: vá em **File** > **Add Existing Item** > **Add**. 
2. Selecione o arquivo no **Solution Explorer**.
3. Na janela **Properties**, defina **Build Action** como **Embedded Resource**.
4. Para acessar a licença incorporada no assembly, adicione o arquivo de licença como recurso incorporado ao projeto e, em seguida, passe o nome do arquivo de licença ao método `SetLicense`. 


A classe `License` encontra automaticamente o arquivo de licença nos recursos incorporados. Você não precisa chamar os métodos `GetExecutingAssembly` e `GetManifestResourceStream` da classe `System.Reflection.Assembly` no Microsoft .NET Framework.

Este código C# demonstra como definir uma licença como recurso incorporado:

``` csharp
// Instancia a classe License
Aspose.Slides.License license = new Aspose.Slides.License();

// Passa o nome do arquivo de licença incorporado no assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Validate a License**

Para verificar se uma licença foi definida corretamente, você pode validá‑la. Este código C# demonstra como validar uma licença:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Thread Safety**

{{% alert color="warning" title="Warning" %}}

O método [license.SetLicense](https://reference.aspose.com/slides/pt/net/aspose.slides/license/setlicense/) não é seguro para uso em múltiplas threads. Se esse método precisar ser chamado simultaneamente por várias threads, você pode querer usar primitivas de sincronização (como um lock) para evitar problemas. 

{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão à internet.

### What happens after the one-year subscription expires? Will the library stop working?

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; você apenas não estará elegível a usar versões mais recentes sem renovar.