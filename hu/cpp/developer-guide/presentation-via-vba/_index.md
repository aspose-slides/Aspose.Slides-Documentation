---
title: "VBA projektek kezelése bemutatókban C++ használatával"
linktitle: "Bemutató VBA-val"
type: docs
weight: 250
url: /hu/cpp/presentation-via-vba/
keywords:
- "makró"
- "VBA"
- "VBA makró"
- "makró hozzáadása"
- "makró eltávolítása"
- "makró kinyerése"
- "VBA hozzáadása"
- "VBA eltávolítása"
- "VBA kinyerése"
- "PowerPoint"
- "OpenDocument"
- "bemutató"
- "C++"
- "Aspose.Slides"
description: "Fedezd fel, hogyan hozhatsz létre és manipulálhatsz PowerPoint és OpenDocument bemutatókat VBA-n keresztül az Aspose.Slides for C++ segítségével, hogy hatékonyabbá tedd a munkafolyamatod."
---
## **Bevezetés**

Az [Aspose.Slides.Vba](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.vba/) névtér osztályokat és interfészeket tartalmaz a makrókkal és a VBA kóddal való munkához.

{{% alert title="Megjegyzés" color="warning" %}} 
Amikor egy makrókat tartalmazó bemutatót más fájlformátumba (PDF, HTML stb.) konvertálsz, az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrehozott fájlba).

Amikor makrókat adsz egy bemutatóhoz vagy újra mented a makrókat tartalmazó bemutatót, az Aspose.Slides egyszerűen a makrók bájtait írja.

Az Aspose.Slides **soha** nem futtatja a makrókat egy bemutatóban.
{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides a [VbaProject](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.vba.vba_project) osztályt biztosítja, hogy VBA projekteket (és projekt hivatkozásokat) hozz létre, és meglévő modulokat szerkessz. A [IVbaProject](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.vba.i_vba_project/) interfészt használhatod a bemutatóba beágyazott VBA kezelésére.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.  
2. Használd a [VbaProject](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) konstruktorát egy új VBA projekt hozzáadásához.  
3. Adj hozzá egy modult a VbaProject-hez.  
4. Állítsd be a modul forráskódját.  
5. Adj hozzá hivatkozásokat a <stdole>-hez.  
6. Adj hozzá hivatkozásokat a **Microsoft Office**-hoz.  
7. Társítsd a hivatkozásokat a VBA projekthez.  
8. Mentsd el a bemutatót.

Ez a C++ kód azt mutatja be, hogyan adhatunk hozzá egy VBA makrót a semmiből egy bemutatóhoz: 

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Létrehozza a Presentation osztály példányát
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

// Mentés a prezentációt
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 
Érdemes megnézned az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) oldalt, amely egy ingyenes webalkalmazás a makrók eltávolításához PowerPoint, Excel és Word dokumentumokból. 
{{% /alert %}} 

## **VBA makrók eltávolítása**

A [VbaProject](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) tulajdonságot a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztály alatt használva eltávolíthatod a VBA makrót.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltsd be a makrót tartalmazó bemutatót.  
2. Érd el a Makró modult, és távolítsd el.  
3. Mentsd el a módosított bemutatót.

Ez a C++ kód azt mutatja be, hogyan távolítható el egy VBA makró: 

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Betölti a makrót tartalmazó bemutatót
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Eléri a Vba modult, és eltávolítja 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Mentés a prezentációt
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA makrók kinyerése**

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltsd be a makrót tartalmazó bemutatót.  
2. Ellenőrizd, hogy a bemutató tartalmaz-e VBA projektet.  
3. Iterálj végig a VBA Projektben található összes modulon a makrók megtekintéséhez.

Ez a C++ kód azt mutatja be, hogyan nyerhetők ki VBA makrók egy makrókat tartalmazó bemutatóból: 

```c++

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

## **Ellenőrizd, hogy a VBA projekt jelszóval védett-e**

Az [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/hu/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) tulajdonság használatával meghatározhatod, hogy egy projekt tulajdonságai jelszóval védettek-e.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, és tölts be egy makrót tartalmazó bemutatót.  
2. Ellenőrizd, hogy a bemutató tartalmaz-e egy [VBA project](https://reference.aspose.com/slides/hu/cpp/aspose.slides.vba/vbaproject/) elemet.  
3. Ellenőrizd, hogy a VBA projekt jelszóval védett-e, hogy megtekinthesd annak tulajdonságait.

```cpp
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

**Mi történik a makrókkal, ha PPTX formátumban mentem a bemutatót?**  
A makrók eltávolításra kerülnek, mivel a PPTX nem támogatja a VBA-t. A makrók megtartásához válaszd a PPTM, PPSM vagy POTM formátumot.

**Futtathatja az Aspose.Slides a makrókat egy bemutatóban, például adatfrissítéshez?**  
Nem. A könyvtár soha nem hajt végre VBA kódot; a végrehajtás csak a PowerPointban lehetséges a megfelelő biztonsági beállításokkal.

**Támogatott-e az ActiveX vezérlők VBA kóddal való kapcsolatának kezelése?**  
Igen, elérheted a meglévő [ActiveX controls](/slides/hu/cpp/activex/) elemeket, módosíthatod azok tulajdonságait, és eltávolíthatod őket. Ez akkor hasznos, ha a makrók az ActiveX-szel kommunikálnak.