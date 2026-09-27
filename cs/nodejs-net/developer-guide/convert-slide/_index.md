---
title: Převod snímků prezentace na obrázky v Node.js přes .NET
linktitle: Snímek na obrázek
type: docs
weight: 40
url: /cs/nodejs-net/convert-slide/
keywords:
- převod snímku
- snímek na obrázek
- snímek na PNG
- uložit snímek jako obrázek
- vykreslit snímek
- miniatura snímku
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vykreslete snímky z prezentací PPTX, PPT a ODP jako PNG obrázky v JavaScriptu pomocí Aspose.Slides pro Node.js přes .NET, buď s měřítkem nebo s přesnou velikostí v pixelech."
---
## **Přehled**

Aspose.Slides for Node.js via .NET vykresluje snímky z prezentací PowerPoint a OpenDocument jako obrázky, například pro zobrazení náhledů snímků na webové stránce. Tento článek ukazuje dva způsoby, jak zvolit velikost obrázku: měřítko relativně k velikosti snímku a přesnou velikost v pixelech. Obě ukázky ukládají soubory PNG.

Ukázky očekávají prezentaci pojmenovanou `sample.pptx` ve složce projektu, kterou jste vytvořili v [Installation](/slides/cs/nodejs-net/installation/). Lze použít libovolnou prezentaci PowerPoint. Uložte každou ukázku jako soubor s příponou `.js` do složky projektu a spusťte ji z této složky pomocí `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET nemá vlastní referenci API. Zrcadlí API Aspose.Slides pro .NET s názvy ve stylu camelCase, takže odkazy na API v tomto článku vedou na odpovídající třídy a členy v [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/cs/net/).
{{% /alert %}}

Pro převod snímku na obrázek postupujte podle následujících kroků:

1. Otevřete prezentaci pomocí konstruktoru [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/presentation/).
1. Získáte snímek ze sbírky [slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) metodou `get(index)`. Indexy začínají od 0.
1. Vykreslete snímek pomocí `getImageWithScale` nebo `getImageWithImageSize`. V referenci .NET API jsou oba přetížení metody [Slide.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/getimage/). Vrací objekt obrázku odpovídající typu [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/).
1. Uložte obrázek pomocí jeho metody [save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/) a hodnoty [ImageFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/), a poté zavolejte jeho metodu `dispose`.

## **Převést každý snímek na PNG obrázek**

`getImageWithScale` přijímá horizontální a vertikální faktor měřítka. Při měřítku 1 se jeden bod snímku stane jedním pixelem obrázku. Následující příklad vykresluje každý snímek při měřítku 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Měřítko 1 vykresluje jeden pixel na bod; 2 zdvojnásobí šířku i výšku.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Skript zapíše jeden soubor na snímek, např. `slide_1.png`, `slide_2.png` a tak dále, číslované od 1. Pro prezentaci 16:9 se snímky o rozměrech 960 × 540 bodů vytvoří obrázky o rozměrech 1920 × 1080 pixelů. Skryté snímky jsou také vykresleny; pro jejich přeskočení zkontrolujte vlastnost [hidden](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/hidden/) snímku. Každý obrázek je uvolněn ve svém vlastním bloku `finally`, což ho uvolní před vykreslením dalšího snímku. Bez licence se na obrázcích také objeví vodoznak evaluace; viz [Licensing](/slides/cs/nodejs-net/licensing/).

## **Převést snímek na obrázek o dané velikosti**

`getImageWithImageSize` přijímá objekt s `width` a `height` v pixelech. Následující příklad vykresluje první snímek s šířkou 1280 pixelů a výšku spočítá podle velikosti snímku, takže obrázek zachová poměr stran snímku:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

Vlastnost [slideSize.size](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesize/size/) vrací šířku a výšku snímku v bodech. Pro prezentaci 16:9 skript vypíše `Saved a 1280 x 720 image` a vytvoří soubor `slide_1_1280px.png`; pro prezentaci 4:3 má obrázek rozměry 1280 × 960 pixelů.

## **FAQ**

**Proč je obrázek z `getImage` bez parametrů tak malý?**

Bez parametrů `getImage` vykresluje snímek na 20 % jeho velikosti v bodech, takže snímek 960 × 540 bodů se změní na obrázek 192 × 108 pixelů. Použijte `getImageWithScale` nebo `getImageWithImageSize` pro volbu velikosti.

**Jak uložit JPEG nebo jiný formát obrázku?**

Předejte metodě `save` obrázku jinou hodnotu `ImageFormat`, např. `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Formát vychází z hodnoty `ImageFormat`, nikoli z přípony souboru, takže je třeba je sladit.

**Proč text na obrázcích vypadá na Linuxu jinak?**

Aspose.Slides může používat pouze fonty nainstalované na počítači, který snímky vykresluje. Když prezentace používá font, který chybí (např. Calibri na typickém Linux serveru), Aspose.Slides použije místo něj nainstalovaný font, což může změnit vzhled textu a jeho zalomení. Nainstalujte fonty, které vaše prezentace používají, abyste získali stejné obrázky jako ve Windows.

**Proč `getThumbnailWithImageSize` selhává s TypeError?**

README balíčku používá `getThumbnailWithImageSize`, ale balíček neobsahuje metody `getThumbnail`. Místo toho použijte `getImageWithImageSize`; přijímá stejný argument `{ width, height }`.