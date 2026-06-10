---
title: Prezentáció diáinak klónozása .NET-ben
linktitle: Diák klónozása
type: docs
weight: 40
url: /hu/net/clone-slides/
keywords:
- dia klónozása
- dia másolása
- dia mentése
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET segítségével gyorsan duplikálhatja a PowerPoint diákat. Kövesse átlátható kódpéldáinkat, hogy másodperc alatt automatizálja a PPT létrehozását és megszüntesse a manuális munkát."
---
## **Bevezetés**

A klónozás egy folyamat, amelynek során egy pontos másolat vagy replikát készítünk valamiről. Az Aspose.Slides lehetővé teszi, hogy bármely diát másolj (klónozz) és aztán a klónozott diát beilleszd az aktuális prezentációba vagy bármely más nyitott prezentációba. A diakléonál egy új dia jön létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti diát befolyásolnák. Többféleképpen lehet klónozni egy diát:

- Klónozás a prezentáció végén.
- Klónozás egy másik pozícióban a prezentáción belül.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik pozícióban egy másik prezentációban.
- Klónozás egy meghatározott pozícióban egy másik prezentációban.

Az Aspose.Slides for .NET-ben a diakollekció (egy [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/) objektumok gyűjteménye), amelyet a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektum tesz elérhetővé, biztosítja a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) és [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/insertclone/) metódusokat a fent leírt diaklónál műveletek végrehajtásához.

## **Dia klónozása a prezentáció végén**

