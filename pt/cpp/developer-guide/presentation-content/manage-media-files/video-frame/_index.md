---
title: Gerenciar Quadros de Vídeo em Apresentações Usando C++
linktitle: Quadro de Vídeo
type: docs
weight: 10
url: /pt/cpp/video-frame/
keywords:
- adicionar vídeo
- criar vídeo
- incorporar vídeo
- extrair vídeo
- recuperar vídeo
- quadro de vídeo
- fonte web
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para C++. Guia rápido de como-fazer."
---
## **Introdução**

Um vídeo bem colocado em uma apresentação pode tornar sua mensagem mais persuasiva e aumentar os níveis de engajamento com o público. 

O PowerPoint permite que você adicione vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado em sua máquina)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, o Aspose.Slides fornece a interface [IVideo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideo/) , a interface [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) e outros tipos relevantes. 

## **Criar um Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um frame de vídeo para incorporar o vídeo em sua apresentação. 

1. Crie uma instância da classe [Presentation ](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
1. Obtenha a referência de um slide através de seu índice. 
1. Adicione um objeto [IVideo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideo/) e passe o caminho do arquivo de vídeo para incorporá-lo na apresentação. 
1. Adicione um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) para criar um frame para o vídeo.  
1. Salve a apresentação modificada. 

Este código C++ mostra como adicionar um vídeo armazenado localmente a uma apresentação:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternativamente, você pode adicionar um vídeo passando seu caminho de arquivo diretamente para o método [AddVideoFrame()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Criar um Quadro de Vídeo com Vídeo de uma Fonte Web**

Versões mais recentes do Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) suportam vídeos online em apresentações. Se o vídeo que você deseja usar estiver disponível online (por exemplo, no YouTube), você pode adicioná-lo à sua apresentação por meio de seu link web.

1. Crie uma instância da classe [Presentation ](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) 
1. Obtenha a referência de um slide através de seu índice. 
1. Adicione um objeto [IVideo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideo/) e passe o link para o vídeo.
1. Defina uma miniatura para o frame de vídeo. 
1. Salve a apresentação. 

Este código C++ mostra como adicionar um vídeo da web a um slide em uma apresentação do PowerPoint:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instancia um objeto Presentation que representa um arquivo de apresentação
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Adiciona um Quadro de Vídeo 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Define o Modo de Reprodução e o Volume do Vídeo
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Salva a apresentação no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Recortar um Frame de Vídeo**

O Aspose.Slides permite controlar qual parte de um vídeo é reproduzida definindo os valores trim-from-start e trim-from-end através de [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/set_trimfromstart/) e [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/set_trimfromend/). Ambos os valores são especificados em milissegundos e definem quanto tempo é pulado do início e do fim do vídeo, respectivamente. Essas configurações alteram as configurações de reprodução do vídeo na apresentação; elas não cortam nem modificam de outra forma os dados binários do vídeo incorporado.

**Definir Configurações de Corte**

Para criar um frame de vídeo e definir suas configurações de corte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
1. Adicione um objeto [IVideo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideo/) à apresentação.
1. Adicione um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) a um slide.
1. Defina os valores trim-from-start e trim-from-end através de [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/set_trimfromstart/) e [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/set_trimfromend/) .
1. Salve a apresentação modificada.

O exemplo de código a seguir pula os primeiros 2,5 segundos e o último segundo de um vídeo incorporado durante a reprodução:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Ler Configurações de Corte**

Para inspecionar as configurações de corte existentes, carregue uma apresentação, encontre um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) entre as formas do primeiro slide e leia os valores através de [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/get_trimfromstart/) e [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/get_trimfromend/) .

O exemplo de código a seguir encontra o primeiro frame de vídeo no primeiro slide e relata suas configurações de corte em milissegundos:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **Gerenciar Legendas de Vídeo**

O Aspose.Slides permite gerenciar legendas fechadas para frames de vídeo em apresentações do PowerPoint. As legendas são armazenadas no formato WebVTT e expostas através do método [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/get_captiontracks/) .

**Adicionar Legendas a um Frame de Vídeo**

Para adicionar legendas a um frame de vídeo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
1. Adicione um vídeo à apresentação.
1. Adicione um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) a um slide.
1. Use a [ICaptionsCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/) retornada por [get_CaptionTracks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/get_captiontracks/) para adicionar uma faixa de legendas WebVTT.
1. Salve a apresentação modificada.

O código a seguir mostra como adicionar legendas a um frame de vídeo:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adiciona uma nova faixa de legendas a partir de um arquivo WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A interface [ICaptionsCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um stream.

**Extrair Legendas de um Frame de Vídeo**

Para extrair legendas de um frame de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Encontre o objeto [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) alvo.
1. Itere pelas faixas de legendas retornadas por [get_CaptionTracks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/get_captiontracks/) .
1. Salve cada faixa de legenda em um arquivo `.vtt` .

O código a seguir mostra como extrair legendas de um frame de vídeo:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // Salva a faixa de legendas em um arquivo WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptions/) expõe o identificador da legenda, rótulo, dados binários e dados da legenda como uma string UTF-8.

**Remover Legendas de um Frame de Vídeo**

Para remover legendas de um frame de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Obtenha o objeto [IVideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/) alvo.
1. Remova as faixas de legendas da coleção retornada por [get_CaptionTracks](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ivideoframe/get_captiontracks/) .
1. Salve a apresentação modificada.

O código a seguir mostra como remover todas as legendas de um frame de vídeo:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Remove todas as legendas do quadro de vídeo.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Se precisar remover apenas uma faixa de legenda, use os métodos [Remove](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/removeat/) em vez de [Clear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icaptionscollection/clear/) .

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos a slides, o Aspose.Slides permite extrair vídeos incorporados em apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) para carregar a apresentação que contém o vídeo. 
2. Itere por todos os objetos [ISlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/) .
3. Itere por todos os objetos [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/videoframe/) . 
4. Salve o vídeo no disco.

Este código C++ mostra como extrair o vídeo de um slide de apresentação:

```c++
// O caminho para o diretório de documentos.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **Perguntas Frequentes**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um VideoFrame?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/pt/cpp/aspose.slides/videoframe/set_playmode/) (automático ou ao clicar) e o [looping](https://reference.aspose.com/slides/pt/cpp/aspose.slides/videoframe/set_playloopmode/). Essas opções estão disponíveis nas propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/videoframe/) .

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/videoframe/set_embeddedvideo/) dentro do frame mantendo a geometria da forma; isso é um cenário comum para atualizar a mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/video/get_contenttype/) que você pode ler e usar, por exemplo ao salvá-lo no disco.