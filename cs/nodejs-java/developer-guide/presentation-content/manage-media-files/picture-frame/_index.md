---
title: Správa rámů obrázků v prezentacích pomocí JavaScriptu
linktitle: Rám obrázku
type: docs
weight: 10
url: /cs/nodejs-java/picture-frame/
keywords:
- rám obrázku
- přidat rám obrázku
- vytvořit rám obrázku
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování rámu obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte rámy obrázků v prezentacích pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Rám obrázku je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) vlastní vložené obrazové zdroje prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čáry, otočení, oříznutí, efekty obrázku a další nastavení na úrovni rámu.

Toto oddělení je užitečné, když se stejný obrázek zobrazuje vícekrát. Přidejte obrázek do prezentace jednou, uložte vrácený [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/), a použijte tento obrázkový zdroj při vytváření rámů obrázků.

Rámy obrázků mohou obsahovat rastrové obrázky, jako jsou PNG nebo JPEG, a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování exportu, takže je užitečné se rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte rám obrázku pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná, když je přesunuta na jiný počítač.

Následující příklad přidá PNG obrázek, vytvoří rám v nativních rozměrech obrázku a aplikuje formátování čáry a otočení:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rám obrázku řídí zobrazenou geometrii; změna velikosti rámu nemění původní rozměry pixelů uložených ve vloženém obrázkovém zdroji. Tento rozdíl se stává důležitým při následném ořezávání nebo kompresi obrázku.

## **Použití relativní měřítka**

[PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) umožňuje nastavovat relativní šířku a výšku měřítka rámu pomocí [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Relativní měřítko mění nastavení měřítka rámu; nepřevzorkovává ani nekompresuje vložený obrázek.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [Picture.setLinkPathLong](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-), místo aby embedoval data obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat dostupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které mají být e‑mailem distribuovány, archivovány nebo vykresleny v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rám obrázku a nasměruje jej na lokální soubor obrázku. Zabývá se jen propojováním obrázků; propojování videí je samostatný mediální workflow a není v tomto příkladu smícháno.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Používejte odkazy, když je externí správa souborů úmyslná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s porušenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámů obrázků**

Před extrahováním obrázku z existující prezentace zkontrolujte, že tvar je skutečně [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené rámy obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API pro obrázky používá přímo [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/). Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Ukládání přes [IImage.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/#save) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete zakódované bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte binární data obrázkového zdroje.

### **Extrahování SVG obrázku**

Pro SVG obrázek [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) poskytuje objekt [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také renderovací operací, takže exportovaná grafika by neměla být považována za bit‑po‑bit kopii originálního vloženého SVG; použijte data [SvgImage.getSvgData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/#getSvgData--) když je vyžadován samotný vektorový zdroj.

## **Ořezání obrázku**

Ořezání mění, která část obrázku je viditelná uvnitř rámu. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořezání zpočátku nesmaže skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde rám obrázku a aplikuje hodnoty ořezu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Protože skrytá data obrázku jsou stále přítomna, ořez lze později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než reverzibilita, lze ořezané oblasti fyzicky odstranit, jak je popsáno v následující sekci.

## **Odstranění ořezaných dat obrázku**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný obrázkový zdroj. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace jsou odstraněné pixely již nedostupné pro pozdější operaci „uncrop“.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Metoda může do prezentace přidat nový obrázkový zdroj. Pokud je originální obrázek také používán dalšími rámy, tyto rámy stále potřebují svůj existující zdroj, takže mazání ořezaných oblastí nutně nesníží celkový počet obrázků. Ořezávání WMF nebo EMF obsahu touto metodou rasterizuje výsledek do PNG.

## **Komprese rastrových obrázků**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) snižuje rozlišení rastrového obrázku relativně k velikosti, ve které je obrázek zobrazován. Může také odstranit ořezané oblasti v téže operaci. Metoda vrací `true`, když byl obrázek změněn velikostí nebo ořezán, a `false`, když změna nebyla nutná.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturescompression/), když stačí standardní cílové rozlišení:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Místo předdefinované hodnoty lze zadat vlastní kladnou hodnotu DPI, pokud je vyžadován konkrétní cíl.

Komprese je určena pro rastrové obrázky. SVG a metafile obsah není touto rasterovou kompresí zmenšen. Také si pamatujte, že nižší rozlišení a smazané ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Kontrola efektů obrázku**

Efekty obrázku jsou uloženy na obrázku použitém rámem. Kolekce transformací obrázku může obsahovat efekty jako fixní alfa modulace pro průhlednost a luminanci pro jas a kontrast. Níže uvedený příklad bezpečně čte oba typy efektů z prvního rámu na snímku:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tyto efekty mění, jak je obrázek vykreslen v rámci; nepřepisují původní bajty vloženého obrázku.

## **Uzamčení geometrie rámu obrázku**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframelock/) řídí, které operace úprav jsou pro rám obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) zachovává proporce tvaru při změně velikosti.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uzamčení se vztahuje na tvar rámu obrázku. Neznamená to, že by zdrojový obrázek byl převezen nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku „stretch“, hodnoty stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku. Kladná procenta vytvářejí vnitřní odsazení od hrany, zatímco záporná procenta vytvářejí vnější odsazení.

To se liší od ořezu. Hodnoty ořezu určují, která část zdrojového obrázku je viditelná; stretch offset mění obdélník, do kterého je viditelná výplň obrázku natažena.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Používejte stretch offset pro umístění výplně. Používejte vlastnosti ořezu, když je cílem skrýt hrany zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy jsou snazší řídit, když je úložiště obrázků a formátování rámu odděleno:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side vykreslování, ale velké rastrové obrázky zvyšují velikost PPTX a paměťovou náročnost.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na externích souborech, které musí zůstat dostupné na uložených cestách nebo místech.
- **Ořezávání** je zpočátku neinvazivní. Skryté pixely zůstávají vloženy, dokud nejsou ořezané oblasti explicitně smazány nebo odstraněny během komprese.
- **Kompresi** lze použít k výraznému snížení velikosti souboru u příliš velkých rastrových obrázků, ale dochází k úbytku rozlišení zdroje. Měla by být použita po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektorové věrnosti. Vložené [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/) lze extrahovat přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly opakovaně využívat existující zdroj [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/), pokud je to možné, místo aby se stejný soubor znovu načítal do workflow prezentace.

U velkých prezentací je optimalizace obrázků nejúčinnější, když je prováděna selektivně: uchovávejte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné velikosti zobrazení, odstraňujte ořezané pixely jen když není potřeba další úprava, a vyhýbejte se externím odkazům, pokud správa závislostí není součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámem obrázku a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) představuje obrázkový zdroj spjatý s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) je tvar na snímku, který zobrazuje obrázek a ukládá geometrické a formátovací informace rámu, jako jsou velikost, otočení, hodnoty ořezu, efekty a uzamčení.

**Mám embedovat nebo propojovat obrázky?**

Embedujte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslená bez přístupu k externím zdrojům. Propojujte obrázky jen tehdy, když je úmyslné mít soubory mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořezávání velikost souboru PPTX?**

Ne, samotné ořezávání velikost souboru nesníží. Normální nastavení ořezu skrývá části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) nebo kompresi s odstraněním ořezaných oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění ořezaných oblastí zruší data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava ve vysokém rozlišení.

**Jak zacházet s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když záleží na vektorové věrnosti. Vložený [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/) lze extrahovat přímo. Renderování snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak mohu předejít nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro rám obrázku. Kontrola `java.instanceOf` vůči [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) zabraňuje neplatným přetypováním a umožňuje kódu ošetřit snímky, které neobsahují rámy obrázků.