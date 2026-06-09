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
description: "Abra apresentações PowerPoint (.pptx, .ppt) e OpenDocument (.odp) de forma simples com Aspose.Slides para .NET — rápido, confiável e com todos os recursos."
---
## **Introdução**

Além de criar apresentações PowerPoint do zero, o Aspose.Slides também permite abrir apresentações existentes. Depois de carregar uma apresentação, você pode recuperar informações sobre ela, editar o conteúdo dos slides, adicionar novos slides, remover os existentes e muito mais.

## **Abrir Apresentações**

Para abrir uma apresentação existente, instancie a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e passe o caminho do arquivo ao seu construtor.

O exemplo C# a seguir mostra como abrir uma apresentação e obter a contagem de slides:

```cs
// Instancie a classe Presentation e passe um caminho de arquivo ao seu construtor.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Imprima o número total de slides na apresentação.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Abrir Apresentações Protegidas por Senha**

Quando precisar abrir uma apresentação protegida por senha, passe a senha através da propriedade [Password](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/password/) da classe [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/) para descriptografá‑la e carregá‑la. O código C# a seguir demonstra esta operação:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Execute operações na apresentação descriptografada.
}
```

## **Abrir Apresentações Grandes**

O Aspose.Slides fornece opções — especialmente a propriedade [BlobManagementOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/blobmanagementoptions/) na classe [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/) — para ajudá‑lo a carregar apresentações grandes.

O código C# a seguir demonstra como carregar uma apresentação grande (por exemplo, 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Escolha o comportamento KeepLocked — o arquivo de apresentação permanecerá bloqueado durante a vida útil da 
        // instância Presentation, mas não precisa ser carregado na memória ou copiado para um arquivo temporário.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // A grande apresentação foi carregada e pode ser usada, enquanto o consumo de memória permanece baixo.

    // Faça alterações na apresentação.
    presentation.Slides[0].Name = "Large presentation";

    // Salve a apresentação em outro arquivo. O consumo de memória permanece baixo durante esta operação.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Não faça isso! Uma exceção de I/O será lançada porque o arquivo está bloqueado até que o objeto Presentation seja descartado.
    File.Delete(filePath);
}

// É seguro fazer isso aqui. O arquivo fonte não está mais bloqueado pelo objeto Presentation.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Para contornar certas limitações ao trabalhar com streams, o Aspose.Slides pode copiar o conteúdo de um stream. Carregar uma apresentação grande a partir de um stream faz com que a apresentação seja copiada e pode tornar o carregamento mais lento. Portanto, quando precisar carregar uma apresentação grande, recomendamos enfaticamente usar o caminho do arquivo da apresentação em vez de um stream.

Ao criar uma apresentação que contém objetos grandes (vídeo, áudio, imagens de alta resolução, etc.), você pode usar [BLOB management](/slides/pt/net/manage-blob/) para reduzir o consumo de memória.
{{%/alert %}}

## **Controlar Recursos Externos**

O Aspose.Slides fornece a interface [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/iresourceloadingcallback/) que permite gerenciar recursos externos. O código C# a seguir mostra como usar a interface `IResourceLoadingCallback`:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Carregue uma imagem substituta.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Defina uma URL substituta.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Ignorar todas as outras imagens.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Carregar Apresentações sem Objetos Binários Incorporados**

Uma apresentação PowerPoint pode conter os seguintes tipos de objetos binários incorporados:

- Projeto VBA (acessível via [IPresentation.VbaProject](https://reference.aspose.com/slides/pt/net/aspose.slides/ipresentation/vbaproject/));
- Dados incorporados de objeto OLE (acessível via [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/pt/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Dados binários de controle ActiveX (acessível via [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/pt/net/aspose.slides/icontrol/activexcontrolbinary/)).

Usando a propriedade [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), você pode carregar uma apresentação sem nenhum objeto binário incorporado.

Esta propriedade é útil para remover conteúdo binário potencialmente malicioso. O código C# a seguir demonstra como carregar uma apresentação sem nenhum conteúdo binário incorporado:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Execute operações na apresentação.
}
```

## **FAQ**

**Como posso saber se um arquivo está corrompido e não pode ser aberto?**

Você receberá uma exceção de validação de análise/formato durante o carregamento. Esses erros geralmente mencionam uma estrutura ZIP inválida ou registros PowerPoint corrompidos.

**O que acontece se fontes obrigatórias estiverem ausentes ao abrir?**

O arquivo será aberto, mas, posteriormente, [rendering/export](/slides/pt/net/convert-presentation/) pode substituir fontes. [Configure font substitutions](/slides/pt/net/font-substitution/) ou [add the required fonts](/slides/pt/net/custom-font/) ao ambiente de tempo de execução.

**E quanto à mídia incorporada (vídeo/áudio) ao abrir?**

Eles ficam disponíveis como recursos da apresentação. Se a mídia for referenciada por caminhos externos, certifique‑se de que esses caminhos estejam acessíveis no seu ambiente; caso contrário, [rendering/export](/slides/pt/net/convert-presentation/) pode omitir a mídia.