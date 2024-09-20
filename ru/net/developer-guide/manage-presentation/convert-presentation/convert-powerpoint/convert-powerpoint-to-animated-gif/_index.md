---
title: Преобразование PowerPoint в анимированный GIF
type: docs
weight: 65
url: /net/convert-powerpoint-to-animated-gif/
keywords: "Преобразовать PowerPoint, PPT, PPTX, анимированный GIF, PPT в анимированный GIF, PPTX в анимированный GIF C#, Csharp, .NET, параметры по умолчанию, пользовательские параметры"
description: "Преобразование презентации PowerPoint в анимированный GIF: PPT в GIF, PPTX в GIF на C# или .NET"
---

## Преобразование презентаций в анимированный GIF с использованием параметров по умолчанию ##

Этот пример кода на C# показывает, как преобразовать презентацию в анимированный GIF с использованием стандартных параметров:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Анимированный GIF будет создан с параметрами по умолчанию.

{{% alert title="Совет" color="primary" %}} 

Если вы хотите настроить параметры для GIF, вы можете использовать класс [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions). Смотрите пример кода ниже.

{{% /alert %}} 

## Преобразование презентаций в анимированный GIF с использованием пользовательских параметров ##
Этот пример кода показывает, как преобразовать презентацию в анимированный GIF с использованием пользовательских параметров на C#:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // размер полученного GIF  
        DefaultDelay = 2000, // как долго каждый слайд будет отображаться, прежде чем будет заменен на следующий
        TransitionFps = 35 // увеличьте FPS для улучшения качества анимации перехода
    });
}
```

{{% alert title="Информация" color="info" %}}

Вы можете ознакомиться с БЕСПЛАТНЫМ конвертером [Текст в GIF](https://products.aspose.app/slides/text-to-gif), разработанным Aspose. 

{{% /alert %}}