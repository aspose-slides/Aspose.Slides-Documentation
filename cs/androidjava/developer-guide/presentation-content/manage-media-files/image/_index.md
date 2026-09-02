---
title: "Optimalizace správy obrázků v prezentacích na Androidu"
linktitle: "Správa obrázků"
type: docs
weight: 10
url: /cs/androidjava/image/
keywords:
- přidat obrázek
- přidat obrázek
- nahradit obrázek
- kolekce obrázků
- rámeček s obrázkem
- odkazovaný obrázek
- pozadí
- přidat PNG
- přidat JPG
- přidat SVG
- SVG na tvary
- externí SVG zdroje
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak přidávat, znovu používat, odkazovat, nahrazovat a spravovat rastrové a SVG obrázky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android pomocí Javy."
---
## **Úvod**

Aspose.Slides for Android via Java poskytuje několik způsobů práce s obrázky a každý slouží jinému účelu. Můžete uložit obrázek v prezentaci, zobrazit jej v rámečku s obrázkem, použít jej jako pozadí snímku, odkázat na externí obrázek, nahradit sdílený obrázkový zdroj nebo převést obsah SVG na editovatelné tvary.

Tento článek se zaměřuje na obrázkové zdroje a jak jsou používány v celé prezentaci. Pro ořezávání, průhlednost, efekty, natahování a další formátování aplikované na jednotlivý rámeček s obrázkem, viz [Picture Frame](/slides/cs/androidjava/picture-frame/).

## **Porozumění modelu obrázku**

Následující pojmy API jsou úzce související, ale nejsou zaměnitelné:

- [Kolekce obrázků prezentace](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagecollection/) ukládá obrázkové zdroje používané v prezentaci. Použijte [ImageCollection.addImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imagecollection/) pro přidání dat obrázku a získání zdroje [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/).
- [Rámeček s obrázkem](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) je tvar, který zobrazuje obrázek na snímku, rozvržení nebo předloze. Použijte [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/) pro umístění obrázkového zdroje na snímek.
- Pozadí snímku používá obrázek jako část výplně snímku, nikoli jako tvar. Proto se nechová jako rámeček s obrázkem.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) nahrazuje obrázkový zdroj. Pokud jej používá několik prvků prezentace, všichni použijí nahrazení.
- Převod SVG na tvary vytvoří editovatelné tvary snímku. Po převodu není obsah již spravován jako jeden obrázkový zdroj.

Typický pracovní postup je tedy: přidat data obrázku do kolekce obrázků, získat [IPPImage] a poté použít tento zdroj v jednom nebo více rámečcích s obrázkem nebo výplních.

## **Přidání vloženého obrázku**

Pro vložení lokálního obrázku načtěte soubor, přidejte jej do kolekce obrázků a vytvořte rámeček s obrázkem, který použije vrácený `IPPImage`.

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

Obrázek přidaný tímto způsobem je vložen do prezentace, takže výsledný soubor nezávisí na tom, zda je původní soubor obrázku nadále dostupný.

### **Přidání obrázku z webu**

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

V dlouho běžících aplikacích opakovaně používejte HTTP klienta nebo strategii správy připojení vhodnou pro aplikaci místo opakovaného vytváření zbytečné síťové infrastruktury. Také ověřujte vzdálené URL, velikosti odpovědí a typy obsahu, pokud zdroj není důvěryhodný.

## **Znovupoužití obrázků napříč snímky**

Pokud je stejný obrázek potřeba vícekrát, přidejte jej do prezentace jednou a opakovaně použijte vrácený [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) při vytváření dalších rámečků s obrázkem. Tím se zabrání opakovanému načítání stejných zdrojových dat a vztah mezi sdíleným obrázkovým zdrojem a jeho použití se stane explicitním.

Pro grafiku, která by se měla automaticky objevovat na mnoha snímcích, například firemní logo, zvažte umístění rámečku s obrázkem na [slide master](/slides/cs/androidjava/slide-master/) nebo rozvržení místo přidávání ekvivalentního tvaru na každý snímek.

## **Použití obrázku jako pozadí snímku**

