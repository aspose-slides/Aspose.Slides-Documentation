---
title: VBA projektek kezelése bemutatókban C++ segítségével
linktitle: Bemutató VBA-val
type: docs
weight: 250
url: /hu/cpp/presentation-via-vba/
keywords:
- makró
- VBA
- VBA makró
- makró hozzáadása
- makró eltávolítása
- makró kinyerése
- VBA hozzáadása
- VBA eltávolítása
- VBA kinyerése
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és módosíthat PowerPoint és OpenDocument bemutatókat VBA-val az Aspose.Slides for C++ segítségével, hogy egyszerűsítse munkafolyamatát."
---
## **Bevezetés**

Az [Aspose.Slides.Vba](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.vba/) névtér osztályokat és interfészeket tartalmaz a makrókkal és a VBA kóddal való munkához.

{{% alert title="Note" color="warning" %}} 

Amikor egy makrókat tartalmazó bemutatót konvertálsz egy másik fájlformátumba (PDF, HTML, stb.), az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrejövő fájlba).

Amikor makrókat adsz egy bemutatóhoz, vagy újra mented a makrókat tartalmazó bemutatót, az Aspose.Slides egyszerűen csak a makrók bájtait írja.

Az Aspose.Slides **soha** nem futtatja a makrókat egy bemutatóban.

{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides biztosítja a [VbaProject](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.vba.vba_project) osztályt, amely lehetővé teszi VBA projektek (és projekt hivatkozások) létrehozását, valamint meglévő modulok szerkesztését. Használhatod a [IVbaProject](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.vba.i_vba_project/) interfészt a bemutatóba ágyazott VBA kezeléséhez.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Használd a [VbaProject](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) konstruktorát új VBA projekt hozzáadásához.  
3. Adj egy modult a VbaProject-hez.  
4. Állítsd be a modul forráskódját.  
5. Adj hivatkozásokat a <stdole>-hez.  
6. Adj hivatkozásokat a **Microsoft Office**-hoz.  
7. Kapcsold össze a hivatkozásokat a VBA projekttel.  
8. Mentsd el a bemutatót.

Ez a C++ kód megmutatja, hogyan adhatsz hozzá egy VBA makrót alapoktól egy bemutatóhoz: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Létrehozza a Presentation osztály egy példányát
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Létrehozza az új VBA projektet
presentation->set_VbaProject(MakeObject<VbaProject>());

// Üres modult ad hozzá a VBA projekthez
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Beállítja a modul forráskódját
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Létrehozza a <stdole> hivatkozást
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Létrehozza az Office hivatkozást
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Hivatkozásokat ad a VBA projekthez
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Mentés a bemutató
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 

Érdemes megnézned az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) alkalmazást, amely egy ingyenes webes eszköz a makrók eltávolítására a PowerPoint, Excel és Word dokumentumokból. 

{{% /alert %}} 

## **VBA makrók eltávolítása**

A [VbaProject](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) tulajdonságot a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály alatt használva eltávolíthatod a VBA makrót.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltsd be a makrót tartalmazó bemutatót.  
2. Érd el a Macro modult, és távolítsd el.  
3. Mentsd el a módosított bemutatót.

Ez a C++ kód megmutatja, hogyan távolíthatsz el egy VBA makrót: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Betölti a makrót tartalmazó bemutatót
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Eléri a Vba modult és eltávolítja
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Mentés a bemutató
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA makrók kinyerése**

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltsd be a makrót tartalmazó bemutatót.  
2. Ellenőrizd, hogy a bemutató tartalmaz-e VBA Project-et.  
3. Iterálj végig a VBA Project összes modulján a makrók megtekintéséhez.

Ez a C++ kód megmutatja, hogyan nyerheted ki a VBA makrókat egy makrókat tartalmazó bemutatóból: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// A dokumentumok könyvtárának elérési útja.
	const String templatePath = u"../templates/VBA.pptm";

	// Betölti a makrót tartalmazó bemutatót
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Ellenőrzi, hogy a bemutató tartalmaz-e VBA projektet
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **Annak ellenőrzése, hogy egy VBA projekt jelszóval védett-e**

A [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/hu/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) tulajdonság használatával meghatározhatod, hogy egy projekt tulajdonságai jelszóval védettek-e.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, és tölts be egy makrót tartalmazó bemutatót.  
2. Ellenőrizd, hogy a bemutató tartalmaz-e [VBA projektet](https://reference.aspose.com/slides/hu/cpp/aspose.slides.vba/vbaproject/).  
3. Ellenőrizd, hogy a VBA projekt jelszóval védett-e a tulajdonságai megtekintéséhez.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Ellenőrzi, hogy a bemutató tartalmaz-e VBA projektet.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **GYIK**

### Mi történik a makrókkal, ha a bemutatót PPTX formátumban mentem?

A makrók eltávolításra kerülnek, mert a PPTX nem támogatja a VBA-t. A makrók megtartásához válaszd a PPTM, PPSM vagy POTM formátumot.

### Futathatja az Aspose.Slides a makrókat a bemutatóban, például az adatok frissítéséhez?

Nem. A könyvtár soha nem hajtja végre a VBA kódot; a futtatás csak a PowerPointban lehetséges a megfelelő biztonsági beállításokkal.

### Támogatott-e az ActiveX vezérlőkkel, amelyek VBA kódra hivatkoznak, való munka?

Igen, elérheted a meglévő [ActiveX vezérlőket](/slides/hu/cpp/activex/), módosíthatod a tulajdonságaikat, és eltávolíthatod őket. Ez akkor hasznos, amikor a makrók ActiveX-szel lépnek interakcióba.