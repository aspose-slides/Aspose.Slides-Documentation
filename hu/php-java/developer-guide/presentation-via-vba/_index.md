---
title: VBA projektek kezelése bemutatókban PHP használatával
linktitle: Bemutató VBA-val
type: docs
weight: 250
url: /hu/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Fedezze fel, hogyan lehet VBA-val PowerPoint és OpenDocument bemutatókat létrehozni és manipulálni az Aspose.Slides PHP (Java) segítségével a munkafolyamat optimalizálása érdekében."
---
## **Bevezetés**

Az Aspose.Slides API osztályokat tartalmaz a makrókkal és VBA kóddal való munkához.

{{% alert title="Megjegyzés" color="warning" %}} 

Ha egy makrókat tartalmazó bemutatót más fájlformátumba (PDF, HTML stb.) konvertálsz, az Aspose.Slides figyelmen kívül hagyja az összes makrót (a makrók nem kerülnek át a létrejövő fájlba).

Ha makrókat adsz hozzá egy bemutatóhoz, vagy újra mented a makrókat tartalmazó bemutatót, az Aspose.Slides egyszerűen csak a makrók bájtait írja.

Az Aspose.Slides **soha** nem futtatja a bemutató makróit.

{{% /alert %}}

## **VBA makrók hozzáadása**

Az Aspose.Slides biztosítja a [VbaProject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/vbaproject/) osztályt, amely lehetővé teszi VBA projektek (és projekthelyes hivatkozások) létrehozását, valamint a meglévő modulok szerkesztését. A `VbaProject` osztály segítségével kezelheted a bemutatóba beágyazott VBA-t.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból.
1. Használd a [VbaProject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/vbaproject/#VbaProject) konstruktorát új VBA projekt hozzáadásához.
1. Adj hozzá egy modult a VbaProject-hez.
1. Állítsd be a modul forráskódját.
1. Adj hozzá hivatkozásokat a <stdole>-hez.
1. Adj hozzá hivatkozásokat a **Microsoft Office**-hoz.
1. Kapcsold össze a hivatkozásokat a VBA projekttel.
1. Mentse a bemutatót.

Ez a PHP kód bemutatja, hogyan adhatunk hozzá egy VBA makrót a semmiből egy bemutatóhoz:

```php
  # Létrehoz egy példányt a bemutató osztályból
  $pres = new Presentation();
  try {
    # Létrehoz egy új VBA projektet
    $pres->setVbaProject(new VbaProject());
    # Üres modult ad a VBA projekthez
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Beállítja a modul forráskódját
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Létrehoz egy hivatkozást a <stdole>-re
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Létrehoz egy hivatkozást az Office-ra
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Hivatkozásokat ad a VBA projekthez
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Elmenti a bemutatót
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Érdemes megnézni az **Aspose** [Macro Remover](https://products.aspose.app/slides/hu/remove-macros) ingyenes webalkalmazást, amely a PowerPoint, Excel és Word dokumentumokból távolítja el a makrókat. 

{{% /alert %}} 

## **VBA makrók eltávolítása**

A [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztály alatt található [VbaProject](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getVbaProject) tulajdonság használatával eltávolíthatod a VBA makrót.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból, és töltsd be a makrót tartalmazó bemutatót.
1. Érd el a Macro modult, és távolítsd el.
1. Mentse a módosított bemutatót.

Ez a PHP kód bemutatja, hogyan távolíthatod el egy VBA makrót:

```php
  # Betölti a makrót tartalmazó bemutatót
  $pres = new Presentation("VBA.pptm");
  try {
    # Eléri a Vba modult és eltávolítja
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Elmenti a bemutatót
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **VBA makrók kinyerése**

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból, és töltsd be a makrót tartalmazó bemutatót.
2. Ellenőrizd, hogy a bemutató tartalmaz-e VBA projektet.
3. Iterálj végig a VBA projektben található összes modulon a makrók megtekintéséhez.

Ez a PHP kód bemutatja, hogyan nyerheted ki a VBA makrókat egy makrókat tartalmazó bemutatóból:

```php
  # Betölti a makrót tartalmazó bemutatót
  $pres = new Presentation("VBA.pptm");
  try {
    # Ellenőrzi, hogy a bemutató tartalmaz-e VBA projektet
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ellenőrizze, hogy egy VBA projekt jelszóval védett-e**

A [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/hu/php-java/aspose.slides/vbaproject/#isPasswordProtected) metódus használatával meghatározhatod, hogy a projekt tulajdonságai jelszóval védettek-e.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból, és tölts be egy makrót tartalmazó bemutatót.
2. Ellenőrizd, hogy a bemutató tartalmazza-e a [VBA projektet](https://reference.aspose.com/slides/hu/php-java/aspose.slides/vbaproject/).
3. Ellenőrizd, hogy a VBA projekt jelszóval védett-e, hogy megtekinthesd a tulajdonságait.

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Ellenőrizze, hogy a bemutató tartalmaz-e VBA projektet.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Mi történik a makrókkal, ha a bemutatót PPTX formátumban mentem?**

A makrók eltávolításra kerülnek, mert a PPTX nem támogatja a VBA-t. A makrók megtartásához válaszd a PPTM, PPSM vagy POTM formátumot.

**Futtathatja az Aspose.Slides a makrókat egy bemutatóban, például adatfrissítésre?**

Nem. A könyvtár soha nem hajtja végre a VBA kódot; a végrehajtás csak a megfelelő biztonsági beállításokkal rendelkező PowerPointban lehetséges.

**Támogatott-e az ActiveX vezérlők VBA kóddal való összekapcsolása?**

Igen, elérheted a meglévő [ActiveX vezérlőket](/slides/hu/php-java/activex/), módosíthatod a tulajdonságaikat, és eltávolíthatod őket. Ez hasznos, ha a makrók az ActiveX-szel kommunikálnak.