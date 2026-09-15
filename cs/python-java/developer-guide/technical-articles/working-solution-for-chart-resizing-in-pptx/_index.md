---
title: Pracovní řešení pro změnu velikosti grafu v PPTX
type: docs
weight: 40
url: /cs/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- změna velikosti grafu
- graf Excel
- OLE objekt
- vložit graf
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Opravte neočekávanou změnu velikosti grafu v PPTX při použití vložených OLE objektů Excel s Aspose.Slides for Python via Java. Naučte se dvě metody s kódem pro zachování konzistentních rozměrů."
---
## **Pozadí**

Bylo zaznamenáno, že grafy Excelu vložené jako OLE objekty v prezentaci PowerPoint pomocí komponent Aspose jsou po své první aktivaci změněny na neurčité měřítko. Toto chování způsobuje výrazný vizuální rozdíl v prezentaci mezi stavem grafu před a po aktivaci. Tým Aspose problém podrobně prošetřil a našel řešení. Tento článek popisuje příčiny problému a odpovídající opravu.

V [previous article](/slides/cs/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) jsme vysvětlili, jak vytvořit graf Excelu pomocí Aspose.Cells for Python via Java a vložit ho do prezentace PowerPoint pomocí Aspose.Slides for Python via Java. K řešení [object preview issue](/slides/cs/python-java/object-preview-issue-when-adding-oleobjectframe/) jsme přiřadili obrázek grafu k OLE objektovému rámci grafu. V výstupní prezentaci, když dvakrát kliknete na OLE objektový rámec zobrazující obrázek grafu, aktivuje se graf Excelu. Koncoví uživatelé mohou provádět požadované změny v podkladovém sešitu Excel a poté se vrátit na odpovídající snímek kliknutím mimo aktivovaný sešit. Velikost OLE objektového rámce se změní, když se uživatel vrátí na snímek, a faktor změny velikosti se liší v závislosti na původních velikostech jak OLE objektového rámce, tak vloženého sešitu Excel.

## **Příčina změny velikosti**

Protože má sešit Excelu vlastní velikost okna, pokouší se při první aktivaci zachovat svou původní velikost. OLE objektový rámec má však svou vlastní velikost. Podle Microsoftu, když je sešit Excelu aktivován, Excel a PowerPoint vyjednávají velikost a udržují správné proporce jako součást procesu vkládání. V závislosti na rozdílech mezi velikostí okna Excelu a velikostí nebo polohou OLE objektového rámce dochází k změně velikosti.

## **Funkční řešení**

Existují dva možné scénáře pro vytváření prezentací PowerPoint pomocí Aspose.Slides for Python via Java.

**Scenario 1:** Vytvořit prezentaci na základě existující šablony.  
**Scenario 2:** Vytvořit prezentaci od nuly.

Řešení, které zde poskytujeme, platí pro oba scénáře. Základ všech přístupů k řešení je stejný: **velikost okna vloženého OLE objektu by měla odpovídat OLE objektovému rámci na snímku PowerPoint**. Nyní probereme dva přístupy k tomuto řešení.

## **První přístup**

V tomto přístupu se naučíme, jak nastavit velikost okna vloženého sešitu Excel tak, aby odpovídala velikosti OLE objektového rámce na snímku PowerPoint.

**Scenario 1**

Předpokládejme, že jsme definovali šablonu a chceme na jejím základě vytvářet prezentace. Předpokládejme, že v šabloně je na indexu 2 tvar, do kterého chceme umístit OLE rámec obsahující vložený sešit Excel. V tomto scénáři je velikost OLE objektového rámce předdefinována – odpovídá velikosti tvaru na indexu 2 v šabloně. Stačí nastavit velikost okna sešitu na velikost tohoto tvaru. Následující útržek kódu slouží k tomuto účelu:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Načtěte sešit Excel obsahující graf.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Nastavte velikost okna sešitu v palcích (PowerPoint používá 72 bodů na palec).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # Uložte sešit do paměťového proudu.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Vytvořte OLE objektový rámec s vloženými daty Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

Předpokládejme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excel. V následujícím útržku kódu vytvoříme OLE objektový rámec vysoký 4 palce a široký 9,5 palce na souřadnicích x = 0,5 palce a y = 1 palce na snímku. Pak nastavíme okno sešitu Excel na stejnou velikost – 4 palce vysoké a 9,5 palce široké.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Načtěte sešit Excel obsahující graf.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 palce (4 * 72).
    desired_width = 684  # 9.5 palce (9.5 * 72).

    # Definujte velikost grafu s oknem.
    chart.setSizeWithWindow(True)

    # Nastavte velikost okna sešitu v palcích (PowerPoint používá 72 bodů na palec).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # Uložte sešit do paměťového proudu.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Vytvořte OLE objektový rámec s vloženými daty Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Druhý přístup**

