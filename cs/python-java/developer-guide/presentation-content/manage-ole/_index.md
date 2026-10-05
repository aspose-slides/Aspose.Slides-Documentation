---
title: Správa OLE v prezentacích pomocí Pythonu
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/python-java/manage-ole/
keywords:
- OLE objekt
- Objektové propojení a vložení
- přidat OLE
- vložit OLE
- přidat objekt
- vložit objekt
- přidat soubor
- vložit soubor
- propojený objekt
- propojený soubor
- změnit OLE
- OLE ikona
- OLE titul
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides for Python via Java. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) je technologie Microsoftu, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení.
{{% /alert %}}

Zvažte graf vytvořený v MS Excel. Tento graf je poté umístěn do snímku PowerPointu. Tento Excel graf je považován za OLE objekt.

- OLE objekt se může zobrazovat jako ikona. V takovém případě se po dvojitém kliknutí na ikonu graf otevře v přidružené aplikaci (Excel) nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu.
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) umožňuje vkládat OLE objekty do snímků jako OLE objektové rámy ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)).

## **Přidání OLE objektových rámců do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides for Python via Java, můžete tak učinit tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přečtěte soubor Excel jako pole bajtů.
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) do snímku, který obsahuje pole bajtů a další informace o OLE objektu.
5. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako OLE objektový rámec pomocí Aspose.Slides for Python via Java. **Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) přijímá rozšíření vkládaného objektu jako svůj druhý parametr. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a zvolit správnou aplikaci pro otevření tohoto OLE objektu.

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

    # Připravit data pro OLE objekt.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Přidat OLE objektový rámec do snímku.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Přidání propojených OLE objektových rámců**

Aspose.Slides for Python via Java umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) s odkazem na soubor místo vložených dat.

Tento Python kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) s propojeným souborem Excel do snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidat OLE objektový rámec s propojeným souborem Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte přístup k tvaru [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/).
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar.  Poté jsme ověřili, že objekt je [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). To byl požadovaný OLE objektový rámec, ke kterému jsme chtěli získat přístup.
4. Jakmile je OLE objektový rámec získán, můžete na něm provádět libovolné operace.

V níže uvedeném příkladu je získán OLE objektový rámec (objekt grafu Excel vložený do snímku) a jeho souborová data.

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
        # Získat příponu vloženého souboru.
        # ...

finally:
    presentation.dispose()
```

### **Přístup k vlastnostem propojeného OLE objektového rámce**

Aspose.Slides umožňuje přístup k vlastnostem propojených OLE objektových rámců.

Tento Python kód ukazuje, jak zkontrolovat, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

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

        # Zkontrolovat, zda je OLE objekt propojen.
        if ole_frame.isObjectLink():
            # Vytisknout úplnou cestu k propojenému souboru.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Vytisknout relativní cestu k propojenému souboru, pokud existuje.
            # Pouze prezentace PPT mohou obsahovat relativní cestu.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Změna dat OLE objektu**

{{% alert color="info" title="Note" %}}
V této sekci níže uvedený ukázkový kód používá [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete k objektu snadno přistupovat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte přístup k tvaru OLE objektového rámce.
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Poté jsme ověřili, že objekt je [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). To byl požadovaný OLE objektový rámec, ke kterému jsme chtěli získat přístup.
4. Jakmile je OLE objektový rámec získán, můžete na něm provádět libovolné operace.
5. Vytvořte objekt [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) a získejte přístup k OLE datům.
6. Získejte přístup k požadovanému [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) a upravte data.
7. Uložte aktualizovaný [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je získán OLE objektový rámec (objekt grafu Excel vložený do snímku) a jeho souborová data jsou upravena tak, aby aktualizovala data grafu.

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

        # Načíst data OLE objektu jako objekt Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Upravit data sešitu.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Změnit data objektu OLE rámce.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vkládání jiných typů souborů do snímků**

Kromě grafů Excel umožňuje Aspose.Slides for Python via Java vkládat do snímků i jiné typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvakrát klikne na vložený objekt, automaticky se otevře v příslušném programu, nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.

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

Při práci s prezentacemi může být nutné nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Python via Java umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámce nebo jeho rozšíření.

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

    # Změnit typ souboru na ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení ikon a nadpisů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete v náhledu použít konkrétní obrázek a text, můžete nastavit ikonu a nadpis pomocí Aspose.Slides for Python via Java.

Tento Python kód ukazuje, jak nastavit obrázek ikony a nadpis pro vložený objekt:

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

    # Přidat obrázek do zdrojů prezentace.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Nastavit název a obrázek pro OLE náhled.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zabránění změně velikosti a přesunu OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření prezentace v PowerPointu může zobrazit zpráva s výzvou k aktualizaci odkazů. Kliknutím na tlačítko “Update Links” (Aktualizovat odkazy) se může změnit velikost a pozice OLE objektového rámce, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Aby PowerPoint nevyzýval k aktualizaci dat objektu, zavolejte metodu [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) třídy [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) s hodnotou `False`:

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

Aspose.Slides for Python via Java umožňuje tímto způsobem extrahovat soubory vložené do snímků jako OLE objekty:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), která obsahuje OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a získejte přístup k tvarům [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/).
3. Získejte data vložených souborů z OLE objektových rámců a zapište je na disk.

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

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

Na snímku se vykreslí to, co je viditelné – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah se během vykreslování nespouští. V případě potřeby nastavte vlastní náhledový obrázek, aby se v exportovaném PDF zobrazoval očekávaný vzhled. Pro zachování vloženého souboru také jako PDF přílohu zavolejte [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) s hodnotou `True`. Tato volba je ve výchozím nastavení vypnutá. Pro příklad a instrukce, jak zkontrolovat přílohu, viz [Preserve Embedded OLE Files as PDF Attachments](/slides/cs/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mohu zamknout OLE objekt na snímku, aby uživatelé nemohli pohybovat nebo jej upravovat v PowerPointu?**

Zamkněte tvar: Aspose.Slides poskytuje [shape-level locks](/slides/cs/python-java/applying-protection-to-presentation/). Nejedná se o šifrování, ale účinně zabraňuje neúmyslným úpravám a přesunutí.

**Proč se propojený Excel objekt „přesouvá“ nebo mění velikost, když otevřu prezentaci?**

PowerPoint může obnovením náhledu propojeného OLE objektu způsobit změnu. Pro stabilní vzhled se řiďte postupy v [Working Solution for Worksheet Resizing](/slides/cs/python-java/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo přizpůsobte rozsah pevně danému rámci a nastavte vhodný náhradní obrázek.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány ve formátu PPTX?**

V PPTX není informace o „relativní cestě“ dostupná – pouze úplná cesta. Relativní cesty se vyskytují ve starším formátu PPT. Pro přenositelnost upřednostňujte spolehlivé absolutní cesty/přístupné URI nebo vkládání.