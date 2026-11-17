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
- efekt alfa
- řetězec efektů
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte, řetězujte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků s Aspose.Slides pro Android pomocí Javy."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrázku. Pro rámeček obrázku začněte s rámcem pomocí [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) a přistupte k [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Vrácená [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) vám umožní přidávat, procházet, zkoumat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek demonstruje kompletní pracovní postup pro jas a kontrast, barevné transformace, rozostření, průhlednost, uspořádané řetězce efektů, efektivní hodnoty, odstraňování a ověření zpětného importu PPTX.

## **Pochopení vlastnictví efektů a opětovné použití obrázku**

Obrázkový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) patří výplni obrázku a odkazuje na zdroj obrázku při ukládání kolekce transformací obrázku.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrie, nastavení ořezu a další formátování na úrovni rámce.

Proto operace transformace obrázku nemění bajty v [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). Když je stejný `IPPImage` předán více než jednou metodě [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-), každému novému rámečku obrázku je přiřazen vlastní `ISlidesPicture` a vlastní kolekce transformací. Aplikace odstínu šedi na jeden rámeček neovlivní ostatní rámečky, i když všechny používají stejný vložený obrázkový zdroj.

Stejný model `ISlidesPicture.getImageTransform` se používá i u dalších výplní obrázku, například u tvaru nebo pozadí snímku. Níže uvedené příklady se zaměřují na rámečky obrázku.

## **Použijte platné rozsahy parametrů a jednotky**

