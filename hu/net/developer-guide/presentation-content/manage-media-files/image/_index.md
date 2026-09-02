---
title: Képek kezelésének optimalizálása .NET prezentációkban
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/net/image/
keywords:
- kép hozzáadása
- képkeret hozzáadása
- kép cseréje
- képgyűjtemény
- képkeret
- hivatkozott kép
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- SVG alakzatokká konvertálása
- külső SVG erőforrások
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, újrahasználhat, hivatkozhat, cserélhet és kezelhet raszter és SVG képeket PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével."
---
## **Bevezetés**

Az Aspose.Slides for .NET többféle módot biztosít a képekkel való munkához, és mindegyik más célra szolgál. Egy képet elhelyezhet a prezentációban, megjelenítheti egy képkeretben, használhatja dia háttérként, hivatkozhat külső képre, lecserélhet egy megosztott kép erőforrást, vagy SVG tartalmat alakíthat át szerkeszthető alakzatokká.

Ez a cikk a kép erőforrásokra és azok prezentáción belüli használatára összpontosít. A vágás, átlátszóság, effektusok, nyújtás és egyéb formázások egyedi képkerethez kapcsolódó részleteiért lásd a [Képkeret](/slides/hu/net/picture-frame/) oldalt.

## **Értsd meg a képmodellt**

- A [prezentáció képgyűjteménye](https://reference.aspose.com/slides/hu/net/aspose.slides/iimagecollection/) tárolja a prezentáció által használt kép erőforrásokat. Használja az [ImageCollection.AddImage](https://reference.aspose.com/slides/hu/net/aspose.slides/imagecollection/addimage/) metódust a kép adat hozzáadásához, és egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) erőforrást kap.
- A [képkeret](https://reference.aspose.com/slides/hu/net/aspose.slides/ipictureframe/) egy alakzat, amely képet jelenít meg egy dián, elrendezésen vagy masteren. Használja az [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addpictureframe/) metódust egy kép erőforrás elhelyezéséhez a dián.
- A dia háttér egy képet a dia kitöltésének részeként használja, nem alakzatként. Ezért nem viselkedik úgy, mint egy képkeret.
- Az [IPPImage.ReplaceImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/replaceimage/) lecserél egy kép erőforrást. Ha több prezentációelem használja azt, mindegyik a helyettesítést használja.
- Az SVG alakzatokká konvertálása szerkeszthető diaalakzatokat hoz létre. A konverzió után a tartalom már nem egyetlen képernyő erőforrásként van kezelve.

Egy tipikus munkafolyamat tehát: képadatok hozzáadása a képgyűjteményhez, egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) kapása, majd ennek az erőforrásnak a használata egy vagy több képkeretben vagy kitöltésben.

## **Beágyazott kép hozzáadása**

Helyi kép beszúrásához olvassa be a fájlt, adja hozzá adatait a képgyűjteményhez, és hozzon létre egy képkeretet, amely a visszakapott `IPPImage`-t használja.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Az így hozzáadott kép be van ágyazva a prezentációba, így a keletkezett fájl nem függ a forrás képfájl elérhetőségétől.

### **Kép hozzáadása a webről**

Ha egy kép HTTP vagy HTTPS-en érhető el, töltse le a bájtokat a `HttpClient`‑el, adja hozzá a prezentáció képgyűjteményéhez, és a visszakapott kép erőforrást ugyanúgy használja, mint egy helyi képet.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

Hosszú futású alkalmazásokban használja újra a `HttpClient`‑et ahelyett, hogy minden kéréshez új példányt hozna létre. Emellett ellenőrizze a távoli URL‑eket, a válasz méretét és a tartalomtípusokat, ha a forrás nem megbízható.

## **Képek újrahasználata diák között**

Ha ugyanarra a képre több alkalommal is szükség van, adja hozzá egyszer a prezentációhoz, és az így visszakapott [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) használja további képkeretek létrehozásakor. Ez elkerüli a forrásadatok többszöri betöltését, és egyértelművé teszi a megosztott kép erőforrás és felhasználásai közti kapcsolatot.

Azokhoz a grafikákhoz, amelyeknek automatikusan meg kell jelenniük sok dián, például vállalati logóhoz, érdemes a képkeretet egy [dia master](/slides/hu/net/slide-master/) vagy elrendezésre helyezni, ahelyett, hogy minden diához egy ekvivalens alakzatot adna hozzá.

## **Kép használata dia háttérként**

A háttérkép a dia kitöltéséhez van rendelve; nem kerül hozzáadásra képkeret alakzatként. Ez akkor hasznos, amikor a képnek a dia hátterét kell lefednie, és nem szabad a szokásos diaobjektumként kezelni.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

További háttérbeállításokért, beleértve a master és elrendezés háttereket, lásd a [Prezentáció háttér](/slides/hu/net/presentation-background/) oldalt.

## **Beágyazott és hivatkozott képek**

A beágyazott és a hivatkozott képek különböző hordozhatósági és fájlméretbeli kompromisszumokkal járnak:
- **Beágyazott kép:** a képadat a prezentáción belül tárolódik. A prezentáció önálló, de a fájlméret tartalmazza a képadatot.
- **Hivatkozott kép:** a prezentáció egy útvonalat vagy URL‑t tárol egy külső képhez. Ez csökkentheti a prezentáció méretét, de a külső erőforrásnak elérhetőnek kell maradnia a prezentáció megnyitásakor vagy renderelésekor.

Egy hivatkozott képet úgy hozhatunk létre, hogy a külső útvonalat vagy URL‑t a [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/hu/net/aspose.slides/islidespicture/linkpathlong/) segítségével állítjuk be, ahelyett, hogy a képadatot beágyaznánk.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Csak akkor használjon hivatkozott képeket, ha a telepítési környezet megbízhatóan eléri a külső erőforrást. Olyan prezentációk esetén, amelyeknek offline kell működniük vagy rendszerek között mozgatniuk kell őket, a beágyazott képek általában biztonságosabbak.

## **Működés SVG képekkel**

Az SVG egy vektoros formátum, ezért ikonok, diagramok és egyéb grafikák esetén hasznos, amelyeket méretezéskor nem veszítenek részletességben a raszteres képekhez képest. Az Aspose.Slides támogatja az SVG‑t mind képernyő erőforrásként, mind szerkeszthető dia alakzatok forrásaként.

### **SVG hozzáadása képként**

Hozzon létre egy [SvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/svgimage/) objektumot, adja hozzá a képgyűjteményhez, és helyezze az eredményül kapott kép erőforrást egy képkeretbe.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **SVG fájlok külső erőforrásokkal**

Az SVG külső képekre, stíluslapokra vagy betűkészletekre hivatkozhat. Ilyen esetekre a [SvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/svgimage/) konstruktorok fogadnak egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/net/aspose.slides.import/iexternalresourceresolver/) és egy alap‑URI értéket. A resolver képes egy relatív URI‑t egy engedélyezett abszolút URI‑ra leképezni, és egy streamet visszaadni a kért erőforráshoz.

