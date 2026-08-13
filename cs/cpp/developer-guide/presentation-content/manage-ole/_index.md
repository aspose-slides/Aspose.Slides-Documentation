---
title: Správa OLE v prezentacích pomocí C++
linktitle: Správa OLE
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
description: "Optimalizujte správu OLE objektů v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro C++. Vkládejte, aktualizujte a exportujte OLE obsah bez problémů."
---
## **Úvod**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) je technologie Microsoftu, která umožňuje umístit data a objekty vytvořené v jedné aplikaci do jiné aplikace pomocí propojení nebo vkládání. 

{{% /alert %}} 

Uvažujte o grafu vytvořeném v MS Excel. Tento graf je poté umístěn do snímku PowerPointu. Tento Excel graf je považován za OLE objekt. 

- OLE objekt se může zobrazit jako ikona. V takovém případě se po dvojitém kliknutí na ikonu otevře graf v přidružené aplikaci (Excel), nebo budete vyzváni k výběru aplikace pro otevření či úpravu objektu. 
- OLE objekt může zobrazit svůj skutečný obsah, například obsah grafu. V tomto případě se graf aktivuje v PowerPointu, načte se rozhraní grafu a můžete upravovat data grafu přímo v PowerPointu.

[Aspose.Slides for C++](https://products.aspose.com/slides/cs/cpp/) vám umožňuje vložit OLE objekty do snímků jako OLE rámce objektů ([OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/)).

## **Přidání OLE rámců objektů do snímků**

Pokud jste již vytvořili graf v Microsoft Excel a chcete jej vložit do snímku jako OLE rámec objektu pomocí Aspose.Slides for C++, můžete to provést takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Přečtěte soubor Excel jako pole bajtů.  
4. Přidejte [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) do snímku a zahrňte pole bajtů a další informace o OLE objektu.  
5. Zapište upravenou prezentaci jako soubor PPTX.  

V níže uvedeném příkladu jsme přidali graf ze souboru Excel do snímku jako [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) pomocí Aspose.Slides for C++. **Poznámka**: konstruktor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) přijímá jako druhý parametr příponu vkládaného objektu. Tato přípona umožňuje PowerPointu správně interpretovat typ souboru a zvolit správnou aplikaci pro otevření tohoto OLE objektu.

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

### **Přidání propojených OLE rámců objektů**

Aspose.Slides for C++ vám umožňuje přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) bez vkládání dat, ale pouze s odkazem na soubor.

Tento C++ kód vám ukazuje, jak přidat [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/) s odkazovaným souborem Excel do snímku:

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

// Přidejte rámec OLE objektu s propojeným souborem Excel.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Přístup k OLE rámcům objektů**

Pokud je OLE objekt již vložen do snímku, můžete jej snadno najít nebo získat přístup tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Získejte přístup k tvaru [OleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku pouze jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/). To byl požadovaný OLE rámec objektu, ke kterému jsme chtěli získat přístup.  
4. Jakmile získáte přístup k OLE rámci objektu, můžete na něm provádět jakékoli operace.  

V níže uvedeném příkladu je přístup k OLE rámci objektu (objektu grafu Excel vloženému do snímku) a jeho souborovým datům.

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

### **Přístup k vlastnostem propojeného OLE rámce objektu**

Aspose.Slides umožňuje přístup k vlastnostem propojených OLE rámců objektů.

