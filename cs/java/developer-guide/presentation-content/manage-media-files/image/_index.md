---
title: Optimize Image Management in Presentations Using Java
linktitle: Manage Images
type: docs
weight: 10
url: /cs/java/image/
keywords:
- přidat obrázek
- přidat fotografii
- nahradit obrázek
- kolekce obrázků
- rámec obrázku
- propojený obrázek
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- SVG na tvary
- externí SVG zdroje
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak přidávat, znovu používat, propojit, nahrazovat a spravovat rastrové a SVG obrázky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Javu."
---
## **Úvod**

Aspose.Slides for Java poskytuje několik způsobů, jak pracovat s obrázky, a každý slouží jinému účelu. Můžete uložit obrázek v prezentaci, zobrazit jej v rámečku obrázku, použít jej jako pozadí snímku, propojit na externí obrázek, nahradit sdílený obrázkový zdroj nebo převést obsah SVG na upravitelný tvary.

Tento článek se zaměřuje na obrázkové zdroje a jejich použití v celé prezentaci. Pro ořezávání, průhlednost, efekty, natažení a další formátování aplikované na jednotlivý rámeček obrázku viz [Rámec obrázku](/slides/cs/java/picture-frame/).

## **Pochopte model obrázku**

- [kolekci obrázků prezentace](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimagecollection/) ukládá obrázkové zdroje používané v prezentaci. Použijte [ImageCollection.addImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imagecollection/) k přidání dat obrázku a získání zdroje [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/).
- [Rámeček obrázku](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipictureframe/) je tvar, který zobrazí obrázek na snímku, rozvržení nebo hlavě. Použijte [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/) k umístění obrázkového zdroje na snímek.
- Pozadí snímku používá obrázek jako součást výplně snímku, nikoli jako tvar. Proto se nechová jako rámeček obrázku.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) nahrazuje obrázkový zdroj. Pokud ho používá několik prvků prezentace, všichni používají náhradu.
- Převod SVG na tvary vytvoří upravitelné tvary snímku. Po převodu už není obsah spravován jako jeden obrázkový zdroj.

Typický postup je tedy: přidat data obrázku do kolekce obrázků, získat [IPPImage] a poté použít tento zdroj v jednom či více rámečcích obrázku nebo výplních.

## **Přidat vložený obrázek**

Pro vložení místního obrázku načtěte soubor, přidejte jej do kolekce obrázků a vytvořte rámeček obrázku, který použije vrácený `IPPImage`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obrázek přidaný tímto způsobem je vložen do prezentace, takže výsledný soubor není závislý na dostupnosti původního souboru obrázku.

### **Přidat obrázek z webu**

Když je obrázek dostupný přes HTTP nebo HTTPS, stáhněte jeho bajty, přidejte je do kolekce obrázků prezentace a použijte vrácený obrázkový zdroj stejným způsobem jako lokální obrázek.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V dlouho běžících aplikacích znovu použijte HTTP klienta nebo strategii správy připojení vhodnou pro aplikaci, místo opakovaného vytváření zbytečné síťové infrastruktury. Také ověřujte vzdálené URL, velikosti odpovědí a typy obsahu, pokud zdroj není důvěryhodný.

## **Znovu použít obrázky napříč snímky**

Pokud je stejný obrázek potřeba vícekrát, přidejte jej do prezentace jen jednou a znovu použijte vrácený [IPPImage] při vytváření dalších rámečků obrázku. Tím se vyhnete opakovanému načítání stejných zdrojových dat a vztah mezi sdíleným obrázkovým zdrojem a jeho použitím bude explicitní.

Pro grafiku, která má být automaticky zobrazena na mnoha snímcích, například firemní logo, zvažte umístění rámečku obrázku na [hlavní snímek](/slides/cs/java/slide-master/) nebo rozvržení místo přidávání ekvivalentního tvaru na každý snímek.

## **Použít obrázek jako pozadí snímku**

