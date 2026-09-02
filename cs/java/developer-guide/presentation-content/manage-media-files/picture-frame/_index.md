---
title: Spravovat rámy obrázků v prezentacích pomocí Javy
linktitle: Rám obrázku
type: docs
weight: 10
url: /cs/java/picture-frame/
keywords:
- rám obrázku
- přidat rám obrázku
- vytvořit rám obrázku
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- ořez obrázku
- odstranit oříznuté oblasti
- komprimovat obrázek
- StretchOffset
- formátování rámu obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte rámy obrázků v prezentacích pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Rám obrazu je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, oddělené objekty: [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím svého [IImageCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagecollection/), zatímco [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) řídí pozici obrázku, velikost, formátování čáry, otočení, ořez, efekty obrázku a další nastavení na úrovni rámu.

Díky tomuto oddělení je užitečné, když se stejný obrázek zobrazuje vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/), a použijte tento zdroj obrázku při vytváření rámců obrázků.

Rámce obrázků mohou obsahovat rastrové obrázky, například PNG nebo JPEG, a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je vhodné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

Pro vložený obrázek přidejte data obrázku do prezentace a vytvořte rámec obrázku pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidává JPEG obrázek, vytvoří rámec v nativních rozměrech obrázku a aplikuje formátování čáry a otočení:

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

Rámec obrázku řídí zobrazovanou geometrii; změna velikosti rámce nemění původní rozměry pixelů uložené ve vloženém zdroji obrázku. Toto rozlišení se stává důležitým při ořezu nebo kompresi obrázku později.

## **Použití relativního měřítka**

[IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) poskytuje relativní škálování šířky a výšky rámce prostřednictvím [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když pracovní postup potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

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

Relativní měřítko mění nastavení měřítka rámce; neprovádí resampling ani kompresi vloženého obrázku.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění metodou [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které musí být posílány emailem, archivovány nebo vykreslovány v izolovaném prostředí, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rámec obrázku a nasměruje jej na lokální soubor obrázku. Zabývá se pouze propojováním obrázků; propojování videí je samostatný multimediální workflow a je úmyslně nezahrnuto v tomto příkladu.

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

Používejte odkazy, když je externí správa souborů zamýšlená. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s nefunkčními závislostmi obrázků je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámců obrázků**

Před extrahováním obrázku z existující prezentace zkontrolujte, že tvar je skutečně [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) a že obsahuje vložený obrázek. Propojené rámce obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API pro obrázky používá přímo [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) a nevyžaduje starší Java obal pro obrázky. Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

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

Pro SVG obrázek [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejdříve.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně vykreslují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také operace vykreslení, takže exportovaná grafika by neměla být považována za bit‑po‑bitu kopii původního vloženého SVG; použijte vložená data [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/#getSvgData--) , pokud je vyžadován samotný vektorový zdroj.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámce. Hodnoty ořezu na [IPictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez původně nesmaže skryté pixely ze vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde rámec obrázku a aplikuje hodnoty ořezu:

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

Protože skrytá data obrázku stále existují, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než možnost vrácení, lze oříznuté oblasti fyzicky odstranit, jak je popsáno v následující sekci.

## **Odstranění oříznutých dat obrázku**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely k dispozici pro pozdější operaci „uncrop“.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými rámy obrázků, tyto rámce stále potřebují svůj existující zdroj, takže mazání ořezaných oblastí nemusí nutně snížit celkový počet obrázků. Ořez WMF nebo EMF obsahu touto metodou rasterizuje ořezaný výsledek do PNG.

## **Komprese rastrových obrázků**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) snižuje rozlišení rastrového obrázku vzhledem k velikosti, ve které je obrázek zobrazen. Může také v rámci stejné operace odstranit oříznuté oblasti. Metoda vrací `true`, pokud byl obrázek upraven nebo oříznut, a `false`, pokud nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/java/com.aspose.slides/picturescompression/) , když je dostačující standardní cílové rozlišení:

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

Vlastní kladná hodnota DPI může být předána místo předdefinované hodnoty, pokud je vyžadován konkrétní cíl.

Kompresie je určena pro rastrové obrázky. SVG a metafile obsah není tímto rastrovým kompresním workflow zmenšován. Také si pamatujte, že nižší rozlišení a smazané oříznuté oblasti nelze z optimalizované prezentace obnovit. Vyberte cílové rozlišení na základě největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo globálního použití nejnižšího DPI.

## **Kontrola efektů obrázku**

Efekty obrázku jsou uloženy na obrázku použitým v rámci. Kolekce transformací obrázku může obsahovat efekty jako pevná alfa modulace pro průhlednost a luminanci pro jas a kontrast. Následující příklad bezpečně čte oba druhy efektů z prvního rámce obrázku na snímku:

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
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tyto efekty mění způsob, jak je obrázek vykreslen v rámci; nepřepisují původní vložené bajty obrázku.

## **Uzamčení geometrie rámce obrázku**

Nastavení [IPictureFrameLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframelock/) řídí, které operace úprav jsou pro rámec obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachovává proporce tvaru při jeho změně velikosti.

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

Zámek se vztahuje na tvar rámce obrázku. Nevyžaduje, aby byl zdrojový obrázek resamplován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku stretch, hodnoty stretch‑offset na [IPictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku rámce obrázku. Kladná procenta vytvářejí vnitřní odsazení od okraje, zatímco záporná procenta vytvářejí vnější odsazení.

To se liší od ořezu. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch offsety mění obdélník, do kterého je viditelná výplň obrázku roztahována.

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

Používejte stretch offsety pro umístění výplně. Používejte vlastnosti ořezu, když je cílem skrýt okraje zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy se snáze řídí, když jsou úložiště obrázků a formátování rámců obrázků řešeny odděleně:

- **Vložené obrázky** dělají prezentaci samostatnou a jsou nejspolehlivější pro sdílení a serverové vykreslování, ale velké rastrové obrázky zvyšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na tom, že externí soubory zůstanou dostupné na uložených cestách nebo umístěních.
- **Ořez** je zpočátku nedestruktivní. Skryté pixely zůstávají vložené, dokud nejsou oříznuté oblasti explicitně smazány nebo odstraněny během komprese.
- **Kompresí** lze výrazně snížit velikost souboru u příliš velkých rastrových obrázků, avšak za cenu ztráty původního rozlišení. Měla by být použita po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, pokud je důležitá zachování vektoru. Vložené SVG extrahujte přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly opakovaně využívat existující zdroj [IPPImage], pokud je to možné, místo opakovaného načítání stejného souboru do pracovního postupu prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když se provádí selektivně: uchovávejte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte oříznuté pixely pouze pokud není potřeba pozdější úprava, a vyhýbejte se externím odkazům, pokud správa závislostí není součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámcem obrázku a zdrojem obrázku?**

[IPPImage] představuje zdroj obrázku spojený s prezentací. [IPictureFrame] je tvar na snímku, který zobrazuje obrázek a ukládá geometrii a formátování na úrovni rámce, jako jsou velikost, otočení, hodnoty ořezu, efekty a zámky.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslovaná bez přístupu k externím zdrojům. Propojujte obrázky pouze pokud je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Nebyl vynuceně. Normální nastavení ořezu skryje části zdrojového obrázku, ale podkladové pixely zůstávají. Použijte [IPictureFillFormat.deletePictureCroppedAreas] nebo kompresi obrázku s odstraňováním oříznutých oblastí, pokud lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstraňování oříznutých oblastí zahazuje data obrázku. Ponechte původní zdrojový obrázek mimo prezentaci, pokud by pozdější úpravy ve vysokém rozlišení mohly být potřeba.

**Jak by měly být zpracovány SVG obrázky?**

Uchovávejte SVG obsah jako SVG, pokud záleží na vektorové věrnosti. Vložený [ISvgImage] lze extrahovat přímo. Vykreslení snímku do rastrového formátu, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak se mohu vyhnout nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro rámce obrázků. Kontrola `instanceof` vůči [IPictureFrame] zabrání neplatným přetypováním a umožní kódu zpracovat snímky, které neobsahují rámce obrázků.