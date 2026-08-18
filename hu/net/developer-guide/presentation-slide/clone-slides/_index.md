---
title: Prezentáció diák klónozása .NET-ben
linktitle: Dia klónozása
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
description: "Gyorsan duplikálja a PowerPoint diákat az Aspose.Slides for .NET segítségével. Kövesse egyértelmű kódrészleteinket, hogy másodpercek alatt automatizálja a PPT létrehozását és megszüntesse a manuális munkát."
---
## **Bevezetés**

A klónozás egy dolog pontos másolatának vagy replikájának létrehozási folyamata. Az Aspose.Slides lehetővé teszi, hogy bármely diát lemásolja (klónozza), majd a klónozott diát beillessze az aktuális prezentációba vagy bármely más megnyitott prezentációba. A diáklónozás új diát hoz létre, amelyet a fejlesztők módosíthatnak anélkül, hogy az eredeti dia változna. Többféleképpen lehet egy diát klónozni:

- Klónozás a prezentáció végén.
- Klónozás egy másik pozícióba a prezentáción belül.
- Klónozás egy másik prezentáció végén.
- Klónozás egy másik pozícióba egy másik prezentációban.
- Klónozás a saját mesterdiájával együtt egy másik prezentációba.

Az Aspose.Slides for .NET-ben a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) objektum által biztosított dia gyűjtemény (az [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/) objektumok gyűjteménye) tartalmazza az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) és az [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/insertclone/) metódusokat a fent leírt diáklónozási műveletek végrehajtásához.

## **Dia klónozása a prezentáció végén**

Ha egy diát szeretne klónozni, és azt ugyanabban a prezentációfájlban a meglévő diák végén használni, használja az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust az alábbi lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Hozza létre az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) osztály példányát a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektum által biztosított Slides gyűjtemény hivatkozásával.
1. Hívja meg az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektumon, és adja át a klónozandó diát paraméterként az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusnak.
1. Írja ki a módosított prezentációfájlt.

Az alábbi példában egy diát (a prezentáció első pozíciójában – nulla indexen – lévő) klónoztunk a prezentáció végére.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosít egy Presentation osztályt, amely egy prezentációfájlt képvisel
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // Klónozza a kívánt diát a ugyanabban a prezentációban lévő diák gyűjteményének végére
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // Kiírja a módosított prezentációt a lemezre
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **Dia klónozása egy másik pozícióba egy prezentáción belül**

Ha egy diát szeretne klónozni, és azt ugyanabban a prezentációfájlban, de más pozícióban használni, használja az [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódust:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Hozzon létre egy példányt a **Slides** gyűjteményre hivatkozva, amelyet a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektum biztosít.
1. Hívja meg az [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektumon, és adja át a klónozandó diát a kívánt új pozíció indexével együtt paraméterként az [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódusnak.
1. Írja ki a módosított prezentációt PPTX fájlként.

Az alábbi példában egy diát (a prezentáció 1-es indexén – 2. pozíció – lévő) klónoztunk a 2-es indexre – 3. pozícióra – a prezentációban.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosít egy Presentation osztályt, amely egy prezentációfájlt képvisel
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // Klónozza a kívánt diát a ugyanabban a prezentációban lévő diák gyűjteményének végére
    ISlideCollection slds = pres.Slides;

    // Klónozza a kívánt diát a megadott indexre ugyanabban a prezentációban
    slds.InsertClone(2, pres.Slides[1]);

    // Kiírja a módosított prezentációt a lemezre
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **Dia klónozása egy másik prezentáció végén**

Ha egy diát szeretne klónozni, és azt egy másik prezentáció fájljában a meglévő diák végén használni:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányt, amely tartalmazza azt a prezentációt, amelyből a diát klónozni kívánja.
1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányt, amely a célprezentációt tartalmazza, amelyhez a diát hozzáadja.
1. Hozza létre az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) osztály példányát a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektuma által biztosított **Slides** gyűjtemény hivatkozásával.
1. Hívja meg az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektumon, és adja át a forrásprezentáció diáját paraméterként az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusnak.
1. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy diát (a forrásprezentáció első indexéről) klónoztunk a célprezentáció végére.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosít egy Presentation osztályt a forrás prezentációfájl betöltéséhez
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Példányosít egy Presentation osztályt a cél PPTX-hez (ahová a diát klónozni kell)
    using (Presentation destPres = new Presentation())
    {
        // Klónozza a kívánt diát a forrás prezentációból a cél prezentáció diagyűjteményének végére
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // Kiírja a cél prezentációt a lemezre
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Dia klónozása egy másik prezentációban egy másik pozícióba**

Ha egy diát szeretne klónozni, és azt egy másik prezentáció fájljában egy meghatározott pozícióban használni:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányt, amely a forrásprezentációt tartalmazza, amelyből a diát klónozni kívánja.
1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányt, amely a célprezentációt tartalmazza, amelyhez a diát hozzáadja.
1. Hozza létre az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) osztály példányát a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektuma által biztosított Slides gyűjtemény hivatkozásával.
1. Hívja meg az [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektumon, és adja át a forrásprezentáció diáját a kívánt pozícióval együtt paraméterként az [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides.ishapecollection/insertclone/methods/1) metódusnak.
1. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy diát (a forrásprezentáció nulla indexéről) klónoztunk a célprezentáció 1-es indexére (2. pozícióra).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosít egy Presentation osztályt a forrás prezentációfájl betöltéséhez
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // Példányosít egy Presentation osztályt a cél PPTX-hez (ahová a diát klónozni kell)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // Kiírja a cél prezentációt a lemezre
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **Dia és mesterdia klónozása egy másik prezentációba**

Ha egy diát a hozzá tartozó mesterdiával kíván klónozni egy prezentációból, és egy másik prezentációban használni, először a kívánt mesterdiát kell a forrásprezentációból a célprezentációba klónozni. Ezután ezt a mesterdiát kell használni a diák mesterrel történő klónozásához. A **AddClone(ISlide, IMasterSlide)** egy a célprezentációból származó mesterdiát vár, nem a forrásprezentációból. A diák mesterrel való klónozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányt, amely a forrásprezentációt tartalmazza, amelyből a diát klónozni kívánja.
1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányt, amely a célprezentációt tartalmazza, amelyhez a diát klónozni kívánja.
1. Keresse meg a klónozandó diát a hozzá tartozó mesterdiával együtt.
1. Hozza létre az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection) osztály példányát a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektuma által biztosított Masters gyűjtemény hivatkozásával.
1. Hívja meg az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust az [IMasterSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection) objektumon, és adja át a forrás PPTX-ből származó, klónozandó mesterdiát paraméterként az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusnak.
1. Hozza létre az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) osztály példányát a célprezentáció [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) objektuma által biztosított Slides gyűjtemény hivatkozásával.
1. Hívja meg az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) objektumon, és adja át a forrásprezentációból származó, klónozandó diát és a mesterdiát paraméterként az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódusnak.
1. Írja ki a módosított célprezentáció fájlt.

