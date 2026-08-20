---
title: Správa rámů obrázků v prezentacích pro Android
linktitle: Rám obrázku
type: docs
weight: 10
url: /cs/androidjava/picture-frame/
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
- Android
- Java
- Aspose.Slides
description: "Vytvořte, formátujte, propojujte, ořezejte, extrahujte a komprimujte rámové obrázky v prezentacích pomocí Aspose.Slides pro Android prostřednictvím Javy."
---
## **Přehled**

Rám obrázku je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím svého [IImageCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagecollection/), zatímco [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) řídí pozici obrázku, velikost, formátování čáry, rotaci, ořez, efekty obrázku a další nastavení na úrovni rámu.

Toto oddělení je užitečné, když je stejný obrázek zobrazen vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/), a použijte tento zdroj obrázku při vytváření rámů obrázků.

Rámové obrázky mohou obsahovat rastrové obrázky, jako jsou PNG nebo JPEG, a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné se rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte rám obrázku pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstává samostatná, když je přesunuta na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rám s původními rozměry obrázku a použije formátování čáry a rotaci:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Rám obrázku řídí zobrazovanou geometrii; změna velikosti rámu nemění původní rozměry v pixelech uložené ve vloženém zdroji obrázku. Toto rozlišení se stává důležitým při následném ořezu nebo kompresi obrázku.

## **Použití relativního měřítka**

[IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) umožňuje relativní měřítko šířky a výšky rámu pomocí [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když pracovní postup potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

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

Relativní měřítko mění nastavení měřítka rámu; nepřevzorkovává ani nekonprezuje vložený obrázek.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která otevírá nebo vykresluje prezentaci. Pokud se cesta změní, soubor je přesunut nebo není zdroj dostupný, může být propojený obrázek zobrazen neočekávaně. Pro prezentace, které musí být zasílány e-mailem, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rám obrázku a nasměruje jej na lokální soubor obrázku. Zabývá se jen propojováním obrázků; propojování videí je samostatný mediální tok a není úmyslně zahrnut do tohoto příkladu.

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

Používejte odkazy, když je správa externích souborů záměrná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámů**

Před extrahováním obrázku z existující prezentace zkontrolujte, že tvar je skutečně [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) a že obsahuje vložený obrázek. Propojené rámové obrázky nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API pro obrázky používá přímo [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) a nevyžaduje starší Java obal obrázku. Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

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

Uložení přes [IImage.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) převede extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete zakódované bajty uložené v prezentaci místo převedeného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj v prezentaci. Rasterové exporty jako PNG nebo JPEG nutně převádějí tento vektorový obsah na pixely. Export snímku do PDF nebo SVG je také operací renderování, takže exportovaná grafika by neměla být považována za přesnou kopii původního vloženého SVG; použijte vložená data [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/#getSvgData--) , pokud je požadován samotný vektorový zdroj.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámu. Hodnoty ořezu na [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez neodstraňuje skryté pixely z vloženého obrázku, pouze mění viditelnou oblast.

Následující příklad bezpečně najde rám obrázku a použije hodnoty ořezu:

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

Protože skrytá data obrázku jsou stále přítomna, může být ořez později změněn bez ztráty původních pixelů. Pokud je velikost souboru důležitější než reverzibilita, mohou být oříznuté oblasti fyzicky odstraněny, jak je popsáno v následující sekci.

## **Odstranění oříznutých dat obrázku**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací vzniklý zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely již k dispozici pro pozdější operaci odořezování.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými rámy obrázků, tyto rámce stále potřebují svůj existující zdroj, takže odstranění oříznutých oblastí nemusí nutně snížit celkový počet obrázků. Ořezávání WMF nebo EMF obsahu touto metodou rasterizuje oříznutý výsledek do PNG.

## **Kompresní rastrových obrázků**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) snižuje rozlišení rastrového obrázku vzhledem k velikosti, při které je obrázek zobrazován. Může také v rámci stejné operace odstranit oříznuté oblasti. Metoda vrací `true`, když byl obrázek změněn velikostně nebo oříznut, a `false`, když nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/picturescompression/) , když je standardní cílové rozlišení dostatečné:

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

Místo předdefinované hodnoty lze předat vlastní kladnou hodnotu DPI, pokud je požadován konkrétní cíl.

Kompresí jsou určeny rastrové obrázky. SVG a obsah meta souborů nejsou tímto rasterovým kompresním procesem zmenšeny. Také si pamatujte, že nižší rozlišení a odstraněné oříznuté oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, namísto použití nejnižšího DPI globálně.

## **Prozkoumání efektů obrázku**

Efekty obrázku jsou uloženy na obrázku použitém rámem. Kolekce transformací obrázku může obsahovat efekty jako pevná alfa modulace pro průhlednost a luminanci pro jas a kontrast. Níže uvedený příklad bezpečně načte oba typy efektů z prvního rámu obrázku na snímku:

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

Tyto efekty mění, jak je obrázek vykreslen v rámci; nepřepisují původní bajty vloženého obrázku.

## **Uzamčení geometrie rámu obrázku**

Nastavení [IPictureFrameLock](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframelock/) řídí, které operace úprav jsou pro rám obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachovává proporce tvaru během změny velikosti.

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

Uzamčení se vztahuje na tvar rámu obrázku. Neukládá zdrojovému obrázku nutnost být převzorkován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku natažený, hodnoty stretch-offset na [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) definují výplňový obdélník vzhledem k ohraničujícímu rámečku rámu obrázku. Kladná procenta vytvoří vnitřní odsazení od hrany, zatímco záporná procenta vytvoří vnější odsazení.

Toto se liší od ořezu. Hodnoty ořezu vybírají, která část zdrojového obrázku je viditelná; stretch offsety mění obdélník, do kterého je viditelná výplň obrázku natažena.

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

Hlavní kompromisy jsou snazší spravovat, když jsou úložiště obrázků a formátování rámu obrázku řešeny odděleně:

- **Vložené obrázky** dělají prezentaci samostatnou a jsou nejspolehlivější pro sdílení a serverové vykreslování, ale velké rastrové obrázky zvyšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na tom, že externí soubory zůstanou dostupné na uložených cestách nebo umístěních.
- **Ořez** je zpočátku neškodlivý. Skryté pixely zůstávají vložené, dokud nejsou oříznuté oblasti výslovně smazány nebo odstraněny během komprese.
- **Kompresí** lze výrazně snížit velikost souboru u příliš velkých rastrových obrázků, ale snižuje rozlišení zdroje. Měla by být aplikována po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležité zachovat vektor. Vložený SVG extrahujte přímo, pokud potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly v případě možnosti znovu použít existující zdroj [IPPImage] místo opakovaného načítání stejného souboru do pracovního postupu prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když je prováděna selektivně: uchovávejte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné velikosti zobrazení, odstraňujte oříznuté pixely pouze když není vyžadována následná úprava, a vyhýbejte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámem obrázku a zdrojem obrázku?**

[IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) představuje zdroj obrázku spojený s prezentací. [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) je tvar na snímku, který zobrazuje obrázek a ukládá geometrii a formátování na úrovni rámu, jako jsou velikost, rotace, hodnoty ořezu, efekty a uzamčení.

**Mám obrázky vložit nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslená bez přístupu k externím zdrojům. Propojujte obrázky jen když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Nevytváří to samo o sobě. Normální nastavení ořezu skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) nebo kompresi obrázku s odstraněním oříznutých oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění oříznutých oblastí vymaže data obrázku. Uchovávejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava ve vysokém rozlišení.

**Jak by měly být SVG obrázky zpracovány?**

Uchovávejte SVG obsah jako SVG, když je důležitá vektorová věrnost. Vložený [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/) lze extrahovat přímo. Vykreslení snímku do rastrového formátu jako PNG nebo JPEG rasterizuje SVG jako součást obrázku snímku.

**Jak se vyvarovat nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro rám obrázku. Kontrola `instanceof` proti [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) zabraňuje neplatným přetypováním a umožní kódu zpracovat snímky, které neobsahují rám obrázku.