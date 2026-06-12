---
title: Funkční řešení změny velikosti grafu v PPTX
type: docs
weight: 60
url: /cs/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excelu
- OLE objekt
- vložit graf
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených OLE objektů Excelu s Aspose.Slides pro .NET. Naučte se dvě metody s kódem, jak udržet velikosti konzistentní."
---
## **Pozadí**

Bylo zaznamenáno, že grafy Excelu vložené jako OLE objekty v prezentaci PowerPoint prostřednictvím komponent Aspose jsou po první aktivaci změněny na neurčité měřítko. Toto chování způsobuje znatelný vizuální rozdíl v prezentaci mezi stavem grafu před a po aktivaci. Tým Aspose problém podrobně prozkoumal a našel řešení. Tento článek popisuje příčiny problému a odpovídající opravu.

V [předchozím článku](/slides/cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excelu pomocí Aspose.Cells pro .NET a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro .NET. Pro řešení [problému náhledu objektu](/slides/cs/net/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámci grafu. Ve výstupní prezentaci, když dvojkliknete OLE objektový rámec zobrazující obrázek grafu, aktivuje se graf Excelu. Koncoví uživatelé mohou provést libovolné požadované změny v podkladové sešitu Excelu a poté se vrátit na odpovídající snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních velikostech jak OLE objektového rámce, tak vloženého sešitu Excelu.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, při první aktivaci se snaží zachovat svou původní velikost. OLE objektový rámec má však svou vlastní velikost. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint vyjednávají velikost a zachovávají správný poměr stran jako součást procesu vkládání. V závislosti na rozdílech mezi velikostí okna Excelu a velikostí nebo polohou OLE objektového rámce dochází ke změně velikosti.

## **Fungující řešení**

Existují dva možné scénáře pro vytváření prezentací PowerPoint pomocí Aspose.Slides pro .NET.

**Scénář 1:** Vytvořit prezentaci na základě existující šablony.

**Scénář 2:** Vytvořit prezentaci od nuly.

Řešení, které zde poskytujeme, platí pro oba scénáře. Základ všech řešení je stejný: **velikost okna vloženého OLE objektu by měla odpovídat OLE objektovému rámci na snímku PowerPointu**. Nyní projedeme dva přístupy k tomuto řešení.

## **První přístup**

V tomto přístupu se naučíme, jak nastavit velikost okna vloženého sešitu Excel tak, aby odpovídala velikosti OLE objektového rámce na snímku PowerPointu.

**Scénář 1**

Předpokládejme, že jsme definovali šablonu a chceme na jejím základě vytvářet prezentace. Předpokládejme, že v šabloně je tvar na indexu 2, kam chceme umístit OLE rámec obsahující vložený sešit Excel. V tomto scénáři je velikost OLE objektového rámce předdefinovaná – odpovídá velikosti tvaru na indexu 2 v šabloně. Vše, co musíme udělat, je nastavit velikost okna sešitu na velikost tohoto tvaru. Následující úryvek kódu slouží tomuto účelu:

```cs
// Definujte velikost grafu s oknem. 
// Nastavte šířku okna sešitu v palcích (děleno 72, protože PowerPoint používá 72 pixelů na palec).
// Nastavte výšku okna sešitu v palcích.
// Uložte sešit do paměťového proudu.
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
chart.SizeWithWindow = true;

// Set the window width of the workbook in inches (divided by 72 as PowerPoint uses 72 pixels per inch).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Set the window height of the workbook in inches.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Save the workbook to a memory stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scénář 2**

Předpokládejme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excel. V následujícím úryvku kódu vytvoříme OLE objektový rámec vysoký 4 palce a široký 9,5 palce na souřadnicích x = 0,5 palce a y = 1 palec na snímku. Poté nastavíme okno sešitu Excel na stejnou velikost – 4 palce vysoké a 9,5 palce široké.

```cs
// Požadovaná výška.
int desiredHeight = 288; // 4 palce (4 * 72)

// Požadovaná šířka.
int desiredWidth = 684;//9.5 palce (9.5 * 72)

// Definujte velikost grafu s oknem.
chart.SizeWithWindow = true;

// Nastavte šířku okna sešitu v palcích.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Nastavte výšku okna sešitu v palcích.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Uložte sešit do paměťového proudu.
MemoryStream workbookStream = workbook.SaveToStream();

// Vytvořte OLE objektový rámec s vloženými daty Excelu.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Druhý přístup**

V tomto přístupu se naučíme, jak nastavit velikost grafu v vloženém sešitu Excel tak, aby odpovídala velikosti OLE objektového rámce na snímku PowerPointu. Tento přístup je užitečný, když je velikost grafu předem známá a nikdy se nezmění.

**Scénář 1**

Předpokládejme, že jsme definovali šablonu a chceme na jejím základě vytvářet prezentace. Předpokládejme, že v šabloně je tvar na indexu 2, kam chceme umístit OLE rámec obsahující vložený sešit Excel. V tomto scénáři je velikost OLE rámce předdefinovaná – odpovídá velikosti tvaru na indexu 2 v šabloně. Vše, co musíme udělat, je nastavit velikost grafu v sešitu na velikost tohoto tvaru. Následující úryvek kódu slouží tomuto účelu:

```cs
// Definujte velikost grafu bez okna. 
chart.SizeWithWindow = false;

// Nastavte šířku grafu v pixelech (vynásobte 96, protože Excel používá 96 pixelů na palec).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Nastavte výšku grafu v pixelech.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Definujte tiskovou velikost grafu.
chart.PrintSize = PrintSizeType.Custom;

// Uložte sešit do paměťového proudu.
MemoryStream workbookStream = workbook.SaveToStream();

// Vytvořte OLE objektový rámec s vloženými daty Excelu.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scénář 2**

Předpokládejme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excel. V následujícím úryvku kódu vytvoříme OLE objektový rámec výšky 4 palce a šířky 9,5 palce na souřadnicích x = 0,5 palce a y = 1 palec na snímku. Také nastavíme odpovídající velikost grafu na stejné rozměry: výšku 4 palce a šířku 9,5 palce.

```cs
 // Požadovaná výška.
int desiredHeight = 288; // 4 palce (4 * 576)

// Požadovaná šířka.
int desiredWidth = 684; // 9.5 palce (9.5 * 576)

// Definujte velikost grafu bez okna. 
chart.SizeWithWindow = false;

// Nastavte šířku grafu v pixelech.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Nastavte výšku grafu v pixelech.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Uložte sešit do paměťového proudu.
MemoryStream workbookStream = workbook.SaveToStream();

// Vytvořte OLE objektový rámec s vloženými daty Excelu.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Závěr**

Existují dva přístupy k řešení problému změny velikosti grafu. Volba přístupu závisí na požadavcích a konkrétním případu použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Také neexistuje žádný limit velikosti OLE objektového rámce v tomto řešení.

## **Často kladené otázky**

**Proč se po aktivaci v PowerPointu mění velikost mého vloženého grafu Excel?**  
Stane se to, protože se Excel při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tomuto problému se změnou velikosti úplně předejít?**  
Ano. Pokud před vložením nastavíte velikost okna sešitu Excel nebo velikost grafu tak, aby odpovídala velikosti OLE objektového rámce, můžete udržet velikosti grafů konzistentní.

**Který přístup mám zvolit, nastavení velikosti okna sešitu nebo nastavení velikosti grafu?**  
Použijte **Přístup 1 (velikost okna)**, pokud chcete zachovat poměr stran sešitu a případně umožnit pozdější změnu velikosti.  
Použijte **Přístup 2 (velikost grafu)**, pokud jsou rozměry grafu pevně dané a po vložení se nebudou měnit.

**Budou tyto metody fungovat jak pro prezentace založené na šabloně, tak pro nové prezentace?**  
Ano. Oba přístupy fungují stejně pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE objektového rámce?**  
Ne. OLE rámec můžete nastavit na jakoukoli velikost, pokud se správně škáluje na velikost sešitu nebo grafu.

**Mohu tyto metody použít s grafy vytvořenými v jiných tabulkových programech?**  
Příklady jsou vytvořeny pro grafy Excelu vytvořené pomocí Aspose.Cells, ale principy platí i pro jiné OLE-kompatibilní tabulkové programy, pokud podporují podobné možnosti nastavení velikosti.

## **Související sekce**

- [Vytvořit grafy Excel a vložit je jako OLE objekty do prezentací](/slides/cs/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Automaticky aktualizovat OLE objekty pomocí doplňku PowerPoint](/slides/cs/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)