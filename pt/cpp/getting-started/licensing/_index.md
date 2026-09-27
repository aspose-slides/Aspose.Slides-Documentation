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
description: "Aplique, gerencie e resolva problemas de licenças no Aspose.Slides para C++. Garanta acesso ininterrupto a todos os recursos com nosso guia passo a passo de licenciamento."
---
## **Visão geral**

Aspose.Slides pode ser usado em modo de avaliação ou com uma licença válida. A versão de avaliação oferece a mesma funcionalidade da versão licenciada, mas adiciona uma marca d'água de avaliação a cada slide de cada apresentação que salva e trunca o texto que seu código lê das apresentações.

Este artigo explica como o licenciamento funciona no Aspose.Slides e como aplicar uma licença antes de usar a biblioteca. Uma licença pode ser carregada a partir de um arquivo ou de um fluxo usando a classe `License`. O artigo também mostra como validar se uma licença foi aplicada corretamente.

## **Avaliar Aspose.Slides**

{{% alert color="info" title="Note" %}}
Você pode baixar uma versão de avaliação do **Aspose.Slides for C++** a partir da [sua página de download no NuGet](https://www.nuget.org/packages/Aspose.Slides.Cpp/) ou, como um pacote ZIP, da [página de download](https://releases.aspose.com/slides/cpp/). A versão de avaliação oferece a mesma funcionalidade do produto licenciado. Na verdade, o pacote de avaliação é idêntico ao comprado — ele simplesmente se torna licenciado quando você adiciona algumas linhas de código para aplicar a licença.

Quando estiver satisfeito com sua avaliação do **Aspose.Slides**, você pode [adquirir uma licença](https://purchase.aspose.com/pricing/slides/cpp/). Recomendamos revisar os tipos de assinatura disponíveis. Se você tiver alguma dúvida, sinta‑se à vontade para contatar a equipe de vendas da Aspose.

Cada licença da Aspose inclui uma assinatura de um ano para atualizações gratuitas, incluindo novas versões e correções de bugs lançadas durante esse período. Seja você usuário de uma versão licenciada ou de avaliação, recebe suporte técnico gratuito e ilimitado.
{{% /alert %}} 

**Limitações da Versão de Avaliação**

* A versão de avaliação (sem uma licença especificada) fornece a funcionalidade completa do produto, mas adiciona uma caixa de texto de marca d'água de avaliação a cada slide de cada apresentação que salva.
* O texto que seu código lê de uma apresentação é truncado aos primeiros caracteres, seguido por um aviso sobre a limitação da avaliação. O texto que seu código grava é salvo integralmente.

{{% alert color="info" title="Note" %}}
Para testar o Aspose.Slides sem limitações, você pode solicitar uma **Licença Temporária de 30 dias**. Para mais informações, veja a página [Como obter uma Licença Temporária](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licenciamento no Aspose.Slides**

* Uma versão de avaliação torna‑se licenciada depois que você adquire uma licença e a aplica adicionando algumas linhas de código.
* A licença é um arquivo XML em texto simples que contém detalhes como o nome do produto, o número de desenvolvedores aos quais está licenciada, a data de expiração da assinatura e mais.
* O arquivo de licença é assinado digitalmente, portanto não deve ser modificado. Até mesmo uma alteração acidental — como adicionar uma quebra de linha — invalidará o arquivo.
* Quando você fornece um nome de arquivo sem pasta, o Aspose.Slides for C++ procura o arquivo de licença apenas no diretório de trabalho atual. Ele não busca na pasta do seu executável ou da biblioteca Aspose.Slides, portanto forneça o caminho completo quando o arquivo de licença estiver armazenado em outro local.
* Para evitar as limitações da versão de avaliação, você deve definir a licença antes de usar o Aspose.Slides. Uma licença precisa ser definida apenas uma vez por aplicação ou processo.

## **Aplicar uma Licença**

Uma licença pode ser carregada a partir de um **arquivo** ou de um **fluxo**.

{{% alert color="info" title="Note" %}}
O Aspose.Slides fornece a classe [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) para operações de licenciamento.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Novas licenças podem ativar o Aspose.Slides somente a partir da versão 21.4 ou posterior. Versões anteriores utilizam um sistema de licenciamento diferente e não reconhecerão essas licenças.
{{% /alert %}}

### **Arquivo**

A maneira mais fácil de definir uma licença é colocar o arquivo de licença no diretório de trabalho do seu programa e especificar apenas o nome do arquivo, sem o caminho. Caso contrário, especifique o caminho completo para o arquivo.

O código C++ a seguir aplica o arquivo de licença *Aspose.Slides.lic* a partir do diretório de trabalho do programa:

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

Se a licença for válida, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) retorna e o programa termina sem saída; a partir daí, o Aspose.Slides funciona sem as limitações de avaliação. Se o arquivo não estiver no diretório de trabalho, o método lança uma [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) com a mensagem *License "Aspose.Slides.lic" doesn't exist or access is restricted*. O exemplo não trata a exceção, portanto o programa para.

{{% alert color="warning" title="Warning" %}}
Se você colocar o arquivo de licença em um diretório diferente, ao chamar o método [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/), o nome do arquivo no final do caminho explícito especificado deve corresponder exatamente ao nome do seu arquivo de licença.

Por exemplo, se você renomear seu arquivo de licença para *Aspose.Slides.lic.xml*, deve passar o caminho completo terminando com *Aspose.Slides.lic.xml* ao método [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) no seu código.
{{% /alert %}}

### **Fluxo**

Carregue uma licença a partir de um fluxo quando seu programa não mantém a licença como um arquivo nomeável, por exemplo, ao ler a licença de um banco de dados. [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) aceita qualquer [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/) que contenha a licença. Para manter o exemplo curto, o código C++ a seguir abre *Aspose.Slides.lic* no diretório de trabalho com [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) e aplica a licença a partir desse fluxo:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Uma licença válida produz o mesmo resultado do exemplo com arquivo. Se o arquivo não existir, [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) lança uma [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) antes que a licença seja aplicada, e o programa para.

## **Validar uma Licença**

Para verificar se uma licença foi configurada corretamente, chame [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/). Ele retorna `true` somente após uma licença válida ter sido aplicada, e `false` antes disso. O código C++ a seguir aplica o arquivo de licença a partir do diretório de trabalho e então o verifica:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Com uma licença válida, o programa imprime *License is good!*. Se o arquivo estiver ausente ou não for um arquivo de licença, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) lança uma exceção antes da verificação, e o programa para sem imprimir nada. Se o arquivo for uma licença cuja assinatura não corresponde, por exemplo porque foi editada, SetLicense retorna sem erro mas `IsLicensed` retorna `false`, portanto nada é impresso e o Aspose.Slides permanece em modo de avaliação.

## **Segurança de Thread**

{{% alert color="warning" title="Warning" %}}
O método [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) não é **thread‑safe**. Se precisar chamar esse método a partir de várias threads simultaneamente, recomenda‑se usar primitivas de sincronização (como um lock) para evitar problemas potenciais.
{{% /alert %}}

## **FAQ**

### Posso aplicar a licença em um ambiente totalmente offline (sem acesso à internet)?

Sim. A validação da licença é realizada localmente usando o arquivo de licença; não é necessária conexão com a internet.

### O que acontece após a expiração da assinatura de um ano? A biblioteca deixará de funcionar?

Não. A licença é perpétua: você pode continuar usando as versões lançadas antes da data de término da sua assinatura; apenas não será elegível a usar versões mais recentes sem renovação.