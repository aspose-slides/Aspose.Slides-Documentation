---
title: Abrir Apresentações em C++
linktitle: Abrir Apresentação
type: docs
weight: 20
url: /pt/cpp/open-presentation/
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
- C++
- Aspose.Slides
description: "Abra apresentações PowerPoint (.pptx, .ppt) e OpenDocument (.odp) sem esforço com Aspose.Slides para C++ — rápido, confiável e com todos os recursos."
---
## **Introdução**

Além de criar apresentações PowerPoint do zero, o Aspose.Slides também permite abrir apresentações existentes. Após carregar uma apresentação, você pode recuperar informações sobre ela, editar o conteúdo dos slides, adicionar novos slides, remover os existentes e muito mais.

## **Abrir Apresentações**

Para abrir uma apresentação existente, instancie a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e passe o caminho do arquivo ao seu construtor.

O exemplo C++ a seguir mostra como abrir uma apresentação e obter sua contagem de slides:

```cpp
// Instancie a classe Presentation e passe um caminho de arquivo ao seu construtor.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Imprima o número total de slides na apresentação.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Abrir Apresentações Protegidas por Senha**

Quando for necessário abrir uma apresentação protegida por senha, passe a senha através do método [set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/) da classe [LoadOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/) para descriptografá‑la e carregá‑la. O código C++ a seguir demonstra essa operação:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Execute operações na apresentação descriptografada.

presentation->Dispose();
```

## **Abrir Apresentações Grandes**

O Aspose.Slides oferece opções — particularmente o método [get_BlobManagementOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) na classe [LoadOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/) — para ajudar a carregar apresentações grandes.

O código C++ a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Escolha o comportamento KeepLocked — o arquivo de apresentação permanecerá bloqueado durante a vida útil de
// a instância Presentation, mas não precisa ser carregado na memória ou copiado para um arquivo temporário.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// A grande apresentação foi carregada e pode ser usada, enquanto o consumo de memória permanece baixo.

// Faça alterações na apresentação.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Salve a apresentação em outro arquivo. O consumo de memória permanece baixo durante esta operação.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Não faça isso! Uma exceção de I/O será lançada porque o arquivo está bloqueado até que o objeto Presentation seja descartado.
File::Delete(filePath);

presentation->Dispose();

// É seguro fazer isso aqui. O arquivo fonte não está mais bloqueado pelo objeto Presentation.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Para contornar certas limitações ao trabalhar com streams, o Aspose.Slides pode copiar o conteúdo de um stream. Carregar uma apresentação grande a partir de um stream faz com que a apresentação seja copiada e pode tornar o carregamento mais lento. Portanto, quando precisar carregar uma apresentação grande, recomendamos enfaticamente usar o caminho do arquivo da apresentação em vez de um stream.

Ao criar uma apresentação que contenha objetos grandes (vídeo, áudio, imagens de alta resolução, etc.), você pode usar o [BLOB management](/slides/pt/cpp/manage-blob/) para reduzir o consumo de memória.
{{%/alert %}}

## **Controlar Recursos Externos**

O Aspose.Slides fornece a interface [IResourceLoadingCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iresourceloadingcallback/) que permite gerenciar recursos externos. O código C++ a seguir mostra como usar a interface `IResourceLoadingCallback`:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Carregue uma imagem substituta.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Defina um URL substituto.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Ignorar todas as outras imagens.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Carregar Apresentações sem Objetos Binários Incorporados**

Uma apresentação PowerPoint pode conter os seguintes tipos de objetos binários incorporados:

- Projeto VBA (acessível via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_vbaproject/));
- Dados incorporados de objeto OLE (acessíveis via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- Dados binários de controle ActiveX (acessíveis via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Usando o método [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/), você pode carregar uma apresentação sem nenhum objeto binário incorporado.

Esse método é útil para remover conteúdo binário potencialmente malicioso. O código C++ a seguir demonstra como carregar uma apresentação sem nenhum conteúdo binário incorporado:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```

## **Perguntas Frequentes**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Você receberá uma exceção de validação/análise de formato durante o carregamento. Esses erros geralmente mencionam uma estrutura ZIP inválida ou registros do PowerPoint corrompidos.

**O que acontece se fontes necessárias estiverem ausentes ao abrir?**

O arquivo será aberto, mas posteriormente a [renderização/exportação](/slides/pt/cpp/convert-presentation/) pode substituir as fontes. [Configure substituições de fontes](/slides/pt/cpp/font-substitution/) ou [adicione as fontes necessárias](/slides/pt/cpp/custom-font/) ao ambiente de tempo de execução.

**E quanto a mídia incorporada (vídeo/áudio) ao abrir?**

Eles se tornam disponíveis como recursos da apresentação. Se a mídia for referenciada por caminhos externos, certifique‑se de que esses caminhos estejam acessíveis no seu ambiente; caso contrário, a [renderização/exportação](/slides/pt/cpp/convert-presentation/) pode omitir a mídia.