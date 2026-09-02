---
title: Optimalizace správy obrázků v prezentacích v .NET
linktitle: Správa obrázků
type: docs
weight: 10
url: /cs/net/image/
keywords:
- přidat obrázek
- přidat obrázek
- nahradit obrázek
- kolekce obrázků
- rámeček obrázku
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
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak přidávat, opakovaně používat, odkazovat, nahrazovat a spravovat rastrové a SVG obrázky v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET."
---
## **Úvod**

Aspose.Slides pro .NET poskytuje několik způsobů práce s obrázky a každý slouží jinému účelu. Můžete uložit obrázek v prezentaci, zobrazit jej v rámečku obrázku, použít jej jako pozadí snímku, odkazovat na externí obrázek, nahradit sdílený zdroj obrázku nebo převést obsah SVG na editovatelné tvary.

Tento článek se zaměřuje na zdroje obrázků a jak jsou používány v celé prezentaci. Pro ořez, průhlednost, efekty, natažení a další formátování aplikované na jednotlivý rámeček obrázku viz [Rámeček obrázku](/slides/cs/net/picture-frame/).

## **Pochopte model obrázku**

Následující koncepty API jsou úzce související, ale ne zaměnitelné:

- [kolekce obrázků prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/iimagecollection/) ukládá zdroje obrázků používané v prezentaci. Použijte [ImageCollection.AddImage](https://reference.aspose.com/slides/cs/net/aspose.slides/imagecollection/addimage/) k přidání dat obrázku a získání zdroje [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).
- [Rámeček obrázku](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) je tvar, který zobrazuje obrázek na snímku, rozvržení nebo hlavě. Použijte [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addpictureframe/) k umístění zdroje obrázku na snímek.
- Pozadí snímku používá obrázek jako část výplně snímku, nikoli jako tvar. Proto se nechová jako rámeček obrázku.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/replaceimage/) nahrazuje zdroj obrázku. Pokud jej používá několik prvků prezentace, všichni používají náhradu.
- Převedení SVG na tvary vytváří editovatelné tvary snímku. Po převodu není obsah nadále spravován jako jeden zdroj obrázku.

Typický postup tedy je: přidat data obrázku do kolekce obrázků, získat [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/), a poté použít tento zdroj v jednom nebo více rámečcích obrázku či výplních.

## **Přidání vloženého obrázku**

Chcete-li vložit lokální obrázek, načtěte soubor, přidejte jeho data do kolekce obrázků a vytvořte rámeček obrázku, který používá vrácený `IPPImage`.

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

Obrázek přidaný tímto způsobem je vložen v prezentaci, takže výsledný soubor nezávisí na dostupnosti původního souboru obrázku.

### **Přidání obrázku z webu**

Pokud je obrázek dostupný přes HTTP nebo HTTPS, stáhněte jeho bajty pomocí `HttpClient`, přidejte je do kolekce obrázků prezentace a použijte vrácený zdroj obrázku stejným způsobem jako lokální obrázek.

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

V dlouho běžících aplikacích opakovaně používejte `HttpClient` místo vytváření nové instance pro každý požadavek. Také ověřujte vzdálené URL, velikosti odpovědí a typy obsahu, pokud zdroj není důvěryhodný.

## **Opětovné použití obrázků napříč snímky**

Pokud je stejný obrázek potřeba vícekrát, přidejte jej do prezentace jednou a znovu použijte vrácený [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) při vytváření dalších rámečků obrázku. Tím se zabrání opakovanému načítání stejných zdrojových dat a vztah mezi sdíleným zdrojem obrázku a jeho použitím je explicitní.

Pro grafiku, která by se měla automaticky zobrazovat na mnoha snímcích, například firemní logo, zvažte umístění rámečku obrázku na [slide master](/slides/cs/net/slide-master/) nebo rozvržení místo přidávání ekvivalentního tvaru na každý snímek.

## **Použití obrázku jako pozadí snímku**

Obrázek na pozadí je přiřazen k výplni snímku; není přidán jako tvar rámečku obrázku. To je užitečné, když má obrázek pokrývat pozadí snímku a neměl by být manipulován jako běžný objekt snímku.

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

Pro další možnosti pozadí, včetně pozadí masteru a rozvržení, viz [Pozadí prezentace](/slides/cs/net/presentation-background/).

