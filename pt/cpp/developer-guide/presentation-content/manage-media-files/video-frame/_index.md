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
description: "Aprenda a adicionar e extrair quadros de vídeo programaticamente em slides PowerPoint e OpenDocument usando Aspose.Slides para C++. Guia rápido de como-fazer."
---
## **Introdução**

Os vídeos podem ajudar a explicar ideias e envolver o público. Aspose.Slides for C++ permite adicionar quadros de vídeo aos slides, ajustar as configurações de reprodução, gerenciar legendas e extrair dados de vídeo incorporados.

O PowerPoint suporta vídeos locais e links para vídeos online, como vídeos do YouTube.

Para representar dados de vídeo e quadros de vídeo, o Aspose.Slides fornece a interface [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) , a interface [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) e outros tipos relevantes.

## **Criar um Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao slide está armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo em sua apresentação.

Este exemplo incorpora um vídeo local no primeiro slide de uma apresentação existente e salva o resultado. As coordenadas e dimensões do quadro estão em pontos. O fluxo permanece aberto até que a gravação termine porque [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) o mantém bloqueado enquanto a apresentação o utiliza.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

Você também pode passar um caminho de vídeo local diretamente para [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Este exemplo incorpora o vídeo no primeiro slide de uma nova apresentação. O vídeo deve permanecer acessível até que a apresentação seja salva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Criar um Quadro de Vídeo com Vídeo de uma Fonte Web**

O Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) suporta vídeos online em apresentações. Você pode criar um quadro de vídeo que faça link para um vídeo online, como um vídeo do YouTube.

Este exemplo adiciona um link de vídeo do YouTube e uma miniatura ao primeiro slide. Substitua o identificador do vídeo para usar outro vídeo. O método [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) solicita reprodução automática. Baixar a miniatura e reproduzir o vídeo requer acesso à internet. O visualizador de apresentações também deve suportar reprodução de vídeo online.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Reproduzir um Vídeo em Modo de Tela Cheia**

Em uma apresentação de treinamento, você pode reproduzir uma demonstração de software em modo de tela cheia para que o público veja os detalhes. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) aceita `true` para habilitar esse comportamento durante a reprodução.

Este exemplo abre uma apresentação, encontra o primeiro [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) no primeiro slide e habilita a reprodução em tela cheia. A apresentação de entrada deve conter ao menos um slide com um quadro de vídeo existente no primeiro slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A reprodução em tela cheia controla como o vídeo é exibido. Independentemente, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) controla se ele inicia automaticamente ou ao clicar, e [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) controla se ele se repete. Para escolher o comportamento de início, defina o modo de reprodução para [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). O exemplo preserva as configurações de início e loop existentes.

## **Retroceder um Vídeo Após a Reprodução**

Em uma apresentação de treinamento, retornar um vídeo de demonstração ao início o deixa pronto para o apresentador reproduzir novamente. Chame [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) com `true` para devolver o vídeo ao início após a reprodução terminar.

Este exemplo abre uma apresentação, encontra o primeiro [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) no primeiro slide e habilita o retrocesso. Ele desabilita o loop para que a reprodução possa terminar e define a reprodução para iniciar ao clicar. A apresentação de entrada deve conter ao menos um slide com um quadro de vídeo existente no primeiro slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O retrocesso devolve o vídeo ao início sem inici‑lo novamente. Em contraste, habilitar [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) repete a reprodução automaticamente. Mantenha o loop desativado quando desejar que o vídeo termine e permaneça pronto para ser reproduzido novamente. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) controla independentemente o início automático ou ao clicar; este exemplo usa [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) para que o apresentador controle quando a reprodução começa. Defina o modo de reprodução após a configuração de loop, conforme mostrado no exemplo. O retrocesso funciona independentemente de [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Cortar um Quadro de Vídeo**

Use [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) e [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) para pular parte do início ou do final de um vídeo durante a reprodução. Ambos os valores estão em milissegundos. O corte altera as configurações de reprodução sem modificar os dados de vídeo incorporados.

**Definir Configurações de Corte**

Este exemplo incorpora um vídeo local e pula os primeiros 2,5 segundos e o último segundo durante a reprodução. Use um vídeo com mais de 3,5 segundos para que reste um segmento reproduzível.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Ler Configurações de Corte**

Este exemplo exibe os valores de corte do primeiro quadro de vídeo no primeiro slide em milissegundos. A apresentação deve conter ao menos um slide. Se esse slide não possuir quadro de vídeo, nada será exibido. O exemplo anterior produz valores de 2500 e 1000.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **Gerenciar Legendas de Vídeo**

Aspose.Slides permite gerenciar legendas ocultas para quadros de vídeo em apresentações do PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através do método [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Adicionar Legendas a um Quadro de Vídeo**

Este exemplo incorpora um vídeo local e adiciona uma faixa de legenda WebVTT rotulada como English. Os carimbos de tempo das legendas devem corresponder ao vídeo. A apresentação salva inclui tanto o vídeo quanto suas legendas.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A interface [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um fluxo.

**Extrair Legendas de um Quadro de Vídeo**

Este exemplo salva todas as faixas de legenda dos quadros de vídeo no primeiro slide como arquivos WebVTT separados. Números sequenciais mantêm os arquivos de saída distintos. O console relata o número de faixas extraídas. A apresentação deve conter ao menos um slide.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) expõe o identificador da legenda, o rótulo, os dados binários e o texto da legenda como uma string UTF-8.

**Remover Legendas de um Quadro de Vídeo**

Este exemplo remove todas as legendas do quadro de vídeo na primeira posição da forma no primeiro slide e salva o resultado. Assume‑se que o slide e a forma existam e que a forma seja um quadro de vídeo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Se precisar remover apenas uma faixa de legenda, use os métodos [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) em vez de [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos aos slides, Aspose.Slides permite extrair vídeos incorporados em apresentações.

Este exemplo extrai vídeos incorporados de cada slide em arquivos binários separados e numerados. Vídeos vinculados são ignorados porque não possuem dados incorporados. O console imprime o tipo MIME de cada vídeo e o total de contagem. A saída usa a extensão genérica `.bin`; altere‑a para corresponder ao tipo de mídia relatado quando necessário.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **FAQ**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um quadro de vídeo?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (auto ou ao clicar) e o [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Essas opções estão disponíveis através dos métodos do objeto [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você cria um link para um vídeo online e adiciona uma miniatura, a apresentação armazena o link e a imagem de pré‑visualização em vez dos dados do vídeo, de modo que o aumento de tamanho costuma ser menor.

**Posso substituir o vídeo em um quadro de vídeo existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) dentro do quadro preservando a geometria da forma; este é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) que você pode ler e usar, por exemplo ao salvá‑lo no disco.