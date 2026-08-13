---
title: VBA projektek kezelése prezentációkban Androidon
linktitle: Prezentáció VBA-val
type: docs
weight: 250
url: /hu/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan lehet VBA segítségével PowerPoint és OpenDocument prezentációkat létrehozni és módosítani az Aspose.Slides for Android Java segítségével, hogy egyszerűsítse munkafolyamatát."
---
## **Bevezetés**

Az Aspose.Slides osztályokat és interfészeket biztosít a makrókkal és VBA kóddal való munkához.

{{% alert title="Megjegyzés" color="warning" %}} 

Amikor egy makrókat tartalmazó prezentációt más fájlformátumra (PDF, HTML, stb.) konvertál, az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrehozott fájlba).

Amikor makrókat ad hozzá egy prezentációhoz vagy újra ment egy makrókat tartalmazó prezentációt, az Aspose.Slides egyszerűen a makrók bájtjait írja.

Az Aspose.Slides **soha** nem futtatja a prezentációban lévő makrókat.

{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides a [VbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/vbaproject/) osztályt biztosítja, amely lehetővé teszi VBA projektek (és projektreferenciák) létrehozását, valamint meglévő modulok szerkesztését. Használhatja az [IVbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivbaproject/) interfészt a prezentációban beágyazott VBA kezeléséhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Használja a [VbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/vbaproject/#VbaProject--) konstruktorát új VBA projekt hozzáadásához.
3. Adjon modult a VbaProject-hez.
4. Állítsa be a modul forráskódját.
5. Adjon hozzá hivatkozásokat a <stdole>-ra.
6. Adjon hozzá hivatkozásokat a **Microsoft Office**-ra.
7. Kösse össze a hivatkozásokat a VBA projekttel.
8. Mentse a prezentációt.

```java
import com.aspose.slides.*;

// Létrehozza a prezentáció osztály egy példányát
Presentation pres = new Presentation();
try {
    // Létrehozza az új VBA projektet
    pres.setVbaProject(new VbaProject());
    
    // Üres modult ad hozzá a VBA projekthez
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Beállítja a modul forráskódját
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Létrehoz egy hivatkozást a <stdole>-ra
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Létrehoz egy hivatkozást az Office-ra
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Hivatkozásokat ad a VBA projekthez
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Mentés a prezentáció
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

Érdemes megnézni az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) alkalmazást, amely egy ingyenes webalkalmazás a makrók eltávolításához a PowerPoint, Excel és Word dokumentumokból. 

{{% /alert %}} 

## **VBA makrók eltávolítása**

A [VbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getVbaProject--) tulajdonság használatával a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályon belül eltávolíthat egy VBA makrót.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó prezentációt.
2. Érje el a Makró modult, és távolítsa el azt.
3. Mentse a módosított prezentációt.

```java
import com.aspose.slides.*;

// Betölti a makrót tartalmazó prezentációt
Presentation pres = new Presentation("VBA.pptm");
try {
    // Eléri a Vba modult és eltávolítja 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Mentés a prezentációt
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA makrók kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó prezentációt.
2. Ellenőrizze, hogy a prezentáció tartalmaz‑e VBA Projektet.
3. Járja be a VBA Projektben lévő összes modult a makrók megtekintéséhez.

```java
import com.aspose.slides.*;

// Betölti a makrót tartalmazó prezentációt
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Ellenőrzi, hogy a prezentáció tartalmaz-e VBA projektet
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ellenőrizze, hogy a VBA projekt jelszóval védett‑e**

Az [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) metódus használatával meghatározhatja, hogy egy projekt tulajdonságai jelszóval védettek‑e.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltsön be egy makrót tartalmazó prezentációt.
2. Ellenőrizze, hogy a prezentáció tartalmaz‑e [VBA projektet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/vbaproject/).
3. Ellenőrizze, hogy a VBA projekt jelszóval védett‑e a tulajdonságok megtekintéséhez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Ellenőrzi, hogy a prezentáció tartalmaz-e VBA projektet.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

### Mi történik a makrókkal, ha a prezentációt PPTX formátumban mentem?

A makrók eltávolításra kerülnek, mert a PPTX nem támogatja a VBA‑t. A makrók megtartásához válassza a PPTM, PPSM vagy POTM formátumot.

### Futtathatja az Aspose.Slides a makrókat a prezentációban, például adatok frissítésére?

Nem. A könyvtár soha nem hajtja végre a VBA‑kódot; a végrehajtás csak a megfelelő biztonsági beállításokkal rendelkező PowerPointban lehetséges.

### Támogatott‑e az ActiveX vezérlőkkel, VBA kóddal összekapcsolt munkavégzés?

Igen, elérheti a meglévő [ActiveX controls](/slides/hu/androidjava/activex/), módosíthatja azok tulajdonságait, és eltávolíthatja őket. Ez akkor hasznos, ha a makrók az ActiveX‑szel lépnek interakcióba.