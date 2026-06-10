---
title: Hatékonyan egyesítse az előadásokat .NET-ben
linktitle: Előadások egyesítése
type: docs
weight: 40
url: /hu/net/merge-presentation/
keywords:
- PowerPoint egyesítése
- előadások egyesítése
- diák egyesítése
- PPT egyesítése
- PPTX egyesítése
- ODP egyesítése
- PowerPoint összevonása
- előadások összevonása
- diák összevonása
- PPT összevonása
- PPTX összevonása
- ODP összevonása
- .NET
- C#
- Aspose.Slides
description: "Könnyedén egyesítheti a PowerPoint (PPT, PPTX) és OpenDocument (ODP) előadásokat az Aspose.Slides for .NET segítségével, egyszerűsítve a munkafolyamatát."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi előadások egyesítését úgy, hogy diák másolását egy előadásból egy másikba klónozza. Ez a cikk bemutatja, hogyan egyesíthet teljes előadásokat vagy kiválasztott diákat, hogyan használhat diamestert vagy egy adott elrendezést az egyesítés során, hogyan kezelhet különböző dia méretű előadásokat, és hogyan adhat egyesített diákat egy előadás szakaszához. Továbbá gyakorlati megjegyzéseket tartalmaz az egyesített tartalommal kapcsolatban, többek között előadói jegyzetek, megjegyzések, jelszóval védett forrásfájlok és szálhasználat tekintetében.

## **Optimalizálja az előadások egyesítését**

Az [Aspose.Slides for .NET](https://products.aspose.com/slides/hu/net/) segítségével zökkenőmentesen kombinálhatja a PowerPoint‑előadásokat, miközben megőrzi a stílusokat, elrendezéseket és az összes elemet. Más eszközökkel ellentétben az Aspose.Slides minőségromlás vagy adatvesztés nélkül egyesíti az előadásokat. Egyesítheti a teljes előadásokat, konkrét diákat és akár különböző fájlformátumokat (PPT → PPTX stb.).

### **Egyesítési funkciók**

- **Teljes előadás egyesítése:** Minden dia egyetlen fájlba gyűjtése.
- **Kiválasztott dia egyesítése:** Kijelölt diák kombinálása.
- **Keresztformátumú egyesítés:** Különböző formátumú előadások integrálása, az integritás megőrzésével.

{{% alert title="Tip" color="primary" %}}  
Szeretne egy gyors és **ingyenes online eszközt** a **PowerPoint‑előadások egyesítéséhez**? Próbálja ki a [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/hu/merger) alkalmazást.  
- **PowerPoint fájlok egyszerű egyesítése:** Több **PPT, PPTX, ODP** előadást egyetlen fájlba egyesíthet.  
- **Különböző formátumok támogatása:** Egyesíthet **PPT → PPTX**, **PPTX → ODP** és egyéb formátumokat.  
- **Nincs telepítés szükséges:** Közvetlenül a böngészőben működik, gyors és biztonságos.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/hu/merger)  

Kezdje el egyesíteni PowerPoint fájljait az **Aspose ingyenes online eszközével** még ma!  
{{% /alert %}}

## **Előadások egyesítése**

Amikor [egy előadást egy másikba egyesít](https://products.aspose.com/slides/hu/net/merger/ppt/), gyakorlatilag a diák egyetlen előadásba kerülnek, egy fájlt hozva létre.

{{% alert title="Info" color="info" %}}

A legtöbb előadáskezelő program (PowerPoint vagy OpenOffice) nem rendelkezik olyan funkcióval, amely lehetővé tenné a prezentációk ilyen módú egyesítését.  

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/hu/net/), azonban többféleképpen is lehetővé teszi az előadások egyesítését. Az összes alakzat, stílus, szöveg, formázás, megjegyzés, animáció stb. megmarad, minőség- vagy adatvesztés nélkül.  

**Lásd még**

