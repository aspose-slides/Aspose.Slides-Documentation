---
title: Spravovat OLE v prezentacích pomocí C++
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
- OLE ikona
- OLE název
- extrahovat OLE
- extrahovat objekt
- extrahovat soubor
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Optimalizujte správu OLE objektů v PowerPoint a OpenDocument souborech s Aspose.Slides pro C++. Vkládejte, aktualizujte a exportujte OLE obsah hladce."
---
## **Úvod**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) je technologie Microsoft, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vložení. 
{{% /alert %}} 

Uvažujme o grafu vytvořeném v MS Excel. Graf je poté umístěn do snímku PowerPointu. Tento graf z Excelu je považován za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V tomto případě se po dvojitém kliknutí na ikonu graf otevře v přidružené aplikaci (Excel) nebo je vás požádá o výběr aplikace pro otevření nebo úpravu objektu. 
- OLE objekt může zobrazovat svůj skutečný obsah, například obsah grafu. V tomto případě je graf aktivován v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) umožňuje vložit OLE objekty do snímků jako OLE rámy objektů ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **Přidání OLE objektových rámců do snímků**

Za předpokladu, že jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE objektový rámec pomocí Aspose.Slides for C++, můžete to provést takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přečtěte soubor Excel jako pole bajtů.
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) do snímku, který obsahuje pole bajtů a další informace o OLE objektu.
5. Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) pomocí Aspose.Slides for C++. **Poznámka** že konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) přijímá jako druhý parametr rozšíření vkládaného objektu. Toto rozšíření umožňuje PowerPointu správně interpretovat typ souboru a zvolit správnou aplikaci pro otevření tohoto OLE objektu.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Přidání propojených OLE objektových rámců**

Aspose.Slides for C++ umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) bez vložení dat, ale pouze s odkazem na soubor.

Tento C++ kód ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) s propojeným souborem Excel do snímku:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Přidat OLE objektový rámec s propojeným souborem Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Přístup k OLE objektovým rámcům**

Pokud je OLE objekt již vložený do snímku, můžete jej snadno najít nebo získat přístup tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přistupte k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) .
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jen jeden tvar. Poté jsme ten objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). To byl požadovaný OLE objektový rámec, ke kterému jsme chtěli získat přístup.
4. Jakmile je OLE objektový rámec přístupný, můžete na něm provádět libovolnou operaci.

V níže uvedeném příkladu je přístup k OLE objektovému rámci (objektu grafu Excel vloženému do snímku) a k jeho datům souboru.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

### **Přístup k vlastnostem propojeného OLE objektového rámce**

Aspose.Slides umožňuje přístup k vlastnostem propojeného OLE objektového rámce.

Tento C++ kód ukazuje, jak zkontrolovat, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // Zkontrolovat, zda je OLE objekt propojen.
    if (oleFrame->get_IsObjectLink())
    {
        // Vytisknout úplnou cestu k propojenému souboru.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Vytisknout relativní cestu k propojenému souboru, pokud existuje.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Změna dat OLE objektu**

{{% alert color="info" title="Note" %}}
V této sekci níže uvedený příklad kódu používá [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/).
{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete tento objekt snadno získat a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přistupte k tvaru [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) .
   V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Poté jsme ten objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). To byl požadovaný OLE objektový rámec, ke kterému jsme chtěli získat přístup.
4. Jakmile je OLE objektový rámec přístupný, můžete na něm provádět libovolnou operaci.
5. Vytvořte objekt `Workbook` a přistupte k OLE datům.
6. Přistupte k požadovanému `Worksheet` a upravte data.
7. Uložte aktualizovaný `Workbook` do proudu.
8. Změňte data OLE objektu z proudu.

V níže uvedeném příkladu je přístup k OLE objektovému rámci (objektu grafu Excel vloženému do snímku) a jeho data souboru jsou upravena, aby se aktualizovala data grafu.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells pro C++ musí být spuštěn před použitím jakéhokoli jeho typu.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Přečtěte data OLE objektu jako objekt Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Upravte data sešitu.
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

    // Změňte data OLE rámce objektu.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **Vkládání jiných typů souborů do snímků**

Kromě grafů Excel vám Aspose.Slides for C++ umožňuje vložit do snímků i další typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvojklikne na vložený objekt, automaticky se otevře ve příslušném programu, nebo je uživatel vyzván k výběru vhodného programu k jeho otevření.

Tento C++ kód ukazuje, jak vložit HTML a ZIP do snímku:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for C++ vám umožňuje nastavit typ souboru pro vložený objekt, což umožňuje aktualizovat data OLE rámce nebo jeho rozšíření.

Tento C++ kód ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **Nastavení obrázků ikony a titulů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled skládající se z obrázku ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete v náhledu použít konkrétní obrázek a text, můžete nastavit obrázek ikony a název pomocí Aspose.Slides for C++.

Tento C++ kód ukazuje, jak nastavit obrázek ikony a název pro vložený objekt: 

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zabránění změně velikosti a přemístění OLE objektového rámce**

Po přidání propojeného OLE objektu do snímku prezentace, když otevřete prezentaci v PowerPointu, můžete vidět zprávu vyzývající k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a pozici OLE objektového rámce, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Aby PowerPoint nevyzýval k aktualizaci dat objektu, zavolejte metodu [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) s hodnotou `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **Extrahování vložených souborů**

Aspose.Slides for C++ vám umožňuje tímto způsobem extrahovat soubory vložené do snímků jako OLE objekty:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), která obsahuje OLE objekty, které chcete extrahovat.
2. Projděte všechny tvary v prezentaci a přistupujte k tvarům [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).
3. Získejte data vložených souborů z OLE objektových rámců a zapište je na disk.

Tento C++ kód ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

**Bude OLE obsah renderován při exportu snímků do PDF/obrázků?**

Co je na snímku viditelné, se renderuje – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah během renderování není spouštěn. Pokud je potřeba, nastavte vlastní obrázek náhledu, aby výstupní PDF měl očekávaný vzhled.

Pro zachování vloženého souboru také jako přílohu PDF zavolejte [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) s hodnotou `true`. Tato volba je ve výchozím nastavení vypnutá. Příklad a instrukce pro kontrolu přílohy najdete v [Preserve Embedded OLE Files as PDF Attachments](/slides/cs/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli přesouvat/upravovat v PowerPointu?**

Uzamkněte tvar: Aspose.Slides poskytuje [shape-level locks](/slides/cs/cpp/applying-protection-to-presentation/). Není to šifrování, ale účinně zabraňuje neúmyslným úpravám a přesunům.

**Proč se propojený Excel objekt „přesouvá“ nebo mění velikost, když otevřu prezentaci?**

PowerPoint může aktualizovat náhled propojeného OLE. Pro stabilní vzhled postupujte podle praktik [Working Solution for Worksheet Resizing](/slides/cs/cpp/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah na pevný rámec a nastavte vhodný náhradní obrázek.

**Budou relativní cesty k propojeným OLE objektům zachovány ve formátu PPTX?**

V PPTX nejsou informace o „relativní cestě“ k dispozici – pouze úplná cesta. Relativní cesty jsou k dispozici ve starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vkládání.