Obrázek na pozadí je přiřazen k výplni snímku; není přidán jako tvar rámečku s obrázkem. Toto je užitečné, když má obrázek pokrýt pozadí snímku a neměl by být manipulován jako běžný objekt snímku.

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

Pro další možnosti pozadí, včetně pozadí předlohy a rozvržení, viz [Presentation Background](/slides/cs/androidjava/presentation-background/).

## **Vložené a odkazované obrázky**

Vložené a odkazované obrázky mají různé kompromisy v přenositelnosti a velikosti souboru:

- **Vložený obrázek:** data obrázku jsou uložena uvnitř prezentace. Prezentace je samostatná, ale velikost souboru zahrnuje data obrázku.
- **Odkazovaný obrázek:** prezentace ukládá cestu nebo URL k externímu obrázku. To může zmenšit velikost prezentace, ale externí zdroj musí být dostupný při otevření nebo vykreslení prezentace.

Odkazovaný obrázek lze vytvořit přiřazením externí cesty nebo URL pomocí [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidespicture/) místo vložení dat obrázku.

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

Používejte odkazované obrázky jen tehdy, když nasazovací prostředí může spolehlivě přistupovat k externímu zdroji. Pro prezentace, které musí fungovat offline nebo být přesouvány mezi systémy, jsou vložené obrázky obvykle bezpečnější.

## **Práce s SVG obrázky**

SVG je vektorový formát, takže může být užitečný pro ikony, diagramy a další grafiku, která by měla škálovat bez stejné ztráty detailu jako rastrové obrázky. Aspose.Slides podporuje SVG jak jako obrázkový zdroj, tak jako zdroj pro editovatelné tvary snímku.

### **Přidání SVG jako obrázku**

Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgimage/), přidejte jej do kolekce obrázků a umístěte vzniklý obrázkový zdroj do rámečku s obrázkem.

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

SVG může odkazovat na externí obrázky, style sheet nebo fonty. Pro tyto případy [SvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/svgimage/) poskytuje konstruktory, které přijímají [IExternalResourceResolver](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iexternalresourceresolver/) a základní URI. Resolver může mapovat relativní URI na povolené absolutní URI a vrátit proud pro požadovaný zdroj.

Resolver zpřístupňuje externí zdroje během zpracování SVG v Aspose.Slides, ale nepřepisuje SVG na samostatný dokument. Pokud musí SVG zůstat přenosný, vložte požadované zdroje přímo do SVG, například pomocí `data:` URI pro odkazované obrázky.

Když SVG soubory pocházejí z nedůvěryhodných zdrojů, omezte schémata, umístění souborů a hosty, ke kterým může resolver přistupovat. Síťové resolvery by také měly aplikovat časová omezení, limity velikosti odpovědí a validaci obsahu.

### **Převod SVG na editovatelné tvary**

Aspose.Slides může převést SVG na skupinu editovatelných tvarů snímku, podobně jako odpovídající příkaz PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Použijte přetížení [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/), které přijímá [ISvgImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isvgimage/), k provedení převodu.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Použijte převod SVG na tvary, když je potřeba editovat jednotlivé vektorové prvky jako tvary PowerPointu. Pokud je SVG potřeba jen zobrazit, je jednodušší udržet jej jako obrázek a vyhnete se tvorbě mnoha samostatných tvarů.

## **Nahrazení existujícího obrázkového zdroje**

Použijte [IPPImage.replaceImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) pokud chcete nahradit existující obrázkový zdroj. Toto je zvláště užitečné pro sdílenou grafiku, jako jsou loga.

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

Pokud více rámečků s obrázkem, pozadí, předloh nebo rozvržení používá stejný obrázkový zdroj, nahrazení tohoto zdroje aktualizuje všechny tyto použití. Pokud má být změněn jen jeden rámeček s obrázkem, přiřaďte tomuto rámečku jiný obrázek místo nahrazení sdíleného zdroje.

`replaceImage` také poskytuje přetížení, která přijímají pole bajtů nebo další [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/).

## **Praktické pokyny pro správu obrázků**

### **Kontrola velikosti prezentace**

