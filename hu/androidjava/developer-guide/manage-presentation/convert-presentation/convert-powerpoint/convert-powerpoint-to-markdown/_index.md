---
title: "PowerPoint prezentációk konvertálása Markdown formátumba Androidon"
linktitle: "PowerPoint Markdown-re"
type: docs
weight: 140
url: /hu/androidjava/convert-powerpoint-to-markdown/
keywords:
- "PowerPoint átalakítása"
- "prezentáció átalakítása"
- "dia átalakítása"
- "PPT átalakítása"
- "PPTX átalakítása"
- "PowerPoint MD-re"
- "prezentáció MD-re"
- "dia MD-re"
- "PPT MD-re"
- "PPTX MD-re"
- "PowerPoint mentése Markdown formátumban"
- "prezentáció mentése Markdown formátumban"
- "dia mentése Markdown formátumban"
- "PPT mentése MD formátumban"
- "PPTX mentése MD formátumban"
- "PPT exportálása MD-be"
- "PPTX exportálása MD-be"
- "Markdown kép exportálás"
- "CDN kép hivatkozások"
- "PowerPoint"
- "prezentáció"
- "Markdown"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Konvertálja a PPT és PPTX prezentációkat Markdown formátumba Androidon Java használatával, és szabályozza, hogy az exportált bitmap, metafájl és SVG képek hol legyenek mentve és hivatkozva."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes PPT és PPTX előadásokat Markdown formátumba konvertálni a dokumentáció, statikus weboldal, tartalom-migráció és verziókezelési munkafolyamatok számára. Kiválaszthat egy Markdown változatot, szabályozhatja, hogyan jelenik meg a dia tartalma, és meghatározhatja, hol tárolódnak az exportált képek, valamint hogy a generált Markdown hogyan hivatkozik rájuk.

Alapértelmezés szerint a Markdown export csak szöveges kimenetet használ. A vizuális tartalom exportálásához állítsa be az export típust a [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) metódussal a [MarkdownExportType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownexporttype/) felsorolt `Sequential` vagy `Visual` értékére. A `Sequential` külön és sorrendben rendereli a diaelemeket, míg a `Visual` csoportos elemként tartja őket, hogy megőrizze azok vizuális kapcsolatát. A `TextOnly` érték nem bocsát ki képernyőforrásokat, ezért ebben a módban a képmentési visszahívások nem hívódnak meg.

## **Prezentáció konvertálása Markdown formátumba**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) felsorolt `Md` értékével.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown változat kiválasztása**

A [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) metódus szabályozza a kimenethez használt Markdown specifikációt. A [Flavor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/flavor/) felsorolt tartalmazza a CommonMark, a GitHub Flavored Markdown és más támogatott változatok.

Az alábbi példa CommonMark formátumban exportál egy prezentációt:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Képek exportálása az alapértelmezett helyi mentési viselkedéssel**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) osztály két módszert biztosít a helyileg mentett képek konfigurálásához:

- [setBasePath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) megadja a Markdown dokumentum és erőforrásai alapkönyvtárát.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) megadja a képek alkönyvtárát. Alapértelmezett értéke `Images`.

Az alábbi példa vizuális tartalmat renderel, a képeket az `output/assets` könyvtárba írja, és relatív kép hivatkozásokat hoz létre a Markdown dokumentumban:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Ez a viselkedés a tartalék is, ha egy egyéni képmentő kezelő `false` értéket ad vissza.

## **Képmentés és Markdown hivatkozások testreszabása**

Használja a [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) metódust, hogy regisztráljon egy visszahívást a nem SVG bitmap és metafájl erőforrásokhoz, amelyek a Markdown export során keletkeznek. Ennek `MarkdownImageSavingHandler` visszahívása megkapja az [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektumot, annak [ImageFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/) értékét, valamint a generált Markdown hivatkozást egyelemes `String[]` paraméterként. Mentse vagy töltse fel a képet a megadott formátummal, és cserélje le a `link[0]` értéket a Markdown kimenetben megjelenő hivatkozásra.

Az SVG formátumban kibocsátott erőforrások külön kezelendők. Regisztráljon egy visszahívást a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) metódussal. Ennek `MarkdownSvgImageSavingHandler` visszahívása megkap egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) objektumot és egy egyelemes `String[] link` paramétert. Az SVG-nek nincs `ImageFormat` argumentuma; írja vagy töltse fel XML adatát az [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) metódussal. Az export módjától és a vizuális csoportosítástól függően egy forrásprésentációban lévő SVG rasterizálódhat vagy más tartalommal kombinálható; a keletkező nem‑SVG erőforrás ezután átkerül a képmentő visszahívásba. Regisztrálja mindkét visszahívást, ha minden exportált vizuális erőforrás egyedi feldolgozást igényel.

A kezelő visszatérési értéke határozza meg, ki dolgozza fel a képet:

