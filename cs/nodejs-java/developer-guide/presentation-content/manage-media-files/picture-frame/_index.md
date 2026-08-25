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
- ořezat obrázek
- smazat oříznuté oblasti
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
description: "Vytvářejte, formatujte, propojujte, ořezávejte, extrahujte a komprimujte rámy obrázků v prezentacích pomocí Aspose.Slides pro Node.js přes Java."
---
## **Přehled**

Rám obrázku je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, oddělené objekty: [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čáry, otáčení, ořezávání, efekty obrázku a další nastavení na úrovni rámu.

Toto oddělení je užitečné, když se stejný obrázek zobrazuje vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/), a použijte tento zdroj obrázku při vytváření rámů obrázků.

Rám obrazu může obsahovat rastrové obrázky, jako jsou PNG nebo JPEG, i vektorové SVG obrázky. Může také odkazovat na propojené obrázky místo ukládání bajtů obrázku do prezentace. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné se rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte rám obrázku pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Obrázek se tak stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidá PNG obrázek, vytvoří rám v nativních rozměrech obrázku a použije formátování čáry a otáčení:

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

Rám obrázku řídí zobrazenou geometrii; změna velikosti rámu nemění původní rozměry pixelů uložené ve vloženém zdroji obrázku. Toto rozlišení se stává důležitým při pozdějším ořezávání nebo kompresi obrázku.

## **Použití relativní měřítka**

[PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) poskytuje relativní měřítko šířky a výšky rámu prostřednictvím [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

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

Relativní měřítko mění nastavení měřítka rámu; neprovádí přejsampleování ani kompresi vloženého obrázku.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [Picture.setLinkPathLong](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které mají být e‑mailem odesílány, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rám obrázku a nasměruje jej na místní soubor obrázku. Zabývá se pouze propojením obrázku; propojení videa je samostatný mediální workflow a není v tomto příkladu smícháno.

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

Používejte odkazy, když je externí správa souborů úmyslná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámů obrázků**

Před extrahováním obrázku z existující prezentace ověřte, že tvar je skutečně [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené rámy obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázku používá přímo [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/). Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

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

Ukládání přes [IImage.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/#save) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete zakódované bajty uložené v prezentaci místo převodu na rastrový soubor, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek poskytuje [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) objekt [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně rendrují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také operace renderování, takže exportovaná grafika by neměla být považována za bit‑za‑bitem kopii původního vloženého SVG; použijte data [SvgImage.getSvgData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/#getSvgData--) vloženého SVG, když je požadován samotný vektorový zdroj.

## **Ořezání obrázku**

Ořezávání mění, která část obrázku je viditelná uvnitř rámu. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořezání zpočátku neodstraňuje skryté pixely ze vloženého obrázku; jen mění viditelnou oblast.

Následující příklad najde rám obrázku bezpečně a použije hodnoty ořezu:

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

Protože skrytá data obrázku jsou stále přítomna, ořez lze později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než reverzibilita, lze oříznuté oblasti fyzicky odstranit, jak je popsáno v další sekci.

## **Odstranění oříznutých dat obrázku**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný zdroj obrázku. To může zmenšit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely k dispozici pro pozdější operaci „uncrop“.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán dalšími rámci obrázků, tyto rámce stále potřebují existující zdroj, takže smazání oříznutých oblastí nutně nesnižuje celkový počet obrázků. Ořezávání WMF nebo EMF obsahu touto metodou rasterizuje výsledek do PNG.

## **Komprese rastrových obrázků**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) snižuje rozlišení rastrového obrázku vzhledem k velikosti, při které je obrázek zobrazován. Může také odstranit oříznuté oblasti ve stejné operaci. Metoda vrací `true`, když byl obrázek změněn velikostí nebo ořezán, a `false`, když změna nebyla nutná.

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

Místo předdefinované hodnoty lze předat vlastní kladnou hodnotu DPI, pokud je požadován konkrétní cíl.

Komprese je určena pro rastrové obrázky. SVG a metafile obsah není touto rasterovou kompresí zmenšen. Také si pamatujte, že nižší rozlišení a smazané oříznuté oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení na základě největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Správa transformací obrazu**

Pro kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řetězení, inspekci, odstraňování a ověření round‑trip viz [Image Transform Effects](/slides/cs/nodejs-java/image-transform-effects/).

## **Uzamčení geometrie rámu obrázku**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframelock/) řídí, které editační operace jsou pro rám obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) zachovává proporce tvaru při změně velikosti.

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

Uzamčení se vztahuje na tvar rámu obrázku. Nevyžaduje, aby byl zdrojový obrázek přejsampleován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na „stretch“, hodnoty stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku rámu obrázku. Kladná procenta vytvářejí odsazení od okraje, záporná procenta vytvářejí vystoupení.

To se liší od ořezávání. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch offsety mění obdélník, do kterého je viditelná výplň obrázku natáhnuta.

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

Používejte stretch offsety pro umístění výplně. Používejte vlastnosti ořezu, když je cílem skrýt okraje zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy jsou snazší řídit, když jsou úložiště obrázku a formátování rámu obrázku řešeny odděleně:

- **Vložené obrázky** dělají prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side renderování, ale velké rastrové obrázky zvětšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na tom, že externí soubory zůstávají dostupné na uložených cestách nebo umístěních.
- **Ořezávání** je zpočátku nedestruktivní. Skryté pixely zůstávají vložené, dokud nejsou oříznuté oblasti výslovně smazány nebo odstraněny během komprese.
- **Komprese** může podstatně snížit velikost souboru u nadměrně velkých rastrových obrázků, ale obětuje rozlišení zdroje. Měla by být použita po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektoru. Extrahujte vložené SVG přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí rendrovaný snímek na pixely.
- **Opakované obrázky** by měly opakovaně používat existující zdroj [PPImage], pokud je to možné, místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když je prováděna selektivně: udržujte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte oříznuté pixely pouze tehdy, když pozdější úpravy nejsou vyžadovány, a vyhýbejte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámem obrázku a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) představuje zdroj obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) je tvar na snímku, který zobrazuje obrázek a ukládá geometrii a formátování na úrovni rámu, jako jsou velikost, otáčení, hodnoty ořezu, efekty a uzamčení.

**Mám obrázky vkládat nebo odkazovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo renderovaná bez přístupu k externím zdrojům. Odkazujte obrázky jen tehdy, když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořezávání velikost souboru PPTX?**

Ne samostatně. Normální nastavení ořezu skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) nebo kompresi obrazu s odstraněním oříznutých oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rozlišení rastru a odstranění oříznutých oblastí ztrácí data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být později vyžadována úprava ve vysokém rozlišení.

**Jak mít nakládáno s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když je důležitá vektorová věrnost. Vložený [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/) lze extrahovat přímo. Renderování snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak mohu zabránit nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro rám obrázku. Kontrola `java.instanceOf` proti [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) zabraňuje neplatným přetypováním a umožňuje kódu ošetřit snímky, které neobsahují rám obrázku.