A resolver elérhetővé teszi a külső erőforrásokat, amíg az Aspose.Slides feldolgozza az SVG‑t, de nem írja át az SVG‑t önálló dokumentummá. Ha az SVG‑nek hordozhatónak kell maradnia, ágyazza be a szükséges erőforrásokat közvetlenül az SVG‑be, például `data:` URI‑k használatával a hivatkozott képekhez.

Amikor az SVG fájlok nem megbízható forrásból származnak, korlátozza a resolver által elérhető sémákat, fájlhelyek és hostok. A hálózati resolvernek időkorlátokat, válaszméret‑korlátokat és tartalom‑ellenőrzést is alkalmaznia kell.

### **SVG konvertálása szerkeszthető alakzatokká**

Az Aspose.Slides képes egy SVG‑t szerkeszthető diaalakzatok csoportjává konvertálni, hasonlóan a megfelelő PowerPoint parancshoz.

![PowerPoint Popup Menu](img_01_01.png)

Használja a [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addgroupshape/) túlterhelést, amely egy [ISvgImage](https://reference.aspose.com/slides/hu/net/aspose.slides/isvgimage/)‑t fogad, a konverzió végrehajtásához.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Használja az SVG‑alakzat konverziót, ha az egyes vektoros elemeket PowerPoint alakzatokként kell szerkeszteni. Ha az SVG‑t csak megjeleníteni kell, képként tartása egyszerűbb és elkerüli sok különálló alakzat létrehozását.

## **Meglévő kép erőforrás cseréje**

Használja az [IPPImage.ReplaceImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/replaceimage/) metódust, ha egy meglévő kép erőforrást szeretne cserélni. Ez különösen hasznos megosztott grafikák, például logók esetén.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Ha több képkeret, háttér, master vagy elrendezés használja ugyanazt a kép erőforrást, a csere mindegyik használatot frissíti. Ha csak egy képkeretet kell módosítani, rendeljünk hozzá egy másik képet ahhoz a kerethez ahelyett, hogy a megosztott erőforrást cserélnénk.

`ReplaceImage` további túlterheléseket is kínál, amelyek egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) vagy egy másik [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) paramétert fogadnak.

## **Gyakorlati képkezelési útmutató**

### **A prezentáció méretének szabályozása**

A nagy raszteres képek szükségtelenül nagyra bővíthetik a prezentációt. Használjon forrásképeket, amelyek méretei megfelelnek a kívánt megjelenítési méretnek, újrahasználja a megosztott kép erőforrásokat, ahol csak lehetséges, és kerüld el ugyanannak a teljes felbontású grafikának a többszörös beágyazását.

