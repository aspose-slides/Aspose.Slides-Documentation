---
title: Správa efektů transformace obrázku v prezentacích pomocí Javy
linktitle: Efekty transformace obrázku
type: docs
weight: 11
url: /cs/java/image-transform-effects/
keywords:
- transformace obrázku
- efekt obrázku
- jas
- kontrast
- odstín šedé
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
- Java
- Aspose.Slides
description: "Aplikujte, řetězte, kontrolujte, odstraňujte a ověřujte efekty transformace obrázku pro rámečky obrázků pomocí Aspose.Slides pro Java."
---
## **Přehled**

Aspose.Slides představuje úpravy obrázků jako uspořádanou kolekci operací transformace obrázku. Pro rámeček obrázku začněte s rámečkem [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) a přistupte k metodě [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). Vrácená [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) vám umožní přidávat, procházet, kontrolovat, odstraňovat a vymazávat efekty, aniž byste přepisovali původní bajty obrázku.

Tento článek ukazuje kompletní pracovní postup pro jas a kontrast, transformace barev, rozostření, průhlednost, uspořádané řetězce efektů, efektivní hodnoty, odstraňování a ověření PPTX round‑trip.

## **Pochopení vlastnictví efektů a opětovného použití obrázku**

Obrázkový zdroj a obrázek, který jej zobrazuje, jsou různé objekty:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) ukládá nebo odkazuje na zdrojová data obrázku vlastněná prezentací.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) patří k výplni obrázku a odkazuje na obrázkový zdroj, zatímco uchovává kolekci transformací obrázku.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) je tvar snímku, který vlastní příslušnou výplň obrázku, geometrii, nastavení ořezu a další formátování na úrovni rámu.

Proto operace transformace obrázku nemění bajty v [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). Když je stejný `IPPImage` předán metodě [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) více než jednou, každý nový rámeček obrázku získá svůj vlastní `ISlidesPicture` a vlastní kolekci transformací. Použití odstínu šedé na jednom rámu nezpůsobí, že ostatní rámy budou také odstín šedé, i když všechny používají stejný vložený obrázkový zdroj.

Stejný model `ISlidesPicture.getImageTransform` používají také ostatní výplně obrázků, například tvar nebo pozadí snímku. Níže uvedené příklady se soustředí na rámečky obrázků.

## **Použití platných rozsahů parametrů a jednotek**

Ukázané metody používají následující sémantické rozsahy a jednotky. Dodržujte hodnoty v těchto rozsazích, i když konkrétní verze knihovny neodmítne okamžitě každý mimo‑rozsah; cílový formát prezentace může během uložení nebo při otevření souboru v PowerPointu normalizovat, vynechat nebo odmítnout neplatná data.

| Operace | Parametry | Platný rozsah a jednotka |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` až `100`, procent; `0` ponechává komponentu nezměněnou. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Žádné číselné parametry. Alfa zůstává nezměněna. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dvě barvy pro tmavé a světlé pixely. Kanály RGB a alfa v `java.awt.Color` používají hodnoty od `0` do `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Odstín (`hue`) je od `0` včetně do `360` vyloučeno, ve stupních; množství (`amount`) je od `-100` do `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Odstín (`hue`) je od `0` včetně do `360` vyloučeno, ve stupních; sytost a luminance jsou od `-100` do `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Náhradní barva používá hodnoty kanálů od `0` do `255`. Existující alfa hodnoty zůstávají nezměněny. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Poloměr je nezáporný a měří se v bodech; `grow` je logická hodnota, která určuje, zda může rozmazaný obsah přesáhnout původní hranice. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Nezáporné procento. Použijte hodnoty od `0` do `100` pro běžné škálování neprůhlednosti: `0` je zcela průhledné a `100` zachovává existující alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` až `100`, procenta neprůhlednosti. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` až `100`, procentuální alfa práh. Hodnoty pod prahovou hodnotou se stávají průhlednými; hodnoty na prahu nebo nad ním se stávají neprůhlednými. |

Pro pevnou modulaci alfa jsou průhlednost a neprůhlednost komplementární. Například 35 % průhlednosti odpovídá modulaci alfa ve výši 65 %.

## **Použití jasu a kontrastu**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) vrací operaci [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Její skalární nastavení je poskytnuto při vytvoření operace. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) vrací vypočítané pouze pro čtení hodnoty, které lze prohlédnout nebo zalogovat.

Níže uvedený příklad zvýší jas o 15 % a kontrast o 20 %, poté vykreslí náhled bez úpravy vloženého obrázku:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) je rozšíření Office 2010 pro efekt obrázku a je méně přenositelné než standardní efekt luminance v DrawingML. Když má jas a kontrast zůstat po PPTX round‑trip upravitelný, použijte [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) a ověřte výsledek po opětovném otevření souboru. Sekce omezení formátu vysvětluje tento rozdíl podrobněji.

## **Použití transformací barev**

