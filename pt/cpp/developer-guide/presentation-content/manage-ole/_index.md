---
title: Gerenciar OLE em Apresentações Usando C++
linktitle: Gerenciar OLE
type: docs
weight: 40
url: /pt/cpp/manage-ole/
keywords:
- objeto OLE
- Vinculação e Incorporação de Objetos
- adicionar OLE
- incorporar OLE
- adicionar objeto
- incorporar objeto
- adicionar arquivo
- incorporar arquivo
- objeto vinculado
- arquivo vinculado
- alterar OLE
- ícone OLE
- título OLE
- extrair OLE
- extrair objeto
- extrair arquivo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Otimize o gerenciamento de objetos OLE no PowerPoint e arquivos OpenDocument com o Aspose.Slides para C++. Incorpore, atualize e exporte conteúdo OLE de forma fluida."
---
## **Introdução**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) é uma tecnologia da Microsoft que permite que dados e objetos criados em um aplicativo sejam colocados em outro aplicativo por meio de vinculação ou incorporação. 

Considere um gráfico criado no MS Excel. O gráfico é então colocado dentro de um slide do PowerPoint. Esse gráfico do Excel é considerado um objeto OLE. 

- Um objeto OLE pode aparecer como um ícone. Nesse caso, ao clicar duas vezes no ícone, o gráfico é aberto em seu aplicativo associado (Excel), ou é solicitado que você selecione um aplicativo para abrir ou editar o objeto. 
- Um objeto OLE pode exibir seu conteúdo real, como o conteúdo de um gráfico. Nesse caso, o gráfico é ativado no PowerPoint, a interface do gráfico é carregada e você pode modificar os dados do gráfico dentro do PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) permite inserir OLE Objects em slides como quadros de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).
{{% /alert %}} 

## **Adicionar Quadros de Objeto OLE a Slides**

Supondo que você já tenha criado um gráfico no Microsoft Excel e deseje incorporá‑lo em um slide como um quadro de objeto OLE usando o Aspose.Slides for C++, você pode fazer isso da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtenha a referência de um slide por meio de seu índice.
3. Leia o arquivo Excel como um array de bytes.
4. Adicione o [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) ao slide contendo o array de bytes e outras informações sobre o objeto OLE.
5. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um gráfico de um arquivo Excel a um slide como um [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) usando o Aspose.Slides for C++. **Nota** que o construtor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) recebe uma extensão de objeto incorporável como segundo parâmetro. Essa extensão permite que o PowerPoint interprete corretamente o tipo de arquivo e escolha o aplicativo correto para abrir esse objeto OLE.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Preparar dados para o objeto OLE.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Adicionar Quadros de Objeto OLE Vinculados**

Aspose.Slides for C++ permite que você adicione um [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) sem incorporar dados, mas apenas com um link para o arquivo.

Este código C++ mostra como adicionar um [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) com um arquivo Excel vinculado a um slide:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Adicionar um quadro de objeto OLE com um arquivo Excel vinculado.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Acessar Quadros de Objeto OLE**

Se um objeto OLE já estiver incorporado em um slide, você pode encontrá‑lo ou acessá‑lo facilmente desta maneira:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtenha a referência do slide usando seu índice.
3. Acesse a forma [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). Em nosso exemplo, usamos o PPTX criado anteriormente que tem apenas uma forma no primeiro slide. Em seguida, *cast* esse objeto para [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Esse foi o quadro de objeto OLE desejado para ser acessado.
4. Depois que o quadro de objeto OLE for acessado, você pode executar qualquer operação nele.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) e seus dados de arquivo são acessados.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Obter os dados do arquivo incorporado.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Obter a extensão do arquivo incorporado.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Acessar Propriedades do Quadro de Objeto OLE Vinculado**

Aspose.Slides permite que você acesse as propriedades do quadro de objeto OLE vinculado.

Este código C++ mostra como verificar se um objeto OLE está vinculado e, em seguida, obter o caminho do arquivo vinculado:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Verificar se o objeto OLE está vinculado.
    if (oleFrame->get_IsObjectLink())
    {
        // Imprimir o caminho completo do arquivo vinculado.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Imprimir o caminho relativo do arquivo vinculado, se presente.
        // Apenas apresentações PPT podem conter o caminho relativo.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Alterar Dados do Objeto OLE**

{{% alert color="info" title="Note" %}}
Nesta seção, o exemplo de código abaixo usa [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/).
{{% /alert %}}

Se um objeto OLE já estiver incorporado em um slide, você pode acessar facilmente esse objeto e modificar seus dados desta maneira:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Obtenha a referência do slide por meio de seu índice. 
3. Acesse a forma [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). Em nosso exemplo, usamos o PPTX criado anteriormente que tem uma forma no primeiro slide. Em seguida, *cast* esse objeto como [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). Esse foi o quadro de objeto OLE desejado para ser acessado.
4. Depois que o quadro de objeto OLE for acessado, você pode executar qualquer operação nele.
5. Crie um objeto `Workbook` e acesse os dados OLE.
6. Acesse a `Worksheet` desejada e altere os dados.
7. Salve o `Workbook` atualizado em um stream.
8. Altere os dados do objeto OLE a partir do stream.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) é acessado, e seus dados de arquivo são modificados para atualizar os dados do gráfico.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells for C++ deve ser iniciado antes que qualquer de seus tipos seja usado.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Obter a primeira forma como um quadro de objeto OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Ler os dados do objeto OLE como um objeto Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Modificar os dados da planilha.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Alterar os dados do objeto do quadro OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Incorporar Outros Tipos de Arquivo em Slides**