Velké rastrové obrázky mohou prezentaci zbytečně zvětšit. Používejte zdrojové obrázky s rozměry vhodnými pro zamýšlenou velikost zobrazení, opakovaně využívejte sdílené obrázkové zdroje, kde je to možné, a vyhněte se vkládání opakovaných kopií stejné grafiky v plném rozlišení.

Pro rastrové obrázky, které již byly umístěny v rámečcích s obrázkem, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) může snížit data obrázku podle vybrané rozlišení a nastavení ořezu. Jedná se o zpracování rámečku s obrázkem, nikoli správu kolekce obrázků, proto viz [Picture Frame](/slides/cs/androidjava/picture-frame/) pro související operace formátování.

### **Volba mezi vloženým a odkazovaným obsahem**

Vložení činí prezentaci přenosnou, protože všechna potřebná data obrázku cestují se souborem. Odkazování může zmenšit velikost souboru, ale zavádí externí závislost. Používejte odkazy jen tehdy, když je tato závislost přijatelná a stabilní.

### **Opakované využití sdílené značky**

Pro opakovaná loga, vodoznaky nebo dekorativní grafiku použijte jeden obrázkový zdroj a opakovaně jej využijte. Pokud grafika patří do návrhu prezentace spíše než do obsahu snímku, umístěte ji na předlohu nebo rozvržení, aby byla děděna příslušnými snímky.

### **Zachování přenositelnosti SVG zdrojů**

Samostatný SVG je snazší přenést a vykreslovat konzistentně než SVG, který závisí na externích souborech nebo síťových zdrojích. Kdykoli je to možné, vložte požadované zdroje před importem SVG. Převádějte SVG na tvary jen tehdy, když je potřeba editovat jednotlivé vektorové prvky.

### **Použití moderního multiplatformního Image API**

Pro nový kód Android via Java používejte Aspose.Slides [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/) a [Images](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/images/) API namísto staršího veřejného API založeného na `android.graphics.Bitmap`. Viz [Modern API](/slides/cs/androidjava/modern-api/) pro pokyny k migraci.

WMF a EMF vyžadují zvláštní úvahu. Když jsou tyto formáty předány přes [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imagecollection/) převádí metafil na rastrovou PNG reprezentaci před vložením. Pokud je důležité zachovat data metafilu, použijte místo toho přetížení [ImageCollection.addImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imagecollection/) založené na proudu. Generování obsahu EMF z tabulek nebo jiných produktů je samostatný integrační pracovní postup a není součástí tohoto článku.

## **Často kladené otázky**

**Jaký je rozdíl mezi kolekcí obrázků a rámečkem s obrázkem?**

Kolekce obrázků ukládá znovu použitelné obrázkové zdroje. Rámeček s obrázkem je tvar na snímku, který zobrazuje jeden z těchto zdrojů a poskytuje specifické formátování obrázku, jako je ořezávání a efekty.

**Jaký je nejlepší způsob, jak všude nahradit stejné logo?**

Pokud je logo již sdíleno jako jeden obrázkový zdroj, nahraďte tento zdroj pomocí [IPPImage.replaceImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/). Pro značku napříč celou prezentací může umístění loga na předlohu nebo rozvržení také snížit duplicitní obsah snímků.

**Proč odkazovaný obrázek zmizí na jiném počítači?**

Odkazovaný obrázek závisí na externím souboru nebo URL. Pokud není tento zdroj z jiného počítače dosažitelný, může být odkazovaný obrázek nedostupný. Vložte obrázek, pokud musí být prezentace samostatná.

**Lze vložené SVG editovat jako tvary PowerPointu?**

Ano. Převodem SVG pomocí [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/) získáte skupinu obsahující editovatelné tvary snímku místo jednoho SVG obrázku.

**Jak mohu udržet prezentace s mnoha obrázky menší?**

Opakovaně využívejte sdílené obrázkové zdroje, vyhýbejte se zbytečně velkým rastrovým zdrojům, při vhodných podmínkách komprimujte vhodné rastrové obrázky, udržujte opakovanou značku na předlohách nebo rozvrženích a odkazované obrázky používejte jen tehdy, když je externí závislost přijatelná.