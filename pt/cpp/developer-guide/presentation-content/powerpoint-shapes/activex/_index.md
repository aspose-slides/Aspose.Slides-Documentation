---
title: Gerenciar Controles ActiveX em Apresentações Usando C++
linktitle: ActiveX
type: docs
weight: 80
url: /pt/cpp/activex/
keywords:
- ActiveX
- controle ActiveX
- gerenciar ActiveX
- adicionar ActiveX
- modificar ActiveX
- reprodutor de mídia
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Edite caixas de texto e botões ActiveX, atualize as pré‑visualizações de controle e reutilize um controle Windows Media Player em apresentações PowerPoint com Aspose.Slides para C++."
---
## **Introdução**

Os controles ActiveX fornecem a um slide do PowerPoint elementos interativos, como caixas de texto, botões de comando e reprodutores de mídia. Aspose.Slides para C++ expõe os controles de um slide através de [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/). Use esta coleção para editar um controle, movê‑lo no slide ou removê‑lo.

## **Listar Controles ActiveX e Suas Propriedades Armazenadas**

Para inspeccionar um modelo desconhecido, abra‑o para leitura e itere pelos controles em cada slide. O exemplo relata o número do slide, o nome do controle, [ID da classe](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/), e cada par chave‑valor em [propriedades armazenadas](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/). Ele lê a apresentação sem ativar controles, invocar eventos ou macros, alterar valores ou salvar o arquivo.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

A saída selecionada de `ActiveX.pptm` mostra uma caixa de texto e um botão de comando.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Uma coleção de propriedades vazia aparece como `[]`. Para controles que utilizam armazenamento binário, `get_Properties` pode retornar `nullptr`, exibido como `Propriedades indisponíveis`. Se precisar apenas dos nomes, use [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) após verificar se a coleção existe. O relatório lista as propriedades disponíveis na apresentação. Um controle pode suportar propriedades adicionais em tempo de execução.

## **Modificar Controles ActiveX**

O exemplo espera uma apresentação habilitada para macros com uma caixa de texto chamada `TextBox1` e um botão de comando chamado `CommandButton1` no primeiro slide. Ele usa a [coleção de propriedades de controle](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) para alterar o valor da caixa de texto e a legenda do botão. Cada controle também possui uma pré‑visualização estática que o PowerPoint pode exibir antes da ativação. Forneça um PNG para cada controle mostrando seu texto atualizado e aparência. O exemplo atribui essas imagens através de [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/).

O exemplo move todos os controles do primeiro slide 100 pontos para baixo ao mudar seu [quadro](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/). Ele salva a apresentação editada no formato PPTM e, em seguida, usa [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) para gravar uma segunda cópia com todos os controles ActiveX removidos desse slide.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **Adicionar um Controle ActiveX Media Player**

Para reutilizar um controle Windows Media Player configurado, comece com um modelo cujo primeiro slide contenha um player chamado `WindowsMediaPlayer1`. [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) copia todo o slide para uma nova apresentação. O exemplo define o `URL` do player em sua [coleção de propriedades](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) e salva o slide clonado como o único slide na saída. O vídeo permanece externo, portanto escolha um caminho que o player possa acessar durante a reprodução.

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **Perguntas Frequentes**

**O Aspose.Slides pode preservar controles ActiveX sem executá‑los?**

Sim. Aspose.Slides pode ler e salvar controles, incluindo suas propriedades e posições, sem ativá‑los.

**Como os controles ActiveX diferem dos objetos OLE?**

Os controles ActiveX permitem que os usuários interajam com um slide, por exemplo inserindo texto ou clicando em um botão. Um [objeto OLE](/slides/pt/cpp/manage-ole/) permite que um slide contenha ou vincule conteúdo gerenciado por outro aplicativo, como uma planilha do Excel.

**Os eventos ActiveX ainda dispararão macros VBA depois que eu salvar uma apresentação com Aspose.Slides?**

Salve a apresentação em um formato habilitado para macros, como PPTM, para manter seu projeto VBA. O PowerPoint para Windows pode executar os manipuladores de evento existentes quando suas configurações de segurança permitirem tanto controles ActiveX quanto macros.