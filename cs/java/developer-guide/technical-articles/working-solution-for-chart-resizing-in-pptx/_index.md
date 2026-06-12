---
title: Řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 40
url: /cs/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- OLE objekt
- vložit graf
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených OLE objektů Excel s Aspose.Slides pro Java. Naučte se dva způsoby s kódem, jak udržet velikosti konzistentní."
---
## **Pozadí**

Bylo zjištěno, že grafy Excelu vložené jako OLE objekty v PowerPoint prezentaci pomocí komponent Aspose jsou po první aktivaci změněny na neurčenou velikost. Toto chování způsobuje výrazný vizuální rozdíl v prezentaci mezi stavem grafu před a po aktivaci. Tým Aspose problém podrobně prozkoumal a našel řešení. Tento článek popisuje příčiny problému a odpovídající opravu.

V [předchozím článku](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excelu pomocí Aspose.Cells pro Java a vložit jej do PowerPoint prezentace pomocí Aspose.Slides pro Java. Pro řešení [problému s náhledem objektu](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámci grafu. V výsledné prezentaci, když dvojkliknete OLE objektový rámec zobrazující obrázek grafu, aktivuje se graf Excelu. Uživatelé mohou provést libovolné změny v podkladovém sešitu Excel a poté se vrátit na odpovídající snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních velikostech jak OLE objektového rámce, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, snaží se při první aktivaci zachovat původní velikost. OLE objektový rámec však má vlastní rozměry. Podle Microsoftu, když je sešit Excel aktivován, Excel a PowerPoint vyjednávají velikost a udržují správné proporce jako součást procesu vložení. V závislosti na rozdílech mezi velikostí okna Excelu a velikostí či umístěním OLE objektového rámce dochází k změně velikosti.

## **Fungující řešení**

Existují dva možné scénáře pro vytváření PowerPoint prezentací pomocí Aspose.Slides pro Java.

**Scenario 1:** Vytvořit prezentaci na základě existující šablony.

**Scenario 2:** Vytvořit prezentaci od nuly.

Řešení, které zde poskytujeme, platí pro oba scénáře. Základem všech přístupů k řešení je to samé: **velikost okna vloženého OLE objektu by měla odpovídat velikosti OLE objektového rámce ve snímku PowerPointu**. Nyní probereme dva přístupy k tomuto řešení.

## **První přístup**

V tomto přístupu se naučíme, jak nastavit velikost okna vloženého sešitu Excel tak, aby odpovídala rozměrům OLE objektového rámce ve snímku PowerPoint.

**Scenario 1**

Předpokládejme, že máme definovanou šablonu a chceme na jejím základě vytvářet prezentace. Předpokládejme, že v šabloně je na indexu 2 tvar, do kterého chceme umístit OLE rámec obsahující vložený sešit Excel. V tomto scénáři je velikost OLE objektového rámce předdefinována – odpovídá velikosti tvaru na indexu 2 v šabloně. Stačí nastavit velikost okna sešitu na stejnou velikost jako má tento tvar. Následující úryvek kódu slouží tomuto účelu:

```java
// Nastavte šířku okna sešitu v palcích (děleno 576, protože PowerPoint používá 576 pixelů na palec).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Nastavte výšku okna sešitu v palcích.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Uložte sešit do paměťového proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**

Řekněme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excel. V následujícím úryvku kódu vytvoříme OLE objektový rámec vysoký 4 palce a široký 9,5 palce na souřadnicích x = 0,5 palce a y = 1 palec na snímku. Poté nastavíme okno sešitu Excel na stejnou velikost – 4 palce vysoké a 9,5 palce široké.

```java
// Naše požadovaná výška.
int desiredHeight = 288; // 4 palce (4 * 72)
 
// Naše požadovaná šířka.
int desiredWidth = 684; // 9,5 palce (9.5 * 72)
 
// Definujte velikost grafu s oknem.
chart.setSizeWithWindow(true);
 
// Nastavte šířku okna sešitu v palcích (děleno 576, protože PowerPoint používá 576 pixelů na palec).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Nastavte výšku okna sešitu v palcích.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Uložte sešit do paměťového proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Druhý přístup**

V tomto přístupu se naučíme, jak nastavit velikost grafu ve vloženém sešitu Excel tak, aby odpovídala velikosti OLE objektového rámce ve snímku PowerPoint. Tento přístup je užitečný, když je velikost grafu známa předem a nikdy se nezmění.

**Scenario 1**

Předpokládejme, že máme definovanou šablonu a chceme na jejím základě vytvářet prezentace. Předpokládejme, že v šabloně je na indexu 2 tvar, do kterého chceme umístit OLE rámec obsahující vložený sešit Excel. V tomto scénáři je velikost OLE rámce předdefinována – odpovídá velikosti tvaru na indexu 2 v šabloně. Stačí nastavit velikost grafu v sešitu na stejnou velikost jako má tento tvar. Následující úryvek kódu slouží tomuto účelu:

```java
// Definujte velikost grafu bez okna.
chart.setSizeWithWindow(false);
 
// Nastavte šířku grafu v pixelech (vynásobte 96, protože Excel používá 96 pixelů na palec).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Nastavte výšku grafu v pixelech.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definujte tiskovou velikost grafu.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Uložte sešit do paměťového proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Scenario 2**:

Předpokládejme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excel. V následujícím úryvku kódu vytvoříme OLE objektový rámec vysoký 4 palce a široký 9,5 palce na souřadnicích x = 0,5 palce a y = 1 palec na snímku. Také nastavíme odpovídající velikost grafu na stejné rozměry: výšku 4 palce a šířku 9,5 palce.

```java
// Naše požadovaná výška.
int desiredHeight = 288; // 4 palce (4 * 72)
 
// Naše požadovaná šířka.
int desiredWidth = 684; // 9,5 palce (9.5 * 72)
 
// Definujte velikost grafu bez okna.
chart.setSizeWithWindow(false);
 
// Nastavte šířku grafu v pixelech (vynásobte 96, protože Excel používá 96 pixelů na palec).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Nastavte výšku grafu v pixelech.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Uložte sešit do paměťového proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Závěr**

Existují dva přístupy k řešení problému se změnou velikosti grafu. Volba přístupu závisí na požadavcích a konkrétním použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektového rámce.

## **Často kladené dotazy**

**Proč se můj vložený graf Excelu po aktivaci v PowerPointu zvětší?**

K tomu dochází, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné zcela zabránit tomuto problému se změnou velikosti?**

Ano. Pokud před vložením sladíte velikost okna sešitu Excel nebo velikost grafu s velikostí OLE objektového rámce, můžete zachovat konzistentní velikost grafu.

**Který přístup mám zvolit, nastavit velikost okna sešitu nebo velikost grafu?**

Použijte **přístup 1 (velikost okna)**, pokud chcete zachovat poměr stran sešitu a případně umožnit jeho pozdější změnu velikosti.  
Použijte **přístup 2 (velikost grafu)**, pokud jsou rozměry grafu pevně dané a po vložení se nebudou měnit.

**Budou tyto metody fungovat jak pro prezentace založené na šabloně, tak pro nové prezentace?**

Ano. Oba přístupy fungují stejně pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE objektového rámce?**

Ne. OLE rámec můžete nastavit na libovolnou velikost, pokud se vhodně škáluje k velikosti sešitu nebo grafu.

**Mohu tyto metody použít pro grafy vytvořené v jiných tabulkových programech?**

Příklady jsou určeny pro grafy Excel vytvořené pomocí Aspose.Cells, ale principy platí i pro jiné tabulkové programy kompatibilní s OLE, pokud podporují podobné možnosti nastavení velikosti.

## **Související sekce**

- [Vytváření grafů Excel a jejich vkládání jako OLE objekty v prezentacích](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Automatická aktualizace OLE objektů pomocí PowerPoint doplňku](/slides/cs/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)