[Clone Slides](https://docs.aspose.com/slides/hu/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  
{{% /alert %}}

### **Mi egyesíthető**

Az Aspose.Slides segítségével egyesíthet  

* teljes előadásokat. Az összes dia egyetlen előadásba kerül  
* konkrét diákat. A kiválasztott diák egy előadásba kerülnek  
* ugyanabban a formátumban lévő előadásokat (PPT → PPT, PPTX → PPTX stb.) és különböző formátumúakat (PPT → PPTX, PPTX → ODP stb.) egymáshoz.  

{{% alert title="Note" color="warning" %}}  
Az előadások mellett az Aspose.Slides lehetővé teszi más fájlok egyesítését is:

* [Képek](https://products.aspose.com/slides/hu/net/merger/image-to-image/), például [JPG → JPG](https://products.aspose.com/slides/hu/net/merger/jpg-to-jpg/) vagy [PNG → PNG](https://products.aspose.com/slides/hu/net/merger/png-to-png/)  
* Dokumentumok, például [PDF → PDF](https://products.aspose.com/slides/hu/net/merger/pdf-to-pdf/) vagy [HTML → HTML](https://products.aspose.com/slides/hu/net/merger/html-to-html/)  
* Két különböző fájlt, például [kép → PDF](https://products.aspose.com/slides/hu/net/merger/image-to-pdf/), [JPG → PDF](https://products.aspose.com/slides/hu/net/merger/jpg-to-pdf/) vagy [TIFF → PDF](https://products.aspose.com/slides/hu/net/merger/tiff-to-pdf/).  
{{% /alert %}}

### **Egyesítési beállítások**

Alkalmazhat beállításokat, amelyek meghatározzák, hogy  

* minden dia az eredmény‑prezentációban megőrizze-e egyedi stílusát  
* egy adott stílus legyen‑e használva az összes dia számára az eredmény‑prezentációban.  

Az előadások egyesítéséhez az Aspose.Slides a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone) metódusokat (az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) interfészből) biztosítja. Számos `AddClone` implementáció létezik, amelyek a prezentáció egyesítési folyamat paramétereit határozzák meg. Minden Presentation objektumnak van egy [Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/properties/slides) gyűjteménye, így a kívánt cél‑prezentációból hívhatja a `AddClone` metódust.

A `AddClone` metódus egy `ISlide` objektumot ad vissza, amely az eredeti dia klónja. Az eredmény‑prezentáció diáit egyszerűen a forrás‑diák másolataiként kezelhetjük. Ennek köszönhetően a kapott diákon (például stílusok, formázási opciók vagy elrendezések alkalmazása) változtatásokat végezhet anélkül, hogy a forrás‑prezentációk érintettek lennének.  

## **Prezentációk egyesítése**  

Az Aspose.Slides a [**AddClone (ISlide)**](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone) metódust kínálja, amely lehetővé teszi a diák egyesítését úgy, hogy azok megőrzik az eredeti elrendezéseiket és stílusaikat (alapértelmezett paraméterek).  

Ez a C# kód bemutatja, hogyan egyesíthetünk prezentációkat:

```c#
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

## **Prezentációk egyesítése diamesterrel**  

Az Aspose.Slides a [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/hu/net/aspose.slides.islidecollection/addclone/methods/2) metódust biztosítja, amely lehetővé teszi a diák egyesítését egy diamester sablon alkalmazásával. Így szükség esetén megváltoztathatja a kimeneti prezentáció diáinak stílusát.  

Az alábbi C# kód demonstrálja a leírt műveletet:

```c#
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
A diamester elrendezése automatikusan kerül meghatározásra. Ha nem állapítható meg megfelelő elrendezés, és az `allowCloneMissingLayout` logikai paraméter a `AddClone` metódusban true értékre van állítva, akkor a forrásdia elrendezése lesz használva. Ellenkező esetben [PptxEditException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxeditexception) kivétel keletkezik.  
{{% /alert %}}

Ha azt szeretné, hogy a kimeneti prezentáció diái más elrendezést kapjanak, használja helyette a [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/net/aspose.slides.islidecollection/addclone/methods/1) metódust az egyesítés során.  

## **Kiválasztott diák egyesítése előadásokból**  

Kiválasztott diák egyesítése több előadásból hasznos egyedi diakészletek létrehozásához. Az Aspose.Slides for .NET lehetővé teszi, hogy csak a szükséges diákat válassza ki és importálja. Az API megőrzi az eredeti diák formázását, elrendezését és dizájnját.

Az alábbi C# kód egy új prezentációt hoz létre, hozzáadja két másik előadás cím-diáját, majd elmenti az eredményt egy fájlba:

```cs
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
```
```cs
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

## **Prezentációk egyesítése diakalappal**  

Ez a C# kód megmutatja, hogyan kombinálhatók a diák előadásokból, miközben a kívánt diakalappal látják el őket, egyetlen kimeneti prezentációt hozva létre:

```c#
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
Nem lehet különböző dia méretű előadásokat egyesíteni.  
{{% /alert %}}

Két különböző dia méretű prezentáció egyesítéséhez egyik prezentáció méretét át kell állítani, hogy megegyezzen a másikéval.

Ez a mintakód demonstrálja a leírt műveletet:

```c#
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

## **Diák egyesítése egy prezentáció szakaszába**  

Ez a C# kód megmutatja, hogyan egyesíthet egy adott diát egy szakaszba a prezentációban:

```c#
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

A dia a szakasz végére kerül hozzáadásra.  

{{% alert title="Tip" color="primary" %}}  
Az Aspose egy [INGYENES Collage webalkalmazást](https://products.aspose.app/slides/hu/collage) biztosít. Ezzel az online szolgáltatással egyesíthet [JPG → JPG](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG → PNG képeket, készíthet [fotórácsokat](https://products.aspose.app/slides/hu/collage/photo-grid) és így tovább.  
{{% /alert %}}

## **GYIK**

**Megmaradnak a beszámoló jegyzetek az egyesítés során?**  

Igen. A diák klónozása során az Aspose.Slides átviszi az összes diaelemet, beleértve a jegyzeteket, formázást és animációkat.

**Átkerülnek a megjegyzések és szerzőik?**  

A megjegyzések a dia tartalmának részeként másolódnak át. A szerzők címkéi megmaradnak megjegyzésobjektumként a keletkezett prezentációban.

**Mi van, ha a forrás‑prezentáció jelszóval védett?**  

A [jelszóval megnyitott](/slides/hu/net/password-protected-presentation/) dokumentumot a [LoadOptions.Password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) segítségével kell betölteni; betöltés után a diákat biztonságosan klónozhatja egy védtelen vagy akár egy védett célfájlba is.

**Mennyire szálbiztos az egyesítési művelet?**  

Ne használja ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt több [szálról](/slides/hu/net/multithreading/). Az ajánlott szabály: „egy dokumentum – egy szál”; különböző fájlok párhuzamosan feldolgozhatók külön szálakon.