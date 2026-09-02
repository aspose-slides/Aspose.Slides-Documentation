---
title: "Optimalizace správy obrázků v prezentacích pomocí JavaScriptu"
linktitle: "Správa obrázků"
type: docs
weight: 10
url: /cs/nodejs-java/image/
keywords:
- "přidat obrázek"
- "přidat grafiku"
- "nahradit obrázek"
- "kolekce obrázků"
- "rámeček obrázku"
- "propojený obrázek"
- "pozadí"
- "přidat PNG"
- "přidat JPG"
- "přidat SVG"
- "SVG na tvary"
- "externí SVG zdroje"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Zjistěte, jak přidávat, znovu používat, propojit, nahrazovat a spravovat rastrové i SVG obrázky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js prostřednictvím Java."
---
## **Úvod**

Aspose.Slides for Node.js via Java nabízí několik způsobů práce s obrázky a každý slouží jinému účelu. Obrázek můžete uložit v prezentaci, zobrazit ho v rámečku obrázku, použít jako pozadí snímku, odkazovat na externí obrázek, nahradit sdílený zdroj obrázku nebo převést obsah SVG na editovatelné tvary.

Tento článek se zaměřuje na zdroje obrázků a jejich použití v celé prezentaci. Pro ořezávání, průhlednost, efekty, roztahování a další formátování aplikované na jednotlivý rámeček obrázku viz [Rámeček obrázku](/slides/cs/nodejs-java/picture-frame/).

## **Pochopte model obrázků**

Následující pojmy API jsou úzce související, ale nejsou zaměnitelné:

- [Prezentační kolekce obrázků](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/) ukládá zdroje obrázků používané v prezentaci. Použijte [ImageCollection.addImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/) k přidání dat obrázku a získání zdroje [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/).
- [Rámeček obrázku](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) je tvar, který zobrazuje obrázek na snímku, rozvržení nebo masteru. Použijte [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/) k umístění zdroje obrázku na snímek.
- Pozadí snímku používá obrázek jako část výplně snímku místo tvaru, a proto se nechová jako rámeček obrázku.
- [PPImage.replaceImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) nahrazuje zdroj obrázku. Pokud ho používá několik prvků prezentace, všichni používají náhradu.
- Převod SVG na tvary vytváří editovatelné tvary snímku. Po převodu již není obsah spravován jako jeden zdroj obrázku.

Typický postup je tedy: přidat data obrázku do kolekce obrázků, získat [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) a poté tento zdroj použít v jednom či více rámečcích obrázku nebo výplních.

## **Přidání vloženého obrázku**

