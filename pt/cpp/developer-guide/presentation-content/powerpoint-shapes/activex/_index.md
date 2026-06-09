---
title: Gerenciar Controles ActiveX em Apresentações usando C++
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
description: "Saiba como o Aspose.Slides para C++ utiliza ActiveX para automatizar e aprimorar apresentações do PowerPoint, oferecendo aos desenvolvedores controle poderoso sobre os slides."
---
## **Introdução**

Os controles ActiveX são usados em apresentações. Aspose.Slides para C++ permite que você gerencie controles ActiveX, mas o gerenciamento deles é um pouco mais complexo e diferente dos objetos de forma normais. A partir do Aspose.Slides para C++ 18.1, o componente oferece suporte ao gerenciamento de controles ActiveX. No momento, você pode acessar um controle ActiveX já adicionado na sua apresentação e modificá‑lo ou excluí‑lo usando suas diversas propriedades. Lembre‑se de que os controles ActiveX não são formas e não fazem parte da IShapeCollection da apresentação, mas da IControlCollection separada. Este artigo mostra como trabalhá‑los.

## **Modificar um Controle ActiveX**
Para gerenciar um controle ActiveX simples, como uma caixa de texto e um botão de comando simples em um slide:

1. Crie uma instância da classe Presentation e carregue a apresentação que contém controles ActiveX.
1. Obtenha uma referência ao slide pelo seu índice.
1. Acesse os controles ActiveX no slide por meio da IControlCollection.
1. Acesse o controle ActiveX TextBox1 usando o objeto ControlEx.
1. Altere as diversas propriedades do controle ActiveX TextBox1, incluindo texto, fonte, altura da fonte e posição da moldura.
1. Acesse o segundo controle chamado CommandButton1.
1. Altere a legenda do botão, a fonte e a posição.
1. Desloque a posição das molduras dos controles ActiveX.
1. Grave a apresentação modificada em um arquivo PPTX.

O trecho de código abaixo atualiza os controles ActiveX nos slides da apresentação conforme mostrado abaixo.

``` cpp
// Acessando a apresentação com  controles ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// Acessando o primeiro slide na apresentação
auto slide = presentation->get_Slides()->idx_get(0);

// alterando o texto da TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // alterando a imagem substituta. O PowerPoint substituirá esta imagem durante a ativação do ActiveX, então às vezes é aceitável deixar a imagem inalterada.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// alterando a legenda do Botão
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // alterando o substituto
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// Movendo as molduras ActiveX 100 pontos para baixo
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// Salvar a apresentação com Controles ActiveX editados
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// Agora removendo os controles
slide->get_Controls()->Clear();

// Salvando a apresentação com controles ActiveX limpos
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **Adicionar um Controle ActiveX Media Player**
Os controles ActiveX são usados em apresentações. Aspose.Slides para C++ permite que você adicione e gerencie controles ActiveX, mas o gerenciamento deles é um pouco mais complexo e diferente dos objetos de forma normais. A partir do Aspose.Slides para C++ 18.1, o suporte para adicionar o controle ActiveX Media Player foi incluído no Aspose.Slides. Lembre‑se de que os controles ActiveX não são formas e não fazem parte da IShapeCollection da apresentação, mas da IControlExCollection separada. Este artigo mostra como trabalhá‑los. Para gerenciar um controle ActiveX Media Player, siga as etapas a seguir:

1. Crie uma instância da classe Presentation e carregue a apresentação de exemplo que contém controles ActiveX Media Player.
1. Crie uma instância da classe Presentation de destino e gere uma apresentação vazia.
1. Clone o slide com o controle ActiveX Media Player da apresentação modelo para a apresentação de destino.
1. Acesse o slide clonado na apresentação de destino.
1. Acesse os controles ActiveX no slide por meio da IControlCollection.
1. Acesse o controle ActiveX Media Player e defina o caminho do vídeo usando suas propriedades.
1. Salve a apresentação em um arquivo PPTX.

``` cpp
// Instanciar a classe Presentation que representa o arquivo PPTX
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// Criar instância de apresentação vazia
auto newPresentation = System::MakeObject<Presentation>();

// Remover o slide padrão
newPresentation->get_Slides()->RemoveAt(0);

// Clonar slide com o controle ActiveX Media Player
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Acessar o controle ActiveX Media Player e definir o caminho do vídeo
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// Salvar a apresentação
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**O Aspose.Slides preserva os controles ActiveX ao ler e salvar novamente se eles não puderem ser executados no runtime C++?**

Sim. O Aspose.Slides trata‑os como parte da apresentação e pode ler/modificar suas propriedades e molduras; não é necessário executar os próprios controles para preservá‑los.

**Como os controles ActiveX diferem dos objetos OLE em uma apresentação?**

Os controles ActiveX são controles interativos gerenciados (botões, caixas de texto, reprodutor de mídia), enquanto [OLE](/slides/pt/cpp/manage-ole/) refere‑se a objetos de aplicação incorporados (por exemplo, uma planilha do Excel). Eles são armazenados e manipulados de forma diferente e possuem modelos de propriedades distintos.

**Eventos ActiveX e macros VBA funcionam se o arquivo for modificado pelo Aspose.Slides?**

O Aspose.Slides preserva a marcação e os metadados existentes; entretanto, eventos e macros são executados somente dentro do PowerPoint no Windows quando a segurança permite. A biblioteca não executa VBA.