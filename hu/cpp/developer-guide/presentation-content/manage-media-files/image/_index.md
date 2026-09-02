---
title: Képek kezelésének optimalizálása prezentációkban C++ használatával
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/cpp/image/
keywords:
- kép hozzáadása
- kép beillesztése
- kép cseréje
- képgyűjtemény
- képkeret
- hivatkozott kép
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- SVG alakzatokká
- külső SVG erőforrások
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan adjon hozzá, használjon újra, hivatkozzon, cseréljen és kezeljen raszteres és SVG képeket PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ segítségével."
---
## **Bevezetés**

Aspose.Slides for C++ különböző módokat biztosít a képekkel való munkához, és mindegyik más célra szolgál. Képet tárolhat egy prezentációban, megjelenítheti egy képkeretben, használhatja diak háttérként, hivatkozhat külső képre, cserélhet meg egy megosztott kép erőforrást, vagy SVG tartalmat alakíthat át szerkeszthető alakzatokká.

Ez a cikk a kép erőforrásokra és azok prezentáción belüli használatára összpontosít. A képkivágás, átlátszóság, effektusok, nyújtás és egyéb egyedi képkeretre vonatkozó formázások tekintetében lásd a [Képkeret](/slides/hu/cpp/picture-frame/).

## **A képmodell megértése**

- A [presentation image collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimagecollection/) tárolja a prezentáció által használt kép erőforrásokat. Használja az [IImageCollection::AddImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimagecollection/addimage/) metódust a képadatok hozzáadásához és egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) erőforrás lekéréséhez.
- A [picture frame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipictureframe/) egy alakzat, amely képet jelenít meg egy dián, elrendezésen vagy mesteroldalon. Használja az [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addpictureframe/) metódust egy kép erőforrás diára helyezéséhez.
- A diák háttér képet használ a dia kitöltésének részeként, nem alakzatként, ezért nem viselkedik úgy, mint egy képkeret.
- Az [IPPImage::ReplaceImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/replaceimage/) lecserél egy kép erőforrást. Ha több prezentációs elem használja azt, mindegyik a cserét fogja használni.
- Az SVG alakzatokká konvertálása szerkeszthető diaalakzatokat hoz létre. Konvertálás után a tartalom már nem egyetlen kép erőforrásként van kezelve.

A tipikus munkafolyamat tehát: képadatokat hozzáadni a képgyűjteményhez, kapni egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/), majd ezt az erőforrást használni egy vagy több képkeretben vagy kitöltésben.

## **Beágyazott kép hozzáadása**

Helyi kép beszúrásához olvassa be a fájlt, adja hozzá adatait a képgyűjteményhez, majd hozzon létre egy képkeretet, amely a visszaadott [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) erőforrást használja.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ezzel a módon hozzáadott kép beágyazódik a prezentációba, így a kapott fájl nem függ a eredeti képfájl elérhetőségétől.

### **Kép hozzáadása a webből**

Ha egy kép HTTP vagy HTTPS protokollon keresztül érhető el, töltsük le a bájtokat, adjuk hozzá őket a prezentáció képgyűjteményéhez, és a visszaadott kép erőforrást ugyanúgy használjuk, mint a helyi képet.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Érvényesítse a távoli URL-eket, a válasz méretét és a tartalomtípusokat, ha a forrás nem megbízható. Olyan alkalmazásokban, ahol már más HTTP kliens van használatban, letöltheti a képet ezzel a klienssel, majd a kapott bájtokat vagy áramlást átadhatja az [IImageCollection::AddImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimagecollection/addimage/) metódusnak.

## **Képek újrafelhasználása diák között**

Ha ugyanaz a kép többször is szükséges, adja hozzá egyszer a prezentációhoz, és a visszaadott [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) használatával hozza létre a további képkereteket. Ez megakadályozza az azonos forrásadatok többszöri betöltését, és egyértelművé teszi a megosztott kép erőforrás és felhasználásai közötti kapcsolatot.

Az olyan grafikákhoz, amelyeknek automatikusan meg kell jelenniük sok dián – például egy céglogó – fontolja meg a képkeret elhelyezését egy [slide master](/slides/hu/cpp/slide-master/) vagy elrendezésre, ahelyett, hogy minden dián egy ekvivalens alakzatot adna hozzá.

## **Kép használata diak háttérként**

A háttérkép a dia kitöltéséhez van hozzárendelve; nem kerül hozzáadásra képkeret alakzatként. Ez akkor hasznos, ha a képnek a dia hátterét kell lefednie, és nem szabad normál diaobjektumként manipulálni.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

