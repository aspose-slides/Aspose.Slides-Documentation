---
title: Správa rámečků obrázků v prezentacích pomocí Java
linktitle: Rámeček obrázku
type: docs
weight: 10
url: /cs/java/picture-frame/
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
- Java
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte rámečky obrázků v prezentacích pomocí Aspose.Slides pro Java."
---
## **Přehled**

Rámeček obrázku je tvar slidu, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím svého [IImageCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagecollection/), zatímco [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) řídí pozici, velikost, formátování čáry, rotaci, ořez, efekty obrázku a další nastavení na úrovni rámce.

Toto oddělení je užitečné, když je stejný obrázek zobrazen vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/), a použijte tento zdroj obrázku při vytváření rámečků.

Rámečky mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, před tím, než použijete formátování nebo optimalizaci.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte rámeček obrázku pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná, když bude přesunuta na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rámec v přirozených rozměrech obrázku a aplikuje formátování čáry a rotaci:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rámeček řídí zobrazovanou geometrii; změna velikosti rámce nemění původní rozměry pixelů uložené ve vloženém zdroji obrázku. Toto rozlišení je důležité při ořezávání nebo kompresi obrázku později.

## **Použití relativního měřítka**

[IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) vystavuje relativní měřítko šířky a výšky pro rámec prostřednictvím [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Relativní měřítko mění nastavení měřítka rámce; neprovádí přeškálování ani kompresi vloženého obrázku.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a proto je nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) místo vkládání dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které mají být e‑mailem odesílány, archivovány nebo vykresleny v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rámeček obrázku a nasměruje jej na lokální soubor obrázku. Jedná se jen o propojení obrázku; propojení videa je samostatný mediální workflow a záměrně není v tomto příkladu smícháno.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Používejte odkazy, když je správa externích souborů úmyslná. Nepoužívejte je jen jako náhradu komprese: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámečků**

