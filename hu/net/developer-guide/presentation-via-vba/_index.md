---
title: VBA projektek kezelése prezentációkban .NET-ben
linktitle: Prezentáció VBA-val
type: docs
weight: 250
url: /hu/net/presentation-via-vba/
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
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan lehet VBA-val PowerPoint és OpenDocument prezentációkat létrehozni és módosítani az Aspose.Slides for .NET segítségével, hogy egyszerűsítse munkafolyamatait."
---
## **Bevezetés**

A [Aspose.Slides.Vba](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/) névtér osztályokat és interfészeket tartalmaz a makrókkal és a VBA kóddal való munkához.

{{% alert title="Note" color="warning" %}} 

Amikor egy makrókat tartalmazó prezentációt más fájlformátumba (PDF, HTML, stb.) konvertál, az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrehozott fájlba).

Amikor makrókat ad hozzá egy prezentációhoz vagy újra ment egy makrókat tartalmazó prezentációt, az Aspose.Slides egyszerűen a makrók bájtjait írja ki.

Az Aspose.Slides **soha** nem futtatja a prezentáció makróit.

{{% /alert %}}

## **VBA-makrók hozzáadása**

Az Aspose.Slides biztosítja a [VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/vbaproject/) osztályt, amely lehetővé teszi VBA projektek (és projekt hivatkozások) létrehozását és meglévő modulok szerkesztését. A [IVbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/ivbaproject/) interfész segítségével kezelheti a prezentációba ágyazott VBA-t.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Használja a [VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) konstruktort egy új VBA projekt hozzáadásához.
1. Adjon hozzá egy modult a VbaProjecthez.
1. Állítsa be a modul forráskódját.
1. Adjon hozzá hivatkozásokat a <stdole>-re.
1. Adjon hozzá hivatkozásokat a **Microsoft Office**-ra.
1. Kapcsolja össze a hivatkozásokat a VBA projekttel.
1. Mentse a prezentációt.

Ez a C# kód megmutatja, hogyan lehet egy VBA makrót teljesen újonnan hozzáadni egy prezentációhoz:

```c#
    // Létrehoz egy példányt a Presentation osztályból
using (Presentation presentation = new Presentation())
{
    // Létrehoz egy új VBA projektet
    presentation.VbaProject = new VbaProject();

    // Üres modult ad hozzá a VBA projekthez
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Beállítja a modul forráskódját
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Létrehoz egy hivatkozást a <stdole>-ra
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Létrehoz egy hivatkozást az Office-ra
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Hivatkozásokat ad hozzá a VBA projekthez
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Mentse a prezentációt
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Érdemes megnézni az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) ingyenes webalkalmazását, amely makrókat távolít el PowerPoint, Excel és Word dokumentumokból. 

{{% /alert %}} 

## **VBA-makrók eltávolítása**
A [VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/vbaproject/) tulajdonságot a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály alatt használva eltávolíthat egy VBA makrót.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból, és töltse be a makrót tartalmazó prezentációt.
1. Hozzáférés a Makró modulhoz, és távolítsa el azt.
1. Mentse a módosított prezentációt.

Ez a C# kód megmutatja, hogyan lehet egy VBA makrót eltávolítani:

```c#
    // Betölti a makrót tartalmazó prezentációt
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Eléri a Vba modult és eltávolítja 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Mentse a prezentációt
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA-makrók kinyerése**
1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt, és töltse be a makrót tartalmazó prezentációt.
2. Ellenőrizze, hogy a prezentáció tartalmaz‑e VBA Projectet.
3. Járja be a VBA Projectben található összes modult a makrók megtekintéséhez.

Ez a C# kód megmutatja, hogyan lehet VBA makrókat kinyerni egy makrókat tartalmazó prezentációból:

```c#
    // Betölti a makrót tartalmazó prezentációt
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Ellenőrzi, hogy a prezentáció tartalmaz-e VBA projektet
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Ellenőrizze, hogy a VBA projekt jelszóval védett‑e**

Az [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) tulajdonság segítségével megállapítható, hogy egy projekt tulajdonságai jelszóval védettek‑e.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt, és töltse be a makrót tartalmazó prezentációt.
2. Ellenőrizze, hogy a prezentáció tartalmaz‑e [VBA projectet](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/vbaproject/).
3. Ellenőrizze, hogy a VBA projekt jelszóval védett‑e a tulajdonságok megtekintéséhez.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Ellenőrzi, hogy a prezentáció tartalmaz-e VBA projektet.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **GYIK**

**Mi történik a makrókkal, ha a bemutatót PPTX formátumban mentem?**

A makrók eltávolításra kerülnek, mert a PPTX nem támogatja a VBA‑t. A makrók megtartásához válassza a PPTM, PPSM vagy POTM formátumot.

**Futtathatja‑e az Aspose.Slides a makrókat a bemutatóban, például az adatok frissítéséhez?**

Nem. A könyvtár soha nem hajtja végre a VBA kódot; a végrehajtás csak a PowerPointban lehetséges a megfelelő biztonsági beállításokkal.

**Támogatott‑e az ActiveX vezérlőkkel való munka, amelyek VBA kódra hivatkoznak?**

Igen, hozzáférhet a meglévő [ActiveX controls](/slides/hu/net/activex/) vezérlőkhöz, módosíthatja azok tulajdonságait, és eltávolíthatja őket. Ez hasznos, ha a makrók az ActiveX‑szel interakcióba lépnek.