Barevné efekty lze aplikovat nezávisle na různých rámečcích obrázků, které používají stejný obrázkový zdroj. Níže uvedený příklad vytvoří pět rámečků a aplikuje odstín šedé, duotone, tónování, úpravu HSL a náhradu barvy.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) obsahuje dva nezávisle editovatelné barevné parametry: `color1` mapuje tmavé pixely, zatímco `color2` mapuje světlé pixely. To z něj činí užitečný příklad efektu, jehož nastavení je složitější než jediná skalární hodnota.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) nahrazuje barvu každého pixelu jednou pevnou barvou při zachování alfa kanálu. liší se od [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), který mapuje jednu zdrojovou barvu na jinou a umožňuje upravovat oba formáty barvy.

### **Použití prahové luminance**

Prahová luminance může usnadnit rozlišení slabých značek na naskenované stránce od pozadí. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) zachovává střední odstíny šedé. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) mapuje luminanci na černou nebo bílou, zatímco [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) aplikuje práh na neprůhlednost.

Prahová hodnota luminance se pohybuje od 0 % do 100 %, včetně. Pixely pod prahem se stanou černými. Pixely na prahu nebo nad ním se stanou bílými. Zvýšení prahu převádí více odstínů na černou, protože více z nich spadá pod limit.

Stáhněte soubor [grayscale-swatches.png](grayscale-swatches.png) do pracovního adresáře. Každý štítek udává původní úroveň šedé na stupnici od 0 do 255. Příklad umístí originál vedle dvou kopií a uloží práh každé kopie v prezentaci.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

Otevřete výstupní prezentaci v PowerPointu a porovnejte tři rámečky. Štítek označený 96 má přibližně 38 % luminance (96 z 255). Při prahu 20 % se změní na bílou, při prahu 60 % na černou.

![Originální odstíny šedé vedle černobílých výsledků při prahových hodnotách luminance 20 % a 60 %](luminance-threshold.png)

## **Přidání rozostření, průhlednosti a alfa efektů**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) ovlivňuje všechny barevné kanály, včetně alfa. Nastavte `grow` na `true`, pokud může rozmazaný okraj přesáhnout původní hranice obrázku.

Pro jednotnou průhlednost použijte [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Násobí každou existující alfa hodnotu, takže částečně průhledné pixely zůstávají proporcionálně odlišné. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) místo toho přiřadí jednu alfa hodnotu všem pixelům. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) převádí alfa na dvě úrovně podle prahu.

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

Další operace alfa bez parametrů zahrnují [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), který nastaví každou nenulovou alfa hodnotu na plnou neprůhlednost; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), který nastaví každou alfa pod 100 % na plnou průhlednost; a [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), který mění alfa na `100 % - alfa`.

## **Vytvoření uspořádaného řetězce efektů**

Každá metoda `add...Effect` přidá novou operaci na konec kolekce. Vykreslovací část používá kolekci jako uspořádaný pipeline: výstup operace 0 se stává vstupem operace 1 a tak dále. Proto může stejná posloupnost operací v jiném pořadí vytvořit odlišný obrázek.

Například odstín šedé následovaný tónováním nejprve odstraní chromatické informace a pak přebarví výsledek luminance. Tónování následované odstínem šedým odstraní tónování. Podobně může alfa náhrada přepsat alfa hodnoty vypočtené dřívějšími operacemi, zatímco alfa modulace zachová jejich relativní rozdíly.

Níže uvedený příklad vytvoří řetězec se čtyřmi operacemi, uloží jej jako PPTX, otevře prezentaci znovu, zkontroluje typy operací i jejich pořadí a vykreslí znovuotevřený výsledek:

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

Kolekce neukládá žádnou matici kompatibility, která by omezovala barevné, alfa a rozostřovací operace na samostatné řetězce. Lze je kombinovat, ale kombinace nejsou vždy užitečné. Pevná náhrada barvy odstraňuje variaci RGB vytvořenou dřívějšími barevnými efekty; odstín šedý po duotone odstraňuje dvě vybrané barvy; a operace alfa ceiling, floor, replacement nebo bi‑level mohou zahodit alfa detail vytvořený dříve. Vytvořte řetězec podle požadované sekvence zpracování pixelů, nikoli jako neudávaný soubor příznaků formátování.