Ha egy diát szeretnél klónozni, majd ugyanabban a prezentációfájlban használni a meglévő diák végén, használd a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust az alábbi lépések szerint:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Példányosítsd a [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) osztályt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektum által biztosított Slides gyűjtemény hivatkozásával.
1. Hívd meg a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust, amelyet a [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektum biztosít, és add meg a klónozandó diát paraméterként a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusnak.
1. Írd ki a módosított prezentációfájlt.

Az alább bemutatott példában egy diát (ami a prezentáció első pozíciójában – nulla index – helyezkedik el) klónoztunk a prezentáció végére.

```c#
 // A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
 using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
 {
 
     // A kívánt dia klónozása a diák gyűjteményének végére ugyanabban a prezentációban
     ISlideCollection slds = pres.Slides;
 
     slds.AddClone(pres.Slides[0]);
 
     // A módosított prezentáció mentése lemezre
     pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
 
 }
```

## **Dia klónozása egy másik pozícióba a prezentáción belül**

Ha egy diát szeretnél klónozni, majd ugyanabban a prezentációfájlban, de egy másik pozícióban használni, használd a [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódust:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Példányosítsd az osztályt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektum által biztosított **Slides** gyűjtemény hivatkozásával.
1. Hívd meg a [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódust, amelyet a [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektum biztosít, és add meg a klónozandó diát a kívánt új pozíció indexével együtt paraméterként a [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódusnak.
1. Írd ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy diát (ami a prezentáció nulla indexén – 1. pozíció – van) klónoztunk az 1. indexre – 2. pozícióra – a prezentációban.

```c#
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // A kívánt dia klónozása a diák gyűjteményének végére ugyanabban a prezentációban
    ISlideCollection slds = pres.Slides;

    // A kívánt dia klónozása a megadott indexre ugyanabban a prezentációban
    slds.InsertClone(2, pres.Slides[1]);

    // A módosított prezentáció mentése lemezre
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Dia klónozása egy másik prezentáció végén**

Ha egy diát kell klónozni egy prezentációból, és egy másik prezentációfájlban használni, a meglévő diák végén:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a forrás prezentációt tartalmazza, ahonnan a diát klónozni fogjuk.
1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a cél prezentációt tartalmazza, amelyhez a diát hozzáadjuk.
1. Példányosítsd a [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) osztályt a cél prezentáció Presentation objektuma által biztosított **Slides** gyűjtemény hivatkozásával.
1. Hívd meg a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust, amelyet a [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektum biztosít, és add meg a forrás prezentáció diáját paraméterként a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusnak.
1. Írd ki a módosított célprezentáció fájlt.

Az alább bemutatott példában egy diát (a forrás prezentáció első indexéből) klónoztunk a célprezentáció végére.

```c#
 // A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
 using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
 {
     // A Presentation osztály példányosítása a cél PPTX-hez (ahová a dia klónozva lesz)
     using (Presentation destPres = new Presentation())
     {
         // A kívánt dia klónozása a forrás prezentációból a cél prezentáció diagyűjteményének végére
         ISlideCollection slds = destPres.Slides;

         slds.AddClone(srcPres.Slides[0]);

         // A cél prezentáció mentése lemezre
         destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
     }
 }
```

## **Dia klónozása egy másik pozícióba egy másik prezentációban**

Ha egy diát kell klónozni egy prezentációból, és egy másik prezentációfájlban, egy meghatározott pozícióban használni:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a forrás prezentációt tartalmazza, ahonnan a diát klónozni fogjuk.
1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a cél prezentációt tartalmazza, amelyhez a diát hozzáadjuk.
1. Példányosítsd a [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) osztályt a cél prezentáció Presentation objektuma által biztosított Slides gyűjtemény hivatkozásával.
1. Hívd meg a [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódust, amelyet a [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektum biztosít, és add meg a forrás prezentáció diáját a kívánt pozícióval együtt paraméterként a [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódusnak.
1. Írd ki a módosított célprezentáció fájlt.

Az alább bemutatott példában egy diát (a forrás prezentáció nulla indexéről) klónoztunk az 1. indexre (2. pozíció) a célprezentációban.

```c#
// A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // A Presentation osztály példányosítása a cél PPTX-hez (ahová a diát klónozni fogják)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // A cél prezentáció mentése lemezre
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Dia klónozása egy meghatározott pozícióba egy másik prezentációban**

Ha egy diát kell klónozni egy mesterdiával egy prezentációból, és egy másik prezentációban használni, először a kívánt mesterdiát kell klónozni a forrás prezentációból a cél prezentációba. Ezután ezt a mesterdiát kell használni a mesterdiás dia klónozásához. A **AddClone(ISlide, IMasterSlide)** egy a cél prezentációból származó mesterdiát vár, nem a forrásból. A mesterdiával rendelkező dia klónozásához kövesd az alábbi lépéseket:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a forrás prezentációt tartalmazza, ahonnan a diát klónozni fogjuk.
1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a cél prezentációt tartalmazza, amelyhez a diát hozzáadjuk.
1. Érd el a klónozandó diát a hozzá tartozó mesterdiával.
1. Példányosítsd a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection) osztályt a cél prezentáció [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektuma által biztosított Masters gyűjtemény hivatkozásával.
1. Hívd meg a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust, amelyet az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection) objektum biztosít, és add meg a forrás PPTX‑ből származó, klónozandó mesterdiát paraméterként a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusnak.
1. Példányosítsd a [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) osztályt a cél prezentáció [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektuma által biztosított Slides gyűjtemény hivatkozásával.
1. Hívd meg a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust, amelyet az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektum biztosít, és add meg a forrás prezentációból származó, klónozandó diát és mesterdiát paraméterként a [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusnak.
1. Írd ki a módosított célprezentáció fájlt.

Az alább bemutatott példában egy mesterdiával rendelkező diát (a forrás prezentáció nulla indexén) klónoztunk a célprezentáció végére, a forrás diából származó mesterdiát használva.

```c#
 // A Presentation osztály példányosítása a forrás prezentációs fájl betöltéséhez

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // A Presentation osztály példányosítása a cél prezentációhoz (ahová a diát klónozni kell)
    using (Presentation destPres = new Presentation())
    {

        // ISlide példányosítása a forrás prezentáció diagyűjteményéből, együtt
        // Mesterdia
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // A kívánt mesterdia klónozása a forrás prezentációból a mestergyűjteménybe a
        // cél prezentációban
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // A kívánt mesterdia klónozása a forrás prezentációból a mestergyűjteménybe a
        // cél prezentációban
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // A kívánt dia klónozása a forrás prezentációból a kívánt mesterrel a végére
        // a cél prezentáció diagyűjteményébe
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // A kívánt mesterdia klónozása a forrás prezentációból a mestergyűjteménybe a cél prezentációban
        // A cél prezentáció mentése lemezre
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Dia klónozása egy meghatározott szakasz végén**

Az Aspose.Slides for .NET segítségével egy diát klónozhatsz egy prezentáció egy szakaszából, és beillesztheted azt egy másik szakaszba ugyanabban a prezentációban. Ebben az esetben az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) interfész [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusát kell használnod.

Ez a C# kód megmutatja, hogyan lehet egy diát klónozni és a klónozott diát egy meghatározott szakaszba beilleszteni:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // klónozáshoz
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**A jegyzetek és a felülvizsgáló kommentárok klónozva vannak?**

Igen. A jegyzetoldal és a felülvizsgáló kommentárok belekerülnek a klónba. Ha nem akarod őket, [vedd el őket](/slides/hu/net/presentation-notes/) a beillesztés után.

**A diagramok és adatforrásaik hogyan kezelődnek?**

A diagram objektum, a formázás és a beágyazott adatok másolásra kerülnek. Ha a diagram külső forráshoz volt kapcsolva (például egy OLE‑beágyazott munkafüzethez), ezt a kapcsolatot [OLE objektum](/slides/hu/net/manage-ole/) formájában megőrzik. Fájlok közti áthelyezés után ellenőrizd az adatok elérhetőségét és a frissítési viselkedést.

**Szabályozhatom a beillesztés pozícióját és a szakaszokat a klón számára?**

Igen. A klónt egy meghatározott diaindexre szúrhatod be, és egy kiválasztott [szakasz](/slides/hu/net/slide-section/)ba helyezheted. Ha a cél szakasz nem létezik, előbb hozd létre, majd helyezd bele a diát.