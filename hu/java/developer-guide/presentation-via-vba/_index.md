---
title: VBA projektek kezelése prezentációkban Java-val
linktitle: Prezentáció VBA-val
type: docs
weight: 250
url: /hu/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és módosíthat PowerPoint és OpenDocument prezentációkat VBA segítségével az Aspose.Slides for Java használatával a munkafolyamat egyszerűsítése érdekében."
---
## **Bevezetés**

Az Aspose.Slides osztályokat és interfészeket biztosít a makrókkal és a VBA kóddal való munkához.

{{% alert title="Note" color="warning" %}} 

Amikor egy makrókat tartalmazó prezentációt átalakít egy másik fájlformátumba (PDF, HTML stb.), az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrehozott fájlba).

Amikor makrókat ad hozzá egy prezentációhoz vagy újra ment egy makrókat tartalmazó prezentációt, az Aspose.Slides egyszerűen csak a makrók bájtjait írja.

Az Aspose.Slides **soha** nem futtatja a prezentáció makróit.

{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides biztosítja a [VbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/vbaproject/) osztályt, amely lehetővé teszi VBA projektek (és projekt hivatkozások) létrehozását, valamint létező modulok szerkesztését. A [IVbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivbaproject/) interfészt használhatja a prezentációba beágyazott VBA kezeléséhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
1. Használja a [VbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/vbaproject/#VbaProject--) konstruktort egy új VBA projekt hozzáadásához.  
1. Adjon hozzá egy modult a VbaProject-hez.  
1. Állítsa be a modul forráskódját.  
1. Adjon hozzá hivatkozásokat a <stdole>-hoz.  
1. Adjon hozzá hivatkozásokat a **Microsoft Office**-hoz.  
1. Rendelje hozzá a hivatkozásokat a VBA projekthez.  
1. Mentse a prezentációt.

Ez a Java kód bemutatja, hogyan lehet egy VBA makrót a semmiből hozzáadni egy prezentációhoz:

```java
// Létrehoz egy példányt a prezentáció osztályból
Presentation pres = new Presentation();
try {
    // Létrehoz egy új VBA projektet
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
   
    // Mentse a prezentációt
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Érdemes megnézni az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) nevű ingyenes webalkalmazást, amely a PowerPoint, Excel és Word dokumentumok makróinak eltávolítására szolgál. 

{{% /alert %}} 

## **VBA makrók eltávolítása**

A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztály alatti [VbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getVbaProject--) tulajdonság használatával eltávolíthat egy VBA makrót.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó prezentációt.  
1. A Makró modulhoz férjen hozzá, és távolítsa el.  
1. Mentse a módosított prezentációt.

Ez a Java kód bemutatja, hogyan lehet eltávolítani egy VBA makrót:

```java
// Betölti a makrót tartalmazó prezentációt
Presentation pres = new Presentation("VBA.pptm");
try {
    // Eléri a Vba modult és eltávolítja 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Mentse a prezentációt
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA makrók kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó prezentációt.  
2. Ellenőrizze, hogy a prezentáció tartalmaz-e VBA Project-et.  
3. Iteráljon végig a VBA Projectben található összes modulen a makrók megtekintéséhez.

Ez a Java kód bemutatja, hogyan lehet kinyerni a VBA makrókat egy makrókat tartalmazó prezentációból:

```java
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

## **Annak ellenőrzése, hogy egy VBA Project jelszóval védett-e**

A [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) metódus használatával meghatározhatja, hogy a projekt tulajdonságai jelszóval védettek-e.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból, és töltse be egy makrót tartalmazó prezentációt.  
2. Ellenőrizze, hogy a prezentáció tartalmaz-e [VBA projektet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/vbaproject/).  
3. Ellenőrizze, hogy a VBA projekt jelszóval védett-e a tulajdonságok megtekintéséhez.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Ellenőrizze, hogy a prezentáció tartalmaz-e VBA projektet.
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

**Mi történik a makrókkal, ha PPTX formátumban mentem a prezentációt?**

A makrók el lesznek távolítva, mert a PPTX nem támogatja a VBA-t. A makrók megtartásához válassza a PPTM, PPSM vagy POTM formátumot.

**Futtathatja az Aspose.Slides a makrókat a prezentációban, például adatok frissítésére?**

Nem. A könyvtár soha nem hajtja végre a VBA kódot; a végrehajtás csak a megfelelő biztonsági beállításokkal rendelkező PowerPointban lehetséges.

**Támogatott a VBA kóddal összekapcsolt ActiveX vezérlőkkel való munka?**

Igen, elérheti a meglévő [ActiveX vezérlőket](/slides/hu/java/activex/), módosíthatja azok tulajdonságait, és eltávolíthatja őket. Ez akkor hasznos, amikor a makrók interakcióba lépnek az ActiveX-szel.