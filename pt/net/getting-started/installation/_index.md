---
title: Instalação
type: docs
weight: 70
url: /pt/net/installation/
keywords:
- instalar Aspose.Slides
- baixar Aspose.Slides
- usar Aspose.Slides
- instalação do Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Instale Aspose.Slides for .NET via NuGet no Windows, Linux e macOS: escolha entre os dois pacotes, adicione um com a .NET CLI ou Visual Studio e instale os pré-requisitos do Linux."
---
## **Visão geral**

Este artigo explica como adicionar Aspose.Slides for .NET a um projeto no Windows, Linux e macOS. Aspose.Slides é distribuído via NuGet. Você pode adicioná‑lo com a .NET CLI em qualquer sistema operacional, ou com o NuGet Package Manager ou o Package Manager Console no Visual Studio no Windows. O artigo também explica qual dos dois pacotes NuGet escolher e o que o Linux precisa além disso.

Antes da instalação, revise os sistemas operacionais suportados, implementações .NET e dependências adicionais em [Requisitos de Sistema](/slides/pt/net/system-requirements/).

## **Escolha um Pacote**

Aspose.Slides for .NET é publicado como dois pacotes NuGet. Ambos fornecem os mesmos namespaces e classes Aspose.Slides, portanto seu código não muda ao alternar entre eles; apenas a referência ao pacote e os requisitos da plataforma diferem.

| Pacote | Use para | Requisitos adicionais |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Aplicações Windows e .NET Framework | No Linux e macOS: a biblioteca `libgdiplus` e a opção `System.Drawing.EnableUnixSupport` habilitada na inicialização da aplicação |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 ou posterior em Windows, Linux e macOS | No Linux: a biblioteca `fontconfig`, se ainda não estiver instalada |

Se estiver em dúvida, use Aspose.Slides.NET no Windows e Aspose.Slides.NET6.CrossPlatform no Linux e macOS. No Alpine Linux, e em sistemas Linux cuja glibc seja mais antiga que 2.23 (x64) ou 2.39 (ARM64), use Aspose.Slides.NET. [Requisitos de Sistema](/slides/pt/net/system-requirements/) lista as plataformas suportadas por cada pacote.

## **Instalar com a .NET CLI**

Essas etapas funcionam no Windows, Linux e macOS com o .NET SDK 6 ou posterior. Crie um aplicativo de console:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Em seguida, adicione o pacote para sua plataforma. Adicione apenas um dos dois pacotes ao projeto.

- No Windows: `dotnet add package Aspose.Slides.NET`
- No Linux e macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (no Linux, instale seu pré‑requisito primeiro; veja [Linux](#linux))

Para verificar se o pacote funciona, substitua o conteúdo de *Program.cs* pelo primeiro exemplo em [Criar Apresentações](/slides/pt/net/create-presentation/) e execute `dotnet run`. Ele salva *hello.pptx* na pasta do projeto.

## **Windows**

### **Método 1: Instalar ou atualizar Aspose.Slides pelo Gerenciador de Pacotes NuGet**

1. Abra o Microsoft Visual Studio.
2. Crie um aplicativo de console ou abra um projeto existente.
3. No **Solution Explorer**, clique com o botão direito no projeto e selecione **Manage NuGet Packages** (ou vá em **Project** > **Manage NuGet Packages**).
4. Em **Browse**, procure por *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Clique em **Aspose.Slides.NET** e depois clique em **Install**.  
   * Se já instalou o Aspose.Slides e deseja atualizá‑lo, clique em **Update** em vez disso.

O pacote é baixado e referenciado no seu projeto.

### **Método 2: Instalar ou atualizar Aspose.Slides através do Package Manager Console**

Esta é a forma de referenciar o pacote [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) via Package Manager Console:

1. Abra o Microsoft Visual Studio.
2. Crie um aplicativo de console ou abra um projeto existente.
3. Vá em **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Opening the Package Manager Console](installation_2.png)
4. Execute este comando: `Install-Package Aspose.Slides.NET`
![Running the Install-Package command](installation_3.png)
A versão mais recente é instalada no seu projeto.

A mensagem **Installing Aspose.Slides.NET** aparece próximo ao final da janela.
![Installation progress in the Package Manager Console](installation_4.png)

Quando o download termina, aparecem mensagens de confirmação. O pacote é distribuído sob a [Aspose EULA](https://about.aspose.com/legal/eula).
![Installation confirmation messages](installation_5.png)

Aspose.Slides agora está adicionado ao seu projeto e referenciado.
![Aspose.Slides referenced in the project](installation_6.png)

Para atualizar o pacote, execute `Update-Package Aspose.Slides.NET` no Package Manager Console.

## **Linux**

Use as etapas da .NET CLI acima. Escolha o pacote e instale seu pré‑requisito com o gerenciador de pacotes da sua distribuição. No Debian e Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: instale `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: instale `libgdiplus` e habilite o suporte Unix para System.Drawing antes que sua aplicação use Aspose.Slides.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

  Adicione esta instrução no início da sua aplicação, antes de qualquer chamada ao Aspose.Slides. Em um *Program.cs* com declarações de nível superior, coloque‑a após as diretivas `using`:

  ```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

  Use este pacote no Alpine Linux e em sistemas cuja glibc seja muito antiga para Aspose.Slides.NET6.CrossPlatform.

As fontes usadas nas suas apresentações, ou substitutos adequados, devem estar instaladas no sistema para que o texto seja renderizado corretamente. [Requisitos de Sistema](/slides/pt/net/system-requirements/) descreve os pacotes que o Aspose.Slides.NET precisa no Alpine Linux, incluindo fontes.

## **macOS**

Use as etapas da .NET CLI acima com o pacote **Aspose.Slides.NET6.CrossPlatform**, que oferece suporte a Macs Intel (x86_64) e Apple silicon (ARM64):

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Existe uma versão gratuita ou limitação de avaliação?**

Sim. Sem uma licença, o Aspose.Slides roda em modo de avaliação: ele adiciona uma marca d'água de avaliação a cada slide salvo e trunca o texto lido das apresentações. Para remover essas limitações, aplique uma [licença](/slides/pt/net/licensing/).