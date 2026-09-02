---
title: PowerPoint bemutatók konvertálása Markdownba Java-ban
linktitle: PowerPoint Markdownba
type: docs
weight: 140
url: /hu/java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint átalakítása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint MD-be
- bemutató MD-be
- dia MD-be
- PPT MD-be
- PPTX MD-be
- PowerPoint mentése Markdownként
- bemutató mentése Markdownként
- dia mentése Markdownként
- PPT mentése MD-ként
- PPTX mentése MD-ként
- PPT exportálása MD-be
- PPTX exportálása MD-be
- Markdown kép exportálás
- CDN kép hivatkozások
- PowerPoint
- bemutató
- Markdown
- Java
- Aspose.Slides
description: "Konvertálja a PPT és PPTX bemutatókat Markdownba Java-ban, és szabályozza, hogy a exportált bitmap, metafájl és SVG képek hol legyenek mentve és hivatkozva."
---
## **Áttekintés**

Az Aspose.Slides for Java képes PPT és PPTX bemutatókat Markdown formátumba konvertálni dokumentáció, statikus webhely, tartalom‑migráció és verziókezelési munkafolyamatok számára. Kiválaszthat egy Markdown változatot, szabályozhatja, hogyan jelenik meg a diák tartalma, és meghatározhatja, hogy hol kerülnek tárolásra az exportált képek, valamint hogyan hivatkozik rájuk a generált Markdown.

Alapértelmezés szerint a Markdown export csak szöveges kimenetet használ. A vizuális tartalom exportálásához állítsa be az export típust a [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) metódussal a [MarkdownExportType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownexporttype/) felsorolás `Sequential` vagy `Visual` értékére. A `Sequential` külön és sorrendben jeleníti meg a diaelemeket, míg a `Visual` csoportos elemeket együtt tartja, hogy megőrizze azok vizuális kapcsolatát. A `TextOnly` érték nem bocsát ki képernyő erőforrásokat, ezért ebben a módban a képek mentésére vonatkozó visszahívások nem kerülnek meghívásra.

## **Bemutató konvertálása Markdownba**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) felsorolás `Md` értékével.

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

A [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) metódus szabályozza a kimenethez használt Markdown specifikációt. A [Flavor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/flavor/) felsorolás tartalmazza a CommonMark, a GitHub Flavored Markdown és egyéb támogatott változatokat.

A következő példa egy bemutatót CommonMark formátumba exportál:

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

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) osztály két metódust biztosít a helyben mentett képek konfigurálásához:

- [setBasePath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) adja meg a Markdown dokumentum és erőforrásai alapkönyvtárát.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) adja meg a képek alkönyvtárát. Alapértelmezett értéke `Images`.

A következő példa vizuális tartalmat renderel, a képeket a `output/assets` könyvtárba írja, és relatív kép hivatkozásokat hoz létre a Markdown dokumentumban:

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

Ez a viselkedés visszaesetként is működik, ha egy egyéni képfájl mentő kezelő `false` értéket ad vissza.

## **Kép mentésének és Markdown hivatkozások testreszabása**

Használja a [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) metódust, hogy regisztráljon egy visszahívást a nem SVG bitmap és metafájl erőforrásokhoz, amelyeket a Markdown export során ad ki. A `MarkdownImageSavingHandler` visszahívás megkapja a [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumot, annak [ImageFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/) értékét, valamint a generált Markdown hivatkozást egy elemes `String[]` paraméterként. Mentse vagy töltse fel a képet a megadott formátummal, és cserélje ki a `link[0]` értéket arra a hivatkozásra, amelynek meg kell jelennie a Markdown kimenetben.

Az SVG formátumban kiadott erőforrások külön kezelhetők. Regisztráljon egy visszahívást a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) metódussal. Ennek `MarkdownSvgImageSavingHandler` visszahívása kap egy [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) objektumot és egy elemes `String[] link` paramétert. Az SVG‑nek nincs `ImageFormat` argumentuma; helyette írja vagy töltse fel XML adatait a [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) metódussal. Az export módjától és a vizuális csoportosítástól függően a forrás bemutatóban lévő SVG rasterizálódhat vagy más tartalommal kombinálódhat; az eredményül kapott nem‑SVG erőforrás ezután átkerül a kép‑mentés visszahívásba. Regisztrálja mindkét visszahívást, ha minden exportált vizuális erőforrás egyedi feldolgozást igényel.

A handler visszatérési értéke határozza meg, ki dolgozza fel a képet:

- Adjon vissza `true` értéket, ha a kezelő elmentette, feltöltötte, átalakította vagy egyéb módon feldolgozta a képet, és érvényes értéket rendelt a `link[0]`‑hez. Az Aspose.Slides ezt az értéket beírja a Markdown dokumentumba, és nem hajtja végre az alapértelmezett helyi mentést.
- Adjon vissza `false` értéket, hogy az Aspose.Slides helyben mentse a képet, és a [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) illetve a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) által megadott értékek alapján hozza létre a hivatkozást.