Além de gráficos do Excel, o Aspose.Slides for C++ permite incorporar outros tipos de arquivos em slides. Por exemplo, você pode inserir arquivos HTML, PDF e ZIP como objetos. Quando um usuário clica duas vezes no objeto inserido, ele é aberto automaticamente no programa relevante, ou o usuário é solicitado a selecionar um programa apropriado para abri‑lo.

Este código C++ mostra como incorporar HTML e ZIP em um slide:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir Tipos de Arquivo para Objetos Incorporados**

Ao trabalhar com apresentações, pode ser necessário substituir objetos OLE antigos por novos ou substituir um objeto OLE não suportado por um suportado. O Aspose.Slides for C++ permite definir o tipo de arquivo para um objeto incorporado, possibilitando atualizar os dados do quadro OLE ou sua extensão.

Este código C++ mostra como definir o tipo de arquivo para um objeto OLE incorporado como `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Alterar o tipo de arquivo para ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Definir Imagens de Ícone e Títulos para Objetos Incorporados**

Após incorporar um objeto OLE, uma visualização composta por uma imagem de ícone é adicionada automaticamente. Essa visualização é o que os usuários veem antes de acessar ou abrir o objeto OLE. Se você quiser usar uma imagem e texto específicos como elementos na visualização, pode definir a imagem do ícone e o título usando o Aspose.Slides for C++.

Este código C++ mostra como definir a imagem do ícone e o título para um objeto incorporado: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Impedir que um Quadro de Objeto OLE seja Redimensionado e Reposicionado**

Depois de adicionar um objeto OLE vinculado a um slide de apresentação, ao abrir a apresentação no PowerPoint, pode aparecer uma mensagem solicitando a atualização dos links. Clicar no botão "Update Links" pode alterar o tamanho e a posição do quadro de objeto OLE porque o PowerPoint atualiza os dados do objeto OLE vinculado e refresca a visualização do objeto. Para impedir que o PowerPoint solicite a atualização dos dados do objeto, chame o método [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) da interface [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) com `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Extrair Arquivos Incorporados**

O Aspose.Slides for C++ permite extrair os arquivos incorporados em slides como objetos OLE da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) contendo os objetos OLE que você pretende extrair.
2. Percorra todas as formas na apresentação e acesse as formas [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).
3. Acesse os dados dos arquivos incorporados a partir dos quadros de objeto OLE e grave-os no disco.

Este código C++ mostra como extrair arquivos incorporados em um slide como objetos OLE:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **Perguntas Frequentes**

**O conteúdo OLE será renderizado ao exportar slides para PDF/imagens?**

O que está visível no slide é renderizado — o ícone/imagem substituta (pré‑visualização). O conteúdo OLE "ao vivo" não é executado durante a renderização. Se necessário, defina sua própria imagem de pré‑visualização para garantir a aparência esperada no PDF exportado.

Para também preservar o arquivo incorporado como anexo PDF, chame [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) com `true`. Essa opção está desativada por padrão. Para um exemplo e instruções para verificar o anexo, veja [Preservar Arquivos OLE Incorporados como Anexos PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Como posso bloquear um objeto OLE em um slide para que os usuários não possam movê‑lo/edita‑lo no PowerPoint?**

Bloqueie a forma: o Aspose.Slides fornece [shape-level locks](/slides/pt/cpp/applying-protection-to-presentation/). Isso não é criptografia, mas impede efetivamente edições e movimentações acidentais.

**Por que um objeto Excel vinculado "pula" ou muda de tamanho ao abrir a apresentação?**

O PowerPoint pode atualizar a pré‑visualização do OLE vinculado. Para uma aparência estável, siga as práticas da [Working Solution for Worksheet Resizing](/slides/pt/cpp/working-solution-for-worksheet-resizing/) — ajuste o quadro ao intervalo ou escale o intervalo para um quadro fixo e defina uma imagem substituta apropriada.

**Os caminhos relativos para objetos OLE vinculados serão preservados no formato PPTX?**

No PPTX, a informação de "caminho relativo" não está disponível — apenas o caminho completo. Caminhos relativos são encontrados no formato PPT antigo. Para portabilidade, prefira caminhos absolutos confiáveis/URIs acessíveis ou incorporação.