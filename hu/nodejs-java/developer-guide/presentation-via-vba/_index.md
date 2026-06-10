---
title: "VBA projektek kezelése prezentációkban JavaScript segítségével"
linktitle: "Prezentáció VBA-val"
type: docs
weight: 250
url: /hu/nodejs-java/presentation-via-vba/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Hozzon létre és manipuláljon PowerPoint és OpenDocument prezentációkat VBA-val JavaScript-ben az Aspose.Slides for Node.js (Java) segítségével, hogy egyszerűsítse a munkafolyamatát."
---
## **Bevezetés**

Az Aspose.Slides osztályokat biztosít makrókkal és VBA-kóddal való munkához.

{{% alert title="Megjegyzés" color="warning" %}} 

Amikor egy makrókat tartalmazó prezentációt konvertál egy másik fájlformátumba (PDF, HTML stb.), az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrehozott fájlba).

Amikor makrókat ad egy prezentációhoz vagy újra ment egy makrókat tartalmazó prezentációt, az Aspose.Slides egyszerűen csak a makrók bájtjait írja ki.

Az Aspose.Slides **soha** nem futtatja a prezentációban lévő makrókat.

{{% /alert %}}

## **VBA-makrók hozzáadása**

Az Aspose.Slides a [VbaProject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/vbaproject/) osztályt biztosítja, amely lehetővé teszi VBA projektek (és projekt hivatkozások) létrehozását, valamint a meglévő modulok szerkesztését. A [VbaProject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/vbaproject/) osztályt használhatja a prezentációba ágyazott VBA kezelésére.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
1. Használja a [VbaProject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/vbaproject/#VbaProject--) konstruktort egy új VBA-projekt hozzáadásához.  
1. Adjon hozzá egy modult a VbaProject-hez.  
1. Állítsa be a modul forráskódját.  
1. Adjon hozzá hivatkozásokat a <stdole>-hez.  
1. Adjon hozzá hivatkozásokat a **Microsoft Office**-hoz.  
1. Társítsa a hivatkozásokat a VBA projekthez.  
1. Mentse a prezentációt.  

Ez a JavaScript kód megmutatja, hogyan lehet egy VBA makrót teljesen az elejétől hozzáadni egy prezentációhoz:

```javascript
    // Létrehozza a prezentáció osztály egy példányát
    let pres = new aspose.slides.Presentation();
    try {
        // Létrehoz egy új VBA projektet
        pres.setVbaProject(new aspose.slides.VbaProject());
        // Üres modult ad hozzá a VBA projekthez
        let module = pres.getVbaProject().getModules().addEmptyModule("Module");
        // Beállítja a modul forráskódját
        module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
        // Létrehoz egy hivatkozást a <stdole>-ra
        let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
        // Létrehoz egy hivatkozást az Office-re
        let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
        // Hivatkozásokat ad a VBA projekthez
        pres.getVbaProject().getReferences().add(stdoleReference);
        pres.getVbaProject().getReferences().add(officeReference);
        // Mentse a prezentációt
        pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{% alert color="primary" %}} 

Érdemes lehet megnézni az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) ingyenes webalkalmazást, amely makrók eltávolítására szolgál PowerPoint, Excel és Word dokumentumokból. 

{{% /alert %}} 

## **VBA-makrók eltávolítása**

A [VbaProject](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getVbaProject--) tulajdonságot a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztály alatt használva eltávolíthat egy VBA makrót.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó prezentációt.  
1. Lépjen a Makró modulhoz, és távolítsa el azt.  
1. Mentse a módosított prezentációt.  

Ez a JavaScript kód megmutatja, hogyan lehet egy VBA makrót eltávolítani:

```javascript
// Betölti a makrót tartalmazó prezentációt
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Hozzáfér a VBA modulhoz és eltávolítja
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Mentse a prezentációt
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **VBA-makrók kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó prezentációt.  
2. Ellenőrizze, hogy a prezentáció tartalmaz‑e VBA Projektet.  
3. Járja be a VBA Projektben lévő összes modult a makrók megtekintéséhez.  

Ez a JavaScript kód megmutatja, hogyan lehet VBA makrókat kinyerni egy makrókat tartalmazó prezentációból:

```javascript
// Betölti a makrót tartalmazó prezentációt
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Ellenőrzi, hogy a prezentáció tartalmaz-e VBA projektet
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Annak ellenőrzése, hogy egy VBA projekt jelszóval védett‑e**

A [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) metódus segítségével meghatározhatja, hogy egy projekt tulajdonságai jelszóval védettek‑e.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból, és töltsön be egy makrót tartalmazó prezentációt.  
2. Ellenőrizze, hogy a prezentáció tartalmaz‑e [VBA projektet](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/vbaproject/).  
3. Ellenőrizze, hogy a VBA projekt jelszóval védett‑e a tulajdonságai megtekintéséhez.  

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Ellenőrizze, hogy a prezentáció tartalmaz-e VBA projektet.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mi történik a makrókkal, ha PPTX‑ként mentem a prezentációt?**

A makrók eltávolításra kerülnek, mert a PPTX nem támogatja a VBA‑t. A makrók megtartásához válassza a PPTM, PPSM vagy POTM formátumot.

**Futtathatja az Aspose.Slides a makrókat a prezentációban, például adatfrissítéshez?**

Nem. A könyvtár soha nem hajt végre VBA kódot; a végrehajtás csak a megfelelő biztonsági beállításokkal rendelkező PowerPointban lehetséges.

**Támogatott‑e az ActiveX vezérlőkkel, VBA kóddal összekapcsolt munkavégzés?**

Igen, hozzáférhet a meglévő [ActiveX controls](/slides/hu/nodejs-java/activex/) elemekhez, módosíthatja azok tulajdonságait, illetve eltávolíthatja őket. Ez hasznos, ha a makrók ActiveX‑szel kommunikálnak.