## **Vložené obrázky a odkazované obrázky**

Vložené a odkazované obrázky mají různé kompromisy v přenositelnosti a velikosti souboru:

- **Vložený obrázek:** data obrázku jsou uložena uvnitř prezentace. Prezentace je samostatná, ale velikost souboru zahrnuje data obrázku.
- **Odkazovaný obrázek:** prezentace ukládá cestu nebo URL k externímu obrázku. To může snížit velikost prezentace, ale externí zdroj musí být přístupný při otevírání nebo vykreslování prezentace.

Odkazovaný obrázek lze vytvořit přiřazením externí cesty nebo URL přes [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/cs/net/aspose.slides/islidespicture/linkpathlong/) místo vložení dat obrázku.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Používejte odkazované obrázky jen tehdy, když nasazovací prostředí může spolehlivě přistupovat k externímu zdroji. Pro prezentace, které musí fungovat offline nebo být přesouvány mezi systémy, jsou vložené obrázky obvykle bezpečnější.

## **Práce s SVG obrázky**

SVG je vektorový formát, takže může být užitečný pro ikony, diagramy a další grafiku, která by se měla škálovat bez ztráty detailu jako rastrové obrázky. Aspose.Slides podporuje SVG jak jako zdroj obrázku, tak jako zdroj pro editovatelné tvary snímku.

### **Přidání SVG jako obrázku**

Vytvořte [SvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/svgimage/), přidejte jej do kolekce obrázků a umístěte vzniklý zdroj obrázku do rámečku obrázku.

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

### **SVG soubory s externími zdroji**

