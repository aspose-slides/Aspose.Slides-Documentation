---
title: VBA projektek kezelése prezentációkban .NET környezetben
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
description: Ismerje meg, hogyan generálhat és kezelhet PowerPoint és OpenDocument prezentációkat VBA-val az Aspose.Slides for .NET segítségével, hogy egyszerűsítse munkafolyamatát.
---
## **Bevezetés**

Az [Aspose.Slides.Vba](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/) névtér osztályokat és interfészeket tartalmaz a makrókkal és a VBA kóddal való munkához.

{{% alert title="Megjegyzés" color="warning" %}} 

Amikor egy makrókat tartalmazó prezentációt más fájlformátumba (PDF, HTML stb.) konvertál, az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrehozott fájlba).

Amikor makrókat ad hozzá egy prezentációhoz vagy újra ment egy makrókat tartalmazó prezentációt, az Aspose.Slides egyszerűen az eredeti makró bájtjait írja be.

Az Aspose.Slides **soha** nem futtatja a prezentációban található makrókat.

{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides a [VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/vbaproject/) osztályt biztosítja, amely lehetővé teszi VBA projektek (és projekt hivatkozások) létrehozását, valamint meglévő modulok szerkesztését. A [IVbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/ivbaproject/) interfészt használhatja a prezentációba ágyazott VBA kezeléséhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Használja a [VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) konstruktorát egy új VBA projekt hozzáadásához.
1. Adjon hozzá egy modult a VbaProject-hez.
1. Állítsa be a modul forráskódját.
1. Adjon hivatkozásokat a <stdole>-ra.
1. Adjon hivatkozásokat a **Microsoft Office**-ra.
1. Kapcsolja össze a hivatkozásokat a VBA projekttel.
1. Mentse el a prezentációt.

Ez a C# kód megmutatja, hogyan adhat hozzá egy VBA makrót a semmiből egy prezentációhoz:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// Létrehozza a presentation osztály egy példányát
using (Presentation presentation = new Presentation())
{
    // Létrehoz egy új VBA projektet
    presentation.VbaProject = new VbaProject();

    // Üres modult ad hozzá a VBA projekthez
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // Beállítja a modul forráskódját
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Létrehozza a <stdole> hivatkozást
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Létrehozza az Office hivatkozást
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Hivatkozásokat ad a VBA projekthez
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // Elmenti a prezentációt
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

Érdemes megtekinteni az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) ingyenes webalkalmazást, amely makrókat távolít el PowerPoint, Excel és Word dokumentumokból. 

{{% /alert %}} 

## **VBA makrók eltávolítása**
A [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztály alatt elérhető [VbaProject](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/vbaproject/) tulajdonság segítségével eltávolíthat egy VBA makrót.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból, és töltse be a makrót tartalmazó prezentációt.
1. Hozzáfér a Makró modulhoz, és eltávolítja azt.
1. Mentse el a módosított prezentációt.

Ez a C# kód megmutatja, hogyan távolíthat el egy VBA makrót:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Betölti a makrót tartalmazó prezentációt
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Hozzáfér a Vba modulhoz és eltávolítja azt
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Elmenti a prezentációt
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA makrók kinyerése**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból, és töltse be a makrót tartalmazó prezentációt.
2. Ellenőrizze, hogy a prezentáció tartalmaz‑e VBA Projektet.
3. Járja végig a VBA Projektben található összes modult a makrók megtekintéséhez.

Ez a C# kód megmutatja, hogyan nyerhet ki VBA makrókat egy makrókat tartalmazó prezentációból:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Betölti a makrót tartalmazó prezentációt
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Ellenőrizze, hogy a prezentáció tartalmaz-e VBA projektet
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Ellenőrizze, hogy egy VBA projekt jelszóval védett‑e**

Az [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) tulajdonság használatával meghatározhatja, hogy egy projekt tulajdonságai jelszóval védettek‑e.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból, és töltse be egy makrót tartalmazó prezentációt.
2. Ellenőrizze, hogy a prezentáció tartalmaz‑e egy [VBA projektet](https://reference.aspose.com/slides/hu/net/aspose.slides.vba/vbaproject/).
3. Ellenőrizze, hogy a VBA projekt jelszóval védett‑e a tulajdonságai megtekintéséhez.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Ellenőrizze, hogy a prezentáció tartalmaz-e VBA projektet.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **GYIK**

### Mi történik a makrókkal, ha PPTX formátumban mentem a prezentációt?

A makrókat eltávolítja, mert a PPTX nem támogatja a VBA‑t. A makrók megtartásához válassza a PPTM, PPSM vagy POTM formátumot.

### Az Aspose.Slides képes-e makrókat futtatni egy prezentációban, például adatok frissítéséhez?

Nem. A könyvtár soha nem hajtja végre a VBA kódot; a végrehajtás csak a PowerPointban lehetséges a megfelelő biztonsági beállításokkal.

### Támogatott‑e az ActiveX vezérlőkkel való, VBA kódra hivatkozó munka?

Igen, elérheti a meglévő [ActiveX vezérlőket](/slides/hu/net/activex/), módosíthatja azok tulajdonságait, és eltávolíthatja őket. Ez hasznos, ha a makrók ActiveX‑szel lépnek kölcsönhatásba.