---
title: Správa OLE v prezentacích pomocí Pythonu
linktitle: Správa OLE
type: docs
weight: 40
url: /cs/python-net/manage-ole/
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
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v PowerPointu a souborech OpenDocument pomocí Aspose.Slides pro Python via .NET. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** je technologie společnosti Microsoft, která umožňuje propojit nebo vložit data a objekty vytvořené v jedné aplikaci do jiné.

{{% /alert %}}

Například graf vytvořený v Microsoft Excelu a umístěný na snímku PowerPointu je OLE objektem.

- OLE objekt se může zobrazovat jako ikona. Dvojklikem na ikonu se objekt otevře v přidružené aplikaci (např. Excel) nebo se zobrazí výzva k výběru aplikace pro otevření či úpravu.
- OLE objekt může zobrazovat svůj obsah (například graf). V tomto případě PowerPoint aktivuje vložený objekt, načte rozhraní grafu a umožní upravit data grafu přímo v PowerPointu.

Aspose.Slides for Python vám umožňuje vkládat OLE objekty do snímků jako OLE objektové rámy ([OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/)).

## **Přidání OLE objektů do snímků**

Pokud jste již vytvořili graf v Microsoft Excelu a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides for Python, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Načtěte soubor Excel do pole bajtů.
1. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/) do snímku a předáte pole bajtů a další podrobnosti OLE objektu.
1. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu je graf ze souboru Excel vložen do snímku jako [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/).

**Poznámka:** Konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) přijímá jako druhý parametr příponu souboru vkládaného objektu. PowerPoint tuto příponu používá k identifikaci typu souboru a výběru vhodné aplikace pro otevření OLE objektu.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Připravte data pro OLE objekt.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Přidejte OLE objektový rámec do snímku.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Přidání propojených OLE objektů**

Aspose.Slides for Python vám umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/), který odkazuje na soubor místo vkládání jeho dat.

Níže uvedený Python příklad ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/) propojený na soubor Excel na snímku:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte OLE objektový rámec s propojeným souborem Excel.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k OLE objektům**

Pokud je OLE objekt již vložen do snímku, můžete k němu přistoupit následujícím způsobem:

1. Načtěte prezentaci, která obsahuje vložený OLE objekt, vytvořením instance třídy Presentation.
1. Získejte odkaz na snímek podle jeho indexu.
1. Přistupte k tvaru OleObjectFrame.
1. Jakmile máte OLE objektový rámec, proveďte požadované operace.

Níže uvedený příklad přistupuje k OLE objektovému rámci – vloženému Excel grafu – a načte jeho souborová data. V tomto příkladu používáme PPTX, který má na první snímku jediný tvar.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Získejte vložená data souboru.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Získejte příponu vloženého souboru.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Přístup k vlastnostem propojeného OLE objektu**

Aspose.Slides umožňuje přístup k vlastnostem rámce propojeného OLE objektu.

Python příklad níže kontroluje, zda je OLE objekt propojen, a pokud ano, získá cestu k propojenému souboru:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Zkontrolujte, zda je OLE objekt propojen.
        if ole_frame.is_object_link:
            # Vytiskněte úplnou cestu k propojenému souboru.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Vytiskněte relativní cestu k propojenému souboru, pokud existuje.
            # Pouze prezentace .ppt mohou obsahovat relativní cestu.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Změna dat OLE objektu**

{{% alert color="primary" %}}

V této sekci ukázkový kód používá [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete k němu přistoupit a upravit jeho data následujícím způsobem:

1. Načtěte prezentaci vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte cílový snímek podle jeho indexu.
1. Přistupte k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/).
1. Jakmile máte OLE objektový rámec, proveďte požadované operace.
1. Vytvořte objekt `Workbook` a načtěte OLE data.
1. Otevřete požadovaný `Worksheet` a upravte data.
1. Uložte aktualizovaný `Workbook` do proudu.
1. Nahraďte data OLE objektu pomocí tohoto proudu.

