---
title: VBA projektek kezelése bemutatókban Androidon
linktitle: Bemutató VBA-val
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
- bemutató
- Android
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és módosíthat PowerPoint és OpenDocument bemutatókat VBA-val az Aspose.Slides for Android Java segítségével, hogy hatékonyabbá tegye munkafolyamatát."
---
## **Bevezetés**

Az Aspose.Slides osztályokat és interfészeket biztosít a makrókkal és VBA kóddal való munkához.

{{% alert title="Megjegyzés" color="warning" %}} 

Amikor egy makrókat tartalmazó bemutatót átalakít más fájlformátumba (PDF, HTML stb.), az Aspose.Slides figyelmen kívül hagyja a makrókat (a makrók nem kerülnek át a létrehozott fájlba).

Amikor makrókat ad hozzá egy bemutatóhoz, vagy újra ment egy makrókat tartalmazó bemutatót, az Aspose.Slides egyszerűen kiírja a makrók bájtjait.

Az Aspose.Slides **soha** nem futtatja a bemutató makróit.

{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides biztosítja a [VbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/vbaproject/) osztályt, amely lehetővé teszi VBA projektek (és projekt hivatkozások) létrehozását és meglévő modulok szerkesztését. Használhatja a [IVbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivbaproject/) interfészt a bemutatóba beágyazott VBA kezelésére.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
2. Használja a [VbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/vbaproject/#VbaProject--) konstruktort új VBA projekt hozzáadásához.
3. Adjon egy modult a VbaProject-hez.
4. Állítsa be a modul forráskódját.
5. Adjon hivatkozásokat a <stdole>-hez.
6. Adjon hivatkozásokat a **Microsoft Office**-ra.
7. Kapcsolja össze a hivatkozásokat a VBA projekttel.
8. Mentse el a bemutatót.

Ez a Java kód bemutatja, hogyan lehet egy VBA makrót a semmiből hozzáadni egy bemutatóhoz:

```java
// Létrehozza a prezentáció osztály egy példányát
Presentation pres = new Presentation();
try {
    // Létrehozza az új VBA projektet
    pres.setVbaProject(new VbaProject());
    
    // Üres modult ad a VBA projekthez
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Beállítja a modul forráskódját
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Létrehozza a <stdole> hivatkozást
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Létrehozza az Office hivatkozást
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Hozzáadja a hivatkozásokat a VBA projekthez
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Elmenti a prezentációt
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Érdemes megnézni a **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) ingyenes webalkalmazást, amely a PowerPoint, Excel és Word dokumentumokból távolítja el a makrókat. 

{{% /alert %}} 

## **VBA makrók eltávolítása**

A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztály [VbaProject](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getVbaProject--) tulajdonságának használatával eltávolíthat egy VBA makrót.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó bemutatót.
2. Hozzáfér a Makró modulhoz, és eltávolítja azt.
3. Mentse el a módosított bemutatót.

Ez a Java kód bemutatja, hogyan lehet eltávolítani egy VBA makrót:

```java
// Betölti a makrót tartalmazó prezentációt
Presentation pres = new Presentation("VBA.pptm");
try {
    // Eléri a Vba modult és eltávolítja 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Elmenti a prezentációt
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA makrók kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó bemutatót.
2. Ellenőrizze, hogy a bemutató tartalmaz-e VBA projektet.
3. Iteráljon a VBA Projektben található összes modulon a makrók megtekintéséhez.

Ez a Java kód bemutatja, hogyan lehet kinyerni a VBA makrókat egy makrókat tartalmazó bemutatóból:

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

## **VBA projekt jelszóval védett-e ellenőrzése**

Az [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) metódus segítségével meghatározhatja, hogy egy projekt tulajdonságai jelszóval védettek-e.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, és töltse be a makrót tartalmazó bemutatót.
2. Ellenőrizze, hogy a bemutató tartalmaz-e [VBA projektet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/vbaproject/).
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

**Mi történik a makrókkal, ha a bemutatót PPTX formátumban mentem?**

A makrók eltávolításra kerülnek, mivel a PPTX nem támogatja a VBA-t. A makrók megőrzéséhez válassza a PPTM, PPSM vagy POTM formátumot.

**Futtathatja az Aspose.Slides a bemutatóban a makrókat, például adatok frissítésére?**

Nem. A könyvtár soha nem hajtja végre a VBA kódot; a végrehajtás csak a PowerPointban lehetséges a megfelelő biztonsági beállításokkal.

**Támogatott-e az ActiveX vezérlőkkel, amelyek VBA kódhoz vannak kapcsolva, való munka?**

Igen, elérheti a meglévő [ActiveX vezérlőket](/slides/hu/androidjava/activex/), módosíthatja azok tulajdonságait, és eltávolíthatja őket. Ez hasznos, ha a makrók az ActiveX-szel kommunikálnak.