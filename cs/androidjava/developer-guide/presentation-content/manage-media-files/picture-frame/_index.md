---
title: Správa rámečků obrázků v prezentacích pro Android
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
- ořezat obrázek
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
- Android
- Java
- Aspose.Slides
description: "Vytvářet, formátovat, propojit, ořezávat, extrahovat a komprimovat rámečky obrázků v prezentacích pomocí Aspose.Slides pro Android v jazyce Java."
---
## **Přehled**

Rám obrázku je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, oddělené objekty: [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [IImageCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagecollection/), zatímco [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) řídí pozici, velikost, formátování čar, otáčení, ořez, efekty obrázku a další nastavení na úrovni rámu.

Toto oddělení je užitečné, když se stejný obrázek zobrazuje vícekrát. Přidejte obrázek do prezentace jednou, uložte si vrácený [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/), a použijte tento zdroj obrázku při vytváření rámů obrázků.

Rámy obrázků mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku do prezentace. Volba ovlivňuje přenositelnost, velikost souboru, extrakci i export, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte rám obrázku pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná i po přesunu na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rám v nativních rozměrech obrázku a aplikuje formátování čar a otočení:

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

Rám obrázku řídí zobrazenou geometriku; změna velikosti rámu nemění původní rozměry v pixelech uložené ve vloženém zdroji obrázku. Toto rozlišení je důležité při pozdějším ořezu nebo kompresi obrázku.

## **Použití relativního měřítka**

[IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) poskytuje relativní škálování šířky a výšky rámu pomocí [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když pracovní postup musí zachovat vztah k velikosti zdrojového obrázku místo ručního počítání konečných rozměrů.

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

Relativní měřítko mění nastavení měřítka rámu; neprovádí převzorkování ani kompresi vloženého obrázku.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat uložených v PPTX, avšak zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které se mají posílat e‑mailem, archivovat nebo vykreslovat v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rám obrázku a nasměruje jej na lokální soubor obrázku. Zabývá se jen propojováním obrázků; propojování videí je samostatný mediální pracovní postup a je úmyslně v tomto příkladu nezahrnuto.

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

Používejte odkazy, když je správa externích souborů záměrná. Nepoužívejte je jen jako náhradu komprese: malý PPTX s poškozenými závislostmi obrázků je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámů obrázků**

Před extrahováním obrázku z existující prezentace ověřte, že tvar je skutečně [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) a že obsahuje vložený obrázek. Propojené rámy obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázků používá přímo [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) a nevyžaduje starší Java wrapper. Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

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

Ukládání přes [IImage.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci namísto převedeného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/). Ten umožňuje získat SVG data přímo místo rasterizace obrázku nejprve.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také operací renderování, takže exportovaná grafika by neměla být považována za bit‑po‑bitu kopii původního vloženého SVG; použijte data [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/#getSvgData--) při potřebě samotného vektorového zdroje.

## **Ořez obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámu. Hodnoty ořezu na [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořez neodstraňuje skryté pixely z vloženého obrázku; mění jen viditelnou oblast.

Následující příklad bezpečně najde rám obrázku a aplikuje hodnoty ořezu:

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

Protože skrytá data obrázku jsou stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než reverzibilita, lze ořezané oblasti fyzicky odstranit, jak je popsáno v další sekci.

## **Odstranění ořezaných dat obrázku**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace již odstraněné pixely nejsou k dispozici pro pozdější operaci „uncrop“.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými rámci obrázků, tyto rámce stále potřebují svůj existující zdroj, takže smazání ořezaných oblastí nutně nesníží celkový počet obrázků. Ořez WMF nebo EMF pomocí této metody rasterizuje ořezaný výsledek do PNG.

## **Kompresní rasterových obrázků**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) snižuje rozlišení rastrového obrázku relativně k velikosti, ve které je obrázek zobrazován. Může také v téže operaci odstranit ořezané oblasti. Metoda vrací `true`, pokud byl obrázek změněn velikostí nebo oříznut, a `false`, pokud nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/picturescompression/) tehdy, když stačí standardní cílové rozlišení:

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

Kompresi zaměřenou na rastrové obrázky neovlivní SVG ani metafile obsah. Také pamatujte, že nižší rozlišení a smazané ořezané oblasti nelze z optimalizované prezentace obnovit. Zvolte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Správa transformací obrázku**

Kompletní pracovní postup zahrnující jas, kontrast, barevné transformace, rozostření, alfa‑efekty, řetězení, inspekci, odstraňování a ověřování round‑trip najdete v [Image Transform Effects](/slides/cs/androidjava/image-transform-effects/).

## **Zamknutí geometrie rámu obrázku**

Nastavení [IPictureFrameLock](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframelock/) řídí, které úpravy jsou pro rám obrázku zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachovává proporce tvaru při změně velikosti.

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

Zámek se vztahuje na tvar rámu obrázku. Neznamená to, že by byl zdrojový obrázek převzorkován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na „stretch“, hodnoty stretch‑offsetu na [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) definují výplňový obdélník relativně k omezujícímu rámečku rámu obrázku. Kladná procenta vytvářejí útlum od hrany, záporná procenta vytvářejí výstupek.

To se liší od ořezu. Hodnoty ořezu určují, která část zdrojového obrázku je viditelná; stretch‑offsety mění obdélník, do kterého se viditelná výplň obrázku roztahuje.

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

Používejte stretch‑offsety pro umístění výplně. Používejte vlastnosti ořezu, když chcete skrýt hrany zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy jsou snazší spravovat, když je úložiště obrázků a formátování rámu oddělené:

- **Vložené obrázky** dělají prezentaci samostatnou a jsou nejspolehlivější pro sdílení a renderování na serveru, ale velké rastrové obrázky zvyšují velikost PPTX i paměťovou náročnost.
- **Propojené obrázky** mohou balíček zmenšit, ale prezentace závisí na tom, že externí soubory zůstanou dostupné na uložených cestách nebo umístěních.
- **Ořez** je zpočátku neinvazivní. Skryté pixely zůstávají vložené, dokud nejsou ořezané oblasti explicitně smazány nebo odstraněny během komprese.
- **Komprese** může výrazně snížit velikost souboru u příliš velkých rastrových obrázků, ale snižuje zdrojové rozlišení. Měla by být použita poté, co je známá zamýšlená velikost na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektoru. Vložené SVG extrahujte přímo, pokud potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí renderovaný snímek na pixely.
- **Opakované obrázky** by měly znovu použít existující zdroj [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/), pokud je to možné, místo opakovaného načítání stejného souboru do pracovního postupu prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když se provádí selektivně: loga a diagramy ponechte jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte ořezané pixely jen tehdy, když následná úprava není vyžadována, a vyhýbejte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámem obrázku a zdrojem obrázku?**

[IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) představuje zdroj obrázku spojený s prezentací. [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) je tvar na snímku, který obrázek zobrazuje a ukládá geometrické a formátovací informace rámu, jako jsou velikost, otáčení, hodnoty ořezu, efekty a zámky.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivována nebo renderována bez přístupu k externím zdrojům. Propojujte obrázky jen tehdy, když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Zmenšuje ořez velikost souboru PPTX?**

Ne samostatně. Normální nastavení ořezu skrývá části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) nebo kompresi s odstraněním ořezaných oblastí, pokud lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění ořezaných oblastí vymaže data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava v vyšším rozlišení.

**Jak mám zacházet s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když záleží na vektorové věrnosti. Vložený [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/) lze extrahovat přímo. Renderování snímku do rastrového formátu jako PNG nebo JPEG rasterizuje SVG jako součást obrázku snímku.

**Jak se vyhnout nebezpečným přetypováním při čtení existujících snímků?**

Před použitím členů specifických pro rám obrázku ověřte typ tvaru. Kontrola `instanceof` vůči [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) zabrání neplatným přetypováním a umožní kódu správně zacházet se snímky, které neobsahují rámy obrázků.