V níže uvedeném příkladu je OLE objektový rámec (vložený Excel graf) přístupný a jeho souborová data jsou upravena tak, aby se aktualizoval graf. Vzorek používá dříve vytvořený PPTX, který obsahuje na první snímku jediný tvar.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Načtěte data OLE objektu jako objekt Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Upravte data sešitu.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Změňte data objektu OLE rámce.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vkládání souborů do snímků**

Kromě Excel grafů vám Aspose.Slides for Python umožňuje vložit do snímků i jiné typy souborů. Například můžete vložit HTML, PDF a ZIP soubory jako objekty. Když uživatel dvojklikne vložený objekt, otevře se automaticky v přidružené aplikaci, nebo bude vyzván k výběru vhodného programu.

Tento Python kód ukazuje, jak vložit HTML a ZIP soubory do snímku:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo vyměnit nepodporovaný OLE objekt za podporovaný. Aspose.Slides for Python vám umožňuje nastavit typ souboru vloženého objektu, což vám umožní aktualizovat data rámce OLE nebo jeho příponu souboru.

Tento Python kód ukazuje, jak nastavit typ souboru vloženého OLE objektu na `zip`:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Změňte typ souboru na ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení ikon a názvů pro vložené objekty**

Po vložení OLE objektu je automaticky přidán náhled založený na ikonce. Tento náhled je to, co uživatelé vidí před tím, než objekt otevřou nebo k němu přistoupí. Pokud chcete použít konkrétní obrázek a text v náhledu, můžete nastavit ikonu a název pomocí Aspose.Slides for Python.

Tento Python kód ukazuje, jak nastavit ikonu a název pro vložený objekt:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Přidejte obrázek do zdrojů prezentace.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Nastavte název a obrázek pro náhled OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zabránění změnám velikosti a pozice OLE objektových rámců**

Po přidání propojeného OLE objektu do snímku může PowerPoint při otevření prezentace požadovat aktualizaci odkazů. Volba „Update Links“ může změnit velikost a pozici OLE objektového rámce, protože PowerPoint obnoví náhled pomocí dat z propojeného objektu. Chcete‑li zabránit výzvě k aktualizaci dat objektu, nastavte vlastnost `update_automatic` třídy [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/) na `False`:

```py
ole_frame.update_automatic = False
```

## **Extrahování vložených souborů**

Aspose.Slides for Python vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), která obsahuje OLE objekty, jež chcete extrahovat.
1. Projděte všechny tvary v prezentaci a vyhledejte tvary typu OLEObjectFrame.
1. Získejte vložená data souboru z každého [OLEObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/) a zapište je na disk.

Níže uvedený Python kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **Často kladené otázky**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

Na snímku se vykreslí to, co je viditelné – ikona/substituční obrázek (náhled). „Živý“ OLE obsah se během vykreslování neprovádí. Pokud je potřeba, nastavte vlastní obrázek náhledu, aby exportovaný PDF vypadal podle očekávání.

**Jak mohu uzamknout OLE objekt na snímku, aby uživatelé nemohli v PowerPointu objekt přesouvat/upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje [shape-level locks](/slides/cs/python-net/applying-protection-to-presentation/). Nejde o šifrování, ale účinně to brání náhodným úpravám a přesouvání.

**Proč se propojený Excel objekt „posune“ nebo změní velikost při otevření prezentace?**

PowerPoint může obnovit náhled propojeného OLE. Pro stabilní vzhled dodržujte postupy z [Working Solution for Worksheet Resizing](/slides/cs/python-net/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah na pevný rámec a nastavte vhodný substituční obrázek.

**Budou v PPTX formátu zachovány relativní cesty k propojeným OLE objektům?**

V PPTX není informace o „relativní cestě“ dostupná – jen úplná cesta. Relativní cesty jsou k dispozici jen ve starším formátu PPT. Pro přenositelnost upřednostňujte spolehlivé absolutní cesty/přístupné URI nebo vkládání.