További háttérbeállításokért, beleértve a mester- és elrendezés háttérképeket, lásd a [Presentation Background](/slides/hu/cpp/presentation-background/) oldalt.

## **Beágyazott és hivatkozott képek**

A beágyazott és a hivatkozott képek eltérő hordozhatósági és fájlméret‑kompromisszumokkal rendelkeznek:

- **Beágyazott kép:** a képadatai a prezentáción belül tárolódnak. A prezentáció önálló, de a fájlméret magában foglalja a kép adatokat.
- **Hivatkozott kép:** a prezentáció egy útvonalat vagy URL-t tárol egy külső képhez. Ez csökkentheti a prezentáció méretét, de a külső erőforrásnak elérhetőnek kell maradnia a prezentáció megnyitásakor vagy rendereléskor.

Egy hivatkozott képet úgy hozhat létre, hogy a külső útvonalat vagy URL-t az [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/set_linkpathlong/) segítségével állítja be, ahelyett, hogy a képadatokat beágyazná.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Csak akkor használjon hivatkozott képeket, ha a telepítési környezet megbízhatóan hozzáfér a külső erőforráshoz. Az offline vagy rendszerek között mozgatandó prezentációk esetében a beágyazott képek általában biztonságosabbak.

## **Munkavégzés SVG képekkel**

Az SVG egy vektorfájlformátum, ezért hasznos lehet ikonok, diagramok és egyéb grafikák esetén, amelyeknek méretezéskor nem kell elveszíteniük a részleteket, mint a raszteres képek. Az Aspose.Slides támogatja az SVG‑t mind kép erőforrásként, mind szerkeszthető diaalakzatok forrásaként.

### **SVG hozzáadása képként**

Hozzon létre egy [SvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/svgimage/), adja hozzá a képgyűjteményhez, és helyezze el a kapott kép erőforrást egy képkeretben.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Külső erőforrásokkal rendelkező SVG fájlok**

Egy SVG hivatkozhat külső képekre, stíluslapokra vagy betűkészletekre. Ilyen esetekben a [SvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/svgimage/) konstruktorai elfogadnak egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/iexternalresourceresolver/) példányt és egy alap‑URI‑t. A feloldó képes egy relatív URI‑t egy engedélyezett abszolút URI‑ra leképezni, és egy áramlást visszaadni a kért erőforráshoz.

A feloldó lehetővé teszi a külső erőforrások használatát az SVG feldolgozása közben, de nem alakítja át az SVG‑t önálló dokumentummá. Ha az SVG‑nek hordozhatónak kell maradnia, ágyazza be a szükséges erőforrásokat magába, például a `data:` URI‑k használatával a hivatkozott képekhez.

Ha az SVG‑k megbízhatatlan forrásból származnak, korlátozza a feloldó által elérhető séma‑, fájl‑ és host‑címeket. A hálózati feloldóknál alkalmazzon időkorlátokat, válaszméret‑korlátokat és tartalom‑validálást.

### **SVG konvertálása szerkeszthető alakzatokká**

Az Aspose.Slides képes egy SVG‑t szerkeszthető diaalakzatok csoportjává konvertálni, hasonlóan a megfelelő PowerPoint parancshoz.

![PowerPoint Popup Menu](img_01_01.png)

Használja az [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addgroupshape/) olyan túlterhelését, amely egy [ISvgImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isvgimage/) objektumot fogad a konvertáláshoz.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Használja az SVG‑alkotalak‑alakzatra konvertálást, ha az egyes vektor elemeket PowerPoint alakzatként kell szerkeszteni. Ha az SVG‑t csak megjeleníteni kell, az egyszerűbb, ha képként tartja, így elkerülve számos különálló alakzat létrehozását.

## **Meglévő kép erőforrás cseréje**

Használja az [IPPImage::ReplaceImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/replaceimage/) metódust, ha egy meglévő kép erőforrást szeretne lecserélni. Ez különösen hasznos megosztott grafikák, például logók esetén.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ha több képkeret, háttér, mester vagy elrendezés használja ugyanazt a kép erőforrást, annak cseréje minden ilyen felhasználást frissít. Ha csak egy képkeretet szeretne módosítani, adjon neki egy másik képet a megosztott erőforrás helyett.

Az [IPPImage::ReplaceImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/replaceimage/) további túlterhelései egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) vagy egy másik [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) paramétereket is elfogadnak.

## **Gyakorlati képkezelési útmutató**

### **A prezentáció méretének szabályozása**

Nagy raszteres képek a prezentációt indokolatlanul nagy méretűvé tehetik. Használjon olyan forrásképeket, amelyek dimenziói megfelelnek a tervezett megjelenítési méretnek, ahol csak lehetséges, újrahasználjon megosztott kép erőforrásokat, és kerülje azonos teljes felbontású grafika többszöri beágyazását.