Chcete‑li vložit lokální obrázek, načtěte soubor, přidejte jej do kolekce obrázků a vytvořte rámeček obrázku, který použije vrácený zdroj [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obrázek přidaný tímto způsobem je vložený v prezentaci, takže výsledný soubor nezávisí na tom, zda je původní soubor obrázku nadále dostupný.

### **Přidání obrázku z webu**

Když je obrázek dostupný přes HTTP nebo HTTPS, stáhněte jeho bajty, přidejte je do kolekce obrázků prezentace a použijte vrácený zdroj obrázku stejným způsobem jako lokální obrázek.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

V dlouho běžících aplikacích znovu používejte HTTP klienta nebo strategii správy připojení vhodnou pro aplikaci místo opakovaného vytváření zbytečné síťové infrastruktury. Také validujte vzdálené URL, velikosti odpovědí a typy obsahu, pokud zdroj není důvěryhodný.

## **Opětovné použití obrázků napříč snímky**

Pokud je stejný obrázek potřeba vícekrát, přidejte jej do prezentace jednou a znovu použijte získaný [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) při vytváření dalších rámečků obrázku. Tím se vyhnete opakovanému načítání stejných zdrojových dat a vztah mezi sdíleným zdrojem obrázku a jeho použitím je explicitní.

Pro grafiku, která by měla automaticky vystupovat na mnoha snímcích, například firemní logo, zvažte umístění rámečku obrázku na [slide master](/slides/cs/nodejs-java/slide-master/) nebo rozvržení místo přidávání ekvivalentního tvaru na každý snímek.

## **Použití obrázku jako pozadí snímku**

Obrázek pozadí je přiřazen k výplni snímku; není přidán jako tvar rámečku obrázku. To je užitečné, když má obrázek zakrývat pozadí snímku a neměl by být manipulován jako běžný objekt snímku.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Další možnosti pozadí, včetně pozadí masteru a rozvržení, najdete v [Presentation Background](/slides/cs/nodejs-java/presentation-background/).

## **Vložené obrázky a propojené obrázky**

Vložené a propojené obrázky mají odlišné kompromisy v přenositelnosti a velikosti souboru:

- **Vložený obrázek:** data obrázku jsou uložena uvnitř prezentace. Prezentace je samostatná, ale velikost souboru zahrnuje data obrázku.
- **Propojený obrázek:** prezentace ukládá cestu nebo URL k externímu obrázku. To může zmenšit velikost prezentace, ale externí zdroj musí zůstat přístupný při otevření nebo renderování prezentace.

Propojený obrázek lze vytvořit přiřazením externí cesty nebo URL pomocí [Picture.setLinkPathLong](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picture/) místo vložení dat obrázku.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Používejte propojené obrázky jen tehdy, když prostředí nasazení může spolehlivě přistupovat k externímu zdroji. Pro prezentace, které musí fungovat offline nebo být přenášeny mezi systémy, jsou vložené obrázky obvykle bezpečnější.

## **Práce s SVG obrázky**

SVG je vektorový formát, takže může být užitečný pro ikony, diagramy a další grafiku, která by měla být škálovatelná bez ztráty detailů, jaké mají rastrové obrázky. Aspose.Slides podporuje SVG jak jako zdroj obrázku, tak jako zdroj pro editovatelné tvary snímku.

### **Přidání SVG jako obrázku**

Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/), přidejte jej do kolekce obrázků a umístěte výsledný zdroj obrázku do rámečku obrázku.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG soubory s externími zdroji**

SVG může odkazovat na externí obrázky, styly nebo fonty. Pro tyto případy poskytuje [SvgImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/svgimage/) konstruktory, které akceptují [ExternalResourceResolver](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/externalresourceresolver/) a základní URI. Resolver může mapovat relativní URI na povolenou absolutní URI a vrátit proud pro požadovaný zdroj.

Resolver zpřístupňuje externí zdroje během zpracování SVG Aspose.Slides, ale nepřepisuje SVG na samostatný dokument. Pokud SVG musí zůstat přenosné, vložte jeho požadované zdroje přímo do SVG, například pomocí `data:` URI pro propojené obrázky.

Když SVG soubory pocházejí z nedůvěryhodných zdrojů, omezte schémata, umístění souborů a hosty, ke kterým může resolver přistupovat. Síťové resolvery by měly také uplatňovat časové limity, limity velikosti odpovědi a validaci obsahu.

### **Převod SVG na editovatelné tvary**

Aspose.Slides dokáže převést SVG na skupinu editovatelných tvarů snímku, podobně jako odpovídající příkaz v PowerPointu.

![PowerPoint Popup Menu](img_01_01.png)

Použijte přetížení [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/) přijímající SVG obrázek k provedení převodu.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Použijte převod SVG‑na‑tvary, když je potřeba individuální vektorové elementy upravit jako tvary PowerPointu. Pokud má být SVG pouze zobrazen, je jednodušší ponechat jej jako obrázek a vyhnout se vytváření mnoha samostatných tvarů.

## **Nahrazení existujícího zdroje obrázku**

Použijte [PPImage.replaceImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/), když chcete nahradit existující zdroj obrázku. To je zvláště užitečné pro sdílenou grafiku, jako jsou loga.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud několik rámečků obrázku, pozadí, masterů nebo rozvržení používá stejný zdroj obrázku, jeho nahrazení aktualizuje všechny tyto použití. Pokud má změnit jen jeden rámeček, přiřaďte mu jiný obrázek místo nahrazení sdíleného zdroje.

[PPImage.replaceImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) také poskytuje přetížení přijímající pole bajtů nebo jiný [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/).