Az alábbi példában egy diát mesterdiával együtt (a forrásprezentáció nulla indexén) klónoztunk a célprezentáció végére a forrásdiáról származó mesterdia használatával.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation class to load the source presentation file
using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // Instantiate Presentation class for destination presentation (where slide is to be cloned)
    using (Presentation destPres = new Presentation())
    {

        // Instantiate ISlide from the collection of slides in source presentation along with
        // Master slide
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // Clone the desired master slide from the source presentation to the collection of masters in the
        // Destination presentation
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // Clone the desired slide from the source presentation with the desired master to the end of the
        // Collection of slides in the destination presentation
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // Clone the desired master slide from the source presentation to the collection of masters in the // Destination presentation
        // Save the destination presentation to disk
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **Dia klónozása egy megadott szekció végén**

Az Aspose.Slides for .NET segítségével egy prezentáció egy szekciójából klónozhat diát, és beillesztheti azt ugyanabban a prezentációban egy másik szekcióba. Ebben az esetben az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/methods/addclone/index) metódust kell használni az [ISlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection) interfészből. 

Ez a C# kód bemutatja, hogyan lehet egy diát klónozni és a klónozott diát egy megadott szekcióba beilleszteni:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **A megfelelő dia méret biztosítása**

Dia klónozásakor egy másik prezentációba ügyeljen arra, hogy a célprezentáció dia mérete megegyezzen a forráséval. Ha a dia méretek eltérnek, az Aspose.Slides nem méretezi át automatikusan a klónozott alakzatokat – azok eredeti koordinátái és méretei megmaradnak, ami azt eredményezheti, hogy a tartalom eltolódik vagy a dia határain kívül helyezkedik el.

A mester és a dia klónozása előtt beállíthatja a célprezentáció dia méretét, hogy az egyezzen a forráséval:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

Ezt a mester és a dia klónozása előtt végezze.

## **FAQ**

**A beszélői jegyzetek és a recenziós megjegyzések klónozódnak?**

Igen. A jegyzetoldal és a felülvizsgálati megjegyzések a klónba kerülnek. Ha nem szeretné, akkor a beillesztés után [távolítsa el őket](/slides/hu/net/presentation-notes/).

**Hogyan kezelik a diagramok és azok adatforrásai?**

A diagram objektuma, formázása és a beágyazott adatok másolásra kerülnek. Ha a diagram egy külső forráshoz (például OLE-beágyazott munkafüzethez) volt kapcsolva, ez a kapcsolat egy [OLE objektum](/slides/hu/net/manage-ole/) formájában megmarad. Fájlok közti áthelyezés után ellenőrizze az adatok elérhetőségét és a frissítési viselkedést.

**Korlátozhatom a klón beszúrási pozícióját és szekcióit?**

Igen. A klón beilleszthető egy adott dia indexre, és elhelyezhető egy kiválasztott [szekcióba](/slides/hu/net/slide-section/). Ha a cél szekció nem létezik, előbb hozza létre, majd mozgassa át a diát.