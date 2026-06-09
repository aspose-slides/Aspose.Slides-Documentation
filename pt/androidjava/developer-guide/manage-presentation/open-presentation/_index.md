---
title: Abrir Apresentações no Android
linktitle: Abrir Apresentação
type: docs
weight: 20
url: /pt/androidjava/open-presentation/
keywords:
- abrir PowerPoint
- abrir OpenDocument
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
- Android
- Java
- Aspose.Slides
description: "Abra apresentações PowerPoint (.pptx, .ppt) e OpenDocument (.odp) de forma fácil com Aspose.Slides para Android via Java—rápido, confiável, totalmente funcional."
---
## **Introdução**

Além de criar apresentações PowerPoint do zero, o Aspose.Slides também permite abrir apresentações existentes. Após carregar uma apresentação, você pode obter informações sobre ela, editar o conteúdo dos slides, adicionar novos slides, remover os existentes e muito mais.

## **Abrir Apresentações**

Para abrir uma apresentação existente, instancie a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) e passe o caminho do arquivo ao seu construtor.

O exemplo Java a seguir mostra como abrir uma apresentação e obter a contagem de slides:

```java
// Instancie a classe Presentation e passe um caminho de arquivo ao seu construtor.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Imprima o número total de slides na apresentação.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Abrir Apresentações Protegidas por Senha**

Quando precisar abrir uma apresentação protegida por senha, passe a senha através do método [setPassword](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) da classe [LoadOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/) para descriptografá‑la e carregá‑la. O código Java a seguir demonstra essa operação:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Execute operações na apresentação descriptografada.
} finally {
    presentation.dispose();
}
```

## **Abrir Apresentações Grandes**

O Aspose.Slides fornece opções—especialmente o método [getBlobManagementOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) na classe [LoadOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/)—para ajudá‑lo a carregar apresentações grandes.

O código Java a seguir demonstra como carregar uma apresentação grande (por exemplo, 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Escolha o comportamento KeepLocked—o arquivo de apresentação permanecerá bloqueado durante a vida útil de
// a instância Presentation, mas não precisa ser carregado na memória ou copiado para um arquivo temporário.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // A apresentação grande foi carregada e pode ser usada, enquanto o consumo de memória permanece baixo.

    // Faça alterações na apresentação.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Salve a apresentação em outro arquivo. O consumo de memória permanece baixo durante esta operação.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Não faça isso! Uma exceção de E/S será lançada porque o arquivo está bloqueado até que o objeto Presentation seja descartado.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// É seguro fazer isso aqui. O arquivo fonte não está mais bloqueado pelo objeto Presentation.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Para contornar certas limitações ao trabalhar com streams, o Aspose.Slides pode copiar o conteúdo de um stream. Carregar uma apresentação grande a partir de um stream faz com que a apresentação seja copiada e pode tornar o carregamento mais lento. Portanto, quando precisar carregar uma apresentação grande, recomendamos fortemente usar o caminho do arquivo da apresentação em vez de um stream.

Ao criar uma apresentação que contém objetos grandes (vídeo, áudio, imagens de alta resolução etc.), você pode usar [BLOB management](/slides/pt/androidjava/manage-blob/) para reduzir o consumo de memória.
{{%/alert %}}

## **Controlar Recursos Externos**

O Aspose.Slides fornece a interface [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iresourceloadingcallback/) que permite gerenciar recursos externos. O código Java a seguir mostra como usar a interface `IResourceLoadingCallback`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Carregue uma imagem substituta.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Use qualquer método para obter bytes
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Defina uma URL substituta.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Ignore todas as outras imagens.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Carregar Apresentações sem Objetos Binários Incorporados**

Uma apresentação PowerPoint pode conter os seguintes tipos de objetos binários incorporados:

- Projeto VBA (acessível via [IPresentation.getVbaProject](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- Dados incorporados de objeto OLE (acessível via [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Dados binários de controle ActiveX (acessível via [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Usando o método [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), você pode carregar uma apresentação sem nenhum objeto binário incorporado.

Esse método é útil para remover conteúdo binário potencialmente malicioso. O código Java a seguir demonstra como carregar uma apresentação sem nenhum conteúdo binário incorporado:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Execute operações na apresentação.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Você receberá uma exceção de validação de análise/formato durante o carregamento. Esses erros geralmente mencionam uma estrutura ZIP inválida ou registros PowerPoint corrompidos.

**O que acontece se fontes necessárias estiverem ausentes ao abrir?**

O arquivo será aberto, mas a [renderização/exportação](/slides/pt/androidjava/convert-presentation/) posterior pode substituir as fontes. [Configure substituições de fontes](/slides/pt/androidjava/font-substitution/) ou [adicione as fontes necessárias](/slides/pt/androidjava/custom-font/) ao ambiente de tempo de execução.

**E quanto à mídia incorporada (vídeo/áudio) ao abrir?**

Eles ficam disponíveis como recursos da apresentação. Se a mídia for referenciada por caminhos externos, garanta que esses caminhos estejam acessíveis no seu ambiente; caso contrário, a [renderização/exportação](/slides/pt/androidjava/convert-presentation/) pode omitir a mídia.