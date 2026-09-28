---
title: Requisitos do Sistema
type: docs
weight: 60
url: /pt/net/system-requirements/
keywords:
- requisitos do sistema
- plataformas suportadas
- frameworks de destino
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Verifique o que o Aspose.Slides para .NET precisa antes de instalá-lo: os frameworks que cada pacote NuGet tem como alvo, os sistemas operacionais e processadores suportados, e as bibliotecas e fontes que o Linux requer."
---
## **Introdução**

Aspose.Slides for .NET é uma biblioteca autônoma: não requer Microsoft PowerPoint ou Microsoft Office. É publicada como dois pacotes NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) e [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Ambos fornecem os mesmos namespaces e classes Aspose.Slides; diferem nas estruturas de destino e na forma como desenham os slides, o que determina onde são executados e o que precisam.

Este artigo lista as versões .NET e plataformas que cada pacote suporta, bem como as bibliotecas de sistema e fontes necessárias no Linux, e termina com um pequeno programa que verifica sua configuração. Para adicionar um pacote a um projeto, veja [Installation](/slides/pt/net/installation/).

## **Versões .NET Suportadas**

Cada pacote contém uma compilação do Aspose.Slides por framework de destino, e o NuGet seleciona a compilação que corresponde ao framework de destino do seu projeto.

| Pacote | Frameworks de destino no pacote | Seu projeto pode direcionar |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 ou posterior; .NET 6 ou posterior, incluindo .NET 8, .NET 9 e .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 ou posterior, incluindo .NET 8, .NET 9 e .NET 10 |

A compilação `netstandard2.0` permite que uma biblioteca de classes .NET Standard 2.0 faça referência ao Aspose.Slides.NET. Uma aplicação que usa tal biblioteca executa a compilação que corresponde ao framework de destino da própria aplicação: uma aplicação .NET 8, por exemplo, executa a compilação `net6.0`.

## **Sistemas Operacionais e Processadores Suportados**

**Aspose.Slides.NET** contém apenas código gerenciado independente de processador (AnyCPU), portanto roda na arquitetura do processador do runtime .NET que o carrega. Ele desenha slides através da biblioteca System.Drawing.Common da Microsoft, que a Microsoft suporta [somente no Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). No Linux, o Aspose.Slides.NET portanto precisa da biblioteca `libgdiplus` e de uma opção de inicialização, descritas em [Linux](#linux). Ele funciona em distribuições Linux que fornecem `libgdiplus`, como Debian, Ubuntu e Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** desenha slides com seu próprio mecanismo gráfico. O mecanismo é uma biblioteca nativa que o pacote contém em uma compilação por plataforma, portanto o pacote roda apenas nessas plataformas:

| Sistema operacional | Processadores | Observações |
|---|---|---|
| Windows | x86, x64 | Windows em ARM64 não é suportado. |
| Linux | x64, ARM64 | Requer glibc 2.23 ou superior em x64 e glibc 2.39 ou superior em ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) | |

Aspose.Slides.NET6.CrossPlatform não funciona no Alpine Linux ou em outras distribuições baseadas em musl ao invés de glibc, nem em distribuições com glibc mais antigo, como o CentOS 7. Use Aspose.Slides.NET nesses sistemas.

No Windows, a biblioteca nativa do Aspose.Slides.NET6.CrossPlatform usa o runtime Microsoft Visual C++ (*MSVCP140.dll* e *VCRUNTIME140.dll*, além de *VCRUNTIME140_1.dll* em x64). Se esses arquivos estiverem ausentes na máquina de destino, instale o [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Ambos os pacotes precisam de bibliotecas de sistema adicionais no Linux. Sem elas, o primeiro exemplo em [Create Presentations](/slides/pt/net/create-presentation/) falha com uma exceção ao invés de salvar o arquivo. Os comandos abaixo são para Debian e Ubuntu; nessas distribuições, cada biblioteca também traz as fontes DejaVu (`fonts-dejavu-core`), então o texto é renderizado sem pacotes de fontes adicionais.

### **Aspose.Slides.NET6.CrossPlatform**

A biblioteca Linux do pacote requer a biblioteca `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Sem ela, a criação de uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) falha com um `TypeInitializationException` cujo `DllNotFoundException` interno indica que `libfontconfig.so.1` não pode ser aberto.

Imagens base mínimas podem não incluir `fontconfig` também. A imagem base AWS Lambda para .NET 8, por exemplo, não contém `fontconfig` nem fontes. Em uma imagem de contêiner construída sobre ela, execute `dnf install -y fontconfig`, que também instala as fontes Noto Sans.

### **Aspose.Slides.NET**

O pacote requer duas coisas no Linux:

1. A biblioteca `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. A opção `System.Drawing.EnableUnixSupport`, ativada no início da sua aplicação antes de qualquer chamada ao Aspose.Slides. Em um *Program.cs* com declarações de nível superior, coloque-a após as diretivas `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Sem `libgdiplus`, salvar uma apresentação falha com um `TypeInitializationException` cujo `DllNotFoundException` interno indica que `libgdiplus` não pode ser carregado. Sem a opção, a exceção interna é `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
A opção funciona apenas com System.Drawing.Common 6, a versão da qual o Aspose.Slides.NET depende. A Microsoft a removeu no System.Drawing.Common 7. Se o seu projeto referencia System.Drawing.Common 7 ou posterior, direta ou indiretamente através de outro pacote, o Aspose.Slides.NET falha no Linux com `PlatformNotSupportedException` mesmo com `libgdiplus` instalado e a opção ativada. Nesse caso, use Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

No Alpine Linux, use Aspose.Slides.NET com a opção descrita acima. Imagens Alpine normalmente não contêm fontes, e `libgdiplus` sozinho não instala nenhuma, portanto instale `libgdiplus` junto com ao menos um pacote de fontes. Sem fontes, salvar uma apresentação falha com este erro:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Opção 1: fontes DejaVu**

A opção recomendada é o pacote `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Nas versões atuais do Alpine, `ttf-dejavu` instala o pacote `font-dejavu`, que também instala `fontconfig` e as ferramentas de fontes das quais depende.

**Opção 2: fontes principais da Microsoft**

Se suas apresentações usam fontes da Microsoft como Arial, Times New Roman, Courier New ou Verdana, instale as fontes principais da Microsoft. A etapa `update-ms-fonts` baixa as fontes enquanto a imagem é construída, portanto a compilação precisa de acesso à internet:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Suporte à Globalização**

Ambos os pacotes precisam do suporte à globalização do .NET, que o .NET no Linux fornece por meio das bibliotecas ICU. No [modo de globalização invariável](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), criar uma [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) falha com `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Algumas imagens de contêiner ativam esse modo. As imagens de runtime .NET para Alpine Linux (`runtime-deps`, `runtime` e `aspnet`), por exemplo, definem `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` e não incluem ICU. Em uma imagem construída sobre elas, instale ICU e desative o modo:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Também certifique-se de que o arquivo do seu projeto não define a propriedade `InvariantGlobalization` como `true`.

## **Verifique sua configuração**

Para verificar se um pacote e seus requisitos estão presentes, execute um programa que salva uma apresentação e renderiza um slide em uma imagem. Salvar e renderizar usam a biblioteca gráfica e as fontes, que são fornecidas pelos requisitos de Linux acima.

Crie um aplicativo de console e adicione o pacote conforme descrito em [Installation](/slides/pt/net/installation/), substitua o conteúdo de *Program.cs* pelo código abaixo e execute `dotnet run`. Se usar Aspose.Slides.NET no Linux, adicione a instrução de opção `System.Drawing.EnableUnixSupport` mostrada em [Linux](#linux) após as diretivas `using`. O programa usa declarações de nível superior e declarações `using`, que requerem C# 9 ou posterior. Projetos que visam .NET 6 ou posterior utilizam uma versão mais recente do C# por padrão; em um projeto que visa .NET Framework, adicione `<LangVersion>latest</LangVersion>` a um `PropertyGroup` no arquivo de projeto.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

O programa adiciona um retângulo com texto ao primeiro slide e salva a apresentação como *hello.pptx* usando o método [Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/). Em seguida, renderiza o slide com [GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/getimage/) e salva o resultado como *hello.png* usando [IImage.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/iimage/save/) no formato [ImageFormat.Png](https://reference.aspose.com/slides/pt/net/aspose.slides/imageformat/). Os fatores de escala de 1 renderizam um pixel por ponto, de modo que o slide padrão de 720 × 540 pontos se torna uma imagem de 720 × 540 pixels, com o texto visível dentro do retângulo. Sem licença, ambos os arquivos também contêm uma marca d'água de avaliação; veja [Licensing](/slides/pt/net/licensing/). Se algum requisito estiver ausente, o programa termina com uma das exceções descritas em [Linux](#linux).

## **Ferramentas de Desenvolvimento**

Você pode compilar aplicações que usam Aspose.Slides com qualquer ferramenta que suporte o framework de destino do seu projeto: o .NET SDK e sua interface de linha de comando `dotnet` no Windows, Linux e macOS, ou o Visual Studio no Windows. [Installation](/slides/pt/net/installation/) descreve ambos.

## **FAQ**

**Preciso ter o Microsoft PowerPoint instalado para conversões e renderização?**

Não, o PowerPoint não é necessário. Aspose.Slides é um mecanismo autônomo para [criar](/slides/pt/net/create-presentation/), modificar, [converter](/slides/pt/net/convert-presentation/) e [renderizar](/slides/pt/net/convert-powerpoint-to-png/) apresentações.

**Qual pacote devo usar?**

Use Aspose.Slides.NET no Windows e Aspose.Slides.NET6.CrossPlatform no Linux e macOS. No Alpine Linux, em sistemas Linux cujo glibc seja mais antigo que as versões listadas acima, e em projetos que visam .NET Framework, use Aspose.Slides.NET. Adicione apenas um dos dois pacotes a um projeto.

**Quais fontes são necessárias para renderização correta?**

As fontes usadas na apresentação, ou substitutos adequados, devem estar disponíveis no sistema operacional. No Linux e macOS, instale os pacotes de fontes que suas apresentações precisam para obter renderização consistente. No Alpine Linux, instale ao menos um pacote de fontes além de `libgdiplus`, conforme descrito em [Alpine Linux](#alpine-linux).

**Por que uma fonte personalizada é renderizada como fallback ou texto ausente no Linux?**

Se o arquivo de fonte tiver entradas de tabela de nomes inconsistentes ou corrompidas, a pilha de correspondência de fontes do Linux (FreeType/fontconfig) pode selecionar um registro inválido, causando a fonte não ser resolvida. Usar uma versão da fonte com registros de tabela de nomes corrigidos ou instalar um substituto consistente resolve o problema.