---
title: Конвертировать PowerPoint в анимированный GIF
type: docs
weight: 65
url: /ru/nodejs-java/convert-powerpoint-to-animated-gif/
keywords: "Конвертировать PowerPoint в анимированный GIF, PPT в GIF, PPTX в GIF"
description: "Конвертировать PowerPoint в анимированный GIF: PPT в GIF, PPTX в GIF, с помощью API Aspose.Slides."
---

## **Преобразование презентаций в анимированный GIF с настройками по умолчанию**

Этот пример кода на JavaScript показывает, как преобразовать презентацию в анимированный GIF, используя стандартные настройки:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Анимированный GIF будет создан с параметрами по умолчанию. 

{{%  alert  title="TIP"  color="primary"  %}} 

Если вы предпочитаете настроить параметры GIF, можете использовать класс [GifOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GifOptions). См. пример кода ниже.

{{% /alert %}} 

## **Преобразование презентаций в анимированный GIF с пользовательскими настройками**

Этот пример кода показывает, как преобразовать презентацию в анимированный GIF, используя пользовательские настройки в JavaScript:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// размер полученного GIF
    gifOptions.setDefaultDelay(2000);// как долго каждый слайд будет отображаться, пока не будет переключён на следующий
    gifOptions.setTransitionFps(35);// увеличить FPS для лучшего качества анимации перехода
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}

Возможно, вам будет интересно попробовать бесплатный конвертер [Text to GIF](https://products.aspose.app/slides/text-to-gif) от Aspose. 

{{% /alert %}}

## **FAQ**

**Что делать, если шрифты, использованные в презентации, не установлены на системе?**

Установите недостающие шрифты или [настроить резервные шрифты](/slides/ru/nodejs-java/powerpoint-fonts/). Aspose.Slides заменит их, но внешний вид может отличаться. Для брендинга всегда убедитесь, что необходимые шрифты явно доступны.

**Могу ли я наложить водяной знак на кадры GIF?**

Да. [Добавить полупрозрачный объект/логотип](/slides/ru/nodejs-java/watermark/) на главный слайд или отдельные слайды перед экспортом — водяной знак появится на каждом кадре.