---
title: Преобразование PowerPoint в анимированный GIF
type: docs
weight: 65
url: /ru/androidjava/convert-powerpoint-to-animated-gif/
keywords: "Преобразовать PowerPoint в анимированный GIF, PPT в GIF, PPTX в GIF"
description: "Преобразование PowerPoint в анимированный GIF: PPT в GIF, PPTX в GIF с помощью API Aspose.Slides."
---

## Преобразование презентаций в анимированный GIF с использованием стандартных настроек ##

Этот пример кода на Java показывает, как преобразовать презентацию в анимированный GIF с использованием стандартных настроек:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Анимированный GIF будет создан с параметрами по умолчанию.

{{% alert title="ПОДСКАЗКА" color="primary" %}} 

Если вы предпочитаете настроить параметры для GIF, вы можете использовать класс [GifOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/GifOptions). См. пример кода ниже.

{{% /alert %}} 

## Преобразование презентаций в анимированный GIF с использованием пользовательских настроек ##
Этот пример кода показывает, как преобразовать презентацию в анимированный GIF с использованием пользовательских настроек на Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // размер результата GIF  
	gifOptions.setDefaultDelay(2000); // как долго каждый слайд будет отображаться, прежде чем будет изменен на следующий
	gifOptions.setTransitionFps(35); // увеличить FPS для лучшего качества анимации переходов
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Информация" color="info" %}}

Вам может быть интересно ознакомиться с БЕСПЛАТНЫМ конвертером [Text to GIF](https://products.aspose.app/slides/text-to-gif), разработанным Aspose. 

{{% /alert %}}