Obrázek pozadí je přiřazen k výplni snímku; není přidán jako tvar rámečku obrázku. To je užitečné, když má obrázek pokrýt pozadí snímku a neměl by být manipulován jako běžný objekt snímku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Další možnosti pozadí, včetně pozadí hlavního snímku a rozvržení, najdete v [Pozadí prezentace](/slides/cs/java/presentation-background/).

## **Vložené a propojené obrázky**

Vložené a propojené obrázky mají různé kompromisy v přenositelnosti a velikosti souboru:
- **Vložený obrázek:** data obrázku jsou uložena uvnitř prezentace. Prezentace je samostatná, ale velikost souboru zahrnuje data obrázku.
- **Propojený obrázek:** prezentace ukládá cestu nebo URL k externímu obrázku. To může zmenšit velikost prezentace, ale externí zdroj musí být přístupný při otevření nebo vykreslení prezentace.

Propojený obrázek lze vytvořit přiřazením externí cesty nebo URL pomocí [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidespicture/) místo vložení dat obrázku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Používejte propojené obrázky jen tehdy, když nasazovací prostředí může spolehlivě přistupovat k externímu zdroji. Pro prezentace, které musí fungovat offline nebo být přesouvány mezi systémy, jsou vložené obrázky obvykle bezpečnější.

## **Práce s SVG obrázky**

SVG je vektorový formát, takže je užitečný pro ikony, diagramy a další grafiku, která by se měla škálovat bez ztráty detailů jako rastrové obrázky. Aspose.Slides podporuje SVG jak jako obrázkový zdroj, tak jako zdroj pro upravitelné tvary snímku.

### **Přidat SVG jako obrázek**

Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/svgimage/), přidejte jej do kolekce obrázků a umístěte vzniklý obrázkový zdroj do rámečku obrázku.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG soubory s externími zdroji**

SVG může odkazovat na externí obrázky, stylové soubory nebo fonty. Pro tyto případy [SvgImage] poskytuje konstruktory, které přijímají [IExternalResourceResolver] a základní URI. Resolver může převést relativní URI na povolené absolutní URI a vrátit stream požadovaného zdroje.

Resolver zpřístupní externí zdroje během zpracování SVG v Aspose.Slides, ale nepřepíše SVG do samostatného dokumentu. Pokud má SVG zůstat přenosný, vložte požadované zdroje přímo do SVG, například použitím `data:` URI pro propojené obrázky.

Když SVG soubory pocházejí z nedůvěryhodných zdrojů, omezte schémata, umístění souborů a hostitele, ke kterým může resolver přistupovat. Síťové resolvery by také měly uplatňovat časové limity, limity velikosti odpovědí a ověřování obsahu.

### **Převést SVG na upravitelné tvary**

Aspose.Slides dokáže převést SVG na skupinu upravitelných tvarů snímku, podobně jako odpovídající příkaz PowerPointu.

![PowerPoint Popup Menu](img_01_01.png)

Použijte přetížení [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/) přijímající [ISvgImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isvgimage/) k provedení převodu.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Použijte převod SVG na tvary, když je potřeba editovat jednotlivé vektorové prvky jako tvary PowerPointu. Pokud má být SVG pouze zobrazen, je jednoduché ponechat jej jako obrázek a vyhnout se vytváření mnoha samostatných tvarů.

## **Nahradit existující obrázkový zdroj**

Použijte [IPPImage.replaceImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) když chcete nahradit existující obrázkový zdroj. To je zvláště užitečné pro sdílenou grafiku, jako jsou loga.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud více rámečků obrázku, pozadí, hlav nebo rozvržení používá stejný obrázkový zdroj, jeho nahrazení aktualizuje všechny tyto použití. Pokud má být změněn jen jeden rámeček obrázku, přiřaďte mu jiný obrázek místo nahrazení sdíleného zdroje.

`replaceImage` také poskytuje přetížení, která přijímají pole bajtů nebo jiný [IPPImage].

## **Praktické pokyny pro správu obrázků**

### **Kontrola velikosti prezentace**

