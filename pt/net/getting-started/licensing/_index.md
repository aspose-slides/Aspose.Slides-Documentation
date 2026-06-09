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
description: "Aplicar, gerenciar e solucionar problemas de licenças no Aspose.Slides para .NET. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Visão geral**

Aspose.Slides pode ser usado no modo de avaliação ou com uma licença válida. A versão de avaliação fornece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d’água de avaliação quando as apresentações são abertas ou salvas e limita a extração de texto a um slide.

Este artigo explica como o licenciamento funciona no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo, stream ou recurso incorporado usando a classe `License`. O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Avaliar Aspose.Slides**

{{% alert color="primary" %}} 

Você pode baixar uma versão de avaliação do **Aspose.Slides for NET** na [sua página de download do NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). A versão de avaliação fornece as mesmas funcionalidades da versão licenciada do produto. O pacote de avaliação é o mesmo que o pacote adquirido. A versão de avaliação simplesmente se torna licenciada após você adicionar algumas linhas de código (para aplicar a licença).

Depois de ficar satisfeito com sua avaliação do **Aspose.Slides**, você pode [adquirir uma licença](https://purchase.aspose.com/buy). Recomendamos que você analise os diferentes tipos de assinatura. Se tiver dúvidas, entre em contato com a equipe de vendas da Aspose.

Toda licença Aspose inclui uma assinatura de um ano para atualizações gratuitas para novas versões ou correções lançadas dentro do período da assinatura. Usuários com produtos licenciados ou até mesmo versões de avaliação recebem suporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitações da versão de avaliação**

* Embora a versão de avaliação do Aspose.Slides (sem uma licença especificada) ofereça funcionalidade completa do produto, ela insere uma marca d’água de avaliação no topo do documento nas operações de abrir e salvar. 
* Você fica limitado a um slide ao extrair textos das apresentações.

{{% alert color="primary" %}} 

Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Consulte a página [Como obter uma Licença Temporária](https://purchase.aspose.com/temporary-license) para mais informações.

{{% /alert %}}

## **Licenciamento no Aspose.Slides**
* Uma versão de avaliação se torna licenciada depois que você compra uma licença e adiciona algumas linhas de código (para aplicar a licença).
* A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, número de desenvolvedores licenciados, data de expiração da assinatura, etc. 
* O arquivo de licença é assinado digitalmente, portanto não deve ser modificado. Até mesmo a adição inadvertida de uma quebra de linha extra ao conteúdo do arquivo o invalidará.
* O Aspose.Slides for .NET normalmente procura a licença nos seguintes locais:
  * Um caminho explícito
  * A pasta que contém o dll do componente (incluído no Aspose.Slides)
  * A pasta que contém o assembly que chamou o dll do componente (incluído no Aspose.Slides)
  * A pasta que contém o assembly de entrada (seu .exe)
  * Um recurso incorporado no assembly que chamou o dll do componente (incluído no Aspose.Slides).
* Para evitar as limitações associadas à versão de avaliação, você precisa definir uma licença antes de usar o Aspose.Slides. É necessário definir a licença apenas uma vez por aplicação ou processo.

{{% alert color="primary" %}} 

Você pode querer ver [Licenciamento por Medição](https://docs.aspose.com/slides/pt/net/metered-licensing/).

{{% /alert %}} 


## **Aplicar uma licença**
Uma licença pode ser carregada a partir de um **arquivo**, **stream** ou **recurso incorporado**. 

{{% alert color="primary" %}}

Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/net/aspose.slides/license) para operações de licenciamento.

{{% /alert %}} 

{{% alert color="warning" %}} 

Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.

{{% /alert %}}

### **Arquivo**
O método mais simples de definir uma licença requer que você coloque o arquivo de licença na mesma pasta que contém o DLL do componente (incluído no Aspose.Slides) e especifique apenas o nome do arquivo sem o caminho.

Este código C# mostra como definir um arquivo de licença:

``` csharp
// Instancia a classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Define o caminho do arquivo de licença
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Se você colocar o arquivo de licença em um diretório diferente, ao chamar o método [SetLicense](https://reference.aspose.com/slides/pt/net/aspose.slides/license/setlicense/#setlicense_1), o nome do arquivo de licença no final do caminho explícito deve ser o mesmo do seu arquivo de licença.

Por exemplo, você pode mudar o nome do arquivo de licença para *Aspose.Slides.lic.xml*. Então, no seu código, você deve passar o caminho para o arquivo (terminando com *Aspose.Slides.lic.xml*) ao método [SetLicense](https://reference.aspose.com/slides/pt/net/aspose.slides/license/setlicense/#setlicense_1).

{{% /alert %}}

### **Stream**
Você pode carregar uma licença a partir de um stream. Este código C# mostra como aplicar uma licença a partir de um stream:

``` csharp
// Instancia a classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Define a licença através de um stream
license.SetLicense(myStream);
```

### **Recurso Incorporado**
Você pode empacotar a licença com sua aplicação (para evitar perdê‑la) adicionando a licença como recurso incorporado em um dos assemblies que chamam o DLL do componente (incluído no Aspose.Slides). 

Veja como adicionar um arquivo de licença como recurso incorporado:

1. No Visual Studio, adicione o arquivo de licença (.lic) ao projeto desta forma: vá em **File** > **Add Existing Item** > **Add**. 
2. Selecione o arquivo no **Solution Explorer**.
3. Na janela **Properties**, defina **Build Action** como **Embedded Resource**.
4. Para acessar a licença incorporada no assembly, adicione o arquivo de licença como recurso incorporado ao projeto e, em seguida, passe o nome do arquivo de licença ao método `SetLicense`. 

A classe `License` procura automaticamente o arquivo de licença nos recursos incorporados. Você não precisa chamar os métodos `GetExecutingAssembly` e `GetManifestResourceStream` da classe `System.Reflection.Assembly` no Microsoft .NET Framework.

Este código C# mostra como definir uma licença como recurso incorporado:

``` csharp
// Instancia a classe License
Aspose.Slides.License license = new Aspose.Slides.License();

// Passa o nome do arquivo de licença incorporado no assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Validar uma licença**

Para verificar se uma licença foi definida corretamente, você pode validá‑la. Este código C# mostra como validar uma licença:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Segurança de thread**

{{% alert title="Note" color="warning" %}} 

O método [license.SetLicense](https://reference.aspose.com/slides/pt/net/aspose.slides/license/setlicense/) não é seguro para uso simultâneo em múltiplas threads. Se esse método precisar ser chamado simultaneamente por várias threads, considere usar primitivas de sincronização (como um lock) para evitar problemas. 

{{% /alert %}}

## **FAQ**

**Posso aplicar a licença em um ambiente completamente offline (sem acesso à internet)?**

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão com a internet.

**O que acontece após o término da assinatura de um ano? A biblioteca deixará de funcionar?**

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não terá direito a versões mais recentes sem renovação.