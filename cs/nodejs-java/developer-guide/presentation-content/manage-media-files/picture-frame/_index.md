---
title: Správa rámečků obrázků v prezentacích pomocí JavaScriptu
linktitle: Rámeček obrázku
type: docs
weight: 10
url: /cs/nodejs-java/picture-frame/
keywords:
- rámeček obrázku
- přidat rámeček obrázku
- vytvořit rámeček obrázku
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat oříznuté oblasti
- komprimovat obrázek
- StretchOffset
- formátování rámečku obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte rámečky obrázků v prezentacích pomocí Aspose.Slides pro Node.js prostřednictvím JavaScriptu."
---
## **Přehled**

Rámeček obrázku je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, oddělené objekty: [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [ImageCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/), zatímco [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) řídí pozici obrázku, velikost, formátování čáry, otočení, ořez, efekty obrázku a další nastavení na úrovni rámce.

Toto oddělení je užitečné, když je stejný obrázek zobrazen vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/), a použijte tento zdroj obrázku při vytváření rámečků obrázků.

Rámečky obrázků mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo uložení bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte rámeček obrázku pomocí [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidá PNG obrázek, vytvoří rámec v nativních rozměrech obrázku a použije formátování čáry a otočení:

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

Rámeček obrázku řídí zobrazovanou geometrickou strukturu; změna velikosti rámce nemění původní rozměry pixelů uložených ve vloženém zdroji obrázku. Tato distinction je důležitá při ořezu nebo kompresi obrázku později.

## **Použití relativního měřítka**

[PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) poskytuje relativní škálování šířky a výšky pro rámec pomocí [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah ke zdrojové velikosti obrázku místo ručního výpočtu konečných rozměrů.

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

Relativní měřítko mění nastavení měřítka rámce; nepřevzorkovává ani nekomprimuje vložený obrázek.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [Picture.setLinkPathLong](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které musí být e‑mailem odeslány, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rámeček obrázku a nasměruje jej na místní soubor obrázku. Zabývá se pouze propojením obrázku; propojení videa je samostatný workflow a není v tomto příkladu smícháno.

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

Používejte odkazy, když je externí správa souborů záměrná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámečků obrázků**

Před extrahováním obrázku z existující prezentace zkontrolujte, že tvar je opravdu [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) a že obsahuje vložený obrázek. Propojené rámečky obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

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

Ukládání pomocí [IImage.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/#save) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete zakódované bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

U SVG obrázku [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) poskytuje objekt [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také renderovací operací, takže exportovaná grafika by neměla být považována za bit‑po‑bitovou kopii původního vloženého SVG; použijte data [SvgImage.getSvgData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/#getSvgData--) ze zdroje, pokud je vyžadován samotný vektorový zdroj.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámce. Hodnoty ořezu na [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad najde rámeček obrázku bezpečně a použije hodnoty ořezu:

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

## **Odstranění oříznutých dat obrázku**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace již odstraněné pixely nejsou k dispozici pro pozdější operaci „uncrop“.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými rámečky obrázků, tyto rámečky stále potřebují svůj existující zdroj, takže smazání oříznutých oblastí nutně nesníží celkový počet obrázků. Ořez WMF nebo EMF pomocí této metody rasterizuje oříznutý výsledek do PNG.

## **Kompresní rastrových obrázků**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) snižuje rozlišení rastrového obrázku vzhledem k velikosti, ve které je obrázek zobrazen. Může také v rámci jedné operace odstranit oříznuté oblasti. Metoda vrací `true`, když byl obrázek změněn velikostí nebo ořezán, a `false`, když nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturescompression/), pokud je dostačující standardní cílové rozlišení:

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

Kompresní proces je určen pro rastrové obrázky. SVG a metafile obsah není tímto rasterovým kompresním workflow zmenšen. Také si pamatujte, že nižší rozlišení a smazané oříznuté oblasti nelze z optimalizované prezentace obnovit. Vyberte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Správa transformací obrazu**

Pro kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řetězce operací, kontrolu, odstranění a ověření zpětné kompatibility viz [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **Uzamčení geometrie rámečku obrázku**

Nastavení [PictureFrameLock](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframelock/) řídí, které úpravy jsou pro rámeček obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) zachovává proporce tvaru při změně velikosti.

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

Uzamčení se vztahuje na tvar rámečku obrázku. Neznamená to, že musí být zdrojový obrázek přeškálován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na „stretch“, hodnoty stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku obrázku. Kladná procenta vytvářejí vnitřní odsazení od okraje, zatímco záporná procenta vytvářejí vnější výstup.

To se liší od ořezu. Hodnoty ořezu určují, která část zdrojového obrázku je viditelná; stretch‑offsety mění obdélník, do kterého je viditelná výplň obrázku natažena.

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

Používejte stretch‑offsety pro umístění výplně. Používejte ořezové vlastnosti, když chcete skrýt okraje zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy jsou snadněji spravovatelné, když jsou úložiště obrázků a formátování rámečků zpracovány odděleně:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side rendering, ale velké rastrové obrázky zvyšují velikost PPTX a využití paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na dostupnosti externích souborů na uložených cestách nebo umístěních.
- **Ořez** je zpočátku ne­destruktivní. Skryté pixely zůstávají vloženy, dokud nejsou ořezané oblasti explicitně smazány nebo odstraněny během komprese.
- **Kompresní** může podstatně snížit velikost souboru u nadměrných rastrových obrázků, ale snižuje zdrojové rozlišení. Měla by být aplikována až po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, pokud je důležitá zachování vektorové podoby. Extrahujte vložené SVG přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí renderovaný snímek na pixely.
- **Opakované obrázky** by měly opakovaně používat existující zdroj [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/), pokud je to možné, místo aby byl stejný soubor načítán znovu do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když se provádí selektivně: loga a diagramy ponechte jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte oříznuté pixely jen když další úpravy nejsou vyžadovány, a vyhýbejte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámečkem obrázku a zdrojem obrázku?**

[PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) představuje zdroj obrázku spojený s prezentací. [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) je tvar na snímku, který zobrazuje obrázek a ukládá geometrické a formátovací údaje rámce, jako jsou velikost, otočení, hodnoty ořezu, efekty a zamčení.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslovaná bez přístupu k externím zdrojům. Propojujte obrázky jen tehdy, když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Samotný ořez ne. Normální nastavení ořezu skrývá části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) nebo kompresi obrázku s odstraněním oříznutých oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rasterové rozlišení a odstranění oříznutých oblastí vymaže data obrázku. Ponechte originální zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava v vysokém rozlišení.

**Jak by měly být zpracovány SVG obrázky?**

Uchovávejte SVG obsah jako SVG, pokud je důležitá věrnost vektoru. Vložený [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/) lze extrahovat přímo. Renderování snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak se vyhnout nebezpečným přetypováním při čtení existujících snímků?**

Před použitím členů specifických pro rámeček obrázku zkontrolujte typ tvaru. Kontrola `java.instanceOf` vůči [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) zabrání neplatným přetypováním a umožní kódu zpracovat snímky, které neobsahují rámečky obrázků.