Velké rastrové obrázky mohou prezentaci zbytečně zvětšit. Používejte zdrojové obrázky s rozměry odpovídajícími zamýšlené velikosti zobrazení, znovu využívejte sdílené obrázkové zdroje, kde je to možné, a vyhněte se vkládání opakovaných kopií stejné grafiky v plném rozlišení.

Pro rastrové obrázky, které již byly umístěny v rámečcích obrázku, může [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/) snížit data obrázku podle vybrané rozlišení a nastavení ořezu. Jedná se o zpracování rámečku obrázku, nikoli správu kolekce obrázků, takže související formátovací operace najdete v [Rámec obrázku](/slides/cs/java/picture-frame/).

### **Zvolte mezi vloženým a propojeným obsahem**

Vkládání činí prezentaci přenositelnou, protože všechna potřebná data obrázku cestují s souborem. Propojování může snížit velikost souboru, ale zavádí externí závislost. Používejte odkazy jen tehdy, když je tato závislost přijatelná a stabilní.

### **Znovu použít sdílenou značku**

Pro opakující se loga, vodoznaky nebo dekorativní grafiku používejte jeden obrázkový zdroj a znovu jej využívejte. Pokud grafika patří do návrhu prezentace spíše než do obsahu snímků, umístěte ji na hlavní snímek nebo rozvržení, aby ji zdědily příslušné snímky.

### **Udržujte SVG zdroje přenosné**

Samostatné SVG je snadněji přenosné a konzistentně renderované než SVG, který závisí na externích souborech nebo síťových zdrojích. Kdykoli je to možné, vložte požadované zdroje před importováním SVG. Převádějte SVG na tvary jen tehdy, když je potřeba editovat jednotlivé vektorové prvky.

### **Použijte moderní multiplatformní Image API**

Pro nový Java kód používejte Aspose.Slides API [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/) a [Images](https://reference.aspose.com/slides/cs/java/com.aspose.slides/images/) místo zastaralého veřejného API založeného na `java.awt.image.BufferedImage`. Pokyny pro migraci najdete v [Moderní API](/slides/cs/java/modern-api/).

Formáty WMF a EMF vyžadují zvláštní úvahu. Když jsou tyto formáty předány přes [IImage], [ImageCollection.addImage] převede metafilet na rastrovou PNG reprezentaci před vložením. Pokud je důležité zachovat data metafile, použijte přetížení [ImageCollection.addImage] založené na streamu. Generování EMF obsahu z tabulek nebo jiných produktů je samostatný integrační postup a spadá mimo rozsah tohoto článku.

## **FAQ**

**Jaký je rozdíl mezi kolekcí obrázků a rámečkem obrázku?**

Kolekce obrázků ukládá znovu použitelné obrázkové zdroje. Rámeček obrázku je tvar na snímku, který zobrazuje jeden z těchto zdrojů a poskytuje specifické formátování obrázku, jako je ořezávání a efekty.

**Jaký je nejlepší způsob, jak všude nahradit stejné logo?**

Pokud je logo již sdíleno jako jeden obrázkový zdroj, nahraďte tento zdroj pomocí [IPPImage.replaceImage]. Pro celoprezentační značku může umístění loga na hlavní snímek nebo rozvržení také snížit duplicitní obsah snímků.

**Proč se propojený obrázek na jiném počítači ztratí?**

Propojený obrázek závisí na externím souboru nebo URL. Pokud není tento zdroj z jiného počítače dosažitelný, může být propojený obrázek nedostupný. Vložte obrázek, když musí být prezentace samostatná.

**Lze vložené SVG upravit jako tvary PowerPointu?**

Ano. Převodem SVG pomocí [IShapeCollection.addGroupShape] získáte skupinu upravitelných tvarů snímku namísto jediného SVG obrázku.

**Jak mohu udržet prezentace s mnoha obrázky menší?**

Znovu používejte sdílené obrázkové zdroje, vyhněte se zbytečně velkým rastrovým zdrojům, při vhodných situacích komprimujte rastrové obrázky, opakující se značku umisťujte na hlavní snímky nebo rozvržení a používáte propojené obrázky pouze tehdy, když je externí závislost přijatelná.