---
title: Abrir Apresentações em .NET
linktitle: Abrir Apresentação
type: docs
weight: 20
url: /pt/net/open-presentation/
keywords:
- abrir PowerPoint
- abrir apresentação
- abrir PPTX
- abrir PPT
- abrir ODP
- carregar apresentação
- carregar PPTX
- carregar PPT
- carregar ODP
- apresentação protegida
- apresentação grande
- recurso externo
- objeto binário
- .NET
- C#
- Aspose.Slides
description: "Aprenda a abrir apresentações PowerPoint e OpenDocument em C#, fornecer senhas de abertura, controlar o carregamento de recursos e reduzir o uso de memória com Aspose.Slides para .NET."
---
## **Introdução**

[Aspose.Slides para .NET](https://products.aspose.com/slides/pt/net/) pode carregar apresentações PowerPoint e OpenDocument a partir de arquivos e fluxos. Após uma apresentação ser carregada, você pode inspecionar sua estrutura, editar slides, gerenciar recursos e salvá-la no formato original ou em outro formato suportado.

O comportamento de carregamento pode ser personalizado através da classe LoadOptions. Por exemplo, você pode fornecer uma senha de abertura, manter objetos binários grandes fora da memória gerenciada, controlar recursos externos ou omitir dados binários incorporados.

## **Abrir Apresentações**

After loading a file or stream, you can [determine seu formato original de apresentação](/slides/pt/net/detect-presentation-source-format/) to choose how your application processes it.

Para abrir uma apresentação existente, passe o caminho do arquivo ao construtor Presentation. Libere a apresentação após o uso para que os manipuladores de arquivo, dados temporários e outros recursos sejam liberados prontamente.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Abrir apresentações protegidas por senha**

Uma senha de abertura criptografa o conteúdo da apresentação. Para carregar a apresentação completa, atribua a senha correta à [LoadOptions.Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/) e passe as opções ao construtor [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). O carregamento falha quando a senha está ausente ou incorreta.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Para detecção de senha, validação e fluxos de trabalho de criptografia, consulte [Proteção por senha de apresentações](/slides/pt/net/password-protected-presentation/). Se uma apresentação criptografada foi deliberadamente salva com propriedades de documento públicas, essas propriedades podem ser lidas sem senha; veja [Gerenciar propriedades da apresentação](/slides/pt/net/presentation-properties/).

## **Abrir apresentações grandes**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/blobmanagementoptions/) controla como Aspose.Slides lida com objetos binários grandes, como imagens, áudio e vídeo. Você pode manter o arquivo de origem bloqueado, permitir arquivos temporários e limitar a quantidade de dados BLOB retidos na memória.

O código C# a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Com `PresentationLockingBehavior.KeepLocked`, o arquivo de origem permanece bloqueado até que o objeto `Presentation` seja liberado. Não mova, sobrescreva ou exclua o arquivo de origem enquanto esse objeto estiver ativo.

Aspose.Slides pode copiar o conteúdo de um fluxo de entrada ao carregá-lo. Para apresentações grandes, um caminho de arquivo costuma ser mais eficiente que um fluxo. Veja [Gerenciar BLOBs](/slides/pt/net/manage-blob/) para opções adicionais de armazenamento e gerenciamento de memória.
{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/resourceloadingcallback/) aceita uma implementação de [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iresourceloadingcallback/). O callback pode fornecer dados de substituição, redirecionar um recurso, usar o carregador padrão ou pular o recurso. Isso é útil quando as apresentações contêm imagens externas que devem ser resolvidas de acordo com regras de segurança ou armazenamento específicas da aplicação.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Carregar apresentações sem objetos binários incorporados**

Uma apresentação pode conter dados binários incorporados que uma aplicação não precisa ou não deseja reter. Exemplos incluem:

- Projetos VBA, disponíveis através de [IPresentation.VbaProject](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/vbaproject/);
- dados OLE incorporados, disponíveis através de [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/pt/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- dados de controle ActiveX, disponíveis através de [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/pt/net/aspose.slides/icontrol/activexcontrolbinary/).

Defina [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) como `true` para remover esses dados binários durante o carregamento. Salve a apresentação carregada para persistir o resultado sanitizado.

Esta opção reduz a exposição a payloads incorporados indesejados, mas não é um sistema completo de detecção de malware ou sanitização de conteúdo.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **Perguntas frequentes**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Aspose.Slides gera uma exceção de análise ou de formato durante o carregamento. Trate essa falha separadamente de um erro de senha incorreta, para que a aplicação possa relatar a causa com precisão.

**O que acontece se as fontes necessárias estiverem ausentes?**

A apresentação ainda pode ser carregada, mas a renderização e exportação podem substituir fontes. Você pode configurar a substituição de fontes ou fornecer fontes personalizadas para tornar a saída mais previsível.

**Carregar uma apresentação também carrega sua mídia incorporada?**

Áudios e vídeos incorporados ficam disponíveis através do modelo de objetos da apresentação. Recursos externos são resolvidos de acordo com o comportamento configurado de carregamento de recursos e podem estar indisponíveis se suas localizações não puderem ser acessadas.