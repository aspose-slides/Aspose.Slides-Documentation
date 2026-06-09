---
title: Áudio
type: docs
weight: 70
url: /pt/cpp/examples/elements/audio/
keywords:
- exemplo de código
- áudio
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Descubra exemplos de áudio do Aspose.Slides for C++: inserir, reproduzir, cortar e extrair som em apresentações PPT, PPTX e ODP com código C++ claro."
---
Este artigo demonstra como incorporar quadros de áudio e controlar a reprodução com **Aspose.Slides for C++**. Os exemplos a seguir mostram operações básicas de áudio.

## **Adicionar um Quadro de Áudio**

Insira um quadro de áudio vazio que pode posteriormente conter dados de som incorporados.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crie um quadro de áudio vazio (o áudio será incorporado mais tarde).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Acessar um Quadro de Áudio**

Este código recupera o primeiro quadro de áudio em um slide.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Acesse o primeiro quadro de áudio no slide.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Remover um Quadro de Áudio**

Exclua um quadro de áudio adicionado anteriormente.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Remova o quadro de áudio.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Definir Reprodução de Áudio**

Configure o quadro de áudio para reproduzir automaticamente quando o slide aparecer.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Reproduza automaticamente quando o slide aparecer.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```