## **Praktické pokyny pro správu obrázků**

### **Kontrola velikosti prezentace**

Velké rastrové obrázky mohou prezentaci zbytečně zvětšit. Používejte zdrojové obrázky s rozměry vhodnými pro jejich zamýšlenou velikost zobrazení, opakovaně využívejte sdílené zdroje obrázků, kde je to možné, a vyhněte se vkládání opakovaných kopií téže grafiky ve vysokém rozlišení.

U rastrových obrázků, které již byly umístěny v rámečcích, může [PictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/) snížit data obrázku podle vybrané rozlišení a nastavení ořezu. Jedná se o zpracování rámečku obrázku, nikoli o správu kolekce obrázků, proto viz [Rámeček obrázku](/slides/cs/nodejs-java/picture-frame/) pro související operace formátování.

### **Volba mezi vloženým a propojeným obsahem**

Vkládání činí prezentaci přenosnou, protože všechna potřebná data obrázku jsou součástí souboru. Propojení může zmenšit velikost souboru, ale zavádí externí závislost. Používejte odkazy jen tehdy, když je tato závislost přijatelná a stabilní.

### **Opětovné použití sdílené značky**

Pro opakovaná loga, vodoznaky nebo dekorativní grafiku používejte jeden zdroj obrázku a opakujte ho. Pokud grafika patří do designu prezentace spíše než do obsahu snímku, umístěte ji na master nebo rozvržení, aby ji zdědily příslušné snímky.

### **Udržujte SVG zdroje přenosné**

Samostatné SVG je snazší přesunout a renderovat konzistentně než SVG závislé na externích souborech nebo síťových zdrojích. Kdykoli je to možné, vložte požadované zdroje před importem SVG. Převádějte SVG na tvary jen tehdy, když je potřeba individuální vektorové elementy upravit.

### **Používejte moderní multiplatformní Image API**

Pro nový kód Node.js via Java používejte místo starého veřejného API založeného na `java.awt.image.BufferedImage` rozhraní Aspose.Slides [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/) a [Images](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/images/). Viz [Moderní API](/slides/cs/nodejs-java/modern-api/) pro pokyny k migraci.

WMF a EMF vyžadují zvláštní zacházení. Když jsou tyto formáty předány přes [IImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/) převádí metafile na rastrovou PNG reprezentaci před vložením. Pokud je důležité zachovat data metafile, použijte přetížení [ImageCollection.addImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/) přijímající proud. Generování EMF obsahu ze spreadsheetů nebo jiných produktů je samostatný integrační proces a přesahuje rozsah tohoto článku.

## **Často kladené otázky**

**Jaký je rozdíl mezi kolekcí obrázků a rámečkem obrázku?**

Kolekce obrázků ukládá opakovaně použitelné zdroje obrázků. Rámeček obrázku je tvar na snímku, který zobrazuje jeden z těchto zdrojů a poskytuje specifické formátování obrázku, jako je ořez a efekty.

**Jak nejlépe nahradit stejné logo všude?**

Pokud je logo již sdílené jako jeden zdroj obrázku, nahraďte tento zdroj pomocí [PPImage.replaceImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/). Pro značku napříč celou prezentací může také umístění loga na master nebo rozvržení snížit duplicitní obsah snímků.

**Proč se propojený obrázek na jiném počítači nezobrazí?**

Propojený obrázek závisí na externím souboru nebo URL. Pokud tento zdroj není z druhého počítače dostupný, obrázek může chybět. Vložte obrázek, když musí být prezentace samostatná.

**Lze vložené SVG upravovat jako tvary PowerPointu?**

Ano. Převodem SVG pomocí [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/) získáte skupinu editovatelných tvarů snímku místo jednoho SVG obrázku.

**Jak udržet prezentace s mnoha obrázky malé?**

Opakovaně používejte sdílené zdroje obrázků, vyhýbejte se zbytečně velkým rastrovým zdrojům, komprimujte vhodné rastrové obrázky, umisťujte opakovanou značku na master nebo rozvržení a používejte propojené obrázky jen tehdy, když je externí závislost přijatelná.