Před extrahováním obrázku z existující prezentace ověřte, že tvar je skutečně [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) a že obsahuje vložený obrázek. Propojené rámečky nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázku používá přímo [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) a nevyžaduje starší Java wrapper. Následující příklad najde první vložený rastrový obrázek na slidu a uloží jej jako PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Ukládání pomocí [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/#save-java.lang.String-int-) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete zakódované bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) vystavuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rastrové exporty jako PNG nebo JPEG nutně renderují tento vektor do pixelů. Export slidu do PDF nebo SVG je také operací renderování, takže exportovaná grafika by neměla být považována za bit‑za‑bitem kopii původního vloženého SVG; použijte data [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/#getSvgData--) z vloženého zdroje, když je vyžadován samotný vektorový zdroj.

## **Ořezání obrázku**

Ořezání mění, která část obrázku je viditelná uvnitř rámce. Hodnoty ořezu na [IPictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez neodstraňuje skryté pixely z vloženého obrázku; pouze mění viditelný region.

Následující příklad najde rámeček obrázku bezpečně a aplikuje hodnoty ořezu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Protože skrytá data obrázku stále existují, lze ořez později změnit, aniž by se ztratily původní pixely. Pokud je velikost souboru důležitější než reverzibilita, mohou být oříznuté oblasti fyzicky odstraněny, jak je popsáno v další sekci.

## **Odstranění oříznutých dat obrázku**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací vzniklý zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace již nejsou odstraněné pixely k dispozici pro pozdější operaci "uncrop".

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je originální obrázek používán i jinými rámečky, tyto rámečky stále potřebují svůj existující zdroj, takže mazání oříznutých oblastí nutně nesníží celkový počet obrázků. Ořezávání WMF nebo EMF pomocí této metody rasterizuje výsledek do PNG.

## **Kompresace rastrových obrázků**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) snižuje rozlišení rastrového obrázku relativně k velikosti, v které je obrázek zobrazován. Může také v téže operaci odstranit oříznuté oblasti. Metoda vrací `true`, když byl obrázek změněn velikostí nebo oříznut, a `false`, když nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/java/com.aspose.slides/picturescompression/), když stačí standardní cílové rozlišení:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Místo předdefinované hodnoty můžete předat vlastní kladnou hodnotu DPI, pokud je požadován konkrétní cíl.

Kompresní workflow je určeno pro rastrové obrázky. SVG a metafily nejsou tímto rasterním kompresním postupem zmenšeny. Také si pamatujte, že nižší rozlišení a odstraněné oříznuté oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení podle největší velikosti, ve které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Správa efektů transformace obrázku**

Kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řetězce operací, inspekci, odstraňování a ověření round‑trip najdete na stránce [Image Transform Effects](/java/image-transform-effects/).

## **Uzamčení geometrie rámečku obrázku**

Nastavení [IPictureFrameLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframelock/) řídí, které úpravy jsou pro rámeček zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachovává proporce tvaru při změně jeho velikosti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uzamčení se vztahuje na tvar rámečku obrázku. Nevyžaduje, aby byl zdrojový obrázek přeškálován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na stretch, hodnoty stretch‑offset na [IPictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/) definují výplňový obdélník relativně k ohraničnému rámečku rámečku obrázku. Kladná procenta vytvoří úbytek od okraje, záporná procenta vytvoří výstupek.

To se liší od ořezu. Hodnoty ořezu určují, která část zdrojového obrázku je viditelná; stretch offsety mění obdélník, do kterého je viditelná výplň obrázku roztahována.

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

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Používejte stretch offsety pro umístění výplně. Používejte ořezové vlastnosti, když je cílem skrýt okraje zdrojového obrázku.

## **Úložiště, velikost souboru a úvahy o exportu**

Hlavní kompromisy je snazší spravovat, když jsou úložiště obrázků a formátování rámečků řešeny odděleně:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side renderování, ale velké rastrové obrázky zvyšují velikost PPTX a paměťovou náročnost.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na externích souborech, které musí zůstat dostupné na uložených cestách či umístěních.
- **Ořez** je zpočátku ne­destruktivní. Skryté pixely zůstávají vložené, dokud nejsou oříznuté oblasti explicitně smazány nebo odstraněny během komprese.
- **Kompresí** lze podstatně zmenšit velikost souboru u příliš velkých rastrových obrázků, avšak přicházíte o zdrojové rozlišení. Měla by být provedena až po určení zamýšlené velikosti na slidu.
- **SVG obrázky** by měly zůstat ve formátu SVG, pokud je důležitá zachování vektoru. Vložené SVG lze extrahovat přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty slidu vždy převádějí vykreslený slide na pixely.
- **Opakované obrázky** by měly znovu použít existující zdroj [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/), pokud je to možné, místo opakovaného načítání téhož souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků nejúčinnější, když je prováděna selektivně: loga a diagramy uchovávejte jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte oříznuté pixely jen tehdy, když není potřeba další úpravy, a vyhýbejte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámečkem obrázku a zdrojem obrázku?**

[IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) představuje zdroj obrázku spojený s prezentací. [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) je tvar na slidu, který zobrazí obrázek a ukládá geometrické a formátovací informace na úrovni rámce, jako jsou velikost, rotace, hodnoty ořezu, efekty a uzamčení.

**Mám obrázky vkládat nebo propojit?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslena bez přístupu k externím zdrojům. Propojujte obrázky jen tehdy, když je úmyslně uložení souborů mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Ne samostatně. Normální nastavení ořezu skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) nebo kompresi s odstraněním oříznutých oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění oříznutých oblastí zruší data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava ve vysokém rozlišení.

**Jak má být nakládáno s SVG obrázky?**

Uchovávejte SVG jako SVG, když je důležitá vektorová věrnost. Vložený [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/) lze extrahovat přímo. Renderování slidu do rastrového formátu jako PNG nebo JPEG rasterizuje SVG jako součást obrázku slidu.

**Jak mohu předejít nebezpečným přetypováním při čtení existujících slidů?**

Před použitím členů specifických pro rámeček zkontrolujte typ tvaru. Kontrola `instanceof` vůči [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) zabraňuje neplatným přetypováním a umožňuje kódu správně zacházet se slidami, které neobsahují rámečky obrázku.