Ukázané metody používají následující sémantické rozsahy a jednotky. Udržujte hodnoty v těchto rozmezích, i když konkrétní verze knihovny neodmítnou okamžitě každou hodnotu mimo rozsah; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechá komponentu beze změny. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Žádné číselné parametry. Alfa zůstává nezměněna. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Hodnoty kanálů RGB a alfa používané `android.graphics.Color` jsou v rozsahu `0` až `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Odstín je od `0` (včetně) do `360` (vyloučeno) stupňů; množství je od `-100` do `100` procent. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Odstín je od `0` (včetně) do `360` (vyloučeno) stupňů; sytost a luminance jsou od `-100` do `100` procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující hodnoty alfa zůstávají nezměněny. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius je nezáporný a měří se v bodech; `grow` je Boolean, který určuje, zda může rozostřený obsah přesáhnout původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | `amount` nezáporné procento. Použijte `0` až `100` pro běžné škálování neprůhlednosti: `0` je plně průhledná a `100` zachovává existující alfu. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `alpha` `0` až `100`, procento neprůhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `threshold` `0` až `100`, procentní práh alfa. Hodnoty pod prahem se stanou průhlednými; hodnoty na nebo nad prahem se stanou neprůhlednými. |

U pevné modulace alfa jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednost odpovídá hodnotě modulace alfa 65 %.

## **Použití jasu a kontrastu**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) vrací operaci [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Její skalární nastavení jsou zadána při vytvoření operace. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) vrací vypočítané hodnoty pouze pro čtení, které lze prozkoumat nebo zaznamenat.

Následující příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled bez úpravy vloženého obrázku:

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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) je rozšíření Office 2010 pro efekt obrázku a není tak přenositelné jako standardní efekt luminance DrawingML. Když musí zůstat jas a kontrast upravitelné po zpětném importu PPTX, použijte [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) a ověřte výsledek po opětovném otevření souboru. Část o omezeních formátu vysvětluje tento rozdíl podrobněji.

## **Použití barevných transformací**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázku, které znovu používají jeden obrázkový zdroj. Následující příklad vytvoří pět rámců a použije odstín šedi, duotón, tónování, úpravu HSL a náhradu barvy.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) obsahuje dva nezávisle upravitelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To z něj činí užitečný příklad efektu, jehož nastavení jsou složitější než jediné skalární hodnoty.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfa. Je odlišné od [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), který mapuje jednu zdrojovou barvu na jinou a vystavuje oba formáty zdrojové i cílové barvy.

### **Použití prahu luminance**

Prahová hodnota luminance může usnadnit rozlišení slabých značek na naskenované stránce od pozadí. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) zachovává mezistupně šedi. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) mapuje luminanci na černou nebo bílou, zatímco [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) aplikuje práh na neprůhlednost.

Prahová hodnota luminance se pohybuje v rozmezí 0 % až 100 %, včetně. Pixely pod prahem se stanou černými. Pixely na nebo nad prahem se stanou bílými. Zvednutím prahu se více odstínů změní na černou, protože více z nich spadne pod limit.

Stáhněte [grayscale-swatches.png](grayscale-swatches.png) do pracovního adresáře. Každý popisek udává původní úroveň šedi na škále od 0 do 255. Příklad umístí originál vedle dvou kopií a uloží práh každé kopie do prezentace.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otevřete výstupní prezentaci v PowerPointu a porovnejte tři rámce. Vzorek označený 96 má zhruba 38 % luminance (96 ze 255). Při prahu 20 % se změní na bílou a při prahu 60 % na černou.

![Původní vzorky odstínů šedi vedle černobílých výsledků při prahových hodnotách luminance 20 % a 60 %](luminance-threshold.png)

## **Přidání rozostření, průhlednosti a alfa efektů**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) ovlivňuje všechny barevné kanály, včetně alfa. Nastavte `grow` na `true`, pokud rozostřený okraj může přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Násobí každou existující hodnotu alfa, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) místo toho přiřadí jednu hodnotu alfa všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) převádí alfu na dvě úrovně podle prahu.

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

Další operace alfa bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) – která učiní každou nenulovou alfu plně neprůhlednou; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) – která učiní každou alfu pod 100 % plně průhlednou; a [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) – která mění alfu na `100% - alfa`.

## **Vytvoření uspořádaného řetězce efektů**

Každá metoda `add...Effect` přidá novou operaci na konec kolekce. Vykreslovací modul používá kolekci jako uspořádaný pipeline: výstup operace 0 se stane vstupem operace 1 a tak dále. Výsledkem je, že stejné operace v jiném pořadí mohou vytvořit odlišný obrázek.

Například odstín šedi následovaný tónováním nejprve odstraní chromatičtí informace a potom přebarví výsledek luminance. Tónování následované odstínem šedi odstraní tónování znovu. Podobně může nahrazení alfa přepsat hodnoty alfa vypočítané dřívějšími operacemi, zatímco modulace alfa zachová jejich relativní rozdíly.

Následující příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, znovu otevře prezentaci, zkontroluje typy operací i jejich pořadí a vykreslí výsledek po opětovném otevření:

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

Kolekce neukládá kompatibilní matici, která by omezovala barevné, alfa a rozostřovací operace na oddělené řetězce. Mohou být kombinovány, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraní variaci RGB vytvořenou dřívějšími barevnými efekty; odstín šedi po duotónu odstraní dvě vybrané barvy; a operace alfa ceiling, floor, replace nebo bi‑level mohou zlikvidovat alfa detaily vytvořené dříve. Sestavte řetězec podle požadované sekvence zpracování pixelů, místo abyste jeho položky považovali za neřazené příznaky formátování.


<!-- visual-explanation:image-transform-effects:start -->
[![Stejný obrázek prochází nejprve převodem na odstíny šedi a poté tónováním, a naopak tónováním a pak převodem na odstíny šedi. Dvě výsledné obrázky v odstínech šedi mají odlišné tóny.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*V tomto ilustračním renderu Aspose.Slides pro .NET 26.11 zůstává obrázek v odstínech šedi nezměněn při tónování o 220° při 25 %. Aplikování stejného tónování před převodem na odstíny šedi vytváří odlišné tóny.*
<!-- visual-explanation:image-transform-effects:end -->

## **Prozkoumání upravitelných a efektivních hodnot**

Upravitelná operace je objekt uložený v `ISlidesPicture.getImageTransform`. V závislosti na efektu může přímo exponovat zapisovatelné členy. Například [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) exponuje zapisovatelné hodnoty `radius` a `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) exponuje zapisovatelné `amount` a [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) exponuje zapisovatelný `threshold`. Barevné efekty jako [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) exponují měnitelné objekty [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/).

