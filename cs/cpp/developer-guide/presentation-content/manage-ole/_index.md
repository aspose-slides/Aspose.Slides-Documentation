---
title: Správa OLE v prezentacích pomocí C++
linktitle: Spravovat OLE
type: docs
weight: 40
url: /cs/cpp/manage-ole/
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
- C++
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v PowerPoint a OpenDocument souborech pomocí Aspose.Slides pro C++. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) je technologie společnosti Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení. 

{{% /alert %}} 

Zvažte graf vytvořený v MS Excel. Tento graf je poté umístěn na snímek v PowerPointu. Tento Excel graf je považován za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V takovém případě po dvojitém kliknutí na ikonu se graf otevře v přidružené aplikaci (Excel) nebo budete vyzváni k výběru aplikace pro otevření nebo úpravu objektu.  
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.  

[Aspose.Slides for C++](https://products.aspose.com/slides/cs/cpp/) umožňuje vkládat OLE objekty do snímků jako rámy OLE objektů ([OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/)).

## **Přidání rámců OLE objektů do snímků**

Předpokládejme, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako rámec OLE objektu pomocí Aspose.Slides for C++. Můžete tak učinit následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Přečtěte soubor Excelu jako pole bajtů.
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) na snímek, který obsahuje pole bajtů a další informace o OLE objektu.
5. Uložte upravenou prezentaci jako soubor PPTX.

V ukázce níže jsme přidali graf ze souboru Excel do snímku jako [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) pomocí Aspose.Slides for C++.  
**Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) přijímá rozšíření vložitelného objektu jako druhý parametr. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a vybrat správnou aplikaci pro otevření tohoto OLE objektu.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Připravte data pro OLE objekt.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Přidejte rámec OLE objektu do snímku.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Přidání propojených rámců OLE objektů**

Aspose.Slides for C++ umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) bez vložení dat, pouze s odkazem na soubor.

Tento C++ kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) s odkazem na Excel soubor do snímku:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Přidejte rámec OLE objektu s propojeným souborem Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Přístup k rámcům OLE objektů**

Pokud je OLE objekt již vložený ve snímku, můžete jej snadno najít nebo získat takto:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Získejte tvar [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jediný tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/). To byl požadovaný rámec OLE objektu, ke kterému jsme chtěli přistupovat.
4. Jakmile je rámec OLE objektu získán, můžete na něm provádět libovolné operace.

V příkladu níže jsou získány rámec OLE objektu (graf Excel vložený do snímku) a data souboru.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Získat data vloženého souboru.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // Získat příponu vloženého souboru.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **Přístup k vlastnostem propojeného rámce OLE objektu**

Aspose.Slides umožňuje přistupovat k vlastnostem propojených rámců OLE objektu.

Tento C++ kód ukazuje, jak zkontrolovat, zda je OLE objekt propojený, a následně získat cestu k propojenému souboru:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Zkontrolujte, zda je OLE objekt propojen.
    if (oleFrame->get_IsObjectLink())
    {
        // Vytiskněte úplnou cestu k propojenému souboru.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Vytiskněte relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Změna dat OLE objektu**

{{% alert color="primary" %}} 

V této sekci níže uvedený ukázkový kód používá [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Pokud je OLE objekt již vložený ve snímku, můžete k tomuto objektu snadno přistoupit a upravit jeho data takto:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) .
2. Získejte odkaz na snímek podle jeho indexu. 
3. Získejte tvar [OLEObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jediný tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/). To byl požadovaný rámec OLE objektu, ke kterému jsme chtěli přistupovat.
4. Jakmile je rámec OLE objektu získán, můžete na něm provádět libovolné operace.
5. Vytvořte objekt `Workbook` a získejte OLE data.
6. Získejte požadovaný `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu z proudu.

V příkladu níže je získán rámec OLE objektu (graf Excel vložený do snímku) a jeho souborová data jsou upravena tak, aby aktualizovala data grafu.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Získat první tvar jako rámec OLE objektu.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Načíst data OLE objektu jako objekt Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Upravit data workbooku.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // Změnit data objektu OLE rámce.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Vložení jiných typů souborů do snímků**

Kromě grafů Excelu Aspose.Slides for C++ umožňuje vložit do snímků i další typy souborů. Například můžete vložit HTML, PDF a ZIP soubory jako objekty. Když uživatel dvojklikne na vložený objekt, automaticky se otevře v odpovídajícím programu nebo je uživatel vyzván k výběru vhodného programu pro otevření.

Tento C++ kód ukazuje, jak vložit HTML a ZIP do snímku:

``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení typů souborů pro vložené objekty**

Při práci s prezentacemi můžete potřebovat nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for C++ umožňuje nastavit typ souboru pro vložený objekt, což vám umožní aktualizovat data rámce OLE nebo jeho rozšíření.

Tento C++ kód ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Změnit typ souboru na ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nastavení ikonových obrázků a titulů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete použít konkrétní obrázek a text jako součást náhledu, můžete pomocí Aspose.Slides for C++ nastavit ikonu a titulek.

Tento C++ kód ukazuje, jak nastavit ikonu a titulek pro vložený objekt: 

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Přidat obrázek do zdrojů prezentace.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Nastavit titulek a obrázek pro náhled OLE.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zabránění změně velikosti a pozicování rámce OLE objektu**

Po přidání propojeného OLE objektu do snímku prezentace se při otevření prezentace v PowerPointu může zobrazit výzva k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a umístění rámce OLE objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Aby PowerPoint nevyzýval k aktualizaci dat objektu, nastavte metodě `set_UpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/) hodnotu `false`:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **Extrahování vložených souborů**

Aspose.Slides for C++ umožňuje extrahovat soubory vložené do snímků jako OLE objekty tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) obsahující OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a získávejte tvary [OLEObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/).
3. Získejte data vložených souborů z rámců OLE objektu a zapište je na disk.

Tento C++ kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **Často kladené otázky**

**Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?**

To, co je na snímku viditelné, je vykresleno – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah se během renderování neprovádí. V případě potřeby nastavte vlastní obrázek náhledu, aby se zajistil očekávaný vzhled v exportovaném PDF.

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat/upravovat?**

Uzamkněte tvar: Aspose.Slides poskytuje [shape-level locks](/slides/cs/cpp/applying-protection-to-presentation/). Nejde o šifrování, ale účinně zabraňuje nechtěným úpravám a přesunu.

**Proč se propojený Excel objekt „posune“ nebo změní velikost, když otevřu prezentaci?**

PowerPoint může obnovit náhled propojeného OLE objektu. Pro stabilní vzhled postupujte podle [Working Solution for Worksheet Resizing](/slides/cs/cpp/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah do pevného rámce a nastavte vhodný náhradní obrázek.

**Zůstanou v PPTX formátu zachovány relativní cesty k propojeným OLE objektům?**

V PPTX není informace o „relativní cestě“ dostupná – pouze úplná cesta. Relativní cesty jsou k dispozici ve starším formátu PPT. Pro přenositelnost upřednostňujte spolehlivé absolutní cesty/přístupné URI nebo vložení.