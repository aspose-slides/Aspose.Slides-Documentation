---
title: Hatékonyan egyesítse a prezentációkat .NET-ben
linktitle: Prezentációk egyesítése
type: docs
weight: 40
url: /hu/net/merge-presentation/
keywords:
- PowerPoint egyesítése
- prezentációk egyesítése
- diák egyesítése
- PPT egyesítése
- PPTX egyesítése
- ODP egyesítése
- PowerPoint kombinálása
- prezentációk kombinálása
- diák kombinálása
- PPT kombinálása
- PPTX kombinálása
- ODP kombinálása
- .NET
- C#
- Aspose.Slides
description: "Könnyedén egyesítheti a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkat az Aspose.Slides for .NET segítségével, egyszerűsítve a munkafolyamatát."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a prezentációk egyesítését úgy, hogy egy prezentációból származó diák másolatát egy másikba klónozza. Ez a cikk elmagyarázza, hogyan lehet összeolvasztani teljes prezentációkat vagy kiválasztott diákat, hogyan lehet használni egy dia-mestert vagy egy adott elrendezést az egyesítés során, hogyan kezelhetünk különböző dia-méretekkel rendelkező prezentációkat, és hogyan adhatunk összeolvasztott diákot egy prezentáció szekciójához. Emellett gyakorlati megjegyzéseket tartalmaz az egyesített tartalommal kapcsolatban, beleértve a beszélői jegyzeteket, megjegyzéseket, jelszóval védett forrásfájlokat és a szálhasználatot.

## **Optimalizálja a prezentációk egyesítését**

Az [Aspose.Slides for .NET](https://products.aspose.com/slides/hu/net/) segítségével zökkenőmentesen egyesítheti a PowerPoint‑prezentációkat, miközben megőrzi a stílusokat, elrendezéseket és minden elemet. Más eszközökkel ellentétben az Aspose.Slides a prezentációkat úgy keveri össze, hogy ne veszítsen a minőségből vagy az adatokból. Összeolvashat teljes prezentációkat, konkrét diákat, és még különböző fájlformátumokat is (PPT → PPTX, stb.).

### **Egyesítési funkciók**

- **Teljes prezentáció egyesítése:** Az összes dia egyetlen fájlba gyűjtése.  
- **Kiválasztott dia egyesítése:** Kiválasztott diák kombinálása.  
- **Keresztformátumú egyesítés:** Különböző formátumú prezentációk integrálása az integritás megőrzésével.  

{{% alert title="Tip" color="info" %}}  
Gyors, **ingyenes online eszközt** keres a **PowerPoint‑prezentációk egyesítéséhez**? Próbálja ki a [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/hu/merger) szolgáltatást.  

- **PowerPoint fájlok egyszerű egyesítése**: Több **PPT, PPTX, ODP** prezentáció egyetlen fájlba kombinálása.  
- **Különböző formátumok támogatása**: **PPT → PPTX**, **PPTX → ODP**, és több.  
- **Nincs telepítés szükséges**: Közvetlenül böngészőjében működik, gyors és biztonságos.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/hu/merger)  

Kezdje el a PowerPoint fájlok egyesítését a **Aspose ingyenes online eszközzel** még ma!  
{{% /alert %}}

## **Prezentációk egyesítése**