{{% alert color="warning" title="Important" %}}
A `true` értéket visszaadó kezelő vállalja a kép felelősségét. Ha `true`‑t ad vissza anélkül, hogy érvényes, nem üres hivatkozást rendelt volna a `link[0]`‑hez, az export `InvalidOperationException` hibát eredményez.
{{% /alert %}}

### **Képek mentése CDN eredeti könyvtárba és külső URL-ek használata**

A következő példa a `cdn-origin/presentations/quarterly-report` könyvtárat egy felcsatolt vagy szinkronizált CDN eredeti könyvtárként kezeli. Minden kezelő kiolvassa a generált fájlnevet, elmenti a képet ebbe az egyéni könyvtárba, és a generált helyi hivatkozást egy nyilvános CDN URL-re cseréli. A mintakód nem végez hálózati feltöltést: az URL csak akkor válik érvényessé, ha a könyvtár fel van csatolva CDN eredetként vagy fájljai közzé vannak téve a CDN-ben. Objektumtároláshoz cserélje le a fájlrendszer írását a tároló SDK feltöltési műveletére, és csak a feltöltés sikeres befejezése után állítsa be a `link[0]` értékét.

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

A bitmap kezelő szándékosan `false` értéket ad vissza 128 × 128 pixelnél kisebb képek esetén, ezért az Aspose.Slides ezeket a képeket a `output/fallback-images` könyvtárba menti az alapértelmezett viselkedés szerint. A nagyobb bitmap és metafájl erőforrásokat, valamint az SVG erőforrásokat az egyedi kód kezeli. Például egy generált helyi hivatkozás, mint `fallback-images/image1.png`, `https://cdn.example.com/presentations/quarterly-report/image1.png` URL-re alakul. A kezelők csak fájlok írásakor használnak operációs rendszer útvonalakat; a Markdown‑ba írt hivatkozások előre‑döntött perjeleket és URL‑kódolt fájlneveket használnak. Ugyanezt a szabályt alkalmazza relatív hivatkozások felépítésekor: használjon `/`‑t, ne a platform‑specifikus könyvtárelválasztót.

## **FAQ**

**Kezelhet egyetlen handler mind raszteres, mind SVG képeket?**

Nem. Használja a [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) metódust a bitmap és metafájl erőforrásokhoz, valamint a [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) metódust az SVG‑ként kiadott erőforrásokhoz. Az első egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumot és egy [ImageFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/) értéket biztosít; a második egy [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) objektumot, amelynek SVG adatait a [ISvgImage.getSvgData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) metódussal lehet beolvasni. A forrás SVG, amely exportáláskor rasterizálódik, a kép‑mentés visszahívással kerül feldolgozásra.

**Mi történik, ha egy kép‑mentő handler `false`‑t ad vissza?**

Az Aspose.Slides az alapértelmezett helyi mentési viselkedését használja. A kép helyét és a generált hivatkozást a [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) illetve a [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) által megadott értékek szabályozzák.

**Képes‑e egy handler URL‑t szolgáltatni a kép helyi mentése nélkül?**

Igen. A handler feltöltheti a képet objektumtárolóba vagy átadhatja egy másik szolgáltatásnak, a kapott URL‑t rendeli a `link[0]`‑hez, és `true`‑t ad vissza. A handlernek magának kell befejeznie a feldolgozást; a `true` visszaadása megakadályozza az alapértelmezett helyi mentést.

**Miért dob `InvalidOperationException`‑t a Markdown export egy handler‑től?**

Ez a kivétel akkor fordul elő, ha a handler `true`‑t ad vissza, de nem biztosít érvényes hivatkozást. A visszatérés előtt rendelje hozzá a relatív útvonalat vagy külső URL‑t, amelyet a Markdownba kell írni.

**Melyik útvonal‑elválasztót kell használni a kép hivatkozásokban?**

Használjon előre‑döntött perjeleket (`/`) a Markdown hivatkozásokban és URL‑ekben. A fájlrendszer útvonalakhoz csak a `Path.resolve`‑t alkalmazza, majd a Markdown hivatkozást külön normalizálja.

**Megőrződnek‑e a hiperhivatkozások a Markdown export során?**

Igen. A szöveges [hyperlinks](/slides/hu/java/manage-hyperlinks/) megmaradnak szabványos Markdown hivatkozásként. A dia [transitions](/slides/hu/java/slide-transition/) és [animations](/slides/hu/java/powerpoint-animation/) nem kerülnek konvertálásra.

**Konvertálhatók‑e a bemutatók párhuzamosan Markdownba?**

Feldolgozhat különböző bemutató fájlokat párhuzamosan, de ne ossza meg ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt szálak között. Kövesse a [multithreading guidelines](/slides/hu/java/multithreading/) útmutatót, és minden fájlhoz használjon külön példányt.