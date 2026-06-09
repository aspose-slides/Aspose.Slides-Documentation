---
title: Licenciamento
type: docs
weight: 120
url: /pt/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Aplique, gerencie e solucione problemas de licenças no Aspose.Slides para C++. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Visão geral**

Aspose.Slides pode ser usado em modo de avaliação ou com uma licença válida. A versão de avaliação fornece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d'água de avaliação quando as apresentações são abertas ou salvas e limita a extração de texto a um slide.

Este artigo explica como o licenciamento funciona no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo, fluxo ou recurso incorporado usando a classe `License`. O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Avaliar Aspose.Slides**

{{% alert color="primary" %}} 
Você pode baixar uma versão de avaliação do **Aspose.Slides for C++** a partir da sua [página de download no NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). A versão de avaliação oferece a mesma funcionalidade do produto licenciado. Na verdade, o pacote de avaliação é idêntico ao adquirido — simplesmente passa a estar licenciado quando você adiciona algumas linhas de código para aplicar a licença.

Depois de ficar satisfeito com a sua avaliação do **Aspose.Slides**, você pode [comprar uma licença](https://purchase.aspose.com/buy). Recomendamos revisar os tipos de assinatura disponíveis. Se tiver alguma dúvida, fique à vontade para contatar a equipe de vendas da Aspose.

Toda licença Aspose inclui uma assinatura de um ano para atualizações gratuitas, incluindo novas versões e correções de bugs lançadas durante esse período. Seja você um usuário licenciado ou em avaliação, recebe suporte técnico gratuito e ilimitado.
{{% /alert %}} 

**Limitações da Versão de Avaliação**

* Embora a versão de avaliação do Aspose.Slides (quando nenhuma licença é aplicada) forneça funcionalidade total do produto, ela insere uma marca d'água de avaliação no topo do documento durante as operações de abertura e gravação.
* A extração de texto é limitada a um slide ao usar a versão de avaliação.

{{% alert color="primary" %}} 
Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Para mais informações, consulte a página [Como obter uma licença temporária](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliação torna‑se licenciada após você comprar uma licença e aplicá‑la adicionando algumas linhas de código.
* A licença é um arquivo XML de texto simples que contém detalhes como o nome do produto, o número de desenvolvedores a que está licenciada, a data de expiração da assinatura e mais.
* O arquivo de licença é assinado digitalmente, portanto não deve ser modificado. Mesmo uma alteração acidental — como adicionar uma quebra de linha — invalidará o arquivo.
* O Aspose.Slides for C++ normalmente procura o arquivo de licença nos seguintes locais:
  * Um caminho explicitamente especificado no seu código
  * A pasta que contém a DLL do componente (incluída no Aspose.Slides)
  * A pasta que contém o assembly que chama a DLL do componente
* Para evitar as limitações da versão de avaliação, você deve definir a licença antes de usar o Aspose.Slides. A licença precisa ser definida apenas uma vez por aplicação ou processo.

## **Aplicar uma Licença**

Uma licença pode ser carregada a partir de um **arquivo**, um **fluxo** ou um **recurso incorporado**.

{{% alert color="primary" %}}
O Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.license/) para operações de licenciamento.
{{% /alert %}} 

{{% alert color="warning" %}}
Novas licenças podem ativar o Aspose.Slides apenas a partir da versão 21.4 ou posterior. Versões anteriores usam um sistema de licenciamento diferente e não reconhecerão essas licenças.
{{% /alert %}}

### **Arquivo**

A maneira mais simples de definir uma licença é colocar o arquivo de licença na mesma pasta da DLL do componente (incluída no Aspose.Slides) e especificar apenas o nome do arquivo, sem o caminho.

O código C++ a seguir mostra como definir um arquivo de licença:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 
Se você colocar o arquivo de licença em um diretório diferente, ao chamar o método [License::SetLicense](https://reference.aspose.com/slides/pt/cpp/aspose.slides/license/setlicense/), o nome do arquivo ao final do caminho explícito especificado deve corresponder exatamente ao nome do seu arquivo de licença.

Por exemplo, se você renomear seu arquivo de licença para *Aspose.Slides.lic.xml*, deve passar o caminho completo terminando em *Aspose.Slides.lic.xml* ao método [License::SetLicense](https://reference.aspose.com/slides/pt/cpp/aspose.slides/license/setlicense/) no seu código.
{{% /alert %}}

### **Fluxo**

Você pode carregar uma licença a partir de um fluxo. O código C++ a seguir mostra como aplicar uma licença a partir de um fluxo:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validar uma Licença**

Para verificar se uma licença foi definida corretamente, você pode validá‑la. O código C++ a seguir mostra como validar uma licença:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Segurança de Thread**

{{% alert title="Note" color="warning" %}} 
O método [License::SetLicense](https://reference.aspose.com/slides/pt/cpp/aspose.slides/license/setlicense/) **não é thread‑safe**. Se precisar chamar esse método simultaneamente a partir de várias threads, recomenda‑se usar primitivas de sincronização (como um lock) para evitar possíveis problemas.
{{% /alert %}}

## **FAQ**

**Posso aplicar a licença em um ambiente completamente offline (sem acesso à internet)?**

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão à internet.

**O que acontece após o término da assinatura de um ano? A biblioteca deixa de funcionar?**

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não terá direito a usar versões mais recentes sem renovação.