Amikor [egy prezentációt egy másikba egyesít](https://products.aspose.com/slides/hu/net/merger/ppt/), lényegében a diáikat egyetlen prezentációba kombinálja, hogy egy fájlt kapjon.  

{{% alert title="Info" color="info" %}}  
A legtöbb prezentációs program (PowerPoint vagy OpenOffice) nem rendelkezik olyan funkcióval, amely lehetővé tenné a prezentációk ilyen módon történő egyesítését.  

A [**Aspose.Slides for .NET**](https://products.aspose.com/slides/hu/net/) azonban különböző módokon teszi lehetővé a prezentációk egyesítését. A prezentációkat minden alakzatukkal, stílusukkal, szövegükkel, formázásukkal, megjegyzéseikkel, animációikkal stb. egyesítheti anélkül, hogy a minőség vagy az adatok elvesznének.  

**Lásd még**  

[Clone Slides](https://docs.aspose.com/slides/hu/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  
{{% /alert %}}

### **Mi egyesíthető**

Az Aspose.Slides segítségével egyesíthet  

* teljes prezentációkat. Az összes dia egy prezentációba kerül  
* konkrét diákat. A kiválasztott diák egy prezentációba kerülnek  
* prezentációkat egy formátumban (PPT → PPT, PPTX → PPTX stb.) és különböző formátumokban (PPT → PPTX, PPTX → ODP stb.) egymásba.  

{{% alert title="Note" color="warning" %}}  
Az prezentációkon felül az Aspose.Slides lehetővé teszi más fájlok egyesítését is:  

* [Images](https://products.aspose.com/slides/hu/net/merger/image-to-image/), például [JPG to JPG](https://products.aspose.com/slides/hu/net/merger/jpg-to-jpg/) vagy [PNG to PNG](https://products.aspose.com/slides/hu/net/merger/png-to-png/)  
* Dokuments, például [PDF to PDF](https://products.aspose.com/slides/hu/net/merger/pdf-to-pdf/) vagy [HTML to HTML](https://products.aspose.com/slides/hu/net/merger/html-to-html/)  
* És két különböző fájl, például [image to PDF](https://products.aspose.com/slides/hu/net/merger/image-to-pdf/) vagy [JPG to PDF](https://products.aspose.com/slides/hu/net/merger/jpg-to-pdf/) vagy [TIFF to PDF](https://products.aspose.com/slides/hu/net/merger/tiff-to-pdf/).  
{{% /alert %}}

### **Egyesítési beállítások**

Alkalmazhat olyan beállításokat, amelyek meghatározzák, hogy  

* a kimeneti prezentáció minden diája egyedi stílust megtart-e  
* egy adott stílus legyen-e alkalmazva az összes kimeneti diához.  

Az prezentációk egyesítéséhez az Aspose.Slides a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone) metódusokat (az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) interfészből) biztosítja. Többféle `AddClone` metódus megvalósítás létezik, amelyek meghatározzák az egyesítési folyamat paramétereit. Minden Presentation objektumnak van egy [Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/properties/slides) gyűjteménye, így a kívánt prezentációból hívhatja a `AddClone` metódust a diák egyesítéséhez.  

Az `AddClone` metódus egy `ISlide` objektumot ad vissza, amely a forrásdia klónja. A kimeneti prezentáció diái egyszerűen a forrásdiák másolatai. Ennek következtében módosíthatja a létrejött diákot (például stílusok, formázási beállítások vagy elrendezések alkalmazása) anélkül, hogy aggódna a forrásprezentációk hatással való módosulása miatt.  

## **Prezentációk egyesítése**

Aspose.Slides a [**AddClone (ISlide)**](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone) metódust biztosítja, amely lehetővé teszi a diák kombinálását úgy, hogy a diák megtartják elrendezésüket és stílusukat (alapértelmezett paraméterek).  

Ez a C# kód bemutatja, hogyan lehet prezentációkat egyesíteni:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Prezentációk egyesítése dia-mesterrel**

Aspose.Slides a [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/hu/net/aspose.slides.islidecollection/addclone/methods/2) metódust biztosítja, amely lehetővé teszi a diák egyesítését, miközben egy dia-mester prezentációs sablont alkalmaz. Így szükség esetén megváltoztathatja a kimeneti prezentáció diáinak stílusát.  

Ez a C# kód mutatja be a leírt műveletet:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}}  
A dia-mester elrendezése automatikusan kerül meghatározásra. Ha nem található megfelelő elrendezés, és az `allowCloneMissingLayout` boolean paraméter a `AddClone` metódusban igazra van állítva, a forrásdia elrendezése lesz használva. Ellenkező esetben a [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception) kerül dobásra.  
{{% /alert %}}

Ha azt szeretné, hogy a kimeneti prezentáció diái más diaelrendezést kapjanak, használja a [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/net/aspose.slides.islidecollection/addclone/methods/1) metódust egyesítéskor.  

## **Specifikus diák egyesítése prezentációkból**

Konkrét diák több prezentációból történő egyesítése hasznos egyedi diákkészletek létrehozásához. Az Aspose.Slides for .NET lehetővé teszi, hogy kiválassza és importálja csak a szükséges diákat. Az API megőrzi az eredeti diák formázását, elrendezését és tervezését.  

A következő C# kód egy új prezentációt hoz létre, hozzáadja a cím diákat két másik prezentációból, és elmenti az eredményt egy fájlba:  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}

static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```
```cs
using Aspose.Slides;

static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```

## **Prezentációk egyesítése diaelrendezéssel**

Ez a C# kód bemutatja, hogyan lehet a prezentációk diáját egyesíteni, miközben a kívánt diaelrendezést alkalmazza rájuk, hogy egy kimeneti prezentációt kapjon:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Prezentációk egyesítése különböző dia méretekkel**

{{% alert title="Note" color="warning" %}}  
A különböző dia méretekkel rendelkező prezentációk egyesítése nem okoz hibát, de az egyesített diák a célprezentáció dia méretét veszik fel, míg alakzataik megtartják eredeti pozíciójukat és méretüket, így a tartalom elhelyezkedhet hibásan vagy a dia határain kívül.  
{{% /alert %}}

A két különböző dia méretű prezentáció egyesítéséhez, a tartalom megfelelő elrendezésének megőrzéséhez, méretezze át az egyiket, hogy a mérete megegyezzen a másikéval.  

Ez a minta kód demonstrálja a leírt műveletet:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Diák egyesítése egy prezentáció szekciójába**

Ez a C# kód bemutatja, hogyan lehet egy adott diát egy szekcióba egyesíteni a prezentációban:  

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

A dia a szekció végén kerül hozzáadásra.  

{{% alert title="Tip" color="info" %}}  
Az Aspose egy [INGYENES Collage webalkalmazást](https://products.aspose.app/slides/hu/collage) biztosít. Ezzel az online szolgáltatással [JPG → JPG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG → PNG képeket egyesíthet, [fotohálókat](https://products.aspose.app/slides/hu/collage/photo-grid) hozhat létre, stb.  
{{% /alert %}}

## **GYIK**

### Megmaradnak a beszélői jegyzetek az egyesítés során?

Igen. A diák klónozásakor az Aspose.Slides átviszi az összes diaelemet, beleértve a jegyzeteket, a formázást és az animációkat.

### Átkerülnek a megjegyzések és szerzőik?

A megjegyzések, mint a dia tartalmának része, a diával együtt másolódnak. A megjegyzés szerzőjének címkéi megmaradnak a létrejött prezentáció megjegyzésobjektumaiban.

### Mi van, ha a forrásprezentáció jelszóval van védve?

Azt [a jelszóval kell megnyitni](/slides/hu/net/password-protected-presentation/) a [LoadOptions.Password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) segítségével; a betöltés után a diák biztonságosan klónozhatók egy védtelen célfájlba (vagy egy védett fájlba is).

### Mennyire szálbiztos az egyesítési művelet?

Ne használja ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt [több szálból](/slides/hu/net/multithreading/). Az ajánlott szabály: „egy dokumentum – egy szál”; különböző fájlok párhuzamosan feldolgozhatók külön szálakon.