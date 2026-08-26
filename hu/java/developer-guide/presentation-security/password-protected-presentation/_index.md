---
title: Prezentációk jelszóval védése Java-ban
linktitle: Jelszóvédelem
type: docs
weight: 20
url: /hu/java/password-protected-presentation/
keywords:
- jelszóval védett prezentáció
- megnyitási jelszó
- PowerPoint titkosítása
- PowerPoint feloldása
- prezentáció jelszavának ellenőrzése
- prezentáció jelszó ellenőrzése
- titkosított prezentáció megnyitása
- titkosítás eltávolítása
- PowerPoint
- PPT
- PPTX
- prezentáció
- Java
- Aspose.Slides
description: "Titkosítsa, észlelje, ellenőrizze, nyissa meg, és oldja fel a jelszóval védett PowerPoint PPT és PPTX prezentációkat Java-ban az Aspose.Slides segítségével."
---
## **Áttekintés**

A megnyitási jelszó titkosítja a bemutatót. A helyes jelszó szükséges a bemutató tartalmának betöltéséhez és megtekintéséhez, ezért ez a védelem titoktartást biztosít.

A megnyitási jelszó különbözik az írásvédelmi jelszótól. Az írásvédelem korlátozza a módosítást, de nem titkosítja a tartalmat, és nem akadályozza meg a bemutató betöltését. A bemutatók módosításához használt jelszavak kezeléséhez lásd a [Write-Protect Presentations](/slides/hu/java/write-protected-presentation/) oldalt.

Az alábbi munkafolyamatok PPT és PPTX bemutatókra egyaránt vonatkoznak. A példák mindkét formátumot használják, ahol a fájl- és adatfolyam-alapú viselkedés fontos.

## **Bemutató titkosítása megnyitási jelszóval**

Használja az [IProtectionManager.encrypt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-) metódust a megnyitási jelszó hozzárendeléséhez. Ezután használja az [IPresentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) metódust a titkosított bemutató mentéséhez.

A következő példa egy PPTX bemutatót titkosít:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Titkosított bemutató betöltése**

Állítsa be az [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metódust a megnyitási jelszóra, és adja át a beállításokat a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztálynak a fájl betöltésekor. A betöltés sikertelen, ha megnyitási jelszó szükséges, de a megadott jelszó hiányzik vagy helytelen.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Dolgozz a visszafejtett prezentációval.
} finally {
    presentation.dispose();
}
```

## **Titkosítás eltávolítása a bemutatóból**

Töltse be a bemutatót a hozzá tartozó megnyitási jelszóval, hívja meg a [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#removeEncryption--) metódust, és mentse el az eredményt. A mentett bemutató ezután jelszó nélkül betölthető.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Megnyitási jelszó ellenőrzése betöltés előtt**

Használja a [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) metódust, hogy [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/) objektumot kapjon anélkül, hogy teljes bemutató példányt hozna létre. Ellenőrizze a [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) értéket, mielőtt jelszót kérne vagy validálna. Ha védelem van, validálja a megadott értéket a [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) metódussal.

### **Fájlútvonal munkafolyamat**

A következő példa egy PPTX fájl megnyitási jelszavát ellenőrzi, a validált értéket átadja az [ILoadOptions.setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) metódusnak, majd betölti a teljes bemutatót:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Adatfolyam munkafolyamat**

Az [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) adatfolyam-túlterhelése ugyanazt a munkafolyamatot biztosítja. Állítsa vissza a kereshető adatfolyam pozícióját, mielőtt a teljes bemutatót betöltené ebből az adatfolyamból.

A következő példa egy PPT fájlt használ:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **checkPassword visszatérési értékek**

Az [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) csak akkor ad vissza `true` értéket, ha a bemutató megnyitási jelszóval rendelkezik, és a megadott jelszó helyes. `false` értéket ad vissza az alábbi esetekben:

- A jelszó helytelen.
- A bemutató nem rendelkezik megnyitási jelszóval.
- A megadott jelszó `null` vagy üres.

A viselkedés PPT és PPTX bemutatók esetén is ugyanaz.

## **Ellenőrizze, hogy a betöltött bemutató titkosított-e**

A bemutató helyes jelszóval történő betöltése után vizsgálja meg az [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#isEncrypted--) metódust, hogy megerősítse, a forrás bemutató titkosítva volt-e. A megnyitási jelszavas védelem betöltés előtti észleléséhez használja a `IPresentationInfo.isPasswordProtected` metódust, ahogyan fentebb bemutattuk.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Biztonsági ajánlások**

{{% alert color="warning" title="Security" %}}
Ne naplózza a megnyitási jelszavakat, és ne tartalmazza őket diagnosztikai üzenetekben. Kerülje a felesleges ismételt ellenőrzési kísérleteket, tartsa a jelszavakat a memóriában csak annyira, amennyire szükség van, és használja újra a sikeres ellenőrzés eredményét, amikor azonnal betölti a bemutatót.
{{% /alert %}}

## **Bemutató jelszóvédelem online**

1. Nyissa meg az [Aspose.Slides Lock](https://products.aspose.app/slides/hu/lock) alkalmazást.
2. Válassza ki vagy töltse fel a bemutatót.
3. Adjon meg egy jelszót a megtekintési védelemhez.
4. Opcionálisan adjon meg egy külön jelszót a szerkesztési védelemhez.
5. Alkalmazza a védelmet, és töltse le a kapott fájlt.

{{% alert color="info" title="See also" %}}
- [Írásvédelem a bemutatókra](/slides/hu/java/write-protected-presentation/)
- [Digitális aláírás PowerPointban](/slides/hu/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **GYIK**

**Mi a különbség a megnyitási jelszó és az írásvédelmi jelszó között?**

A megnyitási jelszó titkosítja a bemutatót, és szükséges a tartalmának betöltéséhez. Az írásvédelmi jelszó a módosítást korlátozza anélkül, hogy a tartalmat titkosítaná.

**Érvényesíthetek megnyitási jelszót anélkül, hogy az összes diát betölteném?**

Igen. Szerezze meg a bemutató információit, ellenőrizze, hogy van-e megnyitási jelszavas védelem, és validálja a jelszót, mielőtt teljes bemutató példányt hozna létre.

**A jelszó-ellenőrző munkafolyamatok támogatják mind a PPT, mind a PPTX formátumot?**

Igen. A fájlútvonal és adatfolyam-alapú jelszó-észlelés és validálás egyformán működik PPT és PPTX bemutatók esetén.