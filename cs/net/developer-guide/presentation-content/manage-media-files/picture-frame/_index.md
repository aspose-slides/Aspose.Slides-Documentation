---
title: Správa rámečků obrázků v prezentacích v .NET
linktitle: Rámeček obrázku
type: docs
weight: 10
url: /cs/net/picture-frame/
keywords:
- rámeček obrázku
- přidat rámeček obrázku
- vytvořit rámeček obrázku
- vložený obrázek
- propojený obrázek
- extrahovat obrázek
- rastrový obrázek
- SVG obrázek
- oříznout obrázek
- smazat ořezané oblasti
- komprimovat obrázek
- StretchOffset
- formátování rámečku obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: Vytvářejte, formátujte, propojujte, ořezávejte, extrahujte a komprimujte rámečky obrázků v prezentacích pomocí Aspose.Slides pro .NET.
---
## **Přehled**

Rámeček obrázku je tvar snímku, který zobrazuje obrázek. V Aspose.Slides jsou zdroj obrázku a tvar, který jej zobrazuje, samostatné objekty: [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) vlastní vložené zdroje obrázků prostřednictvím své kolekce [Images](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/images/), zatímco [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) řídí polohu obrázku, velikost, formátování čáry, rotaci, ořez, efekty obrázku a další nastavení na úrovni rámce.

Toto oddělení je užitečné, když je stejný obrázek zobrazen vícekrát. Přidejte obrázek do prezentace jednou, uchovejte vrácený [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/), a použijte tento zdroj obrázku při vytváření rámečků obrázku.

Rámečky obrázku mohou obsahovat rastrové obrázky jako PNG nebo JPEG a vektorové SVG obrázky. Mohou také odkazovat na propojené obrázky místo ukládání bajtů obrázku do prezentace. Volba ovlivňuje přenositelnost, velikost souboru, extrakci a chování při exportu, takže je vhodné rozhodnout, jak bude obrázek uložen, ještě před aplikací formátování nebo optimalizace.

## **Přidání a formátování vloženého obrázku**

U vloženého obrázku přidejte data obrázku do prezentace a vytvořte rámeček obrázku pomocí [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addpictureframe/). Obrázek se tak stane součástí balíčku prezentace, takže prezentace zůstane samostatná při přesunu na jiný počítač.

Následující příklad přidá JPEG obrázek, vytvoří rámec s původními rozměry obrázku a aplikuje formátování čáry a rotaci:

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

Rámeček obrázku řídí zobrazovanou geometrii; změna velikosti rámce nemění původní pixelové rozměry uložené ve vloženém zdroji obrázku. Toto rozlišení je důležité při pozdějším ořezávání nebo kompresi obrázku.

## **Použití relativního měřítka**

[IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) poskytuje relativní měřítko šířky a výšky pro rámec. Hodnota `1.0` odpovídá 100 % původní velikosti obrázku. Relativní měřítko je užitečné, když workflow potřebuje zachovat vztah k velikosti zdrojového obrázku místo ručního výpočtu konečných rozměrů.

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

Relativní měřítko mění nastavení měřítka rámce; nepřevzorkovává ani nekonprimuje vložený obrázek.

## **Vložené a propojené obrázky**