<!-- visual-explanation:image-transform-effects:start -->
[![Stejný obrázek prochází převodem na odstín šedé a pak tónováním a naopak. Dvě konečná obrázky v odstínu šedé mají odlišné tóny.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
*V tomto ilustračním renderu Aspose.Slides pro .NET 26.11 zůstává 220° tónování při 25 % nezměněné po převodu na odstín šedé. Použití stejného tónování před převodem na odstín šedé vytváří odlišné tóny.*
<!-- visual-explanation:image-transform-effects:end -->

## **Prohlížení upravitelných a efektivních hodnot**

Upravovatelná operace je objekt uložený v `ISlidesPicture.getImageTransform`. V závislosti na efektu může přímo exponovat zapisovatelná členská data. Například [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) exponuje zapisovatelné hodnoty `radius` a `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) exponuje zapisovatelný `amount` a [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) exponuje zapisovatelný `threshold`. Barevné efekty jako [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) exponují mutovatelné objekty [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/).

Některé rozhraní operací, včetně [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/) a [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), neexponují své tvorební skaláry jako zapisovatelné vlastnosti. Pro změnu těchto nastavení odstraňte operaci a přidejte náhradu na požadovanou pozici.

Efektivní data vrácená metodou `getEffective()` jsou vypočítaná a jen pro čtení. Hodí se k rozlišení barev závislých na tématu a ke čtení normalizovaných hodnot, které vykreslovací část používá, ale není to další editační plocha. Níže uvedený příklad prochází řetězec a kontroluje efektivní hodnoty, kde příslušné API poskytuje tyto informace:

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

Efekty bez parametrů, jako odstín šedý, alfa ceiling a alfa inverse, stále mají objekt efektivních dat, ale nemají žádná skalární nastavení k vytištění. Jejich přítomnost a pozice v kolekci jsou důležitou informací.

## **Odstranění nebo vymazání transformací obrázku**

Použijte [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) k odebrání jedné operace podle indexu. Protože se indexy po odebrání posouvají, nejprve najděte cíl a až po procházení jej odstraňte. K vymazání celého řetězce použijte [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--).

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

Odstranění nebo vymazání transformací mění jen formátování obrázku. Neodstraňuje, nekopresuje ani jinak nemění znovu použité zdroje [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).

## **Zvažování formátů prezentací a cílů exportu**

Transformace obrázku pocházejí z DrawingML, takže PPTX je preferovaný editovatelný formát pro řetězce efektů. I v PPTX však ne každá operace má stejnou přenositelnost:

- Standardní DrawingML operace, jako luminance, odstín šedý, duotone, tónování, HSL, rozostření a běžné alfa operace, mají nejlepší šanci přežít PPTX round‑trip. Vždy po uložení souboru znovu otevřete a prohlédněte kolekci, pokud je zachování požadováno.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) je rozšíření Office 2010 a nikoli standardní operace luminance v DrawingML. Lze jej použít pro renderování v paměti, ale není zaručeno, že po uložení a opětovném otevření PPTX zůstane editovatelný [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Pro trvalé úpravy jasu a kontrastu upřednostněte [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-).
- Binární formát PPT předchází úplnému modelu efektů DrawingML. Uložení do PPT může vynechat nepodporované operace, zredukovat řetězec na podporovanou podmnožinu nebo aproximovat vzhled. Nepoužívejte PPT jako formát pro ověření složitých editovatelných řetězců.
- Renderování do PNG, JPEG, TIFF, PDF, SVG, HTML nebo jiných vizuálních výstupů použije podporovaný řetězec k vytvoření vzhledu. Tyto výstupy neobsahují editovatelnou `IImageTransformOperationCollection`; rastrové formáty výsledek rozloží na pixely a exporty dokumentu/vektoru ukládají vlastní reprezentaci renderování.
- Efekty nezpůsobí, že odkazovaný obrázek bude samostatně uložený. Renderování odkazovaného obrázku stále závisí na dostupnosti odkazovaného zdroje při načítání prezentace.

Různí spotřebitelé prezentací mohou renderovat okrajové případy odlišně, zejména když jsou zkombinovány několik alfa nebo barevných kvantizačních operací. Pro kritické výstupy testujte jak editovatelný round‑trip, tak finální exportní formát se stejnou verzí Aspose.Slides používanou ve výrobu.

## **Často kladené otázky**

**Mění efekty transformace obrázku vložená data obrázku?**

Ne. Operace patří k `ISlidesPicture` používanému výplní obrázku. Podkladové bajty `IPPImage` zůstávají beze změny.

**Budou dva rámečky obrázku, které používají stejný obrázek, sdílet své efekty?**

Ne. Opětovné použití `IPPImage` eliminuje duplicitní data obrázku, ale každý rámeček obrázku má obvykle vlastní `ISlidesPicture` a vlastní kolekci transformací obrázku.

**Lze kombinovat barevné, rozostřovací a alfa efekty?**

Ano. Kolekce je přijímá v jednom uspořádaném řetězci. Zvažte, jak každá operace ovlivní výstup předchozí, protože operace náhrady a prahu mohou zahodit dříve vytvořené barevné nebo alfa detaily.

**Proč jsou efektivní hodnoty jen pro čtení?**

Efektivní data představují vypočítané hodnoty používané při renderování, včetně rozpoznaných barev. Upravte operaci uloženou v kolekci transformací, kde existují zapisovatelné členy; jinak ji odstraňte a přidejte náhradu s novými parametry tvorby.

**Jaký formát použít pro zachování řetězce transformací?**

Použijte PPTX a ověřte soubor opětovným otevřením. Starší PPT nedokáže reprezentovat celý model efektů DrawingML a výstupní formáty exportu zachovávají jen vzhled, ne editovatelné operace transformace.