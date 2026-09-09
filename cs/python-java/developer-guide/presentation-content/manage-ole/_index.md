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
- OLE ikona
- OLE název
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v PowerPoint a OpenDocument souborech pomocí Aspose.Slides for Python via Java. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert color="info" title="Poznámka" %}}

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení.

{{% /alert %}}

Uvažujme o grafu vytvořeném v MS Excel. Tento graf je poté umístěn v snímku PowerPointu. Tento Excel graf se považuje za OLE objekt.

- OLE objekt se může zobrazovat jako ikona. V takovém případě, když na ikonu dvojkliknete, otevře se graf v přidružené aplikaci (Excel), nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu.
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/cs/python-java/) umožňuje vkládat OLE objekty do snímků jako OLE objektové rámce ([OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/)).

## **Přidat OLE objektové rámce do snímků**

Za předpokladu, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides for Python via Java, můžete to provést tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přečtěte soubor Excel jako pole bajtů.
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) do snímku, který obsahuje pole bajtů a další informace o OLE objektu.
5. Napište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako OLE objektový rámec pomocí Aspose.Slides for Python via Java.  
**Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleembeddeddatainfo/) přijímá rozšíření vkládaného objektu jako svůj druhý parametr. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

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

    # Přidejte OLE objektový rámec do snímku.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Přidat propojené OLE objektové rámce**

Aspose.Slides for Python via Java umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/), který obsahuje odkaz na soubor místo vložených dat.

Tento Python kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) s odkazem na soubor Excel, do snímku:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidejte OLE objektový rámec s propojeným souborem Excel.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přistupte k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Poté jsme ověřili, že objekt je [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/). To byl požadovaný OLE objektový rámec, který měl být přístupný.
4. Jakmile je OLE objektový rámec přístupný, můžete na něm provádět jakékoli operace.

V níže uvedeném příkladu je přístup k OLE objektovému rámci (objekt grafu Excel vložený do snímku) a k jeho datům souboru.

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

        # Získejte data vloženého souboru.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Získejte příponu vloženého souboru.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Přístup k vlastnostem propojeného OLE objektového rámce**

Aspose.Slides umožňuje přístup k vlastnostem propojených OLE objektových rámců.

Tento Python kód ukazuje, jak zkontrolovat, zda je OLE objekt propojený, a poté získat cestu k propojenému souboru:

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

            # Vytiskněte relativní cestu k propojenému souboru, pokud je k dispozici.
            # Pouze prezentace PPT mohou obsahovat relativní cestu.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Změna dat OLE objektu**

{{% alert color="info" title="Poznámka" %}}

V této sekci ukázkový kód níže používá [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete k němu snadno přistoupit a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přistupte k OLE objektovému rámci. V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Poté jsme ověřili, že objekt je [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/). To byl požadovaný OLE objektový rámec, který měl být přístupný.
4. Jakmile je OLE objektový rámec přístupný, můžete na něm provádět jakékoli operace.
5. Vytvořte objekt [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) a přistupte k OLE datům.
6. Přistupte k požadovanému [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) a upravte data.
7. Uložte aktualizovaný [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přístup k OLE objektovému rámci (objekt grafu Excel vložený do snímku) a jeho data souboru jsou upravena pro aktualizaci dat grafu.

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

## **Vložení dalších typů souborů do snímků**

Kromě grafů Excel umožňuje Aspose.Slides for Python via Java vložit do snímků i další typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvojklikne na vložený objekt, automaticky se otevře v příslušném programu, nebo je vyzván k výběru vhodného programu pro otevření.

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

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for Python via Java umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data OLE rámce nebo jeho rozšíření.

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

## **Nastavení obrázků ikon a názvů pro vložené objekty**

Po vložení OLE objektu je automaticky přidán náhled sestávající z obrázku ikony. Tento náhled vidí uživatelé před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako prvky v náhledu, můžete nastavit obrázek ikony a název pomocí Aspose.Slides for Python via Java.

Tento Python kód ukazuje, jak nastavit obrázek ikony a název pro vložený objekt:

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

## **Zabránit změně velikosti a přesunu OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření prezentace v PowerPointu může zobrazit zpráva, která požaduje aktualizaci odkazů. Kliknutím na tlačítko „Update Links“ může dojít ke změně velikosti a umístění OLE objektového rámce, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnovuje náhled objektu. Chcete‑li zabránit výzvě PowerPointu k aktualizaci dat objektu, nastavte metodu [setUpdateAutomatic](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) třídy [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) na `False`:

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

## **Extrahovat vložené soubory**

Aspose.Slides for Python via Java umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) obsahující OLE objekty, které chcete extrahovat.
2. Procházejte všechny tvary v prezentaci a přistupujte k tvarům [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/).
3. Přistupujte k datům vložených souborů z OLE objektových rámců a zapisujte je na disk.

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

## **FAQ**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

To, co je na snímku viditelné, je vykresleno – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není během vykreslování prováděn. V případě potřeby nastavte vlastní obrázek náhledu, aby se zajistil očekávaný vzhled v exportovaném PDF.

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli přesouvat/upravovat v PowerPointu?**

Uzamkněte tvar: Aspose.Slides poskytuje [zámky na úrovni tvaru](/slides/cs/python-java/applying-protection-to-presentation/). Není to šifrování, ale efektivně zabraňuje neúmyslným úpravám a přesunu.

**Proč se propojený Excel objekt při otevření prezentace „posune“ nebo změní velikost?**

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled postupujte podle praktik [Working Solution for Worksheet Resizing](/slides/cs/python-java/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah na pevný rámec a nastavte vhodný náhradní obrázek.

**Zůstanou relativní cesty pro propojené OLE objekty zachovány v formátu PPTX?**

V PPTX nejsou informace o „relativní cestě“ k dispozici – je k dispozici jen úplná cesta. Relativní cesty jsou v starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vkládání.