V tomto přístupu se naučíme, jak nastavit velikost grafu v vloženém sešitu Excel tak, aby odpovídala velikosti OLE objektového rámce na snímku PowerPoint. Tento přístup je užitečný, když je velikost grafu známa předem a nikdy se nezmění.

**Scenario 1**

Předpokládejme, že jsme definovali šablonu a chceme na jejím základě vytvářet prezentace. Předpokládejme, že v šabloně je na indexu 2 tvar, do kterého zamýšlíme umístit OLE rámec s vloženým sešitem Excel. V tomto scénáři je velikost OLE rámce předdefinována – odpovídá velikosti tvaru na indexu 2 v šabloně. Stačí nastavit velikost grafu v sešitu tak, aby se rovná velikosti tohoto tvaru. Následující útržek kódu slouží k tomuto účelu:

```python
import jpide
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Načtěte sešit Excel obsahující graf.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # Definujte velikost grafu bez okna.
    chart.setSizeWithWindow(False)

    # Nastavte velikost grafu v pixelech (Excel používá 96 pixelů na palec).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # Definujte velikost tisku grafu.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # Uložte sešit do paměťového proudu.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Vytvořte OLE objektový rámec s vloženými daty Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

Předpokládejme, že chceme vytvořit prezentaci od nuly a zahrnout OLE objektový rámec libovolné velikosti s vloženým sešitem Excel. V následujícím útržku kódu vytvoříme OLE objektový rámec s výškou 4 palce a šířkou 9,5 palce na snímku na souřadnicích x = 0,5 palce a y = 1 palce. Také nastavíme odpovídající velikost grafu na stejné rozměry: výšku 4 palce a šířku 9,5 palce.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# Načtěte sešit Excel obsahující graf.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 palce (4 * 72).
    desired_width = 684  # 9.5 palce (9.5 * 72).

    # Definujte velikost grafu bez okna.
    chart.setSizeWithWindow(False)

    # Nastavte velikost grafu v pixelech (Excel používá 96 pixelů na palec).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # Uložte sešit do paměťového proudu.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # Vytvořte OLE objektový rámec s vloženými daty Excel.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **Závěr**

Existují dva přístupy k vyřešení problému se změnou velikosti grafu. Volba přístupu závisí na požadavcích a konkrétním použití. Oba přístupy fungují stejně, ať už jsou prezentace vytvořeny ze šablony nebo od nuly. Navíc v tomto řešení neexistuje žádný limit velikosti OLE objektového rámce.

## **Často kladené otázky**

**Proč se vložený graf Excelu po aktivaci v PowerPointu změní velikost?**  
K tomu dochází, protože Excel se při první aktivaci snaží obnovit původní velikost okna, zatímco OLE objektový rámec v PowerPointu má své vlastní rozměry. PowerPoint a Excel vyjednávají velikost, aby zachovaly poměr stran, což může způsobit změnu velikosti.

**Je možné tomuto problému se změnou velikosti zcela předejít?**  
Ano. Pokud před vložením nastavíte velikost okna sešitu Excel nebo velikost grafu tak, aby odpovídala velikosti OLE objektového rámce, můžete udržet velikosti grafů konzistentní.

**Jaký přístup mám zvolit, nastavení velikosti okna sešitu nebo nastavení velikosti grafu?**  
Použijte **Approach 1 (window size)**, pokud chcete zachovat poměr stran sešitu a případně umožnit pozdější změnu velikosti.  
Použijte **Approach 2 (chart size)**, pokud jsou rozměry grafu pevně dané a po vložení se nebudou měnit.

**Bude tato metoda fungovat jak u prezentací založených na šabloně, tak u nových prezentací?**  
Ano. Oba přístupy fungují stejně pro prezentace vytvořené ze šablon i od nuly.

**Existuje limit velikosti OLE objektového rámce?**  
Ne. Můžete nastavit OLE rámec na libovolnou velikost, pokud se správně škáluje k velikosti sešitu nebo grafu.

**Mohu tyto metody použít s grafy vytvořenými v jiných tabulkových programech?**  
Příklady jsou určeny pro grafy Excel vytvořené pomocí Aspose.Cells, ale principy platí i pro jiné OLE‑kompatibilní tabulkové programy, pokud podporují podobné možnosti nastavení velikosti.

## **Související sekce**

- [Vytvořit grafy Excel a vložit je jako OLE objekty do prezentací](/slides/cs/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)