Raszeres képek esetén, amelyeket már elhelyeztek képkeretekben, az [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipicturefillformat/compressimage/) csökkentheti a kép adatokat a kiválasztott felbontás és vágóbeállítások alapján. Ez képkeret‑szintű feldolgozás, nem a képgyűjtemény kezelése, ezért a kapcsolódó formázási műveletekért lásd a [Képkeret](/slides/hu/cpp/picture-frame/) oldalt.

### **Válasszon beágyazott és hivatkozott tartalom között**

A beágyazás önállóvá teszi a prezentációt, mert minden szükséges képadat a fájlban van. A hivatkozás csökkentheti a fájlméretet, de külső függőséget vezet be. Csak akkor használjon hivatkozásokat, ha ez a függőség elfogadható és stabil.

### **Megosztott márka újbóli használata**

Ismétlődő logók, vízjelekkel vagy díszítő grafikák esetén használjon egyetlen kép erőforrást és újrahasználja azt. Ha a grafika a prezentáció tervezéséhez, nem a dia tartalmához tartozik, helyezze el egy mester vagy elrendezés rétegben, hogy a megfelelő diák örökölhessék.

### **SVG erőforrások hordozhatóságának megőrzése**

Az önálló SVG könnyebben mozgatható és konzisztensen renderelhető, mint egy olyan SVG, amely külső fájlokra vagy hálózati erőforrásokra támaszkodik. Amennyiben lehetséges, ágyazza be a szükséges erőforrásokat még az SVG importálása előtt. Az SVG‑t csak akkor konvertálja alakzatokká, ha az egyes vektor elemeket szerkeszteni kell.

### **Használja az Aspose.Slides kép API‑t**

C++ képfolyamatokhoz használja az Aspose.Slides [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) és [Images](https://reference.aspose.com/slides/hu/cpp/aspose.slides/images/) API‑kat, ha képobjektumra van szüksége, és az [IImageCollection::AddImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimagecollection/addimage/) metódust, ha képadatokat kell regisztrálni prezentációs erőforrásként. A gyűjtemény túlterhelései bájt‑tömböket és áramlásokat is támogatnak, ami hasznos, ha a kép adatokat fájlokból, hálózati kliensektől, adatbázisokból vagy más könyvtárakból kapja.

EMF tartalom generálása táblázatokból vagy más termékekből külön integrációs munkafolyamat, és nem része ennek a cikknek. Ha egy meglévő WMF vagy EMF fájlt csak be kell szúrni egy prezentációba, adja át az adatokat egy megfelelő [IImageCollection::AddImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimagecollection/addimage/) túlterhelésnek anélkül, hogy a képkezelési munkafolyamatba második termékfüggőséget vezetne be.

## **GYIK**

**Mi a különbség a képgyűjtemény és a képkeret között?**

A képgyűjtemény újrahasználható kép erőforrásokat tárol. A képkeret egy dia alakzat, amely ezeket az erőforrásokat jeleníti meg, és képspecifikus formázást biztosít, például vágást és effektusokat.

**Mi a legjobb módja annak, hogy mindenhol ugyanazt a logót cserélje le?**

Ha a logó már egy közös kép erőforrásként van megosztva, cserélje azt az [IPPImage::ReplaceImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/replaceimage/) metódussal. Az egész prezentációra kiterjedő márka esetén a logó elhelyezése egy mester vagy elrendezés rétegbe szintén csökkentheti a duplikált dia tartalmat.

**Miért tűnik el egy hivatkozott kép egy másik számítógépen?**

Egy hivatkozott kép a külső fájlra vagy URL‑re támaszkodik. Ha az erőforrás nem érhető el a másik gépről, a hivatkozott kép hiányzó lesz. Ha a prezentációnak önállónak kell lennie, ágyazza be a képet.

**Lehet-e egy beszúrt SVG‑t PowerPoint alakzatként szerkeszteni?**

Igen. Konvertálja az SVG‑t az [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addgroupshape/) használatával; a létrejövő csoport szerkeszthető diaalakzatokat tartalmaz, nem egyetlen SVG képet.

**Hogyan tarthatom kisebbnek a sok képet tartalmazó prezentációkat?**

Használjon megosztott kép erőforrásokat, kerülje a szükségtelenül nagy raszteres források használatát, szükség esetén tömörítse a megfelelő raszteres képeket, helyezze el az ismétlődő márkát mesterek vagy elrendezésekre, és csak akkor használjon hivatkozott képeket, ha egy külső függőség elfogadható.