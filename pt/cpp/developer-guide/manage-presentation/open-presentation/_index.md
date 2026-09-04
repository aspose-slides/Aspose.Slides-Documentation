---
title: Abrir apresentações em C++
linktitle: Abrir apresentação
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
description: "Aprenda a abrir apresentações PowerPoint e OpenDocument em C++, fornecer senhas de abertura, controlar o carregamento de recursos e reduzir o uso de memória com Aspose.Slides para C++."
---
## **Introdução**

[Aspose.Slides para C++](https://products.aspose.com/slides/pt/cpp/) pode carregar apresentações PowerPoint e OpenDocument a partir de arquivos e fluxos. Após uma apresentação ser carregada, você pode inspecionar sua estrutura, editar slides, gerenciar recursos e salvá‑la no formato original ou em outro formato suportado.

O comportamento de carregamento pode ser personalizado através da classe LoadOptions. Por exemplo, você pode fornecer uma senha de abertura, manter objetos binários grandes fora da memória, controlar recursos externos ou omitir dados binários incorporados.

## **Abrir apresentações**

Para abrir uma apresentação existente, passe seu caminho de arquivo ao construtor Presentation. Libere a apresentação após o uso para que os manipuladores de arquivo, dados temporários e outros recursos sejam liberados prontamente.

O exemplo C++ a seguir mostra como abrir uma apresentação e obter a contagem de slides:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Abrir apresentações protegidas por senha**

Uma senha de abertura criptografa o conteúdo da apresentação. Para carregar a apresentação completa, passe a senha correta para LoadOptions::set_Password e passe as opções ao construtor Presentation. O carregamento falha quando a senha está ausente ou incorreta.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Para fluxos de detecção, validação e criptografia de senhas, consulte [Proteção de Apresentações por Senha](/slides/pt/cpp/password-protected-presentation/). Se uma apresentação criptografada foi deliberadamente salva com propriedades de documento públicas, essas propriedades podem ser lidas sem senha; consulte [Gerenciar Propriedades da Apresentação](/slides/pt/cpp/presentation-properties/).

## **Abrir apresentações grandes**

[LoadOptions::get_BlobManagementOptions] controla como o Aspose.Slides lida com objetos binários grandes, como imagens, áudio e vídeo. Você pode manter o arquivo de origem bloqueado, permitir arquivos temporários e limitar a quantidade de dados BLOB mantidos na memória.

O código C++ a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Nota" %}}
Com `PresentationLockingBehavior::KeepLocked`, o arquivo de origem permanece bloqueado até que o objeto `Presentation` seja descartado. Não mova, sobrescreva ou exclua o arquivo de origem enquanto esse objeto estiver ativo.

Aspose.Slides pode copiar o conteúdo de um fluxo de entrada durante o carregamento. Para apresentações grandes, um caminho de arquivo costuma ser mais eficiente que um fluxo. Consulte [Gerenciar BLOBs](/slides/pt/cpp/manage-blob/) para opções adicionais de armazenamento e gerenciamento de memória.
{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions::set_ResourceLoadingCallback] aceita uma implementação de IResourceLoadingCallback. O callback pode fornecer dados de substituição, redirecionar um recurso, usar o carregador padrão ou pular o recurso. Isso é útil quando as apresentações contêm imagens externas que precisam ser resolvidas de acordo com regras de segurança ou armazenamento específicas da aplicação.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Carregar apresentações sem objetos binários incorporados**

Uma apresentação pode conter dados binários incorporados que uma aplicação não precisa ou não deseja manter. Exemplos incluem:

- projetos VBA, disponíveis através de [IPresentation::get_VbaProject](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_vbaproject/);
- dados OLE incorporados, disponíveis através de [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- dados de controle ActiveX, disponíveis através de [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Passe `true` para [LoadOptions::set_DeleteEmbeddedBinaryObjects] para remover esses dados binários durante o carregamento. Salve a apresentação carregada para manter o resultado sanitizado.

Esta opção reduz a exposição a conteúdos incorporados indesejados, mas não é um sistema completo de detecção de malware ou sanitização de conteúdo.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Perguntas frequentes**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Aspose.Slides lança uma exceção de análise ou de formato durante o carregamento. Trate essa falha separadamente de um erro de senha incorreta, para que a aplicação possa relatar a causa com precisão.

**O que acontece se as fontes necessárias estiverem ausentes?**

A apresentação ainda pode ser carregada, mas a renderização e a exportação podem substituir fontes. Você pode [configurar substituição de fontes](/slides/pt/cpp/font-substitution/) ou [fornecer fontes personalizadas](/slides/pt/cpp/custom-font/) para tornar a saída mais previsível.

**O carregamento de uma apresentação também carrega sua mídia incorporada?**

Áudios e vídeos incorporados ficam disponíveis através do modelo de objetos da apresentação. Recursos externos são resolvidos de acordo com o comportamento de carregamento de recursos configurado e podem estar indisponíveis se seus locais não puderem ser acessados.