A már képkeretekben elhelyezett raszteres képek esetén az [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/compressimage/) a kiválasztott felbontás és vágóbeállítások alapján csökkentheti a képadatot. Ez képkeret‑feldolgozás, nem a képgyűjtemény kezelése, ezért lásd a [Képkeret](/slides/hu/net/picture-frame/) oldalt a kapcsolódó formázási műveletekhez.

### **Válasszon beágyazott és hivatkozott tartalom között**

A beágyazás hordozhatóvá teszi a prezentációt, mivel minden szükséges képadat a fájllal együtt utazik. A hivatkozás csökkentheti a fájlméretet, de külső függőséget vezet be. Hivatkozásokat csak akkor használjon, ha ez a függőség elfogadható és stabil.

### **Megosztott márka újrahasználata**

Ismétlődő logók, vízjelek vagy dekoratív grafikák esetén használjon egyetlen kép erőforrást, és azt újrahasználja. Ha a grafika a prezentáció tervezéséhez tartozik, nem a dia tartalmához, helyezze el egy masteren vagy elrendezésen, hogy a megfelelő diák örököljék.

### **SVG erőforrások hordozhatóságának biztosítása**

Az önálló SVG könnyebben mozgatható és konzisztensen renderelhető, mint egy külső fájlokra vagy hálózati erőforrásokra támaszkodó SVG. Amikor lehetséges, ágyazzon be szükséges erőforrásokat az SVG importálása előtt. Konvertálja az SVG‑t alakzatokká csak akkor, ha az egyes vektoros elemeket szerkeszteni kell.

### **Használja a modern keresztplatformú kép‑API‑t**

Új .NET kódban használja az Aspose.Slides [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/) és [Images](https://reference.aspose.com/slides/hu/net/aspose.slides/images/) API‑kat a `System.Drawing.Image` vagy `Bitmap` helyett. A migrációs útmutatásért lásd a [Modern API](/slides/hu/net/modern-api/) oldalt.

A WMF és EMF formátumok külön figyelmet igényelnek. Amikor ezeket a formátumokat egy [IImage](https://reference.aspose.com/slides/hu/net/aspose.slides/iimage/)‑en keresztül adjuk át, az [ImageCollection.AddImage](https://reference.aspose.com/slides/hu/net/aspose.slides/imagecollection/addimage/) konvertálja a metafájlt egy raszteres PNG ábrázolássá a beszúrás előtt. Ha a metafájl adatainak megőrzése fontos, használjon stream‑alapú [ImageCollection.AddImage](https://reference.aspose.com/slides/hu/net/aspose.slides/imagecollection/addimage/) túlterhelést. EMF tartalom generálása táblázatokból vagy más termékekből külön integrációs munkafolyamat, és kívül esik ennek a cikknek a hatókörén.

## **GYIK**

**Mi a különbség a képgyűjtemény és egy képkeret között?**

A képgyűjtemény újrahasznosítható kép erőforrásokat tárol. Egy képkeret egy diaalakzat, amely megjeleníti ezeket az erőforrásokat, és képkép‑specifikus formázást, például vágást és effektusokat biztosít.

**Mi a legjobb módja ugyanannak a logónak a cseréjére mindenhol?**

Ha a logó már egy kép erőforrásként van megosztva, cserélje azt az erőforrást az [IPPImage.ReplaceImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/replaceimage/) segítségével. A teljes prezentációra kiterjedő márkaépítéshez a logó elhelyezése egy masteren vagy elrendezésen szintén csökkentheti a duplikált dia tartalmat.

**Miért tűnik el egy hivatkozott kép egy másik számítógépen?**

A hivatkozott kép külső fájlra vagy URL‑re támaszkodik. Ha a másik számítógépről nem érhető el ez az erőforrás, a hivatkozott kép nem lesz elérhető. Ágyazza be a képet, ha a prezentációnak önállóan kell működnie.

**Szerkeszthető-e egy beszúrt SVG PowerPoint alakzatokként?**

Igen. Konvertálja az SVG‑t a [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addgroupshape/) segítségével; a kapott csoport szerkeszthető diaalakzatokat tartalmaz egy SVG‑kép helyett.

**Hogyan tarthatom kisebb méretűnek a sok képet tartalmazó prezentációkat?**

Használjon megosztott kép erőforrásokat újra, kerülje a szükségtelenül nagy raszteres forrásokat, tömörítse a megfelelő raszteres képeket, ha szükséges, tartsa a ismétlődő márkázást mastereken vagy elrendezéseken, és csak akkor használjon hivatkozott képeket, ha egy külső függőség elfogadható.