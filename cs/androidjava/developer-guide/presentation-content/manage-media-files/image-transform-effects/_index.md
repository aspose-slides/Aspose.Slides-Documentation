---
title: Správa efektů transformace obrázku v prezentacích na Androidu
linktitle: Efekty transformace obrázku
type: docs
weight: 11
url: /cs/androidjava/image-transform-effects/
keywords:
- transformace obrázku
- efekt obrázku
- jas
- kontrast
- odstín šedi
- duotón
- tónování
- HSL
- náhrada barvy
- rozostření
- průhlednost
- alfa efekt
- řetězec efektů
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte, řaďte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků s Aspose.Slides pro Android pomocí Javy."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako seřazenou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s [ISlidesPicture](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidespicture/) a přistupte k [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Vrácená [IImageTransformOperationCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/) vám umožní přidávat, enumerovat, zkoumat, odstraňovat a vyprázdnit efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek ukazuje kompletní pracovní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, řazené řetězce efektů, efektivní hodnoty, odstraňování a ověření PPTX round‑trip.

## **Pochopte vlastnictví efektu a opětovné použití obrázku**

Zdrojový obrazový prostředek a obrázek, který jej zobrazuje, jsou odlišné objekty:

- [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [ISlidesPicture](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidespicture/) patří k výplni obrázku a odkazuje na obrazový prostředek a zároveň uchovává kolekci operací transformace.
- [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) je tvar snímku, který vlastní odpovídající výplň obrázku, geometrie, oříznutí a další formátování na úrovni rámce.

Proto operace transformace obrazu nemění bajty v [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/). Když je stejný `IPPImage` předán metodě [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) vícekrát, každý nový rámeček obrázku získá vlastní `ISlidesPicture` a vlastní kolekci transformací. Použití odstínu šedi na jednom rámci neovlivní ostatní rámečky, i když všechny používají stejný vložený obrazový prostředek.

Stejný model `ISlidesPicture.getImageTransform` se používá i u jiných výplní obrázku, například u tvaru nebo pozadí snímku. Níže uváděné příklady se soustředí na rámečky obrázků.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Udržujte hodnoty v těchto rozsazích, i když konkrétní verze knihovny neodmítne každou mimo‑rozsahovou hodnotu okamžitě; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu beze změny. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Žádné | Žádné číselné parametry. Alfa zůstává beze změny. |
| [addDuotoneEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Hodnoty RGB a alfa kanálu použité v `android.graphics.Color` jsou od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue je od `0` (včetně) do `360` (exkluzivně) ve stupních; amount je od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue je od `0` (včetně) do `360` (exkluzivně) ve stupních; saturation a luminance jsou od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Stávající alfa hodnoty zůstávají beze změny. |
| [addBlurEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius je nezáporný a měří se v bodech; `grow` je Boolean, který určuje, zda může rozostřený obsah přesahovat původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je zcela průhledné a `100` zachovává existující alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` až `100`, procento neprůhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` až `100`, procento alfa prahu. Hodnoty pod prahem se stanou průhlednými; hodnoty na prahu nebo nad ním jsou neprůhledné. |

Pro pevnou modulaci alfy jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednost odpovídá alfabmodulačnímu množství 65 %.

## **Použijte jas a kontrast**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) vrací operaci [IBrightnessContrast](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibrightnesscontrast/). Její skalární nastavení jsou zadána při vytvoření operace. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) vrací vypočtené hodnoty jen ke čtení, které lze zkoumat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled bez změny vloženého obrazu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/brightnesscontrast/) je rozšíření Office 2010 pro efekt obrázku a není tak přenositelné jako standardní DrawingML efekt jasu. Když je potřeba, aby jas a kontrast zůstaly po PPTX round‑trip editovatelné, použijte [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) a ověřte výsledek po znovuotevření souboru. Část o omezeních formátu tento rozdíl vysvětluje podrobněji.

## **Použijte barevné transformace**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které sdílejí jeden obrazový prostředek. Následující příklad vytvoří pět rámců a použije odstín šedi, duotón, tónování, úpravu HSL a náhradu barvy.

[IDuotone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iduotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, `color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) nahrazuje barvu každého pixelu jednou fixní barvou a zachovává alfu. Liší se od [addColorChangeEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), který mapuje jednu zdrojovou barvu na jinou a vystavuje oba formáty barvy zdroje i cíle.

## **Přidejte rozostření, průhlednost a alfa efekty**

[addBlurEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) ovlivňuje všechny barevné kanály, včetně alfy. Nastavte `grow` na `true`, když rozostřený okraj může přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Násobí každou existující alfu, takže částečně průhledné pixely zůstávají relativně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) naopak přiřadí jednu alfu všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) převádí alfu na dvě úrovně podle prahu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Další alfa operace bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), která dělá každou nenulovou alfu plně neprůhlednou; [addAlphaFloorEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), která dělá každou alfu pod 100 % plně průhlednou; a [addAlphaInverseEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), která mění alfu na `100% - alpha`.

## **Vytvořte řazený řetězec efektů**

Každá metoda `add...Effect` přidá novou operaci na konec kolekce. Vykreslovač používá kolekci jako řazený pipeline: výstup operace 0 se stane vstupem operace 1 atd. Výsledkem je, že stejné operace v jiném pořadí mohou vytvořit jiný obrázek.

Například odstín šedi následovaný tónováním nejprve odstraní chromatické informace a potom obarví výsledek jasu. Tónování následované odstínem šedi odstraní tónování zpět. Podobně může alfa náhrada přepsat alfu vypočtenou dřívějšími operacemi, zatímco alfa modulace zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, znovu otevře prezentaci, ověří typy operací i jejich pořadí a vykreslí výsledek po opětovném otevření:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Kolekce nevyžaduje matici kompatibility, která by omezovala barevné, alfa a rozostřovací operace na samostatné řetězce. Mohou být kombinovány, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraňuje RGB variaci vytvořenou dřívějšími barevnými efekty; odstín šedi po duotónu odstraňuje dvě vybrané barvy; a alfa ceiling, floor, replacement nebo bi‑level operace mohou zahodit alfa detaily vytvořené dříve. Vytvářejte řetězec podle požadované sekvence zpracování pixelů, nikoli jako neuspořádané příznaky formátování.

## **Prozkoumejte editovatelné a efektivní hodnoty**

Editovatelná operace je objekt uložený v `ISlidesPicture.getImageTransform`. V závislosti na efektu může přímo vystavovat zapisovatelné členy. Například [IBlur](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iblur/) vystavuje zapisovatelné `radius` a `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ialphamodulatefixed/) vystavuje zapisovatelný `amount` a [IAlphaBiLevel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ialphabilevel/) vystavuje zapisovatelný `threshold`. Barevné efekty jako [IDuotone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iduotone/) vystavují změnitelné objekty [IColorFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorformat/).

Některé rozhraní operací, včetně [IBrightnessContrast](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itint/) a [IAlphaReplace](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ialphareplace/), neuvádějí své vytvořené skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte novou na požadovanou pozici.

Efektivní data vrácená metodou `getEffective()` jsou vypočtená a jen ke čtení. Hodí se pro řešení tématem podmíněných barev a čtení normalizovaných hodnot, které vykreslovač používá, ale nejde o další editační povrch. Následující příklad enumeruje řetězec a zkoumá efektivní hodnoty, kde je API poskytuje:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efekty bez parametrů, jako odstín šedi, alfa ceiling a alfa inverse, mají stále objekt efektivních dat, ale není co tisknout. Jejich přítomnost a pozice v kolekci jsou podstatné informace.

## **Odstraňte nebo vyprázdněte transformace obrazu**

Použijte [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) k odstranění jedné operace podle indexu. Protože se indexy po odstranění posunou, nejprve vyhledejte cíl a až po enumeraci jej odstraňte. K vyprázdnění celého řetězce použijte [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Odstranění nebo vyprázdnění transformací mění pouze formátování obrázku. Neodstraňuje, nekomprimuje ani jinak nemění znovu použitý [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) prostředek.

## **Zvažte formáty prezentací a cílové exporty**

Transformace obrazu vznikají v DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX ne každá operace má úplnou přenositelnost:

- Standardní DrawingML operace jako luminance, odstín šedi, duotón, tónování, HSL, rozostření a běžné alfa operace mají nejlepší šanci přežít PPTX round‑trip. Vždy po vygenerování souboru jej znovu otevřete a zkontrolujte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/brightnesscontrast/) je rozšíření Office 2010 místo standardní DrawingML luminance operace. Lze jej použít pro vykreslení v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný [IBrightnessContrast](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibrightnesscontrast/). Upřednostněte [addLuminanceEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) pro trvalé úpravy jasu a kontrastu.
- Binární formát PPT předchází úplnému modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů aplikuje podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelný `IImageTransformOperationCollection`; rastrové formáty výsledek zploští do pixelů a exporty dokumentu/vektoru uchovávají vlastní reprezentaci vykreslení.
- Efekty nečiní propojený obrázek samostatným. Renderování propojeného obrázku stále závisí na dostupnosti propojeného prostředku při načítání prezentace.

Různí spotřebitelé prezentací mohou vykreslovat okrajové případy odlišně, zejména když je kombinováno několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy testujte jak editovatelný round‑trip, tak finální exportní formát se stejnou verzí Aspose.Slides použité v produkci.

## **Často kladené otázky**

**Mění efekty transformace obrazu vložená data obrázku?**

Ne. Operace patří k `ISlidesPicture` používanému výplní obrázku. Bajty podkladového `IPPImage` zůstávají beze změny.

**Budou dva rámečky obrázku, které používají stejný obrázek, sdílet své efekty?**

Ne. Použití `IPPImage` eliminuje duplicitní data obrázku, ale každý rámec obrázku má obvykle samostatný `ISlidesPicture` a kolekci transformací.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je akceptuje v jednom řazeném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože operace náhrady a prahu mohou zahodit dříve vytvořené barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty jen ke čtení?**

Efektivní data představují vypočtené hodnoty použité pro vykreslení, včetně rozpoznaných barev. Editujte operaci uloženou v kolekci transformací tam, kde jsou zapisovatelné členy; jinak ji odstraňte a přidejte novou s novými parametry vytvoření.

**Jaký formát použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nedokáže reprezentovat celý model efektů DrawingML a výstupní formáty exportu zachovají pouze vzhled, nikoli editovatelné operace transformace.