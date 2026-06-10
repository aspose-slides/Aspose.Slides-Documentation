---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 14.8.0 verzióban
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a töréspontokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migreálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 14.8.0 API-val bevezetett egyéb változásokat.

{{% /alert %}} 
## **Nyilvános API változások**
### **Megváltozott tulajdonságok**
#### **Hozzáadott az IVbaProject interfész, megváltozott a Presentation.VbaProject tulajdonság**
A Presentation osztály VbaProject tulajdonsága helyettesítésre került. A VbaProject tulajdonság nyers bájtábrázolásának helyett, hozzá lett adva az új IVbaProject interfész megvalósítása.

Használja az IVbaProject tulajdonságot a prezentációba beágyazott VBA projektek kezeléséhez. Új projekt hivatkozásokat adhat hozzá, szerkesztheti a meglévő modulokat és újat hozhat létre.

Ezen felül új VBA projektet hozhat létre a VbaProject osztály használatával, amely az IVbaProject interfészt valósítja meg.

A következő példa egy egyszerű VBA projekt létrehozását mutatja, amely egy modult tartalmaz, és két szükséges hivatkozást ad hozzá a könyvtárakhoz.

``` csharp

 using (Presentation pres = new Presentation())
{
    // Új VBA projekt létrehozása
    pres.VbaProject = new VbaProject();

    // Üres modul hozzáadása a VBA projekthez
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Modul forráskód beállítása
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Hivatkozás létrehozása a <stdole> elemre
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Hivatkozás létrehozása az Office-hez
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Hivatkozások hozzáadása a VBA projekthez
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);
}
``` 

Ez a példa azt mutatja, hogyan másolhatunk VBA projektet egy meglévő prezentációból egy újba.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())
{
    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());
}
``` 
### **Hozzáadott interfészek, tulajdonságok és felsorolás opciók**
#### **Hozzáadott Az Aspose.Slides.Charts.IChartSeries.Overlap tulajdonság**
Az Aspose.Slides.Charts.IChartSeries.Overlap tulajdonság meghatározza, hogy a sávok és oszlopok mennyire fedhetik egymást 2D diagramokban (‑100 és 100 között).

Ez a tulajdonság nem csak erre a sorozatra vonatkozik, hanem a szülő sorozatcsoport minden sorozatára – ez a megfelelő csoporttulajdonság leképezése. Így ez a tulajdonság csak olvasható.

- Használja a ParentSeriesGroup tulajdonságot a szülő sorozatcsoport eléréséhez.
- Használja a ParentSeriesGroup.Overlap olvasás/írás tulajdonságot az érték módosításához.

``` csharp

 using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
   IChartSeriesCollection series = chart.ChartData.Series;
   if (series[0].Overlap == 0)
      {
            series[0].ParentSeriesGroup.Overlap = -30;
      }
}
``` 
#### **Hozzáadott Az Aspose.Slides.Charts.IChartSeriesGroup.Overlap tulajdonság**
Az Aspose.Slides.Charts.IChartSeriesGroup.Overlap tulajdonság meghatározza, hogy a sávok és oszlopok mennyire fedjék egymást 2D diagramokban (‑100 és 100 között).

``` csharp



using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
   IChartSeriesCollection series = chart.ChartData.Series;
   series[0].ParentSeriesGroup.Overlap = -30;
}
``` 
#### **Hozzáadott a ShapeThumbnailBounds.Appearance felsoroló érték**
Ez a alakzat előnézetkép létrehozási módszer lehetővé teszi, hogy az alakzat megjelenésének határain belül generáljon előnézetképet. Figyelembe veszi az összes alakzateffektet. A generált előnézetkép a dia határai által van korlátozva.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))
{
    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);
    st.Save("ShapeThumbnail.png", ImageFormat.Png);
}
```