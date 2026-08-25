---
title: Správa obrázkových rámců v prezentacích na Androidu
linktitle: Obrázkový rámec
type: docs
weight: 10
url: /cs/androidjava/picture-frame/
keywords:
- obrázkový rámec
- přidat obrázkový rámec
- vytvořit obrázkový rámec
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- ořezat obrázek
- odstranit oříznuté oblasti
- komprimovat obrázek
- StretchOffset
- formátování obrázkového rámce
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte, formátujte, propojte, ořízněte, extrahujte a komprimujte obrázkové rámečky v prezentacích pomocí Aspose.Slides pro Android v Javě."
---
## **Přehled**

Obrázkový rámeček je tvar slidu, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své [IImageCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagecollection/), zatímco [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) řídí pozici, velikost, formátování čar, otočení, ořez, efekty obrázku a další nastavení na úrovni rámce.

Toto oddělení je užitečné, když se stejný obrázek zobrazuje vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/), a použijte tento zdroj obrázku při vytváření obrázkových rámců.

Obrázkové rámečky mohou obsahovat rastrové obrázky, jako jsou PNG nebo JPEG, a vektorové obrázky SVG. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku do prezentace. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

Pro vložený obrázek přidejte data obrázku do prezentace a vytvořte obrázkový rámec pomocí [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná, i když je přesunuta na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rámec v původních rozměrech obrázku a použije formátování čar a otočení:
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

Obrázkový rámeček řídí zobrazovanou geometrii; změna velikosti rámce nemění původní pixelové rozměry uložené ve vloženém zdroji obrázku. Toto rozlišení je důležité při pozdějším ořezu nebo kompresi obrázku.

## **Použití relativního měřítka**

[IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) poskytuje relativní škálování šířky a výšky rámce pomocí [setRelativeScaleWidth](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) a [setRelativeScaleHeight](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.
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

Relativní měřítko mění nastavení měřítka rámce; nepřevzorkuje ani nekomprimuje vložený obrázek.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je tak nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí metody [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může být propojený obrázek zobrazen jinak, než se očekává. Pro prezentace, které musí být posílány e-mailem, archivovány nebo vykreslovány v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří obrázkový rámec a nasměruje jej na místní soubor obrázku. Zabývá se pouze propojením obrázku; propojení videa je samostatný mediální workflow a záměrně není v tomto příkladu kombinováno.
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

Používejte odkazy, když je správa externích souborů záměrná. Nepoužívejte je pouze jako náhradu za kompresi: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z obrázkových rámců**

Před extrahováním obrázku z existující prezentace ověřte, že tvar je skutečně [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) a že obsahuje vložený obrázek. Propojené obrázkové rámečky nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API pro obrázky používá přímo [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) a nevyžaduje starší Java obalovou třídu obrázku. Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:
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

Ukládání pomocí [IImage.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/). To vám umožní získat SVG data přímo, místo aby byl obrázek nejprve rasterizován.
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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rastrové exporty jako PNG nebo JPEG nutně převádějí tento vektorový obsah na pixely. Export snímků do PDF nebo SVG je také operace vykreslování, takže exportovaná grafika by neměla být považována za bit‑po‑bit kopii původního vloženého SVG; použijte vložená data [ISvgImage.getSvgData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/#getSvgData--) , když je požadován samotný vektorový zdroj.

## **Ořez obrázku**

Ořezání mění, která část obrázku je viditelná uvnitř rámce. Hodnoty ořezu na [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořezání zpočátku nesmaže skryté pixely z vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde obrázkový rámec a aplikuje hodnoty ořezu:
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

Protože jsou skrytá data obrázku stále přítomna, lze ořez později změnit, aniž by se ztratily původní pixely. Pokud je velikost souboru důležitější než možnost vrácení, lze oříznuté oblasti fyzicky odstranit, jak je popsáno v následující sekci.

## **Odstranění oříznutých dat obrázku**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací výsledný zdroj obrázku. Toto může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace již odstraněné pixely nejsou k dispozici pro pozdější operaci zrušení ořezu.
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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán dalšími obrázkovými rámečky, tyto rámečky stále potřebují svůj existující zdroj, takže mazání oříznutých oblastí nutně nesníží celkový počet obrázků. Ořezávání obsahu WMF nebo EMF pomocí této metody rasterizuje oříznutý výsledek do PNG.

## **Komprese rastrových obrázků**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) snižuje rozlišení rastrového obrázku vzhledem k velikosti, ve které je obrázek zobrazen. Může také v rámci jedné operace odstranit oříznuté oblasti. Metoda vrací `true`, když byl obrázek změněn velikostně nebo oříznut, a `false`, když nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/picturescompression/) , když je standardní cílové rozlišení dostačující:
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

Vlastní kladná hodnota DPI může být předána místo předdefinované hodnoty, pokud je požadován konkrétní cíl.

Kompresní operace je určena pro rastrové obrázky. SVG a obsah metafile nejsou tímto workflow pro rasterovou kompresi zmenšeny. Také si uvědomte, že nižší rozlišení a odstraněné oříznuté oblasti nelze z optimalizované prezentace obnovit. Vyberte cílové rozlišení na základě největší velikosti, při které bude obrázek skutečně zobrazen nebo exportován, místo aby se globálně použilo nejnižší DPI.

## **Správa transformačních efektů obrázku**

Pro kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řazené řetězce, kontrolu, odstranění a ověření round‑trip, viz [Image Transform Effects](/androidjava/image-transform-effects/).

## **Uzamčení geometrie obrázkového rámce**

Nastavení [IPictureFrameLock](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframelock/) řídí, které operace úprav jsou pro obrázkový rámec zakázány. Například [setAspectRatioLocked](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachovává proporce tvaru při změně velikosti.
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

Uzamčení se vztahuje na tvar obrázkového rámce. Nevyžaduje, aby byl zdrojový obrázek převzorkován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku natažený, hodnoty stretch-offset na [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku obrázkového rámce. Kladná procenta vytvoří odsazení od okraje, zatímco záporná procenta vytvoří vyčnívání.

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

Použijte stretch offsety pro umístění výplně. Použijte vlastnosti ořezu, když je cílem skrýt okraje zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy jsou snáze říditelné, když jsou úložiště obrázků a formátování obrázkových rámců řešeny odděleně:

- **Vložené obrázky** činí prezentaci samostatnou a jsou nejspolehlivější pro sdílení a serverové vykreslování, ale velké rastrové obrázky zvětšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na tom, že externí soubory zůstanou dostupné na uložených cestách nebo umístěních.
- **Ořez** je zpočátku nedestruktivní. Skryté pixely zůstávají vložené, dokud nejsou ořezané oblasti výslovně smazány nebo odstraněny během komprese.
- **Komprese** může výrazně snížit velikost souboru u příliš velkých rastrových obrázků, ale snižuje zdrojové rozlišení. Měla by být aplikována po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektoru. Extrahujte vložené SVG přímo, když potřebujete samotný vektorový zdroj. Rastrové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly při možnosti znovu použít existující zdroj [IPPImage] když je to možné místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když je prováděna selektivně: uchovávejte loga a diagramy ve vektorovém formátu, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte oříznuté pixely pouze když následná úprava není vyžadována, a vyhněte se externím odkazům, pokud řízení závislostí není součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi obrázkovým rámcem a zdrojem obrázku?**

[IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) představuje zdroj obrázku spojený s prezentací. [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) je tvar na snímku, který zobrazuje obrázek a ukládá geometrii a formátování na úrovni rámce, jako jsou velikost, otočení, hodnoty ořezu, efekty a zamknutí.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslovaná bez přístupu k externím zdrojům. Propojujte obrázky pouze když je záměrem uchovávat soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořez velikost souboru PPTX?**

Nevýsledkuje to samostatně. Normální nastavení ořezu skryje části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) nebo kompresi obrázku s odstraňováním oříznutých oblastí, pokud lze tyto pixely trvale zahodit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění oříznutých oblastí zahodí data obrázku. Uchovejte originální zdrojový obrázek mimo prezentaci, pokud může být později potřeba úprava v vysokém rozlišení.

**Jak by měly být SVG obrázky zpracovány?**

Uchovávejte SVG obsah jako SVG, když je věrnost vektoru důležitá. Vložené [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/) lze extrahovat přímo. Vykreslení snímku do rastru, jako je PNG nebo JPEG, rasterizuje SVG jako součást obrázku snímku.

**Jak se vyhnout nebezpečným přetypováním při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro obrázkový rámec. Kontrola `instanceof` vůči [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) zabraňuje neplatným přetypováním a umožňuje kódu zpracovat snímky, které neobsahují obrázkové rámečky.