Některé rozhraní operací, včetně [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/) a [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/), neexponují své tvorby jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte náhradu na požadovanou pozici.

Efektivní data vrácená metodou `getEffective()` jsou vypočítaná a pouze pro čtení. Jsou užitečná pro rozpoznání barev závislých na motivu a čtení normalizovaných hodnot, které vykreslující modul používá, ale nejsou dalším editačním povrchem. Následující příklad prochází řetězec a zkoumá efektivní hodnoty tam, kde příslušné API poskytuje tyto informace:

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

Efekty bez parametrů, jako odstín šedi, alfa ceiling a alfa inverse, stále mají objekt efektivních dat, ale neexistují žádná skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležité informace.

## **Odstranění nebo vymazání transformací obrázku**

Použijte [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) pro odebrání jedné operace podle indexu. Protože se indexy po odebrání posunou, nejprve vyhledejte cíl a až po průchodu jej odstraňte. Pro odebrání celého řetězce použijte [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--).

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

Odstranění nebo vymazání transformací mění pouze formátování obrázku. Nesmaže, nepřekomprimuje ani jinak neubahne znovu použité zdroje [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).

## **Zvažte formáty prezentací a cílové exporty**

Transformace obrázku vznikají v DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX ne všechny operace mají stejnou přenositelnost:

- Standardní operace DrawingML, jako luminance, odstín šedi, duotón, tónování, HSL, rozostření a běžné alfa operace, mají největší šanci přežít zpětný import PPTX. Vždy po uložení souboru jej znovu otevřete a zkontrolujte kolekci, pokud je zachování vyžadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) je rozšíření Office 2010, nikoli standardní operace luminance DrawingML. Lze jej použít pro vykreslování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Upřednostněte [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) pro trvalé úpravy jasu a kontrastu.
- Binární formát PPT předcházel úplnému modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako ověřovací formát pro složitý editovatelný řetězec.
- Vykreslení do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiného vizuálního výstupu použije podporovaný řetězec na vykreslený vzhled. Tyto výstupy neobsahují editovatelný `IImageTransformOperationCollection`; rastrové formáty výsledek zploští do pixelů a dokumentové/vektorové exporty ukládají vlastní reprezentaci vykreslení.
- Efekty nezpůsobí, že propojený obrázek bude samostatně uzavřený. Vykreslení propojeného obrázku stále vyžaduje, aby byl propojený zdroj dostupný při načítání prezentace.

Různí spotřebitelé prezentací mohou renderovat okrajové případy odlišně, zejména když jsou kombinovány několik alfa či barevných kvantizačních operací. Pro kritické výstupy testujte jak editovatelný zpětný import, tak finální exportní formát se stejnou verzí Aspose.Slides používanou v produkci.

## **Často kladené otázky**

**Mění efekty transformace obrázku vložená data obrázku?**

Ne. Operace patří k `ISlidesPicture` používanému výplní obrázku. Bajty podkladového `IPPImage` zůstávají nezměněny.

**Budou dva rámečky obrázku, které znovu používají stejný obrázek, sdílet své efekty?**

Ne. Opětovné použití `IPPImage` eliminuje duplicitní data obrázku, ale každý rámeček obrázku má obvykle vlastní `ISlidesPicture` a vlastní kolekci transformací obrázku.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom uspořádaném řetězci. Zvažte, co každá operace dělá s výstupem předchozí, protože operace nahrazení a prahové operace mohou odstranit dřívější barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty pouze pro čtení?**

Efektivní data představují vypočítané hodnoty používané při vykreslování, včetně rozřešených barev. Upravit lze operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte náhradu s novými parametry vytvoření.

**Jaký formát použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor jeho opětovným otevřením. Starší PPT nedokáže reprezentovat úplný model efektů DrawingML a exportní formáty jako PNG, PDF apod. zachovávají pouze vzhled, ne editovatelné operace transformace obrázku.