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

Aspose.Slides pode ser usado em modo de avaliação ou com uma licença válida. A versão de avaliação fornece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d'agua de avaliação quando as apresentações são abertas ou salvas e limita a extração de texto a um slide.

Este artigo explica como funciona o licenciamento no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo, fluxo ou recurso incorporado usando a classe `License`. O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Avaliar Aspose.Slides**

{{% alert color="info" %}} 

Você pode baixar uma versão de avaliação do **Aspose.Slides for C++** a partir da [sua página de download no NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). A versão de avaliação oferece a mesma funcionalidade do produto licenciado. Na verdade, o pacote de avaliação é idêntico ao adquirido — ele simplesmente se torna licenciado quando você adiciona algumas linhas de código para aplicar a licença.

Depois de ficar satisfeito com a avaliação do **Aspose.Slides**, você pode [adquirir uma licença](https://purchase.aspose.com/buy). Recomendamos revisar os tipos de assinatura disponíveis. Se tiver alguma dúvida, sinta-se à vontade para entrar em contato com a equipe de vendas da Aspose.

Toda licença Aspose inclui uma assinatura de um ano para atualizações gratuitas, incluindo novas versões e correções de bugs lançadas durante esse período. Seja usando a versão licenciada ou de avaliação, você recebe suporte técnico gratuito e ilimitado.

{{% /alert %}} 

**Limitações da versão de avaliação**

* Embora a versão de avaliação do Aspose.Slides (quando nenhuma licença está aplicada) forneça toda a funcionalidade do produto, ela insere uma marca d'agua de avaliação no topo do documento durante as operações de abertura e gravacao.
* A extracao de texto é limitada a um slide ao usar a versão de avaliação.

{{% alert color="info" %}} 

Para testar o Aspose.Slides sem limitacoes, voce pode solicitar uma **Licenca Temporaria de 30 dias**. Para mais informacoes, consulte a pagina [Como obter uma licenca temporaria](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliacao se torna licenciada apos voce adquirir uma licenca e aplicá-la adicionando algumas linhas de codigo.
* A licenca e um arquivo XML de texto simples que contem detalhes como o nome do produto, o numero de desenvolvedores licenciados, a data de vencimento da assinatura e mais.
* O arquivo de licenca e assinado digitalmente, portanto nao deve ser modificado. Mesmo uma alteracao acidental - como a insercao de uma quebra de linha - invalidara o arquivo.
* O Aspose.Slides for C++ normalmente procura o arquivo de licenca nos seguintes locais:
  * Um caminho especificado explicitamente no seu codigo
  * A pasta que contem o DLL do componente (incluido no Aspose.Slides)
  * A pasta que contem o assembly que chama o DLL do componente
* Para evitar as limitacoes da versao de avaliacao, voce deve definir a licenca antes de usar o Aspose.Slides. A licenca precisa ser definida apenas uma vez por aplicacao ou processo.

## **Aplicar uma Licenca**

Uma licenca pode ser carregada a partir de um **arquivo**, um **fluxo** ou um **recurso incorporado**.

{{% alert color="info" %}}

O Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.license/) para operacoes de licenciamento.

{{% /alert %}} 

{{% alert color="warning" %}}

Novas licencas podem ativar o Aspose.Slides somente nas versoes 21.4 ou posteriores. Versoes anteriores usam um sistema de licenciamento diferente e nao reconhecerao essas licencas.

{{% /alert %}}

### **Arquivo**

A maneira mais simples de definir uma licenca e colocar o arquivo de licenca na mesma pasta que o DLL do componente (incluido no Aspose.Slides) e especificar apenas o nome do arquivo, sem o caminho.

O codigo C++ a seguir mostra como definir um arquivo de licenca:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Se voce colocar o arquivo de licenca em um diretorio diferente, entao ao chamar o metodo [License::SetLicense](https://reference.aspose.com/slides/pt/cpp/aspose.slides/license/setlicense/) o nome do arquivo ao final do caminho explicito especificado deve coincidir exatamente com o nome do seu arquivo de licenca.

Por exemplo, se voce renomear seu arquivo de licenca para *Aspose.Slides.lic.xml*, deve passar o caminho completo terminando em *Aspose.Slides.lic.xml* ao metodo [License::SetLicense](https://reference.aspose.com/slides/pt/cpp/aspose.slides/license/setlicense/) no seu codigo.

{{% /alert %}}

### **Fluxo**

Voce pode carregar uma licenca a partir de um fluxo. O codigo C++ a seguir mostra como aplicar uma licenca a partir de um fluxo:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Validar uma Licenca**

Para verificar se uma licenca foi definida corretamente, voce pode valida-la. O codigo C++ a seguir mostra como validar uma licenca:

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Seguranca de Threads**

{{% alert title="Note" color="warning" %}} 

O metodo [License::SetLicense](https://reference.aspose.com/slides/pt/cpp/aspose.slides/license/setlicense/) **nao e thread-safe**. Se precisar chamar esse metodo a partir de multiplas threads simultaneamente, recomenda-se usar primitivas de sincronizacao (como um lock) para evitar possiveis problemas.

{{% /alert %}}

## **FAQ**

### Posso aplicar a licenca em um ambiente totalmente offline (sem acesso à internet)?

Sim. A validacao da licenca e realizada localmente usando o arquivo de licenca; nao e necessario conexao com a internet.

### O que acontece apos o termino da assinatura de um ano? A biblioteca deixara de funcionar?

Nao. A licenca e perpetua: voce pode continuar usando as versoes lancadas antes da data de termino da sua assinatura; apenas nao sera elegivel a usar versoes mais recentes sem renovacao.