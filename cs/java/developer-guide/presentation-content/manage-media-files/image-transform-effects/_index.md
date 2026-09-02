---
title: Správa efektů transformace obrázku v prezentacích s Java
linktitle: Efekty transformace obrázku
type: docs
weight: 11
url: /cs/java/image-transform-effects/
keywords:
- transformace obrázku
- efekt obrázku
- jas
- kontrast
- stupně šedi
- duotón
- odstín
- HSL
- nahrazení barvy
- rozostření
- průhlednost
- efekt alfa
- řetězec efektů
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Použijte, řetězte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků pomocí Aspose.Slides pro Java."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrazu. Pro rámeček obrázku začněte s [ISlidesPicture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidespicture/) a přistupte k [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidespicture/#getImageTransform--). Vrácená [IImageTransformOperationCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/) vám umožní přidávat, procházet, kontrolovat, odstraňovat a mazat efekty bez přepisování původních bajtů obrázku.

Tento článek ukazuje kompletní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, uspořádané řetězce efektů, efektivní hodnoty, odstraňování a ověření zpětné kompatibility PPTX.

## **Pochopte vlastnictví efektu a opětovné používání obrázku**

Obrazový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [ISlidesPicture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidespicture/) patří do výplně obrázku a odkazuje na zdroj obrázku a ukládá kolekci transformací obrázku.
- [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámečku.

Proto operace transformace obrázku nemění bajty v [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/). Když je stejný `IPPImage` předán metodě [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) vícekrát, každý nový rámeček obrázku získá svůj vlastní `ISlidesPicture` a vlastní kolekci transformací. Aplikace stupně šedi na jeden rámeček neovlivní ostatní rámečky, i když všechny používají stejný vložený obrazový zdroj.

Stejný model `ISlidesPicture.getImageTransform` používají také jiné výplně obrázku, jako je tvar nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázku.

## **Používejte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Udržujte hodnoty v těchto rozsazích, i když konkrétní verze knihovny neodmítne okamžitě každou hodnotu mimo rozsah; cílový formát prezentace může během uložení nebo při otevření souboru PowerPointem normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` až `100`, procent; `0` neovlivní komponentu. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Žádné | Žádné číselné parametry. Alfa zůstává nezměněna. |
| [addDuotoneEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dva barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `java.awt.Color` používají hodnoty `0` až `255`. |
| [addTintEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Odtón je `0` (inclusive) až `360` (exclusive) stupňů; množství je `-100` až `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Odtón je `0` (inclusive) až `360` (exclusive) stupňů; sytost a luminance jsou `-100` až `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující hodnoty alfa zůstávají nezměněny. |
| [addBlurEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je Boolean, který určuje, zda rozostřený obsah může přesahovat původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nezáporné procento. Použijte `0` až `100` pro běžné škálování průhlednosti: `0` je plně průhledná a `100` zachovává existující alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` až `100`, procenta průhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` až `100`, procenta prahu alfa. Hodnoty pod prahem se stanou průhlednými; hodnoty na nebo nad prahem se stanou neprůhlednými. |

Pro pevnou modulaci alfa jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednosti odpovídá hodnotě modulace alfa 65 %.

## **Použijte jas a kontrast**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) vrací operaci [IBrightnessContrast](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibrightnesscontrast/). Jeho skalární nastavení jsou zadána při vytvoření operace. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) vrací vypočtené hodnoty pouze pro čtení, které lze prohlížet nebo zapisovat do logu.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled bez změny vloženého obrázku:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/cs/java/com.aspose.slides/brightnesscontrast/) je rozšíření Office 2010 pro efekt obrázku a není tak přenositelné jako standardní efekt luminance v DrawingML. Když je potřeba, aby jas a kontrast zůstaly editovatelné po zpětném průchodu PPTX, použijte [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) a ověřte výsledek po opětovném otevření souboru. Oddíl omezení formátu podrobněji vysvětluje tento rozdíl.

## **Použijte transformace barev**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které používají jeden obrazový zdroj. Následující příklad vytvoří pět rámečků a aplikuje stupně šedi, duotón, odstín, úpravu HSL a nahrazení barvy.

[IDuotone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iduotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To z něj dělá užitečný příklad efektu, jehož nastavení jsou složitější než jediná skalární hodnota.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfa kanálu. Liší se od [addColorChangeEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), který mapuje jednu zdrojovou barvu na jinou a umožňuje oba formáty barvy zdroje i cíle.

## **Přidejte rozostření, průhlednost a alfa efekty**

[addBlurEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) ovlivňuje všechny barevné kanály, včetně alfa. Nastavte `grow` na `true`, když může rozostřený okraj přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Násobí každou existující hodnotu alfa, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) naproti tomu přiřadí jednu hodnotu alfa všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) převádí alfa na dvě úrovně na základě prahu.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Další operace alfa bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), který činí každou nenulovou alfa plně neprůhlednou; [addAlphaFloorEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), který dělá každou alfu pod 100 % plně průhlednou; a [addAlphaInverseEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), který mění alfa na `100% - alfa`.

## **Vytvořte uspořádaný řetězec efektů**

Každá metoda `add...Effect` přidá novou operaci na konec kolekce. Vykreslovací engine používá kolekci jako uspořádaný pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. Výsledkem je, že stejné operace v jiném pořadí mohou vytvořit odlišný obrázek.

Například stupně šedi následované odstínem nejprve odstraní chromatické informace a poté přebarví výsledek luminance. Odtín následovaný stupněm šedi opět odstraní odstín. Podobně může nahrazení alfa přepsat hodnoty alfa vypočítané předchozími operacemi, zatímco modulace alfa zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec čtyř operací, uloží jej jako PPTX, znovu otevře prezentaci, zkontroluje typy operací i jejich pořadí a vykreslí výsledek po opětovném otevření:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

Kolekce neukládá kompatibilní matici, která by omezovala barevné, alfa a rozostřovací operace na samostatné řetězce. Lze je kombinovat, ale kombinace nejsou vždy užitečné. Například pevná náhrada barvy odstraní RGB variaci vytvořenou předchozími barevnými efekty; stupně šedi po duotónu odstraní dvě vybrané barvy; a operace alfa ceiling, floor, replacement či bi‑level mohou zahodit detail alfa vytvořený dříve. Sestavujte řetězec podle požadované sekvence zpracování pixelů, nikoli jako neuspořádané příznaky formátování.

## **Prohlédněte editovatelné a efektivní hodnoty**

Editovatelná operace je objekt uložený v `ISlidesPicture.getImageTransform`. V závislosti na efektu může přímo exponovat zapisovatelné členy. Například [IBlur](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iblur/) exponuje zapisovatelné hodnoty `radius` a `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ialphamodulatefixed/) exponuje zapisovatelný `amount` a [IAlphaBiLevel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ialphabilevel/) exponuje zapisovatelný `threshold`. Barevné efekty jako [IDuotone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iduotone/) exponují měnitelné objekty [IColorFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorformat/).

Některé rozhraní operací, včetně [IBrightnessContrast](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itint/) a [IAlphaReplace](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ialphareplace/), neexponují své tvorby jako zapisovatelné vlastnosti. Chcete‑li tato nastavení změnit, odstraňte operaci a přidejte novou na požadovanou pozici.

Efektivní data vrácená metodou `getEffective()` jsou vypočtená a pouze pro čtení. Hodí se k řešení barev závislých na motivu a ke čtení normalizovaných hodnot, které engine použije, ale není to další editační plocha. Následující příklad prochází řetězec a kontroluje efektivní hodnoty, kde příslušné API poskytuje data:

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

Efekty bez parametrů, jako je stupně šedi, alfa ceiling nebo alfa inverse, mají také objekt efektivních dat, ale nemají skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležité informace.

## **Odstraňte nebo vymažte transformace obrázku**

Použijte [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) k odebrání jedné operace podle indexu. Protože se indexy po odebrání posunou, nejprve vyhledejte cílovou operaci a poté ji odeberte po procházení. Použijte [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imagetransformoperationcollection/#clear--) k odstranění celého řetězce.

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

Odstraňování nebo čištění transformací mění jen formátování obrázku. Neodstraňuje, nepřekomprimuje ani jinak nemění opakovaně použité [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) zdroje.

## **Zvažte formáty prezentací a cíle exportu**

Transformace obrazu vznikají v DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však ne každá operace má stejnou přenositelnost:

- Standardní operace DrawingML, jako jsou luminance, stupně šedi, duotón, odstín, HSL, rozostření a běžné alfa operace, mají nejlepší šanci přežít zpětný průchod PPTX. Vždy po uložení souboru znovu otevřete a prohlédněte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/cs/java/com.aspose.slides/brightnesscontrast/) je rozšíření Office 2010, nikoli standardní operace luminance v DrawingML. Lze jej použít pro renderování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný [IBrightnessContrast](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibrightnesscontrast/). Upřednostněte [addLuminanceEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) pro trvalé úpravy jasu a kontrastu.
- Binární formát PPT existoval před plným modelem efektů DrawingML. Ukládání do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako formát pro ověření složitého editovatelného řetězce.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů použije podporovaný řetězec na výsledný vzhled. Tyto výstupy neobsahují editovatelnou `IImageTransformOperationCollection`; rastrové formáty výsledek "zploští" do pixelů a exporty dokumentu/vektoru ukládají vlastní reprezentaci renderování.
- Efekty nečiní propojený obrázek samostatně uložitelným. Renderování propojeného obrázku stále závisí na dostupnosti propojeného zdroje při načtení prezentace.

Různí spotřebitelé prezentací mohou vykreslovat okrajové případy odlišně, zejména když jsou kombinovány několik alfa nebo barevných kvantizačních operací. Pro kritický výstup testujte jak editovatelný zpětný průchod, tak finální exportní formát se stejnou verzí Aspose.Slides používanou v produkci.

## **Často kladené otázky**

**Mění efekty transformace obrazu vložená data obrázku?**

Ne. Operace patří do `ISlidesPicture` používaného výplní obrázku. Underlying `IPPImage` bajty zůstávají nezměněny.

**Budou dva rámečky obrázku, které používají stejný obrázek, sdílet své efekty?**

Ne. Použití `IPPImage` zabraňuje duplicitě dat obrázku, ale každý rámeček obrázku má obvykle samostatný `ISlidesPicture` a kolekci transformací obrazu.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom uspořádaném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože operace nahrazení a prahové operace mohou zrušit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty pouze pro čtení?**

Efektivní data představují vypočtené hodnoty používané při renderování, včetně rozlišených barev. Editujte operaci uloženou v kolekci transformací tam, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte novou s novými parametry tvorby.

**Který formát použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nedokáže zobrazit celý model efektů DrawingML a renderované exportní formáty zachovávají pouze vzhled, nikoli editovatelné operace transformace.