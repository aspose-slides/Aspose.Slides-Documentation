---
title: "Fungující řešení pro změnu velikosti grafu v PPTX"
type: docs
weight: 40
url: /cs/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- "změna velikosti grafu"
- "graf Excelu"
- "OLE objekt"
- "vložit graf"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Java"
- "Aspose.Slides"
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených OLE objektů Excelu s Aspose.Slides pro Java. Naučte se dvě metody s kódem, jak zachovat konzistentní velikosti."
---
## **Pozadí**

Bylo zaznamenáno, že grafy Excelu vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose jsou po své první aktivaci změněny na neurčené měřítko. Toto chování způsobuje výrazný vizuální rozdíl v prezentaci mezi před- a po‑aktivačním stavem grafu. Tým Aspose problém podrobně prozkoumal a našel řešení. Tento článek popisuje příčiny problému a odpovídající opravu.

V [předchozím článku](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excelu pomocí Aspose.Cells pro Java a vložit jej do prezentace PowerPoint pomocí Aspose.Slides pro Java. Pro řešení [problému s náhledem objektu](/slides/cs/java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámci grafu. V výstupní prezentaci, když dvakrát kliknete na OLE objektový rámec zobrazující obrázek grafu, aktivuje se graf Excelu. Koneční uživatelé mohou provádět jakékoli požadované změny v podkladovém sešitu Excelu a poté se vrátit na odpovídající snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámce se po návratu uživatele na snímek změní a faktor změny velikosti se liší v závislosti na původních rozměrech jak OLE objektového rámce, tak vloženého sešitu Excelu.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, snaží se při první aktivaci zachovat svou původní velikost. OLE objektový rámec však má vlastní rozměry. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint si vyjednávají velikost a udržují správné proporce jako součást procesu vkládání. V závislosti na rozdílech mezi velikostí okna Excelu a velikostí nebo pozicí OLE objektového rámce dochází ke změně velikosti.

## **Řešení fungující**

Existují dva možné scénáře pro vytváření prezentací PowerPoint pomocí Aspose.Slides pro Java.

**Scénář 1:** Vytvořit prezentaci na základě existující šablony.

**Scénář 2:** Vytvořit prezentaci od nuly.

Řešení, které zde poskytujeme, platí pro oba scénáře. Základ všech přístupů řešení je stejný: **okno vloženého OLE objektu by mělo odpovídat velikosti OLE objektového rámce na snímku PowerPointu**. Nyní probereme oba přístupy k tomuto řešení.

## **První přístup**

V tomto přístupu se naučíte, jak nastavit velikost okna vloženého sešitu Excelu tak, aby odpovídala velikosti OLE objektového rámce na snímku PowerPointu.

**Scénář 1**

Předpokládejme, že máme definovanou šablonu a chceme vytvářet prezentace na jejím základě. Předpokládejme, že v šabloně je na indexu 2 tvar, kam chceme umístit OLE rámec obsahující vložený sešit Excelu. V tomto scénáři je velikost OLE objektového rámce předdefinovaná – odpovídá velikosti tvaru na indexu 2 v šabloně. Stačí nastavit velikost okna sešitu tak, aby byla stejná jako velikost tohoto tvaru. Následující úryvek kódu slouží tomuto účelu:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Nastavte šířku okna sešitu v palcích (děleno 72, protože PowerPoint používá 72 bodů na palec).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Nastavte výšku okna sešitu v palcích.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Uložte sešit do paměťového proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scénář 2**

Řekněme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excelu. V následujícím úryvku kódu vytvoříme OLE objektový rámec vysoký 4 palce a široký 9,5 palce na souřadnicích x = 0,5 palce a y = 1 palce na snímku. Poté nastavíme okno sešitu Excelu na stejnou velikost – 4 palce vysoké a 9,5 palce široké.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Požadovaná výška.
int desiredHeight = 288; // 4 palce (4 * 72)
 
// Požadovaná šířka.
int desiredWidth = 684; // 9,5 palce (9.5 * 72)
 
// Definujte velikost grafu s oknem.
chart.setSizeWithWindow(true);
 
// Nastavte šířku okna sešitu v palcích (děleno 72, protože PowerPoint používá 72 bodů na palec).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Nastavte výšku okna sešitu v palcích.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Uložte sešit do paměťového proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 palce (0.5 * 72)
    72,  // y = 1 palec (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Druhý přístup**

V tomto přístupu se naučíte, jak nastavit velikost grafu ve vloženém sešitu Excelu tak, aby odpovídala velikosti OLE objektového rámce na snímku PowerPointu. Tento přístup je užitečný, když je velikost grafu známa předem a nikdy se nezmění.

**Scénář 1**

Předpokládejme, že máme definovanou šablonu a chceme vytvářet prezentace na jejím základě. Předpokládejme, že v šabloně je na indexu 2 tvar, kam máme v úmyslu umístit OLE rámec obsahující vložený sešit Excelu. V tomto scénáři je velikost OLE rámce předdefinovaná – odpovídá velikosti tvaru na indexu 2 v šabloně. Stačí nastavit velikost grafu v sešitě tak, aby byla rovna velikosti tvaru. Následující úryvek kódu tomuto slouží:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Definujte velikost grafu bez okna.
chart.setSizeWithWindow(false);
 
// Nastavte šířku grafu v pixelech (vynásobte 96, protože Excel používá 96 pixelů na palec).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Nastavte výšku grafu v pixelech.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Definujte tiskovou velikost grafu.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Uložte sešit do paměťového proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scénář 2**:

Předpokládejme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excelu. V následujícím úryvku kódu vytvoříme OLE objektový rámec výšky 4 palce a šířky 9,5 palce na snímku na souřadnicích x = 0,5 palce a y = 1 palce. Také nastavíme odpovídající velikost grafu na stejné rozměry: výšku 4 palce a šířku 9,5 palce.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Naše požadovaná výška.
int desiredHeight = 288; // 4 palce (4 * 72)
 
// Naše požadovaná šířka.
int desiredWidth = 684; // 9,5 palce (9.5 * 72)
 
// Definujte velikost grafu bez okna.
chart.setSizeWithWindow(false);
 
// Nastavte šířku grafu v pixelech (děleno 72 pro získání palců, vynásobeno 96, protože Excel používá 96 pixelů na palec).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Nastavte výšku grafu v pixelech.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Uložte sešit do paměťového proudu.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Vytvořte OLE objektový rámec s vloženými daty Excelu.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 palce (0.5 * 72)
    72,  // y = 1 palec (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Závěr**

Existují dva přístupy k odstranění problému změny velikosti grafu. Volba přístupu závisí na požadavcích a konkrétním použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvářeny ze šablony nebo od nuly. Navíc neexistuje žádný limit velikosti OLE objektového rámce v tomto řešení.

## **Často kladené otázky**

### Proč se po aktivaci v PowerPointu změří velikost mého vloženého grafu Excelu?

K tomu dochází, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel si vyjednávají velikost tak, aby zachovaly poměr stran, což může vést ke změně velikosti.

### Je možné tomuto problému se změnou velikosti zcela předejít?

Ano. Pokud před vložením nastavíte velikost okna sešitu Excelu nebo velikost grafu tak, aby odpovídala velikosti OLE objektového rámce, můžete zachovat konstantní rozměry grafu.

### Který přístup mám zvolit, nastavení velikosti okna sešitu nebo nastavení velikosti grafu?

Použijte **Přístup 1 (velikost okna)**, pokud chcete zachovat poměr stran sešitu a případně umožnit pozdější změnu velikosti.  
Použijte **Přístup 2 (velikost grafu)**, pokud jsou rozměry grafu pevně dané a po vložení se nebudou měnit.

### Budou tyto metody fungovat jak pro prezentace založené na šabloně, tak pro nové prezentace?

Ano. Oba přístupy fungují stejně pro prezentace vytvořené ze šablon i pro nově vytvořené prezentace.

### Existuje limit velikosti OLE objektového rámce?

Ne. OLE rámec můžete nastavit na libovolnou velikost, pokud se správně škáluje k velikosti sešitu nebo grafu.

### Mohu tyto metody použít s grafy vytvořenými v jiných tabulkových programech?

Příklady jsou navrženy pro grafy Excelu vytvořené pomocí Aspose.Cells, ale principy platí i pro jiné OLE‑kompatibilní tabulkové programy, pokud podporují podobné možnosti nastavení velikosti.

## **Související sekce**

- [Vytvořit grafy Excelu a vložit je jako OLE objekty do prezentací](/slides/cs/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)