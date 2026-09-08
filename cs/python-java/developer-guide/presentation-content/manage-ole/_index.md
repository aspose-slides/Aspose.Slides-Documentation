---
title: Správa OLE v prezentacích pomocí Pythonu
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/python-java/manage-ole/
keywords:
- OLE objekt
- Propojení a vkládání objektů
- přidat OLE
- vložit OLE
- přidat objekt
- vložit objekt
- přidat soubor
- vložit soubor
- propojený objekt
- propojený soubor
- změnit OLE
- ikona OLE
- název OLE
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v PowerPointu a souborech OpenDocument pomocí Aspose.Slides pro Python prostřednictvím Javy. Vkládejte, aktualizujte a exportujte OLE obsah hladce."
---
## **Úvod**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) je technologie Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení.

{{% /alert %}}

Uvažujme graf vytvořený v MS Excel. Tento graf je poté umístěn do snímku PowerPointu. Graf z Excelu je považován za OLE objekt.

- OLE objekt se může zobrazovat jako ikona. V tomto případě se po dvojitém kliknutí na ikonu otevře graf v přidružené aplikaci (Excel) nebo jste vyzváni k výběru aplikace pro otevření či úpravu objektu.
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/cs/python-java/) umožňuje vkládat OLE objekty do snímků jako rámy OLE objektů ([OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/)).

## **Přidání rámců OLE objektů do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako rámec OLE objektu pomocí Aspose.Slides for Python via Java. Můžete tak učinit následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Načtěte soubor Excelu jako pole bajtů.
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) do snímku s polem bajtů a dalšími informacemi o OLE objektu.
5. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel na snímek jako rámec OLE objektu pomocí Aspose.Slides for Python via Java.  
**Poznámka**: Konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleembeddeddatainfo/) přijímá jako druhý parametr rozšíření vkládaného objektu. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a zvolit správnou aplikaci pro otevření tohoto OLE objektu.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Připravte data pro OLE objekt.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Přidejte rámec OLE objektu do snímku.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Přidání propojených rámců OLE objektů**

Aspose.Slides for Python via Java umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) bez vkládání dat, jen s odkazem na soubor.

Tento Python kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) s propojeným souborem Excel na snímek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidejte rámec OLE objektu s propojeným souborem Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup k rámcům OLE objektů**

Pokud je OLE objekt již vložený v snímku, můžete jej snadno najít nebo přistupovat k němu tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přistupte k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/).  
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Poté jsme ověřili, že objekt je [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/). To byl požadovaný rámec OLE objektu, ke kterému jsme chtěli přistupovat.
4. Jakmile je rámec OLE objektu přístupný, můžete na něm provádět libovolné operace.

V níže uvedeném příkladu jsou přístupny rámec OLE objektu (objekt grafu Excel vložený do snímku) a data souboru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Získat data vloženého souboru.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Získat rozšíření vloženého souboru.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Přístup k vlastnostem propojeného rámce OLE objektu**

Aspose.Slides umožňuje přistupovat k vlastnostem propojených rámců OLE objektů.

Tento Python kód ukazuje, jak zjistit, zda je OLE objekt propojený, a poté získat cestu k propojenému souboru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Zkontrolujte, zda je OLE objekt propojen.
        if ole_frame.isObjectLink():
            # Vytiskněte úplnou cestu k propojenému souboru.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Vytiskněte relativní cestu k propojenému souboru, pokud existuje.
            # Pouze prezentace PPT mohou obsahovat relativní cestu.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Změna dat OLE objektu**

{{% alert color="info" title="Note" %}}

V této sekci příklad kódu níže používá [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Pokud je OLE objekt již vložený v snímku, můžete k tomuto objektu snadno přistupovat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přistupte k tvaru rámce OLE objektu.  
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Poté jsme ověřili, že objekt je [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/). To byl požadovaný rámec OLE objektu, ke kterému jsme chtěli přistupovat.
4. Jakmile je rámec OLE objektu přístupný, můžete na něm provádět libovolné operace.
5. Vytvořte objekt [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) a přistupte k OLE datům.
6. Přistupte k požadovanému [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) a upravte data.
7. Uložte aktualizovaný [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přístup k rámci OLE objektu (objekt grafu Excel vložený do snímku) a jeho souborová data jsou upravena tak, aby se aktualizovala data grafu.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Načtěte data OLE objektu jako objekt Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Upravte data sešitu.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Změňte data objektu OLE rámce.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vkládání dalších typů souborů do snímků**

Kromě grafů Excel umožňuje Aspose.Slides for Python via Java vložit do snímků i jiné typy souborů. Například můžete vložit HTML, PDF a ZIP soubory jako objekty. Když uživatel dvojitě klikne na vložený objekt, otevře se automaticky v příslušném programu, nebo je vyzván k výběru vhodného programu pro jeho otevření.

Tento Python kód ukazuje, jak vložit HTML a ZIP do snímku:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Python via Java umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data rámce OLE nebo jeho rozšíření.

Tento Python kód ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Změňte typ souboru na ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení ikon a titulků pro vložené objekty**

Po vložení OLE objektu je automaticky přidáno náhledové zobrazení sestávající z ikony. Tento náhled vidí uživatelé před tím, než objekt otevřou nebo přistoupí k němu. Pokud chcete v náhledu použít konkrétní obrázek a text, můžete nastavit ikonu a název pomocí Aspose.Slides for Python via Java.

Tento Python kód ukazuje, jak nastavit ikonu a titulek pro vložený objekt:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Přidejte obrázek do zdrojů prezentace.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Nastavte název a obrázek pro náhled OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zabránění změně velikosti a umístění rámce OLE objektu**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření prezentace v PowerPointu může zobrazit zpráva s výzvou k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a polohu rámce OLE objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled. Chcete‑li zabránit výzvě k aktualizaci dat objektu, nastavte metodu [setUpdateAutomatic](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) třídy [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) na `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extrahování vložených souborů**

Aspose.Slides for Python via Java umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) obsahující OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a přistupte k tvarům [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/).
3. Přistupte k datům vložených souborů z rámců OLE objektů a zapište je na disk.

Tento Python kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Bude obsah OLE objektu vykreslen při exportu snímků do PDF/obrázků?**

To, co je viditelné na snímku, se vykreslí – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není při vykreslování proveden. V případě potřeby nastavte vlastní náhledový obrázek, aby exportovaný PDF vypadal podle očekávání.

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli přesouvat/upravovat v PowerPointu?**

Uzamkněte tvar: Aspose.Slides poskytuje [shape-level locks](/slides/cs/python-java/applying-protection-to-presentation/). Nejde o šifrování, ale účinně zabraňuje nechtěným úpravám a přesouvání.

**Proč se propojený Excel objekt „přeskočí“ nebo změní velikost, když otevřu prezentaci?**

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled postupujte podle [Working Solution for Worksheet Resizing](/slides/cs/python-java/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah do pevného rámce a nastavte vhodný náhradní obrázek.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**

V PPTX nejsou informace o „relativní cestě“ k dispozici – je uložen jen úplný (absolutní) popis. Relativní cesty jsou dostupné jen ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/URI nebo vkládání.