Tento C++ kód vám ukazuje, jak zjistit, zda je OLE objekt propojen, a poté získat cestu k propojenému souboru:

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

    // Zkontrolujte, zda je OLE objekt propojen.
    if (oleFrame->get_IsObjectLink())
    {
        // Vytiskněte úplnou cestu k propojenému souboru.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // Vytiskněte relativní cestu k propojenému souboru, pokud je k dispozici.
        // Pouze prezentace PPT mohou obsahovat relativní cestu.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **Změna dat OLE objektu**

{{% alert color="info" %}} 

V této sekci příklad kódu níže používá [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

Pokud je OLE objekt již vložen do snímku, můžete k němu snadno přistoupit a upravit jeho data tímto způsobem:

1. Načtěte prezentaci s vloženým OLE objektem vytvořením instance třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Získejte přístup k tvaru [OLEObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/). V našem příkladu jsme použili dříve vytvořený PPTX, který má na prvním snímku jeden tvar. Poté jsme tento objekt *přetypovali* na [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/). To byl požadovaný OLE rámec objektu, ke kterému jsme chtěli získat přístup.  
4. Jakmile získáte přístup k OLE rámci objektu, můžete na něm provádět jakékoli operace.  
5. Vytvořte objekt `Workbook` a přistupte k OLE datům.  
6. Získejte požadovaný `Worksheet` a upravte data.  
7. Uložte aktualizovaný `Workbook` do proudu.  
8. Změňte data OLE objektu ze proudu.  

V níže uvedeném příkladu je přístup k OLE rámci objektu (objektu grafu Excel vloženému do snímku) a jeho souborová data jsou upravena tak, aby se aktualizovala data grafu.

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

// Aspose.Cells pro C++ musí být spuštěn před tím, než jsou použity jakékoli jeho typy.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // Načíst data OLE objektu jako objekt Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // Upravit data sešitu.
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

Aspose::Cells::Cleanup();
```

## **Vkládání jiných typů souborů do snímků**

Kromě grafů Excel umožňuje Aspose.Slides for C++ vložit do snímků i jiné typy souborů. Například můžete vložit soubory HTML, PDF a ZIP jako objekty. Když uživatel dvakrát klikne na vložený objekt, automaticky se otevře ve příslušném programu, nebo je uživatel vyzván k výběru vhodného programu pro jeho otevření.

Tento C++ kód vám ukazuje, jak vložit HTML a ZIP do snímku:

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

Při práci s prezentacemi může být potřeba nahradit staré OLE objekty novými nebo nahradit nepodporovaný OLE objekt podporovaným. Aspose.Slides for C++ vám umožňuje nastavit typ souboru pro vložený objekt, což umožňuje aktualizovat data OLE rámce nebo jeho příponu.

Tento C++ kód vám ukazuje, jak nastavit typ souboru pro vložený OLE objekt na `zip`:

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

## **Nastavení obrázků ikon a názvů pro vložené objekty**

Po vložení OLE objektu se automaticky přidá náhled sestávající z obrázku ikony. Tento náhled je to, co uživatelé vidí před přístupem nebo otevřením OLE objektu. Pokud chcete v náhledu použít konkrétní obrázek a text, můžete nastavit obrázek ikony a název pomocí Aspose.Slides for C++.

Tento C++ kód vám ukazuje, jak nastavit obrázek ikony a název pro vložený objekt: 

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

// Přidejte obrázek do zdrojů prezentace.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Zabránění změně velikosti a přemístění OLE rámce objektu**

Po přidání propojeného OLE objektu do snímku prezentace a otevření prezentace v PowerPointu se může zobrazit zpráva s výzvou k aktualizaci odkazů. Kliknutí na tlačítko „Update Links“ může změnit velikost a umístění OLE rámce objektu, protože PowerPoint aktualizuje data z propojeného OLE objektu a obnoví náhled objektu. Chcete‑li zabránit PowerPointu v výzvě k aktualizaci dat objektu, nastavte metodu `set_UpdateAutomatic` rozhraní [IOleObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ioleobjectframe/) na `false`:

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

Aspose.Slides for C++ vám umožňuje extrahovat soubory vložené do snímků jako OLE objekty následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) obsahující OLE objekty, které chcete extrahovat.  
2. Projděte všechny tvary v prezentaci a získávejte tvary [OLEObjectFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/oleobjectframe/).  
3. Získejte data vložených souborů z OLE rámců objektů a zapište je na disk.  

Tento C++ kód vám ukazuje, jak extrahovat soubory vložené do snímku jako OLE objekty:

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

## **FAQ**

### Bude OLE obsah vykreslen při exportu snímků do PDF/obrázků?

To, co je na snímku viditelné, je vykresleno – ikona/náhradní obrázek (náhled). „Živý“ OLE obsah není během renderování vykonáván. V případě potřeby nastavte vlastní obrázek náhledu, aby se v exportovaném PDF zobrazoval očekávaný vzhled.

### Jak mohu uzamknout OLE objekt na snímku, aby jej uživatelé nemohli v PowerPointu přesouvat či upravovat?

Uzamkněte tvar: Aspose.Slides poskytuje [zámky na úrovni tvaru](/slides/cs/cpp/applying-protection-to-presentation/). Nejedná se o šifrování, ale účinně zabraňuje neúmyslným úpravám a přesunům.

### Proč se propojený Excel objekt „přesune“ nebo změní velikost při otevření prezentace?

PowerPoint může aktualizovat náhled propojeného OLE. Pro stabilní vzhled se řiďte postupy z [Working Solution for Worksheet Resizing](/slides/cs/cpp/working-solution-for-worksheet-resizing/) – buď přizpůsobte rámec rozsahu, nebo škálujte rozsah do pevného rámce a nastavte vhodný náhradní obrázek.

### Zůstanou relativní cesty pro propojené OLE objekty zachovány v formátu PPTX?

V PPTX nejsou informace o „relativní cestě“ k dispozici – je uložen pouze úplný odkaz. Relativní cesty se vyskytují v starším formátu PPT. Pro přenositelnost upřednostněte spolehlivé absolutní cesty/přístupné URI nebo vkládání.