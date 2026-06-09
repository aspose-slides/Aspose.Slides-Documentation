---
title: Vídeo
type: docs
weight: 80
url: /pt/cpp/examples/elements/video/
keywords:
- exemplo de código
- vídeo
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Adicione e controle vídeos com Aspose.Slides for C++: insira, reproduza, aparar, defina quadros de pôster e exporte com exemplos em C++ para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como incorporar quadros de vídeo e definir opções de reprodução usando **Aspose.Slides for C++**.

## **Adicionar um Quadro de Vídeo**

Insira um quadro de vídeo vazio em um slide.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adicione um vídeo.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Acessar um Quadro de Vídeo**

Recupere o primeiro quadro de vídeo adicionado a um slide.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Acesse o primeiro quadro de vídeo no slide.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Remover um Quadro de Vídeo**

Exclua um quadro de vídeo do slide.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Remova o quadro de vídeo.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Definir Reprodução de Vídeo**

Configure o vídeo para reproduzir automaticamente quando o slide for exibido.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Configure o vídeo para reproduzir automaticamente.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```