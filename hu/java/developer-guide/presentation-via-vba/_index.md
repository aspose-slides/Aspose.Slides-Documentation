---
title: VBA projektek kezelése prezentációkban Java használatával
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
description: "Fedezze fel, hogyan hozhat létre és dolgozhat fel PowerPoint és OpenDocument prezentációkat VBA használatával az Aspose.Slides for Java segítségével, hogy hatékonyabbá tegye munkafolyamatát."
---
## **Bevezetés**

Az Aspose.Slides osztályokat és interfészeket biztosít a makrókkal és a VBA kóddal való munka számára.

{{% alert title="Note" color="warning" %}} 

Amikor egy makrókat tartalmazó bemutatót más fájlformátumba (PDF, HTML stb.) konvertál, az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrehozott fájlba).

Amikor makrókat ad hozzá egy bemutatóhoz vagy újra ment egy makrókat tartalmazó bemutatót, az Aspose.Slides egyszerűen a makrók bájtjait írja.

Az Aspose.Slides **soha** nem futtatja a bemutató makróit.

{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides biztosítja a [VbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/vbaproject/) osztályt, amely lehetővé teszi VBA projektek (és projekt hivatkozások) létrehozását, illetve a meglévő modulok szerkesztését. Használhatja az [IVbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivbaproject/) interfészt a bemutatóba beágyazott VBA kezeléséhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Használja a [VbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/vbaproject/#VbaProject--) konstruktorát egy új VBA projekt hozzáadásához.  
3. Adjon hozzá egy modult a VbaProject-hez.  
4. Állítsa be a modul forráskódját.  
5. Adjon hozzá hivatkozásokat a <stdole>-hez.  
6. Adjon hozzá hivatkozásokat a **Microsoft Office**-hoz.  
7. Kapcsolja össze a hivatkozásokat a VBA projekttel.  
8. Mentse a bemutatót.

Ez a Java kód megmutatja, hogyan adhat hozzá egy VBA makrót a semmiből egy bemutatóhoz:

```java
import com.aspose.slides.*;

// Létrehoz egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Létrehoz egy új VBA projektet
    pres.setVbaProject(new VbaProject());
    
    // Üres modult ad a VBA projekthez
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

Érdemes megnézni az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) ingyenes webalkalmazást, amely a PowerPoint, Excel és Word dokumentumokból távolítja el a makrókat. 

{{% /alert %}} 

## **VBA makrók eltávolítása**

A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztály alatt található [VbaProject](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getVbaProject--) tulajdonság használatával eltávolíthat egy VBA makrót.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó bemutatót.  
2. Érje el a Macro modult és távolítsa el.  
3. Mentse a módosított bemutatót.

Ez a Java kód megmutatja, hogyan távolíthat el egy VBA makrót:

```java
import com.aspose.slides.*;

// Betölti a makrót tartalmazó prezentációt
Presentation pres = new Presentation("VBA.pptm");
try {
    // Eléri a Vba modult és eltávolítja 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Mentés a prezentáció
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **VBA makrók kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból, és töltse be a makrót tartalmazó bemutatót.  
2. Ellenőrizze, hogy a bemutató tartalmaz-e VBA Project-et.  
3. Iteráljon végig a VBA Project-ben található összes modulon a makrók megtekintéséhez.

Ez a Java kód megmutatja, hogyan nyerhet ki VBA makrókat egy makrókat tartalmazó bemutatóból:

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

## **Ellenőrizze, hogy a VBA projekt jelszóval védett-e**

Az [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) metódus használatával meghatározhatja, hogy a projekt tulajdonságai jelszóval védettek-e.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból, és töltsön be egy makrót tartalmazó bemutatót.  
2. Ellenőrizze, hogy a bemutató tartalmaz-e [VBA projectet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/vbaproject/).  
3. Ellenőrizze, hogy a VBA projekt jelszóval védett-e a tulajdonságok megtekintéséhez.

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

### Mi történik a makrókkal, ha a bemutatót PPTX formátumban mentem?

A makrók eltávolításra kerülnek, mert a PPTX nem támogatja a VBA-t. A makrók megőrzéséhez válassza a PPTM, PPSM vagy POTM formátumot.

### Futtathatja az Aspose.Slides a makrókat a bemutatóban például adatok frissítésére?

Nem. A könyvtár soha nem hajtja végre a VBA kódot; a végrehajtás csak a PowerPointban lehetséges a megfelelő biztonsági beállításokkal.

### Támogatott-e az ActiveX vezérlőkkel való munka, amelyek VBA kódhoz vannak kapcsolva?

Igen, elérheti a meglévő [ActiveX vezérlőket](/slides/hu/java/activex/), módosíthatja azok tulajdonságait, és eltávolíthatja őket. Ez hasznos, ha a makrók az ActiveX-szel lépnek interakcióba.