Vložený obrázek ukládá data obrázku uvnitř prezentace a je proto nejbezpečnější volbou pro přenositelnost a předvídatelné vykreslování. Propojený obrázek ukládá externí umístění pomocí cesty odkazu [ISlidesPicture](https://reference.aspose.com/slides/cs/net/aspose.slides/islidespicture/) místo vložení dat obrázku stejným způsobem.

Propojené obrázky mohou snížit množství dat obrázku uložených v PPTX, ale zavádějí externí závislost. Propojený soubor musí zůstat přístupný aplikaci, která prezentaci otevírá nebo vykresluje. Pokud se cesta změní, soubor se přesune nebo zdroj nebude dostupný, může se propojený obrázek nezobrazit podle očekávání. Pro prezentace, které je třeba posílat e‑mailem, archivovat nebo vykreslovat v izolovaných prostředích, jsou vložené obrázky obvykle spolehlivější.

### **Přidání propojeného obrázku**

Následující příklad vytvoří rámeček obrázku a nasměruje jej na lokální soubor obrázku. Zabývá se pouze odkazováním na obrázek; odkazování na video je samostatný mediální workflow a není v tomto příkladu zamícháno.

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

Používejte odkazy, když je externí správa souborů úmyslná. Nepoužívejte je jen jako náhradu komprese: malý PPTX s poškozenými závislostmi na obrázcích je obvykle méně užitečný než větší samostatná prezentace.

## **Extrahování obrázků z rámečků obrázku**

Než extrahujete obrázek z existující prezentace, ověřte, že tvar je skutečně [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) a že obsahuje vložený obrázek. Propojené rámečky obrázku nemusí obsahovat bajty obrázku, které lze extrahovat stejným způsobem.

### **Extrahování rastrového obrázku**

Moderní API pro obrázky používá přímo [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) a nevyžaduje starší obal systémového obrázku. Následující příklad najde první vložený rastrový obrázek na snímku a uloží jej jako PNG:

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

Ukládání přes [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) převádí extrahovaný obrázek do požadovaného výstupního formátu. Pokud potřebujete kódované bajty uložené v prezentaci místo konvertovaného rastrového souboru, použijte binární data zdroje obrázku.

### **Extrahování SVG obrázku**

Pro SVG obrázek [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/). To vám umožní získat SVG data přímo místo rasterizace obrázku nejprve.

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

Uchování SVG obsahu jako SVG zachovává vektorový zdroj uvnitř prezentace. Rasterové exporty jako PNG nebo JPEG nutně vykreslují tento vektorový obsah do pixelů. Export snímku do PDF nebo SVG je také operace vykreslování, takže exportovaná grafika by neměla být považována za 1 : 1 kopii původního vloženého SVG; použijte vložená data [ISvgImage] při požadavku na samotný vektorový zdroj.

## **Oříznutí obrázku**

Ořez mění, která část obrázku je viditelná uvnitř rámce. Hodnoty ořezu na [IPictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/) jsou procenta rozměrů zdrojového obrázku. Ořezování zpočátku nesmaže skryté pixely ze vloženého obrázku; pouze mění viditelnou oblast.

Následující příklad bezpečně najde rámeček obrázku a aplikuje hodnoty ořezu:

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

Protože skrytá data obrázku jsou stále přítomna, lze ořez později změnit bez ztráty původních pixelů. Pokud je velikost souboru důležitější než možnost zpětného ořezu, lze ořezané oblasti fyzicky odstranit, jak je popsáno v následující sekci.

## **Odstranění ořezaných dat obrázku**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) odstraňuje data obrázku mimo aktuální ořezový obdélník a vrací vzniklý zdroj obrázku. To může snížit velikost souboru, ale jedná se o destruktivní optimalizaci: po uložení prezentace nejsou odstraněné pixely již k dispozici pro pozdější operaci „uncrop“.

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

Metoda může do prezentace přidat nový zdroj obrázku. Pokud je původní obrázek používán i v dalších rámečcích, tyto rámečky stále potřebují svůj existující zdroj, takže smazání ořezaných oblastí nemusí nutně snížit celkový počet obrázků. Ořez WMF nebo EMF obsahu touto metodou rasterizuje ořezaný výsledek do PNG.

## **Kompresní rastrových obrázků**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/compressimage/) snižuje rozlišení rastrového obrázku relativně k velikosti, ve které je obrázek zobrazován. Stejně tak může v rámci stejné operace odstranit ořezané oblasti. Metoda vrací `true`, když byl obrázek změněn velikostí nebo oříznut, a `false`, když nebyla nutná žádná změna.

Použijte předdefinovanou hodnotu [PicturesCompression](https://reference.aspose.com/slides/cs/net/aspose.slides.export/picturescompression/), když stačí standardní cílové rozlišení:

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

Místo hodnoty výčtu můžete předat vlastní kladnou hodnotu DPI, pokud je požadován konkrétní cíl.

Kompresi je určena pro rastrové obrázky. SVG a obsah metafile se touto rasterovou kompresí nesnižují. Také pamatujte, že nižší rozlišení a smazané ořezané oblasti nelze z optimalizované prezentace obnovit. Vyberte cílové rozlišení podle největší velikosti, při které bude obrázek skutečně zobrazován nebo exportován, místo globálního nastavení nejnižšího DPI.

## **Správa transformačních efektů obrázku**

Pro kompletní workflow zahrnující jas, kontrast, barevné transformace, rozostření, alfa efekty, řazené řetězce, inspekci, odstranění a ověření round‑trip viz [Image Transform Effects](/slides/cs/net/image-transform-effects/).

## **Uzamčení geometrie rámečku obrázku**

Nastavení [IPictureFrameLock](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframelock/) řídí, které operace úprav jsou pro rámeček obrázku zakázány. Například zamykání poměru stran zachovává proporce tvaru během změny velikosti.

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

Uzamčení se vztahuje na tvar rámečku obrázku. Neznamená to, že by zdrojový obrázek byl převezen nebo trvale změněn na stejný poměr stran.

## **Úprava hodnot StretchOffset**

Když je režim výplně obrázku „stretch“, hodnoty stretch‑offset na [IPictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/) definují výplňový obdélník relativně k ohraničujícímu rámečku obrázku. Kladná procenta vytvářejí vnitřní odsazení od okraje, záporná procenta vytvářejí vnější posun.

To se liší od ořezu. Hodnoty ořezu určují, která část zdrojového obrázku je viditelná; offsety roztažení mění obdélník, do kterého je viditelná výplň obrázku natažena.

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

Používejte offsety roztažení pro umístění výplně. Používejte vlastnosti ořezu, když chcete skrýt okraje zdrojového obrázku.

## **Úvahy o úložišti, velikosti souboru a exportu**

Hlavní kompromisy je snazší řídit, když jsou úložiště obrázků a formátování rámečků oddělené:

- **Vložené obrázky** dělají prezentaci samostatnou a jsou nejspolehlivější pro sdílení a server‑side vykreslování, ale velké rastrové obrázky zvyšují velikost PPTX a spotřebu paměti.
- **Propojené obrázky** mohou udržet balíček menší, ale prezentace závisí na dostupnosti externích souborů na uložených cestách nebo umístěních.
- **Ořez** je zpočátku nedestruktivní. Skryté pixely zůstávají vložené, dokud nejsou ořezané oblasti explicitně smazány nebo odstraněny během komprese.
- **Kompresi** může podstatně snížit velikost souboru u příliš velkých rastrových obrázků, ale snižuje rozlišení zdroje. Měla by být použita po určení zamýšlené velikosti na snímku.
- **SVG obrázky** by měly zůstat jako SVG, když je důležitá zachování vektoru. Vytáhněte vložené SVG přímo, pokud potřebujete samotný vektorový zdroj. Rasterové exporty snímků vždy převádějí vykreslený snímek na pixely.
- **Opakované obrázky** by měly opětovně používat existující zdroj [IPPImage], pokud je to možné, místo opakovaného načítání stejného souboru do workflow prezentace.

U velkých prezentací je optimalizace obrázků obvykle nejúčinnější, když je prováděna selektivně: udržujte loga a diagramy jako vektorový obsah, komprimujte fotografie podle jejich skutečné zobrazovací velikosti, odstraňujte ořezané pixely jen pokud není potřeba další úpravy, a vyhýbejte se externím odkazům, pokud není správa závislostí součástí návrhu nasazení.

## **Často kladené otázky**

**Jaký je rozdíl mezi rámečkem obrázku a zdrojem obrázku?**

[IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) představuje zdroj obrázku přidružený k prezentaci. [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) je tvar na snímku, který zobrazí obrázek a ukládá geometrii a formátování na úrovni rámce, jako jsou velikost, rotace, hodnoty ořezu, efekty a zamykání.

**Mám obrázky vkládat nebo propojovat?**

Vkládejte obrázky, když musí být prezentace přenosná, archivovatelná nebo vykreslena bez přístupu k externím zdrojům. Propojujte obrázky pouze tehdy, když je úmyslné mít soubory obrázků mimo PPTX a lze spolehlivě udržovat externí umístění.

**Snižuje ořez velikost souboru PPTX?**

Ne samostatně. Normální nastavení ořezu skrývá části zdrojového obrázku, ale zachovává podkladové pixely. Použijte [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) nebo kompresi obrázku s odstraněním ořezaných oblastí, když lze tyto pixely trvale odstranit.

**Lze po kompresi obnovit kvalitu obrázku?**

Ne. Komprese může snížit uložené rastrové rozlišení a odstranění ořezaných oblastí zahazuje data obrázku. Uchovejte původní zdrojový obrázek mimo prezentaci, pokud může být v budoucnu potřeba úprava ve vysokém rozlišení.

**Jak zacházet s SVG obrázky?**

Uchovávejte SVG obsah jako SVG, když je důležitá věrnost vektoru. Vložený [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/) lze extrahovat přímo. Vykreslení snímku do rastrového formátu jako PNG nebo JPEG rasterizuje SVG jako součást obrázku snímku.

**Jak předejít nebezpečným přetypováním při čtení existujících snímků?**

Před použitím členů specifických pro rámeček obrázku zkontrolujte typ tvaru. Vzorové porovnání s [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) nebo filtrování kolekce tvarů podle tohoto rozhraní zabraňuje neplatným přetypováním a umožňuje kódu zpracovat snímky, které neobsahují rámečky obrázku.