---
title: Správa obrázkových rámečků v prezentacích v .NET
linktitle: Obrázkový rámeček
type: docs
weight: 10
url: /cs/net/picture-frame/
keywords:
- obrázkový rámeček
- přidat obrázkový rámeček
- vytvořit obrázkový rámeček
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- ořezat obrázek
- smazat oříznuté oblasti
- komprimovat obrázek
- StretchOffset
- formátování obrázkového rámečku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte obrázkové rámečky v prezentacích pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Obrázkový rámeček je objekt snímku, který zobrazí obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své kolekce [Images](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/images/), zatímco [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) řídí pozici obrázku, velikost, formátování čáry, otočení, ořez, efekty obrázku a další nastavení na úrovni rámečku.

Toto oddělení je užitečné, když je stejný obrázek zobrazen vícekrát. Přidejte obrázek do prezentace jednou, udržujte vrácený [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/), a použijte tento zdroj obrázku při vytváření obrázkových rámečků.

Obrázkové rámečky mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo uložení bajtů obrázku v prezentaci. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování exportu, takže je užitečné rozhodnout, jak má být obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte obrázkový rámeček pomocí [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addpictureframe/). Obrázek se stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rámeček v nativních rozměrech obrázku a použije formátování čáry a otočení:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Obrázkový rámeček řídí zobrazovanou geometrii; změna velikosti rámečku nemění původní rozměry pixelů uložených ve vloženém zdroji obrázku. Tento rozdíl je důležitý při pozdějším ořezávání nebo kompresi obrázku.

## **Použití relativního měřítka**

[IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) poskytuje relativní měřítko šířky a výšky pro rámeček. Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když pracovní postup potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Relativní měřítko mění nastavení měřítka rámečku; neprovádí přeškálování ani kompresi vloženého obrázku.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění prostřednictvím cesty odkazu [ISlidesPicture](https://reference.aspose.com/slides/cs/net/aspose.slides/islidespicture/) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj není dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které musí být e‑mailem odeslány, archivovány nebo vykresleny v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří obrázkový rámeček a nasměruje jej na místní soubor obrázku. Zabývá se jen propojením obrázku; propojení videa je samostatný mediální pracovní postup a není v tomto příkladu úmyslně smícháno.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Používejte odkazy, když je externí správa souborů úmyslná. Nepoužívejte je jen jako náhradu za kompresi: malý PPTX s nefunkčními závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámečků**

Před extrahováním obrázku z existující prezentace ověřte, že tvar je skutečně [IPictureFrame] a že obsahuje vložený obrázek. Propojené rámečky obrázků nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API obrázku používá přímo [IImage] a nevyžaduje starší obal systému obrázků. Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Ukládání přes [IImage] převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci místo převedeného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek [IPPImage] poskytuje objekt [ISvgImage]. To vám umožní získat data SVG přímo místo rasterizace obrázku nejprve.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Uchování obsahu SVG jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně renderují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také renderovací operací, takže exportovaná grafika by neměla být považována za bit‑po‑bitovou kopii původního vloženého SVG; použijte vložená data [ISvgImage], když je vyžadován samotný vektorový zdroj.

## **Ořezání obrázku**

Ořezávání mění, která část obrázku je viditelná uvnitř rámečku. Hodnoty ořezu na [IPictureFillFormat] jsou procenta rozměrů zdrojového obrázku. Ořezování zpočátku nesmaže skryté pixely z vloženého obrázku; jen mění viditelnou oblast.

Následující příklad bezpečně najde obrázkový rámeček a použije hodnoty ořezu:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Protože skrytá data obrázku jsou stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než reverzibilita, lze oříznuté oblasti fyzicky odstranit, jak je popsáno v následující sekci.

## **Odstranění oříznutých dat obrázku**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací vzniklý zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely nadále k dispozici pro pozdější operaci odořezání.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek také používán jinými obrázkovými rámečky, tyto rámečky stále potřebují svůj existující zdroj, takže odstranění oříznutých oblastí nutně nesnižuje celkový počet obrázků. Ořezávání obsahu WMF nebo EMF touto metodou rasterizuje oříznutý výsledek do PNG.

## **Komprese rastrových obrázků**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/compressimage/) snižuje rozlišení rastrového obrázku vzhledem k velikosti, ve které je obrázek zobrazen. Může také v rámci stejné operace odstranit oříznuté oblasti. Metoda vrací `true`, když byl obrázek změněn velikosti nebo oříznut, a `false`, když nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/net/aspose.slides.export/picturescompression/), když je dostačující standardní cílové rozlišení:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Místo enum hodnoty lze předat vlastní kladnou hodnotu DPI, pokud je požadován konkrétní cíl.

Komprese je určena pro rastrové obrázky. SVG a obsah metafile nejsou tímto rasterovým kompresním pracovním postupem zmenšeny. Také si pamatujte, že nižší rozlišení a smazané oříznuté oblasti nelze z optimalizované prezentace obnovit. Vyberte cílové rozlišení na základě největší velikosti, při které bude obrázek skutečně prohlížen nebo exportován, místo aby se globálně aplikovalo nejnižší DPI.

## **Kontrola efektů obrázku**

Efekty obrázku jsou uloženy na obrázku použitém rámečkem. Kolekce transformací obrázku může obsahovat efekty jako pevná alfa modulace pro průhlednost a luminance pro jas a kontrast. Níže uvedený příklad bezpečně čte oba typy efektů z prvního obrázkového rámečku na snímku:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Tyto efekty mění, jak je obrázek vykreslen v rámečku; nepřepisují původní bajty vloženého obrázku.

## **Uzamčení geometrie obrázkového rámečku**

Nastavení [IPictureFrameLock] řídí, které operace úprav jsou pro obrázkový rámeček zakázány. Například uzamčení poměru stran zachovává proporce tvaru během změny velikosti.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Uzamčení se vztahuje na tvar obrázkového rámečku. Nenutí zdrojový obrázek, aby byl přeškálován nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku nastaven na roztažení, hodnoty stretch‑offset na [IPictureFillFormat] definují výplňový obdélník relativně k ohraničujícímu rámečku obrázku. Kladná procenta vytvoří vnitřní odsazení od hrany, záporná procenta vytvoří vnější výstupek.

To se liší od ořezávání. Hodnoty ořezu určují, která část zdrojového obrázku je viditelná; stretch offsety mění obdélník, do kterého je viditelná výplň obrázku roztažena.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Používejte stretch offsety pro umístění výplně. Používejte vlastnosti ořezu, když je cílem skrýt okraje zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy jsou snáze říditelné, když jsou úložiště obrázků a formátování rámečků řešeny odděleně:

- **Vložené obrázky** dělají prezentaci samostatnou a jsou nejspolehlivější pro sdílení a renderování na serveru, ale velké rastrové obrázky zvětšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou udržet balík menší, ale prezentace závisí na dostupnosti externích souborů na uložených cestách nebo místech.
- **Ořezávání** je zpočátku neškodné. Skryté pixely zůstávají vloženy, dokud nejsou oříznuté oblasti výslovně smazány nebo odstraněny během komprese.
- **Komprese** může výrazně snížit velikost souboru u příliš velkých rastrových obrázků, ale snižuje rozlišení zdroje. Měla by být použita po určení požadované velikosti na snímku.
- **SVG obrázky** by měly zůstat ve formátu SVG, pokud je důležité zachování vektorové podoby. Vložte vložený SVG přímo, když potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly při možnosti znovu použít existující zdroj [IPPImage] místo opakovaného načítání stejného souboru do pracovního postupu prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejužitečnější, když je prováděna selektivně: loga a diagramy ponechte jako vektorový obsah, fotografie komprimujte podle jejich skutečné zobrazovací velikosti, oříznuté pixely odstraňte jen pokud další úpravy nejsou vyžadovány, a vyhněte se externím odkazům, pokud správa závislostí není součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi obrázkovým rámečkem a zdrojem obrázku?**

[IPPImage] představuje zdroj obrázku spojený s prezentací. [IPictureFrame] je tvar na snímku, který zobrazí obrázek a ukládá geometrii a formátování na úrovni rámečku, jako jsou velikost, otočení, hodnoty ořezu, efekty a uzamčení.

**Mám obrázky vložit nebo propojit?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovaná nebo vykreslená bez přístupu k externím zdrojům. Propojujte obrázky jen když je úmyslné mít soubory obrázků mimo PPTX a externí umístění lze spolehlivě udržovat.

**Snižuje ořezávání velikost souboru PPTX?**

Ne samostatně. Normální nastavení ořezu skrývá části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [IPictureFillFormat.DeletePictureCroppedAreas] nebo kompresi obrázku s odstraněním oříznutých oblastí, když lze tyto pixely trvale odstranit.

**Mohu po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění oříznutých oblastí ztrácí data obrázku. Pokud může být později potřeba úprava v vysokém rozlišení, uchovejte originální zdrojový obrázek mimo prezentaci.

**Jak by se měly nakládat SVG obrázky?**

Uchovávejte obsah SVG jako SVG, když je důležitá vektorová věrnost. Vložený [ISvgImage] lze extrahovat přímo. Renderování snímku do rastrového formátu jako PNG nebo JPEG rasterizuje SVG jako součást obrázku snímku.

**Jak mohu zabránit nebezpečným převodům typů při čtení existujících snímků?**

Zkontrolujte typ tvaru před použitím členů specifických pro obrázkový rámeček. Porovnávání vzorů s [IPictureFrame] nebo filtrování kolekce tvarů podle tohoto rozhraní zabraňuje neplatným převodům a umožňuje kódu zpracovat snímky, které neobsahují obrázkové rámečky.