---
title: Pacote Multiplataforma para .NET 6 e Versões Posteriores
linktitle: Pacote Multiplataforma
type: docs
weight: 235
url: /pt/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- multiplataforma
- suporte .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Saiba quando usar o pacote Aspose.Slides.NET6.CrossPlatform: por que ele existe, em quais plataformas funciona e o que ele necessita no Linux em vez do libgdiplus."
---
## **Introdução**

Aspose.Slides for .NET é distribuído como dois pacotes NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) gera slides através da biblioteca System.Drawing.Common da Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) os gera com seu próprio motor gráfico. Este artigo explica por que o segundo pacote existe, onde ele roda, o que ele precisa no Linux e como ele convive com System.Drawing.Common em um único projeto.

## **Por que um Pacote Separado**

A partir do .NET 6, a Microsoft suporta System.Drawing.Common [apenas no Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Como resultado, no Linux o Aspose.Slides.NET precisa da chave `System.Drawing.EnableUnixSupport` além da biblioteca `libgdiplus`, e falha se o projeto referenciar System.Drawing.Common 7 ou superior. [Requisitos de Sistema](/slides/pt/net/system-requirements/) descreve essas condições.

Aspose.Slides.NET6.CrossPlatform não usa System.Drawing.Common nem `libgdiplus`. Seu motor gráfico é uma biblioteca nativa que o pacote contém em uma compilação por plataforma suportada. Ambos os pacotes fornecem os mesmos namespaces e classes Aspose.Slides, então mudar de um para o outro altera apenas a referência ao pacote, não o seu código.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Gráficos | System.Drawing.Common | Motor gráfico nativo incluído no pacote |
| Frameworks de destino | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Requisitos no Linux | `libgdiplus` e a chave `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Suportado | Não suportado |

## **Plataformas Suportadas**

Aspose.Slides.NET6.CrossPlatform funciona com .NET 6 e versões posteriores nas seguintes plataformas:

- **Windows**: x86 e x64. A biblioteca nativa usa o runtime Microsoft Visual C++; veja [Requisitos de Sistema](/slides/pt/net/system-requirements/).
- **Linux**: x64 com glibc 2.23 ou posterior, e ARM64 com glibc 2.39 ou posterior.
- **macOS**: x64 (Intel) e ARM64 (Apple silicon).

Ele não funciona no Windows em ARM64, no Alpine Linux ou em outras distribuições baseadas em musl em vez de glibc, nem em distribuições com glibc mais antigo, como o CentOS 7. Use Aspose.Slides.NET nesses sistemas.

## **Instalação no Linux**

No Linux, o pacote requer a biblioteca `fontconfig`, mas não `libgdiplus`. No Debian e no Ubuntu, instale `fontconfig` e então adicione o pacote ao seu projeto:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

No Debian e no Ubuntu, `libfontconfig1` também instala as fontes DejaVu, de modo que o texto é renderizado sem pacotes de fontes adicionais. Sem `fontconfig`, a criação de uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) falha com uma `TypeInitializationException` cuja `DllNotFoundException` interna relata que `libfontconfig.so.1` não pôde ser aberto. [Requisitos de Sistema](/slides/pt/net/system-requirements/) inclui um programa curto que verifica a configuração.

## **Hosts de Nuvem e Containers**

Como não necessita de `libgdiplus`, Aspose.Slides.NET6.CrossPlatform é o pacote a ser usado em hosts Linux onde você não pode instalar `libgdiplus`. Ele ainda precisa de `fontconfig` e de fontes, que imagens base mínimas podem não incluir. A imagem base do AWS Lambda para .NET 8, por exemplo, não contém nenhum dos dois. Em uma imagem de container baseada nela, execute `dnf install -y fontconfig`, que também instala as fontes Noto Sans.

Para guias específicas de plataformas de nuvem, veja [Aspose.Slides on Cloud Platforms](/slides/pt/net/slides-on-cloud-platforms/).

## **Usando System.Drawing.Common no Mesmo Projeto (CS0433)**

Um projeto que usa Aspose.Slides.NET6.CrossPlatform pode também referenciar System.Drawing.Common, direta ou indiretamente, por outro pacote. A versão atual do Aspose.Slides não expõe tipos públicos nos namespaces `System`, portanto as duas bibliotecas não entram em conflito, e você pode importar os namespaces `Aspose.Slides` e `System.Drawing` no mesmo arquivo.

Se o compilador relatar o erro CS0433 porque um tipo como `Image` ou `Graphics` existe tanto em Aspose.Slides quanto em System.Drawing.Common, seu projeto está usando uma versão mais antiga do Aspose.Slides. Atualize o pacote para a versão mais recente. Aspose.Slides devolve imagens renderizadas como objetos [IImage](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/), descritos em [Modern API](/slides/pt/net/modern-api/).

## **FAQ**

**Preciso mudar meu código ao trocar de Aspose.Slides.NET para Aspose.Slides.NET6.CrossPlatform?**

Não. Ambos os pacotes fornecem os mesmos namespaces e classes Aspose.Slides, portanto você apenas substitui a referência ao pacote. Aspose.Slides.NET6.CrossPlatform não necessita da chave `System.Drawing.EnableUnixSupport`. Adicione apenas um dos dois pacotes ao projeto.

**Posso usar Aspose.Slides.NET6.CrossPlatform em um projeto .NET Framework?**

Não. O pacote tem como alvo apenas .NET 6 e versões posteriores. Para .NET Framework 4.6.2 e posteriores, use Aspose.Slides.NET.