- `true` értéket adjon vissza, ha a kezelő elmentette, feltöltötte, átalakította vagy egyéb módon feldolgozta a képet, és érvényes értéket rendelt a `link[0]`‑hez. Az Aspose.Slides ezt az értéket írja a Markdown dokumentumba, és nem hajtja végre az alapértelmezett helyi mentést.
- `false` értéket adjon vissza, ha az Aspose.Slides mentse a képet helyben, és készítse el a hivatkozást a [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) és a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) beállítások szerint.

{{% alert color="warning" title="Important" %}}
Egy `true` értéket visszaadó kezelő vállalja a kép felelősségét. Ha a kezelő `true`‑t ad vissza anélkül, hogy érvényes, nem üres hivatkozást rendelném a `link[0]`‑hez, az export `InvalidOperationException` hibával megszakad.
{{% /alert %}}

### **Képek mentése CDN eredeti könyvtárba és külső URL‑ek használata**

Az alábbi példa a `cdn-origin/presentations/quarterly-report` könyvtárat CDN eredeti, csatolt vagy szinkronizált könyvtárként kezeli. Minden kezelő kinyeri a generált fájlnevet, elmenti a képet az egyéni könyvtárba, és lecseréli a generált helyi hivatkozást egy nyilvános CDN URL‑re. A minta maga nem végez hálózati feltöltést: az URL csak akkor válik érvényessé, ha a könyvtár CDN eredetként csatlakozik, vagy fájljai közzétételre kerülnek a CDN‑en. Objektumtárolás esetén cserélje ki a fájlrendszer‑írást a tároló SDK feltöltési műveletére, és csak a feltöltés sikeres befejezése után állítsa be a `link[0]`‑t.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

A bitmap kezelő szándékosan `false`‑t ad vissza 128 × 128 pixelnél kisebb képek esetén, így az Aspose.Slides ezeket a képeket a `output/fallback-images` könyvtárba menti az alapértelmezett viselkedés szerint. A nagyobb bitmap és metafájl erőforrások, valamint az SVG erőforrások a személyre szabott kóddal kerülnek feldolgozásra. Például egy generált helyi hivatkozás, mint `fallback-images/image1.png`, `https://cdn.example.com/presentations/quarterly-report/image1.png` lesz. A kezelők csak operációs rendszer‑specifikus útvonalakat használnak fájlok írásához; a Markdown‑ben írt hivatkozások előre‑perceles vonallal és URL‑kódolt fájlnevekkel rendelkeznek. Ugyanezt a szabályt alkalmazza relatív hivatkozások építésekor: használjon `/`‑t, ne a platform‑specifikus könyvtár‑elválasztót.

## **GYIK**

**Képes egy kezelő mind a raszteres, mind az SVG képeket feldolgozni?**

Nem. Használja a [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/)‑t a bitmap és metafájl erőforrásokhoz, és a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/)‑t az SVG‑ként kibocsátott erőforrásokhoz. Az első egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektumot és egy [ImageFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imageformat/) értéket ad, a második egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) objektumot, amelynek SVG adatait az [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/)‑val lehet olvasni. Egy export során rasterizált SVG forrásfájlt a képmentő visszahívás dolgozza fel.

**Mi történik, ha egy képmentő kezelő `false`‑t ad vissza?**

Az Aspose.Slides az alapértelmezett helyi mentési viselkedést használja. A kép helyét és a generált hivatkozást a [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) és a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) beállítások határozzák meg.

**Adhat egy kezelő URL‑t anélkül, hogy a képet helyben mentené?**

Igen. A kezelő feltöltheti a képet objektumtárolóba vagy átadhatja egy másik szolgáltatásnak, beállíthatja a kapott URL‑t a `link[0]`‑ban, és `true`‑t ad vissza. A kezelőnek saját maga felelőssége a feldolgozás, a `true` visszaadása megakadályozza az alapértelmezett helyi mentést.

**Miért dob `InvalidOperationException`-t a Markdown export egy kezelőtől?**

Ez a kivétel akkor fordul elő, ha a kezelő `true`‑t ad vissza, de nem biztosít érvényes hivatkozást. A visszatérés előtt rendelje hozzá a relatív útvonalat vagy külső URL‑t, amelyet a Markdown‑be kell írni.

**Milyen útvonal‑elválasztót kell használni a kép hivatkozásokhoz?**

Használjon előre‑perceles vonalat (`/`) a Markdown hivatkozásokban és URL‑ekben. A `Path.resolve`‑t csak fájlrendszer‑útvonalakhoz használja, majd külön hozza létre vagy normalizálja a Markdown hivatkozást.

**Megmaradnak a hiperhivatkozások a Markdown export során?**

Igen. A szöveges [hyperlinks](/slides/hu/androidjava/manage-hyperlinks/) megmaradnak szabványos Markdown hivatkozásként. A dia [transitions](/slides/hu/androidjava/slide-transition/) és [animations](/slides/hu/androidjava/powerpoint-animation/) nem kerülnek konvertálásra.

**Konvertálhatók a prezentációk párhuzamosan Markdown formátumba?**

Különböző prezentációfájlok feldolgozhatók párhuzamosan, de egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt ne osszon meg szálak között. Kövesse a [multithreading guidelines](/slides/hu/androidjava/multithreading/) útmutatót, és minden fájlhoz használjon külön példányt.