SVG může odkazovat na externí obrázky, stylové listy nebo písma. Pro tyto případy [SvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/svgimage/) poskytuje konstruktory, které přijímají [IExternalResourceResolver](https://reference.aspose.com/slides/cs/net/aspose.slides.import/iexternalresourceresolver/) a základní URI. Rozlišovač může mapovat relativní URI na povolené absolutní URI a vrátit proud pro požadovaný zdroj.

Rozlišovač zpřístupňuje externí zdroje během zpracování SVG v Aspose.Slides, ale nepřepisuje SVG na samostatný dokument. Pokud musí SVG zůstat přenosný, vložte požadované zdroje přímo do SVG, například pomocí `data:` URI pro odkazované obrázky.

Když SVG soubory pocházejí z nedůvěryhodných zdrojů, omezte schémata, umístění souborů a hosty, ke kterým má rozlišovač přístup. Síťové rozlišovače by měly také uplatňovat časová omezení, limity velikosti odpovědi a validaci obsahu.

### **Převod SVG na editovatelné tvary**

Aspose.Slides může převést SVG na skupinu editovatelných tvarů snímku, podobně jako odpovídající příkaz v PowerPointu.

![PowerPoint Popup Menu](img_01_01.png)

Použijte přetížení [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addgroupshape/) , které přijímá [ISvgImage](https://reference.aspose.com/slides/cs/net/aspose.slides/isvgimage/) , k provedení převodu.

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

Použijte převod SVG na tvary, když je potřeba jednotlivé vektorové elementy upravovat jako tvary v PowerPointu. Pokud je SVG potřeba jen zobrazit, je jednodušší ponechat jej jako obrázek a vyhnout se vytváření mnoha samostatných tvarů.

## **Nahrazení existujícího zdroje obrázku**

Použijte [IPPImage.ReplaceImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/replaceimage/) , když chcete nahradit existující zdroj obrázku. To je zvláště užitečné pro sdílenou grafiku, jako jsou loga.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Pokud více rámečků obrázku, pozadí, masterů nebo rozvržení používá stejný zdroj obrázku, jeho nahrazení aktualizuje všechny tyto použití. Pokud má být změněn jen jeden rámeček obrázku, přiřaďte tomuto rámečku jiný obrázek místo nahrazení sdíleného zdroje.

`ReplaceImage` také poskytuje přetížení, která přijímají [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) nebo další [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) .

## **Praktické doporučení pro správu obrázků**

### **Kontrola velikosti prezentace**

Velké rastrové obrázky mohou způsobit, že je prezentace zbytečně velká. Používejte zdrojové obrázky s rozměry vhodnými pro zamýšlenou velikost zobrazení, opakovaně využívejte sdílené zdroje obrázků, kde je to možné, a vyhněte se vkládání opakovaných kopií stejné grafiky v plném rozlišení.

Pro rastrové obrázky, které již byly umístěny v rámečcích obrázku, může [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/compressimage/) snížit data obrázku podle vybrané rozlišení a nastavení ořezu. Jedná se o zpracování rámečku obrázku, nikoli správu kolekce obrázků, takže viz [Rámeček obrázku](/slides/cs/net/picture-frame/) pro související formátovací operace.

### **Volba mezi vloženým a odkazovaným obsahem**

Vkládání činí prezentaci přenosnou, protože všechna potřebná data obrázku jsou součástí souboru. Odkazování může snížit velikost souboru, ale zavádí externí závislost. Používejte odkazy jen tehdy, když je tato závislost přijatelna a stabilní.

### **Opakované použití sdílené značky**

Pro opakovaná loga, vodoznaky nebo dekorativní grafiku použijte jeden zdroj obrázku a opakujte jeho použití. Pokud grafika patří k návrhu prezentace spíše než k obsahu snímku, umístěte ji na master nebo rozvržení, aby ji zdědily příslušné snímky.

### **Udržujte SVG zdroje přenosné**

Samostatné SVG je snazší přesunout a renderovat konzistentně než SVG, které závisí na externích souborech nebo síťových zdrojích. Kdykoli je to možné, vložte požadované zdroje před importem SVG. Převádějte SVG na tvary jen tehdy, když je potřeba jednotlivé vektorové elementy upravovat.

### **Použití moderního multiplatformního API obrázků**

Pro nový .NET kód používejte Aspose.Slides [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/) a [Images](https://reference.aspose.com/slides/cs/net/aspose.slides/images/) API místo spoléhaní se na `System.Drawing.Image` nebo `Bitmap`. Viz [Moderní API](/slides/cs/net/modern-api/) pro postup migrace.

Formáty WMF a EMF vyžadují zvláštní úvahu. Když jsou tyto formáty předány přes [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/), [ImageCollection.AddImage](https://reference.aspose.com/slides/cs/net/aspose.slides/imagecollection/addimage/) převádí metafile na rastrovou PNG reprezentaci před vložením. Pokud je důležité zachovat data metafile, použijte místo toho přetížení [ImageCollection.AddImage](https://reference.aspose.com/slides/cs/net/aspose.slides/imagecollection/addimage/) založené na proudu. Vytváření EMF obsahu ze spreadsheetů nebo jiných produktů je samostatný integrační pracovní postup a není součástí tohoto článku.

## **Často kladené otázky**

**Jaký je rozdíl mezi kolekcí obrázků a rámečkem obrázku?**

Kolekce obrázků ukládá znovu použitelné zdroje obrázků. Rámeček obrázku je tvar na snímku, který zobrazuje jeden z těchto zdrojů a poskytuje specifické formátování obrázku, jako je ořez a efekty.

**Jaký je nejlepší způsob, jak všude nahradit stejné logo?**

Pokud je logo již sdíleno jako jeden zdroj obrázku, nahraďte tento zdroj pomocí [IPPImage.ReplaceImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/replaceimage/). Pro značku napříč celou prezentací může umístění loga na master nebo rozvržení také snížit duplicitní obsah snímků.

**Proč se odkazovaný obrázek na jiném počítači nezobrazí?**

Odkazovaný obrázek závisí na svém externím souboru nebo URL. Pokud není tento zdroj přístupný z jiného počítače, může být odkazovaný obrázek nedostupný. Vložte obrázek, pokud musí být prezentace samostatná.

**Lze vložené SVG upravit jako tvary PowerPointu?**

Ano. Převěďte SVG pomocí [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addgroupshape/); výsledná skupina obsahuje editovatelné tvary snímku namísto jednoho SVG obrázku.

**Jak mohu udržet prezentace s mnoha obrázky menší?**

Opakovaně používejte sdílené zdroje obrázků, vyhněte se zbytečně velkým rastrovým zdrojům, komprimujte vhodné rastrové obrázky, pokud je to vhodné, uchovávejte opakované značky na masterech nebo rozvrženích a používejte odkazované obrázky jen tehdy, když je externí závislost akceptovatelná.